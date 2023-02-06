using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Store
{
    public class Book
    {
        public int Id { get; }
        public string Isbn { get; }
        public string Author { get; }
        public string Title { get; }
        public string Description { get; }
        public decimal Price { get; }

        public Book(int id,string isbn, string author, string title, string description, decimal price)
        {
            Id = id;
            Isbn = isbn;
            Author = author;
            Title = title;
            Description= description;
            Price = price;
        }
        internal static bool IsIsbn(string s)
        {
            if(s == null)
              return false;

            s = s.Replace("-","")    //Replace - метод для строк который заменяет 1 параметр на второй.
                .Replace(" ","")     // Т.е выбрасывает из строки всё что нам не нужно, в данном случае дефисы и пробелы
                .ToUpper();          // ToUpper - переводит все к верхнему регистру т.е. в заглавные буквы

            return Regex.IsMatch(s, @"^ISBN\d{10}(\d{3})?$");    //Эта строка кода использует метод IsMatch класса Regex, чтобы проверить,
                                                                 //соответствует ли заданная строка s регулярному выражению "ISBN\d{10}".
                                                                 //Регулярное выражение "ISBN\d{10}" ищет строку "ISBN", за которой следуют ровно 10 или 13 ((\d{3}?)) цифр .
                                                                 //Если строка s соответствует этому шаблону, IsMatch вернет значение true, в противном случае — значение false.
                                                                 //^ - означает что начало записи должно совпадать с началом строки (т.е. ISBN),
                                                                 //а $ в конце что после последней цыфры точно должен быть конец строки
        }
    }
}
