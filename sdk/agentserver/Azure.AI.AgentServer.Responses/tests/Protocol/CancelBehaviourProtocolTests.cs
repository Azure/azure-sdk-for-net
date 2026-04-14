// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol conformance tests for cancel endpoint behaviour (US1).
/// Validates the complete cancellation scenario matrix from the API Behaviour Contract.
/// </summary>
public class CancelBehaviourProtocolTests : ProtocolTestBase
{
    // ── Rejection: Non-background responses → 400 ──────────────

    // T035: S4 — cancel completed non-bg non-streaming → 400
    [Test]
    public async Task Cancel_NonBgNonStreaming_Completed_Returns400()
    {
        Handler.EventFactory = (req, ctx, ct) => CompleteImmediately(ctx);
        var responseId = await CreateDefaultResponseAsync();

        var cancelResponse = await CancelResponseAsync(responseId);

        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        using var doc = await ParseJsonAsync(cancelResponse);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        XAssert.Contains("synchronous", error.GetProperty("message").GetString());
    }

    // T036: S5 — cancel completed non-bg streaming → 400
    [Test]
    public async Task Cancel_NonBgStreaming_Completed_Returns400()
    {
        Handler.EventFactory = (req, ctx, ct) => CompleteImmediately(ctx);
        var responseId = await CreateStreamingResponseAsync();

        var cancelResponse = await CancelResponseAsync(responseId);

        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        using var doc = await ParseJsonAsync(cancelResponse);
        var error = doc.RootElement.GetProperty("error");
        XAssert.Contains("synchronous", error.GetProperty("message").GetString());
    }

    // ── Rejection: Terminal background responses → 400 ─────────

    // T037: S2 — cancel completed bg non-streaming → 400
    [Test]
    public async Task Cancel_BgNonStreaming_Completed_Returns400()
    {
        Handler.EventFactory = (req, ctx, ct) => CompleteImmediately(ctx);
        var responseId = await CreateBackgroundResponseAsync();

        // Wait for handler to reach terminal status
        await WaitForBackgroundCompletionAsync(responseId);

        var cancelResponse = await CancelResponseAsync(responseId);

        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        using var doc = await ParseJsonAsync(cancelResponse);
        var error = doc.RootElement.GetProperty("error");
        XAssert.Contains("completed", error.GetProperty("message").GetString());
    }

    // T038: S3 — cancel completed bg streaming → 400
    [Test]
    public async Task Cancel_BgStreaming_Completed_Returns400()
    {
        Handler.EventFactory = (req, ctx, ct) => CompleteImmediately(ctx);

        // Create bg streaming response — currently this runs inline so POST blocks
        var httpResponse = await PostResponsesAsync(new { model = "test", stream = true, background = true });
        var events = await ParseSseAsync(httpResponse);
        using var doc0 = JsonDocument.Parse(events[0].Data);
        var responseId = doc0.RootElement.GetProperty("response").GetProperty("id").GetString()!;

        var cancelResponse = await CancelResponseAsync(responseId);

        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        using var doc = await ParseJsonAsync(cancelResponse);
        var error = doc.RootElement.GetProperty("error");
        XAssert.Contains("completed", error.GetProperty("message").GetString());
    }

    // T039: cancel failed bg response → 400
    [Test]
    public async Task Cancel_BgNonStreaming_Failed_Returns400()
    {
        // Handler emits response.created then fails — response reaches 'failed' state in store.
        Handler.EventFactory = (req, ctx, ct) => FailAfterCreated(ctx);
        var responseId = await CreateBackgroundResponseAsync();

        // Wait for background handler to fail and persist the failed state
        await WaitForBackgroundCompletionAsync(responseId);

        var cancelResponse = await CancelResponseAsync(responseId);

        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        using var doc = await ParseJsonAsync(cancelResponse);
        var error = doc.RootElement.GetProperty("error");
        XAssert.Contains("failed", error.GetProperty("message").GetString());
    }

    // ── Successful cancel: In-progress background → 200 ────────

