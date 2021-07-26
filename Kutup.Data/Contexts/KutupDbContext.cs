using Kutup.Core.Domain.Entities;
using Kutup.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Kutup.Data.Contexts
{
    public class KutupDbContext : DbContext
    {
        private readonly bool _created;

        public KutupDbContext(DbContextOptions<KutupDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            if (!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
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
