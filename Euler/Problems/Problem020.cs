using System.Numerics;

namespace Euler.Problems
{
    /// <summary>
    /// n! means n × (n − 1) × ... × 3 × 2 × 1
    /// For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
    /// and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
    /// 
    /// Find the sum of the digits in the number 100!
    /// </summary>
    public class Problem020 : Problem
    {
        public override void Calculate()
        {
            Print(SumOfDigits(Factorial(100)));
        }

        private int SumOfDigits(BigInteger n)
        {
            char[] ca = n.ToString().ToCharArray();
            int result = 0;
            foreach(char c in ca)
            {
                result += ToInt(c);
            }
            return result;
        }

        private BigInteger Factorial(BigInteger n)
        {
            BigInteger result = 1;
            while(n > 0)
            {
                result *= n;
                n--;
            }
            return result;
        }

        public int ToInt(char c)
        {
            return (c - '0');
        }
    }
}
