// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Invocations.Voice;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

public class VoiceConversationEngineEndpointTests
{
    private static readonly TimeSpan TestTimeout = TimeSpan.FromSeconds(5);

    [TestCase(true, "", "/invocations_ws")]
    [TestCase(true, "", "/conversation_engine")]
    [TestCase(false, "", "/invocations_ws")]
    [TestCase(false, "", "/conversation_engine")]
    [TestCase(false, "/voice", "/invocations_ws")]
    [TestCase(false, "/voice", "/conversation_engine")]
    public async Task VoiceRegistrationExposesBothRoutesWithExistingMessages(
        bool useAgentHostBuilder,
        string prefix,
        string path)
    {
        var observer = new ConnectionObserver();
        await using var app = BuildVoiceApp(observer, useAgentHostBuilder, prefix);
        await app.StartAsync();
        using var socket = await ConnectAsync(app, prefix + path);

        await StartSessionAsync(socket);
        var handler = observer.Handlers.Single();
        Assert.Multiple(() =>
        {
            Assert.That(handler.Start!.ProtocolVersion, Is.EqualTo("1.0"));
            Assert.That(handler.Start.Reconnect, Is.False);
            Assert.That(handler.Session!.InvocationContext.SessionId, Is.Not.Empty);
        });
        await AssertResponseAsync(socket, "in_question");
        await CloseAsync(socket);
        await handler.Terminating.Task.WaitAsync(TestTimeout);
        Assert.That(handler.TerminationCount, Is.EqualTo(1));
    }

    [TestCase("/invocations_ws")]
    [TestCase("/conversation_engine")]
    public async Task VoiceRoutesRejectRequestsWithoutWebSocketUpgrade(string path)
    {
        await using var app = BuildVoiceApp(new ConnectionObserver());
        await app.StartAsync();

        using var response = await app.GetTestClient().GetAsync(path).WaitAsync(TestTimeout);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task GenericInvocationsHostDoesNotExposeConversationEngine(bool hasRawWebSocketHandler)
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        builder.AddInvocations(hasRawWebSocketHandler ? new RawWebSocketHandler() : new HttpHandler());
        await using var app = builder.Build().App;
        await app.StartAsync();

        using var ceResponse = await app.GetTestClient().GetAsync("/conversation_engine").WaitAsync(TestTimeout);
        Assert.That(ceResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        Assert.That(
            async () => await ConnectAsync(app, "/conversation_engine"),
            Throws.TypeOf<InvalidOperationException>().With.Message.Contains("404"));

        if (hasRawWebSocketHandler)
        {
            using var socket = await ConnectAsync(app, "/invocations_ws");
            await SendTextAsync(socket, "independent raw WS");
            var buffer = new byte[256];
            var received = await socket.ReceiveAsync(buffer, CancellationToken.None).WaitAsync(TestTimeout);
            Assert.That(Encoding.UTF8.GetString(buffer, 0, received.Count), Is.EqualTo("independent raw WS"));
            await CloseAsync(socket);
        }
        else
        {
            using var response = await app.GetTestClient().PostAsync("/invocations", new StringContent("{}"))
                .WaitAsync(TestTimeout);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }

    [Test]
    public async Task ClosingConversationEngineDoesNotTerminateConcurrentLegacyConnection()
    {
        var observer = new ConnectionObserver();
        await using var app = BuildVoiceApp(observer);
        await app.StartAsync();
        using var legacy = await ConnectAsync(app, "/invocations_ws");
        await StartSessionAsync(legacy);
        var legacyHandler = observer.Handlers.Single();

        using var ce = await ConnectAsync(app, "/conversation_engine");
        await StartSessionAsync(ce);
        var ceHandler = observer.Handlers.Last();
        Assert.Multiple(() =>
        {
            Assert.That(observer.Handlers, Has.Count.EqualTo(2));
            Assert.That(ceHandler, Is.Not.SameAs(legacyHandler));
            Assert.That(ceHandler.Session, Is.Not.SameAs(legacyHandler.Session));
        });

        await AssertResponseAsync(ce, "in_ce");
        await CloseAsync(ce);
        await ceHandler.Terminating.Task.WaitAsync(TestTimeout);
        Assert.That(legacyHandler.Terminating.Task.IsCompleted, Is.False);

        await AssertResponseAsync(legacy, "in_legacy");
        await CloseAsync(legacy);
        await legacyHandler.Terminating.Task.WaitAsync(TestTimeout);
        Assert.Multiple(() =>
        {
            Assert.That(ceHandler.TerminationCount, Is.EqualTo(1));
            Assert.That(legacyHandler.TerminationCount, Is.EqualTo(1));
        });
    }

    [TestCase("/invocations_ws")]
    [TestCase("/conversation_engine")]
    public async Task BothRoutesPreserveReconnectStartContract(string path)
    {
        var observer = new ConnectionObserver();
        await using var app = BuildVoiceApp(observer);
        await app.StartAsync();

        foreach (var reconnect in new[] { false, true })
        {
            using var socket = await ConnectAsync(app, path);
            await StartSessionAsync(socket, reconnect);
            var handler = observer.Handlers.Last();
            Assert.That(handler.Start!.Reconnect, Is.EqualTo(reconnect));
            await CloseAsync(socket);
            await handler.Terminating.Task.WaitAsync(TestTimeout);
        }
    }

    [TestCase("/invocations_ws")]
    [TestCase("/conversation_engine")]
    public async Task BothRoutesPreserveProtocolErrorCloseCode(string path)
    {
        var observer = new ConnectionObserver();
        await using var app = BuildVoiceApp(observer);
        await app.StartAsync();
        using var socket = await ConnectAsync(app, path);

        await SendTextAsync(socket, "{");
        var buffer = new byte[64];
        var close = await socket.ReceiveAsync(buffer, CancellationToken.None).WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(close.MessageType, Is.EqualTo(WebSocketMessageType.Close));
            Assert.That((int?)close.CloseStatus, Is.EqualTo(1002));
        });
        await observer.Handlers.Single().Terminating.Task.WaitAsync(TestTimeout);
    }

