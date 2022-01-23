namespace libraryAPI.Db;

// creating the Book Schema
public record Book
{
    public int bookId {get; set;}
    public string ? name {get; set;}
    public bool IsBookBorrowed {get; set;}
}

public class BookDatabase
{
    private static List<Book> _books = new List<Book>()
    {
        new Book{ bookId=1, name = "Science", IsBookBorrowed=true},
        new Book{ bookId=2, name = "Maths", IsBookBorrowed=false},
        new Book{ bookId=3, name = "Sinhala", IsBookBorrowed=true}
    };

    public static List<Book> GetBooks()
    {
        return _books;
    }

    public static Book ? GetBook(int bookId)
    {
        return _books.SingleOrDefault(book => book.bookId == bookId);
    }

    public static Book CreateBook(Book book)
    {
        _books.Add(book);
        return book;
    }

    public static Book UpdateBook(Book newBook)
    {
        _books = _books.Select(book =>
        {
            if (book.bookId == newBook.bookId)
            {
                book.name = newBook.name;
                book.IsBookBorrowed = newBook.IsBookBorrowed;
            }
            return book;
        }).ToList();
        return newBook;
    }

    public static void RemoveBook(int bookId)
    {
        _books = _books.FindAll(book => book.bookId != bookId).ToList();        
    }
}