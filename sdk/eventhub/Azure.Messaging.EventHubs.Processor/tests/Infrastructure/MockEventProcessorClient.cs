// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using static Azure.Messaging.EventHubs.Tests.EventProcessorClientTests;

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

        /// <summary>Indicates that <see cref="RunPartitionProcessingAsync" /> should be mocked.</summary>
        private readonly bool FakeRunPartitionProcessingAsync;

        /// <summary>A dictionary used to track calls to <see cref="PartitionInitializingAsync" />.</summary>
        public ConcurrentDictionary<string, int> InitializeCalls = new ConcurrentDictionary<string, int>();

        /// <summary>A dictionary used to track calls to <see cref="ProcessEventAsync" />.</summary>
        public ConcurrentDictionary<string, EventData[]> ProcessEventCalls = new ConcurrentDictionary<string, EventData[]>();

        /// <summary>A dictionary used to track calls to <see cref="PartitionClosingAsync" />.</summary>
        public ConcurrentDictionary<string, int> CloseCalls = new ConcurrentDictionary<string, int>();

        /// <summary>A dictionary used to track ProcessingStoppedReasons for calls to <see cref="PartitionClosingAsync" />.</summary>
        public ConcurrentDictionary<string, ProcessingStoppedReason> StopReasons = new ConcurrentDictionary<string, ProcessingStoppedReason>();

        /// <summary>A dictionary used to track calls to <see cref="ProcessExceptionAsync" />.</summary>
        public ConcurrentDictionary<string, Exception[]> ExceptionCalls = new ConcurrentDictionary<string, Exception[]>();

        /// <summary>A dictionary used to store <see cref="EventData" /> to be received by the mock <see cref="EventHubConsumerClient" />.</summary>
        internal readonly Dictionary<string, ConcurrentQueue<EventData>> EventPipeline = new Dictionary<string, ConcurrentQueue<EventData>>();

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
        ///   Interacts with the storage system with responsibility for creation of checkpoints and for ownership claim.
        /// </summary>
        ///
        private PartitionManager StorageManager { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ShortWaitTimeMock" /> class.
        /// </summary>
        ///
        /// <param name="storageManager">The client responsible for interaction with durable storage, responsible for persisting checkpoints and load-balancing state.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="connectionFactory">A factory used to provide new <see cref="EventHubConnection" /> instances.</param>
        /// <param name="clientOptions">The set of options to use for this processor.</param>
        ///
        internal MockEventProcessorClient(PartitionManager storageManager,
                                          string consumerGroup = "consumerGroup",
                                          string fullyQualifiedNamespace = "somehost.com",
                                          string eventHubName = "somehub",
                                          Func<EventHubConnection> connectionFactory = default,
                                          EventProcessorClientOptions options = default,
                                          bool fakePartitionPRocessing = true,
                                          int numberOfPartitions = 3) : base(storageManager, consumerGroup, fullyQualifiedNamespace, eventHubName, connectionFactory, options)
        {
            StorageManager = storageManager;

            var partitionIds = Enumerable
                    .Range(1, numberOfPartitions)
                    .Select(p => p.ToString())
                    .ToArray();

            foreach (var partitionId in partitionIds)
            {
                EventPipeline[partitionId] = new ConcurrentQueue<EventData>();
            }

            this.FakeRunPartitionProcessingAsync = fakePartitionPRocessing;
            ProcessErrorAsync += async errorContext =>
            {
                Exception[] newException = new Exception[] { errorContext.Exception };
                ExceptionCalls.AddOrUpdate(
                    errorContext.PartitionId,
                    newException,
                    (partitionId, value) => value.Concat(newException).ToArray());
                await Task.Delay(1);
            };

            ProcessEventAsync += async processorEvent =>
            {
                EventData[] newEvent = new EventData[] { processorEvent.Data };
                ProcessEventCalls.AddOrUpdate(
                    processorEvent.Partition.PartitionId,
                    newEvent,
                    (partitionId, value) => value.Concat(newEvent).ToArray());

                await Task.Delay(1);
            };

            PartitionInitializingAsync += async initializationContext =>
            {
                InitializeCalls.AddOrUpdate(initializationContext.PartitionId, 1, (partitionId, value) => value + 1);
                await Task.Delay(1);
            };

            PartitionClosingAsync += async stopContext =>
            {
                CloseCalls.AddOrUpdate(stopContext.PartitionId, 1, (partitionId, value) => value + 1);
                StopReasons[stopContext.PartitionId] = stopContext.Reason;
                await Task.Delay(1);
            };

        }

        /// <summary>
        ///   Creates an <see cref="EventHubConsumerClient" /> to use for mock processing.
        /// </summary>
        ///
        /// <param name="consumerGroup">The consumer group to associate with the consumer client.</param>
        /// <param name="connection">The connection to use for the consumer client.</param>
        /// <param name="options">The options to use for configuring the consumer client.</param>
        ///
        /// <returns>An <see cref="EventHubConsumerClient" /> with the requested configuration.</returns>
        ///
        internal override EventHubConsumerClient CreateConsumer(string consumerGroup, EventHubConnection connection, EventHubConsumerClientOptions options)
        {
            var mockConsumer = new Mock<EventHubConsumerClient>();
            mockConsumer
                .Setup(m => m.ReadEventsFromPartitionAsync(It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<ReadEventOptions>(), It.IsAny<CancellationToken>()))
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((paritionId, EventPosition, options, token) =>
                {
                    var result = CreateReadEventsFromPartitionResponse(paritionId);
                    return result;
                });

            mockConsumer
                .Setup(m => m.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(EventPipeline.Keys.ToArray()));
            return mockConsumer.Object;
        }

        /// <summary>
        ///   Creates a mocked response for <see cref="CreateReadEventsFromPartitionResponse" />.
        /// </summary>
        ///
        /// <param name="partitionId">The partitionId to read events from.</param>
        ///
        /// <returns>An <see cref="IAsyncEnumerable<PartitionEvent>" /> for the requested partitionId.</returns>
        ///
        private async IAsyncEnumerable<PartitionEvent> CreateReadEventsFromPartitionResponse(string partitionId)
        {
            if (EventPipeline.TryGetValue(partitionId, out var eventQueue))
            {
                while (eventQueue.TryDequeue(out var eventData))
                {
                    await Task.Delay(0);
                    var eventResult = new PartitionEvent(new MockPartitionContext(partitionId), eventData);
                    yield return eventResult;
                }
                yield break;
            }
            else
            {
                yield break;
            }
        }

        /// <summary>
        ///   Starts running a task responsible for receiving and processing events in the context of a specified partition.
        ///   If <see cref="FakeRunPartitionProcessingAsync" /> is true, the operation is mocked.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition the task is associated with.  Events will be read only from this partition.</param>
        /// <param name="startingPosition">The position within the partition where the task should begin reading events.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The running task that is currently receiving and processing events in the context of the specified partition. Or a timed expiring task for mocking.</returns>
        ///
        internal override Task RunPartitionProcessingAsync(string partitionId, EventPosition startingPosition, CancellationToken cancellationToken)
        {
            if (FakeRunPartitionProcessingAsync)
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
        ///   Waits until the partition load distribution is stabilized.  Throws an <see cref="OperationCanceledException" />
        ///   if the load takes too long to stabilize.
        /// </summary>
        ///
        /// <param name="verifyAllEventsAreProcessed">Indicates whether stabilization requires that all events have been processed.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public async Task WaitStabilization(bool verifyAllEventsAreProcessed = false)
        {
            var stabilizedStatusAchieved = false;
            var consecutiveStabilizedStatus = 0;
            List<PartitionOwnership> previousActiveOwnership = null;

            CancellationToken timeoutToken = (new CancellationTokenSource(TimeSpan.FromSeconds(5))).Token;

            while (!stabilizedStatusAchieved)
            {
                // Remember to filter expired ownership.

                var activeOwnership = (await StorageManager
                    .ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, timeoutToken)
                    .ConfigureAwait(false))
                    .Where(ownership => DateTimeOffset.UtcNow.Subtract(ownership.LastModifiedTime.Value) < ShortOwnershipExpiration)
                    .ToList();

                // Increment stabilized status count if current partition distribution matches the previous one.  Reset it
                // otherwise.

                if (EventProcessorManager.AreOwnershipDistributionsTheSame(previousActiveOwnership, activeOwnership) &&
                    verifyAllEventsAreProcessed ? EventPipeline.Values.All(q => q.Count == 0) : true)
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

        /// <summary>
        ///   Creates a collection of <see cref="PartitionOwnership" /> based on the specified arguments.
        /// </summary>
        ///
        /// <param name="partitionIds">A collection of partition identifiers that the collection will be associated with.</param>
        /// <param name="identifier">The onwer identifier of the EventProcessorClient owning the collection.</param>
        /// <returns>A collection of <see cref="PartitionOwnership" />.</returns>
        ///
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
