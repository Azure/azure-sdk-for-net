// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.ServerSentEvents;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using NUnit.Framework;
using Streaming.Sse;

namespace TestProjects.Spector.Tests.Http.Streaming.Sse
{
    public class SseProtocolTests : SpectorTestBase
    {
        [SpectorTest]
        [TestCase(false)]
        [TestCase(true)]
        public Task DataWithEnvelope(bool useProtocol) => Test(async (host) =>
        {
            var client = new SseClient(host, null).GetProtocolClient().GetProtocolDataClient();
            await using var response = useProtocol
                ? await client.WithEnvelopeAsync(context: null)
                : await client.WithEnvelopeAsync();
            var item = await ReadSingleEventAsync(response);

            AssertEnvelope(item, "withEnvelope");
            Assert.AreEqual("hello", item.Data.ToString());
        });

        [SpectorTest]
        [TestCase(false)]
        [TestCase(true)]
        public Task DataWithoutEnvelope(bool useProtocol) => Test(async (host) =>
        {
            var client = new SseClient(host, null).GetProtocolClient().GetProtocolDataClient();
            await using var response = useProtocol
                ? await client.WithoutEnvelopeAsync(context: null)
                : await client.WithoutEnvelopeAsync();
            var item = await ReadSingleEventAsync(response);

            AssertEnvelope(item, "withoutEnvelope");
            using var document = JsonDocument.Parse(item.Data.ToMemory());
            Assert.AreEqual("world", document.RootElement.GetProperty("contents").GetString());
            Assert.AreEqual("test", document.RootElement.GetProperty("metadata").GetProperty("source").GetString());
            Assert.AreEqual(2, document.RootElement.EnumerateObject().Count());
        });

        [SpectorTest]
        public Task Id() => Test(async (host) =>
        {
            var client = new SseClient(host, null).GetProtocolClient();
            await using var response = await client.IdAsync();
            var item = await ReadSingleEventAsync(response);

            AssertEnvelope(item, eventId: "event-1");
            Assert.AreEqual("hello", item.Data.Message);
        });

        [SpectorTest]
        public Task InvalidId() => Test(async (host) =>
        {
            var client = new SseClient(host, null).GetProtocolClient();
            await using var response = await client.InvalidIdAsync();
            var item = await ReadSingleEventAsync(response);

            AssertEnvelope(item);
            Assert.AreEqual("hello", item.Data.Message);
        });

        [SpectorTest]
        public Task Retry() => Test(async (host) =>
        {
            var client = new SseClient(host, null).GetProtocolClient();
            await using var response = await client.RetryAsync();
            var item = await ReadSingleEventAsync(response);

            AssertEnvelope(item, reconnectionInterval: TimeSpan.FromMilliseconds(1000));
            Assert.AreEqual("hello", item.Data.Message);
        });

        [SpectorTest]
        public Task InvalidRetry() => Test(async (host) =>
        {
            var client = new SseClient(host, null).GetProtocolClient();
            await using var response = await client.InvalidRetryAsync();
            var item = await ReadSingleEventAsync(response);

            AssertEnvelope(item);
            Assert.AreEqual("hello", item.Data.Message);
        });

        [SpectorTest]
        [TestCase("id", "event-1", null)]
        [TestCase("invalidId", null, null)]
        [TestCase("retry", null, 1000)]
        [TestCase("invalidRetry", null, null)]
        public Task MetadataProtocol(string scenario, string? eventId, int? retryMilliseconds) => Test(async (host) =>
        {
            var client = new SseClient(host, null).GetProtocolClient();
            await using var response = scenario switch
            {
                "id" => await client.IdAsync(context: null),
                "invalidId" => await client.InvalidIdAsync(context: null),
                "retry" => await client.RetryAsync(context: null),
                "invalidRetry" => await client.InvalidRetryAsync(context: null),
                _ => throw new ArgumentOutOfRangeException(nameof(scenario))
            };
            var item = await ReadSingleEventAsync(response);

            TimeSpan? interval = retryMilliseconds.HasValue ? TimeSpan.FromMilliseconds(retryMilliseconds.Value) : null;
            AssertEnvelope(item, eventId: eventId, reconnectionInterval: interval);
            AssertMessage(item.Data, "hello");
        });

        [SpectorTest]
        [TestCase(false)]
        [TestCase(true)]
        public Task Reconnect(bool useProtocol) => Test(async (host) =>
        {
            var client = new SseClient(host, null).GetProtocolClient();
            string lastEventId;
            if (useProtocol)
            {
                await using var response = await client.ReconnectAsync(context: null);
                var initial = await ReadSingleEventAsync(response);
                AssertEnvelope(initial, eventId: "event-1");
                AssertMessage(initial.Data, "hello");
                lastEventId = initial.EventId!;
            }
            else
            {
                await using var response = await client.ReconnectAsync();
                var initial = await ReadSingleEventAsync(response);
                AssertEnvelope(initial, eventId: "event-1");
                Assert.AreEqual("hello", initial.Data.Message);
                lastEventId = initial.EventId!;
            }

            // The mock closes normally, so explicitly resume using the last parsed event ID.
            var context = new RequestContext();
            context.AddPolicy(new LastEventIdPolicy(lastEventId), HttpPipelinePosition.PerCall);
            await using var reconnectedResponse = await client.ReconnectAsync(context);
            var resumed = await ReadSingleEventAsync(reconnectedResponse);
            AssertEnvelope(resumed, eventId: "event-2");
            AssertMessage(resumed.Data, "world");
        });

        private static async Task<SseItem<T>> ReadSingleEventAsync<T>(IAsyncEnumerable<SseItem<T>> response)
        {
            await using var enumerator = response.GetAsyncEnumerator();
            Assert.IsTrue(await enumerator.MoveNextAsync(), "Expected one SSE event.");
            var item = enumerator.Current;
            Assert.IsFalse(await enumerator.MoveNextAsync(), "Expected the SSE stream to end after one event.");
            return item;
        }

        private static void AssertEnvelope<T>(
            SseItem<T> item,
            string eventType = "message",
            string? eventId = null,
            TimeSpan? reconnectionInterval = null)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(eventType, item.EventType);
                Assert.AreEqual(eventId, item.EventId);
                Assert.AreEqual(reconnectionInterval, item.ReconnectionInterval);
            });
        }

        private static void AssertMessage(BinaryData data, string message)
        {
            using var document = JsonDocument.Parse(data.ToMemory());
            Assert.AreEqual(message, document.RootElement.GetProperty("message").GetString());
            Assert.AreEqual(1, document.RootElement.EnumerateObject().Count());
        }

        private sealed class LastEventIdPolicy : HttpPipelineSynchronousPolicy
        {
            private readonly string _lastEventId;

            public LastEventIdPolicy(string lastEventId)
            {
                _lastEventId = lastEventId;
            }

            public override void OnSendingRequest(HttpMessage message)
            {
                message.Request.Headers.SetValue("Last-Event-ID", _lastEventId);
            }
        }
    }
}
