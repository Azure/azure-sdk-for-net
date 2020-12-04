// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Microsoft.Azure.WebJobs.EventHubs.Listeners;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using static Moq.It;

namespace Microsoft.Azure.WebJobs.EventHubs.UnitTests
{
    public class EventHubsScaleMonitorTests
    {
        private readonly string _functionId = "EventHubsTriggerFunction";
        private readonly string _eventHubName = "TestEventHubName";
        private readonly string _consumerGroup = "TestConsumerGroup";
        private readonly string _namespace = "TestNamespace";
        private EventHubsScaleMonitor _scaleMonitor;
        private Mock<BlobsCheckpointStore> _mockCheckpointStore;
        private TestLoggerProvider _loggerProvider;
        private LoggerFactory _loggerFactory;
        private Mock<IEventHubConsumerClient> _consumerClientMock;

        private IEnumerable<PartitionProperties> _partitions;
        private IEnumerable<EventProcessorCheckpoint> _checkpoints;

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
            _consumerClientMock.Setup(client => client.GetPartitionsAsync())
                .Returns(() => Task.FromResult(_partitions.Select(p => p.Id).ToArray()));
            _consumerClientMock.Setup(client => client.GetPartitionPropertiesAsync(IsAny<string>()))
                .Returns((string id) => Task.FromResult(_partitions.SingleOrDefault(p => p.Id == id)));

            _mockCheckpointStore = new Mock<BlobsCheckpointStore>(MockBehavior.Strict);
            _mockCheckpointStore.Setup(s => s.ListCheckpointsAsync(_namespace, _eventHubName, _consumerGroup, default))
                .Returns(() => Task.FromResult(_checkpoints));

            _scaleMonitor = new EventHubsScaleMonitor(
                                    _functionId,
                                    _consumerClientMock.Object,
                                    _mockCheckpointStore.Object,
                                    _loggerFactory.CreateLogger(LogCategories.CreateTriggerCategory("EventHub")));
        }

        [Test]
        public void ScaleMonitorDescriptor_ReturnsExpectedValue()
        {
            Assert.AreEqual($"{_functionId}-EventHubTrigger-{_eventHubName}-{_consumerGroup}".ToLower(), _scaleMonitor.Descriptor.Id);
        }

