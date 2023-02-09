using Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Store.Tests
{
    public class OrderTests
    {
        [Fact]
        public void Order_WithNullItems_ThrowArgumentNullException()  // Проверяем второй элемент конструктора Order на null
        {
            Assert.Throws<ArgumentNullException>(() => new Order(1, null));
        }

        [Fact]
        public void TotalCount_WithEmptyItems_ReturnsZero()  // Получается если у нас корзина пустая (new OrderItem[0]),
                                                             // то order.TotalCount тоже должен быть равен нулю
        {
            var order = new Order(1,new OrderItem[0]);

            Assert.Equal(0, order.TotalCount);
        }

        [Fact]
        public void TotalPrice_WithEmptyItems_ReturnsZero()  // Получается если у нас корзина пустая (new OrderItem[0]),
                                                             // то order.TotalPrice тоже должен быть равен нулю
        {
            var order = new Order(1, new OrderItem[0]);

            Assert.Equal(0m, order.TotalPrice); 
        }

        [Fact]
        public void TotalCount_WithNonEmptyItems_CalculatesTotalCount() // Проверяем автосвойство order.TotalCount
        {
            var order = new Order(1, new[] // общий заказ
            {
              new OrderItem(1, 3, 10m), // первый раз положили в корзину 3 книги с общей ценой 10
              new OrderItem(2,5,100m), // второй раз положили в корзину 5 книг на сумму 100
            });
            Assert.Equal(3+5, order.TotalCount); // и тут мы проверяем общий заказ на кол-во книг в корзине. т.е. автосвойство order.TotalCount
        }

        [Fact]
        public void TotalPrice_WithNonEmptyItems_CalculatesTotalCount() // Проверяем автосвойство order.TotalPrice
        {
            var order = new Order(1, new[] // общий заказ
            {
              new OrderItem(1, 3, 10m), // первый раз положили в корзину 3 книги с общей ценой 10
              new OrderItem(2,5,100m), // второй раз положили в корзину 5 книг на сумму 100
            });
            Assert.Equal(3 * 10m + 5 * 100m, order.TotalPrice); // и тут мы проверяем общий заказ на общую сумму в корзине. т.е. автосвойство order.TotalPrice
        }

        //Эти тесты пробую писать сам
        [Fact]
        public void AddItem_WithNullBooks_ThrowArgumentNullException() // Проверяем метод AddItem, на то что в его параметре вместо book будет null
        {
            var order = new Order(1, new[] // общий заказ
           {
              new OrderItem(1, 3, 10m), //  положили в корзину 3 книги с общей ценой 10
              new OrderItem(2,5,100m), //  положили в корзину 5 книг на сумму 100
            });

            Assert.Throws<ArgumentNullException>(() => order.AddItem(null, 1)); 
        }

        [Fact]
        public void AddItem_WithNullItems_AddItemToOrder() // Проверяем метод AddItem, на добавление книги в корзину,
                                                           // если такой книги не было в корзине
        {
            var order = new Order(1, new[] // общий заказ
           {
              new OrderItem(1, 3, 10m), //  положили в корзину 3 книги с общей ценой 10
              new OrderItem(2,5,100m), //  положили в корзину 5 книг на сумму 100
            });

            Book book = new Book(3, "", "", "", "", 0m);
            order.AddItem(book, 1);

            var item = order.Items.SingleOrDefault(Item => Item.BookId == book.Id);
            var itemlist = order.Items.ToList();

            Assert.Equal(itemlist[2] , item);
        }

        [Fact]
        public void AddItem_WithItems_AddItemToOrder() // Проверяем метод AddItem, на добавление книги в корзину,
                                                           // если такой книги не было в корзине
        {
            var order = new Order(1, new[] // общий заказ
           {
              new OrderItem(1, 3, 10m), //  положили в корзину 3 книги с общей ценой 10
              new OrderItem(2,5,100m), //  положили в корзину 5 книг на сумму 100
            });

            Book book = new Book(1, "", "", "", "", 10m);
            order.AddItem(book, 1);

            Assert.Equal(9, order.TotalCount);
        }
    }
}
