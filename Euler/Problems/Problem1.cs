using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public class Problem1: Problem
    {
        public override void Calculate()
        {
            int sum = 0;

            for(int i = 0; i < 1000; i++)
            {
                if( i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            Print(sum);
        }
    }
}
