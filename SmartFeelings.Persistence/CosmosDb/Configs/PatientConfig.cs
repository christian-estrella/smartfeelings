using Microsoft.EntityFrameworkCore;
using SmartFeelings.Domain.Entities;

namespace SmartFeelings.Persistence.CosmosDb.Configs;

public static class PatientConfig
{
    public static ModelBuilder AddPatientConfig(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>().Property(p => p.Id).ToJsonProperty("patientId");
        modelBuilder.Entity<Patient>().Property(p => p.Name).ToJsonProperty("name");
        modelBuilder.Entity<Patient>().Property(p => p.Lastname).ToJsonProperty("lastname");
        modelBuilder.Entity<Patient>().Property(p => p.Email).ToJsonProperty("email");
        modelBuilder.Entity<Patient>().Property(p => p.Gender).ToJsonProperty("gender");

        return modelBuilder;
    }
}