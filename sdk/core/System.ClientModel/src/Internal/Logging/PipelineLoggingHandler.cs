// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace System.ClientModel.Internal;

/// <summary>
/// An abstraction over ILogger and EventSource that handles logging for any components or policy in the pipeline
/// that writes logs. It determines whether logs should be written to EventSource or ILogger upon creation, and
/// then writes logs appropriately.
/// </summary>
/// <remarks>
/// ClientModelLogMessages and ClientModelEventSource should never be used directly outside of this class.
/// </remarks>
internal class PipelineLoggingHandler
{
    private readonly ILogger _logger;
    private readonly PipelineMessageSanitizer _sanitizer;
    private readonly ClientModelLogMessages? _logMessages;
    private readonly bool _useILogger;

    public PipelineLoggingHandler(ILogger? logger, PipelineMessageSanitizer sanitizer)
    {
        _logger = logger ?? NullLogger.Instance;
        _sanitizer = sanitizer;
        _useILogger = logger is not NullLogger;
        if (_useILogger)
        {
            _logMessages = new ClientModelLogMessages(_logger, _sanitizer);
        }
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

    public void LogRequest(PipelineRequest request, string requestId, string? assemblyName)
    {
        if (_useILogger)
        {
            _logMessages?.Request(requestId, request, assemblyName);
        }
        else
        {
            ClientModelEventSource.Log.Request(requestId, request, assemblyName, _sanitizer);
        }
    }

    public void LogRequestContent(string requestId, byte[] content, Encoding? textEncoding)
    {
        if (_useILogger)
        {
            _logMessages?.RequestContent(requestId, content, textEncoding);
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
            _logMessages?.Response(requestId, response, seconds);
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
            _logMessages?.ResponseContent(requestId, content, textEncoding);
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
            _logMessages?.ResponseContentBlock(requestId, blockNumber, content, textEncoding);
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
            _logMessages?.ErrorResponse(requestId, response, seconds);
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
            _logMessages?.ErrorResponseContent(requestId, content, textEncoding);
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
            _logMessages?.ErrorResponseContentBlock(requestId, blockNumber, content, textEncoding);
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
            _logMessages?.RequestRetrying(requestId, retryCount, seconds);
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
            _logMessages?.ResponseDelay(requestId, seconds);
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
            _logMessages?.ExceptionResponse(requestId, exception);
        }
        else if (isEventSourceEnabled)
        {
            ClientModelEventSource.Log.ExceptionResponse(requestId, exception.ToString());
        }
    }
}
