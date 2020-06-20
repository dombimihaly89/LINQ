using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderingOperatorsII
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Student> studentList = Student.GetAllStudents();

            // Sort students by totalmarks then by name then by id descending.
            IOrderedEnumerable<Student> sortedStudents = studentList.OrderBy(student => student.TotalMarks)
                .ThenBy(student => student.Name)
                .ThenByDescending(student => student.StudentID);
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student.TotalMarks + " " + student.Name + " " + student.StudentID);
            }

            Console.WriteLine("---------------");
            // Sort students by totalmarks then by name then by id descending with sequel like syntax
            IOrderedEnumerable<Student> sortedStudents2 = from student in studentList
                                                          orderby student.TotalMarks
                                                          orderby student.TotalMarks, student.Name ascending, student.StudentID descending
                                                          select student;
            foreach (var student in sortedStudents2)
            {
                Console.WriteLine(student.TotalMarks + " " + student.Name + " " + student.StudentID);
            }

            Console.WriteLine("---------------");
            // Reverse
            Console.WriteLine("Before using reverse method");
            foreach (var student in studentList)
            {
                Console.WriteLine(student.StudentID + "\t" + student.Name + "\t" + student.TotalMarks);
            }
            Console.WriteLine("After using reverse method");
            IEnumerable<Student> reversedStudentList = studentList.Reverse();
            foreach (var student in reversedStudentList)
            {
                Console.WriteLine(student.StudentID + "\t" + student.Name + "\t" + student.TotalMarks);
            }
        }
    }
}
