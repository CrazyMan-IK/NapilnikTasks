using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Cart : IReadOnlyCellStorage
    {
        private readonly CellStorage _storage = new CellStorage();
        private readonly Warehouse _warehouse;

        public IReadOnlyDictionary<Good, IReadOnlyCell> Cells => _storage.Cells;

        public Cart(Warehouse warehouse)
        {
            _warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse));
        }

        public void Add(Good good, int count)
        {
            if (!_warehouse.IsGoodAvailable(good, count))
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            _storage.Add(good, count);
        }

        public IReadOnlyOrder Order()
        {
            foreach (var cell in Cells.Values)
            {
                _warehouse.Take(cell.Good, cell.Count);
            }
            _storage.Clear();

            return new Order(new RandomString(16, _storage.Cells.GetHashCode()).ToString());
        }
    }
}
