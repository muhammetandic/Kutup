using Kutup.Core.Application.Interfaces.Repositories;
using Kutup.Core.Domain.Entities;
using Kutup.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Kutup.Data.Repositories
{
    public class BookRepositoryAsync : GenericRepositoryAsync<Book>, IBookRepositoryAsync
    {
        private DbSet<Book> _parameters;

        public BookRepositoryAsync(KutupDbContext dbContext) : base(dbContext)
        {
            _parameters = dbContext.Set<Book>();       
        }
    }
}
