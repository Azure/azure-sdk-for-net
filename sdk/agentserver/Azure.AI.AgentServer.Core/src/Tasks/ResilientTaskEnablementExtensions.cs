// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
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
        state.SetExplicitlyEnabled(enabled);
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

    /// <summary>
    /// Scopes task access to the current protocol and stamps that owner on newly created tasks.
    /// Without an explicit value, access follows the protocol's registered activation.
    /// </summary>
    /// <param name="provider">The owning application's service provider.</param>
    /// <param name="protocol">The owning protocol's stable identity.</param>
    /// <param name="enabled">Whether the protocol has enabled task execution, or
    /// <see langword="null"/> to use the explicit Core opt-in.</param>
    /// <returns>A scope that restores the prior protocol's task access when disposed.</returns>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public static IDisposable EnterResilientTaskScope(
        this IServiceProvider provider, string protocol, bool? enabled = null)
    {
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentException.ThrowIfNullOrWhiteSpace(protocol);
        ResilientTaskEnablementState? state = provider.GetService<ResilientTaskEnablementState>();
        return TaskEngineAccessor.EnterProtocolScope(
            state, protocol, enabled ?? state?.IsProtocolEnabled(protocol) == true);
    }

    /// <summary>Registers a host-owned protocol's task activation for recovery after restart.</summary>
    /// <param name="services">The application services.</param>
    /// <param name="protocol">The same stable identity used for the protocol's task scopes.</param>
    /// <param name="enabled">Resolve whether this host has enabled the protocol's task execution.</param>
    /// <returns>The same service collection for chaining.</returns>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public static IServiceCollection RegisterResilientTaskProtocol(
        this IServiceCollection services, string protocol, Func<bool> enabled)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentException.ThrowIfNullOrWhiteSpace(protocol);
        ArgumentNullException.ThrowIfNull(enabled);
        if (protocol is TaskWireKeys.ProtocolCore or TaskWireKeys.ProtocolInvocations)
        {
            throw new ArgumentException("Core and Invocations task activation is set by the Core opt-in.", nameof(protocol));
        }

        GetOrCreateState(services).RegisterProtocol(protocol, enabled);
        return services;
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
