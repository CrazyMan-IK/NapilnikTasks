using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Warehouse : IReadOnlyGoodStorage
    {
        private readonly GoodStorage _storage = new GoodStorage();

        public IReadOnlyDictionary<Good, int> Goods => _storage.Goods;

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

            return _storage.Goods.TryGetValue(good, out var goodCount) && goodCount >= count;
        }
    }
}
