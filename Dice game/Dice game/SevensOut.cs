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
            gCounter += 1;
            Console.WriteLine("\nRules are as follows:");
            Console.WriteLine("Roll 2 dice and note the value");
            Console.WriteLine("Add the values together and add to the score");
            Console.WriteLine("If the total of the 2 dice rolls is 7, the game ends");
            Console.WriteLine("Doubles earn twice the points");
            Console.WriteLine("Highest overall score wins");
            Console.WriteLine("\nPlayer 1 starts");
            Player1PVP();
        }

        /// <summary>
        /// This is the same as the one above but moves onto the against the computer version
        /// </summary>
        public void SOPVE()
        {
            gCounter += 1;
            Console.WriteLine("\nRules are as follows:");
            Console.WriteLine("Roll 2 dice and note the value");
            Console.WriteLine("Add the values together and add to the score");
            Console.WriteLine("If the total of the 2 dice rolls is 7, the game ends");
            Console.WriteLine("doubles earn twice the points");
            Console.WriteLine("Highest overall score wins");
            Console.WriteLine("\nPlayer 1 starts");
            Player1PVE();
        }

        /// <summary>
        /// This is player 1's turn method for the PVP game
        /// </summary>
        public void Player1PVP()
        {
            sevenCounter ++;
            Console.WriteLine("\nRoll the dice...");
            die1.Roll();
            diceCounter ++;

            Thread.Sleep(100);
            die2.Roll();
            diceCounter += 1;

            int die1Val = die1.dieValue;
            int die2Val = die2.dieValue;

            SumOfDie += die1Val + die2Val;

            Console.ReadLine();
            Console.WriteLine($"Die roll 1: {die1Val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 2: {die2Val}");
            Console.WriteLine("\nCalculating the score, please wait...");
            Thread.Sleep(3000);
            Console.WriteLine($"\nThe total is: {SumOfDie}");

            if (SumOfDie == 7)
            {
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"Player 2: {playerScore2}");
                Console.WriteLine("It is now Player 2's turn");
                SumOfDie = 0;
                scoreAdd = 0;
                Console.ReadLine();
                Player2();
            }
            else
            {
                if ( die1Val == die2Val)
                {
                    scoreAdd = SumOfDie * 2;
                    playerScore1 += scoreAdd;
                }
                else
                {
                    playerScore1 += SumOfDie;
                }
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"Player 2: {playerScore2}");
                Console.WriteLine("It is still Player 1's turn");
                SumOfDie = 0;
                scoreAdd = 0;
                Console.ReadLine();
                Player1PVP();

            }
        }

        /// <summary>
        /// This is player 1's turn method for the against the computer version
        /// </summary>
        public void Player1PVE()
        {
            sevenCounter += 1;
            Console.WriteLine("\nRoll the dice...");
            die1.Roll();
            diceCounter += 1;

            Thread.Sleep(100);
            die2.Roll();
            diceCounter += 1;

            int die1Val = die1.dieValue;
            int die2Val = die2.dieValue;

            SumOfDie += die1Val + die2Val;

            Console.ReadLine();
            Console.WriteLine($"Die roll 1: {die1Val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 2: {die2Val}");
            Console.WriteLine("\nCalculating the score, please wait...");
            Thread.Sleep(3000);
            Console.WriteLine($"\nThe total is: {SumOfDie}");

            if (SumOfDie == 7)
            {
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"Computer: {botScore}");
                Console.WriteLine("It is now the computer's turn");
                SumOfDie = 0;
                scoreAdd = 0;
                Console.ReadLine();
                Bot();
            }
            else
            {
                if (die1Val == die2Val)
                {
                    scoreAdd = SumOfDie * 2;
                    playerScore1 += scoreAdd;
                }
                else
                {
                    playerScore1 += SumOfDie;
                }
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"Computer: {botScore}");
                Console.WriteLine("It is still Player 1's turn");
                SumOfDie = 0;
                scoreAdd = 0;
                Console.ReadLine();
                Player1PVE();
            }
        }

        /// <summary>
        /// This is the method for Player 2's turn
        /// </summary>
        public void Player2() 
        {
            sevenCounter ++;
            Console.WriteLine("\nRoll the dice...");
            die1.Roll();
            diceCounter += 1;

            Thread.Sleep(100);
            die2.Roll();
            diceCounter += 1;

            int die1Val = die1.dieValue;
            int die2Val = die2.dieValue;

            SumOfDie += die1Val + die2Val;

            Console.ReadLine();
            Console.WriteLine($"Die roll 1: {die1Val}");
            Console.ReadLine();
            Console.WriteLine($"Die roll 2: {die2Val}");
            Console.WriteLine("\nCalculating the score, please wait...");
            Thread.Sleep(3000);
            Console.WriteLine($"\nThe total is: {SumOfDie}");

            if (SumOfDie == 7)
            {
                WinPVP();
            }
            else
            {
                if (die1Val == die2Val)
                {
                    scoreAdd = SumOfDie * 2;
                    playerScore2 += scoreAdd;
                }
                else
                {
                    playerScore2 += SumOfDie;
                }
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"Player 2: {playerScore2}");
                Console.WriteLine("It is still Player 2's turn");
                SumOfDie = 0;
                scoreAdd = 0;
                Console.ReadLine();
                Player2();

            }
        }

        /// <summary>
        /// This is the method for the computer's turn
        /// </summary>
        public void Bot()
        {
            sevenCounter += 1;
            Console.WriteLine("\nRolling the dice...");
            die1.Roll();
            diceCounter += 1;

            Thread.Sleep(100);
            die2.Roll();
            diceCounter += 1;

            int die1Val = die1.dieValue;
            int die2Val = die2.dieValue;

            SumOfDie += die1Val + die2Val;

            Console.WriteLine($"\nDie roll 1: {die1Val}");
            Console.WriteLine($"Die roll 2: {die2Val}");
            Console.WriteLine("\nCalculating the score, please wait...");
            Thread.Sleep(3000);
            Console.WriteLine($"\nThe total is: {SumOfDie}");

            if (SumOfDie == 7)
            {
                WinPVE();
            }
            else
            {
                if (die1Val == die2Val)
                {
                    scoreAdd = SumOfDie * 2;
                    botScore += scoreAdd;
                }
                else
                {
                    botScore += SumOfDie;
                }
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"Computer: {botScore}");
                Console.WriteLine("It is still the computer's turn");
                SumOfDie = 0;
                scoreAdd = 0;
                Console.ReadLine();
                Bot();
            }
        }

        /// <summary>
        /// This is the method for what happens when both players have 7 in PVP
        /// </summary>
        public void WinPVP()
        {
            botS.Add(0);
            player1S.Add(playerScore1);
            player2S.Add(playerScore2);
            gameCounter.Add(gCounter);
            turnCounter.Add(sevenCounter);
            dieCounter.Add(diceCounter);
            Console.WriteLine("\nThe game has ended.");
            if (playerScore1 > playerScore2)
            {
                Console.WriteLine($"Player 1 wins with {playerScore1} points!");
            }
            else if (playerScore2 > playerScore1)
            {
                Console.WriteLine($"Player 2 wins with {playerScore2} points!");
            }
            else 
            {
                Console.WriteLine($"It was a draw with both players getting {playerScore1} points!");
            }

            SOStats();
            Console.WriteLine("\nPress enter to continue");
            Console.WriteLine();
            Console.ReadLine();
            next();
        }

        /// <summary>
        /// This is the method for what happens when the player and the computer have 7
        /// </summary>
        public void WinPVE()
        {
            player2S.Add(0);
            player1S.Add(playerScore1);
            botS.Add(botScore);
            gameCounter.Add(gCounter);
            turnCounter.Add(sevenCounter);
            dieCounter.Add(diceCounter);
            Console.WriteLine("\nThe game has ended.");
            if (playerScore1 > botScore)
            {
                Console.WriteLine($"Player 1 wins with {playerScore1} points!");
            }
            else if (botScore > playerScore1)
            {
                Console.WriteLine($"Player 2 wins with {botScore} points!");
            }
            else
            {
                Console.WriteLine($"It was a draw with both players getting {playerScore1} points!");
            }

            SOStats();
            Console.WriteLine("\nPress enter to continue");
            Console.WriteLine();
            Console.ReadLine();
            next();
        }

        /// <summary>
        /// This is the method that is used in testing to show that the end method works
        /// </summary>
        public void WinTest()
        {
            Console.WriteLine("\nThe game has ended.");
            if (botTestscore1 > botTestscore2)
            {
                Console.WriteLine($"Computer 1 wins with {botTestscore1} points!");
            }
            else if (botTestscore2 > botTestscore1)
            {
                Console.WriteLine($"Computer 2 wins with {botTestscore2} points!");
            }
            else
            {
                Console.WriteLine($"It was a draw with both players getting {botTestscore1} points!");
            }
        }

        /// <summary>
        /// The method for calculating the statistics for the game
        /// </summary>
        public void SOStats()
        {
            player1S.Sort();
            player2S.Sort();
            botS.Sort();

            player1S.Reverse();
            player2S.Reverse();
            botS.Reverse();

            foreach (int item in turnCounter)
            {
                sCounter = item + item;
            }
            foreach (int item in dieCounter)
            {
                dCounter = item + item;
            }
            foreach (int item in gameCounter)
            {
                gaCounter = item + item;
            }

            Statistics.hps1 = player1S[0];
            Statistics.hps2 = player2S[0];
            Statistics.hbs = botS[0];
            Statistics.sc = sCounter;
            Statistics.dc = dCounter;
            Statistics.gc = gaCounter;
        }

        /// <summary>
        /// This is the method to call the menu
        /// </summary>
        public void next()
        {
            Game game = new Game();
            game.menu();
        }

        /// <summary>
        /// This is the method for the first computer player in the testing
        /// </summary>
        public void BotTest1()
        {
            die1.Roll();

            Thread.Sleep(100);
            die2.Roll();

            int die1Val = die1.dieValue;
            int die2Val = die2.dieValue;

            SumOfDie += die1Val + die2Val;

            Console.WriteLine($"\nDie roll 1: {die1Val}");
            Console.WriteLine($"Die roll 2: {die2Val}");
            Console.WriteLine($"\nThe total is: {SumOfDie}");

            if (SumOfDie == 7)
            {
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Computer 1: {botTestscore1}");
                Console.WriteLine($"Computer 2: {botTestscore2}");
                Console.WriteLine("It is now Computer 2's turn");
                SumOfDie = 0;
                scoreAdd = 0;
                BotTest2();
            }
            else
            {
                if (die1Val == die2Val)
                {
                    scoreAdd = SumOfDie * 2;
                    botTestscore1 += scoreAdd;
                }
                else
                {
                    botTestscore1 += SumOfDie;
                }
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Computer 1: {botTestscore1}");
                Console.WriteLine($"Computer 2: {botTestscore2}");
                Console.WriteLine("It is still computer 1's turn");
                SumOfDie = 0;
                scoreAdd = 0;
                BotTest1();
            }
        }

        /// <summary>
        /// This is the method for the second computer player in the testing
        /// </summary>
        public void BotTest2()
        {
            die1.Roll();

            Thread.Sleep(100);
            die2.Roll();

            int die1Val = die1.dieValue;
            int die2Val = die2.dieValue;

            SumOfDie += die1Val + die2Val;

            Console.WriteLine($"\nDie roll 1: {die1Val}");
            Console.WriteLine($"Die roll 2: {die2Val}");
            Console.WriteLine($"\nThe total is: {SumOfDie}");

            if (SumOfDie == 7)
            {
                WinTest();
            }
            else
            {
                if (die1Val == die2Val)
                {
                    scoreAdd = SumOfDie * 2;
                    botTestscore2 += scoreAdd;
                }
                else
                {
                    botTestscore2 += SumOfDie;
                }
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Computer 1: {botTestscore1}");
                Console.WriteLine($"Computer 2: {botTestscore2}");
                Console.WriteLine("It is still Computer 2's turn");
                SumOfDie = 0;
                scoreAdd = 0;
                BotTest2();
            }
        }
    }
}
