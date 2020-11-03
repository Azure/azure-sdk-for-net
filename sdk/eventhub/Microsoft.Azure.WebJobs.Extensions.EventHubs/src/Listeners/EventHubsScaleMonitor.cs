// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.EventHubs.Listeners
{
    internal class EventHubsScaleMonitor : IScaleMonitor<EventHubsTriggerMetrics>
    {
        private const string EventHubContainerName = "azure-webjobs-eventhub";
        private const int PartitionLogIntervalInMinutes = 5;

        private readonly string _functionId;
        private readonly string _eventHubName;
        private readonly string _consumerGroup;
        private readonly string _connectionString;
        private readonly string _storageConnectionString;
        private readonly Lazy<EventHubConsumerClient> _client;
        private readonly ScaleMonitorDescriptor _scaleMonitorDescriptor;
        private readonly ILogger _logger;

        private BlobContainerClient _blobContainer;
        private DateTime _nextPartitionLogTime;
        private DateTime _nextPartitionWarningTime;

        public EventHubsScaleMonitor(
            string functionId,
            string eventHubName,
            string consumerGroup,
            string connectionString,
            string storageConnectionString,
            ILogger logger,
            BlobContainerClient blobContainer = null)
        {
            _functionId = functionId;
            _eventHubName = eventHubName;
            _consumerGroup = consumerGroup;
            _connectionString = connectionString;
            _storageConnectionString = storageConnectionString;
            _logger = logger;
            _scaleMonitorDescriptor = new ScaleMonitorDescriptor($"{_functionId}-EventHubTrigger-{_eventHubName}-{_consumerGroup}".ToLowerInvariant());
            _nextPartitionLogTime = DateTime.UtcNow;
            _nextPartitionWarningTime = DateTime.UtcNow;
            _blobContainer = blobContainer;

            EventHubsConnectionStringBuilder builder = new EventHubsConnectionStringBuilder(connectionString);
            builder.EntityPath = eventHubName;

            _client = new Lazy<EventHubConsumerClient>(() => new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, builder.ToString()));
        }

        public ScaleMonitorDescriptor Descriptor
        {
            get
            {
                return _scaleMonitorDescriptor;
            }
        }

        private BlobContainerClient BlobContainer
        {
            get
            {
                if (_blobContainer == null)
                {
                    BlobServiceClient blobService = new BlobServiceClient(_storageConnectionString);
                    _blobContainer = blobService.GetBlobContainerClient(EventHubContainerName);
                }
                return _blobContainer;
            }
        }

        async Task<ScaleMetrics> IScaleMonitor.GetMetricsAsync()
        {
            return await GetMetricsAsync().ConfigureAwait(false);
        }

        public async Task<EventHubsTriggerMetrics> GetMetricsAsync()
        {
            EventHubsTriggerMetrics metrics = new EventHubsTriggerMetrics();
            EventHubProperties runtimeInfo = null;

            try
            {
                runtimeInfo = await _client.Value.GetEventHubPropertiesAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _logger.LogWarning($"Encountered an exception while checking EventHub '{_eventHubName}'. Error: {e.Message}");
                return metrics;
            }

            // Get the PartitionRuntimeInformation for all partitions
            _logger.LogInformation($"Querying partition information for {runtimeInfo.PartitionIds.Length} partitions.");
            var tasks = new Task<PartitionProperties>[runtimeInfo.PartitionIds.Length];

            for (int i = 0; i < runtimeInfo.PartitionIds.Length; i++)
            {
                tasks[i] = _client.Value.GetPartitionPropertiesAsync(runtimeInfo.PartitionIds[i]);
            }

            await Task.WhenAll(tasks).ConfigureAwait(false);

            return await CreateTriggerMetrics(tasks.Select(t => t.Result).ToList()).ConfigureAwait(false);
        }

        internal async Task<EventHubsTriggerMetrics> CreateTriggerMetrics(List<PartitionProperties> partitionRuntimeInfo, bool alwaysLog = false)
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
                Tuple<BlobParitionCheckpoint, string> partitionLeaseFile = await GetPartitionLeaseFileAsync(i).ConfigureAwait(false);
                BlobParitionCheckpoint partitionLeaseInfo = partitionLeaseFile.Item1;
                string errorMsg = partitionLeaseFile.Item2;

                if (partitionRuntimeInfo[i] == null || partitionLeaseInfo == null)
                {
                    partitionErrors.Add(errorMsg);
                }
                else
                {
                    // Check for the unprocessed messages when there are messages on the event hub parition
                    // In that case, LastEnqueuedSequenceNumber will be >= 0
                    if ((partitionRuntimeInfo[i].LastEnqueuedSequenceNumber != -1 && partitionRuntimeInfo[i].LastEnqueuedSequenceNumber != partitionLeaseInfo.SequenceNumber)
                        || (partitionLeaseInfo.Offset == null && partitionRuntimeInfo[i].LastEnqueuedSequenceNumber >= 0))
                    {
                        long partitionUnprocessedEventCount = GetUnprocessedEventCount(partitionRuntimeInfo[i], partitionLeaseInfo);
                        totalUnprocessedEventCount += partitionUnprocessedEventCount;
                    }
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

        // EventProcessorClient checkpoints by storing metadata on zero byte blobs named after the partition
        // that is being checkpointed. These are the names of the keys that are used for storing this data.
        private const string SequenceNumberMetadataName = "sequencenumber";
        private const string OffsetMetadataName = "offset";

        private async Task<Tuple<BlobParitionCheckpoint, string>> GetPartitionLeaseFileAsync(int partitionId)
        {
            BlobParitionCheckpoint blobParitionCheckpoint = null;
            string prefix = $"{EventHubOptions.GetBlobPrefix(_eventHubName, _client.Value.FullyQualifiedNamespace)}{_consumerGroup}/checkpoint/{partitionId}";
            string errorMsg = null;

            try
            {
                BlobClient blockBlob = BlobContainer.GetBlobClient(prefix);
                BlobProperties properties = await blockBlob.GetPropertiesAsync().ConfigureAwait(false);

                if (properties.Metadata.TryGetValue(SequenceNumberMetadataName, out string sequenceNumberString))
                {
                    blobParitionCheckpoint ??= new BlobParitionCheckpoint();
                    blobParitionCheckpoint.SequenceNumber = long.Parse(sequenceNumberString, CultureInfo.InvariantCulture);
                }

                if (properties.Metadata.TryGetValue(OffsetMetadataName, out string offsetString))
                {
                    blobParitionCheckpoint ??= new BlobParitionCheckpoint();
                    blobParitionCheckpoint.Offset = long.Parse(offsetString, CultureInfo.InvariantCulture);
                }

                if (blobParitionCheckpoint == null)
                {
                    errorMsg = $"Checkpoint file did not contain required metadata on Partition: '{partitionId}', " +
                        $"EventHub: '{_eventHubName}', '{_consumerGroup}'.";
                }
            }
            catch (RequestFailedException e) when (e.Status == (int)HttpStatusCode.NotFound)
            {
                errorMsg = $"Checkpoint file data could not be found for blob on Partition: '{partitionId}', " +
                    $"EventHub: '{_eventHubName}', '{_consumerGroup}'. Error: {e.Message}";
            }
            catch (Exception e)
            {
                errorMsg = $"Encountered exception while checking for last checkpointed sequence number for blob " +
                    $"on Partition: '{partitionId}', EventHub: '{_eventHubName}', Consumer Group: '{_consumerGroup}'. Error: {e.Message}";
            }

            return new Tuple<BlobParitionCheckpoint, string>(blobParitionCheckpoint, errorMsg);
        }

        // Get the number of unprocessed events by deriving the delta between the server side info and the partition lease info,
        private static long GetUnprocessedEventCount(PartitionProperties partitionInfo, BlobParitionCheckpoint partitionLeaseInfo)
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
                                       $"of partitions ({partitionCount}) for EventHubs entity ({_eventHubName}, {_consumerGroup}).");
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
                _logger.LogInformation($"Event count ({latestEventCount}) for EventHubs entity ({_eventHubName}, {_consumerGroup}) " +
                                       $"is too high relative to the number of instances ({workerCount}).");
                return status;
            }

            // Check to see if the EventHub has been empty for a while. Only if all metrics samples are empty do we scale down.
            bool isIdle = metrics.All(m => m.EventCount == 0);
            if (isIdle)
            {
                status.Vote = ScaleVote.ScaleIn;
                _logger.LogInformation($"'{_eventHubName}' is idle.");
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
                    _logger.LogInformation($"Event count is increasing for '{_eventHubName}'.");
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
                _logger.LogInformation($"Event count is decreasing for '{_eventHubName}'.");
                return status;
            }

            _logger.LogInformation($"EventHubs entity '{_eventHubName}' is steady.");

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

        // The BlobParitionCheckpoint class used for reading blob lease data for a partition from storage. The Offset and SequenceNumber
        // are stored as storage metdata on the blob.
        private class BlobParitionCheckpoint
        {
            public long? Offset { get; set; }

            public long? SequenceNumber { get; set; }
        }
    }
}