// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Messaging.EventHubs.Primitives;
using Microsoft.Azure.WebJobs.EventHubs;
using Microsoft.Azure.WebJobs.EventHubs.Listeners;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.EventHubs.Listeners
{
    internal class EventHubTargetScaler : ITargetScaler
    {
        private readonly string _functionId;
        private readonly EventHubsMetricsProvider _eventHubsMetricsProvider;
        private readonly EventHubOptions _options;
        private readonly TargetScalerDescriptor _targetScalerDescriptor;
        private readonly ILogger _logger;

        public EventHubTargetScaler(
            string functionId,
            IEventHubConsumerClient client,
            EventHubOptions options,
            ILoggerFactory loggerFactory,
            BlobCheckpointStoreInternal checkpointStore)
        {
            _functionId = functionId;
            _eventHubsMetricsProvider = new EventHubsMetricsProvider(functionId, client, checkpointStore, loggerFactory);
            _options = options;
            _targetScalerDescriptor = new TargetScalerDescriptor(functionId);
            _logger = loggerFactory.CreateLogger<EventHubTargetScaler>();
        }

        public TargetScalerDescriptor TargetScalerDescriptor => _targetScalerDescriptor;

        public async Task<TargetScalerResult> GetScaleResultAsync(TargetScalerContext context)
        {
            EventHubsTriggerMetrics metrics = await _eventHubsMetricsProvider.GetMetricsAsync().ConfigureAwait(false);
            return GetScaleResultInternal(context, metrics);
        }

        internal TargetScalerResult GetScaleResultInternal(TargetScalerContext context, EventHubsTriggerMetrics metrics)
        {
            int concurrency = !context.InstanceConcurrency.HasValue ? _options.MaxEventBatchSize : context.InstanceConcurrency.Value;

            long maxUnprocessedEventInPartition = metrics.EventCountPerPartition.DefaultIfEmpty().Max(e => e.Value);
            int desiredWorkerCount = (int)(maxUnprocessedEventInPartition * metrics.PartitionCount / concurrency);
            List<long> unprocessedEventCounts = metrics.EventCountPerPartition.Values.ToList();

            if (unprocessedEventCounts.Count == 0)
            {
                unprocessedEventCounts.AddRange(Enumerable.Repeat(0L, metrics.PartitionCount));
            }

            string unprocessedEventsPerPartitionString = string.Join(",", unprocessedEventCounts);

            _logger.LogInformation($"Event Hub unprocessed events per partition are {unprocessedEventsPerPartitionString} " +
                $"and events processed per worker should be {concurrency}, so we want " +
                $"{desiredWorkerCount} worker(s) for function '{_functionId}'.");

            if (desiredWorkerCount > metrics.PartitionCount)
            {
                desiredWorkerCount = metrics.PartitionCount;
                _logger.LogInformation($" However, desiredWorkerCount > numPartitions, so modifying desiredWorkerCount to numPartitions. numPartitions: '{metrics.PartitionCount}'.");
            }

            return new TargetScalerResult
            {
                TargetWorkerCount = desiredWorkerCount
            };
        }
    }
}
