// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol tests for B30 — Models.ResponseObject validation.
/// Handler-yielded invalid events → 500 <c>"server_error"</c> (non-streaming)
/// or <c>response.failed</c> (streaming). Details are logged but never exposed to caller.
/// </summary>
public class ResponseValidationProtocolTests : ProtocolTestBase
{
    // Validates: B30 — background non-streaming handler validation error → GET returns failed
    [Test]
    public async Task Background_HandlerValidationError_GET_ReturnsFailed()
    {
        Handler.EventFactory = (req, ctx, ct) => ValidationFailingStream(ctx);

        var createResponse = await PostResponsesAsync(new { model = "test", background = true });
        Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var createDoc = await ParseJsonAsync(createResponse);
        var responseId = createDoc.RootElement.GetProperty("id").GetString()!;

        await WaitForBackgroundCompletionAsync(responseId);

        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var getDoc = await ParseJsonAsync(getResponse);
        Assert.That(getDoc.RootElement.GetProperty("status").GetString(), Is.EqualTo("failed"));

        // B30: error is present (server_error)
        var error = getDoc.RootElement.GetProperty("error");
        Assert.That(error.ValueKind, Is.Not.EqualTo(JsonValueKind.Null));
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("server_error"));

        // B30: validation details are NOT exposed to caller
        var errorStr = error.ToString();
        XAssert.DoesNotContain("output", errorStr, StringComparison.OrdinalIgnoreCase);
    }

    // Validates: B30 — streaming handler validation error → response.failed SSE event with server_error
    [Test]
    public async Task Streaming_HandlerValidationError_EmitsResponseFailed_WithServerError()
    {
        Handler.EventFactory = (req, ctx, ct) => ValidationFailingStreamAfterCreated(ctx);

        var response = await PostResponsesAsync(new
        {
            model = "test",
            stream = true,
            background = true
        });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var events = await ParseSseAsync(response);
        Assert.That(events.Count >= 2, Is.True, "Should have at least created + failed events");

        // B30: terminal event is response.failed
        var lastEvent = events[^1];
        Assert.That(lastEvent.EventType, Is.EqualTo("response.failed"));

        // Verify the embedded response has server_error
        using var doc = JsonDocument.Parse(lastEvent.Data);
        var responseElem = doc.RootElement.GetProperty("response");
        Assert.That(responseElem.GetProperty("status").GetString(), Is.EqualTo("failed"));

        var error = responseElem.GetProperty("error");
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("server_error"));

        // B30: validation detail paths are NOT exposed
        var errorStr = error.ToString();
        XAssert.DoesNotContain("$.output", errorStr);
    }

    // ── Helper streams ──

    /// <summary>
    /// Handler that throws a ResponseValidationException (simulated via invalid event state).
    /// Throws immediately — non-streaming path will catch it.
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> ValidationFailingStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();

        // Throw ResponseValidationException to simulate response validation failure
        throw new ResponseValidationException(
            new[] { new ValidationError("$.output[0]", "Invalid output item") });
    }

    /// <summary>
    /// Handler for streaming: emits response.created, then throws validation error.
    /// The SSE path should emit response.failed.
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> ValidationFailingStreamAfterCreated(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();

        throw new ResponseValidationException(
            new[] { new ValidationError("$.output[0].content", "Invalid content type") });
    }
}
