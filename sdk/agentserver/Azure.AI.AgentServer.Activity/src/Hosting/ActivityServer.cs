// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.AI.AgentServer.Activity.Internal;
using Azure.AI.AgentServer.Core;
using Microsoft.Agents.Builder.App;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Activity;

/// <summary>
/// One-line entry point for running an Activity protocol server. Each overload creates the Core host builder,
/// registers the Activity protocol, builds, and runs (wiring OpenTelemetry, health probes, and the
/// Foundry middleware for you).
/// </summary>
/// <remarks>
/// <para>Pick the overload that matches how your agent is constructed:</para>
/// <list type="bullet">
///   <item><see cref="Run{TAgent}(string[], Action{ActivityServerOptions}, Action{AgentHostBuilder})"/>
///     — host a Microsoft 365 Agents SDK <see cref="AgentApplication"/> <b>by type</b> (handlers
///     registered in its constructor). The fastest path to a working server.</item>
///   <item><see cref="Run(Func{IServiceProvider, AgentApplication}, string[], Action{ActivityServerOptions}, Action{AgentHostBuilder})"/>
///     — host an application created by a <b>factory</b> with access to the service provider.</item>
///   <item><see cref="Run(AgentApplication, string[], Action{ActivityServerOptions}, Action{AgentHostBuilder})"/>
///     — host a <b>pre-built</b> application instance as-is.</item>
///   <item><see cref="Run(Action{AgentApplication}, string[], Action{ActivityServerOptions}, Action{AgentHostBuilder})"/>
///     — build the stack and register handlers <b>inline</b> on the application (no agent class
///     required).</item>
///   <item><see cref="Run(RequestDelegate, string[], Action{AgentHostBuilder})"/> — own the request
///     pipeline entirely; the Microsoft 365 Agents SDK is not initialized.</item>
/// </list>
/// </remarks>
public static class ActivityServer
{
    /// <summary>
    /// Builds and runs an Activity protocol server using the specified Microsoft 365 Agents SDK
    /// <typeparamref name="TAgent"/> — the fastest path to a working server, one line of code.
    /// </summary>
    /// <typeparam name="TAgent">The <see cref="AgentApplication"/> implementation to host. Its
    /// handlers are registered in its constructor.</typeparam>
    /// <param name="args">Optional command-line arguments forwarded to the host builder.</param>
    /// <param name="configureOptions">Optional callback to configure <see cref="ActivityServerOptions"/>
    /// (for example to select the digital-worker outbound-auth model or override storage).</param>
    /// <param name="configure">Optional callback to further configure the <see cref="AgentHostBuilder"/>
    /// (register services, configure tracing/shutdown) before the server runs.</param>
    public static void Run<TAgent>(
        string[]? args = null,
        Action<ActivityServerOptions>? configureOptions = null,
        Action<AgentHostBuilder>? configure = null)
        where TAgent : AgentApplication
    {
        var builder = AgentHost.CreateBuilder(args);
        builder.AddActivity<TAgent>(configureOptions);
        configure?.Invoke(builder);
        builder.Build().Run();
    }

    /// <summary>
    /// Builds and runs an Activity protocol server using a factory delegate that creates the
    /// Microsoft 365 Agents SDK <see cref="AgentApplication"/>. Use this when you need full control
    /// over how the application is constructed while still having access to the
    /// <see cref="IServiceProvider"/>.
    /// </summary>
    /// <param name="factory">A factory that receives the service provider and returns an
    /// <see cref="AgentApplication"/>.</param>
    /// <param name="args">Optional command-line arguments forwarded to the host builder.</param>
    /// <param name="configureOptions">Optional callback to configure <see cref="ActivityServerOptions"/>.</param>
    /// <param name="configure">Optional callback to further configure the <see cref="AgentHostBuilder"/>.</param>
    public static void Run(
        Func<IServiceProvider, AgentApplication> factory,
        string[]? args = null,
        Action<ActivityServerOptions>? configureOptions = null,
        Action<AgentHostBuilder>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(factory);

        var builder = AgentHost.CreateBuilder(args);
        builder.AddActivity(factory, configureOptions);
        configure?.Invoke(builder);
        builder.Build().Run();
    }

    /// <summary>
    /// Builds and runs an Activity protocol server hosting a pre-built Microsoft 365 Agents SDK
    /// <see cref="AgentApplication"/> as-is (with its handlers already registered).
    /// </summary>
    /// <param name="agentApp">The application to host.</param>
    /// <param name="args">Optional command-line arguments forwarded to the host builder.</param>
    /// <param name="configureOptions">Optional callback to configure <see cref="ActivityServerOptions"/>.</param>
    /// <param name="configure">Optional callback to further configure the <see cref="AgentHostBuilder"/>.</param>
    public static void Run(
        AgentApplication agentApp,
        string[]? args = null,
        Action<ActivityServerOptions>? configureOptions = null,
        Action<AgentHostBuilder>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(agentApp);

        var builder = AgentHost.CreateBuilder(args);
        builder.AddActivity(agentApp, configureOptions);
        configure?.Invoke(builder);
        builder.Build().Run();
    }

    /// <summary>
    /// Builds the Microsoft 365 Agents SDK stack from the environment, lets you register handlers
    /// <b>inline</b> on the created <see cref="AgentApplication"/> (no agent class required), and
    /// runs the server.
    /// </summary>
    /// <param name="configureAgent">Callback that receives the created <see cref="AgentApplication"/>
    /// to register handlers on (for example <c>app.OnActivity(...)</c>).</param>
    /// <param name="args">Optional command-line arguments forwarded to the host builder.</param>
    /// <param name="configureOptions">Optional callback to configure <see cref="ActivityServerOptions"/>.</param>
    /// <param name="configure">Optional callback to further configure the <see cref="AgentHostBuilder"/>.</param>
    public static void Run(
        Action<AgentApplication> configureAgent,
        string[]? args = null,
        Action<ActivityServerOptions>? configureOptions = null,
        Action<AgentHostBuilder>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(configureAgent);

        var options = new ActivityServerOptions();
        configureOptions?.Invoke(options);

        var agentApp = ActivityStack.CreateAgentApplication(options);
        configureAgent(agentApp);

        var builder = AgentHost.CreateBuilder(args);
        // Host the already-built application with the already-resolved options so the options
        // callback is not invoked a second time.
        builder.AddActivity(agentApp, options);
        configure?.Invoke(builder);
        builder.Build().Run();
    }

    /// <summary>
    /// Builds and runs an Activity protocol server that owns the request pipeline entirely. The
    /// Microsoft 365 Agents SDK is not initialized; the supplied delegate receives each inbound
    /// <c>POST /activity/messages</c> (and <c>/api/messages</c>) request.
    /// </summary>
    /// <param name="requestHandler">The request handler that processes inbound activities.</param>
    /// <param name="args">Optional command-line arguments forwarded to the host builder.</param>
    /// <param name="configure">Optional callback to further configure the <see cref="AgentHostBuilder"/>.</param>
    public static void Run(
        RequestDelegate requestHandler,
        string[]? args = null,
        Action<AgentHostBuilder>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(requestHandler);

        var builder = AgentHost.CreateBuilder(args);

        // Custom-handler mode: register only the Activity package services (for the session-id /
        // baggage stamping) and map the custom delegate; the M365 SDK stack is not initialized.
        builder.Services.AddActivityServerServices();
        builder.RegisterProtocol("Activity", endpoints => endpoints.MapFoundryActivity(requestHandler));

        configure?.Invoke(builder);
        builder.Build().Run();
    }
}
