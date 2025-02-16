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
            throw new NotImplementedException();
        }
    }
}
