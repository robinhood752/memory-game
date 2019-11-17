using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memory_game
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                int boardSize;

                char[] boardValues;

                #region Define board size
                do
                {
                    Console.WriteLine("Enter an even number between 2 and 8");
                    while (!int.TryParse(Console.ReadLine(), out boardSize)) ;
                } while (boardSize <= 0 || boardSize > 8 || boardSize % 2 != 0);
                Console.Clear();
                #endregion

                #region Initiate board values
                boardValues = new char[boardSize * boardSize / 2];

                char value = 'A';
                for (int i = 0; i < boardValues.Length; i++, value = char.IsUpper(++value) ? value : 'a')
                {
                    boardValues[i] = value;
                }
                #endregion

                Round<char> round = new Round<char>(
                    new Player[]
                    {
                        new Player("Player 1", 0),
                        new Player("Player 2", 0)
                    },
                    new ConsoleBoard<char>(boardSize, boardSize, boardValues));

                Console.WriteLine($"And the winner is... {round.Play().Name}\n");
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
