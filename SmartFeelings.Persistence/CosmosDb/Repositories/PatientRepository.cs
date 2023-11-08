using SmartFeelings.Application.Interfaces.Persistence.CosmosDb;
using SmartFeelings.Domain.Entities;
using System.Linq.Expressions;

namespace SmartFeelings.Persistence.CosmosDb.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly SmartFeelingsDbContext _context;

    public PatientRepository(SmartFeelingsDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddAsync(Patient entity)
    {
        await _context.AddAsync(entity);
        var result = await _context.SaveChangesAsync();

        return result;
    }

    public async Task<int> UpdateAsync(Patient entity)
    {
        _context.Update(entity);

        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(Patient entity)
    {
        _context.Remove(entity);

        return await _context.SaveChangesAsync();
    }

    public IQueryable<Patient> Where(Expression<Func<Patient, bool>> predicate)
        => _context.Patients.Where(predicate).AsQueryable();
}