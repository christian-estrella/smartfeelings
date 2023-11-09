using MediatR;
using SmartFeelings.Application.Common.Base;
using SmartFeelings.Application.Interfaces.Persistence;

namespace SmartFeelings.Application.UseCases.Commands.Patient.Create;

public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, BaseResponse<Domain.Entities.Patient>>
{
    private readonly IRepository<Domain.Entities.Patient> _patientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePatientCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _patientRepository = _unitOfWork.Repository<Domain.Entities.Patient>();
    }

    public async Task<BaseResponse<Domain.Entities.Patient>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = new Domain.Entities.Patient(Guid.NewGuid(),
            request.Name,
            request.Lastname,
            request.Email,
            request.Gender);

        patient.AssignDetail(request.Detail);
        
        _patientRepository.Add(patient);
        var result = await _unitOfWork.CommitAsync();

        return new BaseResponse<Domain.Entities.Patient>(result, $"Success", patient);
    }
}