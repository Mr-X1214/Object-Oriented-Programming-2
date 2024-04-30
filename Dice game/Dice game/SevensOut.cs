using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Dice_game
{
    public class SevensOut
    {
        // these bellow create the variables and objects I needed in this class
        Die die1 = new Die(); // creates the first die object
        Die die2 = new Die(); // creates the second die object

        public int sevenCounter; // creates the variable for the turn counter
        public int playerScore1; // creates the variable for player 1's score
        public int playerScore2; // creates the variable for player 2's score
        public int botScore; // creates the variable for the computer's score
        public int diceCounter; // creates the variable for the dice rolls counter
        public int gaCounter; // creates the variable for the amount of games played counter
        public int SumOfDie; // creates the variable for adding up the dice roll totals
        public int scoreAdd; // creates the variable for adding the dice roll totals to the score
        public int sCounter; // creates the variable for adding up the turn counter
        public int dCounter; // creates the variable for adding up the dice roll counter
        public int gCounter; // creates the variable for adding up the game counter
        public int botTestscore1; // creates the variable for the first computer's test score
        public int botTestscore2; // creates the variable for the second computer's test score
        public List<int> player1S = new List<int>(); // creates the list for all of player 1's scores
        public List<int> player2S = new List<int>(); // creates the list for all of player 2's scores
        public List<int> botS = new List<int>(); // creates the list for all of the computer's scores
        public List<int> turnCounter = new List<int>(); // creates the list for all of the turn counter amounts
        public List<int> dieCounter = new List<int>(); // creates the list for all of the dice roll counter amounts
        public List<int> gameCounter = new List<int>(); // creates the list for all of the game counter amounts


        /// <summary>
        /// This shows the rules for the game before moving onto player1's turn
        /// </summary>
        public void SOPVP()
        {
            gCounter += 1; // this adds 1 to the game counter everytime this is called
            // this prints out the rules for the players to see at the start of the game
            Console.WriteLine("\nRules are as follows:");
            Console.WriteLine("Roll 2 dice and note the value");
            Console.WriteLine("Add the values together and add to the score");
            Console.WriteLine("If the total of the 2 dice rolls is 7, the game ends");
            Console.WriteLine("Doubles earn twice the points");
            Console.WriteLine("Highest overall score wins");
            Console.WriteLine("\nPlayer 1 starts"); // telling them the player that started
            Player1PVP(); // then calling the PVP method for player one
        }

        /// <summary>
        /// This is the same as the one above but moves onto the against the computer version
        /// </summary>
        public void SOPVE()
        {
            gCounter += 1; // adds one to the game counter everytime this is called
            // prints out the rules for the player to see
            Console.WriteLine("\nRules are as follows:");
            Console.WriteLine("Roll 2 dice and note the value");
            Console.WriteLine("Add the values together and add to the score");
            Console.WriteLine("If the total of the 2 dice rolls is 7, the game ends");
            Console.WriteLine("doubles earn twice the points");
            Console.WriteLine("Highest overall score wins");
            Console.WriteLine("\nPlayer 1 starts"); // tells them the starting player
            Player1PVE(); // calls the against the computer player 1 method
        }

        /// <summary>
        /// This is player 1's turn method for the PVP game
        /// </summary>
        public void Player1PVP()
        {
            sevenCounter ++; // adds to the turn counter everytime it's called
            Console.WriteLine("\nRoll the dice..."); // tells the player to roll the dice
            die1.Roll(); // calls the dice rolling method
            diceCounter ++; // adds to the dice rolled counter 

            Thread.Sleep(100); // this allows for time for the thread to sleep so that the roll will be randomised
            die2.Roll(); // this calls the dice rolling method for the second dice
            diceCounter ++; // adding to the dice rolled counter again

            // this makes sure that the 2 dice rolls are stored in their own values
            int die1Val = die1.dieValue;
            int die2Val = die2.dieValue;

            SumOfDie += die1Val + die2Val; // this adds the dice together

            Console.ReadLine(); // this makes it so the player has to press enter to see the roll
            // this then shows the values of the dice rolls
            Console.WriteLine($"Die roll 1: {die1Val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 2: {die2Val}");
            Console.WriteLine("\nCalculating the score, please wait...");
            Thread.Sleep(3000); // this is there for an effect, it makes the player wait so it looks like it's actually calculating it
            Console.WriteLine($"\nThe total is: {SumOfDie}"); // shows the sum of the dice

            // this if statement checks if the score is 7
            if (SumOfDie == 7)
            {
                // this being for it is 7
                // it prints the current score if
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"Player 2: {playerScore2}");
                Console.WriteLine("It is now Player 2's turn"); // prints that it's now the second player's turn
                // resetting these two variables so that they can be used again
                SumOfDie = 0;
                scoreAdd = 0;
                Console.ReadLine();
                Player2(); // calls the method for the second player
            }
            else
            {
                // if it does not equal 7
                // this if statement checks if the player has rolled a double
                if ( die1Val == die2Val)
                {
                    // this is for if it is
                    scoreAdd = SumOfDie * 2; // it doubles the dice added together
                    playerScore1 += scoreAdd; // and adds it to the player's score
                }
                else
                {
                    // this is for if they are different
                    playerScore1 += SumOfDie; // just simply adds it to the players score
                }
                // this then prints the current score
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"Player 2: {playerScore2}");
                Console.WriteLine("It is still Player 1's turn"); // tells them that the player turn has not changed
                // resets the same variables as it did if it was 7
                SumOfDie = 0;
                scoreAdd = 0;
                Console.ReadLine();
                Player1PVP(); // and calls this method so it will go back around until the value equals 7

            }
        }

        /// <summary>
        /// This is player 1's turn method for the against the computer version
        /// </summary>
        // this is the same as the PVP version for player 1 but with minor changes
        // I will comment the changes and say what is the same
        public void Player1PVE()
        {
            // the dice rolling is the same
            sevenCounter += 1;
            Console.WriteLine("\nRoll the dice...");
            die1.Roll();
            diceCounter += 1;

            Thread.Sleep(100);
            die2.Roll();
            diceCounter += 1;

            // storing it is the same
            int die1Val = die1.dieValue;
            int die2Val = die2.dieValue;

            SumOfDie += die1Val + die2Val; // adding the values together is the same

            // printing it all out and showing the valye is the same
            Console.ReadLine();
            Console.WriteLine($"Die roll 1: {die1Val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 2: {die2Val}");
            Console.WriteLine("\nCalculating the score, please wait...");
            Thread.Sleep(3000);
            Console.WriteLine($"\nThe total is: {SumOfDie}");

            // the function of the if statement is the same
            if (SumOfDie == 7)
            {
                // this now prints the computer score with player 1's score
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"Computer: {botScore}");
                Console.WriteLine("It is now the computer's turn"); // says it's the computer's turn
                SumOfDie = 0;
                scoreAdd = 0;
                Console.ReadLine();
                Bot(); // and calls the method for the computer instead
            }
            else
            {
                // this if statement is the same
                if (die1Val == die2Val)
                {
                    // this is the same
                    scoreAdd = SumOfDie * 2;
                    playerScore1 += scoreAdd;
                }
                else
                {
                    // this is the same
                    playerScore1 += SumOfDie;
                }
                // the printing of the scores is the same as it was in this method when the value is 7
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"Computer: {botScore}");
                // this is the same
                Console.WriteLine("It is still Player 1's turn");
                SumOfDie = 0;
                scoreAdd = 0;
                Console.ReadLine();
                Player1PVE(); // calls this method instead as it is currently this method being used for the against the computer game
            }
        }

        /// <summary>
        /// This is the method for Player 2's turn
        /// </summary>
        // this is the same as player 1 PVP but with minor changes
        // I will comment the changes and say what is the same
        public void Player2() 
        {
            // the dice rolling is the same
            sevenCounter ++;
            Console.WriteLine("\nRoll the dice...");
            die1.Roll();
            diceCounter += 1;

            Thread.Sleep(100);
            die2.Roll();
            diceCounter += 1;

            // storing it is the same
            int die1Val = die1.dieValue;
            int die2Val = die2.dieValue;

            SumOfDie += die1Val + die2Val; // adding it together is the same

            // printing out the values and the value of it added together is the same
            Console.ReadLine();
            Console.WriteLine($"Die roll 1: {die1Val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 2: {die2Val}");
            Console.WriteLine("\nCalculating the score, please wait...");
            Thread.Sleep(3000);
            Console.WriteLine($"\nThe total is: {SumOfDie}");

            // this if statment is the same
            if (SumOfDie == 7)
            {
                WinPVP(); // this now calls the method for what happens the game ends
            }
            else
            {
                // this if statment is the same
                if (die1Val == die2Val)
                {
                    scoreAdd = SumOfDie * 2;
                    playerScore2 += scoreAdd; // it adds it to player 2's score instead
                }
                else
                {
                    playerScore2 += SumOfDie; // this adds it to player 2's score instead
                }
                // the score printing is the same
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"Player 2: {playerScore2}");
                Console.WriteLine("It is still Player 2's turn"); // tells you it's player 2's turn instead
                // this is the same
                SumOfDie = 0;
                scoreAdd = 0;
                Console.ReadLine();
                Player2(); // calls player 2's method instead as that is the currently used one

            }
        }

        /// <summary>
        /// This is the method for the computer's turn
        /// </summary>
        // this is the same as player 1 against the computer but with minor changes
        // I will comment the changes and say what is the same
        public void Bot()
        {
            // rolling the dice is the same
            sevenCounter += 1;
            Console.WriteLine("\nRolling the dice..."); // says rolling instead of roll
            die1.Roll();
            diceCounter += 1;

            Thread.Sleep(100);
            die2.Roll();
            diceCounter += 1;

            // storing the values is the same
            int die1Val = die1.dieValue;
            int die2Val = die2.dieValue;

            SumOfDie += die1Val + die2Val; // adding it together is the same

            // for the computer, the readlines are no longer there when going through the values but is generally the same
            Console.WriteLine($"\nDie roll 1: {die1Val}");
            Console.WriteLine($"Die roll 2: {die2Val}");
            Console.WriteLine("\nCalculating the score, please wait...");
            Thread.Sleep(3000);
            Console.WriteLine($"\nThe total is: {SumOfDie}");

            // this if statement is the same
            if (SumOfDie == 7)
            {
                WinPVE(); // this calls the method for what happens at the end of the aginst the computer game
            }
            else
            {
                // this if statement is the same
                if (die1Val == die2Val)
                {
                    scoreAdd = SumOfDie * 2;
                    botScore += scoreAdd; // adds it to the computer's score instead
                }
                else
                {
                    botScore += SumOfDie; // this adds it to the computer's score instead
                }
                // displaying the score is the same
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"Computer: {botScore}");
                Console.WriteLine("It is still the computer's turn"); // says it's the computer's turn
                // this is the same
                SumOfDie = 0;
                scoreAdd = 0;
                Console.ReadLine();
                Bot(); // calls the method for the computer's turn as that is the current method
            }
        }

        /// <summary>
        /// This is the method for what happens when both players have 7 in PVP
        /// </summary>
        public void WinPVP()
        {
            botS.Add(0); // this adds 0 to the list for the computer so that it has a value stored in it and doesn't break
            player1S.Add(playerScore1); // adds the score to the player 1 list
            player2S.Add(playerScore2); // adds the score to the player 2 list
            gameCounter.Add(gCounter); // adds the game counter to the game counter list
            turnCounter.Add(sevenCounter); // adds the turn counter to the turn counter list
            dieCounter.Add(diceCounter); // adds the dice counter to the dice counter list
            Console.WriteLine("\nThe game has ended."); // tells the players that the game has ended
            // this if statement checks who won
            if (playerScore1 > playerScore2)
            {
                // this prints out that player 1 won and how many points they had
                Console.WriteLine($"Player 1 wins with {playerScore1} points!");
            }
            else if (playerScore2 > playerScore1)
            {
                // this prints out that player 2 won and how amny points they had
                Console.WriteLine($"Player 2 wins with {playerScore2} points!");
            }
            else 
            {
                // this prints out that there was a draw and only prints out one score as they are both the same
                Console.WriteLine($"It was a draw with both players getting {playerScore1} points!");
            }

            SOStats(); // this calls the statistics method inside this class so that all of them would be calculated and stored in the statistics class
            Console.WriteLine("\nPress enter to continue");
            Console.WriteLine();
            Console.ReadLine();
            next(); // this calls the method that goes to the menu 
        }

        /// <summary>
        /// This is the method for what happens when the player and the computer have 7
        /// </summary>
        // this is the same as WinPVP but with minor changes
        // I will comment the changes and say what is the same
        public void WinPVE()
        {
            player2S.Add(0); // this now adds the 0 to the player 2 score list for the same reason
            player1S.Add(playerScore1); // this is the same
            botS.Add(botScore); // this adds the computer score to the computer score list
            // adding these to the counter is the same
            gameCounter.Add(gCounter);
            turnCounter.Add(sevenCounter);
            dieCounter.Add(diceCounter);
            Console.WriteLine("\nThe game has ended.");
            // this if statment is the same but checks player 1 against the computer's score
            if (playerScore1 > botScore)
            {
                // this is the same
                Console.WriteLine($"Player 1 wins with {playerScore1} points!");
            }
            else if (botScore > playerScore1)
            {
                // this prints out that computer wins and how many points they have
                Console.WriteLine($"The computer wins with {botScore} points!");
            }
            else
            {
                // this is the same
                Console.WriteLine($"It was a draw with both players getting {playerScore1} points!");
            }

            // this is also the same
            SOStats();
            Console.WriteLine("\nPress enter to continue");
            Console.WriteLine();
            Console.ReadLine();
            next();
        }

        /// <summary>
        /// This is the method that is used in testing to show that the end method works
        /// </summary>
        // this is the same as WinPVP and WinPVE but with minor changes
        // I will comment the changes and say what is the same
        public void WinTest()
        {
            // there are no variables being added to lists as this is for testing
            Console.WriteLine("\nThe game has ended.");
            // this if statment is the same but it's comparing both of the computer's scores against each other
            if (botTestscore1 > botTestscore2)
            {
                // this prints out that the first computer won and how many points they had
                Console.WriteLine($"Computer 1 wins with {botTestscore1} points!");
            }
            else if (botTestscore2 > botTestscore1)
            {
                // this prints out that the second computer won and how many points they had
                Console.WriteLine($"Computer 2 wins with {botTestscore2} points!");
            }
            else
            {
                // this is the same for the draw only it uses the first computer's score
                Console.WriteLine($"It was a draw with both players getting {botTestscore1} points!");
            }
            // it no longer does anything after the rest of the method has been run through
        }

        /// <summary>
        /// The method for calculating the statistics for the game
        /// </summary>
        public void SOStats()
        {
            // this sorts out the 3 lists for the score
            player1S.Sort();
            player2S.Sort();
            botS.Sort();

            // this then reverses it so the highest is the first one in the list
            player1S.Reverse();
            player2S.Reverse();
            botS.Reverse();

            // these foreach statements allow the counters to be added together
            // this one adds the number turns together
            foreach (int item in turnCounter)
            {
                sCounter = item + item; // adding them to the variable that then will be used
            }
            // this one adds the dice roll amounts together
            foreach (int item in dieCounter)
            {
                dCounter = item + item;
            }
            // this one adds the number of games together
            foreach (int item in gameCounter)
            {
                gaCounter = item + item;
            }

            // these are all here so that the variables in statistics can be set to the values of the variables I used in SevensOut
            Statistics.hps1 = player1S[0]; // this stores the first index in the list as the player 1 high score
            Statistics.hps2 = player2S[0]; // this stores the first index in the list as the player 2 high score
            Statistics.hbs = botS[0]; // this stores the first index in the list as the computer high score
            // these are there to tell the statistics variables that they use the values of the counter variables
            Statistics.sc = sCounter; // this using the turn counter
            Statistics.dc = dCounter; // this using the dice rolls counter
            Statistics.gc = gaCounter; // this using the game counter
        }

        /// <summary>
        /// This is the method to call the menu
        /// </summary>
        public void next()
        {
            Game game = new Game(); // this creates a new game object
            game.menu(); // this calls the method for the menu
        }

        /// <summary>
        /// This is the method for the first computer player in the testing
        /// </summary>
        // this is the same as the computer turn method but with minor changes
        // I will comment the changes and say what has stayed the same
        public void BotTest1()
        {
            // there is nothing to tell them that the dice is being rolled
            // the rice rolls stays the same
            die1.Roll();

            Thread.Sleep(100);
            die2.Roll();

            // storing the values stays the same
            int die1Val = die1.dieValue;
            int die2Val = die2.dieValue;

            SumOfDie += die1Val + die2Val; // adding the values together is the same

            // there is no thread.sleep between the the second dice roll value being printed and the value of the rolls added together being printed
            Console.WriteLine($"\nDie roll 1: {die1Val}");
            Console.WriteLine($"Die roll 2: {die2Val}");
            Console.WriteLine($"\nThe total is: {SumOfDie}");

            // this if statement is the same
            if (SumOfDie == 7)
            {
                // displaying the score is the same but shows the two computer scores
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Computer 1: {botTestscore1}");
                Console.WriteLine($"Computer 2: {botTestscore2}");
                Console.WriteLine("It is now Computer 2's turn"); // this says it's the second computer's turn instead
                SumOfDie = 0;
                scoreAdd = 0;
                BotTest2(); // calls the method for the second computer's turn
            }
            else
            {
                // this if statement is the same
                if (die1Val == die2Val)
                {
                    scoreAdd = SumOfDie * 2;
                    botTestscore1 += scoreAdd; // adds it to the first computer's score
                }
                else
                {
                    botTestscore1 += SumOfDie; // this adds it to the first computer's score
                }
                // displaying the scores is the same
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Computer 1: {botTestscore1}");
                Console.WriteLine($"Computer 2: {botTestscore2}");
                Console.WriteLine("It is still computer 1's turn"); // this tells you it's still the first computer's turn
                SumOfDie = 0;
                scoreAdd = 0;
                BotTest1(); // this calls the firts computer's turn as that is the current method
            }
        }

        /// <summary>
        /// This is the method for the second computer player in the testing
        /// </summary>
        // this is the same as the computer 1's turn for testing method but with minor changes
        // I will comment the changes and say what has stayed the same
        public void BotTest2()
        {
            // dice rolling has stayed the same
            die1.Roll();

            Thread.Sleep(100);
            die2.Roll();

            // storing the values has stayed the same
            int die1Val = die1.dieValue;
            int die2Val = die2.dieValue;

            SumOfDie += die1Val + die2Val; // adding the rolls together is the same

            // printing the values of the dice rolls and added values is the same
            Console.WriteLine($"\nDie roll 1: {die1Val}");
            Console.WriteLine($"Die roll 2: {die2Val}");
            Console.WriteLine($"\nThe total is: {SumOfDie}");

            // this if statement is the same
            if (SumOfDie == 7)
            {
                WinTest(); // this calls the method that has what happens at the end of the testing game
            }
            else
            {
                // this if statement is the same
                if (die1Val == die2Val)
                {
                    scoreAdd = SumOfDie * 2;
                    botTestscore2 += scoreAdd; // adds it to the second computer's score
                }
                else
                {
                    botTestscore2 += SumOfDie; // this adds it to the second computers score
                }
                // printing the scores is the same
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Computer 1: {botTestscore1}");
                Console.WriteLine($"Computer 2: {botTestscore2}");
                Console.WriteLine("It is still Computer 2's turn"); // says it's still the second computer's turn instead
                SumOfDie = 0;
                scoreAdd = 0;
                BotTest2(); // calls the method for the second computer's turn as that is the current method
            }
        }
    }
}
