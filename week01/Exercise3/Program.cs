using System;

class Program
{
    static void Main(string[] args)
    {
        // Stretch Challenge 2: Loop to play again
        string keepPlaying = "yes";

        while (keepPlaying.ToLower() == "yes")
        {
            // Core Requirement 3: Pick a random number between 1 and 100
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int userGuess = -1;
            int numberOfGuesses = 0; // Stretch Challenge 1: Count attempts

            // Core Requirement 1 & 2: Loop until the guess matches the magic number
            while (userGuess != magicNumber)
            {
                Console.Write("What is your guess? ");
                userGuess = int.Parse(Console.ReadLine());
                numberOfGuesses++;

                if (userGuess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (userGuess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            // Display total guesses
            Console.WriteLine($"You guessed it in {numberOfGuesses} tries!");

            // Ask if they want to play another round
            Console.Write("Do you want to play again? (yes/no) ");
            keepPlaying = Console.ReadLine();
            Console.WriteLine();
        }

        Console.WriteLine("Thanks for playing!");
    }
}