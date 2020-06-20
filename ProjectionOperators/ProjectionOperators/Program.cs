using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProjectionOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            // Employee Id's
            IEnumerable<int> employeeIds = Employee.GetAllEmployees().Select(emp => emp.EmployeeID);
            foreach (var id in employeeIds)
            {
                Console.WriteLine(id);
            }

            // Firstname and gender
            var genderAndFirstName = Employee.GetAllEmployees().Select(emp => new { FirstName = emp.FirstName, Gender = emp.Gender });
            foreach(var person in genderAndFirstName)
            {
                Console.WriteLine("Name: " + person.FirstName + ", Gender: " + person.Gender);
            }

            // Salaries
            var monthlySalaries = Employee.GetAllEmployees()
                .Select(emp => new { FullName = emp.FirstName + " " + emp.LastName, MonthlySalary = emp.AnnualSalary / 12 });

            foreach (var data in monthlySalaries)
            {
                Console.WriteLine("Name: " + data.FullName + ", monthly salary: " + data.MonthlySalary);
            }

            // Bonus
            var entitledEmployees = Employee.GetAllEmployees()
                .Where(emp => emp.AnnualSalary > 50000)
                .Select(emp => new { emp.FirstName, emp.AnnualSalary, Bonus = emp.AnnualSalary * 0.1, });

            foreach (var data in entitledEmployees)
            {
                Console.WriteLine(data.FirstName + " : " + data.AnnualSalary + " - " + data.Bonus);
            }

        }
    }
}
