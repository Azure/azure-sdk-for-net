// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners
{
    /// <summary>
    /// Used to retrieve metrics and make scale decisions for Queues.
    /// </summary>
    internal class QueueScaleMonitor : IScaleMonitor<QueueTriggerMetrics>
    {
        private const int NumberOfSamplesToConsider = 5;

        private QueueClient _queue;
        private ILogger _logger;
        private ScaleMonitorDescriptor _scaleMonitorDescriptor;
        private QueueMetricsProvider _queueMetricsProvider;

        // mock testing only
        internal QueueScaleMonitor()
        {
        }

        /// <summary>
        /// Public constructor used to instantiate a QueueScaleMonitor for retrieving metrics and making scale decisions.
        /// </summary>
        /// <param name="functionId">The function name to make scale decisions for.</param>
        /// <param name="queue">The queue client to poll metrics from.</param>
        /// <param name="loggerFactory">Used to create an ILogger instance.</param>
        public QueueScaleMonitor(string functionId, QueueClient queue, ILoggerFactory loggerFactory)
        {
            _queue = queue;
            _logger = loggerFactory.CreateLogger<QueueListener>();
            _scaleMonitorDescriptor = new ScaleMonitorDescriptor($"{functionId}-QueueTrigger-{_queue.Name}".ToLower(CultureInfo.InvariantCulture), functionId);
            _queueMetricsProvider = new QueueMetricsProvider(queue, loggerFactory);
        }

        /// <summary>
        /// Retrieves the descriptor of the QueueScaleMonitor with functionId.
        /// </summary>
        public ScaleMonitorDescriptor Descriptor
        {
            get
            {
                return _scaleMonitorDescriptor;
            }
        }

        async Task<ScaleMetrics> IScaleMonitor.GetMetricsAsync()
        {
            return await GetMetricsAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves metrics from the queueClient.
        /// </summary>
        /// <returns></returns>
        public async Task<QueueTriggerMetrics> GetMetricsAsync()
        {
            return await _queueMetricsProvider.GetMetricsAsync().ConfigureAwait(false);
        }

        ScaleStatus IScaleMonitor.GetScaleStatus(ScaleStatusContext context)
        {
            return GetScaleStatusCore(context.WorkerCount, context.Metrics?.Cast<QueueTriggerMetrics>().ToArray());
        }

        /// <summary>
        /// Using a ScaleStatusContext, return an incremental scale decision.
        /// </summary>
        /// <param name="context">The ScaleStatusContext containing the worker count and trigger metrics to make scale decisions for.</param>
        /// <returns>Returns a vote to scale out, maintain state, or scale in.</returns>
        public ScaleStatus GetScaleStatus(ScaleStatusContext<QueueTriggerMetrics> context)
        {
            return GetScaleStatusCore(context.WorkerCount, context.Metrics?.ToArray());
        }

        private ScaleStatus GetScaleStatusCore(int workerCount, QueueTriggerMetrics[] metrics)
        {
            ScaleStatus status = new ScaleStatus
            {
                Vote = ScaleVote.None
            };

            // verify we have enough samples to make a scale decision.
            if (metrics == null || (metrics.Length < NumberOfSamplesToConsider))
            {
                return status;
            }

            // Maintain a minimum ratio of 1 worker per 1,000 queue messages.
            long latestQueueLength = metrics.Last().QueueLength;
            if (latestQueueLength > workerCount * 1000)
            {
                status.Vote = ScaleVote.ScaleOut;
                _logger.LogInformation($"QueueLength ({latestQueueLength}) > workerCount ({workerCount}) * 1,000");
                _logger.LogInformation($"Length of queue ({_queue.Name}, {latestQueueLength}) is too high relative to the number of instances ({workerCount}).");
                return status;
            }

            // Check to see if the queue has been empty for a while.
            bool queueIsIdle = metrics.All(p => p.QueueLength == 0);
            if (queueIsIdle)
            {
                status.Vote = ScaleVote.ScaleIn;
                _logger.LogInformation($"Queue '{_queue.Name}' is idle");
                return status;
            }

            // Samples are in chronological order. Check for a continuous increase in time or length.
            // If detected, this results in an automatic scale out.
            if (metrics[0].QueueLength > 0)
            {
                bool queueLengthIncreasing =
                IsTrueForLastN(
                    metrics,
                    NumberOfSamplesToConsider,
                    (prev, next) => prev.QueueLength < next.QueueLength);
                if (queueLengthIncreasing)
                {
                    status.Vote = ScaleVote.ScaleOut;
                    _logger.LogInformation($"Queue length is increasing for '{_queue.Name}'");
                    return status;
                }
            }

            if (metrics[0].QueueTime > TimeSpan.Zero && metrics[0].QueueTime < metrics[NumberOfSamplesToConsider - 1].QueueTime)
            {
                bool queueTimeIncreasing =
                    IsTrueForLastN(
                        metrics,
                        NumberOfSamplesToConsider,
                        (prev, next) => prev.QueueTime <= next.QueueTime);
                if (queueTimeIncreasing)
                {
                    status.Vote = ScaleVote.ScaleOut;
                    _logger.LogInformation($"Queue time is increasing for '{_queue.Name}'");
                    return status;
                }
            }

            bool queueLengthDecreasing =
                IsTrueForLastN(
                    metrics,
                    NumberOfSamplesToConsider,
                    (prev, next) => prev.QueueLength > next.QueueLength);
            if (queueLengthDecreasing)
            {
                status.Vote = ScaleVote.ScaleIn;
                _logger.LogInformation($"Queue length is decreasing for '{_queue.Name}'");
                return status;
            }

            bool queueTimeDecreasing = IsTrueForLastN(
                metrics,
                NumberOfSamplesToConsider,
                (prev, next) => prev.QueueTime > next.QueueTime);
            if (queueTimeDecreasing)
            {
                status.Vote = ScaleVote.ScaleIn;
                _logger.LogInformation($"Queue time is decreasing for '{_queue.Name}'");
                return status;
            }

            _logger.LogInformation($"Queue '{_queue.Name}' is steady");

            return status;
        }

        private static bool IsTrueForLastN(IList<QueueTriggerMetrics> samples, int count, Func<QueueTriggerMetrics, QueueTriggerMetrics, bool> predicate)
        {
            Debug.Assert(count > 1, "count must be greater than 1.");
            Debug.Assert(count <= samples.Count, "count must be less than or equal to the list size.");

            // Walks through the list from left to right starting at len(samples) - count.
            for (int i = samples.Count - count; i < samples.Count - 1; i++)
            {
                if (!predicate(samples[i], samples[i + 1]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
