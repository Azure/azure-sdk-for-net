using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
using Azure.AI.AgentServer.Core.Common.Http.ServerSentEvent;
using Azure.AI.AgentServer.Core.Common.Id;
using Azure.AI.AgentServer.Core.Telemetry;
using Azure.AI.AgentServer.Responses.Invocation;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

using OpenTelemetry;

namespace Azure.AI.AgentServer.Responses.Endpoint;

public static class AgentRunEndpoints
{
    private sealed class AgentRunEndpointsLogger
    {
    }

    public static IEndpointRouteBuilder MapAgentRunEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var agentRunGroup = endpoints.MapGroup("/{p:regex(^runs|responses$)}")
            .AddEndpointFilter<AgentRunExceptionFilter>()
            .WithTags("Agent Runs");

        agentRunGroup.MapPost("", CreateResponseAsync)
            .Produces<Contracts.Generated.Responses.Response>(StatusCodes.Status200OK, "application/json")
            .Produces<ResponseStreamEvent>(StatusCodes.Status200OK, "text/event-stream")
            .Produces<Contracts.Generated.OpenAI.ResponseError>(StatusCodes.Status200OK, "application/json")
            .WithName("CreateAgentRun");
        return endpoints;
    }

    private static async Task<IResult> CreateResponseAsync([FromBody] CreateResponseRequest request,
        IAgentInvocation agentInvocation,
        ILogger<AgentRunEndpointsLogger> logger,
        HttpContext httpContext,
        CancellationToken ct)
    {
        var idGenerator = FoundryIdGenerator.From(request);
        var requestId = GetRequestId(httpContext);
        var context = new AgentInvocationContext(idGenerator, idGenerator.ResponseId, idGenerator.ConversationId);
        var scopeAttrs = CreateContextAttributions(context, requestId, request);

        UpdateContextBaggage(scopeAttrs);
        await using var _ = AgentInvocationContext.Setup(context).ConfigureAwait(false);
        using var activity = context.StartActivity(logger, request);
        try
        {
            logger.LogInformation($"Processing CreateResponse request: response_id={context.ResponseId}, "
                                  + $"conversation_id={context.ConversationId}, streaming={request.Stream ?? false}, "
                                  + $"request_Id={requestId}.");
            if (request.Stream ?? false)
            {
                logger.LogInformation("Invoking agent to create streaming response.");
                var updates = agentInvocation.InvokeStreamAsync(request, context, ct);
                return updates.ToSseResult(
                    e => SseFrame.Of(name: e.Type.ToString(), data: e),
                    logger,
                    ct);
            }

            logger.LogInformation("Invoking agent to create response.");
            var response = await agentInvocation.InvokeAsync(request, context, ct).ConfigureAwait(false);
            logger.LogInformation($"End of processing CreateResponse request: response_id={context.ResponseId}, "
                                  + $"conversation_id={context.ConversationId}, streaming={request.Stream ?? false}, "
                                  + $"request_Id={requestId}.");
            return Results.Json(response);
        }
        catch (Exception ex)
        {
            // Exceptions will be export to exceptions table in Application Insights.
            logger.LogError(ex, "Error when processing CreateResponse request.");
            throw;
        }
    }

    private static Dictionary<string, string> CreateContextAttributions(
        AgentInvocationContext agentContext,
        string? requestId,
        CreateResponseRequest requestBody)
    {
        var scopeAttrs = new Dictionary<string, string>()
        {
            { "azure.ai.agentserver.responses.response_id", agentContext.ResponseId },
            { "azure.ai.agentserver.responses.conversation_id", agentContext.ConversationId },
            { "azure.ai.agentserver.responses.streaming", (requestBody.Stream ?? false).ToString() },
        };
        if (!string.IsNullOrEmpty(requestId))
        {
            scopeAttrs["azure.ai.agentserver.responses.request_id"] = requestId;
        }

        return scopeAttrs;
    }

    private static string? GetRequestId(HttpContext httpContext)
    {
        if (httpContext.Request.Headers.TryGetValue("X-Request-Id", out var reqId))
        {
            return !string.IsNullOrWhiteSpace(reqId)
                ? reqId.ToString()
                : null;
        }

        return null;
    }

    private static void UpdateContextBaggage(Dictionary<string, string> scopeAttrs)
    {
        foreach (var kv in scopeAttrs)
        {
            Baggage.SetBaggage(kv.Key, kv.Value);
        }
    }
}
