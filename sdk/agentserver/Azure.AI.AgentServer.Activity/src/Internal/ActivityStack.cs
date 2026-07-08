// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Agents.Authentication;
using Microsoft.Agents.Builder;
using Microsoft.Agents.Builder.App;
using Microsoft.Agents.Hosting.AspNetCore;
using Microsoft.Agents.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Azure.AI.AgentServer.Activity.Internal;

/// <summary>
/// Builds the Microsoft 365 Agents SDK stack (an <see cref="AgentApplication"/> and its
/// <see cref="IAgentHttpAdapter"/>) eagerly, using the real compile-time SDK APIs.
/// This is the .NET counterpart of the Python package's <c>_m365_bridge.build_m365_app</c>.
/// </summary>
internal static class ActivityStack
{
    /// <summary>
    /// Builds a fresh M365 <see cref="AgentApplication"/> and adapter from the environment.
    /// </summary>
    /// <param name="options">The activity server options (selects the outbound-auth model).</param>
    /// <returns>The built application and its HTTP adapter.</returns>
    public static (AgentApplication AgentApp, IAgentHttpAdapter Adapter) Build(ActivityServerOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        var provider = BuildProvider(options);
        var appOptions = provider.GetRequiredService<AgentApplicationOptions>();
        var agentApp = new AgentApplication(appOptions);
        var adapter = provider.GetRequiredService<IAgentHttpAdapter>();

        return (agentApp, adapter);
    }

    /// <summary>
    /// Builds a standalone M365 HTTP adapter (used to drive a pre-built, injected
    /// <see cref="AgentApplication"/>). The adapter takes the agent as a per-turn argument,
    /// so a freshly built adapter can process any application.
    /// </summary>
    /// <param name="options">The activity server options (selects the outbound-auth model).</param>
    /// <returns>The built HTTP adapter.</returns>
    public static IAgentHttpAdapter BuildAdapter(ActivityServerOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        return BuildProvider(options).GetRequiredService<IAgentHttpAdapter>();
    }

    private static ServiceProvider BuildProvider(ActivityServerOptions options)
    {
        // Bridge Foundry-native environment variables to the M365 CONNECTIONS__* format
        // before any M365 connection manager is constructed.
        ActivityEnvironment.InitializeEnvironment(options.DigitalWorker);

        var services = new ServiceCollection();

        services.AddLogging();

        // Required by the M365 adapter stack: RestChannelServiceClientFactory (registered by
        // AddAgentCore) depends on IHttpClientFactory. In a normal ASP.NET host this is present;
        // in this manually-built provider we must register it explicitly.
        services.AddHttpClient();

        services.AddSingleton<IConfiguration>(
            new ConfigurationBuilder().AddEnvironmentVariables().Build());

        // In-memory storage for local/testing; a durable backend can be injected by the caller
        // via the injected-AgentApplication construction mode.
        services.TryAddSingleton<IStorage, MemoryStorage>();

        // Register AgentApplicationOptions and the core M365 adapter services
        // (IConnections, IChannelServiceClientFactory, CloudAdapter/IAgentHttpAdapter).
        services.AddAgentApplicationOptions();
        services.AddAgentCore<CloudAdapter>();

        // Replace the default configuration-driven IConnections with the Foundry connections
        // that acquire Bot Connector tokens via the container's managed identity / FMI exchange.
        services.Replace(ServiceDescriptor.Singleton<IConnections, FoundryConnections>());

        return services.BuildServiceProvider();
    }
}
