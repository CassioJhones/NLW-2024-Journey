using Journey.Application.UseCases.Activities.Complete;
using Journey.Application.UseCases.Activities.Delete;
using Journey.Application.UseCases.Activities.Register;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Journey.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ActivitiesController : ControllerBase
{
    /// <summary>
    /// Registra uma atividade relacionada a uma viagem no banco de dados
    /// </summary>
    /// <param name="tripId">Id da Viagem</param>
    /// <param name="request">Objeto com os campos necessarios</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Viagem adicionada com Sucesso</response>
    /// <response code="400">Faltando campos necessarios</response>
    /// <response code="404">Nao Encontrado</response>
    [HttpPost]
    [Route("{tripId}/activity")]
    [ProducesResponseType(typeof(ResponseShortTripJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult RegisterActivity([FromRoute] Guid tripId, [FromBody] RequestRegisterActivityJson request)
    {
        RegisterActivityForTripUseCase useCase = new();
        ResponseActivityJson? response = useCase.Execute(tripId, request);
        return Created(string.Empty, response);
    }

    /// <summary>
    /// Completa uma atividade e Atualiza o seu Status
    /// </summary>
    /// <param name="tripId">Id da Viagem</param>
    /// <param name="activId">Id da Atividade</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Sem Conteudo</response>
    /// <response code="404">Nao Encontrado</response>
    [HttpPut]
    [Route("{tripId}/activity/{activId}/complete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseShortTripJson), StatusCodes.Status404NotFound)]
    public IActionResult CompleteActivity(
        [FromRoute] Guid tripId,
        [FromRoute] Guid activId)
    {
        CompleteActivityForTripUseCase useCase = new();
        useCase.Execute(tripId, activId);
        return NoContent();
    }

    /// <summary>
    /// Deleta uma atividade
    /// </summary>
    /// <param name="tripId">Id da Viagem</param>
    /// <param name="activId">Id da Atividade</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Sem Conteudo</response>
    /// <response code="404">Nao Encontrado</response>
    [HttpDelete]
    [Route("{tripId}/activity/{activId}/complete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseShortTripJson), StatusCodes.Status404NotFound)]
    public IActionResult DeleteActivity(
        [FromRoute] Guid tripId,
        [FromRoute] Guid activId)
    {
        DeleteActivityForTripUseCase useCase = new();
        useCase.Execute(tripId, activId);
        return NoContent();
    }
}
