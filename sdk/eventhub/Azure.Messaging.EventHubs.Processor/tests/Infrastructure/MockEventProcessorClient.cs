// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Moq;
using static Azure.Messaging.EventHubs.Processor.Tests.EventProcessorClientTests;

namespace Azure.Messaging.EventHubs.Processor.Tests
{
    /// <summary>
    ///   Allows the load balance update and ownership expiration time spans to be overridden
    ///   for testing purposes.
    /// </summary>
    ///
    public class MockEventProcessorClient : EventProcessorClient
    {
        /// <summary>A value used to override event processors' load balance update time span.</summary>
        public static readonly TimeSpan ShortLoadBalanceUpdate = TimeSpan.FromMilliseconds(100);

        /// <summary>A value used to override event processors' ownership expiration time span.</summary>
        public static readonly TimeSpan ShortOwnershipExpiration = TimeSpan.FromSeconds(3);
        private readonly bool fakeRunPartitionProcessingAsync;

        /// <summary>A dictionary used to track calls to InitializeProcessingForPartitionAsync.</summary>
        public ConcurrentDictionary<string, int> initializeCalls = new ConcurrentDictionary<string, int>();

        /// <summary>A dictionary used to track calls to ProcessEventAsync.</summary>
        public ConcurrentDictionary<string, EventData[]> processEventCalls = new ConcurrentDictionary<string, EventData[]>();

        /// <summary>A dictionary used to track calls to ProcessingForPartitionStoppedAsync.</summary>
        public ConcurrentDictionary<string, int> closeCalls = new ConcurrentDictionary<string, int>();

        /// <summary>A dictionary used to track ProcessingStoppedReasons for calls to ProcessingForPartitionStoppedAsync.</summary>
        public ConcurrentDictionary<string, ProcessingStoppedReason> stopReasons = new ConcurrentDictionary<string, ProcessingStoppedReason>();

        /// <summary>A dictionary used to track calls to ProcessExceptionAsync.</summary>
        public ConcurrentDictionary<string, Exception[]> exceptionCalls = new ConcurrentDictionary<string, Exception[]>();

        internal readonly Dictionary<string, ConcurrentQueue<EventData>> eventPipeline = new Dictionary<string, ConcurrentQueue<EventData>>();

        /// <summary>
        ///   The minimum amount of time to be elapsed between two load balancing verifications.
        /// </summary>
        ///
        internal override TimeSpan LoadBalanceUpdate => ShortLoadBalanceUpdate;

        /// <summary>
        ///   The minimum amount of time for an ownership to be considered expired without further updates.
        /// </summary>
        ///
        internal override TimeSpan OwnershipExpiration => ShortOwnershipExpiration;

        /// <summary>
        ///   Initializes a new instance of the <see cref="ShortWaitTimeMock"/> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">The client responsible for interaction with durable storage, responsible for persisting checkpoints and load-balancing state.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="connectionFactory">A factory used to provide new <see cref="EventHubConnection" /> instances.</param>
        /// <param name="clientOptions">The set of options to use for this processor.</param>
        ///
        internal MockEventProcessorClient(BlobContainerClient checkpointStore,
                                        string consumerGroup = "consumerGroup",
                                        string fullyQualifiedNamespace = "somehost.com",
                                        string eventHubName = "somehub",
                                        Func<EventHubConnection> connectionFactory = default,
                                        EventProcessorClientOptions options = default,
                                        bool fakePartitionPRocessing = true,
                                        int numberOfPartitions = 3) : base(checkpointStore, consumerGroup, fullyQualifiedNamespace, eventHubName, connectionFactory, options)
        {
            var partitionIds = Enumerable
                    .Range(1, numberOfPartitions)
                    .Select(p => p.ToString())
                    .ToArray();

            foreach (var partitionId in partitionIds)
            {
                eventPipeline[partitionId] = new ConcurrentQueue<EventData>();
            }

            this.fakeRunPartitionProcessingAsync = fakePartitionPRocessing;
            ProcessErrorAsync += async errorContext =>
            {
                Exception[] newException = new Exception[] { errorContext.Exception };
                exceptionCalls.AddOrUpdate(
                    errorContext.PartitionId,
                    newException,
                    (partitionId, value) => value.Concat(newException).ToArray());
                await Task.Delay(1);
            };

            ProcessEventAsync += async processorEvent =>
            {
                EventData[] newEvent = new EventData[] { processorEvent.Data };
                processEventCalls.AddOrUpdate(
                    processorEvent.Partition.PartitionId,
                    newEvent,
                    (partitionId, value) => value.Concat(newEvent).ToArray());

                await Task.Delay(1);
            };

            PartitionInitializingAsync += async initializationContext =>
            {
                initializeCalls.AddOrUpdate(initializationContext.PartitionId, 1, (partitionId, value) => value + 1);
                await Task.Delay(1);
            };

            PartitionClosingAsync += async stopContext =>
            {
                closeCalls.AddOrUpdate(stopContext.PartitionId, 1, (partitionId, value) => value + 1);
                stopReasons[stopContext.PartitionId] = stopContext.Reason;
                await Task.Delay(1);
            };

        }

