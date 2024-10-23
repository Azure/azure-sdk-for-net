// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace System.ClientModel;

internal class ClientLogging
{
    private readonly LoggingOptions _loggingOptions;
    private readonly LoggingHandler _loggingHandler;

    public ClientLogging(PipelineMessageSanitizer sanitizer, LoggingOptions? options = default)
    {
        _loggingOptions = options ?? new LoggingOptions();

        ILogger logger = _loggingOptions.LoggerFactory.CreateLogger<ClientLogging>();
        _loggingHandler = new LoggingHandler(logger, sanitizer);
    }

    public void LogRetry(PipelineMessage message, double secondsElapsed)
    {
        _loggingHandler.LogRequestRetrying(message.LoggingCorrelationId, message.RetryCount, secondsElapsed);
    }
}
