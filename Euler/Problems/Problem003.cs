namespace Euler.Problems
{
    /// <summary>
    /// The prime factors of 13195 are 5, 7, 13 and 29.
    /// What is the largest prime factor of the number 600851475143 ?
    /// </summary>
    public class Problem003 : Problem
    {
        private int PrimeCounter = 0;   //Counter, used to count the amount of primes we calculated
        private int CurrentPrime = 1;   //variable, used to store the current prime
        private int CurrentNumber = 2;  //variable, used to store the number we last checked wether or not it was a prime. 
                                        //Basically used to keep track of where we left off when calculting a new Prime.

        public override void Calculate()
        {
            long number = 600851475143; //Input number
            int primeIndex = 0; //local counter
            while(number > 1) //while we haven't reached 1 yet
            {
                if(primeIndex >= PrimeCounter) //Check if we have to calculate a new prime...
                {
                    FindNextPrime();
                }
                if((number / ((double)CurrentPrime)) % 1 == 0) //Check if current prime is a legit prime factor of our input number
                {
                    PrintTemp(CurrentPrime); //print...
                    number /= CurrentPrime; //update input-number
                }
                else
                {
                    primeIndex++; //if not, lets check the next prime...
                }
            }
        }

        /// <summary>
        /// Method used to find the next Prime number
        /// </summary>
        private void FindNextPrime()
        {
            while (true)//We keep going until we find a new prime!
            {
                if (IsPrime(CurrentNumber)) //Is this number a prime?
                {
                    CurrentPrime = CurrentNumber;
                    PrimeCounter++;
                    CurrentNumber++;
                    break;
                }
                CurrentNumber++;
            }
        }

        /// <summary>
        /// Method used to check wether or not a number is a Prime
        /// </summary>
        /// <param name="prime"></param>
        /// <returns>Returns true or false, wether the number is a Prime or not</returns>
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

