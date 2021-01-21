// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners
{
    internal sealed partial class QueueListener
    {
        private static class Logger
        {
            private static readonly Action<ILogger, string, string, string, int, long, Exception> _getMessages =
                LoggerMessage.Define<string, string, string, int, long>(LogLevel.Debug, new EventId(1, nameof(GetMessages)),
                    "Poll for function '{functionName}' on queue '{queueName}' with ClientRequestId '{clientRequestId}' found {messageCount} messages in {pollLatency} ms.");

            private static readonly Action<ILogger, string, double, string, Exception> _backoffDelay =
                LoggerMessage.Define<string, double, string>(LogLevel.Debug, new EventId(2, nameof(BackoffDelay)),
                    "Function '{functionName}' will wait {pollDelay} ms before polling queue '{queueName}'.");

            private static readonly Action<ILogger, string, string, string, string, long, string, Exception> _handlingStorageException =
               LoggerMessage.Define<string, string, string, string, long, string>(LogLevel.Debug, new EventId(3, nameof(HandlingStorageException)),
                   "Poll for function '{functionName}' on queue '{queueName}' with ClientRequestId '{clientRequestId}' threw a {exceptionType} in {pollLatency} ms. This exception is handled and queue polling will resume after a delay. Message: '{exceptionMessage}'");

            public static void GetMessages(ILogger logger, string functionName, string queueName, string clientRequestId, int messageCount, long pollLatency) =>
                _getMessages(logger, functionName, queueName, clientRequestId, messageCount, pollLatency, null);

            public static void BackoffDelay(ILogger logger, string functionName, string queueName, double pollDelay) =>
                _backoffDelay(logger, functionName, pollDelay, queueName, null);

            public static void HandlingStorageException(ILogger logger, string functionName, string queueName, string clientRequestId, long pollLatency, Exception exception) =>
                _handlingStorageException(logger, functionName, queueName, clientRequestId, exception.GetType().Name, pollLatency, exception.Message, null);
        }
    }
}
