namespace Euler.Problems
{
    /// <summary>
    /// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    /// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    /// </summary>
    public class Problem5 : Problem
    {
        public override void Calculate()
        {
            Start();
            int number = 1;
            int range = 20;
            while (!Legit(number, range))
            {
                number++;
                PrintTemp(number);
            }
            Stop();
        }


        private bool Legit(int number, int range)
        {
            //if (!IsEven(number)) return false;
            for(int i = range; i > 1; i--)
            {
                if (number % i != 0) return false;
            }
            return true;
        }

        private bool IsEven(int n)
        {
            return (n % 2 == 0);
        }
    }
}
