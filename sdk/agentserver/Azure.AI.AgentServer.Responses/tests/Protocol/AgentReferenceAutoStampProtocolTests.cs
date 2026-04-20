// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol conformance tests for auto-stamping <c>agent_reference</c> on output items (US3).
/// Validates that <c>agent_reference</c> from <c>CreateResponse</c> propagates to the
/// <c>Models.ResponseObject</c> object and all output items, with handler-set values taking precedence.
/// </summary>
public class AgentReferenceAutoStampProtocolTests : ProtocolTestBase
{
    // ── T024: agent_reference on CreateResponse appears on Models.ResponseObject ──

    [Test]
    public async Task POST_Streaming_AgentReference_AppearsOnResponse()
    {
        Handler.EventFactory = (req, ctx, ct) => StreamWithOutputItem(ctx, req);

        var response = await PostResponsesAsync(new
        {
            model = "test",
            stream = true,
            agent_reference = new { type = "agent_reference", name = "my-agent", version = "1.0" },
        });
        var events = await ParseSseAsync(response);

        var createdEvent = events.First(e => e.EventType == "response.created");
        using var doc = JsonDocument.Parse(createdEvent.Data);
        var resp = doc.RootElement.GetProperty("response");
        var agentRef = resp.GetProperty("agent_reference");
        Assert.That(agentRef.GetProperty("name").GetString(), Is.EqualTo("my-agent"));
        Assert.That(agentRef.GetProperty("version").GetString(), Is.EqualTo("1.0"));
    }

    // ── T025: agent_reference propagates to output items ────────

    [Test]
    public async Task POST_Streaming_AgentReference_PropagatesToOutputItems()
    {
        Handler.EventFactory = (req, ctx, ct) => StreamWithOutputItem(ctx, req);

        var response = await PostResponsesAsync(new
        {
            model = "test",
            stream = true,
            agent_reference = new { type = "agent_reference", name = "my-agent", version = "1.0" },
        });
        var events = await ParseSseAsync(response);

        var itemEvents = events.Where(e =>
            e.EventType is "response.output_item.added" or "response.output_item.done").ToList();

        Assert.That(itemEvents, Is.Not.Empty);

        foreach (var evt in itemEvents)
        {
            using var doc = JsonDocument.Parse(evt.Data);
            var item = doc.RootElement.GetProperty("item");
            var agentRef = item.GetProperty("agent_reference");
            Assert.That(agentRef.GetProperty("name").GetString(), Is.EqualTo("my-agent"));
            Assert.That(agentRef.GetProperty("version").GetString(), Is.EqualTo("1.0"));
        }
    }

    // ── T026: Handler-set agent_reference takes precedence ──────

    [Test]
    public async Task POST_Streaming_HandlerSetAgentReference_IsPreserved()
    {
        Handler.EventFactory = (req, ctx, ct) => StreamWithHandlerSetAgentRef(ctx, req);

        var response = await PostResponsesAsync(new
        {
            model = "test",
            stream = true,
            agent_reference = new { type = "agent_reference", name = "request-agent", version = "1.0" },
        });
        var events = await ParseSseAsync(response);

        var itemAdded = events.First(e => e.EventType == "response.output_item.added");
        using var doc = JsonDocument.Parse(itemAdded.Data);
        var item = doc.RootElement.GetProperty("item");
        var agentRef = item.GetProperty("agent_reference");
        Assert.That(agentRef.GetProperty("name").GetString(), Is.EqualTo("handler-agent"));
    }

    // ── T027: No agent_reference on request → no agent_reference on items ──

    [Test]
    public async Task POST_Streaming_NoAgentReference_ItemsHaveNoAgentReference()
    {
        Handler.EventFactory = (req, ctx, ct) => StreamWithOutputItem(ctx, req);

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        var events = await ParseSseAsync(response);

        var itemEvents = events.Where(e =>
            e.EventType is "response.output_item.added" or "response.output_item.done").ToList();

        Assert.That(itemEvents, Is.Not.Empty);

        foreach (var evt in itemEvents)
        {
            using var doc = JsonDocument.Parse(evt.Data);
            var item = doc.RootElement.GetProperty("item");
            // agent_reference should be absent (null → omitted in JSON)
            Assert.That(item.TryGetProperty("agent_reference", out var agentRefProp)
                && agentRefProp.ValueKind != JsonValueKind.Null, Is.False, "Output item should not have agent_reference when request has none");
        }
    }

    // ── T028: Direct-yield handler gets agent_reference auto-stamped (Layer 2) ──

    [Test]
    public async Task POST_Streaming_DirectYieldHandler_GetsAgentReferenceAutoStamped()
    {
        Handler.EventFactory = (req, ctx, ct) => DirectYieldStreamWithAgentRef(ctx);

        var response = await PostResponsesAsync(new
        {
            model = "test",
            stream = true,
            agent_reference = new { type = "agent_reference", name = "direct-agent", version = "2.0" },
        });
        var events = await ParseSseAsync(response);

        var itemAdded = events.First(e => e.EventType == "response.output_item.added");
        using var doc = JsonDocument.Parse(itemAdded.Data);
        var item = doc.RootElement.GetProperty("item");
        var agentRef = item.GetProperty("agent_reference");
        Assert.That(agentRef.GetProperty("name").GetString(), Is.EqualTo("direct-agent"));
    }

    // ── Helper event factories ─────────────────────────────────

    private static async IAsyncEnumerable<ResponseStreamEvent> StreamWithOutputItem(
        ResponseContext ctx,
        CreateResponse request,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, request);

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

    private static async IAsyncEnumerable<ResponseStreamEvent> StreamWithHandlerSetAgentRef(
        ResponseContext ctx,
        CreateResponse request,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, request);

        yield return stream.EmitCreated();

        var message = stream.AddOutputItemMessage();
        var item = new OutputItemMessage(
            id: message.ItemId,
            content: Array.Empty<MessageContent>(),
            status: MessageStatus.InProgress)
        {
            AgentReference = new AgentReference("handler-agent") { Version = "9.0" },
        };
        yield return message.EmitAdded(item);
        yield return message.EmitDone(item);

        yield return stream.EmitCompleted();
    }

    /// <summary>
    /// Directly yields events without using ResponseEventStream builders.
    /// Layer 2 must stamp agent_reference from the request.
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> DirectYieldStreamWithAgentRef(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var response = new Models.ResponseObject(ctx.ResponseId, "test");

        yield return new ResponseCreatedEvent(0, response);

        // Directly construct output item without setting AgentReference
        var outputItem = new OutputItemMessage(
            id: "msg_direct_agref_001",
            content: Array.Empty<MessageContent>(),
            status: MessageStatus.InProgress);
        yield return new ResponseOutputItemAddedEvent(0, 0, outputItem);
        yield return new ResponseOutputItemDoneEvent(0, 0, outputItem);

        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }
}
