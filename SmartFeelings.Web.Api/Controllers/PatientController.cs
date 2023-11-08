using Microsoft.AspNetCore.Mvc;
using SmartFeelings.Application.UseCases.Commands.Patient.Create;
using SmartFeelings.Application.UseCases.Queries.Patient.GetById;
using SmartFeelings.Web.Api.Controllers.Common;

namespace SmartFeelings.Web.Api.Controllers;

[ApiController]
[Produces("application/json")]
public class PatientController : ApiBaseController
{
    [HttpPost]
    public async Task<IActionResult> CreatePatient([FromBody] CreatePatientCommand command)
    {
        var result = await Mediator.Send(command);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetPatient(Guid id)
    {
        var result = await Mediator.Send(new GetPatientByIdQuery(id));

        if (!result.Success)
            return NotFound(result);

        return Ok(result);
    }
}