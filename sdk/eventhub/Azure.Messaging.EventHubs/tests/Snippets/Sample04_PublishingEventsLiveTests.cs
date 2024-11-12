// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
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

#if SNIPPET
            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var credential = new DefaultAzureCredential();
#else
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = scope.EventHubName;
            var credential = EventHubsTestEnvironment.Instance.Credential;
#endif

            var producer = new EventHubProducerClient(
                fullyQualifiedNamespace,
                eventHubName,
                credential);

            try
            {
                using EventDataBatch eventBatch = await producer.CreateBatchAsync();

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

#if SNIPPET
            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var credential = new DefaultAzureCredential();
#else
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = scope.EventHubName;
            var credential = EventHubsTestEnvironment.Instance.Credential;
#endif

            var producer = new EventHubProducerClient(
                fullyQualifiedNamespace,
                eventHubName,
                credential);

            try
            {
                using EventDataBatch eventBatch = await producer.CreateBatchAsync();

                for (var index = 0; index < 5; ++index)
                {
                    var eventData = new EventData($"Event #{ index }");

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
        public async Task AutomaticRoutingBuffered()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample04_AutomaticRoutingBuffered

#if SNIPPET
            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var credential = new DefaultAzureCredential();
#else
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = scope.EventHubName;
            var credential = EventHubsTestEnvironment.Instance.Credential;
#endif

            var producer = new EventHubBufferedProducerClient(
                fullyQualifiedNamespace,
                eventHubName,
                credential);

            // The failure handler is required and invoked after all allowable
            // retries were applied.

            producer.SendEventBatchFailedAsync += args =>
            {
                Debug.WriteLine($"Publishing failed for { args.EventBatch.Count } events.  Error: '{ args.Exception.Message }'");
                return Task.CompletedTask;
            };

            // The success handler is optional.

            producer.SendEventBatchSucceededAsync += args =>
            {
               Debug.WriteLine($"{ args.EventBatch.Count } events were published to partition: '{ args.PartitionId }.");
               return Task.CompletedTask;
            };

            try
            {
                for (var index = 0; index < 5; ++index)
                {
                    var eventData = new EventData($"Event #{ index }");
                    await producer.EnqueueEventAsync(eventData);
                }
            }
            finally
            {
                // Closing the producer will flush any
                // enqueued events that have not been published.

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

#if SNIPPET
            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var credential = new DefaultAzureCredential();
#else
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = scope.EventHubName;
            var credential = EventHubsTestEnvironment.Instance.Credential;
#endif

            var producer = new EventHubProducerClient(
                fullyQualifiedNamespace,
                eventHubName,
                credential);

            try
            {
                var batchOptions = new CreateBatchOptions
                {
                    PartitionKey = "Any Value Will Do..."
                };

                using EventDataBatch eventBatch = await producer.CreateBatchAsync(batchOptions);

                for (var index = 0; index < 5; ++index)
                {
                    var eventData = new EventData($"Event #{ index }");

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
        public async Task PartitionKeyBuffered()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample04_PartitionKeyBuffered

#if SNIPPET
            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var credential = new DefaultAzureCredential();
#else
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = scope.EventHubName;
            var credential = EventHubsTestEnvironment.Instance.Credential;
#endif

            var producer = new EventHubBufferedProducerClient(
                fullyQualifiedNamespace,
                eventHubName,
                credential);

            // The failure handler is required and invoked after all allowable
            // retries were applied.

            producer.SendEventBatchFailedAsync += args =>
            {
                Debug.WriteLine($"Publishing failed for { args.EventBatch.Count } events.  Error: '{ args.Exception.Message }'");
                return Task.CompletedTask;
            };

            // The success handler is optional.

            producer.SendEventBatchSucceededAsync += args =>
            {
               Debug.WriteLine($"{ args.EventBatch.Count } events were published to partition: '{ args.PartitionId }.");
               return Task.CompletedTask;
            };

            try
            {
                var enqueueOptions = new EnqueueEventOptions
                {
                    PartitionKey = "Any Value Will Do..."
                };

                for (var index = 0; index < 5; ++index)
                {
                    var eventData = new EventData($"Event #{ index }");
                    await producer.EnqueueEventAsync(eventData, enqueueOptions);
                }
            }
            finally
            {
                // Closing the producer will flush any
                // enqueued events that have not been published.

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

#if SNIPPET
            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var credential = new DefaultAzureCredential();
#else
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = scope.EventHubName;
            var credential = EventHubsTestEnvironment.Instance.Credential;
#endif

            var producer = new EventHubProducerClient(
                fullyQualifiedNamespace,
                eventHubName,
                credential);

            try
            {
                string firstPartition = (await producer.GetPartitionIdsAsync()).First();

                var batchOptions = new CreateBatchOptions
                {
                    PartitionId = firstPartition
                };

                using EventDataBatch eventBatch = await producer.CreateBatchAsync(batchOptions);

                for (var index = 0; index < 5; ++index)
                {
                    var eventData = new EventData($"Event #{ index }");

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
        public async Task PartitionIdBuffered()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample04_PartitionIdBuffered

#if SNIPPET
            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var credential = new DefaultAzureCredential();
#else
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = scope.EventHubName;
            var credential = EventHubsTestEnvironment.Instance.Credential;
#endif

            var producer = new EventHubBufferedProducerClient(
                fullyQualifiedNamespace,
                eventHubName,
                credential);

            // The failure handler is required and invoked after all allowable
            // retries were applied.

            producer.SendEventBatchFailedAsync += args =>
            {
                Debug.WriteLine($"Publishing failed for { args.EventBatch.Count } events.  Error: '{ args.Exception.Message }'");
                return Task.CompletedTask;
            };

            // The success handler is optional.

            producer.SendEventBatchSucceededAsync += args =>
            {
               Debug.WriteLine($"{ args.EventBatch.Count } events were published to partition: '{ args.PartitionId }.");
               return Task.CompletedTask;
            };

            try
            {
                string firstPartition = (await producer.GetPartitionIdsAsync()).First();

                var enqueueOptions = new EnqueueEventOptions
                {
                    PartitionId = firstPartition
                };

                for (var index = 0; index < 5; ++index)
                {
                    var eventData = new EventData($"Event #{ index }");
                    await producer.EnqueueEventAsync(eventData, enqueueOptions);
                }
            }
            finally
            {
                // Closing the producer will flush any
                // enqueued events that have not been published.

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

#if SNIPPET
            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var credential = new DefaultAzureCredential();
#else
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = scope.EventHubName;
            var credential = EventHubsTestEnvironment.Instance.Credential;
#endif

            var producer = new EventHubBufferedProducerClient(
                fullyQualifiedNamespace,
                eventHubName,
                credential);

            // The failure handler is required and invoked after all allowable
            // retries were applied.

            producer.SendEventBatchFailedAsync += args =>
            {
                Debug.WriteLine($"Publishing failed for { args.EventBatch.Count } events.  Error: '{ args.Exception.Message }'");
                return Task.CompletedTask;
            };

            // The success handler is optional.

            producer.SendEventBatchSucceededAsync += args =>
            {
               Debug.WriteLine($"{ args.EventBatch.Count } events were published to partition: '{ args.PartitionId }.");
               return Task.CompletedTask;
            };

            try
            {
                var eventData = new EventData("Hello, Event Hubs!")
                {
                   MessageId = "H1",
                   ContentType = "application/json"
                };

                eventData.Properties.Add("EventType", "com.microsoft.samples.hello-event");
                eventData.Properties.Add("priority", 1);
                eventData.Properties.Add("score", 9.0);

                await producer.EnqueueEventAsync(eventData);

                eventData = new EventData("Goodbye, Event Hubs!")
                {
                   MessageId = "G1",
                   ContentType = "application/json"
                };

                eventData.Properties.Add("EventType", "com.microsoft.samples.goodbye-event");
                eventData.Properties.Add("priority", "17");
                eventData.Properties.Add("blob", true);

                await producer.EnqueueEventAsync(eventData);
            }
            finally
            {
                // Closing the producer will flush any
                // enqueued events that have not been published.

                await producer.CloseAsync();
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task BufferedConfiguration()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample04_BufferedConfiguration

#if SNIPPET
            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var credential = new DefaultAzureCredential();
#else
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = scope.EventHubName;
            var credential = EventHubsTestEnvironment.Instance.Credential;
#endif

            var options = new EventHubBufferedProducerClientOptions
            {
                MaximumWaitTime = TimeSpan.FromSeconds(1),
                MaximumConcurrentSends = 5,
                MaximumConcurrentSendsPerPartition = 1,
                MaximumEventBufferLengthPerPartition = 5000,
                EnableIdempotentRetries = true
            };

            var producer = new EventHubBufferedProducerClient(
                fullyQualifiedNamespace,
                eventHubName,
                credential,
                options);

            // The failure handler is required and invoked after all allowable
            // retries were applied.

            producer.SendEventBatchFailedAsync += args =>
            {
                Debug.WriteLine($"Publishing failed for { args.EventBatch.Count } events.  Error: '{ args.Exception.Message }'");
                return Task.CompletedTask;
            };

            // The success handler is optional.

            producer.SendEventBatchSucceededAsync += args =>
            {
               Debug.WriteLine($"{ args.EventBatch.Count } events were published to partition: '{ args.PartitionId }.");
               return Task.CompletedTask;
            };

            try
            {
                for (var index = 0; index < 5; ++index)
                {
                    var eventData = new EventData($"Event #{ index }");
                    await producer.EnqueueEventAsync(eventData);
                }
            }
            finally
            {
                // Closing the producer will flush any
                // enqueued events that have not been published.

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

#if SNIPPET
            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var credential = new DefaultAzureCredential();
#else
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = scope.EventHubName;
            var credential = EventHubsTestEnvironment.Instance.Credential;
#endif

            var producer = new EventHubProducerClient(
                fullyQualifiedNamespace,
                eventHubName,
                credential);

            try
            {
                var eventsToSend = new List<EventData>();

                for (var index = 0; index < 10; ++index)
                {
                    var eventData = new EventData("Hello, Event Hubs!");
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

#if SNIPPET
            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var credential = new DefaultAzureCredential();
#else
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = scope.EventHubName;
            var credential = EventHubsTestEnvironment.Instance.Credential;
#endif

            var producer = new EventHubProducerClient(
                fullyQualifiedNamespace,
                eventHubName,
                credential);

            var batches = default(IEnumerable<EventDataBatch>);
            var eventsToSend = new Queue<EventData>();

            try
            {
                for (var index = 0; index < 1500; ++index)
                {
                    eventsToSend.Enqueue(new EventData(new byte[80000]));
                }

                batches = await BuildBatchesAsync(eventsToSend, producer);

                foreach (var batch in batches)
                {
                    await producer.SendAsync(batch);
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

#if SNIPPET
            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var credential = new DefaultAzureCredential();
#else
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = scope.EventHubName;
            var credential = EventHubsTestEnvironment.Instance.Credential;
#endif

            var producer = new EventHubProducerClient(
                fullyQualifiedNamespace,
                eventHubName,
                credential);

            try
            {
                var batchOptions = new CreateBatchOptions
                {
                    MaximumSizeInBytes = 350
                };

                using EventDataBatch eventBatch = await producer.CreateBatchAsync(batchOptions);

                for (var index = 0; index < 5; ++index)
                {
                    var eventData = new EventData($"Event #{ index }");

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
