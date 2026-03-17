using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol conformance tests for error envelope shapes (US6).
/// Validates that HTTP error responses have correct <c>error.type</c> and <c>error.code</c>
/// field values per the API Behaviour Contract.
/// </summary>
public class ErrorShapeProtocolTests : ProtocolTestBase
{
    // ── T013: 400 error envelope shape ────────────────────────

    [Test]
    public async Task POST_EmptyBody_400_HasErrorType_InvalidRequestError()
    {
        var response = await PostResponsesAsync("");

        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.AreEqual("invalid_request_error", error.GetProperty("type").GetString());
        Assert.IsTrue(error.TryGetProperty("message", out var msg) && !string.IsNullOrEmpty(msg.GetString()));
    }

    [Test]
    public async Task POST_InvalidJson_400_HasErrorType_InvalidRequestError()
    {
        var response = await PostResponsesAsync("{not-valid-json!");

        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.AreEqual("invalid_request_error", error.GetProperty("type").GetString());
    }

    [Test]
    public async Task POST_MissingModel_200_ModelIsOptional()
    {
        // PW-006: model is now optional — omitting it should succeed
        var response = await PostResponsesAsync("""{"instructions":"hello"}""");

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }

    // ── T014: 404 error envelope shape ────────────────────────

    [Test]
    public async Task GET_UnknownId_404_HasErrorType_InvalidRequestError()
    {
        var response = await GetResponseAsync("caresp_nonexistent_404");

        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        // Per API contract, 404 uses type "invalid_request_error" (not "not_found")
        Assert.AreEqual("invalid_request_error", error.GetProperty("type").GetString());
        Assert.IsTrue(error.TryGetProperty("message", out var msg) && !string.IsNullOrEmpty(msg.GetString()));
    }

    [Test]
    public async Task Cancel_UnknownId_404_HasErrorType_InvalidRequestError()
    {
        var response = await CancelResponseAsync("caresp_nonexistent_404");

        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.AreEqual("invalid_request_error", error.GetProperty("type").GetString());
    }

    // ── T015: Models.Response error shape on failed responses ────────

    [Test]
    public async Task POST_HandlerThrows_FailedResponse_HasResponseError()
    {
        // Handler throws before response.created → pre-created error → 500 error JSON
        Handler.EventFactory = (req, ctx, ct) => ThrowingStream(ctx);

        var response = await PostResponsesAsync(new { model = "test" });

        Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, response.StatusCode);
        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.IsTrue(error.TryGetProperty("type", out var type) && !string.IsNullOrEmpty(type.GetString()));
        Assert.IsTrue(error.TryGetProperty("message", out var msg) && !string.IsNullOrEmpty(msg.GetString()));
    }

    [Test]
    public async Task POST_StreamingHandlerThrows_FailedResponse_HasResponseError()
    {
        Handler.EventFactory = (req, ctx, ct) => ThrowingStreamAfterCreated(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });

        var events = await ParseSseAsync(response);
        // Find the terminal event
        var lastEvent = events.Last();
        Assert.AreEqual("response.failed", lastEvent.EventType);

        using var doc = JsonDocument.Parse(lastEvent.Data);
        var resp = doc.RootElement.GetProperty("response");
        Assert.AreEqual("failed", resp.GetProperty("status").GetString());

        var error = resp.GetProperty("error");
        Assert.IsTrue(error.TryGetProperty("code", out var code) && !string.IsNullOrEmpty(code.GetString()));
        Assert.IsTrue(error.TryGetProperty("message", out var msg) && !string.IsNullOrEmpty(msg.GetString()));
    }

    // ── Helper event factories ─────────────────────────────────

    private static async IAsyncEnumerable<ResponseStreamEvent> ThrowingStream(
        IResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        throw new InvalidOperationException("Simulated handler failure");
#pragma warning disable CS0162 // Unreachable code detected
        yield break;
#pragma warning restore CS0162
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> ThrowingStreamAfterCreated(
        IResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        await Task.CompletedTask;
        throw new InvalidOperationException("Simulated handler failure after created");
    }
}
