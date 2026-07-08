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
/// <see cref="FoundryConnections"/> for outbound token acquisition.
/// </remarks>
internal static class ActivityStack
{
    /// <summary>
    /// Resolves the derived M365 <c>CONNECTIONS__*</c> connection settings for the selected
    /// outbound-auth model, as a configuration map (never mutates the environment).
    /// </summary>
    /// <param name="options">The activity server options (selects the outbound-auth model).</param>
    /// <returns>The effective connection settings keyed by their M365 configuration names.</returns>
    public static IReadOnlyDictionary<string, string?> GetConnectionConfiguration(ActivityServerOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        return ActivityEnvironment.GetHostedAgentConfiguration(options.DigitalWorker);
    }

    /// <summary>
    /// Registers the Microsoft 365 Agents SDK services into the given service collection so the
    /// SDK's <c>CloudAdapter</c> (and its background activity service) are available from the
    /// application's dependency-injection container.
    /// </summary>
    /// <param name="services">The host service collection.</param>
    public static void RegisterM365Services(IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        // In-memory storage for local/testing; a durable backend can be injected by the caller
        // via the injected-AgentApplication construction mode.
        services.TryAddSingleton<IStorage, MemoryStorage>();

        // Register AgentApplicationOptions and the core M365 adapter services
        // (IConnections, IChannelServiceClientFactory, CloudAdapter/IAgentHttpAdapter, and the
        // background HostedActivityService that drains normal-delivery turns).
        services.AddAgentApplicationOptions();
        services.AddAgentCore<CloudAdapter>();

        // Replace the default configuration-driven IConnections with the Foundry connections
        // that acquire Bot Connector tokens via the container's managed identity / FMI exchange.
        services.Replace(ServiceDescriptor.Singleton<IConnections, FoundryConnections>());
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
        services.AddHttpClient();
        services.AddSingleton<IConfiguration>(
            new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddInMemoryCollection(GetConnectionConfiguration(options))
                .Build());
        RegisterM365Services(services);

        using var provider = services.BuildServiceProvider();
        return new AgentApplication(provider.GetRequiredService<AgentApplicationOptions>());
    }
}
