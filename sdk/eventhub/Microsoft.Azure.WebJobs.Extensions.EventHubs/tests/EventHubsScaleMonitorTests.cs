// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Messaging.EventHubs;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.EventHubs.Listeners;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Moq;
using Newtonsoft.Json;
using Xunit;
using static Moq.It;
using BlobProperties = Azure.Storage.Blobs.Models.BlobProperties;

namespace Microsoft.Azure.WebJobs.EventHubs.UnitTests
{
    public class EventHubsScaleMonitorTests
    {
        private readonly string _functionId = "EventHubsTriggerFunction";
        private readonly string _eventHubContainerName = "azure-webjobs-eventhub";
        private readonly string _eventHubName = "TestEventHubName";
        private readonly string _consumerGroup = "TestConsumerGroup";
        private readonly string _eventHubConnectionString = "Endpoint=sb://test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=";
        private readonly string _storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=EventHubScaleMonitorFakeTestAccount;AccountKey=ABCDEFG;EndpointSuffix=core.windows.net";

        private readonly Uri _storageUri = new Uri("https://eventhubsteststorageaccount.blob.core.windows.net/");
        private readonly EventHubsScaleMonitor _scaleMonitor;
        private readonly Mock<BlobContainerClient> _mockBlobContainer;
        private readonly TestLoggerProvider _loggerProvider;
        private readonly LoggerFactory _loggerFactory;

        public EventHubsScaleMonitorTests()
        {
            _mockBlobContainer = new Mock<BlobContainerClient>(MockBehavior.Strict, new Uri(_storageUri, _eventHubContainerName));
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

        [Fact]
        public void ScaleMonitorDescriptor_ReturnsExpectedValue()
        {
            Assert.Equal($"{_functionId}-EventHubTrigger-{_eventHubName}-{_consumerGroup}".ToLower(), _scaleMonitor.Descriptor.Id);
        }

        [Fact]
        public async void CreateTriggerMetrics_ReturnsExpectedResult()
        {
            EventHubsConnectionStringBuilder sb = new EventHubsConnectionStringBuilder(_eventHubConnectionString);
            string prefix = $"{sb.Endpoint.Host}/{_eventHubName.ToLower()}/{_consumerGroup}/0";

            var mockBlobReference = new Mock<BlobClient>(MockBehavior.Strict, new Uri(_storageUri, $"{_eventHubContainerName}/{prefix}"));

            _mockBlobContainer
                .Setup(c => c.GetBlobClient(prefix))
                .Returns(mockBlobReference.Object);

            SetupBlobMock(mockBlobReference, 0, 0);

            var partitionInfo = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 0)
            };

            var metrics = await _scaleMonitor.CreateTriggerMetrics(partitionInfo);

            Assert.Equal(0, metrics.EventCount);
            Assert.Equal(1, metrics.PartitionCount);
            Assert.NotEqual(default(DateTime), metrics.Timestamp);

            // Partition got its first message (Offset == null, LastEnqueued == 0)
            SetupBlobMock(mockBlobReference, null, 0);

            metrics = await _scaleMonitor.CreateTriggerMetrics(partitionInfo);

            Assert.Equal(1, metrics.EventCount);
            Assert.Equal(1, metrics.PartitionCount);
            Assert.NotEqual(default(DateTime), metrics.Timestamp);

            // No instances assigned to process events on partition (Offset == null, LastEnqueued > 0)
            SetupBlobMock(mockBlobReference, null, 0);

