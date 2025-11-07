// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.AI.AgentServer.Core.HealthCheck;
using Azure.AI.AgentServer.Responses.Endpoint;
using Azure.AI.AgentServer.Responses.Invocation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Core.Context;

/// <summary>
/// Provides functionality for creating and running an agent server application.
/// </summary>
public static class AgentServerApplication
{
    /// <summary>
    /// Runs the agent server application asynchronously.
    /// </summary>
    /// <param name="applicationOptions">The configuration options for the application.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task RunAsync(ApplicationOptions applicationOptions)
    {
        var app = BuildApp(applicationOptions);
        await using var _ = app.ConfigureAwait(false);
        await app.RunAsync().ConfigureAwait(false);
    }

    private static WebApplication BuildApp(ApplicationOptions applicationOptions)
    {
        var builder = WebApplication.CreateBuilder();
        var appConf = builder.Configuration.Get<AppConfiguration>()!;

        // Kestrel
        builder.Services.AddOptions<KestrelServerOptions>()
            .Configure(kestrel =>
            {
                kestrel.ListenAnyIP(appConf.Port, listenOptions =>
                {
                    listenOptions.Protocols = HttpProtocols.Http1;
                });
            });
        builder.WebHost.UseKestrel();

        builder.Services.ConfigureHttpJsonOptions(o =>
        {
            o.SerializerOptions.Converters.Add(new JsonModelConverter());
        });

        // Health Checks
        builder.Services.AddHealthChecks();

        // Logging
        var loggerFactory = builder.ConfigureLogging(appConf, applicationOptions.LoggerFactory);

        // OpenTelemetry
        builder.TryEnableOpenTelemetry(appConf, applicationOptions.TelemetrySourceName, loggerFactory);

        // Configure
        builder.ConfigureAndValidateServices(applicationOptions.ConfigureServices);

        var app = builder.Build();

        app.MapHealthChecksEndpoints()
            .MapAgentRunEndpoints();

        return app;
    }

    private static void ConfigureAndValidateServices(this WebApplicationBuilder builder, Action<IServiceCollection> configure)
    {
        configure(builder.Services);

        var registered = builder.Services.Any(d => d.ServiceType == typeof(IAgentInvocation));
        if (!registered)
        {
            throw new InvalidOperationException("Unable to run agent: IAgentInvocation is not registered.");
        }
    }

    private static ILoggerFactory? ConfigureLogging(this WebApplicationBuilder builder, AppConfiguration appConfig, Func<ILoggerFactory>? loggerFactory = null)
    {
        if (loggerFactory != null)
        {
            builder.Logging.ClearProviders();
            var loggerFactoryInstance = loggerFactory();
            builder.Services.Replace(ServiceDescriptor.Singleton(loggerFactoryInstance));
            return loggerFactoryInstance;
        }
        else
        {
            builder.Logging.SetMinimumLevel(appConfig.LogLevel);
            builder.Logging.AddFilter("Microsoft.AIFoundry.ContainerAgents", LogLevel.Debug);
            return null;
        }
    }
}
