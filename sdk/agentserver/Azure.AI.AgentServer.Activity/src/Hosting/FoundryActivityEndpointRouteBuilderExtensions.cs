// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Activity.Internal;
using Azure.AI.AgentServer.Core;
using Microsoft.Agents.Builder;
using Microsoft.Agents.Hosting.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Activity;

/// <summary>
/// Endpoint-mapping extensions that expose a Microsoft 365 Agents SDK <c>AgentApplication</c> over
/// the Foundry Activity protocol. These are the Foundry counterpart to the SDK's
/// <c>MapAgentApplicationEndpoints</c>: an existing Microsoft 365 agent converts to a Foundry
/// hosted agent by swapping <c>MapAgentApplicationEndpoints(...)</c> for <c>MapFoundryActivity()</c>.
/// </summary>
public static class FoundryActivityEndpointRouteBuilderExtensions
{
    /// <summary>The Activity protocol inbound endpoint paths, shared by every hosting entry point.</summary>
    internal static readonly string[] ActivityPaths = { "/activity/messages", "/api/messages" };

    /// <summary>
    /// Adds the Foundry platform middleware, health probe, and Activity protocol endpoints to a
    /// <see cref="WebApplication"/>. This is the one-call app-side setup that replaces the Microsoft
    /// 365 SDK's <c>UseAuthentication()</c> / <c>UseAuthorization()</c> /
    /// <c>MapAgentApplicationEndpoints(...)</c> sequence.
    /// </summary>
    /// <param name="app">The web application.</param>
    /// <returns>The web application, for chaining.</returns>
    public static WebApplication MapFoundryActivity(this WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        // Foundry platform middleware: request-id, correlation baggage, inbound logging, and
        // WebSocket upgrade handling (the same pipeline the AgentHost builder installs).
        app.UseAgentServerCore();

        // Platform readiness probe.
        app.MapHealthChecks("/readiness");

        // Activity protocol endpoints.
        ((IEndpointRouteBuilder)app).MapFoundryActivity();

        return app;
    }

    /// <summary>
    /// Maps the Foundry Activity protocol endpoints (<c>POST /api/messages</c> and
    /// <c>POST /activity/messages</c>) onto an existing endpoint route builder. Use this overload
    /// when you compose the middleware pipeline yourself; otherwise prefer
    /// <see cref="MapFoundryActivity(WebApplication)"/>.
    /// </summary>
    /// <param name="endpoints">The endpoint route builder.</param>
    /// <returns>The endpoint route builder, for chaining.</returns>
    public static IEndpointRouteBuilder MapFoundryActivity(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        // Register the Activity protocol identity with the version registry (if available).
        var registry = endpoints.ServiceProvider.GetService<ServerVersionRegistry>();
        registry?.Register(ServerVersionRegistry.BuildIdentityString(
            "azure-ai-agentserver-activity",
            typeof(FoundryActivityEndpointRouteBuilderExtensions).Assembly));

        foreach (var path in ActivityPaths)
        {
            endpoints.MapPost(path, static async (
                HttpContext context,
                IAgentHttpAdapter adapter,
                IAgent agent,
                ActivityEndpointHandler handler,
                CancellationToken cancellationToken) =>
            {
                await handler.HandleAsync(context, adapter, agent, cancellationToken).ConfigureAwait(false);
            }).AddEndpointFilter<ActivityErrorSourceFilter>();
        }

        return endpoints;
    }

    /// <summary>
    /// Maps the Foundry Activity protocol endpoints (<c>POST /api/messages</c> and
    /// <c>POST /activity/messages</c>) onto an existing endpoint route builder, routing each request
    /// to the supplied <paramref name="requestHandler"/> instead of the Microsoft 365 Agents SDK
    /// adapter. Use this to own the request pipeline in a self-hosted app while still getting the
    /// Foundry platform contract (session-id response header, correlation baggage, and error-source
    /// classification). The Microsoft 365 Agents SDK is <b>not</b> used on this path.
    /// </summary>
    /// <param name="endpoints">The endpoint route builder.</param>
    /// <param name="requestHandler">The request handler invoked for each inbound activity request.</param>
    /// <returns>The endpoint route builder, for chaining.</returns>
    public static IEndpointRouteBuilder MapFoundryActivity(
        this IEndpointRouteBuilder endpoints,
        RequestDelegate requestHandler)
    {
        ArgumentNullException.ThrowIfNull(endpoints);
        ArgumentNullException.ThrowIfNull(requestHandler);

        // Register the Activity protocol identity with the version registry (if available).
        var registry = endpoints.ServiceProvider.GetService<ServerVersionRegistry>();
        registry?.Register(ServerVersionRegistry.BuildIdentityString(
            "azure-ai-agentserver-activity",
            typeof(FoundryActivityEndpointRouteBuilderExtensions).Assembly));

        foreach (var path in ActivityPaths)
        {
            endpoints.MapPost(path, async (HttpContext context, ActivityEndpointHandler handler) =>
            {
                // Apply the Foundry platform response contract (session-id header + baggage) around
                // the caller's handler; the caller owns reading the request and writing the response.
                handler.StampSessionAndBaggage(context);
                await requestHandler(context).ConfigureAwait(false);
            }).AddEndpointFilter<ActivityErrorSourceFilter>();
        }

        return endpoints;
    }

    /// <summary>
    /// Alias for <see cref="MapFoundryActivity(WebApplication)"/>.
    /// </summary>
    /// <param name="app">The web application.</param>
    /// <returns>The web application, for chaining.</returns>
    public static WebApplication MapActivityServer(this WebApplication app) => app.MapFoundryActivity();

    /// <summary>
    /// Alias for <see cref="MapFoundryActivity(IEndpointRouteBuilder)"/>.
    /// </summary>
    /// <param name="endpoints">The endpoint route builder.</param>
    /// <returns>The endpoint route builder, for chaining.</returns>
    public static IEndpointRouteBuilder MapActivityServer(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapFoundryActivity();

    /// <summary>
    /// Alias for <see cref="MapFoundryActivity(IEndpointRouteBuilder, RequestDelegate)"/>.
    /// </summary>
    /// <param name="endpoints">The endpoint route builder.</param>
    /// <param name="requestHandler">The request handler invoked for each inbound activity request.</param>
    /// <returns>The endpoint route builder, for chaining.</returns>
    public static IEndpointRouteBuilder MapActivityServer(
        this IEndpointRouteBuilder endpoints,
        RequestDelegate requestHandler) =>
        endpoints.MapFoundryActivity(requestHandler);
}
