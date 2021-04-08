using Kutup.Core.Domain.Entities;
using Kutup.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Kutup.Data.Contexts
{
    public class KutupDbContext : DbContext
    {
        public KutupDbContext(DbContextOptions<KutupDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KutupFluentMapping).Assembly);
        }
    }
}
