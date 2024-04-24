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
    internal class SevensOut
    {
        Die die1 = new Die();
        Die die2 = new Die();

        public int sevenCounter;
        public int playerScore1;
        public int playerScore2;
        public int botScore;
        public int hps1;
        public int hps2;
        public int hbs;
        public int player1SLength;
        public int player2SLength;
        public int botSLength;
        public int pas1;
        public int pas2;
        public int bas;
        public int sc;
        public int dc;
        public int gc;
        public int diceCounter;
        public int gaCounter;
        public int SumOfDie;
        public int scoreAdd;
        public int sCounter;
        public int dCounter;
        public int gCounter;
        public int sumOfscore1;
        public int sumOfscore2;
        public int sumOfbotScore;
        public int botTestscore1;
        public int botTestscore2;
        public List<int> player1S = new List<int>();
        public List<int> player2S = new List<int>();
        public List<int> botS = new List<int>();
        public List<int> turnCounter = new List<int>();
        public List<int> dieCounter = new List<int>();
        public List<int> gameCounter = new List<int>();


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
                WinPVP();
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
                Console.WriteLine("It is now Player 2's turn");
                SumOfDie = 0;
                scoreAdd = 0;
                Console.ReadLine();
                Player2();

            }
        }

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
                WinPVE();
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
                Console.WriteLine("It is now the computer's turn");
                SumOfDie = 0;
                scoreAdd = 0;
                Console.ReadLine();
                Bot();
            }
        }

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
                Console.WriteLine("It is now Player 1's turn");
                SumOfDie = 0;
                scoreAdd = 0;
                Console.ReadLine();
                Player1PVP();

            }
        }

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
                Console.WriteLine("It is now Player 1's turn");
                SumOfDie = 0;
                scoreAdd = 0;
                Console.ReadLine();
                Player1PVE();
            }
        }

        public void WinPVP()
        {
            player1S.Add(1);
            player2S.Add(1);
            botS.Add(1);
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

        public void WinPVE()
        {
            player1S.Add(1);
            player2S.Add(1);
            botS.Add(1);
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

        public void SOStats()
        {
            player1S.Sort();
            player2S.Sort();
            botS.Sort();

            player1S.Reverse();
            player2S.Reverse();
            botS.Reverse();
            player1SLength = player1S.Count;
            player2SLength = player2S.Count;

            foreach (int item in turnCounter)
            {
                sCounter = item + item;
            }
            foreach (int item in dieCounter)
            {
                dCounter = item + item;
            }
            foreach (int item in player1S)
            {
                sumOfscore1 = item + item;
            }
            foreach (int item in player2S)
            {
                sumOfscore2 = item + item;
            }
            foreach (int item in botS)
            {
                sumOfbotScore = item + item;
            }
            foreach (int item in gameCounter)
            {
                gaCounter = item + item;
            }

            sc = sCounter;
            dc = dCounter;
            gc = gaCounter;
            hps1 = player1S[0];
            hps2 = player2S[0];
            hbs = botS[0];
            botSLength = botS.Count;
            pas1 = sumOfscore1 / player1SLength;
            pas2 = sumOfscore2 /player2SLength;
            bas = sumOfbotScore / botSLength;

            Statistics stats = new Statistics();
            stats.sevenstats(hps1, pas1, hps2, pas2, hbs, bas, sc, dc, gc);
        }

        public void next()
        {
            Game game = new Game();
            game.menu();
        }

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
                WinTest();
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
                Console.WriteLine("It is now Computer 2's turn");
                SumOfDie = 0;
                scoreAdd = 0;
                BotTest2();
            }
        }

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
                Console.WriteLine("It is now Computer 1's turn");
                SumOfDie = 0;
                scoreAdd = 0;
                BotTest1();
            }
        }
    }
}
