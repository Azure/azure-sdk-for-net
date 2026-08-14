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
    public static AgentHostBuilder AddResponses<THandler>(
        this AgentHostBuilder builder,
        Action<ResponsesServerOptions>? configure = null)
        where THandler : ResponseHandler
    {
        builder.Services.AddResponsesServer(configure);
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
    public static AgentHostBuilder AddResponses(
        this AgentHostBuilder builder,
        ResponseHandler handler,
        Action<ResponsesServerOptions>? configure = null)
    {
        builder.Services.AddResponsesServer(configure);
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
    public static AgentHostBuilder AddResponses(
        this AgentHostBuilder builder,
        Func<IServiceProvider, ResponseHandler> factory,
        Action<ResponsesServerOptions>? configure = null)
    {
        Argument.AssertNotNull(factory, nameof(factory));

        builder.Services.AddResponsesServer(configure);
        builder.Services.AddScoped<ResponseHandler>(factory);

        builder.RegisterProtocol("Responses", endpoints =>
        {
            endpoints.MapResponsesServer();
        });

        return builder;
    }
}
