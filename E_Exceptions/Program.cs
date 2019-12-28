using System;
using System.IO;
using System.Text;

namespace E_Filestream_and_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //с потоками ввода/вывода можно работать через класс Stream

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
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            finally
            {
                fs.Close();
            }

            //при работе с классами, которые реализуют IDisposable, например FileStream
            //конструкцию try-finally можно заменить на using
            using (Stream readingStream = new FileStream("test.txt", FileMode.Open, FileAccess.Read))
            {
                byte[] temp = new byte[14];
                int len = 0;
                while((len = readingStream.Read(temp, 0, temp.Length)) > 0)
                {
                    string str = Encoding.UTF8.GetString(temp, 0, len);
                    Console.WriteLine(str);
                }
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
