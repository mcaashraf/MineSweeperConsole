using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperConsole
{
    public class Board
    {
        public Tile[,] Grid { get; private set; }
        public string[,] defaultMatrix;
        public Board(int rows, int cols)
        {

            SetBoardDimensions(rows, cols);

        }
        public bool CheckForMine(int row, int col)
        {
            defaultMatrix = GetDefaultMatrix();
            var minechar = defaultMatrix[row, col];
            return (minechar == "m") ? true : false;
        }
        public string[,] GetDefaultMatrix()
        {
            string[,] matrix = new string[3, 3];
            int i, j;
            for (i = 0; i < 3; i++)

                for (j = 0; j < 3; j++)
                {
                    if ((i == 0) && (j == 2) || (i == 1) && (j == 1))
                    {
                        matrix[i, j] = "m";

                    }
                    else matrix[i, j] = "x";
                }

            return matrix;

        }



        private void SetBoardDimensions(int rows, int cols)
        {
            Grid = new Tile[rows, cols];
            for (int r = 0; r < rows; ++r)
            {
                for (int c = 0; c < cols; ++c)
                {
                    Grid[r, c] = new Tile();
                }
            }

        }


        private bool IsTileOpen(int r, int c)
        {
            return r >= 0 && c >= 0;
        }
        public bool Open(int row, int col)
        {
            if (SteppedOnMine(row, col)) return false;
            var open = Grid[row, col].Open();
            if (!open) return false;
            {
                if (IsTileOpen(row, col))
                    Grid[row, col].Open();


            }
            return true;
        }

        private bool SteppedOnMine(int row, int col)
        {
            if (CheckForMine(row, col))
            {
                Grid[row, col].Mine = true;
                Console.WriteLine("Oops! You stepped on a mine. Game Over");
                return true;
            }
            return false;
        }

        public void Flag(int row, int col)
        {
            Grid[row, col].SetFlag();
        }

        public int Rows
        {
            get { return Grid.GetLength(0); }
        }

        public int Cols
        {
            get { return Grid.GetLength(1); }
        }

        public string Print()
        {
            string board = "";
            for (int row = 0; row < Rows; ++row)
            {
                for (int col = 0; col < Cols; ++col)
                {
                    switch (Grid[row, col].Status)
                    {
                        case Tile.TileStatus.MINE:
                            board += 'm';
                            break;
                        case Tile.TileStatus.FLAGGED:
                            board += 'f';
                            break;
                        case Tile.TileStatus.OPEN:
                            board += 'o';
                            break;
                        case Tile.TileStatus.CLOSED:
                            board += 'x';
                            break;
                    }
                    if (col != Cols - 1)
                        board += " ";
                }
                board += Environment.NewLine;
            }
            return board;
        }

    }
}
