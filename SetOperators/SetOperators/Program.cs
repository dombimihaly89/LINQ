using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SetOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] countries = { "USA", "usa", "INDIA", "UK", "UK" };

            // with default comparer
            var result = countries.Distinct();

            foreach(var country in result)
            {
                Console.WriteLine(country);
            }

            Console.WriteLine("-------------");
            // with an other comparer. It has to extend IEqualityComparer
            var result2 = countries.Distinct(StringComparer.OrdinalIgnoreCase);

            // Distinct on objects
            List<Employee> list = new List<Employee>()
            {
                new Employee() { ID = 101, Name = "Mike"},
                new Employee() { ID = 101, Name = "Mike"},
                new Employee() { ID = 102, Name = "Mary"}
            };

            // this aren't going to distinct the first 2 objects of course, because we didn't make a comparer 
            // if there is no overriden equals and gethashcode in the class then we can pass IEqualityComparer.
            var distinctEmployees = list.Distinct(/*IEqualityComparer instance*/);
            foreach(Employee emp in distinctEmployees)
            {
                Console.WriteLine(emp.ID + "\t" + emp.Name);
            }
            Console.WriteLine(list[0].Equals(list[1]));

            Console.WriteLine("--------------------");
            // third way is to project the employee object's properties into an anonymous object
            // this works because anonymous types are automatically override the equals and the gethashcode methods.
            var distinctEmployees2 = list.Select(emp => new { emp.ID, emp.Name }).Distinct();
            foreach(var obj in distinctEmployees2)
            {
                Console.WriteLine(obj.ID + "\t" + obj.Name);
            }
        }
    }
}
