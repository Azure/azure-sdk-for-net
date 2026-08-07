// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Invocations.Internal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Patterns;
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
    /// <param name="prefix">
    /// Optional literal route prefix (e.g., <c>/v1</c>). Parameters and
    /// catch-alls are not supported. The default maps routes at the root.
    /// </param>
    /// <returns>A <see cref="RouteGroupBuilder"/> for further endpoint configuration.</returns>
    /// <exception cref="InvalidOperationException">
    /// Invocations services were not registered before mapping.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="prefix"/> is not an absolute literal route prefix.
    /// </exception>
    public static RouteGroupBuilder MapInvocationsServer(
        this IEndpointRouteBuilder endpoints,
        string? prefix = null)
    {
        ArgumentNullException.ThrowIfNull(endpoints);
        if (endpoints.ServiceProvider.GetService<InvocationsEndpointOwnershipRegistration>() is null)
        {
            throw new InvalidOperationException(
                "Invocations services are not registered. Call AddInvocationsServer() " +
                "before MapInvocationsServer().");
        }

        var groupPrefix = NormalizeLiteralPrefix(prefix);
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
            InvocationEndpointHandler endpointHandler,
            InvocationHandler userHandler) =>
        {
            await endpointHandler.HandleInvokeAsync(httpContext, userHandler);
        }).AddEndpointFilter<InvocationsErrorSourceFilter>();

        // GET /invocations/{invocationId} — get invocation result
        group.MapGet("/invocations/{invocationId}", async (
            HttpContext httpContext,
            string invocationId,
            InvocationEndpointHandler endpointHandler,
            InvocationHandler userHandler) =>
        {
            await endpointHandler.HandleGetAsync(httpContext, invocationId, userHandler);
        }).AddEndpointFilter<InvocationsErrorSourceFilter>();

        // POST /invocations/{invocationId}/cancel — cancel invocation
        group.MapPost("/invocations/{invocationId}/cancel", async (
            HttpContext httpContext,
            string invocationId,
            InvocationEndpointHandler endpointHandler,
            InvocationHandler userHandler) =>
        {
            await endpointHandler.HandleCancelAsync(httpContext, invocationId, userHandler);
        }).AddEndpointFilter<InvocationsErrorSourceFilter>();

        // GET /invocations/docs/openapi.json — OpenAPI spec
        group.MapGet("/invocations/docs/openapi.json", async (
            HttpContext httpContext,
            InvocationEndpointHandler endpointHandler,
            InvocationHandler userHandler) =>
        {
            await endpointHandler.HandleGetOpenApiAsync(httpContext, userHandler);
        }).AddEndpointFilter<InvocationsErrorSourceFilter>();

        // GET /invocations/docs/asyncapi.json — AsyncAPI spec (JSON)
        group.MapGet("/invocations/docs/asyncapi.json", async (
            HttpContext httpContext,
            InvocationEndpointHandler endpointHandler,
            InvocationHandler userHandler) =>
        {
            await endpointHandler.HandleGetAsyncApiJsonAsync(httpContext, userHandler);
        }).AddEndpointFilter<InvocationsErrorSourceFilter>();

        // GET /invocations/docs/asyncapi.yaml — AsyncAPI spec (YAML)
        group.MapGet("/invocations/docs/asyncapi.yaml", async (
            HttpContext httpContext,
            InvocationEndpointHandler endpointHandler,
            InvocationHandler userHandler) =>
        {
            await endpointHandler.HandleGetAsyncApiYamlAsync(httpContext, userHandler);
        }).AddEndpointFilter<InvocationsErrorSourceFilter>();

        // /invocations_ws — WebSocket transport.
        // Endpoint short-circuits to 404 when the handler does not override
        // `InvocationHandler.HandleWebSocketAsync`, so an upgrade attempt
        // against a host without a registered WS handler fails fast with
        // "endpoint not registered".
        group.MapGet(InvocationsWebSocketConstants.RoutePath, async (
            HttpContext httpContext,
            WebSocketEndpointHandler endpointHandler,
            InvocationHandler userHandler) =>
        {
            await endpointHandler.HandleAsync(httpContext, userHandler);
        }).WithMetadata(InvocationsEndpointOwnerMetadata.Instance);

        group.WithTags("Invocations");

        return group;
    }

    private static string NormalizeLiteralPrefix(string? prefix)
    {
        if (string.IsNullOrEmpty(prefix) || prefix == "/")
        {
            return string.Empty;
        }

        if (!prefix.StartsWith("/", StringComparison.Ordinal))
        {
            throw new ArgumentException("The route prefix must start with '/'.", nameof(prefix));
        }

        var normalized = prefix.TrimEnd('/');
        var pattern = RoutePatternFactory.Parse(normalized);
        if (!InvocationsEndpointOwnershipValidator.TryGetLiteralPath(pattern, out _))
        {
            throw new ArgumentException(
                "The route prefix must contain only literal path segments.",
                nameof(prefix));
        }

        return normalized;
    }
}
