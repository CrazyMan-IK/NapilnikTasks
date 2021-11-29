using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class CellStorage : ICellStorage
    {
        private Dictionary<Good, Cell> _cells = new Dictionary<Good, Cell>();

        public IReadOnlyDictionary<Good, IReadOnlyCell> Cells => _cells.ToDictionary<KeyValuePair<Good, Cell>, Good, IReadOnlyCell>(x => x.Key, x => x.Value);

        public void Add(Good good, int count)
        {
            if (good == null)
            {
                throw new ArgumentNullException(nameof(good));
            }
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (!_cells.TryGetValue(good, out var cell))
            {
                cell = new Cell(good, 0);
                _cells[good] = cell;
            }

            cell.Add(count);
        }

        public void Subtract(Good good, int count)
        {
            if (good == null)
            {
                throw new ArgumentNullException(nameof(good));
            }
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (!_cells.TryGetValue(good, out var cell))
            {
                throw new InvalidOperationException();
            }

            if (cell.Count < count)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            cell.Subtract(count);
        }

        public void Clear()
        {
            _cells.Clear();
        }
    }
}
