using Kutup.Core.Application.Interfaces;
using Kutup.Core.Application.Interfaces.Services;
using Kutup.Core.Domain.Entities;

namespace Kutup.Services.Services
{
    public class BookService : CrudServiceBase<Book> , IBookService
    {
        private readonly IGenericRepositoryAsync<Book> _repository;
        public BookService(IGenericRepositoryAsync<Book> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
