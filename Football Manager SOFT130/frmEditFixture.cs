using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

/************************************************************************************
*                                  editFixture.cs                                   *
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
    public partial class frmEditFixture : Form
    {
        public static frmEditFixture frmKeepEditFixture = null; // need reference to call form back

        public frmEditFixture()
        {
            InitializeComponent();
            frmKeepEditFixture = this;
        }


        /******************************************************************
        *                    EDIT FIXTURE - ON LOAD EVENT                 *
        ******************************************************************/
        private void frmEditFixture_Load(object sender, EventArgs e)
        {
            // populate all combo boxes and set their index...
            populateLeagueBox();
            cboLeagues.SelectedIndex = 0;

            populateAwayTeamBox();
            cboAwayTeam.SelectedIndex = -1;

            populateHomeTeamBox();
            cboHomeTeam.SelectedIndex = -1;

            // get details for the current fixture...
            getFixtureDetails();

            validateFixture();
        }


        /******************************************************************
        *                 EDIT FIXTURE - RESULTS PROCESSING               *
        ******************************************************************/
        private void btnProcessResult_Click(object sender, EventArgs e)
        {
            // local variables...
            int homeScore, awayScore;
            int currentHomePoints, currentAwayPoints;
            bool gameTime = false;
            Team homeTeam, awayTeam;

            // initialisation...
            homeScore = Convert.ToInt32(txtHomeScore.Text);
            awayScore = Convert.ToInt32(txtAwayScore.Text);

            DialogResult dialogResult = MessageBox.Show("Are you certain the result: " + homeScore + " - " + awayScore + " is accurate?\n\nOnce the result has been processed"
                                                      + " system wide changes will take effect, and the record of this fixture shall be deleted.",
                                                       "Proceed to process result?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // if the result is yes...
            if (dialogResult == DialogResult.Yes)
            {
                // check to see whether the game has been played...
                while (gameTime == false)
                {
                    // loop through all leagues...
                    foreach (League l in frmMainMenu.allLeagues)
                    {
                        // loop through all fixtures...
                        foreach (Fixture f in l.getAllLeagueFixtures().ToArray())
                        {
                            // check that the right home and away team are selected to determine fixture...
                            if (f.getFixtureHomeTeam() == cboHomeTeam.Text && f.getFixtureAwayTeam() == cboAwayTeam.Text)
                            {

                                // create the date input strings...
                                DateTime inputFixture = Convert.ToDateTime(f.getFixtureDate());
                                DateTime inputTime = Convert.ToDateTime(f.getFixtureTime());
                                DateTime currentDate = DateTime.Now;

                                // format the input strings...
                                String.Format("{0:dd/MM/yyyy}", inputFixture);
                                String.Format("{0:dd/MM/yyyy}", currentDate);

                                // check if the date has passed or it is match day, and that the match has been played...
                                if ((inputFixture - currentDate).TotalDays <= 1 && inputFixture.AddMinutes(90) <= currentDate)
                                {

                                    // loop through each home team...
                                    foreach (Team home in frmMainMenu.allTeams.ToArray())
                                    {
                                        // check the correct home team is selected...
                                        if (cboHomeTeam.Text == home.getTeamName())
                                        {
                                            homeTeam = home;
                                            currentHomePoints = homeTeam.getTeamPoints();

                                            // get and process the result...
                                            Operations.getHomeResult(homeTeam, currentHomePoints, homeScore, awayScore);

                                        }

                                    }

                                    // loop through each away team...
                                    foreach (Team away in frmMainMenu.allTeams.ToArray())
                                    {
                                        // check the correct away team is selected...
                                        if (cboAwayTeam.Text == away.getTeamName())
                                        {
                                            awayTeam = away;
                                            currentAwayPoints = awayTeam.getTeamPoints();

                                            // get and process the result...
                                            Operations.getAwayResult(awayTeam, currentAwayPoints, homeScore, awayScore);

                                        }

                                    }

                                    // refresh the team UI in the left panel...
                                    foreach (Team t in frmMainMenu.allTeams)
                                    {
                                        if (cboAwayTeam.Text == t.getTeamName())
                                        {
                                            renderAway(t);
                                        }

                                        if (cboHomeTeam.Text == t.getTeamName())
                                        {
                                            renderHome(t);
                                        }
                                    }

                                    // Tidy up the interface...
                                    lblStatus.Text = "SUCCESS: Match details successfully recorded!";
                                    lblStatus.ForeColor = Color.FromArgb(46, 178, 216);

                                    cboLeagues.Focus();
                                    btnProcessResult.Enabled = false;
                                    txtAwayScore.Enabled = false;
                                    txtHomeScore.Enabled = false;

                                    // Delete the played fixture...
                                    Operations.deletePlayedFixture(l, f);

                                    gameTime = true;
                                }

                                else
                                {
                                    // Inform user that the game has not been played yet and break out loop...
                                    lblStatus.Text = "ERROR: The game has not been played yet...";
                                    lblStatus.ForeColor = Color.FromArgb(240, 64, 64);
                                    gameTime = true;

                                }

                            } // end if

                        } // end foreach fixture

                    } // end foreach league

                } // end while

                frmKeepEditFixture.Close();
                frmMainMenu.frmKeepMainMenu.Show();

            } // end dialog confirm

            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("The result was not processed, no changes have been made to the system.");
            }

        }


        /******************************************************************
        *                   EDIT FIXTURE - DELETE FIXTURE                 *
        ******************************************************************/
        private void btnDeleteFixture_Click(object sender, EventArgs e)
        {
            // local variables...
            League deleteLeague;

            deleteLeague = (League)frmMainMenu.allLeagues[frmMainMenu.leagueSelected];
            var theLeagues = deleteLeague.getAllLeagueFixtures();

            // loop through each fixture in 'theLeagues', convert to array to prevent
            // the Enumerator changed error exception to be thrown by compiler...
            foreach (Fixture f in theLeagues.ToArray())
            {
                // Get the correct fixture...
                if (f.getFixtureHomeTeam() == cboHomeTeam.SelectedItem.ToString() &&
                    f.getFixtureAwayTeam() == cboAwayTeam.SelectedItem.ToString())
                {
                    // create the date input strings...
                    DateTime inputFixture = Convert.ToDateTime(f.getFixtureDate());
                    DateTime currentTime = DateTime.Now;

                    // format the input strings...
                    String.Format("{0:dd/MM/yyyy}", inputFixture);
                    String.Format("{0:dd/MM/yyyy}", currentTime);

                    // check whether its the week of the fixture...
                    if ((inputFixture - currentTime).TotalDays <= 7)
                    {
                        MessageBox.Show("ERROR: A Fixture can only be deleted one week in advance...");
                    }

                    // otherwise delete the item at the selected index...
                    else
                    {
                        deleteLeague.getAllLeagueFixtures().RemoveAt(frmMainMenu.fixtureSelected);

                        Operations.writeAllLeagues(frmMainMenu.inputFootball, frmMainMenu.allLeagues);
                        Operations.writeAllFixtures(frmMainMenu.inputFootball, frmMainMenu.allLeagues);

                        // prompt the user that the fixture has been deleted...
                        MessageBox.Show("Success - The Fixture: " + f.getFixtureHomeTeam() + " vs " + f.getFixtureAwayTeam()
                                         + " at " + txtFixtureLocation.Text + " has been deleted.");
                    }
                }
            }

        }


        /******************************************************************
        *                   EDIT FIXTURE - EDIT THE FIXTURE               *
        ******************************************************************/
        private void btnEditFixture_Click(object sender, EventArgs e)
        {
            // local variables...
            bool validationCheck = false;
            League whichLeague = (League)frmMainMenu.allLeagues[frmMainMenu.leagueSelected];


            // initialisation...
            // FIXTURE ORDER = fixtureLeague, fixtureDate, fixtureTime, fixtureLocation, fixtureHomeTeam, fixtureAwayTeam
            string tempFixtureLeague = cboLeagues.Text;
            string tempFixtureDate = txtFixtureDate.Text;
            string tempFixtureTime = txtFixtureTime.Text;
            string tempFixtureLocation = txtFixtureLocation.Text;
            string tempFixtureHomeTeam = cboHomeTeam.Text;
            string tempFixtureAwayTeam = cboAwayTeam.Text;


            // do validation...
            validationCheck = cboLeagues != null && Operations.notNullTextBox(txtFixtureDate, "the fixture date")
                            && Operations.notNullTextBox(txtFixtureTime, "the fixture time") && Operations.notNullTextBox(txtFixtureLocation, "the fixtures location")
                            && cboHomeTeam != null && cboAwayTeam != null;


            // if the validation returns true then...
            if (validationCheck)
            {
                // create the tempFixture object...
                Fixture tempFixture = new Fixture(tempFixtureDate, tempFixtureTime, tempFixtureLocation, tempFixtureHomeTeam, tempFixtureAwayTeam);

                // use the replaceFixture method (in League) to replace team, then rewrite file...
                whichLeague.replaceFixture(whichLeague.getAllLeagueFixtures(), tempFixture, frmMainMenu.fixtureSelected);
                Operations.writeAllFixtures(frmMainMenu.inputFootball, frmMainMenu.allLeagues);

                // prompt the user of success and reset the form...
                MessageBox.Show("SUCCESS: The fixture has been amended, " + tempFixtureHomeTeam + " shall play " + tempFixtureAwayTeam + " on "
                               + tempFixtureDate + " at " + tempFixtureTime + " at " + tempFixtureLocation + ".");

                resetForm();
            }
        }


        /******************************************************************
        *             EDIT FIXTURE - GET THE FIXTURE DETAILS              *
        ******************************************************************/
        private void getFixtureDetails()
        {
            try
            {
                // local variables...
                int selectedLeague = frmMainMenu.leagueSelected;
                int selectedFixture = frmMainMenu.fixtureSelected;
                ArrayList allOfTheLeagues = frmMainMenu.allLeagues;

                League currentLeague = (League)allOfTheLeagues[selectedLeague];
                Fixture currentFixture = (Fixture)currentLeague.getAllLeagueFixtures()[selectedFixture];


                // set input fields to the currentFixture details...
                cboLeagues.Text = currentLeague.getLeagueName();
                txtFixtureDate.Text = currentFixture.getFixtureDate();
                txtFixtureTime.Text = currentFixture.getFixtureTime();
                txtFixtureLocation.Text = currentFixture.getFixtureLocation();
                cboHomeTeam.Text = currentFixture.getFixtureHomeTeam();
                cboAwayTeam.Text = currentFixture.getFixtureAwayTeam();


                // loop through each team in allTeams...
                foreach (Team t in frmMainMenu.allTeams)
                {
                    // check to see if the right home team has been selected...
                    if (t.getTeamName().ToString() == cboHomeTeam.Text)
                    {
                        // render the left panel using t's details...
                        renderHome(t);
                    }

                    // check to see if the right away team is selected
                    if (t.getTeamName().ToString() == cboAwayTeam.Text)
                    {
                        // render the left panel using t's details...
                        renderAway(t);
                    }
                }
            }

            catch (IndexOutOfRangeException)
            { }

            catch (Exception)
            {
                MessageBox.Show("Please select a fixture from the list before trying to edit one.", "Operation Failed");

            }
        }

        /******************************************************************
        *         EDIT FIXTURE - DO DATE VALIDATION AND SET FORM          *
        ******************************************************************/
        private void validateFixture()
        {
            // local vars...
            DateTime fixtureDate = Convert.ToDateTime(txtFixtureDate.Text);
            DateTime currentDate = DateTime.Now;
            DateTime fixTime = Convert.ToDateTime(txtFixtureTime.Text);

            // get the end match time...
            DateTime processTime = fixTime.AddMinutes(90);

            // format the string to HH:MM...
            string getTime = processTime.ToString();
            string[] containTime = getTime.Split(' ');
            string[] stripSecs = containTime[1].Split(':');

            // set the output string...
            string outputTime = stripSecs[0] + ":" + stripSecs[1];


            // if the match has been played, do not allow the user to amend details...
            if ((fixtureDate - currentDate).TotalDays <= -1)
            {
                txtFixtureDate.Enabled = false;
                cboAwayTeam.Enabled = false;
                cboHomeTeam.Enabled = false;
                cboLeagues.Enabled = false;
                txtFixtureLocation.Enabled = false;
                txtFixtureTime.Enabled = false;
                lblEditFixture.Text = "Please enter the result of this fixture...";
            }

            // if the match has NOT been played, allow the user to only edit details...
            else
            {
                btnProcessResult.Enabled = false;
                txtAwayScore.Enabled = false;
                txtHomeScore.Enabled = false;
                lblStatus.Text = "Results processing is available from " + outputTime + " on " + txtFixtureDate.Text + ".";
            }
        }

        /******************************************************************
        *                     EDIT FIXTURE - RESET FORM                   *
        ******************************************************************/
        private void resetForm()
        {
            txtFixtureDate.Text = "";
            txtFixtureTime.Text = "";
            txtFixtureLocation.Text = "";

        }


        /******************************************************************
        *               EDIT FIXTURE - POPULATE COMBO BOXES               *
        ******************************************************************/
        private void populateLeagueBox()
        {
            // loop through each league and add its name to the combo list...
            foreach (League L in frmMainMenu.allLeagues)
            {
                string option;
                option = L.getLeagueName();
                cboLeagues.Items.Add(option);
            }
        }

        private void populateAwayTeamBox()
        {
            // loop through each team and add its name to the combo list...
            foreach (Team T in frmMainMenu.allTeams)
            {
                // only add to the list if the team belongs to the league...
                if (T.getTeamLeague() == cboLeagues.SelectedItem.ToString())
                {
                    string option;
                    option = T.getTeamName();
                    cboHomeTeam.Items.Add(option);
                }
            }

        }

        private void populateHomeTeamBox()
        {
            // loop through each team and add its name to the combo list...
            foreach (Team T in frmMainMenu.allTeams)
            {
                // only add to the list if the team belongs to the league...
                if (T.getTeamLeague() == cboLeagues.SelectedItem.ToString())
                {
                    string option;
                    option = T.getTeamName();
                    cboAwayTeam.Items.Add(option);
                }
            }

        }


        /******************************************************************
        *             EDIT FIXTURE - POPULATE LEFT PANEL DISPLAY          *
        ******************************************************************/
        private void renderHome(Team homeTeam)
        {
            // local variables...
            string homeLogo = @"../logos/" + homeTeam.getTeamLogo();

            // set teamIcons...
            picHome.ImageLocation = homeLogo;
            picHomeScore.ImageLocation = homeLogo;

            // render home labels...
            lblHomeName.Text = homeTeam.getTeamName();
            lblHomeManager.Text = homeTeam.getTeamManager();
            lblHomeNickname.Text = homeTeam.getTeamNickname();
            lblHomeStadium.Text = homeTeam.getTeamStadium();
            lblHomePosition.Text = homeTeam.getTeamPosition().ToString();
            lblHomePoints.Text = homeTeam.getTeamPoints().ToString();
            lblHomeTeamGamesPlayed.Text = homeTeam.getTeamGamesPlayed().ToString();
            lblHomeGoalDifference.Text = homeTeam.getTeamGoalDifference().ToString();
            lblHomePlayers.Text = homeTeam.getTeamNumPlayers().ToString();

            // get a substring representation of the team...
            lblHomeSubString.Text = homeTeam.getTeamName().Substring(0, 3).ToUpper();
        }

        private void renderAway(Team awayTeam)
        {
            // local variables...
            string awayLogo = @"../logos/" + awayTeam.getTeamLogo();

            // set teamIcons...
            picAway.ImageLocation = awayLogo;
            picAwayScore.ImageLocation = awayLogo;

            // render away labels...
            lblAwayName.Text = awayTeam.getTeamName();
            lblAwayManager.Text = awayTeam.getTeamManager();
            lblAwayNickname.Text = awayTeam.getTeamNickname();
            lblAwayStadium.Text = awayTeam.getTeamStadium();
            lblAwayPosition.Text = awayTeam.getTeamPosition().ToString();
            lblAwayPoints.Text = awayTeam.getTeamPoints().ToString();
            lblAwayGamesPlayed.Text = awayTeam.getTeamGamesPlayed().ToString();
            lblAwayGoalDifference.Text = awayTeam.getTeamGoalDifference().ToString();
            lblAwayPlayers.Text = awayTeam.getTeamNumPlayers().ToString();

            // get a substring representation of the team...
            lblAwaySubString.Text = awayTeam.getTeamName().Substring(0, 3).ToUpper();
        }


        /******************************************************************
        *                  EDIT FIXTURE - GO TO MAIN MENU                 *
        ******************************************************************/
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            frmMainMenu.frmKeepMainMenu.Show();
            frmKeepEditFixture.Close();

        }


        /******************************************************************
        *            EDIT FIXTURE - COMBO HOME BOX INDEX CHANGED          *
        ******************************************************************/
        private void cboHomeTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            // local variables...
            string teamName;
            int teamPositionCounter = 0;
            int teamComboIndex = 0;

            // if there are any teams listed in the listbox...
            if (this.cboHomeTeam.Items.Count > -1)
            {
                teamComboIndex = this.cboHomeTeam.SelectedIndex;
                teamName = cboHomeTeam.SelectedItem.ToString();

                // find team array position within a particular league...
                teamPositionCounter = Operations.teamArrayPosition(teamPositionCounter, teamName);

                // set the position counter to the methods return...
                frmMainMenu.teamSelected = teamPositionCounter;

                // set the selected teams index...
                Team homeTeam = (Team)frmMainMenu.allTeams[teamPositionCounter];

                // get the teams logo so it can be rendered...
                string filePath = @"../logos/" + homeTeam.getTeamLogo();

                picHome.ImageLocation = filePath;
                picHomeScore.ImageLocation = filePath;

                txtFixtureLocation.Text = homeTeam.getTeamStadium();

                //TEAM ORDER = teamName, teamManager, teamNickname, teamStadium, teamPosition, teamPoints, 
                //             teamGamesPlayed, teamGoalDifference, teamNumPlayers
                lblHomeName.Text = homeTeam.getTeamName();
                lblHomeManager.Text = homeTeam.getTeamManager();
                lblHomeNickname.Text = homeTeam.getTeamNickname();
                lblHomeStadium.Text = homeTeam.getTeamStadium();
                lblHomePosition.Text = homeTeam.getTeamPosition().ToString();
                lblHomePoints.Text = homeTeam.getTeamPoints().ToString();
                lblHomeTeamGamesPlayed.Text = homeTeam.getTeamGamesPlayed().ToString();
                lblHomeGoalDifference.Text = homeTeam.getTeamGoalDifference().ToString();
                lblHomePlayers.Text = homeTeam.getTeamNumPlayers().ToString();

            }
        }


        /******************************************************************
        *           EDIT FIXTURE - COMBOBOX AWAY INDEX CHANGED            *
        ******************************************************************/
        private void cboAwayTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            string teamName;
            int teamPositionCounter = 0;
            int teamComboIndex = 0;

            // if there are any teams listed in the listbox
            if (this.cboAwayTeam.Items.Count > 0)
            {
                teamComboIndex = this.cboAwayTeam.SelectedIndex;
                teamName = cboAwayTeam.SelectedItem.ToString();

                // find team array position within a particular league
                teamPositionCounter = Operations.teamArrayPosition(teamPositionCounter, teamName);

                frmMainMenu.teamSelected = teamPositionCounter;

                Team awayTeam = (Team)frmMainMenu.allTeams[teamPositionCounter];

                string filePath = @"../logos/" + awayTeam.getTeamLogo();

                picAway.ImageLocation = filePath;
                picAwayScore.ImageLocation = filePath;

                //TEAM ORDER = teamName, teamManager, teamNickname, teamStadium, teamPosition, teamPoints, teamGamesPlayed, teamGoalDifference, teamNumPlayers
                lblAwayName.Text = awayTeam.getTeamName();
                lblAwayManager.Text = awayTeam.getTeamManager();
                lblAwayNickname.Text = awayTeam.getTeamNickname();
                lblAwayStadium.Text = awayTeam.getTeamStadium();
                lblAwayPosition.Text = awayTeam.getTeamPosition().ToString();
                lblAwayPoints.Text = awayTeam.getTeamPoints().ToString();
                lblAwayGamesPlayed.Text = awayTeam.getTeamGamesPlayed().ToString();
                lblAwayGoalDifference.Text = awayTeam.getTeamGoalDifference().ToString();
                lblAwayPlayers.Text = awayTeam.getTeamNumPlayers().ToString();

            }
        }


        /******************************************************************
        *          EDIT FIXTURE - COMBOBOX LEAGUES INDEX CHANGED          *
        ******************************************************************/
        private void cboLeagues_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboHomeTeam.Items.Clear();
            cboAwayTeam.Items.Clear();

            populateHomeTeamBox();
            populateAwayTeamBox();
        }



        /******************************************************************
        *            EDIT FIXTURE - FORM AESTHETIC OPERATIONS             *
        ******************************************************************/
        private void txtHomeScore_Enter(object sender, EventArgs e)
        {
            txtHomeScore.BackColor = Color.FromArgb(40, 40, 40);
            txtHomeScore.Text = "";
        }

        private void txtAwayScore_Enter(object sender, EventArgs e)
        {
            txtAwayScore.BackColor = Color.FromArgb(40, 40, 40);
            txtAwayScore.Text = "";
        }

        private void txtHomeScore_Leave(object sender, EventArgs e)
        {
            txtHomeScore.BackColor = Color.FromArgb(50, 50, 50);
            if (txtHomeScore.Text == "" || txtHomeScore.Text == " ")
            {
                txtHomeScore.Text = "0";
            }
        }

        private void txtAwayScore_Leave(object sender, EventArgs e)
        {
            txtAwayScore.BackColor = Color.FromArgb(50, 50, 50);
            if (txtAwayScore.Text == "" || txtAwayScore.Text == " ")
            {
                txtAwayScore.Text = "0";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmEditFixture.frmKeepEditFixture.Hide();
            string searchInput = txtSearchAll.Text;
            Operations.searchItem(searchInput);
        }


        /******************************************************************
        *         EDIT FIXTURE - CHECK IF A MATCH NEEDS PROCESSING        *
        ******************************************************************/
        private void btnPendingResult_Click(object sender, EventArgs e)
        {
            // check whether there are any pending results...
            if (Operations.checkPendingResults() == true)
            {
                string input = "Fixtures pending results...";
                frmSearch.frmSearchClose.Show();
                frmKeepEditFixture.Hide();

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
