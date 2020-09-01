// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Samples.Infrastructure;

namespace Azure.Messaging.EventHubs.Samples
{
    /// <summary>
    ///   An introduction to publishing events, specifying a specific partition for the batch to be published to.
    /// </summary>
    ///
    public class Sample07_PublishAnEventBatchToASpecificPartition : IEventHubsSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name => nameof(Sample07_PublishAnEventBatchToASpecificPartition);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description => "An introduction to publishing events, specifying a specific partition for the batch to be published to.";

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
                // To ensure that we request a valid partition, we'll need to read the metadata for the Event Hub.  We will
                // select the first available partition.

                string firstPartition = (await producerClient.GetPartitionIdsAsync()).First();

                // When publishing events, it may be desirable to request that the Event Hubs service place a batch on a specific partition,
                // for organization and processing.  For example, you may have designated one partition of your Event Hub as being responsible
                // for all of your telemetry-related events.
                //
                // This can be accomplished by setting the identifier of the desired partition when creating the batch.  It is important to note
                // that if you are using a partition identifier, you may not also specify a partition key; they are mutually exclusive.
                //
                // We will publish a small batch of events based on simple sentences.

                // To choose a partition identifier, you will need to create a custom set of batch options.

                var batchOptions = new CreateBatchOptions
                {
                    PartitionId = firstPartition
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
