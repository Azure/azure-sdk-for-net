// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.WebJobs.EventHubs.Listeners;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.EventHubs.Listeners
{
    internal class TargetScaleThrottler
    {
        // Throttle scale down requests if last scale up/scale down time was within ThrottleScaleDownIntervalInSeconds.
        private const int ThrottleScaleDownIntervalInSeconds = 180;

        // Keep metrics in the history for ExpirationThresholdInseconds
        private const int ExpirationThresholdInSeconds = 65;

        private const int ScaleUpFactor = 30;

        private readonly List<EventHubTargetScalerResult> _history = new List<EventHubTargetScalerResult>();
        private readonly ILogger _logger;
        private object lockObject = new object();

        private TargetScalerResult _lastTargetScalerResult = new TargetScalerResult();
        private DateTime _lastScaleTime = DateTime.MinValue;

        public TargetScaleThrottler(ILogger logger)
        {
            _logger = logger;
        }

        // for tests
        public TargetScaleThrottler(DateTime lastScaleTime, TargetScalerResult lastTargetScalerResult, ILogger logger)
        {
            _lastScaleTime = lastScaleTime;
            _lastTargetScalerResult = lastTargetScalerResult;
            _logger = logger;
        }

        public TargetScalerResult ThrottleIfNeeded(TargetScalerResult result, EventHubsTriggerMetrics metric, DateTime executionTime, out string scaleResultLog)
        {
            // Throttle scale down if there was a scale operation or the same target worker count was voted within 180 seconds
            // Throttle scale down if there was a scale up in the last 60 seconds
            // Throttle scale up vote if backlog is less than 30% of the execution rate
            // On scale down, pick the maximum of the following: the highest vote from the history, or one step back from the sorted valid worker count
            // Allow scale down to 0 only if there were no executions in the last 60 seconds

            scaleResultLog = string.Empty;
            try
            {
                lock (lockObject)
                {
                    // Removing expired items from history. We want to keep the history item around the threshold so adding 2 secs.
                    var threshold = executionTime - TimeSpan.FromSeconds(ExpirationThresholdInSeconds);
                    bool historyCleared = false;
                    for (int i = _history.Count - 1; i >= 0; i--)
                    {
                        if (_history[i].Metrics.Timestamp < threshold)
                        {
                            historyCleared = true;
                            _history.RemoveAt(i);
                        }
                    }

                    // Adding new history item
                    EventHubTargetScalerResult currentResult = new EventHubTargetScalerResult
                    {
                        TargetScalerResult = result,
                        Metrics = metric,
                    };
                    _history.Add(currentResult);
                    int changeWorkerCount = result.TargetWorkerCount - _lastTargetScalerResult.TargetWorkerCount;

                    // Calculate how many messages were processed and what's is the total backlog
                    long totalProcessedMessages = 0;
                    long totalBacklog = 0;
                    var samplesCount = _history.Count - 1;
                    for (int i = samplesCount; i > 0; i--)
                    {
                        totalProcessedMessages += GetProcessedEventsCount(_history[i - 1].Metrics, _history[i].Metrics);
                        totalBacklog += _history[i].Metrics.EventCount;
                    }
                    scaleResultLog = $", TotalProcessedMessages: '{totalProcessedMessages}', TotalBacklog: '{totalBacklog}', SamplesCount: '{samplesCount}'";

                    // Throttle scale down based on latest scale operation
                    if (changeWorkerCount < 0 && (executionTime - _lastScaleTime).TotalSeconds < ThrottleScaleDownIntervalInSeconds)
                    {
                        scaleResultLog += $", ThrottlingReason: Throttling scale down, since last scaling operation time was within {ThrottleScaleDownIntervalInSeconds} seconds. (LastScaleUpTime: '{_lastScaleTime}', LastTargetWorkerRequest: '{_lastTargetScalerResult.TargetWorkerCount}'";
                        return _lastTargetScalerResult;
                    }

                    // If there we have enough history try to throttle based on history
                    if (historyCleared && Math.Abs(changeWorkerCount) > 0)
                    {
                        // Throttle scale up based average backlog and execution rate
                        if (changeWorkerCount > 0 && totalBacklog < (double)totalProcessedMessages * 100 / ScaleUpFactor && _lastTargetScalerResult.TargetWorkerCount != 0)
                        {
                            scaleResultLog += $", ThrottlingReason: Throttling scale up because average backlog is less than '{ScaleUpFactor}%' of total processed messages. (LastScaleTime: {_lastScaleTime}, LastTargetWorkerRequest: {_lastTargetScalerResult.TargetWorkerCount}";
                            return _lastTargetScalerResult;
                        }

                        // Throttle scale down based on history.
                        if (changeWorkerCount < 0)
                        {
                            // All votes in the history must be scale down
                            if (!_history.All(x => x.TargetScalerResult.TargetWorkerCount == 0))
                            {
                                scaleResultLog += $", ThrottlingReason: Throttling scale down because there was at least one non-scale down vote. (LastScaleTime: {_lastScaleTime}, LastTargetWorkerRequest: {_lastTargetScalerResult.TargetWorkerCount}";
                                return _lastTargetScalerResult;
                            }
                            else
                            {
                                long processedMessageCount = GetProcessedEventsCount(_history.First().Metrics, _history.Last().Metrics);
                                if (processedMessageCount > 0)
                                {
                                    // TargetWorkerCount based on the history
                                    var maxItem = _history.First(item => item.TargetScalerResult.TargetWorkerCount == _history.Max(i => i.TargetScalerResult.TargetWorkerCount));
                                    // TargetWorkerCount based on valid worker list
                                    int[] sortedValidWorkerCounts = EventHubsTargetScaler.GetSortedValidWorkerCountsForPartitionCount(metric.PartitionCount);
                                    string sortedValidWorkerCountsAsString = string.Join(",", sortedValidWorkerCounts);
                                    int index = Array.BinarySearch(sortedValidWorkerCounts, _lastTargetScalerResult.TargetWorkerCount);
                                    if (index <= 0)
                                    {
                                        throw new InvalidOperationException($"Unexpected index for '{_lastTargetScalerResult.TargetWorkerCount}' in valid workers count array '{sortedValidWorkerCountsAsString}");
                                    }
                                    int newTargetWorkerCount= sortedValidWorkerCounts[index - 1];
                                    if (newTargetWorkerCount == 0)
                                    {
                                        newTargetWorkerCount = 1;
                                    }

                                    if (maxItem.TargetScalerResult.TargetWorkerCount > sortedValidWorkerCounts[index])
                                    {
                                        scaleResultLog += $", ChangingReason: Change scale down TargetWorkerCount to the max from the history '{result.TargetWorkerCount}'->'{maxItem.TargetScalerResult.TargetWorkerCount}', Time: {maxItem.Metrics.Timestamp}";
                                        result.TargetWorkerCount = maxItem.TargetScalerResult.TargetWorkerCount;
                                    }
                                    else
                                    {
                                        scaleResultLog += $", ChangingReason: Change scale down TargetWorkerCount based on value from valid sorted workers list: [{sortedValidWorkerCountsAsString}] '{result.TargetWorkerCount}'->'{newTargetWorkerCount}'";
                                        result.TargetWorkerCount = newTargetWorkerCount;
                                    }
                                }
                            }
                        }
                    }

                    _lastTargetScalerResult = currentResult.TargetScalerResult;
                    _lastScaleTime = executionTime;

                    return _lastTargetScalerResult;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to throttle EvetnHubs scalingю");
                return result;
            }
        }

        private static long GetProcessedEventsCount(EventHubsTriggerMetrics prev, EventHubsTriggerMetrics current)
        {
            long totalProcessedMessages = 0;
            foreach (var currentCheckpoint in current.Checkpoints)
            {
                var previosCheckpoint = prev.Checkpoints.FirstOrDefault(x => x.PartitionId == currentCheckpoint.PartitionId);

                if (previosCheckpoint != null)
                {
                    if (currentCheckpoint.SequenceNumber.HasValue && previosCheckpoint.SequenceNumber.HasValue
                        && currentCheckpoint.SequenceNumber.Value > previosCheckpoint.SequenceNumber.Value)
                    {
                        totalProcessedMessages += currentCheckpoint.SequenceNumber.Value - previosCheckpoint.SequenceNumber.Value;
                    }
                }
            }
            return totalProcessedMessages;
        }

        internal class EventHubTargetScalerResult
        {
            public TargetScalerResult TargetScalerResult { get; set; }

            public EventHubsTriggerMetrics Metrics { get; set; }
        }
    }
}
