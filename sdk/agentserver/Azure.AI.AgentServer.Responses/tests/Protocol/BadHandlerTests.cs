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
/// Protocol tests for bad handler detection (S-031 through S-033, S-015/B32).
/// Verifies that the SDK correctly surfaces errors to clients when the
/// handler violates the event stream contract.
/// </summary>
public class BadHandlerTests : ProtocolTestBase
{
    // ═══════════════════════════════════════════════════════════════════════
    // T028: Handler yields wrong first event (not response.created)
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task WrongFirstEvent_Stream_ReturnsErrorEvent()
    {
        // Handler yields an output event as first event (not response.created)
        Handler.EventFactory = (req, ctx, ct) => WrongFirstEventStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var events = await ParseSseAsync(response);
        XAssert.Contains(events, e => e.EventType == "error");
        // No response.created should have been emitted
        XAssert.DoesNotContain(events, e => e.EventType == "response.created");
    }

    [Test]
    public async Task WrongFirstEvent_NoStream_Returns500()
    {
        Handler.EventFactory = (req, ctx, ct) => WrongFirstEventStream(ctx);

        var response = await PostResponsesAsync(new { model = "test" });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("server_error"));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T029: Handler returns empty enumerable
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task EmptyEnumerable_Stream_ReturnsErrorEvent()
    {
        Handler.EventFactory = (req, ctx, ct) => EmptyStream();

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var events = await ParseSseAsync(response);
        XAssert.Contains(events, e => e.EventType == "error");
    }

    [Test]
    public async Task EmptyEnumerable_NoStream_Returns500()
    {
        Handler.EventFactory = (req, ctx, ct) => EmptyStream();

        var response = await PostResponsesAsync(new { model = "test" });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("message").GetString(), Is.EqualTo("An internal server error occurred."));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T030: Handler throws before response.created
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task ThrowBeforeCreated_Stream_ReturnsErrorEvent()
    {
        Handler.EventFactory = (req, ctx, ct) => ThrowBeforeCreatedStream();

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var events = await ParseSseAsync(response);
        XAssert.Contains(events, e => e.EventType == "error");
        XAssert.DoesNotContain(events, e => e.EventType == "response.created");
    }

    [Test]
    public async Task ThrowBeforeCreated_NoStream_Returns500()
    {
        Handler.EventFactory = (req, ctx, ct) => ThrowBeforeCreatedStream();

        var response = await PostResponsesAsync(new { model = "test" });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("server_error"));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T031: Handler ends after response.created without terminal event
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task MissingTerminal_Stream_EmitsResponseFailed()
    {
        Handler.EventFactory = (req, ctx, ct) => CreatedOnlyStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var events = await ParseSseAsync(response);
        XAssert.Contains(events, e => e.EventType == "response.created");
        // SDK should auto-fail (S-015/B32)
        XAssert.Contains(events, e => e.EventType == "response.failed");
    }

    [Test]
    public async Task MissingTerminal_NoStream_ReturnsFailed()
    {
        Handler.EventFactory = (req, ctx, ct) => CreatedOnlyStream(ctx);

        var response = await PostResponsesAsync(new { model = "test" });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var doc = await ParseJsonAsync(response);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("failed"));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T032: Handler throws after response.created
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task ThrowAfterCreated_Stream_EmitsResponseFailed()
    {
        Handler.EventFactory = (req, ctx, ct) => ThrowAfterCreatedStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var events = await ParseSseAsync(response);
        XAssert.Contains(events, e => e.EventType == "response.created");
        XAssert.Contains(events, e => e.EventType == "response.failed");
    }

    [Test]
    public async Task ThrowAfterCreated_NoStream_ReturnsFailed()
    {
        Handler.EventFactory = (req, ctx, ct) => ThrowAfterCreatedStream(ctx);

        var response = await PostResponsesAsync(new { model = "test" });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var doc = await ParseJsonAsync(response);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("failed"));
        // Should have error info
        Assert.That(doc.RootElement.TryGetProperty("error", out var error), Is.True);
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("server_error"));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T033: Bad-handler error logs include handler type, request ID, detail
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task BadHandler_NoStream_ErrorContainsDiagnosticInfo()
    {
        // Empty handler triggers bad-handler detection
        Handler.EventFactory = (req, ctx, ct) => EmptyStream();

        var response = await PostResponsesAsync(new { model = "test" });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        // Error should contain diagnostic message
        var message = error.GetProperty("message").GetString()!;
        Assert.That(string.IsNullOrWhiteSpace(message), Is.False);
    }

    [Test]
    public async Task BadHandler_Stream_ErrorContainsDiagnosticInfo()
    {
        // Wrong first event triggers bad-handler detection
        Handler.EventFactory = (req, ctx, ct) => WrongFirstEventStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var events = await ParseSseAsync(response);
        var errorEvent = events.FirstOrDefault(e => e.EventType == "error");
        Assert.That(errorEvent, Is.Not.Null);
        // Error data should contain diagnostic info
        using var errorDoc = JsonDocument.Parse(errorEvent.Data);
        var message = errorDoc.RootElement.GetProperty("message").GetString()!;
        Assert.That(string.IsNullOrWhiteSpace(message), Is.False);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Helpers
    // ═══════════════════════════════════════════════════════════════════════

    /// <summary>
    /// Handler that yields an output event as first event (not response.created).
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> WrongFirstEventStream(
        ResponseContext ctx)
    {
        await Task.CompletedTask;
        var response = new Models.ResponseObject(ctx.ResponseId, "test");
        // Yield a completed event directly — violates contract
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }

    /// <summary>
    /// Handler that returns immediately with no events.
    /// </summary>
#pragma warning disable CS1998 // Async method lacks 'await' operators
    private static async IAsyncEnumerable<ResponseStreamEvent> EmptyStream()
    {
        yield break;
    }
#pragma warning restore CS1998

    /// <summary>
    /// Handler that throws before yielding any events.
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> ThrowBeforeCreatedStream()
    {
        await Task.CompletedTask;
        throw new InvalidOperationException("Handler failed before response.created");
#pragma warning disable CS0162 // Unreachable code — yield break required for async iterator signature
        yield break;
#pragma warning restore CS0162
    }

    /// <summary>
    /// Handler that yields response.created only (no terminal event).
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> CreatedOnlyStream(
        ResponseContext ctx)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        await Task.CompletedTask;
        // No terminal event — handler just ends
    }

    /// <summary>
    /// Handler that yields response.created then throws.
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> ThrowAfterCreatedStream(
        ResponseContext ctx)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        await Task.CompletedTask;
        throw new InvalidOperationException("Simulated handler failure after created");
    }
}
