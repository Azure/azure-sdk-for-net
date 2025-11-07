// Copyright (c) .NET Foundation. All rights reserved.
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
        // Throttle scale in requests if last scale out time was within ThrottleScaleDownIntervalInSeconds.
        private const int ThrottleScaleDownIntervalInSeconds = 180;

        private readonly string _functionId;
        private readonly IEventHubConsumerClient _client;
        private readonly ILogger _logger;
        private readonly EventHubMetricsProvider _metricsProvider;
        private readonly EventHubOptions _options;

        private DateTime _lastScaleUpTime;
        private TargetScalerResult _lastTargetScalerResult;

        public EventHubsTargetScaler(string functionId,
            IEventHubConsumerClient client,
            EventHubOptions options,
            EventHubMetricsProvider metricsProvider,
            ILogger logger)
        {
            _functionId = functionId;
            _logger = logger;
            _client = client;
            _metricsProvider = metricsProvider;
            _options = options;

            _lastScaleUpTime = DateTime.MinValue;
            _lastTargetScalerResult = new TargetScalerResult();

            TargetScalerDescriptor = new TargetScalerDescriptor(_functionId);
        }

        public TargetScalerDescriptor TargetScalerDescriptor { get; }

        public async Task<TargetScalerResult> GetScaleResultAsync(TargetScalerContext context)
        {
            EventHubsTriggerMetrics latestMetric = await _metricsProvider.GetMetricsAsync().ConfigureAwait(false);

            long eventCount = latestMetric.EventCount;
            int partitionCount = latestMetric.PartitionCount;

            TargetScalerResult currentResult = GetScaleResultInternal(context, eventCount, partitionCount);
            currentResult = ThrottleScaleDownIfNecessaryInternal(currentResult, _lastTargetScalerResult, _lastScaleUpTime, _logger);

            if (GetChangeWorkerCount(currentResult, _lastTargetScalerResult) > 0)
            {
                _lastScaleUpTime = DateTime.UtcNow;
            }

            _lastTargetScalerResult = currentResult;

            return currentResult;
        }

        internal static TargetScalerResult ThrottleScaleDownIfNecessaryInternal(TargetScalerResult currentResult, TargetScalerResult previousResult, DateTime lastScaleUpTime, ILogger logger)
        {
            int changeWorkerCount = GetChangeWorkerCount(currentResult, previousResult);

            if (changeWorkerCount < 0 && (DateTime.UtcNow - lastScaleUpTime).TotalSeconds < ThrottleScaleDownIntervalInSeconds)
            {
                logger.LogInformation($"Throttling scale down, since last scale up time was within {ThrottleScaleDownIntervalInSeconds} seconds. (LastScaleUpTime: '{lastScaleUpTime}', LastTargetWorkerRequest: '{previousResult.TargetWorkerCount}')");

                return previousResult;
            }
            else
            {
                return currentResult;
            }
        }

        internal TargetScalerResult GetScaleResultInternal(TargetScalerContext context, long eventCount, int partitionCount)
        {
            int desiredConcurrency = GetDesiredConcurrencyInternal(context);

            int desiredWorkerCount;
            try
            {
                checked
                {
                    desiredWorkerCount = (int)Math.Ceiling(eventCount / (decimal)desiredConcurrency);
                }
            }
            catch (OverflowException)
            {
                desiredWorkerCount = int.MaxValue;
            }

            int[] sortedValidWorkerCounts = GetSortedValidWorkerCountsForPartitionCount(partitionCount);
            int validatedTargetWorkerCount = GetValidWorkerCount(desiredWorkerCount, sortedValidWorkerCounts);

            string details = $"Target worker count for function '{_functionId}' is '{validatedTargetWorkerCount}' (EventHubName='{_client.EventHubName}', EventCount ='{eventCount}', Concurrency='{desiredConcurrency}', PartitionCount='{partitionCount}').";
            if (validatedTargetWorkerCount != desiredWorkerCount)
            {
                details += $" Desired target worker count of '{desiredWorkerCount}' is not in list of valid sorted workers: '{string.Join(",", sortedValidWorkerCounts)}'. Using next largest valid worker as target worker count.";
            }

            _logger.LogFunctionScaleVote(_functionId, validatedTargetWorkerCount, (int)eventCount, desiredConcurrency, details);

            return new TargetScalerResult
            {
                TargetWorkerCount = validatedTargetWorkerCount,
            };
        }

        internal int GetDesiredConcurrencyInternal(TargetScalerContext context)
        {
            int concurrency = 0;

            if (!context.InstanceConcurrency.HasValue)
            {
                if (_options.TargetUnprocessedEventThreshold > 0)
                {
                    concurrency = (int)_options.TargetUnprocessedEventThreshold;
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
        internal static int[] GetSortedValidWorkerCountsForPartitionCount(int partitionCount)
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
        internal static int GetValidWorkerCount(int workerCount, int[] sortedValidWorkerCountList)
        {
            if (sortedValidWorkerCountList.Length == 0)
            {
                return 0;
            }

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

        private static int GetChangeWorkerCount(TargetScalerResult currentResult, TargetScalerResult previousResult)
        {
            return currentResult.TargetWorkerCount - previousResult.TargetWorkerCount;
        }
    }
}
