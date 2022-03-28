using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;

namespace Azure.Messaging.EventHubs.StressTests
{
    public static class EventGenerator
    {
        private static int s_randomSeed = Environment.TickCount;
        private static readonly ThreadLocal<Random> RandomNumberGenerator = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref s_randomSeed)), false);

        public static readonly string IdPropertyName = $"{ nameof(EventGenerator) }::Identifier";
        public static readonly string SequencePropertyName = $"{ nameof(EventGenerator) }::Sequence";
        public static readonly string PublishTimePropertyName = $"{ nameof(EventGenerator) }::PublishTime";
        public static readonly string PartitionPropertyName = $"{ nameof(EventGenerator) }::Partition";

        public static IEnumerable<EventData> CreateEvents(long maximumBatchSize,
                                                          int numberOfEvents,
                                                          int largeMessageRandomFactor = 30,
                                                          int minimumBodySize = 15,
                                                          int maximumBodySize = 83886,
                                                          long sequenceNumber = 0,
                                                          string publishToPartition = null)
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

                yield return CreateEventFromBody(buffer, sequenceNumber++, publishToPartition);
            }
        }

        public static EventData CreateEventFromBody(ReadOnlyMemory<byte> eventBody,
                                                    long sequenceNumber,
                                                    string publishToPartition)
        {
            var currentEvent = new EventData(eventBody);
            currentEvent.Properties.Add(IdPropertyName, Guid.NewGuid().ToString());
            currentEvent.Properties.Add(SequencePropertyName, sequenceNumber);
            currentEvent.Properties.Add(PublishTimePropertyName, DateTimeOffset.UtcNow);

            if (!String.IsNullOrEmpty(publishToPartition))
            {
                currentEvent.Properties[PartitionPropertyName] = publishToPartition;
            }

            return currentEvent;
        }

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
