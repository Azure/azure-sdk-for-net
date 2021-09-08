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

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   Sample10_AzureEventSourceListener sample.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class Sample11_MockEventHubProducerClientTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void EventDataBatch()
        {
            #region Snippet:EventHubs_Sample11_EventDataBatch

            // Data batch mock simulating failure adding events to it.

            var mockEventDataBatch = EventHubsModelFactory.EventDataBatch(
                It.IsAny<long>(),
                It.IsAny<IList<EventData>>(),
                It.IsAny<CreateBatchOptions>(),
                _ => false);

            // Producer mock.

            var mockProducer = new Mock<EventHubProducerClient>();
            mockProducer.Setup(producer => producer.CreateBatchAsync(It.IsAny<CancellationToken>())).ReturnsAsync(mockEventDataBatch);

            var producer = mockProducer.Object;

            // An example method demonstrating basic scenario of adding events to a batch.

            async Task methodUnderTest()
            {
                try
                {
                    using var eventBatch = await producer.CreateBatchAsync();
                    var eventData = new EventData("This is an event body");

                    if (!eventBatch.TryAdd(eventData))
                    {
                        throw new Exception($"The event could not be added.");
                    }
                }
                finally
                {
                    await producer.CloseAsync();
                }
            }

            // Testing condition of the method.

            Assert.That(async () => await methodUnderTest(), Throws.Exception);

            #endregion
        }
    }
}
