using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Order
    {
        public int Id { get; }
        private List<OrderItem> _items;
        public int TotalCount => _items.Sum(item => item.Count);
        public decimal TotalPrice => Items.Sum(item => item.Price * item.Count);
       
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

        public OrderItem GetItem(int bookId) // возвращает книгу по ID
        {
            int index = _items.FindIndex(item => item.BookId == bookId); // ищем индекс книги в нашей корзине
            if (index == -1) // если id не найдет то вызываем ошибку
                throw new InvalidOperationException("Book not found");

            return _items[index]; // возвращаем книгу которую искали
        }

        public void AddOrUpdateItem(Book book, int count)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            int index = _items.FindIndex(item => item.BookId == book.Id); // Проверяем есть ли такая книга у нас в заказе
            if (index == -1) // если нет 
                _items.Add(new OrderItem(book.Id, count,book.Price)); // то добавляем
            else
                _items[index].Count += count; // если уже есть, то просто добавляем кол-во
        }

       public void RemoveItem(int bookId)
        {
            int index = _items.FindIndex(item => item.BookId == bookId);

            if(index == -1)
                ThrowBookException("Order does not contain specified item. ", bookId);

            _items.RemoveAt(index);
        }

        private void ThrowBookException(string message, int bookId)
        {
            var exception = new InvalidOperationException(message);

            exception.Data[("BookId")] = bookId;

            throw exception;
        }
    }
}
