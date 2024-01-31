using LibraryAPI.DTOs.Books;
using LibraryAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;
[Route("api/book/")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly LibraryDb _db;

    public BookController(LibraryDb db)
    {
        _db = db;
    }

    [HttpPost("add-new-book")]
    public void AddBook( AddBookDto command)
    {
        var book = new Book(command.Title, command.Genre, command.PublishDate, command.Auther);
        _db.Books.Add(book);
        _db.SaveChanges();
    }

    [HttpPut("edit-book/{id}")]
    public void EditBook([FromRoute]int id,[FromBody] EditBookDto command)
    {
        var book = _db.Books.FirstOrDefault(_ => _.Id == id);
        if (book == null)
        {
            throw new Exception("book not fount");
        }

        book.EditBook(command.Title, command.Genre, command.PublishDate, command.Auther);

        _db.SaveChanges();


    }


    [HttpGet("get-books")]
    public List<BookDto> GetBooks()
    {

        var book = _db.Books.OrderByDescending(x => x.Id).Select(x => new BookDto
        {
            Title = x.Title,

            Genre = x.Genre,
            PublishDate = x.PublishDate,
            Auther = x.Auther
        }).ToList();

        return book;
    }

    [HttpGet("get-book-by-name/{bookName}")]
    public BookDto GetBookByBookName( string bookName)
    {
        var findBook = _db.Books.FirstOrDefault(_ => _.Title == bookName);


        if (findBook == null)
        {
            throw new Exception("book not found");
        }
        else
        {

            var book = new BookDto()
            {
                Title = findBook.Title,
                Genre = findBook.Genre,
                PublishDate = findBook.PublishDate,
                Auther = findBook.Auther
            };
            return book;

        }

    }


    [HttpGet("get-books-by-genre/{genre}")]
    public List<BookDto> GetBooksByGenre( string genre)
    {

        var books=_db.Books.Where(_=>_.Genre == genre).Select(_=>new BookDto
        {
            Title= _.Title,
            Genre= _.Genre,
            PublishDate= _.PublishDate,
            Auther = _.Auther
        }).ToList();

        return books;
    }

    [HttpDelete("delete-book-by-id/{id}")]
    public void DeleteBookById([FromRoute]int id)
    {
        var book = _db.Books.FirstOrDefault(_ => _.Id == id);

        if (book == null)
        {
            throw new Exception("book not found");
        }

        _db.Remove(book);
        _db.SaveChanges();
    }


}
