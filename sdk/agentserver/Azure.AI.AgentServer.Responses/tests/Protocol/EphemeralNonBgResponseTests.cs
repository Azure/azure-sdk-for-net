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
/// Verifies FR-004 (non-bg cancelled/disconnected → no persistence, GET 404),
/// FR-005 (non-bg terminal → persisted, GET 200).
/// </summary>
public class EphemeralNonBgResponseTests : ProtocolTestBase
{
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
        Assert.AreEqual(HttpStatusCode.NotFound, getResponse.StatusCode);
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
        Assert.AreEqual(HttpStatusCode.NotFound, getResponse.StatusCode);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T023: bg=false — handler completes → GET 200 with status: completed
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task NonBg_Completed_GET_Returns200()
    {
        // Default handler: response.created → response.completed
        var postResponse = await PostResponsesAsync(new { model = "test" });
        Assert.AreEqual(HttpStatusCode.OK, postResponse.StatusCode);

        using var postDoc = await ParseJsonAsync(postResponse);
        var responseId = postDoc.RootElement.GetProperty("id").GetString()!;
        Assert.AreEqual("completed", postDoc.RootElement.GetProperty("status").GetString());

        // Non-bg completed → persisted → GET 200
        var getResponse = await GetResponseAsync(responseId);
        Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);
        using var getDoc = await ParseJsonAsync(getResponse);
        Assert.AreEqual("completed", getDoc.RootElement.GetProperty("status").GetString());
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T024: bg=false — handler fails (after response.created) → GET 200
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task NonBg_Failed_GET_Returns200()
    {
        Handler.EventFactory = (req, ctx, ct) => ThrowAfterCreatedStream(ctx);

        var postResponse = await PostResponsesAsync(new { model = "test" });
        Assert.AreEqual(HttpStatusCode.OK, postResponse.StatusCode);

        using var postDoc = await ParseJsonAsync(postResponse);
        var responseId = postDoc.RootElement.GetProperty("id").GetString()!;
        Assert.AreEqual("failed", postDoc.RootElement.GetProperty("status").GetString());

        // Non-bg failed → persisted → GET 200
        var getResponse = await GetResponseAsync(responseId);
        Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);
        using var getDoc = await ParseJsonAsync(getResponse);
        Assert.AreEqual("failed", getDoc.RootElement.GetProperty("status").GetString());
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T025: bg=false — handler returns incomplete → GET 200
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task NonBg_Incomplete_GET_Returns200()
    {
        Handler.EventFactory = (req, ctx, ct) => IncompleteStream(ctx);

        var postResponse = await PostResponsesAsync(new { model = "test" });
        Assert.AreEqual(HttpStatusCode.OK, postResponse.StatusCode);

        using var postDoc = await ParseJsonAsync(postResponse);
        var responseId = postDoc.RootElement.GetProperty("id").GetString()!;
        Assert.AreEqual("incomplete", postDoc.RootElement.GetProperty("status").GetString());

        // Non-bg incomplete → persisted → GET 200
        var getResponse = await GetResponseAsync(responseId);
        Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);
        using var getDoc = await ParseJsonAsync(getResponse);
        Assert.AreEqual("incomplete", getDoc.RootElement.GetProperty("status").GetString());
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
        Assert.AreEqual(HttpStatusCode.OK, postResponse.StatusCode);
        using var postDoc = await ParseJsonAsync(postResponse);
        var responseId = postDoc.RootElement.GetProperty("id").GetString()!;

        // Handler is in-flight (bg POST returns after response.created is yielded)
        // Cancel the response
        var cancelResponse = await CancelResponseAsync(responseId);
        Assert.AreEqual(HttpStatusCode.OK, cancelResponse.StatusCode);

        // Wait for bg task to complete
        await WaitForBackgroundCompletionAsync(responseId);

        // bg cancelled → persisted → GET 200
        var getResponse = await GetResponseAsync(responseId);
        Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);
        using var getDoc = await ParseJsonAsync(getResponse);
        Assert.AreEqual("cancelled", getDoc.RootElement.GetProperty("status").GetString());
        Assert.AreEqual(0, getDoc.RootElement.GetProperty("output").GetArrayLength());
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
        Assert.AreEqual(HttpStatusCode.OK, streamResponse.StatusCode);
        var events = await ParseSseAsync(streamResponse);
        using var eventDoc = JsonDocument.Parse(events[0].Data);
        var streamResponseId = eventDoc.RootElement.GetProperty("response")
            .GetProperty("id").GetString()!;

        var getStreamResponse = await GetResponseAsync(streamResponseId);
        Assert.AreEqual(HttpStatusCode.OK, getStreamResponse.StatusCode);

        // Non-bg+nostream completes → persisted → GET 200
        var noStreamResponse = await PostResponsesAsync(new { model = "test" });
        Assert.AreEqual(HttpStatusCode.OK, noStreamResponse.StatusCode);
        using var noStreamDoc = await ParseJsonAsync(noStreamResponse);
        var noStreamResponseId = noStreamDoc.RootElement.GetProperty("id").GetString()!;

        var getNoStreamResponse = await GetResponseAsync(noStreamResponseId);
        Assert.AreEqual(HttpStatusCode.OK, getNoStreamResponse.StatusCode);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Helpers
    // ═══════════════════════════════════════════════════════════════════════

    /// <summary>
    /// Handler that signals when started, then waits for cancellation.
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> DisconnectTrackingStream(
        IResponseContext ctx, TaskCompletionSource started, TaskCompletionSource cancelled,
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
        IResponseContext ctx, Task gate,
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
        IResponseContext ctx)
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
        IResponseContext ctx)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        await Task.CompletedTask;
        yield return stream.EmitIncomplete();
    }
}
