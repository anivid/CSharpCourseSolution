using System;
using System.Text;

namespace CSharpCourse
{
    class Program
    {
        static void Main(string[] args)
        { 

        }

        static void DateTimeDemo()
        {
            //now - экземпляр DateTime
            DateTime now = DateTime.Now;
            Console.WriteLine(now.ToString());

            Console.WriteLine($"It's {now.Hour}:{now.Minute}:{now.Second}");

            //арифметика производится на типе datetime
            DateTime dt = new DateTime(2016, 2, 28);
            DateTime newDt = dt.AddDays(2);
            Console.WriteLine(newDt);

            TimeSpan ts = now - dt;
            Console.WriteLine(ts.Days);
            //ts = now.Subtract(dt);
        }
        static void ArraysIntro()
        {
            //объявление массива из 5-ти элементов (выделение памяти (40байт))
            int[] a1;
        a1 = new int[5];

            //алтернативное представление
            int[] a2 = new int[5];

        //объявление с инициализацией (заполнением)
        int[] a3 = new int[5] { 1, 2, 3, 4, 5 };

        //альтерниатива объявление с инициализацией (заполнением)
        int[] a4 = { 1, 2, 3, 4, 5 };

        //перезапись эленемтов
        a4[4] = 6;

            //количество эл-тов массива (последний индекс (a4.Length - 1))
            Console.WriteLine(a4.Length);

            string s1 = "abcdefg";

        char first = s1[0];
        char last = s1[s1.Length - 1];

        Console.WriteLine($"first: {first}\nlast: {last}");

            //строки защищены от модификаций как массив
            // impossible
            // s1[0] = 'z';
        }
        static void MathDemo()
        {
            Console.WriteLine(Math.Pow(2.1, 3));
            Console.WriteLine(Math.Sqrt(9));

            Console.WriteLine(Math.Round(1.4));
            Console.WriteLine(Math.Round(1.6));
            Console.WriteLine($"{Math.Round(1.5)}\n");

            Console.WriteLine(Math.Round(2.5, MidpointRounding.AwayFromZero));
            Console.WriteLine(Math.Round(2.5, MidpointRounding.ToEven));
        }
        static void CastingAndParsing()
        {
            // неявное приведение типов
            byte b = 3; // 0000 0011
            int i = b; // 0000 0000 0000 0000 0000 0000 0000 0011
            long l = i; // 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0011

            float f = i; // cw -> 3
            Console.WriteLine(f);

            b = (byte)i; // явное приведение типа
            Console.WriteLine(b);

            i = (int)f;

            f = 3.1f;
            i = (int)f; // 3

            string str = "1";
            i = int.Parse(str);
            double result;

            Console.WriteLine(result = (double)b / 2); 

        }
        static void ConsoleDemo()
        {
            //Console.WriteLine("Hi, please tell me your name");
            //string name = Console.ReadLine();
            //string sentence = $"Your name is {name}";
            //Console.WriteLine(sentence);

            Console.WriteLine("tell me your age");
            string inputAge = Console.ReadLine();
            int age = int.Parse(inputAge);
            Console.WriteLine($"your age is {age}");

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("New stryle"); // без перевода строки

        }
        static void StringComparisonDemo()
        {
            string str1 = "abcde";
            string str2 = "abcde";

            bool areEqual = str1 == str2;
            Console.WriteLine(areEqual);

            areEqual = string.Equals(str1, str2, StringComparison.Ordinal); //метод сравния строк с режимом ordinal
            Console.WriteLine(areEqual);
        }
        static void StringFormat()
        {
            string name = "John";
            int age = 30;
            string str1 = string.Format("My name is {0}, I'm {1}", name, age);// = "My name is " + name + ", I,m " + age;
            Console.WriteLine(str1);

            string str2 = $"My name is {name}, I'm {age}"; // интерполирование строк (записи str1 == str2)

            string str3 = $"My name is {Environment.NewLine}John"; // {Environment.NewLine} используется для корректного перевода строки в разных ОС (вместо \n или \n\r)
            //Console.WriteLine(str3);

#pragma warning disable CS0219 // Переменная назначена, но ее значение не используется
            string str4 = "I'm John and I'm \"good\" programmer"; // \ используется для экранирования специальных символов
            string str5 = "C:\\temp\\text.txt"; // в этом примере \ используется для экранирования символа \
#pragma warning restore CS0219 // Переменная назначена, но ее значение не используется

            str5 = @"C:\temp\text.txt";// @ - обозначает verbatim string, строка записывается как есть, без необходимости экранирования

            double answer = 42.009;
            //string result = string.Format("{0:d}", answer);
            //string result2 = string.Format("{0:d4}", answer); //0 - обозначает первый аргумент после запятой, d4 - десятчное число с четыремя символами
            //Console.WriteLine(result2);

            
            string result = string.Format("{0:f2}", answer);
            string result2 = string.Format("{0:f1}", answer);

            Console.WriteLine("{0:R}", .1 + .2);

            Console.OutputEncoding = Encoding.UTF8;
            double money = 12.8;

            result = string.Format("{0:C}", money); //:C используется для обозначения местной валюты
            result2 = string.Format("{0:C1}", money); //:C используется для обозначения местной валюты

            Console.WriteLine(result);
            Console.WriteLine(result2);



        }
        static void MeetStringBuilding()
        {
            StringBuilder sb = new StringBuilder(); // этот тип быстрее всего обрабатывает строки нежели методы типа string.
            sb.Append("My ");
            sb.Append("name ");
            sb.Append("is ");
            sb.Append("Matvey");
            sb.AppendLine("!");
            sb.AppendLine("Hello");

            string str = sb.ToString();
            Console.WriteLine(str);
        }
        static void StringModification()
        {
            string nameConcat = string.Concat("my ", "name ", "is ", "Matvey "); // == nameConcat = "my " + "name " + "is " + "Matvey "
            Console.WriteLine(nameConcat);

            nameConcat = string.Join(" ", "my", "name", "is", "Matvey"); // первый аргумент указывает какой будет разделитель
            Console.WriteLine(nameConcat);

            nameConcat = nameConcat.Insert(0, "Hello, "); // первый аргумент указвает индекс вхождения
            Console.WriteLine(nameConcat);

            string removed = nameConcat.Remove(0, 3); // первый аргумент указвает индекс с которого начнется удаление символов в строке, второй - кол-во удаляемых символов
            Console.WriteLine(removed); // lo, my name is Matvey

            string replaced = nameConcat.Replace("m", "*"); // заменяет все символы в строке(тут с m на *)
            Console.WriteLine(replaced); //Hello, *y na*e is Matvey

            string data = "12;28;34;35;63";
            string[] splitData = data.Split(';'); // метод разделения строки, аргуметн служит для поиска разделителя. рез-т записывается в массив
            string first = splitData[0];
            Console.WriteLine(first);

            char[] chars = nameConcat.ToCharArray(); // возвращает массив чаров

            string lower = nameConcat.ToLower();
            string upper = nameConcat.ToUpper();

            Console.WriteLine("lower cases: {0}\nupper cases: {1}", lower, upper);

            string john = " My name is John ";
            Console.WriteLine(john.Trim()); // удаляет пробельные символы в начале и конце строки

        }
        static void EmptyStrings()
        {
            string empty = "";  // == string someName = stirng.Empty;
            string whiteSpace = " ";
            string notEmpty = " b";
            string nullString = null;

            bool isNullOrEmpty = string.IsNullOrEmpty(empty); // метод IsNullOrEmpty возвращает true если если строка пустая или содержит null
            Console.WriteLine(isNullOrEmpty);

            isNullOrEmpty = string.IsNullOrEmpty(whiteSpace);
            Console.WriteLine(isNullOrEmpty);

            isNullOrEmpty = string.IsNullOrEmpty(notEmpty);
            Console.WriteLine(isNullOrEmpty);

            isNullOrEmpty = string.IsNullOrEmpty(nullString);
            Console.WriteLine(isNullOrEmpty);


            bool isNullOrWhitheSpace = string.IsNullOrWhiteSpace(empty); //возвращает true если если строка содержит только пробел, null или пустая
            Console.WriteLine(isNullOrWhitheSpace);

            isNullOrWhitheSpace = string.IsNullOrWhiteSpace(whiteSpace);
            Console.WriteLine(isNullOrWhitheSpace);

            isNullOrWhitheSpace = string.IsNullOrWhiteSpace(notEmpty);
            Console.WriteLine(isNullOrWhitheSpace);

            isNullOrWhitheSpace = string.IsNullOrWhiteSpace(nullString);
            Console.WriteLine(isNullOrWhitheSpace);
        }
        static void QueryingStrings()
        {
            string name = "abracadabra";
            bool containsA = name.Contains('a');
            bool containsE = name.Contains('E');

            Console.WriteLine(containsA);
            Console.WriteLine(containsE);

            bool endWithAbra = name.EndsWith("abra");
            Console.WriteLine(endWithAbra);

            bool startWithAbra = name.StartsWith("abra");
            Console.WriteLine(startWithAbra);

            int indexOfA = name.IndexOf('a', 1);
            Console.WriteLine(indexOfA);

            int lastIndexOfR = name.LastIndexOf('r');
            Console.WriteLine(lastIndexOfR);
            Console.WriteLine(name.Length);

            string substrFrom5 = name.Substring(5); //возвращает подстроку с пятого (индекс) символа
            string substrFromTo = name.Substring(3, 5); //возвращает пять символов с третьего индекса

            Console.WriteLine("substrFrom5 = {0}; substrFromTo = {1}", substrFrom5, substrFromTo);
        }
        static void StaticAndInstanceMembers()
        {
            string name = "abrakadabra";
            bool containsA = name.Contains('a'); //name.Contains('a') - метод (член) уровня экземпляра (вызывается на экземпляре)
            Console.WriteLine(containsA);

            string abc = string.Concat("a", "b", "c"); //вызов статического метода, его результат записвается в экземпляр abc
            Console.WriteLine(abc);
            Console.WriteLine(int.MinValue); // статическое свойство

            int x = 1;
            string xStr = x.ToString(); //метод преобразования числа в строку
            Console.WriteLine(xStr);
        }
        static void BoolOperations()
        {
            int x = 1;
            int y = 2;
            bool AreEqual = x == y;
            Console.WriteLine(AreEqual);
            bool result = x > y;
            Console.WriteLine("x > y ? - {0}", result);
            result = x < y;
            Console.WriteLine("x < y ? - {0}", result);
            result = x == y;
            Console.WriteLine("x == y ? - {0}", result);
            result = x <= y;
            Console.WriteLine("x <= y ? - {0}", result);
        }
        static void MathOperations()
        {
            int a, b, c, d, x, y;
            a = 1;
            b = 2;
            c = 3;
            d = 4;

            x = a * b;
            y = d / c; //при делении типов int вернется целое число (1).

            a = x % y; //остаток от деления (0)

            b = b * b; //возведение в степень

            b *= 2; //умножение переменной на 2
            b /= 2; //деление
        }
        static void IncrementDecrementDemo()
        {
            int x = 1;
            x = x + 1; // == x++ or ++x 
            x = x - 1; // == x-- or --x

            Console.WriteLine("Learn about increments");
            Console.WriteLine($"This x = {x}");
            int j = 1;
            Console.WriteLine($"This j = {j}");

            j = x++; //постфиксный инкремент
            Console.WriteLine("x= {0}\nj= {1}", x, j);
            j = ++x; //префиксный(инфиксный) инкремент (имеет больший приоритет присвоения)
            Console.WriteLine("x= {0}\nj= {1}", x, j);
        }
        static void Vars()
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(.1 + .2);
            string number = Console.ReadLine();
            int outNumber;
            Int32.TryParse(number, out outNumber);
            //a += 1;
            //Console.WriteLine(outNumber.GetType());
            object typeOutNumber = outNumber.GetType();
            object typeTypeOutNumber = typeOutNumber.GetType();
            Console.WriteLine(typeOutNumber);
            Console.WriteLine(typeTypeOutNumber);
            string strTypeOutNumber = string.Concat(typeTypeOutNumber);
            Console.WriteLine(strTypeOutNumber.GetType());
        }
        static void Overflow()
        {
            checked // производит проветрку на переполнение
            {
                uint x = uint.MaxValue;
                Console.WriteLine("Max value of uint type: {0}", x);
                x += 1;
                Console.WriteLine("Max value of uint type + 1: {0}", x);
                x -= 1;
                Console.WriteLine("Max value of uint type - 1: {0}", x);
            }
        }

