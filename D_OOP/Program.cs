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
            double s = calc.TriangleSquare(1, 1, 1.0);

            //именованые аргументы, один из вариантов передачи аргументов методу
            double s1 = calc.TriangleSquare(a: 1, b: 2, angleAB: 3);

            double[] arr = { 1, 2, 3, 4, 5 };
            double avg = calc.Average(arr);
            Console.WriteLine(avg);
        }   
    }
}
