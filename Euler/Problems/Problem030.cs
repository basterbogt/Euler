using System;

namespace Euler.Problems
{
    /// <summary>
    /// 
    ///     Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:
    ///     
    ///     1634 = 1^4 + 6^4 + 3^4 + 4^4
    ///     8208 = 8^4 + 2^4 + 0^4 + 8^4
    ///     9474 = 9^4 + 4^4 + 7^4 + 4^4
    ///     As 1 = 14 is not a sum it is not included.
    ///     
    ///     The sum of these numbers is 1634 + 8208 + 9474 = 19316.
    ///     
    ///     Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.
    /// 
    /// </summary>
    public class Problem030 : Problem
    {
        private const int power = 5;

        public override void Calculate()
        {
            int result = 0;
            int counter = 2; //We dont use 0 or 1, so we start from 2
            while (true)
            {
                PrintTemp(string.Format("Current total: {0} Currently calculating: {1}", result, counter));
                if (IsSumOfPower(counter)) {
                    result += counter;
                    PrintOverwriteTemp(string.Format("Result = {0}                                         ", counter));
                }
                counter++;
            }
        }
        
        private bool IsSumOfPower(int number)
        {
            char[] array = number.ToString().ToCharArray();
            int result = 0;
            foreach (char c in array)
            {
                result += (int)Math.Pow(ToInt(c), power);
            }
            return (result == number);
        }

        public int ToInt(char c)
        {
            return (int)(c - '0');
        }
    }
}
