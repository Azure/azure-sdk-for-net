// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Net.ServerSentEvents;
using System.Text.Json;
using System.Threading.Tasks;
using ClientModel.Tests.Collections;
using NUnit.Framework;

namespace System.ClientModel.Tests.Results;

public class StreamingResultParsingTests
{
    [Test]
    public async Task SseParsesEventEnvelopeAndTypedPayload()
    {
        MockStreamedResponse response =
            new(MockStreamedData.SseMetadataMockContent);
        AsyncStreamingClientResult<SseItem<StreamedValue>> result =
            SseStreamedValueResult.Create(response);
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

    [Test]
    public async Task SseDetectsTerminalPayloadBeforeInvokingTypedParser()
    {
        MockStreamedResponse response = new(
            "data: { \"id\": 0, \"value\": \"0\" }\n\ndata: [DONE]\n\n");
        int parserInvocationCount = 0;
        AsyncStreamingClientResult<SseItem<StreamedValue>> result =
            AsyncStreamingClientResult.CreateSse(
                response,
                (_, data) =>
                {
                    parserInvocationCount++;
                    return StreamedValue.FromJson(data.ToArray());
                },
                static item => item.Data.ToString() == "[DONE]");
        List<SseItem<StreamedValue>> items = [];

        await foreach (SseItem<StreamedValue> item in result)
        {
            items.Add(item);
        }

        Assert.AreEqual(1, parserInvocationCount);
        Assert.AreEqual(1, items.Count);
        Assert.AreEqual(0, items[0].Data.Id);
        Assert.IsTrue(response.IsDisposed);
    }

    [Test]
    public async Task SseWithoutTerminalPredicateUsesTypedParser()
    {
        MockStreamedResponse response =
            new("event: value\nid: 1\ndata: { \"id\": 1, \"value\": \"one\" }\n\n");
        int parserInvocationCount = 0;
        AsyncStreamingClientResult<SseItem<StreamedValue>> result =
            AsyncStreamingClientResult.CreateSse(
                response,
                (_, data) =>
                {
                    parserInvocationCount++;
                    return StreamedValue.FromJson(data.ToArray());
                });

        await foreach (SseItem<StreamedValue> item in result)
        {
            Assert.AreEqual("value", item.EventType);
            Assert.AreEqual("1", item.EventId);
            Assert.AreEqual(1, item.Data.Id);
        }

        Assert.AreEqual(1, parserInvocationCount);
        Assert.IsTrue(response.IsDisposed);
    }

    [TestCase("\n")]
    [TestCase("\r\n")]
    public async Task JsonlParsesTypedValuesAndBlankLines(string newline)
    {
        string content = MockStreamedData.JsonlMockContent
            .Replace("\r\n", "\n")
            .Replace("\n", newline);
        MockStreamedResponse response = new(content);
        AsyncStreamingClientResult<StreamedValue> result =
            JsonlStreamedValueResult.Create(response);
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
        AsyncStreamingClientResult<StreamedValue> result =
            JsonlStreamedValueResult.Create(response);

        Assert.CatchAsync<JsonException>(async () =>
        {
            await foreach (StreamedValue _ in result)
            {
            }
        });

        Assert.IsTrue(response.IsDisposed);
    }

    [TestCase("\n")]
    [TestCase("\r\n")]
    public async Task JsonlSkipsLeadingUtf8Bom(string newline)
    {
        MockStreamedResponse response =
            new($"\uFEFF{{ \"id\": 0, \"value\": \"0\" }}{newline}");
        AsyncStreamingClientResult<StreamedValue> result =
            JsonlStreamedValueResult.Create(response);

        await foreach (StreamedValue item in result)
        {
            Assert.AreEqual(0, item.Id);
            Assert.AreEqual("0", item.Value);
        }

        Assert.IsTrue(response.IsDisposed);
    }

    [Test]
    public async Task JsonlDoesNotSkipBomAfterFirstRecord()
    {
        MockStreamedResponse response =
            new("{\"id\":0}\n\uFEFF{\"id\":1}\n");
        List<BinaryData> items = [];

        await foreach (BinaryData item in
            AsyncStreamingClientResult.CreateJsonLines(response))
        {
            items.Add(item);
        }

        Assert.AreEqual(2, items.Count);
        Assert.AreEqual(0xEF, items[1].ToMemory().Span[0]);
        Assert.IsTrue(response.IsDisposed);
    }

    [Test]
    public async Task JsonlSkipsAsciiWhitespaceLines()
    {
        MockStreamedResponse response =
            new(" \t\r\n{\"id\":1}\n");
        List<BinaryData> items = [];

        await foreach (BinaryData item in
            AsyncStreamingClientResult.CreateJsonLines(response))
        {
            items.Add(item);
        }

        Assert.AreEqual(1, items.Count);
        Assert.AreEqual("{\"id\":1}", items[0].ToString());
        Assert.IsTrue(response.IsDisposed);
    }

    [Test]
    public void JsonlRejectsLineOverConfiguredLimit()
    {
        MockStreamedResponse response = new("123456789\n");
        AsyncStreamingClientResult<BinaryData> result =
            AsyncStreamingClientResult.CreateJsonLines(
                response,
                static data => data,
                maxLineLength: 8);

        Assert.ThrowsAsync<InvalidDataException>(async () =>
        {
            await foreach (BinaryData _ in result)
            {
            }
        });
        Assert.IsTrue(response.IsDisposed);
    }

    [Test]
    public void SseTerminalPredicateRequiresTerminalEvent()
    {
        MockStreamedResponse response = new("data: value\n\n");
        AsyncStreamingClientResult<SseItem<BinaryData>> result =
            AsyncStreamingClientResult.CreateSse(
                response,
                static item => item.Data.ToString() == "[DONE]");

        Assert.ThrowsAsync<InvalidDataException>(async () =>
        {
            await foreach (SseItem<BinaryData> _ in result)
            {
            }
        });
        Assert.IsTrue(response.IsDisposed);
    }

    [Test]
    public async Task RawFactoriesReturnBinaryData()
    {
        MockStreamedResponse sseResponse = new("event: value\ndata: hello\n\n");
        await foreach (SseItem<BinaryData> item in
            AsyncStreamingClientResult.CreateSse(sseResponse))
        {
            Assert.AreEqual("value", item.EventType);
            Assert.AreEqual("hello", item.Data.ToString());
        }

        MockStreamedResponse jsonlResponse = new("{\"value\":1}\n");
        await foreach (BinaryData item in
            AsyncStreamingClientResult.CreateJsonLines(jsonlResponse))
        {
            Assert.AreEqual("{\"value\":1}", item.ToString());
        }
    }
}
