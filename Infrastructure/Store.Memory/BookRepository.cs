using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        public Book[] GetAllByTitle(string titlePart)
        {
            throw new NotImplementedException();
        }
    }
}
