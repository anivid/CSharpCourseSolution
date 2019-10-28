using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP
{
    public class Calculator
    {
        //params позволяет при вызове метода заполнять массив элементами через запятую
        //например calc.Average(1, 2, 3, 4, 5); будет передан массив items{1, 2, 3, 4, 5}
        //так же можно передавать массив сразу целиком
        public double Average(params double[] items)
        {
            double summ = 0;
            foreach (var number in items)
            {
                summ += number;
            }
            return summ/items.Length;
        }
        public double TriangleSquare(double sideA, double sideB, double sideC)
        {
            double p = (sideA + sideB + sideC) / 2;
            return Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
        }
        public double TriangleSquare(double foot, double height)
        {
            return 0.5 * foot * height;
        }
        //bool isInRadiands = false - опциональный параметр
        public double TriangleSquare(double a, double b, double angleAB, bool isInRadiands = false)
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
        public bool TryDivide(double divider, double dividend, out double result)
        {
            //выходному значению обязательно нужно присвоить значение по умолчанию
            result = 0;
            if (dividend == 0)
            {
                return false;
            }
            result = divider / dividend;
            return true;            
        }

    }
}