        [Test]
        public async Task CreateTriggerMetrics_ReturnsExpectedResult()
        {
            _partitions = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 0)
            };

            _checkpoints = new EventProcessorCheckpoint[]
            {
                new BlobsCheckpointStore.BlobStorageCheckpoint { Offset = 0,  SequenceNumber = 0 }
            };

            var metrics = await _scaleMonitor.GetMetricsAsync();

            Assert.AreEqual(0, metrics.EventCount);
            Assert.AreEqual(1, metrics.PartitionCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // Partition got its first message (Offset == null, LastEnqueued == 0)
            _checkpoints = new EventProcessorCheckpoint[]
            {
                new BlobsCheckpointStore.BlobStorageCheckpoint { Offset = null,  SequenceNumber = 0 }
            };

            metrics = await _scaleMonitor.GetMetricsAsync();

            Assert.AreEqual(1, metrics.EventCount);
            Assert.AreEqual(1, metrics.PartitionCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // No instances assigned to process events on partition (Offset == null, LastEnqueued > 0)
            _checkpoints = new EventProcessorCheckpoint[]
            {
                new BlobsCheckpointStore.BlobStorageCheckpoint { Offset = null, SequenceNumber = 0 }
            };

            _partitions = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 5)
            };

            metrics = await _scaleMonitor.GetMetricsAsync();

            Assert.AreEqual(6, metrics.EventCount);
            Assert.AreEqual(1, metrics.PartitionCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // Checkpointing is ahead of partition info (SequenceNumber > LastEnqueued)
            _checkpoints = new EventProcessorCheckpoint[]
            {
                new BlobsCheckpointStore.BlobStorageCheckpoint { Offset = 25, SequenceNumber = 11 }
            };

            _partitions = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 10)
            };

            metrics = await _scaleMonitor.GetMetricsAsync();

            Assert.AreEqual(0, metrics.EventCount);
            Assert.AreEqual(1, metrics.PartitionCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);
        }

        [Test]
        public async Task CreateTriggerMetrics_MultiplePartitions_ReturnsExpectedResult()
        {
            // No messages processed, no messages in queue
            _checkpoints = new EventProcessorCheckpoint[]
            {
                new BlobsCheckpointStore.BlobStorageCheckpoint { Offset = 0,  SequenceNumber = 0, PartitionId = "1" },
                new BlobsCheckpointStore.BlobStorageCheckpoint { Offset = 0,  SequenceNumber = 0, PartitionId = "2" },
                new BlobsCheckpointStore.BlobStorageCheckpoint { Offset = 0,  SequenceNumber = 0, PartitionId = "3" }
            };

            _partitions = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 0, partitionId: "1"),
                new TestPartitionProperties(lastSequenceNumber: 0, partitionId: "2"),
                new TestPartitionProperties(lastSequenceNumber: 0, partitionId: "3")
            };

            var metrics = await _scaleMonitor.GetMetricsAsync();

            Assert.AreEqual(0, metrics.EventCount);
            Assert.AreEqual(3, metrics.PartitionCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // Messages processed, Messages in queue
            _checkpoints = new EventProcessorCheckpoint[]
            {
                new BlobsCheckpointStore.BlobStorageCheckpoint { Offset = 0,  SequenceNumber = 2, PartitionId = "1" },
                new BlobsCheckpointStore.BlobStorageCheckpoint { Offset = 0,  SequenceNumber = 3, PartitionId = "2" },
                new BlobsCheckpointStore.BlobStorageCheckpoint { Offset = 0,  SequenceNumber = 4, PartitionId = "3" }
            };

            _partitions = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 12, partitionId: "1"),
                new TestPartitionProperties(lastSequenceNumber: 13, partitionId: "2"),
                new TestPartitionProperties(lastSequenceNumber: 14, partitionId: "3")
            };

            metrics = await _scaleMonitor.GetMetricsAsync();

            Assert.AreEqual(30, metrics.EventCount);
            Assert.AreEqual(3, metrics.PartitionCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // One invalid sample
            _checkpoints = new EventProcessorCheckpoint[]
            {
                new BlobsCheckpointStore.BlobStorageCheckpoint { Offset = 0,  SequenceNumber = 2, PartitionId = "1" },
                new BlobsCheckpointStore.BlobStorageCheckpoint { Offset = 0,  SequenceNumber = 3, PartitionId = "2" },
                new BlobsCheckpointStore.BlobStorageCheckpoint { Offset = 0,  SequenceNumber = 4, PartitionId = "3" }
            };

            _partitions = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 12, partitionId: "1"),
                new TestPartitionProperties(lastSequenceNumber: 13, partitionId: "2"),
                new TestPartitionProperties(lastSequenceNumber: 1, partitionId: "3")
            };

            metrics = await _scaleMonitor.GetMetricsAsync();

            Assert.AreEqual(20, metrics.EventCount);
            Assert.AreEqual(3, metrics.PartitionCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);
        }

        [Test]
        public void GetScaleStatus_NoMetrics_ReturnsVote_None()
        {
            var context = new ScaleStatusContext<EventHubsTriggerMetrics>
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
            Assert.AreEqual(ScaleVote.ScaleIn, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.AreEqual(LogLevel.Information, log.Level);
            Assert.AreEqual("WorkerCount (17) > PartitionCount (16).", log.FormattedMessage);
            log = logs[1];
            Assert.AreEqual(LogLevel.Information, log.Level);
            Assert.AreEqual($"Number of instances (17) is too high relative to number of partitions (16) for EventHubs entity ({_eventHubName}, {_consumerGroup}).", log.FormattedMessage);

            // verify again with a non generic context instance
            var context2 = new ScaleStatusContext
            {
                WorkerCount = 1,
                Metrics = eventHubTriggerMetrics
            };
            status = ((IScaleMonitor)_scaleMonitor).GetScaleStatus(context2);
            Assert.AreEqual(ScaleVote.ScaleOut, status.Vote);
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
            Assert.AreEqual(ScaleVote.ScaleOut, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.AreEqual(LogLevel.Information, log.Level);
            Assert.AreEqual("EventCount (2900) > WorkerCount (1) * 1,000.", log.FormattedMessage);
            log = logs[1];
            Assert.AreEqual(LogLevel.Information, log.Level);
            Assert.AreEqual($"Event count (2900) for EventHubs entity ({_eventHubName}, {_consumerGroup}) " +
                         $"is too high relative to the number of instances (1).", log.FormattedMessage);

            // verify again with a non generic context instance
            var context2 = new ScaleStatusContext
            {
                WorkerCount = 1,
                Metrics = eventHubTriggerMetrics
            };
            status = ((IScaleMonitor)_scaleMonitor).GetScaleStatus(context2);
            Assert.AreEqual(ScaleVote.ScaleOut, status.Vote);
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
            Assert.AreEqual(ScaleVote.ScaleIn, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.AreEqual(LogLevel.Information, log.Level);
            Assert.AreEqual($"'{_eventHubName}' is idle.", log.FormattedMessage);
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
            Assert.AreEqual(ScaleVote.ScaleOut, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.AreEqual(LogLevel.Information, log.Level);
            Assert.AreEqual($"Event count is increasing for '{_eventHubName}'.", log.FormattedMessage);
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
            Assert.AreEqual(ScaleVote.ScaleIn, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.AreEqual(LogLevel.Information, log.Level);
            Assert.AreEqual($"Event count is decreasing for '{_eventHubName}'.", log.FormattedMessage);
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
            Assert.AreEqual(ScaleVote.None, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.AreEqual(LogLevel.Information, log.Level);
            Assert.AreEqual($"EventHubs entity '{_eventHubName}' is steady.", log.FormattedMessage);
        }
        [Test]
        public async Task CreateTriggerMetrics_HandlesExceptions()
        {
            // StorageException
            _mockCheckpointStore
                .Setup(c => c.ListCheckpointsAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Throws(new RequestFailedException(404, "Uh oh"));

            _partitions = new List<PartitionProperties>
            {
                new TestPartitionProperties()
            };

            var metrics = await _scaleMonitor.GetMetricsAsync();

            Assert.AreEqual(1, metrics.PartitionCount);
            Assert.AreEqual(0, metrics.EventCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // Generic Exception
            _mockCheckpointStore
                .Setup(c => c.ListCheckpointsAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Throws(new Exception("Uh oh"));

            _partitions = new List<PartitionProperties>
            {
                new TestPartitionProperties()
            };

            metrics = await _scaleMonitor.GetMetricsAsync();

            Assert.AreEqual(1, metrics.PartitionCount);
            Assert.AreEqual(0, metrics.EventCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            _loggerProvider.ClearAllLogMessages();
        }
    }
}
