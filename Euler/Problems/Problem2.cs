﻿namespace Euler.Problems
{
    /// <summary>
    /// Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:
    /// 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
    /// By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
    /// </summary>
    public class Problem2 : Problem
    {
        public override void Calculate()
        {
            int sum = 0;
            int a = 1;
            int b = 1;
            int c = a + b;
            while( c < 4000000) {
                if (c % 2 == 0) sum += c;
                a = b;
                b = c;
                c = a + b;
            }
            Print(sum);
        }
    }
}
