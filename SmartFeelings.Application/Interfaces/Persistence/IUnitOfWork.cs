namespace SmartFeelings.Application.Interfaces.Persistence;

public interface IUnitOfWork
{
    Task<bool> CommitAsync();

    Task RollbackAsync();

    public IRepository<T> Repository<T>() where T : class;
}