        internal override EventHubConsumerClient CreateConsumer(string consumerGroup, EventHubConnection connection, EventHubConsumerClientOptions options)
        {
            var mockConsumer = new Mock<EventHubConsumerClient>();
            mockConsumer
                .Setup(m => m.ReadEventsFromPartitionAsync(It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<ReadEventOptions>(), It.IsAny<CancellationToken>()))
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((paritionId, EventPosition, options, token) =>
                {
                    return CreateAsyncEnumerable(paritionId);
                });

            mockConsumer
                .Setup(m => m.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(eventPipeline.Keys.ToArray()));
            return mockConsumer.Object;
        }

        private async IAsyncEnumerable<PartitionEvent> CreateAsyncEnumerable(string partitionId)
        {
            if (eventPipeline.TryGetValue(partitionId, out var eventQueue))
            {
                while (eventQueue.TryDequeue(out var eventData))
                {
                    await Task.Delay(0);
                    yield return new PartitionEvent(Mock.Of<PartitionContext>(), eventData);
                }
            }
            else
            {
                yield break;
            }
        }

        internal override Task RunPartitionProcessingAsync(string partitionId, EventPosition startingPosition, CancellationToken cancellationToken)
        {
            if (fakeRunPartitionProcessingAsync)
            {
                // return a task that will only reasonably return when cancelled
                return Task.Delay(TimeSpan.FromMinutes(1), cancellationToken);
            }
            else
            {
                return base.RunPartitionProcessingAsync(partitionId, startingPosition, cancellationToken);
            }
        }

        /// <summary>
        ///   Waits until the partition load distribution is stabilized.  Throws an <see cref="OperationCanceledException"/>
        ///   if the load takes too long to stabilize.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public async Task WaitStabilization()
        {
            var stabilizedStatusAchieved = false;
            var consecutiveStabilizedStatus = 0;
            List<PartitionOwnership> previousActiveOwnership = null;

            CancellationToken timeoutToken = (new CancellationTokenSource(TimeSpan.FromSeconds(5))).Token;

            while (!stabilizedStatusAchieved)
            {
                // Remember to filter expired ownership.

                var activeOwnership = (await StorageManager.Value
                    .ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup)
                    .ConfigureAwait(false))
                    .Where(ownership => DateTimeOffset.UtcNow.Subtract(ownership.LastModifiedTime.Value) < ShortOwnershipExpiration)
                    .ToList();

                // Increment stabilized status count if current partition distribution matches the previous one.  Reset it
                // otherwise.

                if (EventProcessorManager.AreOwnershipDistributionsTheSame(previousActiveOwnership, activeOwnership))
                {
                    ++consecutiveStabilizedStatus;
                }
                else
                {
                    consecutiveStabilizedStatus = 1;
                }

                previousActiveOwnership = activeOwnership;

                if (consecutiveStabilizedStatus < 10)
                {
                    // Wait a load balance update cycle before the next verification.  Give up if the whole process takes more than 1 minute.

                    await Task.Delay(ShortLoadBalanceUpdate, timeoutToken);
                }
                else
                {
                    // We'll consider the load stabilized only if its status doesn't change after 10 verifications.

                    stabilizedStatusAchieved = true;
                }
            }
        }

        internal IEnumerable<PartitionOwnership> CreatePartitionOwnerships(IEnumerable<string> partitionIds, string identifier)
            {
                return partitionIds
                    .Select(partitionId =>
                        new PartitionOwnership
                            (
                                this.FullyQualifiedNamespace,
                                this.EventHubName,
                                this.ConsumerGroup,
                                identifier,
                                partitionId,
                                DateTimeOffset.UtcNow,
                                Guid.NewGuid().ToString()
                            )).ToList();
            }
    }
}
