using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AggregateFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] countries = { "India", "US", "UK", "Canada", "Australia" };

            // Without aggregate function
            string concatenatedCountries = ConcatenateArray(countries);
            Console.WriteLine("Concatenated countries: " + concatenatedCountries);

            // With aggregate function
            string concatenateWithAggregate = countries.Aggregate((a, b) => a + ", " + b);
            Console.WriteLine("Concatenated countries: " + concatenateWithAggregate);

            /////////////////////////////////////////////////////////////////////////////
            
            int[] numbers = { 2, 3, 4, 5 };

            // Without aggreagate function
            int? computedNumbers = Compute(numbers);
            Console.WriteLine("computed numbers: " + computedNumbers);

            // With aggregate function
            int computedNumbersWithAggregation = numbers.Aggregate(1, (acc, a) => acc * a);
            // or 
            // int computedNumbersWithAggregation = numbers.Aggregate((a, b) => a * b);

            Console.WriteLine("computed numbers with aggregator function: " + computedNumbersWithAggregation);

        }

        public static string ConcatenateArray(string[] array)
        {
            string result = "";
            foreach (var item in array)
            {
                if (result == "")
                {
                    result += item;
                }
                else
                {
                    result += ", " + item;
                }
            }
            return result;
        }

        public static int? Compute(int[] array)
        {
            int? result = null;
            foreach (int item in array)
            {
                if (!result.HasValue)
                {
                    result = item;
                }
                else
                {
                    result *= item;
                }
            }

            return result;
        }
    }
}
