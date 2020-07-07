// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Host.Loggers
{
    internal class CompositeFunctionInstanceLogger : IFunctionInstanceLogger
    {
        private readonly IFunctionInstanceLogger[] _loggers;

        public CompositeFunctionInstanceLogger(params IFunctionInstanceLogger[] loggers)
        {
            _loggers = loggers;
        }

        public async Task<string> LogFunctionStartedAsync(FunctionStartedMessage message, CancellationToken cancellationToken)
        {
            string startedMessageId = null;

            foreach (IFunctionInstanceLogger logger in _loggers)
            {
                var messageId = await logger.LogFunctionStartedAsync(message, cancellationToken);
                if (!String.IsNullOrEmpty(messageId))
                {
                    if (String.IsNullOrEmpty(startedMessageId))
                    {
                        startedMessageId = messageId;
                    }
                    else if (startedMessageId != messageId)
                    {
                        throw new NotSupportedException();
                    }
                }
            }

            return startedMessageId;
        }

        public async Task LogFunctionCompletedAsync(FunctionCompletedMessage message, CancellationToken cancellationToken)
        {
            foreach (IFunctionInstanceLogger logger in _loggers)
            {
                await logger.LogFunctionCompletedAsync(message, cancellationToken);
            }
        }

        public async Task DeleteLogFunctionStartedAsync(string startedMessageId, CancellationToken cancellationToken)
        {
            foreach (IFunctionInstanceLogger logger in _loggers)
            {
                await logger.DeleteLogFunctionStartedAsync(startedMessageId, cancellationToken);
            }
        }
    }
}
