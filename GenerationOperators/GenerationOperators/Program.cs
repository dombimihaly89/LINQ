using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace GenerationOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            // Range generates an IEnumerable<int> with intergers in it from 1 to 10.
            IEnumerable<int> result = Enumerable.Range(1, 10);
            IEnumerable<int> evenNumbers = Enumerable.Range(1, 10).Where(num => num % 2 == 0);
            foreach(int num in evenNumbers)
            {
                Console.WriteLine(num);
            }

            // Repeat operator
            IEnumerable<string> words = Enumerable.Repeat("Hello", 5);
            foreach(string word in words)
            {
                Console.WriteLine(word);
            }

            // Empty method is useful if we are getting data from a 3rd party service and their return value can be null.
            // So we are checking whether if their returning value is null, and if it is then we instead giving an
            // Enumberable.Empty<int>();
            IEnumerable<int> data = getData() ?? Enumerable.Empty<int>();
            foreach(var item in data)
            {
                Console.WriteLine(item);
            }

            int[] numbers1 = { 1, 2, 3 };
            int[] numbers2 = { 1, 4, 5 };

            // The concat method is different than the union method because when we use Union method then
            // duplicate elements appear once in the result.
            IEnumerable<int> concatenatedNumbers = numbers1.Concat(numbers2);
            foreach(int num in concatenatedNumbers)
            {
                Console.WriteLine(num);
            }

        }

        public static IEnumerable<int> getData()
        {
            return null;
        }
    }
}
