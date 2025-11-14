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

        private readonly string _errorMessage = "Uh oh";

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

            _mockCheckpointStore
                .Setup(s => s.GetCheckpointAsync(
                    _namespace,
                    _eventHubName,
                    _consumerGroup,
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Returns<string, string, string, string, CancellationToken>((ns, hub, cg, partitionId, ct) =>
                {
                    if (ct.IsCancellationRequested)
                    {
                        throw new TaskCanceledException();
                    }

                    var checkpoint = _checkpoints == null
                        ? null
                        : _checkpoints.SingleOrDefault(cp => cp.PartitionId == partitionId);

                    return Task.FromResult(checkpoint);
                });

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
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = "0",  SequenceNumber = 0 }
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
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = "999", SequenceNumber = 11 }
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
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = "0",  SequenceNumber = 0, PartitionId = "1" },
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = "0",  SequenceNumber = 0, PartitionId = "2" },
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = "0",  SequenceNumber = 0, PartitionId = "3" }
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
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = "0",  SequenceNumber = 2, PartitionId = "1" },
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = "0",  SequenceNumber = 3, PartitionId = "2" },
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = "0",  SequenceNumber = 4, PartitionId = "3" }
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
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = "0",  SequenceNumber = 2, PartitionId = "1" },
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = "0",  SequenceNumber = 3, PartitionId = "2" },
                new BlobCheckpointStoreInternal.BlobStorageCheckpoint { Offset = "0",  SequenceNumber = 4, PartitionId = "3" }
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
                .ThrowsAsync(new RequestFailedException(404, _errorMessage));
            // Clear previous logs
            _loggerProvider.ClearAllLogMessages();

            _partitions = new List<PartitionProperties>
            {
                new TestPartitionProperties()
            };

            var metrics = await _metricsProvider.GetMetricsAsync();

            Assert.AreEqual(1, metrics.PartitionCount);
            Assert.AreEqual(1, metrics.EventCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);
            AssertGetCheckpointAsyncErrorLogs(_partitions.First().Id, _errorMessage);

            // Generic Exception
            _mockCheckpointStore
                .Setup(c => c.GetCheckpointAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception(_errorMessage));
            // Clear previous logs
            _loggerProvider.ClearAllLogMessages();

            _partitions = new List<PartitionProperties>
            {
                new TestPartitionProperties()
            };

            metrics = await _metricsProvider.GetMetricsAsync();

            Assert.AreEqual(1, metrics.PartitionCount);
            Assert.AreEqual(1, metrics.EventCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);
            AssertGetCheckpointAsyncErrorLogs(_partitions.First().Id, _errorMessage);

            _loggerProvider.ClearAllLogMessages();
        }

        private void AssertGetCheckpointAsyncErrorLogs(string partitionId, string message)
        {
            var logs = _loggerProvider.GetAllLogMessages().ToList();
            Assert.That(logs.Any(l =>
                    l.Level == LogLevel.Debug),
                $"Requesting cancellation of other checkpoint tasks. Error while getting checkpoint for eventhub '{_eventHubName}', partition '{partitionId}': {message}");
            Assert.That(logs.Any(l =>
                    l.Level == LogLevel.Warning),
                $"Encountered an exception while getting checkpoints for Event Hub '{_eventHubName}' used for scaling. Error: {message}");
        }

        [TestCase(false, 0, -1, -1, 0)] // Microsoft.Azure.Functions.Worker.Extensions.EventHubs < 5.0.0, auto created checkpoint, no events sent
        [TestCase(true, 0, -1, -1, 0)] // Microsoft.Azure.Functions.Worker.Extensions.EventHubs >= 5.0.0, no checkpoint, no events sent
        [TestCase(false, 0, 0, 0, 0)] // Microsoft.Azure.Functions.Worker.Extensions.EventHubs < 5.0.0, auto created checkpoint, 1 event sent. Know issue: we are not scalling out in this case.
        [TestCase(true, 0, 0, 0, 1)] // Microsoft.Azure.Functions.Worker.Extensions.EventHubs >= 5.0.0, no checkpoint, 1 event sent
        [TestCase(false, 0, 0, 1, 1)] // Microsoft.Azure.Functions.Worker.Extensions.EventHubs < 5.0.0, auto created checkpoint, 2 events sent
        [TestCase(false, 0, 0, 1, 1)] // Microsoft.Azure.Functions.Worker.Extensions.EventHubs >= 5.0.0, no checkpoint, 2 events sent
        [TestCase(false, 0, 0, 1, 1)] // checkpoint for 1 event created, 1 more event sent
        [TestCase(false, 0, 0, 2, 2)] // checkpoint for 1 event created, 2 more event sent
        [TestCase(false, 1, 0, 2, 1)] // checkpoint for 2 events created, 1 more event sent
        [TestCase(false, 1, 0, 3, 2)] // checkpoint for 2 events created, more event sent
        [TestCase(false, 0, 0, 0, 0)] // checkpoint for 1 events created, no events sent
        [TestCase(false, 1, 0, 1, 0)] // checkpoint for 2 events created, no events sent
        public async Task CreateTriggerMetrics_DifferentCheckpointFormats_ReturnsExpectedResult(
            bool isNullCheckpoint,
            long checkpointSequenceNumber,
            long partitionBeginningSequenceNumber,
            long partitionLastSequenceNumber,
            long expectedUnprocessedMessageCount)
        {
            if (!isNullCheckpoint)
            {
                this._checkpoints = new EventProcessorCheckpoint[]
                {
                    new BlobCheckpointStoreInternal.BlobStorageCheckpoint { SequenceNumber = checkpointSequenceNumber, PartitionId = "0" }
                };
            }
            else
            {
                this._checkpoints = null;
            }

            _partitions = new List<PartitionProperties>
            {
                new TestPartitionProperties(beginningSequenceNumber: partitionBeginningSequenceNumber, lastSequenceNumber: partitionLastSequenceNumber, partitionId: "0"),
            };

            var metrics = await _metricsProvider.GetMetricsAsync();
            Assert.AreEqual(expectedUnprocessedMessageCount, metrics.EventCount);
        }

        private Task<EventProcessorCheckpoint> WaitTillCancelled(CancellationToken ct, string partition)
        {
            var tcs = new TaskCompletionSource<EventProcessorCheckpoint>(TaskCreationOptions.RunContinuationsAsynchronously);

            if (ct.IsCancellationRequested)
            {
                _loggerProvider.CreatedLoggers.First().LogDebug($"Cancellation requested for partition {partition}");
                throw new TaskCanceledException();
            }

            ct.Register(state => ((TaskCompletionSource<EventProcessorCheckpoint>)state).TrySetCanceled(),
                        tcs);

            return tcs.Task;
        }

        [Test]
        public async Task CreateTriggerMetric_CancellationCascades_AfterFirstFailure()
        {
            _partitions = new List<PartitionProperties>
            {
                new TestPartitionProperties(partitionId: "0"),
                new TestPartitionProperties(partitionId: "1"),
                new TestPartitionProperties(partitionId: "2")
            };

            _checkpoints = Array.Empty<EventProcessorCheckpoint>();

            _loggerProvider.ClearAllLogMessages();

            // First partition triggers token cancellation
            _mockCheckpointStore
                .Setup(s => s.GetCheckpointAsync(_namespace, _eventHubName, _consumerGroup, "0", It.IsAny<CancellationToken>()))
                .Returns(async (string ns, string hub, string cg, string partitionId, CancellationToken ct) =>
                {
                    await Task.Delay(500);
                    throw new Exception(_errorMessage);
                });

            // Other partitions wait till cancellation is requested
            _mockCheckpointStore
                .Setup(s => s.GetCheckpointAsync(
                    _namespace, _eventHubName, _consumerGroup,
                    It.Is<string>(p => p == "1" || p == "2"),
                    It.IsAny<CancellationToken>()))
                .Returns<string, string, string, string, CancellationToken>((ns, hub, cg, pid, ct) =>
                    WaitTillCancelled(ct, pid));

            var metrics = await _metricsProvider.GetMetricsAsync();

            Assert.AreEqual(3, metrics.PartitionCount);
            var logs = _loggerProvider.GetAllLogMessages().ToList();

            AssertGetCheckpointAsyncErrorLogs("0", _errorMessage);
            Assert.That(logs.Any(), "Cancellation requested for partition 1");
            Assert.That(logs.Any(), "Cancellation requested for partition 2");

            _mockCheckpointStore.Verify(s =>
                s.GetCheckpointAsync(_namespace, _eventHubName, _consumerGroup, It.IsAny<string>(), It.IsAny<CancellationToken>()),
                Times.Exactly(3));
        }
    }
}
