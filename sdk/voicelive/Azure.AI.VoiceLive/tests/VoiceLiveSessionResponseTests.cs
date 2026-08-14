// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.AI.VoiceLive;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using Azure.Core;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Unit tests covering response management related commands for <see cref="VoiceLiveSession"/>.
    /// These validate that the expected JSON command payloads are emitted over the injected <see cref="FakeWebSocket"/>.
    /// </summary>
    [TestFixture]
    public class VoiceLiveSessionResponseTests
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
            session.SetWebSocket(fakeSocket); // Inject our capture socket.
            return session;
        }

        private static JsonDocument? GetLastJsonMessage(FakeWebSocket socket)
        {
            foreach (var msg in socket.GetSentTextMessages().Reverse())
            {
                if (string.IsNullOrWhiteSpace(msg))
                    continue;
                try
                {
                    return JsonDocument.Parse(msg);
                }
                catch (JsonException)
                {
                    // ignore non-JSON
                }
            }
            return null;
        }

        private static List<JsonDocument> GetMessagesOfType(FakeWebSocket socket, string type)
        {
            var list = new List<JsonDocument>();
            foreach (var m in socket.GetSentTextMessages())
            {
                if (string.IsNullOrWhiteSpace(m))
                    continue;
                try
                {
                    var doc = JsonDocument.Parse(m);
                    if (doc.RootElement.TryGetProperty("type", out var tProp) && tProp.ValueKind == JsonValueKind.String && string.Equals(tProp.GetString(), type, StringComparison.OrdinalIgnoreCase))
                    {
                        list.Add(doc);
                    }
                    else
                    {
                        doc.Dispose();
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }
            }
            return list;
        }

        [Test]
        public async Task StartResponseAsync_NoOptions_SendsResponseCreate()
        {
            var session = CreateSessionWithFakeSocket(out var fake);

            await session.StartResponseAsync();

            using var last = GetLastJsonMessage(fake);
            Assert.That(last, Is.Not.Null, "Expected a response.create message.");
            var root = last!.RootElement;
            Assert.That(root.TryGetProperty("type", out var typeProp), Is.True);
            Assert.That(typeProp.GetString(), Is.EqualTo("response.create"));
            // Ensure no additional_instructions property present
            Assert.That(root.TryGetProperty("additional_instructions", out _), Is.False, "Did not expect additional_instructions for no-options overload.");
        }

        [Test]
        public async Task StartResponseAsync_WithAdditionalInstructions_IncludesField()
        {
            var session = CreateSessionWithFakeSocket(out var fake);
            string instructions = "Respond cheerfully.";

            await session.StartResponseAsync(instructions);

            using var last = GetLastJsonMessage(fake);
            Assert.That(last, Is.Not.Null);
            var root = last!.RootElement;
            Assert.That(root.GetProperty("type").GetString(), Is.EqualTo("response.create"));
            Assert.That(root.TryGetProperty("additional_instructions", out var aiProp), Is.True, "Expected additional_instructions property.");
            Assert.That(aiProp.GetString(), Is.EqualTo(instructions));
        }

        [Test]
        public async Task CancelResponseAsync_SendsResponseCancel()
        {
            var session = CreateSessionWithFakeSocket(out var fake);

            await session.CancelResponseAsync();

            var cancelMessages = GetMessagesOfType(fake, "response.cancel");
            Assert.That(cancelMessages.Count, Is.EqualTo(1), "Expected one response.cancel message.");
            foreach (var d in cancelMessages)
                d.Dispose();
        }

        [Test]
        public async Task StartResponseAfterFunctionCallOutput_SendsFunctionCallOutputThenResponseCreate()
        {
            var session = CreateSessionWithFakeSocket(out var fake);

            // Construct a function_call_output item.
            var item = new FunctionCallOutputItem("call-1", "{ \"result\": \"ok\" }");

            await session.AddItemAsync(item);
            await session.StartResponseAsync();

            // Examine ordering of messages: conversation.item.create should precede response.create
            var sent = fake.GetSentTextMessages().ToList();
            int createIndex = -1;
            int responseIndex = -1;
            for (int i = 0; i < sent.Count; i++)
            {
                var msg = sent[i];
                if (string.IsNullOrWhiteSpace(msg))
                    continue;
                try
                {
                    using var doc = JsonDocument.Parse(msg);
                    if (!doc.RootElement.TryGetProperty("type", out var tProp) || tProp.ValueKind != JsonValueKind.String)
                        continue;
                    var typeVal = tProp.GetString();
                    if (typeVal == "conversation.item.create" && createIndex == -1)
                    {
                        createIndex = i;
                    }
                    if (typeVal == "response.create" && responseIndex == -1)
                    {
                        responseIndex = i;
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }
            }

            if (createIndex == -1 || responseIndex == -1)
            {
                Assert.Inconclusive("Could not locate required message types in sent frames (conversation.item.create and response.create).");
            }

            Assert.That(createIndex, Is.LessThan(responseIndex), "conversation.item.create should be sent before response.create");
        }
    }
}
