using Kutup.Core.Application.Interfaces.Repositories;
using Kutup.Core.Domain.Entities;
using Kutup.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Kutup.Data.Repositories
{
    public class CategoryRepositoryAsync : GenericRepositoryAsync<Category>, ICategoryRepositoryAsync
    {
        private readonly DbSet<Category> _parameters;

        public CategoryRepositoryAsync(KutupDbContext dbContext) : base(dbContext)
        {
            _parameters = dbContext.Set<Category>();
        }
    }
}
