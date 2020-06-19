using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace RestrictionOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Func<int, bool> filterEven = (a) => a % 2 == 0;

            // First option
            // IEnumerable<int> evenNumbers = numbers.Where(x => x % 2 == 0);

            // Second option
            //IEnumerable<int> evenNumbers = numbers.Where(filterEven);
            //foreach (int item in evenNumbers)
            //{
            //    Console.WriteLine(item);
            //}

            // Third option
            IEnumerable<int> evenNumbers = numbers.Where(num => isEven(num));


            // If we want to use sequel queries
            IEnumerable<int> evenNumbers2 = from num in numbers 
                                            where num % 2 == 0 select num;

            // If we need indexes
            IEnumerable<int> evensBiggerAfterFifthIndex = numbers.Where((num, index) => num % 2 == 0 && index > 5);

            IEnumerable<int> indexesOfTheEvens = numbers.Select((num, index) => new { Number = num, Index = index })
                .Where(obj => obj.Number % 2 == 0).Select(obj => obj.Index);

            foreach (int item in indexesOfTheEvens)
            {
                Console.WriteLine(item);
            }
        }

        public static bool isEven(int num)
        {
            return num % 2 == 0 ? true : false;
        }
    }
}
