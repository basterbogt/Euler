using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public abstract class Problem
    {
        public abstract void Calculate();

        public void Print(object print, bool newLine = true)
        {
            if (newLine) { 
                Console.WriteLine(print);
            }
            else
            {
                Console.Write(print);
            }
        }
    }
}
