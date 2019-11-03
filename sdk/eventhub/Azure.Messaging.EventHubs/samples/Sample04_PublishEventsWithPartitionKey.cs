// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Samples.Infrastructure;

namespace Azure.Messaging.EventHubs.Samples
{
    /// <summary>
    ///   An introduction to publishing events, using a partition key to group them together.
    /// </summary>
    ///
    public class Sample04_PublishEventsWithPartitionKey : IEventHubsSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name { get; } = nameof(Sample04_PublishEventsWithPartitionKey);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description { get; } = "An introduction to publishing events, using a partition key to group them together.";

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
            // We will start by creating a producer client using its default set of options.

            await using (var producerClient = new EventHubProducerClient(connectionString, eventHubName))
            {
                // When publishing events with a producer client it may be desirable to request that the Event Hubs service keep
                // different events or batches of events together on the same partition.  This can be accomplished by setting a
                // partition key when publishing the events.
                //
                // The partition key is NOT the identifier of a specific partition.  Rather, it is an arbitrary piece of string data
                // that Event Hubs uses as the basis to compute a hash value.  Event Hubs will associate the hash value with a specific
                // partition, ensuring that any events published with the same partition key are routed to the same partition.
                //
                // Note that there is no means of accurately predicting which partition will be associated with a given partition key;
                // we can only be assured that it will be a consistent choice of partition.  If you have a need to understand which
                // exact partition an event is published to, you will need to use an Event Hub producer associated with that partition.

                // We will publish a small batch of events based on simple sentences.

                var eventBatch = new EventData[]
                {
                    new EventData(Encoding.UTF8.GetBytes("Hello, Event Hubs!")),
                    new EventData(Encoding.UTF8.GetBytes("Goodbye, Event Hubs!"))
                };

                // To choose a partition key, you will need to create a custom set of send options.

                var sendOptions = new SendOptions
                {
                    PartitionKey = "Any Value Will Do..."
                };

                await producerClient.SendAsync(eventBatch, sendOptions);

                Console.WriteLine("The event batch has been published.");
            }

            // At this point, our client has passed its "using" scope and have safely been disposed of.  We
            // have no further obligations.

            Console.WriteLine();
        }
    }
}
