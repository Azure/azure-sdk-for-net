// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Shared;
using Azure.Core.TestFramework;
using Azure.Core.Tests;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor.Diagnostics;
using Azure.Messaging.EventHubs.Processor;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System.Diagnostics;
using static Azure.Messaging.EventHubs.Tests.EventProcessorClientTests;

namespace Azure.Messaging.EventHubs.Tests
{
#if NET5_0_OR_GREATER
    /// <summary>
    ///   The suite of tests for validating the diagnostics instrumentation
    ///   of the client library when ActivitySource is enabled.  These tests are not constrained to a specific
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
    public class DiagnosticsActivitySourceTests
    {
        /// <summary>
        ///   Resets the activity source feature switch after each test.
        /// </summary>
        ///
        [SetUp]
        [TearDown]
        public void ResetFeatureSwitch()
        {
            ActivityExtensions.ResetFeatureSwitch();
        }

        /// <summary>
        ///   Verifies checkpoint activities are not created when feature flag is off />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointStoreActivitySourceDisabled()
        {
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockContext = new Mock<PartitionContext>("65");
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<CheckpointStore>(), "cg", "host", "hub", 50, Mock.Of<TokenCredential>(), null) { CallBase = true };

            mockProcessor
                .Protected()
                .Setup<EventHubConnection>("CreateConnection")
                .Returns(Mock.Of<EventHubConnection>());

            var mockLogger = new Mock<EventProcessorClientEventSource>();
            mockLogger
                .Setup(log => log.UpdateCheckpointComplete(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() => completionSource.TrySetResult(true));

            mockProcessor.Object.Logger = mockLogger.Object;

            using var listener = new TestActivitySourceListener(source => source.Name.StartsWith(DiagnosticProperty.DiagnosticNamespace));
            await InvokeUpdateCheckpointAsync(mockProcessor.Object, mockContext.Object.PartitionId, "998", default);
            await InvokeUpdateCheckpointAsync(mockProcessor.Object, mockContext.Object.PartitionId, "1:0:556", default);

            Assert.IsEmpty(listener.Activities);
        }

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

            using var _ = SetAppConfigSwitch();

            using var listener = new TestActivitySourceListener(source => source.Name.StartsWith(DiagnosticProperty.DiagnosticNamespace));
            await InvokeUpdateCheckpointAsync(mockProcessor.Object, mockContext.Object.PartitionId, "1:0:998", default);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            var checkpointActivity = listener.AssertAndRemoveActivity(DiagnosticProperty.EventProcessorCheckpointActivityName);
            CollectionAssert.Contains(checkpointActivity.Tags, new KeyValuePair<string, string>(MessagingClientDiagnostics.ServerAddress, "host"));
            CollectionAssert.Contains(checkpointActivity.Tags, new KeyValuePair<string, string>(MessagingClientDiagnostics.DestinationName, "hub"));
            CollectionAssert.Contains(checkpointActivity.Tags, new KeyValuePair<string, string>(MessagingClientDiagnostics.MessagingSystem, DiagnosticProperty.EventHubsServiceContext));
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
            using var _ = SetAppConfigSwitch();
            using var listener = new TestActivitySourceListener(source => source.Name.StartsWith(DiagnosticProperty.DiagnosticNamespace));

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

