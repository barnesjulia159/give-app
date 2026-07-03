using Microsoft.EntityFrameworkCore;

namespace Capstone.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Database tables
        public DbSet<Product> Products { get; set; }
    }
}