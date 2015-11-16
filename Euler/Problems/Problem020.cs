using System.Numerics;

namespace Euler.Problems
{
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
