using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Responses.Invocation;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Responses.Endpoint;

/// <summary>
/// Endpoint filter that handles exceptions from agent invocations and converts them to appropriate HTTP responses.
/// </summary>
public class AgentRunExceptionFilter : IEndpointFilter
{
    /// <summary>
    /// Invokes the next filter in the pipeline and handles any exceptions.
    /// </summary>
    /// <param name="ctx">The endpoint filter invocation context.</param>
    /// <param name="next">The next filter delegate in the pipeline.</param>
    /// <returns>The result of the endpoint invocation or an error response.</returns>
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
            var errorResponse =
                new Contracts.Generated.OpenAI.ResponseError(code: ResponseErrorCode.ServerError, message: e.Message);
            return Results.Json(errorResponse, statusCode: StatusCodes.Status502BadGateway);
        }
    }
}
