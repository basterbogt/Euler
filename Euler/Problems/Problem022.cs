using System;

namespace Euler.Problems
{
    /// <summary>
    /// Using Problem022.txt, a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. 
    /// Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.
    /// 
    ///     For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list.
    ///     So, COLIN would obtain a score of 938 × 53 = 49714.
    /// 
    /// What is the total of all the name scores in the file?
    /// </summary>
    public class Problem022 : Problem
    {
        private string[] array;

        public Problem022()
        {
            array = ReadTextFile(); //read the file
        }

        public override void Calculate()
        {
            string[] names = array[0].Replace("\"", "").Split(','); //Get all the names, in a list
            Array.Sort(names); //sort all the names in alphabetical order

            long sum = 0;
            for(int i = 1; i <= names.Length; i++) //Loop through all the names
            {
                int indexSum = 0;
                char[] ca = names[i-1].ToCharArray(); //removing one to get the index value
                foreach(char c in ca)
                {
                    indexSum += GetIndexNumber(c);
                }
                sum += indexSum * i; //Count total index number and multiply it by the name's position in the list
            }
            Print(sum);
        }

        private int GetIndexNumber(char c)
        {
            return c % 32;
        }
    }
}
