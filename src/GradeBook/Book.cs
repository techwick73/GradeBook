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
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            var total = 0.0;

            foreach (double grade in grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);

                total += grade;
            }

            result.Average = total / grades.Count;

            return result;
        }


        // Below has the default scope of private which means that grades is only usable within this class
        // Standard is to keep private at the bottom
        private List<double> grades;
        public string Name;
    }
}
