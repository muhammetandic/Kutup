using Kutup.Core.Application.Interfaces;
using Kutup.Core.Application.Interfaces.Services;
using Kutup.Core.Domain.Entities;

namespace Kutup.Services.Services
{
    public class CategoryService : CrudServiceBase<Category>, ICategoryService
    {
        private readonly IGenericRepositoryAsync<Category> _repository;
        public CategoryService(IGenericRepositoryAsync<Category> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
