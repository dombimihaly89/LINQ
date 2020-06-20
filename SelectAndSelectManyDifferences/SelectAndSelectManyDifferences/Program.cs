using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SelectAndSelectManyDifferences
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<List<string>> result = Student.GetAllStudents().Select(student => student.Subjects);
            foreach(List<string> subjects in result)
            {
                foreach(string subject in subjects)
                {
                    Console.WriteLine(subject);
                }
            }

            IEnumerable<string> result2 = Student.GetAllStudents().SelectMany(student => student.Subjects);
            foreach (string subject in result2)
            {
                Console.WriteLine(subject);
            }
        }
    }
}
