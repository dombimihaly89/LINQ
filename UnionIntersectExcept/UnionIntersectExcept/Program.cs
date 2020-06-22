using System;
using System.Collections.Generic;
using System.Linq;

namespace UnionIntersectExcept
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers1 = { 1, 2, 3, 4, 5 };
            int[] numbers2 = { 1, 3, 6, 7, 8 };

            // Union combinbes 2 collection into 1 collection while removes duplicate elements.
            // If we use complex data types then we have to do the same as we did when we used complex data types
            // in ourn Distinct method examples.
            var result = numbers1.Union(numbers2);
            foreach(int num in result)
            {
                Console.WriteLine(num);
            }

            // with complex data types
            List<Employee> list1 = new List<Employee>()
            {
                new Employee { ID = 101, Name = "Mike"},
                new Employee { ID = 102, Name = "Susy"},
                new Employee { ID = 103, Name = "Mary"}
            };

            List<Employee> list2 = new List<Employee>()
            {
                new Employee { ID = 101, Name = "Mike"},
                new Employee { ID = 104, Name = "John"}
            };

            var unionOfEmployees = list1.Select(emp => new { emp.ID, emp.Name }).Union(list2.Select(emp => new { emp.ID, emp.Name}));

            foreach (var obj in unionOfEmployees)
            {
                Console.WriteLine(obj.ID + "\t" + obj.Name);
            }

            // Intersect returns the collection of the elements that are common in the collections.
            // Except return the collection of the elements that are present in the first collection but not in the second collection.
        }
    }
}
