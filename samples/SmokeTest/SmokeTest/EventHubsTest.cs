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
    class EventHubsTest : TestBase
    {
        private EventHubClient client;
        private EventSender sender;
        private EventReceiver receiver;

        public EventHubsTest(string connectionString)
        {
            this.client = new EventHubClient(connectionString);
        }

        /// <summary>
        /// Test the Event Hubs SDK by sending and receiving events
        /// </summary>
        /// <returns>true if pases, false if fails</returns>
        public async Task<bool> RunTests()
        {
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("EVENT HUBS");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Functionalities to test: 2:");
            Console.WriteLine("1.- Send an Event batch");
            Console.WriteLine("2.- Recieve those events\n");

            Console.Write("Creating the Sender and Receivers... ");
            var result1 = await ExcecuteTest(CreateSenderAndReceiver);
            if(!result1)
            {
                //If this test fail, the next one is going to fail too.
                Console.WriteLine("Cannot send or receive events.");
                return false;
            }

            var result2 = await ExcecuteTest(SendAndReceiveEvents);
            if(!result2)
            {
                return false;
            }

            return true;
        }

        private async Task CreateSenderAndReceiver()
        {
            var partition = (await client.GetPartitionIdsAsync()).First();
            var senderOptions = new EventSenderOptions
            {
                PartitionId = partition
            };
            var receiverOptions = new EventReceiverOptions
            {
                BeginReceivingAt = EventPosition.NewEventsOnly
            };
            sender = client.CreateSender(senderOptions);
            receiver = client.CreateReceiver(partition, receiverOptions);
        }

        private async Task SendAndReceiveEvents()
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
            index = 0;

            //Check if at least one event was received in roder to start validation
            if (receivedEvents.Count == 0)
            {
                throw new Exception(String.Format("Error, No events received."));
            }
            Console.Write(receivedEvents.Count() + " events received.\n");

            Console.WriteLine("Beggining validation...");
            foreach (var receivedEvent in receivedEvents)
            {
                var receivedEventMessage = Encoding.UTF8.GetString(receivedEvent.Body.ToArray());
                var sentEventMessage = Encoding.UTF8.GetString(eventBatch[index].Body.ToArray());

                if (receivedEventMessage == sentEventMessage)
                {
                    Console.WriteLine("\tEvent '" + receivedEventMessage + "' correctly validated.");
                }
                else
                {
                    throw new Exception(String.Format("Error, Event: '" + receivedEventMessage + "' was not expected."));                
                }
                index++;
            }

            if (index < eventBatch.Count())
            {
                throw new Exception(String.Format("Error, expecting " + eventBatch.Count().ToString() + " events, but only got " + index.ToString() + "."));
            }
        }
    }
}