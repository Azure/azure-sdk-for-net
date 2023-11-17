// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !NET462
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Samples.Processor.HostedService;
using Azure.Messaging.EventHubs.Tests;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using static Azure.Messaging.EventHubs.Tests.EventProcessorClientTests;

namespace Azure.Messaging.EventHubs.Processor.Tests.Samples
{
    [TestFixture]
    public class HostedServiceTests
    {
        [Test]
        public async Task HostedServiceProcessesEventWhenEventIsReceived()
        {
            var mockCheckpointStore = new Mock<CheckpointStore>();
            var mockLogger = new Mock<ILogger<EventProcessorClientService>>();
            var processorClient = new TestEventProcessorClient(mockCheckpointStore.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
            var mockAppProcessor = new Mock<ISampleApplicationProcessor>();

            var service = new EventProcessorClientService(mockLogger.Object, processorClient, mockAppProcessor.Object);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            await service.StartAsync(cancellationSource.Token);

            var eventBody = "Test";

            MockEventData[] eventBatch = new[]
            {
                new MockEventData(Encoding.ASCII.GetBytes(eventBody))
            };

            await processorClient.InvokeOnProcessingEventBatchAsync(eventBatch, new TestEventProcessorPartition("0"), cancellationSource.Token);

            mockAppProcessor.Verify(processor => processor.Process(eventBody), Times.Once());
        }

        [Test]
        public async Task HostedServiceLogsExceptions()
        {
            var mockCheckpointStore = new Mock<CheckpointStore>();
            var mockLogger = new Mock<ILogger<EventProcessorClientService>>();
            var processorClient = new TestEventProcessorClient(mockCheckpointStore.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
            var mockAppProcessor = new Mock<ISampleApplicationProcessor>();

            var service = new EventProcessorClientService(mockLogger.Object, processorClient, mockAppProcessor.Object);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

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
            var mockCheckpointStore = new Mock<CheckpointStore>();
            var mockLogger = new Mock<ILogger<EventProcessorClientService>>();
            var processorClient = new TestEventProcessorClient(mockCheckpointStore.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
            var mockAppProcessor = new Mock<ISampleApplicationProcessor>();

            var service = new EventProcessorClientService(mockLogger.Object, processorClient, mockAppProcessor.Object);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            await service.StartAsync(cancellationSource.Token);

            Assert.IsTrue(processorClient.IsRunning);
        }

        [Test]
        public async Task StoppingHostedServiceStopsEventProcessing()
        {
            var mockCheckpointStore = new Mock<CheckpointStore>();
            var mockLogger = new Mock<ILogger<EventProcessorClientService>>();
            var processorClient = new TestEventProcessorClient(mockCheckpointStore.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
            var mockAppProcessor = new Mock<ISampleApplicationProcessor>();

            var service = new EventProcessorClientService(mockLogger.Object, processorClient, mockAppProcessor.Object);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            await service.StartAsync(cancellationSource.Token);
            await service.StopAsync(cancellationSource.Token);

            Assert.IsFalse(processorClient.IsRunning);
        }
    }
}
#endif
