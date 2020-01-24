//using E_FileStream_and_Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace E_Filestream_and_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex(1, 1);
            Complex c2 = new Complex(1, 2);

            Complex result = c1.Minus(c2);

            Console.WriteLine(result.ComplexNum);

        }
        
        static void DirFileDemo()
        {
            {
                File.Copy("test.txt", @"D:\tmp\test_copy.txt", overwrite: true);
                File.Move("test_copy.txt", "test_copy_renamed.txt");
                File.Delete("test_copy.txt");

                //проверка наличия файла
                if (File.Exists("test.txt"))
                {
                    File.AppendAllText("test.txt", "bla");
                }

                bool existsDir = Directory.Exists(@"C:\tmp");
                if (existsDir)
                {
                    //поиск всех txt файлов во всех вложенных папках
                    var files = Directory.EnumerateFiles(@"C:\tmp", "*.txt", SearchOption.AllDirectories);
                    //вывести все найденные файлы
                    foreach (var file in files)
                    {
                        Console.WriteLine(file);
                    }
                }
            }
        }
        static void FileDemo()
        {
            //с потоками ввода/вывода можно работать через класс Stream

            //запист всех строк из файла в массив
            string[] allLines = File.ReadAllLines("test.txt");
            string allText = File.ReadAllText("test.txt");//в строку
            //здесь строки будут читаться при прохождении foreach по lines построчно
            //сейчас по факту не происходит чтения. на крупном файле экономит время
            IEnumerable<string> lines = File.ReadLines("test.txt");

            //запись
            File.WriteAllText("test_2.txt", "Hello");//если файла нет то он будет создан
            File.WriteAllLines("test_3.txt", new string[] { "Hello", "World" });//запись массива
            File.WriteAllBytes("test_4.txt", new byte[] { 234, 42, 25, 123, 31 });


            Console.ReadLine();

            Stream fs = new FileStream(@"test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            try
            {
                string str = "Hello, World";
                //метод Write принимает буффер байтов, поэтому строку надо преобразовать в массив байт
                byte[] strInBytes = Encoding.UTF8.GetBytes(str);

                //в аргументы указываем массив байтов, начальный байт, конечный байт 
                fs.Write(strInBytes, 0, strInBytes.Length);
                //if (fs.CanWrite)
                //{
                //    fs.Write()
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            finally
            {
                fs.Close();
            }

            Console.WriteLine("Reading...");

            //при работе с классами, которые реализуют IDisposable, например FileStream
            //конструкцию try-finally можно заменить на using
            using (Stream readingStream = new FileStream(@"test.txt", FileMode.Open, FileAccess.Read))
            {
                byte[] temp = new byte[readingStream.Length];
                int bytesToRead = (int)readingStream.Length;
                int bytesRead = 0;

                while (bytesToRead > 0)
                {
                    int n = readingStream.Read(temp, bytesRead, bytesToRead);
                    if (n == 0) break;

                    bytesRead += n;
                    bytesToRead -= n;
                }
                string str = Encoding.UTF8.GetString(temp, 0, bytesRead);
                Console.WriteLine(str);
            }
        }
        static void ExtensionsDemo()
        {
            FileStream file = null;
            try
            {
                file = File.Open("temp.txt", FileMode.Open);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (file != null)
                    file.Dispose();
            }

            Console.ReadLine();

            Console.WriteLine("Please input a number");
            string result = Console.ReadLine();
            string log = "";

            try
            {
                int number = int.Parse(result);
            }
            catch (FormatException ex)
            {
                log = String.Concat("Exception catched", "\n", ex.ToString());
            }
            Console.WriteLine();

            Console.WriteLine(log);
        }
    }
}
