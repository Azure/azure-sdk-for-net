// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Core.Tasks.Providers.Hosted;

/// <summary>
/// Azure.Core pipeline policy that logs outbound Foundry task storage API
/// requests and responses with correlation headers for distributed tracing.
/// <para>
/// Placed as a per-retry policy so each attempt (including retries) is logged
/// with its own duration and correlation IDs.
/// </para>
/// </summary>
internal sealed partial class HostedTaskStoreLoggingPolicy : HttpPipelinePolicy
{
    private readonly ILogger _logger;

    public HostedTaskStoreLoggingPolicy(ILogger logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Masks a Foundry task storage URL for safe logging.
    /// Everything before the <c>/tasks</c> path segment (scheme, host, project path) is replaced
    /// with <c>"***"</c>. Query parameters are stripped except <c>api-version</c>.
    /// </summary>
    internal static string MaskTaskStorageUrl(string? url)
    {
        if (string.IsNullOrEmpty(url))
        {
            return "(redacted)";
        }

        try
        {
            string path;
            string? apiVersion = null;

            var queryIndex = url.IndexOf('?');
            if (queryIndex >= 0)
            {
                var query = url.Substring(queryIndex + 1);
                path = url.Substring(0, queryIndex);

                foreach (var segment in query.Split('&'))
                {
                    if (segment.StartsWith("api-version=", StringComparison.OrdinalIgnoreCase))
                    {
                        apiVersion = segment;
                        break;
                    }
                }
            }
            else
            {
                path = url;
            }

            // Anchor on the LAST `/tasks`: the appended route segment (`/tasks` or `/tasks/{id}`)
            // is always last, so a project-path prefix containing `/tasks…` cannot leak through.
            var storageIndex = path.LastIndexOf("/tasks", StringComparison.Ordinal);
            if (storageIndex >= 0)
            {
                var masked = "***" + path.Substring(storageIndex);
                return apiVersion is not null ? $"{masked}?{apiVersion}" : masked;
            }

            return "(redacted)";
        }
        catch
        {
            return "(redacted)";
        }
    }

    /// <inheritdoc/>
    public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        var sw = Stopwatch.StartNew();
        var clientRequestId = message.Request.ClientRequestId;
        var traceParent = GetTraceParent(message);
        LogRequestStarted(message.Request.Method.ToString(), MaskTaskStorageUrl(message.Request.Uri.ToString()), clientRequestId, traceParent);

        bool transportFailureLogged = false;
        try
        {
            ProcessNext(message, pipeline);
        }
        catch (Exception ex) when (LogAndFilterTransportException(message, clientRequestId, traceParent, sw, ex, out transportFailureLogged))
        {
            throw; // unreachable
        }
        finally
        {
            sw.Stop();
            LogOutcome(message, clientRequestId, traceParent, sw.ElapsedMilliseconds, transportFailureLogged);
        }
    }

    /// <inheritdoc/>
    public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        var sw = Stopwatch.StartNew();
        var clientRequestId = message.Request.ClientRequestId;
        var traceParent = GetTraceParent(message);
        LogRequestStarted(message.Request.Method.ToString(), MaskTaskStorageUrl(message.Request.Uri.ToString()), clientRequestId, traceParent);

