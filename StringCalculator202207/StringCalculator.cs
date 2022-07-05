using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator202207
{
    public class StringCalculator
    {
        internal object Add(string numbers)
        {
            if (String.IsNullOrEmpty(numbers)) return 0;

            var delimiters = new List<char> { ',', '\n' };

            var useCutomSeparator = numbers.StartsWith("//");
            if (useCutomSeparator)
            {
                delimiters.Add(GetCustomCharacter(numbers));
                var onlyNumbers = numbers.Split('\n').Skip(1);
                numbers = string.Join("", onlyNumbers);
            }

            var elements = numbers.Split(delimiters.ToArray());

            var numberList = numbers.Split(delimiters.ToArray())
                .Select(s => int.Parse(s));

            var negatives = numberList.Where(n => n < 0);
            if (negatives.Any())
            {
                string negativeString = string.Join(',', negatives.Select(n => n.ToString()));
                throw new Exception($"Negatives not allowed: {negativeString}");
            }

            var result = numberList.Sum();

            

            return result;
        }

        private char GetCustomCharacter(string inputString)
        {
            var theNewCharacter = ';';

            var firstCharacterAfterRemovedCustomMarker = string.Join(' ',inputString.Split("//").TakeLast(1)).First();

            theNewCharacter = firstCharacterAfterRemovedCustomMarker;
            
            return theNewCharacter;
        }
    }
    
}
