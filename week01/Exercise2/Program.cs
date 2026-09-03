using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter number: ");
        string valuefromUser = Console.ReadLine();
        int x = int.Parse(valuefromUser);
        int y = 2;

        if (x > y)

        {
            Console.WriteLine("Greater");
        }
        else if (x < y)
        {
            Console.WriteLine("Less");
        }
        else
        {
            Console.WriteLine("equal");
        }
    }
}