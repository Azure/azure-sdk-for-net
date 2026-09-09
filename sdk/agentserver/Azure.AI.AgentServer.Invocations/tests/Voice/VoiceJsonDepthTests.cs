// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Invocations.Voice;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

public class VoiceJsonDepthTests
{
    private static readonly TimeSpan TestTimeout = TimeSpan.FromSeconds(5);

    [TestCase("array")]
    [TestCase("object")]
    public void JsonDepthBoundaryAcceptsLimitRejectsNextLevelAndAllowsRetry(string containerKind)
    {
        var accepted = UnknownFrameAtDepth(VoiceProtocolCodec.MaxJsonDepth, containerKind);
        var rejected = UnknownFrameAtDepth(VoiceProtocolCodec.MaxJsonDepth + 1, containerKind);

        Assert.That(VoiceProtocolCodec.Decode(accepted), Is.Null);
        var exception = Assert.Throws<VoiceProtocolException>(() => VoiceProtocolCodec.Decode(rejected));
        var retry = VoiceProtocolCodec.Decode(accepted);

        Assert.Multiple(() =>
        {
            Assert.That(exception!.CloseCode, Is.EqualTo(1002));
            Assert.That(retry, Is.Null);
        });
    }

    [Test]
    public void NearFrameLimitPathologicalNestingIsRejectedAndAllowsRetry()
    {
        var prefix = UnknownFramePrefix;
        const string scalarAndSuffix = "0}";
        var fixedBytes = Encoding.UTF8.GetByteCount(prefix + scalarAndSuffix);
        var nesting = (VoiceProtocolCodec.MaxFrameBytes - fixedBytes) / 2;
        var frame = prefix + new string('[', nesting) + scalarAndSuffix[0] + new string(']', nesting) + scalarAndSuffix[1];
        var payload = Encoding.UTF8.GetBytes(frame);

        var exception = Assert.Throws<VoiceProtocolException>(() => VoiceProtocolCodec.Decode(payload));
        var retry = VoiceProtocolCodec.Decode(UnknownFrameAtDepth(VoiceProtocolCodec.MaxJsonDepth));

        Assert.Multiple(() =>
        {
            Assert.That(payload.Length, Is.LessThanOrEqualTo(VoiceProtocolCodec.MaxFrameBytes));
            Assert.That(payload.Length, Is.GreaterThan(VoiceProtocolCodec.MaxFrameBytes - 2));
            Assert.That(exception!.CloseCode, Is.EqualTo(1002));
            Assert.That(retry, Is.Null);
        });
    }

    [Test]
    public async Task ExcessiveDepthClosesBeforeDispatchAndNextConnectionRecovers()
    {
        var handler = new StartCountingHandler();
        await using var app = BuildApp(handler);
        await app.StartAsync().WaitAsync(TestTimeout);

        using (var first = await ConnectAsync(app))
        {
            await SendTextAsync(first, SessionStartAtDepth(VoiceProtocolCodec.MaxJsonDepth + 1));
            var buffer = new byte[64];
            var close = await first.ReceiveAsync(buffer, CancellationToken.None).WaitAsync(TestTimeout);
            await handler.FirstTermination.Task.WaitAsync(TestTimeout);

            Assert.Multiple(() =>
            {
                Assert.That(close.MessageType, Is.EqualTo(WebSocketMessageType.Close));
                Assert.That((int?)first.CloseStatus, Is.EqualTo(1002));
                Assert.That(handler.StartCount, Is.Zero);
                Assert.That(handler.TerminationCount, Is.EqualTo(1));
            });
        }

        using (var second = await ConnectAsync(app))
        {
            await SendTextAsync(second, SessionStartAtDepth(2));
            using var ready = await ReceiveJsonAsync(second).WaitAsync(TestTimeout);
            Assert.That(ready.RootElement.GetProperty("type").GetString(), Is.EqualTo("session.ready"));
            await second.CloseOutputAsync(
                WebSocketCloseStatus.NormalClosure,
                "done",
                CancellationToken.None).WaitAsync(TestTimeout);
            await handler.SecondTermination.Task.WaitAsync(TestTimeout);
        }

        Assert.Multiple(() =>
        {
            Assert.That(handler.StartCount, Is.EqualTo(1));
            Assert.That(handler.TerminationCount, Is.EqualTo(2));
        });
    }

    private const string UnknownFramePrefix =
        "{\"type\":\"future.message\",\"id\":\"m_1\",\"ts\":\"2026-08-13T00:00:00.000Z\",\"value\":";

    private static byte[] UnknownFrameAtDepth(int jsonDepth, string containerKind = "array")
    {
        var nesting = jsonDepth - 1;
        var value = containerKind switch
        {
            "array" => new string('[', nesting) + "0" + new string(']', nesting),
            "object" => string.Concat(Enumerable.Repeat("{\"value\":", nesting)) +
                "0" + new string('}', nesting),
            _ => throw new ArgumentOutOfRangeException(nameof(containerKind)),
        };
        var frame = UnknownFramePrefix + value + "}";
        return Encoding.UTF8.GetBytes(frame);
    }

    private static string SessionStartAtDepth(int jsonDepth)
    {
        var nesting = jsonDepth - 1;
        var extension = new string('[', nesting) + "0" + new string(']', nesting);
        return $$"""
            {"type":"session.start","id":"m_start","ts":"2026-08-13T00:00:00.000Z","protocol_version":"1.0","reconnect":false,"response_timeouts":{"first_output_ms":1,"idle_ms":2,"max_duration_ms":3},"extension":{{extension}}}
            """;
    }

    private static WebApplication BuildApp(VoiceHandler handler)
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerCore();
        VoiceTracingRegistration.Add(builder.Services);
        builder.Services.AddInvocationsServer();
        builder.Services.AddSingleton<InvocationHandler>(handler);
        builder.Services.AddSingleton(new VoiceRegistrationMarker(handler.GetType()));
        var app = builder.Build();
        app.UseAgentServerCore();
        app.MapInvocationsServer();
        return app;
    }

    private static async Task<WebSocket> ConnectAsync(WebApplication app)
    {
        var client = app.GetTestServer().CreateWebSocketClient();
        return await client.ConnectAsync(
            new Uri(app.GetTestServer().BaseAddress, "invocations_ws"),
            CancellationToken.None).WaitAsync(TestTimeout);
    }

    private static Task SendTextAsync(WebSocket webSocket, string value) =>
        webSocket.SendAsync(
            Encoding.UTF8.GetBytes(value),
            WebSocketMessageType.Text,
            endOfMessage: true,
            CancellationToken.None).WaitAsync(TestTimeout);

    private static async Task<JsonDocument> ReceiveJsonAsync(WebSocket webSocket)
    {
        var buffer = new byte[4096];
        var received = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
        Assert.That(received.MessageType, Is.EqualTo(WebSocketMessageType.Text));
        Assert.That(received.EndOfMessage, Is.True);
        return JsonDocument.Parse(buffer.AsMemory(0, received.Count));
    }

    private sealed class StartCountingHandler : VoiceHandler
    {
        public int StartCount { get; private set; }

        public int TerminationCount { get; private set; }

        public TaskCompletionSource FirstTermination { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource SecondTermination { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken)
        {
            StartCount++;
            return session.SendAsync(new VoiceSessionReadyMessage(), cancellationToken);
        }

        protected override void OnConnectionTerminating(VoiceSession session)
        {
            TerminationCount++;
            if (TerminationCount == 1)
            {
                FirstTermination.TrySetResult();
            }
            else if (TerminationCount == 2)
            {
                SecondTermination.TrySetResult();
            }
        }
    }
}
