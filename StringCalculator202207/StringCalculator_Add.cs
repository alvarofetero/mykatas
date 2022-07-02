using System;
using Xunit;

namespace StringCalculator202207
{
    public class StringCalculator_Add
    {
        [Fact]
        public void Returns0GivenEmptyString()
        {
            var calculator = new StringCalculator();

            var result = calculator.Add("");

            Assert.Equal(0, result);
            
        }
    }
}
