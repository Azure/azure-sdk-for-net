// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Invocations.Voice;

/// <summary>Registration extensions for the typed Voice event relay.</summary>
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

        services.AddInvocationsServer(configure);
        services.AddScoped<VoiceHandler, THandler>();
        services.AddScoped<InvocationHandler>(provider =>
            provider.GetRequiredService<VoiceHandler>());
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

/// <summary>One-line startup for a typed Voice relay.</summary>
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
