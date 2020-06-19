using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionMethodsInCSharp
{
    public static class StringHelper
    {
        public static string ChangeFirstLetterCase(this string inputString)
        {
            char[] chars = inputString.ToCharArray();

            if (inputString[0] == char.ToLower(inputString[0]))
            {
                return Char.ToUpper(inputString[0]) + inputString.Substring(1, inputString.Length - 1);
            }
            return Char.ToLower(inputString[0]) + inputString.Substring(1, inputString.Length - 1);
        }
    }
}
