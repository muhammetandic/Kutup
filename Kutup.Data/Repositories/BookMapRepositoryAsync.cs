using Kutup.Core.Domain.Entities;
using Kutup.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Kutup.Data.Repositories
{
    public class BookMapRepositoryAsync : GenericRepositoryAsync<Author>
    {
        private readonly DbSet<BookMap> _parameters;

        public BookMapRepositoryAsync(KutupDbContext dbContext) : base(dbContext)
        {
            _parameters = dbContext.Set<BookMap>();
        }
    }
}
