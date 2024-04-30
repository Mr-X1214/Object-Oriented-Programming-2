using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Dice_game
{
    internal class ThreeOrMore
    {
        // these below before the method create all of the variables and objects that I needed
        Die die1 = new Die(); // this created the first die object
        Die die2 = new Die(); // this created the second die object
        Die die3 = new Die(); // this created the third die object
        Die die4 = new Die(); // this created the fourth die object
        Die die5 = new Die(); // this created the fifth die object
        Die rerolldie = new Die(); // this created the die objbect for rerolling

        public int threeCounter; // this is used for the counter for the number of turns taken
        public int diceCounter; // this is used for the counter for the number of rerolls made
        public int gaCounter; // this is used for the counter for the amount of three or more games played
        public int playerScore1; // this is for player 1's score
        public int playerScore2; // this is for player 2's score
        public int botScore; // this is for the computer's score
        public int tCounter; // this is used for the turn counter
        public int dCounter; // this is used for the reroll counter
        public int gCounter; // this is used for the game counter
        public int sumOfscore1; // this is used when adding together the number of times player 1 wins
        public int sumOfscore2; // this is used when adding together the number of times player 2 wins
        public int sumOfbotScore; // this is used when adding together the number of times the computer wins
        public int botTestscore1; // this is for the first computer's score in testing
        public int botTestscore2; // this is for the second computer's score in testing
        bool reroll1 = true; // this is boolean for the first reroll question while loop
        bool reroll2 = true; // this is the boolean for the second reroll question while loop
        public List<int> rerollrolls = new List<int>(); // the list that holds the dice that don't need to be rerolled
        public List<int> player1S = new List<int>(); // the list for the player 1 win amounts
        public List<int> player2S = new List<int>(); // the list for the player 2 win amounts
        public List<int> botS = new List<int>(); // the list for the computer win amounts
        public List<int> turnCounter = new List<int>(); // the list for the amount of turns taken 
        public List<int> dieCounter = new List<int>(); // the list for the amount of rerolls done
        public List<int> gameCounter = new List<int>(); // the list for the amount of times the game has been played

        /// <summary>
        /// This method shows the rules for the game
        /// </summary>
        public void TOMPVP()
        {
            gCounter ++; // adds to the turn counter each time this is called

            // this prints out the rules for the players to see
            Console.WriteLine("\nThe rules are as follows:");
            Console.WriteLine("Roll 5 dice, aim to get 3 of a kind");
            Console.WriteLine("If it's 2 of a kind, there is a choice of a reroll");
            Console.WriteLine("The reroll is either of all dice or just the different ones");
            Console.WriteLine("Each 'of a kind' has it's own points");
            Console.WriteLine("3 of a kind: 3 points");
            Console.WriteLine("4 of a kind: 6 points");
            Console.WriteLine("5 of a kind: 12 points");
            Console.WriteLine("The game ends when one player reaches 20 or more points.");
            Console.WriteLine("\nPlayer 1 starts"); // it then says which turn it is
            Player1PVP(); // calls the method for player 1's turn when played against player
        }

        /// <summary>
        /// This does the same as the one above but moves it onto the against the computer version
        /// </summary>
        // this is the same as the one above but for against the computer and with minor changes
        // I will comment the changes and say where it is the same
        public void TOMPVE()
        {
            gCounter ++; // this is the same
            
            // the rules that are printed are the exact same, as is the player that starts
            Console.WriteLine("\nThe rules are as follows:");
            Console.WriteLine("Roll 5 dice, aim to get 3 of a kind");
            Console.WriteLine("If it's 2 of a kind, there is a choice of a reroll");
            Console.WriteLine("The reroll is either of all dice or just the different ones");
            Console.WriteLine("Each 'of a kind' has it's own points");
            Console.WriteLine("3 of a kind: 3 points");
            Console.WriteLine("4 of a kind: 6 points");
            Console.WriteLine("5 of a kind: 12 points");
            Console.WriteLine("The game ends when one player reaches 20 or more points.");
            Console.WriteLine("\nPlayer 1 starts");
            Player1PVE(); // this calls the against the computer version of player 1 instead
        }

        /// <summary>
        /// This is the method for player 1's version for the PVP version
        /// </summary>
        public void Player1PVP()
        {
            threeCounter ++; // adds to the turn counter each time it is called
            Console.WriteLine("\nRoll the dice...");
            // this for rolling the dice
            die1.Roll(); // it calls the roll method from the dice class
            Thread.Sleep(100); // it then makes the thread sleep for 1 second so that the number will be randomised
            // it does this 4 more times
            die2.Roll();
            Thread.Sleep(100);
            die3.Roll();
            Thread.Sleep(100);
            die4.Roll();
            Thread.Sleep(100);
            die5.Roll(); // not adding a thread.sleep after this one

            // it then stores those rolls in individual variables
            int die1val = die1.dieValue;
            int die2val = die2.dieValue;
            int die3val = die3.dieValue;
            int die4val = die4.dieValue;
            int die5val = die5.dieValue;

            int[] roll = { die1val, die2val, die3val, die4val, die5val }; // storing it in an array

            // they then all get printed out for the use to see
            Console.ReadLine();
            Console.WriteLine($"Die roll 1: {die1val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 2: {die2val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 3: {die3val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 4: {die4val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 5: {die5val}");
            Console.ReadLine();

            Array.Sort(roll); // it then sorts the list 
            // these two variables are there to record the mode and the number of times it shows up
            int numberSame = 0;
            int mostNumber = 0;
            // this goes through the list of numbers
            foreach (int item in roll)
            {
                int sameNumber = 0; // this variable is then created for each one

                // this for each then goes through it again
                foreach (int j in roll)
                {
                    // this if statement checking if the item and J equal each other
                    if (item == j)
                    {
                        sameNumber++; // adding to sameNumber if so
                        // this if statement then checks if sameNumber is more than mostNumber
                        if (sameNumber > mostNumber)
                        {
                            numberSame = j; // it then makes the mode the value of J
                            mostNumber = sameNumber; // then makes the amount it appears, the value of sameNumber
                        }
                    }
                }
            }
            // this if statement then goes and checks how many points the player gets based on the amount of times the mode shows up
            if (mostNumber == 1)
            {
                // this is for no matching nummbers, it gives no points and tells the player that
                Console.WriteLine("\nThere are no matching numbers, you get no points");
            }
            else if (mostNumber == 2)
            {
                // this is for a two of a kind, it allows a player to reroll, aasking them that first
                Console.WriteLine("\nYou have a two of a kind, would you like to reroll?");
                // this while statement means that the player doesn't have to worry about messing up the choice
                while (reroll1 == true)
                {
                    Console.WriteLine("[Y or N]"); // this shows the choices
                    string choice1 = Console.ReadLine(); // this stores the choice
                    // this if statement goes through what to do based on the choice
                    if (choice1 == "Y")
                    {
                        // this is if it is yes / Y
                        diceCounter ++; // adds to the reroll counter everytime it is yes
                        reroll1 = false; // stops the while loop
                        // it then asks how many the player would like to reroll
                        Console.WriteLine("\nWould you like to reroll all or just the different ones?");
                        // this second while loop also being there to stop errors with choices made by the player
                        while (reroll2 == true)
                        {
                            Console.WriteLine("[ALL or SOME]"); // this showing the choices
                            string choice2 = Console.ReadLine(); // this recording the choice
                            // this if statement then goes through what to do based on the choice made
                            if (choice2 == "ALL")
                            {
                                // this if the player picked all to be rerolled
                                reroll2 = false; // stops the while loop
                                Player1PVPReroll(); // calls the method for rerolling all of the dice for PVP
                            }
                            else if (choice2 == "SOME")
                            {
                                // this is if the player choice to reoll some of the dice
                                reroll2 = false; // stop the while loop
                                // this for each goes through each dice to see if it is the dice that needs to be rerolled
                                foreach (int item in roll)
                                {
                                    // this if statement checking if item is equal to the mode
                                    if (item != numberSame)
                                    {
                                        // this is if they are not the same
                                        rerolldie.Roll(); // it rerolls the dice
                                        int rerollval = rerolldie.dieValue; // stores the value
                                        rerollrolls.Add(rerollval); // adds it to the list
                                        Console.WriteLine(rerollval); // prints the list
                                        Thread.Sleep(100); // sleeps the thread so the next roll is randomised
                                    }
                                }
                                // this bit of code is the same as finding the amount that is the same earlier in the code, with minor changes
                                // these two variables are now the reroll version as to not get them mixed up
                                int numberSamereroll = 0;
                                int mostNumberreroll = 0;
                                foreach (int item in rerollrolls) // this uses the reroll list 
                                {
                                    int sameNumberreroll = 0;

                                    foreach (int j in rerollrolls)
                                    {
                                        if (item == j || item == numberSame)
                                        {
                                            sameNumberreroll++;
                                            if (sameNumberreroll > mostNumberreroll)
                                            {
                                                numberSamereroll = j;
                                                mostNumberreroll = sameNumberreroll + 2; // this adds on two as the original set of dice had the two that were the same
                                            }
                                        }
                                    }
                                }
                                // this then checks how amy are the same after the reroll
                                if (mostNumberreroll == 3)
                                {
                                    // this is if there is a 3 of a kind
                                    Console.WriteLine("\nThere are 3 matching numbers, you get 3 points!"); // this tells them that they have a 3 of a kind and the amount of points gained
                                    playerScore1 += 3; // this adds 3 to the player score
                                }
                                else if (mostNumberreroll == 4)
                                {
                                    // this is if there is a 4 of a kind
                                    Console.WriteLine("\nThere are 4 matching numbers, you get 6 points!"); // this tells them that they have a 4 of a kind and the amount of points gained
                                    playerScore1 += 6; // this adds 6 to the player score
                                }
                                else if (mostNumberreroll == 5)
                                {
                                    Console.WriteLine("\nThere are 5 matching numbers, you get 12 points!"); // this tells them that they have a 5 of a kind and the amount of points gained
                                    playerScore1 += 12; // this adds 12 to the player score
                                }
                                else if (mostNumberreroll == 2)
                                {
                                    // this is if it remains at 2 of a kind
                                    Console.WriteLine("There has been no change in total, no points."); // nothing happens and the player is told this
                                }
                                else
                                {
                                    // this is generally to catch if there are any other options, which there shouldn't be but it's just incase
                                    Console.WriteLine("There has been no change in total, no points.");
                                }
                            }
                            else
                            {
                                // this is if the choice was not ALL or SOME so they can try again
                                Console.WriteLine("That is not a choice"); // tells them that it's not valid
                                reroll2 = true; // keeps the while loop going so they can try again
                            }
                        }
                    }
                    else if (choice1 == "N")
                    {
                        // this is if the first choice was no / N
                        Console.WriteLine("\nNo rerolling will happen and you get no points"); // this tells the player that they won't get points for not rerolling
                        reroll1 = false; // makes the while loop false
                    }
                    else
                    {
                        // this is for if the choice wasn't Y or N
                        Console.WriteLine("\nThat is not a choice"); // tells the player it is invalid
                        reroll1 = true; // keeps the while loop going so they can try again
                    }
                }
            }
            else if (mostNumber == 3)
            {
                // this is if they have a 3 of a kind
                Console.WriteLine("\nYou have a three of a kind, you get 3 points!"); // tells the player what they have and the points awarded
                playerScore1 += 3; // adds 3 to the player's score
            }
            else if (mostNumber == 4)
            {
                // this is if they have a 4 of a kind
                Console.WriteLine("\nYou have a four of a kind, you gte 6 points!"); // tells the player what they have and the points awarded
                playerScore1 += 6; // adds 6 to the player's score
            }
            else if (mostNumber == 5)
            {
                // this is if they have a 5 of a kind
                Console.WriteLine("\nYou have a five of a kind, you get 12 points!"); // tells the player what they have and the points awarded
                playerScore1 += 12; // adds 12 to the player's score
            }

            // this if statement then checks if player 1's score is equal to 20
            if (playerScore1 >= 20)
            {
                // this is if it is
                winPVP(); // it calls the method for what happens at the end of the game
            }
            else
            {
                // this is if it is not
                // it prints out the current scores
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"Player 2: {playerScore2}");
                Console.WriteLine("It is now Player 2's turn"); // tells them it's player 2's turn
                // resets these 4 variables so they can be used again
                numberSame = 0;
                mostNumber = 0;
                reroll1 = true;
                reroll2 = true;
                Console.ReadLine();
                Player2(); // calls the method for player 2's turn
            }
        }

        /// <summary>
        /// this is the method for rerolling all of the dice for player 1 in PVP
        /// </summary>
        // this uses code from Player1PVP but with a change
        // I will comment the changes and say what is the same
        public void Player1PVPReroll()
        {
            // rolling the dice is the same
            Console.WriteLine("\nRoll the dice...");
            die1.Roll();
            Thread.Sleep(100);
            die2.Roll();
            Thread.Sleep(100);
            die3.Roll();
            Thread.Sleep(100);
            die4.Roll();
            Thread.Sleep(100);
            die5.Roll();

            // recording the values of the dice rolls is the same
            int die1val = die1.dieValue;
            int die2val = die2.dieValue;
            int die3val = die3.dieValue;
            int die4val = die4.dieValue;
            int die5val = die5.dieValue;

            int[] roll = { die1val, die2val, die3val, die4val, die5val }; // adding them to the array is the same

            // writing them all out is the same
            Console.ReadLine();
            Console.WriteLine($"Die roll 1: {die1val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 2: {die2val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 3: {die3val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 4: {die4val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 5: {die5val}");
            Console.ReadLine();

            // this block of code including the for each is the same
            Array.Sort(roll);
            int numberSame = 0;
            int mostNumber = 0;
            foreach (int item in roll)
            {
                int sameNumber = 0;

                foreach (int j in roll)
                {
                    if (item == j)
                    {
                        sameNumber++;
                        if (sameNumber > mostNumber)
                        {
                            numberSame = j;
                            mostNumber = sameNumber;
                        }
                    }
                }
            }
            // the function of this if statement is the same
            if (mostNumber == 1)
            {
                // this is the same
                Console.WriteLine("There are no matching numbers, no points.");
            }
            else if (mostNumber == 2)
            {
                // this instead does not allow a reroll, it tells them that they get no points as it is the same
                Console.WriteLine("You have a 2 of a kind, umable to reroll again, no points");
            }
            else if (mostNumber == 3)
            {
                // this is the same
                Console.WriteLine("You have a three of a kind, you get 3 points!");
                playerScore1 += 3;
            }
            else if (mostNumber == 4)
            {
                // this is the same
                Console.WriteLine("You have a four of a kind, you get 6 points!");
                playerScore1 += 6;
            }
            else if (mostNumber == 5)
            {
                // this is the same
                Console.WriteLine("You have a five of a kind, you get 12 points!");
                playerScore1 += 12;
            }
            else
            {
                // this is the same
                Console.WriteLine("There are no matching numbers, no points");
            }

            // the function of this if statement is the same
            if (playerScore1 >= 20)
            {
                // this is the same
                winPVP();
            }
            else
            {
                // prints out the score the same
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"Player 2: {playerScore2}");
                Console.WriteLine("It is now Player 2's turn"); // says the same turn
                // resets the same variables
                numberSame = 0;
                mostNumber = 0;
                reroll1 = true;
                reroll2 = true;
                Console.ReadLine();
                Player2(); // calls the same method
            }
        }

        /// <summary>
        /// This is the method for player 1's turn in the against the computer version
        /// </summary>
        // this is the same as the Player1PVP but for against the computer, it has minor changes
        // I will comment the changes and say what is the same
        public void Player1PVE()
        {
            // the rolling the is the same
            threeCounter ++;
            Console.WriteLine("\nRoll the dice...");
            die1.Roll();
            Thread.Sleep(100);
            die2.Roll();
            Thread.Sleep(100);
            die3.Roll();
            Thread.Sleep(100);
            die4.Roll();
            Thread.Sleep(100);
            die5.Roll();

            // recording the values of the rolls is the same
            int die1val = die1.dieValue;
            int die2val = die2.dieValue;
            int die3val = die3.dieValue;
            int die4val = die4.dieValue;
            int die5val = die5.dieValue;

            int[] roll = { die1val, die2val, die3val, die4val, die5val }; // adding them to an array is the same

            // writing them all out is the same
            Console.ReadLine();
            Console.WriteLine($"Die roll 1: {die1val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 2: {die2val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 3: {die3val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 4: {die4val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 5: {die5val}");
            Console.ReadLine();

            // the block of code to find out the mode and the amount is the same
            Array.Sort(roll);
            int numberSame = 0;
            int mostNumber = 0;
            foreach (int item in roll)
            {
                int sameNumber = 0;

                foreach (int j in roll)
                {
                    if (item == j)
                    {
                        sameNumber++;
                        if (sameNumber > mostNumber)
                        {
                            numberSame = j;
                            mostNumber = sameNumber;
                        }
                    }
                }
            }
            // this if statement is the same
            if (mostNumber == 1)
            {
                // this is the same
                Console.WriteLine("\nThere are no matching numbers, you get no points");
            }
            else if (mostNumber == 2)
            {
                // this is the same
                Console.WriteLine("\nYou have a two of a kind, would you like to reroll?");
                // this while loop is the same
                while (reroll1 == true)
                {
                    // this is the same
                    Console.WriteLine("[Y or N]");
                    string choice1 = Console.ReadLine();
                    // this if statement is the same
                    if (choice1 == "Y")
                    {
                        // this is the same
                        diceCounter ++;
                        reroll1 = false;
                        Console.WriteLine("\nWould you like to reroll all or just the different ones?");
                        // this while loop is the same
                        while (reroll2 == true)
                        {
                            // this is the same
                            Console.WriteLine("[ALL or SOME]");
                            string choice2 = Console.ReadLine();
                            // this if statement is the same
                            if (choice2 == "ALL")
                            {
                                reroll2 = false;
                                Player1PVEReroll(); // it instead calls the reroll method for against the computer game of 3 or more
                            }
                            else if (choice2 == "SOME")
                            {
                                // this is the same
                                reroll2 = false;

                                // this foreach is the same
                                foreach (int item in roll)
                                {
                                    if (item != numberSame)
                                    {
                                        // this is the same
                                        rerolldie.Roll();
                                        int rerollval = rerolldie.dieValue;
                                        rerollrolls.Add(rerollval);
                                        Console.WriteLine(rerollval);
                                        Thread.Sleep(100);
                                    }
                                }
                                // this is the same
                                int numberSamereroll = 0;
                                int mostNumberreroll = 0;
                                // this foreach is the same
                                foreach (int item in rerollrolls)
                                {
                                    int sameNumberreroll = 0;

                                    foreach (int j in rerollrolls)
                                    {
                                        if (item == j | item == numberSame)
                                        {
                                            sameNumberreroll++;
                                            if (sameNumberreroll > mostNumberreroll)
                                            {
                                                numberSamereroll = j;
                                                mostNumberreroll = sameNumberreroll + 2;
                                            }
                                        }
                                    }
                                }
                                // this if statement is the same
                                if (mostNumberreroll == 3)
                                {
                                    // this is the same 
                                    Console.WriteLine("\nThere are 3 matching numbers, you get 3 points!");
                                    playerScore1 += 3;
                                }
                                else if (mostNumberreroll == 4)
                                {
                                    // this is the same
                                    Console.WriteLine("\nThere are 4 matching numbers, you get 6 points!");
                                    playerScore1 += 6;
                                }
                                else if (mostNumberreroll == 5)
                                {
                                    // this is the same
                                    Console.WriteLine("\nThere are 5 matching numbers, you get 12 points!");
                                    playerScore1 += 12;
                                }
                                else if (mostNumberreroll == 2)
                                {
                                    // this is the same
                                    Console.WriteLine("There has been no change in total, no points.");
                                }
                                else
                                {
                                    // this is the same
                                    Console.WriteLine("There has been no change in total, no points.");
                                }
                            }
                            else
                            {
                                // this is the same
                                Console.WriteLine("That is not a choice");
                                reroll2 = true;
                            }
                        }
                    }
                    else if (choice1 == "N")
                    {
                        // this is the same
                        Console.WriteLine("\nNo rerolling will happen and you get no points");
                        reroll1 = false;
                    }
                    else
                    {
                        // this is the same
                        Console.WriteLine("\nThat is not a choice");
                        reroll1 = true;
                    }
                }
            }
            else if (mostNumber == 3)
            {
                // this is the same
                Console.WriteLine("\nYou have a three of a kind, you get 3 points!");
                playerScore1 += 3;
            }
            else if (mostNumber == 4)
            {
                // this is the same
                Console.WriteLine("\nYou have a four of a kind, you gte 6 points!");
                playerScore1 += 6;
            }
            else if (mostNumber == 5)
            {
                // this is the same
                Console.WriteLine("\nYou have a five of a kind, you get 12 points!");
                playerScore1 += 12;
            }

            // this if statement is the same
            if (playerScore1 >= 20)
            {
                WinPVE(); // this calls the method for what happens at the end of a against the computer game instead
            }
            else
            {
                // writes the scores in the same way
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"The computer {botScore}"); // puts the computer score instead
                Console.WriteLine("It is now the computer's turn"); // says it's the computer's turn instead
                // resets the same variables
                numberSame = 0;
                mostNumber = 0;
                reroll1 = true;
                reroll2 = true;
                Console.ReadLine();
                Bot(); // calls the method for the computer's turn instead
            }
        }

        /// <summary>
        /// This is the method for rerolling all of the dice for player 1 in against the computer
        /// </summary>
        // this is the same as the Player1PVPReroll but for against the computer, it has minor changes
        // I will comment the changes and say what is the same
        public void Player1PVEReroll()
        {
            // rolling the dice
            Console.WriteLine("\nRoll the dice...");
            die1.Roll();
            Thread.Sleep(100);
            die2.Roll();
            Thread.Sleep(100);
            die3.Roll();
            Thread.Sleep(100);
            die4.Roll();
            Thread.Sleep(100);
            die5.Roll();

            // storing the roll values is the same
            int die1val = die1.dieValue;
            int die2val = die2.dieValue;
            int die3val = die3.dieValue;
            int die4val = die4.dieValue;
            int die5val = die5.dieValue;

            int[] roll = { die1val, die2val, die3val, die4val, die5val }; // storing it in an array is the same

            // writing out the rolled numbers is the same
            Console.ReadLine();
            Console.WriteLine($"Die roll 1: {die1val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 2: {die2val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 3: {die3val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 4: {die4val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 5: {die5val}");
            Console.ReadLine();

            // this block of code including the foreach is the same
            Array.Sort(roll);
            int numberSame = 0;
            int mostNumber = 0;
            foreach (int item in roll)
            {
                int sameNumber = 0;

                foreach (int j in roll)
                {
                    if (item == j)
                    {
                        sameNumber++;
                        if (sameNumber > mostNumber)
                        {
                            numberSame = j;
                            mostNumber = sameNumber;
                        }
                    }
                }
            }
            // this if statement is the same
            if (mostNumber == 1)
            {
                // this is the same
                Console.WriteLine("There are no matching numbers, no points.");
            }
            else if (mostNumber == 2)
            {
                // this is the same
                Console.WriteLine("You have a 2 of a kind, umable to reroll again, no points");
            }
            else if (mostNumber == 3)
            {
                // this is the same
                Console.WriteLine("You have a three of a kind, you get 3 points!");
                playerScore1 += 3;
            }
            else if (mostNumber == 4)
            {
                // this is the same
                Console.WriteLine("You have a four of a kind, you get 6 points!");
                playerScore1 += 6;
            }
            else if (mostNumber == 5)
            {
                // this is the same
                Console.WriteLine("You have a five of a kind, you get 12 points!");
                playerScore1 += 12;
            }
            else
            {
                // this is the same
                Console.WriteLine("There are no matching numbers, no points");
            }

            // this if statement is the same
            if (playerScore1 >= 20)
            {
                WinPVE(); // instead calls the method for what happens when the against the computer three or more game ends
            }
            else
            {
                // prints out the scores the same
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"The computer: {botScore}"); // uses computer score instead
                Console.WriteLine("It is now the computer's turn"); // tells them it's the computer's turn instead
                // resets the same variables
                numberSame = 0;
                mostNumber = 0;
                reroll1 = true;
                reroll2 = true;
                Console.ReadLine();
                Bot(); // calls the computer's turn instead
            }
        }

        /// <summary>
        /// This is the method for player 2's turn
        /// </summary>
        // this is the same as Player1PVP but for player 2 and with minor changes
        // I will comment the changes and say what is the same
        public void Player2()
        {
            // rolling the dice is the same
            threeCounter ++;
            Console.WriteLine("\nRoll the dice...");
            die1.Roll();
            Thread.Sleep(100);
            die2.Roll();
            Thread.Sleep(100);
            die3.Roll();
            Thread.Sleep(100);
            die4.Roll();
            Thread.Sleep(100);
            die5.Roll();

            // storing the value of the dice rolls is the same
            int die1val = die1.dieValue;
            int die2val = die2.dieValue;
            int die3val = die3.dieValue;
            int die4val = die4.dieValue;
            int die5val = die5.dieValue;

            int[] roll = { die1val, die2val, die3val, die4val, die5val }; // storing it in an array is the same

            // printing the dice roll values is the same
            Console.ReadLine();
            Console.WriteLine($"Die roll 1: {die1val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 2: {die2val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 3: {die3val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 4: {die4val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 5: {die5val}");
            Console.ReadLine();

            // this block of code including the foreach is the same
            Array.Sort(roll);
            int numberSame = 0;
            int mostNumber = 0;
            foreach (int item in roll)
            {
                int sameNumber = 0;

                foreach (int j in roll)
                {
                    if (item == j)
                    {
                        sameNumber++;
                        if (sameNumber > mostNumber)
                        {
                            numberSame = j;
                            mostNumber = sameNumber;
                        }
                    }
                }
            }
            // the if statement is the same
            if (mostNumber == 1)
            {
                // this is the same
                Console.WriteLine("\nThere are no matching numbers, you get no points");
            }
            else if (mostNumber == 2)
            {
                // this is the same
                Console.WriteLine("\nYou have a two of a kind, would you like to reroll?");
                // this while loop is the same
                while (reroll1 == true)
                {
                    // this is the same
                    Console.WriteLine("[Y or N]");
                    string choice1 = Console.ReadLine();
                    // this if statement is the same
                    if (choice1 == "Y")
                    {
                        // this is the same
                        diceCounter++;
                        reroll1 = false;
                        Console.WriteLine("\nWould you like to reroll all or just the different ones?");
                        // this while loop is the same
                        while (reroll2 == true)
                        {
                            // this is the same
                            Console.WriteLine("[ALL or SOME]");
                            string choice2 = Console.ReadLine();
                            // this if statement is the same
                            if (choice2 == "ALL")
                            {
                                // this is the same
                                reroll2 = false;
                                Player2Reroll(); // only it calls the method to player 2's reroll of all dice instead
                            }
                            else if (choice2 == "SOME")
                            {
                                // this is the same
                                reroll2 = false;

                                // this foreach is the same
                                foreach (int item in roll)
                                {
                                    if (item != numberSame)
                                    {
                                        // this is the same
                                        rerolldie.Roll();
                                        int rerollval = rerolldie.dieValue;
                                        rerollrolls.Add(rerollval);
                                        Console.WriteLine(rerollval);
                                        Thread.Sleep(100);
                                    }
                                }
                                // this is the same
                                int numberSamereroll = 0;
                                int mostNumberreroll = 0;
                                // this foreach is the same
                                foreach (int item in rerollrolls)
                                {
                                    int sameNumberreroll = 0;

                                    foreach (int j in rerollrolls)
                                    {
                                        if (item == j | item == numberSame)
                                        {
                                            sameNumberreroll++;
                                            if (sameNumberreroll > mostNumberreroll)
                                            {
                                                numberSamereroll = j;
                                                mostNumberreroll = sameNumberreroll + 2;
                                            }
                                        }
                                    }
                                }
                                // this if statement is the same
                                if (mostNumberreroll == 3)
                                {
                                    // this is the same
                                    Console.WriteLine("\nThere are 3 matching numbers, you get 3 points!");
                                    playerScore2 += 3; // adds to player 2's score instead
                                }
                                else if (mostNumberreroll == 4)
                                {
                                    // this is the same
                                    Console.WriteLine("\nThere are 4 matching numbers, you get 6 points!");
                                    playerScore2 += 6; // adds to player 2's score instead
                                }
                                else if (mostNumberreroll == 5)
                                {
                                    // this is the same
                                    Console.WriteLine("\nThere are 5 matching numbers, you get 12 points!");
                                    playerScore2 += 12; // adds to player 2's score instead
                                }
                                else if (mostNumberreroll == 2)
                                {
                                    // this is the same
                                    Console.WriteLine("There has been no change in total, no points.");
                                }
                                else
                                {
                                    // this is the same
                                    Console.WriteLine("There has been no change in total, no points.");
                                }
                            }
                            else
                            {
                                // this is the same
                                Console.WriteLine("That is not a choice");
                                reroll2 = true;
                            }
                        }
                    }
                    else if (choice1 == "N")
                    {
                        // this is the same
                        Console.WriteLine("\nNo rerolling will happen and you get no points");
                        reroll1 = false;
                    }
                    else
                    {
                        // this is the same
                        Console.WriteLine("\nThat is not a choice");
                        reroll1 = true;
                    }
                }
            }
            else if (mostNumber == 3)
            {
                // this is the same
                Console.WriteLine("\nYou have a three of a kind, you get 3 points!");
                playerScore2 += 3; // adds to player 2's score instead
            }
            else if (mostNumber == 4)
            {
                // this is the same
                Console.WriteLine("\nYou have a four of a kind, you gte 6 points!");
                playerScore2 += 6; // adds to player 2's score instead
            }
            else if (mostNumber == 5)
            {
                // this is the same
                Console.WriteLine("\nYou have a five of a kind, you get 12 points!");
                playerScore2 += 12; // adds to player 2's score instead
            }

            // this if statement is the same
            if (playerScore2 >= 20)
            {
                // this is the same
                winPVP();
            }
            else
            {
                // how it prints the scores is the same
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"Player 2: {playerScore2}");
                Console.WriteLine("It is now Player 1's turn"); // says it's player 1's turn instead
                // this is the same
                numberSame = 0;
                mostNumber = 0;
                reroll1 = true;
                reroll2 = true;
                Console.ReadLine();
                Player1PVP(); // calls player 1's turn instead
            }
        }

        /// <summary>
        ///  this is the method for player 2 rerolling all of the dice
        /// </summary>
        // this is the same as Player1PVPReroll but for player 2 and with minor changes
        // I will comment the changes and say what is the same
        public void Player2Reroll()
        {
            // rolling the dice is the same
            Console.WriteLine("\nRoll the dice...");
            die1.Roll();
            Thread.Sleep(100);
            die2.Roll();
            Thread.Sleep(100);
            die3.Roll();
            Thread.Sleep(100);
            die4.Roll();
            Thread.Sleep(100);
            die5.Roll();

            // storing the values of the dice is the same
            int die1val = die1.dieValue;
            int die2val = die2.dieValue;
            int die3val = die3.dieValue;
            int die4val = die4.dieValue;
            int die5val = die5.dieValue;

            int[] roll = { die1val, die2val, die3val, die4val, die5val }; // storing it in an array is the same

            // printing the values of the dice rolls is the same
            Console.ReadLine();
            Console.WriteLine($"Die roll 1: {die1val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 2: {die2val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 3: {die3val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 4: {die4val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 5: {die5val}");
            Console.ReadLine();

            // this block of code including the foreach is the same
            Array.Sort(roll);
            int numberSame = 0;
            int mostNumber = 0;
            foreach (int item in roll)
            {
                int sameNumber = 0;

                foreach (int j in roll)
                {
                    if (item == j)
                    {
                        sameNumber++;
                        if (sameNumber > mostNumber)
                        {
                            numberSame = j;
                            mostNumber = sameNumber;
                        }
                    }
                }
            }
            // this is if statement is the same
            if (mostNumber == 1)
            {
                // this is the same
                Console.WriteLine("There are no matching numbers, no points.");
            }
            else if (mostNumber == 2)
            {
                // this is the same
                Console.WriteLine("You have a 2 of a kind, umable to reroll again, no points");
            }
            else if (mostNumber == 3)
            {
                // this is the same
                Console.WriteLine("You have a three of a kind, you get 3 points!");
                playerScore2 += 3; // adds to player 2's score instead
            }
            else if (mostNumber == 4)
            {
                // this is the same
                Console.WriteLine("You have a four of a kind, you get 6 points!");
                playerScore2 += 6; // adds to player 2's score instead
            }
            else if (mostNumber == 5)
            {
                // this is the same
                Console.WriteLine("You have a five of a kind, you get 12 points!");
                playerScore2 += 12; // adds to player 2's score instead
            }
            else
            {
                // this is the same
                Console.WriteLine("There are no matching numbers, no points");
            }

            // this if statement is the same
            if (playerScore2 >= 20)
            {
                // this is the same
                winPVP();
            }
            else
            {
                // how the scores are printed out is the same
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"Player 2: {playerScore2}");
                Console.WriteLine("It is now Player 1's turn turn"); // says it's player 1's turn instead
                // this is the same
                numberSame = 0;
                mostNumber = 0;
                reroll1 = true;
                reroll2 = true;
                Console.ReadLine();
                Player1PVP(); // calls the method for player 1's turn
            }
        }

        /// <summary>
        ///  this is the method for the computer's turn
        /// </summary>
        // this is the same as Player1PVE but for the computer and with minor changes
        // I will comment the changes and say what is the same
        public void Bot()
        {
            // the rolling of the dice is the same
            threeCounter ++;
            Console.WriteLine("\nRolling the dice..."); // says rolling instead of rolled
            die1.Roll();
            Thread.Sleep(100);
            die2.Roll();
            Thread.Sleep(100);
            die3.Roll();
            Thread.Sleep(100);
            die4.Roll();
            Thread.Sleep(100);
            die5.Roll();

            // sotring the values of the dice that were rolled is the same
            int die1val = die1.dieValue;
            int die2val = die2.dieValue;
            int die3val = die3.dieValue;
            int die4val = die4.dieValue;
            int die5val = die5.dieValue;

            int[] roll = { die1val, die2val, die3val, die4val, die5val }; // storing it in an array is the same


            // printing the values out no longer has the readlines but is the same apart from that
            Console.WriteLine($"Die roll 1: {die1val}");
            Console.WriteLine($"Die roll 2: {die2val}");
            Console.WriteLine($"Die roll 3: {die3val}");
            Console.WriteLine($"Die roll 4: {die4val}");
            Console.WriteLine($"Die roll 5: {die5val}");

            // this block of code, including the for each is the same
            Array.Sort(roll);
            int numberSame = 0;
            int mostNumber = 0;
            foreach (int item in roll)
            {
                int sameNumber = 0;

                foreach (int j in roll)
                {
                    if (item == j)
                    {
                        sameNumber++;
                        if (sameNumber > mostNumber)
                        {
                            numberSame = j;
                            mostNumber = sameNumber;
                        }
                    }
                }
            }
            // this if statement is the same
            if (mostNumber == 1)
            {
                // this is the same
                Console.WriteLine("\nThere are no matching numbers, you get no points");
            }
            else if (mostNumber == 2)
            {
                // this is not the same for the computer
                // I created 2 Random objects
                Random random1 = new Random();
                Random random2 = new Random();
                // I then used one of the random objects to get a number that is either 1 or 2
                int rerollrand = random1.Next(1, 3);
                // this if statement checks what to do based on what the random number was
                if (rerollrand == 1)
                {
                    // this is if it was 1
                    diceCounter++; // adds to the reroll counter each time
                    Console.WriteLine("\nThe computer will reroll."); // tells the player what it will do
                    // I then used the second random to get a random number thay is either 1, 2 or 3
                    int AllorSamerand = random2.Next(1, 4);
                    // this if statement checking what to do based on the random number
                    if (AllorSamerand == 2 | AllorSamerand == 3)
                    {
                        // this is if it is 2 or 3
                        Console.WriteLine("\nThe computer is rerolling all the dice"); // tells the player what the computer is doing
                        BotReroll(); // calls the method for the computer rerolling all of the dice
                    }
                    else
                    {
                        // this is if it was a 1
                        Console.WriteLine("\nThe computer is rerolling some of the dice"); // tells the player what the computer is doing
                        // this foreach is the same
                        foreach (int item in roll)
                        {
                            if (item != numberSame)
                            {
                                // this is the same
                                rerolldie.Roll();
                                int rerollval = rerolldie.dieValue;
                                rerollrolls.Add(rerollval);
                                Console.WriteLine(rerollval);
                                Thread.Sleep(100);
                            }
                        }
                        // this is the same
                        int numberSamereroll = 0;
                        int mostNumberreroll = 0;
                        // this foreach is the same
                        foreach (int item in rerollrolls)
                        {
                            int sameNumberreroll = 0;

                            foreach (int j in rerollrolls)
                            {
                                if (item == j | item == numberSame)
                                {
                                    sameNumberreroll++;
                                    if (sameNumberreroll > mostNumberreroll)
                                    {
                                        numberSamereroll = j;
                                        mostNumberreroll = sameNumberreroll + 2;
                                    }
                                }
                            }
                        }
                        // this if statement is the same
                        if (mostNumberreroll == 3)
                        {
                            // this is the same
                            Console.WriteLine("\nThere are 3 matching numbers, you get 3 points!");
                            botScore+= 3; // adds to the computer's score instead
                        }
                        else if (mostNumberreroll == 4)
                        {
                            // this is the same
                            Console.WriteLine("\nThere are 4 matching numbers, you get 6 points!");
                            botScore += 6; // adds to the computer's score instead
                        }
                        else if (mostNumberreroll == 5)
                        {
                            // this is the same
                            Console.WriteLine("\nThere are 5 matching numbers, you get 12 points!");
                            botScore += 12; // adds to the computers's score instead
                        }
                        else if (mostNumberreroll == 2)
                        {
                            // this is the same
                            Console.WriteLine("There has been no change in total, no points.");
                        }
                        else
                        {
                            // this is the same
                            Console.WriteLine("There has been no change in total, no points.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nThe computer won't reroll"); // this tells the player what the computer is doing
                }
                
            }
            else if (mostNumber == 3)
            {
                // this is the same
                Console.WriteLine("\nYou have a three of a kind, you get 3 points!");
                botScore += 3; // adds to the computer's score instead
            }
            else if (mostNumber == 4)
            {
                // this is the same
                Console.WriteLine("\nYou have a four of a kind, you gte 6 points!");
                botScore += 6; // adds to the computer's score instead
            }
            else if (mostNumber == 5)
            {
                // this is the same
                Console.WriteLine("\nYou have a five of a kind, you get 12 points!");
                botScore += 12; // adds to the computer's score instead
            }
            // this if statement is the same
            if (botScore >= 20)
            {
                // this is the same
                WinPVE();
            }
            else
            {
                // how the scores are printed is the same
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"The computer: {botScore}");
                Console.WriteLine("It is now Player 1's turn"); // tells them it's player 1's turn instead
                // this is the same
                numberSame = 0;
                mostNumber = 0;
                reroll1 = true;
                reroll2 = true;
                Console.ReadLine();
                Player1PVE(); // calls the method for player 1's turn instead
            }
        }

        /// <summary>
        ///  this is the method for the computer reolling all of the dice
        /// </summary>
        // this is the same as the same as Player1PVEReroll but for the computer and with minor changes
        // I will comment the changes and say what is the same
        public void BotReroll()
        {
            // the rolling of the dice is the same
            Console.WriteLine("\nRolling the dice..."); // says rolling not roll
            die1.Roll();
            Thread.Sleep(100);
            die2.Roll();
            Thread.Sleep(100);
            die3.Roll();
            Thread.Sleep(100);
            die4.Roll();
            Thread.Sleep(100);
            die5.Roll();

            // storing the dice values is the same
            int die1val = die1.dieValue;
            int die2val = die2.dieValue;
            int die3val = die3.dieValue;
            int die4val = die4.dieValue;
            int die5val = die5.dieValue;

            int[] roll = { die1val, die2val, die3val, die4val, die5val }; // storing it in an array is the same

            // printing the dice rolls is the same but without the readlines
            Console.WriteLine($"Die roll 1: {die1val}");
            Console.WriteLine($"Die roll 2: {die2val}");
            Console.WriteLine($"Die roll 3: {die3val}");
            Console.WriteLine($"Die roll 4: {die4val}");
            Console.WriteLine($"Die roll 5: {die5val}");

            // this block of code including the foreach is the same
            Array.Sort(roll);
            int numberSame = 0;
            int mostNumber = 0;
            foreach (int item in roll)
            {
                int sameNumber = 0;

                foreach (int j in roll)
                {
                    if (item == j)
                    {
                        sameNumber++;
                        if (sameNumber > mostNumber)
                        {
                            numberSame = j;
                            mostNumber = sameNumber;
                        }
                    }
                }
            }
            // this if statement is the same
            if (mostNumber == 1)
            {
                // this is the same
                Console.WriteLine("There are no matching numbers, no points.");
            }
            else if (mostNumber == 2)
            {
                // this is the same
                Console.WriteLine("You have a 2 of a kind, umable to reroll again, no points");
            }
            else if (mostNumber == 3)
            {
                // this is the same
                Console.WriteLine("You have a three of a kind, you get 3 points!");
                botScore += 3; // adds to the computer's score instead
            }
            else if (mostNumber == 4)
            {
                // this is the same
                Console.WriteLine("You have a four of a kind, you get 6 points!");
                botScore += 6; // adds to the computer's score instead
            }
            else if (mostNumber == 5)
            {
                // this is the same
                Console.WriteLine("You have a five of a kind, you get 12 points!");
                botScore += 12; // adds to the computer's score instead
            }
            else
            {
                // this is the same
                Console.WriteLine("There are no matching numbers, no points");
            }
            // this if statement is the same
            if (botScore >= 20)
            {
                // this is the same
                WinPVE();
            }
            else
            {
                // how the scores are written out is the same 
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"The computer: {botScore}");
                Console.WriteLine("It is now Player 1's turn"); // says player 1's turn instead
                // this is the same
                numberSame = 0;
                mostNumber = 0;
                reroll1 = true;
                reroll2 = true;
                Console.ReadLine();
                Player1PVE(); // calls the method player 1's turn instead
            }
        }

        /// <summary>
        /// this is the method for the end of the game in PVP
        /// </summary>
        public void winPVP()
        {
            gameCounter.Add(gCounter); // adds the game counter to the game counter list
            turnCounter.Add(threeCounter); // adds the turn counter to the turn counter list
            dieCounter.Add(diceCounter); // adds the rerolled dice counter to the rerolled dice counter list
            // resets these 2 variables
            reroll1 = false;
            reroll2 = false;
            Console.WriteLine("\nThe game has come to an end!"); // tells the players that it's ended
            // and if statement to determine the winner and who will get the win points
            if (playerScore1 >= 20)
            {
                // this is for when player 1 wins
                Console.WriteLine("Player 1 wins!"); // tells the players
                player1S.Add(1); // adds 1 to the player 1 score list
            }
            else
            {
                // this is for when player 2 wins
                Console.WriteLine("Player 2 wins!"); // tells the players
                player2S.Add(1); // adds 2 to the player 2 score list
            }

            TOMStats(); // calls the method for the statistics to be calculated
            Console.WriteLine("\nPress enter to continue");
            Console.WriteLine();
            Console.ReadLine();
            next(); // this calls the method that holds the menu
        }

        /// <summary>
        /// this is the method for the end of the game in against the computer
        /// </summary>
        // this is the same as winPVP but for against the computer and has minor changes
        // I will comment the changes and say what is the same
        public void WinPVE()
        {
            // this block of code up to the if statement is the same
            gameCounter.Add(gCounter);
            turnCounter.Add(threeCounter);
            dieCounter.Add(diceCounter);
            reroll1 = false;
            reroll2 = false;
            Console.WriteLine("\nThe game has come to an end!");
            // this if statement is the same
            if (playerScore1 >= 20)
            {
                // this is the same
                Console.WriteLine("Player 1 wins!");
                player1S.Add(1);
            }
            else
            {
                // this is for if the computer wins 
                Console.WriteLine("The computer wins wins!"); // tells the player
                botS.Add(1); // adds 1 to the computer score list
            }
            // this is the same
            TOMStats();
            Console.WriteLine("\nPress enter to continue");
            Console.WriteLine();
            Console.ReadLine();
            next();
        }
        
        /// <summary>
        /// this is the method for the end of the game when testing
        /// </summary>
        // this is the same as the other two win methods but it is for the testing and has minor changes
        // I will comment the changes and say what is the same
        public void WinTest()
        {
            // this is the same but nothing is added to any lists as it's for testing
            reroll1 = false;
            reroll2 = false;
            Console.WriteLine("\nThe game has come to an end!");
            // this if statement is the same
            if (botTestscore1 >= 20)
            {
                // this is for when the first computer wins
                Console.WriteLine("Computer 1 wins!"); // it prints it for testing purposes
            }
            else
            {
                // this is for when the second computer wins
                Console.WriteLine("Computer 2 wins!"); // it prints it for testing purposes
            }
        }

        /// <summary>
        /// this method calculates all of the statistics for the game
        /// </summary>
        public void TOMStats()
        {

            // sorts the lists to ascending order
            player1S.Sort();
            player2S.Sort();
            botS.Sort();

            // reverses the list so it's descending order
            player1S.Reverse();
            player2S.Reverse();
            botS.Reverse();

            // all of the foreachs add up what is inside the list 
            // this is for the total amount of times
            foreach (int item in turnCounter)
            {
                tCounter = item + item; // adding that to a variable that will be used to hold it
            }
            // this is for the total amount of rerolls done
            foreach (int item in dieCounter)
            {
                dCounter = item + item;
            }
            // this is for the total times player 1 has won
            foreach (int item in player1S)
            {
                sumOfscore1 = item + item;
            }
            // this is for the total times player 2 has won
            foreach (int item in player2S)
            {
                sumOfscore2 = item + item;
            }
            // this is for the total times the computer has won
            foreach (int item in botS)
            {
                sumOfbotScore = item + item;
            }
            // this is for the total number of times the game is played
            foreach (int item in gameCounter)
            {
                gaCounter = item + item;
            }

            // these then give the variables in the statistics class the values the corresponding variable has
            Statistics.win1 = sumOfscore1; // this is for the number of wins player 1 has
            Statistics.win2 = sumOfscore2; // this is for the number of wins player 2 has
            Statistics.winb = sumOfbotScore; // this is for the number of wins the computer has
            Statistics.tc = tCounter; // this is for the turn counter
            Statistics.rc = dCounter; // this is for the reroll of the dice counter
            Statistics.gc3 = gaCounter; // this is for the game counter
        }

        /// <summary>
        /// this method is for the first computer in testing
        /// </summary>
        // this is the same as the method for the computer's turn but for the first testing computer and has minor changes
        // I will comment the changes and say what is the same
        public void BotTest1()
        {
            // the roll of the dice is the same but it doesn't tell the player that it is rolling the dice
            die1.Roll();
            Thread.Sleep(100);
            die2.Roll();
            Thread.Sleep(100);
            die3.Roll();
            Thread.Sleep(100);
            die4.Roll();
            Thread.Sleep(100);
            die5.Roll();

            // the dice being stored in their values is the same
            int die1val = die1.dieValue;
            int die2val = die2.dieValue;
            int die3val = die3.dieValue;
            int die4val = die4.dieValue;
            int die5val = die5.dieValue;

            int[] roll = { die1val, die2val, die3val, die4val, die5val }; // the values being stored in an array is the same

            // how the values is printed out is the same
            Console.WriteLine($"Die roll 1: {die1val}");
            Console.WriteLine($"Die roll 2: {die2val}");
            Console.WriteLine($"Die roll 3: {die3val}");
            Console.WriteLine($"Die roll 4: {die4val}");
            Console.WriteLine($"Die roll 5: {die5val}");

            // this block of code including the foreach is the same
            Array.Sort(roll);
            int numberSame = 0;
            int mostNumber = 0;
            foreach (int item in roll)
            {
                int sameNumber = 0;

                foreach (int j in roll)
                {
                    if (item == j)
                    {
                        sameNumber++;
                        if (sameNumber > mostNumber)
                        {
                            numberSame = j;
                            mostNumber = sameNumber;
                        }
                    }
                }
            }
            //this if statement is the same
            if (mostNumber == 1)
            {
                // this is the same
                Console.WriteLine("\nThere are no matching numbers, you get no points");
            }
            else if (mostNumber == 2)
            {
                // this is the same
                Random random1 = new Random();
                Random random2 = new Random();
                int rerollrand = random1.Next(1, 3);
                // this if statement is the same
                if (rerollrand == 1)
                {
                    // this is the same
                    Console.WriteLine("\nThe computer will reroll.");
                    int AllorSamerand = random2.Next(1, 4);
                    // this if statement is the same
                    if (AllorSamerand == 2 | AllorSamerand == 3)
                    {
                        // this is the same
                        Console.WriteLine("\nThe computer is rerolling all the dice");
                        BotTestReroll1(); // but it calls the method for the first computer's reroll instead
                    }
                    else
                    {
                        // this is the same
                        Console.WriteLine("\nThe computer is rerolling some of the dice");
                        // this foreach is the same
                        foreach (int item in roll)
                        {
                            if (item != numberSame)
                            {
                                // this is the same
                                rerolldie.Roll();
                                int rerollval = rerolldie.dieValue;
                                rerollrolls.Add(rerollval);
                                Console.WriteLine(rerollval);
                                Thread.Sleep(100);
                            }
                        }
                        // this is the same
                        int numberSamereroll = 0;
                        int mostNumberreroll = 0;
                        // this foreach is the same
                        foreach (int item in rerollrolls)
                        {
                            int sameNumberreroll = 0;

                            foreach (int j in rerollrolls)
                            {
                                if (item == j | item == numberSame)
                                {
                                    sameNumberreroll++;
                                    if (sameNumberreroll > mostNumberreroll)
                                    {
                                        numberSamereroll = j;
                                        mostNumberreroll = sameNumberreroll + 2;
                                    }
                                }
                            }
                        }
                        // this if statement is the same
                        if (mostNumberreroll == 3)
                        {
                            // this is the same
                            Console.WriteLine("\nThere are 3 matching numbers, you get 3 points!");
                            botTestscore1 += 3; // adds it to the first computer's score instead
                        }
                        else if (mostNumberreroll == 4)
                        {
                            // this is the same
                            Console.WriteLine("\nThere are 4 matching numbers, you get 6 points!");
                            botTestscore1 += 6; // adds it to the first computer's score instead
                        }
                        else if (mostNumberreroll == 5)
                        {
                            // this is the same
                            Console.WriteLine("\nThere are 5 matching numbers, you get 12 points!");
                            botTestscore1 += 12; // adds it to the first computer's score instead
                        }
                        else if (mostNumberreroll == 2)
                        {
                            // this is the same
                            Console.WriteLine("There has been no change in total, no points.");
                        }
                        else
                        {
                            // this is the same
                            Console.WriteLine("There has been no change in total, no points.");
                        }
                    }
                }
                else
                {
                    // this is the same
                    Console.WriteLine("\nThe computer won't reroll");
                }

            }
            else if (mostNumber == 3)
            {
                // this is the same
                Console.WriteLine("\nYou have a three of a kind, you get 3 points!");
                botTestscore1 += 3; // adds it to the first computer's score instead
            }
            else if (mostNumber == 4)
            {
                // this is the same
                Console.WriteLine("\nYou have a four of a kind, you gte 6 points!");
                botTestscore1 += 6; // adds it to the first computer's score instead
            }
            else if (mostNumber == 5)
            {
                // this is the same
                Console.WriteLine("\nYou have a five of a kind, you get 12 points!");
                botTestscore1 += 12; // adds it to the first computer's score instead
            }

            if (botTestscore1 >= 20)
            {
                WinTest(); // calls the method for what happens at the end of the game but for the testing
            }
            else
            {
                // how the scores are printed is the same
                Console.WriteLine("\nThe current scores are:");
                // uses the computer scores instead
                Console.WriteLine($"Computer 1: {botTestscore1}");
                Console.WriteLine($"Computer 2: {botTestscore2}");
                Console.WriteLine("It is now Computer 2's turn"); // says it's computer 2's turn instead
                // this is the same
                numberSame = 0;
                mostNumber = 0;
                reroll1 = true;
                reroll2 = true;
                BotTest2(); // calls the method for the second computer's turn
            }
        }

        /// <summary>
        /// this method is for the second computer in testing
        /// </summary>
        // this is the same as the method BotTest1 but for the second testing computer and has minor changes
        // I will comment the changes and say what is the same
        public void BotTest2()
        {
            // the dice rolling is the same
            die1.Roll();
            Thread.Sleep(100);
            die2.Roll();
            Thread.Sleep(100);
            die3.Roll();
            Thread.Sleep(100);
            die4.Roll();
            Thread.Sleep(100);
            die5.Roll();

            // storing the values is the same
            int die1val = die1.dieValue;
            int die2val = die2.dieValue;
            int die3val = die3.dieValue;
            int die4val = die4.dieValue;
            int die5val = die5.dieValue;

            int[] roll = { die1val, die2val, die3val, die4val, die5val }; // storing them in an array is the same

            // printing the dice rolls out is the same
            Console.WriteLine($"Die roll 1: {die1val}");
            Console.WriteLine($"Die roll 2: {die2val}");
            Console.WriteLine($"Die roll 3: {die3val}");
            Console.WriteLine($"Die roll 4: {die4val}");
            Console.WriteLine($"Die roll 5: {die5val}");

            // this block of code including the foreach is the same
            Array.Sort(roll);
            int numberSame = 0;
            int mostNumber = 0;
            foreach (int item in roll)
            {
                int sameNumber = 0;

                foreach (int j in roll)
                {
                    if (item == j)
                    {
                        sameNumber++;
                        if (sameNumber > mostNumber)
                        {
                            numberSame = j;
                            mostNumber = sameNumber;
                        }
                    }
                }
            }
            // this if statement is the same
            if (mostNumber == 1)
            {
                // this is the same
                Console.WriteLine("\nThere are no matching numbers, you get no points");
            }
            else if (mostNumber == 2)
            {
                // this is the same
                Random random1 = new Random();
                Random random2 = new Random();
                int rerollrand = random1.Next(1, 3);
                // this if statement is the same
                if (rerollrand == 1)
                {
                    // this is the same
                    Console.WriteLine("\nThe computer will reroll.");
                    int AllorSamerand = random2.Next(1, 4);
                    // this if statement is the same
                    if (AllorSamerand == 2 | AllorSamerand == 3)
                    {
                        // this is the same
                        Console.WriteLine("\nThe computer is rerolling all the dice");
                        BotTestReroll2(); // calls the reroll for the second computer instead
                    }
                    else
                    {
                        // this is the same
                        Console.WriteLine("\nThe computer is rerolling some of the dice");
                        // this foreach is the same
                        foreach (int item in roll)
                        {
                            if (item != numberSame)
                            {
                                // this is the same
                                rerolldie.Roll();
                                int rerollval = rerolldie.dieValue;
                                rerollrolls.Add(rerollval);
                                Console.WriteLine(rerollval);
                                Thread.Sleep(100);
                            }
                        }
                        // this is the same
                        int numberSamereroll = 0;
                        int mostNumberreroll = 0;
                        // this foreach is the same
                        foreach (int item in rerollrolls)
                        {
                            int sameNumberreroll = 0;

                            foreach (int j in rerollrolls)
                            {
                                if (item == j | item == numberSame)
                                {
                                    sameNumberreroll++;
                                    if (sameNumberreroll > mostNumberreroll)
                                    {
                                        numberSamereroll = j;
                                        mostNumberreroll = sameNumberreroll + 2;
                                    }
                                }
                            }
                        }
                        // this if statement is the same
                        if (mostNumberreroll == 3)
                        {
                            // this is the same
                            Console.WriteLine("\nThere are 3 matching numbers, you get 3 points!");
                            botTestscore2 += 3; // adds it to the second computer's score instead
                        }
                        else if (mostNumberreroll == 4)
                        {
                            // this is the same
                            Console.WriteLine("\nThere are 4 matching numbers, you get 6 points!");
                            botTestscore2 += 6; // adds it to the second computer's score instead
                        }
                        else if (mostNumberreroll == 5)
                        {
                            // this is the same
                            Console.WriteLine("\nThere are 5 matching numbers, you get 12 points!");
                            botTestscore2 += 12; // adds it to the second computer's score instead
                        }
                        else if (mostNumberreroll == 2)
                        {
                            // this is the same
                            Console.WriteLine("There has been no change in total, no points.");
                        }
                        else
                        {
                            // this is the same
                            Console.WriteLine("There has been no change in total, no points.");
                        }
                    }
                }
                else
                {
                    // this is the same
                    Console.WriteLine("\nThe computer won't reroll");
                }

            }
            else if (mostNumber == 3)
            {
                // this is the same
                Console.WriteLine("\nYou have a three of a kind, you get 3 points!");
                botTestscore2 += 3; // adds to the second computer's score instead
            }
            else if (mostNumber == 4)
            {
                // this is the same
                Console.WriteLine("\nYou have a four of a kind, you gte 6 points!");
                botTestscore2 += 6; // adds to the second computer's score instead
            }
            else if (mostNumber == 5)
            {
                // this is the same
                Console.WriteLine("\nYou have a five of a kind, you get 12 points!");
                botTestscore2 += 12; // adds to the second computer's score instead
            }

            if (botTestscore2 >= 20)
            {
                // this is the same
                WinTest();
            }
            else
            {
                // how the scores are printed is the same
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Computer 1: {botTestscore1}");
                Console.WriteLine($"Computer 2: {botTestscore2}");
                Console.WriteLine("It is now Computer 1's turn"); // says it's computer 1's turn instead
                // this is the same
                numberSame = 0;
                mostNumber = 0;
                reroll1 = true;
                reroll2 = true;
                BotTest1(); // calls the method for the first computer's turn
            }
        }
        
        /// <summary>
        /// this method is used for rerolling all of the dice for the first computer in testing
        /// </summary>
        // this is the same the BotReroll method but for the first computer and with minor changes
        // I will comment the changes and say what is the same
        public void BotTestReroll1()
        {
            // the dice rolls are the same
            die1.Roll();
            Thread.Sleep(100);
            die2.Roll();
            Thread.Sleep(100);
            die3.Roll();
            Thread.Sleep(100);
            die4.Roll();
            Thread.Sleep(100);
            die5.Roll();

            // the sotring of the dice roll values is the same
            int die1val = die1.dieValue;
            int die2val = die2.dieValue;
            int die3val = die3.dieValue;
            int die4val = die4.dieValue;
            int die5val = die5.dieValue;

            int[] roll = { die1val, die2val, die3val, die4val, die5val }; // storing the values in an array is the same

            // printing the values of the dice rolls is the same
            Console.WriteLine($"Die roll 1: {die1val}");
            Console.WriteLine($"Die roll 2: {die2val}");
            Console.WriteLine($"Die roll 3: {die3val}");
            Console.WriteLine($"Die roll 4: {die4val}");
            Console.WriteLine($"Die roll 5: {die5val}");

            // the block of code including the foreach is the same
            Array.Sort(roll);
            int numberSame = 0;
            int mostNumber = 0;
            foreach (int item in roll)
            {
                int sameNumber = 0;

                foreach (int j in roll)
                {
                    if (item == j)
                    {
                        sameNumber++;
                        if (sameNumber > mostNumber)
                        {
                            numberSame = j;
                            mostNumber = sameNumber;
                        }
                    }
                }
            }
            // the if statement is the same
            if (mostNumber == 1)
            {
                // this is the same
                Console.WriteLine("There are no matching numbers, no points.");
            }
            else if (mostNumber == 2)
            {
                // this is the same
                Console.WriteLine("You have a 2 of a kind, umable to reroll again, no points");
            }
            else if (mostNumber == 3)
            {
                // this is the same
                Console.WriteLine("You have a three of a kind, you get 3 points!");
                botTestscore1 += 3; // adds the score to the first compouter instead
            }
            else if (mostNumber == 4)
            {
                // this is the same
                Console.WriteLine("You have a four of a kind, you get 6 points!");
                botTestscore1 += 6; // adds the score to the first computer instead
            }
            else if (mostNumber == 5)
            {
                // this is the same
                Console.WriteLine("You have a five of a kind, you get 12 points!");
                botTestscore1 += 12; // adds the score to the first computer instead
            }
            else
            {
                // this is the same
                Console.WriteLine("There are no matching numbers, no points");
            }
            // this if statement is the same
            // it checks the first computer's score instead
            if (botTestscore1 >= 20)
            {
                WinTest(); // calls the method that has what happens when the game ends in testing
            }
            else
            {
                // how the scores are printed is the same
                Console.WriteLine("\nThe current scores are:");
                // uses the tetsing computer's scores instead
                Console.WriteLine($"Computer 1: {botTestscore1}");
                Console.WriteLine($"Computer 2: {botTestscore2}");
                Console.WriteLine("It is now Computer 2's turn"); // says computer 2's turn instead
                // this is the same
                numberSame = 0;
                mostNumber = 0;
                reroll1 = true;
                reroll2 = true;
                BotTest2(); // calls the method for the second computer's turn
            }
        }

        /// <summary>
        /// this method is used for rerolling all of the dice for the second computer in testing
        /// </summary>
        // this is the same as the BotTestReroll1 but it is for the second computer and with minor changes
        // I woll comment the changes and say what is the same
        public void BotTestReroll2()
        {
            // the dice rolling is the same
            die1.Roll();
            Thread.Sleep(100);
            die2.Roll();
            Thread.Sleep(100);
            die3.Roll();
            Thread.Sleep(100);
            die4.Roll();
            Thread.Sleep(100);
            die5.Roll();

            // storing the dice roll values is the same
            int die1val = die1.dieValue;
            int die2val = die2.dieValue;
            int die3val = die3.dieValue;
            int die4val = die4.dieValue;
            int die5val = die5.dieValue;

            int[] roll = { die1val, die2val, die3val, die4val, die5val }; // storing them in an array is the same

            Console.WriteLine($"Die roll 1: {die1val}");
            Console.WriteLine($"Die roll 2: {die2val}");
            Console.WriteLine($"Die roll 3: {die3val}");
            Console.WriteLine($"Die roll 4: {die4val}");
            Console.WriteLine($"Die roll 5: {die5val}");

            // the block of code including the foreach is the same
            Array.Sort(roll);
            int numberSame = 0;
            int mostNumber = 0;
            foreach (int item in roll)
            {
                int sameNumber = 0;

                foreach (int j in roll)
                {
                    if (item == j)
                    {
                        sameNumber++;
                        if (sameNumber > mostNumber)
                        {
                            numberSame = j;
                            mostNumber = sameNumber;
                        }
                    }
                }
            }
            // the if statement is the same
            if (mostNumber == 1)
            {
                // this is the same
                Console.WriteLine("There are no matching numbers, no points.");
            }
            else if (mostNumber == 2)
            {
                // this is the same
                Console.WriteLine("You have a 2 of a kind, umable to reroll again, no points");
            }
            else if (mostNumber == 3)
            {
                // this is the same
                Console.WriteLine("You have a three of a kind, you get 3 points!");
                botTestscore2 += 3; // adds to the second computer's score instead
            }
            else if (mostNumber == 4)
            {
                // this is the same
                Console.WriteLine("You have a four of a kind, you get 6 points!");
                botTestscore2 += 6; // adds to the second computer's score instead
            }
            else if (mostNumber == 5)
            {
                // this is the same
                Console.WriteLine("You have a five of a kind, you get 12 points!");
                botTestscore2 += 12; // adds to the second computer's score instead
            }
            else
            {
                // this is the same
                Console.WriteLine("There are no matching numbers, no points");
            }
            // this if statement is the same
            if (botTestscore2 >= 20)
            {
                // this is the same
                WinTest();
            }
            else
            {
                // how the scores are printed is the same
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Computer 1: {botTestscore1}");
                Console.WriteLine($"Computer 2: {botTestscore2}");
                Console.WriteLine("It is now Computer 1's turn"); // says it's computer 1's turn instead
                // this is the same
                numberSame = 0;
                mostNumber = 0;
                reroll1 = true;
                reroll2 = true;
                BotTest1(); // calls the method for the first computer's turn
            }
        }

        /// <summary>
        /// this calls the menu
        /// </summary>
        public void next()
        {
            Game game = new Game(); // creates a new game object
            game.menu(); // calls the menu
        }
    }
}
