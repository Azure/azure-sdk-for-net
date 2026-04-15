// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.VoiceLive.Telemetry;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using Azure.Core;
using NUnit.Framework;
using Keys = Azure.AI.VoiceLive.Telemetry.VoiceLiveTelemetryAttributeKeys;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Unit tests for the OpenTelemetry tracing layer (<see cref="VoiceLiveTracer"/>) and its
    /// integration with <see cref="VoiceLiveSession"/> send/receive paths.
    ///
    /// Tests use an <see cref="ActivityListener"/> registered against
    /// <see cref="VoiceLiveTracer.ActivitySource"/> to capture completed spans without requiring
    /// any live network connections.
    /// </summary>
    [TestFixture]
    public class VoiceLiveTelemetryTests
    {
        // ─── Activity capture helpers ─────────────────────────────────────────────

        /// <summary>
        /// Registers an <see cref="ActivityListener"/> for the VoiceLive ActivitySource and
        /// collects snapshots of every stopped span.  Implements <see cref="IDisposable"/> so
        /// that tests can wrap it in a <c>using</c> statement — the listener is removed from the
        /// pipeline on disposal, preventing cross-test interference.
        /// </summary>
        private sealed class ActivityCapturer : IDisposable
        {
            private readonly ActivityListener _listener;
            private readonly List<ActivitySnapshot> _completed = new();
            private readonly object _lock = new();

            public ActivityCapturer()
            {
                _listener = new ActivityListener
                {
                    ShouldListenTo = source => source.Name == "Azure.AI.VoiceLive",
                    Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                        ActivitySamplingResult.AllDataAndRecorded,
                    ActivityStopped = a =>
                    {
                        lock (_lock)
                            _completed.Add(ActivitySnapshot.From(a));
                    }
                };
                ActivitySource.AddActivityListener(_listener);
            }

            public IReadOnlyList<ActivitySnapshot> Completed
            {
                get { lock (_lock) return _completed.ToArray(); }
            }

#nullable enable
            public ActivitySnapshot? Find(string displayName) =>
                Completed.FirstOrDefault(a => a.DisplayName == displayName);
#nullable disable

            public IEnumerable<ActivitySnapshot> FindAll(string displayName) =>
                Completed.Where(a => a.DisplayName == displayName);

            public void Dispose() => _listener.Dispose();
        }

        /// <summary>
        /// Immutable snapshot of an <see cref="Activity"/>'s data taken inside the
        /// ActivityStopped callback.  Avoids any post-stop activity lifecycle concerns.
        /// </summary>
        private sealed class ActivitySnapshot
        {
            public string DisplayName { get; private set; }
            public ActivityKind Kind { get; private set; }
            public ActivityStatusCode Status { get; private set; }
            public string StatusDescription { get; private set; }
            public Dictionary<string, object> Tags { get; private set; }
            public List<(string Name, Dictionary<string, object> Tags)> Events { get; private set; }
            public ActivityTraceId TraceId { get; private set; }
            public ActivitySpanId SpanId { get; private set; }
            public ActivitySpanId ParentSpanId { get; private set; }

            public string GetTag(string key) =>
                Tags.TryGetValue(key, out var v) ? v?.ToString() : null;

            public static ActivitySnapshot From(Activity a) => new ActivitySnapshot
            {
                DisplayName = a.DisplayName,
                Kind = a.Kind,
                Status = a.Status,
                StatusDescription = a.StatusDescription,
                Tags = a.TagObjects.ToDictionary(kv => kv.Key, kv => kv.Value ?? (object)string.Empty),
                Events = a.Events
                    .Select(e => (e.Name, e.Tags.ToDictionary(t => t.Key, t => t.Value ?? (object)string.Empty)))
                    .ToList(),
                TraceId = a.TraceId,
                SpanId = a.SpanId,
                ParentSpanId = a.ParentSpanId,
            };
        }

        // ─── Construction helpers ─────────────────────────────────────────────────

        private static VoiceLiveTracer CreateTracer(
            string endpoint = "wss://example.voicelive.azure.com/realtime",
            bool? enableContentRecording = null)
        {
            return new VoiceLiveTracer(new Uri(endpoint), enableContentRecording);
        }

        private static TestableVoiceLiveSession CreateSession(out FakeWebSocket socket)
        {
            return TestSessionFactory.CreateSession(out socket);
        }

        // ─── Connect span ─────────────────────────────────────────────────────────

        [Test]
        public void ConnectActivity_HasCommonAttributes()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer("wss://my-service.azure.com/realtime");

            tracer.StartConnectActivity();
            tracer.EndConnectActivity();

            var span = capturer.Find("connect");
            Assert.That(span, Is.Not.Null, "connect span should be recorded");
            Assert.That(span!.GetTag(Keys.AzNamespace), Is.EqualTo(Keys.AzNamespaceValue));
            Assert.That(span.GetTag(Keys.GenAiSystem), Is.EqualTo(Keys.GenAiSystemValue));
            Assert.That(span.GetTag(Keys.GenAiProviderName), Is.EqualTo(Keys.GenAiProviderValue));
            Assert.That(span.GetTag(Keys.GenAiOperationName), Is.EqualTo("connect"));
            Assert.That(span.GetTag(Keys.ServerAddress), Is.EqualTo("my-service.azure.com"));
        }

        [Test]
        public void ConnectActivity_WithModelEndpoint_HasModelAttribute()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer("wss://example.azure.com/realtime?model=gpt-4o-realtime-preview");

            tracer.StartConnectActivity();
            tracer.EndConnectActivity();

            var span = capturer.Find("connect");
            Assert.That(span, Is.Not.Null);
            Assert.That(span!.GetTag(Keys.GenAiRequestModel), Is.EqualTo("gpt-4o-realtime-preview"));
        }

        [Test]
        public void ConnectActivity_WithAgentEndpoint_HasAgentAttributes()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer("wss://example.azure.com/realtime?agent-name=my-bot&agent-project-name=my-project&agent-version=2");

            tracer.StartConnectActivity();
            tracer.EndConnectActivity();

            var span = capturer.Find("connect");
            Assert.That(span, Is.Not.Null);
            Assert.That(span!.GetTag(Keys.GenAiAgentName), Is.EqualTo("my-bot"));
            Assert.That(span.GetTag(Keys.GenAiAgentProjectName), Is.EqualTo("my-project"));
            Assert.That(span.GetTag(Keys.GenAiAgentVersion), Is.EqualTo("2"));
        }

        [Test]
        public void EndConnectActivity_IsIdempotent()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();

            tracer.StartConnectActivity();
            tracer.EndConnectActivity();  // first — should stop the span
            tracer.EndConnectActivity();  // second — should be a no-op

            Assert.That(capturer.FindAll("connect").Count(), Is.EqualTo(1),
                "connect span should appear exactly once");
        }

        [Test]
        public void EndConnectActivity_WithException_RecordsError()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();

            tracer.StartConnectActivity();
            tracer.EndConnectActivity(new InvalidOperationException("connection refused"));

            var span = capturer.Find("connect");
            Assert.That(span, Is.Not.Null);
            Assert.That(span!.Status, Is.EqualTo(ActivityStatusCode.Error));
            Assert.That(span.GetTag(Keys.ErrorType), Does.Contain("InvalidOperationException"));
            Assert.That(span.GetTag(Keys.ErrorMessage), Is.EqualTo("connection refused"));
        }

        [Test]
        public void WhenNoActivityListener_StartConnectActivity_ReturnsNull()
        {
            // No ActivityCapturer in scope — verify the tracer handles the no-listener case.
            // Because other tests in this process may have registered listeners, we only
            // assert when we can confirm no listeners are active.
            var tracer = CreateTracer();
            if (!tracer.IsEnabled)
            {
                Assert.That(tracer.StartConnectActivity(), Is.Null);
            }
            else
            {
                Assert.Pass("Skipped: another test's ActivityCapturer is active in this process.");
            }
        }

        // ─── Send spans ───────────────────────────────────────────────────────────

        [Test]
        public void SendActivity_IsParentedToConnectActivity()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer("wss://example.azure.com/realtime?model=gpt-4o");

            tracer.StartConnectActivity();
            var sendActivity = tracer.StartSendActivity("session.update");
            sendActivity?.Stop();
            tracer.EndConnectActivity();

            var connectSpan = capturer.Find("connect");
            var sendSpan = capturer.Find("send session.update");

            Assert.That(sendSpan, Is.Not.Null, "send span should be recorded");
            Assert.That(sendSpan!.GetTag(Keys.GenAiSystem), Is.EqualTo(Keys.GenAiSystemValue));
            Assert.That(sendSpan.GetTag(Keys.GenAiOperationName), Is.EqualTo("send"));
            // Child span must be in the same trace and parented to the connect span
            Assert.That(sendSpan.TraceId, Is.EqualTo(connectSpan!.TraceId), "should be in same trace");
            Assert.That(sendSpan.ParentSpanId, Is.EqualTo(connectSpan.SpanId), "should be child of connect span");
        }

        [Test]
        public void SendActivity_WithoutConnectActivity_ReturnsNull()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();  // no StartConnectActivity call

            var activity = tracer.StartSendActivity("session.update");

            Assert.That(activity, Is.Null, "should return null when no connect activity exists");
        }

        [Test]
        public void EnrichSendSessionUpdate_SetsTemperatureAndMaxOutputTokens()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var sendActivity = tracer.StartSendActivity("session.update");
            using var doc = JsonDocument.Parse(
                @"{""type"":""session.update"",""session"":{""temperature"":0.8,""max_response_output_tokens"":4096}}");
            tracer.EnrichSendSessionUpdate(sendActivity, doc.RootElement);
            sendActivity?.Stop();
            tracer.EndConnectActivity();

            var span = capturer.Find("send session.update");
            Assert.That(span, Is.Not.Null);
            Assert.That(span!.GetTag(Keys.GenAiRequestTemperature), Is.EqualTo("0.8"));
            Assert.That(span.GetTag(Keys.GenAiRequestMaxOutputTokens), Is.EqualTo("4096"));
        }

        [Test]
        public void AddSendContentEvent_WhenEnabled_AddsActivityEvent()
        {
            using var capturer = new ActivityCapturer();
            var tracer = new VoiceLiveTracer(new Uri("wss://example.azure.com"), enableContentRecordingOverride: true);
            tracer.StartConnectActivity();

            var sendActivity = tracer.StartSendActivity("session.update");
            tracer.AddSendContentEvent(sendActivity, "session.update", @"{""type"":""session.update""}");
            sendActivity?.Stop();
            tracer.EndConnectActivity();

            var span = capturer.Find("send session.update");
            Assert.That(span, Is.Not.Null);
            Assert.That(span!.Events.Count, Is.EqualTo(1));
            Assert.That(span.Events[0].Name, Is.EqualTo("session.update"));
        }

        [Test]
        public void AddSendContentEvent_WhenDisabled_NoActivityEvent()
        {
            using var capturer = new ActivityCapturer();
            var tracer = new VoiceLiveTracer(new Uri("wss://example.azure.com"), enableContentRecordingOverride: false);
            tracer.StartConnectActivity();

            var sendActivity = tracer.StartSendActivity("session.update");
            tracer.AddSendContentEvent(sendActivity, "session.update", @"{""type"":""session.update""}");
            sendActivity?.Stop();
            tracer.EndConnectActivity();

            var span = capturer.Find("send session.update");
            Assert.That(span, Is.Not.Null);
            Assert.That(span!.Events.Count, Is.EqualTo(0),
                "content events should be suppressed when recording is disabled");
        }

        // ─── Recv spans ───────────────────────────────────────────────────────────

        [Test]
        public void RecvActivity_IsParentedToConnectActivity()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();

            tracer.StartConnectActivity();
            var recvActivity = tracer.StartRecvActivity("session.created");
            recvActivity?.Stop();
            tracer.EndConnectActivity();

            var connectSpan = capturer.Find("connect");
            var recvSpan = capturer.Find("recv session.created");

            Assert.That(recvSpan, Is.Not.Null, "recv span should be recorded");
            Assert.That(recvSpan!.GetTag(Keys.GenAiSystem), Is.EqualTo(Keys.GenAiSystemValue));
            Assert.That(recvSpan.GetTag(Keys.GenAiOperationName), Is.EqualTo("recv"));
            Assert.That(recvSpan.TraceId, Is.EqualTo(connectSpan!.TraceId), "should be in same trace");
            Assert.That(recvSpan.ParentSpanId, Is.EqualTo(connectSpan.SpanId), "should be child of connect span");
        }

        [Test]
        public void EnrichRecvSessionEvent_SetsSessionIdAndBackfillsConnectSpan()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var recvActivity = tracer.StartRecvActivity("session.created");
            using var doc = JsonDocument.Parse(
                @"{""type"":""session.created"",""session"":{""id"":""sess_abc123"",""model"":""gpt-4o""}}");
            tracer.EnrichRecvSessionEvent(recvActivity, doc.RootElement);
            recvActivity?.Stop();
            tracer.EndConnectActivity();

            var recvSpan = capturer.Find("recv session.created");
            Assert.That(recvSpan, Is.Not.Null);
            Assert.That(recvSpan!.GetTag(Keys.GenAiVoiceSessionId), Is.EqualTo("sess_abc123"));
            Assert.That(recvSpan.GetTag(Keys.GenAiResponseModel), Is.EqualTo("gpt-4o"));

            // Session ID must be back-filled on the connect span too
            var connectSpan = capturer.Find("connect");
            Assert.That(connectSpan!.GetTag(Keys.GenAiVoiceSessionId), Is.EqualTo("sess_abc123"),
                "connect span should have session ID back-filled from session.created");
        }

        [Test]
        public void EnrichRecvResponseDone_SetsTokenUsageAndResponseId()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var recvActivity = tracer.StartRecvActivity("response.done");
            using var doc = JsonDocument.Parse(@"{
                ""type"": ""response.done"",
                ""response"": {
                    ""id"": ""resp_xyz"",
                    ""status"": ""completed"",
                    ""usage"": { ""input_tokens"": 50, ""output_tokens"": 120 }
                }
            }");
            tracer.EnrichRecvResponseDone(recvActivity, doc.RootElement);
            recvActivity?.Stop();
            tracer.EndConnectActivity();

            var span = capturer.Find("recv response.done");
            Assert.That(span, Is.Not.Null);
            Assert.That(span!.GetTag(Keys.GenAiResponseId), Is.EqualTo("resp_xyz"));
            Assert.That(span.GetTag(Keys.GenAiResponseFinishReasons), Is.EqualTo("completed"));
            Assert.That(span.GetTag(Keys.GenAiUsageInputTokens), Is.EqualTo("50"));
            Assert.That(span.GetTag(Keys.GenAiUsageOutputTokens), Is.EqualTo("120"));
        }

        [Test]
        public void EnrichRecvMcpEvent_SetsMcpServerAndToolAttributes()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var recvActivity = tracer.StartRecvActivity("response.mcp_call.completed");
            using var doc = JsonDocument.Parse(
                @"{""type"":""response.mcp_call.completed"",""server_label"":""weather-mcp"",""tool_name"":""get_forecast""}");
            tracer.EnrichRecvMcpEvent(recvActivity, doc.RootElement);
            recvActivity?.Stop();
            tracer.EndConnectActivity();

            var span = capturer.Find("recv response.mcp_call.completed");
            Assert.That(span, Is.Not.Null);
            Assert.That(span!.GetTag(Keys.GenAiVoiceMcpServerLabel), Is.EqualTo("weather-mcp"));
            Assert.That(span.GetTag(Keys.GenAiVoiceMcpToolName), Is.EqualTo("get_forecast"));
        }

        [Test]
        public void EnrichWithItemIds_SetsItemIdAndOutputIndex()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var recvActivity = tracer.StartRecvActivity("response.output_item.added");
            using var doc = JsonDocument.Parse(
                @"{""type"":""response.output_item.added"",""item"":{""id"":""item_123""},""output_index"":2}");
            tracer.EnrichWithItemIds(recvActivity, doc.RootElement);
            recvActivity?.Stop();
            tracer.EndConnectActivity();

            var span = capturer.Find("recv response.output_item.added");
            Assert.That(span, Is.Not.Null);
            Assert.That(span!.GetTag(Keys.GenAiVoiceItemId), Is.EqualTo("item_123"));
            Assert.That(span.GetTag(Keys.GenAiVoiceOutputIndex), Is.EqualTo("2"));
        }

        // ─── Session-level counters ───────────────────────────────────────────────

        [Test]
        public void SessionCounters_AccumulateAndAppearOnConnectSpan()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            tracer.OnRecvSpeechStarted();   // turn 1
            tracer.OnRecvSpeechStarted();   // turn 2
            tracer.OnSendResponseCancel();  // interruption 1
            tracer.OnSendAudioData(1000);   // 1000 bytes sent
            tracer.OnSendAudioData(500);    // 1500 bytes sent total

            using var deltaDoc = JsonDocument.Parse(
                @"{""type"":""response.audio.delta"",""delta"":""AQID""}");  // "AQID" = 3 bytes
            tracer.OnRecvAudioDelta(deltaDoc.RootElement);

            tracer.OnRecvMcpCallDone();        // mcp call 1
            tracer.OnRecvMcpListToolsDone();   // mcp list 1
            tracer.OnRecvMcpListToolsDone();   // mcp list 2

            tracer.EndConnectActivity();

            var span = capturer.Find("connect");
            Assert.That(span, Is.Not.Null);
            Assert.That(span!.Tags[Keys.GenAiVoiceTurnCount], Is.EqualTo(2L));
            Assert.That(span.Tags[Keys.GenAiVoiceInterruptionCount], Is.EqualTo(1L));
            Assert.That(span.Tags[Keys.GenAiVoiceAudioBytesSent], Is.EqualTo(1500L));
            Assert.That(span.Tags[Keys.GenAiVoiceMcpCallCount], Is.EqualTo(1L));
            Assert.That(span.Tags[Keys.GenAiVoiceMcpListToolsCount], Is.EqualTo(2L));
        }

        [Test]
        public void AudioBytesReceived_ApproximatedFromBase64Delta()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            // "AAAA" encodes 3 bytes; base64 estimate: length * 3/4 = 4 * 3/4 = 3
            using var doc = JsonDocument.Parse(@"{""delta"":""AAAA""}");
            tracer.OnRecvAudioDelta(doc.RootElement);

            tracer.EndConnectActivity();

            var span = capturer.Find("connect");
            Assert.That(span, Is.Not.Null);
            Assert.That(span!.Tags.ContainsKey(Keys.GenAiVoiceAudioBytesReceived), Is.True,
                "audio_bytes_received should be set");
            Assert.That(Convert.ToInt64(span.Tags[Keys.GenAiVoiceAudioBytesReceived]), Is.GreaterThan(0L));
        }

        // ─── First-token latency ──────────────────────────────────────────────────

        [Test]
        public void FirstTokenLatency_RecordedOncePerResponseCycle()
        {
            var tracer = CreateTracer();
            tracer.OnSendResponseCreate();  // starts a new response cycle

            double? first = tracer.TryRecordFirstTokenLatency();
            Assert.That(first, Is.Not.Null, "first call should return a latency value");
            Assert.That(first.Value, Is.GreaterThanOrEqualTo(0.0));

            double? second = tracer.TryRecordFirstTokenLatency();
            Assert.That(second, Is.Null, "second call for same response should return null");
        }

        [Test]
        public void FirstTokenLatency_ResetsWhenNewResponseCreated()
        {
            var tracer = CreateTracer();

            tracer.OnSendResponseCreate();
            double? first = tracer.TryRecordFirstTokenLatency();
            Assert.That(first, Is.Not.Null, "first response cycle should record");

            // Start a new response cycle — the recorded flag resets
            tracer.OnSendResponseCreate();
            double? second = tracer.TryRecordFirstTokenLatency();
            Assert.That(second, Is.Not.Null, "new response cycle should be recordable again");
        }

        // ─── Error recording ──────────────────────────────────────────────────────

        [Test]
        public void RecordError_SetsStatusAndErrorTagsOnActivity()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var sendActivity = tracer.StartSendActivity("session.update");
            var ex = new TimeoutException("send timed out");
            VoiceLiveTracer.RecordError(sendActivity, ex);
            sendActivity?.Stop();
            tracer.EndConnectActivity();

            var span = capturer.Find("send session.update");
            Assert.That(span, Is.Not.Null);
            Assert.That(span!.Status, Is.EqualTo(ActivityStatusCode.Error));
            Assert.That(span.GetTag(Keys.ErrorType), Does.Contain("TimeoutException"));
            Assert.That(span.GetTag(Keys.ErrorMessage), Is.EqualTo("send timed out"));
        }

        [Test]
        public void RecordError_WithNullActivity_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => VoiceLiveTracer.RecordError(null, new Exception("test")));
        }

        // ─── Integration: VoiceLiveSession ────────────────────────────────────────

        [Test]
        public async Task GetUpdatesAsync_SessionCreated_CreatesEnrichedRecvSpan()
        {
            using var capturer = new ActivityCapturer();
            var session = CreateSession(out var fake);

            // Simulate the connect span that ConnectAsync would normally create
            session._tracer.StartConnectActivity();

            fake.EnqueueTextMessage(
                @"{""type"":""session.created"",""event_id"":""e1"",""session"":{""id"":""sess_test"",""model"":""gpt-4o""}}");

            await foreach (var _ in session.GetUpdatesAsync()) break;

            session._tracer.EndConnectActivity();

            var span = capturer.Find("recv session.created");
            Assert.That(span, Is.Not.Null, "session.created should produce a recv span");
            Assert.That(span!.GetTag(Keys.GenAiVoiceSessionId), Is.EqualTo("sess_test"));
        }

        [Test]
        public async Task GetUpdatesAsync_ResponseDone_CreatesRecvSpanWithTokenUsage()
        {
            using var capturer = new ActivityCapturer();
            var session = CreateSession(out var fake);
            session._tracer.StartConnectActivity();

            fake.EnqueueTextMessage(@"{
                ""type"": ""response.done"",
                ""event_id"": ""e2"",
                ""response"": {
                    ""id"": ""resp_99"",
                    ""status"": ""completed"",
                    ""usage"": { ""input_tokens"": 10, ""output_tokens"": 25 }
                }
            }");

            await foreach (var _ in session.GetUpdatesAsync()) break;

            session._tracer.EndConnectActivity();

            var span = capturer.Find("recv response.done");
            Assert.That(span, Is.Not.Null, "response.done should produce a recv span");
            Assert.That(span!.GetTag(Keys.GenAiResponseId), Is.EqualTo("resp_99"));
            Assert.That(span.GetTag(Keys.GenAiUsageInputTokens), Is.EqualTo("10"));
            Assert.That(span.GetTag(Keys.GenAiUsageOutputTokens), Is.EqualTo("25"));
        }

        [Test]
        public async Task GetUpdatesAsync_TextDelta_DoesNotCreateSpan()
        {
            using var capturer = new ActivityCapturer();
            var session = CreateSession(out var fake);
            session._tracer.StartConnectActivity();

            fake.EnqueueTextMessage(
                @"{""type"":""response.text.delta"",""event_id"":""e3"",""delta"":""hello""}");

            await foreach (var _ in session.GetUpdatesAsync()) break;

            session._tracer.EndConnectActivity();

            Assert.That(capturer.Find("recv response.text.delta"), Is.Null,
                "response.text.delta should be skipped — high-frequency delta events are not traced");
        }

        [Test]
        public async Task GetUpdatesAsync_AudioTranscriptDelta_DoesNotCreateSpan()
        {
            using var capturer = new ActivityCapturer();
            var session = CreateSession(out var fake);
            session._tracer.StartConnectActivity();

            fake.EnqueueTextMessage(
                @"{""type"":""response.audio_transcript.delta"",""event_id"":""e4"",""delta"":""hello ""}");

            await foreach (var _ in session.GetUpdatesAsync()) break;

            session._tracer.EndConnectActivity();

            Assert.That(capturer.Find("recv response.audio_transcript.delta"), Is.Null,
                "response.audio_transcript.delta should be skipped — high-frequency delta events are not traced");
        }

        [Test]
        public async Task GetUpdatesAsync_McpCallCompleted_CreatesEnrichedRecvSpan()
        {
            using var capturer = new ActivityCapturer();
            var session = CreateSession(out var fake);
            session._tracer.StartConnectActivity();

            fake.EnqueueTextMessage(
                @"{""type"":""response.mcp_call.completed"",""event_id"":""e5"",""server_label"":""my-mcp"",""tool_name"":""list_files""}");

            await foreach (var _ in session.GetUpdatesAsync()) break;

            session._tracer.EndConnectActivity();

            var span = capturer.Find("recv response.mcp_call.completed");
            Assert.That(span, Is.Not.Null, "response.mcp_call.completed should produce a recv span");
            Assert.That(span!.GetTag(Keys.GenAiVoiceMcpServerLabel), Is.EqualTo("my-mcp"));
            Assert.That(span.GetTag(Keys.GenAiVoiceMcpToolName), Is.EqualTo("list_files"));
        }

        [Test]
        public async Task SendCommandAsync_SessionUpdate_CreatesSpan()
        {
            using var capturer = new ActivityCapturer();
            var session = CreateSession(out _);
            session._tracer.StartConnectActivity();

            await session.ConfigureSessionAsync(new VoiceLiveSessionOptions());

            session._tracer.EndConnectActivity();

            Assert.That(capturer.Find("send session.update"), Is.Not.Null,
                "session.update command should produce a send span");
        }

        [Test]
        public async Task SendInputAudio_DoesNotCreateSpan()
        {
            using var capturer = new ActivityCapturer();
            var session = CreateSession(out _);
            session._tracer.StartConnectActivity();

            // Audio append commands are high-frequency and must not create spans
            await session.SendInputAudioAsync(new byte[] { 0x01, 0x02, 0x03 });

            session._tracer.EndConnectActivity();

            Assert.That(
                capturer.Completed.Any(s => s.DisplayName != null && s.DisplayName.StartsWith("send input_audio")),
                Is.False,
                "audio append commands should not produce send spans");
        }
    }
}
