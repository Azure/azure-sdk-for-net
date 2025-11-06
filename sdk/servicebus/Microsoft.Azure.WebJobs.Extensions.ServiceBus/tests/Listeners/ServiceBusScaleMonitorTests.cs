// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Listeners;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.ServiceBus.Listeners;
using Microsoft.Azure.WebJobs.ServiceBus.Tests;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests.Listeners
{
    [NonParallelizable]
    [TestFixture(ServiceBusEntityType.Queue)]
    [TestFixture(ServiceBusEntityType.Topic)]
    public class ServiceBusScaleMonitorTests
    {
        private ServiceBusListener _listener;
        private ServiceBusScaleMonitor _scaleMonitor;
        private ServiceBusOptions _serviceBusOptions;
        private Mock<ITriggeredFunctionExecutor> _mockExecutor;
        private Mock<MessagingProvider> _mockProvider;
        private Mock<ServiceBusClientFactory> _mockClientFactory;
        private Mock<MessageProcessor> _mockMessageProcessor;
        private Mock<ServiceBusReceiver> _mockMessageReceiver;
        private TestLoggerProvider _loggerProvider;
        private LoggerFactory _loggerFactory;
        private string _functionId = "test-functionid";
        private string _queue = "test-queue";
        private string _topic = "test-topic";
        private string _subscription = "test-subscription";
        private string _entityPath;
        private string _testConnection = "Endpoint=sb://test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=";
        private string _connection = "connection";
        private ServiceBusClient _client;
        private Mock<ServiceBusAdministrationClient> _mockAdminClient;
        private readonly ServiceBusEntityType _entityType;
        private readonly string _entityTypeName;

        public ServiceBusScaleMonitorTests(ServiceBusEntityType entityType)
        {
            _entityType = entityType;
            _entityTypeName = entityType == ServiceBusEntityType.Queue ? "queue" : "topic";
            _entityPath = _entityType == ServiceBusEntityType.Queue ? _queue : EntityNameFormatter.FormatSubscriptionPath(_topic, _subscription);
        }

        [SetUp]
        public void Setup()
        {
            _mockExecutor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            _client = new ServiceBusClient(_testConnection);
            ServiceBusProcessorOptions processorOptions = new ServiceBusProcessorOptions();
            ServiceBusProcessor messageProcessor = _client.CreateProcessor(_entityPath);

            _mockAdminClient = new Mock<ServiceBusAdministrationClient>(MockBehavior.Strict);

            _mockMessageProcessor = new Mock<MessageProcessor>(MockBehavior.Strict, messageProcessor);
            var configuration = ConfigurationUtilities.CreateConfiguration(new KeyValuePair<string, string>(_connection, _testConnection));

            _serviceBusOptions = new ServiceBusOptions();
            _mockProvider = new Mock<MessagingProvider>(new OptionsWrapper<ServiceBusOptions>(_serviceBusOptions));
            _mockClientFactory = new Mock<ServiceBusClientFactory>(
                configuration,
                 Mock.Of<AzureComponentFactory>(),
                _mockProvider.Object,
                new AzureEventSourceLogForwarder(new NullLoggerFactory()),
                new OptionsWrapper<ServiceBusOptions>(_serviceBusOptions));

            _mockMessageReceiver = new Mock<ServiceBusReceiver>();

            _mockProvider
                .Setup(p => p.CreateMessageProcessor(_client, _entityPath, It.IsAny<ServiceBusProcessorOptions>()))
                .Returns(_mockMessageProcessor.Object);

            _mockProvider
                .Setup(p => p.CreateClient(_testConnection, It.IsAny<ServiceBusClientOptions>()))
                .Returns(_client);

            _mockProvider
                .Setup(p => p.CreateBatchMessageReceiver(_client, _entityPath, It.IsAny<ServiceBusReceiverOptions>()))
                .Returns(_mockMessageReceiver.Object);

            _mockClientFactory.Setup(p => p.CreateAdministrationClient(_connection))
                .Returns(_mockAdminClient.Object);

            _loggerFactory = new LoggerFactory();
            _loggerProvider = new TestLoggerProvider();
            _loggerFactory.AddProvider(_loggerProvider);

            var concurrencyOptions = new OptionsWrapper<ConcurrencyOptions>(new ConcurrencyOptions());
            var mockConcurrencyThrottleManager = new Mock<IConcurrencyThrottleManager>(MockBehavior.Strict);
            var concurrencyManager = new ConcurrencyManager(concurrencyOptions, _loggerFactory, mockConcurrencyThrottleManager.Object);

            _listener = new ServiceBusListener(
                _functionId,
                _entityType,
                _entityPath,
                false,
                _serviceBusOptions.AutoCompleteMessages,
                _serviceBusOptions.MaxMessageBatchSize,
                _mockExecutor.Object,
                _serviceBusOptions,
                _connection,
                _mockProvider.Object,
                _loggerFactory,
                false,
                _mockClientFactory.Object,
                concurrencyManager,
                default);

            _scaleMonitor = (ServiceBusScaleMonitor)_listener.GetMonitor();
        }

        [Test]
        public void ScaleMonitorDescriptor_ReturnsExpectedValue()
        {
            Assert.AreEqual($"{_functionId}-ServiceBusTrigger-{_entityPath}".ToLower(), _scaleMonitor.Descriptor.Id);
        }

        [Test]
        public async Task GetMetrics_IgnoresScheduledMessages()
        {
            var scheduledMessage = ServiceBusModelFactory.ServiceBusReceivedMessage(serviceBusMessageState: ServiceBusMessageState.Scheduled);

            var anotherScheduledMessage = ServiceBusModelFactory.ServiceBusReceivedMessage(serviceBusMessageState: ServiceBusMessageState.Scheduled);

            _mockMessageReceiver.Setup(x => x.PeekMessageAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(scheduledMessage);

            _mockMessageReceiver.Setup(x => x.PeekMessagesAsync(It.IsAny<int>(), It.IsAny<long>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<ServiceBusReceivedMessage> { anotherScheduledMessage });

            ServiceBusListener listener = CreateListener();

            var metrics = await ((ServiceBusScaleMonitor)listener.GetMonitor()).GetMetricsAsync();

            Assert.AreEqual(0, metrics.PartitionCount);
            Assert.AreEqual(0, metrics.MessageCount);
            Assert.AreEqual(TimeSpan.FromSeconds(0), metrics.QueueTime);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);
        }

        [Test]
        public async Task GetMetrics_IgnoresDeferredMessages()
        {
            var deferredMessage = ServiceBusModelFactory.ServiceBusReceivedMessage(serviceBusMessageState: ServiceBusMessageState.Deferred);
            var anotherDeferredMessage = ServiceBusModelFactory.ServiceBusReceivedMessage(serviceBusMessageState: ServiceBusMessageState.Deferred);

            _mockMessageReceiver.Setup(x => x.PeekMessageAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(deferredMessage);

            _mockMessageReceiver.Setup(x => x.PeekMessagesAsync(It.IsAny<int>(), It.IsAny<long>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<ServiceBusReceivedMessage> { anotherDeferredMessage });

            ServiceBusListener listener = CreateListener();

            var metrics = await ((ServiceBusScaleMonitor)listener.GetMonitor()).GetMetricsAsync();

            Assert.AreEqual(0, metrics.PartitionCount);
            Assert.AreEqual(0, metrics.MessageCount);
            Assert.AreEqual(TimeSpan.FromSeconds(0), metrics.QueueTime);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);
        }

        [Test]
        public async Task GetMetrics_DoesNotPeekBatchesWhenFirstAttemptReturnsActive()
        {
            var activeMessage = ServiceBusModelFactory.ServiceBusReceivedMessage(enqueuedTime: DateTimeOffset.UtcNow.Subtract(TimeSpan.FromSeconds(30)), sequenceNumber: 2);

            _mockMessageReceiver.Setup(x => x.PeekMessageAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(activeMessage);

            _mockMessageReceiver.Verify(x => x.PeekMessagesAsync(It.IsAny<int>(), It.IsAny<long>(), It.IsAny<CancellationToken>()), Times.Never);

            ServiceBusListener listener = CreateListener();

            var metrics = await ((ServiceBusScaleMonitor)listener.GetMonitor()).GetMetricsAsync();

            Assert.AreEqual(0, metrics.PartitionCount);
            Assert.AreEqual(1, metrics.MessageCount);
            Assert.That(metrics.QueueTime, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(30)));
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);
        }

        [Test]
        public async Task GetMetrics_DoesNotPeekBatchesWhenFirstAttemptReturnsNull()
        {
            _mockMessageReceiver.Setup(x => x.PeekMessageAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => null);

            _mockMessageReceiver.Verify(x => x.PeekMessagesAsync(It.IsAny<int>(), It.IsAny<long>(), It.IsAny<CancellationToken>()), Times.Never);

            ServiceBusListener listener = CreateListener();

            var metrics = await ((ServiceBusScaleMonitor)listener.GetMonitor()).GetMetricsAsync();

            Assert.AreEqual(0, metrics.PartitionCount);
            Assert.AreEqual(0, metrics.MessageCount);
            Assert.AreEqual(TimeSpan.FromSeconds(0), metrics.QueueTime);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);
        }

        [Test]
        public async Task GetMetrics_IgnoresEmptyBatch()
        {
            var deferredMessage = ServiceBusModelFactory.ServiceBusReceivedMessage(serviceBusMessageState: ServiceBusMessageState.Deferred);

            _mockMessageReceiver.Setup(x => x.PeekMessageAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(deferredMessage);

            _mockMessageReceiver.Setup(x => x.PeekMessagesAsync(It.IsAny<int>(), It.IsAny<long>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<ServiceBusReceivedMessage>());

            ServiceBusListener listener = CreateListener();

            var metrics = await ((ServiceBusScaleMonitor)listener.GetMonitor()).GetMetricsAsync();

            Assert.AreEqual(0, metrics.PartitionCount);
            Assert.AreEqual(0, metrics.MessageCount);
            Assert.AreEqual(TimeSpan.FromSeconds(0), metrics.QueueTime);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);
        }

        [Test]
        public async Task GetMetrics_UseSequenceNumberToRetrieveBatches()
        {
            var deferredMessage = ServiceBusModelFactory.ServiceBusReceivedMessage(sequenceNumber: 12, serviceBusMessageState: ServiceBusMessageState.Deferred);
            var activeMessage = ServiceBusModelFactory.ServiceBusReceivedMessage(enqueuedTime: DateTimeOffset.UtcNow.Subtract(TimeSpan.FromSeconds(30)), sequenceNumber: 2);

            _mockMessageReceiver.Setup(x => x.PeekMessageAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(deferredMessage);

            _mockMessageReceiver.Setup(x => x.PeekMessagesAsync(It.IsAny<int>(), 12, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<ServiceBusReceivedMessage> { activeMessage });

            ServiceBusListener listener = CreateListener();

            var metrics = await ((ServiceBusScaleMonitor)listener.GetMonitor()).GetMetricsAsync();

            Assert.AreEqual(0, metrics.PartitionCount);
            Assert.AreEqual(1, metrics.MessageCount);
            Assert.That(metrics.QueueTime, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(30)));
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);
        }

        [Test]
        public async Task GetMetrics_PeeksOneFromHeadAndTenWithBatching()
        {
            var deferredMessage = ServiceBusModelFactory.ServiceBusReceivedMessage(serviceBusMessageState: ServiceBusMessageState.Deferred);
            var activeMessage = ServiceBusModelFactory.ServiceBusReceivedMessage(enqueuedTime: DateTimeOffset.UtcNow.Subtract(TimeSpan.FromSeconds(30)), sequenceNumber: 2);

            _mockMessageReceiver.Setup(x => x.PeekMessageAsync(0, It.IsAny<CancellationToken>()))
                .ReturnsAsync(deferredMessage);

            _mockMessageReceiver.Setup(x => x.PeekMessagesAsync(10, It.IsAny<long>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<ServiceBusReceivedMessage> { activeMessage, activeMessage });

            ServiceBusListener listener = CreateListener();

            var metrics = await ((ServiceBusScaleMonitor)listener.GetMonitor()).GetMetricsAsync();

            Assert.AreEqual(0, metrics.PartitionCount);
            Assert.AreEqual(1, metrics.MessageCount);
            Assert.That(metrics.QueueTime, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(30)));
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);
        }

        [Test]
        public async Task GetMetrics_IgnoresDeferredOrScheduledMessagesUntilItFindsAnActive()
        {
            var firstDeferredMessage = ServiceBusModelFactory.ServiceBusReceivedMessage(serviceBusMessageState: ServiceBusMessageState.Deferred);
            var secondScheduledMessage = ServiceBusModelFactory.ServiceBusReceivedMessage(serviceBusMessageState: ServiceBusMessageState.Scheduled);
            var activeMessage = ServiceBusModelFactory.ServiceBusReceivedMessage(enqueuedTime: DateTimeOffset.UtcNow.Subtract(TimeSpan.FromSeconds(30)), sequenceNumber: 2);

            _mockMessageReceiver.Setup(x => x.PeekMessageAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(firstDeferredMessage);

            _mockMessageReceiver.Setup(x => x.PeekMessagesAsync(It.IsAny<int>(), It.IsAny<long>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<ServiceBusReceivedMessage> { secondScheduledMessage, activeMessage });

            ServiceBusListener listener = CreateListener();

            var serviceBusScaleMonitor = (ServiceBusScaleMonitor)listener.GetMonitor();
            var metrics = await serviceBusScaleMonitor.GetMetricsAsync();

            Assert.AreEqual(0, metrics.PartitionCount);
            Assert.AreEqual(1, metrics.MessageCount);
            Assert.That(metrics.QueueTime, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(30)));
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);
        }

        [Test]
        public async Task GetMetrics_GiveUpAfterFirstAndBatchPeekDoesntReturnActive()
        {
            var firstDeferredMessage = ServiceBusModelFactory.ServiceBusReceivedMessage(serviceBusMessageState: ServiceBusMessageState.Deferred);

            _mockMessageReceiver.Setup(x => x.PeekMessageAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(firstDeferredMessage);

            _mockMessageReceiver.Setup(x => x.PeekMessagesAsync(It.IsAny<int>(), It.IsAny<long>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((int batchSize, long _, CancellationToken __) => Enumerable.Range(1, batchSize)
                    .Select(i => ServiceBusModelFactory.ServiceBusReceivedMessage(serviceBusMessageState: ServiceBusMessageState.Scheduled))
                    .ToList());

            ServiceBusListener listener = CreateListener();

            var serviceBusScaleMonitor = (ServiceBusScaleMonitor)listener.GetMonitor();
            var metrics = await serviceBusScaleMonitor.GetMetricsAsync();

            Assert.AreEqual(0, metrics.PartitionCount);
            Assert.AreEqual(0, metrics.MessageCount);
            Assert.AreEqual(TimeSpan.FromSeconds(0), metrics.QueueTime);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);
        }

        [Test]
        public async Task GetMetrics_CalculatesMetrics()
        {
            var message = ServiceBusModelFactory.ServiceBusReceivedMessage(enqueuedTime: DateTimeOffset.UtcNow.Subtract(TimeSpan.FromSeconds(30)));

            _mockMessageReceiver.Setup(x => x.PeekMessageAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(message);

            ServiceBusListener listener = CreateListener();

            var metrics = await ((ServiceBusScaleMonitor)listener.GetMonitor()).GetMetricsAsync();

            Assert.AreEqual(0, metrics.PartitionCount);
            Assert.AreEqual(1, metrics.MessageCount);
            Assert.That(metrics.QueueTime, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(30)));
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);
        }

        [Test]
        public async Task GetMetrics_CalculatesMetrics_UsingRuntimeInformation()
        {
            var message = ServiceBusModelFactory.ServiceBusReceivedMessage(enqueuedTime: DateTimeOffset.UtcNow.Subtract(TimeSpan.FromSeconds(30)));

            _mockMessageReceiver.Setup(x => x.PeekMessageAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(message);

            if (_entityType == ServiceBusEntityType.Queue)
            {
                _mockAdminClient.Setup(x => x.GetQueueRuntimePropertiesAsync(_entityPath, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(Response.FromValue(ServiceBusModelFactory.QueueRuntimeProperties(_entityPath, activeMessageCount: 10, deadLetterMessageCount: 5), new MockResponse(200)))
                    .Verifiable();
                _mockAdminClient.Setup(x => x.GetQueueAsync(_entityPath, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(Response.FromValue(
                        ServiceBusModelFactory.QueueProperties(
                            _entityPath,
                            maxDeliveryCount: 10,
                            lockDuration: TimeSpan.FromSeconds(30),
                            autoDeleteOnIdle: TimeSpan.FromMinutes(5),
                            duplicateDetectionHistoryTimeWindow: TimeSpan.FromSeconds(20),
                            defaultMessageTimeToLive: TimeSpan.FromSeconds(30),
                            userMetadata: "data"),
                        new MockResponse(200)))
                    .Verifiable();
            }
            else
            {
                _mockAdminClient.Setup(x => x.GetSubscriptionRuntimePropertiesAsync(_topic, _subscription, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(Response.FromValue(ServiceBusModelFactory.SubscriptionRuntimeProperties(_topic, _subscription, activeMessageCount: 10, deadLetterMessageCount: 5), new MockResponse(200)))
                    .Verifiable();
                _mockAdminClient.Setup(x => x.GetTopicAsync(_topic, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(Response.FromValue(
                        ServiceBusModelFactory.TopicProperties(
                            _topic,
                            defaultMessageTimeToLive: TimeSpan.FromMinutes(5),
                            autoDeleteOnIdle: TimeSpan.FromMinutes(5),
                            duplicateDetectionHistoryTimeWindow: TimeSpan.FromMinutes(5)),
                        new MockResponse(200)))
                    .Verifiable();
            }
            ServiceBusListener listener = CreateListener();

            var metrics = await ((ServiceBusScaleMonitor)listener.GetMonitor()).GetMetricsAsync();

            _mockAdminClient.VerifyAll();

            Assert.AreEqual(0, metrics.PartitionCount);
            Assert.AreEqual(10, metrics.MessageCount);
            Assert.That(metrics.QueueTime, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(30)));
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);
        }

        [Test]
        public async Task GetMetrics_CalculatesMetrics_UsingRuntimeInformation_UsingDLQ()
        {
            var message = ServiceBusModelFactory.ServiceBusReceivedMessage(enqueuedTime: DateTimeOffset.UtcNow.Subtract(TimeSpan.FromSeconds(30)));

            _mockMessageReceiver.Setup(x => x.PeekMessageAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(message);

            if (_entityType == ServiceBusEntityType.Queue)
            {
                _mockAdminClient.Setup(x => x.GetQueueRuntimePropertiesAsync(_entityPath, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(Response.FromValue(ServiceBusModelFactory.QueueRuntimeProperties(_entityPath, activeMessageCount: 10, deadLetterMessageCount: 5), new MockResponse(200)))
                    .Verifiable();
                _mockAdminClient.Setup(x => x.GetQueueAsync(_entityPath, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(Response.FromValue(
                        ServiceBusModelFactory.QueueProperties(
                            _entityPath,
                            maxDeliveryCount: 10,
                            lockDuration: TimeSpan.FromSeconds(30),
                            autoDeleteOnIdle: TimeSpan.FromMinutes(5),
                            duplicateDetectionHistoryTimeWindow: TimeSpan.FromSeconds(20),
                            defaultMessageTimeToLive: TimeSpan.FromSeconds(30),
                            userMetadata: "data"), new MockResponse(200)))
                    .Verifiable();
            }
            else
            {
                _mockAdminClient.Setup(x => x.GetSubscriptionRuntimePropertiesAsync(_topic, _subscription, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(Response.FromValue(ServiceBusModelFactory.SubscriptionRuntimeProperties(_topic, _subscription, activeMessageCount: 10, deadLetterMessageCount: 5), new MockResponse(200)))
                    .Verifiable();
                _mockAdminClient.Setup(x => x.GetTopicAsync(_topic, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(Response.FromValue(
                        ServiceBusModelFactory.TopicProperties(
                            _topic,
                            defaultMessageTimeToLive: TimeSpan.FromMinutes(5),
                            autoDeleteOnIdle: TimeSpan.FromMinutes(5),
                            duplicateDetectionHistoryTimeWindow: TimeSpan.FromMinutes(5)),
                        new MockResponse(200)))
                    .Verifiable();
            }

            ServiceBusListener listener = CreateListener(useDeadletterQueue: true);

            var metrics = await ((ServiceBusScaleMonitor)listener.GetMonitor()).GetMetricsAsync();

            _mockAdminClient.VerifyAll();

            Assert.AreEqual(0, metrics.PartitionCount);
            Assert.AreEqual(5, metrics.MessageCount);
            Assert.That(metrics.QueueTime, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(30)));
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);
        }

        [Test]
        public async Task GetMetrics_HandlesExceptions()
        {
            // MessagingEntityNotFoundException
            _mockProvider
                .Setup(p => p.CreateBatchMessageReceiver(_client, _entityPath, It.IsAny<ServiceBusReceiverOptions>()))
                .Throws(new ServiceBusException("", reason: ServiceBusFailureReason.MessagingEntityNotFound));

            ServiceBusListener listener = CreateListener();
            var notFoundException = Assert.ThrowsAsync<ServiceBusException>(async () =>
                await ((ServiceBusScaleMonitor)listener.GetMonitor()).GetMetricsAsync());
            Assert.AreEqual(ServiceBusFailureReason.MessagingEntityNotFound, notFoundException.Reason);

            _loggerProvider.ClearAllLogMessages();

            // UnauthorizedAccessException
            _mockProvider
                .Setup(p => p.CreateBatchMessageReceiver(_client, _entityPath, It.IsAny<ServiceBusReceiverOptions>()))
                .Throws(new UnauthorizedAccessException(""));
            listener = CreateListener();

            var metrics = await ((ServiceBusScaleMonitor)listener.GetMonitor()).GetMetricsAsync();

            Assert.AreEqual(0, metrics.PartitionCount);
            Assert.AreEqual(0, metrics.MessageCount);
            Assert.AreEqual(TimeSpan.FromSeconds(0), metrics.QueueTime);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            var warning = _loggerProvider.GetAllLogMessages().Single(p => p.Level == LogLevel.Warning);
            Assert.AreEqual($"Connection string does not have Manage claim for {_entityTypeName} '{_entityPath}'. Failed to get {_entityTypeName} description to derive {_entityTypeName} length metrics. " +
                        $"Falling back to using first message enqueued time.",
                        warning.FormattedMessage);
            _loggerProvider.ClearAllLogMessages();

            // Generic Exception
            _mockProvider
                .Setup(p => p.CreateBatchMessageReceiver(_client, _entityPath, It.IsAny<ServiceBusReceiverOptions>()))
                .Throws(new Exception("Uh oh"));
            listener = CreateListener();

            var genericException = Assert.ThrowsAsync<Exception>(async () =>
                await ((ServiceBusScaleMonitor)listener.GetMonitor()).GetMetricsAsync());
            Assert.AreEqual("Uh oh", genericException.Message);
        }

        private ServiceBusListener CreateListener(bool useDeadletterQueue = false)
        {
            var concurrencyOptions = new OptionsWrapper<ConcurrencyOptions>(new ConcurrencyOptions());
            var mockConcurrencyThrottleManager = new Mock<IConcurrencyThrottleManager>(MockBehavior.Strict);
            var concurrencyManager = new ConcurrencyManager(concurrencyOptions, _loggerFactory, mockConcurrencyThrottleManager.Object);
            string entityPath = _entityPath;

            if (useDeadletterQueue)
            {
                entityPath = EntityNameFormatter.FormatDeadLetterPath(entityPath);
                _mockProvider
                    .Setup(p => p.CreateMessageProcessor(_client, entityPath, It.IsAny<ServiceBusProcessorOptions>()))
                    .Returns(_mockMessageProcessor.Object);
                _mockProvider
                    .Setup(p => p.CreateBatchMessageReceiver(_client, entityPath, It.IsAny<ServiceBusReceiverOptions>()))
                    .Returns(_mockMessageReceiver.Object);
            }

            return new ServiceBusListener(
                _functionId,
                _entityType,
                entityPath,
                false,
                _serviceBusOptions.AutoCompleteMessages,
                _serviceBusOptions.MaxMessageBatchSize,
                _mockExecutor.Object,
                _serviceBusOptions,
                _connection,
                _mockProvider.Object,
                _loggerFactory,
                false,
                _mockClientFactory.Object,
                concurrencyManager,
                default);
        }

        [Test]
        public void GetScaleStatus_NoMetrics_ReturnsVote_None()
        {
            var context = new ScaleStatusContext<ServiceBusTriggerMetrics>
            {
                WorkerCount = 1
            };

            var status = _scaleMonitor.GetScaleStatus(context);
            Assert.AreEqual(ScaleVote.None, status.Vote);

            // verify the non-generic implementation works properly
            status = ((IScaleMonitor)_scaleMonitor).GetScaleStatus(context);
            Assert.AreEqual(ScaleVote.None, status.Vote);
        }

        [Test]
        public void GetScaleStatus_InstancesPerPartitionThresholdExceeded_ReturnsVote_ScaleIn()
        {
            var context = new ScaleStatusContext<ServiceBusTriggerMetrics>
            {
                WorkerCount = 17
            };
            var timestamp = DateTime.UtcNow;
            var serviceBusTriggerMetrics = new List<ServiceBusTriggerMetrics>
                {
                    new ServiceBusTriggerMetrics { MessageCount = 2500, PartitionCount = 16, QueueTime = TimeSpan.FromSeconds(15), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 2505, PartitionCount = 16, QueueTime = TimeSpan.FromSeconds(15), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 2612, PartitionCount = 16, QueueTime = TimeSpan.FromSeconds(15), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 2700, PartitionCount = 16, QueueTime = TimeSpan.FromSeconds(15), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 2810, PartitionCount = 16, QueueTime = TimeSpan.FromSeconds(15), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 2900, PartitionCount = 16, QueueTime = TimeSpan.FromSeconds(15), Timestamp = timestamp.AddSeconds(15) },
                };
            context.Metrics = serviceBusTriggerMetrics;

            var status = _scaleMonitor.GetScaleStatus(context);
            Assert.AreEqual(ScaleVote.ScaleIn, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.AreEqual(LogLevel.Information, log.Level);
            Assert.AreEqual("WorkerCount (17) > PartitionCount (16).", log.FormattedMessage);
            log = logs[1];
            Assert.AreEqual(LogLevel.Information, log.Level);
            Assert.AreEqual($"Number of instances (17) is too high relative to number of partitions for Service Bus entity ({_entityPath}, 16).", log.FormattedMessage);

            // verify again with a non generic context instance
            var context2 = new ScaleStatusContext
            {
                WorkerCount = 1,
                Metrics = serviceBusTriggerMetrics
            };
            status = ((IScaleMonitor)_scaleMonitor).GetScaleStatus(context2);
            Assert.AreEqual(ScaleVote.ScaleOut, status.Vote);
        }

        [Test]
        public void GetScaleStatus_MessagesPerWorkerThresholdExceeded_ReturnsVote_ScaleOut()
        {
            var context = new ScaleStatusContext<ServiceBusTriggerMetrics>
            {
                WorkerCount = 1
            };
            var timestamp = DateTime.UtcNow;
            var serviceBusTriggerMetrics = new List<ServiceBusTriggerMetrics>
                {
                    new ServiceBusTriggerMetrics { MessageCount = 2500, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 2505, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 2612, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 2700, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 2810, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 2900, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
                };
            context.Metrics = serviceBusTriggerMetrics;

            var status = _scaleMonitor.GetScaleStatus(context);
            Assert.AreEqual(ScaleVote.ScaleOut, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.AreEqual(LogLevel.Information, log.Level);
            Assert.AreEqual("MessageCount (2900) > WorkerCount (1) * 1,000.", log.FormattedMessage);
            log = logs[1];
            Assert.AreEqual(LogLevel.Information, log.Level);
            Assert.AreEqual($"Message count for Service Bus Entity ({_entityPath}, 2900) " +
                         $"is too high relative to the number of instances (1).", log.FormattedMessage);

            // verify again with a non generic context instance
            var context2 = new ScaleStatusContext
            {
                WorkerCount = 1,
                Metrics = serviceBusTriggerMetrics
            };
            status = ((IScaleMonitor)_scaleMonitor).GetScaleStatus(context2);
            Assert.AreEqual(ScaleVote.ScaleOut, status.Vote);
        }

        [Test]
        public void GetScaleStatus_QueueLengthIncreasing_ReturnsVote_ScaleOut()
        {
            var context = new ScaleStatusContext<ServiceBusTriggerMetrics>
            {
                WorkerCount = 1
            };
            var timestamp = DateTime.UtcNow;
            context.Metrics = new List<ServiceBusTriggerMetrics>
                {
                    new ServiceBusTriggerMetrics { MessageCount = 10, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 20, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 40, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 80, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 150, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
                };

            var status = _scaleMonitor.GetScaleStatus(context);
            Assert.AreEqual(ScaleVote.ScaleOut, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.AreEqual(LogLevel.Information, log.Level);
            Assert.AreEqual($"Message count is increasing for '{_entityPath}'.", log.FormattedMessage);
        }

        [Test]
        public void GetScaleStatus_QueueTimeIncreasing_ReturnsVote_ScaleOut()
        {
            var context = new ScaleStatusContext<ServiceBusTriggerMetrics>
            {
                WorkerCount = 1
            };
            var timestamp = DateTime.UtcNow;
            context.Metrics = new List<ServiceBusTriggerMetrics>
                {
                    new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(2), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(3), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(4), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(5), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(6), Timestamp = timestamp.AddSeconds(15) },
                };

            var status = _scaleMonitor.GetScaleStatus(context);
            Assert.AreEqual(ScaleVote.ScaleOut, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.AreEqual(LogLevel.Information, log.Level);
            Assert.AreEqual($"Queue time is increasing for '{_entityPath}'.", log.FormattedMessage);
        }

        [Test]
        public void GetScaleStatus_QueueTimeIncreasingLessThanMinimumWaitTime_ReturnsScaleVoteNone()
        {
            var context = new ScaleStatusContext<ServiceBusTriggerMetrics>
            {
                WorkerCount = 1
            };
            var timestamp = DateTime.UtcNow;
            var lastQueueTime = 0.5;
            context.Metrics = new List<ServiceBusTriggerMetrics>
                {
                    new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0.1), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0.2), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0.3), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0.4), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(lastQueueTime), Timestamp = timestamp.AddSeconds(15) },
                };

            var status = _scaleMonitor.GetScaleStatus(context);
            Assert.AreEqual(ScaleVote.None, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.AreEqual(LogLevel.Information, log.Level);
            Assert.AreEqual($"Queue time is increasing for '{_entityPath}' but we do not scale out unless queue latency is greater than {ServiceBusScaleMonitor.MinimumLastQueueMessageInSecondsThreshold.TotalSeconds}s. Current queue latency is {lastQueueTime}s.", log.FormattedMessage);
        }

        [Test]
        public void GetScaleStatus_QueueLengthDecreasing_ReturnsVote_ScaleIn()
        {
            var context = new ScaleStatusContext<ServiceBusTriggerMetrics>
            {
                WorkerCount = 1
            };
            var timestamp = DateTime.UtcNow;
            context.Metrics = new List<ServiceBusTriggerMetrics>
                {
                    new ServiceBusTriggerMetrics { MessageCount = 150, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 80, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 40, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 20, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 10, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
                };

            var status = _scaleMonitor.GetScaleStatus(context);
            Assert.AreEqual(ScaleVote.ScaleIn, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.AreEqual(LogLevel.Information, log.Level);
            Assert.AreEqual($"Message count is decreasing for '{_entityPath}'.", log.FormattedMessage);
        }

        [Test]
        public void GetScaleStatus_QueueTimeDecreasing_ReturnsVote_ScaleIn()
        {
            var context = new ScaleStatusContext<ServiceBusTriggerMetrics>
            {
                WorkerCount = 1
            };
            var timestamp = DateTime.UtcNow;
            context.Metrics = new List<ServiceBusTriggerMetrics>
                {
                    new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(6), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(5), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(4), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(3), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(2), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                };

            var status = _scaleMonitor.GetScaleStatus(context);
            Assert.AreEqual(ScaleVote.ScaleIn, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.AreEqual(LogLevel.Information, log.Level);
            Assert.AreEqual($"Queue time is decreasing for '{_entityPath}'.", log.FormattedMessage);
        }

        [Test]
        public void GetScaleStatus_QueueSteady_ReturnsVote_None()
        {
            var context = new ScaleStatusContext<ServiceBusTriggerMetrics>
            {
                WorkerCount = 2
            };
            var timestamp = DateTime.UtcNow;
            context.Metrics = new List<ServiceBusTriggerMetrics>
                {
                    new ServiceBusTriggerMetrics { MessageCount = 1500, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 1600, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 1400, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 1300, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 1700, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 1600, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                };

            var status = _scaleMonitor.GetScaleStatus(context);
            Assert.AreEqual(ScaleVote.None, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.AreEqual(LogLevel.Information, log.Level);
            Assert.AreEqual($"Service Bus entity '{_entityPath}' is steady.", log.FormattedMessage);
        }

        [Test]
        public void GetScaleStatus_QueueIdle_ReturnsVote_ScaleIn()
        {
            var context = new ScaleStatusContext<ServiceBusTriggerMetrics>
            {
                WorkerCount = 3
            };
            var timestamp = DateTime.UtcNow;
            context.Metrics = new List<ServiceBusTriggerMetrics>
                {
                    new ServiceBusTriggerMetrics { MessageCount = 0, PartitionCount = 0, QueueTime = TimeSpan.Zero, Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 0, PartitionCount = 0, QueueTime = TimeSpan.Zero, Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 0, PartitionCount = 0, QueueTime = TimeSpan.Zero, Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 0, PartitionCount = 0, QueueTime = TimeSpan.Zero, Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 0, PartitionCount = 0, QueueTime = TimeSpan.Zero, Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 0, PartitionCount = 0, QueueTime = TimeSpan.Zero, Timestamp = timestamp.AddSeconds(15) },
                };

            var status = _scaleMonitor.GetScaleStatus(context);
            Assert.AreEqual(ScaleVote.ScaleIn, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.AreEqual(LogLevel.Information, log.Level);
            Assert.AreEqual($"'{_entityPath}' is idle.", log.FormattedMessage);
        }

        [Test]
        public void GetScaleStatus_UnderSampleCountThreshold_ReturnsVote_None()
        {
            var context = new ScaleStatusContext<ServiceBusTriggerMetrics>
            {
                WorkerCount = 1
            };
            var timestamp = DateTime.UtcNow;
            context.Metrics = new List<ServiceBusTriggerMetrics>
                {
                    new ServiceBusTriggerMetrics { MessageCount = 5, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                    new ServiceBusTriggerMetrics { MessageCount = 10, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) }
                };

            var status = _scaleMonitor.GetScaleStatus(context);
            Assert.AreEqual(ScaleVote.None, status.Vote);
        }
    }
}
