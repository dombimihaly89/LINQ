using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupBy
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<IGrouping<string, Employee>> employeesByGroup = Employee.GetAllEmployees().GroupBy(employee => employee.Department);

            foreach(IGrouping<string, Employee> group in employeesByGroup)
            {
                Console.WriteLine(group.Key + " department:");
                foreach(Employee emp in group)
                {
                    Console.WriteLine("\t" + emp.Name + "\t" + emp.Department);
                }
            }

            Console.WriteLine("----------------");
            // The GroupBy with sequel like syntax. Also people sorted by their names'
            IEnumerable<IGrouping<string, Employee>> employeesByGroup2 = from employee in Employee.GetAllEmployees()
                                                                        group employee by employee.Department;
            foreach (IGrouping<string, Employee> group in employeesByGroup2)
            {
                Console.WriteLine(group.Key + " department:");
                foreach (Employee emp in group.OrderBy(emp => emp.Name))
                {
                    Console.WriteLine("\t" + emp.Name + "\t" + emp.Department);
                }
            }

            Console.WriteLine("----------------");
            // Find the employee with the highest salary in a department
            foreach (IGrouping<string, Employee> group in employeesByGroup2)
            {
                Console.WriteLine(group.Key + " departments highest salary: " + group.Max(emp => emp.Salary));
            }

            Console.WriteLine("----------------");
            // Sorting employees and department ascending order before foreach
            var sortedDepartments = from employee in Employee.GetAllEmployees()
                                    group employee by employee.Department into employeeGroup
                                    orderby employeeGroup.Key
                                    select new
                                    {
                                        Key = employeeGroup.Key,
                                        Employees = employeeGroup.OrderBy(emp => emp.Name)
                                    };
            foreach (var group in sortedDepartments)
            {
                Console.WriteLine(group.Key + " department: " + group.Employees.Count() + " people");
                foreach (var employee in group.Employees)
                {
                    Console.WriteLine("\t" + employee.Name + "\t" + employee.Salary);
                }
            }
        }
    }
}
