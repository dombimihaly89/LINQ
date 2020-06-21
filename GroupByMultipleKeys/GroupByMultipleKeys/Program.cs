using System;
using System.Data;
using System.Linq;

namespace GroupByMultipleKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            var groupByDepartmentAndGender = Employee.GetAllEmployees()
                .GroupBy(emp => new { emp.Department, emp.Gender })
                .OrderBy(group => group.Key.Department).ThenBy(group => group.Key.Gender)
                .Select(group => new
                {
                    Key = new
                    {
                        Department = group.Key.Department,
                        Gender = group.Key.Gender,
                    },
                    Employees = group.OrderBy(emp => emp.Name)
                });

            foreach(var group in groupByDepartmentAndGender)
            {
                Console.WriteLine(group.Key.Department + " department. " + group.Key.Gender + " group. Count = " + group.Employees.Count());
                foreach(var employee in group.Employees)
                {
                    Console.WriteLine("\t" + employee.Name);
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            // The upper one with sequel like query.
            var groupByDepartmentAndGender2 = from employee in Employee.GetAllEmployees()
                                               group employee by new { employee.Department, employee.Gender } into deptGroup
                                               orderby deptGroup.Key.Department, deptGroup.Key.Gender
                                               select new
                                               {
                                                   Department = deptGroup.Key.Department,
                                                   Gender = deptGroup.Key.Gender,
                                                   Employees = deptGroup.OrderBy(emp => emp.Name)
                                               };

            foreach(var group in groupByDepartmentAndGender2)
            {
                Console.WriteLine("{0} department. {1} group. Count = {2}.", group.Department, group.Gender, group.Employees.Count());
                foreach(var emp in group.Employees)
                {
                    Console.WriteLine("\t" + emp.Name + "\t" + emp.Salary);
                }
            }
        }
    }
}
