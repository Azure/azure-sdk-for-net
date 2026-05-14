// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Invocations.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Azure.AI.AgentServer.Invocations;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/> to register
/// the Invocations API server SDK services.
/// </summary>
public static class InvocationsServerServiceCollectionExtensions
{
    /// <summary>
    /// Registers the Invocations API server SDK services into the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection to add services to.</param>
    /// <param name="configure">Optional callback to configure <see cref="InvocationsServerOptions"/>.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddInvocationsServer(
        this IServiceCollection services,
        Action<InvocationsServerOptions>? configure = null)
    {
        if (configure is not null)
        {
            services.Configure(configure);
        }
        else
        {
            services.Configure<InvocationsServerOptions>(_ => { });
        }

        // Register activity source as singleton (virtual → mockable)
        services.TryAddSingleton<InvocationsActivitySource>();

        // Register endpoint handler as scoped (per-request)
        services.AddScoped<InvocationEndpointHandler>();

        // Log startup configuration when the host starts
        services.AddHostedService<InvocationsStartupLogger>();

        return services;
    }
}
