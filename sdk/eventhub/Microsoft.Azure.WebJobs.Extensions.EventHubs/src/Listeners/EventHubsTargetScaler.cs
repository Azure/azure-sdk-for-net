﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Primitives;
using Microsoft.Azure.WebJobs.EventHubs;
using Microsoft.Azure.WebJobs.EventHubs.Listeners;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.EventHubs.Listeners
{
    internal class EventHubsTargetScaler : ITargetScaler
    {
        private readonly string _functionId;
        private readonly IEventHubConsumerClient _client;
        private readonly ILogger _logger;
        private readonly BlobCheckpointStoreInternal _checkpointStore;
        private readonly EventHubsMetricsProvider _metricsProvider;
        private readonly EventHubOptions _options;

        public EventHubsTargetScaler(string functionId,
            IEventHubConsumerClient client,
            BlobCheckpointStoreInternal checkpointStore,
            EventHubOptions options,
            ILogger logger)
        {
            _functionId = functionId;
            _logger = logger;
            _checkpointStore = checkpointStore;
            _client = client;
            _metricsProvider = new EventHubsMetricsProvider(_functionId, _client, _checkpointStore, _logger);
            _options = options;

            TargetScalerDescriptor = new TargetScalerDescriptor(_functionId);
        }

        public TargetScalerDescriptor TargetScalerDescriptor { get; }

        public async Task<TargetScalerResult> GetScaleResultAsync(TargetScalerContext context)
        {
            EventHubsTriggerMetrics latestMetric = await _metricsProvider.GetMetricsAsync().ConfigureAwait(false);

            long eventCount = latestMetric.EventCount;
            int partitionCount = latestMetric.PartitionCount;

            int desiredConcurrency = GetDesiredConcurrency(context);
            int desiredWorkerCount = (int)Math.Ceiling(eventCount / (decimal)desiredConcurrency);

            int[] sortedValidWorkerCounts = GetSortedValidWorkerCountsForPartitionCount(partitionCount);

            int validatedTargetWorkerCount = GetValidWorkerCount(desiredWorkerCount, sortedValidWorkerCounts);

            _logger.LogInformation($"'Target worker count for function '{_functionId}' is '{validatedTargetWorkerCount}' (EventHubName='{_client.EventHubName}', EventCount ='{eventCount}', Concurrency='{desiredConcurrency}').");

            return new TargetScalerResult
            {
                TargetWorkerCount = validatedTargetWorkerCount
            };
        }

        private int GetDesiredConcurrency(TargetScalerContext context)
        {
            int concurrency = 0;

            if (!context.InstanceConcurrency.HasValue)
            {
                if (_options.TargetUnprocessedEventThreshold > 0)
                {
                    concurrency = _options.TargetUnprocessedEventThreshold;
                }
                else if (_options.MaxEventBatchSize > 0)
                {
                    concurrency = _options.MaxEventBatchSize;
                }
            }
            else
            {
                concurrency = context.InstanceConcurrency.Value;
            }

            if (concurrency < 1)
            {
                throw new ArgumentOutOfRangeException($"Unexpected concurrency='{concurrency}'. Concurrency must be > 0.");
            }
            else
            {
                return concurrency;
            }
        }
        /// <summary>
        /// Returns an ordered list of valid worker counts for a given Event Hub partitionCount.
        /// </summary>
        /// <param name="partitionCount">Partition count of EventHub. Must be greater than 0.</param>
        /// <returns></returns>
        private static int[] GetSortedValidWorkerCountsForPartitionCount(int partitionCount)
        {
            if (partitionCount == 0)
            {
                return Enumerable.Range(0, partitionCount).ToArray();
            }
            else
            {
                List<int> list = Enumerable.Range(1, partitionCount).
                    Select(c => (double)partitionCount / (double)c).
                    Select(d => (int)Math.Ceiling((double)d)).
                    Distinct().
                    OrderBy(e => e).
                    ToList();
                list.Insert(index: 0, item: 0);

                return list.ToArray();
            }
        }

        /// <summary>
        /// Uses binary search to return the first element equal to or larger than the value. If it is greater than all elements in the sortedValidWorkerCountList, the last element is returned. Binary search documentation is at https://learn.microsoft.com/en-us/dotnet/api/system.array.binarysearch?view=net-7.0.
        /// </summary>
        /// <param name="workerCount">The value that we want to find in the sortedValues list (if it exists), or the next largest element.</param>
        /// <param name="sortedValidWorkerCountList">The list of valid worker counts. This must be sorted.</param>
        /// <returns></returns>
        private static int GetValidWorkerCount(int workerCount, int[] sortedValidWorkerCountList)
        {
            int i = Array.BinarySearch(sortedValidWorkerCountList, workerCount);
            if (i >= 0)
            {
                return sortedValidWorkerCountList[i];
            }
            else
            {
                if (~i < sortedValidWorkerCountList.Length)
                {
                    return sortedValidWorkerCountList[~i];
                }
                else
                {
                    return sortedValidWorkerCountList[~i - 1];
                }
            }
        }
    }
}
