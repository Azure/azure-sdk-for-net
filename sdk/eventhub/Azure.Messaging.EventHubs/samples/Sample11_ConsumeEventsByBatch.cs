// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Samples.Infrastructure;

namespace Azure.Messaging.EventHubs.Samples
{
    /// <summary>
    ///   An example of consuming events, using a batch approach to control throughput.
    /// </summary>
    ///
    public class Sample11_ConsumeEventsByBatch : IEventHubsSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name { get; } = nameof(Sample11_ConsumeEventsByBatch);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description { get; } = "An example of consuming events, using a batch approach to control throughput.";

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
                // Because our consumer client is reading from the latest position, it won't see events that have previously
                // been published. Before we can publish the events, we will need to ask the consumer to perform an operation,
                // because it opens its connection only when it needs to.  The first receive that we ask of it will not see
                // any events, but will allow the consumer to start watching the partition.
                //
                // Because the maximum wait time is specified as zero, this call will return immediately and will not
                // have consumed any events.

                await consumerClient.ReceiveAsync(1, TimeSpan.Zero);

                // Now that the consumer is watching the partition, let's publish a fair sized batch of events
                // we would like for it to consume.

                int eventBatchSize = 100;
                EventData[] eventBatch = new EventData[eventBatchSize];

                for (int index = 0; index < eventBatchSize; ++index)
                {
                    eventBatch[index] = new EventData(Encoding.UTF8.GetBytes($"I am event #{ index }"));
                }

                await producerClient.SendAsync(eventBatch);
                Console.WriteLine($"The event batch with { eventBatchSize } events has been published.");

                // To allow for throughput in our application, we will process the published events by consuming them in
                // small batches with a small wait time.  This will allow us to receive and process more quickly than blocking
                // to wait on a larger batch size.
                //
                // The values that are used in this example are intended just for illustration and not intended as guidance for a recommended
                // set of defaults.  In a real-world application, determining the right balance of batch size and wait time to achieve
                // the desired performance will often vary depending on the application and event data being consumed.  It is an area
                // where some experimentation in the application context may prove helpful.
                //
                // Our example will attempt to read about 1/5 of the batch at a time, which should result in the need for 5 batches to
                // be consumed.  Because publishing and receiving events is asynchronous, the events that we published may not be
                // immediately available for our consumer to see. To compensate, we will allow for a small number of extra attempts beyond
                // the expected 5 to be sure that we don't stop reading before we receive all of our events.

                var receivedEvents = new List<EventData>();
                int consumeBatchSize = (int)Math.Floor(eventBatchSize / 5.0f);
                int maximumAttempts = 15;
                int attempts = 0;

                while ((receivedEvents.Count < eventBatchSize) && (++attempts < maximumAttempts))
                {
                    // Each receive, we ask for the maximum amount of events that we would like in the batch and
                    // specify the maximum amount of time that we would like to wait for them.
                    //
                    // The batch of events will be returned to us when either we have read our maximum number of events
                    // or when the time that we asked to wait has elapsed.  This means that a batch we receive may have
                    // between zero and the maximum we asked for, depending on what was available in the partition.
                    //
                    // For this attempt, we will ask to receive our computed batch size (1/5 of published events) and wait, at most,
                    // 25 milliseconds to receive them.  We'll then process them and if we haven't gotten all that we published, we'll
                    // make another attempt until either we have them or we have tried for our maximum number of attempts.

                    IEnumerable<EventData> receivedBatch = await consumerClient.ReceiveAsync(consumeBatchSize, TimeSpan.FromMilliseconds(25));
                    receivedEvents.AddRange(receivedBatch);
                }

                // Print out the events that we received.

                Console.WriteLine();
                Console.WriteLine($"Events Consumed: { receivedEvents.Count }");

                foreach (EventData eventData in receivedEvents)
                {
                    // The body of our event was an encoded string; we'll recover the
                    // message by reversing the encoding process.

                    string message = Encoding.UTF8.GetString(eventData.Body.ToArray());
                    Console.WriteLine($"\tMessage: \"{ message }\"");
                }
            }

            // At this point, our clients have passed their "using" scope and have safely been disposed of.  We
            // have no further obligations.

            Console.WriteLine();
        }
    }
}
