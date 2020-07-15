// ------------------------------------
// Copyright(c) Microsoft Corporation.
// Licensed under the MIT License.
// ------------------------------------
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Producer;
using Azure.Storage.Blobs;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmokeTest
{
    class EventHubsTest
    {
        private const int ReadTimeoutInSeconds = 60;

        private static EventHubProducerClient sender;
        private static EventProcessorClient processor;
        private static BlobContainerClient storageClient;

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
            Console.WriteLine("2.- Receive those events\n");

            var connectionString = Environment.GetEnvironmentVariable("EVENT_HUBS_CONNECTION_STRING");
            var storageConnectionString = Environment.GetEnvironmentVariable("BLOB_CONNECTION_STRING");

            try
            {
                CreateSenderAndReceiver(connectionString, storageConnectionString);
                await SendAndReceiveEvents();
            }
            finally
            {
                await Cleanup();
            }
        }

        public static Task Cleanup() => sender.CloseAsync();

        private static void CreateSenderAndReceiver(string connectionString, string storageConnectionString)
        {
            Console.Write("Creating the Sender and Receivers... ");

            sender = new EventHubProducerClient(connectionString);
            storageClient = new BlobContainerClient(storageConnectionString, "mycontainer");
            processor = new EventProcessorClient(storageClient, EventHubConsumerClient.DefaultConsumerGroupName, connectionString);
            Console.WriteLine("\tdone");
        }

        private static async Task SendAndReceiveEvents()
        {
            var partitionId = (await sender.GetPartitionIdsAsync()).First();

            var events = new[]
            {
                new EventData(Encoding.UTF8.GetBytes(".NET event 1")),
                new EventData(Encoding.UTF8.GetBytes(".NET event 2")),
                new EventData(Encoding.UTF8.GetBytes(".NET event 3"))
            };

            var eventBatch = await sender.CreateBatchAsync();

            foreach (var ev in events)
            {
                eventBatch.TryAdd(ev);
            }

            Console.Write("Ready to send a batch of " + eventBatch.Count.ToString() + " events... ");
            await sender.SendAsync(eventBatch);
            Console.Write("Sent\n");

            Console.WriteLine("Receiving events... ");
            var receivedEventCount = 0;
            var readCancellationSource = new CancellationTokenSource();
            readCancellationSource.CancelAfter(TimeSpan.FromSeconds(ReadTimeoutInSeconds));

            Task processEvent(ProcessEventArgs eventArgs)
            {
                // Only display the first few events received to prevent
                // filling the console with redundant messages
                if (++receivedEventCount <= eventBatch.Count)
                {
                    var bodyReader = new StreamReader(eventArgs.Data.BodyAsStream);
                    var bodyContents = bodyReader.ReadToEnd();
                    Console.WriteLine("Recieved Event: {0}", bodyContents);
                }

                return Task.CompletedTask;
            }

            Task processError(ProcessErrorEventArgs eventArgs)
            {
                if (eventArgs.CancellationToken.IsCancellationRequested)
                {
                    return Task.CompletedTask;
                }

                Console.WriteLine("Error has occurred: {0}", eventArgs.Exception.ToString());
                readCancellationSource.Cancel();
                throw new Exception("Error while processing events", eventArgs.Exception);
            }

            processor.ProcessEventAsync += processEvent;
            processor.ProcessErrorAsync += processError;


            try
            {
                await processor.StartProcessingAsync();

                while ((!readCancellationSource.IsCancellationRequested) && (receivedEventCount <= eventBatch.Count))
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(250));
                }

                await processor.StopProcessingAsync();
            }
            finally
            {
                processor.ProcessEventAsync -= processEvent;
                processor.ProcessErrorAsync -= processError;
            }
        }
    }
}