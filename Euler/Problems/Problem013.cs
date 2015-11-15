namespace Euler.Problems
{
    /// <summary>
    /// Work out the first ten digits of the sum of the following one-hundred 50-digit numbers.
    /// 
    ///     file:GitHub/Euler/Euler/Files/Problem013.txt
    /// 
    /// </summary>
    public class Problem013 : Problem
    {
        private string[] input;
        private int numberCount;
        private int numberLength;

        public Problem013()
        {
            input = ReadTextFile();
            numberCount = input.Length;
            if(numberCount > 0)
                numberLength = input[0].Length;
        }

        public override void Calculate()
        {
            int firstXnumbers = 10;
            int pointer = numberLength - 1; //variable keeping track of what index number we are checking
            int overflow = 0; //All the values ten and higher, which should be taken into account in the next cycle...

            string resultString = string.Empty; //init string

            while(pointer >= 0) { 
                int sum = overflow;
                for(int i = 0; i < numberCount; i++)
                {
                    sum += ToInt(input[i][pointer]);
                }
                resultString = (sum % 10).ToString() + resultString;
                overflow = sum / 10;
                pointer--;
            }
            resultString = overflow.ToString() + resultString;

            int result = 0; //Count first x numbers of the resultString
            for(int b = 0; b < firstXnumbers; b++)
            {
                result += ToInt(resultString[b]);
                Print(resultString[b], false);
            }
            Print(result);
        }

        public int ToInt(char c)
        {
            return (c - '0');
        }

    }
}
