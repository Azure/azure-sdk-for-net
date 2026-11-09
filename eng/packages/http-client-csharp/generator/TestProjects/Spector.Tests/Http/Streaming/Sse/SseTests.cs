// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;
using Streaming.Sse;
using Streaming.Sse._Retrieve;

namespace TestProjects.Spector.Tests.Http.Streaming.Sse
{
    public class SseTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Unnamed() => Test(async (host) =>
        {
            var client = new SseClient(host, null).GetUnnamedClient();
            await using var response = await client.ReceiveAsync();
            var descriptions = new List<string>();
            await foreach (var item in response)
            {
                Assert.AreEqual("message", item.EventType);
                descriptions.Add(item.Data.Desc);
            }

            CollectionAssert.AreEqual(new[] { "one", "two", "three" }, descriptions);
        });

        [SpectorTest]
        public Task Named() => Test(async (host) =>
        {
            var client = new SseClient(host, null).GetNamedClient();
            await using var response = await client.ReceiveAsync();
            var events = new List<(string Type, string Value)>();
            await foreach (var item in response)
            {
                using var document = JsonDocument.Parse(item.Data.ToMemory());
                var value = item.EventType == "responseCreated"
                    ? document.RootElement.GetProperty("id").GetString()!
                    : document.RootElement.GetProperty("delta").GetString()!;
                events.Add((item.EventType, value));
            }

            CollectionAssert.AreEqual(
                new[]
                {
                    ("responseCreated", "resp_1"),
                    ("responseDelta", "Hello"),
                    ("responseDelta", " world"),
                },
                events);
        });

        [SpectorTest]
        public Task Retrieve() => Test(async (host) =>
        {
            var client = new SseClient(host, null).GetRetrieveClient();
            await using var response = await client.StreamAsync(
                new RetrievalRequest("what is typespec?"));
            var events = new List<(string Type, string Value)>();
            await foreach (var item in response)
            {
                using var document = JsonDocument.Parse(item.Data.ToMemory());
                var value = item.EventType == "partialResult"
                    ? document.RootElement.GetProperty("text").GetString()!
                    : string.Join(
                        ",",
                        document.RootElement.GetProperty("references")
                            .EnumerateArray()
                            .Select(element => element.GetString()));
                events.Add((item.EventType, value));
            }

            CollectionAssert.AreEqual(
                new[]
                {
                    ("partialResult", "partial one"),
                    ("partialResult", "partial two"),
                    ("finalResult", "doc1,doc2"),
                },
                events);
        });
    }
}
