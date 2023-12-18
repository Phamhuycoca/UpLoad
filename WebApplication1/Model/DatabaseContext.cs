using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
                : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
    }
}
