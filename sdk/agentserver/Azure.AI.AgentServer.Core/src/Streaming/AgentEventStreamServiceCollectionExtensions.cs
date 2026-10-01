// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Core.Streaming;

/// <summary>
/// Registration entry point for the event-streaming feature. Replaces Python's
/// module-global <c>streams</c> singleton with an injectable
/// <see cref="AgentEventStreamRegistry"/>. A backing is selected once at startup via
/// <see cref="AgentEventStreamOptions"/>; the default (no configuration) is the
/// in-memory live backing.
/// </summary>
public static class AgentEventStreamServiceCollectionExtensions
{
    /// <summary>
    /// Adds the event-stream registry using a configuration section with <c>Backing</c>,
    /// <c>StorageDirectory</c>, and <c>Ttl</c> values.
    /// </summary>
    /// <param name="builder">The host application builder.</param>
    /// <param name="sectionName">The configuration section name.</param>
    /// <returns>The same host application builder for chaining.</returns>
    public static IHostApplicationBuilder AddAgentEventStreams(
        this IHostApplicationBuilder builder,
        string sectionName)
    {
        ArgumentNullException.ThrowIfNull(builder);
        if (string.IsNullOrWhiteSpace(sectionName))
        {
            throw new ArgumentException(
                "The event-stream configuration section name must be non-empty.",
                nameof(sectionName));
        }

        AgentEventStreamRegistrationState state = GetOrCreateState(builder.Services);
        state.Add(new AgentEventStreamRegistrationRequest(
            $"configuration section '{sectionName}'",
            AgentEventStreamRegistrationPriority.Application,
            _ => ReadConfiguration(builder.Configuration, sectionName)));

        EnsureRegistry(builder.Services, state);
        return builder;
    }

    /// <summary>
    /// Adds the event-stream registry, selecting and configuring the single backing
    /// for the process.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configure">An optional configurator that selects the backing; defaults to in-memory live.</param>
    /// <returns>The same service collection for chaining.</returns>
    public static IServiceCollection AddAgentEventStreams(
        this IServiceCollection services,
        Action<AgentEventStreamOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(services);

        AgentEventStreamRegistrationState state = GetOrCreateState(services);
        if (configure is not null)
        {
            state.Add(CreateRequest(
                GetApplicationConfigurationSource(),
                AgentEventStreamRegistrationPriority.Application,
                configure));
        }

        EnsureRegistry(services, state);
        return services;
    }

    /// <summary>
    /// Registers a protocol package's default stream backing. Application configuration registered
    /// through <see cref="AddAgentEventStreams(IServiceCollection, Action{AgentEventStreamOptions}?)"/>
    /// takes precedence regardless of registration order.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="source">The protocol component requesting the default.</param>
    /// <param name="configure">The default backing configuration.</param>
    /// <returns>The same service collection for chaining.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static IServiceCollection AddAgentEventStreamsDefault(
        this IServiceCollection services,
        string source,
        Action<AgentEventStreamOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(services);
        if (string.IsNullOrWhiteSpace(source))
        {
            throw new ArgumentException(
                "The protocol stream-default source must be non-empty.",
                nameof(source));
        }

