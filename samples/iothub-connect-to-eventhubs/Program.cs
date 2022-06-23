
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;

namespace IotHubToEventHubsSample
{
    /// <summary>
    ///   Serves as the main entry point for the application.
    /// </summary>
    ///
    public static class Program
    {
        /// <summary>
        ///   The method invoked as the main entry point for execution.
        /// </summary>
        ///
        /// <param name="args">The arguments passed to the application on the command line.</param>
        ///
        /// <returns>Zero for a successful run, non-zero when an exception is encountered.</returns>
        ///
        /// <remarks>
        ///   If arguments are passed, the first argument is assumed to be the IoT Hub connection string; the rest
        ///   are ignored.  If no arguments were present, an interactive prompt will collect the IoT Hub connection.
        /// </remarks>
        ///
        public static async Task<int> Main(string[] args)
        {
            var connectionString = default(string);

            try
            {
                // If there were arguments passed, assume the first is the connection string.

                if (args.Length > 0)
                {
                    connectionString = args[0];
                }

                // If there was no connection string provided, then prompt for one.

                while (string.IsNullOrEmpty(connectionString))
                {
                    Console.Write("Please provide the connection string for the IoT Hub that you'd like to use and then press Enter: ");
                    connectionString = Console.ReadLine().Trim();
                    Console.WriteLine();
                }

                // Translate the connection string.

                Console.WriteLine();
                Console.WriteLine("Requesting Event Hubs connection string...");
                var eventHubsConnectionString = await IotHubConnection.RequestEventHubsConnectionStringAsync(connectionString);

                Console.WriteLine("Connection string obtained.  Connecting to Event Hubs...");
                await using var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, eventHubsConnectionString);

                // Read events from any partition of the Event Hub; once no events are read after a couple of seconds, stop reading.

                Console.WriteLine();
                Console.WriteLine("Reading events...");
                var consecutiveEmpties = 0;

                await foreach (var partitionEvent in consumer.ReadEventsAsync(new ReadEventOptions { MaximumWaitTime = TimeSpan.FromMilliseconds(500) }))
                {
                    if (partitionEvent.Data != null)
                    {
                        Console.WriteLine($"\tRead an event from partition { partitionEvent.Partition.PartitionId }");
                        consecutiveEmpties = 0;
                    }
                    else if (++consecutiveEmpties > 5)
                    {
                        Console.WriteLine("\tNo events are available. No longer reading...");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An exception of type { ex.GetType().Name } occurred.  Message:{ Environment.NewLine }\t{ ex.Message }");
                return -1;
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Exiting...");

            return 0;
        }
    }
}
