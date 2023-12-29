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
        // Throttle scale in requests if last scale out time was within ThrottleScaleDownIntervalInSeconds.
        private const int ThrottleScaleDownIntervalInSeconds = 180;

        // Keep metrics and target scale resut history for ExpirationThresholdInseconds
        private const int ExpirationThresholdInseconds = 60;

        private const int ScaleUpFactor = 10;

        private readonly List<EventHubTragetScalerReult> _history = new List<EventHubTragetScalerReult>();
        private readonly ILogger _logger;
        private object lockObject = new object();

        private TargetScalerResult _lastTargetScalerResult = new TargetScalerResult();
        private DateTime _lastScaleUpTime = DateTime.MinValue;

        public TargetScaleThrottler(ILogger logger)
        {
            _logger = logger;
        }

        // for tests
        public TargetScaleThrottler(DateTime lastScaleUpTime, TargetScalerResult lastTargetScalerResult, ILogger logger)
        {
            _lastScaleUpTime = lastScaleUpTime;
            _lastTargetScalerResult = lastTargetScalerResult;
            _logger = logger;
        }

        public TargetScalerResult ThrottleIfNeeded(TargetScalerResult result, EventHubsTriggerMetrics metric, DateTime executionTime)
        {
            try
            {
                lock (lockObject)
                {
                    // Removing expired items from history. We want to keep the history item around the threshold so adding 2 secs.
                    var threshold = executionTime - TimeSpan.FromSeconds(ExpirationThresholdInseconds + 2);
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
                    EventHubTragetScalerReult currentResult = new EventHubTragetScalerReult
                    {
                        TargetScalerResult = result,
                        Metrics = metric,
                        ChangeWorkerCount = result.TargetWorkerCount - _lastTargetScalerResult.TargetWorkerCount
                    };
                    _history.Add(currentResult);
                    int changeWorkerCount = currentResult.ChangeWorkerCount;

                    // Throttle scale down based on latest scale up
                    if (changeWorkerCount < 0 && (executionTime - _lastScaleUpTime).TotalSeconds < ThrottleScaleDownIntervalInSeconds)
                    {
                        _logger.LogInformation($"Throttling scale down, since last scale up time was within {ThrottleScaleDownIntervalInSeconds} seconds. (LastScaleUpTime: '{_lastScaleUpTime}', LastTargetWorkerRequest: '{_lastTargetScalerResult.TargetWorkerCount}')");
                        return _lastTargetScalerResult;
                    }

                    // If there we have enough history try to throttle based on history
                    if ((historyCleared) && (Math.Abs(changeWorkerCount) > 0))
                    {
                        long totalProcessedMessages = 0;
                        long totalBacklog = 0;
                        var samplesCount = _history.Count - 1;
                        for (int i = samplesCount; i > 0; i--)
                        {
                            totalProcessedMessages += GetProcessedEventsCount(_history[i - 1].Metrics, _history[i].Metrics);
                            totalBacklog += _history[i].Metrics.EventCount;
                        }

                        // Throttle scale up based average backlog and execution rate
                        if (changeWorkerCount > 0 && totalBacklog < (double)totalProcessedMessages / ScaleUpFactor)
                        {
                            _logger.LogInformation($"Throttling scale up due average backlog is less then '{ScaleUpFactor}%' of total processed messages. (TotalProcessedMessages: '{totalProcessedMessages}', TotalBackLog: '{totalBacklog}', SamplesCount: '{samplesCount}'");
                            return _lastTargetScalerResult;
                        }

                        // Throttle scale down based on history.
                        if (changeWorkerCount < 0 && !_history.All(x => x.ChangeWorkerCount < 0))
                        {
                            _logger.LogInformation($"Throttling scale down due there was at least one non-scale down vote");
                            return _lastTargetScalerResult;
                        }
                    }

                    _lastTargetScalerResult = currentResult.TargetScalerResult;

                    if (changeWorkerCount > 0)
                    {
                        _lastScaleUpTime = DateTime.UtcNow;
                    }

                    return _lastTargetScalerResult;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to throttle EvetnHubs");
                return result;
            }
        }

        private static long GetProcessedEventsCount(EventHubsTriggerMetrics prev, EventHubsTriggerMetrics current)
        {
            long totalProcessedMessages = 0;
            foreach (var partitionId in current.CheckpointSequences.Keys)
            {
                if (prev.CheckpointSequences.TryGetValue(partitionId, out var count))
                {
                    if (current.CheckpointSequences[partitionId].HasValue && prev.CheckpointSequences[partitionId].HasValue)
                    {
                        totalProcessedMessages += current.CheckpointSequences[partitionId].Value - prev.CheckpointSequences[partitionId].Value;
                    }
                }
            }
            return totalProcessedMessages;
        }

        internal class EventHubTragetScalerReult
        {
            public TargetScalerResult TargetScalerResult { get; set; }

            public EventHubsTriggerMetrics Metrics { get; set; }

            public int ChangeWorkerCount { get; set; }
        }
    }
}
