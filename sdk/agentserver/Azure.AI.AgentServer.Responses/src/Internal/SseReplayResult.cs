// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;
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
/// Core event-stream primitive (<see cref="AgentEventStreamRegistry"/> / <see cref="AgentEventStream"/>) —
/// the same streaming primitive the orchestrator publishes onto. The Responses layer holds no
/// event-stream store of its own, mirroring the Python implementation.
/// </summary>
internal sealed class SseReplayResult : IResult
{
    private readonly AgentEventStreamRegistry _eventStreamRegistry;
    private readonly string _responseId;
    private readonly JsonSerializerOptions _jsonOptions;
    private readonly ILogger _logger;
    private readonly TimeSpan _keepAliveInterval;
    private readonly long? _startingAfter;

    public SseReplayResult(
        AgentEventStreamRegistry eventStreamRegistry,
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
        // backing was evicted), the Core registry throws AgentEventStreamNotFoundException and we return
        // a JSON error instead of an SSE body.
        AgentEventStream stream;
        try
        {
            stream = await _eventStreamRegistry.GetAsync(_responseId, ct);
        }
        catch (AgentEventStreamNotFoundException ex)
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
            // Replay from the reconnect token (exclusive) then continue with live events until the
            // stream is closed by the producer (the iterator drains and completes). The Core stream
            // carries client-ready SSE frames addressed by their string event id (the sequence
            // number), so each item is forwarded to the client verbatim without a model round-trip.
            // The Responses `starting_after` contract is a strict numeric cursor: enforce it here so a
            // cursor that matches no retained item (e.g. a value past the last event) yields nothing,
            // rather than triggering Core's SSE Last-Event-ID best-effort "replay all on miss".
            await foreach (var item in stream.Subscribe(
                _startingAfter?.ToString(CultureInfo.InvariantCulture), ct).ConfigureAwait(false))
            {
                if (_startingAfter is long after
                    && long.TryParse(item.EventId, NumberStyles.Integer, CultureInfo.InvariantCulture, out var seq)
                    && seq <= after)
                {
                    continue;
                }

                await sseWriter.WriteRawEventAsync(item.EventType, item.Data, ct);
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
