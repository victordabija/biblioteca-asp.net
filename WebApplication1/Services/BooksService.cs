using WebApplication1.Models;

namespace WebApplication1.Services;

public class BooksService
{
    static IList<Book> _books = new List<Book>
    {
        new Book
        {
            Id = 1,
            Title = "1984",
            Author = "George Orwell",
            PagesCount = 328,
            EditYear = "1949"
        },
        new Book
        {
            Id = 2,
            Title = "To Kill a Mockingbird",
            Author = "Harper Lee",
            PagesCount = 281,
            EditYear = "1960"
        },
        new Book
        {
            Id = 3,
            Title = "Pride and Prejudice",
            Author = "Jane Austen",
            PagesCount = 279,
            EditYear = "1813"
        },
        new Book
        {
            Id = 4,
            Title = "The Great Gatsby",
            Author = "F. Scott Fitzgerald",
            PagesCount = 180,
            EditYear = "1925"
        },
        new Book
        {
            Id = 5,
            Title = "Moby Dick",
            Author = "Herman Melville",
            PagesCount = 635,
            EditYear = "1851"
        },
        new Book
        {
            Id = 6,
            Title = "The Catcher in the Rye",
            Author = "J.D. Salinger",
            PagesCount = 277,
            EditYear = "1951"
        },
        new Book
        {
            Id = 7,
            Title = "Brave New World",
            Author = "Aldous Huxley",
            PagesCount = 268,
            EditYear = "1932"
        },
        new Book
        {
            Id = 8,
            Title = "War and Peace",
            Author = "Leo Tolstoy",
            PagesCount = 1225,
            EditYear = "1869"
        },
        new Book
        {
            Id = 9,
            Title = "Crime and Punishment",
            Author = "Fyodor Dostoevsky",
            PagesCount = 671,
            EditYear = "1866"
        },
        new Book
        {
            Id = 10,
            Title = "The Hobbit",
            Author = "J.R.R. Tolkien",
            PagesCount = 310,
            EditYear = "1937"
        }
    };

    public IList<Book> GetAllBooks()
    {
        return _books;
    }

    public Book FindById(uint id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);

        if (book == null)
        {
            throw new Exception("Book not found");
        }

        return book;
    }

    public Book FindByObject(Book book)
    {
        var foundedBook = _books.FirstOrDefault(b => b.Id == book.Id);

        if (foundedBook == null)
        {
            throw new Exception("Book not found");
        }

        return foundedBook;
    }

    public void DeleteById(uint id)
    {
        _books.Remove(FindById(id));
    }

    public void Update(Book updatedBook)
    {
        Book book = FindByObject(updatedBook);

        book.Title = updatedBook.Title;
        book.Author = updatedBook.Author;
        book.PagesCount = updatedBook.PagesCount;
        book.EditYear = updatedBook.EditYear;
    }

    public void Create(Book book)
    {
        book.Id = _books.Last().Id + 1;

        _books.Add(book);
    }
}