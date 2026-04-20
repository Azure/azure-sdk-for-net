// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Internal;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Azure.AI.AgentServer.Core;

/// <summary>
/// Extension methods for standalone (Tier 3) server setups that do not use
/// <see cref="AgentHostBuilder"/>. Provides fine-grained control over which
/// Core middleware features to enable.
/// </summary>
public static class AgentHostMiddlewareExtensions
{
    /// <summary>
    /// Registers the server version services (<see cref="ServerVersionRegistry"/>
    /// and middleware) required for the <c>x-platform-server</c> response header.
    /// Call this before <see cref="UseAgentServerVersion"/> when not using
    /// <see cref="AgentHostBuilder"/>.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddAgentServerVersion(this IServiceCollection services)
    {
        services.TryAddSingleton<ServerVersionRegistry>();
        services.TryAddSingleton<ServerVersionMiddleware>();
        services.Configure<AgentHostOptions>(_ => { });
        return services;
    }

    /// <summary>
    /// Adds the server version middleware to the pipeline.
    /// This middleware sets the <c>x-platform-server</c> header on all HTTP responses.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <returns>The application builder for chaining.</returns>
    public static IApplicationBuilder UseAgentServerVersion(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ServerVersionMiddleware>();
    }

    /// <summary>
    /// Registers the inbound request logging middleware.
    /// Call this before <see cref="UseAgentServerLogging"/> when not using
    /// <see cref="AgentHostBuilder"/>.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddAgentServerLogging(this IServiceCollection services)
    {
        services.TryAddSingleton<InboundRequestLoggingMiddleware>();
        return services;
    }

    /// <summary>
    /// Adds the inbound request logging middleware to the pipeline.
    /// This middleware logs request/response details including method, path,
    /// status code, duration, and trace ID.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <returns>The application builder for chaining.</returns>
    public static IApplicationBuilder UseAgentServerLogging(this IApplicationBuilder app)
    {
        return app.UseMiddleware<InboundRequestLoggingMiddleware>();
    }
}
