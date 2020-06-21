using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] noNumbers = { };
            string[] words = { };
            
            // First number
            int firstElement = numbers.First();
            Console.WriteLine(firstElement);

            Console.WriteLine("----------------------");
            // First even number
            // It's important that if none of the elements satisfy the condition then it will throw an InvalidOperationException
            // It also throws this exception when the array is empty.
            int firstEven = numbers.First(num => num % 2 == 0);
            Console.WriteLine(firstEven);

            Console.WriteLine("----------------------");
            // There is FirstOfDefault method which doesn't throw an exception even if the array is empty.
            // If the array is empty or the condition doesn't satisfied it gives back a default element.
            // For int (because it's a value type) it gives back 0; because it's the default.
            int firstOrDefault = noNumbers.FirstOrDefault();
            string firstOrDefaultString = words.FirstOrDefault();
            Console.WriteLine(firstOrDefault);
            // String's default value is null
            Console.WriteLine(firstOrDefaultString == null);

            Console.WriteLine("----------------------");
            // ElementAt
            // If the IEnumerable is empty or there is less index than the argument that's passed then it's going to throw
            // ArgumentOutOfRangeException
            // There is ElementAtOrDefault which doesn't throw exception instead it gives back a default value of the type of the collection.
            int elementAt = numbers.ElementAt(1);
            Console.WriteLine(elementAt);


            Console.WriteLine("----------------------");
            // Single
            // It gives back an element if there is no other elements in the collection. If there are more elements than one
            // then it throws InvalidOperationException.
            int[] singleElementArray = { 1 };
            int singleElement = singleElementArray.Single();

            // If we pass a predicate then it gives back the only element that satisfies the condition. If there are more
            // elements that satisfy the condition then it throws an exception.
            int[] moreElementsArray = { 1, 10, 3, 5, 7};
            int onlyEvenElement = moreElementsArray.Single(num => num % 2 == 0);
            Console.WriteLine("The only even element from the array : " + onlyEvenElement);

            // There are SingleOrDefault variation of this but it's still throwing an exception if more than one element satisfy
            // the condition, or if we are using the overlodaded version of the method that doesn't require parameters then also
            // it's going to throw an exception if more elements are in the collection.
            int[] elements = { 1, 2, 3};
            var oneElement = elements.SingleOrDefault(num => num % 2 == 0);
            Console.WriteLine(oneElement);

            // DefaultIfEmpty
            IEnumerable<int> notEmpty = elements.DefaultIfEmpty();
            foreach(var num in notEmpty)
            {
                Console.WriteLine(num);
            }

            // We can specify the default value in the parameter.
            int[] emptyArray = { };
            IEnumerable<int> defaultIfEmpty = emptyArray.DefaultIfEmpty(100);
            foreach (var num in defaultIfEmpty)
            {
                Console.WriteLine("default if empty " + num);
            }






        }
    }
}
