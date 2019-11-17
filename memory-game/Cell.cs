using System;

namespace memory_game
{
    public class Cell<T> : IEquatable<Cell<T>>
    {
        public IEquatable<T> Value { get; set; }

        public CellStatus Status { get; set; }

        public Cell(IEquatable<T> value)
        {
            Value = value;
            Status = CellStatus.Closed;
        }

        public bool Equals(Cell<T> other)
        {
            return Value.Equals(other.Value);
        }
    }

    public enum CellStatus
    {
        Closed,
        Opened,
        Paired
    }
}
