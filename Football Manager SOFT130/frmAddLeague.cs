using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

/************************************************************************************
*                                  addLeague.cs                                     *
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
    public partial class frmAddLeague : Form
    {
        public static frmAddLeague frmKeepAddLeague = null; //need reference to call form back

        // MAIN ENTRY POINT...
        public frmAddLeague()
        {
            InitializeComponent();
            frmKeepAddLeague = this;
        }


        /******************************************************************
        *              ADD LEAGUE - ADD THE NEW LEAGUE OBJECT             *
        ******************************************************************/
        private void btnAddLeague_Click(object sender, EventArgs e)
        {
            bool allInputOK = false;

            //get inputs - LEAGUE ORDER = Name, Sponsor, Prize, NumberOfTeams
            string tempLeagueName        = txtLeagueName.Text;
            string tempLeagueSponsor     = txtLeagueSponsor.Text;
            string tempLeaguePrize       = txtLeaguePrize.Text;
            string tempLeagueNumFixtures = txtLeagueNumFixtures.Text;

            allInputOK = Operations.notNullTextBox(txtLeagueName, "the Name") && Operations.notNullTextBox(txtLeagueSponsor, "the Sponser") &&
                         Operations.notNullTextBox(txtLeaguePrize, "the Prize") && Operations.notNullTextBox(txtLeagueNumFixtures, "the Number of Teams");

            // if the validation passes...
            if (allInputOK)
            {
                League tempLeague = new League(tempLeagueName, tempLeagueSponsor, tempLeaguePrize, Convert.ToInt32(tempLeagueNumFixtures)); //create League               
                frmMainMenu.allLeagues.Add(tempLeague);
                Operations.writeAllLeagues(frmMainMenu.inputFootball, frmMainMenu.allLeagues);//update file 
                MessageBox.Show("Success: League " + tempLeagueName + " added"); //feedback to user
                resetForm();

            }
        }


        /******************************************************************
        *                   ADD LEAGUE - RESET THE FORM                   *
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
        *              ADD LEAGUE - GO BACK TO THE MAIN MENU              *
        ******************************************************************/
        private void btnMainMenu_Click(object sender, EventArgs e)
        {

            frmMainMenu.frmKeepMainMenu.Show();
            frmKeepAddLeague.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmAddLeague.frmKeepAddLeague.Hide();
            string searchInput = txtSearchAll.Text;
            Operations.searchItem(searchInput);
        }


        /******************************************************************
        *         ADD LEAGUE - CHECK IF A MATCH NEEDS PROCESSING          *
        ******************************************************************/
        private void btnPendingResult_Click(object sender, EventArgs e)
        {
            // check whether there are any pending results...
            if (Operations.checkPendingResults() == true)
            {
                string input = "Fixtures pending results...";
                frmSearch.frmSearchClose.Show();
                frmKeepAddLeague.Hide();

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
