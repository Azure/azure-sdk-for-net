// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using NUnit.Framework;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Tests;

public class ProjectsLiveSessionClientTests
{
    private const string SessionCloseJson = """{"type":"session.close"}""";
    private const string ErrorJson = """{"type":"error","event_id":"error-event","error":{"type":"invalid_request_error","code":"invalid_request","message":"A deterministic service error.","client_event_id":"client-command"}}""";
    private const string PcmSessionStartedJson = """{"type":"session.started","event_id":"started-event","session":{"id":"live-session","model":"gpt-live-1","expires_at":2000000000,"status":"active","audio":{"format":{"type":"audio/pcm","rate":24000}}}}""";

    [TestCase("model_not_found")]
    [TestCase(null)]
    public void StartupErrorsRetainNativeTypeCodeAndMessage(string code)
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        socket.QueueText(BinaryData.FromObjectAsJson(new
        {
            type = "error",
            error = new { type = "invalid_request_error", code, message = "The requested Live deployment does not exist." }
        }).ToString());

        InvalidOperationException error = Assert.ThrowsAsync<InvalidOperationException>(() =>
            LiveTestHelpers.InitializeAsync(session, timeout.Token));

        Assert.Multiple(() =>
        {
            Assert.That(error.Message, Does.Contain("invalid_request_error")
                .And.Contain(code ?? "<not supplied>").And.Contain("The requested Live deployment does not exist."));
            Assert.That(session.SessionStarted, Is.Null);
            Assert.That(socket.SentCommands, Is.Empty);
        });
    }

    [TestCase("""{"type":"error"}""")]
    [TestCase("""{"type":"error","error":null}""")]
    public void StartupErrorsWithoutDetailsAreRejectedAsMalformed(string json)
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        socket.QueueText(json);

        Assert.ThrowsAsync<InvalidDataException>(() => LiveTestHelpers.InitializeAsync(session, timeout.Token));
        Assert.That(session.SessionStarted, Is.Null);
    }

    [Test]
    public async Task StartupAcknowledgmentIsReplayedOnceAcrossEnumerations()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        socket.QueueText(LiveTestHelpers.SessionStartedJson);
        await LiveTestHelpers.InitializeAsync(session, timeout.Token);

        await using (IAsyncEnumerator<LiveServerEvent> first = session.ReceiveEventsAsync(timeout.Token).GetAsyncEnumerator())
        {
            Assert.That(await LiveTestHelpers.AwaitAsync(first.MoveNextAsync().AsTask()), Is.True);
            Assert.That(first.Current, Is.SameAs(session.SessionStarted));
            Assert.That(first.Current, Is.TypeOf<LiveServerEventLiveSessionStarted>());
            LiveServerEventLiveSessionStarted started = (LiveServerEventLiveSessionStarted)first.Current;
            Assert.Multiple(() =>
            {
                Assert.That(started.Session.Id, Is.EqualTo("live-session"));
                Assert.That(started.Session.Model, Is.EqualTo(ModelIdsLive.GptLive1));
                Assert.That(started.Session.Status, Is.EqualTo("active"));
                Assert.That(started.ConversationId, Is.EqualTo("foundry-conversation"));
            });
        }

        socket.QueueText(ErrorJson);
        await using IAsyncEnumerator<LiveServerEvent> second = session.ReceiveEventsAsync(timeout.Token).GetAsyncEnumerator();
        Assert.That(await LiveTestHelpers.AwaitAsync(second.MoveNextAsync().AsTask()), Is.True);

        Assert.Multiple(() =>
        {
            Assert.That(LiveTestHelpers.EventType(second.Current), Is.EqualTo("error"));
            Assert.That(second.Current, Is.Not.SameAs(session.SessionStarted));
            Assert.That(socket.ReceiveCalls, Is.EqualTo(2), "Replaying the acknowledgment must not read from the socket.");
            Assert.That(socket.SentCommands, Is.Empty, "Foundry auto-start initialization must never send a duplicate native session.start.");
        });
    }

    [Test]
    public async Task ServiceErrorIsDeliveredAsNativeEventAndDoesNotTerminateReceiving()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        socket.QueueText(ErrorJson);
        socket.QueueText(LiveTestHelpers.SessionStartedJson);
        await using IAsyncEnumerator<LiveServerEvent> events = session.ReceiveEventsAsync(timeout.Token).GetAsyncEnumerator();

        Assert.That(await LiveTestHelpers.AwaitAsync(events.MoveNextAsync().AsTask()), Is.True);
        Assert.That(events.Current, Is.TypeOf<LiveServerEventLiveErrorEvent>());
        LiveServerEventLiveErrorEvent error = (LiveServerEventLiveErrorEvent)events.Current;
        Assert.Multiple(() =>
        {
            Assert.That(error.EventId, Is.EqualTo("error-event"));
            Assert.That(error.Error.Type, Is.EqualTo("invalid_request_error"));
            Assert.That(error.Error.Code, Is.EqualTo("invalid_request"));
            Assert.That(error.Error.Message, Is.EqualTo("A deterministic service error."));
            Assert.That(error.Error.ClientEventId, Is.EqualTo("client-command"));
        });
        Assert.That(await LiveTestHelpers.AwaitAsync(events.MoveNextAsync().AsTask()), Is.True);
        Assert.That(LiveTestHelpers.EventType(events.Current), Is.EqualTo("session.started"));
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task FragmentedNativeAudioJsonIsDeliveredWithTypedBase64Properties(bool reflectedInput)
    {
        using LiveLoopbackServer server = new();
        AIProjectClient project = new(server.Endpoint, new LiveTestTokenProvider());
        Task<LiveLoopbackConnection> accepting = server.AcceptSessionAsync();
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        using ProjectsLiveSessionClient session = await LiveTestHelpers.AwaitAsync(
            project.ProjectsLiveClient.StartSessionAsync("agent", cancellationToken: timeout.Token));
        LiveLoopbackConnection connection = await LiveTestHelpers.AwaitAsync(accepting);
        await using IAsyncEnumerator<LiveServerEvent> events = session.ReceiveEventsAsync(timeout.Token).GetAsyncEnumerator();
        Assert.That(await LiveTestHelpers.AwaitAsync(events.MoveNextAsync().AsTask()), Is.True);
        Assert.That(events.Current, Is.SameAs(session.SessionStarted));
        byte[] audio = Enumerable.Range(0, 9600).Select(index => (byte)index).ToArray();
        string base64 = Convert.ToBase64String(audio);
        string json = reflectedInput
            ? "{\"type\":\"session.input_audio.append\",\"audio\":\"" + base64 + "\"}"
            : "{\"type\":\"session.output_audio.delta\",\"delta\":\"" + base64 + "\",\"start_ms\":100,\"end_ms\":300}";
        byte[] bytes = Encoding.UTF8.GetBytes(json);

        await connection.Socket.SendAsync(new ArraySegment<byte>(bytes, 0, 17), WebSocketMessageType.Text, false, timeout.Token);
        await connection.Socket.SendAsync(new ArraySegment<byte>(bytes, 17, 49), WebSocketMessageType.Text, false, timeout.Token);
        await connection.Socket.SendAsync(new ArraySegment<byte>(bytes, 66, bytes.Length - 66), WebSocketMessageType.Text, true, timeout.Token);

        Assert.That(await LiveTestHelpers.AwaitAsync(events.MoveNextAsync().AsTask()), Is.True);
        if (reflectedInput)
        {
            Assert.That(events.Current, Is.TypeOf<LiveInputAudioAppend>());
            Assert.That(Convert.FromBase64String(((LiveInputAudioAppend)events.Current).Audio), Is.EqualTo(audio));
        }
        else
        {
            Assert.That(events.Current, Is.TypeOf<LiveOutputAudioDelta>());
            LiveOutputAudioDelta delta = (LiveOutputAudioDelta)events.Current;
            Assert.Multiple(() =>
            {
                Assert.That(Convert.FromBase64String(delta.Delta), Is.EqualTo(audio));
                Assert.That(delta.StartMs, Is.EqualTo(100));
                Assert.That(delta.EndMs, Is.EqualTo(300));
            });
        }
    }

    [Test]
    public async Task UnknownNativeEventPreservesExtensionPayload()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        socket.QueueText("""{"type":"future.extension","payload":{"number":7,"text":"café"}}""");
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        await using IAsyncEnumerator<LiveServerEvent> events = session.ReceiveEventsAsync(timeout.Token).GetAsyncEnumerator();

        Assert.That(await LiveTestHelpers.AwaitAsync(events.MoveNextAsync().AsTask()), Is.True);

        using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(
            events.Current, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default));
        Assert.Multiple(() =>
        {
            Assert.That(document.RootElement.GetProperty("type").GetString(), Is.EqualTo("future.extension"));
            Assert.That(document.RootElement.GetProperty("payload").GetProperty("number").GetInt32(), Is.EqualTo(7));
            Assert.That(document.RootElement.GetProperty("payload").GetProperty("text").GetString(), Is.EqualTo("café"));
        });
    }

    [TestCase("session.close")]
    [TestCase("session.start")]
    public async Task GeneratedClientEventIsSentAsOneNativeJsonTextMessage(string eventType)
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        LiveClientEvent command = eventType == "session.start"
            ? new LiveSessionStartEvent(new LiveSessionCreateParams(ModelIdsLive.GptLive1)) { EventId = "client-command" }
            : new LiveClientEventLiveSessionCloseParam { EventId = "client-command" };
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();

        await LiveTestHelpers.AwaitAsync(session.SendEventAsync(command, timeout.Token));

        Assert.Multiple(() =>
        {
            Assert.That(socket.SendCalls, Is.EqualTo(1));
            Assert.That(socket.SentCommands.Count, Is.EqualTo(1));
            Assert.That(LiveTestHelpers.EventType(socket.SentCommands[0]), Is.EqualTo(eventType));
            using JsonDocument document = JsonDocument.Parse(socket.SentCommands[0]);
            Assert.That(document.RootElement.GetProperty("event_id").GetString(), Is.EqualTo("client-command"));
            Assert.That(socket.LastSendMessageType, Is.EqualTo(WebSocketMessageType.Text));
            Assert.That(socket.LastSendEndOfMessage, Is.True);
        });
    }

    [Test]
    public async Task InputAudioHelperSendsNativeBase64WithoutRealtimeBufferCommands()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        socket.QueueText(PcmSessionStartedJson);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        await LiveTestHelpers.InitializeAsync(session, timeout.Token);
        byte[] audio = { 0, 1, 254, 255 };

        await session.SendInputAudioAsync(BinaryData.FromBytes(audio), timeout.Token);

        using JsonDocument command = JsonDocument.Parse(socket.SentCommands.Single());
        Assert.Multiple(() =>
        {
            Assert.That(command.RootElement.GetProperty("type").GetString(), Is.EqualTo("session.input_audio.append"));
            Assert.That(Convert.FromBase64String(command.RootElement.GetProperty("audio").GetString()), Is.EqualTo(audio));
            Assert.That(command.RootElement.EnumerateObject().Count(), Is.EqualTo(2));
            Assert.That(socket.LastSendMessageType, Is.EqualTo(WebSocketMessageType.Text));
        });
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(3)]
    public async Task PcmInputAudioRejectsEmptyOrIncompleteSamples(int length)
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        socket.QueueText(PcmSessionStartedJson);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        await LiveTestHelpers.InitializeAsync(session, timeout.Token);

        Assert.Throws<ArgumentException>(() => session.SendInputAudioAsync(BinaryData.FromBytes(new byte[length]), timeout.Token));
        Assert.That(socket.SentCommands, Is.Empty);
    }

    [Test]
    public async Task InputAudioStreamCombinesPartialPcmReadsWithoutLosingBytesOrOwningStream()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        socket.QueueText(PcmSessionStartedJson);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        await LiveTestHelpers.InitializeAsync(session, timeout.Token);
        byte[] audio = Enumerable.Range(0, 12).Select(index => (byte)index).ToArray();
        using ChunkedReadStream stream = new(audio, 3);

        await session.SendInputAudioAsync(stream, timeout.Token);

        List<byte> sentAudio = new();
        foreach (BinaryData data in socket.SentCommands)
        {
            using JsonDocument command = JsonDocument.Parse(data);
            Assert.That(command.RootElement.GetProperty("type").GetString(), Is.EqualTo("session.input_audio.append"));
            byte[] chunk = Convert.FromBase64String(command.RootElement.GetProperty("audio").GetString());
            Assert.That(chunk.Length % 2, Is.Zero);
            sentAudio.AddRange(chunk);
        }
        Assert.Multiple(() =>
        {
            Assert.That(sentAudio, Is.EqualTo(audio));
            Assert.That(stream.CanRead, Is.True, "The session must leave the caller's stream open.");
            Assert.That(stream.Position, Is.EqualTo(stream.Length));
        });
    }

    [Test]
    public async Task InputAudioStreamRejectsTrailingIncompletePcmSample()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        socket.QueueText(PcmSessionStartedJson);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        await LiveTestHelpers.InitializeAsync(session, timeout.Token);
        using ChunkedReadStream stream = new(new byte[7], 3);

        Assert.ThrowsAsync<InvalidDataException>(() => session.SendInputAudioAsync(stream, timeout.Token));
        Assert.That(stream.CanRead, Is.True);
    }

    [Test]
    public void InputAudioHelpersRejectNullArguments()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);

        Assert.Throws<ArgumentNullException>(() => session.SendInputAudioAsync((BinaryData)null));
        Assert.ThrowsAsync<ArgumentNullException>(() => session.SendInputAudioAsync((Stream)null));
        Assert.That(socket.SendCalls, Is.Zero);
    }

    [TestCase(false, false)]
    [TestCase(true, false)]
    [TestCase(false, true)]
    [TestCase(true, true)]
    public async Task CancelingOrDisposingAudioSendDoesNotOwnCallerStream(bool useStream, bool disposeSession)
    {
        using ControlledLiveWebSocket socket = new() { HoldSends = true };
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        socket.QueueText(PcmSessionStartedJson);
        using CancellationTokenSource cancellation = LiveTestHelpers.CreateTimeout();
        await LiveTestHelpers.InitializeAsync(session, cancellation.Token);
        byte[] audio = { 0, 1, 2, 3 };
        using MemoryStream stream = new(audio);
        Task sending = useStream
            ? session.SendInputAudioAsync(stream, cancellation.Token)
            : session.SendInputAudioAsync(BinaryData.FromBytes(audio), cancellation.Token);
        await LiveTestHelpers.AwaitAsync(socket.SendEntered.Task);

        if (disposeSession)
        {
            session.Dispose();
        }
        else
        {
            cancellation.Cancel();
        }

        Assert.CatchAsync<OperationCanceledException>(async () => await LiveTestHelpers.AwaitAsync(sending));
        Assert.Multiple(() =>
        {
            Assert.That(socket.SentCommands, Is.Empty);
            Assert.That(socket.SendCalls, Is.EqualTo(1));
            Assert.That(stream.CanRead, Is.True, "Canceling or disposing the session must not dispose caller-owned audio.");
            Assert.That(cancellation.IsCancellationRequested, Is.EqualTo(!disposeSession));
        });
    }

    [Test]
    public async Task CancelingAudioStreamReadPropagatesCancellationWithoutOwningStream()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        using ControlledReadStream stream = new();
        using CancellationTokenSource cancellation = LiveTestHelpers.CreateTimeout();
        Task sending = session.SendInputAudioAsync(stream, cancellation.Token);
        await LiveTestHelpers.AwaitAsync(stream.ReadEntered.Task);

        cancellation.Cancel();

        Assert.CatchAsync<OperationCanceledException>(async () => await LiveTestHelpers.AwaitAsync(sending));
        Assert.Multiple(() =>
        {
            Assert.That(stream.ReadCancellationToken.IsCancellationRequested, Is.True);
            Assert.That(stream.CanRead, Is.True);
            Assert.That(socket.SentCommands, Is.Empty);
        });
    }

    [Test]
    public async Task DisposingSessionCancelsPendingAudioStreamRead()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        using ControlledReadStream stream = new();
        using CancellationTokenSource cancellation = LiveTestHelpers.CreateTimeout();
        Task sending = session.SendInputAudioAsync(stream, cancellation.Token);
        await LiveTestHelpers.AwaitAsync(stream.ReadEntered.Task);

        session.Dispose();

        Assert.Multiple(() =>
        {
            Assert.That(stream.ReadCancellationToken.IsCancellationRequested, Is.True,
                "Pending audio reads must observe session disposal, not only caller cancellation.");
            Assert.That(cancellation.IsCancellationRequested, Is.False);
            Assert.That(stream.CanRead, Is.True);
        });
        Assert.CatchAsync<OperationCanceledException>(async () => await LiveTestHelpers.AwaitAsync(sending));
        Assert.That(socket.SentCommands, Is.Empty);
    }

    [Test]
    public void DisposedSessionRejectsEmptyAudioStream()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        using MemoryStream stream = new();
        session.Dispose();

        Assert.ThrowsAsync<ObjectDisposedException>(() => session.SendInputAudioAsync(stream));
        Assert.That(stream.CanRead, Is.True);
    }

    [Test]
    public async Task RawCommandPreservesExtensionFields()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        BinaryData command = BinaryData.FromString("""{"type":"session.start","extension":{"number":7},"text":"café"}""");

        await session.SendCommandAsync(command);

        Assert.That(socket.SentCommands.Single().ToArray(), Is.EqualTo(command.ToArray()));
    }

    [Test]
    public void NullClientEventAndCommandAreRejectedBeforeSending()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);

        Assert.Throws<ArgumentNullException>(() => session.SendEventAsync(null));
        Assert.ThrowsAsync<ArgumentNullException>(() => session.SendCommandAsync(null));
        Assert.That(socket.SendCalls, Is.Zero);
    }

    [TestCase("[]")]
    [TestCase("\"scalar\"")]
    [TestCase("{}")]
    [TestCase("""{"type":null}""")]
    [TestCase("""{"type":42}""")]
    [TestCase("""{"type":""}""")]
    public void CommandMustBeJsonObjectWithNonemptyStringType(string command)
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);

        Assert.ThrowsAsync<ArgumentException>(() => session.SendCommandAsync(BinaryData.FromString(command)));
        Assert.That(socket.SendCalls, Is.Zero);
    }

    [Test]
    public void MalformedOutgoingJsonIsRejectedBeforeSending()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);

        Assert.CatchAsync<JsonException>(() => session.SendCommandAsync(BinaryData.FromString("{")));
        Assert.That(socket.SendCalls, Is.Zero);
    }

    [Test]
    public void OversizeOutgoingCommandIsRejectedBeforeSending()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        BinaryData command = BinaryData.FromBytes(new byte[16 * 1024 * 1024 + 1]);

        Assert.ThrowsAsync<ArgumentException>(() => session.SendCommandAsync(command));
        Assert.That(socket.SendCalls, Is.Zero);
    }

    [TestCase(WebSocketState.Closed)]
    [TestCase(WebSocketState.CloseSent)]
    [TestCase(WebSocketState.Aborted)]
    public void SendRejectsNonOpenSession(WebSocketState state)
    {
        using ControlledLiveWebSocket socket = new(state);
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);

        Assert.ThrowsAsync<InvalidOperationException>(() => session.SendCommandAsync(BinaryData.FromString(SessionCloseJson)));
        Assert.That(socket.SendCalls, Is.Zero);
    }

    [Test]
    public void PreCanceledSendDoesNotEnterWebSocket()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        using CancellationTokenSource cancellation = new();
        cancellation.Cancel();

        Assert.CatchAsync<OperationCanceledException>(() =>
            session.SendCommandAsync(BinaryData.FromString(SessionCloseJson), cancellation.Token));
        Assert.That(socket.SendCalls, Is.Zero);
    }

    [Test]
    public async Task CancellationDuringSendReachesWebSocketAndReleasesSendLock()
    {
        using ControlledLiveWebSocket socket = new() { HoldSends = true };
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        using CancellationTokenSource cancellation = LiveTestHelpers.CreateTimeout();
        Task sending = session.SendCommandAsync(BinaryData.FromString(SessionCloseJson), cancellation.Token);
        await LiveTestHelpers.AwaitAsync(socket.SendEntered.Task);

        cancellation.Cancel();

        Assert.CatchAsync<OperationCanceledException>(async () => await LiveTestHelpers.AwaitAsync(sending));
        socket.ReleaseSends();
        await session.SendCommandAsync(BinaryData.FromString(SessionCloseJson));
        Assert.Multiple(() =>
        {
            Assert.That(socket.SentCommands.Count, Is.EqualTo(1), "The canceled send must not have completed.");
            Assert.That(socket.MaximumConcurrentSends, Is.EqualTo(1));
        });
    }

    [Test]
    public async Task ConcurrentSendsAreSerializedWithoutDroppingOrCombiningMessages()
    {
        using ControlledLiveWebSocket socket = new() { HoldSends = true };
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        BinaryData[] commands = Enumerable.Range(0, 12)
            .Select(index => BinaryData.FromString("""{"type":"session.start","test_sequence":""" + index + "}")).ToArray();
        Task[] sends = commands.Select(command => session.SendCommandAsync(command, timeout.Token)).ToArray();
        await LiveTestHelpers.AwaitAsync(socket.SendEntered.Task);

        Assert.That(socket.SendCalls, Is.EqualTo(1), "Only the first caller may enter a blocked WebSocket send.");
        socket.ReleaseSends();
        await LiveTestHelpers.AwaitAsync(Task.WhenAll(sends));

        Assert.Multiple(() =>
        {
            Assert.That(socket.MaximumConcurrentSends, Is.EqualTo(1));
            Assert.That(socket.SendCalls, Is.EqualTo(commands.Length));
            Assert.That(socket.SentCommands.Select(command => command.ToString()),
                Is.EquivalentTo(commands.Select(command => command.ToString())));
        });
    }

    [Test]
    public async Task CancelingQueuedSendDoesNotCancelOrSkipOtherSenders()
    {
        using ControlledLiveWebSocket socket = new() { HoldSends = true };
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        using CancellationTokenSource cancellation = LiveTestHelpers.CreateTimeout();
        BinaryData first = BinaryData.FromString("""{"type":"session.start","test_sequence":1}""");
        BinaryData canceled = BinaryData.FromString("""{"type":"session.start","test_sequence":2}""");
        BinaryData last = BinaryData.FromString("""{"type":"session.start","test_sequence":3}""");
        Task firstSend = session.SendCommandAsync(first, timeout.Token);
        await LiveTestHelpers.AwaitAsync(socket.SendEntered.Task);
        Task canceledSend = session.SendCommandAsync(canceled, cancellation.Token);
        Task lastSend = session.SendCommandAsync(last, timeout.Token);

        cancellation.Cancel();

        Assert.CatchAsync<OperationCanceledException>(async () => await LiveTestHelpers.AwaitAsync(canceledSend));
        Assert.That(socket.SendCalls, Is.EqualTo(1));
        socket.ReleaseSends();
        await LiveTestHelpers.AwaitAsync(Task.WhenAll(firstSend, lastSend));
        Assert.That(socket.SentCommands.Select(command => command.ToString()),
            Is.EqualTo(new[] { first.ToString(), last.ToString() }));
    }

    [Test]
    public async Task ConcurrentReceiverIsRejectedAndConsumerDisposalReleasesReceiver()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        IAsyncEnumerator<LiveServerEvent> first = session.ReceiveEventsAsync(timeout.Token).GetAsyncEnumerator();
        await using (first)
        {
            Task<bool> receiving = first.MoveNextAsync().AsTask();
            await LiveTestHelpers.AwaitAsync(socket.ReceiveEntered.Task);
            await using IAsyncEnumerator<LiveServerEvent> competing = session.ReceiveEventsAsync(timeout.Token).GetAsyncEnumerator();

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await LiveTestHelpers.AwaitAsync(competing.MoveNextAsync().AsTask()));
            Assert.That(socket.ReceiveCalls, Is.EqualTo(1));
            socket.QueueText(LiveTestHelpers.SessionStartedJson);
            Assert.That(await LiveTestHelpers.AwaitAsync(receiving), Is.True);
        }
        socket.QueueText(ErrorJson);
        await using IAsyncEnumerator<LiveServerEvent> replacement = session.ReceiveEventsAsync(timeout.Token).GetAsyncEnumerator();
        Assert.That(await LiveTestHelpers.AwaitAsync(replacement.MoveNextAsync().AsTask()), Is.True);
        Assert.That(LiveTestHelpers.EventType(replacement.Current), Is.EqualTo("error"));
    }

    [Test]
    public async Task PreCanceledReceiveDoesNotEnterWebSocket()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        using CancellationTokenSource cancellation = new();
        cancellation.Cancel();
        await using IAsyncEnumerator<LiveServerEvent> events = session.ReceiveEventsAsync(cancellation.Token).GetAsyncEnumerator();

        Assert.CatchAsync<OperationCanceledException>(async () =>
            await LiveTestHelpers.AwaitAsync(events.MoveNextAsync().AsTask()));
        Assert.That(socket.ReceiveCalls, Is.Zero);
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task ReceiveCancellationReleasesReceiver(bool cancelEnumeratorToken)
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        using CancellationTokenSource cancellation = LiveTestHelpers.CreateTimeout();
        IAsyncEnumerable<LiveServerEvent> stream = session.ReceiveEventsAsync(
            cancelEnumeratorToken ? default : cancellation.Token);
        await using (IAsyncEnumerator<LiveServerEvent> events = stream.GetAsyncEnumerator(
            cancelEnumeratorToken ? cancellation.Token : default))
        {
            Task<bool> receiving = events.MoveNextAsync().AsTask();
            await LiveTestHelpers.AwaitAsync(socket.ReceiveEntered.Task);

            cancellation.Cancel();

            Assert.CatchAsync<OperationCanceledException>(async () => await LiveTestHelpers.AwaitAsync(receiving));
        }
        socket.QueueText(LiveTestHelpers.SessionStartedJson);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        await using IAsyncEnumerator<LiveServerEvent> replacement = session.ReceiveEventsAsync(timeout.Token).GetAsyncEnumerator();
        Assert.That(await LiveTestHelpers.AwaitAsync(replacement.MoveNextAsync().AsTask()), Is.True);
        Assert.That(LiveTestHelpers.EventType(replacement.Current), Is.EqualTo("session.started"));
    }

    [Test]
    public async Task BinaryServerMessageIsRejected()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        socket.QueueFrame(Encoding.UTF8.GetBytes(LiveTestHelpers.SessionStartedJson), WebSocketMessageType.Binary, true);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        await using IAsyncEnumerator<LiveServerEvent> events = session.ReceiveEventsAsync(timeout.Token).GetAsyncEnumerator();

        Assert.ThrowsAsync<InvalidDataException>(async () =>
            await LiveTestHelpers.AwaitAsync(events.MoveNextAsync().AsTask()));
    }

    [TestCase("{")]
    [TestCase("""{"type":"session.started",}""")]
    public async Task MalformedServerJsonIsRejected(string message)
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        socket.QueueText(message);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        await using IAsyncEnumerator<LiveServerEvent> events = session.ReceiveEventsAsync(timeout.Token).GetAsyncEnumerator();

        Assert.CatchAsync<JsonException>(async () =>
            await LiveTestHelpers.AwaitAsync(events.MoveNextAsync().AsTask()));
    }

    [Test]
    public async Task OversizeFragmentedServerMessageIsRejectedBeforeDeserialization()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        byte[] fragment = new byte[8192];
        for (int index = 0; index < 2048; index++)
        {
            socket.QueueFrame(fragment, WebSocketMessageType.Text, false);
        }
        socket.QueueFrame(new byte[1], WebSocketMessageType.Text, true);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        await using IAsyncEnumerator<LiveServerEvent> events = session.ReceiveEventsAsync(timeout.Token).GetAsyncEnumerator();

        Assert.ThrowsAsync<InvalidDataException>(async () =>
            await LiveTestHelpers.AwaitAsync(events.MoveNextAsync().AsTask()));
        Assert.That(socket.ReceiveCalls, Is.EqualTo(2049), "The client must count bytes across all fragments.");
    }

    [TestCase(WebSocketCloseStatus.NormalClosure)]
    [TestCase(WebSocketCloseStatus.EndpointUnavailable)]
    public async Task GracefulPeerCloseIsAcknowledgedAndEndsEnumeration(WebSocketCloseStatus status)
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        socket.QueueClose(status);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        await using IAsyncEnumerator<LiveServerEvent> events = session.ReceiveEventsAsync(timeout.Token).GetAsyncEnumerator();

        Assert.That(await LiveTestHelpers.AwaitAsync(events.MoveNextAsync().AsTask()), Is.False);
        Assert.Multiple(() =>
        {
            Assert.That(socket.CloseOutputCalls, Is.EqualTo(1));
            Assert.That(socket.OutputCloseStatus, Is.EqualTo(status));
            Assert.That(socket.SentCommands, Is.Empty, "Peer closure must not send an unsolicited session.close command.");
            Assert.That(session.State, Is.EqualTo(WebSocketState.Closed));
        });
    }

    [Test]
    public async Task AbnormalPeerCloseIsAcknowledgedAndReported()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        socket.QueueClose(WebSocketCloseStatus.InternalServerError);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        await using IAsyncEnumerator<LiveServerEvent> events = session.ReceiveEventsAsync(timeout.Token).GetAsyncEnumerator();

        Assert.ThrowsAsync<WebSocketException>(async () =>
            await LiveTestHelpers.AwaitAsync(events.MoveNextAsync().AsTask()));
        Assert.Multiple(() =>
        {
            Assert.That(socket.CloseOutputCalls, Is.EqualTo(1));
            Assert.That(socket.OutputCloseStatus, Is.EqualTo(WebSocketCloseStatus.InternalServerError));
            Assert.That(session.State, Is.EqualTo(WebSocketState.Closed));
        });
    }

    [Test]
    public async Task PrematureTransportClosureIsPropagatedUnchanged()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        WebSocketException failure = new(WebSocketError.ConnectionClosedPrematurely);
        socket.QueueFailure(failure);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        await using IAsyncEnumerator<LiveServerEvent> events = session.ReceiveEventsAsync(timeout.Token).GetAsyncEnumerator();

        WebSocketException actual = Assert.ThrowsAsync<WebSocketException>(async () =>
            await LiveTestHelpers.AwaitAsync(events.MoveNextAsync().AsTask()));
        Assert.That(actual, Is.SameAs(failure));
    }

    [Test]
    public async Task LocalCloseSendsNativeCommandBeforeClosingOutputAndWaitsForPeer()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        socket.QueueText(LiveTestHelpers.SessionClosedJson);
        Task closing = session.CloseAsync(timeout.Token);
        await LiveTestHelpers.AwaitAsync(socket.CloseOutputEntered.Task);
        await LiveTestHelpers.AwaitAsync(socket.ReceiveEntered.Task);

        Assert.Multiple(() =>
        {
            Assert.That(socket.SentCommands.Select(LiveTestHelpers.EventType), Is.EqualTo(new[] { "session.close" }));
            Assert.That(socket.Operations.First(), Is.EqualTo("send"));
            Assert.That(closing.IsCompleted, Is.False);
            Assert.That(socket.OutputCloseStatus, Is.EqualTo(WebSocketCloseStatus.NormalClosure));
            Assert.That(session.State, Is.EqualTo(WebSocketState.CloseSent));
        });
        socket.QueueClose(WebSocketCloseStatus.NormalClosure);
        await LiveTestHelpers.AwaitAsync(closing);
        await session.CloseAsync(timeout.Token);
        Assert.Multiple(() =>
        {
            Assert.That(session.State, Is.EqualTo(WebSocketState.Closed));
            Assert.That(socket.SentCommands.Count, Is.EqualTo(1));
            Assert.That(socket.CloseOutputCalls, Is.EqualTo(1));
        });
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task NativeCloseRejectsNewCommandsAndIsNotSentTwice(bool sendExplicitEvent)
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        if (sendExplicitEvent)
        {
            await session.SendEventAsync(new LiveClientEventLiveSessionCloseParam(), timeout.Token);
        }
        Task closing = session.CloseAsync(timeout.Token);
        await LiveTestHelpers.AwaitAsync(socket.SendEntered.Task);

        Assert.ThrowsAsync<InvalidOperationException>(() => session.SendEventAsync(new LiveClientEventLiveInputAudioMuteParam(), timeout.Token));
        socket.QueueText(LiveTestHelpers.SessionClosedJson);
        await LiveTestHelpers.AwaitAsync(socket.CloseOutputEntered.Task);
        socket.QueueClose(WebSocketCloseStatus.NormalClosure);
        await LiveTestHelpers.AwaitAsync(closing);
        Assert.That(socket.SentCommands.Select(LiveTestHelpers.EventType), Is.EqualTo(new[] { "session.close" }));
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task NativeFinalizationWhileCloseWaitsForSendStillClosesTransport(bool pendingNativeClose)
    {
        using ControlledLiveWebSocket socket = new() { HoldSends = true };
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        LiveClientEvent pendingEvent = pendingNativeClose
            ? new LiveClientEventLiveSessionCloseParam()
            : new LiveClientEventLiveInputAudioMuteParam();
        Task sending = session.SendEventAsync(pendingEvent, timeout.Token);
        await LiveTestHelpers.AwaitAsync(socket.SendEntered.Task);
        Task closing = session.CloseAsync(timeout.Token);
        Assert.That(closing.IsCompleted, Is.False);

        socket.QueueText(LiveTestHelpers.SessionClosedJson);
        await using (IAsyncEnumerator<LiveServerEvent> events = session.ReceiveEventsAsync(timeout.Token).GetAsyncEnumerator())
        {
            Assert.That(await LiveTestHelpers.AwaitAsync(events.MoveNextAsync().AsTask()), Is.True);
            Assert.That(events.Current, Is.TypeOf<LiveServerEventLiveSessionClosed>());
        }
        socket.ReleaseSends();
        await LiveTestHelpers.AwaitAsync(sending);
        await LiveTestHelpers.AwaitAsync(socket.CloseOutputEntered.Task);
        socket.QueueClose(WebSocketCloseStatus.NormalClosure);
        await LiveTestHelpers.AwaitAsync(closing);

        Assert.That(socket.SentCommands.Count, Is.EqualTo(1), "Already confirmed/requested native closure must not send another close command.");
        Assert.That(session.State, Is.EqualTo(WebSocketState.Closed));
        Assert.That(session.SessionClosed, Is.Not.Null);
    }

    [Test]
    public async Task CloseWaitsForNativeTerminalSessionClosedBeforeClosingWebSocketOutput()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        Task closing = session.CloseAsync(timeout.Token);
        await LiveTestHelpers.AwaitAsync(socket.SendEntered.Task);

        Assert.Multiple(() =>
        {
            Assert.That(socket.SentCommands.Select(LiveTestHelpers.EventType), Is.EqualTo(new[] { "session.close" }));
            Assert.That(socket.CloseOutputCalls, Is.Zero, "The native session.closed event, not a WebSocket close frame, confirms session finalization.");
            Assert.That(closing.IsCompleted, Is.False);
            Assert.That(session.State, Is.EqualTo(WebSocketState.Open));
        });
        socket.QueueText(LiveTestHelpers.SessionClosedJson);
        await LiveTestHelpers.AwaitAsync(socket.CloseOutputEntered.Task);
        socket.QueueClose(WebSocketCloseStatus.NormalClosure);

        await LiveTestHelpers.AwaitAsync(closing);
        Assert.Multiple(() =>
        {
            Assert.That(socket.CloseOutputCalls, Is.EqualTo(1));
            Assert.That(session.State, Is.EqualTo(WebSocketState.Closed));
            Assert.That(session.SessionClosed.EventId, Is.EqualTo("closed-event"));
            Assert.That(session.SessionClosed.Reason, Is.EqualTo(LiveServerEventLiveSessionClosedReason.CloseRequested));
            Assert.That(session.SessionClosed.Session.Status, Is.EqualTo("active"));
            Assert.That(session.SessionClosed.Usage.Seconds, Is.Zero);
        });
    }

    [Test]
    public async Task NativeTerminalEventIsRetainedBeforeGracefulWebSocketClosure()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        socket.QueueText(LiveTestHelpers.SessionClosedJson);
        LiveServerEventLiveSessionClosed closed;
        await using (IAsyncEnumerator<LiveServerEvent> events = session.ReceiveEventsAsync(timeout.Token).GetAsyncEnumerator())
        {
            Assert.That(await LiveTestHelpers.AwaitAsync(events.MoveNextAsync().AsTask()), Is.True);
            Assert.That(events.Current, Is.TypeOf<LiveServerEventLiveSessionClosed>());
            closed = (LiveServerEventLiveSessionClosed)events.Current;
            Assert.Multiple(() =>
            {
                Assert.That(session.SessionClosed, Is.SameAs(closed));
                Assert.That(closed.Session.Status, Is.EqualTo("active"));
                Assert.That(closed.Usage.Seconds, Is.Zero);
                Assert.That(session.State, Is.EqualTo(WebSocketState.Open));
            });
            Assert.That(await LiveTestHelpers.AwaitAsync(events.MoveNextAsync().AsTask()), Is.False);
            Assert.That(socket.ReceiveCalls, Is.EqualTo(1), "The terminal event ends native enumeration without waiting for a WebSocket close.");
        }

        Task closing = session.CloseAsync(timeout.Token);
        await LiveTestHelpers.AwaitAsync(socket.CloseOutputEntered.Task);
        socket.QueueClose(WebSocketCloseStatus.NormalClosure);
        await LiveTestHelpers.AwaitAsync(closing);

        Assert.Multiple(() =>
        {
            Assert.That(socket.SentCommands, Is.Empty, "A finalized session must not receive another native close command.");
            Assert.That(session.SessionClosed, Is.SameAs(closed));
            Assert.That(session.State, Is.EqualTo(WebSocketState.Closed));
        });
    }

    [Test]
    public void WebSocketClosureWithoutNativeTerminalEventDoesNotConfirmFinalization()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        socket.QueueClose(WebSocketCloseStatus.NormalClosure);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();

        Assert.ThrowsAsync<InvalidDataException>(() => session.CloseAsync(timeout.Token));
        Assert.Multiple(() =>
        {
            Assert.That(session.SessionClosed, Is.Null);
            Assert.That(session.State, Is.EqualTo(WebSocketState.Closed));
        });
    }

    [Test]
    public async Task LocalCloseSharesSocketReceiverWithActiveEnumeration()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        Task closing;
        await using (IAsyncEnumerator<LiveServerEvent> events = session.ReceiveEventsAsync(timeout.Token).GetAsyncEnumerator())
        {
            Task<bool> receiving = events.MoveNextAsync().AsTask();
            await LiveTestHelpers.AwaitAsync(socket.ReceiveEntered.Task);
            closing = session.CloseAsync(timeout.Token);
            await LiveTestHelpers.AwaitAsync(socket.SendEntered.Task);

            Assert.That(socket.ReceiveCalls, Is.EqualTo(1), "Closing must not start a second WebSocket receive.");
            socket.QueueText(LiveTestHelpers.SessionClosedJson);
            Assert.That(await LiveTestHelpers.AwaitAsync(receiving), Is.True);
            Assert.That(LiveTestHelpers.EventType(events.Current), Is.EqualTo("session.closed"));
        }
        await LiveTestHelpers.AwaitAsync(socket.CloseOutputEntered.Task);
        socket.QueueClose(WebSocketCloseStatus.NormalClosure);

        await LiveTestHelpers.AwaitAsync(closing);
        Assert.That(session.State, Is.EqualTo(WebSocketState.Closed));
    }

    [Test]
    public async Task CloseAfterIteratorBreakDrainsRemainingFramesAndPeerClose()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        socket.QueueText(LiveTestHelpers.SessionStartedJson);
        Task closing = null;

        await foreach (LiveServerEvent serverEvent in session.ReceiveEventsAsync(timeout.Token))
        {
            Assert.That(LiveTestHelpers.EventType(serverEvent), Is.EqualTo("session.started"));
            closing = session.CloseAsync(timeout.Token);
            await LiveTestHelpers.AwaitAsync(socket.SendEntered.Task);
            socket.QueueText(ErrorJson);
            socket.QueueText(LiveTestHelpers.SessionClosedJson);
            Assert.Multiple(() =>
            {
                Assert.That(closing.IsCompleted, Is.False, "Closing must wait for the enumeration to release receive ownership.");
                Assert.That(socket.ReceiveCalls, Is.EqualTo(1), "Only the enumeration may receive until its iterator is disposed.");
            });
            break;
        }

        Assert.That(closing, Is.Not.Null);
        await LiveTestHelpers.AwaitAsync(socket.CloseOutputEntered.Task);
        socket.QueueClose(WebSocketCloseStatus.NormalClosure);
        await LiveTestHelpers.AwaitAsync(closing);
        Assert.Multiple(() =>
        {
            Assert.That(socket.ReceiveCalls, Is.EqualTo(4), "Closing must drain the remaining event, native terminal event, and peer close after the consumer breaks.");
            Assert.That(socket.SentCommands.Select(LiveTestHelpers.EventType), Is.EqualTo(new[] { "session.close" }));
            Assert.That(socket.CloseOutputCalls, Is.EqualTo(1));
            Assert.That(session.State, Is.EqualTo(WebSocketState.Closed));
        });
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task CancelingActiveReceiverUnblocksCloseWithoutCancelingShutdown(bool cancelEnumeratorToken)
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        using CancellationTokenSource receiveCancellation = LiveTestHelpers.CreateTimeout();
        using CancellationTokenSource closeTimeout = LiveTestHelpers.CreateTimeout();
        IAsyncEnumerable<LiveServerEvent> stream = session.ReceiveEventsAsync(
            cancelEnumeratorToken ? default : receiveCancellation.Token);
        Task closing;
        await using (IAsyncEnumerator<LiveServerEvent> events = stream.GetAsyncEnumerator(
            cancelEnumeratorToken ? receiveCancellation.Token : default))
        {
            Task<bool> receiving = events.MoveNextAsync().AsTask();
            await LiveTestHelpers.AwaitAsync(socket.ReceiveEntered.Task);
            closing = session.CloseAsync(closeTimeout.Token);
            await LiveTestHelpers.AwaitAsync(socket.SendEntered.Task);
            Assert.That(socket.ReceiveCalls, Is.EqualTo(1));

            receiveCancellation.Cancel();

            Assert.CatchAsync<OperationCanceledException>(async () => await LiveTestHelpers.AwaitAsync(receiving));
        }
        socket.QueueText(LiveTestHelpers.SessionClosedJson);
        await LiveTestHelpers.AwaitAsync(socket.CloseOutputEntered.Task);
        socket.QueueClose(WebSocketCloseStatus.NormalClosure);

        await LiveTestHelpers.AwaitAsync(closing);
        Assert.Multiple(() =>
        {
            Assert.That(closeTimeout.IsCancellationRequested, Is.False);
            Assert.That(socket.ReceiveCalls, Is.EqualTo(3));
            Assert.That(socket.CloseOutputCalls, Is.EqualTo(1));
            Assert.That(session.State, Is.EqualTo(WebSocketState.Closed));
        });
    }

    [Test]
    public async Task DisposeCancelsCloseWaitingForActiveIteratorOwnership()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        socket.QueueText(LiveTestHelpers.SessionStartedJson);
        await using IAsyncEnumerator<LiveServerEvent> events = session.ReceiveEventsAsync().GetAsyncEnumerator();
        Assert.That(await LiveTestHelpers.AwaitAsync(events.MoveNextAsync().AsTask()), Is.True);
        Task closing = session.CloseAsync();
        await LiveTestHelpers.AwaitAsync(socket.SendEntered.Task);
        Assert.That(socket.ReceiveCalls, Is.EqualTo(1));

        session.Dispose();

        Assert.CatchAsync<OperationCanceledException>(async () => await LiveTestHelpers.AwaitAsync(closing));
        Assert.Multiple(() =>
        {
            Assert.That(socket.ReceiveCalls, Is.EqualTo(1), "Disposal must cancel the waiting close without starting a competing receive.");
            Assert.That(socket.DisposeCalls, Is.EqualTo(1));
            Assert.That(session.State, Is.EqualTo(WebSocketState.Closed));
        });
    }

    [Test]
    public async Task PreCanceledCloseDoesNotPreventLaterGracefulClose()
    {
        using ControlledLiveWebSocket socket = new();
        using ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        using CancellationTokenSource cancellation = new();
        cancellation.Cancel();

        Assert.CatchAsync<OperationCanceledException>(() => session.CloseAsync(cancellation.Token));
        Assert.Multiple(() =>
        {
            Assert.That(socket.SendCalls, Is.Zero);
            Assert.That(socket.CloseOutputCalls, Is.Zero);
            Assert.That(session.State, Is.EqualTo(WebSocketState.Open));
        });
        socket.QueueText(LiveTestHelpers.SessionClosedJson);
        socket.QueueClose(WebSocketCloseStatus.NormalClosure);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();

        await LiveTestHelpers.AwaitAsync(session.CloseAsync(timeout.Token));

        Assert.That(socket.SentCommands.Select(LiveTestHelpers.EventType), Is.EqualTo(new[] { "session.close" }),
            "Cancellation before shutdown starts must not permanently suppress the native close command.");
    }

    [Test]
    public async Task DisposeCancelsPendingReceiveAndSubsequentOperationsRejectDisposedSession()
    {
        using ControlledLiveWebSocket socket = new();
        ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        await using IAsyncEnumerator<LiveServerEvent> events = session.ReceiveEventsAsync().GetAsyncEnumerator();
        Task<bool> receiving = events.MoveNextAsync().AsTask();
        await LiveTestHelpers.AwaitAsync(socket.ReceiveEntered.Task);

        session.Dispose();

        Assert.CatchAsync<OperationCanceledException>(async () => await LiveTestHelpers.AwaitAsync(receiving));
        session.Dispose();
        await session.DisposeAsync();
        Assert.ThrowsAsync<ObjectDisposedException>(() => session.SendCommandAsync(BinaryData.FromString(SessionCloseJson)));
        Assert.ThrowsAsync<ObjectDisposedException>(() => session.CloseAsync());
        await using IAsyncEnumerator<LiveServerEvent> afterDisposal = session.ReceiveEventsAsync().GetAsyncEnumerator();
        Assert.ThrowsAsync<ObjectDisposedException>(async () =>
            await LiveTestHelpers.AwaitAsync(afterDisposal.MoveNextAsync().AsTask()));
        Assert.That(socket.DisposeCalls, Is.EqualTo(1));
    }

    [Test]
    public async Task DisposeCancelsBothActiveAndQueuedSend()
    {
        using ControlledLiveWebSocket socket = new() { HoldSends = true };
        ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        Task active = session.SendCommandAsync(BinaryData.FromString(SessionCloseJson));
        await LiveTestHelpers.AwaitAsync(socket.SendEntered.Task);
        Task queued = session.SendCommandAsync(BinaryData.FromString(SessionCloseJson));

        session.Dispose();

        Assert.CatchAsync<OperationCanceledException>(async () => await LiveTestHelpers.AwaitAsync(active));
        Assert.CatchAsync<OperationCanceledException>(async () => await LiveTestHelpers.AwaitAsync(queued));
        Assert.Multiple(() =>
        {
            Assert.That(socket.SendCalls, Is.EqualTo(1));
            Assert.That(socket.DisposeCalls, Is.EqualTo(1));
            Assert.That(socket.SentCommands, Is.Empty);
        });
    }

    [Test]
    public async Task ConcurrentSynchronousDisposeReleasesSocketOnlyOnce()
    {
        using ControlledLiveWebSocket socket = new();
        ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);

        await LiveTestHelpers.AwaitAsync(Task.WhenAll(Enumerable.Range(0, 16).Select(_ => Task.Run(session.Dispose))));
        await session.DisposeAsync();

        Assert.That(socket.DisposeCalls, Is.EqualTo(1));
    }

    [Test]
    public async Task AsyncDisposeGracefullyClosesAndRepeatedDisposalDoesNotRepeatHandshake()
    {
        using ControlledLiveWebSocket socket = new();
        ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        socket.QueueText(LiveTestHelpers.SessionClosedJson);
        Task disposing = session.DisposeAsync().AsTask();
        await LiveTestHelpers.AwaitAsync(socket.CloseOutputEntered.Task);
        Assert.That(disposing.IsCompleted, Is.False);
        socket.QueueClose(WebSocketCloseStatus.NormalClosure);

        await LiveTestHelpers.AwaitAsync(disposing);
        await session.DisposeAsync();
        session.Dispose();

        Assert.Multiple(() =>
        {
            Assert.That(socket.SentCommands.Select(LiveTestHelpers.EventType), Is.EqualTo(new[] { "session.close" }));
            Assert.That(socket.CloseOutputCalls, Is.EqualTo(1));
            Assert.That(socket.DisposeCalls, Is.EqualTo(1));
            Assert.That(session.State, Is.EqualTo(WebSocketState.Closed));
        });
    }

    [Test]
    public async Task AsyncDisposeReleasesSocketEvenWhenGracefulCloseFails()
    {
        using ControlledLiveWebSocket socket = new();
        ProjectsLiveSessionClient session = LiveTestHelpers.CreateSession(socket);
        WebSocketException failure = new(WebSocketError.ConnectionClosedPrematurely);
        socket.QueueFailure(failure);

        WebSocketException actual = Assert.ThrowsAsync<WebSocketException>(async () =>
            await LiveTestHelpers.AwaitAsync(session.DisposeAsync().AsTask()));
        await session.DisposeAsync();

        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.SameAs(failure));
            Assert.That(socket.DisposeCalls, Is.EqualTo(1));
        });
    }

    private sealed class ChunkedReadStream : MemoryStream
    {
        private readonly int _readSize;

        public ChunkedReadStream(byte[] bytes, int readSize) : base(bytes)
        {
            _readSize = readSize;
        }

        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) =>
            base.ReadAsync(buffer, offset, Math.Min(count, _readSize), cancellationToken);
    }

    private sealed class ControlledReadStream : MemoryStream
    {
        private readonly SemaphoreSlim _release = new(0);

        public TaskCompletionSource<bool> ReadEntered { get; } = LiveTestHelpers.CreateSignal();
        public CancellationToken ReadCancellationToken { get; private set; }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            ReadCancellationToken = cancellationToken;
            ReadEntered.TrySetResult(true);
            await _release.WaitAsync(cancellationToken);
            return 0;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _release.Release();
            }
            base.Dispose(disposing);
        }
    }

    private sealed class ControlledLiveWebSocket : WebSocket
    {
        private readonly Queue<ReceiveFrame> _frames = new();
        private readonly SemaphoreSlim _availableFrames = new(0);
        private readonly TaskCompletionSource<bool> _releaseSends = LiveTestHelpers.CreateSignal();
        private WebSocketState _state;
        private WebSocketCloseStatus? _closeStatus;
        private int _sendCalls;
        private int _receiveCalls;
        private int _activeSends;
        private int _maximumConcurrentSends;
        private int _disposeCalls;

        public ControlledLiveWebSocket(WebSocketState state = WebSocketState.Open)
        {
            _state = state;
        }

        public bool HoldSends { get; set; }
        public int SendCalls => Volatile.Read(ref _sendCalls);
        public int ReceiveCalls => Volatile.Read(ref _receiveCalls);
        public int MaximumConcurrentSends => Volatile.Read(ref _maximumConcurrentSends);
        public int DisposeCalls => Volatile.Read(ref _disposeCalls);
        public int CloseOutputCalls { get; private set; }
        public WebSocketCloseStatus? OutputCloseStatus { get; private set; }
        public WebSocketMessageType LastSendMessageType { get; private set; }
        public bool LastSendEndOfMessage { get; private set; }
        public List<BinaryData> SentCommands { get; } = new();
        public List<string> Operations { get; } = new();
        public TaskCompletionSource<bool> SendEntered { get; } = LiveTestHelpers.CreateSignal();
        public TaskCompletionSource<bool> ReceiveEntered { get; } = LiveTestHelpers.CreateSignal();
        public TaskCompletionSource<bool> CloseOutputEntered { get; } = LiveTestHelpers.CreateSignal();
        public override WebSocketCloseStatus? CloseStatus => _closeStatus;
        public override string CloseStatusDescription => null;
        public override WebSocketState State => _state;
        public override string SubProtocol => null;

        public void QueueText(string text) => QueueFrame(Encoding.UTF8.GetBytes(text), WebSocketMessageType.Text, true);

        public void QueueFrame(byte[] bytes, WebSocketMessageType messageType, bool endOfMessage)
        {
            Enqueue(new ReceiveFrame(bytes, messageType, endOfMessage));
        }

        public void QueueClose(WebSocketCloseStatus status)
        {
            Enqueue(new ReceiveFrame(Array.Empty<byte>(), WebSocketMessageType.Close, true, status));
        }

        public void QueueFailure(WebSocketException exception)
        {
            Enqueue(new ReceiveFrame(Array.Empty<byte>(), WebSocketMessageType.Text, true, failure: exception));
        }

        private void Enqueue(ReceiveFrame frame)
        {
            lock (_frames)
            {
                _frames.Enqueue(frame);
            }
            _availableFrames.Release();
        }

        public void ReleaseSends()
        {
            HoldSends = false;
            _releaseSends.TrySetResult(true);
        }

        public override async Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType,
            bool endOfMessage, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            Interlocked.Increment(ref _sendCalls);
            int active = Interlocked.Increment(ref _activeSends);
            int maximum;
            do
            {
                maximum = Volatile.Read(ref _maximumConcurrentSends);
            }
            while (active > maximum && Interlocked.CompareExchange(ref _maximumConcurrentSends, active, maximum) != maximum);
            SendEntered.TrySetResult(true);
            try
            {
                if (HoldSends)
                {
                    TaskCompletionSource<bool> canceled = LiveTestHelpers.CreateSignal();
                    using CancellationTokenRegistration registration = cancellationToken.Register(() => canceled.TrySetCanceled());
                    Task completed = await Task.WhenAny(_releaseSends.Task, canceled.Task);
                    await completed;
                }
                cancellationToken.ThrowIfCancellationRequested();
                byte[] bytes = new byte[buffer.Count];
                Array.Copy(buffer.Array, buffer.Offset, bytes, 0, buffer.Count);
                lock (SentCommands)
                {
                    SentCommands.Add(BinaryData.FromBytes(bytes));
                }
                lock (Operations)
                {
                    Operations.Add("send");
                }
                LastSendMessageType = messageType;
                LastSendEndOfMessage = endOfMessage;
            }
            finally
            {
                Interlocked.Decrement(ref _activeSends);
            }
        }

        public override async Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken)
        {
            Interlocked.Increment(ref _receiveCalls);
            lock (Operations)
            {
                Operations.Add("receive");
            }
            ReceiveEntered.TrySetResult(true);
            await _availableFrames.WaitAsync(cancellationToken);
            ReceiveFrame frame;
            lock (_frames)
            {
                frame = _frames.Dequeue();
            }
            if (frame.Failure != null)
            {
                _state = WebSocketState.Aborted;
                throw frame.Failure;
            }
            Assert.That(frame.Bytes.Length, Is.LessThanOrEqualTo(buffer.Count), "The controlled test frame must fit in the receive buffer.");
            Array.Copy(frame.Bytes, 0, buffer.Array, buffer.Offset, frame.Bytes.Length);
            if (frame.MessageType == WebSocketMessageType.Close)
            {
                _closeStatus = frame.CloseStatus;
                _state = _state == WebSocketState.CloseSent ? WebSocketState.Closed : WebSocketState.CloseReceived;
            }
            return new WebSocketReceiveResult(frame.Bytes.Length, frame.MessageType, frame.EndOfMessage, frame.CloseStatus, null);
        }

        public override Task CloseOutputAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            CloseOutputCalls++;
            OutputCloseStatus = closeStatus;
            lock (Operations)
            {
                Operations.Add("close-output");
            }
            _state = _state == WebSocketState.CloseReceived ? WebSocketState.Closed : WebSocketState.CloseSent;
            CloseOutputEntered.TrySetResult(true);
            return Task.CompletedTask;
        }

        public override Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _state = WebSocketState.Closed;
            _closeStatus = closeStatus;
            return Task.CompletedTask;
        }

        public override void Abort() => _state = WebSocketState.Aborted;

        public override void Dispose()
        {
            Interlocked.Increment(ref _disposeCalls);
            _state = WebSocketState.Closed;
        }

        private sealed class ReceiveFrame
        {
            public ReceiveFrame(byte[] bytes, WebSocketMessageType messageType, bool endOfMessage,
                WebSocketCloseStatus? closeStatus = null, WebSocketException failure = null)
            {
                Bytes = bytes;
                MessageType = messageType;
                EndOfMessage = endOfMessage;
                CloseStatus = closeStatus;
                Failure = failure;
            }

            public byte[] Bytes { get; }
            public WebSocketMessageType MessageType { get; }
            public bool EndOfMessage { get; }
            public WebSocketCloseStatus? CloseStatus { get; }
            public WebSocketException Failure { get; }
        }
    }
}
