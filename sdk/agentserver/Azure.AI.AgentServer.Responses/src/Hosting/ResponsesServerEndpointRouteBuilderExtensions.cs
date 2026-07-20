// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Extension methods for <see cref="IEndpointRouteBuilder"/> to map
/// the Responses API routes.
/// </summary>
public static class ResponsesServerEndpointRouteBuilderExtensions
{
    /// <summary>
    /// Maps the Responses API routes to the endpoint routing pipeline.
    /// </summary>
    /// <param name="endpoints">The endpoint route builder to map routes on.</param>
    /// <param name="prefix">Optional route prefix (e.g., "/openai/v1"). Default: empty (routes at /responses).</param>
    /// <returns>A <see cref="RouteGroupBuilder"/> for further endpoint configuration.</returns>
    public static RouteGroupBuilder MapResponsesServer(
        this IEndpointRouteBuilder endpoints,
        string? prefix = null)
    {
        // Fail-fast: verify ResponseHandler is registered (S-004)
        var handler = endpoints.ServiceProvider.GetService<ResponseHandler>();
        if (handler is null)
        {
            throw new InvalidOperationException(
                "No ResponseHandler implementation is registered. " +
                "Call AddResponsesServer() and register an ResponseHandler implementation " +
                "before calling MapResponsesServer().");
        }

        var groupPrefix = string.IsNullOrEmpty(prefix) ? string.Empty : prefix.TrimEnd('/');
        var group = endpoints.MapGroup(groupPrefix);

        // Register Responses protocol identity with the version registry (if available)
        var registry = endpoints.ServiceProvider.GetService<ServerVersionRegistry>();
        if (registry is not null)
        {
            registry.Register(ServerVersionRegistry.BuildIdentityString(
                "azure-ai-agentserver-responses",
                typeof(ResponsesServerEndpointRouteBuilderExtensions).Assembly));
        }

        group.AddEndpointFilter<SessionIdResponseHeaderFilter>();
        group.AddEndpointFilter<ResponsesExceptionFilter>();

        group.MapPost("/responses", async (HttpContext httpContext, ResponseEndpointHandler handler) =>
        {
            return await handler.CreateResponseAsync(httpContext);
        });

        group.MapGet("/responses/{responseId}", async (HttpContext httpContext, string responseId, ResponseEndpointHandler handler) =>
        {
            return await handler.GetResponseAsync(httpContext, responseId);
        });

        group.MapPost("/responses/{responseId}/cancel", async (HttpContext httpContext, string responseId, ResponseEndpointHandler handler) =>
        {
            return await handler.CancelResponseAsync(httpContext, responseId);
        });

        group.MapDelete("/responses/{responseId}", async (HttpContext httpContext, string responseId, ResponseEndpointHandler handler) =>
        {
            return await handler.DeleteResponseAsync(httpContext, responseId);
        });

        group.MapGet("/responses/{responseId}/input_items", async (HttpContext httpContext, string responseId, ResponseEndpointHandler handler) =>
        {
            return await handler.GetInputItemsAsync(httpContext, responseId);
        });

        group.WithTags("Responses");

        return group;
    }
}
