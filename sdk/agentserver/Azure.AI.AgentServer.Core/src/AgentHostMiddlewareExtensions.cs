// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Internal;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Azure.AI.AgentServer.Core;

/// <summary>
/// Extension methods for standalone (Tier 3) server setups that do not use
/// <see cref="AgentHostBuilder"/>. Registers the <c>x-platform-server</c>
/// user-agent middleware and its dependencies.
/// </summary>
public static class AgentHostMiddlewareExtensions
{
    /// <summary>
    /// Registers the server user-agent services (<see cref="ServerUserAgentRegistry"/>
    /// and middleware) required for the <c>x-platform-server</c> response header.
    /// Call this before <see cref="UseAgentServerUserAgent"/> when not using
    /// <see cref="AgentHostBuilder"/>.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddAgentServerUserAgent(this IServiceCollection services)
    {
        services.TryAddSingleton<ServerUserAgentRegistry>();
        services.TryAddSingleton<ServerUserAgentMiddleware>();
        services.TryAddSingleton<InboundRequestLoggingMiddleware>();
        services.Configure<AgentHostOptions>(_ => { });
        return services;
    }

    /// <summary>
    /// Adds the server user-agent middleware to the pipeline.
    /// This middleware sets the <c>x-platform-server</c> header on all HTTP responses.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <returns>The application builder for chaining.</returns>
    public static IApplicationBuilder UseAgentServerUserAgent(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ServerUserAgentMiddleware>();
    }
}
