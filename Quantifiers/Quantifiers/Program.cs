using System;
using System.Collections.Generic;
using System.Linq;

namespace Quantifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            // All method
            bool isAllLessThanTen = numbers.All(num => num < 10);
            Console.WriteLine("All elements are less than 10? " + (isAllLessThanTen ? "Yes" : "No"));

            Console.WriteLine("---------------");
            // Any
            // If we use the overloaded method without parameters then it checks whether the sequence contains at least
            // one element. And there is an overloaded version of the method with a predicate and returns true if
            // there is at last one element that satisfies the condition.
            bool isThereNegative = numbers.Any(num => num < 0);
            Console.WriteLine("Are there any negative numbers in the array? " + (isThereNegative ? "Yes" : "No"));

            Console.WriteLine("---------------");
            // Contains
            bool isThereFour = numbers.Contains(4);
            Console.WriteLine("Is there a 4 in the array? " + (isThereFour ? "Yes" : "No"));

            Console.WriteLine("---------------");
            // Theres is also a version the expects a second parameter which has to an IEqualityComparer
            // And also we can override the classes' Equals and GetHashCode methods or we can project to anonymous type
            // with select many operator.
            string[] countries = { "INDIA", "USA", "UK" };
            bool containsIndia = countries.Contains("india", StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("Does this contain india? " + (containsIndia ? "Yes" : "No"));

            // Example to a complex type
            Employee emp1 = new Employee() { ID = 1, Name = "Dina" };
            Employee emp2 = new Employee() { ID = 2, Name = "Maki" };
            List<Employee> list = new List<Employee>() { emp1, emp2 };

            bool containsEmployee = list.Contains(new Employee { ID = 1, Name = "Dina" });
            Console.WriteLine("First: " + containsEmployee);
            bool containsEmployee2 = list.Contains(new Employee { ID = 1, Name = "Dina" }, new EmployeeComparer());
            Console.WriteLine("Second: " + containsEmployee2);
        }
    }
}
