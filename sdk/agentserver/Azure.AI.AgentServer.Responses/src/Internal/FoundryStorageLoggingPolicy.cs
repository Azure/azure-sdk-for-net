// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
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

    /// <inheritdoc/>
    public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        var sw = Stopwatch.StartNew();
        var clientRequestId = message.Request.ClientRequestId;
        LogRequestStarted(message.Request.Method.ToString(), message.Request.Uri.ToString(), clientRequestId);

        try
        {
            ProcessNext(message, pipeline);
        }
        finally
        {
            sw.Stop();
            LogResponse(message, clientRequestId, sw.ElapsedMilliseconds);
        }
    }

    /// <inheritdoc/>
    public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        var sw = Stopwatch.StartNew();
        var clientRequestId = message.Request.ClientRequestId;
        LogRequestStarted(message.Request.Method.ToString(), message.Request.Uri.ToString(), clientRequestId);

        try
        {
            await ProcessNextAsync(message, pipeline);
        }
        finally
        {
            sw.Stop();
            LogResponse(message, clientRequestId, sw.ElapsedMilliseconds);
        }
    }

    private void LogResponse(HttpMessage message, string clientRequestId, long durationMs)
    {
        var response = message.Response;
        if (response is null)
        {
            return;
        }

        var uri = message.Request.Uri.ToString();

        // Extract service-side correlation headers.
        response.Headers.TryGetValue("x-ms-request-id", out var serviceRequestId);
        response.Headers.TryGetValue("x-request-id", out var xRequestId);
        response.Headers.TryGetValue("apim-request-id", out var apimRequestId);

        if (response.IsError)
        {
            LogRequestFailed(
                message.Request.Method.ToString(),
                uri,
                response.Status,
                durationMs,
                clientRequestId,
                serviceRequestId,
                xRequestId,
                apimRequestId);
        }
        else
        {
            LogRequestSucceeded(
                message.Request.Method.ToString(),
                uri,
                response.Status,
                durationMs,
                clientRequestId,
                serviceRequestId,
                xRequestId,
                apimRequestId);
        }
    }

    // --- LoggerMessage source-generated methods ---

    [LoggerMessage(Level = LogLevel.Debug, Message = "Foundry storage {Method} {Uri} starting (x-ms-client-request-id: {ClientRequestId})")]
    private partial void LogRequestStarted(string method, string uri, string clientRequestId);

    [LoggerMessage(Level = LogLevel.Information, Message = "Foundry storage {Method} {Uri} completed HTTP {StatusCode} in {DurationMs}ms (x-ms-client-request-id: {ClientRequestId}, x-ms-request-id: {ServiceRequestId}, x-request-id: {XRequestId}, apim-request-id: {ApimRequestId})")]
    private partial void LogRequestSucceeded(string method, string uri, int statusCode, long durationMs, string clientRequestId, string? serviceRequestId, string? xRequestId, string? apimRequestId);

    [LoggerMessage(Level = LogLevel.Warning, Message = "Foundry storage {Method} {Uri} failed HTTP {StatusCode} in {DurationMs}ms (x-ms-client-request-id: {ClientRequestId}, x-ms-request-id: {ServiceRequestId}, x-request-id: {XRequestId}, apim-request-id: {ApimRequestId})")]
    private partial void LogRequestFailed(string method, string uri, int statusCode, long durationMs, string clientRequestId, string? serviceRequestId, string? xRequestId, string? apimRequestId);
}
