using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Cell : IReadOnlyCell
    {
        public Cell(Good good, int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            Good = good ?? throw new ArgumentNullException(nameof(good));
            Count = count;
        }

        public Good Good { get; private set; }
        public int Count { get; private set; } = 0;

        public void Add(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            Count += count;
        }

        public void Subtract(int count)
        {
            if (Count <= 0 || Count < count)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            Count -= count;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Good, Count);
        }

        public override string ToString()
        {
            return $"{Good.Name}: {Count}";
        }
    }
}
