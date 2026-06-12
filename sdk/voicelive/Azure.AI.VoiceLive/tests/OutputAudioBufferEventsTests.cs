// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    [TestFixture]
    public class OutputAudioBufferEventsTests
    {
        private static TestableVoiceLiveSession CreateSessionWithFakeSocket(out FakeWebSocket fakeSocket)
        {
            var client = new VoiceLiveClient(new Uri("https://example.org"), new AzureKeyCredential("test-key"));
            var session = new TestableVoiceLiveSession(client, new Uri("wss://example.org/realtime"), new AzureKeyCredential("test-key"));
            fakeSocket = new FakeWebSocket();
            session.SetWebSocket(fakeSocket);
            return session;
        }

        [Test]
        public void OutputAudioBufferEventTypeStrings_AreRegistered()
        {
            Assert.That(ServerEventType.OutputAudioBufferStarted.ToString(), Is.EqualTo("output_audio_buffer.started"));
            Assert.That(ServerEventType.OutputAudioBufferStopped.ToString(), Is.EqualTo("output_audio_buffer.stopped"));
            Assert.That(ServerEventType.OutputAudioBufferCleared.ToString(), Is.EqualTo("output_audio_buffer.cleared"));
        }

        [Test]
        public async Task ServerEventOutputAudioBufferCleared_ParsesCorrectly()
        {
            var session = CreateSessionWithFakeSocket(out var fake);
            fake.EnqueueTextMessage("""{"type":"output_audio_buffer.cleared","event_id":"a3"}""");

            await foreach (SessionUpdate update in session.GetUpdatesAsync())
            {
                Assert.That(update, Is.TypeOf<ServerEventOutputAudioBufferCleared>());
                break;
            }
        }

        [Test]
        public async Task ServerEventOutputAudioBufferStarted_ParsesCorrectly()
        {
            var session = CreateSessionWithFakeSocket(out var fake);
            fake.EnqueueTextMessage("""{"type":"output_audio_buffer.started","event_id":"a1","response_id":"resp-7"}""");

            await foreach (SessionUpdate update in session.GetUpdatesAsync())
            {
                Assert.That(update, Is.TypeOf<ServerEventOutputAudioBufferStarted>());
                var started = (ServerEventOutputAudioBufferStarted)update;
                Assert.That(started.ResponseId, Is.EqualTo("resp-7"));
                break;
            }
        }

        [Test]
        public async Task ServerEventOutputAudioBufferStopped_ParsesCorrectly()
        {
            var session = CreateSessionWithFakeSocket(out var fake);
            fake.EnqueueTextMessage("""{"type":"output_audio_buffer.stopped","event_id":"a2","response_id":"resp-8"}""");

            await foreach (SessionUpdate update in session.GetUpdatesAsync())
            {
                Assert.That(update, Is.TypeOf<ServerEventOutputAudioBufferStopped>());
                var stopped = (ServerEventOutputAudioBufferStopped)update;
                Assert.That(stopped.ResponseId, Is.EqualTo("resp-8"));
                break;
            }
        }
    }
}
