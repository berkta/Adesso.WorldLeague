using Adesso.WorldLeague.Application.Draws.Commands;
using Adesso.WorldLeague.Application.Draws.Inputs;
using Adesso.WorldLeague.Application.Draws.Outputs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Adesso.WorldLeague.Api.EndpointHandlers;

public static class DrawEndpointHandlers
{
    public static async Task<IResult> CreateDraw([FromBody] CreateDrawCommandInput input, [FromServices] IMediator mediator)
    {
        var output = await mediator.Send(new CreateDrawCommand(input));

        return Results.Ok(output) ;
    }
}