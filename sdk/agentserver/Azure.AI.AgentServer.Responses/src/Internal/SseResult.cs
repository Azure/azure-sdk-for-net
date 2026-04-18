// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// An <see cref="IResult"/> implementation that streams pre-processed response events as SSE.
/// All event processing (validation, auto-stamping, publisher push, error recovery,
/// persistence) is handled by <see cref="ResponseOrchestrator"/>. This class is
/// responsible only for SSE wire-format output, keep-alive heartbeats, and
/// background-mode client-disconnect handling.
/// </summary>
/// <remarks>
/// Takes ownership of the <see cref="Activity"/> created by
/// <see cref="ResponsesActivitySource.StartCreateResponseActivity"/> so that the
/// tracing span covers the full SSE streaming duration. The activity is disposed
/// in the <c>finally</c> block of <see cref="ExecuteAsync"/>, matching the
/// cross-language <c>trace_stream</c> / <c>end_span</c> pattern.
/// </remarks>
internal sealed class SseResult : IResult
{
    private readonly IAsyncEnumerable<ResponseStreamEvent> _events;
    private readonly ResponseExecution _execution;
    private readonly CancellationTokenSource _linkedCts;
    private readonly Activity? _activity;
    private readonly JsonSerializerOptions _jsonOptions;
    private readonly ILogger _logger;
    private readonly TimeSpan _keepAliveInterval;

    public SseResult(
        IAsyncEnumerable<ResponseStreamEvent> events,
        ResponseExecution execution,
        CancellationTokenSource linkedCts,
        Activity? activity,
        JsonSerializerOptions jsonOptions,
        ILogger logger,
        TimeSpan keepAliveInterval)
    {
        _events = events;
        _execution = execution;
        _linkedCts = linkedCts;
        _activity = activity;
        _jsonOptions = jsonOptions;
        _logger = logger;
        _keepAliveInterval = keepAliveInterval;
    }

    public async Task ExecuteAsync(HttpContext httpContext)
    {
        // Set SSE headers
        httpContext.Response.ContentType = "text/event-stream; charset=utf-8";
        httpContext.Response.Headers["Cache-Control"] = "no-cache";
        httpContext.Response.Headers["Connection"] = "keep-alive";
        httpContext.Response.Headers["X-Accel-Buffering"] = "no";

        var responseId = _execution.ResponseId;
        _logger.LogInformation("SSE stream started for response {ResponseId}", responseId);

        using var sseWriter = new SseWriter(httpContext.Response.Body, _jsonOptions);

        // Start keep-alive timer if interval is not infinite
        Timer? keepAliveTimer = null;
        if (_keepAliveInterval != Timeout.InfiniteTimeSpan && _keepAliveInterval > TimeSpan.Zero)
        {
            keepAliveTimer = new Timer(
                async _ =>
                {
                    try
                    {
                        await sseWriter.WriteKeepAliveAsync(CancellationToken.None);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogDebug(ex, "Keep-alive write failed for response {ResponseId}", responseId);
                    }
                },
                null,
                _keepAliveInterval,
                _keepAliveInterval);
        }

        try
        {
            var sseDisconnected = false;

            await foreach (var evt in _events)
            {
                if (!sseDisconnected)
                {
                    try
                    {
                        await sseWriter.WriteEventAsync(evt, evt.SequenceNumber,
                            _execution.IsBackground ? CancellationToken.None : httpContext.RequestAborted);
                    }
                    catch when (_execution.IsBackground && httpContext.RequestAborted.IsCancellationRequested)
                    {
                        sseDisconnected = true;
                        _logger.LogInformation(
                            "SSE client disconnected for bg response {ResponseId}, handler continues",
                            responseId);
                    }
                }
            }

            _logger.LogInformation(
                "SSE stream completed for response {ResponseId}", responseId);
        }
        catch (OperationCanceledException) when (httpContext.RequestAborted.IsCancellationRequested)
        {
            // Non-bg client disconnected — orchestrator handles status via ClientDisconnected flag
            _logger.LogInformation(
                "SSE stream cancelled (client disconnect) for response {ResponseId}", responseId);
        }
        catch (Exception ex)
        {
            // Any error (pre-created failure, cancellation before response.created, etc.)
            // — tag the Activity span and write a standalone SSE error event with
            // full fidelity from the exception.
            ResponsesExceptionFilter.RecordException(_activity, ex);
            _logger.LogWarning(ex,
                "SSE stream error for response {ResponseId}", responseId);
            try
            {
                await sseWriter.WriteErrorEventAsync(ApiErrorFactory.ToSseErrorEvent(ex));
            }
            catch
            {
                // Stream may be broken — best effort
            }
        }
        finally
        {
            if (keepAliveTimer is not null)
            {
                await keepAliveTimer.DisposeAsync();
            }

            _linkedCts.Dispose();
            _activity?.Dispose();
        }
    }
}
