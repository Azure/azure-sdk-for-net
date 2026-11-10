// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Microsoft.ClientModel.TestFramework;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using OpenAI.Realtime;

#pragma warning disable AAIP002
#pragma warning disable OPENAI002

namespace Azure.AI.Projects.Tests;

[NonParallelizable]
public class VoiceAgentRealtimeTelemetryTests
{
    private const string TracingSwitch = "Azure.Experimental.EnableGenAITracing";
    private const string ContentSwitch = "Azure.Experimental.TraceGenAIMessageContent";
    private const string TracingVariable = "AZURE_EXPERIMENTAL_ENABLE_GENAI_TRACING";
    private const string ContentVariable = "OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT";
    private const string SourceName = "Azure.AI.Projects.ProjectsRealtimeClient";
    private const string Prefix = "az.ai.voice_agents.";
    private const string SessionName = "voice_agents.realtime.session";
    private const string ConnectName = "voice_agents.realtime.connect";
    private const string ResponseName = "invoke_agent";
    private const string MessageSecret = "private-message-content";
    private const string ExceptionSecret = "private-exception-message";
    private const string MetadataSecret = "private-metadata-value";
    private static readonly Uri s_endpoint = new("https://voice.example.test:8443/api/projects/private-project?key=private-query-value");

    private readonly ConcurrentQueue<Activity> _activities = new();
    private readonly ConcurrentQueue<string> _logs = new();
    private readonly List<RealtimeTelemetry> _telemetries = new();
    private ActivityListener _listener;
    private AzureEventSourceListener _logListener;
    private Activity _previousActivity;
    private string _previousTracing;
    private string _previousContent;
    private bool _hadTracingSwitch;
    private bool _hadContentSwitch;
    private bool _previousTracingSwitch;
    private bool _previousContentSwitch;

    [SetUp]
    public void SetUp()
    {
        _previousActivity = Activity.Current;
        _previousTracing = Environment.GetEnvironmentVariable(TracingVariable);
        _previousContent = Environment.GetEnvironmentVariable(ContentVariable);
        _hadTracingSwitch = AppContext.TryGetSwitch(TracingSwitch, out _previousTracingSwitch);
        _hadContentSwitch = AppContext.TryGetSwitch(ContentSwitch, out _previousContentSwitch);
        SetTracing("true");
        SetContentCapture(false);
        while (_activities.TryDequeue(out _))
        {
        }
        while (_logs.TryDequeue(out _))
        {
        }
        _telemetries.Clear();
        _listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == SourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
            ActivityStopped = activity => _activities.Enqueue(activity)
        };
        ActivitySource.AddActivityListener(_listener);
        _logListener = new AzureEventSourceListener((eventData, message) =>
        {
            if (eventData.EventSource.Name == "Azure-AI-Projects-Realtime")
            {
                _logs.Enqueue(message);
            }
        }, EventLevel.Verbose);
    }

    [TearDown]
    public void TearDown()
    {
        try
        {
            foreach (RealtimeTelemetry telemetry in _telemetries)
            {
                telemetry.Close(null, true);
            }
        }
        finally
        {
            _logListener?.Dispose();
            _listener?.Dispose();
            Environment.SetEnvironmentVariable(TracingVariable, _previousTracing);
            Environment.SetEnvironmentVariable(ContentVariable, _previousContent);
            if (_hadTracingSwitch)
            {
                AppContext.SetSwitch(TracingSwitch, _previousTracingSwitch);
            }
            if (_hadContentSwitch)
            {
                AppContext.SetSwitch(ContentSwitch, _previousContentSwitch);
            }
            Activity.Current = _previousActivity;
        }
    }

    [TestCase(null, true)]
    [TestCase("false", true)]
    [TestCase("true", false)]
    public void StartRequiresTracingOptInAndClientEnablement(string tracingValue, bool enabled)
    {
        SetTracing(tracingValue);
        using Activity caller = new Activity("caller").SetIdFormat(ActivityIdFormat.W3C).Start();

        RealtimeTelemetry telemetry = CreateTelemetry(enabled: enabled);

        Assert.Multiple(() =>
        {
            Assert.That(telemetry, Is.Null);
            Assert.That(_activities, Is.Empty);
            Assert.That(_logs, Is.Empty);
            Assert.That(Activity.Current, Is.SameAs(caller));
        });
    }

    [Test]
    public void StartWithoutListenersDoesNotCreateTelemetryOrChangeAmbientActivity()
    {
        _listener.Dispose();
        using Activity caller = new Activity("caller").SetIdFormat(ActivityIdFormat.W3C).Start();

        RealtimeTelemetry telemetry = CreateTelemetry();

        Assert.Multiple(() =>
        {
            Assert.That(telemetry, Is.Null);
            Assert.That(_activities, Is.Empty);
            Assert.That(_logs, Is.Empty);
            Assert.That(Activity.Current, Is.SameAs(caller));
        });
    }

    [Test]
    public void DistributedTracingDisabledOnClientSkipsTelemetry()
    {
        InvalidOperationException failure = new(ExceptionSecret);
        AIProjectClient client = new(
            s_endpoint,
            new FailingTokenProvider(failure),
            new AIProjectClientOptions { EnableDistributedTracing = false });
        Activity caller = Activity.Current;

        InvalidOperationException actual = Assert.ThrowsAsync<InvalidOperationException>(
            async () => await client.ProjectsRealtimeClient.StartSessionAsync("voice-agent", intent: null));

        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.SameAs(failure));
            Assert.That(_activities, Is.Empty);
            Assert.That(_logs, Is.Empty);
            Assert.That(Activity.Current, Is.SameAs(caller));
        });
    }

    [TestCase(null, true, false)]
    [TestCase("false", true, false)]
    [TestCase("true", false, false)]
    [TestCase("true", true, true)]
    public void RealtimeUsesExistingFoundryTracingSettings(string tracing, bool distributedTracing, bool expected)
    {
        SetTracing(tracing);
        InvalidOperationException failure = new(ExceptionSecret);
        AIProjectClient client = new(s_endpoint, new FailingTokenProvider(failure),
            new AIProjectClientOptions { EnableDistributedTracing = distributedTracing });

        InvalidOperationException actual = Assert.ThrowsAsync<InvalidOperationException>(
            async () => await client.ProjectsRealtimeClient.StartSessionAsync("voice-agent", intent: null));

        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.SameAs(failure));
            Assert.That(_activities, Has.Count.EqualTo(expected ? 2 : 0));
        });
    }

    [TestCase(false)]
    [TestCase(true)]
    public void RealtimeUsesExistingFoundryLoggingSettings(bool enabled)
    {
        InvalidOperationException failure = new(ExceptionSecret);
        AIProjectClient client = new(s_endpoint, new FailingTokenProvider(failure),
            new AIProjectClientOptions { ClientLoggingOptions = new ClientLoggingOptions { EnableLogging = enabled } });

        InvalidOperationException actual = Assert.ThrowsAsync<InvalidOperationException>(
            async () => await client.ProjectsRealtimeClient.StartSessionAsync("voice-agent", intent: null));

        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.SameAs(failure));
            Assert.That(_activities, Has.Count.EqualTo(2));
            Assert.That(_logs.IsEmpty, Is.EqualTo(!enabled));
        });
        AssertPrivate(ExceptionSecret);
    }

    [TestCase(null, "websocket")]
    [TestCase("store=true&transport=webrtc", "webrtc")]
    public void SpansUseClientKindsAndExplicitParentsWithoutLeakingAmbientActivity(string queryString, string transport)
    {
        using Activity caller = new Activity("caller").SetIdFormat(ActivityIdFormat.W3C).Start();
        RealtimeTelemetry telemetry = StartTelemetry(queryString);
        Assert.That(Activity.Current, Is.SameAs(caller));
        telemetry.Connected();
        Assert.That(Activity.Current, Is.SameAs(caller));

        using (Activity foreign = new Activity("foreign").SetIdFormat(ActivityIdFormat.W3C).SetParentId(
            ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom()).Start())
        {
            Observe(telemetry, new { type = "response.created", response = new { id = "response-parenting" } });
            Assert.That(Activity.Current, Is.SameAs(foreign));
            Observe(telemetry, new { type = "response.done", response = new { id = "response-parenting", status = "completed" } });
            Assert.That(Activity.Current, Is.SameAs(foreign));
            telemetry.Close(WebSocketCloseStatus.NormalClosure, true);
            Assert.That(Activity.Current, Is.SameAs(foreign));
        }

        Activity session = Span(SessionName);
        Activity connect = Span(ConnectName);
        Activity response = Span(ResponseName);
        Assert.Multiple(() =>
        {
            Assert.That(_activities, Has.Count.EqualTo(3));
            foreach (Activity activity in _activities)
            {
                Assert.That(activity.Kind, Is.EqualTo(ActivityKind.Client));
                Assert.That(activity.Source.Name, Is.EqualTo(SourceName));
                Assert.That(activity.DisplayName, Is.EqualTo(activity.OperationName));
                Assert.That(activity.TraceId, Is.EqualTo(caller.TraceId));
                Assert.That(Tag(activity, "gen_ai.provider.name"), Is.EqualTo("microsoft.foundry"));
                Assert.That(Tag(activity, "gen_ai.agent.name"), Is.EqualTo("voice-agent"));
                Assert.That(Tag(activity, "gen_ai.agent.type"), Is.EqualTo("voice"));
                Assert.That(Tag(activity, "server.address"), Is.EqualTo("voice.example.test"));
                Assert.That(Tag(activity, "server.port"), Is.EqualTo(8443));
            }
            Assert.That(session.ParentSpanId, Is.EqualTo(caller.SpanId));
            Assert.That(connect.ParentSpanId, Is.EqualTo(session.SpanId));
            Assert.That(response.ParentSpanId, Is.EqualTo(session.SpanId));
            Assert.That(Tag(session, Prefix + "connection.transport"), Is.EqualTo(transport));
            Assert.That(Tag(connect, Prefix + "connection.transport"), Is.EqualTo(transport));
            Assert.That(Tag(session, Prefix + "connected"), Is.True);
            Assert.That(Tag(response, "gen_ai.operation.name"), Is.EqualTo("invoke_agent"));
            Assert.That(_logs, Is.Not.Empty, "Privacy checks must exercise the enabled EventSource logging path.");
            Assert.That(_logs.Any(message => message.Contains(session.TraceId.ToString())), Is.True);
            Assert.That(Activity.Current, Is.SameAs(caller));
        });
        AssertPrivate("private-query-value", "private-project");
    }

    [Test]
    public void TraceHeadersUseConnectContextAndPreserveCaseInsensitiveCallerValues()
    {
        using Activity caller = new Activity("caller").SetIdFormat(ActivityIdFormat.W3C).Start();
        caller.TraceStateString = "vendor=caller";
        RealtimeTelemetry telemetry = StartTelemetry();
        Dictionary<string, string> generated = new();
        Dictionary<string, string> supplied = new()
        {
            ["TraceParent"] = "00-0123456789abcdef0123456789abcdef-0123456789abcdef-01",
            ["TraceState"] = "vendor=supplied"
        };
        Dictionary<string, string> suppliedState = new() { ["TraceState"] = "vendor=preserved" };

        telemetry.AddTraceHeaders(generated);
        telemetry.AddTraceHeaders(supplied);
        telemetry.AddTraceHeaders(suppliedState);
        telemetry.Connected();
        Dictionary<string, string> afterConnect = new();
        telemetry.AddTraceHeaders(afterConnect);
        telemetry.Close(WebSocketCloseStatus.NormalClosure, true);

        Activity connect = Span(ConnectName);
        Assert.Multiple(() =>
        {
            Assert.That(generated["traceparent"], Is.EqualTo(connect.Id));
            Assert.That(generated["tracestate"], Is.EqualTo("vendor=caller"));
            Assert.That(supplied, Has.Count.EqualTo(2));
            Assert.That(supplied["TraceParent"], Is.EqualTo("00-0123456789abcdef0123456789abcdef-0123456789abcdef-01"));
            Assert.That(supplied["TraceState"], Is.EqualTo("vendor=supplied"));
            Assert.That(suppliedState, Has.Count.EqualTo(2));
            Assert.That(suppliedState["traceparent"], Is.EqualTo(connect.Id));
            Assert.That(suppliedState["TraceState"], Is.EqualTo("vendor=preserved"));
            Assert.That(afterConnect, Is.Empty);
            Assert.That(Activity.Current, Is.SameAs(caller));
        });
    }

    [Test]
    public void DisposalThroughBaseSessionAndWebSocketStopsOutstandingSpansExactlyOnce()
    {
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        Observe(telemetry, new { type = "response.created", response = new { id = "response-interrupted" } });
        StubWebSocket inner = new();
        using WebSocket socket = telemetry.CreateWebSocket(inner);
        using RealtimeSessionClient client = new SessionWithSocket(socket);
        Activity caller = Activity.Current;

        client.Dispose();
        socket.Dispose();
        telemetry.Close(null, false);

        Assert.Multiple(() =>
        {
            Assert.That(inner.DisposeCount, Is.EqualTo(1));
            Assert.That(_activities, Has.Count.EqualTo(3));
            Assert.That(Tag(Span(ResponseName), Prefix + "response.status"), Is.EqualTo("interrupted"));
            Assert.That(Span(SessionName).Status, Is.Not.EqualTo(ActivityStatusCode.Error));
            Assert.That(Tag(Span(SessionName), "error.type"), Is.Null);
            Assert.That(Activity.Current, Is.SameAs(caller));
        });
    }

    [Test]
    public async Task PartialFramesUseIndependentBuffersAndHonorArrayOffsetsAndMemoryOverloads()
    {
        SetContentCapture(true);
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        const string text = "caf\u00e9";
        byte[] sent = Encoding.UTF8.GetBytes("!{\"type\":\"conversation.item.create\",\"item\":{\"type\":\"message\",\"role\":\"user\"," +
            "\"content\":[{\"type\":\"input_text\",\"text\":\"" + text + "\"}]}}!");
        int split = Array.IndexOf(sent, (byte)0xC3) + 1;
        Assert.That(split, Is.GreaterThan(1), "Split within a multibyte UTF-8 character.");
        const string received = "{\"type\":\"session.created\",\"session\":{\"id\":\"session-fragmented\",\"model\":\"model-fragmented\"}}";
        int receiveSplit = received.Length / 2;
        StubWebSocket inner = new();
        inner.QueueText(received.Substring(0, receiveSplit), endOfMessage: false);
        inner.QueueText(received.Substring(receiveSplit));
        using WebSocket socket = telemetry.CreateWebSocket(inner);
        byte[] buffer = new byte[512];
        Activity caller = Activity.Current;

#if FullNetFx
        await socket.SendAsync(new ArraySegment<byte>(sent, 1, split - 1), WebSocketMessageType.Text, false, CancellationToken.None);
#else
        await socket.SendAsync(new ReadOnlyMemory<byte>(sent, 1, split - 1), WebSocketMessageType.Text, false, CancellationToken.None);
#endif
        WebSocketReceiveResult first = await socket.ReceiveAsync(new ArraySegment<byte>(buffer, 7, 400), CancellationToken.None);
#if FullNetFx
        await socket.SendAsync(new ArraySegment<byte>(sent, split, sent.Length - split - 1), WebSocketMessageType.Text, true, CancellationToken.None);
#else
        await socket.SendAsync(new ReadOnlyMemory<byte>(sent, split, sent.Length - split - 1), WebSocketMessageType.Text, true, CancellationToken.None);
#endif
        WebSocketReceiveResult last = await socket.ReceiveAsync(new ArraySegment<byte>(buffer, 7, 400), CancellationToken.None);
        Observe(telemetry, new { type = "response.created", response = new { id = "response-fragmented" } });
        Observe(telemetry, new { type = "response.done", response = new { id = "response-fragmented", status = "completed" } });
#if FullNetFx
        await socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(MessageSecret)), WebSocketMessageType.Binary, true, CancellationToken.None);
