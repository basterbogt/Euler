using System;
using System.Linq;
using System.Numerics;

namespace Euler.Problems
{
    /// <summary>
    /// A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with denominators 2 to 10 are given:
    /// 
    ///         1/2	 = 	0.5
    ///         1/3	 = 	0.(3)
    ///         1/4	 = 	0.25
    ///         1/5	 = 	0.2
    ///         1/6	 = 	0.1(6)
    ///         1/7	 = 	0.(142857)
    ///         1/8	 = 	0.125
    ///         1/9	 = 	0.(1)
    ///         1/10 = 	0.1
    /// 
    /// Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle.It can be seen that 1/7 has a 6-digit recurring cycle.
    /// 
    /// Find the value of d< 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.
    /// </summary>
    public class Problem026 : Problem
    {
        public override void Calculate()
        {
            int result = 0;
            int resultIvalue = 0;
            for (int i = 1000; i > 1; i--)
            {
                int tempRes = GetRecurringCycleLength(i);
                if (tempRes > result)
                {
                    PrintOverwriteTemp(i + " - " + tempRes);
                    result = tempRes;
                    resultIvalue = i;
                }
                else
                {
                    PrintTemp(i + " - " + tempRes);
                }
            }
            Print(string.Format("Winner: {0} - {1}", resultIvalue, result));
        }

        private int GetRecurringCycleLength(int n)
        {
            // Quick check to see if the number is invalid. Helps for some numbers i guess...
            if (10000000.0d / n % 10 == 0) return 0;
            
            BigInteger big = new BigInteger(10); //initialise big integer
            big = BigInteger.Pow(big, 10000); //bigger is better

            string fractionString = (BigInteger.Divide(big, new BigInteger(n)).ToString());
            
            int lowestLength = fractionString.Length;
            for (int i = fractionString.Length; i > 0; i--)
            {
                if (GetCycle(fractionString, i))
                {
                    if (i < lowestLength)
                    {
                        lowestLength = i;
                    }
                }
            }
            if (lowestLength == fractionString.Length) return 0;
            return lowestLength;
        }

        private bool GetCycle(string input, int substringSize)
        {
            //String i'm comparing with
            string compareString = input.Substring(input.Length - substringSize, substringSize);
            
            //If the comparestring is the same number over and over and the string is longer than 1 character: false
            if (compareString.Distinct().Count() == 1 && compareString.Length > 1) return false;

            //Check if the string is actually a repeat of two times a smaller string:
            if (IsEven(compareString.Length))
            {
                if(compareString.Substring(0,compareString.Length/2) == compareString.Substring(compareString.Length / 2))
                {
                    return false;
                }
            }

            //Check if the comparestring is repeating itself in the end, and thus be there at least twice in the end of the input string
            if(substringSize * 2 < input.Length)
                if (compareString == input.Substring(input.Length - substringSize * 2, substringSize)) return true;
         
            //none of the above? false:!
            return false;
        }

        public static bool IsEven(int value)
        {
            return value % 2 == 0;
        }
    }
}
