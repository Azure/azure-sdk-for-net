using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol tests for bad handler detection (FR-006 through FR-011).
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
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

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
        Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.AreEqual("server_error", error.GetProperty("type").GetString());
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T029: Handler returns empty enumerable
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task EmptyEnumerable_Stream_ReturnsErrorEvent()
    {
        Handler.EventFactory = (req, ctx, ct) => EmptyStream();

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var events = await ParseSseAsync(response);
        XAssert.Contains(events, e => e.EventType == "error");
    }

    [Test]
    public async Task EmptyEnumerable_NoStream_Returns500()
    {
        Handler.EventFactory = (req, ctx, ct) => EmptyStream();

        var response = await PostResponsesAsync(new { model = "test" });
        Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.AreEqual("An internal server error occurred.", error.GetProperty("message").GetString());
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T030: Handler throws before response.created
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task ThrowBeforeCreated_Stream_ReturnsErrorEvent()
    {
        Handler.EventFactory = (req, ctx, ct) => ThrowBeforeCreatedStream();

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var events = await ParseSseAsync(response);
        XAssert.Contains(events, e => e.EventType == "error");
        XAssert.DoesNotContain(events, e => e.EventType == "response.created");
    }

    [Test]
    public async Task ThrowBeforeCreated_NoStream_Returns500()
    {
        Handler.EventFactory = (req, ctx, ct) => ThrowBeforeCreatedStream();

        var response = await PostResponsesAsync(new { model = "test" });
        Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.AreEqual("server_error", error.GetProperty("type").GetString());
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T031: Handler ends after response.created without terminal event
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task MissingTerminal_Stream_EmitsResponseFailed()
    {
        Handler.EventFactory = (req, ctx, ct) => CreatedOnlyStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var events = await ParseSseAsync(response);
        XAssert.Contains(events, e => e.EventType == "response.created");
        // SDK should auto-fail (FR-009)
        XAssert.Contains(events, e => e.EventType == "response.failed");
    }

    [Test]
    public async Task MissingTerminal_NoStream_ReturnsFailed()
    {
        Handler.EventFactory = (req, ctx, ct) => CreatedOnlyStream(ctx);

        var response = await PostResponsesAsync(new { model = "test" });
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        using var doc = await ParseJsonAsync(response);
        Assert.AreEqual("failed", doc.RootElement.GetProperty("status").GetString());
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T032: Handler throws after response.created
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task ThrowAfterCreated_Stream_EmitsResponseFailed()
    {
        Handler.EventFactory = (req, ctx, ct) => ThrowAfterCreatedStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var events = await ParseSseAsync(response);
        XAssert.Contains(events, e => e.EventType == "response.created");
        XAssert.Contains(events, e => e.EventType == "response.failed");
    }

    [Test]
    public async Task ThrowAfterCreated_NoStream_ReturnsFailed()
    {
        Handler.EventFactory = (req, ctx, ct) => ThrowAfterCreatedStream(ctx);

        var response = await PostResponsesAsync(new { model = "test" });
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        using var doc = await ParseJsonAsync(response);
        Assert.AreEqual("failed", doc.RootElement.GetProperty("status").GetString());
        // Should have error info
        Assert.IsTrue(doc.RootElement.TryGetProperty("error", out var error));
        Assert.AreEqual("server_error", error.GetProperty("code").GetString());
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
        Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        // Error should contain diagnostic message
        var message = error.GetProperty("message").GetString()!;
        Assert.IsFalse(string.IsNullOrWhiteSpace(message));
    }

    [Test]
    public async Task BadHandler_Stream_ErrorContainsDiagnosticInfo()
    {
        // Wrong first event triggers bad-handler detection
        Handler.EventFactory = (req, ctx, ct) => WrongFirstEventStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var events = await ParseSseAsync(response);
        var errorEvent = events.FirstOrDefault(e => e.EventType == "error");
        Assert.IsNotNull(errorEvent);
        // Error data should contain diagnostic info
        using var errorDoc = JsonDocument.Parse(errorEvent.Data);
        var message = errorDoc.RootElement.GetProperty("message").GetString()!;
        Assert.IsFalse(string.IsNullOrWhiteSpace(message));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Helpers
    // ═══════════════════════════════════════════════════════════════════════

    /// <summary>
    /// Handler that yields an output event as first event (not response.created).
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> WrongFirstEventStream(
        IResponseContext ctx)
    {
        await Task.CompletedTask;
        var response = new Models.Response(ctx.ResponseId, "test");
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
        yield break; // Required for async iterator
    }

    /// <summary>
    /// Handler that yields response.created only (no terminal event).
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> CreatedOnlyStream(
        IResponseContext ctx)
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
        IResponseContext ctx)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        await Task.CompletedTask;
        throw new InvalidOperationException("Simulated handler failure after created");
    }
}
