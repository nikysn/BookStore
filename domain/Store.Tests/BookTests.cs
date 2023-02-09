using System;
using Xunit;

namespace Store.Tests
{
    public class BookTests
    {
        [Fact]   // атрибут указывающий что это метод тестировани€
        public void IsIsbn_WithNull_ReturnFalse() 
        {
            bool actual = Book.IsIsbn(null);  //ѕровер€ем параметр метода на null

            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithBlankString_ReturnFalse()
        {
            bool actual = Book.IsIsbn("   ");  //ѕровер€ем параметр метода на наличие только пробелов

            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithInvalidIsbn_ReturnFalse()
        {
            bool actual = Book.IsIsbn("ISBN 123");  //ѕровер€ем параметр метода на правильность ISBN ( вроде как он должен состо€ть из 10 или 13 символов)

            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithIsbn10_ReturnTrue()
        {
            bool actual = Book.IsIsbn("IsBn 123-456-789 0");   //ѕровер€ем параметр метода на количество символов в строке

            Assert.True(actual);
        }

        [Fact]
        public void IsIsbn_WithIsbn13_ReturnTrue()
        {
            bool actual = Book.IsIsbn("IsBn 123-456-789 0123"); //ѕровер€ем параметр метода на количество символов в строке

            Assert.True(actual);
        }

        [Fact]
        public void IsIsbn_WithTrashStart_ReturnFalse()
        {
            bool actual = Book.IsIsbn("xxxIsBn 123-456-789 0123 yyy");  //ѕровер€ем параметр метода на то что начало строки должно начинатьс€ с ISBN, а после цыфр не должно быть букв

            Assert.False(actual);
        }
    }
}
