// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Samples.Infrastructure;

namespace Azure.Messaging.EventHubs.Samples
{
    /// <summary>
    ///   An introduction to publishing events, using an <see cref="EventHubProducer" /> that is associated with a specific partition.
    /// </summary>
    ///
    public class Sample06_PublishEventsToSpecificPartitions : IEventHubsSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name { get; } = nameof(Sample06_PublishEventsToSpecificPartitions);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description { get; } = "An introduction to publishing events, using aa Event Hub producer that is associated with a specific partition.";

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
            // We will start by creating a client using its default set of options.

            await using (var client = new EventHubClient(connectionString, eventHubName))
            {
                // Because partitions are owned by the Event Hubs service, it is not advised to assume that they have a stable
                // and predictable set of identifiers.  We'll inspect the Event Hub and select the first partition to use for
                // publishing our event batch.

                string[] partitionIds = await client.GetPartitionIdsAsync();

                // In order to request that a producer be associated with a specific partition, it needs to be created with a custom
                // set of options.  Like the Event Hub client, there are options for a producer available to tune the behavior for
                // operations that interact with the Event Hubs service.
                //
                // In our case, we will set the partition association but otherwise make use of the default options.

                var producerOptions = new EventHubProducerOptions
                {
                    PartitionId = partitionIds[0]
                };

                await using (var producer = client.CreateProducer(producerOptions))
                {
                    // When an Event Hub producer is associated with any specific partition, it can publish events only to that partition.
                    // The producer has no ability to ask for the service to route events, including by using a partition key.
                    //
                    // If you attempt to use a partition key with an Event Hub producer that is associated with a partition, an exception
                    // will occur.  Otherwise, publishing to a specific partition is exactly the same as other publishing scenarios.

                    // We will publish a small batch of events based on simple sentences.

                    var eventBatch = new EventData[]
                    {
                        new EventData(Encoding.UTF8.GetBytes("Hello, Event Hubs!")),
                        new EventData(Encoding.UTF8.GetBytes("Goodbye, Event Hubs!"))
                    };

                    await producer.SendAsync(eventBatch);

                    Console.WriteLine("The event batch has been published.");
                }
            }

            // At this point, our client and producer have passed their "using" scope and have safely been disposed of.  We
            // have no further obligations.

            Console.WriteLine();
        }
    }
}
