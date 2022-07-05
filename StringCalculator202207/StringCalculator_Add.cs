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

    }
}
