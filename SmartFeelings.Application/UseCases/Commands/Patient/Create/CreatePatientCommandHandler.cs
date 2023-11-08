using MediatR;
using SmartFeelings.Application.Common.Base;
using SmartFeelings.Application.Interfaces.Persistence.CosmosDb;

namespace SmartFeelings.Application.UseCases.Commands.Patient.Create;

public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, BaseResponse<Domain.Entities.Patient>>
{
    private readonly IPatientRepository _patientRepository;

    public CreatePatientCommandHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<BaseResponse<Domain.Entities.Patient>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = new Domain.Entities.Patient(Guid.NewGuid(), request.Name, request.Lastname, request.Email, request.Gender);
        var result = await _patientRepository.AddAsync(patient);

        return new BaseResponse<Domain.Entities.Patient>(true, $"OK: {result}", patient);
    }
}