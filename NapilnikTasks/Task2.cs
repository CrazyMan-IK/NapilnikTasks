using System;
using Xunit;
using Xunit.Abstractions;
using Task2;

namespace NapilnikTasks
{
    public class Task2
    {
        private readonly ITestOutputHelper _output = null;

        public Task2(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void CommonTest()
        {
            Good iPhone12 = new Good("IPhone 12");
            Good iPhone11 = new Good("IPhone 11");

            Warehouse warehouse = new Warehouse();

            Shop shop = new Shop(warehouse);

            warehouse.Delive(iPhone12, 10);
            warehouse.Delive(iPhone11, 1);

            //Вывод всех товаров на складе с их остатком
            ViewStorage(warehouse);

            Cart cart = shop.Cart();
            cart.Add(iPhone12, 4);
            Assert.Throws<ArgumentOutOfRangeException>(() => cart.Add(iPhone11, 3)); //при такой ситуации возникает ошибка так, как нет нужного количества товара на складе

            //Вывод всех товаров в корзине
            ViewStorage(cart);

            _output.WriteLine(cart.Order().Paylink);

            Assert.Throws<ArgumentOutOfRangeException>(() => cart.Add(iPhone12, 9)); //Ошибка, после заказа со склада убираются заказанные товары
        }

        private void ViewStorage(ICellStorage storage)
        {
            foreach (var cell in storage.Cells.Values)
            {
                _output.WriteLine(cell.ToString());
            }
        }
    }
}
