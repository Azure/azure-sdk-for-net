// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Host.Queues
{
#if STORAGE_WEBJOBS_PUBLIC_QUEUE_PROCESSOR
    /// <summary>
    /// This class defines a strategy used for processing queue messages.
    /// </summary>
    /// <remarks>
    /// Custom <see cref="QueueProcessor"/> implementations can be registered by implementing
    /// a custom <see cref="IQueueProcessorFactory"/>.
    /// </remarks>
    public class QueueProcessor
#else
    internal class QueueProcessor
#endif
    {
        private readonly QueueClient _queue;
        private readonly QueueClient _poisonQueue;
        private readonly ILogger _logger;

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="queueProcessorOptions">The options.</param>
        internal protected QueueProcessor(QueueProcessorOptions queueProcessorOptions)
        {
            if (queueProcessorOptions == null)
            {
                throw new ArgumentNullException(nameof(queueProcessorOptions));
            }

            _queue = queueProcessorOptions.Queue;
            _poisonQueue = queueProcessorOptions.PoisonQueue;
            _logger = queueProcessorOptions.Logger;

            QueuesOptions = queueProcessorOptions.Options;
        }

        /// <summary>
        /// Event raised when a message is added to the poison queue.
        /// </summary>
        public event EventHandler<PoisonMessageEventArgs> MessageAddedToPoisonQueue;

        internal QueuesOptions QueuesOptions { get; private set; }

        /// <summary>
        /// This method is called when there is a new message to process, before the job function is invoked.
        /// This allows any preprocessing to take place on the message before processing begins.
        /// </summary>
        /// <param name="message">The message to process.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use</param>
        /// <returns>True if the message processing should continue, false otherwise.</returns>
        internal protected virtual async Task<bool> BeginProcessingMessageAsync(QueueMessage message, CancellationToken cancellationToken)
        {
            if (message.DequeueCount > QueuesOptions.MaxDequeueCount)
            {
                await HandlePoisonMessageAsync(message, cancellationToken).ConfigureAwait(false);
                return await Task.FromResult<bool>(false).ConfigureAwait(false);
            }
            return await Task.FromResult<bool>(true).ConfigureAwait(false);
        }

        /// <summary>
        /// This method completes processing of the specified message, after the job function has been invoked.
        /// </summary>
        /// <remarks>
        /// If the message was processed successfully, the message should be deleted. If message processing failed, the
        /// message should be release back to the queue, or if the maximum dequeue count has been exceeded, the message
        /// should be moved to the poison queue (if poison queue handling is configured for the queue).
        /// </remarks>
        /// <param name="message">The message to complete processing for.</param>
        /// <param name="result">The <see cref="FunctionResult"/> from the job invocation.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns></returns>
        internal protected virtual async Task CompleteProcessingMessageAsync(QueueMessage message, FunctionResult result, CancellationToken cancellationToken)
        {
            if (result.Succeeded)
            {
                await DeleteMessageAsync(message, cancellationToken).ConfigureAwait(false);
            }
            else if (_poisonQueue != null)
            {
                if (message.DequeueCount >= QueuesOptions.MaxDequeueCount)
                {
                    await HandlePoisonMessageAsync(message, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    await ReleaseMessageAsync(message, result, QueuesOptions.VisibilityTimeout, cancellationToken).ConfigureAwait(false);
                }
            }
            else
            {
                // For queues without a corresponding poison queue, leave the message invisible when processing
                // fails to prevent a fast infinite loop.
                // Specifically, don't call ReleaseMessage(message)
            }
        }

        private async Task HandlePoisonMessageAsync(QueueMessage message, CancellationToken cancellationToken)
        {
            if (_poisonQueue != null)
            {
                await CopyMessageToPoisonQueueAsync(message, _poisonQueue, cancellationToken).ConfigureAwait(false);
                await DeleteMessageAsync(message, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Moves the specified message to the poison queue.
        /// </summary>
        /// <param name="message">The poison message.</param>
        /// <param name="poisonQueue">The poison queue to copy the message to.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns></returns>
        protected virtual async Task CopyMessageToPoisonQueueAsync(QueueMessage message, QueueClient poisonQueue, CancellationToken cancellationToken)
        {
            string msg = string.Format(CultureInfo.InvariantCulture, "Message has reached MaxDequeueCount of {0}. Moving message to queue '{1}'.", QueuesOptions.MaxDequeueCount, poisonQueue.Name);
            _logger?.LogWarning(msg);

            await poisonQueue.AddMessageAndCreateIfNotExistsAsync(message.Body, cancellationToken).ConfigureAwait(false);

            var eventArgs = new PoisonMessageEventArgs(message, poisonQueue);
            OnMessageAddedToPoisonQueue(eventArgs);
        }

        /// <summary>
        /// Release the specified failed message back to the queue.
        /// </summary>
        /// <param name="message">The message to release</param>
        /// <param name="result">The <see cref="FunctionResult"/> from the job invocation.</param>
        /// <param name="visibilityTimeout">The visibility timeout to set for the message.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns></returns>
        protected virtual async Task ReleaseMessageAsync(QueueMessage message, FunctionResult result, TimeSpan visibilityTimeout, CancellationToken cancellationToken)
        {
            try
            {
                // We couldn't process the message. Let someone else try.
                await _queue.UpdateMessageAsync(message.MessageId, message.PopReceipt, visibilityTimeout: visibilityTimeout, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException exception)
            {
                if (exception.IsBadRequestPopReceiptMismatch())
                {
                    // Someone else already took over the message; no need to do anything.
                    return;
                }
                else if (exception.IsNotFoundMessageOrQueueNotFound() ||
                         exception.IsConflictQueueBeingDeletedOrDisabled())
                {
                    // The message or queue is gone, or the queue is down; no need to release the message.
                    return;
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Delete the specified message.
        /// </summary>
        /// <param name="message">The message to delete.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns></returns>
        protected virtual async Task DeleteMessageAsync(QueueMessage message, CancellationToken cancellationToken)
        {
            try
            {
                await _queue.DeleteMessageAsync(message.MessageId, message.PopReceipt, cancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException exception)
            {
                // For consistency, the exceptions handled here should match UpdateQueueMessageVisibilityCommand.
                if (exception.IsBadRequestPopReceiptMismatch())
                {
                    // If someone else took over the message; let them delete it.
                    string msg = $"Unable to delete queue message '{message.MessageId}' because the {nameof(QueueMessage.PopReceipt)} did not match. This could indicate that the function has modified the message and may be expected.";
                    _logger.LogDebug(msg);
                    return;
                }
                else if (exception.IsNotFoundMessageOrQueueNotFound())
                {
                    string msg = $"Unable to delete queue message '{message.MessageId}' because either the message or the queue '{_queue.Name}' was not found.";
                    _logger.LogDebug(msg);
                }
                else if (exception.IsConflictQueueBeingDeletedOrDisabled())
                {
                    // The message or queue is gone, or the queue is down; no need to delete the message.
                    string msg = $"Unable to delete queue message '{message.MessageId}' because the queue `{_queue.Name}` is either disabled or being deleted.";
                    _logger.LogDebug(msg);
                    return;
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Called to raise the MessageAddedToPoisonQueue event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected internal virtual void OnMessageAddedToPoisonQueue(PoisonMessageEventArgs e)
        {
            MessageAddedToPoisonQueue?.Invoke(this, e);
        }
    }
}
