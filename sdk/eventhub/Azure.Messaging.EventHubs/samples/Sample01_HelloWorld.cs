// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Metadata;
using Azure.Messaging.EventHubs.Samples.Infrastructure;

namespace Azure.Messaging.EventHubs.Samples
{
    /// <summary>
    ///   An introduction to Event Hubs, illustrating how to connect and query the service.
    /// </summary>
    ///
    public class Sample01_HelloWorld : IEventHubsSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name { get; } = nameof(Sample01_HelloWorld);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description { get; } = "An introduction to Event Hubs, illustrating how to create a client and explore an Event Hub.";

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
            // To interact with an Event Hubs, a client is needed.  There are clients associated with each of the core areas of functionality
            // with an Event Hub, naming publishing events and consuming events.  Each of these clients manages resources and should be
            // explicitly closed or disposed, but it is not necessary to do both.
            //
            // In this example, we will create a producer client and use it to inspect the properties of an Event Hub.  When complete, we take
            // advantage of the new asynchronous dispose to ensure that clean-up is performed when we are done or when an exception is encountered.

            await using (var producerClient = new EventHubProducerClient(connectionString, eventHubName))
            {
                // Using the client, we will inspect the Event Hub that it is connected to, getting
                // access to its informational properties.

                EventHubProperties properties = await producerClient.GetEventHubPropertiesAsync();

                Console.WriteLine("The Event Hub has the following properties:");
                Console.WriteLine($"\tThe path to the Event Hub from the namespace is: { properties.Name }");
                Console.WriteLine($"\tThe Event Hub was created at: { properties.CreatedAt.ToString("yyyy-MM-dd hh:mm:ss tt (zzz)") }, in UTC.");
                Console.WriteLine();

                // Partitions of an Event Hub are an important concept.  Using the Event Hub properties, we'll inspect each of its partitions,
                // getting access to partition-level properties.

                foreach (string partitionId in properties.PartitionIds)
                {
                    PartitionProperties partitionProperties = await producerClient.GetPartitionPropertiesAsync(partitionId);

                    Console.WriteLine($"\tPartition: { partitionProperties.Id }");
                    Console.WriteLine($"\t\tThe partition contains no events: { partitionProperties.IsEmpty }");
                    Console.WriteLine($"\t\tThe first sequence number of an event in the partition is: { partitionProperties.BeginningSequenceNumber }");
                    Console.WriteLine($"\t\tThe last sequence number of an event in the partition is: { partitionProperties.LastEnqueuedSequenceNumber }");
                    Console.WriteLine($"\t\tThe last offset of an event in the partition is: { partitionProperties.LastEnqueuedOffset }");
                    Console.WriteLine($"\t\tThe last time that an event was enqueued in the partition is: { partitionProperties.LastEnqueuedTime.ToString("yyyy-MM-dd hh:mm:ss tt (zzz)") }, in UTC.");
                    Console.WriteLine();
                }
            }

            // At this point, our client has passed its "using" scope and has safely been disposed of.  We have no
            // further obligations.

            Console.WriteLine();
        }
    }
}
