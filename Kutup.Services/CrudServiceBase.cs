using Kutup.Core.Application.Interfaces;
using Kutup.Core.Domain.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kutup.Services
{
    public class CrudServiceBase<TEntity> : ICrudService<TEntity> where TEntity : BaseEntity
    {
        private readonly IGenericRepositoryAsync<TEntity> _repository;

        public CrudServiceBase(IGenericRepositoryAsync<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual async Task<TEntity> Create(TEntity entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public virtual async Task Delete(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null)
            {
                throw new KeyNotFoundException();
            }
            await _repository.DeleteAsync(id);
        }

        public virtual async Task<IList<TEntity>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public IQueryable<TEntity> GetAsQueryable()
        {
            return _repository.Table.AsQueryable();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public IQueryable<TEntity> GetByIdAsQueryable(int id)
        {
            return _repository.Table.Where(x => x.Id == id).AsQueryable();
        }

        public async Task Update(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
