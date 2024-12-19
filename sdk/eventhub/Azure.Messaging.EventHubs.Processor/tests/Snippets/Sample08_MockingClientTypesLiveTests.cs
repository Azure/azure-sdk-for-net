// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   Sample08_MockingClientTypes sample.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class Sample08_MockingClientTypesLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void CallingHandlersDirectly()
        {
            #region Snippet:EventHubs_Sample08_CallingHandlersDirectly

            // This process event handler is for illustrative purposes only.

            Task processEventHandler(ProcessEventArgs args)
            {
                // Application-defined code here

                return Task.CompletedTask;
            }

            // This process error handler is for illustrative purposes only.

            Task processErrorHandler(ProcessErrorEventArgs args)
            {
                // Application-defined code here

                return Task.CompletedTask;
            }

            // Here we are mocking a partition context using the model factory.

            PartitionContext partitionContext = EventHubsModelFactory.PartitionContext(
                fullyQualifiedNamespace: "sample-hub.servicebus.windows.net",
                eventHubName: "sample-hub",
                consumerGroup: "$Default",
                partitionId: "0");

            // Here we are mocking an event data instance with broker-owned properties populated.

            EventData eventData = EventHubsModelFactory.EventData(
                eventBody: new BinaryData("Sample-Event"),
                systemProperties: new Dictionary<string, object>(), //arbitrary value
                partitionKey: "sample-key",
                sequenceNumber: 1000,
                offsetString: "1500:1:3344.1",
                enqueuedTime: DateTimeOffset.Parse("11:36 PM"));

            // This creates a new instance of ProcessEventArgs to pass into the handler directly.

            ProcessEventArgs processEventArgs = new(
                partition: partitionContext,
                data: eventData,
                updateCheckpointImplementation: _ => Task.CompletedTask); // arbitrary value

            // Here is where the application defined handler code can be tested and validated.

            Assert.DoesNotThrowAsync(async () => await processEventHandler(processEventArgs));

            // This creates a new instance of ProcessErrorEventArgs to pass into the handler directly.

            ProcessErrorEventArgs processErrorEventArgs = new(
                partitionId: "sample-partition-id",
                operation: "sample-operation",
                exception: new Exception("sample-exception"));

            // Here is where the application defined handler code can be tested and validated.

            Assert.DoesNotThrowAsync(async () => await processErrorHandler(processErrorEventArgs));

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task CallingHandlersOnAnInterval()
        {
            #region Snippet:EventHubs_Sample08_CallingHandlersOnAnInterval

            // This handler is for illustrative purposes only.

            Task processEventHandler(ProcessEventArgs args)
            {
                // Application-defined code here

                return Task.CompletedTask;
            }

            // This function simulates a random event being emitted for processing.

            Random rng = new();
            string[] partitions = new[] { "0", "1", "2", "3" };

            TimerCallback dispatchEvent = async _ =>
            {
                string partition = partitions[rng.Next(0, partitions.Length - 1)];

                PartitionContext partitionContext = EventHubsModelFactory.PartitionContext(
                    fullyQualifiedNamespace: "sample-hub.servicebus.windows.net",
                    eventHubName: "sample-hub",
                    consumerGroup: "$Default",
                    partitionId: partition);

                EventData eventData = EventHubsModelFactory.EventData(
                    eventBody: new BinaryData("Sample-Event"),
                    systemProperties: new Dictionary<string, object>(), //arbitrary value
                    partitionKey: "sample-key",
                    sequenceNumber: 1000,
                    offsetString: "1500:1:1111",
                    enqueuedTime: DateTimeOffset.Parse("11:36 PM"));

                ProcessEventArgs eventArgs = new(
                    partition: partitionContext,
                    data: eventData,
                    updateCheckpointImplementation: _ => Task.CompletedTask);

                await processEventHandler(eventArgs);
            };

            // Create a timer that runs once-a-second when started and, otherwise, sits idle.

            Timer eventDispatchTimer = new(
                dispatchEvent,
                null,
                Timeout.Infinite,
                Timeout.Infinite);

            void startTimer() =>
                eventDispatchTimer.Change(0, (int)TimeSpan.FromSeconds(1).TotalMilliseconds);

            void stopTimer() =>
                eventDispatchTimer.Change(Timeout.Infinite, Timeout.Infinite);

            // Create a mock of the processor that dispatches events on when StartProcessingAsync
            // is called and does so until StopProcessingAsync is called.

            Mock<EventProcessorClient> mockProcessor = new Mock<EventProcessorClient>();

            mockProcessor
                .Setup(processor => processor.StartProcessingAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Callback(startTimer);

            mockProcessor
                .Setup(processor => processor.StopProcessingAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Callback(stopTimer);

            // Start the processor.

            await mockProcessor.Object.StartProcessingAsync();

            // << ... Application Testing Here ... >>

            // Stop the processor.

            await mockProcessor.Object.StopProcessingAsync();

            #endregion
        }
    }
}