    [TestCase("/invocations_ws")]
    [TestCase("/conversation_engine")]
    public async Task BothRoutesRejectOverriddenVoiceRegistration(string path)
    {
        var observer = new ConnectionObserver();
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        builder.Services.AddSingleton(observer);
        builder.AddVoice<RecordingVoiceHandler>();
        builder.Services.AddScoped<InvocationHandler, RawWebSocketHandler>();
        await using var app = builder.Build().App;
        await app.StartAsync();

        Assert.That(
            async () => await ConnectAsync(app, path),
            Throws.TypeOf<InvalidOperationException>().With.Message.Contains("overridden"));
        Assert.That(observer.Handlers, Is.Empty);
    }

    [TestCase("/invocations_ws")]
    [TestCase("/conversation_engine")]
    public async Task BothRoutesInheritManualRouteGroupFilters(string path)
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerCore();
        builder.Services.AddSingleton(new ConnectionObserver());
        builder.Services.AddVoice<RecordingVoiceHandler>();
        await using var app = builder.Build();
        app.UseAgentServerCore();
        app.MapInvocationsServer("/voice").AddEndpointFilter((_, _) =>
            ValueTask.FromResult<object?>(Results.StatusCode(StatusCodes.Status403Forbidden)));
        await app.StartAsync();

