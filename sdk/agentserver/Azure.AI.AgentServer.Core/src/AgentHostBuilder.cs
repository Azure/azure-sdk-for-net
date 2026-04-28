// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Internal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenTelemetry.Trace;

namespace Azure.AI.AgentServer.Core;

/// <summary>
/// Composable builder for configuring and starting an agent server.
/// Wraps <see cref="Microsoft.AspNetCore.Builder.WebApplicationBuilder"/>
/// (via <see cref="WebApplication.CreateSlimBuilder(string[])"/>) and exposes
/// protocol registration, health checks, tracing, shutdown, and escape hatches.
/// </summary>
public sealed class AgentHostBuilder
{
    private readonly WebApplicationBuilder _builder;
    private readonly HashSet<string> _registeredProtocols = new(StringComparer.OrdinalIgnoreCase);
    private readonly List<Action<IEndpointRouteBuilder>> _endpointMappers = new();
    private Action<TracerProviderBuilder>? _tracingConfigure;
    private Action<IHealthChecksBuilder>? _healthConfigure;

    /// <summary>
    /// Initializes a new <see cref="AgentHostBuilder"/> from command-line arguments.
    /// </summary>
    internal AgentHostBuilder(string[]? args)
    {
        _builder = WebApplication.CreateSlimBuilder(args ?? Array.Empty<string>());

        // Pre-register a shared registry instance so protocols can register before Build().
        VersionRegistry = new ServerVersionRegistry();
        _builder.Services.AddSingleton(VersionRegistry);

        // Register all Core middleware services (TryAdd — won't duplicate the registry above).
        _builder.Services.AddAgentServerCore();
    }

    /// <summary>
    /// Escape hatch to the underlying service collection.
    /// </summary>
    public IServiceCollection Services => _builder.Services;

    /// <summary>
    /// Escape hatch to the underlying configuration.
    /// </summary>
    public IConfiguration Configuration => _builder.Configuration;

    /// <summary>
    /// Access the <see cref="Microsoft.AspNetCore.Builder.WebApplicationBuilder"/> for advanced scenarios.
    /// </summary>
    public WebApplicationBuilder WebApplicationBuilder => _builder;

    /// <summary>
    /// Registry for protocol version identity segments appended to the
    /// <c>x-platform-server</c> response header. Protocol extensions register
    /// their identity during route mapping.
    /// </summary>
    public ServerVersionRegistry VersionRegistry { get; }

    /// <summary>
    /// Configure agent server options (port, shutdown timeout, identity).
    /// </summary>
    /// <param name="configure">The configuration callback.</param>
    /// <returns>This builder for chaining.</returns>
    public AgentHostBuilder Configure(Action<AgentHostOptions> configure)
    {
        _builder.Services.Configure(configure);
        return this;
    }

    /// <summary>
    /// Add custom health checks alongside the default liveness probe.
    /// </summary>
    /// <param name="configure">The health check configuration callback.</param>
    /// <returns>This builder for chaining.</returns>
    public AgentHostBuilder ConfigureHealth(Action<IHealthChecksBuilder> configure)
    {
        _healthConfigure = configure;
        return this;
    }

    /// <summary>
    /// Add custom tracing sources or configure the <see cref="TracerProviderBuilder"/>.
    /// </summary>
    /// <param name="configure">The tracing configuration callback.</param>
    /// <returns>This builder for chaining.</returns>
    public AgentHostBuilder ConfigureTracing(Action<TracerProviderBuilder> configure)
    {
        _tracingConfigure = configure;
        return this;
    }

    /// <summary>
    /// Set the graceful shutdown timeout.
    /// This is a convenience shorthand for <c>Configure(o =&gt; o.ShutdownTimeout = timeout)</c>.
    /// </summary>
    /// <param name="timeout">The maximum duration to wait for in-flight requests during shutdown.</param>
    /// <returns>This builder for chaining.</returns>
    public AgentHostBuilder ConfigureShutdown(TimeSpan timeout)
    {
        _builder.Services.Configure<AgentHostOptions>(o => o.ShutdownTimeout = timeout);
        return this;
    }

    /// <summary>
    /// Registers a protocol with the builder. Throws if the protocol is already registered.
    /// Called by protocol extension methods (e.g., <c>AddResponses</c>, <c>AddInvocations</c>).
    /// </summary>
    /// <param name="protocolName">The protocol name (e.g., "Responses", "Invocations").</param>
    /// <param name="endpointMapper">Action to map protocol endpoints during the build phase.</param>
    public void RegisterProtocol(string protocolName, Action<IEndpointRouteBuilder> endpointMapper)
    {
        ArgumentException.ThrowIfNullOrEmpty(protocolName);
        ArgumentNullException.ThrowIfNull(endpointMapper);

        if (!_registeredProtocols.Add(protocolName))
        {
            throw new InvalidOperationException(
                $"Protocol '{protocolName}' is already registered. Each protocol can only be added once.");
        }

        _endpointMappers.Add(endpointMapper);
    }

