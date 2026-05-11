// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Invocations.Internal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Invocations;

/// <summary>
/// Extension methods for <see cref="IEndpointRouteBuilder"/> to map
/// the Invocations API routes.
/// </summary>
public static class InvocationsServerEndpointRouteBuilderExtensions
{
    /// <summary>
    /// Maps the Invocations API routes to the endpoint routing pipeline.
    /// </summary>
    /// <param name="endpoints">The endpoint route builder to map routes on.</param>
    /// <param name="prefix">Optional route prefix (e.g., "/v1"). Default: empty (routes at /invocations).</param>
    /// <returns>A <see cref="RouteGroupBuilder"/> for further endpoint configuration.</returns>
    public static RouteGroupBuilder MapInvocationsServer(
        this IEndpointRouteBuilder endpoints,
        string? prefix = null)
    {
        var groupPrefix = string.IsNullOrEmpty(prefix) ? string.Empty : prefix.TrimEnd('/');
        var group = endpoints.MapGroup(groupPrefix);

        // Register Invocations protocol identity with the version registry (if available)
        var registry = endpoints.ServiceProvider.GetService<ServerVersionRegistry>();
        if (registry is not null)
        {
            registry.Register(ServerVersionRegistry.BuildIdentityString(
                "azure-ai-agentserver-invocations",
                typeof(InvocationsServerEndpointRouteBuilderExtensions).Assembly));
        }

        // POST /invocations — invoke the agent
        group.MapPost("/invocations", async (
            HttpContext httpContext,
            InvocationEndpointHandler handler,
            InvocationHandler invocationHandler) =>
        {
            await handler.HandleInvokeAsync(httpContext, invocationHandler);
        });

        // GET /invocations/{invocationId} — get invocation result
        group.MapGet("/invocations/{invocationId}", async (
            HttpContext httpContext,
            string invocationId,
            InvocationEndpointHandler handler,
            InvocationHandler invocationHandler) =>
        {
            await handler.HandleGetAsync(httpContext, invocationId, invocationHandler);
        });

        // POST /invocations/{invocationId}/cancel — cancel invocation
        group.MapPost("/invocations/{invocationId}/cancel", async (
            HttpContext httpContext,
            string invocationId,
            InvocationEndpointHandler handler,
            InvocationHandler invocationHandler) =>
        {
            await handler.HandleCancelAsync(httpContext, invocationId, invocationHandler);
        });

        // GET /invocations/docs/openapi.json — OpenAPI spec
        group.MapGet("/invocations/docs/openapi.json", async (
            HttpContext httpContext,
            InvocationEndpointHandler handler,
            InvocationHandler invocationHandler) =>
        {
            await handler.HandleGetOpenApiAsync(httpContext, invocationHandler);
        });

        group.WithTags("Invocations");

        return group;
    }
}
