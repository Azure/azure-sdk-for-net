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
    ///   An introduction to Event Hubs, exploring additional options for creating an <see cref="EventHubClient" />.
    /// </summary>
    ///
    public class Sample2_ClientWithCustomOptions : IEventHubsSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name { get; } = nameof(Sample2_ClientWithCustomOptions);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description { get; } = "An introduction to Event Hubs, exploring additional options for creating an Event Hub client.";

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
            // The Event Hub client offers additional options on creation, which allow you to control different aspects of its behavior.
            // This is a common concept in the client library, and is extended to many of the types that you create to perform operations against
            // an Event Hub.  If you choose not to provide these options, a set of defaults is applied.
            //
            // The Event Hub client allows you to customize how it interacts with the Event Hubs service on an operational level,
            // by specifying the timeout that is used while waiting for the Event Hubs service to respond and the retry policy to
            // apply for a failed operation.
            //
            // The Event Hub client also allows you to customize how it connects to the service by specifying the specific transport that it
            // should communicate over and whether it should make use of a proxy for network communication.
            //
            // Please note that the proxy is only supported when using Websockets as a transport; it isn't compatibile with raw TCP or other
            // transport channels.

            var clientOptions = new EventHubClientOptions
            {
               DefaultTimeout = TimeSpan.FromMinutes(1),
               Retry = new ExponentialRetry(TimeSpan.FromSeconds(0.25), TimeSpan.FromSeconds(30), 5),
               TransportType = TransportType.AmqpWebSockets,
               Proxy = (IWebProxy)null
            };

            await using (var client = new EventHubClient(connectionString, eventHubName, clientOptions))
            {
                // Using the client, we will inspect the Event Hub that it is connected to, getting
                // access to metadata about it.

                EventHubProperties properties = await client.GetPropertiesAsync();

                Console.WriteLine("The Event Hub has the following properties:");
                Console.WriteLine($"\tThe path to the Event Hub from the namespace is: { properties.Path }");
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
