using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class RandomString
    {
        private const string _Chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private string _str = "";
        private readonly Random _random;

        public RandomString(int length) : this(length, DateTime.Now.Millisecond)
        {

        }

        public RandomString(int length, int seed)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            _random = new Random(seed);
            Length = length;
        }

        public int Length { get; private set; }

        public override string ToString()
        {
            if (_str == "")
            {
                for (int i = 0; i < Length; i++)
                {
                    var charIndex = _random.Next(0, _Chars.Length);
                    _str += _Chars[charIndex];
                }
            }

            return _str;
        }
    }
}
