﻿using Journey.Application.UseCases.Trips.DeleteById;
using Journey.Application.UseCases.Trips.GetAll;
using Journey.Application.UseCases.Trips.GetById;
using Journey.Application.UseCases.Trips.Register;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Journey.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    /// <summary>
    /// Registra uma viagem no banco de dados
    /// </summary>
    /// <param name="request">Objeto com os campos necessarios</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Viagem adicionada com Sucesso</response>
    /// <response code="400">Faltando campos necessarios</response>
    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortTripJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestRegisterTripJson request)
    {
        RegisterTripUseCase useCase = new();
        ResponseShortTripJson response = useCase.Execute(request);
        return Created(string.Empty, response);
    }

    /// <summary>
    /// Busca todas as viagens salvas no banco de dados
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Sucesso</response>
    [HttpGet]
    [ProducesResponseType(typeof(ResponseTripJson), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        GetAllTripsUseCase useCase = new();
        List<Trip> result = useCase.Execute();
        return Ok(result);
    }

    /// <summary>
    /// Busca uma viagem por Id
    /// </summary>
    /// <param name="id">Id da Viagem</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Concluido</response>
    /// <response code="404">Nao Encontrado</response>
    /// <response code="500">Erro Interno</response>
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTripJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status500InternalServerError)]
    public IActionResult GetById([FromRoute] Guid id)
    {
        GetTripByIdUseCase useCase = new();
        ResponseTripJson reponse = useCase.Execute(id);
        return Ok(reponse);
    }

    /// <summary>
    /// Deleta uma viagem do banco de dados
    /// </summary>
    /// <param name="id">Id da Viagem</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Sem Conteudo</response>
    /// <response code="404">Nao Encontrado</response>
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] Guid id)
    {
        DeleteTripById useCase = new();
        useCase.Execute(id);
        return NoContent();
    }
}

