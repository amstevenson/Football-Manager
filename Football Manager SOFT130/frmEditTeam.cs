using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

/************************************************************************************
*                                   editTeam.cs                                     *
-------------------------------------------------------------------------------------
*                 SOFT130 ASSIGNMENT 2013 - FOOTBALL LEAGUE MANAGER                 *
************************************************************************************* 
*     COURSE              - BSC COMPUTING                                           *
*     CREATED BY          - SHARPE SOLUTIONS                                        *
*     TEAM MEMBERS        - ALEX SIMS, ADAM STEVENSON, MATT SMITH                   *
*                                                                                   *
*     NOTE                - LUKE WOODHEAD DID NOT CONTRIBUTE TO THE DEVELOPMENT     *
*                           OF THIS SOLUTION.                                       *
*                                                                                   *
************************************************************************************/

namespace Football_Manager_SOFT130
{
    public partial class frmEditTeam : Form
    {
        public static frmEditTeam frmKeepEditTeam = null; // need reference to call form back

        // MAIN ENTRY POINT...
        public frmEditTeam()
        {
            InitializeComponent();
            frmKeepEditTeam = this;
        }

        /******************************************************************
        *              EDIT TEAM - ADD THE NEW LEAGUE OBJECT              *
        ******************************************************************/
        private void frmEditTeam_Load(object sender, EventArgs e)
        {
            // populate the league combo box...
            populateLeagueBox();

            // if no team is found then display the default logo...
            if (frmMainMenu.teamSelected < -1)
            {
                picTeamLogo.ImageLocation = @"../logos/default.png";
            }

            // otherwise render the selected teams properties...
            else
            {
                getTeamDetails();

                txtTeamName.Focus();

                picTeamLogo.ImageLocation = @"../logos/" + txtTeamLogo.Text;
            }
            
        }


        /******************************************************************
        *               EDIT TEAM - EDIT THE SELECTED TEAM               *
        ******************************************************************/
        private void btnEditTeam_Click(object sender, EventArgs e)
        {
            // local variables...
            bool validationCheck = false;
            int selection;
            int fixtureReplaceCounter = 0; // index for fixture replacement (to reflect changes made to team)

            League whichLeague;
            Team whichTeam = (Team)frmMainMenu.allTeams[frmMainMenu.teamSelected];

            /* get team inputs - Team order = teamName, teamLeague, teamManager, teamNickname, teamStadium, teamPosition, teamPoints, teamGamesplayed
                                              teamGoalDifference, teamLogo, teamNumOfPlayers...                                                      */
            string tempTeamName           =  txtTeamName.Text;
            string tempTeamLeague         =  cboLeagueName.Text;
            string tempTeamManager        =  txtTeamManager.Text;
            string tempTeamNickname       =  txtTeamNickname.Text;
            string tempTeamStadium        =  txtTeamStadium.Text;
            string tempTeamPosition       =  txtTeamPosition.Text;
            string tempTeamPoints         =  txtTeamPoints.Text;
            string tempTeamGamesPlayed    =  txtTeamGamesPlayed.Text;
            string tempTeamGoalDifference =  txtTeamGoalDifference.Text;
            string tempTeamLogo           =  txtTeamLogo.Text;
            string tempTeamNumPlayers     =  txtTeamNumPlayers.Text;


            // validate the input strings...
            validationCheck = Operations.notNullTextBox(txtTeamName, "the teams name") && Operations.notNullTextBox(txtTeamManager, "the teams manager")
                           && Operations.notNullTextBox(txtTeamNickname, "the teams nickname") && Operations.notNullTextBox(txtTeamStadium, "the teams stadium")
                           && Operations.notNullTextBox(txtTeamPosition, "the teams position in the league") && Operations.notNullTextBox(txtTeamPoints, "the teams points")
                           && Operations.notNullTextBox(txtTeamGamesPlayed, "the amount of games the team has played") && Operations.notNullTextBox(txtTeamGoalDifference, "the teams goal difference")
                           && Operations.notNullTextBox(txtTeamLogo, "the teams logo") && Operations.notNullTextBox(txtTeamNumPlayers, "the amount of players on the teams");


            // create the new team object...
            if (validationCheck)
            {
                Team temp = new Team(tempTeamName, tempTeamLeague, tempTeamManager, tempTeamNickname, tempTeamStadium, Convert.ToInt32(tempTeamPosition), Convert.ToInt32(tempTeamPoints),
                                         Convert.ToInt32(tempTeamGamesPlayed), Convert.ToInt32(tempTeamGoalDifference), tempTeamLogo, Convert.ToInt32(tempTeamNumPlayers));

                // set the selected index...
                selection = cboLeagueName.SelectedIndex;

                whichLeague = (League)frmMainMenu.allLeagues[frmMainMenu.leagueSelected];

                //update fixtures to reflect the changes made to the above fields...
                foreach (Fixture F in whichLeague.getAllLeagueFixtures().ToArray())
                {
                    if (F.getFixtureHomeTeam().Contains(whichTeam.getTeamName()))
                    {
                        Fixture tempFixture = new Fixture(F.getFixtureDate(), F.getFixtureTime(), F.getFixtureLocation(), tempTeamName, F.getFixtureAwayTeam());
                        whichLeague.replaceFixture(whichLeague.getAllLeagueFixtures(), tempFixture, fixtureReplaceCounter);
                    }

                    if (F.getFixtureAwayTeam().Contains(whichTeam.getTeamName()))
                    {
                        Fixture tempFixture = new Fixture(F.getFixtureDate(), F.getFixtureTime(), F.getFixtureLocation(), F.getFixtureHomeTeam(), tempTeamName);
                        whichLeague.replaceFixture(whichLeague.getAllLeagueFixtures(), tempFixture, fixtureReplaceCounter);
                    }

                    fixtureReplaceCounter += 1;

                }

                // make amendments to team...
                whichTeam.replaceTeam(frmMainMenu.allTeams, temp, frmMainMenu.teamSelected);

                // write the fixtures to the file...
                Operations.writeAllFixtures(frmMainMenu.inputFootball, frmMainMenu.allLeagues);
                // write the new team to the file...
                Operations.writeAllTeams(frmMainMenu.inputTeams, frmMainMenu.allTeams);

                MessageBox.Show("SUCCESS: The team " + tempTeamName + " in " + tempTeamLeague + " has been edited.", "Team updated");

                frmMainMenu.frmKeepMainMenu.Show();
                frmKeepEditTeam.Close();
            }

            else
            {
                MessageBox.Show("OOPS: Something went wrong...\n\n", "Operation Aborted");
                frmMainMenu.frmKeepMainMenu.Show();
                frmKeepEditTeam.Close();
            }

        }   // end editTeam_click



