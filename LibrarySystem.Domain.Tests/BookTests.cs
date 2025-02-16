using LibrarySystem.Domain.Entities;

namespace LibrarySystem.Domain.Tests;

public class BookTests
{
    [Fact]
    public void CreateBook_WithValidData_ShouldSucceed()
    {
        // Arrange
        var title = "Clean Code";
        var author = "Robert Martin";
        var publicationDate = new DateTime(2008, 8, 1);
        var isbn = "9780132350884";
        var editionNumber = 1;

        // Act
        var book = new Book(title, author, publicationDate, isbn, editionNumber);

        // Assert
        Assert.Equal(title, book.Title);
        Assert.Equal(author, book.Author);
        Assert.Equal(publicationDate, book.PublicationDate);
        Assert.Equal(isbn, book.ISBN);
        Assert.Equal(editionNumber, book.EditionNumber);
    }

    [Theory]
    [InlineData("", "Author", "ISBN")]
    [InlineData("Title", "", "ISBN")]
    [InlineData("Title", "Author", "")]
    public void CreateBook_WithInvalidData_ShouldThrowArgumentException(string title, string author, string isbn)
    {
        // Arrange
        var publicationDate = DateTime.UtcNow;

        // Act
        var createBook = () => new Book(title, author, publicationDate, isbn);

        // Act & Assert
        Assert.Throws<ArgumentException>(createBook);
    }

    [Fact]
    public void CreateBook_WithFuturePublicationDate_ShouldThrowArgumentException()
    {
        // Arrange
        var futureDate = DateTime.UtcNow.AddDays(1);
        
        // Act
        var createBook = () => new Book("Title", "Author", futureDate, "ISBN");

        // Assert
        Assert.Throws<ArgumentException>(createBook);
    }
}
