// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol conformance tests for POST /responses/{id}/cancel.
/// Validates cancellation behavior and error responses.
/// All assertions use HttpClient + JsonDocument only — no SDK model types in assertions.
/// </summary>
public class CancelResponseProtocolTests : ProtocolTestBase
{
    [Test]
    public async Task Cancel_InProgressResponse_Returns200_WithResponse()
    {
        var tcs = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => WaitingStream(ctx, tcs.Task, ct);

        var responseId = await CreateBackgroundResponseAsync();

        var cancelResponse = await CancelResponseAsync(responseId);

        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(cancelResponse.Content.Headers.ContentType?.MediaType, Is.EqualTo("application/json"));

        using var doc = await ParseJsonAsync(cancelResponse);
        Assert.That(doc.RootElement.GetProperty("id").GetString(), Is.EqualTo(responseId));
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("cancelled"),
            "Cancel endpoint must always return a cancelled snapshot");

        // Clean up — handler should eventually exit via cancellation
        tcs.TrySetResult();
        await Task.Delay(200);
    }

    [Test]
    public async Task Cancel_UncooperativeHandler_StillReturnsCancelledStatus()
    {
        // Handler that ignores CancellationToken — simulates a handler that
        // doesn't cooperate within the grace period. The cancel endpoint must
        // still return a cancelled snapshot, not in_progress.
        var handlerCompleted = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => UncooperativeStream(ctx, handlerCompleted);

        var responseId = await CreateBackgroundResponseAsync();

        var cancelResponse = await CancelResponseAsync(responseId);

        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var doc = await ParseJsonAsync(cancelResponse);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("cancelled"),
            "Cancel endpoint must return cancelled even when handler doesn't cooperate");

        // Let the handler finish so background task cleans up
        handlerCompleted.TrySetResult();
        await Task.Delay(200);
    }

    [Test]
    public async Task Cancel_InProgressResponse_TriggersCancellationToken()
    {
        var tcs = new TaskCompletionSource();
        var handlerCancelled = new TaskCompletionSource();

        Handler.EventFactory = (req, ctx, ct) => CancellationTrackingStream(ctx, tcs.Task, handlerCancelled, ct);

        var responseId = await CreateBackgroundResponseAsync();

        // Cancel the response
        await CancelResponseAsync(responseId);

        // Handler should have been cancelled
        await handlerCancelled.Task.WaitAsync(TimeSpan.FromSeconds(5));
        // If we get here without timeout, the handler was cancelled

        tcs.TrySetResult();
    }

    [Test]
    public async Task Cancel_NonBgCompletedResponse_Returns400()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleStream(ctx);

        var responseId = await CreateDefaultResponseAsync();

        // Cancel a non-background response → 400 (per B1: non-bg cannot be cancelled)
        var cancelResponse = await CancelResponseAsync(responseId);

        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        using var doc = await ParseJsonAsync(cancelResponse);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("invalid_request_error"));
        XAssert.Contains("synchronous", error.GetProperty("message").GetString());
    }

    [Test]
    public async Task Cancel_UnknownId_Returns404_WithErrorShape()
    {
        var cancelResponse = await CancelResponseAsync(IdGenerator.NewResponseId());

        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        using var doc = await ParseJsonAsync(cancelResponse);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("invalid_request_error"));
        Assert.That(string.IsNullOrEmpty(error.GetProperty("message").GetString()), Is.False);
    }

    [Test]
    public async Task Cancel_Twice_IsIdempotent()
    {
        var tcs = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => WaitingStream(ctx, tcs.Task, ct);

        var responseId = await CreateBackgroundResponseAsync();

        // Cancel twice
        var first = await CancelResponseAsync(responseId);
        var second = await CancelResponseAsync(responseId);

        Assert.That(first.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(second.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        tcs.TrySetResult();
        await Task.Delay(200);
    }

    [Test]
    public async Task Cancel_PersistedState_IsCancelled_EvenWhenHandlerCompletesAfterTimeout()
    {
        // B11 race condition test: handler ignores CancellationToken and eventually
        // yields response.completed AFTER the cancel endpoint returns. The durable
        // store must still reflect "cancelled", not "completed".
        var handlerCompleted = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => UncooperativeStream(ctx, handlerCompleted);

        var responseId = await CreateBackgroundResponseAsync();

        // Cancel — this will force status to cancelled after 10s timeout
        var cancelResponse = await CancelResponseAsync(responseId);
        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var cancelDoc = await ParseJsonAsync(cancelResponse);
        Assert.That(cancelDoc.RootElement.GetProperty("status").GetString(), Is.EqualTo("cancelled"));

        // Now let the handler finish — it will try to yield response.completed
        handlerCompleted.TrySetResult();

        // Wait for the background task to fully finalize (FinalizeExecutionAsync → UpdateResponseAsync)
        await Task.Delay(1000);

        // GET the response from the durable store — must still be cancelled
        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var getDoc = await ParseJsonAsync(getResponse);
        Assert.That(getDoc.RootElement.GetProperty("status").GetString(), Is.EqualTo("cancelled"),
            "B11: Persisted state must be 'cancelled' — cancellation always wins, " +
            "even when the handler yields response.completed after the cancel timeout");
    }

    // ── Helper event factories ─────────────────────────────────

    private static async IAsyncEnumerable<ResponseStreamEvent> SimpleStream(
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

    private static async IAsyncEnumerable<ResponseStreamEvent> CancellationTrackingStream(
        ResponseContext ctx,
        Task waitTask,
        TaskCompletionSource handlerCancelled,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();

        try
        {
            await waitTask.WaitAsync(ct);
        }
        catch (OperationCanceledException)
        {
            handlerCancelled.TrySetResult();
            throw;
        }

        yield return stream.EmitCompleted();
    }

    /// <summary>
    /// Handler that does NOT observe CancellationToken — waits on an external
    /// signal instead, simulating a handler that ignores cancellation.
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> UncooperativeStream(
        ResponseContext ctx,
        TaskCompletionSource handlerCompleted)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        // Wait WITHOUT ct — handler ignores cancellation
        await handlerCompleted.Task;
        yield return stream.EmitCompleted();
    }
}
