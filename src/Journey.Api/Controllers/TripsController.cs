using Journey.Application.UseCases.Trips.GetAll;
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
            RegisterTripUseCase useCase = new();
            Communication.Responses.ResponseShortTripJson response = useCase.Execute(request);
            return Created(string.Empty, response);
        }
        catch (JourneyException erro)
        {
            return BadRequest(erro.Message);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro Desconhecido");
        }
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        GetAllTripsUseCase useCase = new();
        List<Infrastructure.Entities.Trip> result = useCase.Execute();
        return Ok(result);
    }
}
