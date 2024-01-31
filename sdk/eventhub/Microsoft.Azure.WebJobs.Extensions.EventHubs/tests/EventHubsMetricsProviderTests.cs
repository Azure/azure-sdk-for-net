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
using Microsoft.Azure.WebJobs.Extensions.EventHubs.Listeners;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using static Moq.It;

namespace Microsoft.Azure.WebJobs.EventHubs.UnitTests
{
    public class EventHubsMetricsProviderTests
    {
        private readonly string _functionId = "EventHubsTriggerFunction";
        private readonly string _eventHubName = "TestEventHubName";
        private readonly string _consumerGroup = "TestConsumerGroup";
        private readonly string _namespace = "TestNamespace";
        private EventHubMetricsProvider _metricsProvider;
        private Mock<BlobCheckpointStoreInternal> _mockCheckpointStore;
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

            this._mockCheckpointStore = new Mock<BlobCheckpointStoreInternal>(MockBehavior.Strict);

            _mockCheckpointStore.Setup(s => s.GetCheckpointAsync(_namespace, _eventHubName, _consumerGroup, It.IsAny<string>(), default))
                .Returns<string, string, string, string, CancellationToken>((ns, hub, cg, partitionId, ct) => Task.FromResult(_checkpoints.SingleOrDefault(cp => cp.PartitionId == partitionId)));

            _metricsProvider = new EventHubMetricsProvider(
                                    _functionId,
                                    _consumerClientMock.Object,
                                    _mockCheckpointStore.Object,
                                    _loggerFactory.CreateLogger(LogCategories.CreateTriggerCategory("EventHub")));
        }

        [Test]
        public async Task CreateTriggerMetrics_ReturnsExpectedResult()
        {
            _partitions = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 0)
            };

            this._checkpoints = new EventProcessorCheckpoint[]
            {
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = 0,  SequenceNumber = 0 }
            };

            var metrics = await _metricsProvider.GetMetricsAsync();

            Assert.AreEqual(0, metrics.EventCount);
            Assert.AreEqual(1, metrics.PartitionCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // Partition got its first message (no checkpoint, LastEnqueued == 0)
            this._checkpoints = new EventProcessorCheckpoint[0];
            metrics = await _metricsProvider.GetMetricsAsync();

            Assert.AreEqual(1, metrics.EventCount);
            Assert.AreEqual(1, metrics.PartitionCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // No instances assigned to process events on partition (no checkpoint, LastEnqueued > 0)
            this._checkpoints = new EventProcessorCheckpoint[0];

            _partitions = new List<PartitionProperties>
            {
                new TestPartitionProperties(
                    beginningSequenceNumber: 5,
                    lastSequenceNumber: 10)
            };

            metrics = await _metricsProvider.GetMetricsAsync();

            Assert.AreEqual(6, metrics.EventCount);
            Assert.AreEqual(1, metrics.PartitionCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // Checkpointing is ahead of partition info and invalid (SequenceNumber > LastEnqueued)
            this._checkpoints = new EventProcessorCheckpoint[]
            {
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = 999, SequenceNumber = 11 }
            };

            _partitions = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 10)
            };

            metrics = await _metricsProvider.GetMetricsAsync();

            Assert.AreEqual(0, metrics.EventCount);
            Assert.AreEqual(1, metrics.PartitionCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);
        }

        [Test]
        public async Task CreateTriggerMetrics_MultiplePartitions_ReturnsExpectedResult()
        {
            // No messages processed, no messages in queue
            this._checkpoints = new EventProcessorCheckpoint[]
            {
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = 0,  SequenceNumber = 0, PartitionId = "1" },
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = 0,  SequenceNumber = 0, PartitionId = "2" },
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = 0,  SequenceNumber = 0, PartitionId = "3" }
            };

            _partitions = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 0, partitionId: "1"),
                new TestPartitionProperties(lastSequenceNumber: 0, partitionId: "2"),
                new TestPartitionProperties(lastSequenceNumber: 0, partitionId: "3")
            };

            var metrics = await _metricsProvider.GetMetricsAsync();

            Assert.AreEqual(0, metrics.EventCount);
            Assert.AreEqual(3, metrics.PartitionCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // Messages processed, Messages in queue
            this._checkpoints = new EventProcessorCheckpoint[]
            {
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = 0,  SequenceNumber = 2, PartitionId = "1" },
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = 0,  SequenceNumber = 3, PartitionId = "2" },
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = 0,  SequenceNumber = 4, PartitionId = "3" }
            };

            _partitions = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 12, partitionId: "1"),
                new TestPartitionProperties(lastSequenceNumber: 13, partitionId: "2"),
                new TestPartitionProperties(lastSequenceNumber: 14, partitionId: "3")
            };

            metrics = await _metricsProvider.GetMetricsAsync();

            Assert.AreEqual(30, metrics.EventCount);
            Assert.AreEqual(3, metrics.PartitionCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // One invalid sample
            this._checkpoints = new EventProcessorCheckpoint[]
            {
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = 0,  SequenceNumber = 2, PartitionId = "1" },
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = 0,  SequenceNumber = 3, PartitionId = "2" },
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = 0,  SequenceNumber = 4, PartitionId = "3" }
            };

            _partitions = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 12, partitionId: "1"),
                new TestPartitionProperties(lastSequenceNumber: 13, partitionId: "2"),
                new TestPartitionProperties(lastSequenceNumber: 1, partitionId: "3")
            };

            metrics = await _metricsProvider.GetMetricsAsync();

            Assert.AreEqual(20, metrics.EventCount);
            Assert.AreEqual(3, metrics.PartitionCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);
        }

        [Test]
        public async Task CreateTriggerMetrics_HandlesExceptions()
        {
            // StorageException
            _mockCheckpointStore
                .Setup(c => c.GetCheckpointAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new RequestFailedException(404, "Uh oh"));

            _partitions = new List<PartitionProperties>
            {
                new TestPartitionProperties()
            };

            var metrics = await _metricsProvider.GetMetricsAsync();

            Assert.AreEqual(1, metrics.PartitionCount);
            Assert.AreEqual(0, metrics.EventCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // Generic Exception
            _mockCheckpointStore
                .Setup(c => c.GetCheckpointAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Uh oh"));

            _partitions = new List<PartitionProperties>
            {
                new TestPartitionProperties()
            };

            metrics = await _metricsProvider.GetMetricsAsync();

            Assert.AreEqual(1, metrics.PartitionCount);
            Assert.AreEqual(0, metrics.EventCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            _loggerProvider.ClearAllLogMessages();
        }
    }
}