            partitionInfo = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 5)
            };

            metrics = await _scaleMonitor.CreateTriggerMetrics(partitionInfo);

            Assert.Equal(6, metrics.EventCount);
            Assert.Equal(1, metrics.PartitionCount);
            Assert.NotEqual(default(DateTime), metrics.Timestamp);

            // Checkpointing is ahead of partition info (SequenceNumber > LastEnqueued)
            SetupBlobMock(mockBlobReference, 25, 11);

            partitionInfo = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 10)
            };

            metrics = await _scaleMonitor.CreateTriggerMetrics(partitionInfo);

            Assert.Equal(0, metrics.EventCount);
            Assert.Equal(1, metrics.PartitionCount);
            Assert.NotEqual(default(DateTime), metrics.Timestamp);
        }

        [Fact]
        public async void CreateTriggerMetrics_MultiplePartitions_ReturnsExpectedResult()
        {
            EventHubsConnectionStringBuilder sb = new EventHubsConnectionStringBuilder(_eventHubConnectionString);
            string prefix = $"{sb.Endpoint.Host}/{_eventHubName.ToLower()}/{_consumerGroup}/";

            var mockBlobReference = new Mock<BlobClient>(MockBehavior.Strict, new Uri(_storageUri, $"{_eventHubContainerName}/{prefix}"));

            _mockBlobContainer
                .Setup(c => c.GetBlobClient(IsAny<string>()))
                .Returns(mockBlobReference.Object);

            // No messages processed, no messages in queue
            SetupBlobMock(mockBlobReference, 0, 0);
            SetupBlobMock(mockBlobReference, 0, 0);
            SetupBlobMock(mockBlobReference, 0, 0);

            var partitionInfo = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 0),
                new TestPartitionProperties(lastSequenceNumber: 0),
                new TestPartitionProperties(lastSequenceNumber: 0)
            };

            var metrics = await _scaleMonitor.CreateTriggerMetrics(partitionInfo);

            Assert.Equal(0, metrics.EventCount);
            Assert.Equal(3, metrics.PartitionCount);
            Assert.NotEqual(default(DateTime), metrics.Timestamp);

            // Messages processed, Messages in queue
            SetupBlobMock(mockBlobReference, 0, 2);
            SetupBlobMock(mockBlobReference, 0, 3);
            SetupBlobMock(mockBlobReference, 0, 4);

            partitionInfo = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 12),
                new TestPartitionProperties(lastSequenceNumber: 13),
                new TestPartitionProperties(lastSequenceNumber: 14)
            };

            metrics = await _scaleMonitor.CreateTriggerMetrics(partitionInfo);

            Assert.Equal(30, metrics.EventCount);
            Assert.Equal(3, metrics.PartitionCount);
            Assert.NotEqual(default(DateTime), metrics.Timestamp);

            // One invalid sample
            SetupBlobMock(mockBlobReference, 0, 2);
            SetupBlobMock(mockBlobReference, 0, 3);
            SetupBlobMock(mockBlobReference, 0, 4);

            partitionInfo = new List<PartitionProperties>
            {
                new TestPartitionProperties(lastSequenceNumber: 12),
                new TestPartitionProperties(lastSequenceNumber: 13),
                new TestPartitionProperties(lastSequenceNumber: 1)
            };

            metrics = await _scaleMonitor.CreateTriggerMetrics(partitionInfo);

            Assert.Equal(20, metrics.EventCount);
            Assert.Equal(3, metrics.PartitionCount);
            Assert.NotEqual(default(DateTime), metrics.Timestamp);
        }

        [Fact]
        public async Task CreateTriggerMetrics_HandlesExceptions()
        {
            // StorageException
            _mockBlobContainer
                .Setup(c => c.GetBlobClient(IsAny<string>()))
                .Throws(new RequestFailedException(404, "Not found"));

            var partitionInfo = new List<PartitionProperties>
            {
                new TestPartitionProperties()
            };

            var metrics = await _scaleMonitor.CreateTriggerMetrics(partitionInfo, true);

            Assert.Equal(1, metrics.PartitionCount);
            Assert.Equal(0, metrics.EventCount);
            Assert.NotEqual(default(DateTime), metrics.Timestamp);

            var warning = _loggerProvider.GetAllLogMessages().Single(p => p.Level == Extensions.Logging.LogLevel.Warning);
            var expectedWarning = $"Function '{_functionId}': Unable to deserialize partition or lease info with the following errors: " +
                                    $"Lease file data could not be found for blob on Partition: '0', EventHub: '{_eventHubName}', " +
                                    $"'{_consumerGroup}'. Error: Uh oh";
            Assert.Equal(expectedWarning, warning.FormattedMessage);
            _loggerProvider.ClearAllLogMessages();

            // JsonSerializationException
            _mockBlobContainer
                .Setup(c => c.GetBlobClient(IsAny<string>()))
                .Throws(new JsonSerializationException("Uh oh"));

            partitionInfo = new List<PartitionProperties>
            {
                new TestPartitionProperties()
            };

            metrics = await _scaleMonitor.CreateTriggerMetrics(partitionInfo, true);

            Assert.Equal(1, metrics.PartitionCount);
            Assert.Equal(0, metrics.EventCount);
            Assert.NotEqual(default(DateTime), metrics.Timestamp);

            warning = _loggerProvider.GetAllLogMessages().Single(p => p.Level == Extensions.Logging.LogLevel.Warning);
            expectedWarning = $"Function '{_functionId}': Unable to deserialize partition or lease info with the following errors: " +
                                $"Could not deserialize blob lease info for blob on Partition: '0', EventHub: '{_eventHubName}', " +
                                $"Consumer Group: '{_consumerGroup}'. Error: Uh oh";
            Assert.Equal(expectedWarning, warning.FormattedMessage);
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

            Assert.Equal(1, metrics.PartitionCount);
            Assert.Equal(0, metrics.EventCount);
            Assert.NotEqual(default(DateTime), metrics.Timestamp);

            warning = _loggerProvider.GetAllLogMessages().Single(p => p.Level == Extensions.Logging.LogLevel.Warning);
            expectedWarning = $"Function '{_functionId}': Unable to deserialize partition or lease info with the following errors: " +
                                $"Encountered exception while checking for last checkpointed sequence number for blob on Partition: '0', " +
                                $"EventHub: '{_eventHubName}', Consumer Group: '{_consumerGroup}'. Error: Uh oh";
            Assert.Equal(expectedWarning, warning.FormattedMessage);
            _loggerProvider.ClearAllLogMessages();
        }

        [Fact]
        public void GetScaleStatus_NoMetrics_ReturnsVote_None()
        {
            var context = new ScaleStatusContext<EventHubsTriggerMetrics>
            {
                WorkerCount = 1
            };

            var status = _scaleMonitor.GetScaleStatus(context);
            Assert.Equal(ScaleVote.None, status.Vote);

            // verify the non-generic implementation works properly
            status = ((IScaleMonitor)_scaleMonitor).GetScaleStatus(context);
            Assert.Equal(ScaleVote.None, status.Vote);
        }

        [Fact]
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
            Assert.Equal(ScaleVote.ScaleIn, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.Equal(Extensions.Logging.LogLevel.Information, log.Level);
            Assert.Equal("WorkerCount (17) > PartitionCount (16).", log.FormattedMessage);
            log = logs[1];
            Assert.Equal(Extensions.Logging.LogLevel.Information, log.Level);
            Assert.Equal($"Number of instances (17) is too high relative to number of partitions (16) for EventHubs entity ({_eventHubName}, {_consumerGroup}).", log.FormattedMessage);

            // verify again with a non generic context instance
            var context2 = new ScaleStatusContext
            {
                WorkerCount = 1,
                Metrics = eventHubTriggerMetrics
            };
            status = ((IScaleMonitor)_scaleMonitor).GetScaleStatus(context2);
            Assert.Equal(ScaleVote.ScaleOut, status.Vote);
        }

        [Fact]
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
            Assert.Equal(ScaleVote.ScaleOut, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.Equal(Extensions.Logging.LogLevel.Information, log.Level);
            Assert.Equal("EventCount (2900) > WorkerCount (1) * 1,000.", log.FormattedMessage);
            log = logs[1];
            Assert.Equal(Extensions.Logging.LogLevel.Information, log.Level);
            Assert.Equal($"Event count (2900) for EventHubs entity ({_eventHubName}, {_consumerGroup}) " +
                         $"is too high relative to the number of instances (1).", log.FormattedMessage);

            // verify again with a non generic context instance
            var context2 = new ScaleStatusContext
            {
                WorkerCount = 1,
                Metrics = eventHubTriggerMetrics
            };
            status = ((IScaleMonitor)_scaleMonitor).GetScaleStatus(context2);
            Assert.Equal(ScaleVote.ScaleOut, status.Vote);
        }

        [Fact]
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
            Assert.Equal(ScaleVote.ScaleIn, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.Equal(Extensions.Logging.LogLevel.Information, log.Level);
            Assert.Equal($"'{_eventHubName}' is idle.", log.FormattedMessage);
        }

        [Fact]
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
            Assert.Equal(ScaleVote.ScaleOut, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.Equal(Extensions.Logging.LogLevel.Information, log.Level);
            Assert.Equal($"Event count is increasing for '{_eventHubName}'.", log.FormattedMessage);
        }

        [Fact]
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
            Assert.Equal(ScaleVote.ScaleIn, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.Equal(Extensions.Logging.LogLevel.Information, log.Level);
            Assert.Equal($"Event count is decreasing for '{_eventHubName}'.", log.FormattedMessage);
        }

        [Fact]
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
            Assert.Equal(ScaleVote.None, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.Equal(Extensions.Logging.LogLevel.Information, log.Level);
            Assert.Equal($"EventHubs entity '{_eventHubName}' is steady.", log.FormattedMessage);
        }

        private static void SetupBlobMock(Mock<BlobClient> mock, int? offset, int? sequencenumber)
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

            // No messages processed, no messages in queue
            mock
                .Setup(m => m.GetPropertiesAsync(IsAny<BlobRequestConditions>(), IsAny<CancellationToken>()))
                .ReturnsAsync(response);
        }
    }
}
