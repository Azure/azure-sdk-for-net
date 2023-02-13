// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   Provides operations related to generating instances of <see cref="EventData" />
    ///   and <see cref="EventDataBatch" /> for use in testing scenarios.
    /// </summary>
    ///
    public static class EventGenerator
    {
        /// <summary>The seed to use for initializing random number generated for a given thread-specific instance.</summary>
        private static int s_randomSeed = Environment.TickCount;

        /// <summary>The name of the custom event property which holds a test-specific artificial event identifier.</summary>
        public static readonly string IdPropertyName = $"{ nameof(EventGenerator) }::Identifier";

        /// <summary>The random number generator to use for a specific thread.</summary>
        private static readonly ThreadLocal<Random> RandomNumberGenerator = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref s_randomSeed)), false);

        /// <summary>
        ///   Creates a buffer of read-only memory with random values to serve
        ///   as the body of an event.
        /// </summary>
        ///
        /// <param name="bodySizeBytes">The size of the body, in bytes.</param>
        ///
        /// <returns>A memory buffer of the requested size range containing randomized data.</returns>
        ///
        public static ReadOnlyMemory<byte> CreateRandomBody(long bodySizeBytes)
        {
            var buffer = new byte[bodySizeBytes];
            RandomNumberGenerator.Value.NextBytes(buffer);

            return buffer;
        }

        /// <summary>
        ///   Creates a set of events with random data and random body size.
        /// </summary>
        ///
        /// <param name="numberOfEvents">The number of events to create.</param>
        ///
        /// <returns>The requested set of events.</returns>
        ///
        public static IEnumerable<EventData> CreateEvents(int numberOfEvents)
        {
            const int minimumBodySize = 15;
            const int maximumBodySize = 83886;

            for (var index = 0; index < numberOfEvents; ++index)
            {
                var buffer = new byte[RandomNumberGenerator.Value.Next(minimumBodySize, maximumBodySize)];
                RandomNumberGenerator.Value.NextBytes(buffer);

                yield return CreateEventFromBody(buffer);
            }
        }

        /// <summary>
        ///   Creates a random set of events with random data and random body size within the specified constraints.
        /// </summary>
        ///
        /// <param name="maximumBatchSize">The maximum size of the batch.</param>
        /// <param name="numberOfEvents">The number of events to create.</param>
        /// <param name="largeMessageRandomFactor">The percentage of events that should be large.</param>
        /// <param name="minimumBodySize">The minimum size of the event body.</param>
        /// <param name="maximumBodySize">The maximum size of the event body.</param>
        ///
        /// <returns>The requested set of events.</returns>
        ///
        public static IEnumerable<EventData> CreateEvents(long maximumBatchSize,
                                                          int numberOfEvents,
                                                          int largeMessageRandomFactor = 30,
                                                          int minimumBodySize = 15,
                                                          int maximumBodySize = 83886)
        {
            var activeMinimumBodySize = minimumBodySize;
            var activeMaximumBodySize = maximumBodySize;
            var totalBytesGenerated = 0;

            if (RandomNumberGenerator.Value.Next(1, 100) < largeMessageRandomFactor)
            {
                activeMinimumBodySize = (int)Math.Ceiling(maximumBodySize * 0.65);
            }
            else
            {
                activeMaximumBodySize = (int)Math.Floor((maximumBatchSize * 1.0f) / numberOfEvents);
            }

            for (var index = 0; ((index < numberOfEvents) && (totalBytesGenerated <= maximumBatchSize)); ++index)
            {
                var buffer = new byte[RandomNumberGenerator.Value.Next(activeMinimumBodySize, activeMaximumBodySize)];
                RandomNumberGenerator.Value.NextBytes(buffer);
                totalBytesGenerated += buffer.Length;

                yield return CreateEventFromBody(buffer);
            }
        }

        /// <summary>
        ///   Creates a set of events with random data and a small body size.
        /// </summary>
        ///
        /// <param name="numberOfEvents">The number of events to create.</param>
        ///
        /// <returns>The requested set of events.</returns>
        ///
        public static IEnumerable<EventData> CreateSmallEvents(int numberOfEvents)
        {
            const int minimumBodySize = 5;
            const int maximumBodySize = 25;

            for (var index = 0; index < numberOfEvents; ++index)
            {
                var buffer = new byte[RandomNumberGenerator.Value.Next(minimumBodySize, maximumBodySize)];
                RandomNumberGenerator.Value.NextBytes(buffer);

                yield return CreateEventFromBody(buffer);
            }
        }

        /// <summary>
        ///   Creates and configures an <see cref="EventData" /> instance using the
        ///   provided <paramref name="eventBody" /> as the embedded data.
        /// </summary>
        ///
        /// <param name="eventBody">The set of bytes to use as the data body of the event.</param>
        ///
        /// <returns>The event that was created.</returns>
        ///
        public static EventData CreateEventFromBody(ReadOnlyMemory<byte> eventBody)
        {
            var id = Guid.NewGuid().ToString();

            return new EventData(eventBody)
            {
                MessageId = id,
                Properties = {{ IdPropertyName, id }}
            };
        }

        /// <summary>
        ///   Creates and configures an <see cref="EventData" /> instance using the
        ///   provided <paramref name="eventBody" /> as the embedded data.
        /// </summary>
        ///
        /// <param name="numberOfEvents">The number of events to create.</param>
        /// <param name="eventBody">The set of bytes to use as the data body of the event.</param>
        ///
        /// <returns>The requested set of events.</returns>
        ///
        public static IEnumerable<EventData> CreateEventsFromBody(int numberOfEvents,
                                                                  ReadOnlyMemory<byte> eventBody)
        {
            for (var index = 0; index < numberOfEvents; ++index)
            {
                yield return CreateEventFromBody(eventBody);
            }
        }

        /// <summary>
        ///   Builds a set of batches from the provided events.
        /// </summary>
        ///
        /// <param name="events">The events to group into batches.</param>
        /// <param name="producer">The producer to use for creating batches.</param>
        /// <param name="batchEvents">A dictionary to which the events included in the batches should be tracked.</param>
        /// <param name="batchOptions">The set of options to apply when creating batches.</param>
        /// <param name="cancellationToken">The token used to signal a cancellation request.</param>
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
        public static async Task<IEnumerable<EventDataBatch>> BuildBatchesAsync(IEnumerable<EventData> events,
                                                                                EventHubProducerClient producer,
                                                                                CreateBatchOptions batchOptions = default,
                                                                                CancellationToken cancellationToken = default)
        {
            EventData eventData;

            var queuedEvents = new Queue<EventData>(events);
            var batches = new List<EventDataBatch>();
            var currentBatch = default(EventDataBatch);

            while (queuedEvents.Count > 0)
            {
                currentBatch ??= (await producer.CreateBatchAsync(batchOptions, cancellationToken).ConfigureAwait(false));
                eventData = queuedEvents.Peek();

                if (!currentBatch.TryAdd(eventData))
                {
                    if (currentBatch.Count == 0)
                    {
                        throw new InvalidOperationException("There was an event too large to fit into a batch.");
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
    }
}
