// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Messaging.EventHubs;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Azure.WebJobs.EventHubs.Listeners;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Language;
using NUnit.Framework;
using static Moq.It;

namespace Microsoft.Azure.WebJobs.EventHubs.UnitTests
{
    public class EventHubsScaleMonitorTests
    {
        private readonly string _functionId = "EventHubsTriggerFunction";
        private readonly string _eventHubName = "TestEventHubName";
        private readonly string _consumerGroup = "TestConsumerGroup";
        private readonly string _eventHubConnectionString = "Endpoint=sb://test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=";
        private readonly string _storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=EventHubScaleMonitorFakeTestAccount;AccountKey=ABCDEFG;EndpointSuffix=core.windows.net";

        private EventHubsScaleMonitor _scaleMonitor;
        private Mock<BlobContainerClient> _mockBlobContainer;
        private TestLoggerProvider _loggerProvider;
        private LoggerFactory _loggerFactory;

        [SetUp]
        public void SetUp()
        {
            _mockBlobContainer = new Mock<BlobContainerClient>(MockBehavior.Strict);
            _loggerFactory = new LoggerFactory();
            _loggerProvider = new TestLoggerProvider();
            _loggerFactory.AddProvider(_loggerProvider);

            _scaleMonitor = new EventHubsScaleMonitor(
                                    _functionId,
                                    _eventHubName,
                                    _consumerGroup,
                                    _eventHubConnectionString,
                                    _storageConnectionString,
                                    _loggerFactory.CreateLogger(LogCategories.CreateTriggerCategory("EventHub")),
                                    _mockBlobContainer.Object);
        }

        [Test]
        public void ScaleMonitorDescriptor_ReturnsExpectedValue()
        {
            Assert.AreEqual($"{_functionId}-EventHubTrigger-{_eventHubName}-{_consumerGroup}".ToLower(), _scaleMonitor.Descriptor.Id);
        }

        [Test]
        public async Task CreateTriggerMetrics_ReturnsExpectedResult()
        {
            EventHubsConnectionStringBuilder sb = new EventHubsConnectionStringBuilder(_eventHubConnectionString);
            string prefix = $"{sb.Endpoint.Host}/{_eventHubName.ToLower()}/{_consumerGroup}/checkpoint/0";

            var mockBlobReference = new Mock<BlobClient>(MockBehavior.Strict);
            var sequence = mockBlobReference.SetupSequence(m => m.GetPropertiesAsync(IsAny<BlobRequestConditions>(), IsAny<CancellationToken>()));

            _mockBlobContainer
                .Setup(c => c.GetBlobClient(prefix))
                .Returns(mockBlobReference.Object);

            SetupBlobMock(sequence, 0, 0);

            var partitionInfo = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 0)
            };

            var metrics = await _scaleMonitor.CreateTriggerMetrics(partitionInfo);

            Assert.AreEqual(0, metrics.EventCount);
            Assert.AreEqual(1, metrics.PartitionCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // Partition got its first message (Offset == null, LastEnqueued == 0)
            SetupBlobMock(sequence, null, 0);

            metrics = await _scaleMonitor.CreateTriggerMetrics(partitionInfo);

            Assert.AreEqual(1, metrics.EventCount);
            Assert.AreEqual(1, metrics.PartitionCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // No instances assigned to process events on partition (Offset == null, LastEnqueued > 0)
            SetupBlobMock(sequence, null, 0);

            partitionInfo = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 5)
            };

            metrics = await _scaleMonitor.CreateTriggerMetrics(partitionInfo);

