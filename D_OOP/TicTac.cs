using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP
{
    enum Items
    {
        X,
        O
    }
    class TicTac
    {
        private string[] _gameField = new string[9];
        private readonly string[] _players = new string[2];
        public TicTac()
        {
            this._players[0] = "Player 1";
            this._players[1] = "Player 2";
            int count = 0;
            foreach (var item in _gameField)
            {
                _gameField[count] = $"{count}";
                count++;
            }
        }
        public TicTac(string player1, string player2)
        {
            this._players[0] = player1;
            this._players[1] = player2;
            int count = 0;
            foreach (var item in _gameField)
            {
                _gameField[count] = $"{count}";
                count++;
            }
        }
        private bool CheckWin()
        {
            if ((_gameField[0] == _gameField[1] && _gameField[2] == _gameField[0]) ||
                (_gameField[3] == _gameField[4] && _gameField[5] == _gameField[3]) ||
                (_gameField[6] == _gameField[7] && _gameField[8] == _gameField[6]) ||
                (_gameField[0] == _gameField[3] && _gameField[6] == _gameField[0]) ||
                (_gameField[1] == _gameField[4] && _gameField[7] == _gameField[1]) ||
                (_gameField[2] == _gameField[5] && _gameField[8] == _gameField[2]) ||
                (_gameField[0] == _gameField[4] && _gameField[8] == _gameField[0]) ||
                (_gameField[2] == _gameField[4] && _gameField[6] == _gameField[2]))
                return true;

            else return false;
        }
        private bool AddItem(int numCell, Items item)
        {
            if (!_gameField[numCell].Contains("O") && !_gameField[numCell].Contains("X"))
            {
                _gameField[numCell] = item.ToString();
                return true;
            }
            else return false;
        }
        private void DispScreen()
        {
            Console.Clear();
            Console.WriteLine($"{_gameField[0]}\t{_gameField[1]}\t{_gameField[2]}\n\n\n" +
                              $"{_gameField[3]}\t{_gameField[4]}\t{_gameField[5]}\n\n\n" +
                              $"{_gameField[6]}\t{_gameField[7]}\t{_gameField[8]}\n\n\n");
        }
        public void Step()
        {
            bool win;
            for (int i = 0; i < 9; i++)
            {
                DispScreen();
                int j = ((i % 2) == 0) ? 0 : 1;
                Console.WriteLine("Enter the index of field where put X or O");
                while (true)
                {
                    bool addItem = AddItem(int.Parse(Console.ReadLine()), (Items)j);
                    if (addItem) break;
                }
                win = CheckWin();
                if (win)
                {
                    DispScreen();
                    Console.WriteLine($"{_players[j]} WIN");
                    break;
                }
            }
            DispScreen();
            Console.WriteLine("Draw");
        }        
    }
}
