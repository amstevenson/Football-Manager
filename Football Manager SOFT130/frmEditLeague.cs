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
*                                  editLeague.cs                                    *
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
    public partial class frmEditLeague : Form
    {
        public static frmEditLeague frmKeepEditLeague = null; // need reference to call form back

        // MAIN ENTRY POINT...
        public frmEditLeague()
        {
            InitializeComponent();
            frmKeepEditLeague = this;
            getLeagueDetails();
        }


        /******************************************************************
        *               EDIT LEAGUE - EDIT THE SELECTED LEAGUE            *
        ******************************************************************/
        private void btnEditLeague_Click(object sender, EventArgs e)
        {
            // local variables..
            bool allInputOK = false;
            League whichLeague = (League)frmMainMenu.allLeagues[frmMainMenu.leagueSelected];

            // get inputs - LEAGUE ORDER = Name, Sponsor, Prize, NumberOfTeams...
            string tempLeagueName        = txtLeagueName.Text;
            string tempLeagueSponsor     = txtLeagueSponsor.Text;
            string tempLeaguePrize       = txtLeaguePrize.Text;
            string tempLeagueNumFixtures = txtLeagueNumFixtures.Text;

            // define the validation...
            allInputOK = Operations.notNullTextBox(txtLeagueName, "the Name") && Operations.notNullTextBox(txtLeagueSponsor, "the Sponsor") &&
                         Operations.notNullTextBox(txtLeaguePrize, "the Prize") && Operations.notNullTextBox(txtLeagueNumFixtures, "the Number of Teams");


            // if the validation passes...
            if (allInputOK)
            {
                League tempLeague = new League(tempLeagueName, tempLeagueSponsor, tempLeaguePrize, Convert.ToInt32(tempLeagueNumFixtures)); //create League        

                whichLeague.replaceLeague(frmMainMenu.allLeagues, tempLeague, frmMainMenu.leagueSelected);

                // write the amended league object to the text file...
                Operations.writeAllLeagues(frmMainMenu.inputFootball, frmMainMenu.allLeagues); //update file 
                MessageBox.Show("Success: League " + tempLeagueName + " added"); //feedback to user
                resetForm();

            }
   
        }


        /******************************************************************
        *       EDIT LEAGUE - GET THE DETAILS OF THE SELECTED LEAGUE      *
        ******************************************************************/
        private void getLeagueDetails()
        {
            // get the current league...
            League currentLeague = (League)frmMainMenu.allLeagues[frmMainMenu.leagueSelected];

            // set the forms values to the current leagues values...
            txtLeagueName.Text        = currentLeague.getLeagueName();
            txtLeagueSponsor.Text     = currentLeague.getLeagueSponsor();
            txtLeaguePrize.Text       = currentLeague.getLeaguePrize();
            txtLeagueNumFixtures.Text = currentLeague.getNumLeagueFixtures().ToString();
        }


        /******************************************************************
        *                EDIT LEAGUE - RESET FORM FIELDS                  *
        ******************************************************************/
        private void resetForm()
        {
            //LEAGUE ORDER = Name, Sponsor, Prize, NumberOfTeams
            txtLeagueName.Text        = "";
            txtLeagueSponsor.Text     = "";
            txtLeaguePrize.Text       = "";
            txtLeagueNumFixtures.Text = "";

        }


        /******************************************************************
        *               EDIT LEAGUE - RETURN TO THE MAIN MENU             *
        ******************************************************************/
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            frmMainMenu.frmKeepMainMenu.Show();
            frmKeepEditLeague.Close();
        }


        /******************************************************************
        *               EDIT LEAGUE - DELETE THE SELECTED LEAGUE          *
        ******************************************************************/
        private void btnDeleteLeague_Click(object sender, EventArgs e)
        {
            League deleteLeague;

            // get the selected league...
            deleteLeague = (League)frmMainMenu.allLeagues[frmMainMenu.leagueSelected];

            int removeFixtureCount = Math.Max(0, deleteLeague.getAllLeagueFixtures().Count);
            deleteLeague.getAllLeagueFixtures().RemoveRange(0, removeFixtureCount);

            frmMainMenu.allLeagues.RemoveAt(frmMainMenu.leagueSelected); //remove league at the selected index, dependant on the variable leagueCboPosition

            // loop through the teams...
            foreach (Team t in frmMainMenu.allTeams.ToArray())
            {
                // check the correct team is selected...
                if (t.getTeamLeague() == deleteLeague.getLeagueName())
                {
                    int teamPositionCounter = 0;
                    string teamName = t.getTeamName();

                    // find team array position within a particular league
                    teamPositionCounter = Operations.teamArrayPosition(teamPositionCounter, teamName);

                    frmMainMenu.teamSelected = teamPositionCounter;


                    Team deleteTeam;
                    deleteTeam = (Team)frmMainMenu.allTeams[frmMainMenu.teamSelected];

                    frmMainMenu.allTeams.RemoveAt(frmMainMenu.teamSelected); //remove team at the selected index, dependant on the variable teamSelected
                    Operations.writeAllTeams(frmMainMenu.inputTeams, frmMainMenu.allTeams);
                }
            }

            Operations.writeAllLeagues(frmMainMenu.inputFootball, frmMainMenu.allLeagues);
            Operations.writeAllFixtures(frmMainMenu.inputFootball, frmMainMenu.allLeagues);

            MessageBox.Show("Success - League: " + txtLeagueName.Text + " has been deleted.");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmEditLeague.frmKeepEditLeague.Hide();
            string searchInput = txtSearchAll.Text;
            Operations.searchItem(searchInput);
        }


        /******************************************************************
        *       EDIT LEAGUE - CHECK IF A MATCH NEEDS PROCESSING           *
        ******************************************************************/
        private void btnPendingResult_Click(object sender, EventArgs e)
        {
            // check whether there are any pending results...
            if (Operations.checkPendingResults() == true)
            {
                string input = "Fixtures pending results...";
                frmSearch.frmSearchClose.Show();
                frmKeepEditLeague.Hide();

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

        private void frmEditLeague_Load(object sender, EventArgs e)
        {

        }

    }
}
