using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book;

namespace Book
{
    public interface IBookRepository
    {
        BookClass Add(BookClass book);

        BookClass? Update(int id, BookClass book);

        BookClass? Delete(int id);

        BookClass? GetById(int id);

        IEnumerable<BookClass> Get(int? id, string? title, int? price);
    }
}
