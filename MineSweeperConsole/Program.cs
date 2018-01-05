using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            StartNewGame();

            void StartNewGame()
            {
                var board = new Board(3, 3);
                bool breakFlag = false;
                do
                {
                    Console.WriteLine(board.Print());
                    var input = Console.ReadLine().Split(' ');
                    if (input.Length > 2)
                    {
                        var command = input[0].Trim();
                        var row = int.Parse(input[1].Trim());
                        var col = int.Parse(input[2].Trim());

                        switch (command)
                        {
                            case "o":
                                if (board.Open(row, col))
                                {
                                    board.Print();
                                }
                                else
                                {
                                    breakFlag = true;
                                }
                                break;
                            case "f":
                                board.Flag(row, col);
                                break;
                        }
                    }
                }
                while (!breakFlag);
            }
            Console.ReadKey();
        }
    }
}
    
