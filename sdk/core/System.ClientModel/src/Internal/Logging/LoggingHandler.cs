// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace System.ClientModel.Internal;

internal class LoggingHandler
{
    private readonly ILogger _logger;
    private readonly PipelineMessageSanitizer _sanitizer;
    private readonly ClientModelLogMessages _logMessages;
    private readonly bool _useILogger;

    public LoggingHandler(ILogger logger, PipelineMessageSanitizer sanitizer)
    {
        _logger = logger;
        _sanitizer = sanitizer;
        _logMessages = new ClientModelLogMessages(logger);
        _useILogger = logger is not NullLogger;
    }

    public void LogRequest(PipelineRequest request, string requestId, string? assemblyName)
    {
        if (_useILogger)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logMessages.Request(requestId, request.Method, _sanitizer.SanitizeUrl(request.Uri!.AbsoluteUri), FormatHeaders(request.Headers), assemblyName);
            }
        }
        else
        {
            if (ClientModelEventSource.Log.IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                ClientModelEventSource.Log.Request(requestId, request.Method, _sanitizer.SanitizeUrl(request.Uri!.AbsoluteUri), FormatHeaders(request.Headers), assemblyName);
            }
        }
    }

    public void LogRequestContent(string requestId, byte[] content, Encoding? textEncoding)
    {
        if (_useILogger)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                if (textEncoding != null)
                {
                    _logMessages.RequestContentText(requestId, textEncoding.GetString(content));
                }
                else
                {
                    _logMessages.RequestContent(requestId, content);
                }
            }
        }
        else
        {
            if (ClientModelEventSource.Log.IsEnabled(EventLevel.Verbose, EventKeywords.None))
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
    }

    public void LogResponse(string requestId, PipelineResponse response, double seconds)
    {
        if (_useILogger)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logMessages.Response(requestId, response.Status, response.ReasonPhrase, FormatHeaders(response.Headers), seconds);
            }
        }
        else
        {
            if (ClientModelEventSource.Log.IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                ClientModelEventSource.Log.Response(requestId, response.Status, response.ReasonPhrase, FormatHeaders(response.Headers), seconds);
            }
        }
    }

    public void LogResponseContent(string requestId, byte[] content, Encoding? textEncoding)
    {
        if (_useILogger)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                if (textEncoding != null)
                {
                    _logMessages.ResponseContentText(requestId, textEncoding.GetString(content));
                }
                else
                {
                    _logMessages.ResponseContent(requestId, content);
                }
            }
        }
        else
        {
            if (ClientModelEventSource.Log.IsEnabled(EventLevel.Verbose, EventKeywords.None))
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
    }

    public void LogResponseContentBlock(string requestId, int blockNumber, byte[] content, Encoding? textEncoding)
    {
        if (_useILogger)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                if (textEncoding != null)
                {
                    _logMessages.ResponseContentTextBlock(requestId, blockNumber, textEncoding.GetString(content));
                }
                else
                {
                    _logMessages.ResponseContentBlock(requestId, blockNumber, content);
                }
            }
        }
        else
        {
            if (ClientModelEventSource.Log.IsEnabled(EventLevel.Verbose, EventKeywords.None))
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
    }

    public void LogErrorResponse(string requestId, PipelineResponse response, double seconds)
    {
        if (_useILogger)
        {
            if (_logger.IsEnabled(LogLevel.Warning))
            {
                _logMessages.ErrorResponse(requestId, response.Status, response.ReasonPhrase, FormatHeaders(response.Headers), seconds);
            }
        }
        else
        {
            if (ClientModelEventSource.Log.IsEnabled(EventLevel.Warning, EventKeywords.None))
            {
                ClientModelEventSource.Log.ErrorResponse(requestId, response.Status, response.ReasonPhrase, FormatHeaders(response.Headers), seconds);
            }
        }
    }

    public void LogErrorResponseContent(string requestId, byte[] content, Encoding? textEncoding)
    {
        if (_useILogger)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                if (textEncoding != null)
                {
                    _logMessages.ErrorResponseContentText(requestId, textEncoding.GetString(content));
                }
                else
                {
                    _logMessages.ErrorResponseContent(requestId, content);
                }
            }
        }
        else
        {
            if (ClientModelEventSource.Log.IsEnabled(EventLevel.Informational, EventKeywords.None))
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
    }

    public void LogErrorResponseContentBlock(string requestId, int blockNumber, byte[] content, Encoding? textEncoding)
    {
        if (_useILogger)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                if (textEncoding != null)
                {
                    _logMessages.ErrorResponseContentTextBlock(requestId, blockNumber, textEncoding.GetString(content));
                }
                else
                {
                    _logMessages.ErrorResponseContentBlock(requestId, blockNumber, content);
                }
            }
        }
        else
        {
            if (ClientModelEventSource.Log.IsEnabled(EventLevel.Informational, EventKeywords.None))
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
    }

    public void LogRequestRetrying(string requestId, int retryCount, double seconds)
    {
        if (_useILogger)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logMessages.RequestRetrying(requestId, retryCount, seconds);
            }
        }
        else
        {
            if (ClientModelEventSource.Log.IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                ClientModelEventSource.Log.RequestRetrying(requestId, retryCount, seconds);
            }
        }
    }

    public void LogResponseDelay(string requestId, double seconds)
    {
        if (_useILogger)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logMessages.ResponseDelay(requestId, seconds);
            }
        }
        else
        {
            if (ClientModelEventSource.Log.IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                {
                    ClientModelEventSource.Log.ResponseDelay(requestId, seconds);
                }
            }
        }
    }

    public void LogExceptionResponse(string requestId, Exception exception)
    {
        bool isEventSourceEnabled = ClientModelEventSource.Log.IsEnabled(EventLevel.Informational, EventKeywords.None);
        bool isLoggerEnabled = _logger.IsEnabled(LogLevel.Information);

        if (_useILogger && isLoggerEnabled)
        {
            _logMessages.ExceptionResponse(requestId, exception);
        }
        else if (isEventSourceEnabled)
        {
            ClientModelEventSource.Log.ExceptionResponse(requestId, exception.ToString());
        }
    }

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
}
