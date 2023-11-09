using Microsoft.EntityFrameworkCore;
using SmartFeelings.Application.Interfaces.Persistence;
using SmartFeelings.Persistence.Repositories;

namespace SmartFeelings.Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly SmartFeelingsDbContext _context;
    private readonly Dictionary<Type, object> _repositories;

    public UnitOfWork(SmartFeelingsDbContext context)
    {
        _context = context;
        _repositories = new Dictionary<Type, object>();
    }

    public async Task<bool> CommitAsync()
    {
        try
        {
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception a)
        {
            await RollbackAsync();
            throw;
        }
    }

    public async Task RollbackAsync()
    {
        foreach (var entry in _context.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged))
        {
            switch (entry.State)
            {
                case EntityState.Modified:
                    entry.State = EntityState.Unchanged;
                    break;
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
                case EntityState.Deleted:
                    await entry.ReloadAsync();
                    break;
                case EntityState.Detached:
                case EntityState.Unchanged:
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Entry state doesn't exists or it's unavailable.");
            }
        }
    }

    public IRepository<T> Repository<T>() where T : class
    {
        if (_repositories.ContainsKey(typeof(T)))
            return (IRepository<T>)_repositories[typeof(T)];

        var repository = new Repository<T>(_context);
        _repositories.Add(typeof(T), repository);

        return repository;
    }

    private bool _disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                _context.Dispose();
        
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
#pragma warning disable CA1816
        GC.SuppressFinalize(this);
#pragma warning restore CA1816
    }
}