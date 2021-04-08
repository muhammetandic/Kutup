using Kutup.Core.Application.Interfaces;
using Kutup.Core.Domain.Common;
using Kutup.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kutup.Data.Repositories
{
    public class GenericRepositoryAsync<TEntity> : IGenericRepositoryAsync<TEntity> where TEntity : BaseEntity
    {
        private readonly KutupDbContext _dbContext;
        private readonly IQueryable<TEntity> _dbSet;
        private bool _disposed;

        public GenericRepositoryAsync(KutupDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Table => _dbSet;

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            var result = _dbSet.AsQueryable();
            if (predicate!=null)
            { 
                result = result.Where(predicate);
            }

            return await result.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var result = _dbSet.AsQueryable().AsNoTracking();
           
            return await result.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            var result = _dbSet.AsQueryable();
            if (predicate !=null)
            {
                result = result.Where(predicate);
            }
            
            return await result.FirstOrDefaultAsync();
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentException();
            }

            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();
            
            return entity;
            
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbSet.AnyAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
