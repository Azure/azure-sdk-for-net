// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol conformance tests for status lifecycle invariants (US5).
/// Validates <c>completed_at</c> presence/absence for each status value.
/// </summary>
public class StatusLifecycleTests : ProtocolTestBase
{
    // ── T017: completed → completed_at non-null ────────────────

    [Test]
    public async Task Completed_Response_HasCompletedAt()
    {
        var response = await PostResponsesAsync(new { model = "test" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var doc = await ParseJsonAsync(response);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
        // completed_at MUST be present and non-null for completed responses
        Assert.That(doc.RootElement.TryGetProperty("completed_at", out var completedAt), Is.True);
        Assert.That(completedAt.ValueKind, Is.Not.EqualTo(JsonValueKind.Null));
    }

    // ── T017: failed → completed_at null ────────────────────────

    [Test]
    public async Task Failed_Response_HasNullCompletedAt()
    {
        // Handler throws before response.created → pre-created error → 500 error JSON
        Handler.EventFactory = (req, ctx, ct) => ThrowingStream(ctx);

        var response = await PostResponsesAsync(new { model = "test" });

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.InternalServerError));
        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("message").GetString(), Is.Not.Null);
    }

    // ── T017: incomplete → completed_at null ────────────────────

    [Test]
    public async Task Incomplete_Response_HasNullCompletedAt()
    {
        Handler.EventFactory = (req, ctx, ct) => IncompleteStream(ctx);

        var response = await PostResponsesAsync(new { model = "test" });

        using var doc = await ParseJsonAsync(response);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("incomplete"));
        if (doc.RootElement.TryGetProperty("completed_at", out var completedAt))
        {
            Assert.That(completedAt.ValueKind, Is.EqualTo(JsonValueKind.Null));
        }
    }

    // ── T018: in_progress → completed_at null ────────────────────

    [Test]
    public async Task InProgress_Response_HasNullCompletedAt()
    {
        var tcs = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => WaitingStream(ctx, tcs.Task, ct);

        // Create background response (returns immediately while handler runs)
        var responseId = await CreateBackgroundResponseAsync();

        // Poll GET while handler is still running
        var getResponse = await GetResponseAsync(responseId);
        using var doc = await ParseJsonAsync(getResponse);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("in_progress"));
        if (doc.RootElement.TryGetProperty("completed_at", out var completedAt))
        {
            Assert.That(completedAt.ValueKind, Is.EqualTo(JsonValueKind.Null));
        }

        tcs.TrySetResult();
        await Task.Delay(200);
    }

    // ── T019: zero events → completed with empty output ────────────
    // Validates: B6 — Zero-output completion is valid (status completed, output [])

    [Test]
    public async Task ZeroOutputEvents_Completed_WithEmptyOutput()
    {
        // Empty handler (no events) → S-015 bad handler → 500 error
        Handler.EventFactory = (req, ctx, ct) => EmptyStream();

        var response = await PostResponsesAsync(new { model = "test" });

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.InternalServerError));
        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("message").GetString(), Is.EqualTo("An internal server error occurred."));
    }

    // ── T020: Handler starts with queued status ────────────────

    [Test]
    public async Task Streaming_QueuedStatus_HonouredInCreatedEvent()
    {
        Handler.EventFactory = (req, ctx, ct) => QueuedThenCompletedStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        var events = await ParseSseAsync(response);

        // First event is response.created with status "queued"
        var createdEvent = events.First(e => e.EventType == "response.created");
        using var doc = JsonDocument.Parse(createdEvent.Data);
        Assert.That(
            doc.RootElement.GetProperty("response").GetProperty("status").GetString(),
            Is.EqualTo("queued"),
            "Handler set status to queued but the response.created event did not honour it.");
    }

    [Test]
    public async Task Background_QueuedStatus_HonouredInPostResponse()
    {
        var tcs = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => QueuedWaitingStream(ctx, tcs.Task, ct);

        var response = await PostResponsesAsync(new { model = "test", background = true });

        using var doc = await ParseJsonAsync(response);
        Assert.That(
            doc.RootElement.GetProperty("status").GetString(),
            Is.EqualTo("queued"),
            "Handler set status to queued but the background POST response did not honour it.");

        // Clean up — let handler finish
        tcs.SetResult();
        await WaitForBackgroundCompletionAsync(
            doc.RootElement.GetProperty("id").GetString()!);
    }

    [Test]
    public async Task Background_QueuedStatus_EventuallyCompletes()
    {
        var tcs = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => QueuedWaitingStream(ctx, tcs.Task, ct);

        var createResponse = await PostResponsesAsync(new { model = "test", background = true });
        using var createDoc = await ParseJsonAsync(createResponse);
        var responseId = createDoc.RootElement.GetProperty("id").GetString()!;

        // Verify initial queued status
        Assert.That(createDoc.RootElement.GetProperty("status").GetString(), Is.EqualTo("queued"));

        // Let handler finish
        tcs.SetResult();
        await WaitForBackgroundCompletionAsync(responseId);

        // Final GET returns completed
        var getResponse = await GetResponseAsync(responseId);
        using var getDoc = await ParseJsonAsync(getResponse);
        Assert.That(getDoc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    // ── Helper event factories ─────────────────────────────────

    private static async IAsyncEnumerable<ResponseStreamEvent> ThrowingStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        throw new InvalidOperationException("Simulated failure");
#pragma warning disable CS0162
        yield break;
#pragma warning restore CS0162
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> IncompleteStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        yield return stream.EmitIncomplete(ResponseIncompleteDetailsReason.MaxOutputTokens);
        await Task.CompletedTask;
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

    private static async IAsyncEnumerable<ResponseStreamEvent> QueuedThenCompletedStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated(ResponseStatus.Queued);
        yield return stream.EmitInProgress();
        yield return stream.EmitCompleted();
        await Task.CompletedTask;
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> QueuedWaitingStream(
        ResponseContext ctx,
        Task waitTask,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated(ResponseStatus.Queued);
        await waitTask.WaitAsync(ct);
        yield return stream.EmitInProgress();
        yield return stream.EmitCompleted();
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> EmptyStream(
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        yield break;
    }
}
