// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Timers;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Azure;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Timers;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;

namespace Microsoft.Azure.WebJobs.Host.Queues.Listeners
{
    internal class UpdateQueueMessageVisibilityCommand : ITaskSeriesCommand
    {
        private readonly QueueClient _queue;
        private readonly QueueMessage _message;
        private readonly TimeSpan _visibilityTimeout;
        private readonly IDelayStrategy _speedupStrategy;

        public UpdateQueueMessageVisibilityCommand(QueueClient queue, QueueMessage message,
            TimeSpan visibilityTimeout, IDelayStrategy speedupStrategy)
        {
            if (queue == null)
            {
                throw new ArgumentNullException(nameof(queue));
            }

            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (speedupStrategy == null)
            {
                throw new ArgumentNullException(nameof(speedupStrategy));
            }

            _queue = queue;
            _message = message;
            _visibilityTimeout = visibilityTimeout;
            _speedupStrategy = speedupStrategy;
        }

        public async Task<TaskSeriesCommandResult> ExecuteAsync(CancellationToken cancellationToken)
        {
            TimeSpan delay;

            try
            {
                await _queue.UpdateMessageAsync(_message.MessageId, _message.PopReceipt, visibilityTimeout: _visibilityTimeout, cancellationToken: cancellationToken).ConfigureAwait(false);
                // The next execution should occur after a normal delay.
                delay = _speedupStrategy.GetNextDelay(executionSucceeded: true);
            }
            catch (RequestFailedException exception)
            {
                // For consistency, the exceptions handled here should match PollQueueCommand.DeleteMessageAsync.
                if (exception.IsServerSideError())
                {
                    // The next execution should occur more quickly (try to update the visibility before it expires).
                    delay = _speedupStrategy.GetNextDelay(executionSucceeded: false);
                }
                if (exception.IsBadRequestPopReceiptMismatch())
                {
                    // There's no point to executing again. Once the pop receipt doesn't match, we've permanently lost
                    // ownership.
                    delay = Timeout.InfiniteTimeSpan;
                }
                else if (exception.IsNotFoundMessageOrQueueNotFound() ||
                    exception.IsConflictQueueBeingDeletedOrDisabled())
                {
                    // There's no point to executing again. Once the message or queue is deleted, we've permanently lost
                    // ownership.
                    // For queue disabled, in theory it's possible the queue could be re-enabled, but the scenarios here
                    // are currently unclear.
                    delay = Timeout.InfiniteTimeSpan;
                }
                else
                {
                    throw;
                }
            }

            return new TaskSeriesCommandResult(wait: Task.Delay(delay));
        }
    }
}
