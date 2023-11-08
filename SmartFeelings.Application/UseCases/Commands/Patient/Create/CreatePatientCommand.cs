using MediatR;
using SmartFeelings.Application.Common.Base;
using SmartFeelings.Domain.Enums;

namespace SmartFeelings.Application.UseCases.Commands.Patient.Create;

public record CreatePatientCommand(string Name, string Lastname, string Email, Gender Gender)
    : IRequest<BaseResponse<Domain.Entities.Patient>>;