using Microcredentials.Model;
using Microsoft.EntityFrameworkCore;

namespace Microcredentials.Data
{
    public class MicrocredentialsDbContext : DbContext
    {
        public MicrocredentialsDbContext(DbContextOptions<MicrocredentialsDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
