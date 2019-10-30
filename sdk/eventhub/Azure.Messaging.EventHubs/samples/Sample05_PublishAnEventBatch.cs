// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Samples.Infrastructure;

namespace Azure.Messaging.EventHubs.Samples
{
    /// <summary>
    ///   An introduction to publishing events, using a size-aware batch to ensure the size
    ///   does not exceed the transport size limits.
    /// </summary>
    ///
    public class Sample05_PublishAnEventBatch : IEventHubsSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name { get; } = nameof(Sample05_PublishAnEventBatch);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description { get; } = "An introduction to publishing events, using a size-aware batch to ensure the size does not exceed the transport size limits.";

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
            // We will start by creating a producer client using its default options.

            await using (var producerClient = new EventHubProducerClient(connectionString, eventHubName))
            {
                // There is a limit to the size of an event or batch of events that can be published at once.  This limit varies, and depends
                // on the underlying transport and protocol that the Event Hub producer is using.  Because the size limit is based on the
                // size of an event or batch as it would be sent over the network, it is not simple to understand the size of an event as
                // it is being created.  For this reason, producers creating events with a large body or batching a large number of events
                // may experience errors when they attempt to send.
                //
                // In order to avoid errors, support creation of known-good batches, and allow for producers with the need to predictably
                // control bandwidth use, the Event Hub producer client allows creation of an Event Data Batch, which acts as a container for
                // a batch of events.  Events can be added to the batch using a "TryAdd" pattern, allowing insight into when an event
                // or batch would be too large without triggering an exception.
                //
                // An Event Data Batch can be created using a partition key or without one, following the same rules as the Event Hub
                // producer with respect to partition routing.  (see, Sample04_PublishEventsWithPartitionKey for more information.)

                // We will publish a batch of events based on simple sentences.

                var events = new EventData[]
                {
                    new EventData(Encoding.UTF8.GetBytes("Hello, Event Hubs!")),
                    new EventData(Encoding.UTF8.GetBytes("Goodbye, Event Hubs!")),
                    new EventData(Encoding.UTF8.GetBytes("A third event, the plot thickens!")),
                    new EventData(Encoding.UTF8.GetBytes("...and a fourth too."))
                };

                // When creating the batch, you may specify a custom set of options or allow the defaults to take precedence.
                // If a size limit is not specified, the maximum size allowed by the transport is used.  In this example, we
                // will set a custom partition key and otherwise use the default options.

                BatchOptions options = new BatchOptions { PartitionKey = "This is a custom key!" };
                EventDataBatch batch = await producerClient.CreateBatchAsync(options);

                foreach (EventData eventData in events)
                {
                    if (!batch.TryAdd(eventData))
                    {
                        throw new ApplicationException("The events will not fit in the same batch.");
                    }
                }

                // When publishing a batch, no SendOptions may be specified.  Those options are
                // all expressed upfront during batch creation and apply to all events in the batch.

                await producerClient.SendAsync(batch);

                Console.WriteLine("The event batch has been published.");
            }

            // At this point, our client has passed its "using" scope and have safely been disposed of.  We
            // have no further obligations.

            Console.WriteLine();
        }
    }
}
