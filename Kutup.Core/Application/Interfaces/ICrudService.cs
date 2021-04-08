using Kutup.Core.Domain.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kutup.Core.Application.Interfaces
{
    public interface ICrudService<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAsQueryable();
        IQueryable<TEntity> GetByIdAsQueryable(int id);
        Task<IList<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int id);
    }
}
