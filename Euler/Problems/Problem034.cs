namespace Euler.Problems
{
    /// <summary>
    /// 145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.
    /// Find the sum of all numbers which are equal to the sum of the factorial of their digits.
    /// Note: as 1! = 1 and 2! = 2 are not sums they are not included.
    /// </summary>
    public class Problem034 : Problem
    {
        public override void Calculate()
        {
            for (int i = 0; i < 10; i++)
            {
                Print(FactorialValue(i));
            }

            long answer = 0;
            long number = 3;
            while (true)
            {
                var charArray = number.ToString().ToCharArray();

                long totalValue = 0;
                foreach (var c in charArray)
                {
                    totalValue += FactorialValue(ToInt(c));
                }

                if (totalValue == number)
                {
                    answer += number;
                    Print(answer);
                }

                number++;
            }
        }


        private long FactorialValue(int number)
        {
            long answer = 1;
            for (int i = 1; i <= number; i++)
            {
                answer *= i;
            }
            return answer;
        }

        private int ToInt(char c)
        {
            return c - '0';
        }

    }
}