            var mockLogger = new Mock<EventProcessorClientEventSource>();
            var processorClient = new TestEventProcessorClient(Mock.Of<CheckpointStore>(), "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), Mock.Of<EventHubConnection>(), default);

            processorClient.Logger = mockLogger.Object;
            processorClient.ProcessEventAsync += _ => Task.CompletedTask;

            await processorClient.InvokeOnProcessingEventBatchAsync(eventBatch, new TestEventProcessorPartition("0"), cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            // Validate the diagnostics.

            var expectedTags = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>(MessagingClientDiagnostics.DestinationName, "eventHub"),
                new KeyValuePair<string, object>(MessagingClientDiagnostics.ServerAddress, "namespace"),
                new KeyValuePair<string, object>(MessagingClientDiagnostics.MessagingSystem, DiagnosticProperty.EventHubsServiceContext),
                new KeyValuePair<string, object>(DiagnosticProperty.EnqueuedTimeAttribute, enqueuedTime.ToUnixTimeMilliseconds())
            };

            var activities = listener.Activities.ToList();
            Assert.AreEqual(eventBatch.Length, activities.Count);

            foreach (var activity in activities)
            {
                Assert.AreEqual(DiagnosticProperty.EventProcessorProcessingActivityName, activity.OperationName);
                Assert.That(activity.Links, Has.Exactly(1).Items);
                Assert.That(activity.Links.Select(a => a.Context.SpanId), Has.One.EqualTo(activity.ParentSpanId));
                Assert.That(expectedTags, Is.SubsetOf(activity.TagObjects.ToList()));
                Assert.AreEqual(ActivityStatusCode.Unset, activity.Status);
                Assert.AreEqual(ActivityKind.Consumer, activity.Kind);
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
            using var _ = SetAppConfigSwitch();

            using var listener = new TestActivitySourceListener(source => source.Name.StartsWith(DiagnosticProperty.DiagnosticNamespace));
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

            var expectedTags = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>(MessagingClientDiagnostics.DestinationName, "eventHub"),
                new KeyValuePair<string, object>(MessagingClientDiagnostics.ServerAddress, "namespace"),
                new KeyValuePair<string, object>(MessagingClientDiagnostics.MessagingSystem, DiagnosticProperty.EventHubsServiceContext),
                new KeyValuePair<string, object>("error.type", typeof(TimeoutException).FullName),
            };

            var activities = listener.Activities.ToList();
            Assert.AreEqual(eventBatch.Length, activities.Count);

            foreach (var activity in activities)
            {
                Assert.AreEqual(DiagnosticProperty.EventProcessorProcessingActivityName, activity.OperationName);
                Assert.That(expectedTags, Is.SubsetOf(activity.TagObjects.ToList()));
                Assert.AreEqual(ActivityStatusCode.Error, activity.Status);
                Assert.AreEqual(ActivityKind.Consumer, activity.Kind);
                Assert.IsEmpty(activity.TagObjects.Where(t => t.Key == DiagnosticProperty.EnqueuedTimeAttribute));
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
            using var _ = SetAppConfigSwitch();
            using var listener = new TestActivitySourceListener(source => source.Name.StartsWith(DiagnosticProperty.DiagnosticNamespace));

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

            var expectedTags = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>(MessagingClientDiagnostics.DestinationName, "eventHub"),
                new KeyValuePair<string, object>(MessagingClientDiagnostics.ServerAddress, "namespace"),
                new KeyValuePair<string, object>(MessagingClientDiagnostics.MessagingSystem, DiagnosticProperty.EventHubsServiceContext),
                new KeyValuePair<string, object>(DiagnosticProperty.EnqueuedTimeAttribute, enqueuedTime.ToUnixTimeMilliseconds())
            };

            var activities = listener.Activities.ToList();
            Assert.AreEqual(eventBatch.Length, activities.Count);

            foreach (var activity in activities)
            {
                Assert.AreEqual(DiagnosticProperty.EventProcessorProcessingActivityName, activity.OperationName);
                Assert.IsEmpty(activity.Links);
                Assert.That(expectedTags, Is.SubsetOf(activity.TagObjects.ToList()));
                Assert.AreEqual(ActivityKind.Consumer, activity.Kind);
            }
            cancellationSource.Cancel();
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
                    .GetMethod("UpdateCheckpointAsync", BindingFlags.Instance | BindingFlags.NonPublic, new Type[] { typeof(string), typeof(CheckpointPosition), typeof(CancellationToken) })
                    .Invoke(target, new object[] { partitionId, new CheckpointPosition(offset), cancellationToken });

        /// <summary>
        ///   Invokes the protected UpdateCheckpointAsync method on the processor client.
        /// </summary>
        ///
        /// <param name="target">The client whose method to invoke.</param>
        /// <param name="partitionId">The identifier of the partition the checkpoint is for.</param>
        /// <param name="offset">The offset to associate with the checkpoint, indicating that a processor should begin reading form the next event in the stream.</param>
        /// <param name="sequenceNumber">An optional sequence number to associate with the checkpoint, intended as informational metadata.  The <paramref name="offset" /> will be used for positioning when events are read.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal a request to cancel the operation.</param>
        ///
        private static Task InvokeOldUpdateCheckpointAsync(EventProcessorClient target,
                                                        string partitionId,
                                                        string offset,
                                                        long sequenceNumber,
                                                        CancellationToken cancellationToken) =>
            (Task)
                typeof(EventProcessorClient)
                    .GetMethod("UpdateCheckpointAsync", BindingFlags.Instance | BindingFlags.NonPublic, new Type[] { typeof(string), typeof(string), typeof(long), typeof(CancellationToken) })
                    .Invoke(target, new object[] { partitionId, offset, sequenceNumber, cancellationToken });

        /// <summary>
        /// Sets and returns the app config switch to enable Activity Source. The switch must be disposed at the end of the test.
        /// </summary>
        private static TestAppContextSwitch SetAppConfigSwitch()
        {
            var s = new TestAppContextSwitch("Azure.Experimental.EnableActivitySource", "true");
            ActivityExtensions.ResetFeatureSwitch();
            return s;
        }
    }
#endif
}
