// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Internal;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Azure.AI.AgentServer.Core;

/// <summary>
/// Extension methods for standalone (Tier 3) server setups that do not use
/// <see cref="AgentHostBuilder"/>. Registers all Core middleware services
/// and adds them to the pipeline in one call each.
/// </summary>
/// <remarks>
/// <para>
/// Tier 1 and Tier 2 setups (using <see cref="AgentHost"/> or
/// <see cref="AgentHostBuilder"/>) get this automatically — these methods
/// are only needed when building on raw <c>WebApplicationBuilder</c>.
/// </para>
/// <para>
/// Usage:
/// <code>
/// builder.Services.AddAgentServerCore();
/// var app = builder.Build();
/// app.UseAgentServerCore();
/// </code>
/// </para>
/// </remarks>
public static class AgentHostMiddlewareExtensions
{
    /// <summary>
    /// Registers all Core middleware services: request ID, server version,
    /// request ID baggage propagation, and inbound request logging.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddAgentServerCore(this IServiceCollection services)
    {
        services.TryAddSingleton<ServerVersionRegistry>();
        services.TryAddSingleton<RequestIdMiddleware>();
        services.TryAddSingleton<ServerVersionMiddleware>();
        services.TryAddSingleton<RequestIdBaggagePropagator>();
        services.TryAddSingleton<InboundRequestLoggingMiddleware>();
        services.Configure<AgentHostOptions>(_ => { });
        return services;
    }

    /// <summary>
    /// Adds all Core middleware to the pipeline in the correct order:
    /// request ID → server version → request ID baggage → inbound request logging.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <returns>The application builder for chaining.</returns>
    public static IApplicationBuilder UseAgentServerCore(this IApplicationBuilder app)
    {
        app.UseMiddleware<RequestIdMiddleware>();
        app.UseMiddleware<ServerVersionMiddleware>();
        app.UseMiddleware<RequestIdBaggagePropagator>();
        app.UseMiddleware<InboundRequestLoggingMiddleware>();
        return app;
    }
}
