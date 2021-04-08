using Kutup.Core.Application.Interfaces.Repositories;
using Kutup.Core.Domain.Entities;
using Kutup.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Kutup.Data.Repositories
{
    public class AuthorRepositoryAsync : GenericRepositoryAsync<Author>, IAuthorRepositoryAsync
    {
        private readonly DbSet<Author> _parameters;

        public AuthorRepositoryAsync(KutupDbContext dbContext) : base(dbContext)
        {
            _parameters = dbContext.Set<Author>();
        }
    }
}
