using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Order : IReadOnlyOrder
    {
        public Order(string paylink)
        {
            Paylink = paylink;
        }

        public string Paylink { get; private set; }
    }
}
