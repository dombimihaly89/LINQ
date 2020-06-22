using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CrossJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = from emp in Employee.GetAllEmployees()
                         from dept in Department.GetAllDepartments()
                         select new
                         {
                             emp,
                             dept
                         };
            foreach (var obj in result)
            {
                Console.WriteLine(obj.emp.Name + "\t" + obj.dept.Name);
            }

            Console.WriteLine("---------------");
            // with select many extension method
            var result2 = Employee.GetAllEmployees().SelectMany(emp => Department.GetAllDepartments(), (emp, dept) => new
            {
                Employee = emp,
                Department = dept
            });

            foreach(var employee in result2)
            {
                Console.WriteLine(employee.Employee.Name + "\t" + employee.Department.Name);
            }

            Console.WriteLine("---------------");
            // with join extension method
            var result3 = Employee.GetAllEmployees().Join(Department.GetAllDepartments(), e => true, d => true, (e, d) => new
            {
                e,
                d,
            });

            foreach(var obj in result3)
            {
                Console.WriteLine(obj.e.Name + "\t" + obj.d.Name);
            }
        }
    }
}