        /******************************************************************
        *    EDIT TEAM - DELETE THE SELECTED TEAM AND ALL ITS FIXTURES    *
        ******************************************************************/
        private void btnDeleteTeam_Click(object sender, EventArgs e)
        {
            // local variables...
            int fixtureDeleteCounter = 0;

            Team deleteTeam;

            League whichLeague;
            whichLeague = (League)frmMainMenu.allLeagues[frmMainMenu.leagueSelected];

            deleteTeam = (Team)frmMainMenu.allTeams[frmMainMenu.teamSelected];


            DialogResult dialogResult = MessageBox.Show("Are you certain that you want to delete this team?\n\nThis function will premenanately remove them"
                                                     + " and all their associated fixtures from the system.",
                                                       "Proceed to delete team?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                // loop through all fixtures in the league...
                foreach (Fixture F in whichLeague.getAllLeagueFixtures().ToArray())
                {
                    // if the home team names match then remove the team and all its selected fixtures...
                    if (F.getFixtureHomeTeam().Contains(deleteTeam.getTeamName()))
                    {
                        whichLeague.deleteFixture(whichLeague.getAllLeagueFixtures(), F, fixtureDeleteCounter);
                        fixtureDeleteCounter -= 1;
                    }

                    // if the away team names match then remove the team and all its selected fixtures...
                    if (F.getFixtureAwayTeam().Contains(deleteTeam.getTeamName()))
                    {
                        whichLeague.deleteFixture(whichLeague.getAllLeagueFixtures(), F, fixtureDeleteCounter);
                        fixtureDeleteCounter -= 1;
                    }

                    fixtureDeleteCounter += 1;
                }

                // remove team at the selected index, dependant on the variable found in the main menu
                frmMainMenu.allTeams.RemoveAt(frmMainMenu.teamSelected);

                // rewrite the text file without the selected team...
                Operations.writeAllFixtures(frmMainMenu.inputFootball, frmMainMenu.allLeagues);
                Operations.writeAllTeams(frmMainMenu.inputTeams, frmMainMenu.allTeams);

                MessageBox.Show("Success, the team:  " + txtTeamName.Text + " and all of its fixtures have been deleted.", "Team deleted successfully.");

                frmMainMenu.frmKeepMainMenu.Show();
                frmKeepEditTeam.Close();
            }

            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Operation aborted, the team was not deleted.", "Operation Aborted Successfully");
            }
        }