            Assert.AreEqual(6, metrics.EventCount);
            Assert.AreEqual(1, metrics.PartitionCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // Checkpointing is ahead of partition info (SequenceNumber > LastEnqueued)
            SetupBlobMock(sequence, 25, 11);

            partitionInfo = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 10)
            };

            metrics = await _scaleMonitor.CreateTriggerMetrics(partitionInfo);

            Assert.AreEqual(0, metrics.EventCount);
            Assert.AreEqual(1, metrics.PartitionCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);
        }

        [Test]
        public async Task CreateTriggerMetrics_MultiplePartitions_ReturnsExpectedResult()
        {
            EventHubsConnectionStringBuilder sb = new EventHubsConnectionStringBuilder(_eventHubConnectionString);

            var mockBlobReference = new Mock<BlobClient>(MockBehavior.Strict);
            var sequence = mockBlobReference.SetupSequence(m => m.GetPropertiesAsync(IsAny<BlobRequestConditions>(), IsAny<CancellationToken>()));

            _mockBlobContainer
                .Setup(c => c.GetBlobClient(IsAny<string>()))
                .Returns(mockBlobReference.Object);

            // No messages processed, no messages in queue
            SetupBlobMock(sequence, 0, 0);
            SetupBlobMock(sequence, 0, 0);
            SetupBlobMock(sequence, 0, 0);

            var partitionInfo = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 0),
                new TestPartitionProperties(lastSequenceNumber: 0),
                new TestPartitionProperties(lastSequenceNumber: 0)
            };

            var metrics = await _scaleMonitor.CreateTriggerMetrics(partitionInfo);

            Assert.AreEqual(0, metrics.EventCount);
            Assert.AreEqual(3, metrics.PartitionCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // Messages processed, Messages in queue
            SetupBlobMock(sequence, 0, 2);
            SetupBlobMock(sequence, 0, 3);
            SetupBlobMock(sequence, 0, 4);

            partitionInfo = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 12),
                new TestPartitionProperties(lastSequenceNumber: 13),
                new TestPartitionProperties(lastSequenceNumber: 14)
            };

            metrics = await _scaleMonitor.CreateTriggerMetrics(partitionInfo);

            Assert.AreEqual(30, metrics.EventCount);
            Assert.AreEqual(3, metrics.PartitionCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // One invalid sample
            SetupBlobMock(sequence, 0, 2);
            SetupBlobMock(sequence, 0, 3);
            SetupBlobMock(sequence, 0, 4);

            partitionInfo = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 12),
                new TestPartitionProperties(lastSequenceNumber: 13),
                new TestPartitionProperties(lastSequenceNumber: 1)
            };

            metrics = await _scaleMonitor.CreateTriggerMetrics(partitionInfo);

            Assert.AreEqual(20, metrics.EventCount);
            Assert.AreEqual(3, metrics.PartitionCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);
        }

        [Test]
        public async Task CreateTriggerMetrics_HandlesExceptions()
        {
            // StorageException
            _mockBlobContainer
                .Setup(c => c.GetBlobClient(IsAny<string>()))
                .Throws(new RequestFailedException(404, "Uh oh"));

            var partitionInfo = new List<PartitionProperties>
            {
                new TestPartitionProperties()
            };

            var metrics = await _scaleMonitor.CreateTriggerMetrics(partitionInfo, true);

            Assert.AreEqual(1, metrics.PartitionCount);
            Assert.AreEqual(0, metrics.EventCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            var warning = _loggerProvider.GetAllLogMessages().Single(p => p.Level == Extensions.Logging.LogLevel.Warning);
            var expectedWarning = $"Function '{_functionId}': Unable to deserialize partition or lease info with the following errors: " +
                                    $"Checkpoint file data could not be found for blob on Partition: '0', EventHub: '{_eventHubName}', " +
                                    $"'{_consumerGroup}'. Error: Uh oh";
            Assert.AreEqual(expectedWarning, warning.FormattedMessage);
            _loggerProvider.ClearAllLogMessages();

            // Generic Exception
            _mockBlobContainer
                .Setup(c => c.GetBlobClient(IsAny<string>()))
                .Throws(new Exception("Uh oh"));

            partitionInfo = new List<PartitionProperties>
            {
                new TestPartitionProperties()
            };

            metrics = await _scaleMonitor.CreateTriggerMetrics(partitionInfo, true);

            Assert.AreEqual(1, metrics.PartitionCount);
            Assert.AreEqual(0, metrics.EventCount);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            warning = _loggerProvider.GetAllLogMessages().Single(p => p.Level == Extensions.Logging.LogLevel.Warning);
            expectedWarning = $"Function '{_functionId}': Unable to deserialize partition or lease info with the following errors: " +
                                $"Encountered exception while checking for last checkpointed sequence number for blob on Partition: '0', " +
                                $"EventHub: '{_eventHubName}', Consumer Group: '{_consumerGroup}'. Error: Uh oh";
            Assert.AreEqual(expectedWarning, warning.FormattedMessage);
            _loggerProvider.ClearAllLogMessages();
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
            Assert.AreEqual(Extensions.Logging.LogLevel.Information, log.Level);
            Assert.AreEqual("WorkerCount (17) > PartitionCount (16).", log.FormattedMessage);
            log = logs[1];
            Assert.AreEqual(Extensions.Logging.LogLevel.Information, log.Level);
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
            Assert.AreEqual(Extensions.Logging.LogLevel.Information, log.Level);
            Assert.AreEqual("EventCount (2900) > WorkerCount (1) * 1,000.", log.FormattedMessage);
            log = logs[1];
            Assert.AreEqual(Extensions.Logging.LogLevel.Information, log.Level);
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
            Assert.AreEqual(Extensions.Logging.LogLevel.Information, log.Level);
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
            Assert.AreEqual(Extensions.Logging.LogLevel.Information, log.Level);
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
            Assert.AreEqual(Extensions.Logging.LogLevel.Information, log.Level);
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
            Assert.AreEqual(Extensions.Logging.LogLevel.Information, log.Level);
            Assert.AreEqual($"EventHubs entity '{_eventHubName}' is steady.", log.FormattedMessage);
        }

        private static void SetupBlobMock(ISetupSequentialResult<Task<Response<BlobProperties>>> mock, int? offset, int? sequencenumber)
        {
            var metadata = new Dictionary<string, string>();
            if (offset != null)
            {
                metadata.Add("offset", offset.ToString());
            }

            if (sequencenumber != null)
            {
                metadata.Add("sequencenumber", sequencenumber.ToString());
            }

            var response = Response.FromValue(BlobsModelFactory.BlobProperties(default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, metadata, default, default, default, default), Mock.Of<Response>());

            mock.ReturnsAsync(response);
        }
    }
}
