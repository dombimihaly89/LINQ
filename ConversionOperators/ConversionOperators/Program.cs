using System;
using System.Collections.Generic;
using System.Linq;

namespace ConversionOperators
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public int TotalMarks { get; set; }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string City { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // ToList operator
            int[] numbers = { 1, 2, 3, 4, 5 };
            List<int> result = numbers.ToList();

            foreach(int i in result)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("------------");
            // ToArray operator
            List<string> countries = new List<string> { "US", "India", "UK", "Australia", "Canada" };
            string[] countryArray = countries.OrderBy(str => str).ToArray();
            foreach (string country in countryArray)
            {
                Console.WriteLine(country);
            }

            Console.WriteLine("------------");
            // ToDictionary operator
            List<Student> listStudents = new List<Student>
            {
                new Student { StudentID= 101, Name = "Tom", TotalMarks = 800 },
                new Student { StudentID= 102, Name = "Mary", TotalMarks = 900 },
                new Student { StudentID= 103, Name = "Pam", TotalMarks = 800 }
            };

            Dictionary<int, string> studentNamesById = listStudents.ToDictionary(student => student.StudentID, student => student.Name);

            foreach(KeyValuePair<int, string> keyValuePair in studentNamesById)
            {
                Console.WriteLine(keyValuePair.Key + "\t" + keyValuePair.Value);
            }

            Console.WriteLine("------------");
            // ToDictionary operator but now id is the key and the student object is the value
            // If we use this method with one parameter then it's enough to pass the key, the value is going to
            // be the object that the list's consist of.
            Dictionary<int, Student> studentsById = listStudents.ToDictionary(student => student.StudentID);
            foreach(KeyValuePair<int, Student> kpv in studentsById)
            {
                Console.WriteLine(kpv.Key + "\t" + kpv.Value.Name + "\t" + kpv.Value.TotalMarks);
            }

            // ToLookUp operator. A LookUp is almost like the dictionary but the keys can be identical.
            List<Employee> listEmployees = new List<Employee>
            {
                new Employee() { Name = "Ben", JobTitle = "Developer", City = "London" },
                new Employee() { Name = "John", JobTitle = "Sr. Developer", City = "Bangalore" },


                new Employee() { Name = "Steve", JobTitle = "Developer", City = "Bangalore" },
                new Employee() { Name = "Stuart", JobTitle = "Sr. Developer", City = "London" },
                new Employee() { Name = "Sara", JobTitle = "Developer", City = "London" },
                new Employee() { Name = "Pam", JobTitle = "Developer", City = "London" }
            };

            ILookup<string, Employee> employeesByJobTitle = listEmployees.ToLookup(emp => emp.JobTitle);

            Console.WriteLine("Employees Grouped by Job Title");
            foreach (var kvp in employeesByJobTitle)
            {
                Console.WriteLine(kvp.Key);
                foreach (var employee in employeesByJobTitle[kvp.Key])
                {
                    Console.WriteLine("\t" + employee.Name + "\t" + employee.City);
                }
            }

        }
    }
}
