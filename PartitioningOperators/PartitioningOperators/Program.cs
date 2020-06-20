using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PartitioningOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] countries = { "Australia", "Canada", "Germany", "US", "India", "UK", "Italy" };

            // First 3 countries
            IEnumerable<string> threeCountries = countries.Take(3);
            foreach(string country in threeCountries)
            {
                Console.WriteLine(country);
            }

            Console.WriteLine("-------------");
            // First 3 countries with sequel like syntax
            IEnumerable<string> threeCountries2 = (from country in countries
                                                   select country).Take(3);
            foreach (string country in threeCountries2)
            {
                Console.WriteLine(country);
            }

            Console.WriteLine("-------------");
            // Skip the first three countries
            IEnumerable<string> skipFirstThreeCountries = countries.Skip(3);
            foreach (string country in skipFirstThreeCountries)
            {
                Console.WriteLine(country);
            }

            Console.WriteLine("-------------");
            // Skip the first three countries with sequel like syntax
            IEnumerable<string> skipFirstThreeCountries2 = (from country in countries
                                                            select country).Skip(3);
            foreach (string country in skipFirstThreeCountries2)
            {
                Console.WriteLine(country);
            }

            Console.WriteLine("-------------");
            // Return countries until the countries doesnt hit a country with less than 3 characters
            IEnumerable<string> takeWhileTwoCharacters = countries.TakeWhile(country => country.Length > 2);
            foreach (string country in takeWhileTwoCharacters)
            {
                Console.WriteLine(country);
            }

            Console.WriteLine("-------------");
            // Return countries after the iteration hit a country with less than 3 characters
            IEnumerable<string> skipUntilTwoCharacters = countries.SkipWhile(country => country.Length > 2);
            foreach (string country in skipUntilTwoCharacters)
            {
                Console.WriteLine(country);
            }
        }
    }
}
