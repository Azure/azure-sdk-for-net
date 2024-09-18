// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners
{
    /// <summary>
    /// Provides QueueTriggerMetrics from a specific queue entity.
    /// </summary>
    internal class QueueMetricsProvider
    {
        private readonly QueueClient _queue;
        private readonly ILogger _logger;

        /// <summary>
        /// Instantiates a QueueMetricsProvider.
        /// </summary>
        /// <param name="queue">The QueueClient to use for metrics polling.</param>
        /// <param name="loggerFactory">Used to create an ILogger instance.</param>
        public QueueMetricsProvider(QueueClient queue, ILoggerFactory loggerFactory)
        {
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
                    _logger.LogWarning($"Error querying for queue scale status: {ex.ToString()}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Fatal error querying for queue scale status: {ex.ToString()}");
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
                    if (message != null)
                    {
                        if (message.InsertedOn.HasValue)
                        {
                            queueTime = DateTime.UtcNow.Subtract(message.InsertedOn.Value.DateTime);
                        }
                    }
                    else
                    {
                        // ApproximateMessageCount often returns a stale value,
                        // especially when the queue is empty.
                        queueLength = 0;
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
                    _logger.LogWarning($"Error querying for queue scale status: {ex.ToString()}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Fatal error querying for queue scale status: {ex.ToString()}");
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
