// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Hosting;
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
    /// The <see cref="IResponseHandler"/> implementation to handle responses.
    /// </typeparam>
    /// <param name="builder">The agent server builder.</param>
    /// <param name="configure">Optional callback to configure <see cref="ResponsesServerOptions"/>.</param>
    /// <returns>The builder for chaining.</returns>
    public static AgentHostBuilder AddResponses<THandler>(
        this AgentHostBuilder builder,
        Action<ResponsesServerOptions>? configure = null)
        where THandler : class, IResponseHandler
    {
        builder.Services.AddResponsesServer(configure);
        builder.Services.AddScoped<IResponseHandler, THandler>();

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
        IResponseHandler handler,
        Action<ResponsesServerOptions>? configure = null)
    {
        builder.Services.AddResponsesServer(configure);
        builder.Services.AddScoped<IResponseHandler>(_ => handler);

        builder.RegisterProtocol("Responses", endpoints =>
        {
            endpoints.MapResponsesServer();
        });

        return builder;
    }
}
