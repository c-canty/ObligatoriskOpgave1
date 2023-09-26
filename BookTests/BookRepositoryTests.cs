using Book;

namespace BookTest
{
    [TestClass]
    public class BookRepositoryTests
    {                  

        [TestMethod]
        public void TestAdd()
        {
            BookRepository _bookRepository = new BookRepository();

            BookClass book = new BookClass(null, "Book6", 600);
            BookClass? addedBook = _bookRepository.Add(book);
            Assert.AreEqual(6, addedBook?.Id);
            Assert.AreEqual("Book6", addedBook?.Title);
            Assert.AreEqual(600, addedBook?.Price);
        }

        [TestMethod]
        public void TestDelete()
        {
            BookRepository _bookRepository = new BookRepository();

            BookClass? deletedBook = _bookRepository.Delete(1);
            Assert.AreEqual(1, deletedBook?.Id);
            Assert.AreEqual("Book1", deletedBook?.Title);
            Assert.AreEqual(100, deletedBook?.Price);
        }

        [TestMethod]
        public void TestDeleteWithNullBook()
        {
            BookRepository _bookRepository = new BookRepository();

            BookClass? deletedBook = _bookRepository.Delete(6);
            Assert.AreEqual(null, deletedBook);
        }

        [TestMethod]
        public void TestGetById()
        {
            BookRepository _bookRepository = new BookRepository();

            BookClass? book = _bookRepository.GetById(1);
            Assert.AreEqual(1, book?.Id);
            Assert.AreEqual("Book1", book?.Title);
            Assert.AreEqual(100, book?.Price);
        }

        [TestMethod]
        public void TestGetByIdWithNullBook()
        {
            BookRepository _bookRepository = new BookRepository();

            BookClass? book = _bookRepository.GetById(6);
            Assert.AreEqual(null, book);
        }

        [TestMethod]
        public void TestUpdate()
        {
            BookRepository _bookRepository = new BookRepository();

            BookClass book = new BookClass(1, "Book1", 600);
            BookClass? updatedBook = _bookRepository.Update(1,book);
            Assert.AreEqual(1, updatedBook?.Id);
            Assert.AreEqual("Book1", updatedBook?.Title);
            Assert.AreEqual(600, updatedBook?.Price);
        }

        [TestMethod]
        public void TestUpdateWithNullBook()
        {
            BookRepository _bookRepository = new BookRepository();

            BookClass book = new BookClass(6, "Book6", 600);
            BookClass? updatedBook = _bookRepository.Update(6, book);
            Assert.AreEqual(null, updatedBook);
        }

        [TestMethod]
        public void TestGetAll()
        {
            BookRepository _bookRepository = new BookRepository();

            IEnumerable<BookClass> books = _bookRepository.Get(null, null, null, null);
            Assert.AreEqual(5, books.Count());
        }

        [TestMethod]
        public void TestGetWithId()
        {
            BookRepository _bookRepository = new BookRepository();

            IEnumerable<BookClass> books = _bookRepository.Get(1, null, null, null);
            Assert.AreEqual(1, books.Count());
        }

        [TestMethod]
        public void TestGetWithTitle()
        {
            BookRepository _bookRepository = new BookRepository();

            IEnumerable<BookClass> books = _bookRepository.Get(null, "Book1", null, null);
            Assert.AreEqual(1, books.Count());
        }

        [TestMethod]
        public void TestGetWithPrice()
        {
            BookRepository _bookRepository = new BookRepository();

            IEnumerable<BookClass> books = _bookRepository.Get(null, null, 100, null);
            Assert.AreEqual(1, books.Count());
        }

        [TestMethod]
        public void TestGetWithOrderBy()
        {
            BookRepository _bookRepository = new BookRepository();

            IEnumerable<BookClass> books = _bookRepository.Get(null, null, null, "Id");
            Assert.AreEqual(5, books.Count());
            Assert.AreEqual(1, books.ElementAt(0).Id);

            books = _bookRepository.Get(null, null, null, "Id_desc");
            Assert.AreEqual(5, books.Count());
            Assert.AreEqual(5, books.ElementAt(0).Id);

            books = _bookRepository.Get(null, null, null, "Title");
            Assert.AreEqual(5, books.Count());
            Assert.AreEqual(1, books.ElementAt(0).Id);

            books = _bookRepository.Get(null, null, null, "Title_desc");
            Assert.AreEqual(5, books.Count());
            Assert.AreEqual(5, books.ElementAt(0).Id);

            books = _bookRepository.Get(null, null, null, "Price");
            Assert.AreEqual(5, books.Count());
            Assert.AreEqual(1, books.ElementAt(0).Id);

            books = _bookRepository.Get(null, null, null, "Price_desc");
            Assert.AreEqual(5, books.Count());
            Assert.AreEqual(5, books.ElementAt(0).Id);

            books = _bookRepository.Get(null, null, null, "Id_asc");
            Assert.AreEqual(5, books.Count());
            Assert.AreEqual(1, books.ElementAt(0).Id);

            books = _bookRepository.Get(null, null, null, "invalid_input");
            Assert.AreEqual(5, books.Count());
            Assert.AreEqual(1, books.ElementAt(0).Id);
        }
    }
}
