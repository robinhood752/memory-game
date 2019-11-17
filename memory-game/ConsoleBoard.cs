using System;
using System.Collections.Generic;

namespace memory_game
{

    public class ConsoleBoard<T> : IBoard<T> where T : IEquatable<T>
    {
        private Cell<T>[,] board;

        public int Height => board.GetLength(0);

        public int Width => board.GetLength(1);

        public ConsoleBoard(int height, int width, T[] data)
        {
            board = new Cell<T>[height, width];

            int row, column;

            for (int i = 0; i < height * width / 2; i++)
            {
                do
                {
                    row = StaticRandom.Next(width);
                    column = StaticRandom.Next(height);
                } while (board[row, column] != null);
                board[row, column] = new Cell<T>(data[i]);

                do
                {
                    row = StaticRandom.Next(width);
                    column = StaticRandom.Next(height);
                } while (board[row, column] != null);
                board[row, column] = new Cell<T>(data[i]);
            }
        }

        public void Draw()
        {
            Console.Write($"row\\col\t|\t");

            for (int j = 0; j < board.GetLength(1); j++)
            {
                Console.Write(j);
                Console.Write("\t|\t");
            }

            Console.WriteLine();

            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.Write($"{i}\t|\t");

                for (int j = 0; j < board.GetLength(1); j++)
                {
                    switch (board[i, j].Status)
                    {
                        case CellStatus.Closed: 
                            Console.Write("X");
                            break;
                        case CellStatus.Opened:
                            Console.Write(board[i, j].Value);
                            break;
                        case CellStatus.Paired:
                            Console.Write("0");
                            break;
                    }

                    Console.Write("\t|\t");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public bool IsSolved()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i,j].Status != CellStatus.Paired)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public Cell<T> GetCell(int row, int column)
        {
            return board[row, column];
        }
    }
}
