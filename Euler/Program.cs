using Euler.Problems;
using System;

namespace Euler
{
    /// <summary>
    /// https://projecteuler.net
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            Problem p = new Problem012();
            p.Start();
            p.Calculate();
            p.Stop();
            Console.ReadLine();
        }
    }
}
