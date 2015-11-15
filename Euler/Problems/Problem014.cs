using System;

namespace Euler.Problems
{
    /// <summary>
    /// The following iterative sequence is defined for the set of positive integers:
    ///     n → n/2 (n is even)
    ///     n → 3n + 1 (n is odd)
    /// 
    /// Using the rule above and starting with 13, we generate the following sequence:
    ///     13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
    /// 
    /// It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.
    /// 
    /// Which starting number, under one million, produces the longest chain?
    /// 
    /// NOTE: Once the chain starts the terms are allowed to go above one million.
    /// </summary>
    public class Problem014 : Problem
    {
        public override void Calculate()
        {
            int startingLimit = 1000000;
            int longestChain = 0;
            for(int i = 1; i < startingLimit; i++)
            {
                long n = i;
                int chainLength = 1;
                while(n > 1)
                {
                    n = (IsEven(n)) ? n / 2 : 3 * n + 1;
                    chainLength++;
                }
                if(chainLength > longestChain)
                {
                    longestChain = chainLength;
                    PrintTemp(String.Format("{0:000000} - {1}", i, longestChain));
                }
            }
        }

        private bool IsEven(long n)
        {
            return (n % 2 == 0);
        }
    }
}
