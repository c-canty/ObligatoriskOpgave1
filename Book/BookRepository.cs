using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book;

namespace Book
{
    public class BookRepository : IBookRepository
    {
        private static int _nextId = 1;
       
        private List<BookClass> _bookList = new List<BookClass>();

        public BookRepository()
        {
            _bookList.Add(new BookClass() { Id = _nextId++, Title = "Book1", Price = 100});
            _bookList.Add(new BookClass() { Id = _nextId++, Title = "Book2", Price = 200});
            _bookList.Add(new BookClass() { Id = _nextId++, Title = "Book3", Price = 300});
            _bookList.Add(new BookClass() { Id = _nextId++, Title = "Book4", Price = 400});
            _bookList.Add(new BookClass() { Id = _nextId++, Title = "Book5", Price = 500});
        }


        public BookClass Add(BookClass book)
        {
            book.Validate();
            book.Id = _nextId++;
            _bookList.Add(book);
            return book;           
        }

        public BookClass? Delete(int id)
        {
            BookClass? book = GetById(id);
            if (book == null)
            {
                return null;
            }
            _bookList.Remove(book);
            return book;
            
        }

        public IEnumerable<BookClass> Get(int? id, string? title, int? price, string? orderBy)
        {
            IEnumerable<BookClass> books = _bookList;
            if (id != null)
            {
                books = books.Where(b => b.Id == id);
            }
            if (title != null)
            {
                books = books.Where(b => b.Title == title);
            }
            if (price != null)
            {
                books = books.Where(b => b.Price == price);
            }

            if (orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "id":

                    case "id_asc":
                        books = books.OrderBy(b => b.Id);
                        break;

                    case "id_desc":
                        books = books.OrderByDescending(b => b.Id);
                        break;

                    case "title":

                    case "title_asc":
                        books = books.OrderBy(b => b.Title);
                        break;

                    case "title_desc":
                        books = books.OrderByDescending(b => b.Title);
                        break;

                    case "price":

                    case "price_asc":
                        books = books.OrderBy(b => b.Price);
                        break;

                    case "price_desc":
                        books = books.OrderByDescending(b => b.Price);
                        break;

                    default:
                        break;
                }

            }

            return books;

        }

        public BookClass? GetById(int id)
        {
            return _bookList.FirstOrDefault(b => b.Id == id);
        }

        public BookClass? Update(int id, BookClass book)
        {
            BookClass? bookToUpdate = GetById(id);
            if (bookToUpdate == null)
            {
                return null;
            }
            bookToUpdate.Title = book.Title;
            bookToUpdate.Price = book.Price;
            bookToUpdate.Validate();
            return bookToUpdate;
        }   
        
    }
}
