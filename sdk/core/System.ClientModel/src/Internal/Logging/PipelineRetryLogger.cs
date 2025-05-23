// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Microsoft.Extensions.Logging;

namespace System.ClientModel.Internal;

internal partial class PipelineRetryLogger
{
    private readonly ILogger<ClientRetryPolicy>? _logger;

    public PipelineRetryLogger(ILoggerFactory? loggerFactory)
    {
        _logger = loggerFactory?.CreateLogger<ClientRetryPolicy>() ?? null;
    }

    public void LogRequestRetrying(string? requestId, int retryNumber, double seconds)
    {
        if (_logger is not null)
        {
            RequestRetrying(_logger, requestId, retryNumber, seconds);
        }
        else
        {
            ClientModelEventSource.Log.RequestRetrying(requestId, retryNumber, seconds);
        }
    }

    [LoggerMessage(LoggingEventIds.RequestRetryingEvent, LogLevel.Information, "Request [{requestId}] attempt number {retryNumber} took {seconds:00.0}s", EventName = "RequestRetrying")]
    private static partial void RequestRetrying(ILogger logger, string? requestId, int retryNumber, double seconds);
}
