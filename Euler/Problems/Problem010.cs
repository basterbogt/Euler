using System;

namespace Euler.Problems
{
    /// <summary>
    /// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
    /// Find the sum of all the primes below two million.
    /// </summary>
    public class Problem010 : Problem
    {
        public override void Calculate()
        {
            long sum = 0;
            int target = 2000000;
            for(int i = 2; i < target; i++)
            {
                if (IsPrimeImproved(i)) sum += i;
                PrintTemp(String.Format("{0:0000000} - {1}", i, sum));
            }
        }

        /// <summary>
        /// Method used to check wether or not a number is a Prime
        /// </summary>
        /// <param name="prime"></param>
        /// <returns>Returns true or false, wether the number is a Prime or not</returns>
        private bool IsPrime(double prime)
        {
            for (double i = 2; i < prime; i++)
            {
                if ((prime / i) % 1 == 0)
                    return false;
            }
            return true;
        }


        /// <summary>
        /// Some useful facts:
        ///     - 1 is not a prime.
        ///     - All primes except 2 are odd.
        ///     - All primes greater than 3 can be written in the form 6k+/-1.
        ///     - Any number n can have only one primefactor greater than Sqr(n).
        ///     - The consequence for primality testing of a number n is: if we cannot find a number f less than
        ///       or equal Sqr(n) that divides n then n is prime: the only primefactor of n is n itself
        /// </summary>
        /// <param name="n">Calculate if this number is a prime</param>
        /// <returns></returns>
        private bool IsPrimeImproved(double n)
        {
            if (n <= 1) return false;
            if (n < 4) return true;
            if (n % 2 == 0) return false;
            if (n < 9) return true;
            if (n % 3 == 0) return false;

            double r = Math.Floor(Math.Sqrt(n));
            int f = 5;
            while (f <= r)
            {
                if (n % f == 0) return false;
                if (n % (f + 2) == 0) return false;
                f += 6;
            }
            return true;
        }
    }
}
