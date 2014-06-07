using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

/************************************************************************************
*                                   addFixture.cs                                   *
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
    public partial class frmAddFixture : Form
    {
        //need reference to call form back
        public static frmAddFixture frmKeepAddFixture = null; 

        public frmAddFixture()
        {
            InitializeComponent();
            frmKeepAddFixture = this;
        }


        /******************************************************************
        *       ADD FIXTURE - RENDER PICTURE BOXES AND LABELS ON LOAD     *
        ******************************************************************/
        private void frmAddFixture_Load(object sender, EventArgs e)
        {
            // set the default images...
            picAwayTeam.ImageLocation = @"../logos/default.png";
            picHomeTeam.ImageLocation = @"../logos/default.png";

            // populate team details boxes...
            renderLabels();
        }


        /******************************************************************
        *       ADD FIXTURE - ADD THE NEW FIXTURE TO THE TEXTFILE         *
        ******************************************************************/
        private void btnAddFixture_Click(object sender, EventArgs e)
        {
            // local variables...
            bool allInputOK = false;

            int selection, selectHomeTeam, selectAwayTeam;
            League whichLeague;
            Team homeTeam;
            Team awayTeam;


            // get inputs - LEAGUE ORDER = Name, Sponsor, Prize, NumberOfTeams
            string tempFixtureDate     = txtFixtureDate.Text;
            string tempFixtureTime     = txtFixtureTime.Text;
            string tempFixtureLocation = txtFixtureLocation.Text;
            string tempFixtureHomeTeam = cboHomeTeam.Text;
            string tempFixtureAwayTeam = cboAwayTeam.Text;

            // set the validation check...
            allInputOK = Operations.notNullTextBox(txtFixtureDate, "the Date") && Operations.notNullTextBox(txtFixtureTime, "the Time") &&
                         Operations.notNullTextBox(txtFixtureLocation, "the Location");

            // initialise the selection...
            selection = cboLeagues.SelectedIndex;
            whichLeague = (League)frmMainMenu.allLeagues[selection];

            selectHomeTeam = cboHomeTeam.SelectedIndex;

            // test to see if any text has been put in the text box (out of range exception thrown if not)...
            try 
            {
                homeTeam = (Team)frmMainMenu.allTeams[selectHomeTeam];
            }

            // reset form and inform user of error, if home team is not selected...
            catch (ArgumentOutOfRangeException) 
            {
                MessageBox.Show("Please select a home team", "No Home-team Selected.");
            }

            // perform same operations for the home team...
            selectAwayTeam = cboAwayTeam.SelectedIndex;

            try
            {
                awayTeam = (Team)frmMainMenu.allTeams[selectAwayTeam];
            }
            catch (ArgumentOutOfRangeException) 
            {
                MessageBox.Show("Please select an away team", "No Away-team selected.");
            }

            // create the date validation, otherwise add the fixture...
            try
            {
                // initalise and format the date time comparitors...
                DateTime inputFixture = Convert.ToDateTime(tempFixtureDate);
                String.Format("{0:dd/MM/yyyy}", inputFixture);

                DateTime currentTime = DateTime.Now;
                String.Format("{0:dd/MM/yyyy}", currentTime);

                // if the tempFixture dateTime is less than the current time, then prompt an error...
                if ((inputFixture - currentTime).TotalDays <= 7)
                {
                    MessageBox.Show("A fixture can only be created one week in advance of play!", "Invalid fixture date.");
                }

                if (tempFixtureHomeTeam == tempFixtureAwayTeam)
                {
                    MessageBox.Show("The home and away teams cannot be the same, please select a different home or away team.", "Invalid fixture teams.");
                }

                // otherwise add the fixture to the fixtures...
                else
                {
                    if (allInputOK)
                    {
                        // create the new fixture...
                        Fixture tempFixture = new Fixture(tempFixtureDate, tempFixtureTime, tempFixtureLocation, tempFixtureHomeTeam, tempFixtureAwayTeam); 
 
                        whichLeague.addFixtureToLeague(whichLeague.getAllLeagueFixtures(), tempFixture);

                        Operations.writeAllFixtures(frmMainMenu.inputFootball, frmMainMenu.allLeagues);//update file 

                        // feedback to the user...
                        MessageBox.Show("Success, the fixture between " + tempFixtureHomeTeam + " and " + tempFixtureAwayTeam + " at " 
                                         + tempFixtureLocation + " on the " + tempFixtureDate + " at " + tempFixtureTime + "  has been added.", "Success fixture added."); 
                        resetForm();

                    }
                }
            }

            // reset form and inform user of error, if incorrect format is entered for date/time
            catch (FormatException) 
            {
                MessageBox.Show("Please enter a valid date/time", "Invalid date time.");
            }

        }


        /******************************************************************
        *       ADD FIXTURE - RESET THE FORMS LABELS AND COMBO BOXES      *
        ******************************************************************/
        private void resetForm()
        {
            //LEAGUE ORDER = Name, Sponsor, Prize, NumberOfTeams
            txtFixtureDate.Text = "";
            txtFixtureTime.Text = "";
            txtFixtureLocation.Text = "";
            cboHomeTeam.Text = "";
            cboAwayTeam.Text = "";
            txtFixtureDate.Focus();
        }


        /******************************************************************
        *                ADD FIXTURE - GO TO THE MAIN MENU                *
        ******************************************************************/
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            frmMainMenu.frmKeepMainMenu.Show();
            frmKeepAddFixture.Close();
        }


        /******************************************************************
        *     ADD FIXTURE - POPULATE FORM WITH DEFAULT VALUES ON SHOW     *
        ******************************************************************/
        private void frmAddFixture_Shown(object sender, EventArgs e)
        {
            populateLeagueBox();
            cboLeagues.SelectedIndex = 0;

            populateAwayTeamBox();
            cboAwayTeam.SelectedIndex = -1;

            populateHomeTeamBox();
            cboHomeTeam.SelectedIndex = -1;
        }


        /******************************************************************
        *                 ADD FIXTURE - POPULATE COMBO BOXES              *
        ******************************************************************/
        private void populateLeagueBox()
        {
            foreach (League L in frmMainMenu.allLeagues)
            {
                string option;
                option = L.getLeagueName();
                cboLeagues.Items.Add(option);
            }
        }

        /********************** HOME TEAM COMBO **************************/

        private void populateHomeTeamBox()
        {
            foreach (Team T in frmMainMenu.allTeams)
            {
                // check if the teams league is correct, if yes add all league teams...
                if (T.getTeamLeague() == cboLeagues.SelectedItem.ToString())
                {
                    string option;
                    option = T.getTeamName();
                    cboHomeTeam.Items.Add(option);
                }
            }
        }

        /********************** AWAY TEAM COMBO **************************/

        private void populateAwayTeamBox()
        {
            foreach (Team T in frmMainMenu.allTeams)
            {
                // check if the teams league is correct, if yes add all league teams...
                if (T.getTeamLeague() == cboLeagues.SelectedItem.ToString())
                {
                    string option;
                    option = T.getTeamName();
                    cboAwayTeam.Items.Add(option);
                }
            }
        }


        /******************************************************************
        *                 ADD FIXTURE - COMBO INDEX CHANGED               *
        ******************************************************************/
        private void cboLeagues_SelectedIndexChanged(object sender, EventArgs e)
        {
            // empty the home and away team boxes...
            cboHomeTeam.Items.Clear();
            cboAwayTeam.Items.Clear();

            // repopulate with the correct teams...
            populateHomeTeamBox();
            populateAwayTeamBox();

        }


        /********************** HOME TEAM CHANGED **************************/

        private void cboHomeTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            string teamName;
            int teamPositionCounter = 0;
            int teamComboIndex = 0;

            // if there are any teams listed in the listbox
            if (this.cboHomeTeam.Items.Count > 0)
            {
                teamComboIndex = this.cboHomeTeam.SelectedIndex;
                teamName = cboHomeTeam.SelectedItem.ToString();

                // find team array position within a particular league
                teamPositionCounter = Operations.teamArrayPosition(teamPositionCounter, teamName);

                frmMainMenu.teamSelected = teamPositionCounter;

                Team homeTeam = (Team)frmMainMenu.allTeams[teamPositionCounter];

                string filePath = @"../logos/" + homeTeam.getTeamLogo();

                picHomeTeam.ImageLocation = filePath;

                txtFixtureLocation.Text = homeTeam.getTeamStadium();

                //TEAM ORDER = teamName, teamManager, teamNickname, teamStadium, teamPosition, teamPoints, teamGamesPlayed, teamGoalDifference, teamNumPlayers
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


        /********************** AWAY TEAM CHANGED **************************/

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

                picAwayTeam.ImageLocation = filePath;

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


        private void panelLineup_Paint(object sender, PaintEventArgs e)
        {

        }


        /******************************************************************
        *               ADD FIXTURE - RENDER THE FORM LABELS              *
        ******************************************************************/
        private void renderLabels()
        {
            // RENDER AWAY LABELS
            lblAwayName.Text = "unset";
            lblAwayManager.Text = "unset";
            lblAwayNickname.Text = "unset";
            lblAwayStadium.Text = "unset";
            lblAwayPosition.Text = "unset";
            lblAwayPoints.Text = "unset";
            lblAwayGamesPlayed.Text = "unset";
            lblAwayGoalDifference.Text = "unset";
            lblAwayPlayers.Text = "unset";

            // RENDER HOME LABELS
            lblHomeName.Text = "unset";
            lblHomeManager.Text = "unset";
            lblHomeNickname.Text = "unset";
            lblHomeStadium.Text = "unset";
            lblHomePosition.Text = "unset";
            lblHomePoints.Text = "unset";
            lblHomeTeamGamesPlayed.Text = "unset";
            lblHomeGoalDifference.Text = "unset";
            lblHomePlayers.Text = "unset";

        }

        /******************************************************************
        *        ADD FIXTURE - CHECK IF A MATCH NEEDS PROCESSING          *
        ******************************************************************/
        private void btnPendingResult_Click(object sender, EventArgs e)
        {
            // check whether there are any pending results...
            if (Operations.checkPendingResults() == true)
            {
                string input = "Fixtures pending results...";
                frmSearch.frmSearchClose.Show();
                frmKeepAddFixture.Hide();

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmAddFixture.frmKeepAddFixture.Hide();
            string searchInput = txtSearchAll.Text;
            Operations.searchItem(searchInput);
        }



    }
}
