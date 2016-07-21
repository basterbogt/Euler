using System;

namespace Euler.Problems
{
    /// <summary>
    /// Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:
    ///   
    ///                             21 22 23 24 25
    ///                             20  7  8  9 10
    ///                             19  6  1  2 11
    ///                             18  5  4  3 12
    ///                             17 16 15 14 13
    ///   
    ///   It can be verified that the sum of the numbers on the diagonals is 101.
    ///   
    ///   What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?
    ///   
    ///   
    /// </summary>
    public class Problem028 : Problem
    {
        private const int gridLength = 1001; //Must Be an odd number
        private const int GapIncrease = 4;
        public override void Calculate()
        {
            int currentNumber = 1;
            int gapBetweenNumbers = 2;
            int counterForGapIncrease = GapIncrease;
            int result = 0;
            while (currentNumber <= Math.Pow(gridLength, 2))
            {
                result += currentNumber;
                currentNumber += gapBetweenNumbers;

                counterForGapIncrease--;

                if (counterForGapIncrease <= 0)
                {
                    counterForGapIncrease = GapIncrease;
                    gapBetweenNumbers += 2;
                }
            }
            Print(result);
        }
    }
}
