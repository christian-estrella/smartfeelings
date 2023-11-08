using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SmartFeelings.Web.Api.Controllers.Common;

[ApiController]
[Route("api/[controller]")]
public class ApiBaseController : ControllerBase
{
    protected ISender Mediator => HttpContext.RequestServices.GetRequiredService<ISender>();
}