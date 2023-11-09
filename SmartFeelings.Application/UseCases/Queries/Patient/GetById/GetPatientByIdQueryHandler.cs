using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartFeelings.Application.Common.Base;
using SmartFeelings.Application.Interfaces.Persistence;

namespace SmartFeelings.Application.UseCases.Queries.Patient.GetById;

public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, BaseResponse<Domain.Entities.Patient>>
{
    private readonly IRepository<Domain.Entities.Patient> _patientRepository;

    public GetPatientByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _patientRepository = unitOfWork.Repository<Domain.Entities.Patient>();
    }

    public async Task<BaseResponse<Domain.Entities.Patient>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
    {
        var patient = await _patientRepository
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        return patient is null
            ? new BaseResponse<Domain.Entities.Patient>(false, $"Patient with Id: {request.Id} not found", null)
            : new BaseResponse<Domain.Entities.Patient>(true, $"Success", patient);
    }
}