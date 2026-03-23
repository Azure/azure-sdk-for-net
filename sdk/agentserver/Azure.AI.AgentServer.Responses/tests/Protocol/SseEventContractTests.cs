// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol conformance tests for SSE event contract (US5).
/// Validates event ordering and sequence numbers.
/// </summary>
public class SseEventContractTests : ProtocolTestBase
{
    // ── T020: SSE streams must NOT contain [DONE] sentinel ────
    // Validates: B26 — Terminal SSE events (no sentinel)

    [Test]
    public async Task SSE_Stream_DoesNotContainDone_Sentinel()
    {
        var response = await PostResponsesAsync(new { model = "test", stream = true });

        var body = await response.Content.ReadAsStringAsync();
        // [DONE] must NOT appear anywhere in the SSE stream
        XAssert.DoesNotContain("data: [DONE]", body);
    }

    // ── T021: SSE event ordering ────────────────────────────────

    [Test]
    public async Task SSE_Stream_EventOrdering_CreatedFirst_CompletedLast()
    {
        var response = await PostResponsesAsync(new { model = "test", stream = true });

        var events = await ParseSseAsync(response);
        Assert.IsTrue(events.Count >= 2, "Expected at least 2 events");

        // First event must be response.created
        Assert.AreEqual("response.created", events[0].EventType);

        // Last event must be a terminal event
        var lastEvent = events[^1];
        XAssert.Contains(lastEvent.EventType, new[] { "response.completed", "response.failed", "response.incomplete" });
    }

    [Test]
    public async Task SSE_Stream_EventOrdering_InProgressAfterCreated()
    {
        Handler.EventFactory = (req, ctx, ct) => FullLifecycleStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });

        var events = await ParseSseAsync(response);
        Assert.IsTrue(events.Count >= 3, "Expected at least 3 events");

        Assert.AreEqual("response.created", events[0].EventType);
        Assert.AreEqual("response.in_progress", events[1].EventType);
        // Last should be terminal
        XAssert.Contains(events[^1].EventType, new[] { "response.completed", "response.failed", "response.incomplete" });
    }

    // ── T022: Monotonically increasing sequence numbers ────────

    [Test]
    public async Task SSE_Stream_SequenceNumbers_MonotonicallyIncreasing()
    {
        Handler.EventFactory = (req, ctx, ct) => FullLifecycleStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });

        var events = await ParseSseAsync(response);
        Assert.IsTrue(events.Count >= 2);

        long prevSeq = -1;
        foreach (var evt in events)
        {
            using var doc = JsonDocument.Parse(evt.Data);
            var seq = doc.RootElement.GetProperty("sequence_number").GetInt64();
            Assert.IsTrue(seq > prevSeq, $"sequence_number {seq} is not greater than previous {prevSeq}");
            prevSeq = seq;
        }
    }

    [Test]
    public async Task SSE_Stream_FirstSequenceNumber_IsZero()
    {
        var response = await PostResponsesAsync(new { model = "test", stream = true });

        var events = await ParseSseAsync(response);
        Assert.IsTrue(events.Count >= 1);

        using var doc = JsonDocument.Parse(events[0].Data);
        Assert.AreEqual(0, doc.RootElement.GetProperty("sequence_number").GetInt64());
    }

    // ── Helper event factories ─────────────────────────────────

    private static async IAsyncEnumerable<ResponseStreamEvent> FullLifecycleStream(
        IResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();
        yield return stream.EmitCompleted();
        await Task.CompletedTask;
    }

}
