// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Activity.Internal;
using Azure.AI.AgentServer.Core;
using Microsoft.Agents.Builder.App;
using Microsoft.Agents.Hosting.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Activity;

/// <summary>
/// Extension methods for <see cref="AgentHostBuilder"/> that register the Activity protocol
/// on the Foundry Core host builder. It composes the Activity protocol onto a host built with
/// <see cref="AgentHost.CreateBuilder(string[])"/>, giving you full control over service
/// registration, configuration, and tracing while still leveraging the Core framework
/// infrastructure (OpenTelemetry, health probes, middleware).
/// </summary>
public static class ActivityBuilderExtensions
{
    /// <summary>
    /// Registers the Activity protocol with the agent server builder using the specified
    /// <typeparamref name="TAgent"/> as the Microsoft 365 Agents SDK application.
    /// </summary>
    /// <typeparam name="TAgent">The <see cref="AgentApplication"/> implementation to host.</typeparam>
    /// <param name="builder">The agent server builder.</param>
    /// <param name="configure">Optional callback to configure <see cref="ActivityServerOptions"/>.</param>
    /// <returns>The builder for chaining.</returns>
    public static AgentHostBuilder AddActivity<TAgent>(
        this AgentHostBuilder builder,
        Action<ActivityServerOptions>? configure = null)
        where TAgent : AgentApplication
    {
        ArgumentNullException.ThrowIfNull(builder);

        var options = BuildOptions(builder, configure);
        RegisterActivityServices(builder, options);

        // Register the agent type the native Microsoft 365 Agents SDK way. Safe after
        // RegisterM365Services: AddAgentCore only registers defaults when absent, and the Foundry
        // IConnections substitution has already been applied.
        builder.WebApplicationBuilder.AddAgent<TAgent>();

        builder.RegisterProtocol("Activity", endpoints => endpoints.MapFoundryActivity());
        return builder;
    }

    /// <summary>
    /// Registers the Activity protocol with a pre-built Microsoft 365 Agents SDK
    /// <see cref="AgentApplication"/> instance (with its handlers already registered).
    /// </summary>
    /// <param name="builder">The agent server builder.</param>
    /// <param name="agentApp">The application instance to host.</param>
    /// <param name="configure">Optional callback to configure <see cref="ActivityServerOptions"/>.</param>
    /// <returns>The builder for chaining.</returns>
    public static AgentHostBuilder AddActivity(
        this AgentHostBuilder builder,
        AgentApplication agentApp,
        Action<ActivityServerOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(agentApp);

        var options = new ActivityServerOptions();
        configure?.Invoke(options);
        return builder.AddActivity(agentApp, options);
    }

    /// <summary>
    /// Registers the Activity protocol with a pre-built Microsoft 365 Agents SDK
    /// <see cref="AgentApplication"/> instance and a pre-resolved <see cref="ActivityServerOptions"/>
    /// (the options callback has already been applied). Used by the entry points that build the
    /// options and the application before the host builder exists, so the callback is not run twice.
    /// </summary>
    internal static AgentHostBuilder AddActivity(
        this AgentHostBuilder builder,
        AgentApplication agentApp,
        ActivityServerOptions options)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(agentApp);
        ArgumentNullException.ThrowIfNull(options);

        OverlayConnectionConfiguration(builder, options);
        RegisterActivityServices(builder, options);

        builder.Services.AddSingleton(agentApp);
        builder.Services.AddSingleton<Microsoft.Agents.Builder.IAgent>(agentApp);

        builder.RegisterProtocol("Activity", endpoints => endpoints.MapFoundryActivity());
        return builder;
    }

    /// <summary>
    /// Registers the Activity protocol with a factory delegate that creates the Microsoft 365 Agents
    /// SDK <see cref="AgentApplication"/>. Use this overload when you need full control over how the
    /// application is constructed while still having access to the <see cref="IServiceProvider"/>.
    /// </summary>
    /// <remarks>This mirrors the Microsoft 365 Agents SDK's <c>builder.AddAgent(sp =&gt; ...)</c> factory
    /// registration.</remarks>
    /// <param name="builder">The agent server builder.</param>
    /// <param name="factory">A factory that receives the service provider and returns an
    /// <see cref="AgentApplication"/>.</param>
    /// <param name="configure">Optional callback to configure <see cref="ActivityServerOptions"/>.</param>
    /// <returns>The builder for chaining.</returns>
    public static AgentHostBuilder AddActivity(
        this AgentHostBuilder builder,
        Func<IServiceProvider, AgentApplication> factory,
        Action<ActivityServerOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(factory);

        var options = BuildOptions(builder, configure);
        RegisterActivityServices(builder, options);

        // A single application instance resolves for both the concrete type and IAgent (the type
        // the endpoint and the background activity service resolve).
        builder.Services.AddSingleton(factory);
        builder.Services.AddSingleton<Microsoft.Agents.Builder.IAgent>(sp => sp.GetRequiredService<AgentApplication>());

        builder.RegisterProtocol("Activity", endpoints => endpoints.MapFoundryActivity());
        return builder;
    }

    private static ActivityServerOptions BuildOptions(AgentHostBuilder builder, Action<ActivityServerOptions>? configure)
    {
        var options = new ActivityServerOptions();
        configure?.Invoke(options);

        OverlayConnectionConfiguration(builder, options);

        return options;
    }

    /// <summary>
    /// Overlays the derived Microsoft 365 connection settings (<c>CONNECTIONS__*</c>) onto the host
    /// configuration so the SDK adapter and the Foundry connection provider read them. Never mutates
    /// the process environment.
    /// </summary>
    private static void OverlayConnectionConfiguration(AgentHostBuilder builder, ActivityServerOptions options)
    {
        if (builder.WebApplicationBuilder.Configuration is IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.AddInMemoryCollection(ActivityStack.GetConnectionConfiguration(options));
        }
    }

    private static void RegisterActivityServices(AgentHostBuilder builder, ActivityServerOptions options)
    {
        builder.Services.AddSingleton<IOptions<ActivityServerOptions>>(Options.Create(options));
        builder.Services.AddActivityServerServices();
        ActivityStack.RegisterM365Services(builder.Services, options);
    }
}