    /// <summary>
    /// Finalize configuration and build the runnable <see cref="AgentHostApp"/>.
    /// </summary>
    /// <returns>A configured <see cref="AgentHostApp"/> ready to run.</returns>
    public AgentHostApp Build()
    {
        // Build a temporary service provider to resolve and validate options.
        // This uses the registrations accumulated so far (from Configure / ConfigureShutdown).
        TimeSpan shutdownTimeout;
        using (var tempProvider = _builder.Services.BuildServiceProvider())
        {
            var options = tempProvider.GetRequiredService<IOptions<AgentHostOptions>>().Value;
            options.Validate();
            shutdownTimeout = options.ShutdownTimeout;
        }

        // Configure Kestrel — port comes from FoundryEnvironment (platform-controlled)
        var port = FoundryEnvironment.Port;
        _builder.WebHost.ConfigureKestrel(kestrel =>
        {
            kestrel.ListenAnyIP(port, listenOptions =>
            {
                listenOptions.Protocols = HttpProtocols.Http1;
            });
        });

        // Configure shutdown timeout
        _builder.Services.Configure<HostOptions>(opts =>
        {
            opts.ShutdownTimeout = shutdownTimeout;
        });

        // Health checks
        var healthBuilder = _builder.Services.AddHealthChecks();
        _healthConfigure?.Invoke(healthBuilder);

        // OpenTelemetry
        _builder.Services.AddAgentHostTelemetry(_tracingConfigure);

        // Build the WebApplication
        var app = _builder.Build();

        // Log startup configuration
        LogStartupConfiguration(app, shutdownTimeout);

        // Middleware pipeline
        app.UseAgentServerCore();

        // Health endpoint
        app.MapHealthEndpoint();

        // Map deferred protocol endpoints
        foreach (var mapper in _endpointMappers)
        {
            mapper(app);
        }

        return new AgentHostApp(app);
    }

    private void LogStartupConfiguration(WebApplication app, TimeSpan shutdownTimeout)
    {
        var logger = app.Services.GetRequiredService<ILogger<AgentHostBuilder>>();

        // Platform environment
        logger.LogInformation(
            "AgentServer platform environment: IsHosted={IsHosted} AgentName={AgentName} AgentVersion={AgentVersion} " +
            "Port={Port} SessionId={SessionId} SseKeepAliveInterval={SseKeepAliveInterval}",
            FoundryEnvironment.IsHosted,
            FoundryEnvironment.AgentName ?? "(not set)",
            FoundryEnvironment.AgentVersion ?? "(not set)",
            FoundryEnvironment.Port,
            FoundryEnvironment.SessionId ?? "(not set)",
            FoundryEnvironment.SseKeepAliveInterval == Timeout.InfiniteTimeSpan ? "disabled" : FoundryEnvironment.SseKeepAliveInterval.ToString());

        // Connectivity (mask sensitive values)
        logger.LogInformation(
            "AgentServer connectivity: ProjectEndpoint={ProjectEndpoint} OtlpEndpoint={OtlpEndpoint} AppInsightsConfigured={AppInsightsConfigured}",
            MaskUri(FoundryEnvironment.ProjectEndpoint),
            MaskUri(FoundryEnvironment.OtlpEndpoint),
            !string.IsNullOrEmpty(FoundryEnvironment.AppInsightsConnectionString));

        // Host options and registered protocols
        logger.LogInformation(
            "AgentServer host options: ShutdownTimeout={ShutdownTimeout} Protocols={Protocols}",
            shutdownTimeout,
            _registeredProtocols.Count > 0 ? string.Join(", ", _registeredProtocols) : "(none)");
    }

    /// <summary>
    /// Masks a URI to show only the scheme and host, hiding path, query, and credentials.
    /// Returns "(not set)" for null/empty values.
    /// </summary>
    private static string MaskUri(string? uri)
    {
        if (string.IsNullOrEmpty(uri))
        {
            return "(not set)";
        }

        if (Uri.TryCreate(uri, UriKind.Absolute, out var parsed))
        {
            return $"{parsed.Scheme}://{parsed.Host}";
        }

        return "(configured)";
    }
}
