using System.Collections.Generic;
using System;

namespace GradeBook
{
    public class Book
    {
        /* Define an expicit constructor for this class the rules are
        1. Must have the same name as the class
        2. Cannot have a return type
        3. Any code it contains is executed before the variable is used i.e. it is initialised
        */
        public Book(string name)
        {
            grades = new List<double>();
            // use 'this' when referring to the object being operated on but only in a scenario when the incoming paramater has the same name as the class field
            // 'this' always assume you are accessing a member of the class rather than a passed in variable
            // otherwise the compiler was assuming we were doing name = name
            Name = name;
        }

        public void AddLetterGrade(char letter)
        {
            switch (letter)
            {
                // single quotes for char
                // double quotes for string
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                case 'F':
                    AddGrade(0);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }
        public void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
            }
            else
            {
                // Pass the the symbol (i.e. method name, a parm name, anything that exists in scope here) to nameof which returns the string
                // representation of that symbol
                throw new ArgumentException($"Invalid {nameof(grade)}");

            }

        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            for (var index = 0; index < grades.Count; index += 1)
            {
                result.High = Math.Max(grades[index], result.High);
                result.Low = Math.Min(grades[index], result.Low);
                result.Average += grades[index];
            }

            result.Average /= grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;

            }

            return result;
        }


        // Below has the default scope of private which means that grades is only usable within this class
        // Standard is to keep private at the bottom
        private List<double> grades;
        public string Name;
    }
}
