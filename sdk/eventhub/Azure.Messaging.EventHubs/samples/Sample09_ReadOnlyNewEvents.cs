// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Samples.Infrastructure;

namespace Azure.Messaging.EventHubs.Samples
{
    /// <summary>
    ///   An example of reading events, beginning with only those newly available from an Event Hub.
    /// </summary>
    ///
    public class Sample09_ReadOnlyNewEvents : IEventHubsSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name => nameof(Sample09_ReadOnlyNewEvents);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description => "An example of reading events, beginning with only those newly available from an Event Hub.";

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
            // In this example, our consumer will read from the latest position instead of the earliest.  As a result, it won't see events that
            // have previously been published.  Before we can publish the events and have them observed, we will need to ask the consumer
            // to perform a read operation in order for it to begin observing the Event Hub partitions.
            //
            // Each partition of an Event Hub represents potentially infinite stream of events.  When a consumer is reading, there is no definitive
            // point where it can assess that all events have been read and no more will be available.  As a result, when the consumer reaches the end of
            // the available events for a partition, it will continue to wait for new events to arrive so that it can surface them to be processed. During this
            // time, the iterator will block.
            //
            // In order to prevent the consumer from waiting forever for events, and blocking other code, there are two methods available for developers to
            // control this behavior.  First, signaling the cancellation token passed when reading will cause the consumer to stop waiting and end iteration
            // immediately.  This is desirable when you have decided that you are done reading and do not wish to continue.  It is not ideal, however, when
            // you would like control returned to your code momentarily to perform some action and then to continue reading.
            //
            // In that scenario, you may specify a maximum wait time which is applied to each iteration of the enumerator.  If that interval passes without an
            // event being available to read, the enumerator will emit an empty event in order to return control to the loop body.  This allows you to take action,
            // such as sending a heartbeat, emitting telemetry, or simply exiting the loop.
            //
            // For our loop, we'll specify a small wait time when we begin reading, which will allow control to return to our code so that we may publish
            // the events after we ensure the consumer is observing the partition.

            await using (var consumerClient = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString, eventHubName))
            {
                bool wereEventsPublished = false;
                int eventBatchCount = 0;
                List<EventData> receivedEvents = new List<EventData>();

                // Each time the consumer looks to read events, we'll ask that it waits only a short time before emitting
                // an empty event, so that our code has the chance to run without indefinite blocking.

                ReadEventOptions readOptions = new ReadEventOptions
                {
                    MaximumWaitTime = TimeSpan.FromMilliseconds(150)
                };

                // As a preventative measure, we'll also specify that cancellation should occur after 2 minutes, so that we don't iterate indefinitely
                // in the event of a service error where the events we've published cannot be read.

                using CancellationTokenSource cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromMinutes(2));

                // The reading of all events will default to the earliest events available in each partition; in order to begin reading at the
                // latest event, we'll need to specify that reading should not start at earliest.

                await foreach (PartitionEvent currentEvent in consumerClient.ReadEventsAsync(startReadingAtEarliestEvent: false, readOptions, cancellationSource.Token))
                {
                    if (!wereEventsPublished)
                    {
                        await using (var producerClient = new EventHubProducerClient(connectionString, eventHubName))
                        {
                            using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();
                            eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Hello, Event Hubs!")));
                            eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Goodbye, Event Hubs!")));

                            await producerClient.SendAsync(eventBatch);
                            wereEventsPublished = true;
                            eventBatchCount = eventBatch.Count;

                            await Task.Delay(250);
                            Console.WriteLine("The event batch has been published.");
                        }

                        // Since we know that there was no event to observe for this iteration,
                        // we'll just skip to the next one.

                        continue;
                    }

                    // Because publishing and receiving events is asynchronous, the events that we published may not
                    // be immediately available for our consumer to see, so we'll have to guard against an empty event being sent
                    // if our wait time interval has elapsed before the consumer observed the events that we published.

                    if (currentEvent.Data != null)
                    {
                        receivedEvents.Add(currentEvent.Data);

                        if (receivedEvents.Count >= eventBatchCount)
                        {
                            break;
                        }
                    }
                }

                // Print out the events that we received; the body is an encoded string; we'll recover the message by reversing the encoding process.

                Console.WriteLine();

                foreach (EventData currentEvent in receivedEvents)
                {
                    string message = Encoding.UTF8.GetString(currentEvent.Body.ToArray());
                    Console.WriteLine($"\tEvent Message: \"{ message }\"");
                }
            }

            // At this point, our clients have passed their "using" scope and have safely been disposed of.  We
            // have no further obligations.

            Console.WriteLine();
        }
    }
}
