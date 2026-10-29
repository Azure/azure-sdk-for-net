// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using global::A2A;
using global::A2A.AspNetCore;
using Azure.AI.AgentServer.A2A.Internal;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.A2A;

/// <summary>
/// Endpoint mapping extensions for the Foundry A2A container contract.
/// </summary>
public static class FoundryA2AEndpointRouteBuilderExtensions
{
    /// <summary>Adds Core middleware, readiness, and the A2A endpoints to an existing application.</summary>
    /// <param name="app">The application.</param>
    /// <returns>The application for chaining.</returns>
    /// <remarks>
    /// Maps the JSON-RPC endpoint at <c>/a2a</c>, the public Agent Card at
    /// <c>/a2a/.well-known/agent-card.json</c>, and readiness at <c>/readiness</c>.
    /// The application owns its listening port, telemetry exporters, and shutdown settings.
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="app"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">The native card or request handler is not registered.</exception>
    /// <exception cref="ArgumentException">The card advertises an unsupported capability.</exception>
    public static WebApplication MapFoundryA2A(this WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);
        app.UseAgentServerCore();
        app.MapHealthChecks("/readiness");
        ((IEndpointRouteBuilder)app).MapFoundryA2A();
        return app;
    }

    /// <summary>Maps JSON-RPC and public card routes; the caller owns Core middleware and readiness.</summary>
    /// <param name="endpoints">The route builder.</param>
    /// <returns>The route builder for chaining.</returns>
    /// <remarks>
    /// Requires a native <see cref="AgentCard"/> and <see cref="IA2ARequestHandler"/> in dependency
    /// injection. This overload maps only protocol routes. Install Core middleware and readiness
    /// separately, or use <see cref="MapFoundryA2A(WebApplication)"/>.
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="endpoints"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">The native card or request handler is not registered.</exception>
    /// <exception cref="ArgumentException">The card advertises an unsupported capability.</exception>
    public static IEndpointRouteBuilder MapFoundryA2A(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);
        var card = endpoints.ServiceProvider.GetRequiredService<AgentCard>();
        if (card.Capabilities.PushNotifications == true || card.Capabilities.ExtendedAgentCard == true)
        {
            throw new ArgumentException("Foundry A2A hosting does not expose push notifications or extended agent cards.");
        }

        var handler = new FoundryA2ARequestHandler(
            endpoints.ServiceProvider.GetRequiredService<IA2ARequestHandler>(),
            endpoints.ServiceProvider.GetRequiredService<ILogger<FoundryA2ARequestHandler>>());
        var registry = endpoints.ServiceProvider.GetService<ServerVersionRegistry>();
        registry?.Register(ServerVersionRegistry.BuildIdentityString(
            "azure-ai-agentserver-a2a", typeof(FoundryA2AEndpointRouteBuilderExtensions).Assembly));

        var routes = endpoints.MapGroup("");
        routes.AddEndpointFilter((context, next) =>
            ValueTask.FromResult<object?>(new A2ATransportResult(() => next(context))));

        routes.MapPost("/a2a", () => new A2ARpcResult(handler, card));
        routes.MapWellKnownAgentCard(card, "/a2a");

        return endpoints;
    }
}
