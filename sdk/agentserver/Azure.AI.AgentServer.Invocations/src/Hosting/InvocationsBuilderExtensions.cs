// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Invocations.Voice;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Azure.AI.AgentServer.Invocations;

/// <summary>
/// Extension methods for <see cref="AgentHostBuilder"/> to register
/// the Invocations protocol for one-line startup.
/// </summary>
public static class InvocationsBuilderExtensions
{
    internal const string VoiceRegistrationError =
        "VoiceHandler implementations must be registered with AddVoice<THandler>() so Voice-specific tracing is installed.";

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
    /// <remarks>
    /// <see cref="VoiceHandler"/> implementations must be registered with
    /// <see cref="VoiceHostingExtensions.AddVoice{THandler}(AgentHostBuilder, Action{InvocationsServerOptions}?)"/>
    /// so the host installs Voice-specific tracing.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// <typeparamref name="THandler"/> derives from <see cref="VoiceHandler"/>.
    /// </exception>
    public static AgentHostBuilder AddInvocations<THandler>(
        this AgentHostBuilder builder,
        Action<InvocationsServerOptions>? configure = null)
        where THandler : InvocationHandler
    {
        RejectVoiceHandlerType(typeof(THandler));
        RejectVoiceRegistration(builder.Services);
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
    /// <remarks>
    /// <see cref="VoiceHandler"/> instances are not supported by this overload. Register a
    /// concrete Voice handler type with <see cref="VoiceHostingExtensions.AddVoice{THandler}(AgentHostBuilder, Action{InvocationsServerOptions}?)"/>.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// <paramref name="handler"/> is a <see cref="VoiceHandler"/>.
    /// </exception>
    public static AgentHostBuilder AddInvocations(
        this AgentHostBuilder builder,
        InvocationHandler handler,
        Action<InvocationsServerOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(handler);

        RejectVoiceHandler(handler);
        RejectVoiceRegistration(builder.Services);
        builder.Services.AddInvocationsServer(configure);
        builder.Services.TryAddSingleton<InvocationHandler>(handler);

        builder.RegisterProtocol("Invocations", endpoints =>
        {
            endpoints.MapInvocationsServer();
        });

        return builder;
    }

    /// <summary>
    /// Registers the Invocations protocol with a factory delegate that creates the handler.
    /// Use this overload when you need full control over handler construction
    /// while still having access to the <see cref="IServiceProvider"/>.
    /// </summary>
    /// <param name="builder">The agent server builder.</param>
    /// <param name="factory">A factory that receives the service provider and returns an <see cref="InvocationHandler"/>.</param>
    /// <param name="configure">Optional callback to configure <see cref="InvocationsServerOptions"/>.</param>
    /// <returns>The builder for chaining.</returns>
    /// <remarks>
    /// The factory must not return a <see cref="VoiceHandler"/>. Register Voice handlers with
    /// <see cref="VoiceHostingExtensions.AddVoice{THandler}(AgentHostBuilder, Action{InvocationsServerOptions}?)"/>
    /// so the host installs Voice-specific tracing.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// The factory returns a <see cref="VoiceHandler"/> and an Invocations endpoint attempts
    /// to use it.
    /// </exception>
    public static AgentHostBuilder AddInvocations(
        this AgentHostBuilder builder,
        Func<IServiceProvider, InvocationHandler> factory,
        Action<InvocationsServerOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(factory);

        RejectVoiceRegistration(builder.Services);
        builder.Services.AddInvocationsServer(configure);
        builder.Services.AddScoped<InvocationHandler>(factory);

        builder.RegisterProtocol("Invocations", endpoints =>
        {
            endpoints.MapInvocationsServer();
        });

        return builder;
    }

#pragma warning disable AAAS001 // Detect the experimental Voice type only to reject the wrong registration API.
    private static void RejectVoiceHandlerType(Type handlerType)
    {
        if (typeof(VoiceHandler).IsAssignableFrom(handlerType))
        {
            throw new InvalidOperationException(VoiceRegistrationError);
        }
    }

    private static void RejectVoiceHandler(InvocationHandler handler)
    {
        if (handler is VoiceHandler)
        {
            throw new InvalidOperationException(VoiceRegistrationError);
        }
    }
#pragma warning restore AAAS001

    private static void RejectVoiceRegistration(IServiceCollection services)
    {
        if (services.Any(descriptor => descriptor.ServiceType == typeof(VoiceRegistrationMarker)))
        {
            throw new InvalidOperationException(
                "Invocations cannot be registered after Voice because Voice already owns the Invocations endpoints.");
        }
    }
}
