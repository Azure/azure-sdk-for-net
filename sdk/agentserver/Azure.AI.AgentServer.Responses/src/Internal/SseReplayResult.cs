// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// An <see cref="IResult"/> implementation that replays cached response events as SSE.
/// Reads buffered events (replay) and live events (if the response is still in-flight) from the
/// Core event-stream primitive (<see cref="IEventStreamRegistry"/> / <see cref="IEventStream"/>) —
/// the same streaming primitive the orchestrator publishes onto. The Responses layer holds no
/// event-stream store of its own, mirroring the Python implementation.
/// </summary>
internal sealed class SseReplayResult : IResult
{
    private readonly IEventStreamRegistry _eventStreamRegistry;
    private readonly string _responseId;
    private readonly JsonSerializerOptions _jsonOptions;
    private readonly ILogger _logger;
    private readonly TimeSpan _keepAliveInterval;
    private readonly long? _startingAfter;

    public SseReplayResult(
        IEventStreamRegistry eventStreamRegistry,
        string responseId,
        JsonSerializerOptions jsonOptions,
        ILogger logger,
        TimeSpan keepAliveInterval,
        long? startingAfter = null)
    {
        _eventStreamRegistry = eventStreamRegistry;
        _responseId = responseId;
        _jsonOptions = jsonOptions;
        _logger = logger;
        _keepAliveInterval = keepAliveInterval;
        _startingAfter = startingAfter;
    }

    public async Task ExecuteAsync(HttpContext httpContext)
    {
        var ct = httpContext.RequestAborted;

        // Resolve the event stream BEFORE writing SSE headers. If no stream is available for this
        // response (e.g., non-background response, or the stream's replay TTL has expired and the
        // backing was evicted), the Core registry throws EventStreamNotFoundException and we return
        // a JSON error instead of an SSE body.
        IEventStream stream;
        try
        {
            stream = await _eventStreamRegistry.GetAsync(_responseId, ct);
        }
        catch (EventStreamNotFoundException ex)
        {
            _logger.LogWarning(ex, "SSE replay unavailable for response {ResponseId}", _responseId);
            await ApiErrorFactory.InvalidRequest(
                "This response cannot be streamed because it was not created with stream=true or the stream TTL has expired.",
                param: "stream").ExecuteAsync(httpContext);
            return;
        }

        httpContext.Response.ContentType = "text/event-stream; charset=utf-8";
        httpContext.Response.Headers["Cache-Control"] = "no-cache";
        httpContext.Response.Headers["Connection"] = "keep-alive";
        httpContext.Response.Headers["X-Accel-Buffering"] = "no";

        _logger.LogInformation("SSE replay started for response {ResponseId}", _responseId);

        await using var keepAliveSession = SseKeepAliveSession.Start(
            httpContext.Response.Body, _keepAliveInterval, _logger, $"response {_responseId}");
        var sseWriter = new SseWriter(keepAliveSession, _jsonOptions);

        try
        {
            // Replay from the cursor (exclusive) then continue with live events until the stream is
            // closed by the producer (the iterator drains and completes). The Core cursor is int;
            // the Responses sequence number fits within it in practice.
            await foreach (var payload in stream.Subscribe((int?)_startingAfter, ct).ConfigureAwait(false))
            {
                var evt = (ResponseStreamEvent)payload;
                await sseWriter.WriteEventAsync(evt, evt.SequenceNumber, ct);
            }

            _logger.LogInformation(
                "SSE replay completed for response {ResponseId}", _responseId);
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation(
                "SSE replay cancelled (client disconnected) for response {ResponseId}", _responseId);
        }
    }
}
