// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Runtime.CompilerServices;

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
        IDisposable? activityScope = context.StartActivity(logger, request);
        var activity = Activity.Current;
        try
        {
            logger.LogInformation($"Processing CreateResponse request: response_id={context.ResponseId}, "
                                  + $"conversation_id={context.ConversationId}, streaming={request.Stream ?? false}, "
                                  + $"request_Id={requestId}.");
            if (request.Stream ?? false)
            {
                logger.LogInformation("Invoking agent to create streaming response.");
                var updates = agentInvocation.InvokeStreamAsync(request, context, ct);
                // Transfer activity scope ownership to the streaming pipeline so that
                // Activity.Current is restored during enumeration and child spans are
                // properly parented under this activity instead of appearing as siblings.
                var result = WithActivityScope(updates, activity, activityScope, ct)
                    .ToSseResult(
                        e => SseFrame.Of(name: e.Type.ToString(), data: e),
                        logger,
                        ct);
                activityScope = null;
                return result;
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
        finally
        {
            activityScope?.Dispose();
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

    /// <summary>
    /// Wraps an async enumerable to restore the given <see cref="Activity"/> as
    /// <see cref="Activity.Current"/> during enumeration and dispose the
    /// <paramref name="scope"/> when enumeration completes. This ensures that
    /// child spans created during deferred streaming execution are properly
    /// parented under the original activity.
    /// </summary>
    private static async IAsyncEnumerable<T> WithActivityScope<T>(
        IAsyncEnumerable<T> source,
        Activity? activity,
        IDisposable? scope,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        Activity.Current = activity;
        try
        {
            await foreach (var item in source.WithCancellation(ct).ConfigureAwait(false))
            {
                yield return item;
            }
        }
        finally
        {
            scope?.Dispose();
        }
    }
}
