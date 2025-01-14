// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics.Tracing;
using Microsoft.Extensions.Logging;

namespace System.ClientModel.Internal;

internal partial class PipelineTransportLogger
{
    private readonly ILogger<PipelineTransport>? _logger;

    public PipelineTransportLogger(ILoggerFactory? loggerFactory)
    {
        _logger = loggerFactory?.CreateLogger<PipelineTransport>() ?? null;
    }

    #region Delay Response

    public void LogResponseDelay(string requestId, double seconds)
    {
        if (_logger is not null)
        {
            ResponseDelay(_logger, requestId, seconds);
        }
        else
        {
            ClientModelEventSource.Log.ResponseDelay(requestId, seconds);
        }
    }

    [LoggerMessage(LoggingEventIds.ResponseDelayEvent, LogLevel.Warning, "Response [{requestId}] took {seconds:00.0}s", EventName = "ResponseDelay")]
    private static partial void ResponseDelay(ILogger logger, string requestId, double seconds);

    #endregion

    #region Exception Response

    public void LogExceptionResponse(string requestId, Exception exception)
    {
        if (_logger is not null)
        {
            ExceptionResponse(_logger, requestId, exception);
        }
        else if (ClientModelEventSource.Log.IsEnabled(EventLevel.Informational, EventKeywords.None))
        {
            ClientModelEventSource.Log.ExceptionResponse(requestId, exception.ToString());
        }
    }

    [LoggerMessage(LoggingEventIds.ExceptionResponseEvent, LogLevel.Information, "Request [{requestId}] exception occurred.", EventName = "ExceptionResponse")]
    private static partial void ExceptionResponse(ILogger logger, string requestId, Exception exception);

    #endregion
}
