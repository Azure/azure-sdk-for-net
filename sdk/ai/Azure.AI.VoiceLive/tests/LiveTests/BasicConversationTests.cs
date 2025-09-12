// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    public class BasicConversationTests : VoiceLiveTestBase
    {
        public BasicConversationTests() : base(true)
        { }

        public BasicConversationTests(bool isAsync) : base(isAsync)
        {
        }

        [LiveOnly]
        [TestCase]
        public async Task BasicHelloTest()
        {
            HashSet<string> eventIDs = new HashSet<string>();

            foreach (var key in Environment.GetEnvironmentVariables().Keys)
            {
                Console.WriteLine($"{key}: {Environment.GetEnvironmentVariable((string)key)}");
            }
            var vlc = new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true));

            var options = new RequestSession()
            {
                Model = "gpt-4o",
                InputAudioFormat = AudioFormat.Pcm16
            };

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            eventIDs.Add(sessionCreated.EventId);

            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);
            Assert.IsFalse(eventIDs.Contains(sessionUpdated.EventId));
            eventIDs.Add(sessionUpdated.EventId);

            Assert.AreEqual(sessionUpdated.Session.InputAudioFormat, AudioFormat.Pcm16);
            Assert.AreEqual(sessionCreated.Session.Id, sessionUpdated.Session.Id);
            Assert.AreEqual(sessionCreated.Session.Model, sessionUpdated.Session.Model);

            // Flow audio to the service.
            await SendAudioAsync(session, "Weather.wav").ConfigureAwait(false);

            // Now we get a speech started
            var speechStarted = await GetNextUpdate<SessionUpdateInputAudioBufferSpeechStarted>(updatesEnum).ConfigureAwait(false);
            var speechEnded = await GetNextUpdate<SessionUpdateInputAudioBufferSpeechStopped>(updatesEnum).ConfigureAwait(false);
            var bufferCommitted = await GetNextUpdate<SessionUpdateInputAudioBufferCommitted>(updatesEnum).ConfigureAwait(false);
            var transcript = await GetNextUpdate<SessionUpdateConversationItemInputAudioTranscriptionCompleted>(updatesEnum).ConfigureAwait(false);
            var conversationItemCreated = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            var responseCreated = await GetNextUpdate<SessionUpdateResponseCreated>(updatesEnum).ConfigureAwait(false);
            var responseItemAdded = await GetNextUpdate<SessionUpdateResponseOutputItemAdded>(updatesEnum).ConfigureAwait(false);
            var conversationInnerItemCreated = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            var responseContentPartCreated = await GetNextUpdate<SessionUpdateResponseContentPartAdded>(updatesEnum).ConfigureAwait(false);
        }

        private async Task<T> GetNextUpdate<T>(IAsyncEnumerator<SessionUpdate> updateEnumerator) where T : SessionUpdate
        {
            var moved = await updateEnumerator.MoveNextAsync().ConfigureAwait(false);
            Assert.IsTrue(moved);
            var currentUpdate = updateEnumerator.Current;
            Assert.IsNotNull(currentUpdate);
            Assert.IsTrue(currentUpdate is T);

#pragma warning disable CS8603 // Possible null reference return. Assert 2 lines above prevents.
            return currentUpdate as T;
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
