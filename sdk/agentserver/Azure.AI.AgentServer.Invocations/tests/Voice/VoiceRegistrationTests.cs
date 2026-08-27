// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.WebSockets;
using System.Text;
using Azure.AI.AgentServer.Invocations.Voice;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

public class VoiceRegistrationTests
{
    private static readonly TimeSpan TestTimeout = TimeSpan.FromSeconds(2);

    [Test]
    public void AddVoiceRegistersExactlyOneInvocationHandler()
    {
        var services = new ServiceCollection();

        services.AddVoice<TestVoiceHandler>();

        Assert.That(
            services.Count(descriptor => descriptor.ServiceType == typeof(InvocationHandler)),
            Is.EqualTo(1));
    }

    [Test]
    public void AddVoiceRejectsExistingInvocationHandler()
    {
        var services = new ServiceCollection();
        services.AddSingleton<InvocationHandler, RawHandler>();

        Assert.That(
            () => services.AddVoice<TestVoiceHandler>(),
            Throws.TypeOf<InvalidOperationException>());
    }

    [Test]
    public async Task AddVoiceRunsTypedRelayOnExistingRoute()
    {
        RouteSelectedVoiceHandler.Reset();
        await using var app = BuildApp<RouteSelectedVoiceHandler>();
        await app.StartAsync();
        using var webSocket = await ConnectAsync(app);

        await SendSessionStartAsync(webSocket);

        await RouteSelectedVoiceHandler.Selected.Task.WaitAsync(TestTimeout);
        await webSocket.CloseOutputAsync(
            WebSocketCloseStatus.NormalClosure,
            "done",
            CancellationToken.None);
    }

    [Test]
    public async Task ConflictingLiteralRouteAtSameOrderFailsClosed()
    {
        await using var app = BuildApp<TestVoiceHandler>(application =>
            application.MapGet("/invocations_ws", () => Results.Ok()).WithOrder(int.MinValue));
        await app.StartAsync();
        var client = app.GetTestServer().CreateWebSocketClient();

        Assert.That(
            async () => await client.ConnectAsync(
                new Uri(app.GetTestServer().BaseAddress, "invocations_ws"),
                CancellationToken.None),
            Throws.TypeOf<InvalidOperationException>());
    }

    [Test]
    public async Task UpgradeIncludesServerIdentityAndSessionHeader()
    {
        SessionCapturingVoiceHandler.Reset();
        var headers = new TaskCompletionSource<IReadOnlyDictionary<string, string>>(
            TaskCreationOptions.RunContinuationsAsynchronously);
        await using var app = BuildApp<SessionCapturingVoiceHandler>(application =>
        {
            application.Use(async (context, next) =>
            {
                context.Response.OnStarting(() =>
                {
                    headers.TrySetResult(context.Response.Headers.ToDictionary(
                        pair => pair.Key,
                        pair => pair.Value.ToString(),
                        StringComparer.OrdinalIgnoreCase));
                    return Task.CompletedTask;
                });
                await next();
            });
        }, configureBeforeCore: true);
        await app.StartAsync();
        using var webSocket = await ConnectAsync(app);
        var captured = await headers.Task.WaitAsync(TestTimeout);
        await SendSessionStartAsync(webSocket);
        var resolvedSessionId = await SessionCapturingVoiceHandler.SessionId.Task.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(captured, Does.ContainKey(PlatformHeaders.ServerVersion));
            Assert.That(captured, Does.ContainKey(PlatformHeaders.SessionId));
            Assert.That(captured[PlatformHeaders.SessionId], Is.EqualTo(resolvedSessionId));
        });
        await webSocket.CloseOutputAsync(
            WebSocketCloseStatus.NormalClosure,
            "done",
            CancellationToken.None);
    }

    [Test]
    public async Task StartupDoesNotInstantiateScopedVoiceHandler()
    {
        ConstructorCountingVoiceHandler.Reset();
        await using var app = BuildApp<ConstructorCountingVoiceHandler>();

        await app.StartAsync();

        Assert.That(ConstructorCountingVoiceHandler.ConstructorCount, Is.Zero);
    }

    private static WebApplication BuildApp<THandler>(
        Action<WebApplication>? configure = null,
        bool configureBeforeCore = false)
        where THandler : VoiceHandler
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerCore();
        builder.Services.AddVoice<THandler>();
        var app = builder.Build();
        if (configureBeforeCore)
        {
            configure?.Invoke(app);
        }
        app.UseAgentServerCore();
        if (!configureBeforeCore)
        {
            configure?.Invoke(app);
        }
        app.MapInvocationsServer();
        return app;
    }

    private static async Task<WebSocket> ConnectAsync(
        WebApplication app,
        string path = "invocations_ws")
    {
        var client = app.GetTestServer().CreateWebSocketClient();
        return await client.ConnectAsync(
            new Uri(app.GetTestServer().BaseAddress, path),
            CancellationToken.None);
    }

    private static Task SendSessionStartAsync(WebSocket webSocket) =>
        webSocket.SendAsync(
            Encoding.UTF8.GetBytes("""
                {"type":"session.start","id":"m_1","ts":"2026-08-13T00:00:00.000Z","protocol_version":"1.0","reconnect":false,"response_timeouts":{"first_output_ms":1,"idle_ms":2,"max_duration_ms":3}}
                """),
            WebSocketMessageType.Text,
            endOfMessage: true,
            CancellationToken.None);

    private sealed class TestVoiceHandler : VoiceHandler;

    private sealed class SessionCapturingVoiceHandler : VoiceHandler
    {
        public static TaskCompletionSource<string> SessionId { get; private set; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public static void Reset() =>
            SessionId = new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken)
        {
            SessionId.TrySetResult(session.InvocationContext.SessionId);
            return Task.CompletedTask;
        }
    }

    private sealed class RawHandler : InvocationHandler
    {
        public override Task HandleAsync(
            HttpRequest request,
            HttpResponse response,
            InvocationContext context,
            CancellationToken cancellationToken) => Task.CompletedTask;
    }

    private sealed class RouteSelectedVoiceHandler : VoiceHandler
    {
        public static TaskCompletionSource Selected { get; private set; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public static void Reset() =>
            Selected = new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken)
        {
            Selected.TrySetResult();
            return Task.CompletedTask;
        }
    }

    private sealed class ConstructorCountingVoiceHandler : VoiceHandler
    {
        private static int _constructorCount;

        public ConstructorCountingVoiceHandler() => Interlocked.Increment(ref _constructorCount);

        public static int ConstructorCount => Volatile.Read(ref _constructorCount);

        public static void Reset() => Volatile.Write(ref _constructorCount, 0);
    }
}
