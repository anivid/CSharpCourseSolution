using System;
using System.Collections.Generic;
using System.Text;

namespace Guess_Number
{
    public static class StartGame
    {
        public static string mode = String.Empty;
        public static string attempts = String.Empty;
        public static bool win = false;
        public static void Start()
        {
            Console.WriteLine("Game: Guess the number.\n" +
                              "At first you must choise game mode, when you define who make up the number");

            Console.WriteLine("Input numer of attempts, default: 5");
            attempts = Console.ReadLine();

            
            while (true)
            {
                Console.WriteLine("Choise mode: human or machine?");
                mode = Console.ReadLine();
                if (mode == "human" || mode == "machine") break;
                else Console.WriteLine("Incorrect mode, try again\n");
            }
            if ((attempts != ""))
            {
                win = Robot.TryDivine(int.Parse(attempts), mode);
            }
            else win = Robot.TryDivine(mode);

            if (win) Console.WriteLine($"{mode} Losser");
            else Console.WriteLine($"{mode} winner");
        }
    }
}
