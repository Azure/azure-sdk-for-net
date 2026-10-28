// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using global::A2A;
using global::A2A.AspNetCore;
using Azure.AI.AgentServer.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenTelemetry.Trace;

namespace Azure.AI.AgentServer.A2A;

/// <summary>Registers native A2A applications with the Foundry hosting infrastructure.</summary>
public static class FoundryA2AHostingExtensions
{
    /// <summary>Adds Foundry hosting to an application with native A2A services already registered.</summary>
    /// <param name="services">The service collection containing the native card and request handler.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddFoundryA2A(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        RegisterHosting(services);
        return services;
    }

    /// <summary>Registers a native agent handler, preserving any explicitly registered task store.</summary>
    /// <typeparam name="THandler">The native agent handler type.</typeparam>
    /// <param name="services">The service collection.</param>
    /// <param name="agentCard">The native public agent card.</param>
    /// <param name="configure">Optional native server configuration.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddFoundryA2A<
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THandler>(
        this IServiceCollection services,
        AgentCard agentCard,
        Action<A2AServerOptions>? configure = null)
        where THandler : class, IAgentHandler
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(agentCard);

        if (FoundryEnvironment.IsHosted)
        {
            services.TryAddSingleton<ITaskStore>(_ => new FoundryTaskStore(
                $"a2a/tasks/{FoundryEnvironment.AgentId ?? FoundryEnvironment.AgentName ?? agentCard.Name}"));
        }

        services.AddA2AAgent<THandler>(agentCard, configure);
        RegisterHosting(services);
        return services;
    }

    /// <summary>Hosts an existing native request handler without replacing its storage or lifecycle.</summary>
    /// <param name="services">The service collection.</param>
    /// <param name="agentCard">The native public agent card.</param>
    /// <param name="requestHandler">The existing native request handler.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddFoundryA2A(
        this IServiceCollection services,
        AgentCard agentCard,
        IA2ARequestHandler requestHandler)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(agentCard);
        ArgumentNullException.ThrowIfNull(requestHandler);
        services.AddSingleton(agentCard);
        services.AddSingleton(requestHandler);
        RegisterHosting(services);
        return services;
    }

    private static void RegisterHosting(IServiceCollection services)
    {
        services.AddAgentServerCore();
        services.AddHealthChecks();
        services.AddOpenTelemetry().WithTracing(tracing => tracing.AddSource(Internal.A2ARpcResult.SourceName));
    }
}
