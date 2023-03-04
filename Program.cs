using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the game of Pig!");
            int playerScore = 0;
            int turnScore = 0;
            Random random = new Random();
            bool continuePlaying = true;

            while (playerScore < 20 && continuePlaying)
            {
                Console.WriteLine("Your total score is {0}", playerScore);
                Console.WriteLine("Your current turn score is {0}", turnScore);

                Console.Write("Do you want to roll again (r) or hold (h)? ");
                string input = Console.ReadLine();

                if (input != "r" && input != "h")
                {
                    Console.WriteLine("Invalid input. Please enter 'r' to roll again or 'h' to hold.");
                    continue;
                }

                if (input == "r")
                {
                    int roll = RollDice(random);
                    if (roll == 1)
                    {
                        Console.WriteLine("You rolled a 1. Your turn is over.");
                        turnScore = 0;
                        continue;
                    }

                    turnScore = UpdateTurnScore(turnScore, roll);
                }

                if (input == "h")
                {
                    playerScore = UpdateTotalScore(playerScore, turnScore);
                    turnScore = 0;
                    if (playerScore >= 20)
                    {
                        Console.WriteLine("Congratulations, you won!");
                        continuePlaying = false;
                    }
                    continue;
                }
            }

            string displayResult = DisplayEndGameResult(playerScore);
            Console.WriteLine(displayResult);

            Console.Write("Do you want to play again? (y/n) ");
            string playAgain = Console.ReadLine();

            if (playAgain == "y")
            {
                Main(args);
            }
        }

        static int RollDice(Random random)
        {
            int roll = random.Next(1, 7);
            Console.WriteLine("You rolled a {0}", roll);
            return roll;
        }

        static int UpdateTurnScore(int turnScore, int roll)
        {
            turnScore += roll;
            return turnScore;
        }

        static int UpdateTotalScore(int playerScore, int turnScore)
        {
            playerScore += turnScore;
            Console.WriteLine("Your turn is over. Your total score is {0}", playerScore);
            return playerScore;
        }

        static string DisplayEndGameResult(int playerScore)
        {
            if (playerScore >= 20)
            {
                return $"Congratulations! You won with a score of {playerScore}";
            }
            return "Better luck next time!";
        }
    }
}

