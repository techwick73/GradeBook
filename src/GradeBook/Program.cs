using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            var book = new Book("Scott's Grade Book");

            // loop which keeps prompting for input until it gets a q for quit

            // keep looping forever until a break is encountered
            while (true)
            {
                System.Console.WriteLine("Please enter a grade or 'q' to quit: ");
                var input = Console.ReadLine();
                // Console.Reeadline returns a string so we need to test for "q" teh string rather than 'q' the char
                if (input == "q")
                {
                    break;
                }

                try
                {
                    // Convert input into a number
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                // Stack your catches in with the most likely to occur first
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                // the final block will always execute
                // useful for things you always have to do e.g. close a file or network socket
                finally
                {
                    System.Console.WriteLine("***********");
                }
            }

            var stats = book.GetStatistics();

            Console.WriteLine($"Lowest is {stats.Low}, Highest is {stats.High} and Average is {stats.Average}");
            System.Console.WriteLine($"The letter grade is {stats.Letter}");
        }
    }
}
