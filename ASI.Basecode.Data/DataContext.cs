using System.Data.Entity;

namespace MvcBookApplication.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
