namespace Euler.Problems
{
    /// <summary>
    /// Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
    ///         If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.
    /// 
    ///         For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.
    /// 
    /// Evaluate the sum of all the amicable numbers under 10000.
    /// </summary>
    public class Problem021 : Problem
    {
        public override void Calculate()
        {
            int target = 10000;

            long[] solved = InitArray(1000000); //value big enough to store all possible numbers

            int sum = 0; //variable to save our sum
            
            for (int i = 1; i < target; i++)//Loop through all available numbers
            {
                long a = (solved[i] < 0) ? solved[i] = d(i) : solved[i]; //Find d(n) value of i
                if (a <= 0) continue; //If 0 of smaller, ignore this one...
                long b = (solved[solved[i]] < 0) ? solved[solved[i]] = d(solved[i]) : solved[solved[i]];//Find d(n) value a, name it b
                if (solved[b] == a && solved[a] == b && a != b && b == i) sum += i; //If b is equal to i, d(a) = b, d(b) = a and a != b..., then add to sum
            }
            Print(sum);
        }

        /// <summary>
        /// Calculate the sum of proper divisors
        /// </summary>
        /// <param name="n">Number</param>
        /// <returns>Sum of proper divisors</returns>
        private long d(double n)
        {
            long sum = 0;
            for(int i = 1; i < n; i++)
            {
                if (n % i == 0) sum += i; //if its a proper divisor, add to the sum
            }
            return sum;
        }


        private long[] InitArray(int size)
        {
            long[] array = new long[size];
            for(int i = 0; i < size; i++)
            {
                array[i] = -1;
            }
            return array;
        }
    }
}
