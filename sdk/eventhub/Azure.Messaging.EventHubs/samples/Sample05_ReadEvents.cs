// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Samples.Infrastructure;

namespace Azure.Messaging.EventHubs.Samples
{
    /// <summary>
    ///   An introduction to reading all events available from an Event Hub.
    /// </summary>
    ///
    public class Sample05_ReadEvents : IEventHubsSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name => nameof(Sample05_ReadEvents);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description => "An introduction to reading all events available from an Event Hub.";

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
            // To start, we'll publish a small number of events using a producer client.  To ensure that our client is appropriately closed, we'll
            // take advantage of the asynchronous dispose when we are done or when an exception is encountered.

            await using (var producerClient = new EventHubProducerClient(connectionString, eventHubName))
            {
                using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Hello, Event Hubs!")));
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("The middle event is this one")));
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Goodbye, Event Hubs!")));

                await producerClient.SendAsync(eventBatch);

                Console.WriteLine("The event batch has been published.");
            }

            // Now that the events have been published, we'll read back all events from the Event Hub using a consumer client.
            // It's important to note that because events are not removed from the partition when consuming, that if you're using
            // an existing Event Hub for the sample, you will see events that were published prior to running this sample as well
            // as those from the batch that we just sent.
            //
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
            // In this example, we will create our consumer client using the default consumer group that is created with an Event Hub.
            // Our consumer will begin watching the partition at the very end, reading only new events that we will publish for it.

            await using (var consumerClient = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString, eventHubName))
            {
                // To ensure that we do not wait for an indeterminate length of time, we'll stop reading after we receive three events.  For a
                // fresh Event Hub, those will be the three that we had published.  We'll also ask for cancellation after 30 seconds, just to be
                // safe.

                using CancellationTokenSource cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(90));

                int eventsRead = 0;
                int maximumEvents = 3;

                await foreach (PartitionEvent partitionEvent in consumerClient.ReadEventsAsync(cancellationSource.Token))
                {
                    Console.WriteLine($"Event Read: { Encoding.UTF8.GetString(partitionEvent.Data.EventBody.ToBytes().ToArray()) }");
                    eventsRead++;

                    if (eventsRead >= maximumEvents)
                    {
                        break;
                    }
                }
            }

            // At this point, our clients have both passed their "using" scopes and have safely been disposed of.  We
            // have no further obligations.

            Console.WriteLine();
        }
    }
}
