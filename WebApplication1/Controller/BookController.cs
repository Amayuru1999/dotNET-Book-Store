using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controller;


[ApiController]
[Route("api/books")]
public class BookController : Microsoft.AspNetCore.Mvc.Controller
{
    static private List<Book> books = new List<Book>
    {
        new Book
        {
            Id = 1,
            Title = "Book 1",
            Author = "John Doe",
            YearPublished = 2000
        },
        new Book
        {
            Id = 2,
            Title = "Book 2",
            Author = "John Doe",
            YearPublished = 2001
        },
        new Book
        {
            Id = 3,
            Title = "Book 3",
            Author = "John Doe",
            YearPublished = 2002
        },
        new Book
        {
            Id = 4,
            Title = "Book 4",
            Author = "John Doe",
            YearPublished = 2003
        },
        new Book
        {
            Id = 5,
            Title = "Book 5",
            Author = "John Doe",
            YearPublished = 2004
        },
    };

    [HttpGet]
    public ActionResult<List<Book>> Get()
    {
        return Ok(books);
    }

    [HttpGet("{id}")]
    public ActionResult<Book> Get(int id)
    {
        var book = books.FirstOrDefault(x => x.Id == id);
        if(book == null)
            return NotFound();
        return Ok(book);
    }

    [HttpPost]
    public ActionResult<Book> AddBook(Book newBook)
    {
        if(newBook == null)
            return BadRequest();
        books.Add(newBook);
        return CreatedAtAction(nameof(GetBookByID), new { id = newBook.Id }, newBook);
    }
    
    
}