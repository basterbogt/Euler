using System;

namespace Euler.Problems
{
    /// <summary>
    ///  Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
    ///     a^2 + b^2 = c^2
    /// For example, 32 + 42 = 9 + 16 = 25 = 52.
    /// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    /// Find the product abc.
    /// </summary>
    public class Problem009 : Problem
    {
        public override void Calculate()
        {
            int target = 1000;

            double a = 0, b = 0, c = 0;

            bool running = true;
            while (running)
            {
                a++;
                b = 0;
                while(b < a && running)
                {
                    b++;
                    c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
                    if (a + b + c == target) running = false;
                }
            }
            Print(a * b * c);
        }
    }
}
