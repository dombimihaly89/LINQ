using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OrderingOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Student names before sorting:");
            List<Student> students = Student.GetAllStudents();

            foreach (Student student in students)
            {
                Console.WriteLine(student.Name);
            }

            Console.WriteLine("-------------");
            // Sort students by ascending order
            IOrderedEnumerable<Student> studentsOrderedByName = students.OrderBy(student => student.Name);
            foreach (Student student in studentsOrderedByName)
            {
                Console.WriteLine(student.Name);
            }

            Console.WriteLine("-------------");
            // Sort students by ascending order with sequel like syntax
            IOrderedEnumerable<Student> studentsOrderedByName2 = from student in students
                                                                 orderby student.Name ascending
                                                                 select student;
            foreach (Student student in studentsOrderedByName2)
            {
                Console.WriteLine(student.Name);
            }

            Console.WriteLine("-------------");
            // Sort students by descending order
            IOrderedEnumerable<Student> studentsOrderedByNameDesc = students.OrderByDescending(student => student.Name);
            foreach (Student student in studentsOrderedByNameDesc)
            {
                Console.WriteLine(student.Name);
            }

            Console.WriteLine("-------------");
            // Sort students by descending order with sequel like syntax
            IOrderedEnumerable<Student> studentsOrderedByNameDesc2 = from student in students
                                                                     orderby student.Name descending
                                                                     select student;
            foreach (Student student in studentsOrderedByNameDesc2)
            {
                Console.WriteLine(student.Name);
            }
        }
    }
}
