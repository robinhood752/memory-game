using System;
using System.Collections;

namespace memory_game
{
    public class Round<T> where T : IEquatable<T>
    {
        private int row1, column1, row2, column2;

        private readonly Queue players = new Queue();

        private readonly IBoard<T> board;

        public Round(Player[] players, IBoard<T> board)
        {
            foreach (var player in players)
                this.players.Enqueue(player);

            this.board = board;
        }

        public Player Play()
        {
            while (!board.IsSolved())
            {
                var player = (Player)players.Peek();

                board.Draw();

                /// TODO: Comparison for n cells instead
                OpenCell(player.Name, "first", out row1, out column1);
                OpenCell(player.Name, "second", out row2, out column2);

                // wait to let players see both cells
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();

                if (board.GetCell(row1, column1).Equals(board.GetCell(row2, column2)))
                {
                    board.GetCell(row1, column1).Status = CellStatus.Paired;
                    board.GetCell(row2, column2).Status = CellStatus.Paired;
                    player.Score++;
                }
                else
                {
                    board.GetCell(row1, column1).Status = CellStatus.Closed;
                    board.GetCell(row2, column2).Status = CellStatus.Closed;
                    players.Enqueue(players.Dequeue()); // rotate players
                }

                Console.Clear();
            }

            Player winner = (Player)players.Peek();

            foreach (Player player in players)
            {
                winner = winner.Score > player.Score ? winner : player;
            }

            return winner;
        }

        private void OpenCell(string playerName, string cardName, out int row, out int column)
        {
            do
            {
                GetCoordinates(playerName, cardName, out row, out column);
            } while (row < 0 || column < 0
                || row > board.Height || column > board.Width
                || board.GetCell(row, column).Status != CellStatus.Closed);
            Console.Clear();

            board.GetCell(row, column).Status = CellStatus.Opened;
            board.Draw();
        }

        private void GetCoordinates(string playerName, string cardName, out int row, out int column)
        {
            Console.WriteLine($"{playerName}, choose {cardName} card row (zero based)");
            while (!int.TryParse(Console.ReadLine(), out row)) ;

            Console.WriteLine($"{playerName}, choose {cardName} card column (zero based)");
            while (!int.TryParse(Console.ReadLine(), out column)) ;
        }
    }
}
