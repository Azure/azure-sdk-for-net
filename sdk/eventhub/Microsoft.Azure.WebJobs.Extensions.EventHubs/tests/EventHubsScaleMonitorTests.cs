// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Messaging.EventHubs.Primitives;
using Microsoft.Azure.WebJobs.EventHubs.Listeners;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.EventHubs.UnitTests
{
    public class EventHubsScaleMonitorTests
    {
        private readonly string _functionId = "EventHubsTriggerFunction";
        private readonly string _eventHubName = "TestEventHubName";
        private readonly string _consumerGroup = "TestConsumerGroup";
        private readonly string _namespace = "TestNamespace";
        private EventHubsScaleMonitor _scaleMonitor;
        private Mock<BlobCheckpointStoreInternal> _mockCheckpointStore;
        private TestLoggerProvider _loggerProvider;
        private LoggerFactory _loggerFactory;
        private Mock<IEventHubConsumerClient> _consumerClientMock;

        [SetUp]
        public void SetUp()
        {
            _loggerFactory = new LoggerFactory();
            _loggerProvider = new TestLoggerProvider();
            _loggerFactory.AddProvider(_loggerProvider);

            _consumerClientMock = new Mock<IEventHubConsumerClient>(MockBehavior.Strict);
            _consumerClientMock.Setup(c => c.ConsumerGroup).Returns(_consumerGroup);
            _consumerClientMock.Setup(c => c.EventHubName).Returns(_eventHubName);
            _consumerClientMock.Setup(c => c.FullyQualifiedNamespace).Returns(_namespace);

            this._mockCheckpointStore = new Mock<BlobCheckpointStoreInternal>(MockBehavior.Strict);

            _scaleMonitor = new EventHubsScaleMonitor(
                                    _functionId,
                                    _consumerClientMock.Object,
                                    _mockCheckpointStore.Object,
                                    _loggerFactory.CreateLogger(LogCategories.CreateTriggerCategory("EventHub")));
        }

        [Test]
        public void ScaleMonitorDescriptor_ReturnsExpectedValue()
        {
            Assert.That(_scaleMonitor.Descriptor.Id, Is.EqualTo($"{_functionId}-EventHubTrigger-{_eventHubName}-{_consumerGroup}".ToLower()));
        }

        [Test]
        public void GetScaleStatus_NoMetrics_ReturnsVote_None()
        {
            var context = new ScaleStatusContext<EventHubsTriggerMetrics>
            {
                WorkerCount = 1
            };

            var status = _scaleMonitor.GetScaleStatus(context);
            Assert.That(status.Vote, Is.EqualTo(ScaleVote.None));

            // verify the non-generic implementation works properly
            status = ((IScaleMonitor)_scaleMonitor).GetScaleStatus(context);
            Assert.That(status.Vote, Is.EqualTo(ScaleVote.None));
        }

        [Test]
        public void GetScaleStatus_InstancesPerPartitionThresholdExceeded_ReturnsVote_ScaleIn()
        {
            var context = new ScaleStatusContext<EventHubsTriggerMetrics>
            {
                WorkerCount = 17
            };
            var timestamp = DateTime.UtcNow;
            var eventHubTriggerMetrics = new List<EventHubsTriggerMetrics>
            {
                new EventHubsTriggerMetrics { EventCount = 2500, PartitionCount = 16, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 2505, PartitionCount = 16, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 2612, PartitionCount = 16, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 2700, PartitionCount = 16, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 2810, PartitionCount = 16, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 2900, PartitionCount = 16, Timestamp = timestamp.AddSeconds(15) },
            };
            context.Metrics = eventHubTriggerMetrics;

            var status = _scaleMonitor.GetScaleStatus(context);
            Assert.That(status.Vote, Is.EqualTo(ScaleVote.ScaleIn));

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.That(log.Level, Is.EqualTo(LogLevel.Information));
            Assert.That(log.FormattedMessage, Is.EqualTo("WorkerCount (17) > PartitionCount (16)."));
            log = logs[1];
            Assert.That(log.Level, Is.EqualTo(LogLevel.Information));
            Assert.That(log.FormattedMessage, Is.EqualTo($"Number of instances (17) is too high relative to number of partitions (16) for EventHubs entity ({_eventHubName}, {_consumerGroup})."));

            // verify again with a non generic context instance
            var context2 = new ScaleStatusContext
            {
                WorkerCount = 1,
                Metrics = eventHubTriggerMetrics
            };
            status = ((IScaleMonitor)_scaleMonitor).GetScaleStatus(context2);
            Assert.That(status.Vote, Is.EqualTo(ScaleVote.ScaleOut));
        }

        [Test]
        public void GetScaleStatus_EventsPerWorkerThresholdExceeded_ReturnsVote_ScaleOut()
        {
            var context = new ScaleStatusContext<EventHubsTriggerMetrics>
            {
                WorkerCount = 1
            };
            var timestamp = DateTime.UtcNow;
            var eventHubTriggerMetrics = new List<EventHubsTriggerMetrics>
            {
                new EventHubsTriggerMetrics { EventCount = 2500, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 2505, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 2612, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 2700, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 2810, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 2900, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
            };
            context.Metrics = eventHubTriggerMetrics;

            var status = _scaleMonitor.GetScaleStatus(context);
            Assert.That(status.Vote, Is.EqualTo(ScaleVote.ScaleOut));

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.That(log.Level, Is.EqualTo(LogLevel.Information));
            Assert.That(log.FormattedMessage, Is.EqualTo("EventCount (2900) > WorkerCount (1) * 1,000."));
            log = logs[1];
            Assert.That(log.Level, Is.EqualTo(LogLevel.Information));
            Assert.That(log.FormattedMessage, Is.EqualTo($"Event count (2900) for EventHubs entity ({_eventHubName}, {_consumerGroup}) " +
                         $"is too high relative to the number of instances (1)."));

            // verify again with a non generic context instance
            var context2 = new ScaleStatusContext
            {
                WorkerCount = 1,
                Metrics = eventHubTriggerMetrics
            };
            status = ((IScaleMonitor)_scaleMonitor).GetScaleStatus(context2);
            Assert.That(status.Vote, Is.EqualTo(ScaleVote.ScaleOut));
        }

        [Test]
        public void GetScaleStatus_EventHubIdle_ReturnsVote_ScaleIn()
        {
            var context = new ScaleStatusContext<EventHubsTriggerMetrics>
            {
                WorkerCount = 3
            };
            var timestamp = DateTime.UtcNow;
            context.Metrics = new List<EventHubsTriggerMetrics>
            {
                new EventHubsTriggerMetrics { EventCount = 0, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 0, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 0, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 0, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 0, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 0, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
            };

            var status = _scaleMonitor.GetScaleStatus(context);
            Assert.That(status.Vote, Is.EqualTo(ScaleVote.ScaleIn));

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.That(log.Level, Is.EqualTo(LogLevel.Information));
            Assert.That(log.FormattedMessage, Is.EqualTo($"'{_eventHubName}' is idle."));
        }

        [Test]
        public void GetScaleStatus_EventCountIncreasing_ReturnsVote_ScaleOut()
        {
            var context = new ScaleStatusContext<EventHubsTriggerMetrics>
            {
                WorkerCount = 1
            };
            var timestamp = DateTime.UtcNow;
            context.Metrics = new List<EventHubsTriggerMetrics>
            {
                new EventHubsTriggerMetrics { EventCount = 10, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 20, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 40, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 80, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 100, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 150, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
            };

            var status = _scaleMonitor.GetScaleStatus(context);
            Assert.That(status.Vote, Is.EqualTo(ScaleVote.ScaleOut));

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.That(log.Level, Is.EqualTo(LogLevel.Information));
            Assert.That(log.FormattedMessage, Is.EqualTo($"Event count is increasing for '{_eventHubName}'."));
        }

        [Test]
        public void GetScaleStatus_EventCountDecreasing_ReturnsVote_ScaleOut()
        {
            var context = new ScaleStatusContext<EventHubsTriggerMetrics>
            {
                WorkerCount = 1
            };
            var timestamp = DateTime.UtcNow;
            context.Metrics = new List<EventHubsTriggerMetrics>
            {
                new EventHubsTriggerMetrics { EventCount = 150, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 100, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 80, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 40, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 20, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 10, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
            };

            var status = _scaleMonitor.GetScaleStatus(context);
            Assert.That(status.Vote, Is.EqualTo(ScaleVote.ScaleIn));

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.That(log.Level, Is.EqualTo(LogLevel.Information));
            Assert.That(log.FormattedMessage, Is.EqualTo($"Event count is decreasing for '{_eventHubName}'."));
        }

        [Test]
        public void GetScaleStatus_EventHubSteady_ReturnsVote_ScaleIn()
        {
            var context = new ScaleStatusContext<EventHubsTriggerMetrics>
            {
                WorkerCount = 2
            };
            var timestamp = DateTime.UtcNow;
            context.Metrics = new List<EventHubsTriggerMetrics>
            {
                new EventHubsTriggerMetrics { EventCount = 1500, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 1600, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 1400, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 1300, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 1700, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
                new EventHubsTriggerMetrics { EventCount = 1600, PartitionCount = 0, Timestamp = timestamp.AddSeconds(15) },
            };

            var status = _scaleMonitor.GetScaleStatus(context);
            Assert.That(status.Vote, Is.EqualTo(ScaleVote.None));

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.That(log.Level, Is.EqualTo(LogLevel.Information));
            Assert.That(log.FormattedMessage, Is.EqualTo($"EventHubs entity '{_eventHubName}' is steady."));
        }
    }
}
