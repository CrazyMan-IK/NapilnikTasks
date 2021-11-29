using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Good
    {
        public string Name { get; private set; }

        public Good(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}
