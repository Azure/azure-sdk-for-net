// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Storage.Blobs;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class Sample09_AdvancedProcessorMockingLiveTests
    {
        [Test]
        public async Task RaiseRegisteredHandlers()
        {
            #region Snippet:EventHubs_AdvancedProcessorMocking
            Mock<BlobContainerClient> checkpointStore = new();
            TestableEventProcessorClient processor = new(
                checkpointStore.Object,
                EventHubConsumerClient.DefaultConsumerGroupName,
                "namespace.servicebus.windows.net",
                "event-hub",
                new AzureNamedKeyCredential("credential-name", "credential-key"));
            List<string> invokedHandlers = new();

            Task ProcessEventHandler(ProcessEventArgs args)
            {
                invokedHandlers.Add($"event:{args.Data.SequenceNumber}");
                return Task.CompletedTask;
            }

            Task ProcessErrorHandler(ProcessErrorEventArgs args)
            {
                invokedHandlers.Add("error");
                return Task.CompletedTask;
            }

            Task PartitionInitializingHandler(PartitionInitializingEventArgs args)
            {
                invokedHandlers.Add($"opening:{args.PartitionId}");
                return Task.CompletedTask;
            }

            Task PartitionClosingHandler(PartitionClosingEventArgs args)
            {
                invokedHandlers.Add($"closing:{args.PartitionId}");
                return Task.CompletedTask;
            }

            try
            {
                processor.ProcessEventAsync += ProcessEventHandler;
                processor.ProcessErrorAsync += ProcessErrorHandler;
                processor.PartitionInitializingAsync += PartitionInitializingHandler;
                processor.PartitionClosingAsync += PartitionClosingHandler;

                EventData eventData = EventHubsModelFactory.EventData(
                    eventBody: new BinaryData("event"),
                    sequenceNumber: 42,
                    offsetString: "100");

                await processor.RaisePartitionInitializingAsync("0");
                await processor.RaiseProcessingEventAsync(eventData, "0");
                await processor.RaiseProcessingErrorAsync(
                    new InvalidOperationException("Simulated processor error"),
                    "0",
                    "Receive");
                await processor.RaisePartitionClosingAsync(
                    "0",
                    ProcessingStoppedReason.Shutdown);

                Assert.That(
                    invokedHandlers,
                    Is.EqualTo(new[]
                    {
                        "opening:0",
                        "event:42",
                        "error",
                        "closing:0"
                    }));
            }
            finally
            {
                processor.ProcessEventAsync -= ProcessEventHandler;
                processor.ProcessErrorAsync -= ProcessErrorHandler;
                processor.PartitionInitializingAsync -= PartitionInitializingHandler;
                processor.PartitionClosingAsync -= PartitionClosingHandler;
            }
            #endregion
        }

        #region Snippet:EventHubs_TestableEventProcessorClient
        public sealed class TestableEventProcessorClient : EventProcessorClient
        {
            public TestableEventProcessorClient(
                BlobContainerClient checkpointStore,
                string consumerGroup,
                string fullyQualifiedNamespace,
                string eventHubName,
                AzureNamedKeyCredential credential)
                : base(
                    checkpointStore,
                    consumerGroup,
                    fullyQualifiedNamespace,
                    eventHubName,
                    credential)
            {
            }

            public Task RaiseProcessingEventAsync(
                EventData eventData,
                string partitionId,
                CancellationToken cancellationToken = default) =>
                base.OnProcessingEventBatchAsync(
                    new[] { eventData },
                    new TestEventProcessorPartition(partitionId),
                    cancellationToken);

            public Task RaiseProcessingErrorAsync(
                Exception exception,
                string partitionId,
                string operationDescription,
                CancellationToken cancellationToken = default) =>
                base.OnProcessingErrorAsync(
                    exception,
                    new TestEventProcessorPartition(partitionId),
                    operationDescription,
                    cancellationToken);

            public Task RaisePartitionInitializingAsync(
                string partitionId,
                CancellationToken cancellationToken = default) =>
                base.OnInitializingPartitionAsync(
                    new TestEventProcessorPartition(partitionId),
                    cancellationToken);

            public Task RaisePartitionClosingAsync(
                string partitionId,
                ProcessingStoppedReason reason,
                CancellationToken cancellationToken = default) =>
                base.OnPartitionProcessingStoppedAsync(
                    new TestEventProcessorPartition(partitionId),
                    reason,
                    cancellationToken);

            private sealed class TestEventProcessorPartition : EventProcessorPartition
            {
                public TestEventProcessorPartition(string partitionId)
                {
                    PartitionId = partitionId;
                }
            }
        }
        #endregion
    }
}
