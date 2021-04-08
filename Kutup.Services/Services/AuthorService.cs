using Kutup.Core.Application.Interfaces;
using Kutup.Core.Application.Interfaces.Services;
using Kutup.Core.Domain.Entities;

namespace Kutup.Services.Services
{
    public class AuthorService : CrudServiceBase<Author>, IAuthorService
    {
        private readonly IGenericRepositoryAsync<Author> _repository;
        public AuthorService(IGenericRepositoryAsync<Author> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
