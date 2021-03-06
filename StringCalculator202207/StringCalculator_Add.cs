using System;
using Xunit;

namespace StringCalculator202207
{
    public class StringCalculator_Add
    {
        private StringCalculator calculator = new StringCalculator();

        [Fact]
        public void Returns0GivenEmptyString()
        {
            var result = calculator.Add("");

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1",1)]
        [InlineData("2", 2)]
        public void ReturnsNumberGivenStringWithOneNumber(string numbers, int expectedResult)
        {
            var result = calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("2,3", 5)]
        public void ReturnsSumGivenStringWithTwoCommaSeparetedNumber(string numbers, int expectedResult)
        {
            var result = calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1,2,4", 7)]
        [InlineData("2,3,5", 10)]
        public void ReturnsSumGivenStringWithThreeCommaSeparetedNumber(string numbers, int expectedResult)
        {
            var result = calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1\n2,4", 7)]
        [InlineData("2\n3\n5", 10)]
        public void ReturnsSumGivenStringWithThreeCommaOrNewLineSeparetedNumber(string numbers, int expectedResult)
        {
            var result = calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("//;\n1;2;4", 7)]
        [InlineData("//:\n1:2:4", 7)]
        [InlineData("//_\n1_2_4", 7)]
        [InlineData("//_\n1_2,4", 7)]
        public void ReturnsSumGivenStringWithThreeCustomDelimiterSeparetedNumber(string numbers, int expectedResult)
        {
            var result = calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("-1,4", "Negatives not allowed: -1")]
        [InlineData("-1,-4", "Negatives not allowed: -1,-4")]
        public void ThrowsGivenNegativeInputs(string numbers, string expectedMessage)
        {
            Action action = () => calculator.Add(numbers);

            var ex = Assert.Throws<Exception>(action);

            Assert.Equal(expectedMessage, ex.Message);

        }


        [Theory]
        [InlineData("1,2,4,3000", 7)]
        [InlineData("1001,2", 2)]
        [InlineData("1000,2", 1002)]
        public void ReturnsSumGivenStringIgnoringValuesOver1000(string numbers, int expectedResult)
        {
            var result = calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

    }
}
