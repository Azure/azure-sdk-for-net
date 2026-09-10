// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol tests for User Story 2 — Non-Background Responses Are Ephemeral.
/// Verifies B14/B16/B17 (non-bg cancelled/disconnected → no persistence, GET 404),
/// B5/B16 (non-bg terminal → persisted, GET 200).
/// </summary>
public class EphemeralNonBgResponseTests : ProtocolTestBase
{
    // ═══════════════════════════════════════════════════════════════════════
    // C6: store=false, stream=true, bg=false — SSE stream completes, GET 404
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task C6_StoreFalse_StreamTrue_NoBg_StreamsEvents_Then_GET_Returns404()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        var createResponse = await PostResponsesAsync(
            new { model = "test", store = false, stream = true });
        Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(createResponse.Content.Headers.ContentType?.MediaType,
            Is.EqualTo("text/event-stream"));

        // Verify SSE events are present and valid
        var events = await ParseSseAsync(createResponse);
        Assert.That(events.Count, Is.GreaterThanOrEqualTo(2),
            "C6 must produce at least response.created + response.completed");

        var firstEvent = events.First(e => e.EventType == "response.created");
        Assert.That(firstEvent, Is.Not.Null);
        var lastEvent = events.Last(e => e.EventType == "response.completed");
        Assert.That(lastEvent, Is.Not.Null);

        // Extract response ID from first event
        using var doc = JsonDocument.Parse(firstEvent!.Data);
        var responseId = doc.RootElement.GetProperty("response").GetProperty("id").GetString()!;

        // C6: store=false → GET returns 404 (never persisted)
        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T021: bg=false, stream=true — client disconnects mid-stream → GET 404
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task NonBgStream_ClientDisconnect_GET_Returns404()
    {
        var handlerStarted = new TaskCompletionSource();
        var handlerCancelled = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) =>
            DisconnectTrackingStream(ctx, handlerStarted, handlerCancelled, ct);

