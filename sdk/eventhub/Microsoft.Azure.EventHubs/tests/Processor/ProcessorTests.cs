// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Processor
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.EventHubs.Primitives;
    using Microsoft.Azure.EventHubs.Processor;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Microsoft.Azure.Storage;
    using Xunit;

    public class ProcessorTests : ProcessorTestBase
    {
        /// <summary>
        /// Validating cases where entity path is provided through eventHubPath and EH connection string parameters
        /// on the EPH constructor.
        /// </summary>
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public void ProcessorHostEntityPathSetting()
        {
            var connectionString = TestUtility.BuildEventHubsConnectionString("dimmyeventhubname");
            var csb = new EventHubsConnectionStringBuilder(connectionString)
            {
                EntityPath = "myeh"
            };

            // Entity path provided in the connection string.
            TestUtility.Log("Testing condition: Entity path provided in the connection string only.");
            var eventProcessorHost = new EventProcessorHost(
                null,
                PartitionReceiver.DefaultConsumerGroupName,
                csb.ToString(),
                TestUtility.StorageConnectionString,
                "dimmyeventhubname".ToLower());
            Assert.Equal("myeh", eventProcessorHost.EventHubPath);

            // Entity path provided in the eventHubPath parameter.
            TestUtility.Log("Testing condition: Entity path provided in the eventHubPath only.");
            csb.EntityPath = null;
            eventProcessorHost = new EventProcessorHost(
                "myeh2",
                PartitionReceiver.DefaultConsumerGroupName,
                csb.ToString(),
                TestUtility.StorageConnectionString,
                "dimmyeventhubname".ToLower());
            Assert.Equal("myeh2", eventProcessorHost.EventHubPath);

            // The same entity path provided in both eventHubPath parameter and the connection string.
            TestUtility.Log("Testing condition: The same entity path provided in the eventHubPath and connection string.");
            csb.EntityPath = "mYeH";
            eventProcessorHost = new EventProcessorHost(
                "myeh",
                PartitionReceiver.DefaultConsumerGroupName,
                csb.ToString(),
                TestUtility.StorageConnectionString,
                "dimmyeventhubname".ToLower());
            Assert.Equal("myeh", eventProcessorHost.EventHubPath);

            // Entity path not provided in both eventHubPath and the connection string.
            TestUtility.Log("Testing condition: Entity path not provided in both eventHubPath and connection string.");
            try
            {
                csb.EntityPath = null;
                new EventProcessorHost(
                    string.Empty,
                    PartitionReceiver.DefaultConsumerGroupName,
                    csb.ToString(),
                    TestUtility.StorageConnectionString,
                    "dimmyeventhubname".ToLower());
                throw new Exception("Entity path wasn't provided and this new call was supposed to fail");
            }
            catch (ArgumentException)
            {
                TestUtility.Log("Caught ArgumentException as expected.");
            }

            // Entity path conflict.
            TestUtility.Log("Testing condition: Entity path conflict.");
            try
            {
                csb.EntityPath = "myeh";
                new EventProcessorHost(
                    "myeh2",
                    PartitionReceiver.DefaultConsumerGroupName,
                    csb.ToString(),
                    TestUtility.StorageConnectionString,
                    "dimmyeventhubname".ToLower());
                throw new Exception("Entity path values conflict and this new call was supposed to fail");
            }
            catch (ArgumentException)
            {
                TestUtility.Log("Caught ArgumentException as expected.");
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task SingleProcessorHost()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var eventProcessorHost = new EventProcessorHost(
                    null, // Entity path will be picked from connection string.
                    PartitionReceiver.DefaultConsumerGroupName,
                    connectionString,
                    TestUtility.StorageConnectionString,
                    Guid.NewGuid().ToString());

                var epo = await GetOptionsAsync(connectionString);
                await RunGenericScenario(eventProcessorHost, epo);
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task MultipleProcessorHosts()
        {
            await using (var scope = await EventHubScope.CreateAsync(3))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                string[] PartitionIds = GetPartitionIds(connectionString);
                int hostCount = 3;

                TestUtility.Log($"Testing with {hostCount} EventProcessorHost instances");

                // Prepare partition trackers.
                var partitionReceiveEvents = new ConcurrentDictionary<string, AsyncAutoResetEvent>();
                foreach (var partitionId in PartitionIds)
                {
                    partitionReceiveEvents[partitionId] = new AsyncAutoResetEvent(false);
                }

                // Prepare host trackers.
                var hostReceiveEvents = new ConcurrentDictionary<string, AsyncAutoResetEvent>();

                var containerName = Guid.NewGuid().ToString();
                var hosts = new List<EventProcessorHost>();

                try
                {
                    for (int hostId = 0; hostId < hostCount; hostId++)
                    {
                        var thisHostName = $"host-{hostId}";
                        hostReceiveEvents[thisHostName] = new AsyncAutoResetEvent(false);

                        TestUtility.Log("Creating EventProcessorHost");
                        var eventProcessorHost = new EventProcessorHost(
                            thisHostName,
                            string.Empty, // Passing empty as entity path here since path is already in EH connection string.
                            PartitionReceiver.DefaultConsumerGroupName,
                            connectionString,
                            TestUtility.StorageConnectionString,
                            containerName);
                        hosts.Add(eventProcessorHost);
                        TestUtility.Log($"Calling RegisterEventProcessorAsync");
                        var processorOptions = new EventProcessorOptions
                        {
                            ReceiveTimeout = TimeSpan.FromSeconds(10),
                            InvokeProcessorAfterReceiveTimeout = true,
                            MaxBatchSize = 100,
                            InitialOffsetProvider = pId => EventPosition.FromEnqueuedTime(DateTime.UtcNow.Subtract(TimeSpan.FromSeconds(60)))
                        };

                        var processorFactory = new TestEventProcessorFactory();
                        processorFactory.OnCreateProcessor += (f, createArgs) =>
                        {
                            var processor = createArgs.Item2;
                            string partitionId = createArgs.Item1.PartitionId;
                            string hostName = createArgs.Item1.Owner;
                            processor.OnOpen += (_, partitionContext) => TestUtility.Log($"{hostName} > Partition {partitionId} TestEventProcessor opened");
                            processor.OnClose += (_, closeArgs) => TestUtility.Log($"{hostName} > Partition {partitionId} TestEventProcessor closing: {closeArgs.Item2}");
                            processor.OnProcessError += (_, errorArgs) => TestUtility.Log($"{hostName} > Partition {partitionId} TestEventProcessor process error {errorArgs.Item2.Message}");
                            processor.OnProcessEvents += (_, eventsArgs) =>
                            {
                                int eventCount = eventsArgs.Item2.events != null ? eventsArgs.Item2.events.Count() : 0;
                                if (eventCount > 0)
                                {
                                    TestUtility.Log($"{hostName} > Partition {partitionId} TestEventProcessor processing {eventCount} event(s)");
                                    partitionReceiveEvents[partitionId].Set();
                                    hostReceiveEvents[hostName].Set();
                                }
                            };
                        };

                        await eventProcessorHost.RegisterEventProcessorFactoryAsync(processorFactory, processorOptions);
                    }

                    // Allow some time for each host to own at least 1 partition.
                    // Partition stealing logic balances partition ownership one at a time.
                    TestUtility.Log("Waiting for partition ownership to settle...");
                    await Task.Delay(TimeSpan.FromSeconds(60));

                    TestUtility.Log("Sending an event to each partition");
                    var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                    var sendTasks = new List<Task>();
                    foreach (var partitionId in PartitionIds)
                    {
                        sendTasks.Add(TestUtility.SendToPartitionAsync(ehClient, partitionId, $"{partitionId} event."));
                    }
                    await Task.WhenAll(sendTasks);

                    TestUtility.Log("Verifying an event was received by each partition");
                    foreach (var e in partitionReceiveEvents)
                    {
                        bool ret = await e.Value.WaitAsync(TimeSpan.FromSeconds(30));
                        Assert.True(ret, $"Partition {e.Key} didn't receive any message!");
                    }

                    TestUtility.Log("Verifying at least an event was received by each host");
                    foreach (var e in hostReceiveEvents)
                    {
                        bool ret = await e.Value.WaitAsync(TimeSpan.FromSeconds(30));
                        Assert.True(ret, $"Host {e.Key} didn't receive any message!");
                    }
                }
                finally
                {
                    var shutdownTasks = new List<Task>();
                    foreach (var host in hosts)
                    {
                        TestUtility.Log($"Host {host} Calling UnregisterEventProcessorAsync.");
                        shutdownTasks.Add(host.UnregisterEventProcessorAsync());
                    }

                    await Task.WhenAll(shutdownTasks);
                }
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task WithBlobPrefix()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                string leaseContainerName = Guid.NewGuid().ToString();
                var epo = await GetOptionsAsync(connectionString);

                // Consume all messages with first host.
                // Create host with 'firsthost' prefix.
                var eventProcessorHostFirst = new EventProcessorHost(
                    "host1",
                    string.Empty,
                    PartitionReceiver.DefaultConsumerGroupName,
                    connectionString,
                    TestUtility.StorageConnectionString,
                    leaseContainerName,
                    "firsthost");
                var runResult1 = await RunGenericScenario(eventProcessorHostFirst, epo);

                // Consume all messages with second host.
                // Create host with 'secondhost' prefix.
                // Although on the same lease container, this second host should receive exactly the same set of messages
                // as the first host.
                var eventProcessorHostSecond = new EventProcessorHost(
                    "host2",
                    string.Empty,
                    PartitionReceiver.DefaultConsumerGroupName,
                    connectionString,
                    TestUtility.StorageConnectionString,
                    leaseContainerName,
                    "secondhost");
                var runResult2 = await RunGenericScenario(eventProcessorHostSecond, epo, numberOfEventsToSendPerPartition: 0);

                // Confirm that we are looking at 2 identical sets of messages in the end.
                foreach (var kvp in runResult1.ReceivedEvents)
                {
                    Assert.True(kvp.Value.Count() == runResult2.ReceivedEvents[kvp.Key].Count,
                        $"The sets of messages returned from first host and the second host are different for partition {kvp.Key}.");
                }
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task InvokeAfterReceiveTimeoutTrue()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                string[] PartitionIds = GetPartitionIds(connectionString);
                const int ReceiveTimeoutInSeconds = 10;

                TestUtility.Log("Testing EventProcessorHost with InvokeProcessorAfterReceiveTimeout=true");

                var emptyBatchReceiveEvents = new ConcurrentDictionary<string, AsyncAutoResetEvent>();
                foreach (var partitionId in PartitionIds)
                {
                    emptyBatchReceiveEvents[partitionId] = new AsyncAutoResetEvent(false);
                }

                var eventProcessorHost = new EventProcessorHost(
                    string.Empty,
                    PartitionReceiver.DefaultConsumerGroupName,
                    connectionString,
                    TestUtility.StorageConnectionString,
                    Guid.NewGuid().ToString());

                var processorOptions = new EventProcessorOptions
                {
                    ReceiveTimeout = TimeSpan.FromSeconds(ReceiveTimeoutInSeconds),
                    InvokeProcessorAfterReceiveTimeout = true,
                    InitialOffsetProvider = pId => EventPosition.FromEnd()
                };

                var processorFactory = new TestEventProcessorFactory();
                processorFactory.OnCreateProcessor += (f, createArgs) =>
                {
                    var processor = createArgs.Item2;
                    string partitionId = createArgs.Item1.PartitionId;
                    processor.OnOpen += (_, partitionContext) => TestUtility.Log($"Partition {partitionId} TestEventProcessor opened");
                    processor.OnProcessEvents += (_, eventsArgs) =>
                    {
                        int eventCount = eventsArgs.Item2.events != null ? eventsArgs.Item2.events.Count() : 0;
                        TestUtility.Log($"Partition {partitionId} TestEventProcessor processing {eventCount} event(s)");
                        if (eventCount == 0)
                        {
                            var emptyBatchReceiveEvent = emptyBatchReceiveEvents[partitionId];
                            emptyBatchReceiveEvent.Set();
                        }
                    };
                };

                await eventProcessorHost.RegisterEventProcessorFactoryAsync(processorFactory, processorOptions);
                try
                {
                    TestUtility.Log("Waiting for each partition to receive an empty batch of events...");
                    foreach (var partitionId in PartitionIds)
                    {
                        var emptyBatchReceiveEvent = emptyBatchReceiveEvents[partitionId];
                        bool emptyBatchReceived = await emptyBatchReceiveEvent.WaitAsync(TimeSpan.FromSeconds(ReceiveTimeoutInSeconds * 2));
                        Assert.True(emptyBatchReceived, $"Partition {partitionId} didn't receive an empty batch!");
                    }
                }
                finally
                {
                    TestUtility.Log("Calling UnregisterEventProcessorAsync");
                    await eventProcessorHost.UnregisterEventProcessorAsync();
                }
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task InvokeAfterReceiveTimeoutFalse()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                const int ReceiveTimeoutInSeconds = 10;

                TestUtility.Log("Calling RegisterEventProcessorAsync with InvokeProcessorAfterReceiveTimeout=false");

                var eventProcessorHost = new EventProcessorHost(
                    string.Empty,
                    PartitionReceiver.DefaultConsumerGroupName,
                    connectionString,
                    TestUtility.StorageConnectionString,
                    scope.EventHubName.ToLower());

                var processorOptions = new EventProcessorOptions
                {
                    ReceiveTimeout = TimeSpan.FromSeconds(ReceiveTimeoutInSeconds),
                    InvokeProcessorAfterReceiveTimeout = false,
                    MaxBatchSize = 100
                };

                var emptyBatchReceiveEvent = new AsyncAutoResetEvent(false);
                var processorFactory = new TestEventProcessorFactory();
                processorFactory.OnCreateProcessor += (f, createArgs) =>
                {
                    var processor = createArgs.Item2;
                    string partitionId = createArgs.Item1.PartitionId;
                    processor.OnProcessEvents += (_, eventsArgs) =>
                    {
                        int eventCount = eventsArgs.Item2.events != null ? eventsArgs.Item2.events.Count() : 0;
                        TestUtility.Log($"Partition {partitionId} TestEventProcessor processing {eventCount} event(s)");
                        if (eventCount == 0)
                        {
                            emptyBatchReceiveEvent.Set();
                        }
                    };
                };

                await eventProcessorHost.RegisterEventProcessorFactoryAsync(processorFactory, processorOptions);
                try
                {
                    TestUtility.Log("Verifying no empty batches arrive...");
                    bool waitSucceeded = await emptyBatchReceiveEvent.WaitAsync(TimeSpan.FromSeconds(ReceiveTimeoutInSeconds * 2));
                    Assert.False(waitSucceeded, "No empty batch should have been received!");
                }
                finally
                {
                    TestUtility.Log("Calling UnregisterEventProcessorAsync");
                    await eventProcessorHost.UnregisterEventProcessorAsync();
                }
            }
        }

        /// <summary>
        /// This test requires a eventhub with consumer groups $Default and cgroup1.
        /// </summary>
        /// <returns></returns>
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task NonDefaultConsumerGroup()
        {
            var consumerGroups = new[]
              {
                "notdefault"
              };
            await using (var scope = await EventHubScope.CreateAsync(2, consumerGroups))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var epo = await GetOptionsAsync(connectionString);
                var a = Guid.NewGuid().ToString();
                // Run on non-default consumer group
                var eventProcessorHost = new EventProcessorHost(
                    null, // Entity path will be picked from connection string.
                    scope.ConsumerGroups[0],
                    connectionString,
                    TestUtility.StorageConnectionString,
                    a);

                await RunGenericScenario(eventProcessorHost, epo);
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task InitialOffsetProviderWithDateTime()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                // Send and receive single message so we can find out enqueue date-time of the last message.
                var partitions = await DiscoverEndOfStream(connectionString);

                // We will use last enqueued message's enqueue date-time so EPH will pick messages only after that point.
                var lastEnqueueDateTime = partitions.Max(le => le.Value.Item2);
                TestUtility.Log($"Last message enqueued at {lastEnqueueDateTime}");

                // Use a randomly generated container name so that initial offset provider will be respected.
                var eventProcessorHost = new EventProcessorHost(
                    string.Empty,
                    PartitionReceiver.DefaultConsumerGroupName,
                    connectionString,
                    TestUtility.StorageConnectionString,
                    Guid.NewGuid().ToString());

                var processorOptions = new EventProcessorOptions
                {
                    ReceiveTimeout = TimeSpan.FromSeconds(10),
                    InitialOffsetProvider = partitionId => EventPosition.FromEnqueuedTime(lastEnqueueDateTime),
                    MaxBatchSize = 100
                };

                var runResult = await this.RunGenericScenario(eventProcessorHost, processorOptions);

                // We should have received only 1 event from each partition.
                Assert.False(runResult.ReceivedEvents.Any(kvp => kvp.Value.Count != 1), "One of the partitions didn't return exactly 1 event");
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task InitialOffsetProviderWithOffset()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                // Send and receive single message so we can find out offset of the last message.
                var partitions = await DiscoverEndOfStream(connectionString);
                TestUtility.Log("Discovered last event offsets on each partition as below:");
                foreach (var p in partitions)
                {
                    TestUtility.Log($"Partition {p.Key}: {p.Value.Item1}");
                }

                // Use a randomly generated container name so that initial offset provider will be respected.
                var eventProcessorHost = new EventProcessorHost(
                    string.Empty,
                    PartitionReceiver.DefaultConsumerGroupName,
                    connectionString,
                    TestUtility.StorageConnectionString,
                    Guid.NewGuid().ToString());

                var processorOptions = new EventProcessorOptions
                {
                    ReceiveTimeout = TimeSpan.FromSeconds(10),
                    InitialOffsetProvider = partitionId => EventPosition.FromOffset(partitions[partitionId].Item1),
                    MaxBatchSize = 100
                };

                var runResult = await this.RunGenericScenario(eventProcessorHost, processorOptions);

                // We should have received only 1 event from each partition.
                Assert.False(runResult.ReceivedEvents.Any(kvp => kvp.Value.Count != 1), "One of the partitions didn't return exactly 1 event");
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task InitialOffsetProviderWithEndOfStream()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                // Use a randomly generated container name so that initial offset provider will be respected.
                var eventProcessorHost = new EventProcessorHost(
                string.Empty,
                PartitionReceiver.DefaultConsumerGroupName,
                connectionString,
                TestUtility.StorageConnectionString,
                Guid.NewGuid().ToString());

                var processorOptions = new EventProcessorOptions
                {
                    ReceiveTimeout = TimeSpan.FromSeconds(10),
                    InitialOffsetProvider = partitionId => EventPosition.FromEnd(),
                    MaxBatchSize = 100
                };

                var runResult = await this.RunGenericScenario(eventProcessorHost, processorOptions);

                // We should have received only 1 event from each partition.
                Assert.False(runResult.ReceivedEvents.Any(kvp => kvp.Value.Count != 1), "One of the partitions didn't return exactly 1 event");
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task InitialOffsetProviderOverrideBehavior()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                // Generate a new lease container name that will be used through out the test.
                string leaseContainerName = Guid.NewGuid().ToString();
                TestUtility.Log($"Using lease container {leaseContainerName}");

                var epo = await GetOptionsAsync(connectionString);

                // First host will send and receive as usual.
                var eventProcessorHost = new EventProcessorHost(
                    string.Empty,
                    PartitionReceiver.DefaultConsumerGroupName,
                    connectionString,
                    TestUtility.StorageConnectionString,
                    leaseContainerName);
                await this.RunGenericScenario(eventProcessorHost, epo);

                // Second host will use an initial offset provider.
                // Since we are still on the same lease container, initial offset provider shouldn't rule.
                // We should continue receiving where we left instead if start-of-stream where initial offset provider dictates.
                eventProcessorHost = new EventProcessorHost(
                    string.Empty,
                    PartitionReceiver.DefaultConsumerGroupName,
                    connectionString,
                    TestUtility.StorageConnectionString,
                    leaseContainerName);
                var processorOptions = new EventProcessorOptions
                {
                    ReceiveTimeout = TimeSpan.FromSeconds(10),
                    InitialOffsetProvider = partitionId => EventPosition.FromStart(),
                    MaxBatchSize = 100
                };

                var runResult = await this.RunGenericScenario(eventProcessorHost, processorOptions, checkpointLastEvent: false);

                // We should have received only 1 event from each partition.
                Assert.False(runResult.ReceivedEvents.Any(kvp => kvp.Value.Count != 1), "One of the partitions didn't return exactly 1 event");
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task CheckpointEventDataShouldHold()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                // Generate a new lease container name that will use through out the test.
                string leaseContainerName = Guid.NewGuid().ToString();

                var epo = await GetOptionsAsync(connectionString);

                // Consume all messages with first host.
                var eventProcessorHostFirst = new EventProcessorHost(
                    string.Empty,
                    PartitionReceiver.DefaultConsumerGroupName,
                    connectionString,
                    TestUtility.StorageConnectionString,
                    leaseContainerName);
                await RunGenericScenario(eventProcessorHostFirst, epo);

                // For the second time we initiate a host and this time it should pick from where the previous host left.
                // In other words, it shouldn't start receiving from start of the stream.
                var eventProcessorHostSecond = new EventProcessorHost(
                    string.Empty,
                    PartitionReceiver.DefaultConsumerGroupName,
                    connectionString,
                    TestUtility.StorageConnectionString,
                    leaseContainerName);
                var runResult = await RunGenericScenario(eventProcessorHostSecond);

                // We should have received only 1 event from each partition.
                Assert.False(runResult.ReceivedEvents.Any(kvp => kvp.Value.Count != 1), "One of the partitions didn't return exactly 1 event");
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task CheckpointBatchShouldHold()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                // Generate a new lease container name that will use through out the test.
                string leaseContainerName = Guid.NewGuid().ToString();

                var epo = await GetOptionsAsync(connectionString);

                // Consume all messages with first host.
                var eventProcessorHostFirst = new EventProcessorHost(
                    string.Empty,
                    PartitionReceiver.DefaultConsumerGroupName,
                    connectionString,
                    TestUtility.StorageConnectionString,
                    leaseContainerName);
                await RunGenericScenario(eventProcessorHostFirst, epo, checkpointLastEvent: false, checkpointBatch: true);

                // For the second time we initiate a host and this time it should pick from where the previous host left.
                // In other words, it shouldn't start receiving from start of the stream.
                var eventProcessorHostSecond = new EventProcessorHost(
                    string.Empty,
                    PartitionReceiver.DefaultConsumerGroupName,
                    connectionString,
                    TestUtility.StorageConnectionString,
                    leaseContainerName);
                var runResult = await RunGenericScenario(eventProcessorHostSecond, epo);

                // We should have received only 1 event from each partition.
                Assert.False(runResult.ReceivedEvents.Any(kvp => kvp.Value.Count != 1), "One of the partitions didn't return exactly 1 event");
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task HostShouldRecoverAfterReceiverDisconnection()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                string[] PartitionIds = GetPartitionIds(connectionString);
                // We will target one partition and do validation on it.
                var targetPartition = PartitionIds.First();
                int targetPartitionOpens = 0;
                int targetPartitionCloses = 0;
                int targetPartitionErrors = 0;
                PartitionReceiver externalReceiver = null;

                var eventProcessorHost = new EventProcessorHost(
                    "ephhost",
                    string.Empty,
                    PartitionReceiver.DefaultConsumerGroupName,
                    connectionString,
                    TestUtility.StorageConnectionString,
                    Guid.NewGuid().ToString());

                try
                {
                    var processorFactory = new TestEventProcessorFactory();

                    processorFactory.OnCreateProcessor += (f, createArgs) =>
                    {
                        var processor = createArgs.Item2;
                        string partitionId = createArgs.Item1.PartitionId;
                        string hostName = createArgs.Item1.Owner;
                        processor.OnOpen += (_, partitionContext) =>
                            {
                                TestUtility.Log($"{hostName} > Partition {partitionId} TestEventProcessor opened");
                                if (partitionId == targetPartition)
                                {
                                    Interlocked.Increment(ref targetPartitionOpens);
                                }
                            };
                        processor.OnClose += (_, closeArgs) =>
                            {
                                TestUtility.Log($"{hostName} > Partition {partitionId} TestEventProcessor closing: {closeArgs.Item2}");
                                if (partitionId == targetPartition && closeArgs.Item2 == CloseReason.Shutdown)
                                {
                                    Interlocked.Increment(ref targetPartitionCloses);
                                }
                            };
                        processor.OnProcessError += (_, errorArgs) =>
                            {
                                TestUtility.Log($"{hostName} > Partition {partitionId} TestEventProcessor process error {errorArgs.Item2.Message}");
                                if (partitionId == targetPartition && errorArgs.Item2 is ReceiverDisconnectedException)
                                {
                                    Interlocked.Increment(ref targetPartitionErrors);
                                }
                            };
                    };

                    var epo = EventProcessorOptions.DefaultOptions;
                    epo.ReceiveTimeout = TimeSpan.FromSeconds(10);
                    await eventProcessorHost.RegisterEventProcessorFactoryAsync(processorFactory, epo);

                    // Wait 15 seconds then create a new epoch receiver.
                    // This will trigger ReceiverDisconnectedExcetion in the host.
                    await Task.Delay(15000);

                    TestUtility.Log("Creating a new receiver with epoch 2. This will trigger ReceiverDisconnectedException in the host.");
                    var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                    externalReceiver = ehClient.CreateEpochReceiver(PartitionReceiver.DefaultConsumerGroupName,
                        targetPartition, EventPosition.FromStart(), 2);
                    await externalReceiver.ReceiveAsync(100, TimeSpan.FromSeconds(5));

                    // Give another 1 minute for host to recover then do the validations.
                    await Task.Delay(60000);

                    TestUtility.Log("Verifying that host was able to receive ReceiverDisconnectedException");
                    Assert.True(targetPartitionErrors == 1, $"Host received {targetPartitionErrors} ReceiverDisconnectedExceptions!");

                    TestUtility.Log("Verifying that host was able to reopen the partition");
                    Assert.True(targetPartitionOpens == 2, $"Host opened target partition {targetPartitionOpens} times!");

                    TestUtility.Log("Verifying that host notified by close");
                    Assert.True(targetPartitionCloses == 1, $"Host closed target partition {targetPartitionCloses} times!");
                }
                finally
                {
                    TestUtility.Log("Calling UnregisterEventProcessorAsync");
                    await eventProcessorHost.UnregisterEventProcessorAsync();

                    if (externalReceiver != null)
                    {
                        await externalReceiver.CloseAsync();
                    }
                }
            }
        }

        /// <summary>
        /// If a host doesn't checkpoint on the processed events and shuts down, new host should start processing from the beginning.
        /// </summary>
        /// <returns></returns>
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task NoCheckpointThenNewHostReadsFromStart()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                // Generate a new lease container name that will be used through out the test.
                string leaseContainerName = Guid.NewGuid().ToString();

                var epo = await GetOptionsAsync(connectionString);

                // Consume all messages with first host.
                var eventProcessorHostFirst = new EventProcessorHost(
                    string.Empty,
                    PartitionReceiver.DefaultConsumerGroupName,
                    connectionString,
                    TestUtility.StorageConnectionString,
                    leaseContainerName);
                var runResult1 = await RunGenericScenario(eventProcessorHostFirst, epo, checkpointLastEvent: false);
                var totalEventsFromFirstHost = runResult1.ReceivedEvents.Sum(part => part.Value.Count);

                // Second time we initiate a host, it should receive exactly the same number of evets.
                var eventProcessorHostSecond = new EventProcessorHost(
                    string.Empty,
                    PartitionReceiver.DefaultConsumerGroupName,
                   connectionString,
                    TestUtility.StorageConnectionString,
                    leaseContainerName);
                var runResult2 = await RunGenericScenario(eventProcessorHostSecond, epo, 0);
                var totalEventsFromSecondHost = runResult2.ReceivedEvents.Sum(part => part.Value.Count);

                // Second host should have received the same number of events as the first host.
                Assert.True(totalEventsFromFirstHost == totalEventsFromSecondHost,
                    $"Second host received {totalEventsFromSecondHost} events where as first host receive {totalEventsFromFirstHost} events.");
            }
        }

        /// <summary>
        /// Checkpointing every message received should be Ok. No failures expected.
        /// </summary>
        /// <returns></returns>
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task CheckpointEveryMessageReceived()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var epo = await GetOptionsAsync(connectionString);

                var eventProcessorHost = new EventProcessorHost(
                    null, // Entity path will be picked from connection string.
                    PartitionReceiver.DefaultConsumerGroupName,
                    connectionString,
                    TestUtility.StorageConnectionString,
                    Guid.NewGuid().ToString());

                var runResult = await RunGenericScenario(eventProcessorHost, epo, numberOfEventsToSendPerPartition: 10,
                    checkpointLastEvent: false, checkpoingEveryEvent: true);

                // Validate there were not failures.
                Assert.True(runResult.NumberOfFailures == 0, $"RunResult returned with {runResult.NumberOfFailures} failures!");
            }
        }

        /// <summary>
        /// While processing events one event causes a failure. Host should be able to recover any error.
        /// </summary>
        /// <returns></returns>
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task HostShouldRecoverWhenProcessEventsAsyncThrows()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var client = EventHubClient.CreateFromConnectionString(connectionString);
                var eventHubInfo = client.GetRuntimeInformationAsync().WaitAndUnwrapException();
                string[] PartitionIds = eventHubInfo.PartitionIds;
                var lastReceivedAt = DateTime.Now;
                var lastReceivedAtLock = new object();
                var poisonMessageReceived = false;
                var poisonMessageProperty = "poison";
                var processorFactory = new TestEventProcessorFactory();
                var receivedEventCounts = new ConcurrentDictionary<string, int>();

                var eventProcessorHost = new EventProcessorHost(
                    null, // Entity path will be picked from connection string.
                    PartitionReceiver.DefaultConsumerGroupName,
                    connectionString,
                    TestUtility.StorageConnectionString,
                    Guid.NewGuid().ToString());

                processorFactory.OnCreateProcessor += (f, createArgs) =>
                {
                    var processor = createArgs.Item2;
                    string partitionId = createArgs.Item1.PartitionId;
                    string hostName = createArgs.Item1.Owner;
                    string consumerGroupName = createArgs.Item1.ConsumerGroupName;
                    processor.OnOpen += (_, partitionContext) => TestUtility.Log($"{hostName} > {consumerGroupName} > Partition {partitionId} TestEventProcessor opened");
                    processor.OnClose += (_, closeArgs) => TestUtility.Log($"{hostName} > {consumerGroupName} > Partition {partitionId} TestEventProcessor closing: {closeArgs.Item2}");
                    processor.OnProcessError += (_, errorArgs) =>
                    {
                        TestUtility.Log($"{hostName} > {consumerGroupName} > Partition {partitionId} TestEventProcessor process error {errorArgs.Item2.Message}");

                        // Throw once more here depending on where we are at exception sequence.
                        if (errorArgs.Item2.Message.Contains("ExceptionSequence1"))
                        {
                            throw new Exception("ExceptionSequence2");
                        }
                    };
                    processor.OnProcessEvents += (_, eventsArgs) =>
                    {
                        int eventCount = eventsArgs.Item2.events != null ? eventsArgs.Item2.events.Count() : 0;
                        TestUtility.Log($"{hostName} > {consumerGroupName} > Partition {partitionId} TestEventProcessor processing {eventCount} event(s)");
                        if (eventCount > 0)
                        {
                            lock (lastReceivedAtLock)
                            {
                                lastReceivedAt = DateTime.Now;
                            }

                            foreach (var e in eventsArgs.Item2.events)
                            {
                                // If this is poisoned event then throw.
                                if (!poisonMessageReceived && e.Properties.ContainsKey(poisonMessageProperty))
                                {
                                    poisonMessageReceived = true;
                                    TestUtility.Log($"Received poisoned message from partition {partitionId}");
                                    throw new Exception("ExceptionSequence1");
                                }

                                // Track received events so we can validate at the end.
                                if (!receivedEventCounts.ContainsKey(partitionId))
                                {
                                    receivedEventCounts[partitionId] = 0;
                                }

                                receivedEventCounts[partitionId]++;
                            }
                        }
                    };
                };

                try
                {
                    TestUtility.Log("Registering processorFactory...");
                    var epo = new EventProcessorOptions()
                    {
                        MaxBatchSize = 100,
                        InitialOffsetProvider = pId => EventPosition.FromEnqueuedTime(DateTime.UtcNow.Subtract(TimeSpan.FromSeconds(60)))
                    };
                    await eventProcessorHost.RegisterEventProcessorFactoryAsync(processorFactory, epo);

                    TestUtility.Log("Waiting for partition ownership to settle...");
                    await Task.Delay(TimeSpan.FromSeconds(5));



                    // Send first set of messages.
                    TestUtility.Log("Sending an event to each partition as the first set of messages.");
                    var sendTasks = new List<Task>();
                    foreach (var partitionId in PartitionIds)
                    {
                        sendTasks.Add(TestUtility.SendToPartitionAsync(client, partitionId, $"{partitionId} event."));
                    }
                    await Task.WhenAll(sendTasks);

                    // Now send 1 poisoned message. This will fail one of the partition pumps.
                    TestUtility.Log($"Sending a poison event to partition {PartitionIds.First()}");
                    var pSender = client.CreatePartitionSender(PartitionIds.First());
                    var ed = new EventData(Encoding.UTF8.GetBytes("This is poison message"));
                    ed.Properties[poisonMessageProperty] = true;
                    await pSender.SendAsync(ed);

                    // Wait sometime. The host should fail and then recever during this time.
                    await Task.Delay(30000);

                    // Send second set of messages.
                    TestUtility.Log("Sending an event to each partition as the second set of messages.");
                    sendTasks.Clear();
                    foreach (var partitionId in PartitionIds)
                    {
                        sendTasks.Add(TestUtility.SendToPartitionAsync(client, partitionId, $"{partitionId} event."));
                    }
                    await Task.WhenAll(sendTasks);

                    TestUtility.Log("Waiting until hosts are idle, i.e. no more messages to receive.");
                    while (lastReceivedAt > DateTime.Now.AddSeconds(-60))
                    {
                        await Task.Delay(1000);
                    }

                    TestUtility.Log("Verifying poison message was received");
                    Assert.True(poisonMessageReceived, "Didn't receive poison message!");

                    TestUtility.Log("Verifying received events by each partition");
                    foreach (var partitionId in PartitionIds)
                    {
                        if (!receivedEventCounts.ContainsKey(partitionId))
                        {
                            throw new Exception($"Partition {partitionId} didn't receive any messages!");
                        }

                        var receivedEventCount = receivedEventCounts[partitionId];
                        Assert.True(receivedEventCount >= 2, $"Partition {partitionId} received {receivedEventCount} where as at least 2 expected!");
                    }
                }
                finally
                {
                    TestUtility.Log("Calling UnregisterEventProcessorAsync.");
                    await eventProcessorHost.UnregisterEventProcessorAsync();
                }
            }
        }

        /// <summary>
        /// This test is for manual only purpose. Fill in the tenant-id, app-id and app-secret before running.
        /// </summary>
        [Fact(Skip = "Manual run only")]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task SingleProcessorHostWithAadTokenProvider()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var appAuthority = "";
                var aadAppId = "";
                var aadAppSecret = "";

                AzureActiveDirectoryTokenProvider.AuthenticationCallback authCallback =
                    async (audience, authority, state) =>
                    {
                        var authContext = new AuthenticationContext(authority);
                        var cc = new ClientCredential(aadAppId, aadAppSecret);
                        var authResult = await authContext.AcquireTokenAsync(audience, cc);
                        return authResult.AccessToken;
                    };

                var tokenProvider = TokenProvider.CreateAzureActiveDirectoryTokenProvider(authCallback, appAuthority);
                var epo = await GetOptionsAsync(connectionString);
                var csb = new EventHubsConnectionStringBuilder(connectionString);

                var eventProcessorHost = new EventProcessorHost(
                    csb.Endpoint,
                    csb.EntityPath,
                    PartitionReceiver.DefaultConsumerGroupName,
                    tokenProvider,
                    CloudStorageAccount.Parse(TestUtility.StorageConnectionString),
                    Guid.NewGuid().ToString());

                await RunGenericScenario(eventProcessorHost, epo);
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task ReRegister()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var eventProcessorHost = new EventProcessorHost(
                null, // Entity path will be picked from connection string.
                PartitionReceiver.DefaultConsumerGroupName,
                connectionString,
                TestUtility.StorageConnectionString,
                Guid.NewGuid().ToString());

                // Calling register for the first time should succeed.
                TestUtility.Log("Registering EventProcessorHost for the first time.");
                await eventProcessorHost.RegisterEventProcessorAsync<SecondTestEventProcessor>();

                // Unregister event processor should succed
                TestUtility.Log("Registering EventProcessorHost for the first time.");
                await eventProcessorHost.UnregisterEventProcessorAsync();

                var epo = await GetOptionsAsync(connectionString);

                // Run a generic scenario with TestEventProcessor instead
                await RunGenericScenario(eventProcessorHost, epo);
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task ReRegisterAfterLeaseExpiry()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var hostName = Guid.NewGuid().ToString();

                var processorOptions = new EventProcessorOptions
                {
                    ReceiveTimeout = TimeSpan.FromSeconds(10),
                    InitialOffsetProvider = pId => EventPosition.FromEnd()
                };

                var eventProcessorHost = new EventProcessorHost(
                    hostName,
                    null, // Entity path will be picked from connection string.
                    PartitionReceiver.DefaultConsumerGroupName,
                    connectionString,
                    TestUtility.StorageConnectionString,
                    Guid.NewGuid().ToString());

                var runResult = await RunGenericScenario(eventProcessorHost, processorOptions);
                Assert.False(runResult.ReceivedEvents.Any(kvp => kvp.Value.Count != 1), "First host: One of the partitions didn't return exactly 1 event");

                // Allow sometime so that leases can expire.
                await Task.Delay(60);

                runResult = await RunGenericScenario(eventProcessorHost);
                Assert.False(runResult.ReceivedEvents.Any(kvp => kvp.Value.Count != 1), "Second host: One of the partitions didn't return exactly 1 event");
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task LargeHostName()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var longHostname = StringUtility.GetRandomString(100);
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var eventProcessorHost = new EventProcessorHost(
                    longHostname,
                    null, // Entity path will be picked from connection string.
                    PartitionReceiver.DefaultConsumerGroupName,
                    connectionString,
                    TestUtility.StorageConnectionString,
                    Guid.NewGuid().ToString());

                var epo = await GetOptionsAsync(connectionString);
                await RunGenericScenario(eventProcessorHost, epo);
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task DontCheckpointStartOfStream()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);

                // Use a randomly generated container name so that initial offset provider will be respected.
                var eventProcessorHost = new EventProcessorHost(
                string.Empty,
                PartitionReceiver.DefaultConsumerGroupName,
                connectionString,
                TestUtility.StorageConnectionString,
                Guid.NewGuid().ToString());

                var processorOptions = new EventProcessorOptions
                {
                    ReceiveTimeout = TimeSpan.FromSeconds(10),
                    InitialOffsetProvider = partitionId => EventPosition.FromEnd(),
                    InvokeProcessorAfterReceiveTimeout = false
                };

                var processorFactory = new TestEventProcessorFactory();
                processorFactory.OnCreateProcessor += (f, createArgs) =>
                {
                    var processor = createArgs.Item2;
                    string partitionId = createArgs.Item1.PartitionId;
                    string hostName = createArgs.Item1.Owner;
                    processor.OnOpen += (_, partitionContext) => TestUtility.Log($"{hostName} > Partition {partitionId} TestEventProcessor opened");
                    processor.OnClose += (_, closeArgs) =>
                    {
                        TestUtility.Log($"{hostName} > Partition {partitionId} TestEventProcessor closing: {closeArgs.Item2}");

                        // Checkpoint at close.
                       closeArgs.Item1.CheckpointAsync().GetAwaiter().GetResult();
                    };

                    processor.OnProcessError += (_, errorArgs) => TestUtility.Log($"{hostName} > Partition {partitionId} TestEventProcessor process error {errorArgs.Item2.Message}");
                    processor.OnProcessEvents += (_, eventsArgs) =>
                    {
                        int eventCount = eventsArgs.Item2.events != null ? eventsArgs.Item2.events.Count() : 0;
                        if (eventCount > 0)
                        {
                            TestUtility.Log($"{hostName} > Partition {partitionId} TestEventProcessor processing {eventCount} event(s)");
                        }
                    };
                };

                await eventProcessorHost.RegisterEventProcessorFactoryAsync(processorFactory, processorOptions);

                // Wait 30 seconds and then unregister. Host will checkpoint on close w/o receiving any events.
                // This checkpoint attempt should be omitted.
                await Task.Delay(TimeSpan.FromSeconds(30));
                await eventProcessorHost.UnregisterEventProcessorAsync();

                // Now send a single message. This message won't be received by next host.
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                await ehClient.SendAsync(new EventData(Encoding.UTF8.GetBytes("Hello EventHub!")));
                await Task.Delay(TimeSpan.FromSeconds(10));

                var runResult = await RunGenericScenario(eventProcessorHost, processorOptions, numberOfEventsToSendPerPartition: 1);

                // Confirm that we received just 1 event.
                Assert.False(runResult.ReceivedEvents.Any(kvp => kvp.Value.Count != 1), "Didn't receive exactly 1 event.");
            }
        }
    }
}

