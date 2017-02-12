using System;
using System.Collections.Generic;

namespace Euler.Problems
{
    /// <summary>
    /// 
    ///    The fraction 49/98 is a curious fraction, as an inexperienced mathematician in attempting to simplify it may incorrectly believe that 49/98 = 4/8, which is correct, is obtained by cancelling the 9s.
    ///    We shall consider fractions like, 30/50 = 3/5, to be trivial examples.
    ///    There are exactly four non-trivial examples of this type of fraction, less than one in value, and containing two digits in the numerator and denominator.
    ///    If the product of these four fractions is given in its lowest common terms, find the value of the denominator.
    /// 
    /// </summary>
    public class Problem033 : Problem
    {
        private const int decimalPlaces = 9;
        private const int minimalValue = 10;
        private const int maximumValue = 99;
        private List<Fraction> nonTrivialExamples = new List<Fraction>();

        public override void Calculate()
        {
            for (int a = minimalValue; a <= maximumValue; a++)
            {
                for (int b = minimalValue; b <= maximumValue; b++)
                {
                    if (a >= b) //Ignore trivial examples like 13/13 and and ignore results higher than one in value
                    {
                        continue;
                    }

                    var aChars = a.ToString().ToCharArray();
                    int a1 = ToInt(aChars[0]);
                    int a2 = ToInt(aChars[1]);

                    var bChars = b.ToString().ToCharArray();
                    int b1 = ToInt(bChars[0]);
                    int b2 = ToInt(bChars[1]);

                    if(a2 == 0 && b2 == 0) //Ignore trivial examples where both denominators end with 0
                    {
                        continue;
                    }

                    var currentFraction = new Fraction(a, b);

                    ProcessFraction(currentFraction, a1, b1, a2, b2);
                    ProcessFraction(currentFraction, a1, b2, a2, b1);
                    ProcessFraction(currentFraction, a2, b1, a1, b2);
                    ProcessFraction(currentFraction, a2, b2, a1, b1);
                }
            }

            double resultInDouble = 1;
            foreach (Fraction f in nonTrivialExamples)
            {
                resultInDouble *= f.ToDouble(decimalPlaces);
            }

            var result = Fraction.Parse(resultInDouble);
            Print(string.Format("Result: {0} / {1}   -> Answer = {1}", result.Numerator, result.Denominator), true);
        }

        private void ProcessFraction(Fraction currentFraction, int x, int y, int numerator, int denominator)
        {
            if (x == y)
            {
                ProcessFraction(currentFraction, new Fraction(numerator, denominator));
            }
        }

        public void ProcessFraction(Fraction x, Fraction y)
        {
            if (x.ToDouble(decimalPlaces) == y.ToDouble(decimalPlaces))
            {
                Print(string.Format("Fraction found: {0} / {1}    {2} / {3}", x.Numerator, x.Denominator, y.Numerator, y.Denominator));
                nonTrivialExamples.Add( Fraction.Parse(y.ToDouble(decimalPlaces)));
            }
        }

        private int ToInt(char c)
        {
            return c - '0';
        }

    }


    /// <summary>
    /// Represents a rational number
    /// </summary>
    public class Fraction
    {
        public int Numerator;
        public int Denominator;

        /// <summary>
        /// Constructor
        /// </summary>
        public Fraction(int numerator, int denominator)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        /// <summary>
        /// Approximates a fraction from the provided double
        /// </summary>
        public static Fraction Parse(double d)
        {
            return ApproximateFraction(d);
        }

        /// <summary>
        /// Returns this fraction expressed as a double, rounded to the specified number of decimal places.
        /// Returns double.NaN if denominator is zero
        /// </summary>
        public double ToDouble(int decimalPlaces)
        {
            if (this.Denominator == 0)
                return double.NaN;

            return System.Math.Round(
                Numerator / (double)Denominator,
                decimalPlaces
            );
        }


        /// <summary>
        /// Approximates the provided value to a fraction.
        /// http://stackoverflow.com/questions/95727/how-to-convert-floats-to-human-readable-fractions
        /// </summary>
        private static Fraction ApproximateFraction(double value)
        {
            const double EPSILON = .000001d;

            int n = 1;  // numerator
            int d = 1;  // denominator
            double fraction = n / d;

            while (Math.Abs(fraction - value) > EPSILON)
            {
                if (fraction < value)
                {
                    n++;
                }
                else
                {
                    d++;
                    n = (int)Math.Round(value * d);
                }

                fraction = n / (double)d;
            }

            return new Fraction(n, d);
        }
    }
}
