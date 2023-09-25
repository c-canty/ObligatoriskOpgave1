namespace Book
    public class Book
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public int? Price { get; set; }

        public Book()
        {

        }

        public Book(int? id, string? title, int? price)
        {
            Id = id;
            Title = title;
            Price = price;
        }

        public void ValidateTitle()
        {
            if (Title == null)
            {
                throw new ArgumentNullException("Book Title cannot be null");
            }
            if (Title.Length < 3)
            {
                throw new ArgumentException("Book Title must be at least 3 characters long");
            }
        }
        public void ValidatePrice()
        {
            if (Price == null)
            {
                throw new ArgumentNullException("Book Price cannot be null");
            }
            if (Price <= 0 || Price >= 1200)
            {
                throw new ArgumentOutOfRangeException("Price must be between 1 and 1200");
            }
        }
        public void Validate()
        {
            ValidateTitle();
            ValidatePrice();
        }

        public override string ToString()
        {
            return $"Book: {Id}, {Title}, {Price}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false; // if obj is null
            if (obj.GetType() != this.GetType()) return false; // if obj is not a Book
            Book book = (Book)obj; // cast obj to Book
            return (this.Id == book.Id) && (this.Title == book.Title) && (this.Price == book.Price); // compare the values of the two books
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Title, Price); // combine the hashcodes of the three values
        }
    }
}