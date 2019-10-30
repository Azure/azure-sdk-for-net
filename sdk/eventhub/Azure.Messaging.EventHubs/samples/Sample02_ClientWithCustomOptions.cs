// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Metadata;
using Azure.Messaging.EventHubs.Samples.Infrastructure;

namespace Azure.Messaging.EventHubs.Samples
{
    /// <summary>
    ///   An introduction to Event Hubs, exploring additional options for creating the
    ///   different Event Hub clients.
    /// </summary>
    ///
    public class Sample02_ClientWithCustomOptions : IEventHubsSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name { get; } = nameof(Sample02_ClientWithCustomOptions);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description { get; } = "An introduction to Event Hubs, exploring additional options for creating the different Event Hub clients.";

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
            // The clients for an Event Hub client each offer additional options on creation, allowing you to control different aspects of its behavior
            // should your scenario have needs that differ from the common defaults.  If you choose not to provide these options, the default behaviors
            // suitable to most scenarios is used.
            //
            // Each different Event Hub client allows you to customize how it interacts with the Event Hubs service, such as by customizing how it connects
            // to the service by specifying the transport that communication should use and whether a proxy should be used for network communications.  Please
            // note that a proxy is only supported when using WebSockets as a transport; it isn't compatible with raw TCP or other transport channels.
            //
            // The Event Hub clients each offer a common set of options, such as specifying the timeout and retry approach used while interacting with the
            // Event Hubs service.  A specific client will potentially allow you to customize behavior specific to its related operations.
            //

            // This sample will customize the transport for the connection, using WebSockets and will adjust some of the retry-related values for
            // illustration.

            var producerOptions = new EventHubProducerClientOptions
            {
               ConnectionOptions = new EventHubConnectionOptions
                {
                    TransportType = TransportType.AmqpWebSockets,
                    Proxy = (IWebProxy)null
                },

                RetryOptions = new RetryOptions
                {
                   MaximumRetries = 5,
                   TryTimeout = TimeSpan.FromMinutes(1)
                }
            };

            await using (var producer = new EventHubProducerClient(connectionString, eventHubName, producerOptions))
            {
                // Using the client, we will inspect the Event Hub that it is connected to, getting
                // access to metadata about it.

                EventHubProperties properties = await producer.GetEventHubPropertiesAsync();

                Console.WriteLine("The Event Hub has the following properties:");
                Console.WriteLine($"\tThe path to the Event Hub from the namespace is: { properties.Name }");
                Console.WriteLine($"\tThe Event Hub was created at: { properties.CreatedAt.ToString("yyyy-MM-dd hh:mm:ss tt (zzz)") }, in UTC.");
                Console.WriteLine("\tThe Event Hub has the following partitions:");

                foreach (string partitionId in properties.PartitionIds)
                {
                    Console.WriteLine($"\t\tPartition Id: { partitionId }");
                }
            }

            // At this point, our client has passed its "using" scope and has safely been disposed of.  We have no
            // further obligations.

            Console.WriteLine();
        }
    }
}
