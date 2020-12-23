// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Diagnostics;
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
    /// <remarks>
    ///   This segment of the partial class depends on the types and members defined in the
    ///   <c>EventProcessorTests.cs</c> file.
    /// </remarks>
    ///
    public partial class EventProcessorTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StartProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void StartProcessingRespectsACancelledToken(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            if (async)
            {
                Assert.That(async () => await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>(), "The asynchronous call should have been canceled.");
            }
            else
            {
                Assert.That(() => mockProcessor.Object.StartProcessing(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>(), "The synchronous call should have been canceled.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StartProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartProcessingStartsTheProcessing(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(Mock.Of<EventHubConnection>());

            if (async)
            {
                await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            }
            else
            {
                mockProcessor.Object.StartProcessing(cancellationSource.Token);
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(mockProcessor.Object.IsRunning, Is.True, "The processor should report that it is running.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor status should report that it is running.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object).IsCompleted, Is.False, "The task for processing should be active.");
            mockProcessor.Verify(processor => processor.CreateConnection(), Times.Once);

            // Shut the processor down to ensure resource clean-up, but ignore any errors since it isn't the
            // subject of this test.

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token).IgnoreExceptions();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StartProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartProcessingStartsTheLoadBalancer(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitions = new[] { "67", "125" };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions), mockLoadBalancer.Object) { CallBase = true };

            mockLoadBalancer.SetupAllProperties();
            mockLoadBalancer.Object.LoadBalanceInterval = TimeSpan.FromSeconds(1);

            mockLoadBalancer
                .Setup(lb => lb.RunLoadBalancingAsync(It.IsAny<string[]>(), It.IsAny<CancellationToken>()))
                .Callback(() => completionSource.TrySetResult(true))
                .ReturnsAsync(default(EventProcessorPartitionOwnership));

            mockConnection
                .Setup(connection => connection.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitions);

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            if (async)
            {
                await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            }
            else
            {
                mockProcessor.Object.StartProcessing(cancellationSource.Token);
            }

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor status should report that it is running.");

            mockLoadBalancer
                .Verify(lb => lb.RunLoadBalancingAsync(
                    It.Is<string[]>(value => Enumerable.SequenceEqual(value, partitions)),
                    It.IsAny<CancellationToken>()),
                Times.AtLeastOnce);

            // Shut the processor down to ensure resource clean-up, but ignore any errors since it isn't the
            // subject of this test.

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token).IgnoreExceptions();
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StartProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartProcessingDoesNotAttemptToStartWhenRunning(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(Mock.Of<EventHubConnection>());

            if (async)
            {
                await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            }
            else
            {
                mockProcessor.Object.StartProcessing(cancellationSource.Token);
            }

            Assert.That(mockProcessor.Object.IsRunning, Is.True, "The processor should report that it is running.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor status should report that it is running.");

            // The processor is confirmed running; attempt to start again.

            if (async)
            {
                await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            }
            else
            {
                mockProcessor.Object.StartProcessing(cancellationSource.Token);
            }

            // Only a single connection should have been created.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            mockProcessor.Verify(processor => processor.CreateConnection(), Times.Once);

            // Shut the processor down to ensure resource clean-up, but ignore any errors since it isn't the
            // subject of this test.

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token).IgnoreExceptions();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StartProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartProcessingLogsNormalStartup(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var mockEventSource = new Mock<EventHubsEventSource>() { CallBase = true };
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor.Object.Logger = mockEventSource.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(Mock.Of<EventHubConnection>());

            if (async)
            {
                await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            }
            else
            {
                mockProcessor.Object.StartProcessing(cancellationSource.Token);
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockEventSource
                .Verify(log => log.EventProcessorStart(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                Times.Once);

            mockEventSource
                .Verify(log => log.EventProcessorStartComplete(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                Times.Once);

            // Shut the processor down to ensure resource clean-up, but ignore any errors since it isn't the
            // subject of this test.

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token).IgnoreExceptions();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StartProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartProcessingLogsErrorDuringStartup(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var mockEventSource = new Mock<EventHubsEventSource>() { CallBase = true };
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockEventSource
                .Setup(log => log.EventProcessorStart(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .Callback(() => cancellationSource.Cancel());

            mockProcessor.Object.Logger = mockEventSource.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(Mock.Of<EventHubConnection>());

            if (async)
            {
                Assert.That(async () => await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>(), "Task cancellation should have been injected while starting.");
            }
            else
            {
                Assert.That(() => mockProcessor.Object.StartProcessing(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>(), "Task cancellation should have been injected while starting.");
            }

            mockEventSource
                .Verify(log => log.EventProcessorStart(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                Times.Once);

            mockEventSource
                .Verify(log => log.EventProcessorStartError(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup,
                    It.IsAny<string>()),
                Times.Once);

            mockEventSource
                .Verify(log => log.EventProcessorStartComplete(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                Times.Once);

            // Shut the processor down to ensure resource clean-up, but ignore any errors since it isn't the
            // subject of this test.

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token).IgnoreExceptions();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StopProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void StopProcessingRespectsACancelledToken(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            if (async)
            {
                Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>(), "The asynchronous call should have been canceled.");
            }
            else
            {
                Assert.That(() => mockProcessor.Object.StopProcessing(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>(), "The synchronous call should have been canceled.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StopProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StopProcessingStopsProcessing(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(Mock.Of<EventHubConnection>());

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.IsRunning, Is.True, "The processor should report that it is running.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor status should report that it is running.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object).IsCompleted, Is.False, "The task for processing should be active.");

            if (async)
            {
                await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);
            }
            else
            {
                mockProcessor.Object.StopProcessing(cancellationSource.Token);
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The processor should report that it is stopped.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.NotRunning), "The processor status should report that it is not running.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object), Is.Null, "There should be no active task for processing.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StopProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StopProcessingStopsTheLoadBalancer(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var startCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var stopCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions), mockLoadBalancer.Object) { CallBase = true };

            mockLoadBalancer.SetupAllProperties();
            mockLoadBalancer.Object.LoadBalanceInterval = TimeSpan.FromSeconds(1);

            mockLoadBalancer
                .Setup(lb => lb.RelinquishOwnershipAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Callback(() => stopCompletionSource.TrySetResult(true));

            mockConnection
                .Setup(connection => connection.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Array.Empty<string>());

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object)
                .Callback(() => startCompletionSource.TrySetResult(true));

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            await Task.WhenAny(startCompletionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor status should report that it is running.");

            if (async)
            {
                await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);
            }
            else
            {
                mockProcessor.Object.StopProcessing(cancellationSource.Token);
            }

            await Task.WhenAny(stopCompletionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.NotRunning), "The processor status should report that it is not running.");

            mockLoadBalancer
                .Verify(lb => lb.RelinquishOwnershipAsync(
                    It.IsAny<CancellationToken>()),
                Times.AtLeastOnce);

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StopProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void StopProcessingIsSafeToCallWhenNotProcessing(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            if (async)
            {
                Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.Nothing, "The asynchronous stop processing should be safe to call when not processing.");
                Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.Nothing, "The asynchronous stop processing should be safe to call when not processing.");
            }
            else
            {
                Assert.That(() => mockProcessor.Object.StopProcessing(cancellationSource.Token), Throws.Nothing, "The synchronous stop processing should be safe to call when not processing.");
                Assert.That(() => mockProcessor.Object.StopProcessing(cancellationSource.Token), Throws.Nothing, "The synchronous stop processing should be safe to call when not processing.");
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The processor should report that it is stopped.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.NotRunning), "The processor status should report that it is running.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object), Is.Null, "There should be no active task for processing.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StopProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StopProcessingIsSafeToCallAfterStopping(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(Mock.Of<EventHubConnection>());

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.IsRunning, Is.True, "The processor should report that it is running.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor status should report that it is running.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object).IsCompleted, Is.False, "The task for processing should be active.");

            if (async)
            {
                await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);
            }
            else
            {
                mockProcessor.Object.StopProcessing(cancellationSource.Token);
            }

            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The processor should report that it is stopped.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.NotRunning), "The processor status should report that it is not running.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object), Is.Null, "There should be no active task for processing.");

            if (async)
            {
                Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.Nothing, "The asynchronous stop processing should be safe to call when not processing.");
                Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.Nothing, "The asynchronous stop processing should be safe to call when not processing.");
            }
            else
            {
                Assert.That(() => mockProcessor.Object.StopProcessing(cancellationSource.Token), Throws.Nothing, "The synchronous stop processing should be safe to call when not processing.");
                Assert.That(() => mockProcessor.Object.StopProcessing(cancellationSource.Token), Throws.Nothing, "The synchronous stop processing should be safe to call when not processing.");
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been triggered.");
            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The processor should report that it is stopped.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.NotRunning), "The processor status should report that it is not running.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object), Is.Null, "There should be no active task for processing.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StopProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StopProcessingSurfacesExceptions(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new DivideByZeroException("BOOM!");
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Callback(() => completionSource.TrySetResult(true))
                .Throws(expectedException);

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            await completionSource.Task;

            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Faulted), "The processor status should report that it is in a faulted state.");

            if (async)
            {
                Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.Exception.SameAs(expectedException), "The asynchronous close call should bubble the exception.");
            }
            else
            {
                Assert.That(() => mockProcessor.Object.StopProcessing(cancellationSource.Token), Throws.Exception.SameAs(expectedException), "The synchronous close call should bubble the exception.");
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation source should not have been triggered.");
            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The processor should report that it is stopped.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.NotRunning), "The processor status should report that it is not running.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object), Is.Null, "There should be no active task for processing.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StopProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StopProcessingResetsState(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new DivideByZeroException("BOOM!");
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .SetupSequence(processor => processor.CreateConnection())
                .Throws(expectedException)
                .Returns(Mock.Of<EventHubConnection>());

            // Starting the processor should result in an exception on the first call, which should leave it in a faulted state.

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The start call should have triggered an exception.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Faulted), "The processor status should report that it is faulted.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object).IsFaulted, Is.True, "The task for processing should be faulted.");

            // The processor should not reset the faulted state when calling start a second time.

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The start call should not have been able to reset the failure state.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object).IsFaulted, Is.True, "The task for processing should be faulted.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object).IsFaulted, Is.True, "The task for processing should be faulted.");

            // Stopping the processor should clear the faulted state, as well as surface the fault.

            if (async)
            {
                Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.Exception.SameAs(expectedException), "The asynchronous close call should bubble the exception.");
            }
            else
            {
                Assert.That(() => mockProcessor.Object.StopProcessing(cancellationSource.Token), Throws.Exception.SameAs(expectedException), "The synchronous close call should bubble the exception.");
            }

            Assert.That(GetRunningProcessorTask(mockProcessor.Object), Is.Null, "There should be no active task for processing.");

            // After stopping, the processor state should be reset and it should be able to start.

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.IsRunning, Is.True, "The start call should succeed after stopping to reset the state.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor status should report that it is running.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object).IsCompleted, Is.False, "The task for processing should be active.");

            // Shut down the processor now that it is running and confirm that the second shutdown resets state.

            if (async)
            {
                await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);
            }
            else
            {
                mockProcessor.Object.StopProcessing(cancellationSource.Token);
            }

            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The processor should report that it is stopped.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.NotRunning), "The processor status should report that it is not running.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object), Is.Null, "There should be no active task for processing.");

            // Ensure that the cancellation token used to prevent test hangs didn't get signaled, which could invalidate the
            // test results.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation source should not have been triggered.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StopProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StopProcessingLogsNormalShutdown(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var mockEventSource = new Mock<EventHubsEventSource>() { CallBase = true };
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor.Object.Logger = mockEventSource.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(Mock.Of<EventHubConnection>());

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.IsRunning, Is.True, "The processor should have started.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor status should report that it is running.");

            if (async)
            {
                await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);
            }
            else
            {
                mockProcessor.Object.StopProcessing(cancellationSource.Token);
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.NotRunning), "The processor status should report that it is not running.");

            mockEventSource
                .Verify(log => log.EventProcessorStop(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                Times.Once);

            mockEventSource
                .Verify(log => log.EventProcessorStopComplete(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StopProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StopProcessingLogsErrorDuringShutdown(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var mockEventSource = new Mock<EventHubsEventSource>() { CallBase = true };
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockEventSource
                .Setup(log => log.EventProcessorStop(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .Callback(() => cancellationSource.Cancel());

            mockProcessor.Object.Logger = mockEventSource.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(default(EventHubConnection));

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.IsRunning, Is.True, "The processor should be running.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor status should report that it is running.");

            if (async)
            {
                Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>(), "The asynchronous close call should encounter an exception.");
            }
            else
            {
                Assert.That(() => mockProcessor.Object.StopProcessing(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>(), "The synchronous close call should encounter an exception.");
            }

            mockEventSource
                .Verify(log => log.EventProcessorStop(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                Times.Once);

            mockEventSource
               .Verify(log => log.EventProcessorStopError(
                   mockProcessor.Object.Identifier,
                   mockProcessor.Object.EventHubName,
                   mockProcessor.Object.ConsumerGroup,
                   It.IsAny<string>()),
               Times.Once);

            mockEventSource
                .Verify(log => log.EventProcessorStopComplete(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StopProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StopProcessingLogsFaultedTaskDuringShutdown(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new DivideByZeroException("BOOM!");
            var mockEventSource = new Mock<EventHubsEventSource>() { CallBase = true };
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor.Object.Logger = mockEventSource.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Throws(expectedException);

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The processor should have faulted during startup.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object).IsFaulted, Is.True, "The task for processing should be faulted.");

            if (async)
            {
                Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.Exception, "The asynchronous close call should encounter an exception.");
            }
            else
            {
                Assert.That(() => mockProcessor.Object.StopProcessing(cancellationSource.Token), Throws.Exception, "The synchronous close call should encounter an exception.");
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockEventSource
                .Verify(log => log.EventProcessorStop(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                Times.Once);

            mockEventSource
               .Verify(log => log.EventProcessorTaskError(
                   mockProcessor.Object.Identifier,
                   mockProcessor.Object.EventHubName,
                   mockProcessor.Object.ConsumerGroup,
                   expectedException.Message),
               Times.Once);

            mockEventSource
                .Verify(log => log.EventProcessorStopComplete(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   error handler and the <see cref="EventProcessor{TPartition}.StopProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StopProcessingIsSafeToCallInTheErrorHandler(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var capturedException = default(Exception);
            var expectedException = new DivideByZeroException("BOOM!");
            var startCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var stopCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMilliseconds(1) };
            var mockEventSource = new Mock<EventHubsEventSource>() { CallBase = true };
            var mockConnection = new Mock<EventHubConnection>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockEventSource
                .Setup(log => log.EventProcessorStopComplete(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() => stopCompletionSource.TrySetResult(true));

            mockConnection
                .SetupSequence(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Array.Empty<string>())
                .ReturnsAsync(Array.Empty<string>())
                .Returns(async () =>
                {
                    await startCompletionSource.Task;
                    throw expectedException;
                });

            mockProcessor.Object.Logger = mockEventSource.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Setup(processor => processor.StopProcessing(It.IsAny<CancellationToken>()))
                .CallBase();

            mockProcessor
                .Setup(processor => processor.StopProcessingAsync(It.IsAny<CancellationToken>()))
                .CallBase();

            mockProcessor
               .Protected()
               .Setup<Task>("OnProcessingErrorAsync", expectedException, ItExpr.IsAny<EventProcessorPartition>(), ItExpr.IsAny<string>(), ItExpr.IsAny<CancellationToken>())
               .Returns(async () =>
               {
                   try
                   {
                       if (async)
                       {
                           await mockProcessor.Object.StopProcessingAsync(CancellationToken.None);
                       }
                       else
                       {
                           mockProcessor.Object.StopProcessing(CancellationToken.None);
                       }
                   }
                   catch (Exception ex)
                   {
                       capturedException = ex;
                   }
               });

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should be running.");
            startCompletionSource.TrySetResult(true);

            await Task.WhenAny(stopCompletionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockProcessor
                .Protected()
                .Verify("OnProcessingErrorAsync", Times.Once(),
                     expectedException,
                     ItExpr.IsNull<EventProcessorPartition>(),
                     Resources.OperationGetPartitionIds,
                     CancellationToken.None);

            if (async)
            {
                mockProcessor
                    .Verify(processor => processor.StopProcessingAsync(
                        CancellationToken.None),
                    Times.Once);
            }
            else
            {
                mockProcessor
                    .Verify(processor => processor.StopProcessing(
                        CancellationToken.None),
                    Times.Once);
            }

            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.NotRunning), "The processor should not be running.");
            Assert.That(capturedException, Is.Null, "No exception should have occurred when stopping the processor.");

            cancellationSource.Cancel();
        }
    }
}
