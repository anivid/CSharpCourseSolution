using System;
using System.IO;

namespace E_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream file = null;
            try
            {
                file = File.Open("temp.txt", FileMode.Open);
            }
            catch(Exception ex)
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
            catch(FormatException ex)
            {
                log = String.Concat("Exception catched", "\n", ex.ToString());
            }
            Console.WriteLine();

            Console.WriteLine(log);
        }
    }
}