    // T040: S1 — cancel in-flight bg non-streaming → 200 cancelled
    [Test]
    public async Task Cancel_BgNonStreaming_InProgress_Returns200_Cancelled()
    {
        var tcs = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => WaitingStream(ctx, tcs.Task, ct);

        var responseId = await CreateBackgroundResponseAsync();

        var cancelResponse = await CancelResponseAsync(responseId);

        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var doc = await ParseJsonAsync(cancelResponse);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("cancelled"));
        // Output should be empty (cleared by SetCancelled)
        var output = doc.RootElement.GetProperty("output");
        Assert.That(output.GetArrayLength(), Is.EqualTo(0));

        tcs.TrySetResult(); // clean up
    }

    // T042: cancel bg non-streaming mid-flight (handler has emitted deltas)
    //              → 200 status: cancelled, output: []
    // Note: S6 applies to bg streaming; this test uses bg non-streaming
    // which exercises the same cancel winddown path (B11) in a simpler setup.
    [Test]
    public async Task Cancel_BgNonStreaming_MidFlight_Returns200_EmptyOutput()
    {
        var tcs = new TaskCompletionSource();
        var deltasEmitted = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => StreamWithDeltas(ctx, tcs.Task, deltasEmitted, ct);

        var responseId = await CreateBackgroundResponseAsync();

        // Wait for handler to have emitted deltas (deterministic gate)
        await deltasEmitted.Task.WaitAsync(TimeSpan.FromSeconds(5));

        var cancelResponse = await CancelResponseAsync(responseId);

        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var doc = await ParseJsonAsync(cancelResponse);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("cancelled"));
        Assert.That(doc.RootElement.GetProperty("output").GetArrayLength(), Is.EqualTo(0));

        tcs.TrySetResult();
    }

    // ── Idempotency ──────────────────────────────────────────────

    // T043: B3 — cancel already-cancelled bg response → 200 idempotent
    [Test]
    public async Task Cancel_AlreadyCancelled_Returns200_Idempotent()
    {
        var tcs = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => WaitingStream(ctx, tcs.Task, ct);

        var responseId = await CreateBackgroundResponseAsync();

        // First cancel
        var first = await CancelResponseAsync(responseId);
        Assert.That(first.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Second cancel — idempotent
        var second = await CancelResponseAsync(responseId);
        Assert.That(second.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var doc = await ParseJsonAsync(second);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("cancelled"));

        tcs.TrySetResult();
    }

    // T044: cancel unknown ID → 404
    [Test]
    public async Task Cancel_UnknownId_Returns404()
    {
        var cancelResponse = await CancelResponseAsync("resp_nonexistent");

        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    // T045: OCE during winddown → status: cancelled (not failed)
    [Test]
    public async Task Cancel_HandlerThrowsOCE_ResultsInCancelled()
    {
        var handlerStarted = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => ThrowOnCancel(ctx, handlerStarted, ct);

        var responseId = await CreateBackgroundResponseAsync();

        // Wait for handler to start (deterministic gate)
        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));

        var cancelResponse = await CancelResponseAsync(responseId);

        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var doc = await ParseJsonAsync(cancelResponse);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("cancelled"));
    }

    // ── Helper event factories ─────────────────────────────────

    private static async IAsyncEnumerable<ResponseStreamEvent> CompleteImmediately(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
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

    private static async IAsyncEnumerable<ResponseStreamEvent> StreamWithDeltas(
        ResponseContext ctx,
        Task waitTask,
        TaskCompletionSource deltasEmitted,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        // Emit some content before waiting
        var item = stream.AddOutputItemMessage();
        var content = item.AddTextContent();
        yield return content.EmitAdded();
        yield return content.EmitDelta("Hello ");
        yield return content.EmitDelta("World");
        deltasEmitted.TrySetResult();
        // Wait for cancellation/signal
        await waitTask.WaitAsync(ct);
        yield return stream.EmitCompleted();
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> FailAfterCreated(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        throw new InvalidOperationException("Simulated handler failure after created");
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> ThrowOnCancel(
        ResponseContext ctx,
        TaskCompletionSource handlerStarted,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        // Signal that handler has started and is waiting for cancellation
        handlerStarted.TrySetResult();
        // Wait for cancellation, then throw OCE
        var tcs = new TaskCompletionSource();
        ct.Register(() => tcs.TrySetResult());
        await tcs.Task;
        ct.ThrowIfCancellationRequested();
        yield return stream.EmitCompleted(); // unreachable
    }
}
