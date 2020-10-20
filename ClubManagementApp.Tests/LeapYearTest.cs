using Xunit;

namespace ClubManagementApp.Tests
{
    public class LeapYearTest
    {
        private static int[] leapYears = new[] { 2000, 2008, 2012, 2016 };
        private static int[] notLeapYears = new[] { 0, 1700, 1800, 1900, 2100, 2017, 2018, 2019 };

        private FizzBuzz _fizzBuzzBuilder;

        public LeapYearTest()
        {
            _fizzBuzzBuilder = new FizzBuzz();
        }

        [Fact]
        public void ShouldPass()
        {
            foreach (var yearToTest in leapYears)
            {
                bool isLeapYear = IsLeapYear(yearToTest);

                Assert.True(isLeapYear);
            }
        }

        [Fact]
        public void ShouldFail()
        {
            foreach (var yearToTest in notLeapYears)
            {
                bool isLeapYear = IsLeapYear(yearToTest);

                Assert.False(isLeapYear);
            }
        }

        private bool IsLeapYear(int yearToTest)
        {
            if (yearToTest == default) return false;

            var divisibleBy400 = yearToTest % 400 == 0;
            var divisibleBy100 = yearToTest % 100 == 0;
            var divisibleBy4 = yearToTest % 4 == 0;

            if (divisibleBy400) return true;
            if (!divisibleBy4) return false;
            if (divisibleBy100 && !divisibleBy400) return false;
            if (divisibleBy4 && !divisibleBy100) return true;
            return true;
        }

        [Fact]
        public void ShouldFizzBuzzReturn1IfNumberIs1()
        {
            var resultString = _fizzBuzzBuilder.Build(1, 1);
            Assert.Equal("1", resultString);
        }

        [Fact]
        public void ShouldFizzBuzzReturn2IfNumberIs2()
        {
            var resultString = _fizzBuzzBuilder.Build(2, 2);
            Assert.Equal("2", resultString);
        }

        [Fact]
        public void ShouldFizzBuzzReturnFizzIfNumberIs3()
        {
            var resultString = _fizzBuzzBuilder.Build(3, 3);
            Assert.Equal("Fizz", resultString);
        }

        [Fact]
        public void ShouldFizzBuzzReturnFizzIfNumberIs6()
        {
            var resultString = _fizzBuzzBuilder.Build(6, 6);
            Assert.Equal("Fizz", resultString);
        }

        [Fact]
        public void ShouldFizzBuzzReturnFizzIfNumberIs5()
        {
            var resultString = _fizzBuzzBuilder.Build(5, 5);
            Assert.Equal("Buzz", resultString);
        }

        [Fact]
        public void ShouldFizzBuzzReturnFizzIfNumberIs10()
        {
            var resultString = _fizzBuzzBuilder.Build(10, 10);
            Assert.Equal("Buzz", resultString);
        }

        [Fact]
        public void ShouldFizzBuzzReturnFizzIfNumberIs15()
        {
            var resultString = _fizzBuzzBuilder.Build(15, 15);
            Assert.Equal("FizzBuzz", resultString);
        }

        [Fact]
        public void ShouldFizzBuzzReturnFizzIfNumberIs30()
        {
            var resultString = _fizzBuzzBuilder.Build(30, 30);
            Assert.Equal("FizzBuzz", resultString);
        }

        [Fact]
        public void ShouldFizzBuzzReturn12IfNumbersAre1To2()
        {
            var resultString = _fizzBuzzBuilder.Build(1,2);
            Assert.Equal("12", resultString);
        }

        [Fact]
        public void ShouldFizzBuzzReturn12FizzIfNumbersAre1To3()
        {
            var resultString = _fizzBuzzBuilder.Build(1, 3);
            Assert.Equal("12Fizz", resultString);
        }

        [Fact]
        public void ShouldFizzBuzzReturn12Fizz4BuzzIfNumbersAre1To15()
        {
            var resultString = _fizzBuzzBuilder.Build(1, 15);
            Assert.Equal("12Fizz4BuzzFizz78FizzBuzz11Fizz1314FizzBuzz", resultString);
        }

        [Fact]
        public void ShouldFizzBuzzReturn12FizzIfNumbersAre1To5()
        {
            var resultString = _fizzBuzzBuilder.Build(1, 5);
            Assert.Equal("12Fizz4Buzz", resultString);
        }
    }
}
