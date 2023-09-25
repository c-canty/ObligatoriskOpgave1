using Book;

namespace BookTest
{
    [TestClass]
    public class BookClassTests
    {
        BookClass book = new BookClass(1, "Book1", 100);
        BookClass bookNoTitle = new BookClass(1, null, 100);
        BookClass bookShortTitle = new BookClass(1, "Bo", 100);
        BookClass bookNoPrice = new BookClass(1, "Book1", null);
        BookClass bookZeroPrice = new BookClass(1, "Book1", 0);
        BookClass bookNegativePrice = new BookClass(1, "Book1", -1);
        BookClass bookHighPrice = new BookClass(1, "Book1", 1201);
        BookClass bookNoId = new BookClass(null, "Book1", 100);


        [TestMethod]
        public void TestBookConstructor()
        {
            Assert.AreEqual(1, book.Id);
            Assert.AreEqual("Book1", book.Title);
            Assert.AreEqual(100, book.Price);
        }

        [TestMethod]
        public void TestNullValuesInConstructor()
        {
            Assert.AreEqual(null, bookNoTitle.Title);
            Assert.AreEqual(null, bookNoPrice.Price);
            Assert.AreEqual(null, bookNoId.Id);
        }

        [TestMethod]
        public void TestValidateTitle()
        {
            book.ValidateTitle();
            Assert.ThrowsException<ArgumentNullException>(() => bookNoTitle.ValidateTitle());
            Assert.ThrowsException<ArgumentException>(() => bookShortTitle.ValidateTitle());
        }

        [TestMethod]
        public void TestValidatePrice()
        {
            book.ValidatePrice();
            Assert.ThrowsException<ArgumentNullException>(() => bookNoPrice.ValidatePrice());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookZeroPrice.ValidatePrice());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookNegativePrice.ValidatePrice());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookHighPrice.ValidatePrice());
        }

        [TestMethod]
        public void TestValidate()
        {
            book.Validate();
            Assert.ThrowsException<ArgumentNullException>(() => bookNoTitle.Validate());
            Assert.ThrowsException<ArgumentException>(() => bookShortTitle.Validate());
            Assert.ThrowsException<ArgumentNullException>(() => bookNoPrice.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookZeroPrice.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookNegativePrice.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookHighPrice.Validate());
        }

        [TestMethod]
        public void TestToString()
        {
            Assert.AreEqual("Book: 1, Book1, 100", book.ToString());
        }

        [TestMethod]
        public void TestEquals()
        {
            Assert.IsTrue(book.Equals(book));
            Assert.IsFalse(book.Equals(bookNoTitle));
            Assert.IsFalse(book.Equals(bookNoPrice));
            Assert.IsFalse(book.Equals(bookNoId));
            Assert.IsFalse(book.Equals(bookShortTitle));
            Assert.IsFalse(book.Equals(bookZeroPrice));
            Assert.IsFalse(book.Equals(bookNegativePrice));
            Assert.IsFalse(book.Equals(bookHighPrice));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            BookClass book2 = new BookClass(1, "Book1", 100);
            Assert.AreEqual(book.GetHashCode(), book2.GetHashCode());
            Assert.AreNotEqual(book.GetHashCode(), bookNoTitle.GetHashCode());
        }

        [TestMethod]
        public void TestDefaultConstructor()
        {
            BookClass book = new BookClass();
            Assert.AreEqual(null, book.Id);
            Assert.AreEqual(null, book.Title);
            Assert.AreEqual(null, book.Price);
        }

    }
}