        /******************************************************************
        *            EDIT TEAM - LOAD THE SELECTED TEAMS DETAILS         *
        ******************************************************************/
        private void getTeamDetails()
        {
            // set the teams selected index...
            int selectedTeam = frmMainMenu.teamSelected;

            ArrayList existingTeams = frmMainMenu.allTeams;

            // store details in a currentTeam object...
            Team currentTeam = (Team)existingTeams[selectedTeam];

            // get the teams details...
            txtTeamName.Text           = currentTeam.getTeamName();
            cboLeagueName.Text         = currentTeam.getTeamLeague();
            txtTeamManager.Text        = currentTeam.getTeamManager();
            txtTeamNickname.Text       = currentTeam.getTeamNickname();
            txtTeamStadium.Text        = currentTeam.getTeamStadium();
            txtTeamPosition.Text       = currentTeam.getTeamPosition().ToString();
            txtTeamPoints.Text         = currentTeam.getTeamPoints().ToString();
            txtTeamGamesPlayed.Text    = currentTeam.getTeamGamesPlayed().ToString();
            txtTeamGoalDifference.Text = currentTeam.getTeamGoalDifference().ToString();
            txtTeamLogo.Text           = currentTeam.getTeamLogo();
            txtTeamNumPlayers.Text     = currentTeam.getTeamNumPlayers().ToString();

        }


        /******************************************************************
        *                    EDIT TEAM - RESET THE FORM                  *
        ******************************************************************/
        private void resetForm()
        {
            txtTeamName.Text           = "";
            cboLeagueName.Text         = "";
            txtTeamManager.Text        = "";
            txtTeamNickname.Text       = "";
            txtTeamStadium.Text        = "";
            txtTeamPosition.Text       = "";
            txtTeamPoints.Text         = "";
            txtTeamGamesPlayed.Text    = "";
            txtTeamGoalDifference.Text = "";
            txtTeamLogo.Text           = "";
            txtTeamNumPlayers.Text     = "";

            picTeamLogo.ImageLocation = @"../logos/default.png";
        }


        /******************************************************************
        *             EDIT TEAM - POPULATE LEAGUE COMBO BOX               *
        ******************************************************************/
        private void populateLeagueBox()
        {
            // loop through each league in the all leagues array...
            foreach (League League in frmMainMenu.allLeagues)
            {
                // add each league to the box...
                string option;
                option = League.getLeagueName();
                cboLeagueName.Items.Add(option);
            }
        }


        /******************************************************************
        *                EDIT TEAM - GO TO THE MAIN MENU                  *
        ******************************************************************/
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            frmMainMenu.frmKeepMainMenu.Show();
            frmKeepEditTeam.Close();
        }


        /******************************************************************
        *                EDIT TEAM - SEARCH THE SYSTEM                    *
        ******************************************************************/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmEditTeam.frmKeepEditTeam.Hide();
            string searchInput = txtSearchAll.Text;
            Operations.searchItem(searchInput);
        }


        /******************************************************************
        *                EDIT TEAM - UPLOAD A NEW IMAGE                   *
        ******************************************************************/
        private void btnUpload_Click(object sender, EventArgs e)
        {
            // Create a new dialog
            OpenFileDialog myUpload = new OpenFileDialog();


            // Set a filter as to what file types can be found...
            myUpload.Filter = "All files (*.*)|*.*|Bitmap (.bmp)|*.bmp| JPEG (.jpg)|*.jpg| PNG (.png)|*.png";

            // Show the dialog, from where a user can upload an image...
            if (myUpload.ShowDialog() == DialogResult.OK)
            {
                picTeamLogo.ImageLocation = myUpload.FileName;
            }

            // set the file path...
            string filePath = picTeamLogo.ImageLocation;
            FileInfo fi = new FileInfo(filePath);
            string fileName = new DirectoryInfo(filePath).Name;

            // save the image to the bin...
            Image tempImage = Image.FromFile(fi.FullName);
            tempImage.Save(@"../logos/" + fi.Name);

            // output the correct filename for the teams logo...
            txtTeamLogo.Text = fileName;


        }


        /******************************************************************
        *         EDIT TEAM - CHECK IF A MATCH NEEDS PROCESSING           *
        ******************************************************************/
        private void btnPendingResult_Click(object sender, EventArgs e)
        {
            // check whether there are any pending results...
            if (Operations.checkPendingResults() == true)
            {
                string input = "Fixtures pending results...";
                frmSearch.frmSearchClose.Show();
                frmKeepEditTeam.Hide();

                // run the pendin searches method...
                Operations.populatePendingSearches(input);
            }

            // if there are no results pending then prompt the user...
            else
            {
                btnPendingResult.Hide();
                lblPending.Hide();
            }

        }


    }
}
