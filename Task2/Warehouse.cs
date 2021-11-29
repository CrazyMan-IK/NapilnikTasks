using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Warehouse : ICellStorage
    {
        private readonly CellStorage _storage = new CellStorage();

        public IReadOnlyDictionary<Good, IReadOnlyCell> Cells => _storage.Cells;

        public void Delive(Good good, int count)
        {
            _storage.Add(good, count);
        }

        public void Take(Good good, int count)
        {
            _storage.Subtract(good, count);
        }

        public bool IsGoodAvailable(Good good, int count)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            var cell = _storage.Cells[good];
            
            return cell != null && cell.Count >= count;
        }
    }
}
