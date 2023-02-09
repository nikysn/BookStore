using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Order
    {
        public int Id { get; }
        private List<OrderItem> _items;
        public int TotalCount
        {
            get { return _items.Sum(item => item.Count); }
        }

        public decimal TotalPrice
        {
            get { return Items.Sum(item => item.Price * item.Count); }
        }

        public IReadOnlyCollection<OrderItem> Items
        {
            get { return _items; }
        }
        public Order(int id, IEnumerable<OrderItem> items) 
        {
            if(items == null) throw new ArgumentNullException(nameof(items));

            Id = id;
            _items = new List<OrderItem>(items);
        }

        public void AddItem(Book book, int count)
        {
            if (book == null) throw new ArgumentNullException();

            var item = Items.SingleOrDefault(Item => Item.BookId == book.Id); //Тут мы проверяем и выбираем есть ли такая книга в списке наших заказов
                                                                             //В случае если метод SingleOrDefault не находит такого элемента,
                                                                             //вернет нам null 

            if(item == null) // Если такой книги в нашей корзине нет, то добавляем её
            {
                _items.Add(new OrderItem(book.Id, count,book.Price));
            }
            else // Если в нашей корзине уже есть такая книга, то просто добавляем кол-во (count) экземпляров этих книг 
            {
                _items.Remove(item);
                _items.Add(new OrderItem(book.Id, item.Count + count, book.Price));
            }
                                                                             
        }
    }
}
