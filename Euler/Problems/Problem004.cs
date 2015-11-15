using System;

namespace Euler.Problems
{
    /// <summary>
    ///  palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
    ///  Find the largest palindrome made from the product of two 3-digit numbers.
    /// </summary>
    public class Problem004 : Problem
    {
        public override void Calculate()
        {
            int result = 111;
            for(int x = 100; x <= 999; x++)
            {
                for(int y = 100; y <= 999; y++)
                {
                    int sum = x * y;
                    if (IsPalindromic(sum.ToString()))
                    {
                        result = Math.Max(sum, result);
                    }
                }
            }
            Print(result);
        }

        private bool IsPalindromic(string text)
        {
            char[] resultString = text.ToCharArray();
            int pos = 0;
            while (pos <= resultString.Length/2)
            {
                if (resultString[0 + pos] != resultString[resultString.Length - 1 - pos]) return false;
                pos++;
            }
            return true;
        }
    }
}
