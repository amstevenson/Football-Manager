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

/************************************************************************************
*                                 frmAddTeam.CS                                     *
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
    public partial class frmAddTeam : Form
    {
        /******************************************************************
        *                   ADD TEAM - DEFINE GLOBAL VARS                 *
        ******************************************************************/
        public static frmAddTeam frmKeepAddTeam = null; // need reference to call form back
        private int tempTeamPosition;                   // access within this form only - can be found from outside of a try/catch
        private int tempTeamPoints;
        private int tempTeamGamesPlayed;
        private int tempTeamGoalDifference;
        private int tempTeamNumPlayers;

        // FORM ENTRY POINT...
        public frmAddTeam()
        {
            InitializeComponent();
            frmKeepAddTeam = this;
        }


        /******************************************************************
        *      ADD TEAM - SET FIRST FIELD FOCUS AND LOAD DEFAULT LOGO     *
        ******************************************************************/
        private void frmAddTeam_Load(object sender, EventArgs e)
        {
            txtTeamName.Focus();
            txtTeamLogo.Enabled = false;

            picTeamLogo.ImageLocation = @"../logos/default.png";
        }


        /******************************************************************
        *            ADD TEAM - ADD THE NEW TEAM TO THE TEXT FILE         *
        ******************************************************************/
        private void btnAddTeam_Click(object sender, EventArgs e)
        {
            // local vars...
            bool allInputOK = false;
            int selection;
            League whichLeague;
            string filePath = picTeamLogo.ImageLocation;

            //get inputs - TEAM ORDER = Name, Manager, Nickname, Stadium, Position, Points, Games played, Goal difference, logo, number of players
            string tempTeamName     = txtTeamName.Text;
            string tempTeamLeague   = cboLeagueName.Text;
            string tempTeamManager  = txtTeamManager.Text;
            string tempTeamNickname = txtTeamNickname.Text;
            string tempTeamStadium  = txtTeamStadium.Text;

            // input validation...
            validateInputs();

            // set the final validation rules...
            allInputOK = Operations.notNullTextBox(txtTeamName, "the Name") && Operations.notNullTextBox(txtTeamManager, "the Manager")
                         && Operations.notNullTextBox(txtTeamNickname, "the Nickname") && Operations.notNullTextBox(txtTeamStadium, "the Stadium")
                         && Operations.notNullTextBox(txtTeamPosition, "the Teams Position") && Operations.notNullTextBox(txtTeamPoints, "the Teams Points")
                         && Operations.notNullTextBox(txtTeamGamesPlayed, "the Number of Games Played") && Operations.notNullTextBox(txtTeamGoalDifference, "the Goal Difference")
                         && Operations.notNullTextBox(txtTeamLogo, "the Logo") && Operations.notNullTextBox(txtTeamNumPlayers, "the Number of Team Players");

            // set the selection...
            selection = cboLeagueName.SelectedIndex;
            whichLeague = (League)frmMainMenu.allLeagues[selection];

            string tempTeamLogo = txtTeamLogo.Text;

            // if the input is valid then add create and add the new team to the file...
            if (allInputOK)
            {
                Team tempTeam = new Team(tempTeamName, tempTeamLeague, tempTeamManager, tempTeamNickname, tempTeamStadium, tempTeamPosition,
                                          tempTeamPoints, tempTeamGamesPlayed, tempTeamGoalDifference, tempTeamLogo,
                                          tempTeamNumPlayers);  // create Team  


                whichLeague.addTeamToLeague(whichLeague.getAllLeagueTeams(), tempTeam);  // add the team to league array

                Operations.writeAllTeams(frmMainMenu.inputTeams, frmMainMenu.allTeams);  // update file 

                Operations.saveImage(filePath);                                          // save the image

                MessageBox.Show("Success: Team " + tempTeamName + " added");             // feedback to user

                resetForm();

            }

            else
            {
                MessageBox.Show("OOPS: Something went wrong, please try again!");  // feedback to user
            }

        }


        /******************************************************************
        *            ADD TEAM - POPULATE THE LEAGUE BOX ON LOAD           *
        ******************************************************************/
        private void frmAddTeam_Shown(object sender, EventArgs e)
        {
            populateLeagueBox();

            cboLeagueName.SelectedIndex = 0;
        }


        /******************************************************************
        *               ADD TEAM - POPULATE THE LEAGUE BOX                *
        ******************************************************************/
        private void populateLeagueBox()
        {
            // loop through each league in the all leagues arraylist...
            foreach (League League in frmMainMenu.allLeagues)
            {
                string option;
                option = League.getLeagueName();
                cboLeagueName.Items.Add(option);
            }
        }


        /******************************************************************
        *                   ADD TEAM - RESET ALL FIELDS                   *
        ******************************************************************/
        private void resetForm()
        {
            // get inputs - TEAM ORDER = Name, Manager, Nickname, Stadium, Position, Points, Games played, Goal difference, logo, number of players
            txtTeamName.Text = "";
            cboLeagueName.Text = "";
            txtTeamManager.Text = "";
            txtTeamNickname.Text = "";
            txtTeamStadium.Text = "";
            txtTeamPosition.Text = "";
            txtTeamPoints.Text = "";
            txtTeamGamesPlayed.Text = "";
            txtTeamGoalDifference.Text = "";
            txtTeamLogo.Text = "";
            txtTeamNumPlayers.Text = "";
            txtTeamName.Focus();

            // set the picture box back to its default image
            picTeamLogo.ImageLocation = @"../logos/default.png";
        }


        /******************************************************************
        *               ADD TEAM - VALIDATE THE FORM INPUTS               *
        ******************************************************************/
        private void validateInputs()
        { 
        try
            {
                tempTeamPosition = Convert.ToInt32(txtTeamPosition.Text);
            }

            catch (FormatException)
            {
                MessageBox.Show("Please enter a number for the team position", "Invalid Position");
                txtTeamPosition.Text = "";
            }

            try
            {
                tempTeamPoints = Convert.ToInt32(txtTeamPoints.Text);
            }

            catch (FormatException)
            {
                MessageBox.Show("Please enter a number for the team points", "Invalid Team Points");
                txtTeamPoints.Text = "";
            }

            try
            {
                tempTeamGamesPlayed = Convert.ToInt32(txtTeamGamesPlayed.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a number for the games played", "Invalid Games-Played");
                txtTeamGamesPlayed.Text = "";
            }

            try
            {
                tempTeamGoalDifference = Convert.ToInt32(txtTeamGoalDifference.Text);
            }

            catch (FormatException)
            {
                MessageBox.Show("Please enter a number for the goal difference", "Invalid Goal-Difference");
                txtTeamGoalDifference.Text = "";
            }

            try
            {
                tempTeamNumPlayers = Convert.ToInt32(txtTeamNumPlayers.Text);
            }

            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number of team players", "Invalid Number of Players");
                txtTeamNumPlayers.Text = "";
            }

            // check to see if the squad is of a minimum size...
            if (tempTeamNumPlayers < 12)
            {
                MessageBox.Show("Please enter a valid number of team players ( must be more than 12 ).", "Invalid Number of Players");
                txtTeamNumPlayers.Text = "";
            }
        }


        /******************************************************************
        *                 ADD TEAM - GO TO THE MAIN MENU                  *
        ******************************************************************/
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            frmMainMenu.frmKeepMainMenu.Show();
            frmKeepAddTeam.Close();
        }


        /******************************************************************
        *                 ADD TEAM - UPLOAD A NEW PICTURE                 *
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
        *                    ADD TEAM - GLOBAL SEARCH                     *
        ******************************************************************/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmAddTeam.frmKeepAddTeam.Hide();
            string searchInput = txtSearchAll.Text;
            Operations.searchItem(searchInput);
        }

        /******************************************************************
        *          ADD TEAM - CHECK IF A MATCH NEEDS PROCESSING           *
        ******************************************************************/
        private void btnPendingResult_Click(object sender, EventArgs e)
        {
            // check whether there are any pending results...
            if (Operations.checkPendingResults() == true)
            {
                string input = "Fixtures pending results...";
                frmSearch.frmSearchClose.Show();
                frmKeepAddTeam.Hide();

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

