// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.Extensions.Logging.Abstractions;

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

    private static ResponseObject CreateTestResponse()
    {
        return new ResponseObject { Id = "resp_test", Model = "gpt-4o" };
    }

    private static SseKeepAliveSession CreateInactiveSession(Stream output) =>
        SseKeepAliveSession.Start(output, Timeout.InfiniteTimeSpan, NullLogger.Instance, "test");

    [Test]
    public async Task WriteEventAsync_WritesEventAndDataLines()
    {
        using var stream = new MemoryStream();
        await using var session = CreateInactiveSession(stream);
        var writer = new SseWriter(session, _jsonOptions);

        var evt = new ResponseCreatedEvent { Response = CreateTestResponse(), SequenceNumber = (int)(0) };
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
        await using var session = CreateInactiveSession(stream);
        var writer = new SseWriter(session, _jsonOptions);

        var evt = new ResponseTextDeltaEvent { SequenceNumber = (int)(3), ItemId = "item_1", OutputIndex = (int)(0), ContentIndex = (int)(0), Delta = "Hello" };
        foreach (var __v in Array.Empty<ResponseLogProb>() ?? [])
            evt.TokenLogProbabilities.Add(__v);
        await writer.WriteEventAsync(evt, 0, CancellationToken.None);

        var output = Encoding.UTF8.GetString(stream.ToArray());
        var dataLine = output.Split('\n').First(l => l.StartsWith("data: "));
        var json = dataLine["data: ".Length..];
        var parsed = JsonSerializer.Deserialize<JsonElement>(json);
        Assert.That(parsed.GetProperty("type").GetString(), Is.EqualTo("response.output_text.delta"));
        Assert.That(parsed.GetProperty("delta").GetString(), Is.EqualTo("Hello"));
    }

    [Test]
    public async Task WriteEventAsync_EventTypeMatchesTypeField()
    {
        using var stream = new MemoryStream();
        await using var session = CreateInactiveSession(stream);
        var writer = new SseWriter(session, _jsonOptions);

        var evt = new ResponseCompletedEvent { Response = CreateTestResponse(), SequenceNumber = (int)(5) };
        await writer.WriteEventAsync(evt, 5, CancellationToken.None);

        var output = Encoding.UTF8.GetString(stream.ToArray());
        var eventLine = output.Split('\n').First(l => l.StartsWith("event: "));
        Assert.That(eventLine, Is.EqualTo("event: response.completed"));
    }

    [Test]
    public async Task WriteEventAsync_MultipleEvents_AreProperlyDelimited()
    {
        using var stream = new MemoryStream();
        await using var session = CreateInactiveSession(stream);
        var writer = new SseWriter(session, _jsonOptions);

        var response = CreateTestResponse();
        await writer.WriteEventAsync(new ResponseCreatedEvent { Response = response, SequenceNumber = (int)(0) }, 0, CancellationToken.None);
        await writer.WriteEventAsync(new ResponseCompletedEvent { Response = response, SequenceNumber = (int)(1) }, 1, CancellationToken.None);

        var output = Encoding.UTF8.GetString(stream.ToArray());
        // Each event ends with \n\n (blank line separator)
        var events = output.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        Assert.That(events.Length, Is.EqualTo(2));
    }

    [Test]
    public async Task WriteEventAsync_ThreadSafe_WhenWritingConcurrently()
    {
        using var stream = new MemoryStream();
        await using var session = CreateInactiveSession(stream);
        var writer = new SseWriter(session, _jsonOptions);

        // Simulate concurrent event writes — the session-owned lock must serialize them.
        var tasks = new List<Task>();
        for (int i = 0; i < 20; i++)
        {
            var seqNum = i;
            tasks.Add(writer.WriteEventAsync(
                new ResponseCreatedEvent { Response = CreateTestResponse(), SequenceNumber = (int)(seqNum) }, seqNum, CancellationToken.None));
        }

        await Task.WhenAll(tasks);

        var output = Encoding.UTF8.GetString(stream.ToArray());
        // All writes should complete without corruption
        var blocks = output.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        Assert.That(blocks.Length, Is.EqualTo(20));
    }
}
