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
    private const string _assemblyName = "System.ClientModel";

    private readonly ILogger _logger;
    private readonly PipelineMessageSanitizer _sanitizer;
    private readonly bool _useILogger;

    public LoggingHandler(ILogger logger, PipelineMessageSanitizer sanitizer)
    {
        _logger = logger;
        _sanitizer = sanitizer;
        _useILogger = logger is not NullLogger;
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
        return _useILogger ? _logger.IsEnabled(logLevel) : ClientModelEventSource.Log.IsEnabled(eventLevel, EventKeywords.None);
    }

    public void LogRequest(string requestId, PipelineRequest request)
    {
        if (_useILogger)
        {
            ClientModelLogMessages.Request(_logger, requestId, request, _assemblyName, _sanitizer);
        }
        else
        {
            ClientModelEventSource.Log.Request(requestId, request, _assemblyName, _sanitizer);
        }
    }

    public void LogRequestContent(string requestId, byte[] content, Encoding? textEncoding)
    {
        if (_useILogger)
        {
            ClientModelLogMessages.RequestContent(_logger, requestId, content, textEncoding);
        }
        else
        {
            ClientModelEventSource.Log.RequestContent(requestId, content, textEncoding);
        }
    }

    public void LogResponse(string requestId, PipelineResponse response, double seconds)
    {
        if (_useILogger)
        {
            ClientModelLogMessages.Response(_logger, requestId, response, seconds, _sanitizer);
        }
        else
        {
            ClientModelEventSource.Log.Response(requestId, response, seconds, _sanitizer);
        }
    }

    public void LogResponseContent(string requestId, byte[] content, Encoding? textEncoding)
    {
        if (_useILogger)
        {
            ClientModelLogMessages.ResponseContent(_logger, requestId, content, textEncoding);
        }
        else
        {
            ClientModelEventSource.Log.ResponseContent(requestId, content, textEncoding);
        }
    }

    public void LogResponseContentBlock(string requestId, int blockNumber, byte[] content, Encoding? textEncoding)
    {
        if (_useILogger)
        {
            ClientModelLogMessages.ResponseContentBlock(_logger, requestId, blockNumber, content, textEncoding);
        }
        else
        {
            ClientModelEventSource.Log.ResponseContentBlock(requestId, blockNumber, content, textEncoding);
        }
    }

    public void LogErrorResponse(string requestId, PipelineResponse response, double seconds)
    {
        if (_useILogger)
        {
            ClientModelLogMessages.ErrorResponse(_logger, requestId, response, seconds, _sanitizer);
        }
        else
        {
            ClientModelEventSource.Log.ErrorResponse(requestId, response, seconds, _sanitizer);
        }
    }

    public void LogErrorResponseContent(string requestId, byte[] content, Encoding? textEncoding)
    {
        if (_useILogger)
        {
            ClientModelLogMessages.ErrorResponseContent(_logger, requestId, content, textEncoding);
        }
        else
        {
            ClientModelEventSource.Log.ErrorResponseContent(requestId, content, textEncoding);
        }
    }

    public void LogErrorResponseContentBlock(string requestId, int blockNumber, byte[] content, Encoding? textEncoding)
    {
        if (_useILogger)
        {
            ClientModelLogMessages.ErrorResponseContentBlock(_logger, requestId, blockNumber, content, textEncoding);
        }
        else
        {
            ClientModelEventSource.Log.ErrorResponseContentBlock(requestId, blockNumber, content, textEncoding);
        }
    }

    public void LogRequestRetrying(string requestId, int retryCount, double seconds)
    {
        if (_useILogger)
        {
            ClientModelLogMessages.RequestRetrying(_logger, requestId, retryCount, seconds);
        }
        else
        {
            ClientModelEventSource.Log.RequestRetrying(requestId, retryCount, seconds);
        }
    }

    public void LogResponseDelay(string requestId, double seconds)
    {
        if (_useILogger)
        {
            ClientModelLogMessages.ResponseDelay(_logger, requestId, seconds);
        }
        else
        {
            ClientModelEventSource.Log.ResponseDelay(requestId, seconds);
        }
    }

    public void LogExceptionResponse(string requestId, Exception exception)
    {
        bool isEventSourceEnabled = ClientModelEventSource.Log.IsEnabled(EventLevel.Informational, EventKeywords.None);
        bool isLoggerEnabled = _logger.IsEnabled(LogLevel.Information);

        if (_useILogger && isLoggerEnabled)
        {
            ClientModelLogMessages.ExceptionResponse(_logger, requestId, exception);
        }
        else if (isEventSourceEnabled)
        {
            ClientModelEventSource.Log.ExceptionResponse(requestId, exception.ToString());
        }
    }
}
