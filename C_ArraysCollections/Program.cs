using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace C_ArraysCollections
{
    class RomanNumeral
    {
//        while (isRoman == false)
//            {
//                Console.WriteLine("Type the roman numerals to convert to arabic:");
//                inputRoman = Console.ReadLine();
//                inputRoman = inputRoman.ToUpper();
//                int counter = 0;
//                foreach (char word in inputRoman)
//                {
//                    if (word == 'I' || word == 'V' || word == 'X' || word == 'L' || word == 'C' || word == 'D' || word == 'M')
//                    {
//                        counter++;
//                    }
//}

//                if (counter == inputRoman.Length)
//                {
//                    isRoman = true;
//                }
//                else
//                {
//                    Console.WriteLine("\nInput data is not roman numerals, please type correct data");
//                }
//            }
        private static Dictionary<char, int> map = new Dictionary<char, int>()
        {
            {'I', 1 },
            {'V', 5 },
            {'X', 10 },
            {'L', 50 },
            {'C', 100 },
            {'D', 500 },
            {'M', 1000 },
        };

        public static bool checkRomanString(string roman)
        {
            bool isRoman = false;
            while (isRoman == false)
            {               
                int counter = 0;
                foreach (char word in roman)
                {
                    if (word == 'I' || word == 'V' || word == 'X' || word == 'L' || word == 'C' || word == 'D' || word == 'M')
                    {
                        counter++;
                    }
                }

                if (counter == roman.Length)
                {
                    isRoman = true;
                }
                else break;
            }
            return isRoman;
        }

        public static int Parce(string roman)
        {
            int result = 0;

            for (int i = 0; i < roman.Length; i++)
            {
                if (i + 1 < roman.Length && IsSubtractive(roman[i], roman[i + 1]))
                {
                    result -= map[roman[i]];
                }
                else
                {
                    result += map[roman[i]];
                }                               
            }

            return result;
        }

        private static bool IsSubtractive(char c1, char c2)
        {            
            return map[c1] < map[c2];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        
        
        static void CallRomanParce()
        {
            bool roman = false;
            while (roman == false)
            {
                string str = Console.ReadLine();
                str = str.ToUpper();
                if (RomanNumeral.checkRomanString(str))
                {
                    Console.WriteLine(RomanNumeral.Parce(str));
                    roman = true;
                    break;
                }
                else
                {
                    Console.WriteLine("symbols not roman, retype");
                }
            }
        }
        static void JaggedArrays()
        {
            //зубчатые массывы
            //создаем массив из четырех строк
            int[][] jaggedArray = new int[4][];
            //обращаемся к каждой строке и говорим сколько в ней столбцов
            jaggedArray[0] = new int[1];
            jaggedArray[1] = new int[3];
            jaggedArray[2] = new int[2];
            jaggedArray[3] = new int[4];

            //заполнение
            Console.WriteLine("enter the number of jagged array");

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    string st = Console.ReadLine();
                    jaggedArray[i][j] = int.Parse(st);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Printing the elems");

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void MiltidimArrays()
        {
            //многомерные массивы
            //new int[кол-во строк, столбцов]
            int[,] r1 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] r2 = { { 1, 2, 3 }, { 4, 5, 6 } };

            for (int i = 0; i < r2.GetLength(0); i++)
            {
                for (int j = 0; j < r2.GetLength(1); j++)
                {
                    Console.Write($"{r2[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        static void StackQueue()
        {
            //Stack - abstract data type (ADT); LIFO - last-in first-out
            //operation: push - Add intem on the top; Pop - remove top item; Peek - get the top item;

            //Queue - FIFO - first-in first-out
            //operations: Enqueue - add item to the end of queue; Dequeue - remove; Peek

            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            Console.WriteLine($"Peek of stack, this should be 4: {stack.Peek()}");

            stack.Pop();
            Console.WriteLine($"this should be 3: {stack.Peek()}");

            Console.WriteLine("iterate over the stack");

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            Console.WriteLine($"Peek of queue, this should be 1: {queue.Peek()}");

            queue.Dequeue();
            Console.WriteLine($"this should be 2: {queue.Peek()}");

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }
        static void DictionaryDemo()
        {
            //ассоциативный массив. тип Dictionary<тип ключа, тип значения>
            //ключ всегда уникальный
            var people = new Dictionary<int, string>();
            people.Add(1, "John");
            people.Add(2, "Alice");
            people.Add(3, "Bob");

            //еще одна форма заполнения
            people = new Dictionary<int, string>()
            {
                { 1, "John"},
                { 2, "Alice"},
                { 3, "Bob"},
            };

            //доступ по индексу
            string name = people[1];
            Console.WriteLine(name);

            Console.WriteLine("\nIterating over keys");
            Dictionary<int, string>.KeyCollection keys = people.Keys; //можно использовать просто var keys
            foreach (var item in keys)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nIterating over values");
            Dictionary<int, string>.ValueCollection values = people.Values;
            foreach (var item in values)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nIterating over pairs");
            foreach (KeyValuePair<int, string> pair in people) //можно использовать var pair
            {
                Console.WriteLine($"Key: \"{pair.Key}\" Value: \"{pair.Value}\"");
            }

            //количество элементов в Dictionary
            Console.WriteLine($"Count= {people.Count}");

            //проверка на содержимое
            bool containsKey = people.ContainsKey(2); //поиск ключа
            bool containsValue = people.ContainsValue("John"); //поиск значения

            //удаление элемента по ключу, возвращает bool
            people.Remove(1);

            //дублировать ключи нельзя, иначе возникнет исключение
            //чтобы не допустить дублирования
            if (people.TryAdd(2, "Matt"))
            {
                Console.WriteLine("Add successfull");
            }
            else
            {
                Console.WriteLine("failed to add");
            }

            //так же можно пытаться вытащить значение из словаря
            //out записывает рез-т в переменную
            if (people.TryGetValue(2, out string val))
            {
                Console.WriteLine($"key 2, is {val}");
            }
            else
            {
                Console.WriteLine("failed to get val");
            }

            //удалить все пары ключ,значение
            people.Clear();
        }
        static void ListDemo()
        {
            var intList = new List<int> { 1, 4, 2, 5, 6, 12 };
            intList.Add(7);

            int[] intArray = { 1, 2, 3 };
            intList.AddRange(intArray);

            //метод remove возвращает bool (true - если элемент был удален).
            intList.Remove(1);
            //True
            //Console.WriteLine(intList.Remove(1));

            //удалить эл-т по индексу
            intList.RemoveAt(0);

            //вернем минимальное и максимальное значение
            int min = intList.Min();
            int max = intList.Max();

            //проверим наличие элемента
            bool contains = intList.Contains(3);

            //найдем индекс первого вхождения элемента
            int indexOf = intList.IndexOf(5);
            //последнего вхождения
            int lastIndexOf = intList.LastIndexOf(2);

            //вместо свойства .Lenght у списков используется св-во .Count
            for (int i = 0; i < intList.Count; i++)
            {
                Console.Write($"{intList[i]} ");
            }
        }
        static void ArrayType()
        {
            //бинарный поиск работает только на упорядоченном массиве
            //возвращает первое значение искомого числа
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int index = Array.BinarySearch(numbers, 7);

            Console.WriteLine(index);

            //метод(уровня класса) копирования массива
            int[] copy = new int[10];
            Array.Copy(numbers, copy, numbers.Length - 1);

            int[] anotherCopy = new int[10];
            //метод уровня экземпляра
            copy.CopyTo(anotherCopy, 0);

            //метод реверса всех эл-тов массива (не возвращает новый массив, а изменяет текущий)
            Array.Reverse(anotherCopy);

            //сортируем в порядке возрастания
            Array.Sort(anotherCopy);

            //обнуляем массив
            Array.Clear(anotherCopy, 0, anotherCopy.Length);

            int[] a1;
            a1 = new int[5];

            int[] a2 = new int[5];

            int[] a3 = new int[5] { 1, 2, 3, 4, 5 };

            int[] a4 = { 1, 3, 2, 4, 5 };

            //Любой массив представлен типом array
            Array myarray = new int[5];
            //равно
            Array myarray2 = Array.CreateInstance(typeof(int), 5);
            myarray2.SetValue(12, 0);

            Console.WriteLine(myarray2.GetValue(0));
        }
    }

}
