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
        /// <param name="queue">The QueueClient to use for metrics polling.</param>
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
                    if (message != null && message.InsertedOn.HasValue)
                    {
                        queueTime = DateTime.UtcNow.Subtract(message.InsertedOn.Value.DateTime);
                    }
                    // If peek returns null (e.g. message encoding mismatch where
                    // MessageDecodingFailed handler silently filters out un-decodable
                    // messages), we preserve ApproximateMessagesCount as the queue length.
                    // Trade-off: ApproximateMessagesCount may briefly be stale after
                    // a queue is fully drained, causing a transient over-count for one
                    // poll cycle (~10s). This is preferable to the previous behavior
                    // which permanently reported QueueLength=0 when messages existed
                    // but couldn't be peeked.
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
