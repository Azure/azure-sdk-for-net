// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;
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
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StartProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void StartProcessingRespectsACanceledToken(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            var mockProcessor = new Mock<MinimalProcessorMock>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

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

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockProcessor = new Mock<MinimalProcessorMock>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Callback(() => completionSource.TrySetResult(true))
                .Returns(Mock.Of<EventHubConnection>());

            mockProcessor
                .Setup(processor => processor.ValidateProcessingPreconditions(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

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

            Assert.That(mockProcessor.Object.IsRunning, Is.True, "The processor should report that it is running.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor status should report that it is running.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object).IsCompleted, Is.False, "The task for processing should be active.");

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
        public async Task StartProcessingStartsTheLoadBalancer(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitions = new[] { "67", "125" };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockProcessor = new Mock<MinimalProcessorMock>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions), mockLoadBalancer.Object) { CallBase = true };

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

            mockProcessor
                .Setup(processor => processor.ValidateProcessingPreconditions(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

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

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockProcessor = new Mock<MinimalProcessorMock>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Callback(() => completionSource.TrySetResult(true))
                .Returns(Mock.Of<EventHubConnection>());

            mockProcessor
                .Setup(processor => processor.ValidateProcessingPreconditions(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            if (async)
            {
                await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            }
            else
            {
                mockProcessor.Object.StartProcessing(cancellationSource.Token);
            }

            await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);

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
        public async Task StartProcessingValidatesTheEventHubsConnectionCanBeCreated(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();

            var capturedException = default(Exception);
            var expectedException = new DivideByZeroException("The universe will now end.");
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Throws(expectedException);

            mockProcessor
                .Protected()
                .Setup<Task<EventProcessorCheckpoint>>("GetCheckpointAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(default(EventProcessorCheckpoint)));

            try
            {
                if (async)
                {
                    await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
                }
                else
                {
                    mockProcessor.Object.StartProcessing(cancellationSource.Token);
                }
            }
            catch (Exception ex)
            {
                capturedException = ex;
            }

            Assert.That(capturedException, Is.Not.Null, "An exception should have been thrown.");
            Assert.That(capturedException, Is.InstanceOf<AggregateException>(), "A validation exception should be surfaced as an AggregateException.");
            Assert.That(((AggregateException)capturedException).InnerExceptions.Count, Is.EqualTo(1), "There should have been a single validation exception.");

            var innerException = ((AggregateException)capturedException).InnerExceptions.First();
            Assert.That(innerException, Is.SameAs(expectedException), "The source of the validation exception should have been exposed.");
            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The processor should not be running after a validation exception.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StartProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartProcessingValidatesTheEventHubCanBeQueried(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();

            var capturedException = default(Exception);
            var expectedException = new DivideByZeroException("The universe will now end.");
            var mockConnection = new Mock<EventHubConnection>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                 .Protected()
                 .Setup<Task<EventProcessorCheckpoint>>("GetCheckpointAsync",
                     ItExpr.IsAny<string>(),
                     ItExpr.IsAny<CancellationToken>())
                 .Returns(Task.FromResult(default(EventProcessorCheckpoint)));

            mockConnection
                .Setup(connection => connection.GetPropertiesAsync(
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<CancellationToken>()))
                .Throws(expectedException);

            try
            {
                if (async)
                {
                    await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
                }
                else
                {
                    mockProcessor.Object.StartProcessing(cancellationSource.Token);
                }
            }
            catch (Exception ex)
            {
                capturedException = ex;
            }

            Assert.That(capturedException, Is.Not.Null, "An exception should have been thrown.");
            Assert.That(capturedException, Is.InstanceOf<AggregateException>(), "A validation exception should be surfaced as an AggregateException.");
            Assert.That(((AggregateException)capturedException).InnerExceptions.Count, Is.EqualTo(1), "There should have been a single validation exception.");

            var innerException = ((AggregateException)capturedException).InnerExceptions.First();
            Assert.That(innerException, Is.SameAs(expectedException), "The source of the validation exception should have been exposed.");
            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The processor should not be running after a validation exception.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StartProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartProcessingValidatesCheckpointsCanBeQueried(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();

            var capturedException = default(Exception);
            var expectedException = new DivideByZeroException("The universe will now end.");
            var mockConnection = new Mock<EventHubConnection>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockConnection
                .Setup(connection => connection.GetPropertiesAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new EventHubProperties(mockProcessor.Object.EventHubName, new DateTimeOffset(2015, 10, 27, 12, 0, 0, 0, TimeSpan.Zero), new[] { "0" }));

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventProcessorOptions>(),
                    It.IsAny<bool>()))
                .Returns(Mock.Of<TransportConsumer>());

            mockProcessor
                .Protected()
                .Setup("GetCheckpointAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<CancellationToken>())
                .Throws(expectedException);

            try
            {
                if (async)
                {
                    await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
                }
                else
                {
                    mockProcessor.Object.StartProcessing(cancellationSource.Token);
                }
            }
            catch (Exception ex)
            {
                capturedException = ex;
            }

            Assert.That(capturedException, Is.Not.Null, "An exception should have been thrown.");
            Assert.That(capturedException, Is.InstanceOf<AggregateException>(), "A validation exception should be surfaced as an AggregateException.");
            Assert.That(((AggregateException)capturedException).InnerExceptions.Count, Is.EqualTo(1), "There should have been a single validation exception.");

            var innerException = ((AggregateException)capturedException).InnerExceptions.First();
            Assert.That(innerException, Is.SameAs(expectedException), "The source of the validation exception should have been exposed.");
            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The processor should not be running after a validation exception.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StartProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartProcessingSurfacesMultipleValidationFailures(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();

            var capturedException = default(Exception);
            var eventHubException = new DivideByZeroException("The universe will now end.");
            var storageException = new FormatException("I find your format offensive.");
            var mockConnection = new Mock<EventHubConnection>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

             mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Protected()
                .Setup("GetCheckpointAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<CancellationToken>())
                .Throws(storageException);

            mockConnection
                .Setup(connection => connection.GetPropertiesAsync(
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<CancellationToken>()))
                .Throws(eventHubException);

            try
            {
                if (async)
                {
                    await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
                }
                else
                {
                    mockProcessor.Object.StartProcessing(cancellationSource.Token);
                }
            }
            catch (Exception ex)
            {
                capturedException = ex;
            }

            Assert.That(capturedException, Is.Not.Null, "An exception should have been thrown.");
            Assert.That(capturedException, Is.InstanceOf<AggregateException>(), "A validation exception should be surfaced as an AggregateException.");
            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The processor should not be running after a validation exception.");

            var aggregateException = (AggregateException)capturedException;
            Assert.That(aggregateException.InnerExceptions.Count, Is.EqualTo(2), "There should have been two validation exceptions.");

            var eventHubInnerException = aggregateException.InnerExceptions.Where(ex => ReferenceEquals(ex, eventHubException)).FirstOrDefault();
            Assert.That(eventHubInnerException, Is.Not.Null, "The Event Hub exception should have been surfaced.");

            var storageInnerException = aggregateException.InnerExceptions.Where(ex => ReferenceEquals(ex, storageException)).FirstOrDefault();
            Assert.That(storageInnerException, Is.Not.Null, "The storage exception should have been surfaced.");
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

            var mockEventSource = new Mock<EventHubsEventSource>();
            var mockProcessor = new Mock<MinimalProcessorMock>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

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

            var mockEventSource = new Mock<EventHubsEventSource>();
            var mockProcessor = new Mock<MinimalProcessorMock>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

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
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        public async Task StartProcessingWarnsWhenConfiguredIntervalsAreTooClose()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var loadBalancingIntervalSeconds = 30;
            var ownershipIntervalSeconds = (loadBalancingIntervalSeconds * 2) - 1;
            var partitionIds = new[] { "0" };
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromSeconds(loadBalancingIntervalSeconds), PartitionOwnershipExpirationInterval = TimeSpan.FromSeconds(ownershipIntervalSeconds) };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockConsumer = new Mock<TransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options, mockLoadBalancer.Object) { CallBase = true };

            mockLoadBalancer
                .SetupGet(lb => lb.OwnedPartitionIds)
                .Returns(partitionIds);

            mockLoadBalancer
                .SetupGet(lb => lb.OwnedPartitionCount)
                .Returns(partitionIds.Length);

            mockLoadBalancer
                .Setup(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<EventProcessorPartitionOwnership>(default(EventProcessorPartitionOwnership)));

            mockConnection
                .Setup(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitionIds);

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<EventData>(0));

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<EventHubConnection>(), It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object);

            mockProcessor
                .Setup(processor => processor.ValidateProcessingPreconditions(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            mockProcessor
                .Protected()
                .Setup<Task<EventProcessorCheckpoint>>("GetCheckpointAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(default(EventProcessorCheckpoint)));

            mockProcessor
                .Protected()
                .Setup<Task>("OnProcessingErrorAsync",
                    ItExpr.IsAny<Exception>(),
                    ItExpr.IsAny<EventProcessorPartition>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() => completionSource.TrySetResult(true));

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should have started.");

            await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            // Verify that the warning was logged and surfaced to the error handler.

            mockLogger
                .Verify(log => log.ProcessorLoadBalancingIntervalsTooCloseWarning(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    loadBalancingIntervalSeconds,
                    ownershipIntervalSeconds),
            Times.Once);

            mockProcessor
                .Protected()
                .Verify("OnProcessingErrorAsync", Times.Once(),
                    ItExpr.Is<Exception>(ex => ((ex is EventHubsException) && (ex.Message.Contains(nameof(EventProcessorOptions.LoadBalancingUpdateInterval))) && (ex.Message.Contains(nameof(EventProcessorOptions.PartitionOwnershipExpirationInterval))))),
                    ItExpr.IsAny<EventProcessorPartition>(),
                    ItExpr.Is<string>(op => op == Resources.OperationLoadBalancing),
                    ItExpr.IsAny<CancellationToken>());

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token).IgnoreExceptions();
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        [TestCase(60)]
        [TestCase(120)]
        [TestCase(240)]
        public async Task StartProcessingDoesNotWarnForAppropriateIntervals(double ownershipIntervalSeconds)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var loadBalancingIntervalSeconds = 30;
            var partitionIds = new[] { "0" };
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromSeconds(loadBalancingIntervalSeconds), PartitionOwnershipExpirationInterval = TimeSpan.FromSeconds(ownershipIntervalSeconds) };
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockConsumer = new Mock<TransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options, mockLoadBalancer.Object) { CallBase = true };

            mockLoadBalancer
                .SetupGet(lb => lb.OwnedPartitionIds)
                .Returns(partitionIds);

            mockLoadBalancer
                .SetupGet(lb => lb.OwnedPartitionCount)
                .Returns(partitionIds.Length);

            mockLoadBalancer
                .Setup(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<EventProcessorPartitionOwnership>(default(EventProcessorPartitionOwnership)));

            mockConnection
                .Setup(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitionIds);

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<EventData>(0));

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<EventHubConnection>(), It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object);

            mockProcessor
                .Setup(processor => processor.ValidateProcessingPreconditions(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            mockProcessor
                .Protected()
                .Setup<Task<EventProcessorCheckpoint>>("GetCheckpointAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(default(EventProcessorCheckpoint)));

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should have started.");

            // Wait for a small delay to give the handler time to be pinged, if needed.  Since we're testing the absence of an
            // error, there's no risk of false positive if this interval is too short.

            await Task.Delay(500);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            // Verify that the warning was logged and surfaced to the error handler.

            mockLogger
                .Verify(log => log.ProcessorLoadBalancingIntervalsTooCloseWarning(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    loadBalancingIntervalSeconds,
                    ownershipIntervalSeconds),
            Times.Never);

            mockProcessor
                .Protected()
                .Verify("OnProcessingErrorAsync", Times.Never(),
                    ItExpr.Is<Exception>(ex => ((ex is EventHubsException) && (ex.Message.Contains(nameof(EventProcessorOptions.LoadBalancingUpdateInterval))) && (ex.Message.Contains(nameof(EventProcessorOptions.PartitionOwnershipExpirationInterval))))),
                    ItExpr.IsAny<EventProcessorPartition>(),
                    ItExpr.Is<string>(op => op == Resources.OperationLoadBalancing),
                    ItExpr.IsAny<CancellationToken>());

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token).IgnoreExceptions();
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
        public void StopProcessingRespectsACanceledToken(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            var mockProcessor = new Mock<MinimalProcessorMock>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

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

            var processInvokedAfterStop = false;
            var stopCompleted = false;
            var ownedPartition = "0";
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<MinimalProcessorMock>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions), mockLoadBalancer.Object) { CallBase = true };

            mockLoadBalancer
                .SetupGet(lb => lb.OwnedPartitionIds)
                .Returns(new[] { ownedPartition });

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Returns<int, object, CancellationToken>((_, _, cancelToken) =>
                {
                    cancelToken.ThrowIfCancellationRequested<TaskCanceledException>();
                    return Task.FromResult((IReadOnlyList<EventData>)new List<EventData> { new EventData(new BinaryData(Array.Empty<byte>())), new EventData(new BinaryData(Array.Empty<byte>())) });
                });

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Setup(processor => processor.ProcessEventBatchAsync(It.IsAny<EventProcessorPartition>(), It.IsAny<IReadOnlyList<EventData>>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Callback(() =>
                {
                    if ((stopCompleted) && (!cancellationSource.Token.IsCancellationRequested))
                    {
                        processInvokedAfterStop = true;
                    }

                    completionSource.TrySetResult(true);
                })
                .Returns(Task.CompletedTask);

            mockConnection
                .Setup(connection => connection.CreateTransportConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<EventHubsRetryPolicy>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<long>(), It.IsAny<uint?>(), It.IsAny<long?>()))
                .Returns(mockConsumer.Object);

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.IsRunning, Is.True, "The processor should report that it is running.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor status should report that it is running.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object).IsCompleted, Is.False, "The task for processing should be active.");

            await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);

            if (async)
            {
                await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);
            }
            else
            {
                mockProcessor.Object.StopProcessing(cancellationSource.Token);
            }

            stopCompleted = true;

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The processor should report that it is stopped.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.NotRunning), "The processor status should report that it is not running.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object), Is.Null, "There should be no active task for processing.");
            Assert.That(GetActivePartitionProcessors(mockProcessor.Object).Count, Is.Zero, "No partition processor should be running.");
            Assert.That(processInvokedAfterStop, Is.False, "No batches should be processed after stopping.");
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
            var mockProcessor = new Mock<MinimalProcessorMock>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions), mockLoadBalancer.Object) { CallBase = true };

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

            var mockProcessor = new Mock<MinimalProcessorMock>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

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

            var mockProcessor = new Mock<MinimalProcessorMock>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

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
        public async Task StopProcessingResetsState(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new DivideByZeroException("BOOM!");
            var mockProcessor = new Mock<MinimalProcessorMock>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .SetupSequence(processor => processor.CreateConnection())
                .Throws(expectedException)
                .Returns(Mock.Of<EventHubConnection>());

            mockProcessor
                .Setup(processor => processor.ValidateProcessingPreconditions(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);

            // In a real scenario, the processor would fail validation in the cases that would cause a background task
            // fault and be observable by the call to start processing.  Because the test is injecting a mock fault in
            // a very specific location, only the background task will fail but it may not be observable immediately.
            // Spin with a short delay to allow the fault to be observed.

            while ((!cancellationSource.IsCancellationRequested) && (GetRunningProcessorTask(mockProcessor.Object) != null))
            {
                await Task.Delay(75, cancellationSource.Token);
            }

            // Starting the processor should result in an exception on the first call, which will fault and cause it to stop and
            // reset state.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation source should not have been triggered.");
            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The start call should have triggered an exception.");
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

            var mockEventSource = new Mock<EventHubsEventSource>();
            var mockProcessor = new Mock<MinimalProcessorMock>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

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

            var mockEventSource = new Mock<EventHubsEventSource>();
            var mockProcessor = new Mock<MinimalProcessorMock>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

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

            mockProcessor
                .Setup(processor => processor.ValidateProcessingPreconditions(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

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
            var mockEventSource = new Mock<EventHubsEventSource>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockProcessor = new Mock<MinimalProcessorMock>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

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

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StopProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StopProcessingLogsWarningForTokenCancellationErrors(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var firstCall = true;
            var partition = new EventProcessorPartition { PartitionId = "99" };
            var position = EventPosition.FromOffset(12);
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false, RetryOptions = new EventHubsRetryOptions { MaximumRetries = 0, MaximumDelay = TimeSpan.FromMilliseconds(5) } };
            var handlerCompletion = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockEventSource = new Mock<EventHubsEventSource>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConnection
                .Setup(connection => connection.GetPropertiesAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new EventHubProperties(mockProcessor.Object.EventHubName, new DateTimeOffset(2015, 10, 27, 12, 0, 0, 0, TimeSpan.Zero), new[] { "0" }));

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Returns(() => firstCall switch
                {
                    true => Task.FromResult<IReadOnlyList<EventData>>(new List<EventData> { new EventData("Test") }),
                    false => Task.FromResult<IReadOnlyList<EventData>>(new List<EventData>())
                });

            mockProcessor.Object.Logger = mockEventSource.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<EventHubConnection>(), It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object);

            mockProcessor
                 .Setup(processor => processor.ProcessEventBatchAsync(It.IsAny<EventProcessorPartition>(), It.IsAny<IReadOnlyList<EventData>>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                 .Callback<EventProcessorPartition, IReadOnlyList<EventData>, bool, CancellationToken>((partition, events, dispatchEmpties, cancellationToken) =>
                 {
                     if (firstCall)
                     {
                         cancellationToken.Register(() => throw new InvalidOperationException());
                         handlerCompletion.TrySetResult(true);
                         firstCall = false;
                     }
                 })
                 .Returns(Task.CompletedTask);

            mockProcessor
                .Protected()
                .Setup<Task<string[]>>("ListPartitionIdsAsync",
                    ItExpr.IsAny<EventHubConnection>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(new[] { partition.PartitionId }));

            mockProcessor
                .Protected()
                .Setup<Task<IEnumerable<EventProcessorPartitionOwnership>>>("ListOwnershipAsync",
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult<IEnumerable<EventProcessorPartitionOwnership>>(new[] {
                    new EventProcessorPartitionOwnership
                    {
                      OwnerIdentifier = mockProcessor.Object.Identifier,
                      FullyQualifiedNamespace = mockProcessor.Object.FullyQualifiedNamespace,
                      EventHubName = mockProcessor.Object.EventHubName,
                      ConsumerGroup = mockProcessor.Object.ConsumerGroup,
                      PartitionId = partition.PartitionId,
                      LastModifiedTime = DateTime.UtcNow
                    }
                }));

            mockProcessor
                .Protected()
                .Setup<Task<EventProcessorCheckpoint>>("GetCheckpointAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(default(EventProcessorCheckpoint)));

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.IsRunning, Is.True, "The processor should be running.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor status should report that it is running.");

            await Task.WhenAny(handlerCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

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
                .Verify(log => log.ProcessorStoppingCancellationWarning(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup,
                    It.IsAny<string>()),
                Times.Once);

            cancellationSource.Cancel();
        }
    }
}
