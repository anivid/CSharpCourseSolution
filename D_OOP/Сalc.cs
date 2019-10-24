using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP
{
    public class Calculator
    {
        public double TriangleSquare(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public double TriangleSquare(double a, double h)
        {
            return 0.5 * a * h;
        }

        public double TriangleSquare(double a, double b, double angleAB, bool isInRadiands)
        {
            if (isInRadiands)
            {
                return 0.5 * a * b * Math.Sin(angleAB);
            }
            else
            {
                double angleRad = Math.PI / 180 * angleAB;
                return 0.5 * a * b * Math.Sin(angleRad);
            }           
        }
    }
}
