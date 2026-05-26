// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Sse;

public class SseWriterTests
{
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        Converters =
        {
            new TypeSpecModelConverterFactory(),
            new BinaryDataConverter(),
        },
    };

    private static Models.ResponseObject CreateTestResponse()
    {
        return new Models.ResponseObject("resp_test", "gpt-4o");
    }

    [Test]
    public async Task WriteEventAsync_WritesEventAndDataLines()
    {
        using var stream = new MemoryStream();
        var writer = new SseWriter(stream, _jsonOptions);

        var evt = new ResponseCreatedEvent(response: CreateTestResponse(), sequenceNumber: 0);
        await writer.WriteEventAsync(evt, 0, CancellationToken.None);

        var output = Encoding.UTF8.GetString(stream.ToArray());
        XAssert.Contains("event: response.created\n", output);
        XAssert.Contains("data: ", output);
        XAssert.EndsWith("\n\n", output);
    }

    [Test]
    public async Task WriteEventAsync_DataLineContainsValidJson()
    {
        using var stream = new MemoryStream();
        var writer = new SseWriter(stream, _jsonOptions);

        var evt = new ResponseTextDeltaEvent(3, "item_1", 0, 0, "Hello", Array.Empty<ResponseLogProb>());
        await writer.WriteEventAsync(evt, 0, CancellationToken.None);

        var output = Encoding.UTF8.GetString(stream.ToArray());
        var dataLine = output.Split('\n').First(l => l.StartsWith("data: "));
        var json = dataLine["data: ".Length..];
        var parsed = JsonSerializer.Deserialize<JsonElement>(json);
        Assert.That(parsed.GetProperty("type").GetString(), Is.EqualTo("response.output_text.delta"));
        Assert.That(parsed.GetProperty("delta").GetString(), Is.EqualTo("Hello"));
    }

    [Test]
    public async Task WriteKeepAliveAsync_WritesComment()
    {
        using var stream = new MemoryStream();
        var writer = new SseWriter(stream, _jsonOptions);

        await writer.WriteKeepAliveAsync(CancellationToken.None);

        var output = Encoding.UTF8.GetString(stream.ToArray());
        Assert.That(output, Is.EqualTo(": keep-alive\n\n"));
    }

    [Test]
    public async Task WriteEventAsync_EventTypeMatchesTypeField()
    {
        using var stream = new MemoryStream();
        var writer = new SseWriter(stream, _jsonOptions);

        var evt = new ResponseCompletedEvent(response: CreateTestResponse(), sequenceNumber: 5);
        await writer.WriteEventAsync(evt, 5, CancellationToken.None);

        var output = Encoding.UTF8.GetString(stream.ToArray());
        var eventLine = output.Split('\n').First(l => l.StartsWith("event: "));
        Assert.That(eventLine, Is.EqualTo("event: response.completed"));
    }

    [Test]
    public async Task WriteEventAsync_MultipleEvents_AreProperlyDelimited()
    {
        using var stream = new MemoryStream();
        var writer = new SseWriter(stream, _jsonOptions);

        var response = CreateTestResponse();
        await writer.WriteEventAsync(new ResponseCreatedEvent(response: response, sequenceNumber: 0), 0, CancellationToken.None);
        await writer.WriteEventAsync(new ResponseCompletedEvent(response: response, sequenceNumber: 1), 1, CancellationToken.None);

        var output = Encoding.UTF8.GetString(stream.ToArray());
        // Each event ends with \n\n (blank line separator)
        var events = output.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        Assert.That(events.Length, Is.EqualTo(2));
    }

    [Test]
    public async Task WriteEventAsync_ThreadSafe_WithKeepAlive()
    {
        using var stream = new MemoryStream();
        var writer = new SseWriter(stream, _jsonOptions);

        // Simulate concurrent event + keep-alive writes
        var tasks = new List<Task>();
        for (int i = 0; i < 10; i++)
        {
            var seqNum = i;
            tasks.Add(writer.WriteEventAsync(
                new ResponseCreatedEvent(response: CreateTestResponse(), sequenceNumber: seqNum), seqNum, CancellationToken.None));
            tasks.Add(writer.WriteKeepAliveAsync(CancellationToken.None));
        }

        await Task.WhenAll(tasks);

        var output = Encoding.UTF8.GetString(stream.ToArray());
        // All writes should complete without corruption
        var blocks = output.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        Assert.That(blocks.Length, Is.EqualTo(20)); // 10 events + 10 keep-alives
    }
}
