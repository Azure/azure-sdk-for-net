// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using Microsoft.Extensions.Logging;

namespace System.ClientModel.Internal;

internal static class LoggingHandler
{
    public static void LogRequest(ILogger logger, PipelineRequest request, string requestId, string? assemblyName, PipelineMessageSanitizer sanitizer)
    {
        bool isEventSourceEnabled = ClientModelEventSource.Log.IsEnabled(EventLevel.Informational, EventKeywords.None);
        bool isLoggerEnabled = logger.IsEnabled(LogLevel.Information);

        if (isLoggerEnabled)
        {
            ClientModelLogMessages.Request(logger, requestId, request.Method, sanitizer.SanitizeUrl(request.Uri!.AbsoluteUri), FormatHeaders(request.Headers, sanitizer), assemblyName);
        }
        else if (isEventSourceEnabled)
        {
            ClientModelEventSource.Log.Request(requestId, request.Method, sanitizer.SanitizeUrl(request.Uri!.AbsoluteUri), FormatHeaders(request.Headers, sanitizer), assemblyName);
        }
    }

    public static void LogRequestContent(ILogger logger, string requestId, byte[] content, Encoding? textEncoding)
    {
        bool isEventSourceEnabled = ClientModelEventSource.Log.IsEnabled(EventLevel.Verbose, EventKeywords.None);
        bool isLoggerEnabled = logger.IsEnabled(LogLevel.Debug);

        if (isLoggerEnabled)
        {
            if (textEncoding != null)
            {
                ClientModelLogMessages.RequestContentText(logger, requestId, textEncoding.GetString(content));
            }
            else
            {
                ClientModelLogMessages.RequestContent(logger, requestId, content);
            }
        }
        else if (isEventSourceEnabled)
        {
            if (textEncoding != null)
            {
                ClientModelEventSource.Log.RequestContentText(requestId, textEncoding.GetString(content));
            }
            else
            {
                ClientModelEventSource.Log.RequestContent(requestId, content);
            }
        }
    }

    public static void LogResponse(ILogger logger, string requestId, PipelineResponse response, double seconds, PipelineMessageSanitizer sanitizer)
    {
        bool isEventSourceEnabled = ClientModelEventSource.Log.IsEnabled(EventLevel.Informational, EventKeywords.None);
        bool isLoggerEnabled = logger.IsEnabled(LogLevel.Information);

        if (isLoggerEnabled)
        {
            ClientModelLogMessages.Response(logger, requestId, response.Status, response.ReasonPhrase, FormatHeaders(response.Headers, sanitizer), seconds);
        }
        else if (isEventSourceEnabled)
        {
            ClientModelEventSource.Log.Response(requestId, response.Status, response.ReasonPhrase, FormatHeaders(response.Headers, sanitizer), seconds);
        }
    }

    public static void LogResponseContent(ILogger logger, string requestId, byte[] content, Encoding? textEncoding)
    {
        bool isEventSourceEnabled = ClientModelEventSource.Log.IsEnabled(EventLevel.Verbose, EventKeywords.None);
        bool isLoggerEnabled = logger.IsEnabled(LogLevel.Debug);

        if (isLoggerEnabled)
        {
            if (textEncoding != null)
            {
                ClientModelLogMessages.ResponseContentText(logger, requestId, textEncoding.GetString(content));
            }
            else
            {
                ClientModelLogMessages.ResponseContent(logger, requestId, content);
            }
        }
        else if (isEventSourceEnabled)
        {
            if (textEncoding != null)
            {
                ClientModelEventSource.Log.ResponseContentText(requestId, textEncoding.GetString(content));
            }
            else
            {
                ClientModelEventSource.Log.ResponseContent(requestId, content);
            }
        }
    }

    public static void LogResponseContentBlock(ILogger logger, string requestId, int blockNumber, byte[] content, Encoding? textEncoding)
    {
        bool isEventSourceEnabled = ClientModelEventSource.Log.IsEnabled(EventLevel.Verbose, EventKeywords.None);
        bool isLoggerEnabled = logger.IsEnabled(LogLevel.Debug);

        if (isLoggerEnabled)
        {
            if (textEncoding != null)
            {
                ClientModelLogMessages.ResponseContentTextBlock(logger, requestId, blockNumber, textEncoding.GetString(content));
            }
            else
            {
                ClientModelLogMessages.ResponseContentBlock(logger, requestId, blockNumber, content);
            }
        }
        else if (isEventSourceEnabled)
        {
            if (textEncoding != null)
            {
                ClientModelEventSource.Log.ResponseContentTextBlock(requestId, blockNumber, textEncoding.GetString(content));
            }
            else
            {
                ClientModelEventSource.Log.ResponseContentBlock(requestId, blockNumber, content);
            }
        }
    }

