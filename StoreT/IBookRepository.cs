using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public interface IBookRepository
    {
        Book[] GetAllByIsbn(string isbn); //Получаем массив книг по ISBN
        Book[] GetAllByTitleOrAuthor(string titlePartOrAuthor); // Получаем массив книг по названию или автору
        Book GetById(int id); // получаем одну книгу по Id
        Book[] GetAllByIds(IEnumerable<int> bookIds);
    }
}
