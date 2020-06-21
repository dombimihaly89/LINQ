using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OuterJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = from emp in Employee.GetAllEmployees()
                         join dept in Department.GetAllDepartments()
                         on emp.DepartmentID equals dept.ID into employeeGroup
                         from d in employeeGroup.DefaultIfEmpty()
                         select new
                         {
                             Employee = emp.Name,
                             Department = d == null ? "No Department" : d.Name,
                         };
            
            foreach (var emp in result)
            {
                Console.WriteLine(emp.Employee + "\t" + emp.Department);
            }


            Console.WriteLine("-----------------");
            // Rewrite with extension methods
            var result2 = Employee.GetAllEmployees()
                .GroupJoin(Department.GetAllDepartments(), e => e.DepartmentID, d => d.ID, (emp, dept) => new
                {
                    EmployerName = emp.Name,
                    DepartmentName = dept.FirstOrDefault() == null ? "No Department" : dept.First().Name
                });

            foreach(var emp in result2)
            {
                Console.WriteLine(emp.EmployerName + "\t" + emp.DepartmentName);
            }

            Console.WriteLine("-----------------");
            // The authors solution using extension methods.
            var result3 = Employee.GetAllEmployees()
                .GroupJoin(Department.GetAllDepartments(), e => e.DepartmentID, d => d.ID, (emp, dept) => new
                {
                    emp,
                    dept
                })
                .SelectMany(anonym => anonym.dept.DefaultIfEmpty(), (anonym, dept) => new
                {
                    EmployeeName = anonym.emp.Name,
                    DepartmentName = dept == null ? "No Department" : dept.Name
                });

            foreach(var emp in result3)
            {
                Console.WriteLine(emp.EmployeeName + "\t" + emp.DepartmentName);
            }
        }
    }
}
