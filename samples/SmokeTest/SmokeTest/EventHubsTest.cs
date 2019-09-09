// ------------------------------------
// Copyright(c) Microsoft Corporation.
// Licensed under the MIT License.
// ------------------------------------
using Azure;
using Azure.Messaging.EventHubs;
using Microsoft.Azure.Amqp.Framing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmokeTest
{
    class EventHubsTest
    {
        private static EventHubClient client;
        private static EventHubProducer sender;
        private static EventHubConsumer receiver;

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
            client = new EventHubClient(connectionString);

            await CreateSenderAndReceiver();
            await SendAndReceiveEvents();
        }

        private static async Task CreateSenderAndReceiver()
        {
            Console.Write("Creating the Sender and Receivers... ");
            var partition = (await client.GetPartitionIdsAsync()).First();
            var producerOptions = new EventHubProducerOptions
            {
                PartitionId = partition
            };
            sender = client.CreateProducer(producerOptions);
            receiver = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest);
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