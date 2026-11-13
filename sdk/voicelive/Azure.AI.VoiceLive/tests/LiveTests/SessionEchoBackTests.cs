// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// LIVE session echo-back tests — mirrors Java PR #49347 VoiceLiveSessionTests additions.
// Verifies that session configuration sent to the server is echoed back correctly
// in the session.updated event.

using System;
using System.ClientModel.Primitives;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    public class SessionEchoBackTests : VoiceLiveTestBase
    {
        public SessionEchoBackTests() : base(true) { }
        public SessionEchoBackTests(bool isAsync) : base(isAsync) { }

        // -----------------------------------------------------------------------
        // Mirrors: testReasoningEffortIsEchoedInSessionUpdated (Java)
        // Verifies: ReasoningEffort sent in session.update is echoed back by the
        // server in the session.updated event.
        // -----------------------------------------------------------------------
        [LiveOnly]
        [TestCase]
        public async Task ReasoningEffortIsEchoedInSessionUpdated()
        {
            var client = GetLiveClient();

            var options = new VoiceLiveSessionOptions
            {
                Model = TestEnvironment.ModelName,
                ReasoningEffort = ReasoningEffort.Low,
            };
            options.Modalities.Clear();
            options.Modalities.Add(InteractionModality.Text);

            await using var session = await client.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();
            await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            var updated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            Assert.IsNotNull(updated.Session, "session.updated must contain a session object");
            Assert.AreEqual(ReasoningEffort.Low, updated.Session.ReasoningEffort,
                "ReasoningEffort.Low must be echoed back in session.updated");
        }

        // -----------------------------------------------------------------------
        // Mirrors: testInterimResponseIsEchoedInSessionUpdated (Java)
        // Verifies: InterimResponse config sent in session.update is echoed back
        // by the server in the session.updated event.
        // -----------------------------------------------------------------------
        [LiveOnly]
        [TestCase]
        public async Task InterimResponseIsEchoedInSessionUpdated()
        {
            var client = GetLiveClient();

            var config = new StaticInterimResponseConfig();
            config.Texts.Add("One moment please...");
            config.Triggers.Add(InterimResponseTrigger.Latency);
            config.LatencyThreshold = TimeSpan.FromMilliseconds(2000);

            var options = new VoiceLiveSessionOptions
            {
                Model = TestEnvironment.ModelName,
                InterimResponse = ModelReaderWriter.Write(config, new ModelReaderWriterOptions("J")),
            };
            options.Modalities.Clear();
            options.Modalities.Add(InteractionModality.Text);

            await using var session = await client.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();
            await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            var updated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            Assert.IsNotNull(updated.Session, "session.updated must contain a session object");
            Assert.IsNotNull(updated.Session.InterimResponse,
                "InterimResponse config must be echoed back in session.updated");
        }
    }
}
