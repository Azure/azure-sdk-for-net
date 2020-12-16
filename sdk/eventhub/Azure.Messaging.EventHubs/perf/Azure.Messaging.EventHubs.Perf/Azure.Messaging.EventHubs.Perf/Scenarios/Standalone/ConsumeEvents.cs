//Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using CommandLine;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;

namespace Azure.Messafging.EventHub.Perf.Scenarios
{
    public class ConsumeEvents
    {
        private const string _eventHubName = "test";

        // Settings copied from https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-faq#how-much-does-a-single-capacity-unit-let-me-achieve
        private const int _messagesPerBatch = 100;
        private const int _bytesPerMessage = 1024;
        private static readonly byte[] _payload = new byte[_bytesPerMessage];

        public class Options
        {
            [Option('c', "clients", Default = 1)]
            public int Clients { get; set; }

            [Option('p', "partitions", Default = 1)]
            public int Partitions { get; set; }

            [Option('s', "send")]
            public int Send { get; set; }

            [Option('v', "verbose", Default = false)]
            public bool Verbose { get; set; }
        }

        public static async Task Execute(string[] args)
        {
            if (!GCSettings.IsServerGC)
            {
                throw new InvalidOperationException("Requires server GC");
            }

            var connectionString = Environment.GetEnvironmentVariable("EVENTHUBS_CONNECTION_STRING");

            await Parser.Default.ParseArguments<Options>(args).MapResult(
                async o => await Run(connectionString, o.Partitions, o.Clients, o.Verbose, o.Send),
                errors => Task.CompletedTask);
        }

        public static async Task Run(string connectionString, int partitions, int clients, bool verbose, int send)
        {
            if (send > 0)
            {
                await SendMessages(connectionString, send);
            }
            else
            {
                await ReceiveMessages(connectionString, partitions, clients, verbose);
            }
        }

        private static async Task ReceiveMessages(string connectionString, int numPartitions, int numClients, bool verbose)
        {
            Console.WriteLine($"Receiving messages from {numPartitions} partitions using {numClients} client instances");

            var clients = new EventHubConsumerClient[numClients];
            for (var i = 0; i < numClients; i++)
            {
                clients[i] = new EventHubConsumerClient(connectionString, _eventHubName);
            }

            try
            {
                var client = clients.First();
                var partitionIds = (await client.GetPartitionIdsAsync()).Take(numPartitions);
                var partitions = await Task.WhenAll(partitionIds.Select(id => client.GetPartitionPropertiesAsync(id)));

                var totalCount = (long)0;
                foreach (var partition in partitions)
                {
                    var begin = partition.BeginningSequenceNumber;
                    var end = partition.LastEnqueuedSequenceNumber;
                    var count = end - begin + 1;
                    totalCount += count;

                    if (verbose)
                    {
                        Console.WriteLine($"Partition: {partition.Id}, Begin: {begin}, End: {end}, Count: {count}");
                    }
                }
                if (verbose)
                {
                    Console.WriteLine($"Total Count: {totalCount}");
                }

                try
                {
                    var receiveTasks = new Task<(int messagesReceived, long lastSequenceNumber)>[numPartitions];
                    var sw = Stopwatch.StartNew();
                    for (var i = 0; i < numPartitions; i++)
                    {
                        receiveTasks[i] = ReceiveAllMessages(clients[i % numClients], partitions[i]);
                    }
                    var results = await Task.WhenAll(receiveTasks);
                    sw.Stop();

                    var elapsed = sw.Elapsed.TotalSeconds;
                    var messagesReceived = results.Select(r => r.messagesReceived).Sum();
                    var messagesPerSecond = messagesReceived / elapsed;
                    var megabytesPerSecond = (messagesPerSecond * _bytesPerMessage) / (1024 * 1024);

                    Console.WriteLine($"Received {messagesReceived} messages of size {_bytesPerMessage} in {elapsed:N2}s " +
                        $"({messagesPerSecond:N2} msg/s, {megabytesPerSecond:N2} MB/s)");
                }
                finally
                {
                    foreach (var consumer in clients)
                    {
                        await consumer.DisposeAsync();
                    }
                }
            }
            finally
            {
                foreach (var client in clients)
                {
                    await client.DisposeAsync();
                }
            }
        }

        private static async Task<(int messagesReceived, long lastSequenceNumber)> ReceiveAllMessages(EventHubConsumerClient consumer, PartitionProperties partition)
        {
            var messagesReceived = 0;
            var lastSequenceNumber = (long)-1;
            while (lastSequenceNumber < partition.LastEnqueuedSequenceNumber)
            {
                await foreach (PartitionEvent receivedEvent in consumer.ReadEventsFromPartitionAsync(partition.Id, EventPosition.Earliest))
                {
                    messagesReceived++;
                    lastSequenceNumber = receivedEvent.Data.SequenceNumber;
                }
            }

            return (messagesReceived, lastSequenceNumber);
        }

        private static async Task SendMessages(string connectionString, int messages)
        {
            await using (var client = new EventHubProducerClient(connectionString, _eventHubName))
            {
                for (var j = 0; j < (messages / _messagesPerBatch); j++)
                {
                    Console.WriteLine(j);

                    var eventBatch = new EventData[_messagesPerBatch];
                    for (var i = 0; i < _messagesPerBatch; i++)
                    {
                        eventBatch[i] = new EventData(_payload);
                    }

                    await client.SendAsync(eventBatch);
                }
               await client.DisposeAsync();
            }
        }
    }
}
