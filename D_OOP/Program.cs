using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;

namespace D_OOP
{
    class Program //контейнер метода для запуска программы
    {
        static void Main(string[] args)
        {
            Rect rect = new Rect { Height = 2, Width = 5 };
            int rectArea = AreaCalc.CalcSquare(rect);
            Console.WriteLine($"Rect area = {rectArea}");

            //проблема "is a", квадрат является частным случаем
            //прямоугольника и по логике может наследоваться от
            //него. Но при объявлении инстанции класса квадрат,
            //мы можем задать ему неправильные стороны. Это ошибка
            //при проектировании. Problem of representative
            Rect square = new Square { Width = 2, Height = 10 };
        }

        static void InterfaceExtensionCall()
        {
            //чтобы убедиться что интерфейс расширился
            //и проверить работу кода, воспользуйся дебагом
            List<object> list = new List<object>() { 1, 2, 3 };
            IBaseCollection collection = new BaseList(4);

            collection.AddRange(list);
        }
        static void AbstractDemo()
        {
            //с абстрактным классом можно работать как с массивом
            Shape[] shapes = new Shape[2];
            shapes[0] = new Triangle(10, 2, 10);
            shapes[1] = new Rectangle(5, 10);

            foreach (var item in shapes)
            {
                PolymorphismDemo(item);
            }
        }
        static void PolymorphismDemo(Shape shape)
        {
            //Полиморфизм позволяет работать с экземплярами классов
            //на уровне базового класса полиморфно (здесь Shape),  
            //а не с каждым наследником по отдельности.
            Console.WriteLine(shape.Area());
            shape.Draw();
            Console.WriteLine(shape.Perimeter());
        }
        static void InheritanceDemo()
        {
            ModelXTerminal xTerminal = new ModelXTerminal("mx01");
            xTerminal.Connect();
            ModelYTerminal yTerminal = new ModelYTerminal("my02");
            yTerminal.Connect();
        }
        static void BoxingUnboxing()
        {
            //в object можно хранить любые типы данных
            //object - это referece type

            int x = 1;
            //процесс упаковки (boxing) переменной x в obj
            //obj оборачивает x, таким образом значение x будет не на стеке, а в куче
            object obj = x;

            //кастуем обратно (unboxing)
            int y = (int)obj;
            //проблема в том что никто не знает какой тип лежит в object
        }
        static void DoWithObj(object obj)
        {
            //проверить что лежит в object можно с помощью
            //ключевых слов is и as
            bool isPointRef = obj is PointRef;
            if (isPointRef)
            {
                PointRef pr = (PointRef)obj;
                Console.WriteLine(pr.X);
            }
            else
            {
                //do something
            }

            PointRef pr2 = obj as PointRef; //если object - PointRef type, 
                                            //то сразу произойдет кастование 
                                            //PointRef pr2 = (PointRef)obj;
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
