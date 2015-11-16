using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    /// <summary>
    /// If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
    /// 
    /// If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?
    /// 
    ///     NOTE: Do not count spaces or hyphens.For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen)
    ///     contains 20 letters.The use of "and" when writing out numbers is in compliance with British usage.
    /// </summary>
    public class Problem017 : Problem
    {
        private string[] ones;
        private string[] teens;
        private string[] tens;
        private string[] thousandsGroups;

        public Problem017()
        {
            ones = new string[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            teens = new string[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            tens = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            thousandsGroups = new string[] { "", " Thousand", " Million", " Billion" };
        }


        public override void Calculate()
        {
            long sum = 0;
            for(int i = 1; i <= 1000; i++)
            {
                sum += WrittenNumberToInt(i);
            }
            Print(sum);
        }

        private long WrittenNumberToInt(long n)
        {
            string number = GetWrittenNumber(n);
            number = number.Replace(" ", ""); //remove spaces
            return number.Length;
        }

        public string GetWrittenNumber(long n)
        {
            if (n == 0)
            {
                return "Zero";
            }
            else if (n < 0)
            {
                return "Negative " + GetWrittenNumber(-n);
            }

            return GetWrittenNumber(n, "", 0);
        }

        private string GetWrittenNumber(long n, string leftDigits, int thousands)
        {
            if (n == 0)
            {
                return leftDigits;
            }
            string result = leftDigits;
            if (result.Length > 0)
            {
                result += " ";
            }

            if (n < 10)
            {
                result += ones[n];
            }
            else if (n < 20)
            {
                result += teens[n - 10];
            }
            else if (n < 100)
            {
                result += GetWrittenNumber(n % 10, tens[n / 10 - 2], 0);
            }
            else if (n < 1000)
            {
                string text =  (n % 100 == 0)? "Hundred " : " Hundred And ";
                result += GetWrittenNumber(n % 100, (ones[n / 100] + text), 0);
            }
            else
            {
                result += GetWrittenNumber(n % 1000, GetWrittenNumber(n / 1000, "", thousands + 1), 0);
            }

            return result + thousandsGroups[thousands];
        }
    }
    
}
