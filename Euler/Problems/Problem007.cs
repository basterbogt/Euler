namespace Euler.Problems
{
    /// <summary>
    /// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
    /// What is the 10 001st prime number?
    /// </summary>
    public class Problem007 : Problem
    {
        public override void Calculate()
        {
            int target = 10001;
            int primesFound = 0;
            int counter = 2;
            int currentPrimeNumber = 0;
            while(primesFound < target)
            {
                if (IsPrime(counter))
                {
                    primesFound++;
                    currentPrimeNumber = counter;
                    PrintTemp(currentPrimeNumber);
                }
                counter++;
            }
        }
        
        private bool IsPrime(double prime)
        {
            for (double i = 2; i < prime; i++)
            {
                if ((prime / i) % 1 == 0)
                    return false;
            }
            return true;
        }
    }
}
