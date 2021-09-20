// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Azure.Messaging.EventHubs.Producer;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   Sample10_AzureEventSourceListener sample.
    /// </summary>
    ///
    [TestFixture]
    public class Sample11_MockEventHubProducerClientTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task EventDataBatch()
        {
            #region Snippet:EventHubs_Sample11_EventDataBatch

            const int TotalEvents = 10;

            IList<EventData> actualEvents = new List<EventData>();

            var eventDataBatch = EventHubsModelFactory.EventDataBatch(
                500,
                actualEvents,
                null,
                // Custom function filtering out events for the Partition A
                (eventData) => { return eventData.PartitionKey.Equals("Partition A"); });

            var mockProducer = new Mock<EventHubProducerClient>();
            mockProducer.Setup(p => p.CreateBatchAsync(It.IsAny<CancellationToken>())).ReturnsAsync(eventDataBatch);

            var producer = mockProducer.Object;

            using var eventBatch = await producer.CreateBatchAsync();

            for (int eventCount = 0; eventCount < TotalEvents; eventCount++)
            {
                EventData eventData = EventHubsModelFactory.EventData(
                       new BinaryData("This is a sample event body"),
                       null,
                       null,
                       "Partition " + (eventCount % 2 == 0 ? "A" : "B"));

                Constraint constraint = eventCount switch
                {
                    _ when (eventCount % 2 == 0) => Is.True,
                    _ => Is.False
                };

                Assert.That(eventBatch.TryAdd(eventData), constraint);
            }

            // The producer should be returning our batch with the Event Data addressed to the Partition A.

            Assert.That(actualEvents.Count, Is.EqualTo(TotalEvents / 2));

            #endregion
        }
    }
}
