// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.EventHubs.Listeners
{
    internal class EventHubsScaleMonitor : IScaleMonitor<EventHubsTriggerMetrics>
    {
        private const int PartitionLogIntervalInMinutes = 5;

        private readonly string _functionId;
        private readonly IEventHubConsumerClient _client;
        private readonly ILogger _logger;
        private readonly BlobsCheckpointStore _checkpointStore;

        private DateTime _nextPartitionLogTime;
        private DateTime _nextPartitionWarningTime;

        public EventHubsScaleMonitor(
            string functionId,
            IEventHubConsumerClient client,
            BlobsCheckpointStore checkpointStore,
            ILogger logger)
        {
            _functionId = functionId;
            _logger = logger;
            _checkpointStore = checkpointStore;
            _nextPartitionLogTime = DateTime.UtcNow;
            _nextPartitionWarningTime = DateTime.UtcNow;
            _client = client;

            Descriptor = new ScaleMonitorDescriptor($"{_functionId}-EventHubTrigger-{_client.EventHubName}-{_client.ConsumerGroup}".ToLowerInvariant());
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
            EventHubsTriggerMetrics metrics = new EventHubsTriggerMetrics();
            string[] partitions = null;

            try
            {
                partitions = await _client.GetPartitionsAsync().ConfigureAwait(false);
                metrics.PartitionCount = partitions.Length;
            }
            catch (Exception e)
            {
                _logger.LogWarning($"Encountered an exception while checking EventHub '{_client.EventHubName}'. Error: {e.Message}");
                return metrics;
            }

            // Get the PartitionRuntimeInformation for all partitions
            _logger.LogInformation($"Querying partition information for {partitions.Length} partitions.");
            var tasks = new Task<PartitionProperties>[partitions.Length];

            for (int i = 0; i < partitions.Length; i++)
            {
                tasks[i] = _client.GetPartitionPropertiesAsync(partitions[i]);
            }

            await Task.WhenAll(tasks).ConfigureAwait(false);

            IEnumerable<EventProcessorCheckpoint> checkpoints;
            try
            {
                checkpoints = await _checkpointStore.ListCheckpointsAsync(
                        _client.FullyQualifiedNamespace,
                        _client.EventHubName,
                        _client.ConsumerGroup,
                        default)
                    .ConfigureAwait(false);
            }
            catch
            {
                // ListCheckpointsAsync would log
                return metrics;
            }

            return CreateTriggerMetrics(tasks.Select(t => t.Result).ToList(), checkpoints.ToArray());
        }

        private EventHubsTriggerMetrics CreateTriggerMetrics(List<PartitionProperties> partitionRuntimeInfo, EventProcessorCheckpoint[] checkpoints, bool alwaysLog = false)
        {
            long totalUnprocessedEventCount = 0;
            bool logPartitionInfo = alwaysLog ? true : DateTime.UtcNow >= _nextPartitionLogTime;
            bool logPartitionWarning = alwaysLog ? true : DateTime.UtcNow >= _nextPartitionWarningTime;

            // For each partition, get the last enqueued sequence number.
            // If the last enqueued sequence number does not equal the SequenceNumber from the lease info in storage,
            // accumulate new event counts across partitions to derive total new event counts.
            List<string> partitionErrors = new List<string>();
            for (int i = 0; i < partitionRuntimeInfo.Count; i++)
            {
                var partitionProperties = partitionRuntimeInfo[i];

                var checkpoint = (BlobsCheckpointStore.BlobStorageCheckpoint)checkpoints.SingleOrDefault(c => c.PartitionId == partitionProperties.Id);
                if (checkpoint == null)
                {
                    partitionErrors.Add($"Unable to find a checkpoint information for partition: {partitionProperties.Id}");
                    continue;
                }

                // Check for the unprocessed messages when there are messages on the event hub parition
                // In that case, LastEnqueuedSequenceNumber will be >= 0
                if ((partitionProperties.LastEnqueuedSequenceNumber != -1 && partitionProperties.LastEnqueuedSequenceNumber != checkpoint.SequenceNumber)
                    || (checkpoint.Offset == null && partitionProperties.LastEnqueuedSequenceNumber >= 0))
                {
                    long partitionUnprocessedEventCount = GetUnprocessedEventCount(partitionProperties, checkpoint);
                    totalUnprocessedEventCount += partitionUnprocessedEventCount;
                }
            }

            // Only log if not all partitions are failing or it's time to log
            if (partitionErrors.Count > 0 && (partitionErrors.Count != partitionRuntimeInfo.Count || logPartitionWarning))
            {
                _logger.LogWarning($"Function '{_functionId}': Unable to deserialize partition or lease info with the " +
                    $"following errors: {string.Join(" ", partitionErrors)}");
                _nextPartitionWarningTime = DateTime.UtcNow.AddMinutes(PartitionLogIntervalInMinutes);
            }

            if (totalUnprocessedEventCount > 0 && logPartitionInfo)
            {
                _logger.LogInformation($"Function '{_functionId}', Total new events: {totalUnprocessedEventCount}");
                _nextPartitionLogTime = DateTime.UtcNow.AddMinutes(PartitionLogIntervalInMinutes);
            }

            return new EventHubsTriggerMetrics
            {
                Timestamp = DateTime.UtcNow,
                PartitionCount = partitionRuntimeInfo.Count,
                EventCount = totalUnprocessedEventCount
            };
        }

        // Get the number of unprocessed events by deriving the delta between the server side info and the partition lease info,
        private static long GetUnprocessedEventCount(PartitionProperties partitionInfo, BlobsCheckpointStore.BlobStorageCheckpoint partitionLeaseInfo)
        {
            long partitionLeaseInfoSequenceNumber = partitionLeaseInfo.SequenceNumber ?? 0;

            // This handles two scenarios:
            //   1. If the partition has received its first message, Offset will be null and LastEnqueuedSequenceNumber will be 0
            //   2. If there are no instances set to process messages, Offset will be null and LastEnqueuedSequenceNumber will be >= 0
            if (partitionLeaseInfo.Offset == null && partitionInfo.LastEnqueuedSequenceNumber >= 0)
            {
                return (partitionInfo.LastEnqueuedSequenceNumber + 1);
            }

            if (partitionInfo.LastEnqueuedSequenceNumber > partitionLeaseInfoSequenceNumber)
            {
                return (partitionInfo.LastEnqueuedSequenceNumber - partitionLeaseInfoSequenceNumber);
            }

            // Partition is a circular buffer, so it is possible that
            // LastEnqueuedSequenceNumber < SequenceNumber
            long count = 0;
            unchecked
            {
                count = (long.MaxValue - partitionInfo.LastEnqueuedSequenceNumber) + partitionLeaseInfoSequenceNumber;
            }

            // It's possible for checkpointing to be ahead of the partition's LastEnqueuedSequenceNumber,
            // especially if checkpointing is happening often and load is very low.
            // If count is negative, we need to know that this read is invalid, so return 0.
            // e.g., (9223372036854775807 - 10) + 11 = -9223372036854775808
            return (count < 0) ? 0 : count;
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