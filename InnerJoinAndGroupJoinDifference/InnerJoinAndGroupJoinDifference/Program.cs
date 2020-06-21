using System;
using System.Linq;

namespace InnerJoinAndGroupJoinDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            // GroupJoin
            var result = from dept in Department.GetAllDepartments()
                         join emp in Employee.GetAllEmployees()
                         on dept.ID equals emp.DepartmentID into EmpGroup
                         select new
                         {
                             Department = dept,
                             Employees = EmpGroup
                         };
            foreach (var dept in result)
            {
                Console.WriteLine(dept.Department.Name + " department");
                foreach (var emp in dept.Employees)
                {
                    Console.WriteLine("\t" + emp.Name);
                }
            }

            Console.WriteLine("------------------------");
            // with extension method
            var resultExtension = Department.GetAllDepartments()
                .GroupJoin(Employee.GetAllEmployees(), dept => dept.ID, emp => emp.DepartmentID, (department, employees) =>
                new
                {
                    Department = department,
                    Employees = employees
                });

            foreach(var dept in resultExtension)
            {
                Console.WriteLine(dept.Department.Name + " department");
                foreach (var emp in dept.Employees)
                {
                    Console.WriteLine("\t" + emp.Name);
                }
            }

            Console.WriteLine("------------------------");
            // InnerJoin
            var result2 = from emp in Employee.GetAllEmployees()
                          join dept in Department.GetAllDepartments()
                          on emp.DepartmentID equals dept.ID
                          select new
                          {
                              Employee = emp,
                              Department = dept
                          };
            foreach(var emp in result2)
            {
                Console.WriteLine(emp.Employee.Name + "\t" + emp.Department.Name);
            }

            Console.WriteLine("------------------------");
            // InnerJoin with extension method
            var result2Extension = Employee.GetAllEmployees()
                .Join(Department.GetAllDepartments(), emp => emp.DepartmentID, dept => dept.ID, (employee, department) =>
                new
                {
                    Employee = employee,
                    Department = department
                });

            foreach(var emp in result2Extension)
            {
                Console.WriteLine(emp.Employee.Name + " is in the " + emp.Department.Name);
            }
        }
    }
}
