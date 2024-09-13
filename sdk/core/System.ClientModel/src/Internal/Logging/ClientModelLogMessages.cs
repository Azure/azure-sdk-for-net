// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using Microsoft.Extensions.Logging;

namespace System.ClientModel.Internal;

// The methods in this class should only ever be called from LoggingHandler
internal partial class ClientModelLogMessages
{
    private ILogger _logger;
    private PipelineMessageSanitizer _sanitizer;

    public ClientModelLogMessages(ILogger logger, PipelineMessageSanitizer sanitizer)
    {
        _logger = logger;
        _sanitizer = sanitizer;
    }

    #region Request

    public void Request(string requestId, PipelineRequest request, string? clientAssembly)
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            Request(requestId, request.Method, _sanitizer.SanitizeUrl(request.Uri!.AbsoluteUri), FormatHeaders(request.Headers), clientAssembly);
        }
    }

    [LoggerMessage(LoggingEventIds.RequestEvent, LogLevel.Information, "Request [{requestId}] {method} {uri}\r\n{headers}client assembly: {clientAssembly}", EventName = "Request")]
    private partial void Request(string requestId, string method, string uri, string headers, string? clientAssembly);

    public void RequestContent(string requestId, byte[] content, Encoding? textEncoding)
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

    [LoggerMessage(LoggingEventIds.RequestContentEvent, LogLevel.Debug, "Request [{requestId}] content: {content}", EventName = "RequestContent")]
    private partial void RequestContent(string requestId, byte[] content);

    [LoggerMessage(LoggingEventIds.RequestContentTextEvent, LogLevel.Debug, "Request [{requestId}] content: {content}", EventName = "RequestContentText")]
    private partial void RequestContentText(string requestId, string content);
    #endregion

    #region Response

    public void Response(string requestId, PipelineResponse response, double seconds)
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            Response(requestId, response.Status, response.ReasonPhrase, FormatHeaders(response.Headers), seconds);
        }
    }

    [LoggerMessage(LoggingEventIds.ResponseEvent, LogLevel.Information, "Response [{requestId}] {status} {reasonPhrase} ({seconds:00.0}s)\r\n{headers}", EventName = "Response")]
    private partial void Response(string requestId, int status, string reasonPhrase, string headers, double seconds);

    public void ResponseContent(string requestId, byte[] content, Encoding? textEncoding)
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

    [LoggerMessage(LoggingEventIds.ResponseContentEvent, LogLevel.Debug, "Response [{requestId}] content: {content}", EventName = "ResponseContent")]
    private partial void ResponseContent(string requestId, byte[] content);

    [LoggerMessage(LoggingEventIds.ResponseContentTextEvent, LogLevel.Debug, "Response [{requestId}] content: {content}", EventName = "ResponseContentText")]
    private partial void ResponseContentText(string requestId, string content);

    public void ResponseContentBlock(string requestId, int blockNumber, byte[] content, Encoding? textEncoding)
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

    [LoggerMessage(LoggingEventIds.ResponseContentBlockEvent, LogLevel.Debug, "Response [{requestId}] content block {blockNumber}: {content}", EventName = "ResponseContentBlock")]
    private partial void ResponseContentBlock(string requestId, int blockNumber, byte[] content);

    [LoggerMessage(LoggingEventIds.ResponseContentTextBlockEvent, LogLevel.Debug, "Response [{requestId}] content block {blockNumber}: {content}", EventName = "ResponseContentTextBlock")]
    private partial void ResponseContentTextBlock(string requestId, int blockNumber, string content);

    #endregion

    #region Error Response

    [LoggerMessage(LoggingEventIds.ErrorResponseEvent, LogLevel.Warning, "Error response [{requestId}] {status} {reasonPhrase} ({seconds:00.0}s)\r\n{headers}", EventName = "ErrorResponse")]
    private partial void ErrorResponse(string requestId, int status, string reasonPhrase, string headers, double seconds);

    [LoggerMessage(LoggingEventIds.ErrorResponseContentEvent, LogLevel.Information, "Error response [{requestId}] content: {content}", EventName = "ErrorResponseContent")]
    private partial void ErrorResponseContent(string requestId, byte[] content);

    [LoggerMessage(LoggingEventIds.ErrorResponseContentTextEvent, LogLevel.Information, "Error response [{requestId}] content: {content}", EventName = "ErrorResponseContentText")]
    private partial void ErrorResponseContentText(string requestId, string content);

    [LoggerMessage(LoggingEventIds.ErrorResponseContentBlockEvent, LogLevel.Information, "Error response [{requestId}] content block {blockNumber}: {content}", EventName = "ErrorResponseContentBlock")]
    private partial void ErrorResponseContentBlock(string requestId, int blockNumber, byte[] content);

    [LoggerMessage(LoggingEventIds.ErrorResponseContentTextBlockEvent, LogLevel.Information, "Error response [{requestId}] content block {blockNumber}: {content}", EventName = "ErrorResponseContentTextBlock")]
    private partial void ErrorResponseContentTextBlock(string requestId, int blockNumber, string content);

    #endregion

    #region Retry

    [LoggerMessage(LoggingEventIds.RequestRetryingEvent, LogLevel.Information, "Request [{requestId}] attempt number {retryCount} took {seconds:00.0}s", EventName = "RequestRetrying")]
    private partial void RequestRetrying(string requestId, int retryCount, double seconds);

    #endregion

    #region Delay Response

    [LoggerMessage(LoggingEventIds.ResponseDelayEvent, LogLevel.Warning, "Response [{requestId}] took {seconds:00.0}s", EventName = "ResponseDelay")]
    private partial void ResponseDelay(string requestId, double seconds);

    #endregion

    #region Exception Response

    [LoggerMessage(LoggingEventIds.ExceptionResponseEvent, LogLevel.Information, "Request [{requestId}] exception occurred.", EventName = "ExceptionResponse")]
    private partial void ExceptionResponse(string requestId, Exception exception);

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
