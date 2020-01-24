using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp
{
    enum Items
    {
        O,
        X
    }
    class TicTac
    {
        public string[] GameField { get; private set; } = new string[9];

        public bool CheckWin()
        {
            if ((GameField[0] == GameField[1] && GameField[2] == GameField[0]) ||
                (GameField[3] == GameField[4] && GameField[5] == GameField[3]) ||
                (GameField[6] == GameField[7] && GameField[8] == GameField[6]) ||
                (GameField[0] == GameField[3] && GameField[6] == GameField[0]) ||
                (GameField[1] == GameField[4] && GameField[7] == GameField[1]) ||
                (GameField[2] == GameField[5] && GameField[8] == GameField[2]) ||
                (GameField[0] == GameField[4] && GameField[8] == GameField[0]) ||
                (GameField[2] == GameField[4] && GameField[6] == GameField[2]))
                return true;
            else return false;
        }
        public void AddItem(int numCell, Items item)
        {
            if (GameField[numCell].Contains(String.Empty))
                GameField[numCell] = item.ToString();
        }
        public void Step()
        {
            Console.WriteLine($"0:{GameField[0]}\t1:{GameField[1]}\t2:{GameField[2]}\n\n\n" +
                              $"3:{GameField[3]}\t4:{GameField[4]}\t5:{GameField[5]}\n\n\n" +
                              $"6:{GameField[6]}\t7:{GameField[7]}\t8:{GameField[8]}\n\n\n");
        }

            
    }

    
}
