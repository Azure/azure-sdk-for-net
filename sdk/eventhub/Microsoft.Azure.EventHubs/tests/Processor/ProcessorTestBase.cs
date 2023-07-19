// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Processor
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.EventHubs.Primitives;
    using Microsoft.Azure.EventHubs.Processor;
    using Xunit;

    public class ProcessorTestBase
    {
        protected string[] GetPartitionIds(string connectionString)
        {
            var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
            var eventHubInfo = ehClient.GetRuntimeInformationAsync().WaitAndUnwrapException();
            return eventHubInfo.PartitionIds;
        }

        protected async Task<Dictionary<string, Tuple<string, DateTime>>> DiscoverEndOfStream(string connectionString)
        {
            string[] PartitionIds = GetPartitionIds(connectionString);
            var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
            var partitions = new Dictionary<string, Tuple<string, DateTime>>();

            foreach (var pid in PartitionIds)
            {
                var pInfo = await ehClient.GetPartitionRuntimeInformationAsync(pid);
                partitions.Add(pid, Tuple.Create(pInfo.LastEnqueuedOffset, pInfo.LastEnqueuedTimeUtc));
            }

            return partitions.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        protected async Task<GenericScenarioResult> RunGenericScenario(EventProcessorHost eventProcessorHost,
            EventProcessorOptions epo = null, int numberOfEventsToSendPerPartition = 1, bool checkpointLastEvent = true,
            bool checkpointBatch = false, bool checkpoingEveryEvent = false)
        {
            var runResult = new GenericScenarioResult();
            var lastReceivedAt = DateTime.Now;

            if (epo == null)
            {
                epo = new EventProcessorOptions
                {
                    ReceiveTimeout = TimeSpan.FromSeconds(10),
                    MaxBatchSize = 100
                };
            }

            epo.SetExceptionHandler(TestEventProcessorFactory.ErrorNotificationHandler);

            try
            {
                TestUtility.Log("Calling RegisterEventProcessorAsync");
                var processorFactory = new TestEventProcessorFactory();

                processorFactory.OnCreateProcessor += (f, createArgs) =>
                {
                    var processor = createArgs.Item2;
                    string partitionId = createArgs.Item1.PartitionId;
                    string hostName = createArgs.Item1.Owner;
                    processor.OnOpen += (_, partitionContext) => TestUtility.Log($"{hostName} > Partition {partitionId} TestEventProcessor opened");
                    processor.OnClose += (_, closeArgs) => TestUtility.Log($"{hostName} > Partition {partitionId} TestEventProcessor closing: {closeArgs.Item2}");
                    processor.OnProcessError += (_, errorArgs) =>
                        {
                            TestUtility.Log($"{hostName} > Partition {partitionId} TestEventProcessor process error {errorArgs.Item2.Message}");
                            Interlocked.Increment(ref runResult.NumberOfFailures);
                        };
                    processor.OnProcessEvents += (_, eventsArgs) =>
                    {
                        int eventCount = eventsArgs.Item2.events != null ? eventsArgs.Item2.events.Count() : 0;
                        TestUtility.Log($"{hostName} > Partition {partitionId} TestEventProcessor processing {eventCount} event(s)");
                        if (eventCount > 0)
                        {
                            lastReceivedAt = DateTime.Now;
                            runResult.AddEvents(partitionId, eventsArgs.Item2.events);

                            foreach (var e in eventsArgs.Item2.events)
                            {
                                // Checkpoint every event received?
                                if (checkpoingEveryEvent)
                                {
                                    eventsArgs.Item1.CheckpointAsync(e).Wait();
                                }
                            }
                        }

                        eventsArgs.Item2.checkPointLastEvent = checkpointLastEvent;
                        eventsArgs.Item2.checkPointBatch = checkpointBatch;
                    };
                };

                await eventProcessorHost.RegisterEventProcessorFactoryAsync(processorFactory, epo);

                // Wait 5 seconds to avoid races in scenarios like EndOfStream.
                await Task.Delay(5000);
                string[] PartitionIds = GetPartitionIds(TestUtility.BuildEventHubsConnectionString(eventProcessorHost.EventHubPath));
                if (numberOfEventsToSendPerPartition > 0)
                {
                    var ehClient = EventHubClient.CreateFromConnectionString(TestUtility.BuildEventHubsConnectionString(eventProcessorHost.EventHubPath));
                    TestUtility.Log($"Sending {numberOfEventsToSendPerPartition} event(s) to each partition");
                    var sendTasks = new List<Task>();
                    foreach (var partitionId in PartitionIds)
                    {
                        sendTasks.Add(TestUtility.SendToPartitionAsync(ehClient, partitionId, $"{partitionId} event.", numberOfEventsToSendPerPartition));
                    }
                    await Task.WhenAll(sendTasks);
                }

                // Wait until all partitions are silent, i.e. no more events to receive.
                while (lastReceivedAt > DateTime.Now.AddSeconds(-30))
                {
                    await Task.Delay(1000);
                }

                TestUtility.Log($"Verifying at least {numberOfEventsToSendPerPartition} event(s) was received by each partition");
                foreach (var partitionId in PartitionIds)
                {
                    Assert.True(runResult.ReceivedEvents.ContainsKey(partitionId),
                        $"Partition {partitionId} didn't receive any messages. Expected {numberOfEventsToSendPerPartition}, received 0.");
                    Assert.True(runResult.ReceivedEvents[partitionId].Count >= numberOfEventsToSendPerPartition,
                        $"Partition {partitionId} didn't receive expected number of messages. Expected {numberOfEventsToSendPerPartition}, received {runResult.ReceivedEvents[partitionId].Count}.");
                }

                TestUtility.Log("Success");
            }
            finally
            {
                TestUtility.Log("Calling UnregisterEventProcessorAsync");
                await eventProcessorHost.UnregisterEventProcessorAsync();
            }

            return runResult;
        }

        protected async Task<EventProcessorOptions> GetOptionsAsync(string connectionString)
        {
            var partitions = await DiscoverEndOfStream(connectionString);
            return new EventProcessorOptions
            {
                ReceiveTimeout = TimeSpan.FromSeconds(10),
                MaxBatchSize = 100,
                InitialOffsetProvider = pId => EventPosition.FromOffset(partitions[pId].Item1)
            };
        }
    }

    public class GenericScenarioResult
    {
        public ConcurrentDictionary<string, List<EventData>> ReceivedEvents = new ConcurrentDictionary<string, List<EventData>>();
        public int NumberOfFailures = 0;

        readonly object listLock = new object();

        public void AddEvents(string partitionId, IEnumerable<EventData> addEvents)
        {
            List<EventData> events;
            this.ReceivedEvents.TryGetValue(partitionId, out events);
            if (events == null)
            {
                events = new List<EventData>();
            }

            // Account the case where 2 hosts racing by working on the same partition.
            lock (listLock)
            {
                events.AddRange(addEvents);
            }

            this.ReceivedEvents[partitionId] = events;
        }
    }
}

