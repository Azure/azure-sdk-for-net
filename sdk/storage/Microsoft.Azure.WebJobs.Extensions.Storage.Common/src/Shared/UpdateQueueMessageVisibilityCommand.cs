// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Timers;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners
{
    internal class UpdateQueueMessageVisibilityCommand : ITaskSeriesCommand
    {
        private readonly QueueClient _queue;
        private readonly QueueMessage _message;
        private readonly TimeSpan _visibilityTimeout;
        private readonly IDelayStrategy _speedupStrategy;
        private readonly Action<UpdateReceipt> _onUpdateReceipt;

        public UpdateQueueMessageVisibilityCommand(QueueClient queue, QueueMessage message,
            TimeSpan visibilityTimeout, IDelayStrategy speedupStrategy, Action<UpdateReceipt> onUpdateReceipt)
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
            _onUpdateReceipt = onUpdateReceipt;
        }

        public async Task<TaskSeriesCommandResult> ExecuteAsync(CancellationToken cancellationToken)
        {
            TimeSpan delay;

            try
            {
                UpdateReceipt updateReceipt = await _queue.UpdateMessageAsync(_message.MessageId, _message.PopReceipt, visibilityTimeout: _visibilityTimeout, cancellationToken: cancellationToken).ConfigureAwait(false);
                _onUpdateReceipt?.Invoke(updateReceipt);
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

            return new TaskSeriesCommandResult(wait: Task.Delay(delay, cancellationToken));
        }
    }
}
