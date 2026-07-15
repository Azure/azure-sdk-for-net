// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.AgentServer.Activity.Internal;
using Azure.AI.AgentServer.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Activity;

/// <summary>
/// Host-builder extensions that turn a native Microsoft 365 Agents SDK application into a Foundry
/// hosted agent. This is the Foundry counterpart to the SDK's
/// <c>AddAgentAspNetAuthentication(...)</c>: an existing Microsoft 365 agent converts to Foundry by
/// keeping its <c>builder.AddAgent&lt;TAgent&gt;()</c> registration and swapping the authentication
/// call for <see cref="AddFoundryActivity(IHostApplicationBuilder, System.Action{ActivityServerOptions})"/>.
/// </summary>
/// <remarks>
/// Minimal conversion of a Microsoft 365 Agents SDK <c>Program.cs</c>:
/// <code>
/// var builder = WebApplication.CreateBuilder(args);
/// builder.AddAgent&lt;MyAgent&gt;();                          // unchanged (MyAgent : AgentApplication)
/// builder.Services.AddSingleton&lt;IStorage, MemoryStorage&gt;(); // unchanged
/// builder.AddFoundryActivity();                          // was: AddAgentAspNetAuthentication(Configuration)
///
/// var app = builder.Build();
/// app.MapFoundryActivity();                              // was: UseAuthentication/Authorization + MapAgentApplicationEndpoints
/// app.Run();
/// </code>
/// </remarks>
public static class FoundryActivityHostingExtensions
{
    /// <summary>
    /// Registers the Foundry Activity protocol services onto a host application builder: the
    /// Foundry outbound-auth connection provider, the derived connection configuration overlay, the
    /// platform middleware services, health checks, and the shared endpoint handler.
    /// </summary>
    /// <param name="builder">The host application builder (for example a <c>WebApplicationBuilder</c>).</param>
    /// <param name="configure">Optional callback to configure <see cref="ActivityServerOptions"/>.</param>
    /// <returns>The builder, for chaining.</returns>
    public static IHostApplicationBuilder AddFoundryActivity(
        this IHostApplicationBuilder builder,
        System.Action<ActivityServerOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(builder);

        var options = new ActivityServerOptions();
        configure?.Invoke(options);

        // Overlay the derived Microsoft 365 connection settings (CONNECTIONS__*) onto the host
        // configuration so the SDK adapter and the Foundry connection provider read them. This
        // never mutates the process environment; a ConfigurationManager is both an
        // IConfigurationBuilder and an IConfiguration, so adding an in-memory source is safe.
        if (builder.Configuration is IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.AddInMemoryCollection(ActivityStack.GetConnectionConfiguration(options));
        }

        builder.Services.AddFoundryActivityCore(options);
        return builder;
    }

    /// <summary>
    /// Registers the Foundry Activity protocol services directly onto a service collection. Prefer
    /// <see cref="AddFoundryActivity(IHostApplicationBuilder, System.Action{ActivityServerOptions})"/>,
    /// which also overlays the derived connection configuration; use this overload only when you
    /// manage configuration yourself and have already ensured the <c>CONNECTIONS__*</c> settings are
    /// present in the application configuration.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configure">Optional callback to configure <see cref="ActivityServerOptions"/>.</param>
    /// <returns>The service collection, for chaining.</returns>
    public static IServiceCollection AddFoundryActivity(
        this IServiceCollection services,
        System.Action<ActivityServerOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(services);

        var options = new ActivityServerOptions();
        configure?.Invoke(options);

        services.AddFoundryActivityCore(options);
        return services;
    }

    /// <summary>
    /// Registers the Foundry Activity protocol services directly onto a service collection.
    /// </summary>
    /// <remarks>This is an alias for
    /// <see cref="AddFoundryActivity(IServiceCollection, System.Action{ActivityServerOptions})"/>.</remarks>
    /// <param name="services">The service collection.</param>
    /// <param name="configure">Optional callback to configure <see cref="ActivityServerOptions"/>.</param>
    /// <returns>The service collection, for chaining.</returns>
    public static IServiceCollection AddActivityServer(
        this IServiceCollection services,
        System.Action<ActivityServerOptions>? configure = null) => services.AddFoundryActivity(configure);

    /// <summary>
    /// Registers the Foundry Activity protocol services onto a host application builder.
    /// </summary>
    /// <remarks>This is an alias for
    /// <see cref="AddFoundryActivity(IHostApplicationBuilder, System.Action{ActivityServerOptions})"/>.</remarks>
    /// <param name="builder">The host application builder.</param>
    /// <param name="configure">Optional callback to configure <see cref="ActivityServerOptions"/>.</param>
    /// <returns>The builder, for chaining.</returns>
    public static IHostApplicationBuilder AddActivityServer(
        this IHostApplicationBuilder builder,
        System.Action<ActivityServerOptions>? configure = null) => builder.AddFoundryActivity(configure);

    private static void AddFoundryActivityCore(this IServiceCollection services, ActivityServerOptions options)
    {
        // Make the resolved options available to the shared endpoint handler.
        services.AddSingleton<IOptions<ActivityServerOptions>>(Options.Create(options));

        // Foundry platform middleware services (request id, baggage propagation, inbound logging)
        // and the readiness health check.
        services.AddAgentServerCore();
        services.AddHealthChecks();

        // Activity package services: the tracing/baggage helper, the shared endpoint handler, and
        // the startup logger.
        services.AddActivityServerServices();

        // The Microsoft 365 Agents SDK stack (storage, connections, adapter, and the background
        // activity service) plus the Foundry outbound-auth substitution. Safe to call after
        // builder.AddAgent<TAgent>().
        ActivityStack.RegisterM365Services(services, options);
    }
}
