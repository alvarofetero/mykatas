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
                var theNewCharacter = ';';
                delimiters.Add(theNewCharacter);
                var onlyNumbers=numbers.Split('\n').Skip(1);
                numbers = string.Join("",onlyNumbers);
            }

            var elements = numbers.Split(delimiters.ToArray());

            var result = numbers.Split(delimiters.ToArray())
                .Select(s => int.Parse(s)).Sum();

            return result;
        }
    }
}
