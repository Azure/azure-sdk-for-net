// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    [TestFixture]
    public class Sample11_MockingEventHubPublisherTests
    {
        /// <summary>
        ///     Performs basic unit test validation of the contained snippet.
        /// </summary>
        [Test]
        public async Task AddingEventBatch_TryAddReturnsFalse()
        {
            #region Snippet:EventHubs_Sample11_AddingEventBatchMock

            var mockBatchSizeInBytes = 1024;
            var eventStore = new List<EventData>();
            var mockEventBatch = EventHubsModelFactory.EventDataBatch(mockBatchSizeInBytes, eventStore, null, eventToAdd => false);
            var mockEventHubProducerClient = new Mock<EventHubProducerClient>();

            mockEventHubProducerClient
                .Setup(c => c.CreateBatchAsync(It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<EventDataBatch>(mockEventBatch));

            var producer = mockEventHubProducerClient.Object;

            try
            {
                using var eventBatch = await producer.CreateBatchAsync();

                var eventBody = new BinaryData("This is an event body");
                var eventData = new EventData(eventBody);

                var ex = Assert.Throws<Exception>(() =>
                {
                    if (!eventBatch.TryAdd(eventData))
                    {
                        throw new Exception("The event could not be added.");
                    }
                });

                Assert.AreEqual("The event could not be added.", ex.Message);
            }
            finally
            {
                await producer.CloseAsync();
            }

            #endregion
        }

        /// <summary>
        ///     Performs basic unit test validation of the contained snippet.
        /// </summary>
        [Test]
        public async Task PublishingEventBatch()
        {
            #region Snippet:EventHubs_Sample11_MockingPublishingEventBatch

            var mockBatchSizeInBytes = 1024;
            var eventStore = new List<EventData>();
            var mockEventBatch = EventHubsModelFactory.EventDataBatch(mockBatchSizeInBytes, eventStore, null, eventToAdd => true);
            var mockEventHubProducerClient = new Mock<EventHubProducerClient>();

            mockEventHubProducerClient
                .Setup(c => c.CreateBatchAsync(It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<EventDataBatch>(mockEventBatch));

            mockEventHubProducerClient
                .Setup(c => c.SendAsync(mockEventBatch, It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            var producer = mockEventHubProducerClient.Object;
            var expectedEvents = GenerateEventList();

            try
            {
                using var eventBatch = await producer.CreateBatchAsync();

                foreach (var eventData in expectedEvents)
                {
                    if (!eventBatch.TryAdd(eventData))
                    {
                        // My callback rejected the event
                        throw new Exception($"The event could not be added.");
                    }
                }

                await producer.SendAsync(eventBatch, CancellationToken.None);
            }
            finally
            {
                await producer.CloseAsync();
            }

            for (var index = 0; index < expectedEvents.Count; ++index)
            {
                Assert.AreEqual(expectedEvents[index].EventBody.ToString(), eventStore[index].EventBody.ToString());
            }

            mockEventHubProducerClient.VerifyAll();

            #endregion
        }

        private List<EventData> GenerateEventList()
        {
            var generatedEventList = new List<EventData>();
            for (int index = 1; index<5; ++index)
            {
                var eventBody = new BinaryData($"This is an example event body #{index}");
                generatedEventList.Add(new EventData(eventBody));
            }
            return generatedEventList;
        }
    }
}
