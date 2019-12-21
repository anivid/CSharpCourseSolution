using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP
{
    public class Rect
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class Square : Rect
    {

    }

    public static class AreaCalc
    {
        public static int CalcSquare(Square square)
        {
            return square.Height * square.Height;
        }

        public static int CalcSquare(Rect rect)
        {
            return rect.Height * rect.Width;
        }
    }
}
