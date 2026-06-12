// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    [TestFixture]
    public class VoiceLiveSessionOptionsNewFeaturesTests
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
        public async Task ParallelToolCalls_True_SerializesOnWire()
        {
            var session = CreateSessionWithFakeSocket(out var fake);
            await session.ConfigureSessionAsync(new VoiceLiveSessionOptions { ParallelToolCalls = true });

            var sent = fake.GetSentTextMessages();
            using var doc = JsonDocument.Parse(sent[0]);
            Assert.That(doc.RootElement.GetProperty("session").GetProperty("parallel_tool_calls").GetBoolean(), Is.True);
        }

        [Test]
        public async Task ParallelToolCalls_False_SerializesOnWire()
        {
            var session = CreateSessionWithFakeSocket(out var fake);
            await session.ConfigureSessionAsync(new VoiceLiveSessionOptions { ParallelToolCalls = false });

            var sent = fake.GetSentTextMessages();
            using var doc = JsonDocument.Parse(sent[0]);
            Assert.That(doc.RootElement.GetProperty("session").GetProperty("parallel_tool_calls").GetBoolean(), Is.False);
        }

        [Test]
        public void ParallelToolCalls_DeserializesFromJson()
        {
            var opts = TestUtilities.DeserializeViaIJsonModel(
                """{"id":"sess-1","model":"gpt-4o-realtime-preview","parallel_tool_calls":false}""",
                new VoiceLiveSessionOptions());

            Assert.That(opts.ParallelToolCalls, Is.EqualTo(false));
        }

        [Test]
        public void ParallelToolCalls_RoundTrip()
        {
            // Verify serialized JSON has correct TypeSpec wire key
            var json = TestUtilities.SerializeViaIJsonModel(new VoiceLiveSessionOptions { ParallelToolCalls = true });
            using var doc = JsonDocument.Parse(json);
            Assert.That(doc.RootElement.GetProperty("parallel_tool_calls").GetBoolean(), Is.True);

            // Verify deserialization from known TypeSpec wire JSON
            var fromWire = TestUtilities.DeserializeViaIJsonModel(
                """{"parallel_tool_calls":true}""",
                new VoiceLiveSessionOptions());
            Assert.That(fromWire.ParallelToolCalls, Is.EqualTo(true));
        }
    }
}
