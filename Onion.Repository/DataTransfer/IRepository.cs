using Onion.Data.Common;
using System.Linq.Expressions;

namespace Onion.Repository.DataTransfer
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter);

        TEntity? GetById(int entityId);

        Task Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task Save();
    }
}
