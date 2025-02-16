namespace LibrarySystem.Domain.Entities
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ISBN { get; set; }
        public int? EditionNumber { get; set; }

        public Book(string title, string author, DateTime publicationDate, string isbn, int? editionNumber = null)
        {
            ValidateTitle(title);
            ValidateAuthor(author);
            ValidatePublicationDate(publicationDate);
            ValidateISBN(isbn);

            Title = title;
            Author = author;
            PublicationDate = publicationDate;
            ISBN = isbn;
            EditionNumber = editionNumber;
        }

        private static void ValidateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty", nameof(title));
        }

        private static void ValidateAuthor(string author)
        {
            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentException("Author cannot be empty", nameof(author));
        }

        private static void ValidatePublicationDate(DateTime publicationDate)
        {
            // TODO: inject datetime
            if (publicationDate > DateTime.UtcNow)
                throw new ArgumentException("Publication date cannot be in the future", nameof(publicationDate));
        }

        private static void ValidateISBN(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("ISBN cannot be empty", nameof(isbn));
        }
    }
}
