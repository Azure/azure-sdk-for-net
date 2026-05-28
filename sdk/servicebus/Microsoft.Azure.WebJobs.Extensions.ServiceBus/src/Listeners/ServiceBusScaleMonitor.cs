// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Logging;
using System.Globalization;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Listeners;

namespace Microsoft.Azure.WebJobs.ServiceBus.Listeners
{
    internal class ServiceBusScaleMonitor : IScaleMonitor<ServiceBusTriggerMetrics>
    {
        private readonly string _functionId;
        private readonly string _entityPath;
        private readonly ScaleMonitorDescriptor _scaleMonitorDescriptor;
        private readonly ILogger<ServiceBusScaleMonitor> _logger;
        private readonly ServiceBusMetricsProvider _serviceBusMetricsProvider;

        // to avoid frequent scaling out when queue time is increasing, we wait for at least 2s before scaling out (backward compatibility with SCV2).
        public static TimeSpan MinimumLastQueueMessageInSecondsThreshold = TimeSpan.FromSeconds(2.0);

        public ServiceBusScaleMonitor(
            string functionId,
            string entityPath,
            ServiceBusEntityType entityType,
            Lazy<ServiceBusReceiver> receiver,
            Lazy<ServiceBusAdministrationClient> administrationClient,
            ILoggerFactory loggerFactory
            )
        {
            _functionId = functionId;
            _entityPath = entityPath;
            _serviceBusMetricsProvider = new ServiceBusMetricsProvider(entityPath, entityType, receiver, administrationClient, loggerFactory);
            _scaleMonitorDescriptor = new ScaleMonitorDescriptor($"{_functionId}-ServiceBusTrigger-{_entityPath}".ToLower(CultureInfo.InvariantCulture), functionId);
            _logger = loggerFactory.CreateLogger<ServiceBusScaleMonitor>();
        }

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

        public async Task<ServiceBusTriggerMetrics> GetMetricsAsync()
        {
            return await _serviceBusMetricsProvider.GetMetricsAsync().ConfigureAwait(false);
        }

        ScaleStatus IScaleMonitor.GetScaleStatus(ScaleStatusContext context)
        {
            return GetScaleStatusCore(context.WorkerCount, context.Metrics?.Cast<ServiceBusTriggerMetrics>().ToArray());
        }

        public ScaleStatus GetScaleStatus(ScaleStatusContext<ServiceBusTriggerMetrics> context)
        {
            return GetScaleStatusCore(context.WorkerCount, context.Metrics?.ToArray());
        }

        private ScaleStatus GetScaleStatusCore(int workerCount, ServiceBusTriggerMetrics[] metrics)
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
                                       $"of partitions for Service Bus entity ({_entityPath}, {partitionCount}).");
                return status;
            }

            // At least 5 samples are required to make a scale decision for the rest of the checks.
            if (metrics.Length < NumberOfSamplesToConsider)
            {
                return status;
            }

            // Maintain a minimum ratio of 1 worker per 1,000 messages.
            long latestMessageCount = metrics.Last().MessageCount;
            if (latestMessageCount > workerCount * 1000)
            {
                status.Vote = ScaleVote.ScaleOut;
                _logger.LogInformation($"MessageCount ({latestMessageCount}) > WorkerCount ({workerCount}) * 1,000.");
                _logger.LogInformation($"Message count for Service Bus Entity ({_entityPath}, {latestMessageCount}) " +
                                       $"is too high relative to the number of instances ({workerCount}).");
                return status;
            }

            // Check to see if the queue/topic has been empty for a while. Only if all metrics samples are empty do we scale down.
            bool isIdle = metrics.All(m => m.MessageCount == 0);
            if (isIdle)
            {
                status.Vote = ScaleVote.ScaleIn;
                _logger.LogInformation($"'{_entityPath}' is idle.");
                return status;
            }

            // Samples are in chronological order. Check for a continuous increase in message count.
            // If detected, this results in an automatic scale out for the site container.
            if (metrics[0].MessageCount > 0)
            {
                bool messageCountIncreasing =
                IsTrueForLastN(
                    metrics,
                    NumberOfSamplesToConsider,
                    (prev, next) => prev.MessageCount < next.MessageCount) && metrics[0].MessageCount > 0;
                if (messageCountIncreasing)
                {
                    status.Vote = ScaleVote.ScaleOut;
                    _logger.LogInformation($"Message count is increasing for '{_entityPath}'.");
                    return status;
                }
            }

            var lastSampleQueueTime = metrics[NumberOfSamplesToConsider - 1].QueueTime;

            if (metrics[0].QueueTime > TimeSpan.Zero && metrics[0].QueueTime < lastSampleQueueTime)
            {
                bool queueTimeIncreasing =
                    IsTrueForLastN(
                        metrics,
                        NumberOfSamplesToConsider,
                        (prev, next) => prev.QueueTime <= next.QueueTime);
                if (queueTimeIncreasing)
                {
                    // to avoid frequent scaling out when queue time is increasing, we wait for at least 2s (backward compatibility with SCV2).
                    if (lastSampleQueueTime >= MinimumLastQueueMessageInSecondsThreshold)
                    {
                        status.Vote = ScaleVote.ScaleOut;
                        _logger.LogInformation($"Queue time is increasing for '{_entityPath}'.");
                        return status;
                    }
                    else
                    {
                        status.Vote = ScaleVote.None;
                        _logger.LogInformation($"Queue time is increasing for '{_entityPath}' but we do not scale out unless queue latency is greater than {MinimumLastQueueMessageInSecondsThreshold.TotalSeconds}s. Current queue latency is {lastSampleQueueTime.TotalSeconds}s.");
                        return status;
                    }
                }
            }

            bool messageCountDecreasing =
                IsTrueForLastN(
                    metrics,
                    NumberOfSamplesToConsider,
                    (prev, next) => prev.MessageCount > next.MessageCount);
            if (messageCountDecreasing)
            {
                status.Vote = ScaleVote.ScaleIn;
                _logger.LogInformation($"Message count is decreasing for '{_entityPath}'.");
                return status;
            }

            bool queueTimeDecreasing = IsTrueForLastN(
                metrics,
                NumberOfSamplesToConsider,
                (prev, next) => prev.QueueTime > next.QueueTime);
            if (queueTimeDecreasing)
            {
                status.Vote = ScaleVote.ScaleIn;
                _logger.LogInformation($"Queue time is decreasing for '{_entityPath}'.");
                return status;
            }

            _logger.LogInformation($"Service Bus entity '{_entityPath}' is steady.");

            return status;
        }

        private static bool IsTrueForLastN(IList<ServiceBusTriggerMetrics> samples, int count, Func<ServiceBusTriggerMetrics, ServiceBusTriggerMetrics, bool> predicate)
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