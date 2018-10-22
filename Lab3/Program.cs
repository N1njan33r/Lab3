using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
                //if (!string.Equals(Console.ReadLine(), "y", StringComparison.OrdinalIgnoreCase))
                //{
                //    break;
                //}
                //Figured out Console.ReadKey() but is there a better way???
                ConsoleKeyInfo repeat = Console.ReadKey();
                if (!repeat.KeyChar.Equals('y'))
                {
                    break;
                }
                Console.WriteLine();
            }
        }

        public static void IntegerGetter()
        {
            // James - although it seems like a small change, you could break this up into a it's own method like 
            // GetName() and it return a string!
            var name = "Default User";
            while (true)
            {
                Console.Write("Enter your name: ");
                name = Console.ReadLine();
                if (!Regex.IsMatch(name, @"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$"))
                {
                    Console.WriteLine("Name can only contain letters (A-Z).");
                    continue;
                }

                break;
            }
            while (true)
            {
                Console.Write($"Enter an integer (1-100), {name}: ");
                var userInput = Console.ReadLine();

                // James - This is a nice way to validate, I like that you are using continue to essentially 
                // restart the entire loop.  to keep the validation even more modular and tight, you could extract
                // validating the number into it's own method! that way you have less statement  nesting, like you 
                // you seperate the validation, then you do your control flow to figure out what kind of number.
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
                    // James - I like that you kept this as one giant if else if else, to make it 
                    // even more readable, consider using a switch statement.
                    Console.Write("Output: ");
                    if (value % 2 == 1)
                    {
                        Console.WriteLine(value + $" and Odd, {name}.");
                    }
                    // James - sweet use of Enumerable.Range()! smart, glad you are looking up
                    // different ways to solve problems here.
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
