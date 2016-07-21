using System;

namespace Euler.Problems
{
    /// <summary>
    /// Euler discovered the remarkable quadratic formula:
    /// 
    /// n² + n + 41
    /// 
    /// It turns out that the formula will produce 40 primes for the consecutive values n = 0 to 39. 
    /// However, when n = 40, 402 + 40 + 41 = 40(40 + 1) + 41 is divisible by 41, and certainly when n = 41, 41² + 41 + 41 is clearly divisible by 41.
    /// 
    /// The incredible formula n² − 79n + 1601 was discovered, which produces 80 primes for the consecutive values n = 0 to 79. The product of the coefficients, −79 and 1601, is −126479.
    /// 
    /// Considering quadratics of the form:
    /// 
    /// n² + an + b, where |a| < 1000 and |b| < 1000
    /// 
    /// where |n| is the modulus/absolute value of n
    /// e.g. |11| = 11 and |−4| = 4
    /// Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n = 0.
    /// </summary>
    public class Problem027 : Problem
    {
        public override void Calculate()
        {
            int highestSequence = 0;
            int highestSequenceAValue = 0;
            int highestSequenceBValue = 0;
            for (int a = -1000; a < 1000; a++)
            {
                for(int b = -1000; b < 1000; b++)
                {
                    int result = GetConsecutiveValues(a, b);
                    if(result > highestSequence)
                    {
                        highestSequence = result;
                        highestSequenceAValue = a;
                        highestSequenceBValue = b;
                        PrintTemp(string.Format("Sequence = {0}, A = {1}, B = {2}", highestSequence, highestSequenceAValue, highestSequenceBValue));
                    }
                }
            }
            PrintOverwriteTemp(string.Format("Result >> Sequence = {0}, A = {1}, B = {2} -- Answer = {3}", highestSequence, highestSequenceAValue, highestSequenceBValue, highestSequenceAValue*highestSequenceBValue));
        }
        
        private int GetConsecutiveValues(int a, int b)
        {
            int n = 0;
            while(true)
            {
                bool result = IsPrime(Math.Pow(n, 2) + a*n + b);
                if (!result) return n;
                n++;
            }
        }

        /// <summary>
        /// 
        /// ---Used in problem 10----
        /// 
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
        private bool IsPrime(double n)
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
