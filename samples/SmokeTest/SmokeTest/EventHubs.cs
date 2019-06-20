using Azure;
using Azure.Messaging.EventHubs;
using Microsoft.Azure.Amqp.Framing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmokeTest
{
    class EventHubs
    {
        public static async Task performFunctionalities()
        {
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("EVENT HUBS");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Functionalities to test: 2:");
            Console.WriteLine("1.- Send an Event batch");
            Console.WriteLine("2.- Recieve those events\n");

            /* Create EventHub client.
             * THe connection string is retreived from a Envirnment variable
             */
            var client = new EventHubClient(Environment.GetEnvironmentVariable("EventHubs_ConnectionString"));

            Console.Write("Creating the Sender and Receivers... ");
            var response = await CreateSenderAndReceiver(client);
            Console.Write("Done\n");

            Console.Write(await SendAndReceiveEvents(response.Item1, response.Item2) + '\n');

        }

        private static async Task<Tuple<EventSender,EventReceiver>> CreateSenderAndReceiver(EventHubClient client)
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

            var sender = client.CreateSender(senderOptions);
            var receiver = client.CreateReceiver(partition, receiverOptions);

            return new Tuple<EventSender, EventReceiver>(sender, receiver);
        }

        private static async Task<string> SendAndReceiveEvents(EventSender sender, EventReceiver receiver)
        {

            //Start the receiver
            await receiver.ReceiveAsync(1, TimeSpan.Zero);

            //Create the event batch to send
            var eventBatch = new[]
                {
                    new EventData(Encoding.UTF8.GetBytes("First event data")),
                    new EventData(Encoding.UTF8.GetBytes("Second event data")),
                    new EventData(Encoding.UTF8.GetBytes("Third event data"))
                };

            //Send events
            Console.Write("Ready to send a batch of " + eventBatch.Count().ToString() + " events... ");
            await sender.SendAsync(eventBatch);
            Console.Write("Sent\n");

            //Receive the events
            var receivedEvents = new List<EventData>();
            var index = 0;

            Console.Write("Receiving events... ");
            while ((receivedEvents.Count < eventBatch.Length) && (++index < 3))
            {
                receivedEvents.AddRange(await receiver.ReceiveAsync(eventBatch.Length + 10, TimeSpan.FromMilliseconds(25)));
            }
            index = 0;

            //Check if at least one event was received
            if(receivedEvents.Count == 0)
            {
                return "Error, No events received.";
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
                    return "Error, Event: '" + receivedEventMessage + "' was not expected.";
                }
                ++index;
            }

            //Check if the number of events received match the number of events sent
            if (index < eventBatch.Count())
            {
                return "Error, expecting " + eventBatch.Count().ToString() + " events, but only got " + index.ToString() + ".";
            }

            return "Success";
        }

    }
}
