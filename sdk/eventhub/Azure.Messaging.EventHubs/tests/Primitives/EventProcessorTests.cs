// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Primitives;
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
    [TestFixture]
    public class EventProcessorTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="StorageManager" />
        ///   used by the processor.
        /// </summary>
        ///
        [Test]
        public async Task ProcessorStorageManagerDelegatesCalls()
        {
            var listCheckpointsDelegated = false;
            var listOwnershipDelegated = false;
            var claimOwnershipDelegated = false;
            var fqNamespace = "fqns";
            var eventHub = "eh";
            var consumerGroup = "cg";
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(25, consumerGroup, fqNamespace, eventHub, Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .Protected()
                .Setup<Task<IEnumerable<EventProcessorCheckpoint>>>("ListCheckpointsAsync", ItExpr.IsAny<CancellationToken>())
                .Callback(() => listCheckpointsDelegated = true)
                .Returns(Task.FromResult(default(IEnumerable<EventProcessorCheckpoint>)));

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

            var storageManager = mockProcessor.Object.CreateStorageManager(mockProcessor.Object);
            Assert.That(storageManager, Is.Not.Null, "The storage manager should have been created.");

            await storageManager.ListCheckpointsAsync("na", "na", "na", CancellationToken.None);
            Assert.That(listCheckpointsDelegated, Is.True, $"The call to { nameof(storageManager.ListCheckpointsAsync) } should have been delegated.");

            await storageManager.ListOwnershipAsync("na", "na", "na", CancellationToken.None);
            Assert.That(listOwnershipDelegated, Is.True, $"The call to { nameof(storageManager.ListOwnershipAsync) } should have been delegated.");

            await storageManager.ClaimOwnershipAsync(default(IEnumerable<EventProcessorPartitionOwnership>), CancellationToken.None);
            Assert.That(claimOwnershipDelegated, Is.True, $"The call to { nameof(storageManager.ClaimOwnershipAsync) } should have been delegated.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="StorageManager" />
        ///   used by the processor.
        /// </summary>
        ///
        [Test]
        public void ProcessorStorageManagerDoesNotAllowCheckpointUpdate()
        {
            var fqNamespace = "fqns";
            var eventHub = "eh";
            var consumerGroup = "cg";
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(25, consumerGroup, fqNamespace, eventHub, Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            var storageManager = mockProcessor.Object.CreateStorageManager(mockProcessor.Object);
            Assert.That(storageManager, Is.Not.Null, "The storage manager should have been created.");

            Assert.That(() => storageManager.UpdateCheckpointAsync(new EventProcessorCheckpoint(), new EventData(Array.Empty<byte>()), CancellationToken.None), Throws.InstanceOf<NotImplementedException>(), "Calling to update checkpoints should not be implemented.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="StorageManager" />
        ///   used by the processor.
        /// </summary>
        ///
        [Test]
        public async Task TheStorageManagerDoesNotKeepTheProcessorAlive()
        {
            var fqNamespace = "fqns";
            var eventHub = "eh";
            var consumerGroup = "cg";
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(25, consumerGroup, fqNamespace, eventHub, Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };
            var storageManager = mockProcessor.Object.CreateStorageManager(mockProcessor.Object);

            mockProcessor
                .Protected()
                .Setup<Task<IEnumerable<EventProcessorCheckpoint>>>("ListCheckpointsAsync", ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(default(IEnumerable<EventProcessorCheckpoint>)));

            Assert.That(storageManager, Is.Not.Null, "The storage manager should have been created.");
            Assert.That(() => storageManager.ListCheckpointsAsync(fqNamespace, eventHub, consumerGroup, CancellationToken.None), Throws.Nothing, "The initial call should be successful.");

            // Attempt to clear out the processor and force GC.

            mockProcessor = null;

            // Because cleanup may be non-deterministic, allow a small set of retries.

            var attempts = 0;
            var maxAttempts = 5;

            while (attempts <= maxAttempts)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));

                GC.Collect();
                GC.WaitForPendingFinalizers();

                try
                {
                    Assert.That(() => storageManager.ListCheckpointsAsync(fqNamespace, eventHub, consumerGroup, CancellationToken.None), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
                }
                catch (AssertionException)
                {
                    if (++attempts <= maxAttempts)
                    {
                        continue;
                    }

                    throw;
                }

                // If things have gotten here, the test passes.

                break;
            }
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
        ///   Retrieves the load balancer for an event processor instance, using its private accessor.
        /// </summary>
        ///
        /// <typeparam name="T">The partition type to which the processor is bound.</typeparam>
        ///
        /// <param name="processor">The processor instance to read the load balancer for.</param>
        ///
        /// <returns>The load balancer used by the processor.</returns>
        ///
        private static PartitionLoadBalancer GetLoadBalancer<T>(EventProcessor<T> processor) where T : EventProcessorPartition, new() =>
            (PartitionLoadBalancer)
                typeof(EventProcessor<T>)
                    .GetProperty("LoadBalancer", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(processor);
    }
}
