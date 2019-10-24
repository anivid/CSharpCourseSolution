using System;

namespace D_OOP
{
    class Program //контейнер метода для запуска программы
    {
        static void Main(string[] args)
        {
            //Character c = new Character();
            //c.Hit(120);
            //Console.WriteLine(c.Heath);
            Calculator calc = new Calculator();
            double s = calc.TriangleSquare(1,1,1,true);


            Console.WriteLine(s);
        }   
    }
}
