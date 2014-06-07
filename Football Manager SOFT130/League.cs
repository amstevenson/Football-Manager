using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Windows.Forms;

/************************************************************************************
*                                   LEAGUE.CS                                       *
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
    class League
    {
        /******************************************************************
        *                 LEAGUE - CLASS LEVEL VARIABLES                  *
        ******************************************************************/
        private string leagueName;
        private string leagueSponsor;
        private string leaguePrize;
        private int leagueNumFixtures;
        private int leagueNumTeams;
        int leagueCount= frmMainMenu.allLeagues.Count;

        private ArrayList leagueAllFixtures;
        private ArrayList leagueAllTeams;



        /******************************************************************
        *                      LEAGUE - CONSTRUCTOR                       *
        ******************************************************************/
        // LEAGUE ORDER = leagueName, leagueSponsor, leaguePrize, leagueNumTeams
        public League(string theLeagueName, string theLeagueSponsor, string theLeaguePrize,
                      int theLeagueNumFixtures)
        {
            leagueName        = theLeagueName;
            leagueSponsor     = theLeagueSponsor;
            leaguePrize       = theLeaguePrize;
            leagueNumFixtures = theLeagueNumFixtures;
            leagueNumTeams    = 0;

            leagueAllFixtures = new ArrayList();
            leagueAllTeams = new ArrayList();
        }


        /******************************************************************
        *                 LEAGUE - ADD FIXTURE TO LEAGUE                  *
        ******************************************************************/
        public ArrayList addFixtureToLeague(ArrayList leagueFixtures, Fixture theNewFixture)
        {
            leagueFixtures.Add(theNewFixture);
            leagueNumFixtures = leagueFixtures.Count;

            return leagueFixtures;
        }


        /******************************************************************
        *                   LEAGUE - ADD TEAM TO LEAGUE                   *
        ******************************************************************/
        public ArrayList addTeamToLeague(ArrayList leagueAllTeams, Team theNewTeam)
        {
            leagueAllTeams.Add(theNewTeam);

            leagueNumTeams = leagueAllTeams.Count;

            return leagueAllTeams;
        }


        /******************************************************************
        *                  LEAGUE - EDIT EXISTING LEAGUE                  *
        ******************************************************************/
        public ArrayList replaceLeague(ArrayList theLeague, League newLeague, int location)
        {
            League old = (League)theLeague[location];
            League newL = newLeague;
            theLeague[location] = newLeague;

            return theLeague;
        }

        public ArrayList replaceFixture(ArrayList theFixture, Fixture newFixture, int location)
        {
            theFixture[location] = newFixture;

            return theFixture;
        }


        public void deleteFixture(ArrayList theFixture, Fixture thisFixture, int location)
        {
            theFixture[location] = thisFixture;
            theFixture.RemoveAt(location);
        }


        /******************************************************************
        *                      TEAM - GETTER METHODS                      *
        ******************************************************************/
        public string getLeagueName()
        {
            return leagueName;
        }


        public string getLeagueSponsor()
        {
            return leagueSponsor;
        }


        public string getLeaguePrize()
        {
            return leaguePrize;
        }


        public int getNumLeagueFixtures()
        {
            return leagueNumFixtures;
        }


        public ArrayList getAllLeagueFixtures()
        {
            return leagueAllFixtures;
        }


        public ArrayList getAllLeagueTeams()
        {

            return leagueAllTeams;

        }


        /******************************************************************
        *                    LEAGUE - SETTER METHODS                      *
        ******************************************************************/
        public void setLeagueName(string inLeagueName)
        {
            leagueName = inLeagueName;
        }


        public void setLeagueSponsor(string inLeagueSponsor)
        {
            leagueSponsor = inLeagueSponsor;
        }


        public void setLeaguePrize(string inLeaguePrize)
        {
            try
            {
                leaguePrize = inLeaguePrize;
            }

            catch (FormatException e)
            {
                MessageBox.Show("ERROR: The system was unable to determine what the prize for the league >> " + leagueName
                               + " << is, due to a format error of the input string.\n" + "TECHNICAL INFORMATION: " + e.Message, "ERROR");
            }
        }


        public void setNumLeagueFixtures(int inNumLeagueFixtures)
        {
            try
            {
                leagueNumFixtures = inNumLeagueFixtures;
            }
            catch (FormatException e)
            {
                MessageBox.Show("ERROR: The number of fixtures in >> " + leagueName + " << could not be determined due to "
                                + "a format error in the input string.\n" + "TECHNICAL INFORMATION: " + e.Message, "ERROR");
            }
        }


    } // end league class
}
