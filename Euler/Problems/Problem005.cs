using System;

namespace Euler.Problems
{
    /// <summary>
    /// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    /// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    /// </summary>
    public class Problem005 : Problem
    {
        public override void Calculate()
        {
            int range = 20;
            long result = 1;//starting at 1, since we are multiplying the result 
            int i = 0;//counter
            int[] p = GetFirstXPrimes(range);//primes -> Not the most efficient way, because we are calculating too many primes right now
            int[] a = new int[p.Length]; //for each p, we need an a
            bool check = true;
            double limit = Math.Sqrt(range);
            while (p[i] <= range)
            {
                a[i] = 1;
                if (check)
                {
                    if(p[i] <= limit)
                    {
                        a[i] = (int)Math.Floor(Math.Log(range) / Math.Log(p[i]));
                    }
                    else
                    {
                        check = false;
                    }
                }
                result = (long)(result * Math.Pow(p[i] , a[i]));
                i++;
            }
            Print(result);
        }
        
        /// <summary>
        /// returns a list with the first x primes
        /// </summary>
        /// <param name="x">The amount of primes you want</param>
        /// <returns>Returns a lsit with the first x primes</returns>
        private int[] GetFirstXPrimes(int x)
        {
            if (x <= 0) return null;//yeah, that would be weird, getting the first 0 (or less) primes..
            int[] array = new int[x];

            int primeCounter = 0;
            for(int i = 0; primeCounter < x; i++)
            {
                if (IsPrime(i))
                {
                    array[primeCounter] = i;
                    primeCounter++;
                }
            }
            return array;
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
