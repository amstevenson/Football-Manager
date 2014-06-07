using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

/************************************************************************************
*                                   SEARCH.CS                                       *
-------------------------------------------------------------------------------------
*                 SOFT130 ASSIGNMENT 2013 - FOOTBALL LEAGUE MANAGER                 *
************************************************************************************* 
*     COURSE              - BSC COMPUTING                                           *
*     CREATED BY          - SHARPE SOLUTIONS                                        *
*     TEAM MEMBERS        - ALEX SIMS, ADAM STEVENSON, MATT SMITH                   *
*                                                                                   *
*     NOTE                - LUKE WOODHEAD DID NOT CONTRIBUTE TO THE DEVELOPMENT     *
*                           OF THIS SOLUTION.                                       *
*************************************************************************************    
*                 Results on this form are generated via the searchItem()           *
*                 method in Operations - any form can access its input,             *
*                 but this form can only render the output...                       *
*                                                                                   *
************************************************************************************/

namespace Football_Manager_SOFT130
{
    public partial class frmSearch : Form
    {
        // set reference to the form...
        public static frmSearch frmSearchClose = null;
    
        public frmSearch()
        {
            InitializeComponent();
            frmSearchClose = this;
        }

        /******************************************************************
        *                SEARCH - DISPLAY THE SEARCH RESULTS              *
        ******************************************************************/
        public void displayResults(string result)
        {
            txtDynamicSearch.Text = " Search for fixtures, teams and leagues...";
            // add the list items (method takes input from operations)...
            lstSearchResults.Items.Add(result);
        }


        /******************************************************************
        *            SEARCH - DISPLAY MATCHES PENDING A RESULT            *
        ******************************************************************/
        public void displayPendingFixtures(string input)
        {
            txtDynamicSearch.Text = " Search for fixtures...";
            // add the list items dependent on method from Operations.populatePendingSearches...
            lstSearchResults.Items.Add(input);
        }

        

        /******************************************************************
        *              SEARCH - SET SEARCH CRITERIA AS LABEL              *
        ******************************************************************/
        public void renderLabel(string result)
        {
            // search criteria is set in operations...
            lblSearchResult.Text = result;
        }

        /******************************************************************
        *                      SEARCH - GO TO MAIN MENU                   *
        ******************************************************************/
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            lstSearchResults.Items.Clear();

            frmMainMenu.frmKeepMainMenu.Show();
            frmSearchClose.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        /******************************************************************
        *      SEARCH - SET THE INDEXES OF LISTBOX FOR EDITING ITEMS      *
        ******************************************************************/
        private void lstSearchResults_Click(object sender, EventArgs e)
        {
            string searchInput;
            int listViewIndex;

            int[] indexPositions = {0,0,0}; // initialise the array indexes

           
            // if there are any teams to choose from the list...
            if (this.lstSearchResults.SelectedIndices.Count > 0)
            {
                listViewIndex = this.lstSearchResults.SelectedIndices[0];
                searchInput = lstSearchResults.SelectedItems[0].ToString();

                // append the search type to the front of the result...
                searchInput = Regex.Replace(searchInput, @"FIXTURE:", "");
                searchInput = Regex.Replace(searchInput, @"\nTEAM:", "");
                searchInput = Regex.Replace(searchInput, @"\nLEAGUE:", "");

                // find fixture, team, and league array positions based on search result...
                indexPositions = Operations.searchbarArrayPositions(searchInput);
            }

            // set the selectedIndex to the value in the array (determined by method in operations...)
            frmMainMenu.leagueSelected = indexPositions[0];
            frmMainMenu.fixtureSelected = indexPositions[1];
            frmMainMenu.teamSelected = indexPositions[2];

            // refresh the mainMenu...
            frmMainMenu.frmKeepMainMenu.Refresh();
        }


        /******************************************************************
        *                       SEARCH - EDIT LEAGUE                      *
        ******************************************************************/
        private void btnEditLeague_Click(object sender, EventArgs e)
        {
            frmEditLeague tempEditLeague = new frmEditLeague();
            tempEditLeague.Show();
            frmSearch.frmSearchClose.Hide();
        }

        /******************************************************************
        *                      SEARCH - EDIT FIXTURE                      *
        ******************************************************************/
        private void btnEditFixture_Click(object sender, EventArgs e)
        {
            lstSearchResults.Items.Clear();
            frmEditFixture tempEditFixture = new frmEditFixture();
            tempEditFixture.Show();
            frmSearch.frmSearchClose.Hide();
        }

        /******************************************************************
        *                       SEARCH - EDIT TEAM                        *
        ******************************************************************/
        private void btnEditTeam_Click(object sender, EventArgs e)
        {
            frmEditTeam tempEditTeam = new frmEditTeam();
            tempEditTeam.Show();
            frmSearch.frmSearchClose.Hide();
        }


