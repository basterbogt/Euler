using System;
using System.Collections.Generic;

namespace Euler.Problems
{
    /// <summary>
    /// A permutation is an ordered arrangement of objects. For example, 3124 is one possible 
    /// permutation of the digits 1, 2, 3 and 4. If all of the permutations are listed numerically 
    /// or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:
    /// 
    ///     012   021   102   120   201   210
    /// 
    /// What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
    /// </summary>
    public class Problem024 : Problem
    {
        public override void Calculate()
        {
            List<int> numbers = new List<int>();
            numbers.AddRange(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }); //input, range of numbers

            List<long> results = new List<long>();
            CalculateNewNumber(numbers, results, string.Empty); //Create all the numbers
            results.Sort();//Sort the numbers

            Print(results[1000000-1]);//1.000.000th number has the index of 999.999 ^^
        }

        /// <summary>
        /// Recursive function that calculates the different combination of numbers
        /// </summary>
        private void CalculateNewNumber(List<int> numbers, List<long> results, string number)
        {
            if (numbers.Count <= 0) { 
                results.Add(Convert.ToInt64(number));
                return;
            }

            for(int i = 0; i <= 10; i++) { 
                if (numbers.Contains(i))
                    CalculateNewNumber(RemoveOne(numbers, i), results, number + i);
            }
        }

        private List<int> RemoveOne(List<int> numbers, int index) 
        {
            List<int> result = new List<int>();//Also makes sure we have a deep copy
            foreach (int i in numbers)
            {
                if (i != index) result.Add(i);
            }
            return result;
        }
    }
}
