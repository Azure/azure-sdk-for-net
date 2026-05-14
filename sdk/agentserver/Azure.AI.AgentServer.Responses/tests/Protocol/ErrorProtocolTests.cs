// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        Assert.That(string.IsNullOrEmpty(error.GetProperty("message").GetString()), Is.False);
    }

    [Test]
    public async Task POST_InvalidJson_Returns400_WithInvalidRequestError()
    {
        var response = await PostResponsesAsync("{not valid json");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
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
        Assert.That(status, Is.EqualTo("failed"));

        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("server_error"));
    }

    [Test]
    public async Task GET_UnknownId_Returns404_WithNotFoundCode()
    {
        var response = await GetResponseAsync(IdGenerator.NewResponseId());

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        Assert.That(string.IsNullOrEmpty(error.GetProperty("message").GetString()), Is.False);
    }

    // ── Helper event factories ─────────────────────────────────

    private static async IAsyncEnumerable<ResponseStreamEvent> ThrowingStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();

        throw new InvalidOperationException("Simulated handler failure");
    }
}
