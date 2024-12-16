// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Shared;
using Azure.Core.Tests;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Processor.Diagnostics;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using static Azure.Messaging.EventHubs.Tests.EventProcessorClientTests;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for validating the diagnostics instrumentation
    ///   of the client library.  These tests are not constrained to a specific
    ///   class or functional area.
    /// </summary>
    ///
    /// <remarks>
    ///   Every instrumented operation will trigger diagnostics activities as
    ///   long as they are being listened to, making it possible for other
    ///   tests to interfere with these. For this reason, these tests are
    ///   marked as non-parallelizable.
    /// </remarks>
    ///
    [NonParallelizable]
    [TestFixture]
    public class DiagnosticsTests
    {
        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="EventProcessorClient.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task UpdateCheckpointAsyncCreatesScope()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockContext = new Mock<PartitionContext>("65");
            var mockLogger = new Mock<EventProcessorClientEventSource>();
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<CheckpointStore>(), "cg", "host", "hub", 50, Mock.Of<TokenCredential>(), null) { CallBase = true };

            mockProcessor
                .Protected()
                .Setup<EventHubConnection>("CreateConnection")
                .Returns(Mock.Of<EventHubConnection>());

            mockLogger
                .Setup(log => log.UpdateCheckpointComplete(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() => completionSource.TrySetResult(true));

            mockProcessor.Object.Logger = mockLogger.Object;

            using var listener = new ClientDiagnosticListener(DiagnosticProperty.DiagnosticNamespace);
            await InvokeUpdateCheckpointAsync(mockProcessor.Object, mockContext.Object.PartitionId, "998", default);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            ClientDiagnosticListener.ProducedDiagnosticScope scope = listener.Scopes.Single();
            Assert.That(scope.Name, Is.EqualTo(DiagnosticProperty.EventProcessorCheckpointActivityName));

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="EventProcessorClient.OnProcessingEventBatchAsync" /> implementation.
        /// </summary>
        ///
        [Test]
        public async Task EventProcessorClientCreatesScopeForEachEventProcessing()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            using var listener = new ClientDiagnosticListener(DiagnosticProperty.DiagnosticNamespace);
            var enqueuedTime = DateTimeOffset.UtcNow;
            var eventBatch = new[]
            {
                new MockEventData(new byte[] { 0x11 }, offset: "123", sequenceNumber: 123, enqueuedTime: enqueuedTime),
                new MockEventData(new byte[] { 0x22 }, offset: "456", sequenceNumber: 456, enqueuedTime: enqueuedTime)
            };

            for (int i = 0; i < eventBatch.Length; i++)
            {
                eventBatch[i].Properties.Add("Diagnostic-Id", $"00-{i}0112233445566778899aabbccddeeff-0123456789abcdef-01");
            }

            var partitionId = "3";
            var mockLogger = new Mock<EventProcessorClientEventSource>();
            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            processorClient.Logger = mockLogger.Object;
            processorClient.ProcessEventAsync += _ => Task.CompletedTask;

            await processorClient.InvokeOnProcessingEventBatchAsync(eventBatch, new TestEventProcessorPartition(partitionId), cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            // Validate the diagnostics.

            var expectedTags = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>(DiagnosticProperty.KindAttribute, DiagnosticProperty.ConsumerKind),
                new KeyValuePair<string, string>(MessagingClientDiagnostics.MessageBusDestination, "eventHub"),
                new KeyValuePair<string, string>(MessagingClientDiagnostics.PeerAddress, "namespace"),
                new KeyValuePair<string, string>(DiagnosticProperty.EnqueuedTimeAttribute, enqueuedTime.ToUnixTimeMilliseconds().ToString())
            };

            var scopes = listener.Scopes.ToList();
            Assert.AreEqual(eventBatch.Length, listener.Scopes.Count);

            foreach (var scope in scopes)
            {
                Assert.AreEqual(DiagnosticProperty.EventProcessorProcessingActivityName, scope.Name);
                Assert.That(scope.LinkedActivities, Has.Exactly(1).Items);
                Assert.That(scope.LinkedActivities.Select(a => a.ParentId), Has.One.EqualTo(scope.Activity.ParentId));
                Assert.That(expectedTags, Is.SubsetOf(scope.Activity.Tags.ToList()));
                Assert.AreEqual(ActivityStatusCode.Unset, scope.Activity.Status);
            }
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="EventProcessorClient.OnProcessingEventBatchAsync" /> implementation
        ///   when processing callback throws
        /// </summary>
        ///
        [Test]
        public async Task EventProcessorClientCreatesScopeError()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            using var listener = new ClientDiagnosticListener(DiagnosticProperty.DiagnosticNamespace);
            var eventBatch = new[]
            {
                new MockEventData(new byte[] { 0x11 }, offset: "123", sequenceNumber: 123),
                new MockEventData(new byte[] { 0x22 }, offset: "456", sequenceNumber: 456)
            };

            var mockLogger = new Mock<EventProcessorClientEventSource>();
            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            processorClient.Logger = mockLogger.Object;
            processorClient.ProcessEventAsync += _ => throw new TimeoutException();

            await processorClient.InvokeOnProcessingEventBatchAsync(eventBatch, new TestEventProcessorPartition("0"), cancellationSource.Token).IgnoreExceptions();
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            // Validate the diagnostics.

            var expectedTags = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>(DiagnosticProperty.KindAttribute, DiagnosticProperty.ConsumerKind),
                new KeyValuePair<string, string>(MessagingClientDiagnostics.MessageBusDestination, "eventHub"),
                new KeyValuePair<string, string>(MessagingClientDiagnostics.PeerAddress, "namespace"),
            };

            var scopes = listener.Scopes.ToList();
            Assert.AreEqual(eventBatch.Length, listener.Scopes.Count);

            foreach (var scope in scopes)
            {
                Assert.AreEqual(DiagnosticProperty.EventProcessorProcessingActivityName, scope.Name);
                Assert.That(expectedTags, Is.SubsetOf(scope.Activity.Tags.ToList()));
                Assert.AreEqual(ActivityStatusCode.Error, scope.Activity.Status);
            }
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="EventProcessorClient.OnProcessingEventBatchAsync" /> implementation
        ///   when received message does not have trace context.
        /// </summary>
        ///
        [Test]
        public async Task EventProcessorClientCreatesScopeForEachEventProcessingWithoutRemoteLink()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            using var listener = new ClientDiagnosticListener(DiagnosticProperty.DiagnosticNamespace);
            var enqueuedTime = DateTimeOffset.UtcNow;
            var eventBatch = new[]
            {
                new MockEventData(new byte[] { 0x11 }, offset: "123", sequenceNumber: 123, enqueuedTime: enqueuedTime),
                new MockEventData(new byte[] { 0x22 }, offset: "456", sequenceNumber: 456, enqueuedTime: enqueuedTime)
            };

            var mockLogger = new Mock<EventProcessorClientEventSource>();
            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            processorClient.Logger = mockLogger.Object;
            processorClient.ProcessEventAsync += _ => Task.CompletedTask;

            await processorClient.InvokeOnProcessingEventBatchAsync(eventBatch, new TestEventProcessorPartition("0"), cancellationSource.Token).IgnoreExceptions();
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            // Validate the diagnostics.

            var expectedTags = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>(DiagnosticProperty.KindAttribute, DiagnosticProperty.ConsumerKind),
                new KeyValuePair<string, string>(MessagingClientDiagnostics.MessageBusDestination, "eventHub"),
                new KeyValuePair<string, string>(MessagingClientDiagnostics.PeerAddress, "namespace"),
                new KeyValuePair<string, string>(DiagnosticProperty.EnqueuedTimeAttribute, enqueuedTime.ToUnixTimeMilliseconds().ToString())
            };

            var scopes = listener.Scopes.ToList();
            Assert.AreEqual(eventBatch.Length, listener.Scopes.Count);

            foreach (var scope in scopes)
            {
                Assert.AreEqual(DiagnosticProperty.EventProcessorProcessingActivityName, scope.Name);
                Assert.IsEmpty(scope.LinkedActivities);
                Assert.That(expectedTags, Is.SubsetOf(scope.Activity.Tags.ToList()));
            }
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies <see cref="EventProcessorClient" /> disables base batch tracing.
        /// </summary>
        ///
        [Test]
        public void EventProcessorClientDisablesBaseBatchTracing()
        {
            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);
            Assert.That(processorClient.IsBaseBatchTracingEnabled, Is.False);
        }

        /// <summary>
        ///   Invokes the protected UpdateCheckpointAsync method on the processor client.
        /// </summary>
        ///
        /// <param name="target">The client whose method to invoke.</param>
        /// <param name="partitionId">The identifier of the partition the checkpoint is for.</param>
        /// <param name="offset">The offset to associate with the checkpoint, indicating that a processor should begin reading form the next event in the stream.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal a request to cancel the operation.</param>
        ///
        /// <returns>The translated options.</returns>
        ///
        private static Task InvokeUpdateCheckpointAsync(EventProcessorClient target,
                                                        string partitionId,
                                                        string offset,
                                                        CancellationToken cancellationToken) =>
            (Task)
                typeof(EventProcessorClient)
                    .GetMethod("UpdateCheckpointAsync", BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(string), typeof(CheckpointPosition), typeof(CancellationToken) }, null)
                    .Invoke(target, new object[] { partitionId, new CheckpointPosition(offset), cancellationToken });
    }
}
