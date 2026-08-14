// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners
{
    /// <summary>
    /// Provides QueueTriggerMetrics from a specific queue entity.
    /// </summary>
    internal class QueueMetricsProvider
    {
        private readonly string _functionId;
        private readonly QueueClient _queue;
        private readonly ILogger _logger;

        /// <summary>
        /// Instantiates a QueueMetricsProvider.
        /// </summary>
        /// <param name="functionId">The function id to make scale decisions for.</param>
        /// <param name="queue">
        /// The QueueClient to use for metrics polling. Its PeekMessages must not be subject to
        /// decode filtering, otherwise an empty peek is ambiguous between "nothing is visible" and
        /// "messages are present but undecodable" - two opposite scaling decisions. Use a
        /// <see cref="QueueMessageEncoding.None"/> client, or one whose producer and consumer
        /// always agree on the encoding.
        /// </param>
        /// <param name="loggerFactory">Used to create an ILogger instance.</param>
        public QueueMetricsProvider(string functionId, QueueClient queue, ILoggerFactory loggerFactory)
        {
            _functionId = functionId;
            _queue = queue;
            _logger = loggerFactory.CreateLogger<QueueMetricsProvider>();
        }

        /// <summary>
        /// Retrieve queue length from the specified queue entity.
        /// </summary>
        /// <returns>The queue length from the associated queue entity.</returns>
        public async Task<int> GetQueueLengthAsync()
        {
            try
            {
                QueueTriggerMetrics queueMetrics = await GetMetricsAsync().ConfigureAwait(false);
                return queueMetrics.QueueLength;
            }
            catch (RequestFailedException ex)
            {
                if (ex.IsNotFoundQueueNotFound() ||
                    ex.IsConflictQueueBeingDeletedOrDisabled() ||
                    ex.IsServerSideError())
                {
                    // ignore transient errors, and return default metrics
                    // E.g. if the queue doesn't exist, we'll return a zero queue length
                    // and scale in
                    _logger.LogFunctionScaleWarning("Error querying for queue scale status", _functionId, ex);
                }
            }
            catch (Exception ex)
            {
                _logger.LogFunctionScaleWarning("Fatal error querying for queue scale status", _functionId, ex);
            }

            return 0;
        }

        /// <summary>
        /// Retrieves metrics from the queue entity.
        /// </summary>
        /// <returns>Returns a <see cref="QueueTriggerMetrics"/> object.</returns>
        public async Task<QueueTriggerMetrics> GetMetricsAsync()
        {
            int queueLength = 0;
            TimeSpan queueTime = TimeSpan.Zero;

            try
            {
                QueueProperties queueProperties = await _queue.GetPropertiesAsync().ConfigureAwait(false);
                queueLength = queueProperties.ApproximateMessagesCount;

                if (queueLength > 0)
                {
                    PeekedMessage message = (await _queue.PeekMessagesAsync(1).ConfigureAwait(false)).Value.FirstOrDefault();
                    if (message == null)
                    {
                        // Nothing is visible even though ApproximateMessagesCount is non-zero: the messages
                        // are scheduled with a visibility delay, are in-flight on another worker, or the count
                        // is stale after a drain. None of those can be dequeued now, so allocating workers for
                        // them cannot reduce the backlog. Undecodable messages cannot reach this branch given
                        // the encoding requirement on the client - see the constructor remarks.
                        queueLength = 0;
                    }
                    else if (message.InsertedOn.HasValue)
                    {
                        queueTime = DateTime.UtcNow.Subtract(message.InsertedOn.Value.DateTime);
                    }
                }
            }
            catch (RequestFailedException ex)
            {
                if (ex.IsNotFoundQueueNotFound() ||
                    ex.IsConflictQueueBeingDeletedOrDisabled() ||
                    ex.IsServerSideError())
                {
                    // ignore transient errors, and return default metrics
                    // E.g. if the queue doesn't exist, we'll return a zero queue length
                    // and scale in
                    _logger.LogFunctionScaleWarning("Error querying for queue scale status", _functionId, ex);
                }
            }
            catch (Exception ex)
            {
                _logger.LogFunctionScaleWarning("Fatal error querying for queue scale status", _functionId, ex);
            }

            return new QueueTriggerMetrics
            {
                QueueLength = queueLength,
                QueueTime = queueTime,
                Timestamp = DateTime.UtcNow
            };
        }
    }
}
