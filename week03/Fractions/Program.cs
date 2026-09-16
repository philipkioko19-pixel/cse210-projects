using System;

class Program
{
    static void Main(string[] args)
    {
        // Verify the three constructors
        Fraction f1 = new Fraction();          // 1/1
        Fraction f2 = new Fraction(5);         // 5/1
        Fraction f3 = new Fraction(3, 4);      // 3/4
        Fraction f4 = new Fraction(1, 3);      // 1/3

        // Display fractional and decimal views for the initial fractions
        DisplayFractionInfo(f1);
        DisplayFractionInfo(f2);
        DisplayFractionInfo(f3);
        DisplayFractionInfo(f4);

        // Verify getters and setters
        Console.WriteLine("\n--- Testing Getters and Setters ---");
        Fraction testFraction = new Fraction();
        Console.WriteLine($"Initial: {testFraction.GetFractionString()}");
        
        testFraction.SetTop(2);
        testFraction.SetBottom(5);
        Console.WriteLine($"After setting top to 2 and bottom to 5: {testFraction.GetFractionString()}");
        Console.WriteLine($"Retrieved Top: {testFraction.GetTop()}");
        Console.WriteLine($"Retrieved Bottom: {testFraction.GetBottom()}");
    }

    static void DisplayFractionInfo(Fraction f)
    {
        Console.WriteLine(f.GetFractionString());
        Console.WriteLine(f.GetDecimalValue());
    }
}