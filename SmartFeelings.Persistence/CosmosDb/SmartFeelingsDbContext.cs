using Microsoft.EntityFrameworkCore;
using SmartFeelings.Domain.Entities;
using SmartFeelings.Persistence.CosmosDb.Configs;

namespace SmartFeelings.Persistence.CosmosDb;

public class SmartFeelingsDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseCosmos(
            "https://localhost:8081",
            "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
            "SmartFeelings");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>()
            .ToContainer("Patients")
            .HasPartitionKey(x => x.Id);

        // Additional configurations by entity
        modelBuilder.AddPatientConfig();
    }

    public DbSet<Patient> Patients { get; init; } = null!;
}