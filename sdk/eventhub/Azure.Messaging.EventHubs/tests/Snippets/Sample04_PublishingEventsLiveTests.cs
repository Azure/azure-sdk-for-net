// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   Sample04_PublishingEvents sample.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Example assignments needed for snippet output content.")]
    public class Sample04_PublishingEventsLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task EventBatch()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample04_EventBatch

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var producer = new EventHubProducerClient(connectionString, eventHubName);

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
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task AutomaticRouting()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample04_AutomaticRouting

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var producer = new EventHubProducerClient(connectionString, eventHubName);

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

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task PartitionKey()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample04_PartitionKey

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var producer = new EventHubProducerClient(connectionString, eventHubName);

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

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task PartitionId()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample04_PartitionId

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var producer = new EventHubProducerClient(connectionString, eventHubName);

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

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task CustomMetadata()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample04_CustomMetadata

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var producer = new EventHubProducerClient(connectionString, eventHubName);

            try
            {
                using var eventBatch = await producer.CreateBatchAsync();

                var eventBody = new BinaryData("Hello, Event Hubs!");
                var eventData = new EventData(eventBody);
                eventData.Properties.Add("EventType", "com.microsoft.samples.hello-event");
                eventData.Properties.Add("priority", 1);
                eventData.Properties.Add("score", 9.0);

                if (!eventBatch.TryAdd(eventData))
                {
                    throw new Exception("The first event could not be added.");
                }

                eventBody = new BinaryData("Goodbye, Event Hubs!");
                eventData = new EventData(eventBody);
                eventData.Properties.Add("EventType", "com.microsoft.samples.goodbye-event");
                eventData.Properties.Add("priority", "17");
                eventData.Properties.Add("blob", true);

                if (!eventBatch.TryAdd(eventData))
                {
                    throw new Exception("The second event could not be added.");
                }

                await producer.SendAsync(eventBatch);
            }
            finally
            {
                await producer.CloseAsync();
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task NoBatch()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample04_NoBatch

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var producer = new EventHubProducerClient(connectionString, eventHubName);

            try
            {
                var eventsToSend = new List<EventData>();

                for (var index = 0; index < 10; ++index)
                {
                    var eventBody = new BinaryData("Hello, Event Hubs!");
                    var eventData = new EventData(eventBody);

                    eventsToSend.Add(eventData);
                }

                await producer.SendAsync(eventsToSend);
            }
            finally
            {
                await producer.CloseAsync();
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task MultipleBatches()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample04_MultipleBatches

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;
            /*@@*/
            /*@@*/ var sentEventCount = 0;
            /*@@*/ var batchEventCount = 0;

            var producer = new EventHubProducerClient(connectionString, eventHubName);
            var batches = default(IEnumerable<EventDataBatch>);
            var eventsToSend = new Queue<EventData>();

            try
            {
                for (var index = 0; index < 1500; ++index)
                {
                    eventsToSend.Enqueue(new EventData(new byte[80000]));
                }

                batches = await BuildBatchesAsync(eventsToSend, producer);
                /*@@*/ batchEventCount = batches.Sum(batch => batch.Count);

                foreach (var batch in batches)
                {
                    await producer.SendAsync(batch);
                    /*@@*/ sentEventCount += batch.Count;
                }
            }
            finally
            {
                foreach (EventDataBatch batch in batches ?? Array.Empty<EventDataBatch>())
                {
                    batch.Dispose();
                }

                await producer.CloseAsync();
            }

            #endregion

            Assert.That(batchEventCount, Is.EqualTo(sentEventCount));
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task CustomBatchSize()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample04_CustomBatchSize

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var producer = new EventHubProducerClient(connectionString, eventHubName);

            try
            {
                var batchOptions = new CreateBatchOptions
                {
                    MaximumSizeInBytes = 350
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

        /// <summary>
        ///   Creates the batches needed to hold a given set of events.
        /// </summary>
        ///
        /// <param name="queuedEvents">The events to group into batches.</param>
        /// <param name="producer">The producer to use for creating batches.</param>
        ///
        /// <returns>The set of batches needed to contain the entire set of <paramref name="events"/>.</returns>
        ///
        /// <remarks>
        ///   Callers are assumed to be responsible for taking ownership of the lifespan of the returned batches, including
        ///   their disposal.
        ///
        ///   This method is intended for use within the test suite only; it is not hardened for general purpose use.
        /// </remarks>
        ///
        #region Snippet:EventHubs_Sample04_BuildBatches
        private static async Task<IReadOnlyList<EventDataBatch>> BuildBatchesAsync(
            Queue<EventData> queuedEvents,
            EventHubProducerClient producer)
        {
            var batches = new List<EventDataBatch>();
            var currentBatch = default(EventDataBatch);

            while (queuedEvents.Count > 0)
            {
                currentBatch ??= (await producer.CreateBatchAsync().ConfigureAwait(false));
                EventData eventData = queuedEvents.Peek();

                if (!currentBatch.TryAdd(eventData))
                {
                    if (currentBatch.Count == 0)
                    {
                        throw new Exception("There was an event too large to fit into a batch.");
                    }

                    batches.Add(currentBatch);
                    currentBatch = default;
                }
                else
                {
                    queuedEvents.Dequeue();
                }
            }

            if ((currentBatch != default) && (currentBatch.Count > 0))
            {
                batches.Add(currentBatch);
            }

            return batches;
        }
        #endregion
    }
}
