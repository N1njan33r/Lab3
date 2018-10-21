using System;
using System.Linq;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            // James - ah, I see you are breaking the app into  a couple methods here! good use of keeping your main method very lean,
            // to go even further I would instead put this in maybe a try catch block with a general exception to start off and have a totally seperate 
            // method for your entire app, like AppStart or something. 
            while (true)
            {
                IntegerGetter();
                Console.Write("Restart? (y/n): ");
                // James - good condition on restarting the code!
                if (!string.Equals(Console.ReadLine(), "y", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            }
        }

        public static void IntegerGetter()
        {
            Console.Write("Enter your name: ");
            var name = Console.ReadLine();
            while (true)
            {
                Console.Write($"Enter an integer (1-100), {name}: ");
                var userInput = Console.ReadLine();
                if (!int.TryParse(userInput, out int value))
                {
                    Console.WriteLine($"Input cannot be parsed as an integer, {name}.");
                    continue;
                }
                else if (!Enumerable.Range(1, 100).Contains(value))
                {
                    Console.WriteLine($"Input must be between 1 and 100, {name}.");
                    continue;
                }
                else
                {
                    Console.Write("Output: ");
                    if (value % 2 == 1)
                    {
                        Console.WriteLine(value + $" and Odd, {name}.");
                    }
                    else if (value % 2 == 0 && Enumerable.Range(2, 25).Contains(value))
                    {
                        Console.WriteLine($"Even and less than 25, {name}.");
                    }
                    else if (value % 2 == 0 && Enumerable.Range(26, 60).Contains(value))
                    {
                        Console.WriteLine($"Even, {name}.");
                    }
                    else if (value % 2 == 0 && value > 60)
                    {
                        Console.WriteLine(value + $" and Even, {name}.");
                    }
                    else if (value % 2 == 1 && value > 60)
                    {
                        Console.WriteLine(value + $" and Odd, {name}.");
                    }
                    break;
                }
            }
        }
    }
}
