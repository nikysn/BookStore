using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Memory
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new List<Order>();
        public Order Create()
        {
            int nextId = _orders.Count + 1;
            var order = new Order(nextId, new OrderItem[0]);

            _orders.Add(order);
            return order;
        }

        public Order GetById(int id)
        {
            return _orders.Single(order => order.Id == id);  // Если у нас не будет найден заказ с таким id, то метод Single() выбросит исключение
                                                             // Если у нас будет 2 заказа с одинаковым id, то тоже выдаст исключение
        }

        public void Update(Order order)
        {
            ;
        }
    }
}
