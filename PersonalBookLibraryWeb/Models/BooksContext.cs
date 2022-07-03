using Microsoft.EntityFrameworkCore;

namespace PersonalBookLibraryWeb.Models
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;

        public BooksContext(DbContextOptions<BooksContext> options) : base(options)
        {

        }
    }
}
