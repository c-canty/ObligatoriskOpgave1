using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book;

namespace Book
{
    internal class BookRepository : IBookRepository
    {
        private static int _nextId = 1;


        private List<BookClass> books = new List<BookClass>()
        {
            new BookClass(_nextId, "Book1", 100),

            new BookClass(null, "Book2", 200),
            new BookClass(null, "Book3", 300),
            new BookClass(null, "Book4", 400),
            new BookClass(null, "Book5", 500),           
        };





        public BookClass Add(BookClass book)
        {
            throw new NotImplementedException();
        }

        public BookClass? Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookClass> Get(int? id, string? title, int? price)
        {
            throw new NotImplementedException();
        }

        public BookClass? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public BookClass? Update(int id, BookClass book)
        {
            throw new NotImplementedException();
        }
    }
}
