using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
           new Book(1,"ISBN 12312-31231","D. Knuth","Art of Programming","Discription",7.19m),
           new Book(2,"ISBN 12312-31232","M. Fowler","Refactoring","Discription",12.45m),
           new Book(3,"ISBN 12312-31233","B. Kernighan, D.Ritchie","C Programming Language","Discription",14.98m),
       };

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn)  // Выбирает из нашейго массива книг те которые мы хотели найти по isbn
                .ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string titlePart)
        {
            return books.Where(book => book.Author.Contains(titlePart)  // Выбирает из нашейго массива книг те которые мы хотели найти по Автору или Названию
            || book.Title.Contains(titlePart))
                .ToArray();
        }

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);  //Linq. перебираем массив и выбираем одну книгу(Single) у который будет совпадать id:
                                                         //- если id не будет найдет или найдет 2 таких id  то метод выдаст исключение
        }
    }
}
