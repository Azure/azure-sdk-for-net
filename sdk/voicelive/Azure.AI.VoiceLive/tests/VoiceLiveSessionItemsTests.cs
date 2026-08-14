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
    /// Unit tests covering conversation item management commands issued by <see cref="VoiceLiveSession"/>.
    /// These validate that the expected JSON command payloads are emitted over the injected <see cref="FakeWebSocket"/>
    /// without performing any live network operations.
    /// </summary>
    [TestFixture]
    public class VoiceLiveSessionItemsTests
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
            session.SetWebSocket(fakeSocket);
            return session;
        }

        private static List<JsonDocument> GetMessagesOfType(FakeWebSocket socket, string type)
        {
            var list = new List<JsonDocument>();
            foreach (var msg in socket.GetSentTextMessages())
            {
                if (string.IsNullOrWhiteSpace(msg))
                    continue;
                try
                {
                    var doc = JsonDocument.Parse(msg);
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
                    // ignore non-json frames
                }
            }
            return list;
        }

        private static JsonDocument? GetLastMessageOfType(FakeWebSocket socket, string type)
        {
            foreach (var msg in socket.GetSentTextMessages().Reverse())
            {
                if (string.IsNullOrWhiteSpace(msg))
                    continue;
                try
                {
                    var doc = JsonDocument.Parse(msg);
                    if (doc.RootElement.TryGetProperty("type", out var tProp) && tProp.ValueKind == JsonValueKind.String && string.Equals(tProp.GetString(), type, StringComparison.OrdinalIgnoreCase))
                    {
                        return doc; // caller disposes
                    }
                    doc.Dispose();
                }
                catch (JsonException)
                {
                    // ignore
                }
            }
            return null;
        }

        private static MessageItem CreateSimpleUserMessage(string id, string text)
        {
            var item = new UserMessageItem(new[] { new InputTextContentPart(text) })
            {
                Id = id,
            };

            return item;
        }

        [Test]
        public async Task AddItemAsync_SendsConversationItemCreate()
        {
            var session = CreateSessionWithFakeSocket(out var fake);
            var item = CreateSimpleUserMessage("item1", "Hello world");

            await session.AddItemAsync(item);

            using var last = GetLastMessageOfType(fake, "conversation.item.create");
            Assert.That(last, Is.Not.Null, "Expected conversation.item.create message to be sent.");
            var root = last!.RootElement;
            Assert.That(root.TryGetProperty("item", out var itemProp), Is.True, "item property missing");
            Assert.That(itemProp.TryGetProperty("id", out var idProp), Is.True, "id missing inside item");
            Assert.That(idProp.GetString(), Is.EqualTo("item1"));
        }

        [Test]
        public async Task AddItemAsync_WithPreviousItemId_SetsPreviousId()
        {
            var session = CreateSessionWithFakeSocket(out var fake);
            var item = CreateSimpleUserMessage("item2", "Second message");

            await session.AddItemAsync(item, "root");

            using var last = GetLastMessageOfType(fake, "conversation.item.create");
            Assert.That(last, Is.Not.Null, "Expected conversation.item.create message to be sent.");
            var rootEl = last!.RootElement;
            Assert.That(rootEl.TryGetProperty("previous_item_id", out var prevProp), Is.True, "previous_item_id missing");
            Assert.That(prevProp.GetString(), Is.EqualTo("root"));
        }

        [Test]
        public async Task DeleteItemAsync_SendsDeleteEvent()
        {
            var session = CreateSessionWithFakeSocket(out var fake);
            await session.DeleteItemAsync("dead-item");

            using var last = GetLastMessageOfType(fake, "conversation.item.delete");
            Assert.That(last, Is.Not.Null, "Expected conversation.item.delete message.");
            var root = last!.RootElement;
            Assert.That(root.TryGetProperty("item_id", out var idProp), Is.True, "item_id missing");
            Assert.That(idProp.GetString(), Is.EqualTo("dead-item"));
        }

        [Test]
        public async Task RequestItemRetrievalAsync_SendsRetrieveEvent()
        {
            var session = CreateSessionWithFakeSocket(out var fake);
            await session.RequestItemRetrievalAsync("item123");

            using var last = GetLastMessageOfType(fake, "conversation.item.retrieve");
            Assert.That(last, Is.Not.Null, "Expected conversation.item.retrieve message.");
            var root = last!.RootElement;
            Assert.That(root.TryGetProperty("item_id", out var idProp), Is.True, "item_id missing");
            Assert.That(idProp.GetString(), Is.EqualTo("item123"));
        }

        [Test]
        public async Task TruncateConversationAsync_SendsTruncatePayload()
        {
            var session = CreateSessionWithFakeSocket(out var fake);
            await session.TruncateConversationAsync("assistant-msg-1", 0);

            using var last = GetLastMessageOfType(fake, "conversation.item.truncate");
            Assert.That(last, Is.Not.Null, "Expected conversation.item.truncate message.");
            var root = last!.RootElement;
            Assert.That(root.TryGetProperty("item_id", out var idProp), Is.True, "item_id missing");
            Assert.That(idProp.GetString(), Is.EqualTo("assistant-msg-1"));
            Assert.That(root.TryGetProperty("content_index", out var ciProp), Is.True, "content_index missing");
            Assert.That(ciProp.GetInt32(), Is.EqualTo(0));
            Assert.That(root.TryGetProperty("audio_end_ms", out var aProp), Is.True, "audio_end_ms missing");
            Assert.That(aProp.GetInt32(), Is.EqualTo(0)); // VoiceLiveSession currently always uses 0
        }

        [Test]
        public void TruncateConversationAsync_EmptyItemId_Throws()
        {
            var session = CreateSessionWithFakeSocket(out _);
            Assert.ThrowsAsync<ArgumentException>(async () => await session.TruncateConversationAsync(string.Empty, 0));
        }
    }
}
