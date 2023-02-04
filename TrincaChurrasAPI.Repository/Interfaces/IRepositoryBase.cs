using System.Linq.Expressions;
using TrincaChurrasAPI.Domain.Interfaces;

namespace TrincaChurrasAPI.Repository.Interfaces
{
    public interface IRepositoryBase<T> 
    {
        IQueryable<T> QueryAll();

        T Query(string key);

        void AddAsync(T entity);

        IQueryable<T> GetFilter(Expression<Func<T, bool>> predicate);
    }
}