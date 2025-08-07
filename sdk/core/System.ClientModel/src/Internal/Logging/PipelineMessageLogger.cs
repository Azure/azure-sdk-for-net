// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace System.ClientModel.Internal;

internal partial class PipelineMessageLogger
{
    private readonly ILogger<MessageLoggingPolicy>? _logger;
    private readonly PipelineMessageSanitizer _sanitizer;

    public PipelineMessageLogger(PipelineMessageSanitizer sanitizer, ILoggerFactory? loggerFactory)
    {
        _sanitizer = sanitizer;
        _logger = loggerFactory?.CreateLogger<MessageLoggingPolicy>() ?? null;
    }

    /// <summary>
    ///  Whether the given log level or event level is enabled, depending
    ///  on whether this handler logs to ILogger or Event Source. Should be
    ///  used to guard expensive operations.
    /// </summary>
    /// <param name="logLevel">The LogLevel to log to for ILogger. If an ILogger WAS NOT provided to the constructor, this value will be ignored.</param>
    /// <param name="eventLevel">The EventLevel to log to for EventSource. If an ILogger WAS provided to the constructor, this value will be ignored.</param>
    public bool IsEnabled(LogLevel logLevel, EventLevel eventLevel)
    {
        return _logger is not null ? _logger.IsEnabled(logLevel) : ClientModelEventSource.Log.IsEnabled(eventLevel, EventKeywords.None);
    }

    #region Request

