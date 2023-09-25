using BookLibrary;

namespace BookTest
{
    [TestClass]
    public class BookClassTests
    {
        Book book = new Book(1, "Book1", 100);
        Book bookNoTitle = new Book(1, null, 100);
        Book bookShortTitle = new Book(1, "Bo", 100);
        Book bookNoPrice = new Book(1, "Book1", null);
        Book bookZeroPrice = new Book(1, "Book1", 0);
        Book bookNegativePrice = new Book(1, "Book1", -1);
        Book bookHighPrice = new Book(1, "Book1", 1201);
        Book bookNoId = new Book(null, "Book1", 100);


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
            Book book2 = new Book(1, "Book1", 100);
            Assert.AreEqual(book.GetHashCode(), book2.GetHashCode());
            Assert.AreNotEqual(book.GetHashCode(), bookNoTitle.GetHashCode());
        }

    }
}