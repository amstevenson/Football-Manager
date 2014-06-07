using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Football_Manager_SOFT130
{
    public partial class frmLeagueTable : Form
    {
        public static frmLeagueTable frmKeepLeagueTable = new frmLeagueTable();
        public static ArrayList storeTeams = new ArrayList();
        public static int i;

        public frmLeagueTable()
        {
            InitializeComponent();
            frmKeepLeagueTable = this;
        }

        private void frmLeagueTable_Load(object sender, EventArgs e)
        {
            populateLeague();
        }
        
        private void populateLeague()
        {
            foreach (League l in frmMainMenu.allLeagues)
            {
                string option;
                option = l.getLeagueName();
                cboLeagues.Items.Add(option);
            }
        }

        private void cboLeagues_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstLeagues.Refresh();


            foreach (Team t in frmMainMenu.allTeams)
            {
                if (t.getTeamLeague() == cboLeagues.SelectedItem.ToString())
                {
                    string theTeam;
                    theTeam = t.getTeamInfo().ToString();
                    storeTeams.Insert(0, theTeam);
                }
            }


            foreach (string s in storeTeams)
            {
                MessageBox.Show("The team " + s, "TEAM ARRAY STUFFS");
            }
        }

        private void lstLeagues_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            frmKeepLeagueTable.Hide();
            frmMainMenu.frmKeepMainMenu.Show();
        }


        /******************************************************************
        *        LEAGUE TABLE - CHECK IF A MATCH NEEDS PROCESSING         *
        ******************************************************************/
        private void btnPendingResult_Click(object sender, EventArgs e)
        {
            // check whether there are any pending results...
            if (Operations.checkPendingResults() == true)
            {
                string input = "Fixtures pending results...";
                frmSearch.frmSearchClose.Show();
                frmKeepLeagueTable.Hide();

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

        }
    }
}
