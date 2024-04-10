using Onion.Data.Common;
using System.Linq.Expressions;

namespace Onion.Repository.DataTransfer
{
	public interface IBaseRepository<TEntity> : IDisposable where TEntity : BaseEntity
	{
		IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null);

		TEntity? GetById(int entityId);

		Task Insert(TEntity entity);

		void Update(TEntity entity);

		void Delete(TEntity entity);

		Task<bool> IsExist(Expression<Func<TEntity, bool>>? filter = null);

		Task<bool> Any(Expression<Func<TEntity, bool>>? filter = null);

		Task Save();
	}
}
