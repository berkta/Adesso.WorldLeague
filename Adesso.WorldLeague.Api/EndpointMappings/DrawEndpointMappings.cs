using Adesso.WorldLeague.Api.EndpointHandlers;

namespace Adesso.WorldLeague.Api.EndpointMappings;

public static class DrawEndpointMappings
{
    public static void RegisterDrawEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPost("/draws", DrawEndpointHandlers.CreateDraw)
            .WithName("CreateDraw")
            .WithOpenApi();
    }
}