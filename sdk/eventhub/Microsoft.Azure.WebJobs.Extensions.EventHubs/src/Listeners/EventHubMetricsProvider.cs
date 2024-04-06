// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Primitives;
using Microsoft.Azure.WebJobs.EventHubs.Listeners;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.EventHubs.Listeners
{
    internal class EventHubMetricsProvider
    {
        private const int PartitionLogIntervalInMinutes = 5;

        private readonly string _functionId;
        private readonly IEventHubConsumerClient _client;
        private readonly ILogger _logger;
        private readonly BlobCheckpointStoreInternal _checkpointStore;

        private DateTime _nextPartitionLogTime;
        private DateTime _nextPartitionWarningTime;

        // Used for mocking.
        public EventHubMetricsProvider() { }

        public EventHubMetricsProvider(string functionId, IEventHubConsumerClient client, BlobCheckpointStoreInternal checkpointStore, ILogger logger)
        {
            _functionId = functionId;
            _logger = logger;
            _checkpointStore = checkpointStore;
            _nextPartitionLogTime = DateTime.UtcNow;
            _nextPartitionWarningTime = DateTime.UtcNow;
            _client = client;
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
            var partitionPropertiesTasks = new Task<PartitionProperties>[partitions.Length];
            var checkpointTasks = new Task<EventProcessorCheckpoint>[partitionPropertiesTasks.Length];

            for (int i = 0; i < partitions.Length; i++)
            {
                partitionPropertiesTasks[i] = _client.GetPartitionPropertiesAsync(partitions[i]);

                checkpointTasks[i] = _checkpointStore.GetCheckpointAsync(
                        _client.FullyQualifiedNamespace,
                        _client.EventHubName,
                        _client.ConsumerGroup,
                        partitions[i],
                        CancellationToken.None);
            }

            await Task.WhenAll(partitionPropertiesTasks).ConfigureAwait(false);
            EventProcessorCheckpoint[] checkpoints;

            try
            {
                checkpoints = await Task.WhenAll(checkpointTasks).ConfigureAwait(false);
            }
            catch
            {
                // GetCheckpointsAsync would log
                return metrics;
            }

            return CreateTriggerMetrics(partitionPropertiesTasks.Select(t => t.Result).ToList(), checkpoints);
        }

        private EventHubsTriggerMetrics CreateTriggerMetrics(List<PartitionProperties> partitionRuntimeInfo, EventProcessorCheckpoint[] checkpoints, bool alwaysLog = false)
        {
            long totalUnprocessedEventCount = 0;

            DateTime utcNow = DateTime.UtcNow;
            bool logPartitionInfo = alwaysLog ? true : utcNow >= _nextPartitionLogTime;
            bool logPartitionWarning = alwaysLog ? true : utcNow >= _nextPartitionWarningTime;

            // For each partition, get the last enqueued sequence number.
            // If the last enqueued sequence number does not equal the SequenceNumber from the lease info in storage,
            // accumulate new event counts across partitions to derive total new event counts.
            List<string> partitionErrors = new List<string>();
            for (int i = 0; i < partitionRuntimeInfo.Count; i++)
            {
                var partitionProperties = partitionRuntimeInfo[i];

                var checkpoint = (BlobCheckpointStoreInternal.BlobStorageCheckpoint)checkpoints.SingleOrDefault(c => c?.PartitionId == partitionProperties.Id);

                // Check for the unprocessed messages when there are messages on the Event Hub partition
                // In that case, LastEnqueuedSequenceNumber will be >= 0

                if ((partitionProperties.LastEnqueuedSequenceNumber != -1 && partitionProperties.LastEnqueuedSequenceNumber != (checkpoint?.SequenceNumber ?? -1))
                    || (checkpoint == null && partitionProperties.LastEnqueuedSequenceNumber >= 0)
                    || (checkpoint != null && checkpoint.Offset == null && partitionProperties.LastEnqueuedSequenceNumber >= 0))
                {
                    long partitionUnprocessedEventCount = GetUnprocessedEventCount(partitionProperties, checkpoint);
                    totalUnprocessedEventCount += partitionUnprocessedEventCount;
                }
            }

            // Only log if not all partitions are failing or it's time to log
            if (partitionErrors.Count > 0 && (partitionErrors.Count != partitionRuntimeInfo.Count || logPartitionWarning))
            {
                _logger.LogWarning($"Function '{_functionId}': Unable to deserialize partition or checkpoint info with the " +
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
        private static long GetUnprocessedEventCount(PartitionProperties partitionInfo, BlobCheckpointStoreInternal.BlobStorageCheckpoint checkpoint)
        {
            // If the partition is empty, there are no events to process.

            if (partitionInfo.IsEmpty)
            {
                return 0;
            }

            // If there is no checkpoint and the beginning and last sequence numbers for the partition are the same
            // this partition received its first event.

            if (checkpoint == null
                && partitionInfo.LastEnqueuedSequenceNumber == partitionInfo.BeginningSequenceNumber)
            {
                return 1;
            }

            // Legacy checkpoint support
            if (checkpoint != null && checkpoint.Offset == null && partitionInfo.LastEnqueuedSequenceNumber >= 0)
            {
                return partitionInfo.LastEnqueuedSequenceNumber + 1;
            }

            var startingSequenceNumber = checkpoint?.SequenceNumber switch
            {
                // There was no checkpoint, use the beginning sequence number - 1, since
                // that event hasn't been processed yet.

                null => partitionInfo.BeginningSequenceNumber - 1,

                // Use the checkpoint.

                long seq => seq
            };

            // For normal scenarios, the last sequence number will be greater than the starting number and
            // simple subtraction can be used.

            if (partitionInfo.LastEnqueuedSequenceNumber > startingSequenceNumber)
            {
                return (partitionInfo.LastEnqueuedSequenceNumber - startingSequenceNumber);
            }

            // Partition is a circular buffer, so it is possible that
            // LastEnqueuedSequenceNumber < startingSequenceNumber

            long count = 0;
            unchecked
            {
                count = (long.MaxValue - partitionInfo.LastEnqueuedSequenceNumber) + startingSequenceNumber;
            }

            // It's possible for the starting sequence number to be ahead of the last sequence number,
            // especially if checkpointing is happening often and load is very low.  If count is negative,
            // we need to know that this read is invalid, so return 0.
            // e.g., (9223372036854775807 - 10) + 11 = -9223372036854775808

            return (count < 0) ? 0 : count;
        }
    }
}
