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
        Book Add(Book book);
    }
}
