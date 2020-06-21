using System;
using System.Linq;

namespace InnerJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Employee.GetAllEmployees().Join(Department.GetAllDepartments(), emp => emp.DepartmentID, dept => dept.ID,
                (employee, department) => new
                {
                    EmployeeName = employee.Name,
                    DepartmentName = department.Name
                });

            foreach (var person in result)
            {
                Console.WriteLine(person.EmployeeName + " belongs to " + person.DepartmentName + " department");
            }

            Console.WriteLine("----------------------");
            // Now with sequel like syntax

            var result2 = from emp in Employee.GetAllEmployees()
                          join dept in Department.GetAllDepartments()
                          on emp.DepartmentID equals dept.ID
                          select new
                          {
                              EmployeeName = emp.Name,
                              DepartmentName = dept.Name
                          };

            foreach (var person in result2)
            {
                Console.WriteLine(person.EmployeeName + " belongs to " + person.DepartmentName + " department");
            }

        }
    }
}
