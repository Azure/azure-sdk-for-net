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
    public class Sample09_MockingEventHubPublisher
    {
        /// <summary>
        ///     Performs basic unit test validation of the contained snippet.
        /// </summary>
        [Test]
        public async Task EventBatch()
        {
            #region Snippet:EventHubs_Sample09_EventBatchMock

            var size = 1024;
            var store = new List<EventData> { new EventData(Array.Empty<byte>()), new EventData(Array.Empty<byte>()) };
            var mockResponse = new Mock<Response>();
            Response<EventDataBatch> response = Response.FromValue(EventHubsModelFactory.EventDataBatch(size, store), mockResponse.Object);

            var mockEventHubProducerClient = new Mock<EventHubProducerClient>();

            mockEventHubProducerClient.Setup(c => c.CreateBatchAsync(It.IsAny<CancellationToken>())).ReturnsAsync(response);

            var producer = mockEventHubProducerClient.Object;

            try
            {
                using var eventBatch = await producer.CreateBatchAsync();

                var eventBody = new BinaryData("This is an event body");
                var eventData = new EventData(eventBody);

                if (!eventBatch.TryAdd(eventData))
                {
                    throw new Exception($"The event could not be added.");
                }
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
        /// <returns></returns>
        [Test]
        public async Task AutomaticRouting()
        {
            #region Snippet:EventHubs_Sample09_AutomaticRoutingMock

            var size = 1024;
            var store = new List<EventData> { new EventData(Array.Empty<byte>()), new EventData(Array.Empty<byte>()) };
            var mockResponse = new Mock<Response>();
            Response<EventDataBatch> response = Response.FromValue(EventHubsModelFactory.EventDataBatch(size, store), mockResponse.Object);

            var mockEventHubProducerClient = new Mock<EventHubProducerClient>();

            mockEventHubProducerClient.Setup(c => c.CreateBatchAsync(It.IsAny<CancellationToken>())).ReturnsAsync(response);
            mockEventHubProducerClient.Setup(c => c.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            var producer = mockEventHubProducerClient.Object;

            try
            {
                using var eventBatch = await producer.CreateBatchAsync();

                for (var index = 0; index < 5; ++index)
                {
                    var eventBody = new BinaryData($"Event #{ index }");
                    var eventData = new EventData(eventBody);

                    if (!eventBatch.TryAdd(eventData))
                    {
                        throw new Exception($"The event at { index } could not be added.");
                    }
                }

                await producer.SendAsync(eventBatch);
            }
            finally
            {
                await producer.CloseAsync();
            }

            #endregion
        }

        [Test]
        public async Task PartitionKey()
        {
            #region Snippet:EventHubs_Sample09_PartitionKey

            var size = 1024;
            var store = new List<EventData> { new EventData(Array.Empty<byte>()), new EventData(Array.Empty<byte>()) };
            var options = new CreateBatchOptions { PartitionKey = "Any Value Will Do..."};
            var mockResponse = new Mock<Response>();
            Response<EventDataBatch> response = Response.FromValue(EventHubsModelFactory.EventDataBatch(size, store, options), mockResponse.Object);

            var mockEventHubProducerClient = new Mock<EventHubProducerClient>();

            mockEventHubProducerClient.Setup(c => c.CreateBatchAsync(It.IsAny<CreateBatchOptions>(),It.IsAny<CancellationToken>())).ReturnsAsync(response);
            mockEventHubProducerClient.Setup(c => c.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            var producer = mockEventHubProducerClient.Object;

            try
            {
                var batchOptions = new CreateBatchOptions
                {
                    PartitionKey = "Any Value Will Do..."
                };

                using var eventBatch = await producer.CreateBatchAsync(batchOptions);

                for (var index = 0; index < 5; ++index)
                {
                    var eventBody = new BinaryData($"Event #{ index }");
                    var eventData = new EventData(eventBody);

                    if (!eventBatch.TryAdd(eventData))
                    {
                        throw new Exception($"The event at { index } could not be added.");
                    }
                }

                await producer.SendAsync(eventBatch);
            }
            finally
            {
                await producer.CloseAsync();
            }

            #endregion
        }

        [Test]
        public async Task PartitionId()
        {
            #region Snippet:EventHubs_Sample09_PartitionIdMock

            var mockEventHubProducerClient = new Mock<EventHubProducerClient>();

            var partitionIdsResponse = new string[] { "partitionId1" };
            mockEventHubProducerClient.Setup(c => c.GetPartitionIdsAsync(It.IsAny<CancellationToken>())).ReturnsAsync(partitionIdsResponse);

            var size = 1024;
            var store = new List<EventData> { new EventData(Array.Empty<byte>()), new EventData(Array.Empty<byte>()) };
            var options = new CreateBatchOptions { PartitionId = "partitionId1" };
            var mockResponse = new Mock<Response>();
            Response<EventDataBatch> eventDataBatchResponse = Response.FromValue(EventHubsModelFactory.EventDataBatch(size, store, options), mockResponse.Object);
            mockEventHubProducerClient.Setup(c => c.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>())).ReturnsAsync(eventDataBatchResponse);

            mockEventHubProducerClient.Setup(c => c.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            var producer = mockEventHubProducerClient.Object;

            try
            {
                string firstPartition = (await producer.GetPartitionIdsAsync()).First();

                var batchOptions = new CreateBatchOptions
                {
                    PartitionId = firstPartition
                };

                using var eventBatch = await producer.CreateBatchAsync(batchOptions);

                for (var index = 0; index < 5; ++index)
                {
                    var eventBody = new BinaryData($"Event #{ index }");
                    var eventData = new EventData(eventBody);

                    if (!eventBatch.TryAdd(eventData))
                    {
                        throw new Exception($"The event at { index } could not be added.");
                    }
                }

                await producer.SendAsync(eventBatch);
            }
            finally
            {
                await producer.CloseAsync();
            }

            #endregion
        }
    }
}
