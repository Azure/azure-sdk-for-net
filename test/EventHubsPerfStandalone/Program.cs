using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Producer;
using Azure.Storage.Blobs;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace EventHubsPerfStandalone
{
    class Program
    {
        // Basic and Standard support a maximum of 32 partitions
        private const int MAX_PARTITIONS = 32;
        private static readonly int[] _eventsProcessed = new int[MAX_PARTITIONS];

        private static bool _delay;

        static async Task Main(string[] args)
        {
            if (args.Length >= 1 && args[0] == "--delay")
            {
                _delay = true;
            }

            var eventHubsConnectionString = Environment.GetEnvironmentVariable("EVENT_HUBS_CONNECTION_STRING");
            var eventHubName = Environment.GetEnvironmentVariable("EVENT_HUB_NAME");

            var storageConnectionString = Environment.GetEnvironmentVariable("STORAGE_CONNECTION_STRING");
            var storageContainerName = DateTime.Now.ToString("yyyy-MM-dd-HHmmss");

            var containerClient = new BlobContainerClient(storageConnectionString, storageContainerName);
            await containerClient.CreateIfNotExistsAsync();

            var processor = new EventProcessorClient(containerClient, EventHubConsumerClient.DefaultConsumerGroupName,
                eventHubsConnectionString, eventHubName, new EventProcessorClientOptions() {
                    LoadBalancingStrategy = LoadBalancingStrategy.Greedy
                });

            processor.ProcessEventAsync += ProcessEventAsync;
            processor.ProcessErrorAsync += ProcessErrorAsync;

            var sw = new Stopwatch();
            
            var printStatusThread = new Thread(() =>
            {
                Console.WriteLine("Elapsed\tCur\tCurRate\tTot\tTotRate");
                Console.WriteLine("-------\t---\t-------\t---\t-------");

                var lastElapsedSeconds = (double)0;
                var lastTotalEvents = 0;

                while (true)
                {
                    var elapsedSeconds = sw.Elapsed.TotalSeconds;
                    var currentElapsedSeconds = elapsedSeconds - lastElapsedSeconds;

                    var totalEvents = _eventsProcessed.Sum();
                    var currentTotalEvents = totalEvents - lastTotalEvents;

                    var currentTotalEventsPerSecond = currentTotalEvents / currentElapsedSeconds;
                    var totalEventsPerSecond = totalEvents / elapsedSeconds;

                    Console.WriteLine($"{elapsedSeconds:N1}\t{currentTotalEvents:N0}\t{currentTotalEventsPerSecond:N1}\t{totalEvents:N0}\t{totalEventsPerSecond:N1}");

                    lastElapsedSeconds = elapsedSeconds;
                    lastTotalEvents = totalEvents;

                    Thread.Sleep(1000);
                }
            });
            printStatusThread.Start();

            sw.Start();

            await processor.StartProcessingAsync();

            await Task.Delay(Timeout.Infinite);
        }

        private static async Task ProcessErrorAsync(ProcessErrorEventArgs arg)
        {
            Console.WriteLine($"[{arg.PartitionId}] {arg.Operation} {arg.Exception}");
            if (_delay)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

        private static async Task ProcessEventAsync(ProcessEventArgs arg)
        {
            // EventProcessorClient guarantees events within a partition are processed serially, so
            // Interlocked.Increment() should not be required.
            _eventsProcessed[int.Parse(arg.Partition.PartitionId)]++;

            if (_delay)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}
