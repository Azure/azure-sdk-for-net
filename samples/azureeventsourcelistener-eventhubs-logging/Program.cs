using Azure.Core.Diagnostics;
using System;
using System.Diagnostics.Tracing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs;

namespace AzureEventSourceListenerEventHubsLogging
{

    public static class Program
    {
        
        public static async Task<int> Main(string[] args)
        {
            var connectionString = default(string);
            var eventHubName = default(string);

            while (string.IsNullOrEmpty(connectionString))
            {
                Console.Write("Please provide the connection string for the Event Hubs that you'd like to use and then press Enter: ");
                connectionString = Console.ReadLine().Trim();
                Console.WriteLine();
            }

            while (string.IsNullOrEmpty(eventHubName))
            {
                Console.Write("Please provide the Event Hub Name that you'd like to use and then press Enter: ");
                eventHubName = Console.ReadLine().Trim();
                Console.WriteLine();
            }



            // Create AzureEventSource Listener that listens to events produces by Azure SDK Client libraries.
            var listener = new AzureEventSourceListener((args, message) =>
            {
                
                if (args.EventSource.Name.StartsWith("Azure-Messaging-EventHubs"))
                {
                    Console.WriteLine("---------");
                    Console.WriteLine("Event Name : " +args.EventName);
                    Console.WriteLine("Event Message Description : " +message);
                    Console.WriteLine("---------");
                }

             
            }, EventLevel.Informational);

            // Create a producer client that you can use to send some sample events to an event hub
            await using (var producerClient = new EventHubProducerClient(connectionString, eventHubName))
            {
                Console.WriteLine("Preparing event batch...");
                using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();
                
                // Add events to the batch. An event is a represented by a collection of bytes and metadata. 
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Hello, Event Hubs!")));
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("The middle event is this one")));
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Goodbye, Event Hubs!")));

                await producerClient.SendAsync(eventBatch);

                Console.WriteLine("The event batch has been published.");
            }


       

            return 0;
        }
    }
}
