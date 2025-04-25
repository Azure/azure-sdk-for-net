// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="PluggableCheckpointStoreEventProcessor{TPartition}" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class PluggableCheckpointStoreEventProcessorTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="PluggableCheckpointStoreEventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorsValidateTheCheckpointStore()
        {
            Assert.That(() => new MockCheckpointStoreProcessor(null, 100, "fakeConsumer", "Endpoint=sb://fake.servicebus.windows.net/;SharedAccessKeyName=SomeKeyName;SharedAccessKey=SomeKeyValue;EntityPath=fakeHub", new EventProcessorOptions()), Throws.InstanceOf<ArgumentNullException>(), "The connection string constructor should validate the checkpoint store.");
            Assert.That(() => new MockCheckpointStoreProcessor(null, 100, "fakeConsumer", "Endpoint=sb://fake.servicebus.windows.net/;SharedAccessKeyName=SomeKeyName;SharedAccessKey=SomeKeyValue", "fakeHub", new EventProcessorOptions()), Throws.InstanceOf<ArgumentNullException>(), "The connection string and Event Hub constructor should validate the checkpoint store.");
            Assert.That(() => new MockCheckpointStoreProcessor(null, 100, "fakeConsumer", "fakeNamespace", "fakeHub", Mock.Of<TokenCredential>(), new EventProcessorOptions()), Throws.InstanceOf<ArgumentNullException>(), "The token credential constructor should validate the checkpoint store.");
            Assert.That(() => new MockCheckpointStoreProcessor(null, 100, "fakeConsumer", "fakeNamespace", "fakeHub", new AzureNamedKeyCredential("key", "value"), new EventProcessorOptions()), Throws.InstanceOf<ArgumentNullException>(), "The named key constructor should validate the checkpoint store.");
            Assert.That(() => new MockCheckpointStoreProcessor(null, 100, "fakeConsumer", "fakeNamespace", "fakeHub", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value), new EventProcessorOptions()), Throws.InstanceOf<ArgumentNullException>(), "The SAS constructor should validate the checkpoint store.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PluggableCheckpointStoreEventProcessor{TPartition}.GetCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CheckpointStoreIsUsedByGetCheckpointAsync()
        {
            using var cancellationSource = new CancellationTokenSource();

            var expectedException = new AmbiguousMatchException();
            var partitionId = "fakePart";
            var mockCheckpointStore = new Mock<CheckpointStore>();
            var mockProcessor = new MockCheckpointStoreProcessor(mockCheckpointStore.Object, 100, "fakeConsumer", "fakeNamespace", "fakeHub", Mock.Of<TokenCredential>());

            mockCheckpointStore
                .Setup(store => store.GetCheckpointAsync(
                    mockProcessor.FullyQualifiedNamespace,
                    mockProcessor.EventHubName,
                    mockProcessor.ConsumerGroup,
                    partitionId,
                    cancellationSource.Token))
                .ThrowsAsync(expectedException);

            Assert.That(async () => await mockProcessor.InvokeGetCheckpointAsync(partitionId, cancellationSource.Token), Throws.Exception.EqualTo(expectedException));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PluggableCheckpointStoreEventProcessor{TPartition}.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CheckpointStoreIsUsedByUpdateCheckpointAsync()
        {
            using var cancellationSource = new CancellationTokenSource();

            var expectedException = new DivideByZeroException();
            var expectedExceptionOld = new FormatException();
            var partitionId = "fakePart";
            var offset = "12345";
            var sequence = 9987;
            var mockCheckpointStore = new Mock<CheckpointStore>();
            var mockProcessor = new MockCheckpointStoreProcessor(mockCheckpointStore.Object, 100, "fakeConsumer", "fakeNamespace", "fakeHub", Mock.Of<TokenCredential>());

            mockCheckpointStore
                .Setup(store => store.UpdateCheckpointAsync(
                    mockProcessor.FullyQualifiedNamespace,
                    mockProcessor.EventHubName,
                    mockProcessor.ConsumerGroup,
                    partitionId,
                    mockProcessor.Identifier,
                    It.Is<CheckpointPosition>(csp => csp.OffsetString == offset && csp.SequenceNumber == sequence),
                    cancellationSource.Token))
                .ThrowsAsync(expectedException);

            Assert.That(async () => await mockProcessor.InvokeUpdateCheckpointAsync(partitionId, new CheckpointPosition(offset, sequence), cancellationSource.Token), Throws.Exception.EqualTo(expectedException));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PluggableCheckpointStoreEventProcessor{TPartition}.ListOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CheckpointStoreIsUsedByListOwnershipAsync()
        {
            using var cancellationSource = new CancellationTokenSource();

            var expectedException = new ApplicationException();
            var mockCheckpointStore = new Mock<CheckpointStore>();
            var mockProcessor = new MockCheckpointStoreProcessor(mockCheckpointStore.Object, 100, "fakeConsumer", "fakeNamespace", "fakeHub", Mock.Of<TokenCredential>());

            mockCheckpointStore
                .Setup(store => store.ListOwnershipAsync(
                    mockProcessor.FullyQualifiedNamespace,
                    mockProcessor.EventHubName,
                    mockProcessor.ConsumerGroup,
                    cancellationSource.Token))
                .ThrowsAsync(expectedException);

            Assert.That(async () => await mockProcessor.InvokeListOwnershipAsync(cancellationSource.Token), Throws.Exception.EqualTo(expectedException));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PluggableCheckpointStoreEventProcessor{TPartition}.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CheckpointStoreIsUsedByClaimOwnershipAsync()
        {
            using var cancellationSource = new CancellationTokenSource();

            var expectedException = new ApplicationException();
            var desiredOwnership = new[] { new EventProcessorPartitionOwnership { PartitionId = "1" } };
            var mockCheckpointStore = new Mock<CheckpointStore>();
            var mockProcessor = new MockCheckpointStoreProcessor(mockCheckpointStore.Object, 100, "fakeConsumer", "fakeNamespace", "fakeHub", Mock.Of<TokenCredential>());

            mockCheckpointStore
                .Setup(store => store.ClaimOwnershipAsync(
                    desiredOwnership,
                    cancellationSource.Token))
                .ThrowsAsync(expectedException);

            Assert.That(async () => await mockProcessor.InvokeClaimOwnershipAsync(desiredOwnership, cancellationSource.Token), Throws.Exception.EqualTo(expectedException));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PluggableCheckpointStoreEventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void PluggableCheckpointStoreEventProcessorCanBeMocked()
        {
            var mock = new Mock<PluggableCheckpointStoreEventProcessor<EventProcessorPartition>>();
            Assert.That(() => mock.Object, Is.Not.Null);
        }

        /// <summary>
        ///   Serves as a minimal processor implementation for testing functionality
        ///   related  to the checkpoint store integration.
        /// </summary>
        ///
        private class MockCheckpointStoreProcessor : PluggableCheckpointStoreEventProcessor<EventProcessorPartition>
        {
            public MockCheckpointStoreProcessor(CheckpointStore checkpointStore,
                                                int eventBatchMaximumCount,
                                                string consumerGroup,
                                                string connectionString,
                                                EventProcessorOptions options = default) : base(checkpointStore, eventBatchMaximumCount, consumerGroup, connectionString, options)
            {
            }

            public MockCheckpointStoreProcessor(CheckpointStore checkpointStore,
                                                int eventBatchMaximumCount,
                                                string consumerGroup,
                                                string connectionString,
                                                string eventHubName,
                                                EventProcessorOptions options = default) : base(checkpointStore, eventBatchMaximumCount, consumerGroup, connectionString, eventHubName, options)
            {
            }

            public MockCheckpointStoreProcessor(CheckpointStore checkpointStore,
                                                int eventBatchMaximumCount,
                                                string consumerGroup,
                                                string fullyQualifiedNamespace,
                                                string eventHubName,
                                                AzureNamedKeyCredential credential,
                                                EventProcessorOptions options = default) : base(checkpointStore, eventBatchMaximumCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, options)
            {
            }

            public MockCheckpointStoreProcessor(CheckpointStore checkpointStore,
                                                int eventBatchMaximumCount,
                                                string consumerGroup,
                                                string fullyQualifiedNamespace,
                                                string eventHubName,
                                                AzureSasCredential credential,
                                                EventProcessorOptions options = default) : base(checkpointStore, eventBatchMaximumCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, options)
            {
            }

            public MockCheckpointStoreProcessor(CheckpointStore checkpointStore,
                                                int eventBatchMaximumCount,
                                                string consumerGroup,
                                                string fullyQualifiedNamespace,
                                                string eventHubName,
                                                TokenCredential credential,
                                                EventProcessorOptions options = default) : base(checkpointStore, eventBatchMaximumCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, options)
            {
            }

            protected override Task OnProcessingEventBatchAsync(IEnumerable<EventData> events, EventProcessorPartition partition, CancellationToken cancellationToken) => throw new NotImplementedException();
            protected override Task OnProcessingErrorAsync(Exception exception, EventProcessorPartition partition, string operationDescription, CancellationToken cancellationToken) => throw new NotImplementedException();

            public Task<EventProcessorCheckpoint> InvokeGetCheckpointAsync(string partitionId, CancellationToken cancellationToken) => GetCheckpointAsync(partitionId, cancellationToken);
            public Task InvokeUpdateCheckpointAsync(string partitionId, CheckpointPosition checkpointPosition, CancellationToken cancellationToken) => UpdateCheckpointAsync(partitionId, checkpointPosition, cancellationToken);
            public Task<IEnumerable<EventProcessorPartitionOwnership>> InvokeListOwnershipAsync(CancellationToken cancellationToken) => ListOwnershipAsync(cancellationToken);
            public Task<IEnumerable<EventProcessorPartitionOwnership>> InvokeClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> desiredOwnership, CancellationToken cancellationToken) => ClaimOwnershipAsync(desiredOwnership, cancellationToken);
        }
    }
}
