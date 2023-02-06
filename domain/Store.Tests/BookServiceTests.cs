using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Store.Tests
{
    public class BookServiceTests
    {
        [Fact]
        public void GetAllByQuery_WithIsbn_CallsGetAllByIsbn()
        {
            var bookRepositoryStun = new Mock<IBookRepository>();

            bookRepositoryStun.Setup(x => x.GetAllByIsbn("Ritchie"))   // тут заглушка которая создает массив и возвращает его используя метод GetAllByIsbn
                .Returns(new[] { new Book(1, "", "", "", "", 0m) });

            bookRepositoryStun.Setup(x => x.GetAllByTitleOrAuthor("Ritchie")) // Вторая заглушка которая создает массив и возвращает его используя метод GetAllByTitleOrAuthor
                .Returns(new[] { new Book(2, "", "", "", "", 0m) });

            var bookService = new BookService(bookRepositoryStun.Object);
            var author = "Ritchie";

            var actual = bookService.GetAllByQuery(author);

            Assert.Collection(actual, book => Assert.Equal(2, book.Id)); //Строка Assert.Collection(actual, book => Assert.Equal(1, book.Id));
                                                                         //проверяет, имеют ли все элементы в фактической коллекции свойство Id, равное 1.
                                                                         //Метод Assert.Collection принимает два параметра: проверяемую коллекцию и действие,
                                                                         //выполняемое над каждым элементом коллекции.
                                                                         //Второй параметр, book => Assert.Equal(1, book.Id), представляет собой лямбда-выражение,
                                                                         //которое выполняет проверку Assert.Equal(1, book.Id) для каждого элемента коллекции и проверяет,
                                                                         //соответствует ли свойство Id элемента каждый элемент равен 1.
        }


        [Fact]
        public void GetAllByQuery_WithAuthor_CallsGetAllByTitleOrAuthor()
        {
            var bookRepositoryStun = new Mock<IBookRepository>();

            bookRepositoryStun.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))   // тут заглушка которая создает массив и возвращает его используя метод GetAllByIsbn
                .Returns(new[] { new Book(1, "", "", "", "", 0m) });

            bookRepositoryStun.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>())) // Вторая заглушка которая создает массив и возвращает его используя метод GetAllByTitleOrAuthor
                .Returns(new[] { new Book(2, "", "", "","",0m) });

            var bookService = new BookService(bookRepositoryStun.Object);
            var invalidIsbn = "12345-67890";

            var actual = bookService.GetAllByQuery(invalidIsbn);

            Assert.Collection(actual, book => Assert.Equal(2, book.Id)); //Строка Assert.Collection(actual, book => Assert.Equal(1, book.Id));
                                                                         //проверяет, имеют ли все элементы в фактической коллекции свойство Id, равное 1.
                                                                         //Метод Assert.Collection принимает два параметра: проверяемую коллекцию и действие,
                                                                         //выполняемое над каждым элементом коллекции.
                                                                         //Второй параметр, book => Assert.Equal(1, book.Id), представляет собой лямбда-выражение,
                                                                         //которое выполняет проверку Assert.Equal(1, book.Id) для каждого элемента коллекции и проверяет,
                                                                         //соответствует ли свойство Id элемента каждый элемент равен 1.
        }
    }
}
