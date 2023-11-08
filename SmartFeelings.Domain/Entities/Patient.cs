using SmartFeelings.Domain.Enums;

namespace SmartFeelings.Domain.Entities;

public class Patient
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Lastname { get; init; }
    public string Email { get; init; }
    public Gender Gender { get; init; }

    public Patient(Guid id, string name, string lastname, string email, Gender gender)
    {
        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name), "Name cannot be null.");
        Lastname = lastname ?? throw new ArgumentNullException(nameof(lastname), "Lastname cannot be null.");
        Email = email ?? throw new ArgumentNullException(nameof(email), "Email cannot be null");
        Gender = gender;
    }
}