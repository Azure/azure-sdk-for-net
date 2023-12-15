// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !NET462
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Processor.HostedService.Samples.Tests
{
    [TestFixture]
    public class HostedServiceTests
    {
        [Test]
        public async Task HostedServiceProcessesEventWhenEventIsReceived()
        {
            var mockCheckpointStore = new Mock<BlobContainerClient>();
            var mockLogger = new Mock<ILogger<EventProcessorClientService>>();
            var processorClient = new TestEventProcessorClient(mockCheckpointStore.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>());
            var mockAppProcessor = new Mock<ISampleApplicationProcessor>();

            var service = new EventProcessorClientService(mockLogger.Object, processorClient, mockAppProcessor.Object);

            using var cancellationSource = new CancellationTokenSource();

            await service.StartAsync(cancellationSource.Token);

            var eventBody = "Test";

            EventData[] eventBatch = new[]
            {
                new EventData(Encoding.ASCII.GetBytes(eventBody))
            };

            await processorClient.InvokeOnProcessingEventBatchAsync(eventBatch, new TestEventProcessorPartition("0"), cancellationSource.Token);

            mockAppProcessor.Verify(processor => processor.Process(eventBody), Times.Once());
        }

        [Test]
        public async Task HostedServiceLogsExceptions()
        {
            var mockCheckpointStore = new Mock<BlobContainerClient>();
            var mockLogger = new Mock<ILogger<EventProcessorClientService>>();
            var processorClient = new TestEventProcessorClient(mockCheckpointStore.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>());
            var mockAppProcessor = new Mock<ISampleApplicationProcessor>();

            var service = new EventProcessorClientService(mockLogger.Object, processorClient, mockAppProcessor.Object);

            using var cancellationSource = new CancellationTokenSource();

            await service.StartAsync(cancellationSource.Token);

            var expectedException = new Exception("Test");

            await processorClient.InvokeOnProcessingErrorAsync(expectedException, new TestEventProcessorPartition("0"), "TEST", cancellationSource.Token);

            mockLogger.Verify(logger => logger.Log(
                    It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((@object, @type) => true),
                    expectedException,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);

            mockAppProcessor.Verify(processor => processor.Process(It.IsAny<string>()), Times.Never());
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

            await service.StartAsync(cancellationSource.Token);

            Assert.IsTrue(processorClient.IsRunning);
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

            await service.StartAsync(cancellationSource.Token);
            await service.StopAsync(cancellationSource.Token);

            Assert.IsFalse(processorClient.IsRunning);
        }

        /// <summary>
        ///   A mock <see cref="EventProcessorClient" /> used for testing purposes.
        /// </summary>
        ///
        public class TestEventProcessorClient : EventProcessorClient
        {
            internal TestEventProcessorClient(BlobContainerClient checkpointStore,
                                              string consumerGroup,
                                              string fullyQualifiedNamespace,
                                              string eventHubName,
                                              TokenCredential tokenCredential) : base(checkpointStore, consumerGroup, fullyQualifiedNamespace, eventHubName, tokenCredential)
            {}

            public Task InvokeOnProcessingEventBatchAsync(IEnumerable<EventData> events, EventProcessorPartition partition, CancellationToken cancellationToken) => base.OnProcessingEventBatchAsync(events, partition, cancellationToken);
            public Task InvokeOnProcessingErrorAsync(Exception exception, EventProcessorPartition partition, string operationDescription, CancellationToken cancellationToken) => base.OnProcessingErrorAsync(exception, partition, operationDescription, cancellationToken);
            protected override Task ValidateProcessingPreconditions(CancellationToken cancellationToken = default) => Task.CompletedTask;
        }

        /// <summary>
        ///   A mock <see cref="EventProcessorPartition" /> used for testing purposes.
        /// </summary>
        ///
        public class TestEventProcessorPartition : EventProcessorPartition
        {
            public TestEventProcessorPartition(string partitionId) { PartitionId = partitionId; }
        }
    }
}
#endif
