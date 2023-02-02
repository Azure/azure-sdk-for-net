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

namespace Microsoft.Azure.WebJobs.ServiceBus.Listeners
{
    internal class ServiceBusScaleMonitor : IScaleMonitor<ServiceBusTriggerMetrics>
    {
        private const string DeadLetterQueuePath = @"/$DeadLetterQueue";

        private readonly string _functionId;
        private readonly ServiceBusEntityType _serviceBusEntityType;
        private readonly string _entityPath;
        private readonly ScaleMonitorDescriptor _scaleMonitorDescriptor;
        private readonly bool _isListeningOnDeadLetterQueue;
        private readonly Lazy<ServiceBusReceiver> _receiver;
        private readonly Lazy<ServiceBusAdministrationClient> _administrationClient;
        private readonly ILogger<ServiceBusScaleMonitor> _logger;

        private DateTime _nextWarningTime;

        public ServiceBusScaleMonitor(string functionId, ServiceBusEntityType serviceBusEntityType, string entityPath, string connection, Lazy<ServiceBusReceiver> receiver, ILoggerFactory loggerFactory, ServiceBusClientFactory clientFactory)
        {
            _functionId = functionId;
            _serviceBusEntityType = serviceBusEntityType;
            _entityPath = entityPath;
            _scaleMonitorDescriptor = new ScaleMonitorDescriptor($"{_functionId}-ServiceBusTrigger-{_entityPath}".ToLower(CultureInfo.InvariantCulture));
            _isListeningOnDeadLetterQueue = entityPath.EndsWith(DeadLetterQueuePath, StringComparison.OrdinalIgnoreCase);
            _receiver = receiver;
            _administrationClient = new Lazy<ServiceBusAdministrationClient>(() => clientFactory.CreateAdministrationClient(connection));
            _logger = loggerFactory.CreateLogger<ServiceBusScaleMonitor>();
            _nextWarningTime = DateTime.UtcNow;
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
            ServiceBusReceivedMessage activeMessage = null;
            string entityName = _serviceBusEntityType == ServiceBusEntityType.Queue ? "queue" : "topic";

            try
            {
                // Do a first attempt to peek one message from the head of the queue
                var peekedMessage = await _receiver.Value.PeekMessageAsync(fromSequenceNumber: 0).ConfigureAwait(false);
                if (peekedMessage == null)
                {
                    // ignore it. The Get[Queue|Topic]MetricsAsync methods deal with activeMessage being null
                }
                else if (MessageIsActive(peekedMessage))
                {
                    activeMessage = peekedMessage;
                }
                else
                {
                    // Do another attempt to peek ten message from last peek sequence number
                    var peekedMessages  = await _receiver.Value.PeekMessagesAsync(10, fromSequenceNumber: peekedMessage.SequenceNumber).ConfigureAwait(false);
                    foreach (var receivedMessage in peekedMessages )
                    {
                        if (MessageIsActive(receivedMessage))
                        {
                            activeMessage = receivedMessage;
                            break;
                        }
                    }

                    // Batch contains messages but none are active in the peeked batch
                    if (peekedMessages.Count > 0 && activeMessage == null)
                    {
                        _logger.LogDebug("{_serviceBusEntityType} {_entityPath} contains multiple messages but none are active in the peeked batch.");
                    }
                }

                if (_serviceBusEntityType == ServiceBusEntityType.Queue)
                {
                    return await GetQueueMetricsAsync(activeMessage).ConfigureAwait(false);
                }
                else
                {
                    return await GetTopicMetricsAsync(activeMessage).ConfigureAwait(false);
                }
            }
            catch (ServiceBusException ex)
            when (ex.Reason == ServiceBusFailureReason.MessagingEntityNotFound)
            {
                _logger.LogWarning($"ServiceBus {entityName} '{_entityPath}' was not found.");
            }
            catch (UnauthorizedAccessException) // When manage claim is not used on Service Bus connection string
            {
                if (TimeToLogWarning())
                {
                    _logger.LogWarning($"Connection string does not have Manage claim for {entityName} '{_entityPath}'. Failed to get {entityName} description to " +
                        $"derive {entityName} length metrics. Falling back to using first message enqueued time.");
                }
            }
            catch (Exception e)
            {
                _logger.LogWarning($"Error querying for Service Bus {entityName} scale status: {e.Message}");
            }

            // Path for connection strings with no manage claim
            return CreateTriggerMetrics(activeMessage, 0, 0, 0, _isListeningOnDeadLetterQueue);
        }

