using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.IO;
using System.Collections;
using System.Windows.Forms;

/************************************************************************************
*                                 OPERATIONS.CS                                     *
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
    class Operations
    {
        public static frmSearch frmKeepSearch = new frmSearch();

        /******************************************************************
        *          OPERATIONS - READ IN LEAGUE & FIXTURE DATA             *
        ******************************************************************/
        public static void readFootball(string theFile, ArrayList allLeaguesandFixtures)
        {
            // local variables
            StreamReader inLeagues = null;
            bool anyMoreLeaguesAndFixtures = false;
            string[] leagueData = new string[frmMainMenu.numLeagueItems];
            string[] FixtureData = new string[frmMainMenu.numFixtureItems];
            League tempLeague;
            Fixture tempFixture;
            int numFixturesInLeagues;

            // if the file opened without error then...
            if (Operations.fileOpenForReadOK(theFile, ref inLeagues))
            {
                // read the first League Fixtures
                anyMoreLeaguesAndFixtures = Operations.getNext(frmMainMenu.numLeagueItems, inLeagues, leagueData);

                // loop through for all League's in file
                while (anyMoreLeaguesAndFixtures == true)
                {
                    try
                    {
                        numFixturesInLeagues = Convert.ToInt32(leagueData[3]);      // last item is num of teams

                        // LEAGUE ORDER = leagueName, leagueSponsor, leaguePrize, leagueNumFixtures
                        tempLeague = new League(leagueData[0], leagueData[1], leagueData[2], Convert.ToInt32(leagueData[3]));

                        // Read all Fixture's into the League
                        for (int i = 0; i < numFixturesInLeagues; i++)
                        {
                            getNext(frmMainMenu.numFixtureItems, inLeagues, FixtureData);

                            // Fixture order = fixtureData, fixtureTime, fixtureLocation, fixtureHomeTeam, fixtureAwayTeam
                            tempFixture = new Fixture(FixtureData[0], FixtureData[1], FixtureData[2], FixtureData[3], FixtureData[4]);

                            tempLeague.addFixtureToLeague(tempLeague.getAllLeagueFixtures(), tempFixture);

                        }

                        // add the league and its fixtures into the data-structure
                        allLeaguesandFixtures.Add(tempLeague);
                        //tempLeague.addLeagueToLeague(tempLeague.getAllLeagues(), tempLeague);

                        anyMoreLeaguesAndFixtures = getNext(frmMainMenu.numLeagueItems, inLeagues, leagueData);
                    }
                    catch (FormatException)
                    {
                        break;
                    }
                }
            }

            // close the streamReader 
            if (inLeagues != null) inLeagues.Close();

            //   foreach (League L in allLeaguesandFixtures)
            // {

            //   L.addLeagueToLeague(L.getAllLeagues(), L);


            //    }


        } // end read books


        /******************************************************************
        *                  OPERATIONS - READ IN TEAM DATA                 *
        ******************************************************************/
        public static void readTeams(string theFile, ArrayList existingTeams)
        {
            // local variables
            StreamReader inTeams = null;
            bool anyMoreTeams = false;
            string[] teamData = new string[frmMainMenu.numTeamItems];
            Team tempTeam;
            int numOfTeams;

            // if the file opened without error then...
            if (Operations.fileOpenForReadOK(theFile, ref inTeams))
            {
                // read the first Team from the file
                anyMoreTeams = Operations.getNext(frmMainMenu.numTeamItems, inTeams, teamData);

                // loop through for all TEAMS in file
                while (anyMoreTeams == true)
                {
                    numOfTeams = Convert.ToInt32(teamData[10]); // last item is num of teams

                    // TEAM ORDER = teamName, teamManager, teamNickname, teamStadium, teamPosition, teamPoints, teamGamesPlayed, teamGoalDifference, teamLogo, teamNumPlayers
                    tempTeam = new Team(teamData[0], teamData[1], teamData[2], teamData[3], teamData[4], Convert.ToInt32(teamData[5]), Convert.ToInt32(teamData[6]),
                                        Convert.ToInt32(teamData[7]), Convert.ToInt32(teamData[8]), teamData[9], Convert.ToInt32(teamData[10]), numOfTeams);


                    existingTeams.Add(tempTeam);


                    anyMoreTeams = getNext(frmMainMenu.numTeamItems, inTeams, teamData);



                }
            }

            // close the StreamReader
            if (inTeams != null) inTeams.Close();

        } //end read books


        /******************************************************************
        *                    OPERATIONS - GET NEXT ITEM                   *
        ******************************************************************/
        public static bool getNext(int numItems, StreamReader inNext, string[] nextArrayData)
        {
            //locals
            string nextLine;
            int numDataItems = numItems;

            //read book data - based on constant numDataItems
            for (int i = 0; i < numDataItems; i++)
            {
                try
                {
                    nextLine = inNext.ReadLine();
                    if (nextLine != null)
                        nextArrayData[i] = nextLine;
                    else
                    {
                        return false;  // no more full items
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("ERROR: The system could not read the data from the file.\n\n" + "TECHNICAL INFORMATION: " + e.Message);
                    return false; // error - the file could not be read.
                }
            }
            return true;//no problems 
        }


        /******************************************************************
        *          OPERATIONS - VALIDATE TEXT BOX IS NOT NULL             *
        ******************************************************************/
        public static bool notNullTextBox(TextBox txtCurrent, String userFeedback)
        {
            if (txtCurrent.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("ERROR - The input for " + userFeedback + " cannot be empty!. Please input again ... ", "Error: Empty Textbox");
                txtCurrent.Focus();
                return false;
            }
            else
                return true;
        }


        /******************************************************************
        *           OPERATIONS - OPEN FILE FOR WRITE VALIDATION           *
        ******************************************************************/
        public static bool fileOpenForWriteOK(string writeFile, ref StreamWriter dataOut)
        {
            // open file - check for errors            
            try
            {
                dataOut = new StreamWriter(writeFile);
                return true;
            }

            // handle the exception
            catch (FileNotFoundException notFound)
            {
                System.Windows.Forms.MessageBox.Show("ERROR Opening file (when writing data out)" +
                                "- File could not be found.\n" + notFound.Message, "ERROR: Could not write");
                return false;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("ERROR Opening File (when writing data out)" +
                                "- Operation failed.\n" + e.Message, "ERROR: Could not write");
                return false;
            }
        }


        /******************************************************************
        *            OPERATIONS - OPEN FILE FOR READ VALIDATION           *
        ******************************************************************/
        public static bool fileOpenForReadOK(string readFile, ref StreamReader dataIn)
        {
            //open file - check for errors            
            try
            {
                dataIn = new StreamReader(readFile);
                return true;
            }
            catch (FileNotFoundException notFound)
            {
                System.Windows.Forms.MessageBox.Show("ERROR Opening file (when reading data in) - File could not be found.\n" + notFound.Message);
                return false;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("ERROR Opening File (when reading data in)- Operation failed.\n" + e.Message);
                return false;
            }
        }


        /******************************************************************
        *               OPERATIONS - WRITE OUT LEAGUE DATA                * 
        ******************************************************************/
        public static void writeLeague(StreamWriter writingOutFootball, League thisLeague)
        {
            //write out all its details
            writingOutFootball.WriteLine(thisLeague.getLeagueName());
            writingOutFootball.WriteLine(thisLeague.getLeagueSponsor());
            writingOutFootball.WriteLine(thisLeague.getLeaguePrize());
            writingOutFootball.WriteLine(thisLeague.getNumLeagueFixtures());
        }


        /******************************************************************
        *                 OPERATIONS - WRITE OUT TEAM DATA                *
        ******************************************************************/
        public static void writeTeam(StreamWriter writingOutTeam, Team thisTeam)
        {
            //TEAM ORDER = teamName, teamManager, teamNickname, teamStadium, teamPosition, teamPoints, 
            //             teamGamesPlayed, teamGoalDifference, teamLogo, teamNumPlayers
            writingOutTeam.WriteLine(thisTeam.getTeamName());
            writingOutTeam.WriteLine(thisTeam.getTeamLeague());
            writingOutTeam.WriteLine(thisTeam.getTeamManager());
            writingOutTeam.WriteLine(thisTeam.getTeamNickname());
            writingOutTeam.WriteLine(thisTeam.getTeamStadium());
            writingOutTeam.WriteLine(thisTeam.getTeamPosition());
            writingOutTeam.WriteLine(thisTeam.getTeamPoints());
            writingOutTeam.WriteLine(thisTeam.getTeamGamesPlayed());
            writingOutTeam.WriteLine(thisTeam.getTeamGoalDifference());
            writingOutTeam.WriteLine(thisTeam.getTeamLogo());
            writingOutTeam.WriteLine(thisTeam.getTeamNumPlayers());

        }


        /******************************************************************
        *              OPERATIONS - WRITE OUT FIXTURE DATA                *
        ******************************************************************/
        public static void writeFixture(StreamWriter writingOutFixture, Fixture thisFixture)
        {
            // FIXTURE ORDER = fixtureDate, fixtureTime, fixtureLocation, fixtureHomeTeam, fixtureAwayTeam
            writingOutFixture.WriteLine(thisFixture.getFixtureDate());
            writingOutFixture.WriteLine(thisFixture.getFixtureTime());
            writingOutFixture.WriteLine(thisFixture.getFixtureLocation());
            writingOutFixture.WriteLine(thisFixture.getFixtureHomeTeam());
            writingOutFixture.WriteLine(thisFixture.getFixtureAwayTeam());

        }


        /******************************************************************
        *                 OPERATIONS - WRITE ALL TEAM DATA                *
        ******************************************************************/
        public static void writeAllTeams(string theFile, ArrayList theTeams)
        {
            //local variables
            StreamWriter outputTeams = null;

            //create out
            if (fileOpenForWriteOK(theFile, ref outputTeams))
            {
                //loop through each team
                foreach (Team currTeam in theTeams)
                {
                    writeTeam(outputTeams, currTeam);
                }

                outputTeams.Close();

                //finish/tidy up
                if (outputTeams != null) outputTeams.Close();
            }
        }


        /******************************************************************
        *                OPERATIONS - WRITE OUT ALL LEAGUES               *
        ******************************************************************/
        public static void writeAllLeagues(string theFile, ArrayList allLeagues)
        {
            // local variables
            StreamWriter outputLeagues = null;

            // if the file opened ok then write to the file
            if (fileOpenForWriteOK(theFile, ref outputLeagues))
            {
                foreach (League currLeague in allLeagues)
                {
                    // run the writeLeague method...
                    Operations.writeLeague(outputLeagues, currLeague);

                    // get every fixture in the current league...
                    foreach (Fixture currFixture in currLeague.getAllLeagueFixtures())
                    {
                        try
                        {
                            Operations.writeFixture(outputLeagues, currFixture);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Error writing fixture {0} to file.", currFixture.getFixtureLocation());
                        }
                    }
                }

                // close the streamReader
                outputLeagues.Close();

                // finish/tidy up
                if (outputLeagues != null) outputLeagues.Close();
            }
        }


        /******************************************************************
        *                OPERATIONS - WRITE OUT ALL FIXTURES              *
        ******************************************************************/
        public static void writeAllFixtures(string theFile, ArrayList allLeagues)
        {
            //local variables
            StreamWriter outputFixtures = null;

            //create out
            if (fileOpenForWriteOK(theFile, ref outputFixtures))
            {
                //loop through each league   
                foreach (League currLeague in allLeagues)
                {
                    writeLeague(outputFixtures, currLeague);
                    foreach (Fixture currFixture in currLeague.getAllLeagueFixtures()) //loop through each fixture 
                    {

                        writeFixture(outputFixtures, currFixture);
                    }
                }
                outputFixtures.Close();

                //finish/tidy up
                if (outputFixtures != null) outputFixtures.Close();
            }
        }



        /******************************************************************
        *                OPERATIONS - DISPLAY THE FIXTURES                *
        ******************************************************************/
        public static void showListOfFixtures(ListBox lstOutput)
        {
            // clear listbox first            
            lstOutput.Items.Clear();
            string output;

            try
            {
                League whichLeague;

                whichLeague = (League)frmMainMenu.allLeagues[frmMainMenu.leagueSelected]; //index for the league - determines which fixtures are displayed

                // output the data...
                if ((whichLeague.getNumLeagueFixtures() > 0)) //if there are any fixtures 
                {
                    // loop through each fixture...
                    foreach (Fixture F in whichLeague.getAllLeagueFixtures())
                    {
                        output = output = (" " + F.getFixtureHomeTeam() + " VS " + F.getFixtureAwayTeam() + " on the " + F.getFixtureDate()
                              + " at " + F.getFixtureTime() + " at " + F.getFixtureLocation());

                        lstOutput.Items.Add(output);  // add item the listbox
                    }
                }

                else

                //show lib with no books as yet
                {
                    output = ("League " + whichLeague.getLeagueName() + " HAS NO FIXTURES YET!");
                    lstOutput.Items.Add(output);
                }

                foreach (Team t in frmMainMenu.allTeams)
                {
                    t.getAllTeams();

                }
            }

            catch (ArgumentOutOfRangeException)
            { }
        }


        /******************************************************************
        *                    OPERATIONS - SAVE IMAGE                      *
        ******************************************************************/
        public static void saveImage(string filePath)
        {
            try
            {
                // set the fileInfo to the input file i.e. doncaster.png
                FileInfo fInfo = new FileInfo(filePath);

                // create a temporary image...
                Image tempImage = Image.FromFile(fInfo.FullName);

                // use the tempImage and append the file location to get full path...
                tempImage.Save(@"../logos/" + fInfo.Name);
            }

            // if the image exists...
            catch (Exception)
            {
                // create a random number generator...
                Random ranExists = new Random();

                // create a new instanciation of fInfo and tempImage...
                FileInfo fInfo = new FileInfo(filePath);
                Image tempImage = Image.FromFile(fInfo.FullName);

                // ensure that if a duplicate image name is uploaded, '_num' is appended to filename...
                tempImage.Save(@"../logos/" + "_" + ranExists.Next(0, 99) + fInfo.Name);
            }


        }


        /******************************************************************
        *                   OPERATIONS - SEARCH FIELD                     *
        ******************************************************************/
        public static void searchItem(string inputFieldText)
        {
            frmKeepSearch.Show();

            string searchResult = inputFieldText;   // get the input
            string searchFilter = inputFieldText;   // set the label text
            string outputResult = searchResult;     // set the listbox output

            // set the input to lower...
            searchResult.ToLower();
            searchFilter.ToLower();

            // check if the inputs match using each search method...
            if (string.Compare(inputFieldText, searchResult) == 0)
            {
                searchFixtures(searchResult, outputResult); // run a search on fixtures...
                searchTeams(searchResult, outputResult);    // run a search on teams...
                searchLeagues(searchResult, outputResult);  // run a search on leagues...
            }

            // create the label output...
            frmKeepSearch.renderLabel(searchFilter);

        }


        /************************** SEARCH TEAMS ******************************/
        private static void searchTeams(string teamIn, string outputResult)
        {
            // for every team in allTeams
            foreach (Team currTeam in frmMainMenu.allTeams)
            {
                // initialise variables...
                string teamName = currTeam.getTeamName();
                string teamLeague = currTeam.getTeamLeague();
                string teamManager = currTeam.getTeamManager();
                string teamNickname = currTeam.getTeamNickname();
                string teamStadium = currTeam.getTeamStadium();
                int teamPosition = currTeam.getTeamPosition();
                int teamPoints = currTeam.getTeamPoints();
                int teamGamesPlayed = currTeam.getTeamGamesPlayed();
                int teamGoalDifference = currTeam.getTeamGoalDifference();
                int teamNumPlayers = currTeam.getTeamNumPlayers();


                // set the vars into an output string...
                outputResult = "\nTEAM: " + teamName + " Play in: " + teamLeague + " Managed by: " + teamManager + " Known as: " + teamNickname
                             + " Play at: " + teamStadium + " Current position: " + teamPosition + " Current points: " + teamPoints
                             + " Played: " + teamGamesPlayed + " GD + " + teamGoalDifference + " Players: " + teamNumPlayers + " ";

                // set the string to lowercase...
                outputResult.ToLower();

                // do search comparison...
                if (string.Compare(teamIn.ToLower(), teamName.ToLower()) == 0)
                {
                    frmKeepSearch.displayResults(outputResult);
                }
                if (string.Compare(teamIn.ToLower(), teamLeague.ToLower()) == 0)
                {
                    frmKeepSearch.displayResults(outputResult);
                }
                if (string.Compare(teamIn.ToLower(), teamManager.ToLower()) == 0)
                {
                    frmKeepSearch.displayResults(outputResult);
                }
                if (string.Compare(teamIn.ToLower(), teamNickname.ToLower()) == 0)
                {
                    frmKeepSearch.displayResults(outputResult);
                }
                if (string.Compare(teamIn.ToLower(), teamStadium.ToLower()) == 0)
                {
                    frmKeepSearch.displayResults(outputResult);
                }
                if (string.Compare(teamIn.ToLower(), teamPosition.ToString()) == 0)
                {
                    frmKeepSearch.displayResults(outputResult);
                }
                if (string.Compare(teamIn.ToLower(), teamPoints.ToString()) == 0)
                {
                    frmKeepSearch.displayResults(outputResult);
                }
                if (string.Compare(teamIn.ToLower(), teamGamesPlayed.ToString()) == 0)
                {
                    frmKeepSearch.displayResults(outputResult);
                }
                if (string.Compare(teamIn.ToLower(), teamGoalDifference.ToString()) == 0)
                {
                    frmKeepSearch.displayResults(outputResult);
                }
                if (string.Compare(teamIn.ToLower(), teamNumPlayers.ToString()) == 0)
                {
                    frmKeepSearch.displayResults(outputResult);
                }

            }
        }


        /************************** SEARCH LEAGUES ******************************/
        private static void searchLeagues(string LeagueIn, string outputResult)
        {
            foreach (League currLeague in frmMainMenu.allLeagues)
            {
                // local variables ...
                string teamLeagueName = currLeague.getLeagueName();
                string teamLeagueSponsor = currLeague.getLeagueSponsor();
                string teamLeaguePrize = currLeague.getLeaguePrize();
                int teamNumLeagueFixtures = currLeague.getNumLeagueFixtures();

                // format output string using locals...
                outputResult = "\nLEAGUE: " + teamLeagueName + " is sponsored by: " + teamLeagueSponsor + "- Prize: " + teamLeaguePrize + "- Number of Fixtures: " + teamNumLeagueFixtures;

                // convert output to lower for search...
                outputResult.ToLower();

                // run comparisons...
                if (string.Compare(LeagueIn.ToLower(), teamLeagueName.ToLower()) == 0)
                {
                    frmKeepSearch.displayResults(outputResult);
                }
                if (string.Compare(LeagueIn.ToLower(), teamLeagueSponsor.ToLower()) == 0)
                {
                    frmKeepSearch.displayResults(outputResult);
                }
                if (string.Compare(LeagueIn.ToLower(), teamLeaguePrize.ToLower()) == 0)
                {
                    frmKeepSearch.displayResults(outputResult);
                }
                if (string.Compare(LeagueIn.ToLower(), teamNumLeagueFixtures.ToString()) == 0)
                {
                    frmKeepSearch.displayResults(outputResult);
                }


            }
        }


        /************************** SEARCH FIXTURES ******************************/
        private static void searchFixtures(string fixtureIn, string outputResult)
        {
            string fixtureDetails;

            // loop through each fixture in allLeagues...
            foreach (League currLeague in frmMainMenu.allLeagues)
            {
                foreach (Fixture currFixture in currLeague.getAllLeagueFixtures())
                {
                    // initialise locals...
                    string home = currFixture.getFixtureHomeTeam();
                    string away = currFixture.getFixtureAwayTeam();
                    string date = currFixture.getFixtureDate();
                    string time = currFixture.getFixtureTime();
                    string location = currFixture.getFixtureLocation();

                    // format the output result, and set to lower for comparison...
                    outputResult = "FIXTURE: " + home + " VS " + away + " on the " + date + " at " + time + " at " + location;
                    outputResult.ToLower();

                    // get the fixture details...
                    fixtureDetails = currFixture.getFullFixture();
                    fixtureDetails.ToLower();

                    // run comparisons...
                    if (string.Compare(fixtureIn.ToLower(), home.ToLower()) == 0)
                    {
                        frmKeepSearch.displayResults(outputResult);
                    }

                    if (string.Compare(fixtureIn.ToLower(), away.ToLower()) == 0)
                    {
                        frmKeepSearch.displayResults(outputResult);
                    }

                    if (string.Compare(fixtureIn.ToLower(), date.ToLower()) == 0)
                    {
                        frmKeepSearch.displayResults(outputResult);
                    }

                    if (string.Compare(fixtureIn.ToLower(), time.ToLower()) == 0)
                    {
                        frmKeepSearch.displayResults(outputResult);
                    }

                    if (string.Compare(fixtureIn.ToLower(), location.ToLower()) == 0)
                    {
                        frmKeepSearch.displayResults(outputResult);

                    }
                }
            }
        }


        /******************************************************************
        *           OPERATIONS - GET CORRECT TEAM INDEX IN LEAGUE         *
        ******************************************************************/
        public static int teamArrayPosition(int teamLocationCounter, string teamLeagueCompare)
        {
            // for each team, increment count by 1 - to find index in text file...
            foreach (League L in frmMainMenu.allLeagues)
            {
                foreach (Team T in frmMainMenu.allTeams)
                {
                    //if the index of the team is found...
                    if (T.getTeamName() == teamLeagueCompare)
                    {
                        // return the current value of counter...
                        return teamLocationCounter;
                    }

                    // otherwise increment the count and reloop...
                    teamLocationCounter += 1;
                }

            }

            // return the counter...
            return teamLocationCounter;

        }


        /******************************************************************
        *           OPERATIONS - GET CORRECT TEAM INDEX IN TEAMS          *
        ******************************************************************/
        public static int getTeamFixtureIndex(int teamIndex, Team teamComparison)
        {
            // loop through each team...
            foreach (Team t in frmMainMenu.allTeams)
            {
                // if the names match then return the index...
                if (t.getTeamName() == teamComparison.getTeamName())
                {
                    return teamIndex;
                }

                // otherwise increment the count and reloop...
                teamIndex += 1;
            }

            // else return the teams index...
            return teamIndex;
        }


        /******************************************************************
        *          OPERATIONS - GET CORRECT FIXTURE INDEX IN LEAGUES      *
        ******************************************************************/
        public static int fixtureArrayPosition(int fixtureLocationCounter, string fixtureLeagueCompare)
        {
            string compareFixture;

            // for each league, increment count by 1 - to find index in text file...
            foreach (League L in frmMainMenu.allLeagues)
            {
                // loop through each fixture...
                foreach (Fixture F in L.getAllLeagueFixtures())
                {
                    // set the comparison format...
                    compareFixture = (" " + F.getFixtureHomeTeam() + " VS " + F.getFixtureAwayTeam() + " on the " + F.getFixtureDate()
                                + " at " + F.getFixtureTime() + " at " + F.getFixtureLocation());

                    //if the index of the team is found
                    if (compareFixture == fixtureLeagueCompare)
                    {
                        // return the index of the fixture
                        return fixtureLocationCounter;
                    }

                    // increment the count by 1...
                    fixtureLocationCounter += 1;
                }

            }

            // return the location of the fixture...
            return fixtureLocationCounter;

        }


        /******************************************************************
        *         OPERATIONS - GET CORRECT LIST ITEM INDEX ON SEARCH      *
        ******************************************************************/
        public static int[] searchbarArrayPositions(string searchCompare)
        {
            string outputResult;

            // declare and initialise array...
            int[] searchbarIndexPositions = { 0, 0, 0 };

            // set local variables...
            int fixtureIndexPosition = 0;
            int leagueIndexPosition = 0;
            int teamIndexPosition = 0;

            // increment next league, team, fixture to find respective indexes
            foreach (League L in frmMainMenu.allLeagues)
            {
                string leagueName = L.getLeagueName();
                string leagueSponsor = L.getLeagueSponsor();
                string leaguePrize = L.getLeaguePrize();
                int numLeagueFixtures = L.getNumLeagueFixtures();

                // set the output string...
                outputResult = " " + leagueName + " is sponsored by: " + leagueSponsor + "- Prize: " + leaguePrize + "- Number of Fixtures: " + numLeagueFixtures;

                // do comparison...
                if (outputResult == searchCompare)
                {
                    searchbarIndexPositions[0] = leagueIndexPosition; // if league is found, store index
                }

                // loop through each fixture search for the index...
                foreach (Fixture F in L.getAllLeagueFixtures())
                {
                    // format output string...
                    outputResult = (" " + F.getFixtureHomeTeam() + " VS " + F.getFixtureAwayTeam() + " on the " + F.getFixtureDate()
                                + " at " + F.getFixtureTime() + " at " + F.getFixtureLocation());

                    //if the index of the team is found
                    if (outputResult == searchCompare)
                    {
                        searchbarIndexPositions[0] = leagueIndexPosition;  // if fixture is found, store league index (edit fixture requires league to be known)
                        searchbarIndexPositions[1] = fixtureIndexPosition; // if fixture is found, store fixture index
                    }

                    // otherwise increment the counter...
                    fixtureIndexPosition += 1;
                }

                // increment the league counter...
                leagueIndexPosition += 1;
            }

            // loop through all teams...
            foreach (Team T in frmMainMenu.allTeams)
            {
                // set locals...
                string teamName = T.getTeamName();
                string teamLeague = T.getTeamLeague();
                string teamManager = T.getTeamManager();
                string teamNickname = T.getTeamNickname();
                string teamStadium = T.getTeamStadium();
                int teamPosition = T.getTeamPosition();
                int teamPoints = T.getTeamPoints();
                int teamGamesPlayed = T.getTeamGamesPlayed();
                int teamGoalDifference = T.getTeamGoalDifference();
                int teamNumPlayers = T.getTeamNumPlayers();

                // format output string...
                outputResult = " " + teamName + " Play in: " + teamLeague + " Managed by: " + teamManager + " Known as: " + teamNickname
                         + " Play at: " + teamStadium + " Current position: " + teamPosition + " Current points: " + teamPoints
                         + " Played: " + teamGamesPlayed + " GD + " + teamGoalDifference + " Players: " + teamNumPlayers + " ";


                //if the index of the team is found...
                if (outputResult == searchCompare)
                {
                    searchbarIndexPositions[2] = teamIndexPosition; // set the index of the array to position...
                }

                // increment the counter by 1...
                teamIndexPosition += 1;
            }

            // return 3 integer values; fixture, league, and team indexes...
            return searchbarIndexPositions;

        }


        /******************************************************************
        *                 OPERATIONS - GET THE AWAY RESULT                * 
        ******************************************************************/
        public static void getAwayResult(Team awayTeam, int awayPoints, int homeScore, int awayScore)
        {
            // local variables...
            int goalDiff, gamesPlayed;

            // initialise variables...
            goalDiff = awayTeam.getTeamGoalDifference();
            gamesPlayed = awayTeam.getTeamGamesPlayed();

            // increment the games played...
            gamesPlayed = gamesPlayed + 1;

            // did the team lose - add no points and set goal difference...
            if (awayScore < homeScore)
            {
                awayPoints += 0;
                goalDiff = goalDiff - (homeScore - awayScore);
            }

            // did the team draw - add a point and set goal difference...
            else if (awayPoints == homeScore)
            {
                awayPoints += 1;
                goalDiff += 0;
            }

            // did the team win - add 3 points and set goal difference...
            else if (awayScore > homeScore)
            {
                awayPoints += 3;
                goalDiff = goalDiff + (homeScore - awayScore);
            }

            // update the team in the file...
            writeFixtureResult(awayTeam, goalDiff, gamesPlayed, awayPoints);
        }


        /******************************************************************
        *                 OPERATIONS - GET THE HOME RESULT                * 
        ******************************************************************/
        public static void getHomeResult(Team homeTeam, int homePoints, int homeScore, int awayScore)
        {
            // local variables...
            int goalDiff, gamesPlayed;

            // initialise local vars...
            goalDiff = homeTeam.getTeamGoalDifference();
            gamesPlayed = homeTeam.getTeamGamesPlayed();


            // increment the gamesPlayed counter by 1
            gamesPlayed = gamesPlayed + 1;

            // did the team lose? - if so, add no points and calculate goal diff...
            if (homeScore < awayScore)
            {
                homePoints += 0;
                goalDiff = goalDiff - (awayScore - homeScore);
            }

            // did the team draw? - if so add 1 point and calculate goal diff...
            else if (homeScore == awayScore)
            {
                homePoints += 1;
                goalDiff += 0;
            }

            // did the team win? - if so add 3 points and calculate goal diff...
            else if (homeScore > awayScore)
            {
                homePoints += 3;
                goalDiff = goalDiff + (homeScore - awayScore);
            }

            // write the amended team to file...
            writeFixtureResult(homeTeam, goalDiff, gamesPlayed, homePoints);

        }


        /******************************************************************
        *                 OPERATIONS - GET THE HOME RESULT                * 
        ******************************************************************/
        private static void writeFixtureResult(Team theTeam, int goalDiff, int gamesPlayed, int thePoints)
        {
            // initialise the selected index to nil...
            int selectedIndex = 0;

            // set the selected index of the team...
            selectedIndex = getTeamFixtureIndex(selectedIndex, theTeam);

            League whichLeague = (League)frmMainMenu.allLeagues[frmMainMenu.leagueSelected];
            Team whichTeam = (Team)frmMainMenu.allTeams[selectedIndex];

            /* get team inputs - Team order = teamName, teamLeague, teamManager, teamNickname, teamStadium, teamPosition, teamPoints, 
                                              teamGamesplayed, teamGoalDifference, teamLogo, teamNumOfPlayers...                    */

            string tempTeamName = theTeam.getTeamName();
            string tempTeamLeague = theTeam.getTeamLeague();
            string tempTeamManager = theTeam.getTeamManager();
            string tempTeamNickname = theTeam.getTeamNickname();
            string tempTeamStadium = theTeam.getTeamStadium();
            string tempTeamPosition = theTeam.getTeamPosition().ToString();
            string tempTeamPoints = thePoints.ToString();
            string tempTeamGamesPlayed = gamesPlayed.ToString();
            string tempTeamGoalDifference = goalDiff.ToString();
            string tempTeamLogo = theTeam.getTeamLogo();
            string tempTeamNumPlayers = theTeam.getTeamNumPlayers().ToString();

            // create the new team object to update results
            Team updatedTeam = new Team(tempTeamName, tempTeamLeague, tempTeamManager, tempTeamNickname, tempTeamStadium, Convert.ToInt32(tempTeamPosition),
                                        Convert.ToInt32(tempTeamPoints), Convert.ToInt32(tempTeamGamesPlayed), Convert.ToInt32(tempTeamGoalDifference),
                                        tempTeamLogo, Convert.ToInt32(tempTeamNumPlayers));


            // use the replace method in the Team class...
            whichTeam.replaceTeam(frmMainMenu.allTeams, updatedTeam, selectedIndex);

            // write the new team to the file...
            Operations.writeAllTeams(frmMainMenu.inputTeams, frmMainMenu.allTeams);

        }


        /******************************************************************
        *              OPERATIONS - REMOVE FIXTURES FROM TEAMS            * 
        ******************************************************************/
        public static void removeTeamFixtures(League whichLeague, Team deleteTeam, int fixtureDeleteCounter)
        {
            // loop through all fixtures in the league...
            foreach (Fixture F in whichLeague.getAllLeagueFixtures().ToArray())
            {
                // if the home team names match then remove the team and all its selected fixtures...
                if (F.getFixtureHomeTeam().Contains(deleteTeam.getTeamName()))
                {
                    whichLeague.deleteFixture(whichLeague.getAllLeagueFixtures(), F, fixtureDeleteCounter);
                    fixtureDeleteCounter -= 1;
                }

                // if the away team names match then remove the team and all its selected fixtures...
                if (F.getFixtureAwayTeam().Contains(deleteTeam.getTeamName()))
                {
                    whichLeague.deleteFixture(whichLeague.getAllLeagueFixtures(), F, fixtureDeleteCounter);
                    fixtureDeleteCounter -= 1;
                }

                // otherwise increment the deletion counter...
                fixtureDeleteCounter += 1;
            }


            // rewrite the text file without the selected team...
            Operations.writeAllFixtures(frmMainMenu.inputFootball, frmMainMenu.allLeagues);

        }


        /******************************************************************
        *            OPERATIONS - DELETE PROCESSED FIXTURE                *
        ******************************************************************/
        public static void deletePlayedFixture(League whichLeague, Fixture whichFixture)
        {
            whichLeague = (League)frmMainMenu.allLeagues[frmMainMenu.leagueSelected];
            var theLeagues = whichLeague.getAllLeagueFixtures();

            // loop through each fixture in 'theLeagues', convert to array to prevent
            // the Enumerator changed error exception to be thrown by compiler...
            foreach (Fixture f in theLeagues.ToArray())
            {
                // Get the correct fixture...
                if (f.getFixtureHomeTeam() == whichFixture.getFixtureHomeTeam() &&
                    f.getFixtureAwayTeam() == whichFixture.getFixtureAwayTeam())
                {


                    // otherwise delete the item at the selected index...
                    whichLeague.getAllLeagueFixtures().RemoveAt(frmMainMenu.fixtureSelected);

                    Operations.writeAllLeagues(frmMainMenu.inputFootball, frmMainMenu.allLeagues);
                    Operations.writeAllFixtures(frmMainMenu.inputFootball, frmMainMenu.allLeagues);

                    // prompt the user that the fixture has been deleted...
                    MessageBox.Show("Success - The Fixture: " + f.getFixtureHomeTeam() + " vs " + f.getFixtureAwayTeam()
                                    + " has been deleted.", "Fixture Deleted");

                }
            }
        }


        /******************************************************************
        *            OPERATIONS - CHECK FOR OUTSTANDING RESULTS           * 
        ******************************************************************/
        public static bool checkPendingResults()
        {
            bool resultsPending = false;

            // loop through all fixtures in leagues and check if they have not had there result set...
            foreach (League l in frmMainMenu.allLeagues)
            {
                foreach (Fixture f in l.getAllLeagueFixtures())
                {
                    // get the fixture date and the current time...
                    DateTime inputFixture = Convert.ToDateTime(f.getFixtureDate());
                    DateTime currentDate = DateTime.Now;

                    // format the input strings...
                    String.Format("{0:dd/MM/yyyy}", inputFixture);
                    String.Format("{0:dd/MM/yyyy}", currentDate);

                    // check if the date has passed...
                    if ((inputFixture - currentDate).TotalDays <= 0)
                    {
                        resultsPending = true;
                        return resultsPending;
                    }

                    else
                    {
                        resultsPending = false;
                    }

                }
            }

            return resultsPending;
        }


        /******************************************************************
        *            OPERATIONS - POPULATE PENDING FIXTUREs               * 
        ******************************************************************/
        public static void populatePendingSearches(string input)
        {
            frmKeepSearch.renderLabel(input);
            frmKeepSearch.renderResultDisplay();

            // loop through each league...
            foreach (League l in frmMainMenu.allLeagues)
            {
                // loop through each fixture...
                foreach (Fixture f in l.getAllLeagueFixtures().ToArray())
                {
                    // get the fixture date and the current time...
                    DateTime inputFixture = Convert.ToDateTime(f.getFixtureDate());
                    DateTime currentDate = DateTime.Now;

                    // format the input strings...
                    String.Format("{0:dd/MM/yyyy}", inputFixture);
                    String.Format("{0:dd/MM/yyyy}", currentDate);

                    // check if the date has passed...
                    if ((inputFixture - currentDate).TotalDays <= 0)
                    {
                        // add the fixture into the list...
                        frmKeepSearch.displayPendingFixtures(f.getFullFixture().ToString());
                    }

                }
            }
        }

    }


}
