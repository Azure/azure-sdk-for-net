// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Azure.Core pipeline policy that logs outbound Foundry storage API requests
/// and responses with correlation headers for distributed tracing diagnostics.
/// <para>
/// Placed as a per-retry policy so each attempt (including retries) is logged
/// with its own duration and correlation IDs.
/// </para>
/// </summary>
internal sealed partial class FoundryStorageLoggingPolicy : HttpPipelinePolicy
{
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="FoundryStorageLoggingPolicy"/>.
    /// </summary>
    /// <param name="logger">Logger for structured diagnostics.</param>
    public FoundryStorageLoggingPolicy(ILogger logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Masks a Foundry storage URL for safe logging.
    /// Everything before <c>/storage</c> (scheme, host, project path) is replaced
    /// with <c>"***"</c>. Query parameters are stripped except <c>api-version</c>.
    /// </summary>
    internal static string MaskStorageUrl(string? url)
    {
        if (string.IsNullOrEmpty(url))
        {
            return "(redacted)";
        }

        try
        {
            // Separate query string from the path portion.
            string path;
            string? apiVersion = null;

            var queryIndex = url.IndexOf('?');
            if (queryIndex >= 0)
            {
                var query = url.AsSpan(queryIndex + 1);
                path = url.Substring(0, queryIndex);

                // Extract api-version if present.
                foreach (var segment in query.ToString().Split('&'))
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

            // Find the /storage segment and keep only from there.
            var storageIndex = path.IndexOf("/storage", StringComparison.Ordinal);
            if (storageIndex >= 0)
            {
                var masked = "***" + path.Substring(storageIndex);
                return apiVersion is not null ? $"{masked}?{apiVersion}" : masked;
            }

            // Fallback: no /storage segment — redact the whole URL.
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
        LogRequestStarted(message.Request.Method.ToString(), MaskStorageUrl(message.Request.Uri.ToString()), clientRequestId, traceParent);

        bool transportFailureLogged = false;
        try
        {
            ProcessNext(message, pipeline);
        }
        catch (Exception ex) when (LogAndFilterTransportException(message, clientRequestId, traceParent, sw, ex, out transportFailureLogged))
        {
            throw; // unreachable — filter always returns false
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
        LogRequestStarted(message.Request.Method.ToString(), MaskStorageUrl(message.Request.Uri.ToString()), clientRequestId, traceParent);

        bool transportFailureLogged = false;
        try
        {
            await ProcessNextAsync(message, pipeline);
        }
        catch (Exception ex) when (LogAndFilterTransportException(message, clientRequestId, traceParent, sw, ex, out transportFailureLogged))
        {
            throw; // unreachable — filter always returns false
        }
        finally
        {
            sw.Stop();
            LogOutcome(message, clientRequestId, traceParent, sw.ElapsedMilliseconds, transportFailureLogged);
        }
    }

    /// <summary>
    /// Exception filter that logs transport failures. Always returns false so the
    /// exception continues to propagate — we never swallow it.
    /// </summary>
    private bool LogAndFilterTransportException(HttpMessage message, string clientRequestId, string? traceParent, Stopwatch sw, Exception ex, out bool logged)
    {
        logged = false;
        if (!message.HasResponse)
        {
            sw.Stop();
            LogTransportFailure(
                ex,
                message.Request.Method.ToString(),
                MaskStorageUrl(message.Request.Uri.ToString()),
                sw.ElapsedMilliseconds,
                clientRequestId,
                traceParent);
            logged = true;
        }

        return false; // never catch — let the exception propagate
    }

    private void LogOutcome(HttpMessage message, string clientRequestId, string? traceParent, long durationMs, bool transportFailureLogged)
    {
        if (message.HasResponse)
        {
            LogResponse(message, clientRequestId, traceParent, durationMs);
        }
        else if (!transportFailureLogged)
        {
            // No response and no exception — an inner policy short-circuited the pipeline.
            LogTransportFailureNoException(
                message.Request.Method.ToString(),
                MaskStorageUrl(message.Request.Uri.ToString()),
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

        var uri = MaskStorageUrl(message.Request.Uri.ToString());

        // Extract service-side correlation headers.
        response.Headers.TryGetValue(PlatformHeaders.RequestId, out var xRequestId);
        response.Headers.TryGetValue("apim-request-id", out var apimRequestId);

        // Check if isolation headers were sent on the outbound request.
        var hasUserIsolationKey = message.Request.Headers.TryGetValue(
            PlatformHeaders.UserIsolationKey, out _);
        var hasChatIsolationKey = message.Request.Headers.TryGetValue(
            PlatformHeaders.ChatIsolationKey, out _);

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
                hasUserIsolationKey,
                hasChatIsolationKey);
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
                hasUserIsolationKey,
                hasChatIsolationKey);
        }
    }

    // --- LoggerMessage source-generated methods ---

    [LoggerMessage(Level = LogLevel.Debug, Message = "Foundry storage {Method} {Uri} starting (x-ms-client-request-id: {ClientRequestId}, traceparent: {TraceParent})")]
    private partial void LogRequestStarted(string method, string uri, string clientRequestId, string? traceParent);

    [LoggerMessage(Level = LogLevel.Information, Message = "Foundry storage {Method} {Uri} completed HTTP {StatusCode} in {DurationMs}ms (x-ms-client-request-id: {ClientRequestId}, traceparent: {TraceParent}, x-request-id: {XRequestId}, apim-request-id: {ApimRequestId}, HasUserIsolationKey: {HasUserIsolationKey}, HasChatIsolationKey: {HasChatIsolationKey})")]
    private partial void LogRequestSucceeded(string method, string uri, int statusCode, long durationMs, string clientRequestId, string? traceParent, string? xRequestId, string? apimRequestId, bool hasUserIsolationKey, bool hasChatIsolationKey);

    [LoggerMessage(Level = LogLevel.Warning, Message = "Foundry storage {Method} {Uri} failed HTTP {StatusCode} in {DurationMs}ms (x-ms-client-request-id: {ClientRequestId}, traceparent: {TraceParent}, x-request-id: {XRequestId}, apim-request-id: {ApimRequestId}, HasUserIsolationKey: {HasUserIsolationKey}, HasChatIsolationKey: {HasChatIsolationKey})")]
    private partial void LogRequestFailed(string method, string uri, int statusCode, long durationMs, string clientRequestId, string? traceParent, string? xRequestId, string? apimRequestId, bool hasUserIsolationKey, bool hasChatIsolationKey);

    [LoggerMessage(Level = LogLevel.Error, Message = "Foundry storage {Method} {Uri} transport failure after {DurationMs}ms (x-ms-client-request-id: {ClientRequestId}, traceparent: {TraceParent})")]
    private partial void LogTransportFailure(Exception exception, string method, string uri, long durationMs, string clientRequestId, string? traceParent);

    [LoggerMessage(Level = LogLevel.Error, Message = "Foundry storage {Method} {Uri} completed with no response and no exception after {DurationMs}ms — pipeline may have been short-circuited (x-ms-client-request-id: {ClientRequestId}, traceparent: {TraceParent})")]
    private partial void LogTransportFailureNoException(string method, string uri, long durationMs, string clientRequestId, string? traceParent);
}
