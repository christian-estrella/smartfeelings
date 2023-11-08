using System.Linq.Expressions;

namespace SmartFeelings.Application.Interfaces.Persistence.CosmosDb;

public interface ICosmosDbRepository<T>
{
    Task<int> AddAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(T entity);
    IQueryable<T> Where(Expression<Func<T, bool>> predicate);
}