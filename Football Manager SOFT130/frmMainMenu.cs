using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;


    /************************************************************************************
    *                               frmMainMenu.CS                                      *
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
    public partial class frmMainMenu : Form
    {
        public static frmMainMenu frmKeepMainMenu = null; //need reference to call form back
        public static ArrayList allLeagues = new ArrayList(); // need access from other forms
        public static ArrayList allTeams = new ArrayList();   // need access from other forms
        public static string inputTeams = @"../teams.txt";
        public static string inputFootball = @"../football.txt";
        public static int numTeamItems = 11;
        public static int numLeagueItems = 4;
        public static int numFixtureItems = 5;
        public static int leagueSelected;
        public static int fixtureSelected;
        public static int teamSelected;
       
        // MAIN ENTRY POINT...
        public frmMainMenu()
        {
            InitializeComponent();
            frmKeepMainMenu = this;
        }


        /******************************************************************
        *                MAIN MENU - READ IN DATA ON LOAD                 *
        ******************************************************************/
        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            // read in teams, leagues and fixtures...
            Operations.readFootball(inputFootball, allLeagues);
            Operations.readTeams(inputTeams, allTeams);

            // display the fixtures in the list box...
            Operations.showListOfFixtures(lstLeagues);
            
            // get rid of border styling for list view...
            lstViewTeams.BorderStyle = BorderStyle.None;

            // set default text for global search bar...
            if (txtSearchAll.Text == "")
            {
                txtSearchAll.Text = " Search the whole system...";
            }

            if (txtSearchAll.Text == " ")
            {
                txtSearchAll.Text = " Search the whole system...";
            }

        }


        /******************************************************************
        *   MAIN MENU - POPULATE COMBO BOX AND LOAD IMAGES TO LISTVIEW  *
        ******************************************************************/
        private void frmMainMenu_Shown(object sender, EventArgs e)
        {
            // populate the select league combobox...
            populateLeagueBox();

            // try and default to the premiership, else set to index 0...
            try
            {
                cboTargetLeague.SelectedIndex = 7;
            }
            catch(Exception)
            {
                cboTargetLeague.SelectedIndex = 0;
            }

            // Cycle through the arrayList and load all team images into imagelist collection
            foreach (Team t in allTeams)
            {
                try
                {
                    string teamLogo = t.getTeamLogo();

                    // Check whether the logo already exists in the collection...
                    // otherwise load the image into the collection.
                    imgLstIcons.Images.Add(Image.FromFile(@"../logos/" + teamLogo));
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Error when loading image, file not found!", "File not found");
                }

            }

            // check if a result is pending...
            if (Operations.checkPendingResults())
            {
                btnPendingResult.Show();
                lblPending.Show();
            }

            else
            {
                btnPendingResult.Hide();
                lblPending.Hide();
            }

        }


        /******************************************************************
        *                  MAIN MENU - RE-RENDER FORM                     *
        ******************************************************************/
        private void frmMainMenu_VisibleChanged(object sender, EventArgs e)
        {
            // when an item is edited that will change the main menus values, refresh all content...
            try
            {
                lstViewTeams.Items.Clear();
                renderImageList();

            }
            // catch the null ref exception triggered intially on load by the combo box changing index...
            catch (NullReferenceException)
            { }
        }

        /******************************************************************
        *                   MAIN MENU - POPULATE LEAGUE BOX               *
        ******************************************************************/
        private void populateLeagueBox()
        {
            // loop through each league...
            foreach (League L in frmMainMenu.allLeagues)
            {
                string option;
                option = L.getLeagueName();
                cboTargetLeague.Items.Add(option);
            }

        }


        /******************************************************************
        *                     MAIN MENU - ADD NEW LEAGUE                  *
        ******************************************************************/
        private void btnAddLeague_Click(object sender, EventArgs e)
        {
            frmAddLeague tempAddNewLeague = new frmAddLeague();
            tempAddNewLeague.Show();
            frmKeepMainMenu.Hide();
        }


        /******************************************************************
        *                    MAIN MENU - ADD NEW TEAM                     *
        ******************************************************************/
        private void btnAddTeam_Click(object sender, EventArgs e)
        {
            frmAddTeam tempAddNewTeam = new frmAddTeam();
            tempAddNewTeam.Show();
            frmKeepMainMenu.Hide();
        }


        /******************************************************************
        *                    MAIN MENU - ADD NEW FIXTURE                  *
        ******************************************************************/
        private void btnAddFixture_Click_1(object sender, EventArgs e)
        {
            frmAddFixture tempAddNewFixture = new frmAddFixture();
            tempAddNewFixture.Show();
            frmKeepMainMenu.Hide();
        }


        /******************************************************************
        *                   MAIN MENU - UPDATE LIST BOX                   *
        ******************************************************************/
        private void btnShowLeagues_Click(object sender, EventArgs e)
        {
            Operations.showListOfFixtures(lstLeagues);
        }


        /******************************************************************
        *               MAIN MENU - EDIT THE SELECTED LEAGUE              *
        ******************************************************************/
        private void btnEditLeague_Click(object sender, EventArgs e)
        {
            leagueSelected = cboTargetLeague.SelectedIndex;
           
            frmEditLeague tempEditLeague = new frmEditLeague();
            tempEditLeague.Show();
            frmKeepMainMenu.Hide();

        }


        /******************************************************************
        *               MAIN MENU - EDIT THE SELECTED TEAM                *
        ******************************************************************/
        private void btnEditTeam_Click(object sender, EventArgs e)
        {
            // local variables...
            string teamName;
            
            // initalise...
            int teamPositionCounter = 0;
            int teamListViewIndex = 0;

            // if there are any teams pictures to choose from the listview...
            if (this.lstViewTeams.SelectedIndices.Count > 0)  
            {
                // get the correct selected index...
                teamListViewIndex = this.lstViewTeams.SelectedIndices[0];
                teamName = lstViewTeams.SelectedItems[0].ToString();

                teamName = Regex.Replace(teamName, @"ListViewItem: {", "");
                teamName = Regex.Replace(teamName, @"}", "");

                // find team array position within a particular league...
                teamPositionCounter = Operations.teamArrayPosition(teamPositionCounter, teamName); 

                // set the selected index to the counter...
                teamSelected = teamPositionCounter;
            }
            
            frmEditTeam tempEditTeam = new frmEditTeam();
            tempEditTeam.Show();

            frmKeepMainMenu.Hide();
        }


        /******************************************************************
        *               MAIN MENU - EDIT THE SELECTED FIXTURE             *
        ******************************************************************/
        private void btnEditFixture_Click(object sender, EventArgs e)
        {
            leagueSelected = cboTargetLeague.SelectedIndex;
            
            frmEditFixture tempEditFixture = new frmEditFixture();
            tempEditFixture.Show();
            frmKeepMainMenu.Hide();
        }


        /******************************************************************
        *               MAIN MENU - DELETE THE SELECTED TEAM              *
        ******************************************************************/
        private void btnDeleteTeam_Click(object sender, EventArgs e)
        {
            // local variables...
            string teamName = "";
            League whichLeague;

            // var initialisation...
            int teamPositionCounter = 0;
            int teamListViewIndex = 0;
            int fixtureDeleteCounter = 0;
            whichLeague = (League)frmMainMenu.allLeagues[frmMainMenu.leagueSelected];

            // ensure that the user wants to delete the team...
            DialogResult dialogResult = MessageBox.Show("Are you certain that you want to delete this team?\n\nThis function will premenanately remove them" 
                                                      + " and all their associated fixtures from the system.",
                                                        "Proceed to delete team?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {

                // if there are any teams pictures to choose from the listview
                if (this.lstViewTeams.SelectedIndices.Count > 0)
                {
                    teamListViewIndex = this.lstViewTeams.SelectedIndices[0];
                    teamName = lstViewTeams.SelectedItems[0].ToString();

                    teamName = Regex.Replace(teamName, @"ListViewItem: {", "");
                    teamName = Regex.Replace(teamName, @"}", "");

                    // find team array position within a particular league
                    teamPositionCounter = Operations.teamArrayPosition(teamPositionCounter, teamName);

                    teamSelected = teamPositionCounter;
                }


                // remove the team at the selected index...
                lstViewTeams.Items.RemoveAt(teamListViewIndex);

                Team deleteTeam;
                deleteTeam = (Team)allTeams[teamSelected];

                allTeams.RemoveAt(teamSelected); //remove team at the selected index, dependant on the variable teamSelected
                Operations.writeAllTeams(inputTeams, allTeams);

                Operations.removeTeamFixtures(whichLeague, deleteTeam, fixtureDeleteCounter);

                // refresh the listview...
                this.lstViewTeams.Refresh();

                lstLeagues.Items.Clear();
                Operations.showListOfFixtures(lstLeagues);

                // feedback to user...
                MessageBox.Show("Success, the team:  " + deleteTeam.getTeamName() + " and all of its fixtures have been deleted.", "Team deleted successfully.");

            }

            // otherwise feedback that operation was aborted...
            else if(dialogResult == DialogResult.No)
            {
                MessageBox.Show("Operation aborted successfully, the team was not deleted.", "Operation Aborted");
            }
        }


        /******************************************************************
        *               MAIN MENU - DELETE SELECTED LEAGUE                *
        ******************************************************************/
        private void btnDeleteLeague_Click(object sender, EventArgs e)
        {
            // local vars...
            string leagueName;

            leagueName = cboTargetLeague.SelectedItem.ToString();

            League deleteLeague;

            // make sure the user wants to delete the league...
            DialogResult dialogResult = MessageBox.Show("Are you certain that you want to delete " + leagueName + " from the system?"
                                                      + "\n\nThis function will premenanately remove them"
                                                      + " and all their associated teams and fixtures.",
                                                        "Proceed to delete league?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                deleteLeague = (League)allLeagues[leagueSelected];

                // delete all fixtures associated with the league...
                int removeFixtureCount = Math.Max(0, deleteLeague.getAllLeagueFixtures().Count);
                deleteLeague.getAllLeagueFixtures().RemoveRange(0, removeFixtureCount);


                // loop through the teams...
                foreach (Team t in frmMainMenu.allTeams.ToArray())
                {
                    if (t.getTeamLeague() == deleteLeague.getLeagueName())
                    {
                        int teamPositionCounter = 0;
                        string teamName = t.getTeamName();

                        // find team array position within a particular league
                        teamPositionCounter = Operations.teamArrayPosition(teamPositionCounter, teamName);

                        teamSelected = teamPositionCounter;


                        Team deleteTeam;
                        deleteTeam = (Team)allTeams[teamSelected];

                        allTeams.RemoveAt(teamSelected); //remove team at the selected index, dependant on the variable teamSelected
                        Operations.writeAllTeams(inputTeams, allTeams);
    
                    }
                }

                // remove league at the selected index, dependant on the variable leagueCboPosition
                allLeagues.RemoveAt(leagueSelected); 

                // re-write the file...
                Operations.writeAllLeagues(inputFootball, allLeagues);
                Operations.writeAllFixtures(inputFootball, allLeagues);

                // prompt the user of the successfull deletion...
                MessageBox.Show("Success, the league: " + leagueName + " has been deleted from the system.", "League Deleted");

                
                cboTargetLeague.Items.RemoveAt(leagueSelected);

                try
                {
                    // update the form...
                    lstViewTeams.Items.Clear();
                    lstLeagues.Items.Clear();
                    cboTargetLeague.Refresh();
                    cboTargetLeague.SelectedIndex = 0;
                }
                catch (ArgumentOutOfRangeException)
                { MessageBox.Show("There are no more leagues to display", "No more leagues"); }
            }

            // otherwise prompt of successful abort...
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Operation aborted successfully, the league was not deleted.", "Operation Aborted");
            }

        }


        /******************************************************************
        *               MAIN MENU - DELETE SELECTED FIXTURE               *
        ******************************************************************/
        private void btnDeleteFixture_Click(object sender, EventArgs e)
        {
            // local vars...
            string fixtureLocation;

            // initailisation...
            fixtureSelected = lstLeagues.SelectedIndex;
            fixtureLocation = lstLeagues.SelectedItem.ToString();

            League deleteFromLeague;

            // get the selected league index...
            deleteFromLeague = (League)allLeagues[leagueSelected];
            var theLeagues = deleteFromLeague.getAllLeagueFixtures();

            // make sure the user wants to delete the fixture...
            DialogResult dialogResult = MessageBox.Show("Are you certain that you want to delete the selected fixture from the system?"
                                                      + "\n\nThe fixture record will be permennately deleted.",
                                                        "Proceed to delete fixture?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                // convert theLeagues to an arry to void the enumerator changed exception...
                foreach (Fixture f in theLeagues.ToArray())
                {
                    try
                    {
                        // Get the correct fixture...
                        if (f.getFullFixture() == lstLeagues.SelectedItem.ToString())
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

                            // otherwise delete the item...
                            else
                            {
                                deleteFromLeague.getAllLeagueFixtures().RemoveAt(frmMainMenu.fixtureSelected);

                                Operations.writeAllLeagues(frmMainMenu.inputFootball, frmMainMenu.allLeagues);
                                Operations.writeAllFixtures(frmMainMenu.inputFootball, frmMainMenu.allLeagues);

                                MessageBox.Show("Success - The Fixture: " + f.getFixtureHomeTeam() + " vs " + f.getFixtureAwayTeam()
                                                 + " at " + f.getFixtureLocation() + " has been deleted.", "Fixture Deleted");

                                // remove the selected fixture from the list...
                                lstLeagues.Items.RemoveAt(fixtureSelected);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // refresh the listbox to negate the object not set to an instance exception
                        lstLeagues.Refresh();
                    }
                }
            }

            // prompt user of successful abort...
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Operation aborted successfully, the fixture was not deleted.", "Operation Aborted");
            }

        }


        /******************************************************************
        *            MAIN MENU - SEARCH THE GLOBAL SEARCHBAR              *
        ******************************************************************/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmMainMenu.frmKeepMainMenu.Hide();
            string searchInput = txtSearchAll.Text;
            Operations.searchItem(searchInput);
        }


        /******************************************************************
        *             MAIN MENU - GET THE CORRECT LIST INDEX              *
        ******************************************************************/
        private void lstLeagues_Click(object sender, EventArgs e)
        {
            string fixtureLocation;


            int fixturePositionCounter = 0;
            int fixtureListViewIndex = 0;

            // if there are any teams pictures to choose from the listview
            if (this.lstLeagues.SelectedIndices.Count > 0)
            {
                fixtureListViewIndex = this.lstLeagues.SelectedIndices[0];
                fixtureLocation = lstLeagues.SelectedItems[0].ToString();

                // find team array position within a particular league...

                fixturePositionCounter = Operations.fixtureArrayPosition(fixturePositionCounter, fixtureLocation);


            }

            fixtureSelected = fixturePositionCounter;
        }


        /******************************************************************
        *                MAIN MENU - LEAGUE COMBO BOX CHANGED             *
        ******************************************************************/
        private void cboSelectedLeague_SelectedIndexChanged(object sender, EventArgs e)
        {
            // clear the listbox and listview...
            lstLeagues.Items.Clear();
            lstViewTeams.Clear();

            // change the selected leagues name...
            leagueSelected = cboTargetLeague.SelectedIndex;

            // rerender the images and fixtures in that league...
            Operations.showListOfFixtures(lstLeagues);
            renderImageList();
            lblOut.Text = cboTargetLeague.Text;
        }


        /******************************************************************
        *           MAIN MENU - RENDER THE IMAGES TO THE LISTVIEW         *
        ******************************************************************/
        public void renderImageList()
        {
            try
            {
                foreach (League l in allLeagues)
                {
                    string index = cboTargetLeague.SelectedItem.ToString();
                    string leagueName = l.getLeagueName();

                    if (leagueName == index)
                    {
                        foreach (Team t in allTeams)
                        {
                            try
                            {
                                // if the teams league and the combo box text match then render the logos 
                                // for that specific league
                                if (t.getTeamLeague() == cboTargetLeague.Text)
                                {
                                    Image teamIcon = Image.FromFile(@"../logos/" + t.getTeamLogo());

                                    imgLstIcons.Images.Add(teamIcon);

                                    lstViewTeams.Items.Add(new ListViewItem(t.getTeamName(), imgLstIcons.Images.Count - 1));
                                }
                            }
                            catch (FileNotFoundException)
                            {
                                MessageBox.Show("Error when loading file, file not found!", "File not found");
                            }

                        }
                    }
                }
            }

            catch (InvalidCastException iCe)
            {
                MessageBox.Show("There was a problem rendering the image list...\n\nTECHNICAL INFO: " + iCe.Message, "Oops, something went wrong...");
            }

        }


        /******************************************************************
        *                  MAIN MENU - SEARCH FOR A FIXTURE               *
        ******************************************************************/
        private void txtSearchFixtures_TextChanged(object sender, EventArgs e)
        {
            // declare local variables...
            League whichLeague;
            char[] compareA;
            char[] compareB;
            string input;
            int i, j;

            // initialise variables...
            input = txtSearchFixtures.Text;
            input.ToLower();

            // insert the lowercase input into the char array...
            compareA = input.ToCharArray();

            // render the label dependent on the selected league...
            lblOut.Text = cboTargetLeague.SelectedItem.ToString();
            lstLeagues.Items.Clear();

            // get the current league...
            whichLeague = (League)frmMainMenu.allLeagues[frmMainMenu.leagueSelected];
            whichLeague.getAllLeagueFixtures();


            // loop through each fixture in the current league...
            foreach (Fixture f in whichLeague.getAllLeagueFixtures())
            {
                // search through each character in the char array...
                foreach (char c in compareA)
                {
                    // local vars...
                    string home      = f.getFixtureHomeTeam();
                    string away      = f.getFixtureAwayTeam();
                    string date      = f.getFixtureDate();
                    string time      = f.getFixtureTime();
                    string location  = f.getFixtureLocation();
                    string fixTeams  = home + " " + away;
                    string fixTeamsA = home + " VS " + away;
                    string fixTeamsB = away + " VS " + home;
                    string compare   = new string(compareA).ToLower();

                    // format the output string...
                    string output    = (" " + f.getFixtureHomeTeam() + " VS " + f.getFixtureAwayTeam() + " on the " + f.getFixtureDate()
                                            + " at " + f.getFixtureTime() + " at " + f.getFixtureLocation());


                    // format the second char array...
                    compareB = (" " + f.getFixtureHomeTeam() + " VS " + f.getFixtureAwayTeam() + " on the " + f.getFixtureDate()
                                    + " at " + f.getFixtureTime() + " at " + f.getFixtureLocation()).ToCharArray();


                    // loop through each character in the second char array...
                    for (i = 0; i < compareB.Length; i++)
                    {
                        // if the input char appears at this index of char array b then...
                        if (c == compareB[i])
                        {
                            // loop through each item in the list and compare the output string to the item...
                            for (j = 0; j < lstLeagues.Items.Count; j++)
                            {
                                // if the item already exists then remove it at index j...
                                if (string.Compare(output, lstLeagues.Items[j].ToString()) == 0)
                                {
                                    lstLeagues.Items.RemoveAt(j);
                                    j++;
                                }
                            }

                            // create this string to append the next character in the search...
                            string soFar = new string(compareB).ToLower();

                            // set this string to lower for comparison...
                            compare.ToLower();

                            // check to see if the input is contained anywhere in the char array...
                            if (soFar.Contains(compare))
                            {
                                // add the matching output to the list...
                                lstLeagues.Items.Add(output);
                            }
                        }
                        
                        // check the next item...
                        else
                        {
                            i++;
                        }
                    }
                }
            }

            // if the box is empty, render the fixtures for that league...
            if (txtSearchFixtures.Text == "" || txtSearchFixtures.Text == " ")
            {
                Operations.showListOfFixtures(lstLeagues);
            }
        }


        /******************************************************************
        *         MAIN MENU - CHECK IF A MATCH NEEDS PROCESSING           *
        ******************************************************************/
        private void btnPendingResult_Click(object sender, EventArgs e)
        {
            // check whether there are any pending results...
            if (Operations.checkPendingResults() == true)
            {
                string input = "Fixtures pending results...";
                frmSearch.frmSearchClose.Show();
                frmKeepMainMenu.Hide();

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


        /******************************************************************
        *                  MAIN MENU - AESTHETIC FUNCTIONS                *
        ******************************************************************/
        private void txtSearchFixtures_Leave(object sender, EventArgs e)
        {
            lblOut.Text = cboTargetLeague.SelectedItem.ToString();
            txtSearchFixtures.BackColor = Color.FromArgb(28, 44, 66);
        }


        private void txtSearchFixtures_Enter(object sender, EventArgs e)
        {
            txtSearchFixtures.Text = "";
            txtSearchFixtures.BackColor = Color.FromArgb(34, 56, 86);
        }


        /******************************************************************
        *                  MAIN MENU - SEARCH FUNCTIONS                   *
        ******************************************************************/
        private void txtSearchAll_Enter(object sender, EventArgs e)
        {
            txtSearchAll.Text = "";
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        /******************************************************************
        *                  MAIN MENU - OPEN LEAGUE TABLE                  *
        ******************************************************************/
        private void btnViewLeagueTable_Click(object sender, EventArgs e)
        {
            frmKeepMainMenu.Hide();
            frmLeagueTable.frmKeepLeagueTable.Show();
        }

    }
}
