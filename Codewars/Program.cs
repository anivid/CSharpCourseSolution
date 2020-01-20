using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace Codewars
{
    public class Kata
    {
        // return masked string
        public static string Maskify(string cc)
        {
            string res=null;
            if (cc.Length > 4)
            {
                for (int i = 0; i < cc.Length - 4; i++)
                {
                    res = String.Concat(res, "#");
                }
                res = String.Concat(res, cc[cc.Length - 4], cc[cc.Length - 3], cc[cc.Length - 2], cc[cc.Length-1]);                
            }
            else if(cc.Length <= 4)
            {
                res = cc;
            }
            return res;
        }
        public static bool IsValidWalk(string[] walk)
        {
            //Task
            //You live in the city of Cartesia where all roads are laid out in a perfect grid.
            //You arrived ten minutes too early to an appointment, so you decided to take the opportunity to go for a short walk.
            //The city provides its citizens with a Walk Generating App on their phones - everytime you press the button it sends
            //you an array of one - letter strings representing directions to walk(eg. ['N', 's', ' w ', ' e ']).
            //You always walk only a single block in a direction and you know it takes you one minute to traverse one city block,
            //so create a function that will return true if the walk the app gives you will take you exactly ten minutes
            //(you don't want to be early or late!) and will, of course, return you to your starting point. Return false otherwise.

            int[] position = new int[] { 0, 0 };
            int time = 0;
            for (int i = 0; i < walk.Length; i++)
            {
                time++;
                string way = walk[i];
                switch (way)
                {
                    case "n":
                        position[0] += 1; break;
                    case "s":
                        position[0] -= 1; break;
                    case "w":
                        position[1] += 1; break;
                    case "e":
                        position[1] -= 1; break;
                }
            }

            if (position[0] == 0 && position[1] == 0 && time == 10) return true;
            else return false;
        }
        public static int sumTwoSmallestNumbers(int[] numbers)
        {
            List<int> list = new List<int>(numbers);
            list.Sort();
            return list[0] + list[1];
        }
        //at codewars this method named in non static class Kata
        public static int binaryArrayToNumber(int[] BinaryArray)
        {
            int res = BinaryArray[BinaryArray.Length - 1] * 1;
            int count = 2;            
            for (int i = BinaryArray.Length-2; i >= 0; i--)
            {
                res += BinaryArray[i] * count; 
                count = count*2;
            }
            return res;
        }
        public static string Rgb(int r, int g, int b)
        {
            if (r < 0) r = 0;
            else if (r > 255) r = 255;

            if (g < 0) g = 0;
            else if (g > 255) g = 255;

            if (b < 0) b = 0;
            else if (b > 255) b = 255;

            string R = r < 16 ? String.Concat("0", r.ToString("X")) : r.ToString("X");
            string G = g < 16 ? String.Concat("0", g.ToString("X")) : g.ToString("X");
            string B = b < 16 ? String.Concat("0", b.ToString("X")) : b.ToString("X");

            return String.Concat(R,G,B);
        }
        public static string CreatePhoneNumber(int[] numbers)
        {
            return String.Concat("(", numbers[0], numbers[1], numbers[2], ") ", numbers[3], numbers[4], numbers[5], "-", numbers[6], numbers[7], numbers[8], numbers[9]);
        }
        public static string PigIt(string str)
        {
            //Move the first letter of each word to the end of it, then add "ay" to the end of the word. Leave punctuation marks untouched.

            //Kata.PigIt("Pig latin is cool"); // igPay atinlay siay oolcay
            //Kata.PigIt("Hello world !");     // elloHay orldway !
            var list = new List<string>(str.Split(" "));
            string res = null;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Length == 1) res += list[i];
                else
                {
                    list[i] = String.Concat(list[i], " ");
                    string temp = list[i];
                    list[i] = temp.Replace(temp[temp.Length - 1], temp[0]);
                    list[i] = list[i].Remove(0, 1);
                    list[i] = string.Concat(list[i], "ay");
                    res += string.Concat(list[i], " ");
                }                
            }
            return res.Trim(' ');
        }
        private int count = 0;
        public static int[] MoveZeroes(int[] arr)
        {
            int[] nulls = Array.FindAll<int>(arr, x=> x==0);
            int amountOfNulls = nulls.Length;
            var list = new List<int>(arr);
            for (int i = 0; i < amountOfNulls; i++)
            {
                list.RemoveAt(list.IndexOf(0));
            }
            for (int i = 0; i < amountOfNulls; i++)
            {
                list.Add(0);
            }
            return list.ToArray();            
        }
        public static string Add(string a, string b)
        {
            return BigInteger.Add(BigInteger.Parse(a),BigInteger.Parse(b)).ToString();
        }
        public static string FirstNonRepeatingLetter(string s)
        {            
            string temp = s;
            string upTemp = String.Empty;
            string lowTemp = String.Empty;
            string res = String.Empty;
            int count = 0;
            //return s.Substring(0, 1);
            foreach (var item in s)
            {
                temp = temp.Remove(count,1);
                lowTemp = temp.ToLower();
                upTemp = temp.ToUpper();
                if ((!upTemp.Contains(s[count].ToString().ToUpper())) || (!lowTemp.Contains(s[count].ToString().ToLower())))
                {
                    res = s[count].ToString();
                    break;
                }
                temp = temp.Insert(count, s[count].ToString());
                count++;
            }
            return res;
        }     
    }
    public class MorseCodeDecoder
    {
        private static Dictionary<string, string> morseABC = new Dictionary<string, string>()
            {
                {".-"   , "A"},  {"-..." , "B"},  {"-.-." ,    "C"},
                {"-.."  , "D"},  {"."    , "E"},  {"..-." ,    "F"},
                {"--."  , "G"},  {"...." , "H"},  {".."   ,    "I"},
                {".---" , "J"},  {"-.-"  , "K"},  {".-.." ,    "L"},
                {"--"   , "M"},  {"-."   , "N"},  {"---"  ,    "O"},
                {".--." , "P"},  {"--.-" , "Q"},  {".-."  ,    "R"},
                {"..."  , "S"},  {"-"    , "T"},  {"..-"  ,    "U"},
                {"...-" , "V"},  {".--"  , "W"},  {"-..-" ,    "X"},
                {"-.--" , "Y"},  {"--.." , "Z"},  
                {".----", "1"},  {"..---", "2"},  {"...--",    "3"},
                {"....-", "4"},  {".....", "5"},  {"-....",    "6"},
                {"--...", "7"},  {"---..", "8"},  {"----.",    "9"},
                {"-----", "0"},  {" ",     " "},  {"...---...","SOS"}, 
                {"",      ""},   {"-.-.--","!"},  {".-.-.-",   "."},
                {"--..--",","},  {"..--..","?"},  {".----." ,  "'"},
                {"-..-." ,"/"},  {"-.--." ,"("},  {"-.--.-" ,  ")"}
            };

        private static string[] SplitLetters(string morseCode) => morseCode.Split(" ");
        private static string[] SplitWords(string morseCode) => morseCode.Split("   ");

        public static string Decode(string morseCode)
        {
            //List<string> arrCode = new List<string>(SplitCode(morseCode));
            string[] arrCodeWords = SplitWords(morseCode);
            List<string> arrCodeLetters = new List<string>();
            string message = String.Empty;

            for (int i = 0; i < arrCodeWords.Length; i++)
            {
                arrCodeLetters.AddRange(SplitLetters(arrCodeWords[i]));
                arrCodeLetters.Add(" ");
            }

            foreach (var item in arrCodeLetters)
            {
                message = String.Concat(message, morseABC[item]);
            }
            return message.Trim();            
        }
    }
    public class Xbonacci
    {        
        public double[] Tribonacci(double[] sign, int n)
        {
            var seq = new List<double>(n);
            foreach (var item in sign)
            {
                seq.Add(item);
            }
            if (n >= 3)
            {                
                for (int i = 3; i < seq.Capacity; i++)
                {
                    seq.Add(seq[i - 1] + seq[i - 2] + seq[i - 3]);
                }
                return seq.ToArray();
            }
            else if (n == 2)
            {
                seq.RemoveAt(2);
                return seq.ToArray();
            }
            else if (n == 1)
            {
                seq.RemoveAt(2);
                seq.RemoveAt(1);
                return seq.ToArray();
            }
            else if (n == 0)
            {
                seq.Clear();
                return seq.ToArray();
            }
            else return null;         
        }
    }
    public class DigPow
    {
        public static long digPow(int n, int p)
        {
            //https://www.codewars.com/kata/5552101f47fc5178b1000050/
            string strN = n.ToString();
            double sum = 0;
            for (int i = 0; i < strN.Length; i++)
            {
                sum += Math.Pow((int)Char.GetNumericValue(strN[i]), p);
                p++;
            }
            long k = (long)sum % n == 0 ? (long)sum / n : -1;
            return k;
        }
    }
    public class Line
    {
        public static string Tickets(int[] peopleInLine)
        {
            List<int> list = new List<int>(peopleInLine);
            List<int> temp = new List<int>();
            bool res = false;
            for (int i = 0; i < list.Count-1; i++)
            {
                temp.Add(list[i]);
                switch (list[i])
                {
                    case 25: break;
                    case 50:
                        temp.Remove(25);
                        //if (temp.Contains(25)) temp.Remove(25);
                        //else return "NO";
                        break;
                    case 100:
                        if (temp.Contains(25) && temp.Contains(50))
                        {
                            temp.Remove(50);
                            temp.Remove(25);
                        }
                        if (!temp.Contains(50))
                        {
                            temp.Remove(25);
                            temp.Remove(25);
                            temp.Remove(25);
                        }
                        break;
                }
            }

            switch (list[list.Count - 1])
            {
                case 25:
                    res = true;
                    break;
                case 50:
                    res = temp.Contains(25);
                    break;
                case 100:
                    if (temp.Contains(25) && temp.Contains(50)) res = true;
                    else
                    {
                        int count = 0;
                        foreach (var item in temp)
                        {
                            count = item == 25 ? count + 1 : count;
                        }

                        res = count == 3 ? true : false;
                    }                    
                    break;
            }

            string strRes = res == true ? "YES" : "NO";
            return strRes;
        }
    }
    public class SplitString
    {
        public static string[] Solution(string str)
        {
            List<string> strList = new List<string>();
            if ((str.Length - 1) % 2 != 0)
            {
                for (int i = 0; i < str.Length - 1; i = i + 2)
                {
                    strList.Add(String.Concat(str[i], str[i + 1]));
                }
            }
            else
            {
                int count = 0;
                for (int i = 0; i < str.Length - 2; i = i + 2)
                {
                    strList.Add(String.Concat(str[i], str[i + 1]));
                    count+=2;
                }
                strList.Add(String.Concat(str[count], "_"));
            }                      
            return strList.ToArray();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {            
        }

        static void BinToDecCall()
        {
            int[] arr = new int[] { 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 1 };
            Console.WriteLine(Kata.binaryArrayToNumber(arr));
        }
        static void TribonacciCall()
        {
            var tribonacci = new Xbonacci();
            double[] sign = new double[] { 19, 15, 19 };
            double[] trib = tribonacci.Tribonacci(sign, 0);
            foreach (var item in trib)
            {
                Console.WriteLine(item);
            }
        }
    }
}
