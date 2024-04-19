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
        Die die1 = new Die();
        Die die2 = new Die();
        Die die3 = new Die();
        Die die4 = new Die();
        Die die5 = new Die();
        Die rerolldie = new Die();
        int threeCounter = 0;
        public int playerScore1 = 0;
        int playerScore2 = 0;
        public int botScore = 0;
        public int highPlayerscore1 = 0;
        public int highPlayerscore2 = 0;
        public int highBotscore = 0;
        int playerAveragescore1 = 0;
        int playerAveragescore2 = 0;
        int botAveragescore = 0;
        int diceCounter = 0;
        bool reroll1 = true;
        bool reroll2 = true;
        List<int> rerollrolls = new List<int>();

        public void TOMPVP()
        {
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
            Player1PVP();
        }

        public void TOMPVE()
        {
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
            Player1PVE();
        }

        public void Player1PVP()
        {
            threeCounter += 1;
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

            int die1val = die1.dieValue;
            int die2val = die2.dieValue;
            int die3val = die3.dieValue;
            int die4val = die4.dieValue;
            int die5val = die5.dieValue;

            int[] roll = { die1val, die2val, die3val, die4val, die5val };

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
            if (mostNumber == 1)
            {
                Console.WriteLine("\nThere are no matching numbers, you get no points");
            }
            else if (mostNumber == 2)
            {
                Console.WriteLine("\nYou have a two of a kind, would you like to reroll?");
                while (reroll1 == true)
                {
                    Console.WriteLine("[Y or N]");
                    string choice1 = Console.ReadLine();
                    if (choice1 == "Y")
                    {
                        reroll1 = false;
                        Console.WriteLine("\nWould you like to reroll all or just the different ones?");
                        while (reroll2 == true)
                        {
                            Console.WriteLine("[ALL or SOME]");
                            string choice2 = Console.ReadLine();
                            if (choice2 == "ALL")
                            {
                                reroll2 = false;
                                Player1PVPReroll();
                            }
                            else if (choice2 == "SOME")
                            {
                                reroll2 = false;

                                foreach (int item in roll)
                                {
                                    if (item != numberSame)
                                    {
                                        rerolldie.Roll();
                                        int rerollval = rerolldie.dieValue;
                                        rerollrolls.Add(rerollval);
                                        Console.WriteLine(rerollval);
                                        Thread.Sleep(100);
                                    }
                                }
                                int numberSamereroll = 0;
                                int mostNumberreroll = 0;
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
                                if (mostNumberreroll == 3)
                                {
                                    Console.WriteLine("\nThere are 3 matching numbers, you get 3 points!");
                                    playerScore1 += 3;
                                }
                                else if (mostNumberreroll == 4)
                                {
                                    Console.WriteLine("\nThere are 4 matching numbers, you get 6 points!");
                                    playerScore1 += 6;
                                }
                                else if (mostNumberreroll == 5)
                                {
                                    Console.WriteLine("\nThere are 5 matching numbers, you get 12 points!");
                                    playerScore1 += 12;
                                }
                                else if (mostNumberreroll == 2)
                                {
                                    Console.WriteLine("There has been no change in total, no points.");
                                }
                                else
                                {
                                    Console.WriteLine("There has been no change in total, no points.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("That is not a choice");
                                reroll2 = true;
                            }
                        }
                    }
                    else if (choice1 == "N")
                    {
                        Console.WriteLine("\nNo rerolling will happen and you get no points");
                        reroll1 = false;
                    }
                    else
                    {
                        Console.WriteLine("\nThat is not a choice");
                        reroll1 = true;
                    }
                }
            }
            else if (mostNumber == 3)
            {
                Console.WriteLine("\nYou have a three of a kind, you get 3 points!");
                playerScore1 += 3;
            }
            else if (mostNumber == 4)
            {
                Console.WriteLine("\nYou have a four of a kind, you gte 6 points!");
                playerScore1 += 6;
            }
            else if (mostNumber == 5)
            {
                Console.WriteLine("\nYou have a five of a kind, you get 12 points!");
                playerScore1 += 12;
            }

            if (playerScore1 >= 20)
            {
                winPVP();
            }
            else
            {
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"Player 2: {playerScore2}");
                Console.WriteLine("It is now Player 2's turn");
                numberSame = 0;
                mostNumber = 0;
                reroll1 = true;
                reroll2 = true;
                Console.ReadLine();
                Player2();
            }
        }

        public void Player1PVPReroll()
        {
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

            int die1val = die1.dieValue;
            int die2val = die2.dieValue;
            int die3val = die3.dieValue;
            int die4val = die4.dieValue;
            int die5val = die5.dieValue;

            int[] roll = { die1val, die2val, die3val, die4val, die5val };

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
            if (mostNumber == 1)
            {
                Console.WriteLine("There are no matching numbers, no points.");
            }
            else if (mostNumber == 2)
            {
                Console.WriteLine("You have a 2 of a kind, umable to reroll again, no points");
            }
            else if (mostNumber == 3)
            {
                Console.WriteLine("You have a three of a kind, you get 3 points!");
                playerScore1 += 3;
            }
            else if (mostNumber == 4)
            {
                Console.WriteLine("You have a four of a kind, you get 6 points!");
                playerScore1 += 6;
            }
            else if (mostNumber == 5)
            {
                Console.WriteLine("You have a five of a kind, you get 12 points!");
                playerScore1 += 12;
            }
            else
            {
                Console.WriteLine("There are no matching numbers, no points");
            }

            if (playerScore1 >= 20)
            {
                winPVP();
            }
            else
            {
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"Player 2: {playerScore2}");
                Console.WriteLine("It is now Player 2's turn");
                numberSame = 0;
                mostNumber = 0;
                reroll1 = true;
                reroll2 = true;
                Console.ReadLine();
                Player2();
            }
        }

        public void Player1PVE()
        {
            threeCounter += 1;
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

            int die1val = die1.dieValue;
            int die2val = die2.dieValue;
            int die3val = die3.dieValue;
            int die4val = die4.dieValue;
            int die5val = die5.dieValue;

            int[] roll = { die1val, die2val, die3val, die4val, die5val };

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
            if (mostNumber == 1)
            {
                Console.WriteLine("\nThere are no matching numbers, you get no points");
            }
            else if (mostNumber == 2)
            {
                Console.WriteLine("\nYou have a two of a kind, would you like to reroll?");
                while (reroll1 == true)
                {
                    Console.WriteLine("[Y or N]");
                    string choice1 = Console.ReadLine();
                    if (choice1 == "Y")
                    {
                        reroll1 = false;
                        Console.WriteLine("\nWould you like to reroll all or just the different ones?");
                        while (reroll2 == true)
                        {
                            Console.WriteLine("[ALL or SOME]");
                            string choice2 = Console.ReadLine();
                            if (choice2 == "ALL")
                            {
                                reroll2 = false;
                                Player1PVEReroll();
                            }
                            else if (choice2 == "SOME")
                            {
                                reroll2 = false;

                                foreach (int item in roll)
                                {
                                    if (item != numberSame)
                                    {
                                        rerolldie.Roll();
                                        int rerollval = rerolldie.dieValue;
                                        rerollrolls.Add(rerollval);
                                        Console.WriteLine(rerollval);
                                        Thread.Sleep(100);
                                    }
                                }
                                int numberSamereroll = 0;
                                int mostNumberreroll = 0;
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
                                if (mostNumberreroll == 3)
                                {
                                    Console.WriteLine("\nThere are 3 matching numbers, you get 3 points!");
                                    playerScore1 += 3;
                                }
                                else if (mostNumberreroll == 4)
                                {
                                    Console.WriteLine("\nThere are 4 matching numbers, you get 6 points!");
                                    playerScore1 += 6;
                                }
                                else if (mostNumberreroll == 5)
                                {
                                    Console.WriteLine("\nThere are 5 matching numbers, you get 12 points!");
                                    playerScore1 += 12;
                                }
                                else if (mostNumberreroll == 2)
                                {
                                    Console.WriteLine("There has been no change in total, no points.");
                                }
                                else
                                {
                                    Console.WriteLine("There has been no change in total, no points.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("That is not a choice");
                                reroll2 = true;
                            }
                        }
                    }
                    else if (choice1 == "N")
                    {
                        Console.WriteLine("\nNo rerolling will happen and you get no points");
                        reroll1 = false;
                    }
                    else
                    {
                        Console.WriteLine("\nThat is not a choice");
                        reroll1 = true;
                    }
                }
            }
            else if (mostNumber == 3)
            {
                Console.WriteLine("\nYou have a three of a kind, you get 3 points!");
                playerScore1 += 3;
            }
            else if (mostNumber == 4)
            {
                Console.WriteLine("\nYou have a four of a kind, you gte 6 points!");
                playerScore1 += 6;
            }
            else if (mostNumber == 5)
            {
                Console.WriteLine("\nYou have a five of a kind, you get 12 points!");
                playerScore1 += 12;
            }

            if (playerScore1 >= 20)
            {
                WinPVE();
            }
            else
            {
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"The computer {botScore}");
                Console.WriteLine("It is now the computer's turn");
                numberSame = 0;
                mostNumber = 0;
                reroll1 = true;
                reroll2 = true;
                Console.ReadLine();
                Bot();
            }
        }

        public void Player1PVEReroll()
        {
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

            int die1val = die1.dieValue;
            int die2val = die2.dieValue;
            int die3val = die3.dieValue;
            int die4val = die4.dieValue;
            int die5val = die5.dieValue;

            int[] roll = { die1val, die2val, die3val, die4val, die5val };

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
            if (mostNumber == 1)
            {
                Console.WriteLine("There are no matching numbers, no points.");
            }
            else if (mostNumber == 2)
            {
                Console.WriteLine("You have a 2 of a kind, umable to reroll again, no points");
            }
            else if (mostNumber == 3)
            {
                Console.WriteLine("You have a three of a kind, you get 3 points!");
                playerScore1 += 3;
            }
            else if (mostNumber == 4)
            {
                Console.WriteLine("You have a four of a kind, you get 6 points!");
                playerScore1 += 6;
            }
            else if (mostNumber == 5)
            {
                Console.WriteLine("You have a five of a kind, you get 12 points!");
                playerScore1 += 12;
            }
            else
            {
                Console.WriteLine("There are no matching numbers, no points");
            }

            if (playerScore1 >= 20)
            {
                WinPVE();
            }
            else
            {
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"The computer: {botScore}");
                Console.WriteLine("It is now the computer's turn");
                numberSame = 0;
                mostNumber = 0;
                reroll1 = true;
                reroll2 = true;
                Console.ReadLine();
                Bot();
            }
        }

        public void Player2()
        {
            threeCounter += 1;
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

            int die1val = die1.dieValue;
            int die2val = die2.dieValue;
            int die3val = die3.dieValue;
            int die4val = die4.dieValue;
            int die5val = die5.dieValue;

            int[] roll = { die1val, die2val, die3val, die4val, die5val };

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
            if (mostNumber == 1)
            {
                Console.WriteLine("\nThere are no matching numbers, you get no points");
            }
            else if (mostNumber == 2)
            {
                Console.WriteLine("\nYou have a two of a kind, would you like to reroll?");
                while (reroll1 == true)
                {
                    Console.WriteLine("[Y or N]");
                    string choice1 = Console.ReadLine();
                    if (choice1 == "Y")
                    {
                        reroll1 = false;
                        Console.WriteLine("\nWould you like to reroll all or just the different ones?");
                        while (reroll2 == true)
                        {
                            Console.WriteLine("[ALL or SOME]");
                            string choice2 = Console.ReadLine();
                            if (choice2 == "ALL")
                            {
                                reroll2 = false;
                                Player2Reroll();
                            }
                            else if (choice2 == "SOME")
                            {
                                reroll2 = false;

                                foreach (int item in roll)
                                {
                                    if (item != numberSame)
                                    {
                                        rerolldie.Roll();
                                        int rerollval = rerolldie.dieValue;
                                        rerollrolls.Add(rerollval);
                                        Console.WriteLine(rerollval);
                                        Thread.Sleep(100);
                                    }
                                }
                                int numberSamereroll = 0;
                                int mostNumberreroll = 0;
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
                                if (mostNumberreroll == 3)
                                {
                                    Console.WriteLine("\nThere are 3 matching numbers, you get 3 points!");
                                    playerScore2 += 3;
                                }
                                else if (mostNumberreroll == 4)
                                {
                                    Console.WriteLine("\nThere are 4 matching numbers, you get 6 points!");
                                    playerScore2 += 6;
                                }
                                else if (mostNumberreroll == 5)
                                {
                                    Console.WriteLine("\nThere are 5 matching numbers, you get 12 points!");
                                    playerScore2 += 12;
                                }
                                else if (mostNumberreroll == 2)
                                {
                                    Console.WriteLine("There has been no change in total, no points.");
                                }
                                else
                                {
                                    Console.WriteLine("There has been no change in total, no points.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("That is not a choice");
                                reroll2 = true;
                            }
                        }
                    }
                    else if (choice1 == "N")
                    {
                        Console.WriteLine("\nNo rerolling will happen and you get no points");
                        reroll1 = false;
                    }
                    else
                    {
                        Console.WriteLine("\nThat is not a choice");
                        reroll1 = true;
                    }
                }
            }
            else if (mostNumber == 3)
            {
                Console.WriteLine("\nYou have a three of a kind, you get 3 points!");
                playerScore2 += 3;
            }
            else if (mostNumber == 4)
            {
                Console.WriteLine("\nYou have a four of a kind, you gte 6 points!");
                playerScore2 += 6;
            }
            else if (mostNumber == 5)
            {
                Console.WriteLine("\nYou have a five of a kind, you get 12 points!");
                playerScore2 += 12;
            }

            if (playerScore2 >= 20)
            {
                winPVP();
            }
            else
            {
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"Player 2: {playerScore2}");
                Console.WriteLine("It is now Player 1's turn");
                numberSame = 0;
                mostNumber = 0;
                reroll1 = true;
                reroll2 = true;
                Console.ReadLine();
                Player1PVP();
            }
        }

        public void Player2Reroll()
        {
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

            int die1val = die1.dieValue;
            int die2val = die2.dieValue;
            int die3val = die3.dieValue;
            int die4val = die4.dieValue;
            int die5val = die5.dieValue;

            int[] roll = { die1val, die2val, die3val, die4val, die5val };

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
            if (mostNumber == 1)
            {
                Console.WriteLine("There are no matching numbers, no points.");
            }
            else if (mostNumber == 2)
            {
                Console.WriteLine("You have a 2 of a kind, umable to reroll again, no points");
            }
            else if (mostNumber == 3)
            {
                Console.WriteLine("You have a three of a kind, you get 3 points!");
                playerScore2 += 3;
            }
            else if (mostNumber == 4)
            {
                Console.WriteLine("You have a four of a kind, you get 6 points!");
                playerScore2 += 6;
            }
            else if (mostNumber == 5)
            {
                Console.WriteLine("You have a five of a kind, you get 12 points!");
                playerScore2 += 12;
            }
            else
            {
                Console.WriteLine("There are no matching numbers, no points");
            }

            if (playerScore2 >= 20)
            {
                winPVP();
            }
            else
            {
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"Player 2: {playerScore2}");
                Console.WriteLine("It is now Player 1's turn turn");
                numberSame = 0;
                mostNumber = 0;
                reroll1 = true;
                reroll2 = true;
                Console.ReadLine();
                Player1PVP();
            }
        }

        public void Bot()
        {
            threeCounter += 1;

            Console.WriteLine("\nRolling the dice...");
            die1.Roll();
            Thread.Sleep(100);
            die2.Roll();
            Thread.Sleep(100);
            die3.Roll();
            Thread.Sleep(100);
            die4.Roll();
            Thread.Sleep(100);
            die5.Roll();

            int die1val = die1.dieValue;
            int die2val = die2.dieValue;
            int die3val = die3.dieValue;
            int die4val = die4.dieValue;
            int die5val = die5.dieValue;

            int[] roll = { die1val, die2val, die3val, die4val, die5val };


            Console.WriteLine($"Die roll 1: {die1val}");
            Console.WriteLine($"Die roll 2: {die2val}");
            Console.WriteLine($"Die roll 3: {die3val}");
            Console.WriteLine($"Die roll 4: {die4val}");
            Console.WriteLine($"Die roll 5: {die5val}");

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

            if (mostNumber == 1)
            {
                Console.WriteLine("\nThere are no matching numbers, you get no points");
            }
            else if (mostNumber == 2)
            {
                Random random1 = new Random();
                Random random2 = new Random();
                int rerollrand = random1.Next(1, 3);
                if (rerollrand == 1)
                {
                    Console.WriteLine("\nThe computer will reroll.");
                    int AllorSamerand = random2.Next(1, 4);
                    if (AllorSamerand == 2 | AllorSamerand == 3)
                    {
                        Console.WriteLine("\nThe computer is rerolling all the dice");
                        BotReroll();
                    }
                    else
                    {
                        Console.WriteLine("\nThe computer is rerolling some of the dice");
                        foreach (int item in roll)
                        {
                            if (item != numberSame)
                            {
                                rerolldie.Roll();
                                int rerollval = rerolldie.dieValue;
                                rerollrolls.Add(rerollval);
                                Console.WriteLine(rerollval);
                                Thread.Sleep(100);
                            }
                        }
                        int numberSamereroll = 0;
                        int mostNumberreroll = 0;
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
                        if (mostNumberreroll == 3)
                        {
                            Console.WriteLine("\nThere are 3 matching numbers, you get 3 points!");
                            botScore+= 3;
                        }
                        else if (mostNumberreroll == 4)
                        {
                            Console.WriteLine("\nThere are 4 matching numbers, you get 6 points!");
                            botScore += 6;
                        }
                        else if (mostNumberreroll == 5)
                        {
                            Console.WriteLine("\nThere are 5 matching numbers, you get 12 points!");
                            botScore += 12;
                        }
                        else if (mostNumberreroll == 2)
                        {
                            Console.WriteLine("There has been no change in total, no points.");
                        }
                        else
                        {
                            Console.WriteLine("There has been no change in total, no points.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nThe computer won't reroll");
                }
                
            }
            else if (mostNumber == 3)
            {
                Console.WriteLine("\nYou have a three of a kind, you get 3 points!");
                botScore += 3;
            }
            else if (mostNumber == 4)
            {
                Console.WriteLine("\nYou have a four of a kind, you gte 6 points!");
                botScore += 6;
            }
            else if (mostNumber == 5)
            {
                Console.WriteLine("\nYou have a five of a kind, you get 12 points!");
                botScore += 12;
            }

            if (botScore >= 20)
            {
                WinPVE();
            }
            else
            {
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"The computer: {botScore}");
                Console.WriteLine("It is now Player 1's turn");
                numberSame = 0;
                mostNumber = 0;
                reroll1 = true;
                reroll2 = true;
                Console.ReadLine();
                Player1PVE();
            }
        }

        public void BotReroll()
        {
            Console.WriteLine("\nRolling the dice...");
            die1.Roll();
            Thread.Sleep(100);
            die2.Roll();
            Thread.Sleep(100);
            die3.Roll();
            Thread.Sleep(100);
            die4.Roll();
            Thread.Sleep(100);
            die5.Roll();

            int die1val = die1.dieValue;
            int die2val = die2.dieValue;
            int die3val = die3.dieValue;
            int die4val = die4.dieValue;
            int die5val = die5.dieValue;

            int[] roll = { die1val, die2val, die3val, die4val, die5val };

            Console.WriteLine($"Die roll 1: {die1val}");
            Console.WriteLine($"Die roll 2: {die2val}");
            Console.WriteLine($"Die roll 3: {die3val}");
            Console.WriteLine($"Die roll 4: {die4val}");
            Console.WriteLine($"Die roll 5: {die5val}");

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
            if (mostNumber == 1)
            {
                Console.WriteLine("There are no matching numbers, no points.");
            }
            else if (mostNumber == 2)
            {
                Console.WriteLine("You have a 2 of a kind, umable to reroll again, no points");
            }
            else if (mostNumber == 3)
            {
                Console.WriteLine("You have a three of a kind, you get 3 points!");
                botScore += 3;
            }
            else if (mostNumber == 4)
            {
                Console.WriteLine("You have a four of a kind, you get 6 points!");
                botScore += 6;
            }
            else if (mostNumber == 5)
            {
                Console.WriteLine("You have a five of a kind, you get 12 points!");
                botScore += 12;
            }
            else
            {
                Console.WriteLine("There are no matching numbers, no points");
            }

            if (botScore >= 20)
            {
                WinPVE();
            }
            else
            {
                Console.WriteLine("\nThe current scores are:");
                Console.WriteLine($"Player 1: {playerScore1}");
                Console.WriteLine($"The computer: {botScore}");
                Console.WriteLine("It is now Player 1's turn");
                numberSame = 0;
                mostNumber = 0;
                reroll1 = true;
                reroll2 = true;
                Console.ReadLine();
                Player1PVE();
            }
        }

        public void winPVP()
        {
            reroll1 = false;
            reroll2 = false;
            Console.WriteLine("\nThe game has come to an end!");
            if (playerScore1 >= 20)
            {
                Console.WriteLine("Player 1 wins!");
            }
            else
            {
                Console.WriteLine("Player 2 wins!");
            }
        }

        public void WinPVE()
        {
            reroll1 = false;
            reroll2 = false;
            Console.WriteLine("\nThe game has come to an end!");
            if (playerScore1 >= 20)
            {
                Console.WriteLine("Player 1 wins!");
            }
            else
            {
                Console.WriteLine("The computer wins wins!");
            }
        }

        public void TOMStats()
        {
            
            Console.WriteLine("\nThree Or More Statistics: ");
            Console.WriteLine($"\nPlayer 1 high score: {highPlayerscore1}");
            Console.WriteLine($"Player 1 average score: {playerAveragescore1}");
            Console.WriteLine($"Player 2 high score: {highPlayerscore2}");
            Console.WriteLine($"Player 2 average score: {playerAveragescore2}");
            Console.WriteLine($"Computer high score: {highBotscore}");
            Console.WriteLine($"Computer average score: {botAveragescore}");
            Console.WriteLine($"Times game played: {threeCounter}");
            Console.WriteLine($"Times dice has been rolled: {diceCounter}");
        }


    }
}
