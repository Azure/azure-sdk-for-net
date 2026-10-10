// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tasks.Engine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>Opt-in configuration for the resilient-task subsystem.</summary>
public static class ResilientTaskEnablementExtensions
{
    /// <summary>
    /// Enables or disables durable task execution and recovery for the application service
    /// collection. The default is disabled; call this before host startup to opt in.
    /// </summary>
    /// <param name="services">The application services.</param>
    /// <param name="enabled"><see langword="true"/> to enable resilient tasks.</param>
    /// <returns>The same service collection for chaining.</returns>
    public static IServiceCollection SetResilientTasksEnabled(
        this IServiceCollection services,
        bool enabled = true)
    {
        ArgumentNullException.ThrowIfNull(services);
        ResilientTaskEnablementState state = GetOrCreateState(services);
        state.SetConfigured(enabled);
        services.Configure<ResilientTaskOptions>(options => options.Enabled = enabled);
        if (enabled)
        {
            // Force-enable parity with Python: opting in by itself prepares the manager/recovery
            // graph, even when no task has been declared yet. Construction remains lazy until host
            // startup, so task storage and credentials are still not resolved during registration.
            services.AddResilientTasks();
        }

        return services;
    }

    /// <summary>
    /// Enables or disables durable task execution and recovery for an application host.
    /// </summary>
    /// <param name="host">The host application builder.</param>
    /// <param name="enabled"><see langword="true"/> to enable resilient tasks.</param>
    /// <returns>The same host builder for chaining.</returns>
    public static IHostApplicationBuilder SetResilientTasksEnabled(
        this IHostApplicationBuilder host,
        bool enabled = true)
    {
        ArgumentNullException.ThrowIfNull(host);
        host.Services.SetResilientTasksEnabled(enabled);
        return host;
    }

    /// <summary>
    /// Enables or disables durable task execution and recovery for an agent host.
    /// </summary>
    /// <param name="builder">The agent host builder.</param>
    /// <param name="enabled"><see langword="true"/> to enable resilient tasks.</param>
    /// <returns>The same agent host builder for chaining.</returns>
    public static AgentHostBuilder SetResilientTasksEnabled(
        this AgentHostBuilder builder,
        bool enabled = true)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.Services.SetResilientTasksEnabled(enabled);
        return builder;
    }

    internal static ResilientTaskEnablementState GetOrCreateState(IServiceCollection services)
    {
        for (int i = 0; i < services.Count; i++)
        {
            ServiceDescriptor descriptor = services[i];
            if (descriptor.ServiceType == typeof(ResilientTaskEnablementState)
                && descriptor.ImplementationInstance is ResilientTaskEnablementState existing)
            {
                return existing;
            }
        }

        var created = new ResilientTaskEnablementState();
        services.AddSingleton(created);
        return created;
    }
}
