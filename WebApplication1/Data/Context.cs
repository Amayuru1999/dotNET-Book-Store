using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Book>().HasData(
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
            }
            );
    }
    
    public DbSet<Book> Books { get; set; }
}