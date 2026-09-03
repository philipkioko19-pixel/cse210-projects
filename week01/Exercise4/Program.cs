using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int userNumber = -1;

        // Keep asking for numbers until the user types 0
        while (userNumber != 0)
        {
            Console.Write("Enter number: ");
            string response = Console.ReadLine();
            userNumber = int.Parse(response);

            // Only add the number to the list if it is not 0
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // Core Requirement 1: Calculate the sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        // Core Requirement 2: Calculate the average
        // Cast sum to float to get accurate decimal division
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Core Requirement 3: Find the maximum number
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The largest number is: {max}");

        // Stretch Challenge 1: Find the smallest positive number
        int smallestPositive = 999999; 

        foreach (int number in numbers)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
            }
        }

        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        // Stretch Challenge 2: Sort the list and display it
        numbers.Sort();

        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}