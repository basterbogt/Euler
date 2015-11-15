namespace Euler.Problems
{
    /// <summary>
    /// Starting in the top left corner of a 2×2 grid, and only being able to move 
    /// to the right and down, there are exactly 6 routes to the bottom right corner.
    /// 
    ///     https://projecteuler.net/project/images/p015.gif
    /// 
    ///     How many such routes are there through a 20×20 grid?
    /// </summary>
    public class Problem015 : Problem
    {
        public override void Calculate()
        {
            int n = 20;//Grid Size

            n++;//For a 20 by 20 square, we need a 21x21 matrix, because we want to save each split's path total value...
            long[][] grid = new long[n][]; //create a grid where we can save the paths 
            for (int i = 0; i < n; i++) //init grid
            {
                grid[i] = new long[n];
            }
            Print(CalculateRoutes(ref grid, 0, 0)); //start the recursive function
        }

        private long CalculateRoutes(ref long[][] grid, int x, int y)
        {
            if (x == grid[0].Length - 1 && y == grid.Length - 1) return 1; //if its the last square, return 1
            if (!(x < grid[0].Length) || !(y < grid.Length)) return 0;//if out of bounce, return 0
            if (grid[x][y] != 0) return grid[x][y]; //If this path already has been calculated, take the saved value instead of calculating again
            
            long result = CalculateRoutes(ref grid, x + 1, y ) + CalculateRoutes(ref grid, x , y+ 1); //Calculate current path's length
            grid[x][y] = result; //save current path's length
            return result; //return current path's length
        }
        
    }


}
