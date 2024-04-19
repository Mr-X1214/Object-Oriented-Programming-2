using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Dice_game
{
    internal class SevensOut
    {
        Die die1 = new Die();
        Die die2 = new Die();

        public int sevenCounter = 0;
        public int playerScore1 = 0;
        public int playerScore2 = 0;
        public int botScore = 0;
        public int highPlayerscore1 = 0;
        public int highPlayerscore2 = 0;
        public int highBotscore = 0;
        public int diceCounter = 0;
        int SumOfDie = 0;
        int scoreAdd = 0;
        public int sCounter = 0;
        public int dCounter = 0;
        public int gCounter = 0;
        int sumOfscore1 = 0;
        int sumOfscore2 = 0;
        int sumOfbotScore = 0;
        List<int> player1S = new List<int>();
        List<int> player2S = new List<int>();
        List<int> botS = new List<int>();
        List<int> turnCounter = new List<int>();
        List<int> dieCounter = new List<int>();
        List<int> gameCounter = new List<int>();


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
            using (StreamWriter sw = File.AppendText ("Player1Score.txt"))
            {
                sw.WriteLine(playerScore1);
            }
            using (StreamWriter sw = File.AppendText("Player2Score.txt"))
            {
                sw.WriteLine(playerScore2);
            }
            using (StreamWriter sw = File.AppendText("BotScore.txt"))
            {
                sw.WriteLine(botScore);
            }
            using (StreamWriter sw = File.AppendText ("turnCounter.txt"))
            {
                sw.WriteLine(sevenCounter);
            }
            using (StreamWriter sw = File.AppendText ("RollCounter.txt"))
            {
                sw.WriteLine(diceCounter);
            }
            using (StreamWriter sw = File.AppendText ("GameCounter.txt"))
            {
                sw.WriteLine(gCounter);
            }

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

        }

        public void WinPVE()
        {
            string file1 = @"Player1Score.txt";
            using (StreamWriter sw = File.AppendText(file1))
            {
                sw.WriteLine(playerScore1);
            }
            string file2 = @"Player2Score.txt";
            using (StreamWriter sw = File.AppendText(file2))
            {
                sw.WriteLine(playerScore2);
            }
            string file3 = @"BotScore.txt";
            using (StreamWriter sw = File.AppendText(file3))
            {
                sw.WriteLine(botScore);
            }
            string file4 = @"TurnCounter.txt";
            using (StreamWriter sw = File.AppendText(file4))
            {
                sw.WriteLine(turnCounter);
            }
            string file5 = @"RollCounter.txt";
            using (StreamWriter sw = File.AppendText(file5))
            {
                sw.WriteLine(diceCounter);
            }
            string file6 = @"GameCounter.txt";
            using (StreamWriter sw = File.AppendText(file6))
            {
                sw.WriteLine(gameCounter);
            }
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
        }

        public void SOStats()
        {
            foreach (string item in (File.ReadLines("Player1Score.txt")))
            {
                int num = Int32.Parse(item);
                player1S.Add(num);
            }
            foreach (string item in (File.ReadLines("Player2Score.txt")))
            {
                int num = Int32.Parse(item);
                player2S.Add(num);
            }
            foreach (string item in (File.ReadLines("BotScore.txt")))
            {
                int num = Int32.Parse(item);
                botS.Add(num);
            }
            foreach (string item in (File.ReadLines("GameCounter.txt")))
            {
                int num = Int32.Parse(item);
                gameCounter.Add(num);
            }
            foreach (string item in (File.ReadLines("TurnCounter.txt")))
            {
                int num = Int32.Parse(item);
                turnCounter.Add(num);
            }
            foreach (string item in (File.ReadLines("RollCounter.txt")))
            {
                int num = Int32.Parse(item);
                dieCounter.Add(num);
            }


            player1S.Sort();
            player2S.Sort();
            botS.Sort();
            foreach (int item in turnCounter)
            {
                int sCounter = item + item;
            }
            foreach (int item in dieCounter)
            {
                int dCounter = item + item;
            }
            foreach (int item in player1S)
            {
                int sumOfscore1 = item + item;
            }
            foreach (int item in player2S)
            {
                int sumOfscore2 = item + item;
            }
            foreach (int item in botS)
            {
                int sumOfbotScore = item + item;
            }

            int highPlayerscore1 = player1S[-1];
            int highPlayerscore2 = player2S[-1];
            int highBotscore = botS[-1];
            int player1SLength = player1S.Count;
            int player2SLength = player2S.Count;
            int botSLength = botS.Count;
            int playerAveragescore1 = sumOfscore1 / player1SLength;
            int playerAveragescore2 = sumOfscore2 /player2SLength;
            int botAveragescore = sumOfbotScore / botSLength;

            Console.WriteLine("\nSevens Out Statistics: ");
            Console.WriteLine($"\nPlayer 1 high score: {highPlayerscore1}");
            Console.WriteLine($"Player 1 average score: {playerAveragescore1}");
            Console.WriteLine($"Player 2 high score: {highPlayerscore2}");
            Console.WriteLine($"Player 2 average score: {playerAveragescore2}");
            Console.WriteLine($"Computer high score: {highBotscore}");
            Console.WriteLine($"Computer average score: {botAveragescore}");
            Console.WriteLine($"Times game played: {sCounter}");
            Console.WriteLine($"Times dice has been rolled: {dCounter}");
        }
    }
}
