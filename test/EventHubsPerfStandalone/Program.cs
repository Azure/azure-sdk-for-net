using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace EventHubsPerfStandalone
{
    class Program
    {
        private static readonly ConcurrentDictionary<string, StrongBox<int>> _eventsProcessed = new ConcurrentDictionary<string, StrongBox<int>>();

        static async Task Main(string[] args)
        {
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

            processor.PartitionInitializingAsync += PartitionInitializingAsync;
            processor.ProcessEventAsync += ProcessEventAsync;
            processor.ProcessErrorAsync += ProcessErrorAsync;

            var sw = new Stopwatch();

            var printStatusThread = new Thread(() =>
            {
                while (true)
                {
                    var elapsedSeconds = sw.Elapsed.TotalSeconds;
                    var totalEvents = 0;

                    foreach (var kvp in _eventsProcessed.OrderBy(kvp => int.Parse(kvp.Key)))
                    {
                        var events = kvp.Value.Value;
                        totalEvents += events;

                        var eventsPerSecond = kvp.Value.Value / elapsedSeconds;

                        Console.WriteLine($"{kvp.Key}: {events} ({eventsPerSecond:N2} events/sec)");
                    }

                    var totalEventsPerSecond = totalEvents / elapsedSeconds;

                    Console.WriteLine($"Total: {totalEvents} ({totalEventsPerSecond:N2} events/sec)");
                    Console.WriteLine();
                    Thread.Sleep(1000);
                }
            });
            printStatusThread.Start();

            sw.Start();

            await processor.StartProcessingAsync();

            await Task.Delay(Timeout.Infinite);
        }

        private static async Task PartitionInitializingAsync(PartitionInitializingEventArgs arg)
        {
            Console.WriteLine($"[{arg.PartitionId}] {arg.DefaultStartingPosition}");
            _eventsProcessed[arg.PartitionId] = new StrongBox<int>();
        }

        private static async Task ProcessErrorAsync(ProcessErrorEventArgs arg)
        {
            Console.WriteLine($"[{arg.PartitionId}] {arg.Operation} {arg.Exception}");
            await Task.Delay(TimeSpan.FromSeconds(1));
        }

        private static async Task ProcessEventAsync(ProcessEventArgs arg)
        {
            // Console.WriteLine($"[{arg.Partition.PartitionId}] {arg.Data}");
            Interlocked.Increment(ref _eventsProcessed[arg.Partition.PartitionId].Value);
            // await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }
}
