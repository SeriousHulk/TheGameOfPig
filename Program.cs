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
            Console.WriteLine("The goal is to be the first player to reach 20 points.");

            int playerScore = 0;
            int turnScore = 0;
            Random random = new Random();

            while (playerScore < 20)
            {
                Console.WriteLine("Your total score is {0}", playerScore);
                Console.WriteLine("Your current turn score is {0}", turnScore);

                Console.Write("Do you want to roll again (r) or hold (h)? ");
                string input = Console.ReadLine();

                if (input == "r")
                {
                    int roll = random.Next(1, 7);

                    Console.WriteLine("You rolled a {0}", roll);

                    if (roll == 1)
                    {
                        Console.WriteLine("You rolled a 1. Your turn is over.");
                        turnScore = 0;
                        break;
                    }
                    else
                    {
                        turnScore += roll;
                    }
                }
                else if (input == "h")
                {
                    playerScore += turnScore;
                    turnScore = 0;
                    Console.WriteLine("Your turn is over. Your total score is {0}", playerScore);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'r' to roll again or 'h' to hold.");
                }
            }

            if (playerScore >= 20)
            {
                Console.WriteLine("Congratulations! You won with a score of {0}", playerScore);
            }
            else
            {
                Console.WriteLine("Better luck next time!");
            }

            Console.Write("Do you want to play again? (y/n) ");
            string playAgain = Console.ReadLine();

            if (playAgain == "y")
            {
                Main(args);
            }
        }
    }
}
