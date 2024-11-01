﻿using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Journey.Api.Filters;
/// <summary>
/// Filtro de Exceção Geral
/// </summary>
public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is JourneyException)
        {
            JourneyException jorneyException = (JourneyException)context.Exception;
            context.HttpContext.Response.StatusCode = (int)jorneyException.GetStatusCode();

            ResponseErrorsJson responseJson = new(jorneyException.GetErrorMessages());
            context.Result = new ObjectResult(responseJson);
        }
        else
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            ResponseErrorsJson responseJson = new(new List<string> { ResourceErrorMessages.UNKNOWN_ERROR });
            context.Result = new ObjectResult(responseJson);
        }
    }
}
