using System.Numerics;

namespace Euler.Problems
{
    /// <summary>
    /// 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
    /// What is the sum of the digits of the number 21000?
    /// </summary>
    public class Problem016 : Problem
    {
        public override void Calculate()
        {
            int power = 1000;
            BigInteger n = 1;
            for(int i = 0; i < power; i++)
            {
                n *= 2;
                PrintTemp(n);
            }
            char[] ca = n.ToString().ToCharArray();
            int sum = 0;
            foreach(char c in ca)
            {
                sum += ToInt(c);
            }
            Print(sum);
        }
        public int ToInt(char c)
        {
            return (c - '0');
        }
    }
}
