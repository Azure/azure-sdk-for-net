// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Azure.AI.AgentServer.Activity;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/> to register
/// the Activity API server SDK services.
/// </summary>
internal static class ActivityServerServiceCollectionExtensions
{
    /// <summary>
    /// Registers the Activity package's shared services (options, tracing/baggage helper, the
    /// request-time endpoint handler, and the startup logger) into the dependency injection
    /// container. This is an internal building block used by <see cref="FoundryActivityHostingExtensions"/>
    /// and <see cref="ActivityServer"/>; callers use <c>AddFoundryActivity()</c> /
    /// <c>AddActivityServer()</c> instead.
    /// </summary>
    /// <param name="services">The service collection to add services to.</param>
    /// <param name="configure">Optional callback to configure <see cref="ActivityServerOptions"/>.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddActivityServerServices(
        this IServiceCollection services,
        Action<ActivityServerOptions>? configure = null)
    {
        if (configure is not null)
        {
            services.Configure(configure);
        }
        else
        {
            services.Configure<ActivityServerOptions>(_ => { });
        }

        // Register the tracing/baggage helper as a singleton (virtual → mockable).
        services.TryAddSingleton<ActivityProtocolActivitySource>();

        // Register the request-time endpoint handler shared by every hosting entry point.
        services.TryAddSingleton<Internal.ActivityEndpointHandler>();

        // Log startup configuration when the host starts.
        services.AddHostedService<Internal.ActivityStartupLogger>();

        return services;
    }
}
