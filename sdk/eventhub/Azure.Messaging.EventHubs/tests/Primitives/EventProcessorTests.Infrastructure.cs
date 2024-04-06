// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventProcessor{TPartition}" />
    ///   class.
    /// </summary>
    ///
    /// <remarks>
    ///   This segment of the partial class depends on the types and members defined in the
    ///   <c>EventProcessorTests.cs</c> file.
    /// </remarks>
    ///
    public partial class EventProcessorTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        public async Task ReadLastEnqueuedEventPropertiesReadsPropertiesWhenThePartitionIsOwned()
        {
            using var processorCancellation = new CancellationTokenSource();
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "27";
            var partitionIds = new[] { "0", partitionId };
            var ownedPartitions = new List<string>();
            var lastEventProperties = new LastEnqueuedEventProperties(1234, 9876, DateTimeOffset.Parse("2015-10-27T00:00:00Z"), DateTimeOffset.Parse("2012-03-04T08:30:00Z"));
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMinutes(5), TrackLastEnqueuedEventProperties = true };
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockProcessor = new Mock<MinimalProcessorMock>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options, mockLoadBalancer.Object) { CallBase = true };

            mockLoadBalancer
                .SetupGet(processor => processor.OwnedPartitionIds)
                .Returns(ownedPartitions);

            mockLoadBalancer
                .Setup(lb => lb.IsPartitionOwned(It.IsAny<string>()))
                .Returns<string>(partition => ownedPartitions.Contains(partition));

            mockLoadBalancer
                .Setup(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()))
                .Callback(() =>
                {
                    GetActivePartitionProcessors(mockProcessor.Object).TryAdd(
                        partitionId,
                        new EventProcessor<EventProcessorPartition>.PartitionProcessor(Task.Delay(Timeout.Infinite, processorCancellation.Token), new EventProcessorPartition { PartitionId = partitionId }, () => lastEventProperties, processorCancellation)
                    );

                    ownedPartitions.Add(partitionId);
                    completionSource.TrySetResult(true);
                })
                .Returns(() => default);

            mockConnection
                .Setup(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitionIds);

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<EventHubConnection>(), It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(Mock.Of<SettableTransportConsumer>());

             mockProcessor
                .Setup(processor => processor.ValidateProcessingPreconditions(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should not fault if a load balancing cycle fails.");

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(mockProcessor.Object.InvokeReadLastEnqueuedEventProperties(partitionId), Is.EqualTo(lastEventProperties), "The last enqueued properties should have been returned.");

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token).IgnoreExceptions();
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        public async Task ReadLastEnqueuedEventPropertiesThrowsWhenThePartitionIsNotOwned()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "27";
            var partitionIds = new[] { "0", partitionId };
            var lastEventProperties = new LastEnqueuedEventProperties(1234, 9876, DateTimeOffset.Parse("2015-10-27T00:00:00Z"), DateTimeOffset.Parse("2012-03-04T08:30:00Z"));
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMinutes(5), TrackLastEnqueuedEventProperties = true };
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockProcessor = new Mock<MinimalProcessorMock>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options, mockLoadBalancer.Object) { CallBase = true };

            mockLoadBalancer
                .SetupGet(processor => processor.OwnedPartitionIds)
                .Returns(Array.Empty<string>());

            mockLoadBalancer
                .Setup(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()))
                .Returns(() => default)
                .Callback(() => completionSource.TrySetResult(true));

            mockConnection
                .Setup(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitionIds);

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<EventHubConnection>(), It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(Mock.Of<SettableTransportConsumer>());

            mockProcessor
                .Setup(processor => processor.ValidateProcessingPreconditions(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should not fault if a load balancing cycle fails.");

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(() => mockProcessor.Object.InvokeReadLastEnqueuedEventProperties(partitionId), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed), "The last enqueued properties cannot be read for an unowned partition.");

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token).IgnoreExceptions();
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.ToString" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ToStringResultContainsTheProcessorIdentifier()
        {
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default) { CallBase = true };
            Assert.That(mockProcessor.Object.ToString().Contains(mockProcessor.Object.Identifier), Is.True, "ToString should return a value containing the event processor identifier");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="StorageManager" />
        ///   used by the processor.
        /// </summary>
        ///
        [Test]
        public async Task ProcessorCheckpointStoreDelegatesCalls()
        {
            var getCheckpointDelegated = false;
            var listOwnershipDelegated = false;
            var claimOwnershipDelegated = false;
            var fqNamespace = "fqns";
            var eventHub = "eh";
            var consumerGroup = "cg";
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(25, consumerGroup, fqNamespace, eventHub, Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .Protected()
                .Setup<Task<EventProcessorCheckpoint>>("GetCheckpointAsync", ItExpr.IsAny<string>(), ItExpr.IsAny<CancellationToken>())
                .Callback(() => getCheckpointDelegated = true)
                .Returns(Task.FromResult(default(EventProcessorCheckpoint)));

            mockProcessor
                .Protected()
                .Setup<Task<IEnumerable<EventProcessorPartitionOwnership>>>("ListOwnershipAsync", ItExpr.IsAny<CancellationToken>())
                .Callback(() => listOwnershipDelegated = true)
                .Returns(Task.FromResult(default(IEnumerable<EventProcessorPartitionOwnership>)));

            mockProcessor
                .Protected()
                .Setup<Task<IEnumerable<EventProcessorPartitionOwnership>>>("ClaimOwnershipAsync", ItExpr.IsAny<IEnumerable<EventProcessorPartitionOwnership>>(), ItExpr.IsAny<CancellationToken>())
                .Callback(() => claimOwnershipDelegated = true)
                .Returns(Task.FromResult(default(IEnumerable<EventProcessorPartitionOwnership>)));

            var checkpointStore = EventProcessor<EventProcessorPartition>.CreateCheckpointStore(mockProcessor.Object);
            Assert.That(checkpointStore, Is.Not.Null, "The storage manager should have been created.");

            await checkpointStore.GetCheckpointAsync("na", "na", "na", "na", CancellationToken.None);
            Assert.That(getCheckpointDelegated, Is.True, $"The call to { nameof(checkpointStore.GetCheckpointAsync) } should have been delegated.");

            await checkpointStore.ListOwnershipAsync("na", "na", "na", CancellationToken.None);
            Assert.That(listOwnershipDelegated, Is.True, $"The call to { nameof(checkpointStore.ListOwnershipAsync) } should have been delegated.");

            await checkpointStore.ClaimOwnershipAsync(default(IEnumerable<EventProcessorPartitionOwnership>), CancellationToken.None);
            Assert.That(claimOwnershipDelegated, Is.True, $"The call to { nameof(checkpointStore.ClaimOwnershipAsync) } should have been delegated.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="StorageManager" />
        ///   used by the processor.
        /// </summary>
        ///
        [Test]
        public void ProcessorCheckpointStoreDoesNotAllowCheckpointUpdate()
        {
            var fqNamespace = "fqns";
            var eventHub = "eh";
            var consumerGroup = "cg";
            var partitionId = "p0";
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(25, consumerGroup, fqNamespace, eventHub, Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };
            var checkpointStore = EventProcessor<EventProcessorPartition>.CreateCheckpointStore(mockProcessor.Object);

            Assert.That(checkpointStore, Is.Not.Null, "The storage manager should have been created.");
            Assert.That(() => checkpointStore.UpdateCheckpointAsync(fqNamespace, eventHub, consumerGroup, partitionId, "Id", new CheckpointPosition(0), CancellationToken.None), Throws.InstanceOf<NotImplementedException>(), "Calling to update checkpoints should not be implemented.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public async Task ProcessorLoadBalancerUsesTheExpectedStorageManager()
        {
            var fqNamespace = "fqns";
            var eventHub = "eh";
            var consumerGroup = "cg";
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(25, consumerGroup, fqNamespace, eventHub, Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };
            var loadBalancer = GetLoadBalancer(mockProcessor.Object);

            Assert.That(loadBalancer, Is.Not.Null, "The load balancer should have been created.");
            await loadBalancer.RelinquishOwnershipAsync(CancellationToken.None);

            mockProcessor
                .Protected()
                .Verify<Task<IEnumerable<EventProcessorPartitionOwnership>>>("ClaimOwnershipAsync", Times.Once(), ItExpr.IsAny<IEnumerable<EventProcessorPartitionOwnership>>(), ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void ProcessorLoadBalancerIsConfiguredUsingOptions()
        {
            var options = new EventProcessorOptions
            {
                LoadBalancingUpdateInterval = TimeSpan.FromDays(99),
                PartitionOwnershipExpirationInterval = TimeSpan.FromMilliseconds(5)
            };

            var fqNamespace = "fqns";
            var eventHub = "eh";
            var consumerGroup = "cg";
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(25, consumerGroup, fqNamespace, eventHub, Mock.Of<TokenCredential>(), options) { CallBase = true };
            var loadBalancer = GetLoadBalancer(mockProcessor.Object);

            Assert.That(loadBalancer, Is.Not.Null, "The load balancer should have been created.");
            Assert.That(loadBalancer.LoadBalanceInterval, Is.EqualTo(options.LoadBalancingUpdateInterval), "The load balancing interval was incorrect.");
            Assert.That(loadBalancer.OwnershipExpirationInterval, Is.EqualTo(options.PartitionOwnershipExpirationInterval), "The ownership expiration interval is incorrect.");
        }
    }
}
