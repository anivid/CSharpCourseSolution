using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP
{
    //разница между классом и стуктурой в семантике копирования
    //value type - тип значения - структура(struct)
    //reference type - ссылочный тип - класс(class)

    public struct PointVal
    {
        public int X;
        public int Y;

        public void LogValue()
        {
            Console.WriteLine($"X = {X}, Y = {Y}");
        }
    }

    public class PointRef
    {
        public int X;
        public int Y;

        public void LogValue()
        {
            Console.WriteLine($"X = {X}, Y = {Y}");
        }
    }
}
