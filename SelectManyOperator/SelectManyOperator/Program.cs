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

            // The same with sequel like syntax
            IEnumerable<string> listOfAllDisctinctSubject2 = from student in Student.GetAllStudents()
                                                             from subject in student.Subjects
                                                             select subject;

            Console.WriteLine("------------");
            // Disctinct with sequel like syntay:
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


            Console.WriteLine("------------");
            // Tested SelectMany if the subject is empty then what happens. So it's not going to write out the corresponding
            // student if it's empty. If we use DefaultIfEmpty on the subject list, then it is going to attach the student
            // and after that the student get printed out. It's logical because SelectMany first flattens
            // the Subjects and when it's flattened then it starts to get back the corresponding student, but
            // if there is no subject (because the subject list was empty) then there is no correspondig student as well.
            // That's why student doesn't get printed out without using DefaultIfEmpty. If we use DefaultIfEmpty then
            // the empty subject list gets a null value, and now this null is corresponds to the Student
            // that's why it gets printed out. If you want to test this, you have to make a student's subject list empty.
            var test = Student.GetAllStudents().SelectMany(s => s.Subjects.DefaultIfEmpty(), (stud, sub) => new {
                Stud = stud.Name,
                Sub = sub
            });
            foreach(var subject in test)
            {
                Console.WriteLine(subject.Stud + "\t" + subject.Sub);
            }
        }
    }
}
