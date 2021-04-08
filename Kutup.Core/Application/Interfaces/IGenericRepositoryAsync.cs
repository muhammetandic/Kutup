using Kutup.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kutup.Core.Application.Interfaces
{
    public interface IGenericRepositoryAsync<TEntity> : IDisposable where TEntity : IEntity
    {
        IQueryable<TEntity> Table { get; }
        Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<bool> IsExistAsync(int id);
    }
}
