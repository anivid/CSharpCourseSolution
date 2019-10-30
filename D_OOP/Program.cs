using System;
using System.Collections.Generic;

namespace D_OOP
{
    class Program //контейнер метода для запуска программы
    {
        static void Main(string[] args)
        {
            
        }

        static void NRE_NullableValTypesDemo()
        {
            //PointVal pv; //присвоить null невозможно

            //nullable PointVal type 
            PointVal? pv = null;
            if (pv.HasValue) //если не null
            {
                PointVal pv2 = pv.Value;
                Console.WriteLine(pv.Value.X);//если не использовать if, будет NullReferenceException
                //или
                Console.WriteLine(pv2.X);
            }

            //если pv3 == null, то мы получим экземпляр по умолчанию
            PointVal pv3 = pv.GetValueOrDefault();


            //мы не выделили память для с в куче
            PointRef c = null;
            Console.WriteLine(c.X); //NullReferenceException (ссылка объекта не указывает на экземляр объекта)

        }
        static void ValRefTypesAsArguments()
        {
            int a = 1;
            int b = 2;

            //
            Console.WriteLine("Main:\nпередаем в Swap(int a, int b) value types, т.е. значения а не ссылки");
            Swap(a, b);
            Console.WriteLine($"Main:\na = {a} b = {b}");
            //передаем valye types по ссылке
            Console.WriteLine("Main:\nпередаем в Swap(ref int a, ref int b) ref types, т.е. ссылки");
            Swap(ref a, ref b);
            Console.WriteLine($"Main:\na = {a} b = {b}");

            Console.ReadLine();
            var list = new List<int>();
            //передаем класс в качестве арумента
            //копируется ссылка на list
            AddNumbers(list);

            foreach (var item in list)
            {
                Console.WriteLine(item); //1 2 3
            }
        }
        static void Swap(ref int a, ref int b)
        {
            //для приема ссылочных значений
            Console.WriteLine($"void Swap():\noriginal: a = {a}, b = {b}");
            int tmp = a;
            a = b;
            b = tmp;

            Console.WriteLine($"swapped: a = {a}, b = {b}\n");

        }
        static void Swap(int a, int b)
        {
            Console.WriteLine($"original: a = {a}, b = {b}");
            int tmp = a;
            a = b;
            b = tmp;

            Console.WriteLine($"swapped: a = {a}, b = {b}");

        }

        static void AddNumbers(List<int> numbers)
        {
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
        }

        static void CalcCall()
        {
            Calculator calc = new Calculator();
            double s = calc.TriangleSquare(1, 1, 1.0);

            //именованые аргументы, один из вариантов передачи аргументов методу
            double s1 = calc.TriangleSquare(a: 1, b: 2, angleAB: 3);

            double[] arr = { 1, 2, 3, 4, 5 };
            double avg = calc.Average(arr);

            double divideResult;
            bool tryDivide = calc.TryDivide(1, 3, out divideResult);
            Console.WriteLine($"try divide = {tryDivide}\ndivideResult = {divideResult}");
        }
        static void ValueAndReferenceTypes()
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
        }
    }
}
