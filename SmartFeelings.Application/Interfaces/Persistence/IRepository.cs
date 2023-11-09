using System.Linq.Expressions;

namespace SmartFeelings.Application.Interfaces.Persistence;

public interface IRepository<T>
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    IQueryable<T> Where(Expression<Func<T, bool>> predicate);
}