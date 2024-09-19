// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace System.ClientModel.Internal;

// The methods in this class should only ever be called from LoggingHandler
internal static partial class ClientModelLogMessages
{
    #region Request

    public static void Request(ILogger logger, string requestId, PipelineRequest request, string? clientAssembly, PipelineMessageSanitizer sanitizer)
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            Request(logger, requestId, request.Method, sanitizer.SanitizeUrl(request.Uri!.AbsoluteUri), FormatHeaders(request.Headers, sanitizer), clientAssembly);
        }
    }

    [LoggerMessage(LoggingEventIds.RequestEvent, LogLevel.Information, "Request [{requestId}] {method} {uri}\r\n{headers}client assembly: {clientAssembly}", SkipEnabledCheck = true, EventName = "Request")]
    private static partial void Request(ILogger logger, string requestId, string method, string uri, string headers, string? clientAssembly);

    public static void RequestContent(ILogger logger, string requestId, byte[] content, Encoding? textEncoding)
    {
        if (logger.IsEnabled(LogLevel.Debug))
        {
            if (textEncoding != null)
            {
                RequestContentText(logger, requestId, textEncoding.GetString(content));
            }
            else
            {
                RequestContent(logger, requestId, content);
            }
        }
    }

    [LoggerMessage(LoggingEventIds.RequestContentEvent, LogLevel.Debug, "Request [{requestId}] content: {content}", SkipEnabledCheck = true, EventName = "RequestContent")]
    private static partial void RequestContent(ILogger logger, string requestId, byte[] content);

    [LoggerMessage(LoggingEventIds.RequestContentTextEvent, LogLevel.Debug, "Request [{requestId}] content: {content}", SkipEnabledCheck = true, EventName = "RequestContentText")]
    private static partial void RequestContentText(ILogger logger, string requestId, string content);
    #endregion

    #region Response

    public static void Response(ILogger logger, string requestId, PipelineResponse response, double seconds, PipelineMessageSanitizer sanitizer)
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            Response(logger, requestId, response.Status, response.ReasonPhrase, FormatHeaders(response.Headers, sanitizer), seconds);
        }
    }

    [LoggerMessage(LoggingEventIds.ResponseEvent, LogLevel.Information, "Response [{requestId}] {status} {reasonPhrase} ({seconds:00.0}s)\r\n{headers}", SkipEnabledCheck = true, EventName = "Response")]
    private static partial void Response(ILogger logger, string requestId, int status, string reasonPhrase, string headers, double seconds);

    public static void ResponseContent(ILogger logger, string requestId, byte[] content, Encoding? textEncoding)
    {
        if (logger.IsEnabled(LogLevel.Debug))
        {
            if (textEncoding != null)
            {
                ResponseContentText(logger, requestId, textEncoding.GetString(content));
            }
            else
            {
                ResponseContent(logger, requestId, content);
            }
        }
    }

    [LoggerMessage(LoggingEventIds.ResponseContentEvent, LogLevel.Debug, "Response [{requestId}] content: {content}", SkipEnabledCheck = true, EventName = "ResponseContent")]
    private static partial void ResponseContent(ILogger logger, string requestId, byte[] content);

    [LoggerMessage(LoggingEventIds.ResponseContentTextEvent, LogLevel.Debug, "Response [{requestId}] content: {content}", SkipEnabledCheck = true, EventName = "ResponseContentText")]
    private static partial void ResponseContentText(ILogger logger, string requestId, string content);

    public static void ResponseContentBlock(ILogger logger, string requestId, int blockNumber, byte[] content, Encoding? textEncoding)
    {
        if (logger.IsEnabled(LogLevel.Debug))
        {
            if (textEncoding != null)
            {
                ResponseContentTextBlock(logger, requestId, blockNumber, textEncoding.GetString(content));
            }
            else
            {
                ResponseContentBlock(logger, requestId, blockNumber, content);
            }
        }
    }

    [LoggerMessage(LoggingEventIds.ResponseContentBlockEvent, LogLevel.Debug, "Response [{requestId}] content block {blockNumber}: {content}", SkipEnabledCheck = true, EventName = "ResponseContentBlock")]
    private static partial void ResponseContentBlock(ILogger logger, string requestId, int blockNumber, byte[] content);

    [LoggerMessage(LoggingEventIds.ResponseContentTextBlockEvent, LogLevel.Debug, "Response [{requestId}] content block {blockNumber}: {content}", SkipEnabledCheck = true, EventName = "ResponseContentTextBlock")]
    private static partial void ResponseContentTextBlock(ILogger logger, string requestId, int blockNumber, string content);

    #endregion

    #region Error Response

    public static void ErrorResponse(ILogger logger, string requestId, PipelineResponse response, double seconds, PipelineMessageSanitizer sanitizer)
    {
        if (logger.IsEnabled(LogLevel.Warning))
        {
            ErrorResponse(logger, requestId, response.Status, response.ReasonPhrase, FormatHeaders(response.Headers, sanitizer), seconds);
        }
    }

    [LoggerMessage(LoggingEventIds.ErrorResponseEvent, LogLevel.Warning, "Error response [{requestId}] {status} {reasonPhrase} ({seconds:00.0}s)\r\n{headers}", SkipEnabledCheck = true, EventName = "ErrorResponse")]
    private static partial void ErrorResponse(ILogger logger, string requestId, int status, string reasonPhrase, string headers, double seconds);

    public static void ErrorResponseContent(ILogger logger, string requestId, byte[] content, Encoding? textEncoding)
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            if (textEncoding != null)
            {
                ErrorResponseContentText(logger, requestId, textEncoding.GetString(content));
            }
            else
            {
                ErrorResponseContent(logger, requestId, content);
            }
        }
    }

    [LoggerMessage(LoggingEventIds.ErrorResponseContentEvent, LogLevel.Information, "Error response [{requestId}] content: {content}", SkipEnabledCheck = true, EventName = "ErrorResponseContent")]
    private static partial void ErrorResponseContent(ILogger logger, string requestId, byte[] content);

    [LoggerMessage(LoggingEventIds.ErrorResponseContentTextEvent, LogLevel.Information, "Error response [{requestId}] content: {content}", SkipEnabledCheck = true, EventName = "ErrorResponseContentText")]
    private static partial void ErrorResponseContentText(ILogger logger, string requestId, string content);

    public static void ErrorResponseContentBlock(ILogger logger, string requestId, int blockNumber, byte[] content, Encoding? textEncoding)
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            if (textEncoding != null)
            {
                ErrorResponseContentTextBlock(logger, requestId, blockNumber, textEncoding.GetString(content));
            }
            else
            {
                ErrorResponseContentBlock(logger, requestId, blockNumber, content);
            }
        }
    }

    [LoggerMessage(LoggingEventIds.ErrorResponseContentBlockEvent, LogLevel.Information, "Error response [{requestId}] content block {blockNumber}: {content}", SkipEnabledCheck = true, EventName = "ErrorResponseContentBlock")]
    private static partial void ErrorResponseContentBlock(ILogger logger, string requestId, int blockNumber, byte[] content);

    [LoggerMessage(LoggingEventIds.ErrorResponseContentTextBlockEvent, LogLevel.Information, "Error response [{requestId}] content block {blockNumber}: {content}", SkipEnabledCheck = true, EventName = "ErrorResponseContentTextBlock")]
    private static partial void ErrorResponseContentTextBlock(ILogger logger, string requestId, int blockNumber, string content);

    #endregion

    #region Retry
    [LoggerMessage(LoggingEventIds.RequestRetryingEvent, LogLevel.Information, "Request [{requestId}] attempt number {retryCount} took {seconds:00.0}s", EventName = "RequestRetrying")]
    public static partial void RequestRetrying(ILogger logger, string requestId, int retryCount, double seconds);

    #endregion

    #region Delay Response

    [LoggerMessage(LoggingEventIds.ResponseDelayEvent, LogLevel.Warning, "Response [{requestId}] took {seconds:00.0}s", EventName = "ResponseDelay")]
    public static partial void ResponseDelay(ILogger logger, string requestId, double seconds);

    #endregion

    #region Exception Response

    [LoggerMessage(LoggingEventIds.ExceptionResponseEvent, LogLevel.Information, "Request [{requestId}] exception occurred.", EventName = "ExceptionResponse")]
    public static partial void ExceptionResponse(ILogger logger, string requestId, Exception exception);

    #endregion

    #region Helpers

    private static string FormatHeaders(IEnumerable<KeyValuePair<string, string>> headers, PipelineMessageSanitizer sanitizer)
    {
        var stringBuilder = new StringBuilder();
        foreach (var header in headers)
        {
            stringBuilder.Append(header.Key);
            stringBuilder.Append(':');
            stringBuilder.Append(sanitizer.SanitizeHeader(header.Key, header.Value));
            stringBuilder.Append(Environment.NewLine);
        }
        return stringBuilder.ToString();
    }

    #endregion
}
