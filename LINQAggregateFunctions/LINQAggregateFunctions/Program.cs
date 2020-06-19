using System;
using System.Linq;

namespace LINQAggregateFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            //Smallest number
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int min = numbers.Min();
            Console.WriteLine("Min: " + min);

            //Smallest even number
            int smallestEven = numbers.Where(num => num % 2 == 0).Min();
            Console.WriteLine("Smallest even: " + smallestEven);

            //Largest number
            int largestNumber = numbers.Max();

            //Largest even number
            int largestEven = numbers.Where(num => num % 2 == 0).Max();

            //Sum
            int sum = numbers.Sum();

            //Count
            int count = numbers.Count();

            double average = numbers.Average();
            Console.WriteLine("Average: " + average);

            string[] countries = { "India", "USA", "UK" };
            int shortestLength = countries.Min(c => c.Length);
            Console.WriteLine("shortest length: " + shortestLength);

            int longestLength = countries.Max(c => c.Length);
            Console.WriteLine("longest length: " + longestLength);

        }
    }
}
