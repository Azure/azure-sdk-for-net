// ------------------------------------
// Copyright(c) Microsoft Corporation.
// Licensed under the MIT License.
// ------------------------------------
using Azure.Messaging.EventHubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeTest
{
    class EventHubsTest
    {
        private static EventHubProducerClient sender;
        private static EventHubConsumerClient receiver;

        /// <summary>
        /// Test the Event Hubs SDK by sending and receiving events
        /// </summary>
        public static async Task RunTests()
        {
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("EVENT HUBS");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Functionalities to test: 2:");
            Console.WriteLine("1.- Send an Event batch");
            Console.WriteLine("2.- Recieve those events\n");

            var connectionString = Environment.GetEnvironmentVariable("EVENT_HUBS_CONNECTION_STRING");

            await CreateSenderAndReceiver(connectionString);
            await SendAndReceiveEvents();
        }

        private static async Task<string> GetPartitionId(string connectionString)
        {
            var client = new EventHubProducerClient(connectionString);
            var result = (await client.GetPartitionIdsAsync()).First();
            await client.DisposeAsync();
            return result;
        }

        private static async Task CreateSenderAndReceiver(string connectionString)
        {
            Console.Write("Creating the Sender and Receivers... ");

            var partitionId = await GetPartitionId(connectionString);

            var producerOptions = new EventHubProducerClientOptions
            {
                PartitionId = partitionId,
            };
            sender = new EventHubProducerClient(connectionString, producerOptions);
            receiver = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, partitionId, EventPosition.Latest, connectionString);
            Console.WriteLine("\tdone");
        }

        private static async Task SendAndReceiveEvents()
        {
            var eventBatch = new[]
                {
                new EventData(Encoding.UTF8.GetBytes("First event data")),
                new EventData(Encoding.UTF8.GetBytes("Second event data")),
                new EventData(Encoding.UTF8.GetBytes("Third event data"))
            };
            var index = 0;
            var receivedEvents = new List<EventData>();

            //Before sending any event, start the receiver
            await receiver.ReceiveAsync(1, TimeSpan.Zero);

            Console.Write("Ready to send a batch of " + eventBatch.Count().ToString() + " events... ");
            await sender.SendAsync(eventBatch);
            Console.Write("Sent\n");

            Console.Write("Receiving events... ");
            while ((receivedEvents.Count < eventBatch.Length) && (++index < 3))
            {
                receivedEvents.AddRange(await receiver.ReceiveAsync(eventBatch.Length + 10, TimeSpan.FromMilliseconds(25)));
            }

            if (receivedEvents.Count == 0)
            {
                throw new Exception(String.Format("Error, No events received."));
            }
            Console.Write(receivedEvents.Count() + " events received.\n");

            if (receivedEvents.Count() < eventBatch.Count())
            {
                throw new Exception(String.Format($"Error, expecting {eventBatch.Count()} events, but only got {receivedEvents.Count().ToString()}."));
            }

            Console.WriteLine("done");
        }
    }
}