        /******************************************************************
        *                       SEARCH - VIA FORM                         *
        ******************************************************************/
        private void btnSearchForm_Click(object sender, EventArgs e)
        {
            lstSearchResults.Items.Clear();
            renderSearchDisplay();
            string searchInput = textBox1.Text;
            Operations.searchItem(searchInput);
        }


        /******************************************************************
        *        SEARCH - RENDER ALTERNATE INTERFACE FOR RESULTS          *
        ******************************************************************/
        public void renderResultDisplay()
        {
            // refresh the form..
            frmSearchClose.Refresh();

            // hide the buttons...
            btnEditLeague.Hide();
            btnEditTeam.Hide();

            // set new positions...
            btnEditLeague.Location = new Point(0, 0);
            btnEditTeam.Location = new Point(0, 0);
            btnEditFixture.Location = new Point(1080, 526);
            btnEditFixture.Text = "Process Result";
        }


        /******************************************************************
        *        SEARCH - RENDER ALTERNATE INTERFACE FOR SEARCH           *
        ******************************************************************/
        public void renderSearchDisplay()
        {
            // refresh the form...
            frmSearchClose.Refresh();

            // hide the buttons...
            btnEditLeague.Show();
            btnEditTeam.Show();
            btnEditFixture.Show();

            // set new positions...
            btnEditLeague.Location = new Point(919, 526);
            btnEditTeam.Location = new Point(1080, 526);
            btnEditFixture.Location = new Point(758, 526);
            btnEditFixture.Text = "Edit Fixture";
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }


        /******************************************************************
        *                     SEARCH - REAL TIME SEARCH                   *
        ******************************************************************/
        private void txtDynamicSearch_TextChanged(object sender, EventArgs e)
        {
            // declare local variables...
            League whichLeague;
            char[] compareA;
            char[] compareB;
            string input;
            int i, j;

            // initialise variables...
            input = txtDynamicSearch.Text;
            input.ToLower();

            // insert the lowercase input into the char array...
            compareA = input.ToCharArray();


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
                    string home = f.getFixtureHomeTeam();
                    string away = f.getFixtureAwayTeam();
                    string date = f.getFixtureDate();
                    string time = f.getFixtureTime();
                    string location = f.getFixtureLocation();
                    string fixTeams = home + " " + away;
                    string fixTeamsA = home + " VS " + away;
                    string fixTeamsB = away + " VS " + home;
                    string compare = new string(compareA).ToLower();

                    // format the output string...
                    string output = (" " + f.getFixtureHomeTeam() + " VS " + f.getFixtureAwayTeam() + " on the " + f.getFixtureDate()
                                            + " at " + f.getFixtureTime() + " at " + f.getFixtureLocation());


                    // format the second char array...
                    compareB = (" " + f.getFixtureHomeTeam() + " VS " + f.getFixtureAwayTeam() + " on the " + f.getFixtureDate()
                                    + " at " + f.getFixtureTime() + " at " + f.getFixtureLocation()).ToCharArray();


                    // show what the user is searching for...
                    string searchString = new String(compareA);
                    lblSearchResult.Text = searchString;


                    // loop through each character in the second char array...
                    for (i = 0; i < compareB.Length; i++)
                    {
                        // if the input char appears at this index of char array b then...
                        if (c == compareB[i])
                        {
                            // loop through each item in the list and compare the output string to the item...
                            for (j = 0; j < lstSearchResults.Items.Count; j++)
                            {
                                // if the item already exists then remove it at index j...
                                if (string.Compare(output, lstSearchResults.Items[j].ToString()) == 0)
                                {
                                    lstSearchResults.Items.RemoveAt(j);
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
                                lstSearchResults.Items.Add(output);
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

            
        }

        /******************************************************************
        *                    SEARCH - AESTHETIC FUNCTIONS                 *
        ******************************************************************/
        private void txtDynamicSearch_Leave(object sender, EventArgs e)
        {
            txtDynamicSearch.BackColor = Color.FromArgb(28, 44, 66);
        }


        private void txtDynamicSearch_Enter(object sender, EventArgs e)
        {
            txtDynamicSearch.Text = "";
            txtDynamicSearch.BackColor = Color.FromArgb(34, 56, 86);
        }

        /******************************************************************
        *           SEARCH - CHECK IF A MATCH NEEDS PROCESSING            *
        ******************************************************************/
        private void btnPendingResult_Click(object sender, EventArgs e)
        {
            // clear the list...
            lstSearchResults.Items.Clear();

            // check whether there are any pending results...
            if (Operations.checkPendingResults() == true)
            {
                string input = "Fixtures pending results...";
                frmSearch.frmSearchClose.Show();

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
