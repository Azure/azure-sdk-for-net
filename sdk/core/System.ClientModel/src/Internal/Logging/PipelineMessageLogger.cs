// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using Microsoft.Extensions.Logging;

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
    ///  on whether this handler logs to ILogger or Event Source. Can be
    ///  used to guard expensive operations.
    /// </summary>
    /// <param name="logLevel"></param>
    /// <param name="eventLevel"></param>
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
                Request(requestId, request.Method, _sanitizer.SanitizeUrl(request.Uri!.AbsoluteUri), FormatHeaders(request.Headers), clientAssembly);
            }
        }
        else
        {
            ClientModelEventSource.Log.Request(requestId, request, clientAssembly, _sanitizer);
        }
    }

    [LoggerMessage(LoggingEventIds.RequestEvent, LogLevel.Information, "Request [{requestId}] {method} {uri}\r\n{headers}client assembly: {clientAssembly}", SkipEnabledCheck = true, EventName = "Request")]
    private partial void Request(string requestId, string method, string uri, string headers, string? clientAssembly);

    public void LogRequestContent(string requestId, byte[] content, Encoding? textEncoding)
    {
        if (_logger is not null)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                if (textEncoding != null)
                {
                    RequestContentText(requestId, textEncoding.GetString(content));
                }
                else
                {
                    RequestContent(requestId, content);
                }
            }
        }
        else
        {
            ClientModelEventSource.Log.RequestContent(requestId, content, textEncoding);
        }
    }

    [LoggerMessage(LoggingEventIds.RequestContentEvent, LogLevel.Debug, "Request [{requestId}] content: {content}", SkipEnabledCheck = true, EventName = "RequestContent")]
    private partial void RequestContent(string requestId, byte[] content);

    [LoggerMessage(LoggingEventIds.RequestContentTextEvent, LogLevel.Debug, "Request [{requestId}] content: {content}", SkipEnabledCheck = true, EventName = "RequestContentText")]
    private partial void RequestContentText(string requestId, string content);

    #endregion

    #region Response

    public void LogResponse(string requestId, PipelineResponse response, double seconds)
    {
        if (_logger is not null)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                Response(requestId, response.Status, response.ReasonPhrase, FormatHeaders(response.Headers), seconds);
            }
        }
        else
        {
            ClientModelEventSource.Log.Response(requestId, response, seconds, _sanitizer);
        }
    }

    [LoggerMessage(LoggingEventIds.ResponseEvent, LogLevel.Information, "Response [{requestId}] {status} {reasonPhrase} ({seconds:00.0}s)\r\n{headers}", SkipEnabledCheck = true, EventName = "Response")]
    private partial void Response(string requestId, int status, string reasonPhrase, string headers, double seconds);

    public void LogResponseContent(string requestId, byte[] content, Encoding? textEncoding)
    {
        if (_logger is not null)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                if (textEncoding != null)
                {
                    ResponseContentText(requestId, textEncoding.GetString(content));
                }
                else
                {
                    ResponseContent(requestId, content);
                }
            }
        }
        else
        {
            ClientModelEventSource.Log.ResponseContent(requestId, content, textEncoding);
        }
    }

    [LoggerMessage(LoggingEventIds.ResponseContentEvent, LogLevel.Debug, "Response [{requestId}] content: {content}", SkipEnabledCheck = true, EventName = "ResponseContent")]
    private partial void ResponseContent(string requestId, byte[] content);

    [LoggerMessage(LoggingEventIds.ResponseContentTextEvent, LogLevel.Debug, "Response [{requestId}] content: {content}", SkipEnabledCheck = true, EventName = "ResponseContentText")]
    private partial void ResponseContentText(string requestId, string content);

    public void LogResponseContentBlock(string requestId, int blockNumber, byte[] content, Encoding? textEncoding)
    {
        if (_logger is not null)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                if (textEncoding != null)
                {
                    ResponseContentTextBlock(requestId, blockNumber, textEncoding.GetString(content));
                }
                else
                {
                    ResponseContentBlock(requestId, blockNumber, content);
                }
            }
        }
        else
        {
            ClientModelEventSource.Log.ResponseContentBlock(requestId, blockNumber, content, textEncoding);
        }
    }

    [LoggerMessage(LoggingEventIds.ResponseContentBlockEvent, LogLevel.Debug, "Response [{requestId}] content block {blockNumber}: {content}", SkipEnabledCheck = true, EventName = "ResponseContentBlock")]
    private partial void ResponseContentBlock(string requestId, int blockNumber, byte[] content);

    [LoggerMessage(LoggingEventIds.ResponseContentTextBlockEvent, LogLevel.Debug, "Response [{requestId}] content block {blockNumber}: {content}", SkipEnabledCheck = true, EventName = "ResponseContentTextBlock")]
    private partial void ResponseContentTextBlock(string requestId, int blockNumber, string content);

    #endregion

    #region Error Response

    public void LogErrorResponse(string requestId, PipelineResponse response, double seconds)
    {
        if (_logger is not null)
        {
            if (_logger.IsEnabled(LogLevel.Warning))
            {
                ErrorResponse(requestId, response.Status, response.ReasonPhrase, FormatHeaders(response.Headers), seconds);
            }
        }
        else
        {
            ClientModelEventSource.Log.ErrorResponse(requestId, response, seconds, _sanitizer);
        }
    }

    [LoggerMessage(LoggingEventIds.ErrorResponseEvent, LogLevel.Warning, "Error response [{requestId}] {status} {reasonPhrase} ({seconds:00.0}s)\r\n{headers}", SkipEnabledCheck = true, EventName = "ErrorResponse")]
    private partial void ErrorResponse(string requestId, int status, string reasonPhrase, string headers, double seconds);

    public void LogErrorResponseContent(string requestId, byte[] content, Encoding? textEncoding)
    {
        if (_logger is not null)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                if (textEncoding != null)
                {
                    ErrorResponseContentText(requestId, textEncoding.GetString(content));
                }
                else
                {
                    ErrorResponseContent(requestId, content);
                }
            }
        }
        else
        {
            ClientModelEventSource.Log.ErrorResponseContent(requestId, content, textEncoding);
        }
    }

    [LoggerMessage(LoggingEventIds.ErrorResponseContentEvent, LogLevel.Information, "Error response [{requestId}] content: {content}", SkipEnabledCheck = true, EventName = "ErrorResponseContent")]
    private partial void ErrorResponseContent(string requestId, byte[] content);

    [LoggerMessage(LoggingEventIds.ErrorResponseContentTextEvent, LogLevel.Information, "Error response [{requestId}] content: {content}", SkipEnabledCheck = true, EventName = "ErrorResponseContentText")]
    private partial void ErrorResponseContentText(string requestId, string content);

    public void LogErrorResponseContentBlock(string requestId, int blockNumber, byte[] content, Encoding? textEncoding)
    {
        if (_logger is not null)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                if (textEncoding != null)
                {
                    ErrorResponseContentTextBlock(requestId, blockNumber, textEncoding.GetString(content));
                }
                else
                {
                    ErrorResponseContentBlock(requestId, blockNumber, content);
                }
            }
        }
        else
        {
            ClientModelEventSource.Log.ErrorResponseContentBlock(requestId, blockNumber, content, textEncoding);
        }
    }

    [LoggerMessage(LoggingEventIds.ErrorResponseContentBlockEvent, LogLevel.Information, "Error response [{requestId}] content block {blockNumber}: {content}", SkipEnabledCheck = true, EventName = "ErrorResponseContentBlock")]
    private partial void ErrorResponseContentBlock(string requestId, int blockNumber, byte[] content);

    [LoggerMessage(LoggingEventIds.ErrorResponseContentTextBlockEvent, LogLevel.Information, "Error response [{requestId}] content block {blockNumber}: {content}", SkipEnabledCheck = true, EventName = "ErrorResponseContentTextBlock")]
    private partial void ErrorResponseContentTextBlock(string requestId, int blockNumber, string content);

    #endregion

    #region Helpers

    private string FormatHeaders(IEnumerable<KeyValuePair<string, string>> headers)
    {
        var stringBuilder = new StringBuilder();
        foreach (var header in headers)
        {
            stringBuilder.Append(header.Key);
            stringBuilder.Append(':');
            stringBuilder.Append(_sanitizer.SanitizeHeader(header.Key, header.Value));
            stringBuilder.Append(Environment.NewLine);
        }
        return stringBuilder.ToString();
    }


    #endregion
}
