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
    public class ServerEventResponseInvocationDeltaTests
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
        public void ResponseInvocationDeltaEventTypeString_IsRegistered()
        {
            Assert.That(ServerEventType.ResponseInvocationDelta.ToString(), Is.EqualTo("response.invocation.delta"));
        }

        [Test]
        public async Task ServerEventResponseInvocationDelta_ParsesCorrectly()
        {
            var session = CreateSessionWithFakeSocket(out var fake);
            fake.EnqueueTextMessage("""
                {
                    "type": "response.invocation.delta",
                    "event_id": "inv1",
                    "delta": { "event": "thread.run.created", "data": { "id": "run-1" } }
                }
                """);

            await foreach (SessionUpdate update in session.GetUpdatesAsync())
            {
                Assert.That(update, Is.TypeOf<ServerEventResponseInvocationDelta>());
                var delta = (ServerEventResponseInvocationDelta)update;
                Assert.That(delta.Delta, Is.Not.Null);
                Assert.That(delta.Delta.ContainsKey("event"), Is.True);
                break;
            }
        }
    }
}
