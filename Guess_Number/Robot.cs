using System;
using System.Collections.Generic;
using System.Text;

namespace Guess_Number
{
    public static class Robot
    {
        public static int Attempts { get; private set; } = 5;
        private static int randomNumber = new Random().Next(0, 100);
        public static bool TryDivine(string mode)
        {
            if (mode == "human")
            {
                string answer = String.Empty;
                int count = 50;
                int temp = count / 2;

                for (int i = 1; i <= Attempts; i++)
                {
                    Console.WriteLine($"Your number is {count}?");
                    answer = Console.ReadLine();
                    if (answer == "yes") return true;
                    else
                    {
                        Console.WriteLine("More or less?");
                        answer = Console.ReadLine();

                        if (answer == "more") count = count + temp;
                        else if (answer == "less") count = count - temp;
                        temp = temp / 2 == 0 ? 1 : temp / 2;
                    }
                }
                return false;
            }
            else
            {
                int answer;
                Console.WriteLine("Make up the numer from 0 to 100\n" +
                "Press any key, when you're ready");
                Console.WriteLine($"OK, Lets try divine what I'm guess, you have {Attempts} tries");
                for (int i = 0; i < Attempts; i++)
                {
                    Console.WriteLine("Type the number");
                    answer = int.Parse(Console.ReadLine());
                    if (answer == randomNumber) return true;
                    else
                    {
                        if (answer > randomNumber) Console.WriteLine("Less");
                        else Console.WriteLine("More");
                    }
                }
                return false;
            }
        }
        public static bool TryDivine(int attempts, string mode)
        {
            Attempts = attempts;
            return TryDivine(mode);
        }        
    }
}
