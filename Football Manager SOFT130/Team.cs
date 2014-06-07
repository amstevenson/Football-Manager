using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Windows.Forms;

    /************************************************************************************
    *                                    TEAM.CS                                        *
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
    class Team
    {
        /******************************************************************
        *                   TEAM - CLASS LEVEL VARIABLES                  *
        ******************************************************************/
        private string     teamName;
        private string     teamLeague;
        private string     teamManager;
        private string     teamNickname;
        private string     teamStadium;
        private int        teamPosition;
        private int        teamPoints;
        private int        teamGamesPlayed;
        private int        teamGoalDifference;
        private string     teamLogo;
        private int        teamNumPlayers;
        int                numTeams;
        ArrayList          allTeams;

        /******************************************************************
        *                     TEAM - LOAD CONSTRUCTOR                     *
        ******************************************************************/
        // TEAM ORDER = teamName, teamManager, teamNickname, teamStadium, teamPosition, teamPoints, teamGamesPlayed, teamGoalDifference, teamLogo, teamNumPlayers
        public Team(string theTeamName, string theTeamLeague, string theTeamManager ,string theTeamNickname, string theTeamStadium,
                    int theTeamPosition, int theTeamPoints, int theTeamGamesPlayed, int theTeamGoalDifference,
                    string theTeamLogo, int theTeamNumPlayers, int theNumberOfTeams)
        {

            teamName            =   theTeamName;
            teamLeague          =   theTeamLeague;
            teamManager         =   theTeamManager;
            teamNickname        =   theTeamNickname;
            teamStadium         =   theTeamStadium;
            teamPosition        =   theTeamPosition;
            teamPoints          =   theTeamPoints;
            teamGamesPlayed     =   theTeamGamesPlayed;
            teamGoalDifference  =   theTeamGoalDifference;
            teamLogo            =   theTeamLogo;
            teamNumPlayers      =   theTeamNumPlayers;

            numTeams            =   theNumberOfTeams;
            allTeams            =   new ArrayList();

        }


        /******************************************************************
        *                     TEAM - MAIN CONSTRUCTOR                     *
        ******************************************************************/        
        //TEAM ORDER = teamName, teamManager, teamNickname, teamStadium, teamPosition, teamPoints, teamGamesPlayed, teamGoalDifference, teamLogo, teamNumPlayers
        public Team(string theTeamName, string theTeamLeague, string theTeamManager, string theTeamNickname, string theTeamStadium,
                    int theTeamPosition, int theTeamPoints, int theTeamGamesPlayed, int theTeamGoalDifference,
                    string theTeamLogo, int theTeamNumPlayers)
        {

            teamName = theTeamName;
            teamLeague = theTeamLeague;
            teamManager = theTeamManager;
            teamNickname = theTeamNickname;
            teamStadium = theTeamStadium;
            teamPosition = theTeamPosition;
            teamPoints = theTeamPoints;
            teamGamesPlayed = theTeamGamesPlayed;
            teamGoalDifference = theTeamGoalDifference;
            teamLogo = theTeamLogo;
            teamNumPlayers = theTeamNumPlayers;

            numTeams = 0;
            allTeams = new ArrayList();

        }

        /******************************************************************
        *                   TEAM - ADD TEAM TO TEAMS                      *
        ******************************************************************/
        public ArrayList addNewTeam(ArrayList currentTeams, Team newTeam)
        {
            currentTeams.Add(newTeam);

            numTeams = currentTeams.Count;

            return currentTeams;
 
        }

        /******************************************************************
        *                      TEAM - REPLACE TEAM                        *
        ******************************************************************/
        public ArrayList replaceTeam(ArrayList theTeam, Team amendedTeam, int location)
        {
            theTeam[location] = amendedTeam;

            return theTeam;
        }

        /******************************************************************
        *                      TEAM - GETTER METHODS                      *
        ******************************************************************/
        public string getTeamName()
        {
            return teamName;
        }

        public string getTeamLeague()
        {
            return teamLeague;
        }

        public string getTeamManager()
        {
            return teamManager;
        }


        public string getTeamNickname()
        {
            return teamNickname;
        }


        public string getTeamStadium()
        {
            return teamStadium;
        }


        public int getTeamPosition()
        {
            return teamPosition;
        }


        public int getTeamPoints()
        {
            return teamPoints;
        }


        public int getTeamGamesPlayed()
        {
            return teamGamesPlayed;
        }


        public int getTeamGoalDifference()
        {
            return teamGoalDifference;
        }

        public string getTeamLogo()
        {
            return teamLogo;
        }

        public int getTeamNumPlayers()
        {
            return teamNumPlayers;
        }

        public int getNumberOfTeams()
        {
            return numTeams;
        }

        public string getTeamInfo()
        {
            string teamInfo;

            teamInfo = teamInfo = "Team: " + getTeamName() + " Managed by: " + getTeamManager() + " Plays at: " + getTeamStadium() 
                                + " Known as: " + getTeamNickname() + " Current position: " + getTeamPosition(); 

            return teamInfo;
        }

        public ArrayList getAllTeams()
        {
            return allTeams;
        }

        /******************************************************************
        *                      TEAM - SETTER METHODS                      *
        ******************************************************************/
        public void setTeamName(string inTeamName)
        {
            teamName = inTeamName;
        }

        public void setTeamLeague(string inTeamLeague)
        {
            teamLeague = inTeamLeague;
        }

        public void setTeamManager(string inTeamManager)
        {
            teamManager = inTeamManager;
        }


        public void setTeamNickname(string inTeamNickname)
        {
            teamNickname = inTeamNickname;
        }


        public void setTeamStadium(string inTeamStadium)
        {
            teamStadium = inTeamStadium;
        }


        public void setTeamPosition(int inTeamPosition)
        {
            teamPosition = inTeamPosition;
        }

        public void setNumberOfTeams(int inNumberOfTeams)
        {
            numTeams = inNumberOfTeams;
        }


        public void setTeamPoints(int inTeamPoints)
        {
            teamPoints = inTeamPoints;
        }


        public void setTeamGamesPlayed(int inTeamGamesPlayed)
        {
            teamGamesPlayed = inTeamGamesPlayed;
        }


        public void setTeamGoalDifference(int inTeamGoalDifference)
        {
            teamGoalDifference = inTeamGoalDifference;
        }


        public void setTeamLogo(string inTeamLogo)
        {
            teamLogo = inTeamLogo;
        }


        public void setTeamNumPlayers(int inTeamNumPlayers)
        {
            teamNumPlayers = inTeamNumPlayers;
        }

        public void setAllTeams(ArrayList inAllTeams)
        {
            allTeams = inAllTeams;
        }

    } // end team class
}
