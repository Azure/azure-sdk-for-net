// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        Assert.That(error.TryGetProperty("message", out var msg) && !string.IsNullOrEmpty(msg.GetString()), Is.True);
    }

    [Test]
    public async Task POST_InvalidJson_400_HasErrorType_InvalidRequestError()
    {
        var response = await PostResponsesAsync("{not-valid-json!");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
    }

    [Test]
    public async Task POST_MissingModel_200_ModelIsOptional()
    {
        // PW-006: model is now optional — omitting it should succeed
        var response = await PostResponsesAsync("""{"instructions":"hello"}""");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    // ── T014: 404 error envelope shape ────────────────────────

    [Test]
    public async Task GET_UnknownId_404_HasErrorType_InvalidRequestError()
    {
        var response = await GetResponseAsync(IdGenerator.NewResponseId());

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        // Per API contract, 404 uses type "invalid_request_error" (not "not_found")
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        Assert.That(error.TryGetProperty("message", out var msg) && !string.IsNullOrEmpty(msg.GetString()), Is.True);
    }

    [Test]
    public async Task Cancel_UnknownId_404_HasErrorType_InvalidRequestError()
    {
        var response = await CancelResponseAsync(IdGenerator.NewResponseId());

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
    }

    // ── T015: Models.ResponseObject error shape on failed responses ────────

    [Test]
    public async Task POST_HandlerThrows_FailedResponse_HasResponseError()
    {
        // Handler throws before response.created → pre-created error → 500 error JSON
        Handler.EventFactory = (req, ctx, ct) => ThrowingStream(ctx);

        var response = await PostResponsesAsync(new { model = "test" });

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.InternalServerError));
        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.TryGetProperty("type", out var type) && !string.IsNullOrEmpty(type.GetString()), Is.True);
        Assert.That(error.TryGetProperty("message", out var msg) && !string.IsNullOrEmpty(msg.GetString()), Is.True);
    }

    [Test]
    public async Task POST_StreamingHandlerThrows_FailedResponse_HasResponseError()
    {
        Handler.EventFactory = (req, ctx, ct) => ThrowingStreamAfterCreated(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });

        var events = await ParseSseAsync(response);
        // Find the terminal event
        var lastEvent = events.Last();
        Assert.That(lastEvent.EventType, Is.EqualTo("response.failed"));

        using var doc = JsonDocument.Parse(lastEvent.Data);
        var resp = doc.RootElement.GetProperty("response");
        Assert.That(resp.GetProperty("status").GetString(), Is.EqualTo("failed"));

        var error = resp.GetProperty("error");
        Assert.That(error.TryGetProperty("code", out var code) && !string.IsNullOrEmpty(code.GetString()), Is.True);
        Assert.That(error.TryGetProperty("message", out var msg) && !string.IsNullOrEmpty(msg.GetString()), Is.True);
    }

    // ── Helper event factories ─────────────────────────────────

    private static async IAsyncEnumerable<ResponseStreamEvent> ThrowingStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        throw new InvalidOperationException("Simulated handler failure");
#pragma warning disable CS0162 // Unreachable code detected
        yield break;
#pragma warning restore CS0162
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> ThrowingStreamAfterCreated(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        await Task.CompletedTask;
        throw new InvalidOperationException("Simulated handler failure after created");
    }
}
