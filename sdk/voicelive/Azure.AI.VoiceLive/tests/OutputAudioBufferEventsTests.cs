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
    }
}
