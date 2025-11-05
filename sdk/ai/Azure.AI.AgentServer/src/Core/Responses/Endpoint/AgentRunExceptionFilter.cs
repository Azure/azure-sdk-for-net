using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Responses.Invocation;

using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Responses.Endpoint;

public class AgentRunExceptionFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext ctx,
        EndpointFilterDelegate next)
    {
        try
        {
            return await next(ctx).ConfigureAwait(false);
        }
        catch (AgentInvocationException e)
        {
            return Results.Json(e.Error, statusCode: StatusCodes.Status502BadGateway);
        }
        catch (Exception e)
        {
            var errorResponse = new Contracts.Generated.OpenAI.ResponseError(code: ResponseErrorCode.ServerError ,message: e.Message);
            return Results.Json(errorResponse, statusCode: StatusCodes.Status502BadGateway);
        }
    }
}