        private async Task<ServiceBusTriggerMetrics> GetQueueMetricsAsync(ServiceBusReceivedMessage message)
        {
            QueueRuntimeProperties queueRuntimeProperties;
            QueueProperties queueProperties;
            long activeMessageCount = 0, deadLetterCount = 0;
            int partitionCount = 0;

            queueRuntimeProperties = await _administrationClient.Value.GetQueueRuntimePropertiesAsync(_entityPath).ConfigureAwait(false);
            activeMessageCount = queueRuntimeProperties.ActiveMessageCount;
            deadLetterCount = queueRuntimeProperties.DeadLetterMessageCount;

            // If partitioning is turned on, then Service Bus automatically partitions queues into 16 partitions
            // See more information here: https://docs.microsoft.com/en-us/azure/service-bus-messaging/service-bus-partitioning#standard
            queueProperties = await _administrationClient.Value.GetQueueAsync(_entityPath).ConfigureAwait(false);
            partitionCount = queueProperties.EnablePartitioning ? 16 : 0;

            return CreateTriggerMetrics(message, activeMessageCount, deadLetterCount, partitionCount, _isListeningOnDeadLetterQueue);
        }

        private async Task<ServiceBusTriggerMetrics> GetTopicMetricsAsync(ServiceBusReceivedMessage message)
        {
            TopicProperties topicProperties;
            SubscriptionRuntimeProperties subscriptionProperties;
            string topicPath, subscriptionPath;
            long activeMessageCount = 0, deadLetterCount = 0;
            int partitionCount = 0;

            ServiceBusEntityPathHelper.ParseTopicAndSubscription(_entityPath, out topicPath, out subscriptionPath);

            subscriptionProperties = await _administrationClient.Value.GetSubscriptionRuntimePropertiesAsync(topicPath, subscriptionPath).ConfigureAwait(false);
            activeMessageCount = subscriptionProperties.ActiveMessageCount;
            deadLetterCount = subscriptionProperties.DeadLetterMessageCount;

            // If partitioning is turned on, then Service Bus automatically partitions queues into 16 partitions
            // See more information here: https://docs.microsoft.com/en-us/azure/service-bus-messaging/service-bus-partitioning#standard
            topicProperties = await _administrationClient.Value.GetTopicAsync(topicPath).ConfigureAwait(false);
            partitionCount = topicProperties.EnablePartitioning ? 16 : 0;

            return CreateTriggerMetrics(message, activeMessageCount, deadLetterCount, partitionCount, _isListeningOnDeadLetterQueue);
        }

        internal static ServiceBusTriggerMetrics CreateTriggerMetrics(ServiceBusReceivedMessage message, long activeMessageCount, long deadLetterCount, int partitionCount, bool isListeningOnDeadLetterQueue)
        {
            long totalNewMessageCount = 0;
            TimeSpan queueTime = TimeSpan.Zero;

            if (message != null)
            {
                queueTime = DateTimeOffset.UtcNow.Subtract(message.EnqueuedTime);
                totalNewMessageCount = 1; // There's at least one if message != null. Default for connection string with no manage claim
            }

            if ((!isListeningOnDeadLetterQueue && activeMessageCount > 0) || (isListeningOnDeadLetterQueue && deadLetterCount > 0))
            {
                totalNewMessageCount = isListeningOnDeadLetterQueue ? deadLetterCount : activeMessageCount;
            }

            return new ServiceBusTriggerMetrics
            {
                MessageCount = totalNewMessageCount,
                PartitionCount = partitionCount,
                QueueTime = queueTime
            };
        }

        private static bool MessageIsActive(ServiceBusReceivedMessage message)
        {
            return message.State == ServiceBusMessageState.Active;
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

            if (metrics[0].QueueTime > TimeSpan.Zero && metrics[0].QueueTime < metrics[NumberOfSamplesToConsider - 1].QueueTime)
            {
                bool queueTimeIncreasing =
                    IsTrueForLastN(
                        metrics,
                        NumberOfSamplesToConsider,
                        (prev, next) => prev.QueueTime <= next.QueueTime);
                if (queueTimeIncreasing)
                {
                    status.Vote = ScaleVote.ScaleOut;
                    _logger.LogInformation($"Queue time is increasing for '{_entityPath}'.");
                    return status;
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

        private bool TimeToLogWarning()
        {
            DateTime currentTime = DateTime.UtcNow;
            bool timeToLog = currentTime >= _nextWarningTime;
            if (timeToLog)
            {
                _nextWarningTime = currentTime.AddHours(1);
            }
            return timeToLog;
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
