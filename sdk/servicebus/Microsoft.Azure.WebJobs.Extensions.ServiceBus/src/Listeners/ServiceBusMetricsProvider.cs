// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.ServiceBus.Listeners;
using Microsoft.Azure.WebJobs.ServiceBus;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config;

namespace Microsoft.Azure.WebJobs.Extensions.ServiceBus.Listeners
{
    internal class ServiceBusMetricsProvider
    {
        private const string DeadLetterQueuePath = @"/$DeadLetterQueue";

        private readonly ILogger _logger;
        private readonly string _entityPath;
        private readonly ServiceBusEntityType _serviceBusEntityType;
        private readonly Lazy<ServiceBusReceiver> _receiver;
        private readonly bool _isListeningOnDeadLetterQueue;
        private readonly Lazy<ServiceBusAdministrationClient> _administrationClient;

        private DateTime _nextWarningTime;

        public ServiceBusMetricsProvider(
            string entityPath,
            ServiceBusEntityType serviceBusEntityType,
            Lazy<ServiceBusReceiver> receiver,
            Lazy<ServiceBusAdministrationClient> administrationClient,
            ILoggerFactory loggerFactory)
        {
            _serviceBusEntityType = serviceBusEntityType;
            _receiver = receiver;
            _entityPath = entityPath;
            _isListeningOnDeadLetterQueue = entityPath.EndsWith(DeadLetterQueuePath, StringComparison.OrdinalIgnoreCase);
            _administrationClient = administrationClient;
            _logger = loggerFactory.CreateLogger<ServiceBusMetricsProvider>();
            _nextWarningTime = DateTime.UtcNow;
        }

        public async Task<long> GetMessageCountAsync()
        {
            long activeMessageCount = 0;
            long deadLetterCount = 0;
            string entityName = _serviceBusEntityType == ServiceBusEntityType.Queue ? "queue" : "topic";
            try
            {
                if (_serviceBusEntityType == ServiceBusEntityType.Queue)
                {
                    QueueRuntimeProperties queueRuntimeProperties = await _administrationClient.Value.GetQueueRuntimePropertiesAsync(_entityPath).ConfigureAwait(false);
                    activeMessageCount = queueRuntimeProperties.ActiveMessageCount;
                    deadLetterCount = queueRuntimeProperties.DeadLetterMessageCount;
                }
                else
                {
                    ServiceBusEntityPathHelper.ParseTopicAndSubscription(_entityPath, out string topicPath, out string subscriptionPath);

                    SubscriptionRuntimeProperties subscriptionProperties = await _administrationClient.Value.GetSubscriptionRuntimePropertiesAsync(topicPath, subscriptionPath).ConfigureAwait(false);
                    activeMessageCount = subscriptionProperties.ActiveMessageCount;
                    deadLetterCount = subscriptionProperties.DeadLetterMessageCount;
                }
            }
            catch (ServiceBusException ex)
            when (ex.Reason == ServiceBusFailureReason.MessagingEntityNotFound)
            {
                _logger.LogWarning($"ServiceBus {entityName} '{_entityPath}' was not found.");
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning($"Connection string does not have 'Manage Claim' for {entityName} '{_entityPath}'.Unable to determine active message count.", ex);
                throw ex;
            }
            catch (Exception e)
            {
                _logger.LogWarning($"Error querying for Service Bus {entityName} scale status: {e.Message}");
            }

            long totalNewMessageCount = 0;
            if ((!_isListeningOnDeadLetterQueue && activeMessageCount > 0) || (_isListeningOnDeadLetterQueue && deadLetterCount > 0))
            {
                totalNewMessageCount = _isListeningOnDeadLetterQueue ? deadLetterCount : activeMessageCount;
            }

            return totalNewMessageCount;
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
                else if (peekedMessage.State == ServiceBusMessageState.Active)
                {
                    activeMessage = peekedMessage;
                }
                else
                {
                    // Do another attempt to peek ten message from last peek sequence number
                    var peekedMessages = await _receiver.Value.PeekMessagesAsync(10, fromSequenceNumber: peekedMessage.SequenceNumber).ConfigureAwait(false);
                    foreach (var receivedMessage in peekedMessages)
                    {
                        if (receivedMessage.State == ServiceBusMessageState.Active)
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
            long activeMessageCount = 0;
            long deadLetterCount = 0;
            int partitionCount = 0;

            queueRuntimeProperties = await _administrationClient.Value.GetQueueRuntimePropertiesAsync(_entityPath).ConfigureAwait(false);
            activeMessageCount = queueRuntimeProperties.ActiveMessageCount;
            deadLetterCount = queueRuntimeProperties.DeadLetterMessageCount;

            // If partitioning is turned on, then Service Bus automatically partitions queues into 16 partitions
            // See more information here: https://docs.microsoft.com/azure/service-bus-messaging/service-bus-partitioning#standard
            queueProperties = await _administrationClient.Value.GetQueueAsync(_entityPath).ConfigureAwait(false);
            partitionCount = queueProperties.EnablePartitioning ? 16 : 0;

            return CreateTriggerMetrics(message, activeMessageCount, deadLetterCount, partitionCount, _isListeningOnDeadLetterQueue);
        }

        private async Task<ServiceBusTriggerMetrics> GetTopicMetricsAsync(ServiceBusReceivedMessage message)
        {
            TopicProperties topicProperties;
            SubscriptionRuntimeProperties subscriptionProperties;
            string topicPath, subscriptionPath;
            long activeMessageCount = 0;
            long deadLetterCount = 0;
            int partitionCount = 0;

            ServiceBusEntityPathHelper.ParseTopicAndSubscription(_entityPath, out topicPath, out subscriptionPath);

            subscriptionProperties = await _administrationClient.Value.GetSubscriptionRuntimePropertiesAsync(topicPath, subscriptionPath).ConfigureAwait(false);
            activeMessageCount = subscriptionProperties.ActiveMessageCount;
            deadLetterCount = subscriptionProperties.DeadLetterMessageCount;

            // If partitioning is turned on, then Service Bus automatically partitions queues into 16 partitions
            // See more information here: https://docs.microsoft.com/azure/service-bus-messaging/service-bus-partitioning#standard
            topicProperties = await _administrationClient.Value.GetTopicAsync(topicPath).ConfigureAwait(false);
            partitionCount = topicProperties.EnablePartitioning ? 16 : 0;

            return CreateTriggerMetrics(message, activeMessageCount, deadLetterCount, partitionCount, _isListeningOnDeadLetterQueue);
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
    }
}
