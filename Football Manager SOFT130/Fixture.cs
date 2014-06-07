using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Windows.Forms;

    /************************************************************************************
    *                                   FIXTURE.CS                                      *
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
    class Fixture
    {
        /******************************************************************
        *                 FIXTURE - CLASS LEVEL VARIABLES                 *
        ******************************************************************/
        private string fixtureDate;
        private string fixtureTime;
        private string fixtureLocation;
        private string fixtureHomeTeam;
        private string fixtureAwayTeam;

       
        /******************************************************************
        *                     FIXTURE - CONSTRUCTOR                       *
        ******************************************************************/

        // FIXTURE ORDER = fixtureDate, fixtureTime, fixtureLocation, fixtureHomeTeam, fixtureAwayTeam
        public Fixture(string theFixtureDate, string theFixtureTime, string theFixtureLocation,
                       string theFixtureHomeTeam, string theFixtureAwayTeam)
        {

            fixtureDate      =  theFixtureDate;
            fixtureTime      =  theFixtureTime;
            fixtureLocation  =  theFixtureLocation;
            fixtureHomeTeam  =  theFixtureHomeTeam;
            fixtureAwayTeam  =  theFixtureAwayTeam;
           
        }


        /******************************************************************
        *                   FIXTURE - GETTER METHODS                      *
        ******************************************************************/
        public string getFixtureDate()
        {
            return fixtureDate;
        }


        public string getFixtureTime()
        {
            return fixtureTime;
        }


        public string getFixtureLocation()
        {
            return fixtureLocation;
        }


        public string getFixtureHomeTeam()
        {
            return fixtureHomeTeam;
        }


        public string getFixtureAwayTeam()
        {
            return fixtureAwayTeam;
        }

        public string getFullFixture()
        {
            string fullFixture;

            fullFixture = " " + getFixtureHomeTeam() + " VS " + getFixtureAwayTeam() + " on the " + getFixtureDate()
                              + " at " + getFixtureTime() + " at " + getFixtureLocation();

            return fullFixture;
        }


        /******************************************************************
        *                    LEAGUE - SETTER METHODS                      *
        ******************************************************************/
        public void setFixtureDate(string inFixtureDate)
        {
            fixtureDate = inFixtureDate;
        }


        public void setFixtureTime(string inFixtureTime)
        {
            fixtureTime = inFixtureTime;
        }


        public void setFixtureLocation(string inFixtureLocation)
        {
            fixtureLocation = inFixtureLocation;
        }


        public void setFixtureHomeTeam(string inFixtureHomeTeam)
        {
            fixtureHomeTeam = inFixtureHomeTeam;
        }


        public void setFixtureAwayTeam(string inFixtureAwayTeam)
        {
            fixtureAwayTeam = inFixtureAwayTeam;
        }

    }// end fixture class
}
