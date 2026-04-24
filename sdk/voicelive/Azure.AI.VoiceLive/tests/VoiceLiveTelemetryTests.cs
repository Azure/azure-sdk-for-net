// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
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

            // Phase 2: session config attributes are set on the connect span, not the send span
            var connectSpan = capturer.Find("connect");
            Assert.That(connectSpan, Is.Not.Null);
            Assert.That(connectSpan!.GetTag(Keys.GenAiRequestTemperature), Is.EqualTo("0.8"));
            Assert.That(connectSpan.GetTag(Keys.GenAiRequestMaxOutputTokens), Is.EqualTo("4096"));
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
            Assert.That(span.Events[0].Name, Is.EqualTo("gen_ai.input.messages"));
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
            Assert.That(span!.Events.Count, Is.EqualTo(1),
                "event is always emitted but without content when recording is disabled");
            var contentTag = span.Events[0].Tags.FirstOrDefault(t => t.Key == Keys.GenAiEventContent);
            Assert.That(contentTag.Value, Is.Null,
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
            // Phase 2: gen_ai.response.model is no longer set on recv session spans

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

            tracer.OnRecvResponseDone();   // turn 1
            tracer.OnRecvResponseDone();   // turn 2
            tracer.OnSendResponseCancel();  // interruption 1
            // b64.Length * 3L / 4: 1334 → 1000 bytes, 667 → 500 bytes
            using var audioDoc1 = JsonDocument.Parse($"{{\"type\":\"input_audio_buffer.append\",\"audio\":\"{new string('A', 1334)}\"}}");
            tracer.OnSendAudioData(audioDoc1.RootElement);  // 1000 decoded bytes
            using var audioDoc2 = JsonDocument.Parse($"{{\"type\":\"input_audio_buffer.append\",\"audio\":\"{new string('A', 667)}\"}}");
            tracer.OnSendAudioData(audioDoc2.RootElement);  // 500 decoded bytes

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

        // ─── Phase 2: session config on connect span ──────────────────────────────

        [Test]
        public void EnrichSendSessionUpdate_SetsInstructionsAndToolsOnConnectSpan()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var sendActivity = tracer.StartSendActivity("session.update");
            using var doc = JsonDocument.Parse(
                @"{""type"":""session.update"",""session"":{""instructions"":""You are helpful."",""tools"":[{""name"":""get_weather""}]}}");
            tracer.EnrichSendSessionUpdate(sendActivity, doc.RootElement);
            sendActivity?.Stop();
            tracer.EndConnectActivity();

            var connectSpan = capturer.Find("connect");
            Assert.That(connectSpan, Is.Not.Null);
            Assert.That(connectSpan!.GetTag(Keys.GenAiSystemMessage), Is.EqualTo("You are helpful."));
            Assert.That(connectSpan.GetTag(Keys.GenAiRequestTools), Does.Contain("get_weather"));
        }

        [Test]
        public void EnrichSendSessionUpdate_SetsAudioFormatsOnConnectSpan()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var sendActivity = tracer.StartSendActivity("session.update");
            using var doc = JsonDocument.Parse(
                @"{""type"":""session.update"",""session"":{""input_audio_format"":""pcm16"",""output_audio_format"":""g711_ulaw""}}");
            tracer.EnrichSendSessionUpdate(sendActivity, doc.RootElement);
            sendActivity?.Stop();
            tracer.EndConnectActivity();

            var connectSpan = capturer.Find("connect");
            Assert.That(connectSpan, Is.Not.Null);
            Assert.That(connectSpan!.GetTag(Keys.GenAiVoiceInputAudioFormat), Is.EqualTo("pcm16"));
            Assert.That(connectSpan.GetTag(Keys.GenAiVoiceOutputAudioFormat), Is.EqualTo("g711_ulaw"));
        }

        [Test]
        public void EmitSystemInstructionsEvent_WhenContentEnabled_AddsEventToConnectSpan()
        {
            using var capturer = new ActivityCapturer();
            var tracer = new VoiceLiveTracer(new Uri("wss://example.azure.com"), enableContentRecordingOverride: true);
            tracer.StartConnectActivity();

            var sendActivity = tracer.StartSendActivity("session.update");
            using var doc = JsonDocument.Parse(
                @"{""type"":""session.update"",""session"":{""instructions"":""Be concise.""}}");
            tracer.EnrichSendSessionUpdate(sendActivity, doc.RootElement);
            sendActivity?.Stop();
            tracer.EndConnectActivity();

            var connectSpan = capturer.Find("connect");
            Assert.That(connectSpan, Is.Not.Null);
            var instrEvent = connectSpan!.Events.FirstOrDefault(e => e.Name == Keys.SystemInstructionEventName);
            Assert.That(instrEvent.Name, Is.EqualTo(Keys.SystemInstructionEventName), "gen_ai.system.instructions event must be added");
            var content = instrEvent.Tags.FirstOrDefault(t => t.Key == Keys.GenAiEventContent).Value as string;
            Assert.That(content, Does.Contain("Be concise."));
            Assert.That(content, Does.StartWith("[{\"role\":\"system\""));
        }

        [Test]
        public void EmitSystemInstructionsEvent_WhenContentDisabled_NoEventOnConnectSpan()
        {
            using var capturer = new ActivityCapturer();
            var tracer = new VoiceLiveTracer(new Uri("wss://example.azure.com"), enableContentRecordingOverride: false);
            tracer.StartConnectActivity();

            var sendActivity = tracer.StartSendActivity("session.update");
            using var doc = JsonDocument.Parse(
                @"{""type"":""session.update"",""session"":{""instructions"":""Be concise.""}}");
            tracer.EnrichSendSessionUpdate(sendActivity, doc.RootElement);
            sendActivity?.Stop();
            tracer.EndConnectActivity();

            var connectSpan = capturer.Find("connect");
            Assert.That(connectSpan, Is.Not.Null);
            bool hasInstrEvent = connectSpan!.Events.Any(e => e.Name == Keys.SystemInstructionEventName);
            Assert.That(hasInstrEvent, Is.False,
                "gen_ai.system.instructions event must not be emitted when content recording is off");
        }

        [Test]
        public void EnrichRecvSessionEvent_SetsAgentIdAndThreadIdOnConnectSpan()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var recvActivity = tracer.StartRecvActivity("session.created");
            using var doc = JsonDocument.Parse(
                @"{""type"":""session.created"",""session"":{""id"":""sess_agent"",""agent"":{""agent_id"":""agt-001"",""thread_id"":""thr-xyz""}}}");
            tracer.EnrichRecvSessionEvent(recvActivity, doc.RootElement);
            recvActivity?.Stop();
            tracer.EndConnectActivity();

            var connectSpan = capturer.Find("connect");
            Assert.That(connectSpan, Is.Not.Null);
            Assert.That(connectSpan!.GetTag(Keys.GenAiAgentId), Is.EqualTo("agt-001"),
                "agent_id must be back-filled to connect span");
            Assert.That(connectSpan.GetTag(Keys.GenAiAgentThreadId), Is.EqualTo("thr-xyz"),
                "thread_id must be back-filled to connect span");
        }

        [Test]
        public void EnrichRecvSessionEvent_SetsAudioFormatsOnConnectSpan()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var recvActivity = tracer.StartRecvActivity("session.created");
            using var doc = JsonDocument.Parse(
                @"{""type"":""session.created"",""session"":{""id"":""s1"",""input_audio_format"":""pcm16"",""output_audio_format"":""pcm16""}}");
            tracer.EnrichRecvSessionEvent(recvActivity, doc.RootElement);
            recvActivity?.Stop();
            tracer.EndConnectActivity();

            var connectSpan = capturer.Find("connect");
            Assert.That(connectSpan!.GetTag(Keys.GenAiVoiceInputAudioFormat), Is.EqualTo("pcm16"));
            Assert.That(connectSpan.GetTag(Keys.GenAiVoiceOutputAudioFormat), Is.EqualTo("pcm16"));
        }

        [Test]
        public void EnrichRecvSessionEvent_DoesNotSetResponseModelOnAnySpan()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var recvActivity = tracer.StartRecvActivity("session.created");
            using var doc = JsonDocument.Parse(
                @"{""type"":""session.created"",""session"":{""id"":""s1"",""model"":""gpt-4o""}}");
            tracer.EnrichRecvSessionEvent(recvActivity, doc.RootElement);
            recvActivity?.Stop();
            tracer.EndConnectActivity();

            var recvSpan = capturer.Find("recv session.created");
            var connectSpan = capturer.Find("connect");
            Assert.That(recvSpan!.GetTag(Keys.GenAiResponseModel), Is.Null,
                "gen_ai.response.model must not be set on recv session spans");
            Assert.That(connectSpan!.GetTag(Keys.GenAiResponseModel), Is.Null,
                "gen_ai.response.model must not be set on connect span");
        }

        // ─── Phase 3: error/rate_limits events, turn count fix, finish_reasons ──────

        [Test]
        public void OnRecvResponseDone_IncrementsTurnCount()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            tracer.OnRecvResponseDone();
            tracer.OnRecvResponseDone();
            tracer.OnRecvResponseDone();

            tracer.EndConnectActivity();

            var span = capturer.Find("connect");
            Assert.That(span!.Tags[Keys.GenAiVoiceTurnCount], Is.EqualTo(3L),
                "turn_count must be incremented on response.done, not speech_started");
        }

        [Test]
        public void EnrichRecvResponseDone_BackfillsFinishReasonsToConnectSpan()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var recvActivity = tracer.StartRecvActivity("response.done");
            using var doc = JsonDocument.Parse(
                @"{""type"":""response.done"",""response"":{""id"":""resp_1"",""status"":""completed"",""usage"":{""input_tokens"":10,""output_tokens"":20}}}");
            tracer.EnrichRecvResponseDone(recvActivity, doc.RootElement);
            recvActivity?.Stop();
            tracer.EndConnectActivity();

            var recvSpan = capturer.Find("recv response.done");
            Assert.That(recvSpan!.GetTag(Keys.GenAiResponseFinishReasons), Is.EqualTo("completed"),
                "finish_reasons must be on recv span");

            var connectSpan = capturer.Find("connect");
            Assert.That(connectSpan!.GetTag(Keys.GenAiResponseFinishReasons), Is.EqualTo("completed"),
                "finish_reasons must be back-filled to connect span");
        }

        [Test]
        public void EnrichRecvErrorEvent_SetsErrorStatusAndAddsSpanEvent()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var recvActivity = tracer.StartRecvActivity("error");
            using var doc = JsonDocument.Parse(
                @"{""type"":""error"",""error"":{""code"":""invalid_session"",""message"":""Session not found""}}");
            tracer.EnrichRecvErrorEvent(recvActivity, doc.RootElement);
            recvActivity?.Stop();
            tracer.EndConnectActivity();

            var span = capturer.Find("recv error");
            Assert.That(span, Is.Not.Null);
            Assert.That(span!.Status, Is.EqualTo(ActivityStatusCode.Error));
            Assert.That(span.Events.Count, Is.EqualTo(1));
            Assert.That(span.Events[0].Name, Is.EqualTo(Keys.VoiceErrorEventName));
            var code = span.Events[0].Tags.FirstOrDefault(t => t.Key == Keys.GenAiVoiceErrorCode).Value as string;
            var message = span.Events[0].Tags.FirstOrDefault(t => t.Key == Keys.ErrorMessage).Value as string;
            Assert.That(code, Is.EqualTo("invalid_session"));
            Assert.That(message, Is.EqualTo("Session not found"));
        }

        [Test]
        public void EnrichRecvErrorEvent_WithMissingErrorObject_DoesNotThrow()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var recvActivity = tracer.StartRecvActivity("error");
            using var doc = JsonDocument.Parse(@"{""type"":""error""}");
            Assert.DoesNotThrow(() => tracer.EnrichRecvErrorEvent(recvActivity, doc.RootElement));
            recvActivity?.Stop();
            tracer.EndConnectActivity();
        }

        [Test]
        public void AddRateLimitsEvent_WhenContentEnabled_AddsEventWithPayload()
        {
            using var capturer = new ActivityCapturer();
            var tracer = new VoiceLiveTracer(new Uri("wss://example.azure.com"), enableContentRecordingOverride: true);
            tracer.StartConnectActivity();

            var recvActivity = tracer.StartRecvActivity("rate_limits.updated");
            using var doc = JsonDocument.Parse(
                @"{""type"":""rate_limits.updated"",""rate_limits"":[{""name"":""requests"",""limit"":100,""remaining"":99}]}");
            tracer.AddRateLimitsEvent(recvActivity, doc.RootElement);
            recvActivity?.Stop();
            tracer.EndConnectActivity();

            var span = capturer.Find("recv rate_limits.updated");
            Assert.That(span, Is.Not.Null);
            Assert.That(span!.Events.Count, Is.EqualTo(1));
            Assert.That(span.Events[0].Name, Is.EqualTo(Keys.VoiceRateLimitsEventName));
            var content = span.Events[0].Tags.FirstOrDefault(t => t.Key == Keys.GenAiEventContent).Value as string;
            Assert.That(content, Does.Contain("requests"));
        }

        [Test]
        public void AddRateLimitsEvent_WhenContentDisabled_AddsEventWithoutPayload()
        {
            using var capturer = new ActivityCapturer();
            var tracer = new VoiceLiveTracer(new Uri("wss://example.azure.com"), enableContentRecordingOverride: false);
            tracer.StartConnectActivity();

            var recvActivity = tracer.StartRecvActivity("rate_limits.updated");
            using var doc = JsonDocument.Parse(
                @"{""type"":""rate_limits.updated"",""rate_limits"":[{""name"":""requests"",""limit"":100,""remaining"":99}]}");
            tracer.AddRateLimitsEvent(recvActivity, doc.RootElement);
            recvActivity?.Stop();
            tracer.EndConnectActivity();

            var span = capturer.Find("recv rate_limits.updated");
            Assert.That(span, Is.Not.Null);
            Assert.That(span!.Events.Count, Is.EqualTo(1), "event must be emitted even without content");
            Assert.That(span.Events[0].Name, Is.EqualTo(Keys.VoiceRateLimitsEventName));
            var content = span.Events[0].Tags.FirstOrDefault(t => t.Key == Keys.GenAiEventContent).Value;
            Assert.That(content, Is.Null, "payload must be omitted when content recording is off");
        }

        [Test]
        public async Task GetUpdatesAsync_ErrorEvent_SetsErrorStatusOnRecvSpan()
        {
            using var capturer = new ActivityCapturer();
            var session = CreateSession(out var fake);
            session._tracer.StartConnectActivity();

            fake.EnqueueTextMessage(
                @"{""type"":""error"",""event_id"":""e_err"",""error"":{""code"":""invalid_session"",""message"":""bad session""}}");

            await foreach (var _ in session.GetUpdatesAsync()) break;

            session._tracer.EndConnectActivity();

            var span = capturer.Find("recv error");
            Assert.That(span, Is.Not.Null, "error event should produce a recv span");
            Assert.That(span!.Status, Is.EqualTo(ActivityStatusCode.Error));
            Assert.That(span.Events.Any(e => e.Name == Keys.VoiceErrorEventName), Is.True);
        }

        [Test]
        public async Task GetUpdatesAsync_ResponseDone_IncrementsTurnCountOnConnectSpan()
        {
            using var capturer = new ActivityCapturer();
            var session = CreateSession(out var fake);
            session._tracer.StartConnectActivity();

            fake.EnqueueTextMessage(@"{
                ""type"": ""response.done"",
                ""event_id"": ""e_done"",
                ""response"": { ""id"": ""resp_1"", ""status"": ""completed"", ""usage"": { ""input_tokens"": 5, ""output_tokens"": 10 } }
            }");

            await foreach (var _ in session.GetUpdatesAsync()) break;

            session._tracer.EndConnectActivity();

            var connectSpan = capturer.Find("connect");
            Assert.That(connectSpan!.Tags[Keys.GenAiVoiceTurnCount], Is.EqualTo(1L));
            Assert.That(connectSpan.GetTag(Keys.GenAiResponseFinishReasons), Is.EqualTo("completed"),
                "finish_reasons back-filled to connect span from response.done");
        }

        // ─── Phase 4: structured content for done events ──────────────────────────

        [Test]
        public void ExtractDoneEventContent_ResponseTextDone_ReturnsTextObject()
        {
            using var doc = JsonDocument.Parse(@"{""type"":""response.text.done"",""text"":""Hello world""}");
            string result = VoiceLiveTracer.ExtractDoneEventContent("response.text.done", doc.RootElement);
            Assert.That(result, Is.Not.Null);
            using var parsed = JsonDocument.Parse(result);
            Assert.That(parsed.RootElement.GetProperty("text").GetString(), Is.EqualTo("Hello world"));
        }

        [Test]
        public void ExtractDoneEventContent_ResponseAudioTranscriptDone_ReturnsTranscriptObject()
        {
            using var doc = JsonDocument.Parse(@"{""type"":""response.audio_transcript.done"",""transcript"":""I am ready.""}");
            string result = VoiceLiveTracer.ExtractDoneEventContent("response.audio_transcript.done", doc.RootElement);
            Assert.That(result, Is.Not.Null);
            using var parsed = JsonDocument.Parse(result);
            Assert.That(parsed.RootElement.GetProperty("transcript").GetString(), Is.EqualTo("I am ready."));
        }

        [Test]
        public void ExtractDoneEventContent_FunctionCallArgumentsDone_ReturnsNameAndArguments()
        {
            using var doc = JsonDocument.Parse(
                @"{""type"":""response.function_call_arguments.done"",""name"":""get_weather"",""arguments"":""{}""}");
            string result = VoiceLiveTracer.ExtractDoneEventContent("response.function_call_arguments.done", doc.RootElement);
            Assert.That(result, Is.Not.Null);
            using var parsed = JsonDocument.Parse(result);
            Assert.That(parsed.RootElement.GetProperty("name").GetString(), Is.EqualTo("get_weather"));
            Assert.That(parsed.RootElement.TryGetProperty("arguments", out _), Is.True);
        }

        [Test]
        public void ExtractDoneEventContent_ContentPartDone_ReturnsTextAndTranscript()
        {
            using var doc = JsonDocument.Parse(
                @"{""type"":""response.content_part.done"",""part"":{""type"":""text"",""text"":""Hi"",""transcript"":""Hi""}}");
            string result = VoiceLiveTracer.ExtractDoneEventContent("response.content_part.done", doc.RootElement);
            Assert.That(result, Is.Not.Null);
            using var parsed = JsonDocument.Parse(result);
            Assert.That(parsed.RootElement.GetProperty("text").GetString(), Is.EqualTo("Hi"));
            Assert.That(parsed.RootElement.GetProperty("transcript").GetString(), Is.EqualTo("Hi"));
        }

        [Test]
        public void ExtractDoneEventContent_ContentPartDone_TextOnly_OmitsTranscript()
        {
            using var doc = JsonDocument.Parse(
                @"{""type"":""response.content_part.done"",""part"":{""type"":""text"",""text"":""Hi""}}");
            string result = VoiceLiveTracer.ExtractDoneEventContent("response.content_part.done", doc.RootElement);
            Assert.That(result, Is.Not.Null);
            using var parsed = JsonDocument.Parse(result);
            Assert.That(parsed.RootElement.TryGetProperty("text", out _), Is.True);
            Assert.That(parsed.RootElement.TryGetProperty("transcript", out _), Is.False);
        }

        [Test]
        public void ExtractDoneEventContent_ResponseOutputItemDone_ReturnsMessagesArray()
        {
            using var doc = JsonDocument.Parse(
                @"{""type"":""response.output_item.done"",""item"":{""id"":""item_1"",""type"":""message""}}");
            string result = VoiceLiveTracer.ExtractDoneEventContent("response.output_item.done", doc.RootElement);
            Assert.That(result, Is.Not.Null);
            using var parsed = JsonDocument.Parse(result);
            var messages = parsed.RootElement.GetProperty("messages");
            Assert.That(messages.ValueKind, Is.EqualTo(JsonValueKind.Array));
            Assert.That(messages.GetArrayLength(), Is.EqualTo(1));
            Assert.That(messages[0].GetProperty("id").GetString(), Is.EqualTo("item_1"));
        }

        [Test]
        public void ExtractDoneEventContent_ResponseDone_ReturnsMessagesArray()
        {
            using var doc = JsonDocument.Parse(@"{
                ""type"": ""response.done"",
                ""response"": {
                    ""id"": ""resp_1"",
                    ""output"": [
                        {""id"":""item_a"",""type"":""message""},
                        {""id"":""item_b"",""type"":""message""}
                    ]
                }
            }");
            string result = VoiceLiveTracer.ExtractDoneEventContent("response.done", doc.RootElement);
            Assert.That(result, Is.Not.Null);
            using var parsed = JsonDocument.Parse(result);
            var messages = parsed.RootElement.GetProperty("messages");
            Assert.That(messages.GetArrayLength(), Is.EqualTo(2));
        }

        [Test]
        public void ExtractDoneEventContent_NonDoneEvent_ReturnsNull()
        {
            using var doc = JsonDocument.Parse(@"{""type"":""session.created"",""session"":{""id"":""s1""}}");
            string result = VoiceLiveTracer.ExtractDoneEventContent("session.created", doc.RootElement);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void AddRecvContentEvent_WithForceContent_EmitsContentWhenRecordingDisabled()
        {
            using var capturer = new ActivityCapturer();
            var tracer = new VoiceLiveTracer(new Uri("wss://example.azure.com"), enableContentRecordingOverride: false);
            tracer.StartConnectActivity();

            var recvActivity = tracer.StartRecvActivity("response.text.done");
            tracer.AddRecvContentEvent(recvActivity, "response.text.done", jsonContent: null, forceContent: "{\"text\":\"hello\"}");
            recvActivity?.Stop();
            tracer.EndConnectActivity();

            var span = capturer.Find("recv response.text.done");
            Assert.That(span, Is.Not.Null);
            Assert.That(span!.Events.Count, Is.EqualTo(1));
            var content = span.Events[0].Tags.FirstOrDefault(t => t.Key == Keys.GenAiEventContent).Value as string;
            Assert.That(content, Is.EqualTo("{\"text\":\"hello\"}"),
                "forceContent is emitted unconditionally even when content recording is disabled");
        }

        [Test]
        public async Task GetUpdatesAsync_ResponseTextDone_EmitsStructuredContent()
        {
            using var capturer = new ActivityCapturer();
            var session = CreateSession(out var fake);
            session._tracer.StartConnectActivity();

            fake.EnqueueTextMessage(
                @"{""type"":""response.text.done"",""event_id"":""e_td"",""text"":""Hello!""}");

            await foreach (var _ in session.GetUpdatesAsync()) break;

            session._tracer.EndConnectActivity();

            var span = capturer.Find("recv response.text.done");
            Assert.That(span, Is.Not.Null, "response.text.done should produce a recv span");
            Assert.That(span!.Events.Count, Is.EqualTo(1));
            var content = span.Events[0].Tags.FirstOrDefault(t => t.Key == Keys.GenAiEventContent).Value as string;
            Assert.That(content, Does.Contain("Hello!"), "structured text content must be emitted unconditionally");
        }

        // ─── Phase 1: ID tracking & propagation ──────────────────────────────────

        [Test]
        public void ExtractRecvIds_SetsTopLevelIdsOnActivity()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var activity = tracer.StartRecvActivity("response.output_item.added");
            using var doc = JsonDocument.Parse(
                @"{""type"":""response.output_item.added"",""response_id"":""resp_abc"",""call_id"":""call_123"",""output_index"":2,""item"":{""id"":""item_xyz""}}");
            tracer.ExtractRecvIds(activity, doc.RootElement, "response.output_item.added");
            activity?.Stop();
            tracer.EndConnectActivity();

            var span = capturer.Find("recv response.output_item.added");
            Assert.That(span!.GetTag(Keys.GenAiResponseId), Is.EqualTo("resp_abc"));
            Assert.That(span.GetTag(Keys.GenAiVoiceCallId), Is.EqualTo("call_123"));
            Assert.That(span.GetTag(Keys.GenAiVoiceOutputIndex), Is.EqualTo("2"));
            Assert.That(span.GetTag(Keys.GenAiVoiceItemId), Is.EqualTo("item_xyz"));
        }

        [Test]
        public void ExtractRecvIds_ConversationId_BackfillsToConnectSpan()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var activity = tracer.StartRecvActivity("response.done");
            using var doc = JsonDocument.Parse(
                @"{""type"":""response.done"",""response"":{""id"":""resp_1"",""conversation_id"":""conv_abc""}}");
            tracer.ExtractRecvIds(activity, doc.RootElement, "response.done");
            activity?.Stop();
            tracer.EndConnectActivity();

            var recvSpan = capturer.Find("recv response.done");
            var connectSpan = capturer.Find("connect");
            Assert.That(recvSpan!.GetTag(Keys.GenAiConversationId), Is.EqualTo("conv_abc"));
            Assert.That(connectSpan!.GetTag(Keys.GenAiConversationId), Is.EqualTo("conv_abc"),
                "conversation_id must be back-filled to connect span");
        }

        [Test]
        public void ExtractSendIds_ResponseCancel_SetsResponseId()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var activity = tracer.StartSendActivity("response.cancel");
            using var doc = JsonDocument.Parse(@"{""type"":""response.cancel"",""response_id"":""resp_to_cancel""}");
            tracer.ExtractSendIds(activity, doc.RootElement, "response.cancel");
            activity?.Stop();
            tracer.EndConnectActivity();

            var span = capturer.Find("send response.cancel");
            Assert.That(span!.GetTag(Keys.GenAiResponseId), Is.EqualTo("resp_to_cancel"));
        }

        [Test]
        public void ExtractSendIds_ConversationItemCreate_SetsCallIdAndPreviousItemId()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var activity = tracer.StartSendActivity("conversation.item.create");
            using var doc = JsonDocument.Parse(
                @"{""type"":""conversation.item.create"",""previous_item_id"":""prev_123"",""item"":{""call_id"":""call_abc""}}");
            tracer.ExtractSendIds(activity, doc.RootElement, "conversation.item.create");
            activity?.Stop();
            tracer.EndConnectActivity();

            var span = capturer.Find("send conversation.item.create");
            Assert.That(span!.GetTag(Keys.GenAiVoicePreviousItemId), Is.EqualTo("prev_123"));
            Assert.That(span.GetTag(Keys.GenAiVoiceCallId), Is.EqualTo("call_abc"));
        }

        [Test]
        public void CloseActivity_IsParentedToConnectActivity()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var closeActivity = tracer.StartCloseActivity();
            closeActivity?.Stop();
            tracer.EndConnectActivity();

            var connectSpan = capturer.Find("connect");
            var closeSpan = capturer.Find("close");
            Assert.That(closeSpan, Is.Not.Null, "close span should be recorded");
            Assert.That(closeSpan!.TraceId, Is.EqualTo(connectSpan!.TraceId), "should be in same trace");
            Assert.That(closeSpan.ParentSpanId, Is.EqualTo(connectSpan.SpanId), "close span should be child of connect span");
        }

        // ─── Phase 2: session config — supplementary ──────────────────────────────

        [Test]
        public void EnrichSendSessionUpdate_SetsSampleRatesOnConnectSpan()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var sendActivity = tracer.StartSendActivity("session.update");
            using var doc = JsonDocument.Parse(
                @"{""type"":""session.update"",""session"":{""input_audio_sample_rate"":24000,""output_audio_sample_rate"":24000}}");
            tracer.EnrichSendSessionUpdate(sendActivity, doc.RootElement);
            sendActivity?.Stop();
            tracer.EndConnectActivity();

            var connectSpan = capturer.Find("connect");
            Assert.That(connectSpan!.GetTag(Keys.GenAiVoiceInputSampleRate), Is.EqualTo("24000"));
            Assert.That(connectSpan.GetTag(Keys.GenAiVoiceOutputSampleRate), Is.EqualTo("24000"));
        }

        [Test]
        public void EnrichRecvSessionEvent_DoesNotSetAudioFormatsOnRecvSpan()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var recvActivity = tracer.StartRecvActivity("session.created");
            using var doc = JsonDocument.Parse(
                @"{""type"":""session.created"",""session"":{""id"":""s1"",""input_audio_format"":""pcm16"",""output_audio_format"":""pcm16""}}");
            tracer.EnrichRecvSessionEvent(recvActivity, doc.RootElement);
            recvActivity?.Stop();
            tracer.EndConnectActivity();

            var recvSpan = capturer.Find("recv session.created");
            Assert.That(recvSpan!.GetTag(Keys.GenAiVoiceInputAudioFormat), Is.Null,
                "audio format must NOT be set on recv session spans — connect span only");
            Assert.That(recvSpan.GetTag(Keys.GenAiVoiceOutputAudioFormat), Is.Null,
                "audio format must NOT be set on recv session spans — connect span only");
        }

        [Test]
        public void EnrichSendSessionUpdate_DoesNotSetSystemInstructionsOnSendSpan()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var sendActivity = tracer.StartSendActivity("session.update");
            using var doc = JsonDocument.Parse(
                @"{""type"":""session.update"",""session"":{""instructions"":""Be concise.""}}");
            tracer.EnrichSendSessionUpdate(sendActivity, doc.RootElement);
            sendActivity?.Stop();
            tracer.EndConnectActivity();

            var sendSpan = capturer.Find("send session.update");
            Assert.That(sendSpan!.GetTag(Keys.GenAiSystemMessage), Is.Null,
                "gen_ai.system_instructions must not be on the send span");
            var connectSpan = capturer.Find("connect");
            Assert.That(connectSpan!.GetTag(Keys.GenAiSystemMessage), Is.EqualTo("Be concise."),
                "gen_ai.system_instructions must be on the connect span");
        }

        // ─── Phase 3: counter fix & recv coverage — supplementary ─────────────────

        [Test]
        public void TryRecordFirstTokenLatency_FlushesToConnectSpanAtClose()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            tracer.OnSendResponseCreate();
            double? latencyOnRecvSpan = tracer.TryRecordFirstTokenLatency();
            tracer.EndConnectActivity();

            var connectSpan = capturer.Find("connect");
            Assert.That(connectSpan, Is.Not.Null);
            Assert.That(connectSpan!.Tags.ContainsKey(Keys.GenAiVoiceFirstTokenLatencyMs), Is.True,
                "first_token_latency_ms must be flushed to connect span at close");
            double connectLatency = Convert.ToDouble(connectSpan.Tags[Keys.GenAiVoiceFirstTokenLatencyMs]);
            Assert.That(connectLatency, Is.EqualTo(latencyOnRecvSpan!.Value).Within(0.001));
        }

        [Test]
        public async Task GetUpdatesAsync_ResponseCreated_ProducesRecvSpan()
        {
            using var capturer = new ActivityCapturer();
            var session = CreateSession(out var fake);
            session._tracer.StartConnectActivity();

            fake.EnqueueTextMessage(
                @"{""type"":""response.created"",""event_id"":""e_rc"",""response"":{""id"":""resp_rc"",""conversation_id"":""conv_rc""}}");

            await foreach (var _ in session.GetUpdatesAsync()) break;

            session._tracer.EndConnectActivity();

            var span = capturer.Find("recv response.created");
            Assert.That(span, Is.Not.Null, "response.created should produce a recv span");
            Assert.That(span!.GetTag(Keys.GenAiResponseId), Is.EqualTo("resp_rc"),
                "response_id must be extracted from response.created");
        }

        // ─── Phase 2: agent name recv fallback ────────────────────────────────────

        [Test]
        public void EnrichRecvSessionEvent_SetsAgentNameOnConnectSpan_WhenNotSetFromUrl()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer(); // no agent URL params → _agentName is null
            tracer.StartConnectActivity();

            var recvActivity = tracer.StartRecvActivity("session.created");
            using var doc = JsonDocument.Parse(
                @"{""type"":""session.created"",""session"":{""id"":""sess_n"",""agent"":{""agent_id"":""agt-001"",""name"":""MyAgent""}}}");
            tracer.EnrichRecvSessionEvent(recvActivity, doc.RootElement);
            recvActivity?.Stop();
            tracer.EndConnectActivity();

            var connectSpan = capturer.Find("connect");
            Assert.That(connectSpan, Is.Not.Null);
            Assert.That(connectSpan!.GetTag(Keys.GenAiAgentName), Is.EqualTo("MyAgent"),
                "agent.name from session event must be back-filled to connect span when URL param not set");
        }

        // ─── Phase 4: structured content — supplementary ──────────────────────────

        [Test]
        public async Task GetUpdatesAsync_RateLimitsUpdated_ProducesRecvSpanWithEvent()
        {
            using var capturer = new ActivityCapturer();
            var session = CreateSession(out var fake);
            session._tracer.StartConnectActivity();

            fake.EnqueueTextMessage(
                @"{""type"":""rate_limits.updated"",""event_id"":""e_rl"",""rate_limits"":[{""name"":""requests"",""limit"":100,""remaining"":99}]}");

            await foreach (var _ in session.GetUpdatesAsync()) break;

            session._tracer.EndConnectActivity();

            var span = capturer.Find("recv rate_limits.updated");
            Assert.That(span, Is.Not.Null, "rate_limits.updated should produce a recv span");
            Assert.That(span!.Events.Any(e => e.Name == Keys.VoiceRateLimitsEventName), Is.True,
                "rate_limits.updated span must have the rate limits event");
        }

        // ─── Phase 5: metrics ─────────────────────────────────────────────────────

        /// <summary>
        /// Subscribes to the "Azure.AI.VoiceLive" meter and collects measurements by instrument name.
        /// </summary>
        private sealed class MeterCapturer : IDisposable
        {
            private readonly MeterListener _listener;
            public readonly List<(double Value, Dictionary<string, object> Tags)> Durations = new();
            public readonly List<(long Value, Dictionary<string, object> Tags)> Tokens = new();
            private readonly object _lock = new();

            public MeterCapturer()
            {
                _listener = new MeterListener
                {
                    InstrumentPublished = (instrument, listener) =>
                    {
                        if (instrument.Meter.Name == "Azure.AI.VoiceLive")
                            listener.EnableMeasurementEvents(instrument);
                    }
                };
                _listener.SetMeasurementEventCallback<double>((instrument, value, tags, _) =>
                {
                    if (instrument.Name == "gen_ai.client.operation.duration")
                    {
                        var d = new Dictionary<string, object>();
                        foreach (var kv in tags) d[kv.Key] = kv.Value;
                        lock (_lock) Durations.Add((value, d));
                    }
                });
                _listener.SetMeasurementEventCallback<long>((instrument, value, tags, _) =>
                {
                    if (instrument.Name == "gen_ai.client.token.usage")
                    {
                        var d = new Dictionary<string, object>();
                        foreach (var kv in tags) d[kv.Key] = kv.Value;
                        lock (_lock) Tokens.Add((value, d));
                    }
                });
                _listener.Start();
            }

            public void Dispose() => _listener.Dispose();
        }

        [Test]
        public void EndConnectActivity_RecordsOperationDurationMetric()
        {
            using var meter = new MeterCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();
            tracer.EndConnectActivity();

            Assert.That(meter.Durations, Has.Count.EqualTo(1), "one duration measurement expected");
            var (value, tags) = meter.Durations[0];
            Assert.That(value, Is.GreaterThanOrEqualTo(0), "duration must be non-negative");
            Assert.That(tags[Keys.GenAiSystem], Is.EqualTo(Keys.GenAiSystemValue));
            Assert.That(tags[Keys.GenAiProviderName], Is.EqualTo(Keys.GenAiProviderValue));
            Assert.That(tags[Keys.GenAiOperationName], Is.EqualTo(Keys.OperationNameConnect));
        }

        [Test]
        public void EndConnectActivity_WithTokens_RecordsTokenUsageMetric()
        {
            using var meter = new MeterCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            using var doc = JsonDocument.Parse(
                @"{""type"":""response.done"",""response"":{""id"":""r1"",""status"":""completed"",""usage"":{""input_tokens"":100,""output_tokens"":50}}}");
            tracer.EnrichRecvResponseDone(null, doc.RootElement);

            tracer.EndConnectActivity();

            Assert.That(meter.Tokens, Has.Count.EqualTo(2), "input + output token measurements expected");
            var inputRec = meter.Tokens.FirstOrDefault(t => t.Tags.ContainsKey(Keys.GenAiTokenType) && t.Tags[Keys.GenAiTokenType] as string == "input");
            var outputRec = meter.Tokens.FirstOrDefault(t => t.Tags.ContainsKey(Keys.GenAiTokenType) && t.Tags[Keys.GenAiTokenType] as string == "output");
            Assert.That(inputRec.Value, Is.EqualTo(100), "input token count");
            Assert.That(outputRec.Value, Is.EqualTo(50), "output token count");
        }

        [Test]
        public void EndConnectActivity_MultipleResponseDone_AccumulatesTokens()
        {
            using var meter = new MeterCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            using var doc1 = JsonDocument.Parse(
                @"{""type"":""response.done"",""response"":{""id"":""r1"",""status"":""completed"",""usage"":{""input_tokens"":100,""output_tokens"":50}}}");
            using var doc2 = JsonDocument.Parse(
                @"{""type"":""response.done"",""response"":{""id"":""r2"",""status"":""completed"",""usage"":{""input_tokens"":200,""output_tokens"":75}}}");
            tracer.EnrichRecvResponseDone(null, doc1.RootElement);
            tracer.EnrichRecvResponseDone(null, doc2.RootElement);

            tracer.EndConnectActivity();

            var inputRec = meter.Tokens.FirstOrDefault(t => t.Tags[Keys.GenAiTokenType] as string == "input");
            var outputRec = meter.Tokens.FirstOrDefault(t => t.Tags[Keys.GenAiTokenType] as string == "output");
            Assert.That(inputRec.Value, Is.EqualTo(300), "total input tokens across turns");
            Assert.That(outputRec.Value, Is.EqualTo(125), "total output tokens across turns");
        }

        // ─── Per-message: message_size ────────────────────────────────────────────

        [Test]
        public async Task SendCommandAsync_SessionUpdate_RecordsMessageSize()
        {
            using var capturer = new ActivityCapturer();
            var session = CreateSession(out _);
            session._tracer.StartConnectActivity();

            await session.ConfigureSessionAsync(new VoiceLiveSessionOptions());

            session._tracer.EndConnectActivity();

            var span = capturer.Find("send session.update");
            Assert.That(span, Is.Not.Null, "session.update should produce a send span");
            Assert.That(span!.Tags.ContainsKey(Keys.GenAiVoiceMessageSize), Is.True,
                "gen_ai.voice.message_size must be set on send spans");
            Assert.That(Convert.ToInt64(span.Tags[Keys.GenAiVoiceMessageSize]), Is.GreaterThan(0L),
                "message_size must be positive");
        }

        [Test]
        public async Task GetUpdatesAsync_SessionCreated_RecordsMessageSize()
        {
            using var capturer = new ActivityCapturer();
            var session = CreateSession(out var fake);
            session._tracer.StartConnectActivity();

            string msg = @"{""type"":""session.created"",""event_id"":""e_ms"",""session"":{""id"":""sess_ms"",""model"":""gpt-4o""}}";
            fake.EnqueueTextMessage(msg);

            await foreach (var _ in session.GetUpdatesAsync()) break;

            session._tracer.EndConnectActivity();

            var span = capturer.Find("recv session.created");
            Assert.That(span, Is.Not.Null);
            Assert.That(span!.Tags.ContainsKey(Keys.GenAiVoiceMessageSize), Is.True,
                "gen_ai.voice.message_size must be set on recv spans");
            Assert.That(Convert.ToInt64(span.Tags[Keys.GenAiVoiceMessageSize]), Is.GreaterThan(0L),
                "message_size must be positive");
        }

        // ─── ID extraction: previous_item_id on recv conversation.item.created ───

        [Test]
        public void ExtractRecvIds_ConversationItemCreated_SetsPreviousItemIdAndItemId()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var activity = tracer.StartRecvActivity("conversation.item.created");
            using var doc = JsonDocument.Parse(
                @"{""type"":""conversation.item.created"",""previous_item_id"":""prev_abc"",""item"":{""id"":""item_xyz"",""call_id"":""call_qq""}}");
            tracer.ExtractRecvIds(activity, doc.RootElement, "conversation.item.created");
            activity?.Stop();
            tracer.EndConnectActivity();

            var span = capturer.Find("recv conversation.item.created");
            Assert.That(span!.GetTag(Keys.GenAiVoicePreviousItemId), Is.EqualTo("prev_abc"),
                "previous_item_id must be extracted from conversation.item.created");
            Assert.That(span.GetTag(Keys.GenAiVoiceItemId), Is.EqualTo("item_xyz"),
                "item.id must be extracted from item-bearing events");
            Assert.That(span.GetTag(Keys.GenAiVoiceCallId), Is.EqualTo("call_qq"),
                "item.call_id must be extracted from item-bearing events");
        }

        // ─── MCP approval attributes on recv/send ─────────────────────────────────

        [Test]
        public void ExtractRecvIds_OutputItemAddedWithApproval_SetsApprovalAttributes()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var activity = tracer.StartRecvActivity("response.output_item.added");
            using var doc = JsonDocument.Parse(
                @"{""type"":""response.output_item.added"",""item"":{""id"":""item_appr"",""approval_request_id"":""appr_123"",""approve"":true}}");
            tracer.ExtractRecvIds(activity, doc.RootElement, "response.output_item.added");
            activity?.Stop();
            tracer.EndConnectActivity();

            var span = capturer.Find("recv response.output_item.added");
            Assert.That(span!.GetTag(Keys.GenAiVoiceMcpApprovalRequestId), Is.EqualTo("appr_123"),
                "approval_request_id must be extracted from item-bearing events");
            Assert.That(span.Tags[Keys.GenAiVoiceMcpApprove], Is.EqualTo(true),
                "approve must be extracted from item-bearing events");
        }

        [Test]
        public void ExtractSendIds_ConversationItemCreate_SetsApprovalAttributes()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var activity = tracer.StartSendActivity("conversation.item.create");
            using var doc = JsonDocument.Parse(
                @"{""type"":""conversation.item.create"",""item"":{""approval_request_id"":""appr_456"",""approve"":false}}");
            tracer.ExtractSendIds(activity, doc.RootElement, "conversation.item.create");
            activity?.Stop();
            tracer.EndConnectActivity();

            var span = capturer.Find("send conversation.item.create");
            Assert.That(span!.GetTag(Keys.GenAiVoiceMcpApprovalRequestId), Is.EqualTo("appr_456"),
                "approval_request_id must be extracted from MCP approval response sends");
            Assert.That(span.Tags[Keys.GenAiVoiceMcpApprove], Is.EqualTo(false),
                "approve=false must be extracted from MCP approval response sends");
        }

        // ─── D5 fix: close span model + session_id ────────────────────────────────

        [Test]
        public void CloseActivity_WithModelEndpoint_HasModelAttribute()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer("wss://example.azure.com/realtime?model=gpt-4o-realtime-preview");
            tracer.StartConnectActivity();

            var closeActivity = tracer.StartCloseActivity();
            closeActivity?.Stop();
            tracer.EndConnectActivity();

            var span = capturer.Find("close");
            Assert.That(span, Is.Not.Null);
            Assert.That(span!.GetTag(Keys.GenAiRequestModel), Is.EqualTo("gpt-4o-realtime-preview"),
                "close span must carry gen_ai.request.model");
        }

        [Test]
        public void CloseActivity_AfterSessionCreated_HasSessionIdAttribute()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            // Back-fill session ID via session.created recv
            var recvActivity = tracer.StartRecvActivity("session.created");
            using var doc = JsonDocument.Parse(
                @"{""type"":""session.created"",""session"":{""id"":""sess_close_test""}}");
            tracer.EnrichRecvSessionEvent(recvActivity, doc.RootElement);
            recvActivity?.Stop();

            var closeActivity = tracer.StartCloseActivity();
            closeActivity?.Stop();
            tracer.EndConnectActivity();

            var span = capturer.Find("close");
            Assert.That(span, Is.Not.Null);
            Assert.That(span!.GetTag(Keys.GenAiVoiceSessionId), Is.EqualTo("sess_close_test"),
                "close span must carry gen_ai.voice.session_id once session is known");
        }

        [Test]
        public void CloseActivity_BeforeSessionCreated_NoSessionIdAttribute()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            // No session.created — session_id is still null
            var closeActivity = tracer.StartCloseActivity();
            closeActivity?.Stop();
            tracer.EndConnectActivity();

            var span = capturer.Find("close");
            Assert.That(span, Is.Not.Null);
            Assert.That(span!.GetTag(Keys.GenAiVoiceSessionId), Is.Null,
                "close span must not emit session_id before session.created is received");
        }

        [Test]
        public void CloseActivity_AfterResponseDone_HasConversationIdAttribute()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            // Back-fill conversation ID via response.done recv
            var recvActivity = tracer.StartRecvActivity("response.done");
            using var doc = JsonDocument.Parse(
                @"{""type"":""response.done"",""response"":{""id"":""resp_1"",""conversation_id"":""conv_abc123"",""status"":""completed"",""output"":[]}}");
            tracer.ExtractRecvIds(recvActivity, doc.RootElement, "response.done");
            recvActivity?.Stop();

            var closeActivity = tracer.StartCloseActivity();
            closeActivity?.Stop();
            tracer.EndConnectActivity();

            var span = capturer.Find("close");
            Assert.That(span, Is.Not.Null);
            Assert.That(span!.GetTag(Keys.GenAiConversationId), Is.EqualTo("conv_abc123"),
                "close span must carry gen_ai.conversation.id once conversation ID is known");
        }

        // ─── D14 fix: item_id on content_part spans ───────────────────────────────

        [Test]
        public void ExtractRecvIds_ContentPartAdded_SetsItemId()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var activity = tracer.StartRecvActivity("response.content_part.added");
            using var doc = JsonDocument.Parse(
                @"{""type"":""response.content_part.added"",""response_id"":""resp_1"",""item_id"":""item_cp"",""output_index"":0,""content_index"":0}");
            tracer.ExtractRecvIds(activity, doc.RootElement, "response.content_part.added");
            activity?.Stop();
            tracer.EndConnectActivity();

            var span = capturer.Find("recv response.content_part.added");
            Assert.That(span!.GetTag(Keys.GenAiVoiceItemId), Is.EqualTo("item_cp"),
                "item_id must be extracted from response.content_part.added");
            Assert.That(span.GetTag(Keys.GenAiResponseId), Is.EqualTo("resp_1"),
                "response_id must also be extracted from response.content_part.added");
        }

        [Test]
        public void ExtractRecvIds_ContentPartDone_SetsItemId()
        {
            using var capturer = new ActivityCapturer();
            var tracer = CreateTracer();
            tracer.StartConnectActivity();

            var activity = tracer.StartRecvActivity("response.content_part.done");
            using var doc = JsonDocument.Parse(
                @"{""type"":""response.content_part.done"",""response_id"":""resp_2"",""item_id"":""item_cpd"",""output_index"":1,""content_index"":0}");
            tracer.ExtractRecvIds(activity, doc.RootElement, "response.content_part.done");
            activity?.Stop();
            tracer.EndConnectActivity();

            var span = capturer.Find("recv response.content_part.done");
            Assert.That(span!.GetTag(Keys.GenAiVoiceItemId), Is.EqualTo("item_cpd"),
                "item_id must be extracted from response.content_part.done");
        }
    }
}
