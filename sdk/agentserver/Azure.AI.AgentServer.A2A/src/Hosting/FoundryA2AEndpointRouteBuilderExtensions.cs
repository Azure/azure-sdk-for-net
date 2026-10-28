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

namespace Azure.AI.AgentServer.A2A;

/// <summary>Maps the Foundry A2A container endpoints using the native A2A transport.</summary>
public static class FoundryA2AEndpointRouteBuilderExtensions
{
    /// <summary>Adds Core middleware, readiness, and the A2A endpoints to an existing application.</summary>
    /// <param name="app">The application.</param>
    /// <returns>The application for chaining.</returns>
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
    public static IEndpointRouteBuilder MapFoundryA2A(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);
        var card = endpoints.ServiceProvider.GetRequiredService<AgentCard>();
        if (card.Capabilities.PushNotifications == true || card.Capabilities.ExtendedAgentCard == true)
        {
            throw new ArgumentException("Foundry A2A hosting does not expose push notifications or extended agent cards.");
        }

        var handler = new FoundryA2ARequestHandler(endpoints.ServiceProvider.GetRequiredService<IA2ARequestHandler>());
        var registry = endpoints.ServiceProvider.GetService<ServerVersionRegistry>();
        registry?.Register(ServerVersionRegistry.BuildIdentityString(
            "azure-ai-agentserver-a2a", typeof(FoundryA2AEndpointRouteBuilderExtensions).Assembly));

        var routes = endpoints.MapGroup("");
        routes.AddEndpointFilter((context, next) =>
            ValueTask.FromResult<object?>(new A2ATransportResult(() => next(context))));

        foreach (var path in new[] { "/a2a", "/invocations/a2a" })
        {
            routes.MapPost(path, () => new A2ARpcResult(handler, card));
            routes.MapWellKnownAgentCard(card, path);
        }

        return endpoints;
    }
}
