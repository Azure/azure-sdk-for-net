// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Samples.Infrastructure;

namespace Azure.Messaging.EventHubs.Samples
{
    /// <summary>
    ///   An example of reading events from a single Event Hub partition, starting at a well-known position.
    /// </summary>
    ///
    public class Sample10_ReadEventsFromAKnownPosition : IEventHubsSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name => nameof(Sample10_ReadEventsFromAKnownPosition);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description => "An example of reading events from a single Event Hub partition, starting at a well-known position.";

        /// <summary>
        ///   Runs the sample using the specified Event Hubs connection information.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string for the Event Hubs namespace that the sample should target.</param>
        /// <param name="eventHubName">The name of the Event Hub, sometimes known as its path, that she sample should run against.</param>
        ///
        public async Task RunAsync(string connectionString,
                                   string eventHubName)
        {
            // In this example, we'll make use of multiple clients in order to publish an event that we will then read back and use as the starting point
            // for reading events in the partition.  Our initial consumer will begin watching for new events published to the first partition in our Event
            // Hub.  Before we can publish events and have them observed, we will need to ask the consumer to perform an operation for it to begin observing
            // the partition.
            //
            // Each event that a consumer reads will have attributes set that describe the event's location in the partition, such as its offset, sequence
            // number, and the date/time that it was enqueued.  These attributes can be used to create a new consumer that begins consuming at a known position.
            //
            // With Event Hubs, it is the responsibility of an application consuming events to keep track of those that it has processed,
            // and to manage where in the partition the consumer begins reading events.  This is done by using the position information to track
            // state, commonly known as "creating a checkpoint."
            //
            // The goal is to preserve the position of an event in some form of durable state, such as writing it to a database, so that if the
            // consuming application crashes or is otherwise restarted, it can retrieve that checkpoint information and use it to create a consumer that
            // begins reading at the position where it left off.
            //
            // It is important to note that there is potential for a consumer to process an event and be unable to preserve the checkpoint.  A well-designed
            // consumer must be able to deal with processing the same event multiple times without it causing data corruption or otherwise creating issues.
            // Event Hubs, like most event streaming systems, guarantees "at least once" delivery; even in cases where the consumer does not experience a restart,
            // there is a small possibility that the service will return an event multiple times.
            //
            // To demonstrate, we will publish a batch of events to be read by an initial consumer.  The third event that is read will be captured
            // and another consumer will use its attributes to start reading the event that follows, reading the set of events that we published skipping over
            // the first three.

            string firstPartition;
            EventData thirdEvent;

            int eventBatchSize = 50;

            await using (var initialConsumerClient = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString, eventHubName))
            {
                // We will start by using the consumer client inspect the Event Hub and select the first partition to operate against.

                firstPartition = (await initialConsumerClient.GetPartitionIdsAsync()).First();

                // Each time the consumer looks to read events, we'll ask that it waits only a short time before emitting
                // an empty event, so that our code has the chance to run without indefinite blocking.

                ReadEventOptions readOptions = new ReadEventOptions
                {
                    MaximumWaitTime = TimeSpan.FromMilliseconds(150)
                };

                // As a preventative measure, we'll also specify that cancellation should occur after 30 seconds, so that we don't iterate indefinitely
                // in the event of a service error where the events we've published cannot be read.

                using CancellationTokenSource cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(60));

                List<EventData> receivedEvents = new List<EventData>();
                bool wereEventsPublished = false;

                await foreach (PartitionEvent currentEvent in initialConsumerClient.ReadEventsFromPartitionAsync(firstPartition, EventPosition.Latest, readOptions, cancellationSource.Token))
                {
                    if (!wereEventsPublished)
                    {
                        await using (var producerClient = new EventHubProducerClient(connectionString, eventHubName))
                        {
                            // When we publish the event batch, we'll specify the partition to ensure that our consumer and producer clients are
                            // operating against the same partition.

                            using EventDataBatch eventBatch = await producerClient.CreateBatchAsync(new CreateBatchOptions { PartitionId = firstPartition });

                            for (int index = 0; index < eventBatchSize; ++index)
                            {
                                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes($"I am event #{ index }")));
                            }

                            await producerClient.SendAsync(eventBatch);
                            wereEventsPublished = true;

                            await Task.Delay(250);
                            Console.WriteLine($"The event batch with { eventBatchSize } events has been published.");
                        }

                        // Since we know that there was no event to observe for this iteration,
                        // we'll just skip to the next one.

                        continue;
                    }

                    // Because publishing and reading events is asynchronous, the events that we published may not
                    // be immediately available for our consumer to see, so we'll have to guard against an empty event being sent as
                    // punctuation if our actual event is not available within the waiting time period.

                    if (currentEvent.Data != null)
                    {
                        receivedEvents.Add(currentEvent.Data);

                        if (receivedEvents.Count >= eventBatchSize)
                        {
                            break;
                        }
                    }
                }

                // Print out the events that we read, which will be the entire set that
                // we had published.

                Console.WriteLine();
                Console.WriteLine($"The initial consumer processed { receivedEvents.Count } events of the { eventBatchSize } that were published.  { eventBatchSize } were expected.");

                foreach (EventData eventData in receivedEvents)
                {
                    // The body of our event was an encoded string; we'll recover the
                    // message by reversing the encoding process.

                    string message = Encoding.UTF8.GetString(eventData.EventBody.ToBytes().ToArray());
                    Console.WriteLine($"\tEvent Message: \"{ message }\"");
                }

                // Remember the third event that was consumed.

                thirdEvent = receivedEvents[2];
            }

            // At this point, our initial consumer client has passed its "using" scope and has been safely disposed of.
            //
            // Create a new consumer for the partition, specifying the sequence number of the third event as the location to begin reading. Because sequence numbers are non-inclusive
            // by default, the consumer will read the next available event following that sequence number, allowing it to read the set of published events beginning with the fourth one.
            //
            // Because our second consumer will begin watching the partition at a specific event, there is no need to ask for an initial operation to set our place; when
            // we begin iterating, the consumer will locate the proper place in the partition to read from.

            await using (var newConsumerClient = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString, eventHubName))
            {
                // We will consume the events using the new consumer until all of the published events have been received.

                using CancellationTokenSource cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                List<EventData> receivedEvents = new List<EventData>();
                int expectedCount = (eventBatchSize - 3);
                EventPosition startingPosition = EventPosition.FromSequenceNumber(thirdEvent.SequenceNumber);

                await foreach (PartitionEvent currentEvent in newConsumerClient.ReadEventsFromPartitionAsync(firstPartition, startingPosition, cancellationSource.Token))
                {
                    receivedEvents.Add(currentEvent.Data);

                    if (receivedEvents.Count >= expectedCount)
                    {
                        break;
                    }
                }

                // Print out the events that we received.

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"The new consumer processed { receivedEvents.Count } events of the { eventBatchSize } that were published.  { expectedCount } were expected.");

                foreach (EventData eventData in receivedEvents)
                {
                    // The body of our event was an encoded string; we'll recover the
                    // message by reversing the encoding process.

                    string message = Encoding.UTF8.GetString(eventData.EventBody.ToBytes().ToArray());
                    Console.WriteLine($"\tEvent Message: \"{ message }\"");
                }
            }

            // At this point, our clients and connection have passed their "using" scope and have safely been disposed of.  We
            // have no further obligations.

            Console.WriteLine();
        }
    }
}
