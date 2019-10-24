using System;
using System.Numerics;

namespace B_ControlFlow

{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
               
        
        static double GetDouble()
        {
            return double.Parse(Console.ReadLine());
        }
        static void SwitchCase()
        {
            int mounth = int.Parse(Console.ReadLine());

            string season = string.Empty;

            //вложенный switch/case
            switch (mounth)
            {
                case 1:
                case 2:
                case 12:
                    season = "Winter";
                    break;

                case 3:
                case 4:
                case 5:
                    season = "Spring";
                    break;

                case 6:
                case 7:
                case 8:
                    season = "Summer";
                    break;
                case 9:
                case 10:
                case 11:
                    season = "Autumn";
                    break;
                default:
                    //like "Unknown mounth"
                    //если уверены, что в дефолт попасть нельзя, то в нем нужно выбрасывать исключение:
                    throw new ArgumentException("Unexpected number of mounth");
            }

            Console.WriteLine(season);

            Console.ReadLine();
            int weddingYears = int.Parse(Console.ReadLine());
            string name = string.Empty;

            switch (weddingYears)
            {
                case 5:
                    name = "Деревянная свадьба";
                    break;
                case 10:
                    name = "Оловянная свадьба";
                    break;
                case 15:
                    name = "Хрустальная свадьба";
                    break;
                case 20:
                    name = "Фарфоровая свадьба";
                    break;
                case 25:
                    name = "Серебрянная свадьба";
                    break;
                case 30:
                    name = "Жемчужая свадьба";
                    break;
                default:
                    name = "Хз, не знаем такого юбилея";
                    break;
            }

            Console.WriteLine(name);
        }
        static void BreakContinue()
        {

            int[] arrInt = { 0, 3, 2, 1, 5, 4, 6, 7, 8, 9 };
            char[] arrChar = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };

            for (int i = 0; i < arrInt.Length; i++)
            {
                Console.WriteLine($"Number = {arrInt[i]}");

                for (int j = 0; j < arrChar.Length; j++)
                {
                    if (arrInt[i] == j)
                        break;
                    Console.Write($"{arrChar[j]}");
                }
                Console.WriteLine();
            }

            //выведем вче четные числа из массива и помощью if/continue

            foreach (var num in arrInt)
            {
                //если остаток от деления не равен нулю, то перейти к следующей итерации
                if (num % 2 != 0)
                    continue;
                Console.WriteLine(num);
            }

            Console.ReadLine();
            //выведем первые три найденные триплета
            int[] numbers = { 1, -2, 4, 7, -2, -1, 5, 6, -6, 7, -3, 4, 2, -9, 2, 6 };
            int count = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int atI = numbers[i];
                    int atJ = numbers[j];

