// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    public class BasicConversationTests : VoiceLiveTestBase
    {
        private HashSet<string> _eventIDs = new HashSet<string>();

        public BasicConversationTests() : base(true)
        { }

        public BasicConversationTests(bool isAsync) : base(isAsync)
        {
        }

        [LiveOnly]
        [TestCase]
        public async Task BasicHelloTest()
        {
            foreach (var key in Environment.GetEnvironmentVariables().Keys)
            {
                Console.WriteLine($"{key}: {Environment.GetEnvironmentVariable((string)key)}");
            }
            var vlc = new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true));

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                InputAudioFormat = AudioFormat.Pcm16
            };

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);

            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            Assert.AreEqual(sessionUpdated.Session.InputAudioFormat, AudioFormat.Pcm16);
            Assert.AreEqual(sessionCreated.Session.Id, sessionUpdated.Session.Id);
            Assert.AreEqual(sessionCreated.Session.Model, sessionUpdated.Session.Model);
            Assert.AreEqual(sessionCreated.Session.Agent, sessionUpdated.Session.Agent);
            Assert.AreEqual(sessionCreated.Session.Animation, sessionUpdated.Session.Animation);
            Assert.AreEqual(sessionCreated.Session.Avatar, sessionUpdated.Session.Avatar);
            Assert.AreEqual(sessionCreated.Session.InputAudioEchoCancellation, sessionUpdated.Session?.InputAudioEchoCancellation);

            // Flow audio to the service.
            await SendAudioAsync(session, "Weather.wav").ConfigureAwait(false);

            // Now we get a speech started
            var speechStarted = await GetNextUpdate<SessionUpdateInputAudioBufferSpeechStarted>(updatesEnum).ConfigureAwait(false);
            var speechEnded = await GetNextUpdate<SessionUpdateInputAudioBufferSpeechStopped>(updatesEnum).ConfigureAwait(false);
            var bufferCommitted = await GetNextUpdate<SessionUpdateInputAudioBufferCommitted>(updatesEnum).ConfigureAwait(false);
            var transcript = await GetNextUpdate<SessionUpdateConversationItemInputAudioTranscriptionCompleted>(updatesEnum).ConfigureAwait(false);

            var conversationItemCreated = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            Assert.IsTrue(conversationItemCreated.PreviousItemId == null);
            Assert.IsTrue(conversationItemCreated.Item.Type == ItemType.Message);

            var message = SafeCast<ResponseMessageItem>(conversationItemCreated.Item);

            Assert.AreEqual(ResponseMessageRole.User, message.Role);
            Assert.AreEqual(1, message.Content.Count);
            Assert.AreEqual(ContentPartType.InputAudio, message.Content[0].Type);

            // TODO: Confusing that this isn't InputAudioContentPart.
            var contentPart = SafeCast<RequestAudioContentPart>(message.Content[0]);
            Assert.AreEqual(transcript.Transcript, contentPart.Transcript);

            var responseCreated = await GetNextUpdate<SessionUpdateResponseCreated>(updatesEnum).ConfigureAwait(false);

            var responseItems = await CollectResponseUpdates(updatesEnum, TimeoutToken).ConfigureAwait(false);

            Assert.IsTrue(responseItems.Count() > 0);
        }

        private void EnsureEventIdsUnique(SessionUpdate sessionUpdate)
        {
            Assert.IsNotNull(sessionUpdate.EventId, $"Event ID was not specified on type {sessionUpdate.Type}");
            Assert.IsFalse(_eventIDs.Contains(sessionUpdate.EventId), $"EventId {sessionUpdate.EventId} was reused");
            _eventIDs.Add(sessionUpdate.EventId);
        }

        private async Task<IEnumerable<SessionUpdate>> CollectResponseUpdates(IAsyncEnumerator<SessionUpdate> updateEnumerator, CancellationToken cancellationToken)
        {
            List<SessionUpdate> responseUpdates = new List<SessionUpdate>();

            SessionUpdate currentUpdate;

            do
            {
                currentUpdate = await GetNextUpdate(updateEnumerator).ConfigureAwait(false);
                responseUpdates.Add(currentUpdate);
            } while (currentUpdate is not SessionUpdateResponseDone && !cancellationToken.IsCancellationRequested);

            if (cancellationToken.IsCancellationRequested)
            {
                throw new OperationCanceledException();
            }

            return responseUpdates;
        }

        private async Task<T> GetNextUpdate<T>(IAsyncEnumerator<SessionUpdate> updateEnumerator) where T : SessionUpdate
        {
            var currentUpdate = await GetNextUpdate(updateEnumerator).ConfigureAwait(false);
            return SafeCast<T>(currentUpdate);
        }

        private T SafeCast<T>(object o) where T : class
        {
            Assert.IsTrue(o is T);
#pragma warning disable CS8603 // Possible null reference return. Assert 2 lines above prevents.
            return o as T;
#pragma warning restore CS8603 // Possible null reference return.
        }

        private async Task<SessionUpdate> GetNextUpdate(IAsyncEnumerator<SessionUpdate> updateEnumerator)
        {
            var moved = await updateEnumerator.MoveNextAsync().ConfigureAwait(false);
            Assert.IsTrue(moved);
            var currentUpdate = updateEnumerator.Current;
            Assert.IsNotNull(currentUpdate);
            EnsureEventIdsUnique(currentUpdate);

            return currentUpdate;
        }
    }
}
