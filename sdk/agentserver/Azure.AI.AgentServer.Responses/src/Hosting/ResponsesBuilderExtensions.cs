// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Extension methods for <see cref="AgentHostBuilder"/> to register
/// the Responses protocol for one-line startup.
/// </summary>
public static class ResponsesBuilderExtensions
{
    private const string DefaultSettingsSectionName = "ResponsesServer";

    /// <summary>
    /// Registers the Responses protocol with the agent server builder using the
    /// specified <typeparamref name="THandler"/> as the response handler.
    /// </summary>
    /// <typeparam name="THandler">
    /// The <see cref="ResponseHandler"/> implementation to handle responses.
    /// </typeparam>
    /// <param name="builder">The agent server builder.</param>
    /// <param name="configure">Optional callback to configure <see cref="ResponsesServerOptions"/>.</param>
    /// <returns>The builder for chaining.</returns>
    /// <remarks>
    /// In a hosted Foundry environment, credential and endpoint settings bind from the
    /// <c>ResponsesServer</c> configuration section. The <paramref name="configure"/> callback is
    /// applied afterward and therefore remains authoritative for response options.
    /// </remarks>
    public static AgentHostBuilder AddResponses<THandler>(
        this AgentHostBuilder builder,
        Action<ResponsesServerOptions>? configure = null)
        where THandler : ResponseHandler
    {
        AddResponsesServices(builder, configure);
        builder.Services.AddScoped<ResponseHandler, THandler>();

        builder.RegisterProtocol("Responses", endpoints =>
        {
            endpoints.MapResponsesServer();
        });

        return builder;
    }

    /// <summary>
    /// Registers the Responses protocol with a pre-constructed handler instance.
    /// </summary>
    /// <param name="builder">The agent server builder.</param>
    /// <param name="handler">The handler instance.</param>
    /// <param name="configure">Optional callback to configure <see cref="ResponsesServerOptions"/>.</param>
    /// <returns>The builder for chaining.</returns>
    /// <remarks>
    /// In a hosted Foundry environment, credential and endpoint settings bind from the
    /// <c>ResponsesServer</c> configuration section. The <paramref name="configure"/> callback is
    /// applied afterward and therefore remains authoritative for response options.
    /// </remarks>
    public static AgentHostBuilder AddResponses(
        this AgentHostBuilder builder,
        ResponseHandler handler,
        Action<ResponsesServerOptions>? configure = null)
    {
        AddResponsesServices(builder, configure);
        builder.Services.AddScoped<ResponseHandler>(_ => handler);

        builder.RegisterProtocol("Responses", endpoints =>
        {
            endpoints.MapResponsesServer();
        });

        return builder;
    }

    /// <summary>
    /// Registers the Responses protocol with a factory delegate that creates the handler.
    /// Use this overload when you need full control over handler construction
    /// while still having access to the <see cref="IServiceProvider"/>.
    /// </summary>
    /// <param name="builder">The agent server builder.</param>
    /// <param name="factory">A factory that receives the service provider and returns a <see cref="ResponseHandler"/>.</param>
    /// <param name="configure">Optional callback to configure <see cref="ResponsesServerOptions"/>.</param>
    /// <returns>The builder for chaining.</returns>
    /// <remarks>
    /// In a hosted Foundry environment, credential and endpoint settings bind from the
    /// <c>ResponsesServer</c> configuration section. The <paramref name="configure"/> callback is
    /// applied afterward and therefore remains authoritative for response options.
    /// </remarks>
    public static AgentHostBuilder AddResponses(
        this AgentHostBuilder builder,
        Func<IServiceProvider, ResponseHandler> factory,
        Action<ResponsesServerOptions>? configure = null)
    {
        Argument.AssertNotNull(factory, nameof(factory));

        AddResponsesServices(builder, configure);
        builder.Services.AddScoped<ResponseHandler>(factory);

        builder.RegisterProtocol("Responses", endpoints =>
        {
            endpoints.MapResponsesServer();
        });

        return builder;
    }

    private static void AddResponsesServices(
        AgentHostBuilder builder,
        Action<ResponsesServerOptions>? configure)
    {
        if (FoundryEnvironment.IsHosted)
        {
            builder.WebApplicationBuilder.AddResponsesServer(DefaultSettingsSectionName);
            if (configure is not null)
            {
                // Settings bind first; the existing code callback remains the final options override.
                builder.Services.Configure(configure);
            }

            return;
        }

        builder.Services.AddResponsesServer(configure);
    }
}
