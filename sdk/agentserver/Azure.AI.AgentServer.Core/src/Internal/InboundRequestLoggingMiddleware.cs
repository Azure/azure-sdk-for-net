// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Core.Internal;

/// <summary>
/// Middleware that logs all inbound HTTP requests with method, path, status code,
/// duration, and correlation headers for distributed tracing diagnostics.
/// </summary>
internal sealed partial class InboundRequestLoggingMiddleware : IMiddleware
{
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="InboundRequestLoggingMiddleware"/>.
    /// </summary>
    public InboundRequestLoggingMiddleware(ILogger<InboundRequestLoggingMiddleware> logger)
    {
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var sw = Stopwatch.StartNew();
        var method = context.Request.Method;
        var path = context.Request.Path.Value ?? "/";

        context.Request.Headers.TryGetValue("x-request-id", out var xRequestId);
        context.Request.Headers.TryGetValue("x-ms-client-request-id", out var clientRequestId);
        var traceId = Activity.Current?.TraceId.ToString();

        LogRequestStarted(method, path, xRequestId.ToString(), clientRequestId.ToString(), traceId);

        Exception? caughtException = null;
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            caughtException = ex;
            throw;
        }
        finally
        {
            sw.Stop();

            // Re-read traceId in case an Activity was created further down the pipeline.
            traceId = Activity.Current?.TraceId.ToString() ?? traceId;

            // If an exception escaped, the status code may still be the default (200).
            // Force 500 in the log so we don't emit a misleading "completed HTTP 200".
            var statusCode = caughtException is not null
                ? 500
                : context.Response.StatusCode;

            if (statusCode >= 400)
            {
                LogRequestFailed(method, path, statusCode, sw.ElapsedMilliseconds,
                    xRequestId.ToString(), clientRequestId.ToString(), traceId);
            }
            else
            {
                LogRequestSucceeded(method, path, statusCode, sw.ElapsedMilliseconds,
                    xRequestId.ToString(), clientRequestId.ToString(), traceId);
            }
        }
    }

    [LoggerMessage(Level = LogLevel.Information, Message = "Inbound {Method} {Path} starting (x-request-id: {XRequestId}, x-ms-client-request-id: {ClientRequestId}, trace-id: {TraceId})")]
    private partial void LogRequestStarted(string method, string path, string? xRequestId, string? clientRequestId, string? traceId);

    [LoggerMessage(Level = LogLevel.Information, Message = "Inbound {Method} {Path} completed HTTP {StatusCode} in {DurationMs}ms (x-request-id: {XRequestId}, x-ms-client-request-id: {ClientRequestId}, trace-id: {TraceId})")]
    private partial void LogRequestSucceeded(string method, string path, int statusCode, long durationMs, string? xRequestId, string? clientRequestId, string? traceId);

    [LoggerMessage(Level = LogLevel.Warning, Message = "Inbound {Method} {Path} failed HTTP {StatusCode} in {DurationMs}ms (x-request-id: {XRequestId}, x-ms-client-request-id: {ClientRequestId}, trace-id: {TraceId})")]
    private partial void LogRequestFailed(string method, string path, int statusCode, long durationMs, string? xRequestId, string? clientRequestId, string? traceId);
}