    public void LogRequest(string requestId, PipelineRequest request, string? clientAssembly)
    {
        if (_logger is not null)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                Request(_logger, requestId, request.Method, _sanitizer.SanitizeUrl(request.Uri!.AbsoluteUri), new PipelineMessageHeadersLogValue(request.Headers, _sanitizer), clientAssembly);
            }
        }
        else
        {
            ClientModelEventSource.Log.Request(requestId, request, clientAssembly, _sanitizer);
        }
    }

    [LoggerMessage(LoggingEventIds.RequestEvent, LogLevel.Information, "Request [{requestId}] {method} {uri}\r\n{headers}client assembly: {clientAssembly}", SkipEnabledCheck = true, EventName = "Request")]
    private static partial void Request(ILogger logger, string requestId, string method, string uri, PipelineMessageHeadersLogValue headers, string? clientAssembly);

    public void LogRequestContent(string requestId, byte[] content, Encoding? textEncoding)
    {
        if (_logger is not null)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                if (textEncoding != null)
                {
                    RequestContentText(_logger, requestId, textEncoding.GetString(content));
                }
                else
                {
                    RequestContent(_logger, requestId, content);
                }
            }
        }
        else
        {
            ClientModelEventSource.Log.RequestContent(requestId, content, textEncoding);
        }
    }

    [LoggerMessage(LoggingEventIds.RequestContentEvent, LogLevel.Debug, "Request [{requestId}] content: {content}", SkipEnabledCheck = true, EventName = "RequestContent")]
    private static partial void RequestContent(ILogger logger, string requestId, byte[] content);

    [LoggerMessage(LoggingEventIds.RequestContentTextEvent, LogLevel.Debug, "Request [{requestId}] content: {content}", SkipEnabledCheck = true, EventName = "RequestContentText")]
    private static partial void RequestContentText(ILogger logger, string requestId, string content);

    #endregion

    #region Response

    public void LogResponse(string requestId, PipelineResponse response, double seconds)
    {
        if (_logger is not null)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                Response(_logger, requestId, response.Status, response.ReasonPhrase, new PipelineMessageHeadersLogValue(response.Headers, _sanitizer), seconds);
            }
        }
        else
        {
            ClientModelEventSource.Log.Response(requestId, response, seconds, _sanitizer);
        }
    }

    [LoggerMessage(LoggingEventIds.ResponseEvent, LogLevel.Information, "Response [{requestId}] {status} {reasonPhrase} ({seconds:00.0}s)\r\n{headers}", SkipEnabledCheck = true, EventName = "Response")]
    private static partial void Response(ILogger logger, string requestId, int status, string reasonPhrase, PipelineMessageHeadersLogValue headers, double seconds);

    public void LogResponseContent(string requestId, byte[] content, Encoding? textEncoding)
    {
        if (_logger is not null)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                if (textEncoding != null)
                {
                    ResponseContentText(_logger, requestId, textEncoding.GetString(content));
                }
                else
                {
                    ResponseContent(_logger, requestId, content);
                }
            }
        }
        else
        {
            ClientModelEventSource.Log.ResponseContent(requestId, content, textEncoding);
        }
    }

    [LoggerMessage(LoggingEventIds.ResponseContentEvent, LogLevel.Debug, "Response [{requestId}] content: {content}", SkipEnabledCheck = true, EventName = "ResponseContent")]
    private static partial void ResponseContent(ILogger logger, string requestId, byte[] content);

    [LoggerMessage(LoggingEventIds.ResponseContentTextEvent, LogLevel.Debug, "Response [{requestId}] content: {content}", SkipEnabledCheck = true, EventName = "ResponseContentText")]
    private static partial void ResponseContentText(ILogger logger, string requestId, string content);

    public void LogResponseContentBlock(string requestId, int blockNumber, byte[] content, Encoding? textEncoding)
    {
        if (_logger is not null)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                if (textEncoding != null)
                {
                    ResponseContentTextBlock(_logger, requestId, blockNumber, textEncoding.GetString(content));
                }
                else
                {
                    ResponseContentBlock(_logger, requestId, blockNumber, content);
                }
            }
        }
        else
        {
            ClientModelEventSource.Log.ResponseContentBlock(requestId, blockNumber, content, textEncoding);
        }
    }

    [LoggerMessage(LoggingEventIds.ResponseContentBlockEvent, LogLevel.Debug, "Response [{requestId}] content block {blockNumber}: {content}", SkipEnabledCheck = true, EventName = "ResponseContentBlock")]
    private static partial void ResponseContentBlock(ILogger logger, string requestId, int blockNumber, byte[] content);

    [LoggerMessage(LoggingEventIds.ResponseContentTextBlockEvent, LogLevel.Debug, "Response [{requestId}] content block {blockNumber}: {content}", SkipEnabledCheck = true, EventName = "ResponseContentTextBlock")]
    private static partial void ResponseContentTextBlock(ILogger logger, string requestId, int blockNumber, string content);

    #endregion

    #region Error Response

    public void LogErrorResponse(string requestId, PipelineResponse response, double seconds)
    {
        if (_logger is not null)
        {
            if (_logger.IsEnabled(LogLevel.Warning))
            {
                ErrorResponse(_logger, requestId, response.Status, response.ReasonPhrase, new PipelineMessageHeadersLogValue(response.Headers, _sanitizer), seconds);
            }
        }
        else
        {
            ClientModelEventSource.Log.ErrorResponse(requestId, response, seconds, _sanitizer);
        }
    }

    [LoggerMessage(LoggingEventIds.ErrorResponseEvent, LogLevel.Warning, "Error response [{requestId}] {status} {reasonPhrase} ({seconds:00.0}s)\r\n{headers}", SkipEnabledCheck = true, EventName = "ErrorResponse")]
    private static partial void ErrorResponse(ILogger logger, string requestId, int status, string reasonPhrase, PipelineMessageHeadersLogValue headers, double seconds);

    public void LogErrorResponseContent(string requestId, byte[] content, Encoding? textEncoding)
    {
        if (_logger is not null)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                if (textEncoding != null)
                {
                    ErrorResponseContentText(_logger, requestId, textEncoding.GetString(content));
                }
                else
                {
                    ErrorResponseContent(_logger, requestId, content);
                }
            }
        }
        else
        {
            ClientModelEventSource.Log.ErrorResponseContent(requestId, content, textEncoding);
        }
    }

    [LoggerMessage(LoggingEventIds.ErrorResponseContentEvent, LogLevel.Information, "Error response [{requestId}] content: {content}", SkipEnabledCheck = true, EventName = "ErrorResponseContent")]
    private static partial void ErrorResponseContent(ILogger logger, string requestId, byte[] content);

    [LoggerMessage(LoggingEventIds.ErrorResponseContentTextEvent, LogLevel.Information, "Error response [{requestId}] content: {content}", SkipEnabledCheck = true, EventName = "ErrorResponseContentText")]
    private static partial void ErrorResponseContentText(ILogger logger, string requestId, string content);

    public void LogErrorResponseContentBlock(string requestId, int blockNumber, byte[] content, Encoding? textEncoding)
    {
        if (_logger is not null)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                if (textEncoding != null)
                {
                    ErrorResponseContentTextBlock(_logger, requestId, blockNumber, textEncoding.GetString(content));
                }
                else
                {
                    ErrorResponseContentBlock(_logger, requestId, blockNumber, content);
                }
            }
        }
        else
        {
            ClientModelEventSource.Log.ErrorResponseContentBlock(requestId, blockNumber, content, textEncoding);
        }
    }

    [LoggerMessage(LoggingEventIds.ErrorResponseContentBlockEvent, LogLevel.Information, "Error response [{requestId}] content block {blockNumber}: {content}", SkipEnabledCheck = true, EventName = "ErrorResponseContentBlock")]
    private static partial void ErrorResponseContentBlock(ILogger logger, string requestId, int blockNumber, byte[] content);

    [LoggerMessage(LoggingEventIds.ErrorResponseContentTextBlockEvent, LogLevel.Information, "Error response [{requestId}] content block {blockNumber}: {content}", SkipEnabledCheck = true, EventName = "ErrorResponseContentTextBlock")]
    private static partial void ErrorResponseContentTextBlock(ILogger logger, string requestId, int blockNumber, string content);

    #endregion
}
