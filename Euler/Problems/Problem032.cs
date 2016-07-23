using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Problems
{
    /// <summary>
    /// 
    ///     We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; for example, the 5-digit number, 15234, is 1 through 5 pandigital.
    ///
    ///     The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.
    ///
    ///     Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.
    ///
    ///     HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.
    /// 
    /// </summary>
    public class Problem032 : Problem
    {
        public override void Calculate()
        {
            int min = 1;
            int max = 9;

            string fullCharacterString = GetCharacterString(min, max);

            //Find every different way to arrange this string.
            string[] allNumberPermutations = FindPermutations(fullCharacterString);

            //For each different way to arrange it, make 3 unique groups. example: 123456789 could become 1 - 2 - 3456789 and 12 - 3 - 456789
            // GetAllUniquePandigitals
            List<int> resultList = GetAllUniquePandigitals(allNumberPermutations);
            
            ////Count all the answers
            Print("");
            Print(string.Format("Answer: {0}",CountValues(resultList)));
        }
        
        private string GetCharacterString(int min, int max)
        {
            char start = min.ToString().ToCharArray()[0];
            char end = max.ToString().ToCharArray()[0];

            string result = string.Empty;
            for(char a = start; a != (end + 1); a++)
            {
                result += a.ToString();
            }
            return result;
        }

        private string[] FindPermutations(string word)
        {
            if (word.Length == 2)
            {
                char[] _c = word.ToCharArray();
                string s = new string(new char[] { _c[1], _c[0] });
                return new string[] {  word, s };
            }

            List<string> result = new List<string>();
            string[] subsetPermutations = FindPermutations(word.Substring(1));
            char firstChar = word[0];
            foreach (string s in subsetPermutations)
            {
                string temp = firstChar.ToString() + s;
                result.Add(temp);
                char[] chars = temp.ToCharArray();
                for (int i = 0; i < temp.Length - 1; i++)
                {
                    char t = chars[i];
                    chars[i] = chars[i + 1];
                    chars[i + 1] = t;
                    result.Add(new string(chars));
                }
            }
            return result.ToArray();
        }
        private List<int> GetAllUniquePandigitals(string[] allNumberPermutations)
        {
            //List<Group> result = new List<Group>();
            List<int> result = new List<int>();

            int countDown = allNumberPermutations.Length;
            foreach (string s in allNumberPermutations)
            {
                for (int i = 1; i <= s.Length-1; i++)
                {
                    string a = s.Substring(0, i);
                    string temp = s.Substring(i);
                    for (int j = 1; j <= temp.Length-1; j++)
                    {
                        string b = temp.Substring(0, j );
                        string c = temp.Substring(j);
                        if (IsPandigital(Convert.ToInt32(a), Convert.ToInt32(b), Convert.ToInt32(c)))
                        {
                            result.Add(Convert.ToInt32(c));
                        }
                    }
                }
                PrintTemp(string.Format("CountDown: {0}     ", --countDown));
            }
            
            return result.Distinct().ToList();
        }
        private object CountValues(List<int> resultList)
        {
            int result = 0;
            foreach (int value in resultList)
            {
                result += value;
            }
            return result;
        }

        public bool IsPandigital(int a, int b, int c)
        {
            return (a * b == c);
        }
    }
    
}
