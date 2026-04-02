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

        // Clean up — handler should eventually exit via cancellation
        tcs.TrySetResult();
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
        XAssert.Contains("synchronous", error.GetProperty("message").GetString());
    }

    [Test]
    public async Task Cancel_UnknownId_Returns404_WithErrorShape()
    {
        var cancelResponse = await CancelResponseAsync("caresp_nonexistent_id");

        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        using var doc = await ParseJsonAsync(cancelResponse);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
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
}
