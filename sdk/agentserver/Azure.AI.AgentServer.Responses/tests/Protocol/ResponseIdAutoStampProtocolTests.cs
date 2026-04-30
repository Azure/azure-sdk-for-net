// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol conformance tests for auto-stamping <c>response_id</c> on output items (US2).
/// Validates that every output item emitted by the SDK has <c>response_id</c> matching
/// the parent response ID, and that handler-set values take precedence.
/// </summary>
public class ResponseIdAutoStampProtocolTests : ProtocolTestBase
{
    // ── T012: Streaming output items have response_id from response.created ──

    [Test]
    public async Task POST_Streaming_OutputItems_HaveResponseId_MatchingResponseCreated()
    {
        Handler.EventFactory = (req, ctx, ct) => StreamWithOutputItem(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        var events = await ParseSseAsync(response);

        // Extract response ID from response.created
        var createdEvent = events.First(e => e.EventType == "response.created");
        using var createdDoc = JsonDocument.Parse(createdEvent.Data);
        var responseId = createdDoc.RootElement.GetProperty("response").GetProperty("id").GetString();

        // Find output_item.added and output_item.done events
        var itemAddedEvents = events.Where(e => e.EventType == "response.output_item.added").ToList();
        var itemDoneEvents = events.Where(e => e.EventType == "response.output_item.done").ToList();

        Assert.That(itemAddedEvents, Is.Not.Empty);
        Assert.That(itemDoneEvents, Is.Not.Empty);

        foreach (var evt in itemAddedEvents.Concat(itemDoneEvents))
        {
            using var doc = JsonDocument.Parse(evt.Data);
            var item = doc.RootElement.GetProperty("item");
            Assert.That(item.GetProperty("response_id").GetString(), Is.EqualTo(responseId));
        }
    }

    // ── T013: Handler-set ResponseId is preserved ────────────────

    [Test]
    public async Task POST_Streaming_HandlerSetResponseId_IsPreserved()
    {
        const string customResponseId = "custom-response-id-override";
        Handler.EventFactory = (req, ctx, ct) => StreamWithHandlerSetResponseId(ctx, customResponseId);

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        var events = await ParseSseAsync(response);

        var itemAdded = events.First(e => e.EventType == "response.output_item.added");
        using var doc = JsonDocument.Parse(itemAdded.Data);
        var item = doc.RootElement.GetProperty("item");

        Assert.That(item.GetProperty("response_id").GetString(), Is.EqualTo(customResponseId));
    }

    // ── T014: Multiple output items all get same response_id ────

    [Test]
    public async Task POST_Streaming_MultipleOutputItems_AllHaveSameResponseId()
    {
        Handler.EventFactory = (req, ctx, ct) => StreamWithMultipleOutputItems(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        var events = await ParseSseAsync(response);

        var createdEvent = events.First(e => e.EventType == "response.created");
        using var createdDoc = JsonDocument.Parse(createdEvent.Data);
        var responseId = createdDoc.RootElement.GetProperty("response").GetProperty("id").GetString();

        var itemEvents = events.Where(e =>
            e.EventType is "response.output_item.added" or "response.output_item.done").ToList();

        Assert.That(itemEvents.Count >= 4, Is.True, "Expected at least 4 output item events (2 added + 2 done)");

        foreach (var evt in itemEvents)
        {
            using var doc = JsonDocument.Parse(evt.Data);
            var item = doc.RootElement.GetProperty("item");
            Assert.That(item.GetProperty("response_id").GetString(), Is.EqualTo(responseId));
        }
    }

    // ── T015: GET JSON snapshot has response_id on output items ──

    [Test]
    public async Task GET_JsonSnapshot_OutputItems_HaveResponseId()
    {
        Handler.EventFactory = (req, ctx, ct) => StreamWithOutputItem(ctx);

        var responseId = await CreateDefaultResponseAsync();
        var getResponse = await GetResponseAsync(responseId);

        using var doc = await ParseJsonAsync(getResponse);
        var output = doc.RootElement.GetProperty("output");

        Assert.That(output.GetArrayLength() > 0, Is.True, "Expected at least one output item");

        foreach (var item in output.EnumerateArray())
        {
            Assert.That(item.GetProperty("response_id").GetString(), Is.EqualTo(responseId));
        }
    }

    // ── T016: Direct-yield handler gets response_id auto-stamped (Layer 2) ──

    [Test]
    public async Task POST_Streaming_DirectYieldHandler_GetsResponseIdAutoStamped()
    {
        Handler.EventFactory = (req, ctx, ct) => DirectYieldStreamWithoutResponseId(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        var events = await ParseSseAsync(response);

        var createdEvent = events.First(e => e.EventType == "response.created");
        using var createdDoc = JsonDocument.Parse(createdEvent.Data);
        var responseId = createdDoc.RootElement.GetProperty("response").GetProperty("id").GetString();

        var itemAdded = events.First(e => e.EventType == "response.output_item.added");
        using var doc = JsonDocument.Parse(itemAdded.Data);
        var item = doc.RootElement.GetProperty("item");
        Assert.That(item.GetProperty("response_id").GetString(), Is.EqualTo(responseId));
    }

    // ── Helper event factories ─────────────────────────────────

    private static async IAsyncEnumerable<ResponseStreamEvent> StreamWithOutputItem(
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

    private static async IAsyncEnumerable<ResponseStreamEvent> StreamWithHandlerSetResponseId(
        ResponseContext ctx,
        string customResponseId,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });

        yield return stream.EmitCreated();

        var message = stream.AddOutputItemMessage();
        // Set custom response_id before emitting
        var outputMsg = new OutputItemMessage(
            id: message.ItemId,
            content: Array.Empty<MessageContent>(),
            status: MessageStatus.InProgress)
        {
            ResponseId = customResponseId,
        };
        yield return message.EmitAdded(outputMsg);
        yield return message.EmitDone(outputMsg);

        yield return stream.EmitCompleted();
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> StreamWithMultipleOutputItems(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });

        yield return stream.EmitCreated();

        // First output item
        var msg1 = stream.AddOutputItemMessage();
        yield return msg1.EmitAdded();
        var text1 = msg1.AddTextContent();
        yield return text1.EmitAdded();
        yield return text1.EmitTextDone("Hello");
        yield return text1.EmitDone();
        yield return msg1.EmitDone();

        // Second output item
        var msg2 = stream.AddOutputItemMessage();
        yield return msg2.EmitAdded();
        var text2 = msg2.AddTextContent();
        yield return text2.EmitAdded();
        yield return text2.EmitTextDone("World");
        yield return text2.EmitDone();
        yield return msg2.EmitDone();

        yield return stream.EmitCompleted();
    }

    /// <summary>
    /// Directly yields events without using ResponseEventStream builders.
    /// This simulates a handler that bypasses the builder path (Layer 1).
    /// Layer 2 (event consumption loop) must stamp response_id.
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> DirectYieldStreamWithoutResponseId(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var response = new Models.ResponseObject(ctx.ResponseId, "test");

        yield return new ResponseCreatedEvent(0, response);

        // Directly construct output item event without setting ResponseId
        var outputItem = new OutputItemMessage(
            id: "msg_direct_001",
            content: Array.Empty<MessageContent>(),
            status: MessageStatus.InProgress);
        // ResponseId intentionally NOT set — Layer 2 should stamp it
        yield return new ResponseOutputItemAddedEvent(0, 0, outputItem);
        yield return new ResponseOutputItemDoneEvent(0, 0, outputItem);

        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }
}
