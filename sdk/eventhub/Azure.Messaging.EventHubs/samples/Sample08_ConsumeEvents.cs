// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
    public class Sample08_ConsumeEvents : IEventHubsSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name { get; } = nameof(Sample08_ConsumeEvents);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description { get; } = "An introduction to consuming events, using a simple Event Hub consumer client.";

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

                // Now that the consumer is watching the partition, let's publish the event that we would like to
                // receive.

                await producerClient.SendAsync(new EventData(Encoding.UTF8.GetBytes("Hello, Event Hubs!")));
                Console.WriteLine("The event batch has been published.");

                // Because publishing and receiving events is asynchronous, the events that we published may not
                // be immediately available for our consumer to see.
                //
                // We will iterate over the available events in the partition, which should be just the event that we published.  Because
                // we're expecting only the one event, we will exit the loop when we receive it.  To be sure that we do not block forever
                // waiting on an event that is not published, we will specify a fairly long time to wait and then cancel waiting.

                CancellationTokenSource cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                EventData receivedEvent = null;
                Stopwatch watch = Stopwatch.StartNew();

                await foreach (EventData currentEvent in consumerClient.SubscribeToEvents(cancellationSource.Token))
                {
                    receivedEvent = currentEvent;
                    watch.Stop();
                    break;
                }

                // Print out the events that we received.

                Console.WriteLine();
                Console.WriteLine($"The following event was consumed in { watch.ElapsedMilliseconds } milliseconds:");

                // The body of our event was an encoded string; we'll recover the message by reversing the encoding process.

                string message = (receivedEvent == null) ? "No event was received." : Encoding.UTF8.GetString(receivedEvent.Body.ToArray());
                Console.WriteLine($"\tMessage: \"{ message }\"");
            }

            // At this point, our clients have passed their "using" scope and have safely been disposed of.  We
            // have no further obligations.

            Console.WriteLine();
        }
    }
}
