using System;
using System.Collections.Generic;
using System.Linq;

namespace PagingWithTakeAndSkip
{
    class Program
    {

        public const int MaxStudentsOnPage = 3;
        public static string globalMessage;
        static void Main(string[] args)
        {
            IEnumerable<Student> listOfStudents = Student.GetAllStudetns();
            int maximumPage = listOfStudents.Count() / MaxStudentsOnPage + 1;
            globalMessage = "Enter a number between 1 and " + maximumPage + " or type exit to quit";
            Console.WriteLine(globalMessage);
            var pressedKey = Console.ReadLine();
            var page = -1;
            while (isRenderable(ref pressedKey))
            {
                int.TryParse(pressedKey, out page);
                if (maximumPage >= page && page > 0)
                {
                    IEnumerable<Student> studentsOnSamePage = listOfStudents.Skip((page - 1) * MaxStudentsOnPage).Take(MaxStudentsOnPage);
                    Console.WriteLine("Students on page " + page);
                    foreach (Student student in studentsOnSamePage)
                    {
                        Console.WriteLine(student.StudentID + "\t" + student.Name + "\t" + student.TotalMarks);
                    }
                }

                Console.WriteLine(globalMessage);
                pressedKey = Console.ReadLine();
            }
        }

        public static bool isRenderable(ref string pressedKey)
        {
            int page;
            bool renderable = int.TryParse(pressedKey, out page);
            while (!int.TryParse(pressedKey, out page))
            {
                if (pressedKey == "exit") return false;
                Console.WriteLine(globalMessage);
                pressedKey = Console.ReadLine();
            }
            return true;
        }
    }
}
