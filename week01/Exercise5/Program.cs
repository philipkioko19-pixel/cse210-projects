using System;

class Program
{
    static void Main(string[] args)
    {
        // Call DisplayWelcome function
        DisplayWelcome();

        // Call PromptUserName and store the returned string
        string userName = PromptUserName();

        // Call PromptUserNumber and store the returned int
        int userNumber = PromptUserNumber();

        // Call SquareNumber and store the result
        int squaredNumber = SquareNumber(userNumber);

        // Display the final result using the parameters passed in
        DisplayResult(userName, squaredNumber);
    }

    // Displays the welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Asks for the user's name and returns it as a string
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // Asks for the user's favorite number and returns it as an integer
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    // Accepts an integer, squares it, and returns the result
    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    // Accepts the name and squared number, then displays them
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}