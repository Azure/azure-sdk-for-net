// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol conformance tests for GET /responses/{id}.
/// Validates JSON snapshot, SSE replay, and error responses.
/// All assertions use HttpClient + JsonDocument + SseParser only.
/// </summary>
public class GetResponseProtocolTests : ProtocolTestBase
{
    [Test]
    public async Task GET_CompletedResponse_Returns200_WithJson()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        var responseId = await CreateDefaultResponseAsync();

        var getResponse = await GetResponseAsync(responseId);

        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(getResponse.Content.Headers.ContentType?.MediaType, Is.EqualTo("application/json"));

        using var doc = await ParseJsonAsync(getResponse);
        Assert.That(doc.RootElement.GetProperty("id").GetString(), Is.EqualTo(responseId));
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    [Test]
    public async Task GET_WithStreamTrue_NonBg_Returns400()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        var responseId = await CreateDefaultResponseAsync();

        // SSE replay on non-bg response → 400 (per B14/B35)
        var getResponse = await GetResponseStreamAsync(responseId);

        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        using var doc = await ParseJsonAsync(getResponse);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
    }

    [Test]
    public async Task GET_SseReplay_BgStreaming_HasCorrectSequenceNumbers()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        // Create bg streaming response
        var httpResponse = await PostResponsesAsync(new { model = "test", stream = true, background = true });
        var events = await ParseSseAsync(httpResponse);
        using var evtDoc = JsonDocument.Parse(events[0].Data);
        var responseId = evtDoc.RootElement.GetProperty("response").GetProperty("id").GetString()!;

        var getResponse = await GetResponseStreamAsync(responseId);
        var replayEvents = await ParseSseAsync(getResponse);

        var seqNums = new List<long>();
        foreach (var evt in replayEvents)
        {
            using var doc = JsonDocument.Parse(evt.Data);
            seqNums.Add(doc.RootElement.GetProperty("sequence_number").GetInt64());
        }

        // Sequence numbers should be monotonically increasing starting from 0
        Assert.That(seqNums[0], Is.EqualTo(0));
        for (int i = 1; i < seqNums.Count; i++)
        {
            Assert.That(seqNums[i] > seqNums[i - 1], Is.True,
                $"Sequence numbers not monotonically increasing at index {i}: " +
                $"{seqNums[i - 1]} → {seqNums[i]}");
        }
    }

    [Test]
    public async Task GET_UnknownId_Returns404_WithErrorShape()
    {
        var getResponse = await GetResponseAsync("caresp_nonexistent_id");

        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        using var doc = await ParseJsonAsync(getResponse);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        Assert.That(string.IsNullOrEmpty(error.GetProperty("message").GetString()), Is.False);
    }

    [Test]
    public async Task GET_InProgressResponse_Returns200_WithInProgressStatus()
    {
        var tcs = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => WaitingStream(ctx, tcs.Task, ct);

        // Create a background response that stays in progress
        var responseId = await CreateBackgroundResponseAsync();

        var getResponse = await GetResponseAsync(responseId);

        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(getResponse);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("in_progress"));

        // Clean up
        tcs.SetResult();
        await WaitForBackgroundCompletionAsync(responseId);
    }

    // ── T053: store=false → GET 404 ───────────────────────────

    [Test]
    public async Task GET_StoreFalse_Returns404()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        // Create a non-stored response
        var httpResponse = await PostResponsesAsync(new { model = "test", store = false });
        using var doc = await ParseJsonAsync(httpResponse);
        var responseId = doc.RootElement.GetProperty("id").GetString()!;

        var getResponse = await GetResponseAsync(responseId);

        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    // ── T056: cancelled bg → GET 200 with cancelled ──────────

    [Test]
    public async Task GET_CancelledBg_Returns200_WithCancelledStatus()
    {
        var tcs = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => WaitingStream(ctx, tcs.Task, ct);

        var responseId = await CreateBackgroundResponseAsync();
        await CancelResponseAsync(responseId);

        var getResponse = await GetResponseAsync(responseId);

        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(getResponse);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("cancelled"));
        Assert.That(doc.RootElement.GetProperty("output").GetArrayLength(), Is.EqualTo(0));

        tcs.TrySetResult();
    }

    // ── T057: SSE replay rejection ───────────────────────────

    [Test]
    public async Task GET_SseReplay_BgNonStreaming_Returns400()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        var responseId = await CreateBackgroundResponseAsync();
        await WaitForBackgroundCompletionAsync(responseId);

        var getResponse = await GetResponseStreamAsync(responseId);

        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    // ── T058: starting_after ──────────────────────────────────

    [Test]
    public async Task GET_SseReplay_StartingAfter_FiltersEvents()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        // Create bg streaming response
        var httpResponse = await PostResponsesAsync(new { model = "test", stream = true, background = true });
        var events = await ParseSseAsync(httpResponse);
        using var evtDoc = JsonDocument.Parse(events[0].Data);
        var responseId = evtDoc.RootElement.GetProperty("response").GetProperty("id").GetString()!;

        // Replay with starting_after=2 → should skip events with seq <= 2
        var getResponse = await Client.GetAsync($"/responses/{responseId}?stream=true&starting_after=2");

        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var replayEvents = await ParseSseAsync(getResponse);

        foreach (var evt in replayEvents)
        {
            using var doc = JsonDocument.Parse(evt.Data);
            var seq = doc.RootElement.GetProperty("sequence_number").GetInt64();
            Assert.That(seq > 2, Is.True, $"Expected sequence_number > 2 but got {seq}");
        }
    }

    [Test]
    public async Task GET_SseReplay_StartingAfterMax_ReturnsNoEvents()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        // Create bg streaming response
        var httpResponse = await PostResponsesAsync(new { model = "test", stream = true, background = true });
        var postEvents = await ParseSseAsync(httpResponse);
        using var evtDoc = JsonDocument.Parse(postEvents[0].Data);
        var responseId = evtDoc.RootElement.GetProperty("response").GetProperty("id").GetString()!;

        // starting_after >= max sequence → 0 events
        var getResponse = await Client.GetAsync($"/responses/{responseId}?stream=true&starting_after=9999");

        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var replayEvents = await ParseSseAsync(getResponse);
        Assert.That(replayEvents, Is.Empty);
    }

    // ── T060: SSE replay on store=false → 404 ────────────────

    [Test]
    public async Task GET_SseReplay_StoreFalse_Returns404()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        // Create a non-stored response
        var httpResponse = await PostResponsesAsync(new { model = "test", store = false });
        using var doc = await ParseJsonAsync(httpResponse);
        var responseId = doc.RootElement.GetProperty("id").GetString()!;

        var getResponse = await GetResponseStreamAsync(responseId);

        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    // ── US3: ?stream=true query parameter ──────────────────────

    [Test]
    public async Task GET_WithStreamTrue_BgStreaming_Returns200_SseReplay()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        // Create bg streaming response
        var httpResponse = await PostResponsesAsync(new { model = "test", stream = true, background = true });
        var events = await ParseSseAsync(httpResponse);
        using var evtDoc = JsonDocument.Parse(events[0].Data);
        var responseId = evtDoc.RootElement.GetProperty("response").GetProperty("id").GetString()!;

        // Use ?stream=true (not Accept header) to trigger SSE replay
        var getResponse = await GetResponseStreamAsync(responseId);

        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(getResponse.Content.Headers.ContentType?.MediaType, Is.EqualTo("text/event-stream"));

        var replayEvents = await ParseSseAsync(getResponse);
        Assert.That(replayEvents.Count >= 2, Is.True, "Expected at least 2 replayed SSE events");
        Assert.That(replayEvents[0].EventType, Is.EqualTo("response.created"));
        Assert.That(replayEvents[^1].EventType, Is.EqualTo("response.completed"));
    }

    [Test]
    public async Task GET_WithStreamFalse_Returns200_JsonSnapshot()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        // Create bg streaming response
        var httpResponse = await PostResponsesAsync(new { model = "test", stream = true, background = true });
        var events = await ParseSseAsync(httpResponse);
        using var evtDoc = JsonDocument.Parse(events[0].Data);
        var responseId = evtDoc.RootElement.GetProperty("response").GetProperty("id").GetString()!;

        // ?stream=false should NOT trigger SSE — should return JSON snapshot
        var request = new HttpRequestMessage(HttpMethod.Get, $"/responses/{responseId}?stream=false");
        var getResponse = await Client.SendAsync(request);

        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(getResponse.Content.Headers.ContentType?.MediaType, Is.EqualTo("application/json"));

        using var doc = await ParseJsonAsync(getResponse);
        Assert.That(doc.RootElement.GetProperty("id").GetString(), Is.EqualTo(responseId));
    }

    [Test]
    public async Task GET_WithAcceptSse_WithoutStreamTrue_Returns200_JsonSnapshot()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        // Create bg streaming response
        var httpResponse = await PostResponsesAsync(new { model = "test", stream = true, background = true });
        var events = await ParseSseAsync(httpResponse);
        using var evtDoc = JsonDocument.Parse(events[0].Data);
        var responseId = evtDoc.RootElement.GetProperty("response").GetProperty("id").GetString()!;

        // Accept: text/event-stream WITHOUT ?stream=true should return JSON (Accept alone is NOT a trigger)
        var getResponse = await GetResponseAsync(responseId, accept: "text/event-stream");

        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(getResponse.Content.Headers.ContentType?.MediaType, Is.EqualTo("application/json"));

        using var doc = await ParseJsonAsync(getResponse);
        Assert.That(doc.RootElement.GetProperty("id").GetString(), Is.EqualTo(responseId));
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

    private static async IAsyncEnumerable<ResponseStreamEvent> WaitingStream(
        ResponseContext ctx,
        Task waitTask,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });

        yield return stream.EmitCreated();
        await waitTask.WaitAsync(ct);
        yield return stream.EmitCompleted();
    }
}
