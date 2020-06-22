using System;
using System.Collections.Generic;
using System.Linq;

namespace SequenceEqualOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sequence Equal operator returns true if two sequences elements are equivalent.
            // So the sequences have to be the same length, the elements have to be in the same order
            // and it matters if they are hase the letters with the same case. (a - A different).
            List<string> words = new List<string> { "dog", "cat", "zebra" };
            List<string> words2 = new List<string> { "dog", "cat", "zebra" };

            bool isSame = words.SequenceEqual(words2);
            Console.WriteLine(isSame);
            // if the elements are object types then we have 3 ways to make them equal just like I did with Distinct method.
        }
    }
}
