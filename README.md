using System;
namespace BinarySearchDemonstrator
{
    internal class Program
    {
        // Private fields for application state tracking
        private static Random _randomNumberGenerator = new Random();
        private static int _targetNumber;
        private static int _iterationCount;

        static void Main(string[] args)
        {
            InitializeTarget();

            Console.Write("Enter your search query (or 0 to exit): ");
            int currentGuess = Convert.ToInt32(Console.ReadLine());

            // Core evaluation loop
            while (currentGuess != 0)
            {
                _iterationCount++;
                EvaluateInput(currentGuess);

                Console.Write("Enter your next query (or 0 to exit): ");
                currentGuess = Convert.ToInt32(Console.ReadLine());
            }
        }

        /// <summary>
        /// Initializes a new search sequence by generating a random target and resetting the iteration counter.
        /// </summary>
        private static void InitializeTarget()
        {
            _targetNumber = _randomNumberGenerator.Next(1, 1001);
            _iterationCount = 0;
            Console.WriteLine("\n--- New Session Started ---");
            Console.WriteLine("System has generated a target integer between 1 and 1000.");
        }

        /// <summary>
        /// Evaluates the user's input against the target variable and provides directional feedback.
        /// </summary>
        private static void EvaluateInput(int guess)
        {
            if (guess > _targetNumber)
            {
                Console.WriteLine($"[Feedback] {guess} is too high. Adjust your search lower.");
            }
            else if (guess < _targetNumber)
            {
                Console.WriteLine($"[Feedback] {guess} is too low. Adjust your search higher.");
            }
            else
            {
                Console.WriteLine("\n[Success] Target isolated and matched!");
                CalculatePerformanceMetrics();
                InitializeTarget(); // Automatically re-initialize for the next session
            }
        }

        /// <summary>
        /// Analyzes the iteration count against the logarithmic efficiency threshold of O(log n).
        /// </summary>
        private static void CalculatePerformanceMetrics()
        {
            Console.WriteLine($"Target isolated in {_iterationCount} iterations.");

            // A binary search on 1000 items should take a maximum of 10 steps (2^10 = 1024)
            if (_iterationCount < 10)
            {
                Console.WriteLine("[Metric] Outstanding efficiency. Data isolated below the logarithmic threshold.");
            }
            else if (_iterationCount == 10)
            {
                Console.WriteLine("[Metric] Optimal efficiency. Data isolated exactly at the logarithmic threshold.");
            }
            else
            {
                Console.WriteLine("[Metric] Sub-optimal efficiency. A binary search methodology guarantees isolation in 10 or fewer steps.");
            }
        }
    }
}
