using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controller;


[ApiController]
[Route("api/books")]
public class BookController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly Context _context;

    public BookController(Context context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetBooks()
    {
        return Ok(await _context.Books.ToListAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBookByID(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if(book == null)
            return NotFound();
        return Ok(book);
    }
    
    [HttpPost]
    public async Task<ActionResult<Book>> AddBook(Book newBook)
    {
        if(newBook == null)
            return BadRequest();
        _context.Books.Add(newBook);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBookByID), new { id = newBook.Id }, newBook);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, Book updatedBook)
    {
        var  book = await _context.Books.FindAsync(id);
        if(book == null)
            return NotFound();
        book.Id = updatedBook.Id;
        book.Title = updatedBook.Title;
        book.Author = updatedBook.Author;
        book.YearPublished = updatedBook.YearPublished;
        await _context.SaveChangesAsync();
        return NoContent();
    }
    
}