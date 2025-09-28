using Microsoft.EntityFrameworkCore;
using Docker_Api.Models;

namespace Docker_Api.Data
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }

        public DbSet<TestTable> TestTable { get; set; }
    }
}