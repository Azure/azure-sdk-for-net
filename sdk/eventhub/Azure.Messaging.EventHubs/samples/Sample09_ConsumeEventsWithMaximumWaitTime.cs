// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Samples.Infrastructure;

namespace Azure.Messaging.EventHubs.Samples
{
    /// <summary>
    ///   An introduction to consuming events, using a simple <see cref="EventHubConsumerClient" />.
    /// </summary>
    ///
    public class Sample09_ConsumeEventsWithMaximumWaitTime : IEventHubsSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name { get; } = nameof(Sample09_ConsumeEventsWithMaximumWaitTime);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description { get; } = "An introduction to consuming events, using an Event Hub consumer client with maximum wait time.";

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
            // An Event Hub consumer is associated with a specific Event Hub and consumer group.  The consumer group is
            // a label that identifies one or more consumers as a set.  Often, consumer groups are named after the responsibility
            // of the consumer in an application, such as "Telemetry" or "OrderProcessing".  When an Event Hub is created, a default
            // consumer group is created with it, called "$Default."
            //
            // Each consumer has a unique view of the events in a partition that it reads from, meaning that events are available to all
            // consumers and are not removed from the partition when a consumer reads them.  This allows for one or more consumers to read and
            // process events from the partition at different speeds and beginning with different events without interfering with
            // one another.
            //
            // When events are published, they will continue to exist in the partition and be available for consuming until they
            // reach an age where they are older than the retention period.
            // (see: https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-faq#what-is-the-maximum-retention-period-for-events)
            //
            // Because events are not removed from the partition when consuming, a consumer must specify where in the partition it
            // would like to begin reading events.  For example, this may be starting from the very beginning of the stream, at an
            // offset from the beginning, the next event available after a specific point in time, or at a specific event.

            // We will start by creating a client using its default set of options.

            // We will start by creating a client to inspect the Event Hub and select a partition to operate against to ensure that
            // events are being published and read from the same partition.

            string firstPartition;

            await using (var inspectionClient = new EventHubProducerClient(connectionString, eventHubName))
            {
                // With our client, we can now inspect the partitions and find the identifier
                // of the first.

                firstPartition = (await inspectionClient.GetPartitionIdsAsync()).First();
            }

            // In this example, we will create our consumer client for the first partition in the Event Hub, using the default consumer group
            // that is created with an Event Hub.  Our consumer will begin watching the partition at the very end, reading only new events
            // that we will publish for it.

            await using (var consumerClient = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, firstPartition, EventPosition.Latest, connectionString, eventHubName))
            await using (var producerClient = new EventHubProducerClient(connectionString, eventHubName, new EventHubProducerClientOptions { PartitionId = firstPartition }))
            {
                // Because our consumer is reading from the latest position, it won't see events that have previously
                // been published.  Before we can publish the events, we will need to ask the consumer to perform an operation,
                // because it opens its connection only when it needs to.  The first receive that we ask of it will not see
                // any events, but will allow the consumer to start watching the partition.
                //
                // Because the maximum wait time is specified as zero, this call will return immediately and will not
                // have consumed any events.

                await consumerClient.ReceiveAsync(1, TimeSpan.Zero);

                // Now that the consumer is watching the partition, let's publish the events that we would like to
                // receive.

                EventData[] eventsToPublish = new EventData[]
                {
                    new EventData(Encoding.UTF8.GetBytes("Hello, Event Hubs!")),
                    new EventData(Encoding.UTF8.GetBytes("Goodbye, Event Hubs!"))
                };

                await producerClient.SendAsync(eventsToPublish);
                Console.WriteLine("The event batch has been published.");

                // Because publishing and receiving events is asynchronous, the events that we published may not be immediately
                // available for our consumer to see.  We will iterate over the available events in the partition, which should be
                // just the events that we published.
                //
                // When a maximum wait time is specified, the iteration will ensure that it returns control after that time has elapsed,
                // whether or not an event is available in the partition.  If no event was available a null value will be emitted instead.
                // This is intended to return control to the loop and avoid blocking for an indeterminate period of time to allow event
                // processors to verify that the iterator is still consuming the partition and to make decisions on whether or not to continue
                // if events are not arriving.
                //
                // For this example, we will specify a maximum wait time, and won't exit the loop until we've received at least one more
                // event than we published, which is expected to be a null value triggered by exceeding the wait time.
                //
                // To be sure that we do not end up in an infinite loop, we will specify a fairly long time to allow processing to complete
                // then cancel.

                CancellationTokenSource cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                TimeSpan maximumWaitTime = TimeSpan.FromMilliseconds(250);
                List<EventData> receivedEvents = new List<EventData>();
                Stopwatch watch = Stopwatch.StartNew();

                await foreach (EventData currentEvent in consumerClient.SubscribeToEvents(maximumWaitTime, cancellationSource.Token))
                {
                    receivedEvents.Add(currentEvent);

                    if (receivedEvents.Count > eventsToPublish.Length)
                    {
                        watch.Stop();
                        break;
                    }
                }

                // Print out the events that we received.

                Console.WriteLine();
                Console.WriteLine($"The following events were consumed in { watch.ElapsedMilliseconds } milliseconds:");

                foreach (EventData eventData in receivedEvents)
                {
                    // The body of our event was an encoded string; we'll recover the
                    // message by reversing the encoding process.

                    string message = (eventData == null) ? "<< This was a null event >>" : Encoding.UTF8.GetString(eventData.Body.ToArray());
                    Console.WriteLine($"\tMessage: \"{ message }\"");
                }
            }

            // At this point, our clients have passed their "using" scope and have safely been disposed of.  We
            // have no further obligations.

            Console.WriteLine();
        }
    }
}
