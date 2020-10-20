using System;

namespace ClubManagementApp.Tests
{
    internal class FizzBuzz
    {
        public FizzBuzz()
        {
        }

        internal string Build(int minNumber, int maxNumber)
        {
            string stringToReturn = string.Empty;
            for (int i = minNumber; i <= maxNumber; i++)
            {
               stringToReturn += EvaluateNumber(i);
            }
            return stringToReturn;
        }

        private static string EvaluateNumber(int minNumber)
        {
            if (minNumber % 15 == 0)
                return "FizzBuzz";
            else if (minNumber % 3 == 0)
                return "Fizz";
            else if (minNumber % 5 == 0)
                return "Buzz";
            return minNumber.ToString();
        }
    }
}