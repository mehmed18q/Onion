using Microsoft.EntityFrameworkCore;
using Onion.Data.Common;
using Onion.Repository.ApplicationContext;
using System.Linq.Expressions;

namespace Onion.Repository.DataTransfer
{
	public class BaseRepository<TEntity>(ApplicationDbContext context) : IBaseRepository<TEntity> where TEntity : BaseEntity
	{
		private readonly ApplicationDbContext _context = context;
		private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
		public void Dispose() => _context?.Dispose();

		public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null)
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
			_dbSet.Update(entity);
		}

		public void Delete(TEntity entity)
		{
			entity.IsDeleted = true;
			_context.Update(entity);
		}

		public async Task<bool> Any(Expression<Func<TEntity, bool>>? filter = null)
		{
			return filter is not null && await _dbSet.AnyAsync(filter);
		}

		public async Task Save()
		{
			await _context.SaveChangesAsync();
		}

		public async Task<bool> IsExist(Expression<Func<TEntity, bool>>? filter = null)
		{
			return filter is not null && await _dbSet.AnyAsync(filter);
		}
	}
}
