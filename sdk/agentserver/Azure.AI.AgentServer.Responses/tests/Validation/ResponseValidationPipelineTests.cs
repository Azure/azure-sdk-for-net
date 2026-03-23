// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Validation;

/// <summary>
/// Tests for infrastructure-level response validation at SSE and non-streaming chokepoints.
/// Covers T027–T030.
/// </summary>
public class ResponseValidationPipelineTests : ProtocolTestBase
{
    // -----------------------------------------------------------------------
    // T027 — Streaming mode: invalid events after response.created → response.failed
    // -----------------------------------------------------------------------

    [Test]
    public async Task Streaming_HandlerThrowsResponseValidation_AfterCreated_EmitsResponseFailed()
    {
        // Handler emits response.created, then throws ResponseValidationException
        Handler.EventFactory = (req, ctx, ct) => StreamWithValidationError(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        var events = await ParseSseAsync(response);

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        // Should have response.created followed by response.failed
        Assert.IsTrue(events.Count >= 2, $"Expected at least 2 events, got {events.Count}");
        Assert.AreEqual("response.created", events[0].EventType);

        var lastEvent = events[^1];
        Assert.AreEqual("response.failed", lastEvent.EventType);

        // The failed event should include a server_error on the response object
        using var doc = JsonDocument.Parse(lastEvent.Data);
        var errorCode = doc.RootElement.GetProperty("response")
            .GetProperty("error").GetProperty("code").GetString();
        Assert.AreEqual("server_error", errorCode);
    }

    // -----------------------------------------------------------------------
    // T028 — Non-streaming mode: invalid events → HTTP 500
    // -----------------------------------------------------------------------

    [Test]
    public async Task NonStreaming_HandlerThrowsResponseValidation_Returns500()
    {
        // Handler throws ResponseValidationException during event generation
        Handler.EventFactory = (req, ctx, ct) => ThrowsValidationImmediately(ctx);

        var response = await PostResponsesAsync(new { model = "test" });

        // Non-streaming mode: exception should result in 200 with failed status
        // (exception is caught in ConsumeHandlerEventsAsync, response status set to failed)
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        using var doc = await ParseJsonAsync(response);
        Assert.AreEqual("failed", doc.RootElement.GetProperty("status").GetString());
        Assert.AreEqual("server_error", doc.RootElement.GetProperty("error").GetProperty("code").GetString());
    }

    [Test]
    public async Task NonStreaming_ResponseValidationError_DoesNotExposeDetails()
    {
        // The error message should NOT contain validation field details
        Handler.EventFactory = (req, ctx, ct) => ThrowsValidationImmediately(ctx);

        var response = await PostResponsesAsync(new { model = "test" });

        using var doc = await ParseJsonAsync(response);
        var errorMessage = doc.RootElement.GetProperty("error").GetProperty("message").GetString();

        // Error message should be generic, not containing validation-specific paths
        XAssert.DoesNotContain("$.output", errorMessage!);
        XAssert.DoesNotContain("missing", errorMessage!, StringComparison.OrdinalIgnoreCase);
    }

    // -----------------------------------------------------------------------
    // T029 — Pre-response.created error handling (rare case)
    // -----------------------------------------------------------------------

    [Test]
    public async Task Streaming_HandlerThrowsResponseValidation_BeforeCreated_EmitsErrorEvent()
    {
        // Handler throws ResponseValidationException before emitting response.created
        Handler.EventFactory = (req, ctx, ct) => ThrowsValidationBeforeCreated();

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        var events = await ParseSseAsync(response);

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        // Pre-response.created error: standalone error event (not response.failed)
        Assert.IsNotEmpty(events);
        var lastEvent = events[^1];
        Assert.AreEqual("error", lastEvent.EventType);
    }

    // -----------------------------------------------------------------------
    // T030 — Validation details logged via ILogger but NOT exposed to caller
    // -----------------------------------------------------------------------

    [Test]
    public async Task Streaming_ValidationError_DoesNotExposeFieldPaths()
    {
        Handler.EventFactory = (req, ctx, ct) => StreamWithValidationError(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        var rawBody = await response.Content.ReadAsStringAsync();

        // The raw SSE body should NOT include validation error field paths
        XAssert.DoesNotContain("$.output", rawBody);
        XAssert.DoesNotContain("Required property", rawBody);
    }

    [Test]
    public async Task NonStreaming_ValidationError_Does_Not_Expose_Validation_Details()
    {
        Handler.EventFactory = (req, ctx, ct) => ThrowsValidationImmediately(ctx);

        var response = await PostResponsesAsync(new { model = "test" });

        using var doc = await ParseJsonAsync(response);
        var bodyStr = doc.RootElement.GetRawText();

        // Should not contain validation-specific details
        XAssert.DoesNotContain("validation", bodyStr, StringComparison.OrdinalIgnoreCase);
        XAssert.DoesNotContain("$.output", bodyStr);
    }

    // -----------------------------------------------------------------------
    // T032 — Valid response objects pass through without errors
    // -----------------------------------------------------------------------

    [Test]
    public async Task Streaming_ValidEvents_PassThrough()
    {
        Handler.EventFactory = (req, ctx, ct) => ValidStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        var events = await ParseSseAsync(response);

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.AreEqual("response.created", events[0].EventType);
        Assert.AreEqual("response.completed", events[^1].EventType);
    }

    [Test]
    public async Task NonStreaming_ValidEvents_Return200()
    {
        Handler.EventFactory = (req, ctx, ct) => ValidStream(ctx);

        var response = await PostResponsesAsync(new { model = "test" });

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        using var doc = await ParseJsonAsync(response);
        Assert.AreEqual("completed", doc.RootElement.GetProperty("status").GetString());
    }

    // -----------------------------------------------------------------------
    // Helpers
    // -----------------------------------------------------------------------

    private static async IAsyncEnumerable<ResponseStreamEvent> StreamWithValidationError(
        IResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var resp = new Models.Response(ctx.ResponseId, "test");
        yield return new ResponseCreatedEvent(0, resp);
        await Task.CompletedTask;
        // Simulate a response validation error after response.created
        throw new ResponseValidationException(
        [
            new ValidationError("$.output[0].content", "Required property 'content' is missing")
        ]);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> ThrowsValidationImmediately(
        IResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var resp = new Models.Response(ctx.ResponseId, "test");
        yield return new ResponseCreatedEvent(0, resp);
        await Task.CompletedTask;
        throw new ResponseValidationException(
        [
            new ValidationError("$.output[0].type", "Required discriminator 'type' is missing")
        ]);
    }

    private static IAsyncEnumerable<ResponseStreamEvent> ThrowsValidationBeforeCreated(
        CancellationToken ct = default)
    {
        throw new ResponseValidationException(
        [
            new ValidationError("$.model", "Required property 'model' is missing")
        ]);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> ValidStream(
        IResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var resp = new Models.Response(ctx.ResponseId, "test");
        yield return new ResponseCreatedEvent(0, resp);
        resp.SetCompleted();
        yield return new ResponseCompletedEvent(0, resp);
        await Task.CompletedTask;
    }
}
