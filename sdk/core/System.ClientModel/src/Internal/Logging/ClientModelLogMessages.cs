// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using Microsoft.Extensions.Logging;

namespace System.ClientModel.Internal;
internal partial class ClientModelLogMessages
{
    private const int RequestEvent = 1;
    private const int RequestContentEvent = 2;
    private const int ResponseEvent = 5;
    private const int ResponseContentEvent = 6;
    private const int ResponseDelayEvent = 7;
    private const int ErrorResponseEvent = 8;
    private const int ErrorResponseContentEvent = 9;
    private const int RequestRetryingEvent = 10;
    private const int ResponseContentBlockEvent = 11;
    private const int ErrorResponseContentBlockEvent = 12;
    private const int ResponseContentTextEvent = 13;
    private const int ErrorResponseContentTextEvent = 14;
    private const int ResponseContentTextBlockEvent = 15;
    private const int ErrorResponseContentTextBlockEvent = 16;
    private const int RequestContentTextEvent = 17;
    private const int ExceptionResponseEvent = 18;

    private ILogger _logger;
    private PipelineMessageSanitizer _sanitizer;

    public ClientModelLogMessages(ILogger logger, PipelineMessageSanitizer sanitizer)
    {
        _logger = logger;
        _sanitizer = sanitizer;
    }

    #region Request

    public void Request(string requestId, PipelineRequest request)
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            string uri = request.Uri == null ? string.Empty : _sanitizer.SanitizeUrl(request.Uri.AbsoluteUri);
            Request(requestId, request.Method, uri, FormatHeaders(request.Headers));
        }
    }

    [LoggerMessage(RequestEvent, LogLevel.Information, "Request [{requestId}] {method} {uri}\r\n{headers}", EventName = "Request")]
    private partial void Request(string requestId, string method, string uri, string headers);

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

    [LoggerMessage(RequestContentEvent, LogLevel.Debug, "Request [{requestId}] content: {content}", EventName = "RequestContent")]
    private partial void RequestContent(string requestId, byte[] content);

    [LoggerMessage(RequestContentTextEvent, LogLevel.Debug, "Request [{requestId}] content: {content}", EventName = "RequestContentText")]
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

    [LoggerMessage(ResponseEvent, LogLevel.Information, "Response [{requestId}] {status} {reasonPhrase} ({seconds:00.0}s)\r\n{headers}", EventName = "Response")]
    private partial void Response(string requestId, int status, string reasonPhrase, string headers, double seconds);

    public void ResponseContent(string requestId, byte[] content, Encoding? textEncoding)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            if (textEncoding == null)
            {
                ResponseContent(requestId, content);
            }
            else
            {
                ResponseContentText(requestId, textEncoding.GetString(content));
            }
        }
    }

    [LoggerMessage(ResponseContentEvent, LogLevel.Debug, "Response [{requestId}] content: {content}", EventName = "ResponseContent")]
    private partial void ResponseContent(string requestId, byte[] content);

    [LoggerMessage(ResponseContentTextEvent, LogLevel.Debug, "Response [{requestId}] content: {content}", EventName = "ResponseContentText")]
    private partial void ResponseContentText(string requestId, string content);

    public void ResponseContentBlock(string requestId, int blockNumber, byte[] content, Encoding? textEncoding)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            if (textEncoding == null)
            {
                ResponseContentBlock(requestId, blockNumber, content);
            }
            else
            {
                ResponseContentTextBlock(requestId, blockNumber, textEncoding.GetString(content));
            }
        }
    }

    [LoggerMessage(ResponseContentBlockEvent, LogLevel.Debug, "Response [{requestId}] content block {blockNumber}: {content}", EventName = "ResponseContentBlock")]
    private partial void ResponseContentBlock(string requestId, int blockNumber, byte[] content);

    [LoggerMessage(ResponseContentTextBlockEvent, LogLevel.Debug, "Response [{requestId}] content block {blockNumber}: {content}", EventName = "ResponseContentTextBlock")]
    private partial void ResponseContentTextBlock(string requestId, int blockNumber, string content);

    #endregion

    #region Error response

    public void ErrorResponse(string requestId, PipelineResponse response, double seconds)
    {
        if (_logger.IsEnabled(LogLevel.Warning))
        {
            ErrorResponse(requestId, response.Status, response.ReasonPhrase, FormatHeaders(response.Headers), seconds);
        }
    }

    [LoggerMessage(ErrorResponseEvent, LogLevel.Warning, "Error response [{requestId}] {status} {reasonPhrase} ({seconds:00.0}s)\r\n{headers}", EventName = "ErrorResponse")]
    private partial void ErrorResponse(string requestId, int status, string reasonPhrase, string headers, double seconds);

    public void ErrorResponseContent(string requestId, byte[] content, Encoding? textEncoding)
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            if (textEncoding == null)
            {
                ErrorResponseContent(requestId, content);
            }
            else
            {
                ErrorResponseContentText(requestId, textEncoding.GetString(content));
            }
        }
    }

    [LoggerMessage(ErrorResponseContentEvent, LogLevel.Information, "Error response [{requestId}] content: {content}", EventName = "ErrorResponseContent")]
    private partial void ErrorResponseContent(string requestId, byte[] content);

    [LoggerMessage(ErrorResponseContentTextEvent, LogLevel.Information, "Error response [{requestId}] content: {content}", EventName = "ErrorResponseContentText")]
    private partial void ErrorResponseContentText(string requestId, string content);

    public void ErrorResponseContentBlock(string requestId, int blockNumber, byte[] content, Encoding? textEncoding)
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            if (textEncoding == null)
            {
                ErrorResponseContentBlock(requestId, blockNumber, content);
            }
            else
            {
                ErrorResponseContentTextBlock(requestId, blockNumber, textEncoding.GetString(content));
            }
        }
    }

    [LoggerMessage(ErrorResponseContentBlockEvent, LogLevel.Information, "Error response [{requestId}] content block {blockNumber}: {content}", EventName = "ErrorResponseContentBlock")]
    private partial void ErrorResponseContentBlock(string requestId, int blockNumber, byte[] content);

    [LoggerMessage(ErrorResponseContentTextBlockEvent, LogLevel.Information, "Error response [{requestId}] content block {blockNumber}: {content}", EventName = "ErrorResponseContentTextBlock")]
    private partial void ErrorResponseContentTextBlock(string requestId, int blockNumber, string content);

    #endregion

    #region Request retrying

    [LoggerMessage(RequestRetryingEvent, LogLevel.Information, "Request [{requestId}] attempt number {retryCount} took {seconds:00.0}s", EventName = "RequestRetrying")]
    public partial void RequestRetrying(string requestId, int retryCount, double seconds);

    #endregion

    #region Response delay

    [LoggerMessage(ResponseDelayEvent, LogLevel.Warning, "Response [{requestId}] took {seconds:00.0}s", EventName = "ResponseDelay")]
    public partial void ResponseDelay(string requestId, double seconds);

    #endregion

    #region Exception response

    [LoggerMessage(ExceptionResponseEvent, LogLevel.Information, "Request [{requestId}] exception occurred.", EventName = "ExceptionResponse")]
    public partial void ExceptionResponse(string requestId, Exception exception);

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
