using System;
using System.Collections.Generic;
using System.Linq;

namespace SelectManyOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> listOfAllSubject = Student.GetAllStudents().SelectMany(student => student.Subjects);
            foreach (string subject in listOfAllSubject)
            {
                Console.WriteLine(subject);
            }
            Console.WriteLine("------------");
            Console.WriteLine("Distinct: ");

            // If you don't want to duplicate the subjects then there is distinct
            IEnumerable<string> listOfAllDistinctSubjects = Student.GetAllStudents()
                .SelectMany(student => student.Subjects)
                .Distinct();
            foreach (string subject in listOfAllDistinctSubjects)
            {
                Console.WriteLine(subject);
            }

            // Disctinct with sequel like syntay:
            IEnumerable<string> listOfAllDisctinctSubject2 = from student in Student.GetAllStudents()
                                                             from subject in student.Subjects
                                                             select subject;

            Console.WriteLine("------------");
            // The same with sequel like syntax
            IEnumerable<string> listOfAllSubject2 = (from student in Student.GetAllStudents()
                                                    from subject in student.Subjects
                                                    select subject).Distinct();
            foreach (string subject in listOfAllSubject2)
            {
                Console.WriteLine(subject);
            }

            Console.WriteLine("------------");
            // Print all the Student name's and also the subjects
            var studentsSubjects = Student.GetAllStudents()
                .SelectMany(student => student.Subjects, (student, subject) =>
                new { student.Name, Subject = subject });

            foreach (var student in studentsSubjects)
            {
                Console.WriteLine(student.Name + " has the " + student.Subject + " subject.");
            }

            Console.WriteLine("------------");
            // Code down the above one with sequel like syntax
            var studentsSubjects2 = from student in Student.GetAllStudents()
                                  from subject in student.Subjects
                                  select new { student.Name, Subject = subject };

            foreach (var student in studentsSubjects2)
            {
                Console.WriteLine(student.Name + " has the " + student.Subject + " subject.");
            }

            string[] stringArray =
            {
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
            "0123456789"
            };

            // Prining out all the characters
            IEnumerable<char> allCharacters = stringArray
                .SelectMany(str => str);

            foreach (char ch in allCharacters)
            {
                Console.WriteLine(ch);
            }

            Console.WriteLine("------------");

            // Coding down the one above using sequel like syntax
            IEnumerable<char> allCharacters2 = from str in stringArray
                                               from ch in str
                                               select ch;

            foreach (char ch in allCharacters2)
            {
                Console.WriteLine(ch);
            }
        }
    }
}
