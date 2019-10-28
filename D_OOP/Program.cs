using System;

namespace D_OOP
{
    class Program //контейнер метода для запуска программы
    {
        static void Main(string[] args)
        {
            PointVal a; //PointVal a = new PointVal;
            a.X = 3;
            a.Y = 5;

            PointVal b = a;
            b.X = 7;
            b.Y = 10;

            a.LogValue();
            b.LogValue();

            Console.WriteLine("after structs");

            PointRef c = new PointRef();
            c.X = 3;
            c.Y = 5;

            PointRef d = c;
            d.X = 7;
            d.Y = 10;

            c.LogValue();
            d.LogValue();
            // c, d имеют ссылку на одну и ту же область памяти
            // a, b имеют свою выделенную память



            ////Character c = new Character();
            ////c.Hit(120);
            ////Console.WriteLine(c.Heath);
            //Calculator calc = new Calculator();
            //double s = calc.TriangleSquare(1, 1, 1.0);

            ////именованые аргументы, один из вариантов передачи аргументов методу
            //double s1 = calc.TriangleSquare(a: 1, b: 2, angleAB: 3);

            //double[] arr = { 1, 2, 3, 4, 5 };
            //double avg = calc.Average(arr);
            //Console.WriteLine(avg);
        }   
    }
}
