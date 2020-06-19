using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ExtensionMethodsInCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string valami = StringHelper.ChangeFirstLetterCase("macska");
            Console.WriteLine(valami);

            List<int> Numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> EvenNumbers = Numbers.Where(n => n % 2 == 0);
            IEnumerable<int> EvenNumbers2 = Enumerable.Where(Numbers, n => n % 2 == 0);

            Console.WriteLine("enumberale with extension method: ");
            foreach (var item in EvenNumbers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------");
            Console.WriteLine("enumberale2 with extension method: ");
            foreach (var item in EvenNumbers2)
            {
                Console.WriteLine(item);
            }

        }
    }
}