    public static void LogErrorResponse(ILogger logger, string requestId, PipelineResponse response, double seconds, PipelineMessageSanitizer sanitizer)
    {
        bool isEventSourceEnabled = ClientModelEventSource.Log.IsEnabled(EventLevel.Warning, EventKeywords.None);
        bool isLoggerEnabled = logger.IsEnabled(LogLevel.Warning);

        if (isLoggerEnabled)
        {
            ClientModelLogMessages.ErrorResponse(logger, requestId, response.Status, response.ReasonPhrase, FormatHeaders(response.Headers, sanitizer), seconds);
        }
        else if (isEventSourceEnabled)
        {
            ClientModelEventSource.Log.ErrorResponse(requestId, response.Status, response.ReasonPhrase, FormatHeaders(response.Headers, sanitizer), seconds);
        }
    }

    public static void LogErrorResponseContent(ILogger logger, string requestId, byte[] content, Encoding? textEncoding)
    {
        bool isEventSourceEnabled = ClientModelEventSource.Log.IsEnabled(EventLevel.Informational, EventKeywords.None);
        bool isLoggerEnabled = logger.IsEnabled(LogLevel.Information);

        if (isLoggerEnabled)
        {
            if (textEncoding != null)
            {
                ClientModelLogMessages.ErrorResponseContentText(logger, requestId, textEncoding.GetString(content));
            }
            else
            {
                ClientModelLogMessages.ErrorResponseContent(logger, requestId, content);
            }
        }
        else if (isEventSourceEnabled)
        {
            if (textEncoding != null)
            {
                ClientModelEventSource.Log.ErrorResponseContentText(requestId, textEncoding.GetString(content));
            }
            else
            {
                ClientModelEventSource.Log.ErrorResponseContent(requestId, content);
            }
        }
    }

    public static void LogErrorResponseContentBlock(ILogger logger, string requestId, int blockNumber, byte[] content, Encoding? textEncoding)
    {
        bool isEventSourceEnabled = ClientModelEventSource.Log.IsEnabled(EventLevel.Informational, EventKeywords.None);
        bool isLoggerEnabled = logger.IsEnabled(LogLevel.Information);

        if (isLoggerEnabled)
        {
            if (textEncoding != null)
            {
                ClientModelLogMessages.ErrorResponseContentTextBlock(logger, requestId, blockNumber, textEncoding.GetString(content));
            }
            else
            {
                ClientModelLogMessages.ErrorResponseContentBlock(logger, requestId, blockNumber, content);
            }
        }
        else if (isEventSourceEnabled)
        {
            if (textEncoding != null)
            {
                ClientModelEventSource.Log.ErrorResponseContentTextBlock(requestId, blockNumber, textEncoding.GetString(content));
            }
            else
            {
                ClientModelEventSource.Log.ErrorResponseContentBlock(requestId, blockNumber, content);
            }
        }
    }

    public static void LogRequestRetrying(ILogger logger, string requestId, int retryCount, double seconds)
    {
        bool isEventSourceEnabled = ClientModelEventSource.Log.IsEnabled(EventLevel.Informational, EventKeywords.None);
        bool isLoggerEnabled = logger.IsEnabled(LogLevel.Information);

        if (isLoggerEnabled)
        {
            ClientModelLogMessages.RequestRetrying(logger, requestId, retryCount, seconds);
        }
        else if (isEventSourceEnabled)
        {
            ClientModelEventSource.Log.RequestRetrying(requestId, retryCount, seconds);
        }
    }

    public static void LogResponseDelay(ILogger logger, string requestId, double seconds)
    {
        bool isEventSourceEnabled = ClientModelEventSource.Log.IsEnabled(EventLevel.Informational, EventKeywords.None);
        bool isLoggerEnabled = logger.IsEnabled(LogLevel.Information);

        if (isLoggerEnabled)
        {
            ClientModelLogMessages.ResponseDelay(logger, requestId, seconds);
        }
        else if (isEventSourceEnabled)
        {
            ClientModelEventSource.Log.ResponseDelay(requestId, seconds);
        }
    }

    public static void LogExceptionResponse(ILogger logger, string requestId, Exception exception)
    {
        bool isEventSourceEnabled = ClientModelEventSource.Log.IsEnabled(EventLevel.Informational, EventKeywords.None);
        bool isLoggerEnabled = logger.IsEnabled(LogLevel.Information);

        if (isLoggerEnabled)
        {
            ClientModelLogMessages.ExceptionResponse(logger, requestId, exception);
        }
        else if (isEventSourceEnabled)
        {
            ClientModelEventSource.Log.ExceptionResponse(requestId, exception.ToString());
        }
    }

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
}
