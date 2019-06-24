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
    class EventHubs
    {
        private EventHubClient client;
        private EventSender sender;
        private EventReceiver receiver;

        public EventHubs(string connectionString)
        {
            this.client = new EventHubClient(connectionString);
        }

        public async Task<bool> PerformFunctionalities()
        {
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("EVENT HUBS");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Functionalities to test: 2:");
            Console.WriteLine("1.- Send an Event batch");
            Console.WriteLine("2.- Recieve those events\n");

            Console.Write("Creating the Sender and Receivers... ");
            var result1 = await CreateSenderAndReceiver();
            if(result1 != null)
            {
                //If this test fail, the next one is going to fail too.
                Console.Error.Write("FAILED\n");
                Console.Error.WriteLine(result1);
                Console.Error.WriteLine("Cannot send or receive events.");
                return false;
            }
            else
            {
                Console.Write("Done\n");
            }

            var result2 = await SendAndReceiveEvents();
            if(result2 != null)
            {
                Console.Error.Write("FAILED\n");
                Console.Error.WriteLine(result2);
                return false;
            }
            else
            {
                Console.WriteLine("Success.");
            }

            return true;
        }

        private async Task<Exception> CreateSenderAndReceiver()
        {
            try
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
            catch (Exception ex)
            {
                return ex;
            }

            return null;
        }

        private async Task<Exception> SendAndReceiveEvents()
        {
            try
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

                //Why?
                var index = 0;

                Console.Write("Receiving events... ");
                while ((receivedEvents.Count < eventBatch.Length) && (++index < 3))
                {
                    receivedEvents.AddRange(await receiver.ReceiveAsync(eventBatch.Length + 10, TimeSpan.FromMilliseconds(25)));
                }
                index = 0;

                //Check if at least one event was received
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

                //Check if the number of events received match the number of events sent
                if (index < eventBatch.Count())
                {
                    throw new Exception(String.Format("Error, expecting " + eventBatch.Count().ToString() + " events, but only got " + index.ToString() + "."));
                }
            }
            catch (Exception ex)
            {
                return ex;
            }
            
            return null;
        }

    }
}
