// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Azure.AI.AgentServer.Invocations;

/// <summary>
/// Extension methods for <see cref="AgentHostBuilder"/> to register
/// the Invocations protocol for one-line startup.
/// </summary>
public static class InvocationsBuilderExtensions
{
    /// <summary>
    /// Registers the Invocations protocol with the agent server builder using the
    /// specified <typeparamref name="THandler"/> as the invocation handler.
    /// </summary>
    /// <typeparam name="THandler">
    /// The <see cref="InvocationHandler"/> implementation to handle invocations.
    /// </typeparam>
    /// <param name="builder">The agent server builder.</param>
    /// <param name="configure">Optional callback to configure <see cref="InvocationsServerOptions"/>.</param>
    /// <returns>The builder for chaining.</returns>
    public static AgentHostBuilder AddInvocations<THandler>(
        this AgentHostBuilder builder,
        Action<InvocationsServerOptions>? configure = null)
        where THandler : InvocationHandler
    {
        builder.Services.AddInvocationsServer(configure);
        builder.Services.TryAddScoped<InvocationHandler, THandler>();

        builder.RegisterProtocol("Invocations", endpoints =>
        {
            endpoints.MapInvocationsServer();
        });

        return builder;
    }

    /// <summary>
    /// Registers the Invocations protocol with a pre-constructed handler instance.
    /// </summary>
    /// <param name="builder">The agent server builder.</param>
    /// <param name="handler">The handler instance.</param>
    /// <param name="configure">Optional callback to configure <see cref="InvocationsServerOptions"/>.</param>
    /// <returns>The builder for chaining.</returns>
    public static AgentHostBuilder AddInvocations(
        this AgentHostBuilder builder,
        InvocationHandler handler,
        Action<InvocationsServerOptions>? configure = null)
    {
        builder.Services.AddInvocationsServer(configure);
        builder.Services.TryAddScoped<InvocationHandler>(_ => handler);

        builder.RegisterProtocol("Invocations", endpoints =>
        {
            endpoints.MapInvocationsServer();
        });

        return builder;
    }
}
