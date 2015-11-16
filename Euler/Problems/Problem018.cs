using System;

namespace Euler.Problems
{
    /// <summary>
    /// By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.
    /// 
    ///            3
    ///           7 4
    ///          2 4 6
    ///         8 5 9 3
    /// 
    /// That is, 3 + 7 + 4 + 9 = 23.
    /// 
    /// Find the maximum total from top to bottom of the triangle below:
    /// 
    ///                 75
    ///                95 64
    ///               17 47 82
    ///              18 35 87 10
    ///             20 04 82 47 65
    ///            19 01 23 75 03 34
    ///           88 02 77 73 07 63 67
    ///          99 65 04 28 06 16 70 92
    ///         41 41 26 56 83 40 80 70 33
    ///        41 48 72 33 47 32 37 16 94 29
    ///       53 71 44 65 25 43 91 52 97 51 14
    ///      70 11 33 28 77 73 17 78 39 68 17 57
    ///     91 71 52 38 17 14 91 43 58 50 27 29 48
    ///    63 66 04 68 89 53 67 30 73 16 69 87 40 31
    ///   04 62 98 27 23 09 70 98 73 93 38 53 60 04 23
    /// 
    /// </summary>
    public class Problem018 : Problem
    {

        public override void Calculate()
        {
            CalculateWithThisArray(ReadTextFile());
        }

        public void CalculateWithThisArray(string[] text)
        {
            int[][] originalArray = new int[text.Length][]; //Array containing the input values
            int[][] saveValuesArray = new int[text.Length][]; //Array used to store the fastest route from that point

            for (int i = 0; i < text.Length; i++) //Loop through the textarray and fill our int arrays
            {
                string[] split = text[i].Split(' '); //Split on spaces
                int[] ints = new int[split.Length], intSave = new int[ints.Length]; //Create new arrays

                for (int j = 0; j < split.Length; j++) //Fill arrays
                {
                    ints[j] = Convert.ToInt32(split[j]); //Convert string to int
                    intSave[j] = -1;//init on -1
                }
                originalArray[i] = ints;
                saveValuesArray[i] = intSave;
            }

            Print(SumLongestPath(ref originalArray, ref saveValuesArray, 0, 0));
        }

        private int SumLongestPath(ref int[][] array, ref int[][] save, int x, int y)
        {
            if (y < 0 || y >= array.Length) return 0; //If out of bounce, return 0!
            if (x < 0 || x >= array[y].Length) return 0;//Dont think we need this check!

            if (save[y][x] >= 0) return save[y][x]; //If we already calculated this point, return that value:

            int result = Math.Max(SumLongestPath(ref array, ref save, x, y + 1), SumLongestPath(ref array, ref save, x + 1, y + 1)) + array[y][x]; //Calculate this point
            save[y][x] = result; //Save this calculated point in our 'save' array
            return result; //return result;
        }


    }
}