                    if (atI + atJ == 0)
                    {
                        count++;
                        Console.WriteLine($"Pair ({atI}:{atJ}). Indexes ({i}:{j}).");
                        if (count == 3)
                            break;
                    }
                    if (count == 3)
                        break;
                }
                if (count == 3)
                    break;
            }
        }
        static void WhileDoWhile()
        {
            int age = 10;

            //цикл может не начаться если условие будет ложным
            while (age < 18)
            {
                Console.WriteLine("First while loop");
                Console.WriteLine("What is your age?");
                age = int.Parse(Console.ReadLine());
            }

            //здесь, будет выполнена первая итерация цикла, и только потом будет проверяться условие
            //если оно True, то выполнится вторая итерация и т.д...
            do
            {
                Console.WriteLine("What is your age?");
                age = int.Parse(Console.ReadLine());
            }
            while (age < 18);

            Console.WriteLine("Good");

            int[] numbers = { 1, 2, 3, 4, 5 };
            int i = 0;
            while (i < numbers.Length)
            {
                Console.WriteLine(numbers[i]);
                i++;
            }
        }
        static void NestedFor()
        {
            int[] numbers = { 1, -2, 4, 7, -2, -1, 5, 6, -6, 7, -3, 4, 2, -9, 2, 6 };

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int atI = numbers[i];
                    int atJ = numbers[j];

                    if (atI + atJ == 0)
                    {
                        Console.WriteLine($"Pair ({atI}:{atJ}). Indexes ({i}:{j}).");
                    }
                }
            }

            Console.WriteLine();
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                for (int j = i + 1; j < numbers.Length - 1; j++)
                {
                    for (int k = j + 1; k < numbers.Length; k++)
                    {
                        int atI = numbers[i];
                        int atJ = numbers[j];
                        int atK = numbers[k];

                        if (atI + atJ + atK == 0)
                        {
                            Console.WriteLine($"Triplet ({atI}:{atJ}:{atK}). Indexes ({i}:{j}:{k}).");
                        }
                    }
                }
            }
        }
        static void ForForeach()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
            Console.WriteLine();

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                Console.Write($"{numbers[i]} ");
            }
            Console.WriteLine();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    Console.Write($"{numbers[i]} ");
                }
            }
            Console.WriteLine();

            foreach (int val in numbers)
            {
                //содержимое элементов массива numbers будет сразу записываться в val на каждой итерации
                Console.Write(val + " ");
            }

        }
        static void IfDemo()
        {
            Console.WriteLine("Type your last name:");
            string surname = Console.ReadLine();

            Console.WriteLine("\nType your first name:");
            string name = Console.ReadLine();

            Console.WriteLine("\nType your age:");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("\nType your weight in kg:");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("\nType your height in meters:");
            double height = double.Parse(Console.ReadLine());

            double bodyMassIndex = (weight / Math.Pow(height, 2));

            Console.WriteLine($"BMI = {bodyMassIndex}");

            bool isTooLow = bodyMassIndex <= 18.5;
            bool isNormal = bodyMassIndex > 18.5 && bodyMassIndex < 25;
            bool isAboveNormal = bodyMassIndex >= 25 && bodyMassIndex <= 30;
            bool isTooFat = bodyMassIndex > 30;

            bool isFat = isAboveNormal || isTooFat;

            //if(isFat == True)
            //if (isFat) 
            //{
            //    Console.WriteLine("You better lose some weight.");
            //}
            //else
            //{
            //    Console.WriteLine("Oh, you'r in good shape.");
            //}

            if (isTooLow)
            {
                Console.WriteLine("Not enough weight.");
            }

            else if (isNormal)
            {
                Console.WriteLine("You're OK.");
            }

            else if (isAboveNormal)
            {
                Console.WriteLine("Be careful");
            }

            else
            {
                Console.WriteLine("You better lose some weight.");
            }

            if (isTooFat || isAboveNormal)
            {
                Console.WriteLine("Anyway, it's time to get on diet");
            }

            //тернарное выражение
            string description = age > 18 ? "You can drink alcohol" : "You should get a bit older";
            Console.WriteLine(description);
        }

        //HOME TASKS
        static void GetMax()
        {
            Console.WriteLine("Type an integer:");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Type anoter integer:");
            int b = int.Parse(Console.ReadLine());

            int c = a > b ? a : b;
            Console.WriteLine($"\nMax integer is: {c}");
        }
        //Возвращает массив чисел фибоначчи заданной длинны
        static int[] Fibonacci(int n)
        {
            int[] fibonacciSeq = new int[n];

            if (n < 2)
            {
                Console.WriteLine("1");
            }
            else
            {
                fibonacciSeq[0] = 1;
                fibonacciSeq[1] = 1;

                for (int i = 2; i < fibonacciSeq.Length; i++)
                {
                    fibonacciSeq[i] = fibonacciSeq[i - 1] + fibonacciSeq[i - 2];
                }
                //foreach (int num in fibonacciSeq)
                //{
                //    Console.Write($"{num} ");
                //}
            }

            return fibonacciSeq;
        }
        static void FibonacciCall()
        {
            Console.WriteLine("Type the number of elements of fibonacci numbers");
            int n = (int)GetUInt();
            int[] fibonacci = Fibonacci(n);

            Console.WriteLine("Fibonacci sequence: ");
            foreach (int num in fibonacci)
            {
                Console.Write($"{num} ");
            }
        }
        //взятие положительного int
        static uint GetUInt()
        {
            int n = 0;
            while (n <= 0)
            {
                Console.WriteLine("\nnumber must be above 0\n");
                n = int.Parse(Console.ReadLine());
            }
            return (uint)n;
        }
        //рассчет среднего значения чисел кратных трем
        static void AverageOfTen()
        {
            int[] numbers = new int[10];
            int count = 0;

            while (count < 10)
            {
                Console.WriteLine($"Type the number ({count + 1} of 10) or type zero to skip:");
                numbers[count] = int.Parse(Console.ReadLine());
                if (numbers[count] == 0)
                    break;
                count++;
            }
            //for (int i = 0; i < numbers.Length; i++)
            //{                
            //    numbers[i] = 1;
            //    while (numbers[i] % 3 != 0)
            //    {
            //        Console.WriteLine("Type the number of a multiple of three:");
            //        numbers[i] = int.Parse(Console.ReadLine());
            //    }                
            //    if (numbers[i] == 0)
            //        break;
            //    count ++;
            //}
            int summ = 0;
            count = 0;
            foreach (int item in numbers)
            {
                if (item % 3 == 0 && item > 0)
                {
                    summ += item;
                    count++;
                }
            }

            double result = (double)summ / count;
            Console.WriteLine($"\nResult = {result}");
        }
        static void Factorial()
        {
            //need to using System.Numerics.
            int n = int.Parse(Console.ReadLine());

            BigInteger factorial = new BigInteger(1);

            for (int i = 1; i <= n; i++)
            {
                factorial = BigInteger.Multiply(factorial, i);
            }        
            Console.WriteLine(factorial.ToString());
        }
        static void Auth()
        {
            string login = "john";
            string password = "qwerty";
            string inputLogin = string.Empty;
            string inputPassword = string.Empty;

            bool auth = false;

            int count = 0;
            while (true)
            {
                Console.WriteLine("Enter login");
                inputLogin = Console.ReadLine();
                Console.WriteLine("Enter password");
                inputPassword = Console.ReadLine();
                count++;

                if (count > 2)
                {
                    Console.WriteLine("The number of available tries have been exceeded");
                    break;
                }
                else if (inputLogin == login && inputPassword == password)
                {
                    auth = true;
                    break;
                }
            }

            if (auth == true)
            {
                Console.WriteLine("Enter the System");
            }
        }

    }
}
