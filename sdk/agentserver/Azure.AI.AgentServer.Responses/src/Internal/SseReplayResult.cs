// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// An <see cref="IResult"/> implementation that replays cached response events as SSE.
/// Subscribes to the <see cref="ResponsesStreamProvider"/> event stream to get
/// buffered events (replay) and live events (if the response is still in-flight).
/// </summary>
/// <remarks>
/// Uses fully asynchronous <see cref="IAsyncObserver{T}"/> subscription,
/// eliminating the sync-over-async pattern from the legacy <c>ReplaySubject</c> approach.
/// </remarks>
internal sealed class SseReplayResult : IResult
{
    private readonly ResponsesStreamProvider _streamProvider;
    private readonly string _responseId;
    private readonly JsonSerializerOptions _jsonOptions;
    private readonly ILogger _logger;
    private readonly TimeSpan _keepAliveInterval;
    private readonly long? _startingAfter;

    public SseReplayResult(
        ResponsesStreamProvider streamProvider,
        string responseId,
        JsonSerializerOptions jsonOptions,
        ILogger logger,
        TimeSpan keepAliveInterval,
        long? startingAfter = null)
    {
        _streamProvider = streamProvider;
        _responseId = responseId;
        _jsonOptions = jsonOptions;
        _logger = logger;
        _keepAliveInterval = keepAliveInterval;
        _startingAfter = startingAfter;
    }

    public async Task ExecuteAsync(HttpContext httpContext)
    {
        httpContext.Response.ContentType = "text/event-stream; charset=utf-8";
        httpContext.Response.Headers["Cache-Control"] = "no-cache";
        httpContext.Response.Headers["Connection"] = "keep-alive";
        httpContext.Response.Headers["X-Accel-Buffering"] = "no";

        _logger.LogInformation("SSE replay started for response {ResponseId}", _responseId);

        using var sseWriter = new SseWriter(httpContext.Response.Body, _jsonOptions);
        var ct = httpContext.RequestAborted;

        // Start keep-alive timer if configured
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
                        _logger.LogDebug(ex, "Keep-alive write failed for response {ResponseId}", _responseId);
                    }
                },
                null,
                _keepAliveInterval,
                _keepAliveInterval);
        }

        try
        {
            // Subscribe using fully async observer — no sync-over-async
            var tcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            var observer = new SseWritingObserver(sseWriter, ct, tcs);

            await using var subscription = await _streamProvider.SubscribeToEventsAsync(
                _responseId, observer, _startingAfter);

            // Wait for the stream to complete or cancellation
            using var registration = ct.Register(() => tcs.TrySetCanceled(ct));
            await tcs.Task;

            _logger.LogInformation(
                "SSE replay completed for response {ResponseId}", _responseId);
        }
        catch (BadRequestException ex)
        {
            // Stream provider signalled that no event stream is available for this
            // response (e.g., non-streaming background response, or stream TTL expired).
            // Since SSE headers have not been flushed yet, we can still write a JSON error.
            _logger.LogWarning(ex, "SSE replay unavailable for response {ResponseId}", _responseId);
            httpContext.Response.Headers.Remove("Cache-Control");
            httpContext.Response.Headers.Remove("Connection");
            httpContext.Response.Headers.Remove("X-Accel-Buffering");
            // TODO: The container spec prescribes distinct error messages for "not created
            // with stream=true" vs "stream TTL expired", but the BadRequestException from the
            // stream provider does not carry enough context to distinguish the two cases.
            // Until the provider surfaces the reason, we use a combined message.
            await ApiErrorFactory.InvalidRequest(
                "This response cannot be streamed because it was not created with stream=true or the stream TTL has expired.",
                param: "stream").ExecuteAsync(httpContext);
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation(
                "SSE replay cancelled (client disconnected) for response {ResponseId}", _responseId);
        }
        finally
        {
            if (keepAliveTimer is not null)
            {
                await keepAliveTimer.DisposeAsync();
            }
        }
    }

    /// <summary>
    /// Async observer that writes events to the SSE stream as they arrive.
    /// </summary>
    private sealed class SseWritingObserver : IAsyncObserver<ResponseStreamEvent>
    {
        private readonly SseWriter _sseWriter;
        private readonly CancellationToken _ct;
        private readonly TaskCompletionSource _tcs;

        public SseWritingObserver(SseWriter sseWriter, CancellationToken ct, TaskCompletionSource tcs)
        {
            _sseWriter = sseWriter;
            _ct = ct;
            _tcs = tcs;
        }

        public async ValueTask OnNextAsync(ResponseStreamEvent value)
        {
            try
            {
                await _sseWriter.WriteEventAsync(value, value.SequenceNumber, _ct);
            }
            catch (OperationCanceledException)
            {
                _tcs.TrySetCanceled(_ct);
            }
        }

        public ValueTask OnErrorAsync(Exception error)
        {
            _tcs.TrySetException(error);
            return default;
        }

        public ValueTask OnCompletedAsync()
        {
            _tcs.TrySetResult();
            return default;
        }
    }
}
