// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Samples.Infrastructure;

namespace Azure.Messaging.EventHubs.Samples
{
    /// <summary>
    ///   An example of consuming events, starting at a well-known position in the Event Hub partition.
    /// </summary>
    ///
    public class Sample10_ConsumeEventsFromAKnownPosition : IEventHubsSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name { get; } = nameof(Sample10_ConsumeEventsFromAKnownPosition);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description { get; } = "An example of consuming events, starting at a well-known position in the Event Hub partition.";

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
            // We will start by creating a client to inspect the Event Hub and select a partition to operate against to ensure that
            // events are being published and read from the same partition.

            string firstPartition;

            await using (var inspectionClient = new EventHubProducerClient(connectionString, eventHubName))
            {
                // With our client, we can now inspect the partitions and find the identifier
                // of the first.

                firstPartition = (await inspectionClient.GetPartitionIdsAsync()).First();
            }

            // In this example, we will make use of multiple clients.  Because clients are typically responsible for managing their own connection to the
            // Event Hubs service, each will implicitly create their own connection.  In this example, we will create a connection that may be shared amongst
            // clients in order to illustrate connection sharing.  Because we are explicitly creating the connection, we assume responsibility for managing its
            // lifespan and ensuring that it is properly closed or disposed when we are done using it.

            await using (var eventHubConnection = new EventHubConnection(connectionString, eventHubName))
            await using (var producerClient = new EventHubProducerClient(eventHubConnection, new EventHubProducerClientOptions { PartitionId = firstPartition }))
            {
                // Our initial consumer will begin watching the partition at the very end, reading only new events
                // that we will publish for it.
                //
                // Each event that the initial consumer reads will have attributes set that describe the event's place in the
                // partition, such as its offset, sequence number, and the date/time that it was enqueued.  These attributes can be
                // used to create a new consumer that begins consuming at a known position.
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
                // In this example, we will publish a batch of events to be received with an initial consumer.  The third event that is consumed will be captured
                // and another consumer will use its attributes to start reading the event that follows, consuming the same set of events that our initial consumer
                // read, skipping over the first three.

                int eventBatchSize = 50;
                EventData thirdEvent;

                await using (var initialConsumerClient = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, firstPartition, EventPosition.Latest, eventHubConnection))
                {
                    // The first receive that we ask of it will not see any events, but allows the consumer to start watching the partition.  Because
                    // the maximum wait time is specified as zero, this call will return immediately and will not have consumed any events.

                    await initialConsumerClient.ReceiveAsync(1, TimeSpan.Zero);

                    // Now that the consumer is watching the partition, let's publish a batch of events.

                    EventData[] eventBatch = new EventData[eventBatchSize];

                    for (int index = 0; index < eventBatchSize; ++index)
                    {
                        eventBatch[index] = new EventData(Encoding.UTF8.GetBytes($"I am event #{ index }"));
                    }

                    await producerClient.SendAsync(eventBatch);
                    Console.WriteLine($"The event batch with { eventBatchSize } events has been published.");

                    // We will consume the events until all of the published events have been received.

                    var receivedEvents = new List<EventData>();

                    CancellationTokenSource cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                    await foreach (EventData currentEvent in initialConsumerClient.SubscribeToEvents(cancellationSource.Token))
                    {
                        receivedEvents.Add(currentEvent);

                        if (receivedEvents.Count >= eventBatchSize)
                        {
                            break;
                        }
                    }

                    // Print out the events that we received.

                    Console.WriteLine();
                    Console.WriteLine($"The initial consumer processed { receivedEvents.Count } events of the { eventBatchSize } that were published.  { eventBatchSize } were expected.");

                    foreach (EventData eventData in receivedEvents)
                    {
                        // The body of our event was an encoded string; we'll recover the
                        // message by reversing the encoding process.

                        string message = Encoding.UTF8.GetString(eventData.Body.ToArray());
                        Console.WriteLine($"\tMessage: \"{ message }\"");
                    }

                    // Remember the third event that was consumed.

                    thirdEvent = receivedEvents[2];
                }

                // At this point, our initial consumer client has passed its "using" scope and has been safely disposed of.
                //
                // Create a new consumer beginning using the third event as the last sequence number processed; this new consumer will begin reading at the next available
                // sequence number, allowing it to read the set of published events beginning with the fourth one.

                await using (var newConsumerClient = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, firstPartition, EventPosition.FromSequenceNumber(thirdEvent.SequenceNumber.Value), eventHubConnection))
                {
                    // We will consume the events using the new consumer until all of the published events have been received.

                    CancellationTokenSource cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                    int expectedCount = (eventBatchSize - 3);
                    var receivedEvents = new List<EventData>();

                    await foreach (EventData currentEvent in newConsumerClient.SubscribeToEvents(cancellationSource.Token))
                    {
                        receivedEvents.Add(currentEvent);

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

                        string message = Encoding.UTF8.GetString(eventData.Body.ToArray());
                        Console.WriteLine($"\tMessage: \"{ message }\"");
                    }
                }
            }

            // At this point, our clients and connection have passed their "using" scope and have safely been disposed of.  We
            // have no further obligations.

            Console.WriteLine();
        }
    }
}