        var cts = new CancellationTokenSource();
        var json = JsonSerializer.Serialize(new { model = "test", stream = true });
        var postContent = new StringContent(json, Encoding.UTF8, "application/json");
        var postTask = Client.PostAsync("/responses", postContent, cts.Token);

        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));
        var responseId = Handler.LastContext!.ResponseId;

        // Disconnect mid-stream
        cts.Cancel();
        await handlerCancelled.Task.WaitAsync(TimeSpan.FromSeconds(5));

        try
        { await postTask; }
        catch (TaskCanceledException) { }

        // Non-bg cancelled → ephemeral (not persisted) → GET 404
        // Poll until cleanup propagates
        var getResponse = await PollUntilAsync(
            () => GetResponseAsync(responseId),
            r => r.StatusCode == HttpStatusCode.NotFound);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T022: bg=false, stream=false — client disconnects → no persistence
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task NonBgNoStream_ClientDisconnect_GET_Returns404()
    {
        var handlerStarted = new TaskCompletionSource();
        var handlerCancelled = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) =>
            DisconnectTrackingStream(ctx, handlerStarted, handlerCancelled, ct);

        var cts = new CancellationTokenSource();
        var json = JsonSerializer.Serialize(new { model = "test" });
        var postContent = new StringContent(json, Encoding.UTF8, "application/json");
        var postTask = Client.PostAsync("/responses", postContent, cts.Token);

        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));
        var responseId = Handler.LastContext!.ResponseId;

        // Disconnect
        cts.Cancel();
        await handlerCancelled.Task.WaitAsync(TimeSpan.FromSeconds(5));

        try
        { await postTask; }
        catch (TaskCanceledException) { }

        // Non-bg cancelled → ephemeral (not persisted) → GET 404
        // Poll until cleanup propagates
        var getResponse = await PollUntilAsync(
            () => GetResponseAsync(responseId),
            r => r.StatusCode == HttpStatusCode.NotFound);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T023: bg=false — handler completes → GET 200 with status: completed
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task NonBg_Completed_GET_Returns200()
    {
        // Default handler: response.created → response.completed
        var postResponse = await PostResponsesAsync(new { model = "test" });
        Assert.That(postResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var postDoc = await ParseJsonAsync(postResponse);
        var responseId = postDoc.RootElement.GetProperty("id").GetString()!;
        Assert.That(postDoc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));

        // Non-bg completed → persisted → GET 200
        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var getDoc = await ParseJsonAsync(getResponse);
        Assert.That(getDoc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T024: bg=false — handler fails (after response.created) → GET 200
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task NonBg_Failed_GET_Returns200()
    {
        Handler.EventFactory = (req, ctx, ct) => ThrowAfterCreatedStream(ctx);

        var postResponse = await PostResponsesAsync(new { model = "test" });
        Assert.That(postResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var postDoc = await ParseJsonAsync(postResponse);
        var responseId = postDoc.RootElement.GetProperty("id").GetString()!;
        Assert.That(postDoc.RootElement.GetProperty("status").GetString(), Is.EqualTo("failed"));

        // Non-bg failed → persisted → GET 200
        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var getDoc = await ParseJsonAsync(getResponse);
        Assert.That(getDoc.RootElement.GetProperty("status").GetString(), Is.EqualTo("failed"));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T025: bg=false — handler returns incomplete → GET 200
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task NonBg_Incomplete_GET_Returns200()
    {
        Handler.EventFactory = (req, ctx, ct) => IncompleteStream(ctx);

        var postResponse = await PostResponsesAsync(new { model = "test" });
        Assert.That(postResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var postDoc = await ParseJsonAsync(postResponse);
        var responseId = postDoc.RootElement.GetProperty("id").GetString()!;
        Assert.That(postDoc.RootElement.GetProperty("status").GetString(), Is.EqualTo("incomplete"));

        // Non-bg incomplete → persisted → GET 200
        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var getDoc = await ParseJsonAsync(getResponse);
        Assert.That(getDoc.RootElement.GetProperty("status").GetString(), Is.EqualTo("incomplete"));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T026: bg=true — cancel → GET 200 with status: cancelled, 0 output items
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task Bg_Cancel_GET_Returns200WithCancelledStatus()
    {
        var handlerGate = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => WaitingStream(ctx, handlerGate.Task, ct);

        var postResponse = await PostResponsesAsync(new { model = "test", background = true });
        Assert.That(postResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var postDoc = await ParseJsonAsync(postResponse);
        var responseId = postDoc.RootElement.GetProperty("id").GetString()!;

        // Handler is in-flight (bg POST returns after response.created is yielded)
        // Cancel the response
        var cancelResponse = await CancelResponseAsync(responseId);
        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Wait for bg task to complete
        await WaitForBackgroundCompletionAsync(responseId);

        // bg cancelled → persisted → GET 200
        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var getDoc = await ParseJsonAsync(getResponse);
        Assert.That(getDoc.RootElement.GetProperty("status").GetString(), Is.EqualTo("cancelled"));
        Assert.That(getDoc.RootElement.GetProperty("output").GetArrayLength(), Is.EqualTo(0));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T027: background flag is sole determinant — stream flag irrelevant
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task StreamFlagDoesNotAffectPersistence()
    {
        // Non-bg+stream completes → persisted → GET 200
        Handler.EventFactory = null; // default: created → completed
        var streamResponse = await PostResponsesAsync(
            new { model = "test", stream = true });
        Assert.That(streamResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var events = await ParseSseAsync(streamResponse);
        using var eventDoc = JsonDocument.Parse(events[0].Data);
        var streamResponseId = eventDoc.RootElement.GetProperty("response")
            .GetProperty("id").GetString()!;

        var getStreamResponse = await GetResponseAsync(streamResponseId);
        Assert.That(getStreamResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Non-bg+nostream completes → persisted → GET 200
        var noStreamResponse = await PostResponsesAsync(new { model = "test" });
        Assert.That(noStreamResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var noStreamDoc = await ParseJsonAsync(noStreamResponse);
        var noStreamResponseId = noStreamDoc.RootElement.GetProperty("id").GetString()!;

        var getNoStreamResponse = await GetResponseAsync(noStreamResponseId);
        Assert.That(getNoStreamResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Helpers
    // ═══════════════════════════════════════════════════════════════════════

    /// <summary>
    /// Handler that signals when started, then waits for cancellation.
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> DisconnectTrackingStream(
        ResponseContext ctx, TaskCompletionSource started, TaskCompletionSource cancelled,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        started.TrySetResult();

        try
        {
            await Task.Delay(Timeout.Infinite, ct);
        }
        catch (OperationCanceledException)
        {
            cancelled.TrySetResult();
            throw;
        }
    }

    /// <summary>
    /// Handler that yields response.created, then waits for a gate, then completes.
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> WaitingStream(
        ResponseContext ctx, Task gate,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        await gate.WaitAsync(ct);
        yield return stream.EmitCompleted();
    }

    /// <summary>
    /// Handler that yields response.created, then throws.
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> ThrowAfterCreatedStream(
        ResponseContext ctx)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        await Task.CompletedTask;
        throw new InvalidOperationException("Simulated handler failure");
    }

    /// <summary>
    /// Handler that yields response.created → response.incomplete.
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> IncompleteStream(
        ResponseContext ctx)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        await Task.CompletedTask;
        yield return stream.EmitIncomplete();
    }

    /// <summary>
    /// Handler that yields a full text response: created → message → text → completed.
    /// </summary>
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
}
