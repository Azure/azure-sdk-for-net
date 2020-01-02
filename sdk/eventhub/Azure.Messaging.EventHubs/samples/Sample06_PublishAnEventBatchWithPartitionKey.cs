// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Samples.Infrastructure;

namespace Azure.Messaging.EventHubs.Samples
{
    /// <summary>
    ///   An introduction to publishing events, using a partition key to group batches together.
    /// </summary>
    ///
    public class Sample06_PublishAnEventBatchWithPartitionKey : IEventHubsSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name => nameof(Sample06_PublishAnEventBatchWithPartitionKey);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description => "An introduction to publishing events, using a partition key to group batches together.";

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
                // When publishing events, it may be desirable to request that the Event Hubs service keep the different
                // event batches together on the same partition.  This can be accomplished by setting a
                // partition key when publishing the batch.
                //
                // The partition key is NOT the identifier of a specific partition.  Rather, it is an arbitrary piece of string data
                // that Event Hubs uses as the basis to compute a hash value.  Event Hubs will associate the hash value with a specific
                // partition, ensuring that any events published with the same partition key are routed to the same partition.
                //
                // Note that there is no means of accurately predicting which partition will be associated with a given partition key;
                // we can only be assured that it will be a consistent choice of partition.  If you have a need to understand which
                // exact partition an event is published to, you will need to use an Event Hub producer associated with that partition.
                //
                // We will publish a small batch of events based on simple sentences.

                // To choose a partition key, you will need to create a custom set of batch options.

                var batchOptions = new CreateBatchOptions
                {
                    PartitionKey = "Any Value Will Do..."
                };

                using EventDataBatch eventBatch = await producerClient.CreateBatchAsync(batchOptions);
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Hello, Event Hubs!")));
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Goodbye, Event Hubs!")));

                await producerClient.SendAsync(eventBatch);

                Console.WriteLine("The event batch has been published.");
            }

            // At this point, our client has passed its "using" scope and has safely been disposed of.  We
            // have no further obligations.

            Console.WriteLine();
        }
    }
}
