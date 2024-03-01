// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET6_0_OR_GREATER
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Processor.Samples.HostedService.Tests
{
    [TestFixture]
    public class HostedServiceTests
    {
        [Test]
        public async Task HostedServiceProcessesEventWhenEventIsReceived()
        {
            var eventBody = "Test";
            var mockCheckpointStore = new Mock<BlobContainerClient>();
            var mockLogger = new Mock<ILogger<EventProcessorClientService>>();
            var processorClient = new TestEventProcessorClient(mockCheckpointStore.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>());
            var mockAppProcessor = new Mock<ISampleApplicationProcessor>();
            var service = new EventProcessorClientService(mockLogger.Object, processorClient, mockAppProcessor.Object);

            var eventBatch = new[]
            {
                new EventData(eventBody)
            };

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

            await service.StartAsync(cancellationSource.Token);
            await processorClient.InvokeOnProcessingEventBatchAsync(eventBatch, new TestEventProcessorPartition("0"), cancellationSource.Token);
            mockAppProcessor.Verify(processor => processor.Process(eventBody), Times.Once());
        }

        [Test]
        public async Task HostedServiceLogsExceptions()
        {
            var expectedException = new Exception("Test");
            var mockCheckpointStore = new Mock<BlobContainerClient>();
            var mockLogger = new Mock<ILogger<EventProcessorClientService>>();
            var processorClient = new TestEventProcessorClient(mockCheckpointStore.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>());
            var mockAppProcessor = new Mock<ISampleApplicationProcessor>();
            var service = new EventProcessorClientService(mockLogger.Object, processorClient, mockAppProcessor.Object);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

            await service.StartAsync(cancellationSource.Token);
            await processorClient.InvokeOnProcessingErrorAsync(expectedException, new TestEventProcessorPartition("0"), "TEST", cancellationSource.Token);

            mockLogger
                .Verify(logger => logger.Log(
                    It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((@object, @type) => true),
                    expectedException,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);

            mockAppProcessor
                .Verify(processor => processor.Process(It.IsAny<string>()), Times.Never());
        }

        [Test]
        public async Task StartingHostedServiceStartsEventProcessing()
        {
            var mockCheckpointStore = new Mock<BlobContainerClient>();
            var mockLogger = new Mock<ILogger<EventProcessorClientService>>();
            var processorClient = new TestEventProcessorClient(mockCheckpointStore.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>());
            var mockAppProcessor = new Mock<ISampleApplicationProcessor>();

            var service = new EventProcessorClientService(mockLogger.Object, processorClient, mockAppProcessor.Object);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

            await service.StartAsync(cancellationSource.Token);
            Assert.That(processorClient.IsRunning, Is.True);
        }

        [Test]
        public async Task StoppingHostedServiceStopsEventProcessing()
        {
            var mockCheckpointStore = new Mock<BlobContainerClient>();
            var mockLogger = new Mock<ILogger<EventProcessorClientService>>();
            var processorClient = new TestEventProcessorClient(mockCheckpointStore.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>());
            var mockAppProcessor = new Mock<ISampleApplicationProcessor>();
            var service = new EventProcessorClientService(mockLogger.Object, processorClient, mockAppProcessor.Object);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

            await service.StartAsync(cancellationSource.Token);
            await service.StopAsync(cancellationSource.Token);

            Assert.That(processorClient.IsRunning, Is.False);
        }

        public class TestEventProcessorClient : EventProcessorClient
        {
            internal TestEventProcessorClient(BlobContainerClient checkpointStore,
                                              string consumerGroup,
                                              string fullyQualifiedNamespace,
                                              string eventHubName,
                                              TokenCredential tokenCredential)
                : base(checkpointStore, consumerGroup, fullyQualifiedNamespace, eventHubName, tokenCredential)
            {
            }

            public Task InvokeOnProcessingEventBatchAsync(IEnumerable<EventData> events, EventProcessorPartition partition, CancellationToken cancellationToken) => base.OnProcessingEventBatchAsync(events, partition, cancellationToken);
            public Task InvokeOnProcessingErrorAsync(Exception exception, EventProcessorPartition partition, string operationDescription, CancellationToken cancellationToken) => base.OnProcessingErrorAsync(exception, partition, operationDescription, cancellationToken);
            protected override Task ValidateProcessingPreconditions(CancellationToken cancellationToken = default) => Task.CompletedTask;
        }

        public class TestEventProcessorPartition : EventProcessorPartition
        {
            public TestEventProcessorPartition(string partitionId) { PartitionId = partitionId; }
        }
    }
}
#endif