        //HOME TASKS
        static void FirstToThird()
        {
            Console.WriteLine("Type your name:");
            string name = Console.ReadLine();

            Console.WriteLine($"\nHello, {name}");

            Console.WriteLine("Type one integer number:\n");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("\nType one more integer number:\n");
            int y = int.Parse(Console.ReadLine());

            Console.WriteLine($"\nNow:\nx = {x}; y = {y}\n");

            Console.WriteLine("Swap x and y\n");
            int z = x;
            x = y;
            y = z;
            Console.WriteLine($"x = {x}; y = {y}\n");

            Console.WriteLine("Input number:\n");
            x = int.Parse(Console.ReadLine());

            string strX = x.ToString();
            Console.WriteLine(strX.Length);
            //Console.WriteLine(x.ToSting().Length);
        }
        static void GeronFormula()
        {
            double a, b, c, S, p;
            Console.WriteLine("Input a:");
            a = double.Parse(Console.ReadLine());
            Console.WriteLine("Input b:");
            b = double.Parse(Console.ReadLine());
            Console.WriteLine("Input c:");
            c = double.Parse(Console.ReadLine());

            Console.WriteLine($"{a} {b} {c}");
            p = (a + b + c) / 2;
            S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            Console.WriteLine($"Square of triangle = {S}");
        }
        static void UserProfile()
        {
            Console.WriteLine("Type your last name:");
            string surname = Console.ReadLine();

            Console.WriteLine("\nType your first name:");
            string name = Console.ReadLine();

            Console.WriteLine("\nType your age:");
            string age = Console.ReadLine();

            Console.WriteLine("\nType your weight in kg:");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("\nType your height in meters:");
            double height = double.Parse(Console.ReadLine());

            double bodyMassIndex = (weight / Math.Pow(height, 2));

            string profile =
                $"{Environment.NewLine}Your profile:{Environment.NewLine}" +
                $"Full Name: {string.Join(' ', name, surname)}{Environment.NewLine}" +
                $"Age: {age}{Environment.NewLine}" +
                $"Weight: {weight}{Environment.NewLine}" +
                $"Height: {height}{Environment.NewLine}" +
                $"Body Mass Index: {bodyMassIndex}";

            Console.WriteLine(profile);
            //Console.WriteLine($"\nYour profile:\nFull Name: {string.Join(' ', name, surname)}\nAge: {height}\nWeight: {weight}\nHeight: {height}\nBody Mass Index: {bodyMassIndex}");

        }
    }
}
