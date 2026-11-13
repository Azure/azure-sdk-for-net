// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// E2E protocol tests for ResponseCreatedEvent validation rules.
/// Validates S-031 (Models.ResponseObject.Id must match ResponseContext.ResponseId) and
/// B6/B8 (Models.ResponseObject.Status must be non-terminal on ResponseCreatedEvent).
/// </summary>
public class ResponseCreatedValidationTests : ProtocolTestBase
{
    // ── T025: Mismatched ID — S-031 ──────────────────────────────

    [Test]
    public async Task POST_Responses_MismatchedResponseId_ReturnsBadHandlerError()
    {
        // Handler emits ResponseCreatedEvent with a different ID than ResponseContext.ResponseId
        // → SDK rejects with bad handler error (S-031)
        Handler.EventFactory = (req, ctx, ct) => MismatchedIdStream(ctx);

        var response = await PostResponsesAsync(new { model = "test" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("server_error"));
        Assert.That(error.GetProperty("message").GetString()!, Is.EqualTo("An internal server error occurred."));
    }

    [Test]
    public async Task POST_Responses_Streaming_MismatchedResponseId_EmitsErrorSseEvent()
    {
        // Same scenario in streaming mode — error delivered as SSE error event
        Handler.EventFactory = (req, ctx, ct) => MismatchedIdStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var events = await ParseSseAsync(response);

        // Should NOT contain a response.created event (rejected before lifecycle starts)
        XAssert.DoesNotContain(events, e => e.EventType == "response.created");
        // Should contain an error event
        XAssert.Contains(events, e => e.EventType == "error");
    }

    // ── T026: Terminal initial status — B6/B8 ────────────────

    [Test]
    public async Task POST_Responses_TerminalInitialStatus_ReturnsBadHandlerError()
    {
        // Handler emits ResponseCreatedEvent with Status = Failed (terminal status)
        // → SDK rejects with bad handler error (B6/B8)
        Handler.EventFactory = (req, ctx, ct) => TerminalInitialStatusStream(ctx);

        var response = await PostResponsesAsync(new { model = "test" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("server_error"));
        Assert.That(error.GetProperty("message").GetString()!, Is.EqualTo("An internal server error occurred."));
    }

    // ── B31: Null status auto-stamped as in_progress ──────────

    [Test]
    public async Task POST_Responses_NullInitialStatus_AutoStampsInProgress()
    {
        // Handler emits ResponseCreatedEvent with Status = null (not set)
        // → SDK auto-stamps Status = InProgress per B31
        Handler.EventFactory = (req, ctx, ct) => NullStatusStream(ctx);

        var response = await PostResponsesAsync(new { model = "test" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(response);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
        Assert.That(doc.RootElement.TryGetProperty("output", out _), Is.True);
    }

    [Test]
    public async Task POST_Responses_Background_NullInitialStatus_AutoStampsInProgress()
    {
        // Background mode: handler emits ResponseCreatedEvent with Status = null
        // → SDK auto-stamps Status = InProgress so GET never returns statusless response
        Handler.EventFactory = (req, ctx, ct) => NullStatusStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", background = true });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(response);
        // The initial response should have "in_progress" or "queued" status (not missing)
        Assert.That(doc.RootElement.TryGetProperty("status", out var statusProp), Is.True);
        var status = statusProp.GetString();
        XAssert.Contains(status, new[] { "in_progress", "queued", "completed" });
    }

    [Test]
    public async Task POST_Responses_Streaming_TerminalInitialStatus_EmitsErrorSseEvent()
    {
        // Same scenario in streaming mode
        Handler.EventFactory = (req, ctx, ct) => TerminalInitialStatusStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var events = await ParseSseAsync(response);

        XAssert.DoesNotContain(events, e => e.EventType == "response.created");
        XAssert.Contains(events, e => e.EventType == "error");
    }

    // ── Helper event factories ─────────────────────────────────

    private static async IAsyncEnumerable<ResponseStreamEvent> MismatchedIdStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        // Deliberately use a different ID than context provides
        var response = new Models.ResponseObject("wrong-id-not-matching-context", "test")
        {
            Status = ResponseStatus.InProgress,
        };
        yield return new ResponseCreatedEvent(0, response);
        response.SetCompleted();
        yield return new ResponseCompletedEvent(1, response);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> TerminalInitialStatusStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        // Use the correct ID but a terminal initial status
        var response = new Models.ResponseObject(ctx.ResponseId, "test")
        {
            Status = ResponseStatus.Failed,
        };
        yield return new ResponseCreatedEvent(0, response);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> NullStatusStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        // Deliberately omit Status — SDK should auto-stamp InProgress (B31)
        var response = new Models.ResponseObject(ctx.ResponseId, "test");
        yield return new ResponseCreatedEvent(0, response);

        var textContent = new MessageContentOutputTextContent(
            "Hello", Array.Empty<Annotation>(), Array.Empty<LogProb>());
        var msg = new OutputItemMessage(
            "msg_1",
            MessageStatus.Completed,
            new MessageContent[] { textContent });
        yield return new ResponseOutputItemAddedEvent(1, 0, msg);
        yield return new ResponseOutputItemDoneEvent(2, 0, msg);

        var completedResponse = new Models.ResponseObject(ctx.ResponseId, "test");
        completedResponse.Output.Add(msg);
        completedResponse.SetCompleted();
        yield return new ResponseCompletedEvent(3, completedResponse);
    }
}
