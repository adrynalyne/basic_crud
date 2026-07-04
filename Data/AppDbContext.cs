using Microsoft.EntityFrameworkCore;
using REST.Models;

namespace REST.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<NameItem> Names => Set<NameItem>();
    }
}
