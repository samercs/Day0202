using Day0202.Models;
using Microsoft.EntityFrameworkCore;

namespace Day0202.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<News> News => Set<News>();
    }
}
