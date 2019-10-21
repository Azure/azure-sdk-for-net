// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Samples.Infrastructure;

namespace Azure.Messaging.EventHubs.Samples
{
    /// <summary>
    ///   An example of publishing events, extending the event data with custom metadata.
    /// </summary>
    ///
    public class Sample07_PublishEventsWithCustomMetadata : IEventHubsSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name { get; } = nameof(Sample07_PublishEventsWithCustomMetadata);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description { get; } = "An example of publishing events, extending the event data with custom metadata.";

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
            // We will start by creating a producer client, using its default options.

            await using (var producerClient = new EventHubProducerClient(connectionString, eventHubName))
            {
                // Because an event consists mainly of an opaque set of bytes, it may be difficult for consumers of those events to
                // make informed decisions about how to process them.
                //
                // In order to allow event publishers to offer better context for consumers, event data may also contain custom metadata,
                // in the form of a set of key/value pairs.  This metadata is not used by, or in any way meaningful to, the Event Hubs
                // service; it exists only for coordination between event publishers and consumers.
                //
                // One common scenario for the inclusion of metadata is to provide a hint about the type of data contained by an event,
                // so that consumers understand its format and can deserialize it appropriately.
                //
                // We will publish a small batch of events based on simple sentences, but will attach some custom metadata with
                // pretend type names and other hints.  Note that the set of metadata is unique to an event; there is no need for every
                // event in a batch to have the same metadata properties available nor the same data type for those properties.

                var firstEvent = new EventData(Encoding.UTF8.GetBytes("Hello, Event Hubs!"));
                firstEvent.Properties.Add("EventType", "com.microsoft.samples.hello-event");
                firstEvent.Properties.Add("priority", 1);
                firstEvent.Properties.Add("score", 9.0);

                var secondEvent = new EventData(Encoding.UTF8.GetBytes("Goodbye, Event Hubs!"));
                secondEvent.Properties.Add("EventType", "com.microsoft.samples.goodbye-event");
                secondEvent.Properties.Add("priority", "17");
                secondEvent.Properties.Add("blob", true);

                await producerClient.SendAsync(new[] { firstEvent, secondEvent });

                Console.WriteLine("The event batch has been published.");
            }

            // At this point, our client has passed its "using" scope and have safely been disposed of.  We
            // have no further obligations.

            Console.WriteLine();
        }
    }
}
