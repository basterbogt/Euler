using System;
using System.Collections.Generic;

namespace Euler.Problems
{
    /// <summary>
    /// A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. 
    /// For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.
    /// 
    /// A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.
    /// 
    /// As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. 
    /// By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. However, 
    /// this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that cannot be expressed as the 
    /// sum of two abundant numbers is less than this limit.
    /// 
    /// Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
    /// </summary>
    public class Problem023 : Problem
    {
        public override void Calculate()
        {
            int ceil = 28123;
            List<int> abundant = new List<int>();
            for(int i = 0; i < ceil; i++)
            {
                if (IsAbundant(i)) abundant.Add(i);
            }

            long sum = 0;
            for(int i = 0; i < ceil; i++)
            {
                if (!IsComputableWithTwoAbundants(i, abundant)) sum += i;
                PrintTemp(String.Format("Numbers left: {0:00000} - Current Sum: {1}", ceil-i, sum));
            }
            Print(sum);
        }


        private bool IsAbundant(int n)
        {
            return (SumProperDivisors(n) > n);
        }

        private long SumProperDivisors(int n)
        {
            long sum = 0;
            for (int i = 1; i < n; i++)
            {
                if (n % i == 0) sum += i; //if its a proper divisor, add to the sum
            }
            return sum;
        }

        private bool IsComputableWithTwoAbundants(int n, List<int> abundant)
        {
            foreach(int i in abundant)
            {
                if (abundant.Contains(n - i)) return true;
            }
            return false;
        }

    }
}
