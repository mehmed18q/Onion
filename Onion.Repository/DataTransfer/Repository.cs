using Microsoft.EntityFrameworkCore;
using Onion.Data.Common;
using Onion.Repository.ApplicationContext;
using System.Linq.Expressions;

namespace Onion.Repository.DataTransfer
{
    public class Repository<TEntity>(ApplicationDbContext context) : IRepository<TEntity> where TEntity : BaseEntity
    {
        private ApplicationDbContext _context = context;
        private DbSet<TEntity> _dbSet = context.Set<TEntity>();

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> queryable = _dbSet.Where(q => !q.IsDeleted);
            if (filter is not null)
            {
                queryable = queryable.Where(filter);
            }

            return queryable;
        }

        public TEntity? GetById(int entityId)
        {
            return Get(e => e.Id == entityId).FirstOrDefault();
        }

        public async Task Insert(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
