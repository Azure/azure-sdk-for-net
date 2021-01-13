// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.Azure.ServiceBus.Management;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Scale;
//using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.ServiceBus.Listeners;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;
using static Microsoft.Azure.ServiceBus.Message;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests.Listeners
{
    public class ServiceBusScaleMonitorTests
    {
        //private readonly MessagingFactory _messagingFactory;
        //    private readonly ServiceBusListener _listener;
        //    private readonly ServiceBusScaleMonitor _scaleMonitor;
        //    private readonly ServiceBusOptions _serviceBusOptions;
        //    private readonly Mock<ServiceBusAccount> _mockServiceBusAccount;
        //    private readonly Mock<ITriggeredFunctionExecutor> _mockExecutor;
        //    private readonly Mock<MessagingProvider> _mockMessagingProvider;
        //    private readonly Mock<MessageProcessor> _mockMessageProcessor;
        //    private readonly TestLoggerProvider _loggerProvider;
        //    private readonly LoggerFactory _loggerFactory;
        //    private readonly string _functionId = "test-functionid";
        //    private readonly string _entityPath = "test-entity-path";
        //    private readonly string _testConnection = "Endpoint=sb://test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=";

        //    public ServiceBusScaleMonitorTests()
        //    {
        //        _mockExecutor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);

        //        MessageHandlerOptions messageOptions = new MessageHandlerOptions(ExceptionReceivedHandler);
        //        MessageReceiver messageReceiver = new MessageReceiver(_testConnection, _entityPath);
        //        _mockMessageProcessor = new Mock<MessageProcessor>(MockBehavior.Strict, messageReceiver, messageOptions);

        //        _serviceBusOptions = new ServiceBusOptions
        //        {
        //            MessageHandlerOptions = messageOptions
        //        };
        //        _mockMessagingProvider = new Mock<MessagingProvider>(MockBehavior.Strict, new OptionsWrapper<ServiceBusOptions>(_serviceBusOptions));

        //        _mockMessagingProvider
        //            .Setup(p => p.CreateMessageProcessor(_entityPath, _testConnection))
        //            .Returns(_mockMessageProcessor.Object);

        //        _mockServiceBusAccount = new Mock<ServiceBusAccount>(MockBehavior.Strict);
        //        _mockServiceBusAccount.Setup(a => a.ConnectionString).Returns(_testConnection);

        //        _loggerFactory = new LoggerFactory();
        //        _loggerProvider = new TestLoggerProvider();
        //        _loggerFactory.AddProvider(_loggerProvider);

        //        _listener = new ServiceBusListener(_functionId, EntityType.Queue, _entityPath, false, _mockExecutor.Object, _serviceBusOptions, _mockServiceBusAccount.Object,
        //                            _mockMessagingProvider.Object, _loggerFactory, false);
        //        _scaleMonitor = (ServiceBusScaleMonitor)_listener.GetMonitor();
        //    }

        //    Task ExceptionReceivedHandler(ExceptionReceivedEventArgs eventArgs)
        //    {
        //        return Task.CompletedTask;
        //    }

        //    [Fact]
        //    public void ScaleMonitorDescriptor_ReturnsExpectedValue()
        //    {
        //        Assert.Equal($"{_functionId}-ServiceBusTrigger-{_entityPath}".ToLower(), _scaleMonitor.Descriptor.Id);
        //    }

        //    [Fact]
        //    public void GetMetrics_ReturnsExpectedResult()
        //    {
        //        // Unable to test QueueTime because of restrictions on creating Message objects

        //        // Test base case
        //        var metrics = ServiceBusScaleMonitor.CreateTriggerMetrics(null, 0, 0, 0, false);

        //        Assert.Equal(0, metrics.PartitionCount);
        //        Assert.Equal(0, metrics.MessageCount);
        //        Assert.Equal(TimeSpan.FromSeconds(0), metrics.QueueTime);
        //        Assert.NotEqual(default(DateTime), metrics.Timestamp);

        //        // Test messages on main queue
        //        metrics = ServiceBusScaleMonitor.CreateTriggerMetrics(null, 10, 0, 0, false);

        //        Assert.Equal(0, metrics.PartitionCount);
        //        Assert.Equal(10, metrics.MessageCount);
        //        Assert.Equal(TimeSpan.FromSeconds(0), metrics.QueueTime);
        //        Assert.NotEqual(default(DateTime), metrics.Timestamp);

        //        // Test listening on dead letter queue
        //        metrics = ServiceBusScaleMonitor.CreateTriggerMetrics(null, 10, 100, 0, true);

        //        Assert.Equal(0, metrics.PartitionCount);
        //        Assert.Equal(100, metrics.MessageCount);
        //        Assert.Equal(TimeSpan.FromSeconds(0), metrics.QueueTime);
        //        Assert.NotEqual(default(DateTime), metrics.Timestamp);

        //        // Test partitions
        //        metrics = ServiceBusScaleMonitor.CreateTriggerMetrics(null, 0, 0, 16, false);

        //        Assert.Equal(16, metrics.PartitionCount);
        //        Assert.Equal(0, metrics.MessageCount);
        //        Assert.Equal(TimeSpan.FromSeconds(0), metrics.QueueTime);
        //        Assert.NotEqual(default(DateTime), metrics.Timestamp);
        //    }

        //    [Fact]
        //    public async Task GetMetrics_HandlesExceptions()
        //    {
        //        // MessagingEntityNotFoundException
        //        _mockMessagingProvider
        //            .Setup(p => p.CreateMessageReceiver(_entityPath, _testConnection))
        //            .Throws(new MessagingEntityNotFoundException(""));
        //        ServiceBusListener listener = new ServiceBusListener(_functionId, EntityType.Queue, _entityPath, false, _mockExecutor.Object, _serviceBusOptions,
        //                                            _mockServiceBusAccount.Object, _mockMessagingProvider.Object, _loggerFactory, false);

        //        var metrics = await ((ServiceBusScaleMonitor)listener.GetMonitor()).GetMetricsAsync();

        //        Assert.Equal(0, metrics.PartitionCount);
        //        Assert.Equal(0, metrics.MessageCount);
        //        Assert.Equal(TimeSpan.FromSeconds(0), metrics.QueueTime);
        //        Assert.NotEqual(default(DateTime), metrics.Timestamp);

        //        var warning = _loggerProvider.GetAllLogMessages().Single(p => p.Level == LogLevel.Warning);
        //        Assert.Equal($"ServiceBus queue '{_entityPath}' was not found.", warning.FormattedMessage);
        //        _loggerProvider.ClearAllLogMessages();

        //        // UnauthorizedAccessException
        //        _mockMessagingProvider
        //            .Setup(p => p.CreateMessageReceiver(_entityPath, _testConnection))
        //            .Throws(new UnauthorizedException(""));
        //        listener = new ServiceBusListener(_functionId, EntityType.Queue, _entityPath, false, _mockExecutor.Object, _serviceBusOptions,
        //                                            _mockServiceBusAccount.Object, _mockMessagingProvider.Object, _loggerFactory, false);

        //        metrics = await ((ServiceBusScaleMonitor)listener.GetMonitor()).GetMetricsAsync();

        //        Assert.Equal(0, metrics.PartitionCount);
        //        Assert.Equal(0, metrics.MessageCount);
        //        Assert.Equal(TimeSpan.FromSeconds(0), metrics.QueueTime);
        //        Assert.NotEqual(default(DateTime), metrics.Timestamp);

        //        warning = _loggerProvider.GetAllLogMessages().Single(p => p.Level == LogLevel.Warning);
        //        Assert.Equal($"Connection string does not have Manage claim for queue '{_entityPath}'. Failed to get queue description to derive queue length metrics. " +
        //                    $"Falling back to using first message enqueued time.",
        //                    warning.FormattedMessage);
        //        _loggerProvider.ClearAllLogMessages();

        //        // Generic Exception
        //        _mockMessagingProvider
        //            .Setup(p => p.CreateMessageReceiver(_entityPath, _testConnection))
        //            .Throws(new Exception("Uh oh"));
        //        listener = new ServiceBusListener(_functionId, EntityType.Queue, _entityPath, false, _mockExecutor.Object, _serviceBusOptions,
        //                                            _mockServiceBusAccount.Object, _mockMessagingProvider.Object, _loggerFactory, false);

        //        metrics = await ((ServiceBusScaleMonitor)listener.GetMonitor()).GetMetricsAsync();

        //        Assert.Equal(0, metrics.PartitionCount);
        //        Assert.Equal(0, metrics.MessageCount);
        //        Assert.Equal(TimeSpan.FromSeconds(0), metrics.QueueTime);
        //        Assert.NotEqual(default(DateTime), metrics.Timestamp);

        //        warning = _loggerProvider.GetAllLogMessages().Single(p => p.Level == LogLevel.Warning);
        //        Assert.Equal($"Error querying for Service Bus queue scale status: Uh oh", warning.FormattedMessage);
        //    }

        //    [Fact]
        //    public void GetScaleStatus_NoMetrics_ReturnsVote_None()
        //    {
        //        var context = new ScaleStatusContext<ServiceBusTriggerMetrics>
        //        {
        //            WorkerCount = 1
        //        };

        //        var status = _scaleMonitor.GetScaleStatus(context);
        //        Assert.Equal(ScaleVote.None, status.Vote);

        //        // verify the non-generic implementation works properly
        //        status = ((IScaleMonitor)_scaleMonitor).GetScaleStatus(context);
        //        Assert.Equal(ScaleVote.None, status.Vote);
        //    }

        //    [Fact]
        //    public void GetScaleStatus_InstancesPerPartitionThresholdExceeded_ReturnsVote_ScaleIn()
        //    {
        //        var context = new ScaleStatusContext<ServiceBusTriggerMetrics>
        //        {
        //            WorkerCount = 17
        //        };
        //        var timestamp = DateTime.UtcNow;
        //        var serviceBusTriggerMetrics = new List<ServiceBusTriggerMetrics>
        //        {
        //            new ServiceBusTriggerMetrics { MessageCount = 2500, PartitionCount = 16, QueueTime = TimeSpan.FromSeconds(15), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 2505, PartitionCount = 16, QueueTime = TimeSpan.FromSeconds(15), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 2612, PartitionCount = 16, QueueTime = TimeSpan.FromSeconds(15), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 2700, PartitionCount = 16, QueueTime = TimeSpan.FromSeconds(15), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 2810, PartitionCount = 16, QueueTime = TimeSpan.FromSeconds(15), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 2900, PartitionCount = 16, QueueTime = TimeSpan.FromSeconds(15), Timestamp = timestamp.AddSeconds(15) },
        //        };
        //        context.Metrics = serviceBusTriggerMetrics;

        //        var status = _scaleMonitor.GetScaleStatus(context);
        //        Assert.Equal(ScaleVote.ScaleIn, status.Vote);

        //        var logs = _loggerProvider.GetAllLogMessages().ToArray();
        //        var log = logs[0];
        //        Assert.Equal(LogLevel.Information, log.Level);
        //        Assert.Equal("WorkerCount (17) > PartitionCount (16).", log.FormattedMessage);
        //        log = logs[1];
        //        Assert.Equal(LogLevel.Information, log.Level);
        //        Assert.Equal($"Number of instances (17) is too high relative to number of partitions for Service Bus entity ({_entityPath}, 16).", log.FormattedMessage);

        //        // verify again with a non generic context instance
        //        var context2 = new ScaleStatusContext
        //        {
        //            WorkerCount = 1,
        //            Metrics = serviceBusTriggerMetrics
        //        };
        //        status = ((IScaleMonitor)_scaleMonitor).GetScaleStatus(context2);
        //        Assert.Equal(ScaleVote.ScaleOut, status.Vote);
        //    }

        //    [Fact]
        //    public void GetScaleStatus_MessagesPerWorkerThresholdExceeded_ReturnsVote_ScaleOut()
        //    {
        //        var context = new ScaleStatusContext<ServiceBusTriggerMetrics>
        //        {
        //            WorkerCount = 1
        //        };
        //        var timestamp = DateTime.UtcNow;
        //        var serviceBusTriggerMetrics = new List<ServiceBusTriggerMetrics>
        //        {
        //            new ServiceBusTriggerMetrics { MessageCount = 2500, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 2505, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 2612, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 2700, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 2810, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 2900, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
        //        };
        //        context.Metrics = serviceBusTriggerMetrics;

        //        var status = _scaleMonitor.GetScaleStatus(context);
        //        Assert.Equal(ScaleVote.ScaleOut, status.Vote);

        //        var logs = _loggerProvider.GetAllLogMessages().ToArray();
        //        var log = logs[0];
        //        Assert.Equal(LogLevel.Information, log.Level);
        //        Assert.Equal("MessageCount (2900) > WorkerCount (1) * 1,000.", log.FormattedMessage);
        //        log = logs[1];
        //        Assert.Equal(LogLevel.Information, log.Level);
        //        Assert.Equal($"Message count for Service Bus Entity ({_entityPath}, 2900) " +
        //                     $"is too high relative to the number of instances (1).", log.FormattedMessage);

        //        // verify again with a non generic context instance
        //        var context2 = new ScaleStatusContext
        //        {
        //            WorkerCount = 1,
        //            Metrics = serviceBusTriggerMetrics
        //        };
        //        status = ((IScaleMonitor)_scaleMonitor).GetScaleStatus(context2);
        //        Assert.Equal(ScaleVote.ScaleOut, status.Vote);
        //    }

        //    [Fact]
        //    public void GetScaleStatus_QueueLengthIncreasing_ReturnsVote_ScaleOut()
        //    {
        //        var context = new ScaleStatusContext<ServiceBusTriggerMetrics>
        //        {
        //            WorkerCount = 1
        //        };
        //        var timestamp = DateTime.UtcNow;
        //        context.Metrics = new List<ServiceBusTriggerMetrics>
        //        {
        //            new ServiceBusTriggerMetrics { MessageCount = 10, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 20, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 40, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 80, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 150, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
        //        };

        //        var status = _scaleMonitor.GetScaleStatus(context);
        //        Assert.Equal(ScaleVote.ScaleOut, status.Vote);

        //        var logs = _loggerProvider.GetAllLogMessages().ToArray();
        //        var log = logs[0];
        //        Assert.Equal(LogLevel.Information, log.Level);
        //        Assert.Equal($"Message count is increasing for '{_entityPath}'.", log.FormattedMessage);
        //    }

        //    [Fact]
        //    public void GetScaleStatus_QueueTimeIncreasing_ReturnsVote_ScaleOut()
        //    {
        //        var context = new ScaleStatusContext<ServiceBusTriggerMetrics>
        //        {
        //            WorkerCount = 1
        //        };
        //        var timestamp = DateTime.UtcNow;
        //        context.Metrics = new List<ServiceBusTriggerMetrics>
        //        {
        //            new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(2), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(3), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(4), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(5), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(6), Timestamp = timestamp.AddSeconds(15) },
        //        };

        //        var status = _scaleMonitor.GetScaleStatus(context);
        //        Assert.Equal(ScaleVote.ScaleOut, status.Vote);

        //        var logs = _loggerProvider.GetAllLogMessages().ToArray();
        //        var log = logs[0];
        //        Assert.Equal(LogLevel.Information, log.Level);
        //        Assert.Equal($"Queue time is increasing for '{_entityPath}'.", log.FormattedMessage);
        //    }

        //    [Fact]
        //    public void GetScaleStatus_QueueLengthDecreasing_ReturnsVote_ScaleIn()
        //    {
        //        var context = new ScaleStatusContext<ServiceBusTriggerMetrics>
        //        {
        //            WorkerCount = 1
        //        };
        //        var timestamp = DateTime.UtcNow;
        //        context.Metrics = new List<ServiceBusTriggerMetrics>
        //        {
        //            new ServiceBusTriggerMetrics { MessageCount = 150, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 80, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 40, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 20, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 10, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(0), Timestamp = timestamp.AddSeconds(15) },
        //        };

        //        var status = _scaleMonitor.GetScaleStatus(context);
        //        Assert.Equal(ScaleVote.ScaleIn, status.Vote);

        //        var logs = _loggerProvider.GetAllLogMessages().ToArray();
        //        var log = logs[0];
        //        Assert.Equal(LogLevel.Information, log.Level);
        //        Assert.Equal($"Message count is decreasing for '{_entityPath}'.", log.FormattedMessage);
        //    }

        //    [Fact]
        //    public void GetScaleStatus_QueueTimeDecreasing_ReturnsVote_ScaleIn()
        //    {
        //        var context = new ScaleStatusContext<ServiceBusTriggerMetrics>
        //        {
        //            WorkerCount = 1
        //        };
        //        var timestamp = DateTime.UtcNow;
        //        context.Metrics = new List<ServiceBusTriggerMetrics>
        //        {
        //            new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(6), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(5), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(4), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(3), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(2), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 100, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
        //        };

        //        var status = _scaleMonitor.GetScaleStatus(context);
        //        Assert.Equal(ScaleVote.ScaleIn, status.Vote);

        //        var logs = _loggerProvider.GetAllLogMessages().ToArray();
        //        var log = logs[0];
        //        Assert.Equal(LogLevel.Information, log.Level);
        //        Assert.Equal($"Queue time is decreasing for '{_entityPath}'.", log.FormattedMessage);
        //    }

        //    [Fact]
        //    public void GetScaleStatus_QueueSteady_ReturnsVote_None()
        //    {
        //        var context = new ScaleStatusContext<ServiceBusTriggerMetrics>
        //        {
        //            WorkerCount = 2
        //        };
        //        var timestamp = DateTime.UtcNow;
        //        context.Metrics = new List<ServiceBusTriggerMetrics>
        //        {
        //            new ServiceBusTriggerMetrics { MessageCount = 1500, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 1600, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 1400, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 1300, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 1700, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 1600, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
        //        };

        //        var status = _scaleMonitor.GetScaleStatus(context);
        //        Assert.Equal(ScaleVote.None, status.Vote);

        //        var logs = _loggerProvider.GetAllLogMessages().ToArray();
        //        var log = logs[0];
        //        Assert.Equal(LogLevel.Information, log.Level);
        //        Assert.Equal($"Service Bus entity '{_entityPath}' is steady.", log.FormattedMessage);
        //    }

        //    [Fact]
        //    public void GetScaleStatus_QueueIdle_ReturnsVote_ScaleIn()
        //    {
        //        var context = new ScaleStatusContext<ServiceBusTriggerMetrics>
        //        {
        //            WorkerCount = 3
        //        };
        //        var timestamp = DateTime.UtcNow;
        //        context.Metrics = new List<ServiceBusTriggerMetrics>
        //        {
        //            new ServiceBusTriggerMetrics { MessageCount = 0, PartitionCount = 0, QueueTime = TimeSpan.Zero, Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 0, PartitionCount = 0, QueueTime = TimeSpan.Zero, Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 0, PartitionCount = 0, QueueTime = TimeSpan.Zero, Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 0, PartitionCount = 0, QueueTime = TimeSpan.Zero, Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 0, PartitionCount = 0, QueueTime = TimeSpan.Zero, Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 0, PartitionCount = 0, QueueTime = TimeSpan.Zero, Timestamp = timestamp.AddSeconds(15) },
        //        };

        //        var status = _scaleMonitor.GetScaleStatus(context);
        //        Assert.Equal(ScaleVote.ScaleIn, status.Vote);

        //        var logs = _loggerProvider.GetAllLogMessages().ToArray();
        //        var log = logs[0];
        //        Assert.Equal(LogLevel.Information, log.Level);
        //        Assert.Equal($"'{_entityPath}' is idle.", log.FormattedMessage);
        //    }

        //    [Fact]
        //    public void GetScaleStatus_UnderSampleCountThreshold_ReturnsVote_None()
        //    {
        //        var context = new ScaleStatusContext<ServiceBusTriggerMetrics>
        //        {
        //            WorkerCount = 1
        //        };
        //        var timestamp = DateTime.UtcNow;
        //        context.Metrics = new List<ServiceBusTriggerMetrics>
        //        {
        //            new ServiceBusTriggerMetrics { MessageCount = 5, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
        //            new ServiceBusTriggerMetrics { MessageCount = 10, PartitionCount = 0, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) }
        //        };

        //        var status = _scaleMonitor.GetScaleStatus(context);
        //        Assert.Equal(ScaleVote.None, status.Vote);
        //    }
    }
}
