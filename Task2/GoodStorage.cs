using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class GoodStorage : IReadOnlyGoodStorage
    {
        private readonly Dictionary<Good, int> _goods = new Dictionary<Good, int>();

        public IReadOnlyDictionary<Good, int> Goods => _goods;

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

            if (!_goods.TryGetValue(good, out var cell))
            {
                cell = 0;
                _goods[good] = cell;
            }

            _goods[good] = cell + count;
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

            if (!_goods.TryGetValue(good, out var cell))
            {
                throw new InvalidOperationException();
            }

            if (cell < count)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            _goods[good] = cell - count;
        }

        public void Clear()
        {
            _goods.Clear();
        }
    }
}
