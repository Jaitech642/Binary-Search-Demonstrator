using System;
using static System.Console;

namespace Guess_Number
{
    internal class Program
    {
        static Random randomNumbers = new Random();
        static int answer;
        static int guesses;
        static void Main(string[] args)
        {
            {
                int userGuess; // the number a user guesses

                newGame();

                Write("Guess (0 to exit): ");
                userGuess = Convert.ToInt32(Console.ReadLine());

                while (userGuess != 0)
                {
                    guesses++;
                    CheckStatus(userGuess);

                    Write("Guess (0 to exit): ");
                    userGuess = Convert.ToInt32(Console.ReadLine());
                }
            }

            static void newGame()
            {
                answer = randomNumbers.Next(1, 1001);
                guesses = 0;
                WriteLine("Guess a number between 1 and 1000");
            }

            static void CheckStatus(int guess)
            {
                if (guess > answer)   //  too high
                {
                    WriteLine($"{guess} is too high. Try again.");
                }
                else if (guess < answer)  // too low
                {
                    WriteLine($"{guess} is too low. Try again.");
                }
                else   // the right number
                {
                    WriteLine("Congratulations. You guessed the number!");
                    DisplayMessage();
                    newGame(); // Start a new game here
                }
            }

            static void DisplayMessage()
            {
                WriteLine($"You guessed the number in {guesses} tries");

                if (guesses < 10)
                {
                    WriteLine("Either you know the secret or you got lucky!");
                }
                else if (guesses == 10)
                {
                    WriteLine("Aha! You know the secret!");
                }
                else
                {
                    WriteLine("You should be able to do better!");
                }
            }
        }

    }
}

