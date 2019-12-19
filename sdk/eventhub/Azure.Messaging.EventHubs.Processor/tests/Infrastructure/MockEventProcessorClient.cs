// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;

namespace Azure.Messaging.EventHubs.Processor.Tests
{
    /// <summary>
    ///   A mock <see cref="EventProcessorClient" /> used for testing purposes.
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
        ///   Interacts with the storage system with responsibility for creation of checkpoints and for ownership claim.
        /// </summary>
        ///
        private PartitionManager StorageManager { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="MockEventProcessorClient" /> class.
        /// </summary>
        ///
        /// <param name="storageManager">The client responsible for interaction with durable storage, responsible for persisting checkpoints and load-balancing state.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="connectionFactory">A factory used to provide new <see cref="EventHubConnection" /> instances.</param>
        /// <param name="clientOptions">The set of options to use for this processor.</param>
        /// <param name="fakePartitionProcessing"><c>true</c> if <see cref="RunPartitionProcessingAsync" /> should be overridden; otherwise, <c>false</c>.</param>
        /// <param name="numberOfPartitions">The amount of partitions the associated Event Hub has.</param>
        /// <param name="loadBalancer">The <see cref="PartitionLoadBalancer" /> used to manage partition load balance operations.</param>
        ///
        internal MockEventProcessorClient(PartitionManager storageManager,
                                          string consumerGroup = "consumerGroup",
                                          string fullyQualifiedNamespace = "somehost.com",
                                          string eventHubName = "somehub",
                                          Func<EventHubConnection> connectionFactory = default,
                                          EventProcessorClientOptions clientOptions = default,
                                          bool fakePartitionProcessing = true,
                                          int numberOfPartitions = 3,
                                          PartitionLoadBalancer loadBalancer = default) : base(storageManager, consumerGroup, fullyQualifiedNamespace, eventHubName, connectionFactory, clientOptions, loadBalancer)
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

            FakeRunPartitionProcessingAsync = fakePartitionProcessing;

            ProcessErrorAsync += eventArgs =>
            {
                Exception[] newException = new Exception[] { eventArgs.Exception };
                ExceptionCalls.AddOrUpdate(
                    eventArgs.PartitionId,
                    newException,
                    (partitionId, value) => value.Concat(newException).ToArray());

                return Task.CompletedTask;
            };

            ProcessEventAsync += eventArgs =>
            {
                EventData[] newEvent = new EventData[] { eventArgs.Data };
                ProcessEventCalls.AddOrUpdate(
                    eventArgs.Partition.PartitionId,
                    newEvent,
                    (partitionId, value) => value.Concat(newEvent).ToArray());

                return Task.CompletedTask;
            };

            PartitionInitializingAsync += eventArgs =>
            {
                InitializeCalls.AddOrUpdate(eventArgs.PartitionId, 1, (partitionId, value) => value + 1);

                return Task.CompletedTask;
            };

            PartitionClosingAsync += eventArgs =>
            {
                CloseCalls.AddOrUpdate(eventArgs.PartitionId, 1, (partitionId, value) => value + 1);
                StopReasons[eventArgs.PartitionId] = eventArgs.Reason;

                return Task.CompletedTask;
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
        internal override EventHubConsumerClient CreateConsumer(string consumerGroup,
                                                                EventHubConnection connection,
                                                                EventHubConsumerClientOptions options)
        {
            var mockConsumer = new Mock<EventHubConsumerClient>();
            mockConsumer
                .Setup(m => m.ReadEventsFromPartitionAsync(It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<ReadEventOptions>(), It.IsAny<CancellationToken>()))
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partitionId, eventPosition, options, token) =>
                {
                    return CreateReadEventsFromPartitionResponse(partitionId);
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
                    yield return new PartitionEvent(new MockPartitionContext(partitionId), eventData);
                }
            }
            else
            {
                yield return new PartitionEvent();
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
        internal override Task RunPartitionProcessingAsync(string partitionId,
                                                           EventPosition startingPosition,
                                                           CancellationToken cancellationToken)
        {
            if (FakeRunPartitionProcessingAsync)
            {
                // Return a task that will only reasonably return when cancelled.

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

                var activeOwnership = (await StorageManager
                    .ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, timeoutToken)
                    .ConfigureAwait(false))
                    .Where(ownership => DateTimeOffset.UtcNow.Subtract(ownership.LastModifiedTime.Value) < ShortOwnershipExpiration)
                    .ToList();

                // Increment stabilized status count if current partition distribution matches the previous one.  Reset it otherwise.

                if (AreOwnershipDistributionsTheSame(previousActiveOwnership, activeOwnership))
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
        /// <param name="identifier">The owner identifier of the EventProcessorClient owning the collection.</param>
        ///
        /// <returns>A collection of <see cref="PartitionOwnership" />.</returns>
        ///
        internal IEnumerable<PartitionOwnership> CreatePartitionOwnership(IEnumerable<string> partitionIds,
                                                                          string identifier)
        {
            return partitionIds
                .Select(partitionId =>
                    new PartitionOwnership
                        (
                            FullyQualifiedNamespace,
                            EventHubName,
                            ConsumerGroup,
                            identifier,
                            partitionId,
                            DateTimeOffset.UtcNow,
                            Guid.NewGuid().ToString()
                        )).ToList();
        }

        /// <summary>
        ///   Compares two ownership distributions among event processors to determine if they represent the same
        ///   distribution.
        /// </summary>
        ///
        /// <param name="first">The first distribution to consider.</param>
        /// <param name="second">The second distribution to consider.</param>
        ///
        /// <returns><c>true</c>, if there are no owner changes between distributions; otherwise, <c>false</c>.</returns>
        ///
        /// <remarks>
        ///   Filtering expired ownership is assumed to be responsibility of the caller.
        /// </remarks>
        ///
        private bool AreOwnershipDistributionsTheSame(IEnumerable<PartitionOwnership> first,
                                                      IEnumerable<PartitionOwnership> second)
        {
            // If the distributions are the same instance, they're equal.  This should only happen
            // if both are null or if they are the exact same instance.

            if (Object.ReferenceEquals(first, second))
            {
                return true;
            }

            // If one or the other is null, then they cannot be equal, since we know that
            // they are not both null.

            if ((first == null) || (second == null))
            {
                return false;
            }

            // If the owners of each partition are equal, the instances are equal.

            var firstOrderedDistribution = first.OrderBy(ownership => ownership.PartitionId).ToList();
            var secondOrderedDistribution = second.OrderBy(ownership => ownership.PartitionId).ToList();

            if (firstOrderedDistribution.Count != secondOrderedDistribution.Count)
            {
                return false;
            }

            for (var index = 0; index < firstOrderedDistribution.Count; ++index)
            {
                // We must check assert the partitions are the same as well, otherwise we might have matching
                // owners by chance.

                if (firstOrderedDistribution[index].PartitionId != secondOrderedDistribution[index].PartitionId)
                {
                    return false;
                }

                if (firstOrderedDistribution[index].OwnerIdentifier != secondOrderedDistribution[index].OwnerIdentifier)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///   Serves as a mock <see cref="PartitionContext" />.
        /// </summary>
        ///
        private class MockPartitionContext : PartitionContext
        {
            public MockPartitionContext(string partitionId) : base(partitionId)
            {
            }
        }
    }
}
