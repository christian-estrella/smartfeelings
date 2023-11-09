namespace SmartFeelings.Domain.ValueObjects;

public class PatientDetail : ValueObject
{
    public DateTime Birthdate { get; init; }

    public PatientDetail(DateTime birthdate)
    {
        if (birthdate > DateTime.Now)
            throw new ArgumentException("Birthdate cannot be greater than today.");

        Birthdate = birthdate;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Birthdate;
    }
}