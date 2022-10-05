// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Primitives;
using Microsoft.Azure.WebJobs.EventHubs.UnitTests;
using Microsoft.Azure.WebJobs.Extensions.EventHubs.Listeners;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Moq.It;

namespace Microsoft.Azure.WebJobs.Extensions.EventHubs.Tests
{
    internal class EventHubsMetricsProviderTests
    {
        private readonly string _functionId = "EventHubsTriggerFunction";
        private readonly string _eventHubName = "TestEventHubName";
        private readonly string _consumerGroup = "TestConsumerGroup";
        private readonly string _namespace = "TestNamespace";
        private Mock<BlobCheckpointStoreInternal> _mockCheckpointStore;
        private TestLoggerProvider _loggerProvider;
        private ILoggerFactory _loggerFactory;
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
        }

        [Test]
        public void GetMetricsAsyncWithOnePartition()
        {
            //Arrange
            _partitions = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 0)
            };

            _checkpoints = new EventProcessorCheckpoint[]
            {
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = 0,  SequenceNumber = 0 }
            };
            _consumerClientMock.Setup(client => client.GetPartitionsAsync())
               .Returns(() => Task.FromResult(_partitions.Select(p => p.Id).ToArray()));
            _consumerClientMock.Setup(client => client.GetPartitionPropertiesAsync(IsAny<string>()))
                .Returns((string id) => Task.FromResult(_partitions.SingleOrDefault(p => p.Id == id)));

            _mockCheckpointStore = new Mock<BlobCheckpointStoreInternal>(MockBehavior.Strict);

            _mockCheckpointStore.Setup(s => s.GetCheckpointAsync(_namespace, _eventHubName, _consumerGroup, It.IsAny<string>(), default))
                .Returns<string, string, string, string, CancellationToken>((ns, hub, cg, partitionId, ct) => Task.FromResult(_checkpoints.SingleOrDefault(cp => cp.PartitionId == partitionId)));

            //Act
            EventHubsMetricsProvider eventHubsMetricsProvider = new EventHubsMetricsProvider(_functionId, _consumerClientMock.Object,
                _mockCheckpointStore.Object, _loggerFactory);

            var metrics = eventHubsMetricsProvider.GetMetricsAsync();

            //Assert
            Assert.AreEqual(metrics.Result.PartitionCount, 1);
            Assert.AreEqual(metrics.Result.EventCount, 0);
            Assert.IsNotNull(metrics.Result.Timestamp);
        }
        [Test]
        public void GetMetricsAsyncWithFivePartition()
        {
            //Arrange
            _partitions = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 1, partitionId:"1"),
                new TestPartitionProperties(lastSequenceNumber: 2, partitionId:"2"),
                new TestPartitionProperties(lastSequenceNumber: 3, partitionId:"3"),
                new TestPartitionProperties(lastSequenceNumber: 4, partitionId:"4"),
                new TestPartitionProperties(lastSequenceNumber: 5, partitionId:"5"),
            };

            _checkpoints = new EventProcessorCheckpoint[]
            {
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = 0,  SequenceNumber = 0 }
            };
            _consumerClientMock.Setup(client => client.GetPartitionsAsync())
               .Returns(() => Task.FromResult(_partitions.Select(p => p.Id).ToArray()));
            _consumerClientMock.Setup(client => client.GetPartitionPropertiesAsync(IsAny<string>()))
                .Returns((string id) => Task.FromResult(_partitions.SingleOrDefault(p => p.Id == id)));

            _mockCheckpointStore = new Mock<BlobCheckpointStoreInternal>(MockBehavior.Strict);

            _mockCheckpointStore.Setup(s => s.GetCheckpointAsync(_namespace, _eventHubName, _consumerGroup, It.IsAny<string>(), default))
                .Returns<string, string, string, string, CancellationToken>((ns, hub, cg, partitionId, ct) => Task.FromResult(_checkpoints.SingleOrDefault(cp => cp.PartitionId == partitionId)));

            //Act
            EventHubsMetricsProvider eventHubsMetricsProvider = new EventHubsMetricsProvider(_functionId, _consumerClientMock.Object,
                _mockCheckpointStore.Object, _loggerFactory);

            var metrics = eventHubsMetricsProvider.GetMetricsAsync();

            //Assert
            Assert.AreEqual(metrics.Result.PartitionCount, 5);
            Assert.AreEqual(metrics.Result.EventCount, 20);
            Assert.IsNotNull(metrics.Result.Timestamp);
        }

        [Test]
        public void GetMetricsAsyncLastEnqueuedSequenceNumberBiggerThenZero()
        {
            //Arrange
            _partitions = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 10)
            };

            _checkpoints = new EventProcessorCheckpoint[]
            {
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = 0,  SequenceNumber = 0 }
            };
            _consumerClientMock.Setup(client => client.GetPartitionsAsync())
               .Returns(() => Task.FromResult(_partitions.Select(p => p.Id).ToArray()));
            _consumerClientMock.Setup(client => client.GetPartitionPropertiesAsync(IsAny<string>()))
                .Returns((string id) => Task.FromResult(_partitions.SingleOrDefault(p => p.Id == id)));

            _mockCheckpointStore = new Mock<BlobCheckpointStoreInternal>(MockBehavior.Strict);

            _mockCheckpointStore.Setup(s => s.GetCheckpointAsync(_namespace, _eventHubName, _consumerGroup, It.IsAny<string>(), default))
                .Returns<string, string, string, string, CancellationToken>((ns, hub, cg, partitionId, ct) => Task.FromResult(_checkpoints.SingleOrDefault(cp => cp.PartitionId == partitionId)));

            //Act
            EventHubsMetricsProvider eventHubsMetricsProvider = new EventHubsMetricsProvider(_functionId, _consumerClientMock.Object,
                _mockCheckpointStore.Object, _loggerFactory);

            var metrics = eventHubsMetricsProvider.GetMetricsAsync();

            //Assert
            Assert.AreEqual(metrics.Result.PartitionCount, 1);
            Assert.AreEqual(metrics.Result.EventCount, 10);
            Assert.IsNotNull(metrics.Result.Timestamp);
        }
    }
}
