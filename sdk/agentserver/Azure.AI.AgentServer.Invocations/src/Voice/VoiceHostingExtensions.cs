// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Http;
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
        // Factory aliases capture disposable results independently, so THandler needs one DI owner.
        var marker = new VoiceRegistrationMarker(typeof(VoiceHandlerAdapter<THandler>));
        services.AddScoped<InvocationWebSocketHandler, THandler>();
        services.AddScoped<VoiceHandler>(provider =>
            new VoiceHandlerAdapter<THandler>(
                (THandler)provider.GetRequiredService<InvocationWebSocketHandler>()));
        services.AddScoped<InvocationHandler>(provider =>
            provider.GetRequiredService<VoiceHandler>());
        services.AddSingleton(marker);
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

[Experimental("AAAS001")]
internal sealed class VoiceHandlerAdapter<THandler> : VoiceHandler
    where THandler : VoiceHandler
{
    private readonly THandler _handler;

    internal VoiceHandlerAdapter(THandler handler) => _handler = handler;

    internal override VoiceHandler ApplicationHandler => _handler;

    public override Task HandleAsync(
        HttpRequest request,
        HttpResponse response,
        InvocationContext context,
        CancellationToken cancellationToken) =>
        _handler.HandleAsync(request, response, context, cancellationToken);

    public override Task GetAsync(
        string invocationId,
        HttpRequest request,
        HttpResponse response,
        InvocationContext context,
        CancellationToken cancellationToken) =>
        _handler.GetAsync(invocationId, request, response, context, cancellationToken);

    public override Task CancelAsync(
        string invocationId,
        HttpRequest request,
        HttpResponse response,
        InvocationContext context,
        CancellationToken cancellationToken) =>
        _handler.CancelAsync(invocationId, request, response, context, cancellationToken);

    public override Task GetOpenApiAsync(
        HttpRequest request,
        HttpResponse response,
        CancellationToken cancellationToken) =>
        _handler.GetOpenApiAsync(request, response, cancellationToken);

    public override Task GetAsyncApiJsonAsync(
        HttpRequest request,
        HttpResponse response,
        CancellationToken cancellationToken) =>
        _handler.GetAsyncApiJsonAsync(request, response, cancellationToken);

    public override Task GetAsyncApiYamlAsync(
        HttpRequest request,
        HttpResponse response,
        CancellationToken cancellationToken) =>
        _handler.GetAsyncApiYamlAsync(request, response, cancellationToken);
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
