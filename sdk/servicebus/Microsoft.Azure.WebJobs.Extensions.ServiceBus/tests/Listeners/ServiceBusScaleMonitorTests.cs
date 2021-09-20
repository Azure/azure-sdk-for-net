// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config;
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
    public class ServiceBusScaleMonitorTests
    {
        private ServiceBusListener _listener;
        private ServiceBusScaleMonitor _scaleMonitor;
        private ServiceBusOptions _serviceBusOptions;
        private Mock<ITriggeredFunctionExecutor> _mockExecutor;
        private Mock<MessagingProvider> _mockProvider;
        private Mock<ServiceBusClientFactory> _mockClientFactory;
        private Mock<MessageProcessor> _mockMessageProcessor;
        private TestLoggerProvider _loggerProvider;
        private LoggerFactory _loggerFactory;
        private string _functionId = "test-functionid";
        private string _entityPath = "test-entity-path";
        private string _testConnection = "Endpoint=sb://test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=";
        private string _connection = "connection";
        private ServiceBusClient _client;

        [SetUp]
        public void Setup()
        {
            _mockExecutor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            _client = new ServiceBusClient(_testConnection);
            ServiceBusProcessorOptions processorOptions = new ServiceBusProcessorOptions();
            ServiceBusProcessor messageProcessor = _client.CreateProcessor(_entityPath);
            ServiceBusReceiver receiver = _client.CreateReceiver(_entityPath);
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

            _mockProvider
                .Setup(p => p.CreateMessageProcessor(_client, _entityPath, It.IsAny<ServiceBusProcessorOptions>()))
                .Returns(_mockMessageProcessor.Object);

            _mockProvider
                .Setup(p => p.CreateClient(_testConnection, It.IsAny<ServiceBusClientOptions>()))
                .Returns(_client);

            _loggerFactory = new LoggerFactory();
            _loggerProvider = new TestLoggerProvider();
            _loggerFactory.AddProvider(_loggerProvider);

            var concurrencyOptions = new OptionsWrapper<ConcurrencyOptions>(new ConcurrencyOptions());
            var mockConcurrencyThrottleManager = new Mock<IConcurrencyThrottleManager>(MockBehavior.Strict);
            var concurrencyManager = new ConcurrencyManager(concurrencyOptions, _loggerFactory, mockConcurrencyThrottleManager.Object);

            _listener = new ServiceBusListener(
                _functionId,
                ServiceBusEntityType.Queue,
                _entityPath,
                false,
                _serviceBusOptions.AutoCompleteMessages,
                _mockExecutor.Object,
                _serviceBusOptions,
                _connection,
                _mockProvider.Object,
                _loggerFactory,
                false,
                _mockClientFactory.Object,
                concurrencyManager);

            _scaleMonitor = (ServiceBusScaleMonitor)_listener.GetMonitor();
        }

        [Test]
        public void ScaleMonitorDescriptor_ReturnsExpectedValue()
        {
            Assert.AreEqual($"{_functionId}-ServiceBusTrigger-{_entityPath}".ToLower(), _scaleMonitor.Descriptor.Id);
        }

        [Test]
        public void GetMetrics_ReturnsExpectedResult()
        {
            // Unable to test QueueTime because of restrictions on creating Message objects

            // Test base case
            var metrics = ServiceBusScaleMonitor.CreateTriggerMetrics(null, 0, 0, 0, false);

            Assert.AreEqual(0, metrics.PartitionCount);
            Assert.AreEqual(0, metrics.MessageCount);
            Assert.AreEqual(TimeSpan.FromSeconds(0), metrics.QueueTime);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // Test messages on main queue
            metrics = ServiceBusScaleMonitor.CreateTriggerMetrics(null, 10, 0, 0, false);

            Assert.AreEqual(0, metrics.PartitionCount);
            Assert.AreEqual(10, metrics.MessageCount);
            Assert.AreEqual(TimeSpan.FromSeconds(0), metrics.QueueTime);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // Test listening on dead letter queue
            metrics = ServiceBusScaleMonitor.CreateTriggerMetrics(null, 10, 100, 0, true);

            Assert.AreEqual(0, metrics.PartitionCount);
            Assert.AreEqual(100, metrics.MessageCount);
            Assert.AreEqual(TimeSpan.FromSeconds(0), metrics.QueueTime);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // Test partitions
            metrics = ServiceBusScaleMonitor.CreateTriggerMetrics(null, 0, 0, 16, false);

            Assert.AreEqual(16, metrics.PartitionCount);
            Assert.AreEqual(0, metrics.MessageCount);
            Assert.AreEqual(TimeSpan.FromSeconds(0), metrics.QueueTime);
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

            var metrics = await ((ServiceBusScaleMonitor)listener.GetMonitor()).GetMetricsAsync();

            Assert.AreEqual(0, metrics.PartitionCount);
            Assert.AreEqual(0, metrics.MessageCount);
            Assert.AreEqual(TimeSpan.FromSeconds(0), metrics.QueueTime);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            var warning = _loggerProvider.GetAllLogMessages().Single(p => p.Level == LogLevel.Warning);
            Assert.AreEqual($"ServiceBus queue '{_entityPath}' was not found.", warning.FormattedMessage);
            _loggerProvider.ClearAllLogMessages();

            // UnauthorizedAccessException
            _mockProvider
                .Setup(p => p.CreateBatchMessageReceiver(_client, _entityPath, It.IsAny<ServiceBusReceiverOptions>()))
                .Throws(new UnauthorizedAccessException(""));
            listener = CreateListener();

            metrics = await ((ServiceBusScaleMonitor)listener.GetMonitor()).GetMetricsAsync();

            Assert.AreEqual(0, metrics.PartitionCount);
            Assert.AreEqual(0, metrics.MessageCount);
            Assert.AreEqual(TimeSpan.FromSeconds(0), metrics.QueueTime);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            warning = _loggerProvider.GetAllLogMessages().Single(p => p.Level == LogLevel.Warning);
            Assert.AreEqual($"Connection string does not have Manage claim for queue '{_entityPath}'. Failed to get queue description to derive queue length metrics. " +
                        $"Falling back to using first message enqueued time.",
                        warning.FormattedMessage);
            _loggerProvider.ClearAllLogMessages();

            // Generic Exception
            _mockProvider
                .Setup(p => p.CreateBatchMessageReceiver(_client, _entityPath, It.IsAny<ServiceBusReceiverOptions>()))
                .Throws(new Exception("Uh oh"));
            listener = CreateListener();

            metrics = await ((ServiceBusScaleMonitor)listener.GetMonitor()).GetMetricsAsync();

            Assert.AreEqual(0, metrics.PartitionCount);
            Assert.AreEqual(0, metrics.MessageCount);
            Assert.AreEqual(TimeSpan.FromSeconds(0), metrics.QueueTime);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            warning = _loggerProvider.GetAllLogMessages().Single(p => p.Level == LogLevel.Warning);
            Assert.AreEqual($"Error querying for Service Bus queue scale status: Uh oh", warning.FormattedMessage);
        }

        private ServiceBusListener CreateListener()
        {
            var concurrencyOptions = new OptionsWrapper<ConcurrencyOptions>(new ConcurrencyOptions());
            var mockConcurrencyThrottleManager = new Mock<IConcurrencyThrottleManager>(MockBehavior.Strict);
            var concurrencyManager = new ConcurrencyManager(concurrencyOptions, _loggerFactory, mockConcurrencyThrottleManager.Object);

            return new ServiceBusListener(
                _functionId,
                ServiceBusEntityType.Queue,
                _entityPath,
                false,
                _serviceBusOptions.AutoCompleteMessages,
                _mockExecutor.Object,
                _serviceBusOptions,
                _connection,
                _mockProvider.Object,
                _loggerFactory,
                false,
                _mockClientFactory.Object,
                concurrencyManager);
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
