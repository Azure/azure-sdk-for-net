// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Azure.AI.AgentServer.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Invocations.Voice;

/// <summary>Registration extensions for the typed Voice event relay.</summary>
[Experimental("AAAS001")]
public static class VoiceHostingExtensions
{
    /// <summary>Registers one Voice handler in a manually composed service collection.</summary>
    public static IServiceCollection AddVoice<THandler>(
        this IServiceCollection services,
        Action<InvocationsServerOptions>? configure = null)
        where THandler : VoiceHandler
    {
        ArgumentNullException.ThrowIfNull(services);
        if (services.Any(descriptor =>
            descriptor.ServiceType == typeof(InvocationHandler)))
        {
            throw new InvalidOperationException(
                "Voice must be the only InvocationHandler registered for /invocations_ws.");
        }

        VoiceTracingRegistration.Add(services);
        services.AddInvocationsServer(configure);
        services.AddScoped<InvocationHandler, THandler>();
        services.AddSingleton(new VoiceRegistrationMarker(typeof(THandler)));
        return services;
    }

    /// <summary>Registers the typed Voice relay with an AgentServer builder.</summary>
    public static AgentHostBuilder AddVoice<THandler>(
        this AgentHostBuilder builder,
        Action<InvocationsServerOptions>? configure = null)
        where THandler : VoiceHandler
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.Services.AddVoice<THandler>(configure);
        builder.RegisterProtocol("Voice", endpoints => endpoints.MapInvocationsServer());
        return builder;
    }
}

internal sealed class VoiceRegistrationMarker
{
    internal VoiceRegistrationMarker(Type handlerType) => HandlerType = handlerType;

    internal Type HandlerType { get; }
}

/// <summary>One-line startup for a typed Voice relay.</summary>
[Experimental("AAAS001")]
public static class VoiceServer
{
    /// <summary>Builds and runs a Voice-only AgentServer host.</summary>
    public static void Run<THandler>(
        string[]? args = null,
        Action<AgentHostBuilder>? configure = null)
        where THandler : VoiceHandler
    {
        var builder = AgentHost.CreateBuilder(args);
        configure?.Invoke(builder);
        builder.AddVoice<THandler>();
        builder.Build().Run();
    }
}
