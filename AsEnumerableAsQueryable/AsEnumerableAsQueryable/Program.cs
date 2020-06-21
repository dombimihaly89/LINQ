using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsEnumerableAsQueryable
{
    class Program
    {
        static void Main(string[] args)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            // It executes queries in the database until AsEnumerable so it doesn't
            // execute the operations after the AsEnumerable() on the server side.
            // It executes the operations after that in memory. We could put
            // AsEnumerable in somewhere later position. It's a breakpoint basically.
            // So AsEnumberable operator moves query processing to the client side.
            var result = db.Employees.AsEnumerable().Where(employee => employee.Gender == "Male")
                .OrderByDescending(employee => employee.Salary)
                .Take(5);

            foreach(var emp in result)
            {
                Console.WriteLine(emp.Name + "\t" + emp.Salary + "\t" + emp.Gender);
            }
            Console.ReadLine();
        }
    }
}
