using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                IntegerGetter();
                Console.Write("Restart? (y/n): ");
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
