using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol conformance tests for error responses.
/// Validates error shape, status codes, and handler-thrown exceptions.
/// All assertions use HttpClient + JsonDocument only — no SDK model types in assertions.
/// </summary>
public class ErrorProtocolTests : ProtocolTestBase
{
    [Test]
    public async Task POST_EmptyBody_Returns400_WithInvalidRequestError()
    {
        var response = await PostResponsesAsync("");

        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.AreEqual("invalid_request_error", error.GetProperty("type").GetString());
        Assert.IsFalse(string.IsNullOrEmpty(error.GetProperty("message").GetString()));
    }

    [Test]
    public async Task POST_InvalidJson_Returns400_WithInvalidRequestError()
    {
        var response = await PostResponsesAsync("{not valid json");

        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.AreEqual("invalid_request_error", error.GetProperty("type").GetString());
    }

    [Test]
    public async Task POST_HandlerThrows_ReturnsResponseWithFailedStatus()
    {
        Handler.EventFactory = (req, ctx, ct) => ThrowingStream(ctx);

        var response = await PostResponsesAsync(new { model = "test" });

        // When a handler throws, the default mode catches it and returns
        // a response with status: failed and an error object
        using var doc = await ParseJsonAsync(response);
        var status = doc.RootElement.GetProperty("status").GetString();
        Assert.AreEqual("failed", status);

        var error = doc.RootElement.GetProperty("error");
        Assert.AreEqual("server_error", error.GetProperty("code").GetString());
    }

    [Test]
    public async Task GET_UnknownId_Returns404_WithNotFoundCode()
    {
        var response = await GetResponseAsync("caresp_does_not_exist");

        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.AreEqual("invalid_request_error", error.GetProperty("type").GetString());
        Assert.IsFalse(string.IsNullOrEmpty(error.GetProperty("message").GetString()));
    }

    // ── Helper event factories ─────────────────────────────────

    private static async IAsyncEnumerable<ResponseStreamEvent> ThrowingStream(
        IResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();

        throw new InvalidOperationException("Simulated handler failure");
    }
}
