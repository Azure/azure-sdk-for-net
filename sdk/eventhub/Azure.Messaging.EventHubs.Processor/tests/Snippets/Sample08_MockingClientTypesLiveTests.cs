// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
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
            partitionId: "0");

            // Here we are mocking an event data instance using the model factory.

            EventData eventData = EventHubsModelFactory.EventData(
                eventBody: new BinaryData("Sample-Event"),
                systemProperties: new Dictionary<string, object>(), //arbitrary value
                partitionKey: "sample-key",
                sequenceNumber: 1000,
                offset: 1500,
                enqueuedTime: DateTimeOffset.Parse("11:36 PM"));

            // This creates a new instance of ProcessEventArgs to pass into the handler directly.

            ProcessEventArgs processEventArgs = new(
                partition: partitionContext,
                data: eventData,
                updateCheckpointImplementation: async (CancellationToken ct) => await Task.CompletedTask); // arbitrary value

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
    }
}