        using var response = await app.GetTestClient().GetAsync("/voice" + path).WaitAsync(TestTimeout);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Forbidden));
        using var unprefixed = await app.GetTestClient().GetAsync(path).WaitAsync(TestTimeout);
        Assert.That(unprefixed.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task BothRoutesRetainVoiceTracingEndpointMetadata()
    {
        await using var app = BuildVoiceApp(new ConnectionObserver());
        await app.StartAsync();
        var routes = ((IEndpointRouteBuilder)app).DataSources
            .SelectMany(source => source.Endpoints).OfType<RouteEndpoint>()
            .Where(endpoint => endpoint.RoutePattern.RawText is "/invocations_ws" or "/conversation_engine")
            .ToArray();

        Assert.That(routes, Has.Length.EqualTo(2));
        foreach (var route in routes)
        {
            Assert.That(route.Metadata.GetMetadata<VoiceWebSocketEndpointMetadata>(), Is.Not.Null);
        }
    }

    private static WebApplication BuildVoiceApp(
        ConnectionObserver observer,
        bool useAgentHostBuilder = true,
        string prefix = "")
    {
        if (useAgentHostBuilder)
        {
            var builder = AgentHost.CreateBuilder();
            builder.WebApplicationBuilder.WebHost.UseTestServer();
            builder.Services.AddSingleton(observer);
            builder.AddVoice<RecordingVoiceHandler>();
            return builder.Build().App;
        }

        var manualBuilder = WebApplication.CreateBuilder();
        manualBuilder.WebHost.UseTestServer();
        manualBuilder.Services.AddAgentServerCore();
        manualBuilder.Services.AddSingleton(observer);
        manualBuilder.Services.AddVoice<RecordingVoiceHandler>();
        var app = manualBuilder.Build();
        app.UseAgentServerCore();
        app.MapInvocationsServer(prefix);
        return app;
    }

    private static Task<WebSocket> ConnectAsync(WebApplication app, string path) =>
        app.GetTestServer().CreateWebSocketClient()
            .ConnectAsync(new Uri(app.GetTestServer().BaseAddress, path), CancellationToken.None)
            .WaitAsync(TestTimeout);

    private static async Task StartSessionAsync(WebSocket socket, bool reconnect = false)
    {
        await SendTextAsync(socket, JsonSerializer.Serialize(new
        {
            type = "session.start",
            id = "m_start",
            ts = "2026-10-15T00:00:00Z",
            protocol_version = "1.0",
            reconnect,
            response_timeouts = new { first_output_ms = 1000, idle_ms = 1000, max_duration_ms = 3000 },
        }));
        using var ready = await ReceiveJsonAsync(socket);
        Assert.That(ready.RootElement.GetProperty("type").GetString(), Is.EqualTo("session.ready"));
    }

    private static async Task AssertResponseAsync(WebSocket socket, string inputId)
    {
        await SendTextAsync(socket, JsonSerializer.Serialize(new
        {
            type = "user.message",
            id = "m_" + inputId,
            ts = "2026-10-15T00:00:01Z",
            item_id = inputId,
            content = new[] { new { type = "input_text", text = "Hello" } },
        }));
        using var created = await ReceiveJsonAsync(socket);
        Assert.Multiple(() =>
        {
            Assert.That(created.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.created"));
            Assert.That(created.RootElement.GetProperty("response_id").GetString(), Is.EqualTo("r_" + inputId));
            Assert.That(created.RootElement.GetProperty("in_reply_to")[0].GetString(), Is.EqualTo(inputId));
        });
        using var output = await ReceiveJsonAsync(socket);
        Assert.Multiple(() =>
        {
            Assert.That(output.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.output_text.done"));
            Assert.That(output.RootElement.GetProperty("text").GetString(), Is.EqualTo("Hello."));
        });
        using var done = await ReceiveJsonAsync(socket);
        Assert.Multiple(() =>
        {
            Assert.That(done.RootElement.GetProperty("type").GetString(), Is.EqualTo("response.done"));
            Assert.That(done.RootElement.GetProperty("response_id").GetString(), Is.EqualTo("r_" + inputId));
        });
    }

    private static Task SendTextAsync(WebSocket socket, string text) =>
        socket.SendAsync(Encoding.UTF8.GetBytes(text), WebSocketMessageType.Text, true, CancellationToken.None)
            .WaitAsync(TestTimeout);

    private static async Task<JsonDocument> ReceiveJsonAsync(WebSocket socket)
    {
        var buffer = new byte[4096];
        var received = await socket.ReceiveAsync(buffer, CancellationToken.None).WaitAsync(TestTimeout);
        Assert.That(received.MessageType, Is.EqualTo(WebSocketMessageType.Text));
        Assert.That(received.EndOfMessage, Is.True);
        return JsonDocument.Parse(buffer.AsMemory(0, received.Count));
    }

    private static async Task CloseAsync(WebSocket socket)
    {
        await socket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "done", CancellationToken.None)
            .WaitAsync(TestTimeout);
        var buffer = new byte[64];
        var received = await socket.ReceiveAsync(buffer, CancellationToken.None).WaitAsync(TestTimeout);
        Assert.That(received.MessageType, Is.EqualTo(WebSocketMessageType.Close));
        Assert.That(received.CloseStatus, Is.EqualTo(WebSocketCloseStatus.NormalClosure));
    }

    private sealed class ConnectionObserver
    {
        public ConcurrentQueue<RecordingVoiceHandler> Handlers { get; } = new();
    }

    private sealed class RecordingVoiceHandler : VoiceHandler
    {
        private int _terminationCount;

        public RecordingVoiceHandler(ConnectionObserver observer) => observer.Handlers.Enqueue(this);

        public VoiceSession? Session { get; private set; }
        public VoiceSessionStartEvent? Start { get; private set; }
        public TaskCompletionSource Terminating { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public int TerminationCount => _terminationCount;

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken)
        {
            Session = session;
            Start = start;
            return session.SendAsync(new VoiceSessionReadyMessage(), cancellationToken);
        }

        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            VoiceUserMessageEvent message,
            CancellationToken cancellationToken)
        {
            var responseId = "r_" + message.ItemId;
            await session.SendAsync(new VoiceResponseCreatedMessage(responseId, new[] { message.ItemId }), cancellationToken);
            await session.SendAsync(new VoiceResponseOutputTextDoneMessage(responseId, "it_reply", "Hello."), cancellationToken);
            await session.SendAsync(new VoiceResponseDoneMessage(responseId), cancellationToken);
        }

        protected override void OnConnectionTerminating(VoiceSession session)
        {
            Interlocked.Increment(ref _terminationCount);
            Terminating.TrySetResult();
        }
    }

    private sealed class HttpHandler : InvocationHandler
    {
        public override Task HandleAsync(
            HttpRequest request, HttpResponse response, InvocationContext context, CancellationToken cancellationToken)
        {
            response.StatusCode = StatusCodes.Status200OK;
            return Task.CompletedTask;
        }
    }

    private sealed class RawWebSocketHandler : InvocationWebSocketHandler
    {
        public override async Task HandleWebSocketAsync(
            WebSocket socket, InvocationContext context, CancellationToken cancellationToken)
        {
            var buffer = new byte[256];
            var received = await socket.ReceiveAsync(buffer, cancellationToken);
            await socket.SendAsync(
                new ArraySegment<byte>(buffer, 0, received.Count), received.MessageType, true, cancellationToken);
        }
    }
}
