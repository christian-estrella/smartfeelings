using System.Linq.Expressions;
using SmartFeelings.Application.Interfaces.Persistence;

namespace SmartFeelings.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly SmartFeelingsDbContext _context;

    public Repository(SmartFeelingsDbContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Add(entity);
    }

    public void Update(T entity)
    {
        _context.Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        => _context.Set<T>().Where(predicate).AsQueryable();
}