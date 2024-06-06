using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class PgDbContext : DbContext
    {
        public PgDbContext(DbContextOptions<PgDbContext> options) : base(options)
        {
        }

        public DbSet<pw_users> pw_users { get; set; }
    }
}
