// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// LIVE telemetry tests — mirrors test_live_realtime_telemetry.py (Python PR #47324).
// Verifies that real OpenTelemetry spans are emitted for the connect operation
// and for received/sent session events over a live VoiceLive session.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    public class TelemetryLiveTests : VoiceLiveTestBase
    {
        public TelemetryLiveTests() : base(true) { }
        public TelemetryLiveTests(bool isAsync) : base(isAsync) { }

        // -----------------------------------------------------------------------
        // Mirrors: test_telemetry_traces_connect_and_session_updated
        // Verifies: connect, send session.update, and recv session.updated spans
        // are all emitted with correct attributes and parent-child hierarchy.
        // -----------------------------------------------------------------------
        [LiveOnly]
        [TestCase]
        public async Task TelemetryTracesConnectAndSessionUpdated()
        {
            var activities = new ConcurrentBag<Activity>();

            using var listener = new ActivityListener
            {
                ShouldListenTo = source => source.Name == "Azure.AI.VoiceLive",
                Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                    ActivitySamplingResult.AllDataAndRecorded,
                ActivityStopped = activity => activities.Add(activity),
            };
            ActivitySource.AddActivityListener(listener);

            var client = GetLiveClient();
            var options = new VoiceLiveSessionOptions
            {
                Model = TestEnvironment.ModelName,
            };
            options.Modalities.Clear();
            options.Modalities.Add(InteractionModality.Text);
            options.Modalities.Add(InteractionModality.Audio);

            await using (var session = await client.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false))
            {
                var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();
                await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
                await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);
            }
            // Session disposed — connect span has now stopped.

            var spanNames = activities.Select(a => a.DisplayName).ToList();

            var connectSpan = activities.FirstOrDefault(a => a.DisplayName == "connect");
            var recvSpan    = activities.FirstOrDefault(a => a.DisplayName == "recv session.updated");
            var sendSpan    = activities.FirstOrDefault(a => a.DisplayName == "send session.update");

            Assert.IsNotNull(connectSpan, $"Expected 'connect' span. Got: [{string.Join(", ", spanNames)}]");
            Assert.IsNotNull(recvSpan,    $"Expected 'recv session.updated'. Got: [{string.Join(", ", spanNames)}]");
            Assert.IsNotNull(sendSpan,    $"Expected 'send session.update'. Got: [{string.Join(", ", spanNames)}]");

            // Verify connect span carries standard GenAI attributes.
            Assert.AreEqual("connect", connectSpan!.GetTagItem("gen_ai.operation.name")?.ToString(),
                "connect span must have gen_ai.operation.name = 'connect'");
            Assert.AreEqual(TestEnvironment.ModelName, connectSpan.GetTagItem("gen_ai.request.model")?.ToString(),
                "connect span must carry gen_ai.request.model");
            Assert.IsNotNull(connectSpan.GetTagItem("server.address"),
                "connect span must carry server.address");
            Assert.IsNotNull(connectSpan.GetTagItem("server.port"),
                "connect span must carry server.port");

            // Verify parent-child hierarchy: recv and send spans are children of connect.
            Assert.AreEqual(connectSpan.SpanId, recvSpan!.ParentSpanId,
                "recv session.updated span must be a child of the connect span");
            Assert.AreEqual(connectSpan.SpanId, sendSpan!.ParentSpanId,
                "send session.update span must be a child of the connect span");
        }

        // -----------------------------------------------------------------------
        // Mirrors: test_telemetry_content_recording_gate
        // Verifies: gen_ai.event.content on the send span is only present when
        // content recording is enabled (OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT).
        // -----------------------------------------------------------------------
        [LiveOnly]
        [TestCase]
        public async Task TelemetryContentRecordingGate()
        {
            var activities = new ConcurrentBag<Activity>();

            using var listener = new ActivityListener
            {
                ShouldListenTo = source => source.Name == "Azure.AI.VoiceLive",
                Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                    ActivitySamplingResult.AllDataAndRecorded,
                ActivityStopped = activity => activities.Add(activity),
            };
            ActivitySource.AddActivityListener(listener);

            // Read the current content-recording state from the env var (matches Python: reads current state).
            var rawFlag = Environment.GetEnvironmentVariable("OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT")
                       ?? Environment.GetEnvironmentVariable("AZURE_TRACING_GEN_AI_CONTENT_RECORDING_ENABLED")
                       ?? "false";
            bool contentRecordingEnabled = rawFlag.Equals("true", StringComparison.OrdinalIgnoreCase);

            var client = GetLiveClient();
            var options = new VoiceLiveSessionOptions
            {
                Model = TestEnvironment.ModelName,
            };
            options.Modalities.Clear();
            options.Modalities.Add(InteractionModality.Text);
            options.Modalities.Add(InteractionModality.Audio);

            await using (var session = await client.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false))
            {
                var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();
                await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
                await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);
            }

            var sendSpan = activities.FirstOrDefault(a => a.DisplayName == "send session.update");
            Assert.IsNotNull(sendSpan, "Expected 'send session.update' span");

            // Check whether gen_ai.event.content appears on the span events.
            bool hasContent = sendSpan!.Events.Any(evt =>
                evt.Tags.Any(t => t.Key == "gen_ai.event.content" && t.Value != null));

            if (contentRecordingEnabled)
            {
                Assert.IsTrue(hasContent,
                    "Content recording is enabled but gen_ai.event.content was not captured on the send span");
            }
            else
            {
                Assert.IsFalse(hasContent,
                    "Content recording is disabled but gen_ai.event.content was captured on the send span");
            }
        }
    }
}