#else
        await socket.SendAsync(new ReadOnlyMemory<byte>(Encoding.UTF8.GetBytes(MessageSecret)), WebSocketMessageType.Binary, true, CancellationToken.None);
#endif
        socket.Dispose();

        using JsonDocument input = JsonDocument.Parse((string)Tag(Span(ResponseName), "gen_ai.input.messages"));
        Assert.Multiple(() =>
        {
            Assert.That(first.EndOfMessage, Is.False);
            Assert.That(last.EndOfMessage, Is.True);
            Assert.That(inner.SendCount, Is.EqualTo(3));
            Assert.That(Tag(Span(SessionName), Prefix + "session.id"), Is.EqualTo("session-fragmented"));
            Assert.That(Tag(Span(ResponseName), "gen_ai.request.model"), Is.EqualTo("model-fragmented"));
            Assert.That(input.RootElement[0].GetProperty("parts")[0].GetProperty("content").GetString(), Is.EqualTo(text));
            Assert.That(Span(SessionName).Events.Select(item => item.Name), Does.Not.Contain("voice_agents.warning"));
            Assert.That(Activity.Current, Is.SameAs(caller));
        });
        AssertPrivate(MessageSecret);
    }

    [TestCase("system", false)]
    [TestCase("system", true)]
    [TestCase("assistant", false)]
    [TestCase("assistant", true)]
    [TestCase("user", false)]
    [TestCase("user", true)]
    [TestCase("future-role", false)]
    [TestCase("future-role", true)]
    public void InputMessageSummariesPreserveSupportedRoles(string role, bool captureContent)
    {
        SetContentCapture(captureContent);
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        Observe(telemetry, new
        {
            type = "conversation.item.create",
            item = new { type = "message", role, content = new[] { new { type = "input_text", text = MessageSecret } } }
        }, isSend: true);
        Observe(telemetry, new { type = "response.created", response = new { id = "response-message-role" } });
        Observe(telemetry, new { type = "response.done", response = new { id = "response-message-role", status = "completed" } });
        telemetry.Close(WebSocketCloseStatus.NormalClosure, true);

        foreach (Activity activity in new[] { Span(SessionName), Span(ResponseName) })
        {
            using JsonDocument input = JsonDocument.Parse((string)Tag(activity, "gen_ai.input.messages"));
            JsonElement message = input.RootElement[0];
            JsonElement part = message.GetProperty("parts")[0];
            Assert.Multiple(() =>
            {
                Assert.That(message.GetProperty("role").GetString(), Is.EqualTo(role == "future-role" ? "user" : role));
                Assert.That(part.TryGetProperty("content", out _), Is.EqualTo(captureContent));
            });
            if (captureContent)
            {
                Assert.That(part.GetProperty("content").GetString(), Is.EqualTo(MessageSecret));
            }
        }
        AssertLogPrivate(MessageSecret);
        if (!captureContent)
        {
            AssertPrivate(MessageSecret);
        }
    }

    [Test]
    public void OversizedFragmentedMessageIsDiscardedUntilItsEndAndNextMessageIsObserved()
    {
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        byte[] oversized = new byte[1024 * 1024 + 1];

        telemetry.ObserveFrame(new ArraySegment<byte>(oversized, 0, oversized.Length - 1), false, false);
        telemetry.ObserveFrame(new ArraySegment<byte>(oversized, oversized.Length - 1, 1), false, false);
        Assert.That(_logs.Count(message => message.Contains("voice_agents.warning")), Is.EqualTo(1),
            "The size bound must be enforced before the unfinished message can be parsed.");
        Observe(telemetry, new { type = "session.created", session = new { id = "discarded-session" } });
        Observe(telemetry, new { type = "session.created", session = new { id = "accepted-session" } });
        telemetry.Close(WebSocketCloseStatus.NormalClosure, true);

        Assert.Multiple(() =>
        {
            Assert.That(Tag(Span(SessionName), Prefix + "session.id"), Is.EqualTo("accepted-session"));
            Assert.That(Span(SessionName).Events.Count(item => item.Name == "voice_agents.warning"), Is.EqualTo(1));
            Assert.That(Span(SessionName).Events.Count(item => item.Name == "voice_agents.session.created"), Is.EqualTo(1));
            Assert.That(Span(SessionName).Status, Is.Not.EqualTo(ActivityStatusCode.Error));
        });
    }

    [Test]
    public void ResponseAndEventTrackingAreBoundedReuseCompletedSlotsAndCleanUpOnClose()
    {
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        for (int i = 0; i < 70; i++)
        {
            Observe(telemetry, new { type = "response.created", response = new { id = $"response-{i}" } });
        }
        Observe(telemetry, new { type = "response.created", response = new { id = "response-0" } });
        for (int i = 0; i < 150; i++)
        {
            Observe(telemetry, new
            {
                type = "response.function_call_arguments.done",
                response_id = "response-0",
                call_id = $"call-bound-{i}",
                name = MessageSecret,
                arguments = MetadataSecret
            });
            Observe(telemetry, new { type = "response.cancel" }, isSend: true);
        }
        Observe(telemetry, new { type = "response.done", response = new { id = "response-0", status = "completed" } });
        Observe(telemetry, new { type = "response.created", response = new { id = "response-reused-slot" } });
        telemetry.Close(WebSocketCloseStatus.NormalClosure, true);
        int stoppedCount = _activities.Count;
        telemetry.Close(WebSocketCloseStatus.InternalServerError, false);
        Observe(telemetry, new { type = "response.created", response = new { id = "response-after-close" } });
        telemetry.TransportFailed(new WebSocketException(ExceptionSecret), false);

        Activity[] responses = _activities.Where(activity => activity.OperationName == ResponseName).ToArray();
        Assert.Multiple(() =>
        {
            Assert.That(responses, Has.Length.EqualTo(65));
            Assert.That(responses.Select(activity => Tag(activity, "gen_ai.response.id")).Distinct().Count(), Is.EqualTo(responses.Length));
            Assert.That(responses.Count(activity => Equals(Tag(activity, Prefix + "response.status"), "interrupted")), Is.EqualTo(64));
            Assert.That(responses.Select(activity => Tag(activity, "gen_ai.response.id")), Does.Contain("response-reused-slot"));
            Assert.That(Tag(Span(SessionName), Prefix + "responses.untracked"), Is.EqualTo(6));
            Assert.That(Tag(Span(SessionName), Prefix + "responses.finished"), Is.EqualTo(1));
            Assert.That(responses.Sum(activity => activity.Events.Count()) + Span(SessionName).Events.Count(), Is.EqualTo(256));
            Assert.That(responses.Sum(activity => activity.Events.Count()), Is.GreaterThan(0));
            Assert.That(Span(SessionName).Events.Count(), Is.GreaterThan(0));
            Assert.That(Tag(Span(SessionName), Prefix + "events.untracked"), Is.EqualTo(44));
            Assert.That(Span(SessionName).Status, Is.Not.EqualTo(ActivityStatusCode.Error));
            Assert.That(_activities.Count, Is.EqualTo(stoppedCount));
        });
        AssertPrivate(ExceptionSecret, MessageSecret, MetadataSecret);
    }

    [TestCase(false, false)]
    [TestCase(false, true)]
    [TestCase(true, false)]
    [TestCase(true, true)]
    public void FirstTextLatencyUsesOnlyTheFirstNonemptyDelta(bool captureContent, bool legacy)
    {
        SetContentCapture(captureContent);
        Activity response = null;
        _listener.ActivityStarted = activity =>
        {
            if (activity.OperationName == ResponseName)
            {
                response = activity;
            }
        };
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        string type = legacy ? "response.text.delta" : "response.output_text.delta";
        Observe(telemetry, new { type = "response.created", response = new { id = "text-latency" } });
        Observe(telemetry, new { type, response_id = "text-latency", delta = "" });
        Observe(telemetry, new { type, response_id = "unknown", delta = MessageSecret });
        Assert.That(Tag(response, Prefix + "response.time_to_first_text_seconds"), Is.Null);

        Observe(telemetry, new { type, response_id = "text-latency", delta = MessageSecret });
        object first = Tag(response, Prefix + "response.time_to_first_text_seconds");
        Observe(telemetry, new { type = legacy ? "response.output_text.delta" : "response.text.delta", response_id = "text-latency", delta = MetadataSecret });
        Observe(telemetry, new { type = "response.done", response = new { id = "text-latency", status = "completed" } });
        telemetry.Close(WebSocketCloseStatus.NormalClosure, true);

        Assert.That(first, Is.GreaterThanOrEqualTo(0d));
        Assert.That(Tag(response, Prefix + "response.time_to_first_text_seconds"), Is.EqualTo(first));
        AssertPrivate(MessageSecret, MetadataSecret);
    }

    [Test]
    public void SessionInstructionsUseBoundedInstructionParts()
    {
        SetContentCapture(true);
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        Observe(telemetry, new { type = "session.update", session = new { instructions = new string('x', 5000) } }, isSend: true);
        telemetry.Close(WebSocketCloseStatus.NormalClosure, true);

        using JsonDocument instructions = JsonDocument.Parse((string)Tag(Span(SessionName), "gen_ai.system_instructions"));
        JsonElement part = instructions.RootElement[0];
        Assert.That(part.GetProperty("type").GetString(), Is.EqualTo("text"));
        Assert.That(part.GetProperty("content").GetString(), Has.Length.EqualTo(4096));
        Assert.That(part.TryGetProperty("role", out _), Is.False);
        Assert.That(part.TryGetProperty("parts", out _), Is.False);
        AssertLogPrivate(new string('x', 100));
    }

    [TestCase(false)]
    [TestCase(true)]
    public void SessionAudioMetadataUsesSafeReportedFormatsAndPreservesPartialUpdates(bool legacy)
    {
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        ObserveJson(telemetry, legacy
            ? """{"type":"session.created","session":{"input_audio_format":"pcm16","input_audio_sample_rate":24000,"output_audio_format":"g711_ulaw","output_audio_sample_rate":8000}}"""
            : """{"type":"session.created","session":{"audio":{"input":{"format":{"type":"audio/pcm","rate":24000}},"output":{"format":{"type":"audio/pcmu","rate":8000}}}}}""");
        ObserveJson(telemetry, """{"type":"session.updated","session":{"audio":{"output":{"format":{"type":"audio/pcma","rate":8000}}}}}""");
        telemetry.Close(WebSocketCloseStatus.NormalClosure, true);

        Activity session = Span(SessionName);
        Assert.Multiple(() =>
        {
            Assert.That(Tag(session, Prefix + "input.audio.format"), Is.EqualTo("audio/pcm"));
            Assert.That(Tag(session, Prefix + "input.audio.sample_rate"), Is.EqualTo(24000));
            Assert.That(Tag(session, Prefix + "output.audio.format"), Is.EqualTo("audio/pcma"));
            Assert.That(Tag(session, Prefix + "output.audio.sample_rate"), Is.EqualTo(8000));
            Assert.That(session.Events.Select(item => item.Name),
                Does.Contain("voice_agents.session.created").And.Contain("voice_agents.session.updated"));
        });
    }

    [Test]
    public void InvalidAudioMetadataDoesNotLeakOrRetainStaleRates()
    {
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        ObserveJson(telemetry, """{"type":"session.created","session":{"audio":{"input":{"format":{"type":"audio/pcm","rate":24000}},"output":{"format":{"type":"audio/pcm","rate":24000}}}}}""");
        Observe(telemetry, new
        {
            type = "session.updated",
            session = new
            {
                audio = new
                {
                    input = new { format = new { type = MetadataSecret, rate = 15555550101L } },
                    output = new { format = new { type = "audio/pcmu" } }
                }
            }
        });
        ObserveJson(telemetry, """{"type":"session.updated","session":null}""");
        telemetry.Close(WebSocketCloseStatus.NormalClosure, true);

        Assert.Multiple(() =>
        {
            Assert.That(Tag(Span(SessionName), Prefix + "input.audio.format"), Is.Null);
            Assert.That(Tag(Span(SessionName), Prefix + "input.audio.sample_rate"), Is.Null);
            Assert.That(Tag(Span(SessionName), Prefix + "output.audio.format"), Is.EqualTo("audio/pcmu"));
            Assert.That(Tag(Span(SessionName), Prefix + "output.audio.sample_rate"), Is.Null);
        });
        AssertPrivate(MetadataSecret, "15555550101");
    }

    [Test]
    public void SessionOutputAudioCountsCompletedInterruptedAndUntrackedResponses()
    {
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        string audio = Convert.ToBase64String(new byte[] { 140, 151, 22, 33 });
        Observe(telemetry, new { type = "response.created", response = new { id = "audio-completed" } });
        Observe(telemetry, new { type = "response.output_audio.delta", response_id = "audio-completed", delta = audio });
        Observe(telemetry, new { type = "response.done", response = new { id = "audio-completed", status = "completed" } });
        Observe(telemetry, new { type = "response.output_audio.delta", response_id = "untracked", delta = audio });
        Observe(telemetry, new { type = "response.created", response = new { id = "audio-interrupted" } });
        Observe(telemetry, new { type = "response.audio.delta", response_id = "audio-interrupted", delta = audio });
        telemetry.Close(WebSocketCloseStatus.NormalClosure, true);

        Assert.That(Tag(Span(SessionName), Prefix + "output.audio.bytes"), Is.EqualTo(12L));
        Assert.That(_activities.Where(item => item.OperationName == ResponseName)
            .Select(item => Tag(item, Prefix + "output.audio.bytes")), Is.EquivalentTo(new[] { 4L, 4L }));
        AssertPrivate(audio);
    }

    [TestCase(false)]
    [TestCase(true)]
    public void AudioTranscriptsFollowCommitOrderNotCompletionOrder(bool captureContent)
    {
        SetContentCapture(captureContent);
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        string audio = Convert.ToBase64String(new byte[] { 140, 151, 22, 33 });
        foreach (int _ in new[] { 1, 2 })
        {
            Observe(telemetry, new { type = "input_audio_buffer.append", audio }, isSend: true);
            Observe(telemetry, new { type = "input_audio_buffer.commit" }, isSend: true);
        }
        Observe(telemetry, new { type = "input_audio_buffer.committed", item_id = "first-audio" });
        Observe(telemetry, new { type = "input_audio_buffer.committed", item_id = "second-audio" });
        Observe(telemetry, new { type = "response.created", response = new { id = "second-audio-response" } });
        Observe(telemetry, new { type = "conversation.item.input_audio_transcription.completed", item_id = "second-audio", transcript = MessageSecret });
        Observe(telemetry, new { type = "conversation.item.input_audio_transcription.completed", item_id = "first-audio", transcript = MetadataSecret });
        Observe(telemetry, new { type = "response.done", response = new { id = "second-audio-response", status = "completed" } });
        telemetry.Close(WebSocketCloseStatus.NormalClosure, true);

        foreach (Activity activity in new[] { Span(SessionName), Span(ResponseName) })
        {
            using JsonDocument input = JsonDocument.Parse((string)Tag(activity, "gen_ai.input.messages"));
            JsonElement part = input.RootElement[0].GetProperty("parts")[0];
            Assert.That(part.GetProperty("type").GetString(), Is.EqualTo("audio"));
            Assert.That(part.TryGetProperty("content", out _), Is.EqualTo(captureContent));
            if (captureContent)
            {
                Assert.That(part.GetProperty("content").GetString(), Is.EqualTo(MessageSecret));
            }
        }
        AssertPrivate(audio, MetadataSecret);
        AssertLogPrivate(MessageSecret);
        if (!captureContent)
        {
            AssertPrivate(MessageSecret);
        }
    }

    [TestCase(false)]
    [TestCase(true)]
    public void LateTranscriptionCannotReplaceNewerTextOrToolInput(bool tool)
    {
        SetContentCapture(true);
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        Observe(telemetry, new { type = "input_audio_buffer.append", audio = "AQID" }, isSend: true);
        Observe(telemetry, new { type = "input_audio_buffer.commit" }, isSend: true);
        Observe(telemetry, new { type = "input_audio_buffer.committed", item_id = "older-audio" });
        if (tool)
        {
            Observe(telemetry, new { type = "conversation.item.create", item = new { type = "function_call_output", call_id = "tool-call", output = MessageSecret } }, isSend: true);
        }
        else
        {
            Observe(telemetry, new { type = "conversation.item.create", item = new { type = "message", role = "user", content = new[] { new { type = "input_text", text = MessageSecret } } } }, isSend: true);
        }
        Observe(telemetry, new { type = "response.created", response = new { id = "newer-response" } });
        Observe(telemetry, new { type = "conversation.item.input_audio_transcription.completed", item_id = "older-audio", transcript = MetadataSecret });
        Observe(telemetry, new { type = "response.done", response = new { id = "newer-response", status = "completed" } });
        telemetry.Close(WebSocketCloseStatus.NormalClosure, true);

        foreach (Activity activity in new[] { Span(SessionName), Span(ResponseName) })
        {
            using JsonDocument input = JsonDocument.Parse((string)Tag(activity, "gen_ai.input.messages"));
            JsonElement message = input.RootElement[0];
            Assert.That(message.GetProperty("role").GetString(), Is.EqualTo(tool ? "tool" : "user"));
            Assert.That(message.GetProperty("parts")[0].GetProperty(tool ? "response" : "content").GetString(), Is.EqualTo(MessageSecret));
        }
        AssertPrivate(MetadataSecret, "AQID");
        AssertLogPrivate(MessageSecret);
    }

    [TestCase(false)]
    [TestCase(true)]
    public void AudioItemAcknowledgementsCorrelateTranscripts(bool explicitId)
    {
        SetContentCapture(true);
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        Observe(telemetry, new
        {
            type = "conversation.item.create",
            item = new { type = "message", role = "user", id = explicitId ? "audio-item" : null, content = new[] { new { type = "input_audio", audio = "AQID" } } }
        }, isSend: true);
        Observe(telemetry, new { type = "conversation.item.added", item = new { id = "audio-item", role = "user", content = new[] { new { type = "input_audio" } } } });
        Observe(telemetry, new { type = "conversation.item.input_audio_transcription.completed", item_id = "audio-item", transcript = MessageSecret });
        telemetry.Close(WebSocketCloseStatus.NormalClosure, true);

        using JsonDocument input = JsonDocument.Parse((string)Tag(Span(SessionName), "gen_ai.input.messages"));
        Assert.That(input.RootElement[0].GetProperty("parts")[0].GetProperty("content").GetString(), Is.EqualTo(MessageSecret));
        AssertPrivate("AQID");
        AssertLogPrivate(MessageSecret);
    }

    [Test]
    public void UnsupportedNewInputCannotExposeAnOlderAudioTranscript()
    {
        SetContentCapture(true);
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        Observe(telemetry, new { type = "input_audio_buffer.append", audio = "AQID" }, isSend: true);
        Observe(telemetry, new { type = "input_audio_buffer.commit" }, isSend: true);
        Observe(telemetry, new { type = "input_audio_buffer.committed", item_id = "older-audio" });
        Observe(telemetry, new { type = "conversation.item.create", item = new { type = "message", role = "user", content = new[] { new { type = "future-part", content = MessageSecret } } } }, isSend: true);
        Observe(telemetry, new { type = "conversation.item.input_audio_transcription.completed", item_id = "older-audio", transcript = MetadataSecret });
        Observe(telemetry, new { type = "response.created", response = new { id = "future-input" } });
        Observe(telemetry, new { type = "response.done", response = new { id = "future-input", status = "completed" } });
        telemetry.Close(WebSocketCloseStatus.NormalClosure, true);

        Assert.That(Tag(Span(SessionName), "gen_ai.input.messages"), Is.Null);
        Assert.That(Tag(Span(ResponseName), "gen_ai.input.messages"), Is.Null);
        AssertPrivate(MessageSecret, MetadataSecret, "AQID");
    }

    [Test]
    public void VadAndClearAcknowledgementsDoNotReassignNewerAudio()
    {
        SetContentCapture(true);
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        Observe(telemetry, new { type = "input_audio_buffer.append", audio = "AQID" }, isSend: true);
        Observe(telemetry, new { type = "input_audio_buffer.speech_started", item_id = "cleared-audio" });
        Observe(telemetry, new { type = "input_audio_buffer.clear" }, isSend: true);
        Observe(telemetry, new { type = "input_audio_buffer.append", audio = "AQID" }, isSend: true);
        Observe(telemetry, new { type = "input_audio_buffer.cleared" });
        Observe(telemetry, new { type = "input_audio_buffer.speech_started", item_id = "current-audio" });
        Observe(telemetry, new { type = "input_audio_buffer.committed", item_id = "current-audio" });
        Observe(telemetry, new { type = "conversation.item.input_audio_transcription.completed", item_id = "current-audio", transcript = MessageSecret });
        Observe(telemetry, new { type = "conversation.item.input_audio_transcription.completed", item_id = "cleared-audio", transcript = MetadataSecret });
        telemetry.Close(WebSocketCloseStatus.NormalClosure, true);

        using JsonDocument input = JsonDocument.Parse((string)Tag(Span(SessionName), "gen_ai.input.messages"));
        Assert.That(input.RootElement[0].GetProperty("parts")[0].GetProperty("content").GetString(), Is.EqualTo(MessageSecret));
        AssertPrivate(MetadataSecret, "AQID");
    }

    [Test]
    public void BoundedAudioTrackingDoesNotShiftSkippedAcknowledgements()
    {
        SetContentCapture(true);
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        for (int i = 0; i < 65; i++)
        {
            Observe(telemetry, new { type = "input_audio_buffer.append", audio = "AQID" }, isSend: true);
            Observe(telemetry, new { type = "input_audio_buffer.commit" }, isSend: true);
        }
        for (int i = 0; i < 65; i++)
        {
            Observe(telemetry, new { type = "input_audio_buffer.committed", item_id = "audio-" + i });
        }
        Observe(telemetry, new { type = "input_audio_buffer.append", audio = "AQID" }, isSend: true);
        Observe(telemetry, new { type = "input_audio_buffer.commit" }, isSend: true);
        Observe(telemetry, new { type = "input_audio_buffer.committed", item_id = "latest-audio" });
        Observe(telemetry, new { type = "conversation.item.input_audio_transcription.completed", item_id = "audio-64", transcript = MetadataSecret });
        Observe(telemetry, new { type = "conversation.item.input_audio_transcription.completed", item_id = "latest-audio", transcript = new string('x', 5000) });
        telemetry.Close(WebSocketCloseStatus.NormalClosure, true);

        using JsonDocument input = JsonDocument.Parse((string)Tag(Span(SessionName), "gen_ai.input.messages"));
        Assert.That(input.RootElement[0].GetProperty("parts")[0].GetProperty("content").GetString(), Has.Length.EqualTo(4096));
        Assert.That(Tag(Span(SessionName), Prefix + "input.items.untracked"), Is.EqualTo(1L));
        AssertPrivate(MetadataSecret, "AQID");
    }

    [TestCase("[]")]
    [TestCase("""[{"type":"function_call","call_id":"bounded-call"}]""")]
    public void ToolMessageDetailsAreBoundedAndSurviveCompactedFinalOutput(string finalOutput)
    {
        SetContentCapture(true);
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        Observe(telemetry, new { type = "response.created", response = new { id = "bounded-tool" } });
        Observe(telemetry, new
        {
            type = "response.function_call_arguments.done",
            response_id = "bounded-tool",
            call_id = "bounded-call",
            name = new string('n', 5000),
            arguments = new string('a', 5000)
        });
        ObserveJson(telemetry, "{\"type\":\"response.done\",\"response\":{\"id\":\"bounded-tool\",\"status\":\"completed\",\"output\":" + finalOutput + "}}");
        telemetry.Close(WebSocketCloseStatus.NormalClosure, true);

        using JsonDocument output = JsonDocument.Parse((string)Tag(Span(ResponseName), "gen_ai.output.messages"));
        Assert.That(output.RootElement.GetArrayLength(), Is.EqualTo(1));
        JsonElement part = output.RootElement[0].GetProperty("parts")[0];
        Assert.That(part.GetProperty("name").GetString(), Has.Length.EqualTo(4096));
        Assert.That(part.GetProperty("arguments").GetString(), Has.Length.EqualTo(4096));
        Assert.That(part.GetProperty("id").GetString(), Is.EqualTo("bounded-call"));
    }

    [TestCase(false)]
    [TestCase(true)]
    public void CompletedResponseRecordsDecodedAudioBytesUsageAndOptInContentWithoutRawAudio(bool captureContent)
    {
        SetContentCapture(captureContent);
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        string appendedAudio = Convert.ToBase64String(new byte[] { 1, 2, 3, 4, 5 });
        string itemAudio = Convert.ToBase64String(new byte[] { 6, 7, 8, 9 });
        string firstOutputAudio = Convert.ToBase64String(new byte[] { 10, 11 });
        string lastOutputAudio = Convert.ToBase64String(new byte[] { 12, 13, 14, 15, 16 });
        Observe(telemetry, new
        {
            type = "session.created",
            session = new { id = "session-audio", model = "request-model", conversation_id = "conversation-audio" }
        });
        Observe(telemetry, new { type = "session.update", session = new { instructions = MessageSecret } }, isSend: true);
        Observe(telemetry, new { type = "input_audio_buffer.append", audio = appendedAudio }, isSend: true);
        Observe(telemetry, new
        {
            type = "conversation.item.create",
            item = new { type = "message", role = "user", content = new[] { new { type = "input_audio", audio = itemAudio } } }
        }, isSend: true);
        Observe(telemetry, new { type = "response.created", response = new { id = "response-audio" } });
        Observe(telemetry, new { type = "response.audio.delta", response_id = "response-audio", delta = firstOutputAudio });
        Observe(telemetry, new { type = "response.output_audio.delta", response_id = "response-audio", delta = lastOutputAudio });
        Observe(telemetry, new
        {
            type = "response.done",
            response = new
            {
                id = "response-audio",
                status = "completed",
                model = "response-model",
                conversation_id = "conversation-audio",
                output_modalities = new[] { "audio", "text", "audio", MetadataSecret },
                usage = new { input_tokens = 11, output_tokens = 7 },
                metadata = new { private_value = MetadataSecret, values = new[] { MetadataSecret } },
                output = new[]
                {
                    new
                    {
                        type = "message",
                        content = new object[]
                        {
                            new { type = "output_audio", audio = lastOutputAudio, transcript = MessageSecret },
                            new { type = "output_text", text = MessageSecret }
                        }
                    }
                }
            }
        });
        telemetry.Close(WebSocketCloseStatus.NormalClosure, true);

        Activity session = Span(SessionName);
        Activity response = Span(ResponseName);
        using JsonDocument input = JsonDocument.Parse((string)Tag(response, "gen_ai.input.messages"));
        using JsonDocument output = JsonDocument.Parse((string)Tag(response, "gen_ai.output.messages"));
        JsonElement audioPart = output.RootElement.EnumerateArray()
            .Select(item => item.GetProperty("parts")[0]).Single(part => part.GetProperty("type").GetString() == "audio");
        JsonElement textPart = output.RootElement.EnumerateArray()
            .Select(item => item.GetProperty("parts")[0]).Single(part => part.GetProperty("type").GetString() == "text");
        Assert.Multiple(() =>
        {
            Assert.That(response.Status, Is.EqualTo(ActivityStatusCode.Ok));
            Assert.That(Tag(session, Prefix + "input.audio.bytes"), Is.EqualTo(9L));
            Assert.That(Tag(response, Prefix + "output.audio.bytes"), Is.EqualTo(7L));
            Assert.That(Tag(session, Prefix + "output.audio.bytes"), Is.EqualTo(7L));
            Assert.That(Tag(response, Prefix + "response.time_to_first_audio_seconds"), Is.GreaterThanOrEqualTo(0d));
            Assert.That(Tag(response, "gen_ai.usage.input_tokens"), Is.EqualTo(11L));
            Assert.That(Tag(response, "gen_ai.usage.output_tokens"), Is.EqualTo(7L));
            Assert.That(Tag(response, "gen_ai.request.model"), Is.EqualTo("request-model"));
            Assert.That(Tag(response, "gen_ai.response.model"), Is.EqualTo("response-model"));
            Assert.That(Tag(response, "gen_ai.conversation.id"), Is.EqualTo("conversation-audio"));
            Assert.That(Tag(response, Prefix + "response.output_modalities"), Is.EquivalentTo(new[] { "audio", "text" }));
            Assert.That(input.RootElement[0].GetProperty("parts")[0].GetProperty("type").GetString(), Is.EqualTo("audio"));
            Assert.That(output.RootElement.GetArrayLength(), Is.EqualTo(2));
            Assert.That(output.RootElement.EnumerateArray().All(item => item.GetProperty("role").GetString() == "assistant"), Is.True);
            Assert.That(audioPart.TryGetProperty("audio", out _), Is.False);
            Assert.That(audioPart.TryGetProperty("content", out _), Is.EqualTo(captureContent));
            Assert.That(textPart.TryGetProperty("content", out _), Is.EqualTo(captureContent));
            Assert.That(Tag(session, "gen_ai.system_instructions") != null, Is.EqualTo(captureContent));
        });
        AssertPrivate(appendedAudio, itemAudio, firstOutputAudio, lastOutputAudio, MetadataSecret);
        AssertLogPrivate(MessageSecret);
        if (!captureContent)
        {
            AssertPrivate(MessageSecret);
        }
        else
        {
            Assert.That(audioPart.GetProperty("content").GetString(), Is.EqualTo(MessageSecret));
            Assert.That(textPart.GetProperty("content").GetString(), Is.EqualTo(MessageSecret));
        }
    }

    [TestCase(false)]
    [TestCase(true)]
    public void ToolAndCancelMilestonesCaptureOnlyOptedInContent(bool captureContent)
    {
        SetContentCapture(captureContent);
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        const string toolName = "private-tool-name";
        const string arguments = "{\"value\":\"private-tool-arguments\"}";
        const string toolOutput = "private-tool-output";
        Observe(telemetry, new
        {
            type = "conversation.item.create",
            item = new { type = "message", role = "user", content = new[] { new { type = "input_text", text = MessageSecret } } }
        }, isSend: true);
        Observe(telemetry, new { type = "response.created", response = new { id = "response-tool" } });
        Observe(telemetry, new
        {
            type = "response.function_call_arguments.done",
            response_id = "response-tool",
            call_id = "call-1",
            name = toolName,
            arguments
        });
        Observe(telemetry, new
        {
            type = "conversation.item.create",
            item = new { type = "function_call_output", call_id = "call-1", output = toolOutput }
        }, isSend: true);
        Observe(telemetry, new { type = "response.cancel" }, isSend: true);
        Observe(telemetry, new
        {
            type = "response.done",
            response = new
            {
                id = "response-tool",
                status = "cancelled",
                output = new[] { new { type = "function_call", call_id = "call-1", name = toolName, arguments } }
            }
        });
        Observe(telemetry, new { type = "response.created", response = new { id = "response-tool-output" } });
        Observe(telemetry, new { type = "response.done", response = new { id = "response-tool-output", status = "completed" } });
        telemetry.Close(WebSocketCloseStatus.NormalClosure, true);

        Activity response = _activities.Single(activity => Equals(Tag(activity, "gen_ai.response.id"), "response-tool"));
        Activity nextResponse = _activities.Single(activity => Equals(Tag(activity, "gen_ai.response.id"), "response-tool-output"));
        ActivityEvent requested = response.Events.Single(item => item.Name == "voice_agents.tool.requested");
        ActivityEvent outputSent = Span(SessionName).Events.Single(item => item.Name == "voice_agents.tool.output_sent");
        using JsonDocument userInput = JsonDocument.Parse((string)Tag(response, "gen_ai.input.messages"));
        using JsonDocument toolCall = JsonDocument.Parse((string)Tag(response, "gen_ai.output.messages"));
        using JsonDocument input = JsonDocument.Parse((string)Tag(nextResponse, "gen_ai.input.messages"));
        JsonElement toolCallPart = toolCall.RootElement[0].GetProperty("parts")[0];
        JsonElement toolPart = input.RootElement[0].GetProperty("parts")[0];
        Assert.Multiple(() =>
        {
            Assert.That(EventTag(requested, "gen_ai.tool.call.id"), Is.EqualTo("call-1"));
            Assert.That(EventTag(requested, Prefix + "tool.kind"), Is.EqualTo("function"));
            Assert.That(EventTag(requested, "gen_ai.tool.name"), Is.EqualTo(captureContent ? toolName : null));
            Assert.That(EventTag(requested, Prefix + "tool.arguments"), Is.EqualTo(captureContent ? arguments : null));
            Assert.That(EventTag(outputSent, "gen_ai.tool.call.id"), Is.EqualTo("call-1"));
            Assert.That(Span(SessionName).Events.Select(item => item.Name), Does.Contain("voice_agents.response.cancel_requested"));
            Assert.That(Tag(response, Prefix + "response.status"), Is.EqualTo("cancelled"));
            Assert.That(response.Status, Is.Not.EqualTo(ActivityStatusCode.Error));
            Assert.That(userInput.RootElement[0].GetProperty("parts")[0].TryGetProperty("content", out _), Is.EqualTo(captureContent));
            Assert.That(toolCall.RootElement[0].GetProperty("role").GetString(), Is.EqualTo("assistant"));
            Assert.That(toolCallPart.GetProperty("type").GetString(), Is.EqualTo("tool_call"));
            Assert.That(toolCallPart.GetProperty("id").GetString(), Is.EqualTo("call-1"));
            Assert.That(toolCallPart.EnumerateObject().Select(property => property.Name),
                Is.EquivalentTo(captureContent ? new[] { "type", "id", "name", "arguments" } : new[] { "type", "id" }));
            Assert.That(input.RootElement[0].GetProperty("role").GetString(), Is.EqualTo("tool"));
            Assert.That(toolPart.GetProperty("type").GetString(), Is.EqualTo("tool_call_response"));
            Assert.That(toolPart.GetProperty("id").GetString(), Is.EqualTo("call-1"));
            Assert.That(toolPart.TryGetProperty("response", out _), Is.EqualTo(captureContent));
        });
        AssertLogPrivate(toolName, "private-tool-arguments", toolOutput, MessageSecret);
        if (!captureContent)
        {
            AssertPrivate(toolName, "private-tool-arguments", toolOutput, MessageSecret);
        }
        else
        {
            Assert.That(userInput.RootElement[0].GetProperty("parts")[0].GetProperty("content").GetString(), Is.EqualTo(MessageSecret));
            Assert.That(toolPart.GetProperty("response").GetString(), Is.EqualTo(toolOutput));
            Assert.That(toolCallPart.GetProperty("name").GetString(), Is.EqualTo(toolName));
            Assert.That(toolCallPart.GetProperty("arguments").GetString(), Is.EqualTo(arguments));
        }
    }

    [TestCase("failed", ActivityStatusCode.Error)]
    [TestCase("cancelled", ActivityStatusCode.Unset)]
    public void FailedAndCancelledResponsesDoNotExposeStatusDetailsOrFailSession(string status, ActivityStatusCode expectedStatus)
    {
        SetContentCapture(true);
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        Observe(telemetry, new { type = "response.created", response = new { id = "response-terminal" } });
        Observe(telemetry, new
        {
            type = "response.done",
            response = new
            {
                id = "response-terminal",
                status,
                status_details = new { reason = MessageSecret, error = new { type = MetadataSecret, message = ExceptionSecret } }
            }
        });
        telemetry.Close(WebSocketCloseStatus.NormalClosure, true);

        Assert.Multiple(() =>
        {
            Assert.That(Span(ResponseName).Status, Is.EqualTo(expectedStatus));
            Assert.That(Tag(Span(ResponseName), Prefix + "response.status"), Is.EqualTo(status));
            Assert.That(Tag(Span(ResponseName), "error.type"), Is.EqualTo(status == "failed" ? "response_failed" : null));
            Assert.That(Span(ResponseName).StatusDescription, Is.Null.Or.Empty);
            Assert.That(Span(SessionName).Status, Is.Not.EqualTo(ActivityStatusCode.Error));
            Assert.That(Tag(Span(SessionName), Prefix + "responses.finished"), Is.EqualTo(1));
        });
        AssertPrivate(MessageSecret, MetadataSecret, ExceptionSecret);
    }

    [Test]
    public void RecoverableServerErrorsDoNotFailOrEndSessionAndExposeOnlySafeCodes()
    {
        SetContentCapture(true);
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        Observe(telemetry, new { type = "error", error = new { code = "invalid_event", message = ExceptionSecret, param = MetadataSecret } });
        Observe(telemetry, new { type = "rtc.call.error", error = new { code = MetadataSecret, message = ExceptionSecret } });
        Assert.That(_activities.Any(activity => activity.OperationName == SessionName), Is.False);
        Observe(telemetry, new { type = "response.created", response = new { id = "response-after-error" } });
        Observe(telemetry, new { type = "response.done", response = new { id = "response-after-error", status = "completed" } });
        telemetry.Close(WebSocketCloseStatus.NormalClosure, true);

        Activity session = Span(SessionName);
        ActivityEvent serverError = session.Events.Single(item => item.Name == "voice_agents.server_error");
        ActivityEvent rtcError = session.Events.Single(item => item.Name == "rtc.call.error");
        Assert.Multiple(() =>
        {
            Assert.That(session.Status, Is.Not.EqualTo(ActivityStatusCode.Error));
            Assert.That(Tag(session, "error.type"), Is.Null);
            Assert.That(Span(ResponseName).Status, Is.EqualTo(ActivityStatusCode.Ok));
            Assert.That(EventTag(serverError, "error.type"), Is.EqualTo("service_error"));
            Assert.That(EventTag(serverError, Prefix + "error.code"), Is.EqualTo("invalid_event"));
            Assert.That(EventTag(rtcError, "error.type"), Is.EqualTo("service_error"));
            Assert.That(EventTag(rtcError, Prefix + "error.code"), Is.Null);
        });
        AssertPrivate(ExceptionSecret, MetadataSecret);
    }

    [TestCase(false)]
    [TestCase(true)]
    public void FailedConnectStopsBothSpansWithoutExposingExceptionMessages(bool cancelled)
    {
        using Activity caller = new Activity("caller").SetIdFormat(ActivityIdFormat.W3C).Start();
        RealtimeTelemetry telemetry = StartTelemetry();
        Exception failure = cancelled
            ? new OperationCanceledException(ExceptionSecret)
            : new ClientResultException(new MockPipelineResponse(401).WithContent(ExceptionSecret));

        telemetry.ConnectionFailed(failure);

        Activity session = Span(SessionName);
        Activity connect = Span(ConnectName);
        Assert.Multiple(() =>
        {
            Assert.That(_activities, Has.Count.EqualTo(2));
            foreach (Activity activity in _activities)
            {
                Assert.That(activity.Status, Is.EqualTo(cancelled ? ActivityStatusCode.Unset : ActivityStatusCode.Error));
                Assert.That(Tag(activity, "error.type"), Is.EqualTo(cancelled ? null : nameof(ClientResultException)));
                Assert.That(Tag(activity, Prefix + "cancelled"), Is.EqualTo(cancelled ? true : null));
                Assert.That(Tag(activity, "http.response.status_code"), Is.EqualTo(cancelled ? null : 401));
                Assert.That(activity.StatusDescription, Is.Null.Or.Empty);
            }
            Assert.That(Tag(session, Prefix + "connected"), Is.False);
            Assert.That(connect.ParentSpanId, Is.EqualTo(session.SpanId));
            Assert.That(session.ParentSpanId, Is.EqualTo(caller.SpanId));
            Assert.That(session.Events.Select(item => item.Name), Does.Contain("voice_agents.connection.failed"));
            Assert.That(Activity.Current, Is.SameAs(caller));
        });
        AssertPrivate(ExceptionSecret);
    }

    [Test]
    public async Task ReceiveCancellationIsRethrownWithoutEndingOpenSession()
    {
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        using CancellationTokenSource cancellation = new();
        cancellation.Cancel();
        OperationCanceledException failure = new(ExceptionSecret, cancellation.Token);
        StubWebSocket inner = new() { ReceiveFailure = failure };
        using WebSocket socket = telemetry.CreateWebSocket(inner);
        ArraySegment<byte> buffer = new(new byte[512]);
        Activity caller = Activity.Current;

        OperationCanceledException actual = Assert.ThrowsAsync<OperationCanceledException>(
            async () => await socket.ReceiveAsync(buffer, cancellation.Token));
        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.SameAs(failure));
            Assert.That(inner.State, Is.EqualTo(WebSocketState.Open));
            Assert.That(_activities.Any(activity => activity.OperationName == SessionName), Is.False);
            Assert.That(Activity.Current, Is.SameAs(caller));
        });
        inner.ReceiveFailure = null;
        inner.QueueText("{\"type\":\"response.created\",\"response\":{\"id\":\"response-after-cancel\"}}");
        inner.QueueText("{\"type\":\"response.done\",\"response\":{\"id\":\"response-after-cancel\",\"status\":\"completed\"}}");
        await socket.ReceiveAsync(buffer, CancellationToken.None);
        await socket.ReceiveAsync(buffer, CancellationToken.None);
        socket.Dispose();

        Assert.Multiple(() =>
        {
            Assert.That(Span(SessionName).Status, Is.Not.EqualTo(ActivityStatusCode.Error));
            Assert.That(Span(SessionName).Events.Select(item => item.Name), Does.Contain("voice_agents.receive.cancelled"));
            Assert.That(Span(SessionName).Events.Select(item => item.Name), Does.Not.Contain("voice_agents.receive.failed"));
            Assert.That(Span(ResponseName).Status, Is.EqualTo(ActivityStatusCode.Ok));
            Assert.That(Activity.Current, Is.SameAs(caller));
        });
        AssertPrivate(ExceptionSecret);
    }

    [TestCase(false, false, WebSocketState.Aborted)]
    [TestCase(false, false, WebSocketState.Closed)]
    [TestCase(false, true, WebSocketState.Aborted)]
    [TestCase(false, true, WebSocketState.Closed)]
    [TestCase(true, false, WebSocketState.Aborted)]
    [TestCase(true, false, WebSocketState.Closed)]
    [TestCase(true, true, WebSocketState.Aborted)]
    [TestCase(true, true, WebSocketState.Closed)]
    public async Task TerminalTransportFailuresEndActivitiesBeforeDisposal(bool isSend, bool cancelled, WebSocketState state)
    {
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        Observe(telemetry, new { type = "response.created", response = new { id = "response-terminal-transport" } });
        Exception failure = cancelled ? new OperationCanceledException(ExceptionSecret) : new WebSocketException(ExceptionSecret);
        StubWebSocket inner = new()
        {
            StateAfterFailure = state,
            SendFailure = isSend ? failure : null,
            ReceiveFailure = isSend ? null : failure
        };
        using WebSocket socket = telemetry.CreateWebSocket(inner);
        Activity caller = Activity.Current;

        async Task ExchangeAsync()
        {
            if (isSend)
            {
                await socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes("{\"type\":\"response.cancel\"}")),
                    WebSocketMessageType.Text, true, CancellationToken.None);
            }
            else
            {
                await socket.ReceiveAsync(new ArraySegment<byte>(new byte[512]), CancellationToken.None);
            }
        }
        Exception actual = cancelled
            ? Assert.ThrowsAsync<OperationCanceledException>(ExchangeAsync)
            : Assert.ThrowsAsync<WebSocketException>(ExchangeAsync);

        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.SameAs(failure));
            Assert.That(inner.State, Is.EqualTo(state));
            Assert.That(inner.DisposeCount, Is.EqualTo(0), "Terminal socket failure must end telemetry without waiting for caller disposal.");
            Assert.That(_activities, Has.Count.EqualTo(3));
            Assert.That(Span(SessionName).Status, Is.EqualTo(cancelled ? ActivityStatusCode.Unset : ActivityStatusCode.Error));
            Assert.That(Tag(Span(SessionName), "error.type"), Is.EqualTo(cancelled ? null : nameof(WebSocketException)));
            Assert.That(Tag(Span(ResponseName), Prefix + "response.status"), Is.EqualTo("interrupted"));
            Assert.That(Span(ResponseName).Duration, Is.GreaterThan(TimeSpan.Zero));
            Assert.That(Activity.Current, Is.SameAs(caller));
        });
        socket.Dispose();
        Assert.That(_activities, Has.Count.EqualTo(3), "Disposal must not end a terminal session twice.");
        AssertPrivate(ExceptionSecret);
        await Task.CompletedTask;
    }

    [Test]
    public async Task SendFailureIsRethrownWithoutEndingSessionOrExposingMessage()
    {
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        WebSocketException failure = new(ExceptionSecret);
        StubWebSocket inner = new() { SendFailure = failure };
        using WebSocket socket = telemetry.CreateWebSocket(inner);
        ArraySegment<byte> frame = new(Encoding.UTF8.GetBytes("{\"type\":\"response.cancel\"}"));

        WebSocketException actual = Assert.ThrowsAsync<WebSocketException>(
            async () => await socket.SendAsync(frame, WebSocketMessageType.Text, true, CancellationToken.None));
        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.SameAs(failure));
            Assert.That(_activities.Any(activity => activity.OperationName == SessionName), Is.False);
        });
        inner.SendFailure = null;
        await socket.SendAsync(frame, WebSocketMessageType.Text, true, CancellationToken.None);
        socket.Dispose();

        ActivityEvent sendFailed = Span(SessionName).Events.Single(item => item.Name == "voice_agents.send.failed");
        Assert.Multiple(() =>
        {
            Assert.That(Span(SessionName).Status, Is.Not.EqualTo(ActivityStatusCode.Error));
            Assert.That(EventTag(sendFailed, "error.type"), Is.EqualTo(nameof(WebSocketException)));
            Assert.That(Span(SessionName).Events.Count(item => item.Name == "voice_agents.response.cancel_requested"), Is.EqualTo(1));
        });
        AssertPrivate(ExceptionSecret);
    }

    [Test]
    public void ReceiveFailureEndsSessionAndOutstandingResponseWithoutExposingMessage()
    {
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        Observe(telemetry, new { type = "response.created", response = new { id = "response-receive-failure" } });
        WebSocketException failure = new(ExceptionSecret);
        StubWebSocket inner = new() { ReceiveFailure = failure };
        using WebSocket socket = telemetry.CreateWebSocket(inner);

        WebSocketException actual = Assert.ThrowsAsync<WebSocketException>(
            async () => await socket.ReceiveAsync(new ArraySegment<byte>(new byte[512]), CancellationToken.None));
        socket.Dispose();

        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.SameAs(failure));
            Assert.That(_activities, Has.Count.EqualTo(3));
            Assert.That(Span(SessionName).Status, Is.EqualTo(ActivityStatusCode.Error));
            Assert.That(Tag(Span(SessionName), "error.type"), Is.EqualTo(nameof(WebSocketException)));
            Assert.That(Span(SessionName).StatusDescription, Is.Null.Or.Empty);
            Assert.That(Span(SessionName).Events.Select(item => item.Name), Does.Contain("voice_agents.receive.failed"));
            Assert.That(Tag(Span(ResponseName), Prefix + "response.status"), Is.EqualTo("interrupted"));
        });
        AssertPrivate(ExceptionSecret);
    }

    [TestCase(false, WebSocketCloseStatus.NormalClosure)]
    [TestCase(true, WebSocketCloseStatus.NormalClosure)]
    [TestCase(false, WebSocketCloseStatus.EndpointUnavailable)]
    [TestCase(true, WebSocketCloseStatus.EndpointUnavailable)]
    public async Task NormalPeerCloseWaitsForHandshakeCompletion(bool closeOutput, WebSocketCloseStatus closeStatus)
    {
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        Observe(telemetry, new { type = "response.created", response = new { id = "response-peer-close" } });
        StubWebSocket inner = new();
        inner.QueueClose(closeStatus, ExceptionSecret);
        using WebSocket socket = telemetry.CreateWebSocket(inner);
        Activity caller = Activity.Current;

        WebSocketReceiveResult received = await socket.ReceiveAsync(new ArraySegment<byte>(new byte[512]), CancellationToken.None);
        Assert.Multiple(() =>
        {
            Assert.That(received.CloseStatusDescription, Is.EqualTo(ExceptionSecret), "Do not change the application's close result.");
            Assert.That(inner.State, Is.EqualTo(WebSocketState.CloseReceived));
            Assert.That(_activities, Has.Count.EqualTo(1), "Only the handshake span has ended before replying to peer close.");
            Assert.That(Activity.Current, Is.SameAs(caller));
        });

        if (closeOutput)
        {
            await socket.CloseOutputAsync(closeStatus, ExceptionSecret, CancellationToken.None);
        }
        else
        {
            await socket.CloseAsync(closeStatus, ExceptionSecret, CancellationToken.None);
        }
        Assert.Multiple(() =>
        {
            Assert.That(inner.State, Is.EqualTo(WebSocketState.Closed));
            Assert.That(inner.DisposeCount, Is.EqualTo(0));
            Assert.That(_activities, Has.Count.EqualTo(3));
            Assert.That(Tag(Span(SessionName), Prefix + "close.was_clean"), Is.True);
            Assert.That(Tag(Span(SessionName), Prefix + "close.code"), Is.EqualTo((int)closeStatus));
            Assert.That(Span(SessionName).Status, Is.Not.EqualTo(ActivityStatusCode.Error));
            Assert.That(Tag(Span(ResponseName), Prefix + "response.status"), Is.EqualTo("interrupted"));
            Assert.That(Activity.Current, Is.SameAs(caller));
        });
        socket.Dispose();
        Assert.That(_activities, Has.Count.EqualTo(3));
        AssertPrivate(ExceptionSecret);
    }

    [TestCaseSource(nameof(ConcurrentSendCases))]
    public async Task ResponseInputWaitsForConcurrentSendOutcome(string inputKind, string outcome, bool finishFirst, bool captureContent)
    {
        SetContentCapture(captureContent);
        const string previousInput = "previous-input-content";
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        Observe(telemetry, new
        {
            type = "conversation.item.create",
            item = new { type = "message", role = "user", content = new[] { new { type = "input_text", text = previousInput } } }
        }, isSend: true);
        string audio = Convert.ToBase64String(new byte[] { 11, 22, 33, 44, 55 });
        string message = inputKind switch
        {
            "audio" => "{\"type\":\"input_audio_buffer.append\",\"audio\":\"" + audio + "\"}",
            "text" => "{\"type\":\"conversation.item.create\",\"item\":{\"type\":\"message\",\"role\":\"user\",\"content\":[{\"type\":\"input_text\",\"text\":\"" + MessageSecret + "\"}]}}",
            "tool" => "{\"type\":\"conversation.item.create\",\"item\":{\"type\":\"function_call_output\",\"call_id\":\"pending-call\",\"output\":\"" + MessageSecret + "\"}}",
            _ => "{\"type\":\"response.create\"}"
        };
        TaskCompletionSource<bool> completion = new(TaskCreationOptions.RunContinuationsAsynchronously);
        StubWebSocket inner = new() { SendCompletion = completion };
        inner.QueueText("{\"type\":\"response.created\",\"response\":{\"id\":\"concurrent-input\"}}");
        inner.QueueText("{\"type\":\"response.done\",\"response\":{\"id\":\"concurrent-input\",\"status\":\"completed\"}}");
        using WebSocket socket = telemetry.CreateWebSocket(inner);
        Activity response = null;
        _listener.ActivityStarted = activity =>
        {
            if (activity.OperationName == ResponseName)
            {
                response = activity;
            }
        };
        Activity caller = Activity.Current;

        Task send = socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(message)), WebSocketMessageType.Text, true, CancellationToken.None);
        Assert.That(send.IsCompleted, Is.False);
        await socket.ReceiveAsync(new ArraySegment<byte>(new byte[512]), CancellationToken.None);
        Assert.That(Tag(response, "gen_ai.input.messages"), Is.Null, "Do not publish the previous input while send success is unknown.");
        TimeSpan observedResponseDuration = default;
        if (finishFirst)
        {
            await socket.ReceiveAsync(new ArraySegment<byte>(new byte[512]), CancellationToken.None);
            observedResponseDuration = response.Duration;
            Assert.That(observedResponseDuration, Is.GreaterThan(TimeSpan.Zero));
            Assert.That(_activities.Any(activity => activity.OperationName == ResponseName), Is.False,
                "A finished response must not be exported before its pending input is resolved.");
        }
        bool succeeded = outcome == "success";
        if (succeeded)
        {
            completion.SetResult(true);
            await send;
        }
        else
        {
            Exception failure = outcome == "cancelled" ? new OperationCanceledException(ExceptionSecret) : new WebSocketException(ExceptionSecret);
            completion.SetException(failure);
            Exception actual = outcome == "cancelled"
                ? Assert.ThrowsAsync<OperationCanceledException>(async () => await send)
                : Assert.ThrowsAsync<WebSocketException>(async () => await send);
            Assert.That(actual, Is.SameAs(failure));
        }
        if (!finishFirst)
        {
            await socket.ReceiveAsync(new ArraySegment<byte>(new byte[512]), CancellationToken.None);
        }
        telemetry.Close(WebSocketCloseStatus.NormalClosure, true);

        bool newInput = succeeded && inputKind != "response";
        bool audioInput = newInput && inputKind == "audio";
        string role = newInput && inputKind == "tool" ? "tool" : "user";
        string type = audioInput ? "audio" : role == "tool" ? "tool_call_response" : "text";
        string contentKey = role == "tool" ? "response" : "content";
        Assert.Multiple(() =>
        {
            Assert.That(response.Status, Is.EqualTo(ActivityStatusCode.Ok));
            Assert.That(Tag(Span(SessionName), Prefix + "input.audio.bytes"), Is.EqualTo(audioInput ? 5L : 0L));
            Assert.That(inner.SendCount, Is.EqualTo(succeeded ? 1 : 0));
            Assert.That(response.ParentSpanId, Is.EqualTo(Span(SessionName).SpanId));
            Assert.That(_activities, Has.Count.EqualTo(3));
            Assert.That(Activity.Current, Is.SameAs(caller));
        });
        if (succeeded)
        {
            using JsonDocument input = JsonDocument.Parse((string)Tag(response, "gen_ai.input.messages"));
            JsonElement observed = input.RootElement[0];
            JsonElement part = observed.GetProperty("parts")[0];
            Assert.Multiple(() =>
            {
                Assert.That(observed.GetProperty("role").GetString(), Is.EqualTo(role));
                Assert.That(part.GetProperty("type").GetString(), Is.EqualTo(type));
                Assert.That(part.TryGetProperty(contentKey, out _), Is.EqualTo(captureContent && !audioInput));
            });
            if (captureContent && !audioInput)
            {
                Assert.That(part.GetProperty(contentKey).GetString(), Is.EqualTo(newInput ? MessageSecret : previousInput));
            }
        }
        else
        {
            Assert.That(Tag(response, "gen_ai.input.messages"), Is.Null,
                "An unconfirmed send must not silently attribute the response to an older unrelated input.");
        }
        if (finishFirst)
        {
            Assert.That(response.Duration, Is.EqualTo(observedResponseDuration),
                "Waiting for send outcome must not extend the response's measured duration.");
        }
        AssertPrivate(audio, ExceptionSecret);
        AssertLogPrivate(previousInput, MessageSecret);
        if (!captureContent)
        {
            AssertPrivate(previousInput, MessageSecret);
        }
        else if (!newInput || audioInput)
        {
            AssertPrivate(MessageSecret);
        }
    }

    private static IEnumerable<TestCaseData> ConcurrentSendCases()
    {
        foreach (string kind in new[] { "text", "audio", "tool", "response" })
        {
            foreach (string outcome in new[] { "success", "failed", "cancelled" })
            {
                foreach (bool finishFirst in new[] { false, true })
                {
                    foreach (bool capture in new[] { false, true })
                    {
                        yield return new TestCaseData(kind, outcome, finishFirst, capture);
                    }
                }
            }
        }
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task DisposalWhileSendIsPendingCompletesActivitiesWithoutRecordingUnconfirmedInput(bool responseDone)
    {
        SetContentCapture(true);
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        TaskCompletionSource<bool> completion = new(TaskCreationOptions.RunContinuationsAsynchronously);
        StubWebSocket inner = new() { SendCompletion = completion };
        inner.QueueText("{\"type\":\"response.created\",\"response\":{\"id\":\"disposed-input\"}}");
        if (responseDone)
        {
            inner.QueueText("{\"type\":\"response.done\",\"response\":{\"id\":\"disposed-input\",\"status\":\"completed\"}}");
        }
        using WebSocket socket = telemetry.CreateWebSocket(inner);

        Task send = socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(
            "{\"type\":\"conversation.item.create\",\"item\":{\"type\":\"function_call_output\",\"call_id\":\"pending-call\",\"output\":\"" + MessageSecret + "\"}}")),
            WebSocketMessageType.Text, true, CancellationToken.None);
        await socket.ReceiveAsync(new ArraySegment<byte>(new byte[512]), CancellationToken.None);
        if (responseDone)
        {
            await socket.ReceiveAsync(new ArraySegment<byte>(new byte[512]), CancellationToken.None);
        }
        socket.Dispose();
        Assert.That(_activities, Has.Count.EqualTo(3));
        Assert.That(Tag(Span(ResponseName), Prefix + "response.status"), Is.EqualTo(responseDone ? "completed" : "interrupted"));
        Assert.That(Tag(Span(ResponseName), "gen_ai.input.messages"), Is.Null);
        completion.SetResult(true);
        await send;
        Assert.That(_activities, Has.Count.EqualTo(3), "Late send completion must not mutate or re-export stopped Activities.");
        AssertPrivate(MessageSecret);
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task FragmentedInputCorrelationCommitsOnlySuccessfulFinalFrames(bool succeeded)
    {
        SetContentCapture(true);
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        StubWebSocket inner = new();
        using WebSocket socket = telemetry.CreateWebSocket(inner);
        string message = "{\"type\":\"conversation.item.create\",\"item\":{\"type\":\"message\",\"role\":\"user\",\"content\":[{\"type\":\"input_text\",\"text\":\"" + MessageSecret + "\"}]}}";
        byte[] bytes = Encoding.UTF8.GetBytes(message);
        int split = bytes.Length / 2;
        await socket.SendAsync(new ArraySegment<byte>(bytes, 0, split), WebSocketMessageType.Text, false, CancellationToken.None);
        TaskCompletionSource<bool> completion = new(TaskCreationOptions.RunContinuationsAsynchronously);
        inner.SendCompletion = completion;
        inner.QueueText("{\"type\":\"response.created\",\"response\":{\"id\":\"fragmented-race\"}}");
        inner.QueueText("{\"type\":\"response.done\",\"response\":{\"id\":\"fragmented-race\",\"status\":\"completed\"}}");

        Task send = socket.SendAsync(new ArraySegment<byte>(bytes, split, bytes.Length - split), WebSocketMessageType.Text, true, CancellationToken.None);
        await socket.ReceiveAsync(new ArraySegment<byte>(new byte[512]), CancellationToken.None);
        await socket.ReceiveAsync(new ArraySegment<byte>(new byte[512]), CancellationToken.None);
        if (succeeded)
        {
            completion.SetResult(true);
            await send;
        }
        else
        {
            completion.SetException(new WebSocketException(ExceptionSecret));
            Assert.ThrowsAsync<WebSocketException>(async () => await send);
        }
        Activity response = Span(ResponseName);
        if (succeeded)
        {
            using JsonDocument input = JsonDocument.Parse((string)Tag(response, "gen_ai.input.messages"));
            Assert.That(input.RootElement[0].GetProperty("parts")[0].GetProperty("content").GetString(), Is.EqualTo(MessageSecret));
        }
        else
        {
            Assert.That(Tag(response, "gen_ai.input.messages"), Is.Null);
            inner.SendCompletion = null;
            await socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(
                "{\"type\":\"conversation.item.create\",\"item\":{\"type\":\"message\",\"role\":\"user\",\"content\":[{\"type\":\"input_text\",\"text\":\"recovered-input\"}]}}")),
                WebSocketMessageType.Text, true, CancellationToken.None);
        }
        socket.Dispose();
        Assert.That(Span(SessionName).Events.Any(item => item.Name == "voice_agents.warning"), Is.False);
        if (!succeeded)
        {
            AssertPrivate(MessageSecret);
        }
        AssertPrivate(ExceptionSecret);
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task PendingSendRetainsVadTurnAndTranscriptOrder(bool captureContent)
    {
        SetContentCapture(captureContent);
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        TaskCompletionSource<bool> completion = new(TaskCreationOptions.RunContinuationsAsynchronously);
        StubWebSocket inner = new() { SendCompletion = completion };
        using WebSocket socket = telemetry.CreateWebSocket(inner);
        string audio = Convert.ToBase64String(new byte[] { 11, 22, 33, 44, 55 });
        for (int turn = 1; turn <= 2; turn++)
        {
            inner.QueueText("{\"type\":\"input_audio_buffer.speech_started\",\"item_id\":\"turn-" + turn + "\"}");
            inner.QueueText("{\"type\":\"input_audio_buffer.committed\",\"item_id\":\"turn-" + turn + "\"}");
            inner.QueueText("{\"type\":\"response.created\",\"response\":{\"id\":\"response-" + turn + "\"}}");
            inner.QueueText("{\"type\":\"response.done\",\"response\":{\"id\":\"response-" + turn + "\",\"status\":\"completed\"}}");
        }
        inner.QueueText("{\"type\":\"conversation.item.input_audio_transcription.completed\",\"item_id\":\"turn-2\",\"transcript\":\"" + MetadataSecret + "\"}");
        inner.QueueText("{\"type\":\"conversation.item.input_audio_transcription.completed\",\"item_id\":\"turn-1\",\"transcript\":\"" + MessageSecret + "\"}");

        Task send = socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(
            "{\"type\":\"input_audio_buffer.append\",\"audio\":\"" + audio + "\"}")), WebSocketMessageType.Text, true, CancellationToken.None);
        for (int i = 0; i < 10; i++)
        {
            await socket.ReceiveAsync(new ArraySegment<byte>(new byte[512]), CancellationToken.None);
        }
        DateTimeOffset observed = DateTimeOffset.UtcNow;
        Assert.That(_activities, Has.Count.EqualTo(1));
        completion.SetResult(true);
        await send;
        socket.Dispose();

        for (int turn = 1; turn <= 2; turn++)
        {
            Activity response = _activities.Single(activity => Equals(Tag(activity, "gen_ai.response.id"), "response-" + turn));
            using JsonDocument input = JsonDocument.Parse((string)Tag(response, "gen_ai.input.messages"));
            JsonElement part = input.RootElement[0].GetProperty("parts")[0];
            Assert.That(part.GetProperty("type").GetString(), Is.EqualTo("audio"));
            Assert.That(part.TryGetProperty("content", out _), Is.EqualTo(captureContent));
            if (captureContent)
            {
                Assert.That(part.GetProperty("content").GetString(), Is.EqualTo(turn == 1 ? MessageSecret : MetadataSecret));
            }
        }
        Activity session = Span(SessionName);
        Assert.That(Tag(session, Prefix + "input.audio.bytes"), Is.EqualTo(5L));
        Assert.That(session.Events.All(activityEvent => activityEvent.Timestamp <= observed), Is.True,
            "Deferred telemetry keeps the original event observation timestamps.");
        using JsonDocument lastInput = JsonDocument.Parse((string)Tag(session, "gen_ai.input.messages"));
        if (captureContent)
        {
            Assert.That(lastInput.RootElement[0].GetProperty("parts")[0].GetProperty("content").GetString(), Is.EqualTo(MetadataSecret));
        }
        AssertPrivate(audio);
        AssertLogPrivate(MessageSecret, MetadataSecret);
        if (!captureContent)
        {
            AssertPrivate(MessageSecret, MetadataSecret);
        }
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task PendingAudioItemAcknowledgementDoesNotLoseTranscript(bool captureContent)
    {
        SetContentCapture(captureContent);
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        TaskCompletionSource<bool> completion = new(TaskCreationOptions.RunContinuationsAsynchronously);
        StubWebSocket inner = new() { SendCompletion = completion };
        using WebSocket socket = telemetry.CreateWebSocket(inner);
        inner.QueueText("{\"type\":\"conversation.item.added\",\"item\":{\"id\":\"pending-audio\",\"role\":\"user\",\"content\":[{\"type\":\"input_audio\"}]}}");
        inner.QueueText("{\"type\":\"conversation.item.input_audio_transcription.completed\",\"item_id\":\"pending-audio\",\"transcript\":\"" + MessageSecret + "\"}");
        inner.QueueText("{\"type\":\"response.created\",\"response\":{\"id\":\"acknowledged-audio\"}}");
        inner.QueueText("{\"type\":\"response.done\",\"response\":{\"id\":\"acknowledged-audio\",\"status\":\"completed\"}}");

        Task send = socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(
            "{\"type\":\"conversation.item.create\",\"item\":{\"type\":\"message\",\"role\":\"user\",\"content\":[{\"type\":\"input_audio\",\"audio\":\"AQID\"}]}}")),
            WebSocketMessageType.Text, true, CancellationToken.None);
        for (int i = 0; i < 4; i++)
        {
            await socket.ReceiveAsync(new ArraySegment<byte>(new byte[512]), CancellationToken.None);
        }
        completion.SetResult(true);
        await send;
        socket.Dispose();

        using JsonDocument input = JsonDocument.Parse((string)Tag(Span(ResponseName), "gen_ai.input.messages"));
        JsonElement part = input.RootElement[0].GetProperty("parts")[0];
        Assert.That(part.TryGetProperty("content", out _), Is.EqualTo(captureContent));
        if (captureContent)
        {
            Assert.That(part.GetProperty("content").GetString(), Is.EqualTo(MessageSecret));
        }
        Assert.That(Tag(Span(SessionName), Prefix + "input.audio.bytes"), Is.EqualTo(3L));
        AssertPrivate("AQID");
        AssertLogPrivate(MessageSecret);
        if (!captureContent)
        {
            AssertPrivate(MessageSecret);
        }
    }

    [Test]
    public async Task PendingInputEventOverflowOmitsUncertainInputAndReleasesFinishedResponses()
    {
        SetContentCapture(true);
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        TaskCompletionSource<bool> completion = new(TaskCreationOptions.RunContinuationsAsynchronously);
        StubWebSocket inner = new() { SendCompletion = completion };
        using WebSocket socket = telemetry.CreateWebSocket(inner);
        inner.QueueText("{\"type\":\"response.created\",\"response\":{\"id\":\"before-overflow\"}}");
        inner.QueueText("{\"type\":\"response.done\",\"response\":{\"id\":\"before-overflow\",\"status\":\"completed\"}}");
        for (int i = 0; i < 65; i++)
        {
            inner.QueueText("{\"type\":\"input_audio_buffer.committed\",\"item_id\":\"overflow-" + i + "\"}");
        }
        inner.QueueText("{\"type\":\"response.created\",\"response\":{\"id\":\"after-overflow\"}}");
        inner.QueueText("{\"type\":\"response.done\",\"response\":{\"id\":\"after-overflow\",\"status\":\"completed\"}}");

        Task send = socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(
            "{\"type\":\"conversation.item.create\",\"item\":{\"type\":\"function_call_output\",\"call_id\":\"pending-call\",\"output\":\"" + MessageSecret + "\"}}")),
            WebSocketMessageType.Text, true, CancellationToken.None);
        for (int i = 0; i < 69; i++)
        {
            await socket.ReceiveAsync(new ArraySegment<byte>(new byte[512]), CancellationToken.None);
        }
        Assert.That(_activities, Has.Count.EqualTo(3), "Overflow releases both finished responses without waiting indefinitely for the send.");
        completion.SetResult(true);
        await send;
        socket.Dispose();

        Assert.That(_activities, Has.Count.EqualTo(4));
        foreach (Activity response in _activities.Where(activity => activity.OperationName == ResponseName))
        {
            Assert.That(Tag(response, "gen_ai.input.messages"), Is.Null);
            Assert.That(response.Status, Is.EqualTo(ActivityStatusCode.Ok));
        }
        Assert.That(Tag(Span(SessionName), "gen_ai.input.messages"), Is.Null);
        Assert.That(Span(SessionName).Events.Count(activityEvent => activityEvent.Name == "voice_agents.warning"), Is.EqualTo(1));
        AssertPrivate(MessageSecret);
    }

    [Test]
    public async Task PendingFinishedResponsesStayBoundedAndCompleteAfterFailedSend()
    {
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        TaskCompletionSource<bool> completion = new(TaskCreationOptions.RunContinuationsAsynchronously);
        StubWebSocket inner = new() { SendCompletion = completion };
        using WebSocket socket = telemetry.CreateWebSocket(inner);
        for (int i = 0; i < 65; i++)
        {
            inner.QueueText("{\"type\":\"response.created\",\"response\":{\"id\":\"bounded-" + i + "\"}}");
            inner.QueueText("{\"type\":\"response.done\",\"response\":{\"id\":\"bounded-" + i + "\",\"status\":\"completed\"}}");
        }
        Task send = socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes("{\"type\":\"input_audio_buffer.append\",\"audio\":\"AQID\"}")),
            WebSocketMessageType.Text, true, CancellationToken.None);
        for (int i = 0; i < 130; i++)
        {
            await socket.ReceiveAsync(new ArraySegment<byte>(new byte[512]), CancellationToken.None);
        }
        Assert.That(_activities, Has.Count.EqualTo(1));
        completion.SetException(new WebSocketException(ExceptionSecret));
        Assert.ThrowsAsync<WebSocketException>(async () => await send);
        Assert.That(_activities.Count(activity => activity.OperationName == ResponseName), Is.EqualTo(64));
        socket.Dispose();
        Assert.That(Tag(Span(SessionName), Prefix + "responses.untracked"), Is.EqualTo(1));
        Assert.That(Tag(Span(SessionName), Prefix + "responses.finished"), Is.EqualTo(64));
        Assert.That(_activities.Where(activity => activity.OperationName == ResponseName)
            .All(activity => Tag(activity, "gen_ai.input.messages") == null), Is.True);
        AssertPrivate(ExceptionSecret, "AQID");
    }

    [Test]
    public async Task NormalPeerCloseStillEndsOnDisposalWithoutHandshake()
    {
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        Observe(telemetry, new { type = "response.created", response = new { id = "response-unanswered-close" } });
        StubWebSocket inner = new();
        inner.QueueClose(WebSocketCloseStatus.NormalClosure, ExceptionSecret);
        using WebSocket socket = telemetry.CreateWebSocket(inner);
        await socket.ReceiveAsync(new ArraySegment<byte>(new byte[512]), CancellationToken.None);
        socket.Dispose();

        Assert.Multiple(() =>
        {
            Assert.That(_activities, Has.Count.EqualTo(3));
            Assert.That(Tag(Span(SessionName), Prefix + "close.was_clean"), Is.False);
            Assert.That(Span(SessionName).Status, Is.Not.EqualTo(ActivityStatusCode.Error));
            Assert.That(Tag(Span(ResponseName), Prefix + "response.status"), Is.EqualTo("interrupted"));
        });
        AssertPrivate(ExceptionSecret);
    }

    [Test]
    public async Task LocalCloseOutputWaitsForPeerReply()
    {
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        StubWebSocket inner = new();
        inner.QueueClose(WebSocketCloseStatus.NormalClosure, ExceptionSecret);
        using WebSocket socket = telemetry.CreateWebSocket(inner);

        await socket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, ExceptionSecret, CancellationToken.None);
        Assert.That(_activities, Has.Count.EqualTo(1));
        Assert.That(inner.State, Is.EqualTo(WebSocketState.CloseSent));
        await socket.ReceiveAsync(new ArraySegment<byte>(new byte[512]), CancellationToken.None);
        Assert.Multiple(() =>
        {
            Assert.That(_activities, Has.Count.EqualTo(2));
            Assert.That(Tag(Span(SessionName), Prefix + "close.was_clean"), Is.True);
            Assert.That(Tag(Span(SessionName), Prefix + "close.code"), Is.EqualTo(1000));
        });
        AssertPrivate(ExceptionSecret);
    }

    [Test]
    public async Task UnexpectedCloseRecordsSafeCodeAndStopsPendingResponseWithoutLoggingReason()
    {
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        Observe(telemetry, new { type = "response.created", response = new { id = "response-unexpected-close" } });
        StubWebSocket inner = new();
        inner.QueueClose(WebSocketCloseStatus.InternalServerError, ExceptionSecret);
        using WebSocket socket = telemetry.CreateWebSocket(inner);

        WebSocketReceiveResult result = await socket.ReceiveAsync(new ArraySegment<byte>(new byte[512]), CancellationToken.None);
        socket.Dispose();

        Assert.Multiple(() =>
        {
            Assert.That(result.MessageType, Is.EqualTo(WebSocketMessageType.Close));
            Assert.That(result.CloseStatusDescription, Is.EqualTo(ExceptionSecret), "The transport result must remain unmodified.");
            Assert.That(_activities, Has.Count.EqualTo(3));
            Assert.That(Span(SessionName).Status, Is.EqualTo(ActivityStatusCode.Error));
            Assert.That(Tag(Span(SessionName), "error.type"), Is.EqualTo("websocket_close"));
            Assert.That(Tag(Span(SessionName), Prefix + "close.code"), Is.EqualTo(1011));
            Assert.That(Tag(Span(SessionName), Prefix + "close.was_clean"), Is.False);
            Assert.That(Tag(Span(ResponseName), Prefix + "response.status"), Is.EqualTo("interrupted"));
        });
        AssertPrivate(ExceptionSecret);
    }

    [TestCase("null")]
    [TestCase("[]")]
    [TestCase("42")]
    [TestCase("true")]
    [TestCase("\"private-message-content\"")]
    public async Task UnsupportedConversationItemsDoNotFailSuccessfulWebSocketSends(string item)
    {
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        StubWebSocket inner = new();
        using WebSocket socket = telemetry.CreateWebSocket(inner);
        byte[] message = Encoding.UTF8.GetBytes("{\"type\":\"conversation.item.create\",\"item\":" + item + "}");

        await socket.SendAsync(new ArraySegment<byte>(message), WebSocketMessageType.Text, true, CancellationToken.None);
        await socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes("{\"type\":\"response.cancel\"}")),
            WebSocketMessageType.Text, true, CancellationToken.None);
        socket.Dispose();

        Assert.Multiple(() =>
        {
            Assert.That(inner.SendCount, Is.EqualTo(2), "Telemetry must not turn a successful transport send into a failure.");
            Assert.That(Span(SessionName).Status, Is.Not.EqualTo(ActivityStatusCode.Error));
            Assert.That(Span(SessionName).Events.Select(activityEvent => activityEvent.Name),
                Does.Contain("voice_agents.warning").And.Contain("voice_agents.response.cancel_requested"));
        });
        AssertPrivate(MessageSecret);
    }

    [Test]
    public void UnknownFutureAndMalformedEventsDoNotExposePayloadsOrPreventKnownEvents()
    {
        RealtimeTelemetry telemetry = StartTelemetry();
        telemetry.Connected();
        foreach (bool isSend in new[] { false, true })
        {
            Observe(telemetry, new { type = "future.protocol.event", payload = new { value = MessageSecret, values = new[] { MetadataSecret } } }, isSend);
            ObserveJson(telemetry, "[]", isSend);
            ObserveJson(telemetry, "{\"type\":42}", isSend);
            ObserveJson(telemetry, "{}", isSend);
        }
        ObserveJson(telemetry, "not-json-" + ExceptionSecret);
        Observe(telemetry, new { type = "session.created", session = new { id = "session-after-unknown", model = "known-model" } });
        Observe(telemetry, new { type = "response.created", response = new { id = "response-after-unknown" } });
        Observe(telemetry, new { type = "response.done", response = new { id = "response-after-unknown", status = "completed" } });
        telemetry.Close(WebSocketCloseStatus.NormalClosure, true);

        Assert.Multiple(() =>
        {
            Assert.That(_activities, Has.Count.EqualTo(3));
            Assert.That(Tag(Span(SessionName), Prefix + "session.id"), Is.EqualTo("session-after-unknown"));
            Assert.That(Span(SessionName).Status, Is.Not.EqualTo(ActivityStatusCode.Error));
            Assert.That(Span(SessionName).Events.Select(item => item.Name), Is.EquivalentTo(new[] { "voice_agents.warning", "voice_agents.session.created" }));
            Assert.That(Span(ResponseName).Status, Is.EqualTo(ActivityStatusCode.Ok));
            Assert.That(Tag(Span(ResponseName), "gen_ai.request.model"), Is.EqualTo("known-model"));
        });
        AssertPrivate(MessageSecret, MetadataSecret, ExceptionSecret);
    }

    [Test]
    public async Task LoggingOptOutStillRecordsActivitiesAndCleanCloseWithoutEventSourceMessages()
    {
        RealtimeTelemetry telemetry = StartTelemetry(enableLogging: false);
        telemetry.Connected();
        using WebSocket socket = telemetry.CreateWebSocket(new StubWebSocket());
        Observe(telemetry, new { type = "response.cancel" }, isSend: true);
        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, ExceptionSecret, CancellationToken.None);

        Assert.Multiple(() =>
        {
            Assert.That(_activities, Has.Count.EqualTo(2));
            Assert.That(Span(SessionName).Status, Is.Not.EqualTo(ActivityStatusCode.Error));
            Assert.That(Tag(Span(SessionName), Prefix + "close.code"), Is.EqualTo(1000));
            Assert.That(Tag(Span(SessionName), Prefix + "close.was_clean"), Is.True);
            Assert.That(Span(SessionName).Events.Select(item => item.Name), Does.Contain("voice_agents.response.cancel_requested"));
            Assert.That(_logs, Is.Empty);
        });
        AssertPrivate(ExceptionSecret);
    }

    private void SetTracing(string value)
    {
        Environment.SetEnvironmentVariable(TracingVariable, value);
        // AppContext cannot remove a switch, so only override switches that were already defined.
        if (_hadTracingSwitch)
        {
            AppContext.SetSwitch(TracingSwitch, string.Equals(value, "true", StringComparison.OrdinalIgnoreCase));
        }
    }

    private void SetContentCapture(bool value)
    {
        Environment.SetEnvironmentVariable(ContentVariable, value ? "true" : "false");
        if (_hadContentSwitch)
        {
            AppContext.SetSwitch(ContentSwitch, value);
        }
    }

    private RealtimeTelemetry CreateTelemetry(string queryString = null, bool enabled = true, bool enableLogging = true)
    {
        RealtimeTelemetry telemetry = RealtimeTelemetry.Start(s_endpoint, "voice-agent", queryString, enabled, enableLogging);
        if (telemetry != null)
        {
            _telemetries.Add(telemetry);
        }
        return telemetry;
    }

    private RealtimeTelemetry StartTelemetry(string queryString = null, bool enableLogging = true)
    {
        RealtimeTelemetry telemetry = CreateTelemetry(queryString, enableLogging: enableLogging);
        Assert.That(telemetry, Is.Not.Null);
        return telemetry;
    }

    private Activity Span(string name) => _activities.Single(activity => activity.OperationName == name);

    private static object Tag(Activity activity, string name) => activity.GetTagItem(name);

    private static object EventTag(ActivityEvent activityEvent, string name) => activityEvent.Tags.SingleOrDefault(tag => tag.Key == name).Value;

    private static void Observe(RealtimeTelemetry telemetry, object message, bool isSend = false)
        => telemetry.ObserveFrame(new ArraySegment<byte>(JsonSerializer.SerializeToUtf8Bytes(message)), true, isSend);

    private static void ObserveJson(RealtimeTelemetry telemetry, string message, bool isSend = false)
        => telemetry.ObserveFrame(new ArraySegment<byte>(Encoding.UTF8.GetBytes(message)), true, isSend);

    private void AssertPrivate(params string[] secrets)
    {
        string activities = JsonSerializer.Serialize(_activities.Select(activity => new
        {
            activity.DisplayName,
            activity.StatusDescription,
            Tags = activity.TagObjects.ToDictionary(tag => tag.Key, tag => tag.Value),
            Events = activity.Events.Select(item => new { item.Name, Tags = item.Tags.ToDictionary(tag => tag.Key, tag => tag.Value) }).ToArray()
        }).ToArray());
        Assert.Multiple(() =>
        {
            foreach (string secret in secrets)
            {
                Assert.That(activities, Does.Not.Contain(secret));
            }
        });
        AssertLogPrivate(secrets);
    }

    private void AssertLogPrivate(params string[] secrets)
    {
        string logs = string.Join("\n", _logs);
        Assert.Multiple(() =>
        {
            foreach (string secret in secrets)
            {
                Assert.That(logs, Does.Not.Contain(secret));
            }
        });
    }

    // Friend-assembly access also exposes unrelated generated overloads; reflect only this test contract.
    private sealed class RealtimeTelemetry
    {
        private static readonly Type s_type = typeof(AIProjectClient).Assembly.GetType(
            "Azure.AI.Projects.VoiceAgentRealtimeTelemetry", throwOnError: true);
        private static readonly MethodInfo s_start = GetMethod("Start", typeof(Uri), typeof(string), typeof(string), typeof(bool), typeof(bool));
        private static readonly MethodInfo s_connected = GetMethod("Connected");
        private static readonly MethodInfo s_connectionFailed = GetMethod("ConnectionFailed", typeof(Exception));
        private static readonly MethodInfo s_transportFailed = GetMethod("TransportFailed", typeof(Exception), typeof(bool), typeof(WebSocketState));
        private static readonly MethodInfo s_close = GetMethod("Close", typeof(WebSocketCloseStatus?), typeof(bool));
        private static readonly MethodInfo s_observeFrame = GetMethod("ObserveFrame", typeof(ArraySegment<byte>), typeof(bool), typeof(bool));
        private static readonly MethodInfo s_addTraceHeaders = GetMethod("AddTraceHeaders", typeof(IDictionary<string, string>));
        private static readonly Type s_socketType = s_type.Assembly.GetType(
            "Azure.AI.Projects.TelemetryWebSocket", throwOnError: true);
        private static readonly ConstructorInfo s_socketConstructor = s_socketType.GetConstructor(
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
            binder: null, types: new[] { typeof(WebSocket), s_type }, modifiers: null)
            ?? throw new MissingMethodException(s_socketType.FullName, ".ctor");
        private readonly object _instance;

        private RealtimeTelemetry(object instance) => _instance = instance;

        internal static RealtimeTelemetry Start(Uri endpoint, string agentName, string queryString, bool enabled, bool enableLogging)
        {
            object instance = s_start.Invoke(null, new object[] { endpoint, agentName, queryString, enabled, enableLogging });
            return instance == null ? null : new RealtimeTelemetry(instance);
        }

        internal void Connected() => s_connected.Invoke(_instance, null);

        internal void ConnectionFailed(Exception exception) => s_connectionFailed.Invoke(_instance, new object[] { exception });

        internal void TransportFailed(Exception exception, bool isSend, WebSocketState state = WebSocketState.Open)
            => s_transportFailed.Invoke(_instance, new object[] { exception, isSend, state });

        internal void Close(WebSocketCloseStatus? status, bool wasClean) => s_close.Invoke(_instance, new object[] { status, wasClean });

        internal void ObserveFrame(ArraySegment<byte> bytes, bool endOfMessage, bool isSend)
            => s_observeFrame.Invoke(_instance, new object[] { bytes, endOfMessage, isSend });

        internal void AddTraceHeaders(IDictionary<string, string> headers) => s_addTraceHeaders.Invoke(_instance, new object[] { headers });

        internal WebSocket CreateWebSocket(WebSocket inner)
            => (WebSocket)s_socketConstructor.Invoke(new object[] { inner, _instance });

        private static MethodInfo GetMethod(string name, params Type[] parameterTypes)
            => s_type.GetMethod(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic,
                binder: null, types: parameterTypes, modifiers: null)
                ?? throw new MissingMethodException(s_type.FullName, name);
    }

    private sealed class FailingTokenProvider(Exception failure) : AuthenticationTokenProvider
    {
        public override GetTokenOptions CreateTokenOptions(IReadOnlyDictionary<string, object> properties) => new(properties);

        public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken) => throw failure;

        public override ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken) => throw failure;
    }

    private sealed class SessionWithSocket : ProjectsRealtimeSessionClient
    {
        internal SessionWithSocket(WebSocket socket) => WebSocket = socket;
    }

    private sealed class StubWebSocket : WebSocket
    {
        private readonly Queue<(byte[] Bytes, WebSocketReceiveResult Result)> _receives = new();
        private WebSocketState _state = WebSocketState.Open;
        private WebSocketCloseStatus? _closeStatus;
        private string _closeDescription;

        internal Exception SendFailure { get; set; }
        internal Exception ReceiveFailure { get; set; }
        internal WebSocketState? StateAfterFailure { get; set; }
        internal TaskCompletionSource<bool> SendCompletion { get; set; }
        internal int DisposeCount { get; private set; }
        internal int SendCount { get; private set; }

        public override WebSocketCloseStatus? CloseStatus => _closeStatus;
        public override string CloseStatusDescription => _closeDescription;
        public override WebSocketState State => _state;
        public override string SubProtocol => "realtime";

        internal void QueueText(string text, bool endOfMessage = true)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            _receives.Enqueue((bytes, new WebSocketReceiveResult(bytes.Length, WebSocketMessageType.Text, endOfMessage)));
        }

        internal void QueueClose(WebSocketCloseStatus status, string reason)
            => _receives.Enqueue((Array.Empty<byte>(), new WebSocketReceiveResult(0, WebSocketMessageType.Close, true, status, reason)));

        public override void Abort() => _state = WebSocketState.Aborted;

        public override void Dispose()
        {
            DisposeCount++;
            _state = WebSocketState.Closed;
        }

        public override Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _closeStatus = closeStatus;
            _closeDescription = statusDescription;
            _state = WebSocketState.Closed;
            return Task.CompletedTask;
        }

        public override Task CloseOutputAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _closeStatus = closeStatus;
            _closeDescription = statusDescription;
            _state = _state == WebSocketState.CloseReceived ? WebSocketState.Closed : WebSocketState.CloseSent;
            return Task.CompletedTask;
        }

        public override Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken)
        {
            if (SendFailure != null)
            {
                _state = StateAfterFailure ?? _state;
                return Task.FromException(SendFailure);
            }
            cancellationToken.ThrowIfCancellationRequested();
            if (SendCompletion != null)
            {
                return CompletePendingSendAsync(SendCompletion.Task);
            }
            SendCount++;
            return Task.CompletedTask;
        }

        private async Task CompletePendingSendAsync(Task completion)
        {
            await completion.ConfigureAwait(false);
            SendCount++;
        }

        public override Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken)
        {
            if (ReceiveFailure != null)
            {
                _state = StateAfterFailure ?? _state;
                return Task.FromException<WebSocketReceiveResult>(ReceiveFailure);
            }
            cancellationToken.ThrowIfCancellationRequested();
            (byte[] bytes, WebSocketReceiveResult result) = _receives.Dequeue();
            Assert.That(bytes.Length, Is.LessThanOrEqualTo(buffer.Count));
            Array.Copy(bytes, 0, buffer.Array, buffer.Offset, bytes.Length);
            if (result.MessageType == WebSocketMessageType.Close)
            {
                _closeStatus = result.CloseStatus;
                _closeDescription = result.CloseStatusDescription;
                _state = _state == WebSocketState.CloseSent ? WebSocketState.Closed : WebSocketState.CloseReceived;
            }
            return Task.FromResult(result);
        }
    }
}
