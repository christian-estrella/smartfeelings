using MediatR;
using SmartFeelings.Application.Common.Base;
using SmartFeelings.Domain.Enums;
using SmartFeelings.Domain.ValueObjects;

namespace SmartFeelings.Application.UseCases.Commands.Patient.Create;

public record CreatePatientCommand(string Name, string Lastname, string Email, PatientDetail Detail, Gender Gender)
    : IRequest<BaseResponse<Domain.Entities.Patient>>;