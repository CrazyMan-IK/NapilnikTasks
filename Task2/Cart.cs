using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Cart : IReadOnlyGoodStorage
    {
        private readonly GoodStorage _storage = new GoodStorage();
        private readonly Warehouse _warehouse;

        public IReadOnlyDictionary<Good, int> Goods => _storage.Goods;

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
            foreach (var (good, count) in Goods)
            {
                _warehouse.Take(good, count);
            }
            _storage.Clear();

            return new Order(new RandomString(16, _storage.Goods.GetHashCode()).ToString());
        }
    }
}
