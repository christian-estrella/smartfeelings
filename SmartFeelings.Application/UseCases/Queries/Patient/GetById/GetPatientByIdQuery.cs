using MediatR;
using SmartFeelings.Application.Common.Base;

namespace SmartFeelings.Application.UseCases.Queries.Patient.GetById;

public record GetPatientByIdQuery(Guid Id)
    : IRequest<BaseResponse<Domain.Entities.Patient>>;