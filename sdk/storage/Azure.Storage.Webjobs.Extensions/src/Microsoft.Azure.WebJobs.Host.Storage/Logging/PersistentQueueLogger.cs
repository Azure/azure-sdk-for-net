// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Loggers;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace WebJobs.Host.Storage.Logging
{
    internal class PersistentQueueLogger : IHostInstanceLogger, IFunctionInstanceLogger
    {
        private readonly IPersistentQueueWriter<PersistentQueueMessage> _queueWriter;

        public PersistentQueueLogger(IPersistentQueueWriter<PersistentQueueMessage> queueWriter)
        {
            if (queueWriter == null)
            {
                throw new ArgumentNullException("queueWriter");
            }

            _queueWriter = queueWriter;
        }

        public Task LogHostStartedAsync(HostStartedMessage message, CancellationToken cancellationToken)
        {
            return _queueWriter.EnqueueAsync(message, cancellationToken);
        }

        public Task<string> LogFunctionStartedAsync(FunctionStartedMessage message, CancellationToken cancellationToken)
        {
            return _queueWriter.EnqueueAsync(message, cancellationToken);
        }

        public Task LogFunctionCompletedAsync(FunctionCompletedMessage message, CancellationToken cancellationToken)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            return _queueWriter.EnqueueAsync(message, cancellationToken);
        }

        public Task DeleteLogFunctionStartedAsync(string startedMessageId, CancellationToken cancellationToken)
        {
            if (String.IsNullOrEmpty(startedMessageId))
            {
                throw new ArgumentNullException("startedMessageId");
            }

            return _queueWriter.DeleteAsync(startedMessageId, cancellationToken);
        }
    }
}
