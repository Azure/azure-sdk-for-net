// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
using Azure.AI.AgentServer.Core.Telemetry;
using Azure.AI.AgentServer.Responses.Invocation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

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

    private static async Task<IResult> CreateResponseAsync(
        AgentInvoker invoker,
        ILogger<AgentRunEndpointsLogger> logger,
        HttpContext httpContext,
        CancellationToken ct)
    {
        // AgentRunContext is already created and set up by AgentRunContextMiddleware
        // OpenTelemetry baggage is already configured by the middleware
        var context = httpContext.Items["AgentRunContext"] as AgentRunContext
            ?? throw new InvalidOperationException("AgentRunContext not found. Ensure AgentRunContextMiddleware is registered.");

        using var activity = context.StartActivity(logger, context.Request);

        return await invoker.InvokeAsync(httpContext, ct).ConfigureAwait(false);
    }
}
