using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WritingLinqQueris
{
    class Program
    {
        static void Main(string[] args)
        {
            // With lambda
            IEnumerable<Student> maleStudents = Student.GetAllStudents().Where(student => student.Gender == "Male");
            foreach (var item in maleStudents)
            {
                Console.WriteLine(item.Gender);
            }

            // With Sequel like expression
            IEnumerable<Student> maleStudents2 = from student in Student.GetAllStudents()
                                                 where student.Gender == "Male"
                                                 select student;
            foreach (var item in maleStudents2)
            {
                Console.WriteLine(item.Gender);
            }

        }

        public static void collectionPrinter(IEnumerable collection)
        {
            foreach(var item in collection)
            {
                Console.WriteLine();
            }
        }
    }
}
