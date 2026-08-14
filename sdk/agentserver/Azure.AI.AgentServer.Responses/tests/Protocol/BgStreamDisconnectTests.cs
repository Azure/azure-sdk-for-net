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
/// Protocol tests for User Story 3 — Background Streaming Handler Survives Disconnect.
/// Verifies B18 (handler continues after SSE disconnect for bg+stream),
/// B18 (SSE write failure does NOT cancel handler CT).
/// </summary>
public class BgStreamDisconnectTests : ProtocolTestBase
{
    // ═══════════════════════════════════════════════════════════════════════
    // T036: bg+stream — client disconnects after 3 events, handler produces
    // 10 total → GET returns completed with all output items
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task BgStream_ClientDisconnects_HandlerCompletesAllEvents()
    {
        const int totalOutputs = 10;
        const int disconnectAfterOutput = 3;
        var readyForDisconnect = new TaskCompletionSource();
        var handlerCompleted = new TaskCompletionSource();

        Handler.EventFactory = (req, ctx, ct) => MultiOutputStream(
            ctx, totalOutputs, disconnectAfterOutput,
            readyForDisconnect, handlerCompleted, ct);

        var cts = new CancellationTokenSource();
        var json = JsonSerializer.Serialize(
            new { model = "test", background = true, stream = true });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var postTask = Client.PostAsync("/responses", content, cts.Token);

        // Wait for handler to signal it's past the disconnect point
        await readyForDisconnect.Task.WaitAsync(TimeSpan.FromSeconds(5));
        var responseId = Handler.LastContext!.ResponseId;

        // Disconnect the SSE client
        cts.Cancel();
        try
        { await postTask; }
        catch (TaskCanceledException) { }

        // Wait for handler to complete all events
        await handlerCompleted.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Wait for orchestrator to persist terminal status
        await WaitForBackgroundCompletionAsync(responseId);

        // GET should return completed (handler produced all events)
        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(getResponse);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T037: bg+stream — SSE write failure does NOT cancel handler CT
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task BgStream_SseWriteFailure_DoesNotCancelHandlerCt()
    {
        var readyForDisconnect = new TaskCompletionSource();
        var handlerCancelled = new TaskCompletionSource();
        var handlerCompleted = new TaskCompletionSource();

        Handler.EventFactory = (req, ctx, ct) =>
            CancellationTrackingStream(ctx, readyForDisconnect, handlerCancelled,
                handlerCompleted, ct);

        var cts = new CancellationTokenSource();
        var json = JsonSerializer.Serialize(
            new { model = "test", background = true, stream = true });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var postTask = Client.PostAsync("/responses", content, cts.Token);

        // Wait for handler to be ready
        await readyForDisconnect.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Disconnect
        cts.Cancel();
        try
        { await postTask; }
        catch (TaskCanceledException) { }

        // Wait for handler to complete
        var completedTask = await Task.WhenAny(
            handlerCompleted.Task,
            handlerCancelled.Task,
            Task.Delay(TimeSpan.FromSeconds(3)));

        // Handler should have COMPLETED, not been CANCELLED
        Assert.That(handlerCompleted.Task.IsCompleted, Is.True, "Handler should complete normally, not be cancelled by SSE disconnect");
        Assert.That(handlerCancelled.Task.IsCompleted, Is.False, "Handler CT should NOT have been cancelled by SSE disconnect");
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T038: bg+nostream — handler continues after disconnect (regression)
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task BgNoStream_HandlerContinuesAfterDisconnect()
    {
        var handlerCompleted = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) =>
            SlowCompletingStream(ctx, handlerCompleted, ct);

        // POST bg+nostream returns immediately
        var json = JsonSerializer.Serialize(
            new { model = "test", background = true });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var postResponse = await Client.PostAsync("/responses", content);
        Assert.That(postResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var postDoc = await ParseJsonAsync(postResponse);
        var responseId = postDoc.RootElement.GetProperty("id").GetString()!;

        // Handler is still running, wait for it to complete
        await handlerCompleted.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Wait for orchestrator to persist terminal status
        await WaitForBackgroundCompletionAsync(responseId);

        // GET should return completed
        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var getDoc = await ParseJsonAsync(getResponse);
        Assert.That(getDoc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Helpers
    // ═══════════════════════════════════════════════════════════════════════

    /// <summary>
    /// Handler that produces N output items, signals for disconnect after M items,
    /// and continues to completion.
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> MultiOutputStream(
        ResponseContext ctx, int totalOutputs, int disconnectAfter,
        TaskCompletionSource readyForDisconnect, TaskCompletionSource completed,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();

        for (var i = 0; i < totalOutputs; i++)
        {
            yield return new ResponseOutputItemDoneEvent();

            if (i == disconnectAfter - 1)
            {
                readyForDisconnect.TrySetResult();
                // Give client time to disconnect without using handler CT
                await Task.Delay(300, CancellationToken.None);
            }
        }

        yield return stream.EmitCompleted();
        completed.TrySetResult();
    }

    /// <summary>
    /// Handler that tracks whether it was cancelled vs completed.
    /// Signals readyForDisconnect after response.created, then continues.
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> CancellationTrackingStream(
        ResponseContext ctx, TaskCompletionSource readyForDisconnect,
        TaskCompletionSource cancelled, TaskCompletionSource completed,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();

        readyForDisconnect.TrySetResult();

        // Wait without using handler CT (delay uses CancellationToken.None)
        await Task.Delay(500, CancellationToken.None);

        // Check if CT was cancelled by SSE disconnect
        if (ct.IsCancellationRequested)
        {
            cancelled.TrySetResult();
            ct.ThrowIfCancellationRequested();
        }

        yield return stream.EmitCompleted();
        completed.TrySetResult();
    }

    /// <summary>
    /// Handler that takes a moment to complete (for bg+nostream regression test).
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> SlowCompletingStream(
        ResponseContext ctx, TaskCompletionSource completed,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();

        await Task.Delay(200, CancellationToken.None);

        yield return stream.EmitCompleted();
        completed.TrySetResult();
    }
}
