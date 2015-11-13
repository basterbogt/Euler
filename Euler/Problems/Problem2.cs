namespace Euler.Problems
{
    public class Problem2 : Problem
    {
        public override void Calculate()
        {
            int sum = 0;
            int a = 1;
            int b = 1;
            int c = a + b;
            while( c < 4000000) {
                if (c % 2 == 0) sum += c;
                a = b;
                b = c;
                c = a + b;
            }
            Print(sum);
        }
    }
}
