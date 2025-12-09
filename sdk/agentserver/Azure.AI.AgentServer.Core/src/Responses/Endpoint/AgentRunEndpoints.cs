// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
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

/// <summary>
/// Provides extension methods for mapping agent run endpoints.
/// </summary>
public static class AgentRunEndpoints
{
    private sealed class AgentRunEndpointsLogger
    {
    }

    /// <summary>
    /// Maps agent run endpoints to the endpoint route builder.
    /// </summary>
    /// <param name="endpoints">The endpoint route builder.</param>
    /// <returns>The endpoint route builder for chaining.</returns>
    public static IEndpointRouteBuilder MapAgentRunEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var agentRunGroup = endpoints.MapGroup("/{p:regex(^runs|responses$)}")
            .WithTags("Agent Runs");

        agentRunGroup.MapPost("", CreateResponseAsync)
            .Produces<Contracts.Generated.Responses.Response>(StatusCodes.Status200OK, "application/json")
            .Produces<ResponseStreamEvent>(StatusCodes.Status200OK, "text/event-stream")
            .Produces<Contracts.Generated.OpenAI.ResponseError>(StatusCodes.Status200OK, "application/json")
            .WithName("CreateAgentRun");
        return endpoints;
    }

    private static async Task<IResult> CreateResponseAsync([FromBody] CreateResponseRequest request,
        AgentInvoker invoker,
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

        return await invoker.InvokeAsync(requestId, request, context, ct).ConfigureAwait(false);
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
