// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Samples.Infrastructure;

namespace Azure.Messaging.EventHubs.Samples
{
    /// <summary>
    ///   An introduction to consuming events, using a simple <see cref="EventHubConsumer" />.
    /// </summary>
    ///
    public class Sample7_ConsumeEvents : IEventHubsSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name { get; } = nameof(Sample7_ConsumeEvents);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description { get; } = "An introduction to consuming events, using a simple Event Hub consumer.";

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
            // An Event Hub consumer is associated with a specific Event Hub partition and a consumer group.  The consumer group is
            // a label that identifies one or more consumers as a set.  Often, consumer groups are named after the responsibility
            // of the consumer in an application, such as "Telemetry" or "OrderProcessing".  When an Event Hub is created, a default
            // consumer group is created with it, called "$Default."
            //
            // Each consumer has a unique view of the events in the partition, meaning that events are available to all consumers
            // and are not removed from the partition when a consumer reads them.  This allows for different consumers to read and
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

            await using (var client = new EventHubClient(connectionString, eventHubName))
            {
                // With our client, we can now inspect the partitions and find the identifier
                // of the first.

                string firstPartition = (await client.GetPartitionIdsAsync()).First();

                // In this example, we will create our consumer for the first partition in the Event Hub, using the default consumer group
                // that is created with an Event Hub.  Our consumer will begin watching the partition at the very end, reading only new events
                // that we will publish for it.

                await using (EventHubConsumer consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, firstPartition, EventPosition.Latest))
                await using (EventHubProducer producer = client.CreateProducer(new EventHubProducerOptions { PartitionId = firstPartition }))
                {
                    // Because our consumer is reading from the latest position, it won't see events that have previously
                    // been published.  Before we can publish the events, we will need to ask the consumer to perform an operation,
                    // because it opens its connection only when it needs to.  The first receive that we ask of it will not see
                    // any events, but will allow the consumer to start watching the partition.
                    //
                    // Because the maximum wait time is specivied as zero, this call will return immediately and will not
                    // have consumed any events.

                    await consumer.ReceiveAsync(1, TimeSpan.Zero);

                    // Now that the consumer is watching the partition, let's publish the event that we would like to
                    // receive.

                    await producer.SendAsync(new EventData(Encoding.UTF8.GetBytes("Hello, Event Hubs!")));
                    Console.WriteLine("The event batch has been published.");

                    // Because publishing and receving events is asynchronous, the events that we published may not
                    // be immediately available for our consumer to see.
                    //
                    // Each receive specifies the maximum amount of events that we would like in the batch and the maximum
                    // amount of time that we would like to wait for them.  If there are enough events available to meet the
                    // requested amount, they'll be returned immediately.  If not, the consumer will wait and collect events
                    // as they become available in an attempt to reach the requested amount.  If the maximum time that we've
                    // allowed it to wait passes, the consumer will return the events that it has collected so far.
                    //
                    // Each Receive call may return between zero and the number of events that we requested, depending on the
                    // state of events in the partition.  Likewise, it may return immediately or take up to the maximum wait
                    // time that we've allowed.
                    //
                    // We will ask for just our event, but allow a fairly long wait period to ensure that we're able to receive it.
                    // If you observe the time that the call takes, it is extremely likely that the request to receive will complete
                    // long before the maximum wait time.

                    Stopwatch watch = Stopwatch.StartNew();
                    IEnumerable<EventData> receivedBatch = await consumer.ReceiveAsync(1, TimeSpan.FromSeconds(2.5));
                    watch.Stop();

                    // Print out the events that we received.

                    Console.WriteLine();
                    Console.WriteLine($"The following events were consumed in { watch.ElapsedMilliseconds } milliseconds:");

                    foreach (EventData eventData in receivedBatch)
                    {
                        // The body of our event was an encoded string; we'll recover the
                        // message by reversing the encoding process.

                        string message = Encoding.UTF8.GetString(eventData.Body.ToArray());
                        Console.WriteLine($"\tMessage: \"{ message }\"");
                    }
                }
            }

            // At this point, our client, consumer, and producer have passed their "using" scope and have safely been disposed of.  We
            // have no further obligations.

            Console.WriteLine();
        }
    }
}
