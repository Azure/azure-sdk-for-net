using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
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
                var lastResults = new Dictionary<string, int>();
                var lastElapsedSeconds = (double) 0;
                var lastTotalEvents = 0;

                while (true)
                {
                    var elapsedSeconds = sw.Elapsed.TotalSeconds;
                    var recentElapsedSeconds = elapsedSeconds - lastElapsedSeconds;
                    var totalEvents = 0;

                    foreach (var kvp in _eventsProcessed.OrderBy(kvp => int.Parse(kvp.Key)))
                    {
                        if (!lastResults.TryGetValue(kvp.Key, out var lastEvents))
                        {
                            lastEvents = 0;
                            lastResults[kvp.Key] = lastEvents;
                        }

                        var events = kvp.Value.Value;
                        totalEvents += events;

                        var recentEvents = events - lastEvents;

                        var eventsPerSecond = kvp.Value.Value / elapsedSeconds;
                        var recentEventsPerSecond = recentEvents / recentElapsedSeconds;

                        Console.WriteLine($"[{kvp.Key}] Recent: {recentEvents} ({recentEventsPerSecond:N2} events/sec), " +
                            $"Total: {events} ({eventsPerSecond:N2} events/sec)");

                        lastResults[kvp.Key] = events;
                    }

                    var recentTotalEvents = totalEvents - lastTotalEvents;

                    var recentTotalEventsPerSecond = recentTotalEvents / recentElapsedSeconds;
                    var totalEventsPerSecond = totalEvents / elapsedSeconds;

                    Console.WriteLine($"Recent: {recentTotalEvents} ({recentTotalEventsPerSecond:N2} events/sec), " +
                        $"Total: {totalEvents} ({totalEventsPerSecond:N2} events/sec)");
                    Console.WriteLine();

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
