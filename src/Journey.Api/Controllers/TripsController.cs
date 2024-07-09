using Journey.Application.UseCases.Trips.Register;
using Journey.Communication.Requests;
using Journey.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;

namespace Journey.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterTripJson request)
    {

		try
		{
			RegisterTripUseCase usecase = new();
			usecase.Execute(request);
			return Created();
		}
		catch (JourneyException erro)
		{

			return BadRequest(erro.Message);
		}
    }
}
