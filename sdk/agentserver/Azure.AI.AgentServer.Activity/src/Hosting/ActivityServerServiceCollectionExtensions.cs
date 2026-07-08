// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Azure.AI.AgentServer.Activity;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/> to register
/// the Activity API server SDK services.
/// </summary>
public static class ActivityServerServiceCollectionExtensions
{
    /// <summary>
    /// Registers the Activity API server SDK services into the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection to add services to.</param>
    /// <param name="configure">Optional callback to configure <see cref="ActivityServerOptions"/>.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddActivityServer(
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

        // Log startup configuration when the host starts.
        services.AddHostedService<Internal.ActivityStartupLogger>();

        return services;
    }
}
