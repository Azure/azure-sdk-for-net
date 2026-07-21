// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Net.ServerSentEvents;
using System.Text.Json;
using System.Threading.Tasks;
using ClientModel.Tests.Collections;
using NUnit.Framework;

namespace System.ClientModel.Tests.Results;

public class StreamingResultParsingTests
{
    [Test]
    public void SseParsesEventEnvelopeAndTypedPayload()
    {
        MockStreamedResponse response =
            new(MockStreamedData.SseMetadataMockContent);
        SseStreamedValueResult result = new(response);

        SseItem<StreamedValue>[] items = result.ToArray();

        Assert.AreEqual(MockStreamedData.TotalItemCount, items.Length);
        for (int i = 0; i < items.Length; i++)
        {
            Assert.AreEqual($"event.{i}", items[i].EventType);
            Assert.AreEqual(i.ToString(), items[i].EventId);
            Assert.AreEqual(i, items[i].Data.Id);
            Assert.AreEqual(i.ToString(), items[i].Data.Value);
        }
        Assert.AreEqual(TimeSpan.FromMilliseconds(1500), items[0].ReconnectionInterval);
        Assert.IsTrue(response.IsDisposed);
    }

    [Test]
    public async Task SseParsesEventEnvelopeAndTypedPayloadAsync()
    {
        MockStreamedResponse response =
            new(MockStreamedData.SseMetadataMockContent);
        AsyncSseStreamedValueResult result = new(response);
        List<SseItem<StreamedValue>> items = [];

        await foreach (SseItem<StreamedValue> item in result)
        {
            items.Add(item);
        }

        Assert.AreEqual(MockStreamedData.TotalItemCount, items.Count);
        for (int i = 0; i < items.Count; i++)
        {
            Assert.AreEqual($"event.{i}", items[i].EventType);
            Assert.AreEqual(i.ToString(), items[i].EventId);
            Assert.AreEqual(i, items[i].Data.Id);
            Assert.AreEqual(i.ToString(), items[i].Data.Value);
        }
        Assert.AreEqual(TimeSpan.FromMilliseconds(1500), items[0].ReconnectionInterval);
        Assert.IsTrue(response.IsDisposed);
    }

    [TestCase("\n")]
    [TestCase("\r\n")]
    public void JsonlParsesTypedValuesAndBlankLines(string newline)
    {
        string content = MockStreamedData.JsonlMockContent
            .Replace("\r\n", "\n")
            .Replace("\n", newline);
        MockStreamedResponse response = new(content);
        JsonlStreamedValueResult result = new(response);

        StreamedValue[] items = result.ToArray();

        Assert.AreEqual(MockStreamedData.TotalItemCount, items.Length);
        for (int i = 0; i < items.Length; i++)
        {
            Assert.AreEqual(i, items[i].Id);
            Assert.AreEqual(i.ToString(), items[i].Value);
        }
        Assert.IsTrue(response.IsDisposed);
    }

    [TestCase("\n")]
    [TestCase("\r\n")]
    public async Task JsonlParsesTypedValuesAsync(string newline)
    {
        string content = MockStreamedData.JsonlMockContent
            .Replace("\r\n", "\n")
            .Replace("\n", newline);
        MockStreamedResponse response = new(content);
        AsyncJsonlStreamedValueResult result = new(response);
        List<StreamedValue> items = [];

        await foreach (StreamedValue item in result)
        {
            items.Add(item);
        }

        Assert.AreEqual(MockStreamedData.TotalItemCount, items.Count);
        for (int i = 0; i < items.Count; i++)
        {
            Assert.AreEqual(i, items[i].Id);
            Assert.AreEqual(i.ToString(), items[i].Value);
        }
        Assert.IsTrue(response.IsDisposed);
    }

    [Test]
    public void JsonlDisposesResponseWhenParsingFails()
    {
        MockStreamedResponse response = new("""
            { "id": 0, "value": "0" }
            { malformed }

            """);
        JsonlStreamedValueResult result = new(response);

        Assert.Catch<JsonException>(() => result.ToArray());

        Assert.IsTrue(response.IsDisposed);
    }

    [Test]
    public void JsonlDisposesResponseWhenParsingFailsAsync()
    {
        MockStreamedResponse response = new("""
            { "id": 0, "value": "0" }
            { malformed }

            """);
        AsyncJsonlStreamedValueResult result = new(response);

        Assert.CatchAsync<JsonException>(async () =>
        {
            await foreach (StreamedValue _ in result)
            {
            }
        });

        Assert.IsTrue(response.IsDisposed);
    }
}
