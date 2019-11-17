using System;

namespace memory_game
{
    public interface IBoard<T> where T : IEquatable<T>
    {
        public int Height { get; }

        public int Width { get; }

        public void Draw();

        public bool IsSolved();

        public Cell<T> GetCell(int row, int column);
    }
}