        ArgumentNullException.ThrowIfNull(configure);
        AgentEventStreamRegistrationState state = GetOrCreateState(services);
        state.Add(CreateRequest(
            source,
            AgentEventStreamRegistrationPriority.ProtocolDefault,
            configure));
        EnsureRegistry(services, state);
        return services;
    }

    /// <summary>
    /// Registers a protocol package's default stream backing using the final service provider.
    /// Application configuration still takes precedence regardless of registration order.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="source">The protocol component requesting the default.</param>
    /// <param name="configure">Builds the default backing from effective service options.</param>
    /// <returns>The same service collection for chaining.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static IServiceCollection AddAgentEventStreamsDefault(
        this IServiceCollection services,
        string source,
        Func<IServiceProvider, AgentEventStreamOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(services);
        if (string.IsNullOrWhiteSpace(source))
        {
            throw new ArgumentException(
                "The protocol stream-default source must be non-empty.",
                nameof(source));
        }

        ArgumentNullException.ThrowIfNull(configure);
        AgentEventStreamRegistrationState state = GetOrCreateState(services);
        state.Add(new AgentEventStreamRegistrationRequest(
            source,
            AgentEventStreamRegistrationPriority.ProtocolDefault,
            serviceProvider => configure(serviceProvider).Configuration));
        EnsureRegistry(services, state);
        return services;
    }

    private static AgentEventStreamRegistrationRequest CreateRequest(
        string source,
        AgentEventStreamRegistrationPriority priority,
        Action<AgentEventStreamOptions> configure)
    {
        var options = new AgentEventStreamOptions();
        configure(options);
        return new AgentEventStreamRegistrationRequest(
            source,
            priority,
            _ => options.Configuration);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string GetApplicationConfigurationSource()
    {
        foreach (StackFrame frame in new StackTrace(true).GetFrames())
        {
            if (frame.GetMethod()?.DeclaringType == typeof(AgentEventStreamServiceCollectionExtensions))
            {
                continue;
            }

            string? file = frame.GetFileName();
            int line = frame.GetFileLineNumber();
            if (!string.IsNullOrEmpty(file) && line > 0)
            {
                return $"application configuration at {Path.GetFileName(file)}:{line}";
            }

            string? caller = frame.GetMethod()?.DeclaringType?.FullName;
            if (caller is not null)
            {
                return $"application configuration from {caller}";
            }
        }

        return "application configuration";
    }

    private static AgentEventStreamConfiguration? ReadConfiguration(
        IConfiguration configuration,
        string sectionName)
    {
        IConfigurationSection section = configuration.GetSection(sectionName);
        string? backing = section["Backing"];
        string? storageDirectory = section["StorageDirectory"];
        TimeSpan? ttl = ParseTtl(section["Ttl"], sectionName);

        if (string.IsNullOrWhiteSpace(backing))
        {
            if (storageDirectory is not null || ttl is not null)
            {
                throw new InvalidOperationException(
                    $"Configuration section '{sectionName}' must specify Backing when " +
                    "StorageDirectory or Ttl is set.");
            }

            return null;
        }

        var options = new AgentEventStreamOptions();
        ConfigureBacking(options, backing, storageDirectory, ttl, sectionName);
        return options.Configuration;
    }

    private static void ConfigureBacking(
        AgentEventStreamOptions options,
        string backing,
        string? storageDirectory,
        TimeSpan? ttl,
        string sectionName)
    {
        if (string.Equals(backing, "InMemoryLive", StringComparison.OrdinalIgnoreCase))
        {
            if (storageDirectory is not null || ttl is not null)
            {
                throw new InvalidOperationException(
                    $"Configuration section '{sectionName}' cannot set StorageDirectory or Ttl " +
                    "for the InMemoryLive backing.");
            }

            options.UseInMemoryLive();
            return;
        }

        if (string.Equals(backing, "InMemoryReplay", StringComparison.OrdinalIgnoreCase))
        {
            if (storageDirectory is not null)
            {
                throw new InvalidOperationException(
                    $"Configuration section '{sectionName}' cannot set StorageDirectory " +
                    "for the InMemoryReplay backing.");
            }

            options.UseInMemoryReplay(ttl);
            return;
        }

        if (string.Equals(backing, "FileBackedReplay", StringComparison.OrdinalIgnoreCase))
        {
            options.UseFileBackedReplay(storageDirectory, ttl);
            return;
        }

        throw new InvalidOperationException(
            $"Configuration section '{sectionName}' specifies unsupported AgentEventStream " +
            $"backing '{backing}'. Expected InMemoryLive, InMemoryReplay, or FileBackedReplay.");
    }

    private static TimeSpan? ParseTtl(string? value, string sectionName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        if (!TimeSpan.TryParse(value, CultureInfo.InvariantCulture, out TimeSpan ttl) ||
            ttl < TimeSpan.Zero)
        {
            throw new InvalidOperationException(
                $"Configuration section '{sectionName}' has invalid non-negative Ttl '{value}'.");
        }

        return ttl;
    }

    private static AgentEventStreamRegistrationState GetOrCreateState(
        IServiceCollection services)
    {
        AgentEventStreamRegistrationState? state = services
            .Where(descriptor =>
                descriptor.ServiceType == typeof(AgentEventStreamRegistrationState))
            .Select(descriptor => descriptor.ImplementationInstance)
            .OfType<AgentEventStreamRegistrationState>()
            .FirstOrDefault();

        if (state is not null)
        {
            return state;
        }

        state = new AgentEventStreamRegistrationState();
        services.TryAddSingleton(state);
        return state;
    }

    private static void EnsureRegistry(
        IServiceCollection services,
        AgentEventStreamRegistrationState state)
        => services.TryAddSingleton<AgentEventStreamRegistry>(
            serviceProvider => new InMemoryEventStreamRegistry(
                state.ResolveOptions(serviceProvider),
                serviceProvider
                    .GetService<ILoggerFactory>()
                    ?.CreateLogger("Azure.AI.AgentServer.Streaming")));
}
