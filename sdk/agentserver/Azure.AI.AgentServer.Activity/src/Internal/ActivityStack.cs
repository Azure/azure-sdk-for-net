// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.Agents.Authentication;
using Microsoft.Agents.Builder.App;
using Microsoft.Agents.Hosting.AspNetCore;
using Microsoft.Agents.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Azure.AI.AgentServer.Activity.Internal;

/// <summary>
/// Wires the Microsoft 365 Agents SDK stack into the host, using the real compile-time SDK APIs.
/// </summary>
/// <remarks>
/// This registers the SDK's own <c>CloudAdapter</c> (via <c>AddAgentCore</c>) so its background
/// <c>HostedActivityService</c> runs for the host's lifetime — meaning the activity endpoint can
/// use the SDK's native <c>IAgentHttpAdapter.ProcessAsync</c> exactly as a native Microsoft 365
/// Agents SDK application would. The only Foundry-specific substitution is
/// <see cref="FoundryConnections"/> for outbound token acquisition (unless the caller supplies
/// their own via <see cref="ActivityServerOptions.Connections"/>).
/// </remarks>
internal static class ActivityStack
{
    /// <summary>
    /// Resolves the M365 <c>CONNECTIONS__*</c> connection settings for the selected outbound-auth
    /// model, as a configuration map (never mutates the environment). A caller-supplied
    /// <see cref="ActivityServerOptions.ConnectionConfiguration"/> is used as-is when present;
    /// otherwise the settings are derived from the Foundry-native identity.
    /// </summary>
    /// <param name="options">The activity server options (selects the outbound-auth model).</param>
    /// <returns>The effective connection settings keyed by their M365 configuration names.</returns>
    public static IReadOnlyDictionary<string, string?> GetConnectionConfiguration(ActivityServerOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        return options.ConnectionConfiguration
            ?? ActivityEnvironment.GetHostedAgentConfiguration(options.DigitalWorker);
    }

    /// <summary>
    /// Registers the Microsoft 365 Agents SDK services into the given service collection so the
    /// SDK's <c>CloudAdapter</c> (and its background activity service) are available from the
    /// application's dependency-injection container.
    /// </summary>
    /// <param name="services">The host service collection.</param>
    /// <param name="options">The activity server options (supplies optional service overrides).</param>
    public static void RegisterM365Services(IServiceCollection services, ActivityServerOptions options)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(options);

        // The M365 channel client factory (RestChannelServiceClientFactory) depends on
        // IHttpClientFactory for its outbound connector calls.
        services.AddHttpClient();

        // Let the caller register overrides first. AddAgentCore only registers its defaults when a
        // service is not already present, so anything registered here (custom adapter, channel
        // factory, authorization, ...) takes precedence over the SDK defaults below.
        options.ConfigureServices?.Invoke(services);

        // Storage backend for the SDK turn state: the caller-supplied instance, else an in-memory
        // store. TryAdd respects an override registered via ConfigureServices as well.
        if (options.Storage is not null)
        {
            services.TryAddSingleton(options.Storage);
        }

        services.TryAddSingleton<IStorage, MemoryStorage>();

        // Outbound-auth connection provider: the caller-supplied instance, else the Foundry
        // connections. Registering it before AddAgentCore makes the SDK skip its default
        // (ConfigurationConnections).
        if (options.Connections is not null)
        {
            services.TryAddSingleton(options.Connections);
        }

        // Register AgentApplicationOptions and the core M365 adapter services
        // (IConnections, IChannelServiceClientFactory, CloudAdapter/IAgentHttpAdapter, and the
        // background HostedActivityService that drains normal-delivery turns).
        services.AddAgentApplicationOptions();
        services.AddAgentCore<CloudAdapter>();

        // When the caller did not supply their own connections, substitute the Foundry connections
        // that acquire Bot Connector tokens via the container's managed identity / FMI exchange.
        if (options.Connections is null)
        {
            services.Replace(ServiceDescriptor.Singleton<IConnections, FoundryConnections>());
        }
    }

    /// <summary>
    /// Creates a fresh Microsoft 365 Agents SDK <see cref="AgentApplication"/> for handler
    /// registration. The application instance is later hosted by the SDK adapter registered into
    /// the application host via <see cref="RegisterM365Services"/>.
    /// </summary>
    /// <param name="options">The activity server options (selects the outbound-auth model).</param>
    /// <returns>A new, empty <see cref="AgentApplication"/> ready for handler registration.</returns>
    public static AgentApplication CreateAgentApplication(ActivityServerOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        // A minimal standalone provider is used solely to resolve AgentApplicationOptions so the
        // application instance can be created eagerly (before the host is built) for handler
        // registration. The request-time adapter and background service come from the real host.
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddSingleton<IConfiguration>(
            new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddInMemoryCollection(GetConnectionConfiguration(options))
                .Build());
        RegisterM365Services(services, options);

        using var provider = services.BuildServiceProvider();
        return new AgentApplication(provider.GetRequiredService<AgentApplicationOptions>());
    }
}
