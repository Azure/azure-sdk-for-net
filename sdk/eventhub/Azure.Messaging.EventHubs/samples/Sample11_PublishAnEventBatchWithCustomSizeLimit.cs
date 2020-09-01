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
    ///   An example of publishing events using a custom size limitation with the batch.
    /// </summary>
    ///
    public class Sample11_PublishAnEventBatchWithCustomSizeLimit : IEventHubsSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name => nameof(Sample11_PublishAnEventBatchWithCustomSizeLimit);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description => "An example of publishing events using a custom size limitation with the batch.";

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
                // There is a limit to the size of an event or batch of events that can be published at once.  This limit varies and depends
                // on the Event Hubs service and the properties of the namespace that owns the target Event Hub.  Because the size limit is based
                // on the size of an event or batch as it would be sent over the network, it is not simple to understand the size of an event as
                // it is being created.
                //
                // In order to avoid failures when publishing, events are packaged into an Event Batch.  When created, the batch is informed
                // of the size limit for the associated Event Hub.  Events can be added to the batch using a "TryAdd" pattern, allowing insight
                // into when an event or batch would be too large to publish without triggering an exception.
                //
                // To support scenarios where bandwidth is limited or publishers need to maintain control over how much data is transmitted,
                // a custom size limit (in bytes) may be specified when creating an event batch, overriding the default specified by the Event
                // Hub.  It is important to note that the custom limit may not exceed the limit specified by the Event Hub.
                //
                // In this example, we'll create a batch with a small limit and add events until no more are able to fit.

                CreateBatchOptions options = new CreateBatchOptions
                {
                    MaximumSizeInBytes = 150
                };

                using EventDataBatch batch = await producerClient.CreateBatchAsync(options);
                EventData currentEvent = new EventData(Encoding.UTF8.GetBytes("First event"));

                while (batch.TryAdd(currentEvent))
                {
                    Console.WriteLine($"The batch is now { batch.SizeInBytes } bytes in size.");
                    currentEvent = new EventData(Encoding.UTF8.GetBytes($"Event { batch.Count + 1 }"));
                }

                Console.WriteLine($"The final size of the batch is { batch.SizeInBytes } bytes.");
                Console.WriteLine();

                // Now that the batch is full, send it.

                await producerClient.SendAsync(batch);
                Console.WriteLine("The event batch has been published.");
            }

            // At this point, our client has passed its "using" scope and has safely been disposed of.  We
            // have no further obligations.

            Console.WriteLine();
        }
    }
}