        bool transportFailureLogged = false;
        try
        {
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
        }
        catch (Exception ex) when (LogAndFilterTransportException(message, clientRequestId, traceParent, sw, ex, out transportFailureLogged))
        {
            throw; // unreachable
        }
        finally
        {
            sw.Stop();
            LogOutcome(message, clientRequestId, traceParent, sw.ElapsedMilliseconds, transportFailureLogged);
        }
    }

    private bool LogAndFilterTransportException(HttpMessage message, string clientRequestId, string? traceParent, Stopwatch sw, Exception ex, out bool logged)
    {
        logged = false;
        if (!message.HasResponse)
        {
            sw.Stop();
            LogTransportFailure(
                ex,
                message.Request.Method.ToString(),
                MaskTaskStorageUrl(message.Request.Uri.ToString()),
                sw.ElapsedMilliseconds,
                clientRequestId,
                traceParent);
            logged = true;
        }

        return false;
    }

    private void LogOutcome(HttpMessage message, string clientRequestId, string? traceParent, long durationMs, bool transportFailureLogged)
    {
        if (message.HasResponse)
        {
            LogResponse(message, clientRequestId, traceParent, durationMs);
        }
        else if (!transportFailureLogged)
        {
            LogTransportFailureNoException(
                message.Request.Method.ToString(),
                MaskTaskStorageUrl(message.Request.Uri.ToString()),
                durationMs,
                clientRequestId,
                traceParent);
        }
    }

    private static string? GetTraceParent(HttpMessage message)
    {
        message.Request.Headers.TryGetValue(PlatformHeaders.TraceParent, out var traceParent);
        return traceParent;
    }

    private void LogResponse(HttpMessage message, string clientRequestId, string? traceParent, long durationMs)
    {
        var response = message.Response;
        var uri = MaskTaskStorageUrl(message.Request.Uri.ToString());

        response.Headers.TryGetValue(PlatformHeaders.RequestId, out var xRequestId);
        response.Headers.TryGetValue("apim-request-id", out var apimRequestId);

        var hasCallId = message.Request.Headers.TryGetValue(PlatformHeaders.FoundryCallId, out _);

        if (response.IsError)
        {
            LogRequestFailed(
                message.Request.Method.ToString(),
                uri,
                response.Status,
                durationMs,
                clientRequestId,
                traceParent,
                xRequestId,
                apimRequestId,
                hasCallId);
        }
        else
        {
            LogRequestSucceeded(
                message.Request.Method.ToString(),
                uri,
                response.Status,
                durationMs,
                clientRequestId,
                traceParent,
                xRequestId,
                apimRequestId,
                hasCallId);
        }
    }

    // --- LoggerMessage source-generated methods ---

    [LoggerMessage(Level = LogLevel.Debug, Message = "Task storage {Method} {Uri} starting (x-ms-client-request-id: {ClientRequestId}, traceparent: {TraceParent})")]
    private partial void LogRequestStarted(string method, string uri, string clientRequestId, string? traceParent);

    [LoggerMessage(Level = LogLevel.Information, Message = "Task storage {Method} {Uri} completed HTTP {StatusCode} in {DurationMs}ms (x-ms-client-request-id: {ClientRequestId}, traceparent: {TraceParent}, x-request-id: {XRequestId}, apim-request-id: {ApimRequestId}, HasCallId: {HasCallId})")]
    private partial void LogRequestSucceeded(string method, string uri, int statusCode, long durationMs, string clientRequestId, string? traceParent, string? xRequestId, string? apimRequestId, bool hasCallId);

    [LoggerMessage(Level = LogLevel.Warning, Message = "Task storage {Method} {Uri} failed HTTP {StatusCode} in {DurationMs}ms (x-ms-client-request-id: {ClientRequestId}, traceparent: {TraceParent}, x-request-id: {XRequestId}, apim-request-id: {ApimRequestId}, HasCallId: {HasCallId})")]
    private partial void LogRequestFailed(string method, string uri, int statusCode, long durationMs, string clientRequestId, string? traceParent, string? xRequestId, string? apimRequestId, bool hasCallId);

    [LoggerMessage(Level = LogLevel.Error, Message = "Task storage {Method} {Uri} transport failure after {DurationMs}ms (x-ms-client-request-id: {ClientRequestId}, traceparent: {TraceParent})")]
    private partial void LogTransportFailure(Exception exception, string method, string uri, long durationMs, string clientRequestId, string? traceParent);

    [LoggerMessage(Level = LogLevel.Error, Message = "Task storage {Method} {Uri} completed with no response and no exception after {DurationMs}ms — pipeline may have been short-circuited (x-ms-client-request-id: {ClientRequestId}, traceparent: {TraceParent})")]
    private partial void LogTransportFailureNoException(string method, string uri, long durationMs, string clientRequestId, string? traceParent);
}
