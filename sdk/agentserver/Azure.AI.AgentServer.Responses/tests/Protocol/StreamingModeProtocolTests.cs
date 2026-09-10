// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol conformance tests for streaming mode (stream=true, background=false).
/// Validates SSE wire format, event ordering, and sequence numbers.
/// All assertions use HttpClient + JsonDocument + SseParser only.
/// </summary>
public class StreamingModeProtocolTests : ProtocolTestBase
{
    [Test]
    public async Task POST_Responses_Stream_Returns200_WithSseContentType()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo("text/event-stream"));
    }

    [Test]
    // Validates: B27 — SSE wire format (event: + data: structure)
    public async Task POST_Responses_Stream_SseFormat_HasCorrectStructure()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        var rawBody = await response.Content.ReadAsStringAsync();

        // Each SSE block must follow the pattern: "event: {type}\ndata: {json}\n\n"
        var blocks = rawBody.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);

        foreach (var block in blocks)
        {
            if (block.TrimStart().StartsWith(":"))
                continue; // skip keep-alive comments

            var lines = block.Split('\n');
            Assert.That(lines.Length >= 2, Is.True, $"SSE block must have at least 2 lines: {block}");
            XAssert.StartsWith("event: ", lines[0]);
            XAssert.StartsWith("data: ", lines[1]);

            // Data must be valid single-line JSON
            var jsonStr = lines[1]["data: ".Length..];
            XAssert.DoesNotContain("\n", jsonStr);
            using var doc = JsonDocument.Parse(jsonStr);
            Assert.That(doc, Is.Not.Null);
        }
    }

    [Test]
    public async Task POST_Responses_Stream_FirstEvent_IsResponseCreated()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        var events = await ParseSseAsync(response);

        Assert.That(events.Count >= 2, Is.True, "Expected at least 2 SSE events");
        Assert.That(events[0].EventType, Is.EqualTo("response.created"));
    }

    [Test]
    public async Task POST_Responses_Stream_LastEvent_IsResponseCompleted()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        var events = await ParseSseAsync(response);

        Assert.That(events.Count >= 2, Is.True, "Expected at least 2 SSE events");
        Assert.That(events[^1].EventType, Is.EqualTo("response.completed"));
    }

    [Test]
    public async Task POST_Responses_Stream_SequenceNumbers_AreMonotonicallyIncreasing()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        var events = await ParseSseAsync(response);

        var seqNums = new List<long>();
        foreach (var evt in events)
        {
            using var doc = JsonDocument.Parse(evt.Data);
            Assert.That(doc.RootElement.TryGetProperty("sequence_number", out var seqProp), Is.True, $"Event {evt.EventType} missing sequence_number");
            seqNums.Add(seqProp.GetInt64());
        }

        // Verify monotonically increasing (each number > previous)
        for (int i = 1; i < seqNums.Count; i++)
        {
            Assert.That(seqNums[i] > seqNums[i - 1], Is.True,
                $"Sequence numbers not monotonically increasing: {seqNums[i - 1]} → {seqNums[i]} at index {i}");
        }

        // First sequence number should be 0
        Assert.That(seqNums[0], Is.EqualTo(0));
    }

    [Test]
    // Validates: B27 — SSE wire format (event type in data matches event: line)
    public async Task POST_Responses_Stream_EventDataType_MatchesEventLine()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        var events = await ParseSseAsync(response);

        foreach (var evt in events)
        {
            using var doc = JsonDocument.Parse(evt.Data);
            var dataType = doc.RootElement.GetProperty("type").GetString();
            Assert.That(dataType, Is.EqualTo(evt.EventType));
        }
    }

    [Test]
    public async Task POST_Responses_Stream_TextOutput_EventOrdering()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        var events = await ParseSseAsync(response);

        var eventTypes = events.Select(e => e.EventType).ToList();

        // Verify the expected ordering for a simple text response
        var expectedOrder = new[]
        {
            "response.created",
            "response.output_item.added",
            "response.content_part.added",
            "response.output_text.delta",
            "response.output_text.done",
            "response.content_part.done",
            "response.output_item.done",
            "response.completed"
        };

        Assert.That(eventTypes.Count, Is.EqualTo(expectedOrder.Length));
        for (int i = 0; i < expectedOrder.Length; i++)
        {
            Assert.That(eventTypes[i], Is.EqualTo(expectedOrder[i]));
        }
    }

    [Test]
    // Validates: B28 — SSE keep-alive comments during pauses
    public async Task POST_Responses_Stream_KeepAlive_SentDuringPause()
    {
        // Set env var for 1-second keep-alive and reload
        var previousSseEnv = Environment.GetEnvironmentVariable("SSE_KEEPALIVE_INTERVAL");
        try
        {
            Environment.SetEnvironmentVariable("SSE_KEEPALIVE_INTERVAL", "1");
            FoundryEnvironment.Reload();

            Handler.EventFactory = (req, ctx, ct) => SlowStream(ctx, ct);

            using var factory = new TestWebApplicationFactory(Handler);
            using var client = factory.CreateClient();

            var response = await client.PostAsync("/responses",
                new System.Net.Http.StringContent(
                    System.Text.Json.JsonSerializer.Serialize(new { model = "test", stream = true }),
                    System.Text.Encoding.UTF8, "application/json"));

            var rawBody = await response.Content.ReadAsStringAsync();

            // Should contain at least one keep-alive comment
            XAssert.Contains(": keep-alive", rawBody);
        }
        finally
        {
            Environment.SetEnvironmentVariable("SSE_KEEPALIVE_INTERVAL", previousSseEnv);
            FoundryEnvironment.Reload();
        }
    }

    // ── Helper event factories ─────────────────────────────────

    private static async IAsyncEnumerable<ResponseStreamEvent> SimpleTextStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });

        yield return stream.EmitCreated();

        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();

        var text = message.AddTextContent();
        yield return text.EmitAdded();

        yield return text.EmitDelta("Hello");
        yield return text.EmitTextDone("Hello");

        yield return text.EmitDone();
        yield return message.EmitDone();

        yield return stream.EmitCompleted();
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> SlowStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });

        yield return stream.EmitCreated();

        // Delay long enough for keep-alive to fire (interval is 1 second in test)
        await Task.Delay(3000, ct);

        yield return stream.EmitCompleted();
    }
}
