using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CastAndOfTypeOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList() { 1, 2, 3 };
            // Cast uses deferred execution
            IEnumerable<int> result = list.Cast<int>();

            foreach(int item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----------");
            // OfType. It gets all the int type variable from the list. If an element is not an int then it ignores it.
            ArrayList list2 = new ArrayList() { 1, 2, 3, "4", "asd"};
            IEnumerable<int> intList = list2.OfType<int>();
            foreach(int item in intList)
            {
                Console.WriteLine(item);
            }

        }
    }
}
