// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Primitives;
using Microsoft.Azure.WebJobs.Extensions.EventHubs.Listeners;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.EventHubs.Listeners
{
    internal class EventHubsScaleMonitor : IScaleMonitor<EventHubsTriggerMetrics>
    {
        private readonly string _functionId;
        private readonly IEventHubConsumerClient _client;
        private readonly ILogger _logger;
        private readonly BlobCheckpointStoreInternal _checkpointStore;
        private readonly EventHubMetricsProvider _metricsProvider;

        public EventHubsScaleMonitor(
            string functionId,
            IEventHubConsumerClient client,
            BlobCheckpointStoreInternal checkpointStore,
            ILogger logger)
        {
            _functionId = functionId;
            _logger = logger;
            _checkpointStore = checkpointStore;
            _client = client;
            _metricsProvider = new EventHubMetricsProvider(_functionId, _client, _checkpointStore, _logger);

            Descriptor = new ScaleMonitorDescriptor($"{_functionId}-EventHubTrigger-{_client.EventHubName}-{_client.ConsumerGroup}".ToLowerInvariant(), _functionId);
        }

        public ScaleMonitorDescriptor Descriptor { get; }

        /// <summary>
        /// Returns the state of the event hub for scaling purposes.
        /// </summary>
        async Task<ScaleMetrics> IScaleMonitor.GetMetricsAsync()
        {
            return await GetMetricsAsync().ConfigureAwait(false);
        }

        public async Task<EventHubsTriggerMetrics> GetMetricsAsync()
        {
            return await _metricsProvider.GetMetricsAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Return the current scaling decision based on the EventHub status.
        /// </summary>
        ScaleStatus IScaleMonitor.GetScaleStatus(ScaleStatusContext context)
        {
            return GetScaleStatusCore(context.WorkerCount, context.Metrics?.Cast<EventHubsTriggerMetrics>().ToArray());
        }

        public ScaleStatus GetScaleStatus(ScaleStatusContext<EventHubsTriggerMetrics> context)
        {
            return GetScaleStatusCore(context.WorkerCount, context.Metrics?.ToArray());
        }

        private ScaleStatus GetScaleStatusCore(int workerCount, EventHubsTriggerMetrics[] metrics)
        {
            ScaleStatus status = new ScaleStatus
            {
                Vote = ScaleVote.None
            };

            const int NumberOfSamplesToConsider = 5;

            // Unable to determine the correct vote with no metrics.
            if (metrics == null || metrics.Length == 0)
            {
                return status;
            }

            // We shouldn't assign more workers than there are partitions
            // This check is first, because it is independent of load or number of samples.
            int partitionCount = metrics.Last().PartitionCount;
            if (partitionCount > 0 && partitionCount < workerCount)
            {
                status.Vote = ScaleVote.ScaleIn;
                _logger.LogInformation($"WorkerCount ({workerCount}) > PartitionCount ({partitionCount}).");
                _logger.LogInformation($"Number of instances ({workerCount}) is too high relative to number " +
                                       $"of partitions ({partitionCount}) for EventHubs entity ({_client.EventHubName}, {_client.ConsumerGroup}).");
                return status;
            }

            // At least 5 samples are required to make a scale decision for the rest of the checks.
            if (metrics.Length < NumberOfSamplesToConsider)
            {
                return status;
            }

            // Maintain a minimum ratio of 1 worker per 1,000 unprocessed events.
            long latestEventCount = metrics.Last().EventCount;
            if (latestEventCount > workerCount * 1000)
            {
                status.Vote = ScaleVote.ScaleOut;
                _logger.LogInformation($"EventCount ({latestEventCount}) > WorkerCount ({workerCount}) * 1,000.");
                _logger.LogInformation($"Event count ({latestEventCount}) for EventHubs entity ({_client.EventHubName}, {_client.ConsumerGroup}) " +
                                       $"is too high relative to the number of instances ({workerCount}).");
                return status;
            }

            // Check to see if the EventHub has been empty for a while. Only if all metrics samples are empty do we scale down.
            bool isIdle = metrics.All(m => m.EventCount == 0);
            if (isIdle)
            {
                status.Vote = ScaleVote.ScaleIn;
                _logger.LogInformation($"'{_client.EventHubName}' is idle.");
                return status;
            }

            // Samples are in chronological order. Check for a continuous increase in unprocessed event count.
            // If detected, this results in an automatic scale out for the site container.
            if (metrics[0].EventCount > 0)
            {
                bool eventCountIncreasing =
                IsTrueForLastN(
                    metrics,
                    NumberOfSamplesToConsider,
                    (prev, next) => prev.EventCount < next.EventCount);
                if (eventCountIncreasing)
                {
                    status.Vote = ScaleVote.ScaleOut;
                    _logger.LogInformation($"Event count is increasing for '{_client.EventHubName}'.");
                    return status;
                }
            }

            bool eventCountDecreasing =
                IsTrueForLastN(
                    metrics,
                    NumberOfSamplesToConsider,
                    (prev, next) => prev.EventCount > next.EventCount);
            if (eventCountDecreasing)
            {
                status.Vote = ScaleVote.ScaleIn;
                _logger.LogInformation($"Event count is decreasing for '{_client.EventHubName}'.");
                return status;
            }

            _logger.LogInformation($"EventHubs entity '{_client.EventHubName}' is steady.");

            return status;
        }

        private static bool IsTrueForLastN(IList<EventHubsTriggerMetrics> samples, int count, Func<EventHubsTriggerMetrics, EventHubsTriggerMetrics, bool> predicate)
        {
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