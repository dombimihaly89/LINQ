using System;
using System.Linq;

namespace GroupJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeesByDepartment = Department.GetAllDepartments()
                .GroupJoin(Employee.GetAllEmployees(), (dept) => dept.ID, (emp) => emp.DepartmentID, (department, employees) =>
                new
                {
                    Department = department,
                    Employees = employees
                });

            foreach (var dept in employeesByDepartment)
            {
                Console.WriteLine(dept.Department.Name + " department");
                foreach(Employee emp in dept.Employees)
                {
                    Console.WriteLine("\t" + emp.Name);

                }
            }

            Console.WriteLine("-----------------------");
            // With sequel like syntax and also added ordering to it.
            var employeesByDepartment2 = from department in Department.GetAllDepartments()
                                         orderby department.Name
                                         join employee in Employee.GetAllEmployees()
                                         on department.ID equals employee.DepartmentID into deptGroup
                                         select new
                                         {
                                             Department = department,
                                             Employees = deptGroup.OrderBy(emp => emp.Name)
                                         };
            foreach (var dept in employeesByDepartment2)
            {
                Console.WriteLine(dept.Department.Name + " department");
                foreach (Employee emp in dept.Employees)
                {
                    Console.WriteLine("\t" + emp.Name);

                }
            }
        }
    }
}
