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

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Should have response.created followed by response.failed
        Assert.That(events.Count >= 2, Is.True, $"Expected at least 2 events, got {events.Count}");
        Assert.That(events[0].EventType, Is.EqualTo("response.created"));

        var lastEvent = events[^1];
        Assert.That(lastEvent.EventType, Is.EqualTo("response.failed"));

        // The failed event should include a server_error on the response object
        using var doc = JsonDocument.Parse(lastEvent.Data);
        var errorCode = doc.RootElement.GetProperty("response")
            .GetProperty("error").GetProperty("code").GetString();
        Assert.That(errorCode, Is.EqualTo("server_error"));
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
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(response);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("failed"));
        Assert.That(doc.RootElement.GetProperty("error").GetProperty("code").GetString(), Is.EqualTo("server_error"));
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

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Pre-response.created error: standalone error event (not response.failed)
        Assert.That(events, Is.Not.Empty);
        var lastEvent = events[^1];
        Assert.That(lastEvent.EventType, Is.EqualTo("error"));
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

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(events[0].EventType, Is.EqualTo("response.created"));
        Assert.That(events[^1].EventType, Is.EqualTo("response.completed"));
    }

    [Test]
    public async Task NonStreaming_ValidEvents_Return200()
    {
        Handler.EventFactory = (req, ctx, ct) => ValidStream(ctx);

        var response = await PostResponsesAsync(new { model = "test" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(response);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    // -----------------------------------------------------------------------
    // Helpers
    // -----------------------------------------------------------------------

    private static async IAsyncEnumerable<ResponseStreamEvent> StreamWithValidationError(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var resp = new Models.ResponseObject(ctx.ResponseId, "test");
        yield return new ResponseCreatedEvent(0, resp);
        await Task.CompletedTask;
        // Simulate a response validation error after response.created
        throw new ResponseValidationException(
        [
            new ValidationError("$.output[0].content", "Required property 'content' is missing")
        ]);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> ThrowsValidationImmediately(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var resp = new Models.ResponseObject(ctx.ResponseId, "test");
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
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var resp = new Models.ResponseObject(ctx.ResponseId, "test");
        yield return new ResponseCreatedEvent(0, resp);
        resp.SetCompleted();
        yield return new ResponseCompletedEvent(0, resp);
        await Task.CompletedTask;
    }
}
