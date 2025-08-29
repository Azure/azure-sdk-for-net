// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.AI.VoiceLive;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using Azure.Core;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Unit tests covering server event streaming APIs (<see cref="VoiceLiveSession.GetUpdatesAsync(System.Threading.CancellationToken)"/>,
    /// generic overload filtering, and <see cref="VoiceLiveSession.WaitForUpdateAsync{T}(System.Threading.CancellationToken)"/> behavior).
    /// These tests validate parsing, enumeration constraints, cancellation, and disposal error paths without any live network traffic.
    /// </summary>
    [TestFixture]
    public class VoiceLiveSessionEventsTests
    {
        /// <summary>
        /// A lightweight testable subclass that exposes the protected constructor and allows
        /// injecting a <see cref="FakeWebSocket"/> without modifying production code.
        /// </summary>
        private sealed class TestableVoiceLiveSession : VoiceLiveSession
        {
            public TestableVoiceLiveSession(VoiceLiveClient parentClient, Uri endpoint, AzureKeyCredential credential)
                : base(parentClient, endpoint, credential)
            {
            }

            public void SetWebSocket(System.Net.WebSockets.WebSocket socket) => WebSocket = socket;
        }

        private static TestableVoiceLiveSession CreateSessionWithFakeSocket(out FakeWebSocket fakeSocket)
        {
            var client = new VoiceLiveClient(new Uri("https://example.org"), new AzureKeyCredential("test-key"));
            var session = new TestableVoiceLiveSession(client, new Uri("wss://example.org/voice-agent/realtime"), new AzureKeyCredential("test-key"));
            fakeSocket = new FakeWebSocket();
            session.SetWebSocket(fakeSocket); // Inject capture socket (already Open state)
            return session;
        }

        private static string CreateSessionCreatedJson(string eventId = "evt-1")
        {
            // Minimal valid payload for a session.created event. All session fields are optional per deserializer.
            return $"{{ \"type\": \"session.created\", \"event_id\": \"{eventId}\", \"session\": {{ }} }}";
        }

        [Test]
        public async Task GetUpdatesAsync_ParsesSessionCreatedEvent()
        {
            var session = CreateSessionWithFakeSocket(out var fake);
            fake.EnqueueTextMessage(CreateSessionCreatedJson());

            await foreach (SessionUpdate evt in session.GetUpdatesAsync())
            {
                Assert.That(evt, Is.TypeOf<SessionUpdateSessionCreated>());
                var created = (SessionUpdateSessionCreated)evt;
                Assert.That(created.Type.ToString(), Is.EqualTo("session.created"));
                Assert.That(created.Session, Is.Not.Null);
                break; // Only need first event
            }
        }

        [Test]
        public async Task GetUpdatesAsync_IgnoresInvalidJson()
        {
            var session = CreateSessionWithFakeSocket(out var fake);
            // Enqueue invalid JSON then a good event
            fake.EnqueueTextMessage("{ invalid-json");
            fake.EnqueueTextMessage(CreateSessionCreatedJson("evt-2"));

            int count = 0;
            await foreach (SessionUpdate evt in session.GetUpdatesAsync())
            {
                count++;
                Assert.That(evt, Is.TypeOf<SessionUpdateSessionCreated>());
                Assert.That(((SessionUpdateSessionCreated)evt).Type.ToString(), Is.EqualTo("session.created"));
                break; // Stop after first valid event to avoid hanging waiting for more
            }

            Assert.That(count, Is.EqualTo(1), "Expected only the valid event to be surfaced.");
        }

        [Test]
        public async Task GetUpdatesAsync_SingleEnumerationOnly()
        {
            var session = CreateSessionWithFakeSocket(out var fake);
            // Ensure at least one event is available so the first enumerator advances promptly.
            fake.EnqueueTextMessage(CreateSessionCreatedJson("evt-first"));

            await using var enumerator1 = session.GetUpdatesAsync().GetAsyncEnumerator();
            Assert.That(await enumerator1.MoveNextAsync(), Is.True, "First enumeration should obtain an event.");
            Assert.That(enumerator1.Current, Is.TypeOf<SessionUpdateSessionCreated>());

            // Second enumeration attempt should throw InvalidOperationException when MoveNextAsync invoked.
            await using var enumerator2 = session.GetUpdatesAsync().GetAsyncEnumerator();
            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () => await enumerator2.MoveNextAsync());
            StringAssert.Contains("Only one update enumeration", ex?.Message);
        }

        [Test]
        public async Task WaitForUpdateAsync_ReturnsMatchingEvent()
        {
            var session = CreateSessionWithFakeSocket(out var fake);

            // Inject event after slight delay to ensure awaiting path is exercised.
            _ = Task.Run(async () =>
            {
                await Task.Delay(100);
                fake.EnqueueTextMessage(CreateSessionCreatedJson("delayed"));
            });

            var result = await session.WaitForUpdateAsync<SessionUpdateSessionCreated>(CancellationToken.None);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Type.ToString(), Is.EqualTo("session.created"));
        }

        [Test]
        public async Task WaitForUpdateAsync_Cancellation_ThrowsOperationCanceled()
        {
            var session = CreateSessionWithFakeSocket(out _);
            using var cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(200));

            try
            {
                await session.WaitForUpdateAsync<SessionUpdateSessionCreated>(cts.Token);
                Assert.Fail("Did not throw");
            }
            catch (OperationCanceledException)
            {
                // Happy path, can't use assert because we want any derived type to also be OK.
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception type unexpected {ex}");
            }
        }

        [Test]
        public void GetUpdatesAsync_DisposedSession_Throws()
        {
            var session = CreateSessionWithFakeSocket(out _);
            session.Dispose();

            var enumerator = session.GetUpdatesAsync().GetAsyncEnumerator();
            Assert.ThrowsAsync<ObjectDisposedException>(async () => await enumerator.MoveNextAsync());
        }
    }
}
