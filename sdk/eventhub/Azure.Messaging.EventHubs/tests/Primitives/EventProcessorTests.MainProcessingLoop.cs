﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
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
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundProcessingDispatchesTopLevelExceptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new DivideByZeroException("BOOM!");
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Throws(expectedException);

            mockProcessor
                .Setup(processor => processor.ValidateStartupAsync(
                    It.IsAny<bool>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Delay the return from the error handler by slightly longer than cancellation is triggered in
            // order to validate that the handler call does not block or delay other processor operations.

            mockProcessor
               .Protected()
               .Setup<Task>("OnProcessingErrorAsync", expectedException, ItExpr.IsAny<EventProcessorPartition>(), ItExpr.IsAny<string>(), ItExpr.IsAny<CancellationToken>())
               .Callback(() => completionSource.TrySetResult(true))
               .Returns(Task.Delay(TimeSpan.FromSeconds(20)));

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Faulted), "The processor status should report that it is in a faulted state.");

            mockProcessor
                .Protected()
                .Verify("OnProcessingErrorAsync", Times.Once(),
                     expectedException,
                     ItExpr.IsNull<EventProcessorPartition>(),
                     Resources.OperationEventProcessingLoop,
                     CancellationToken.None);

            Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.TypeOf(expectedException.GetType()));
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundProcessingLogsTopLevelExceptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new DivideByZeroException("BOOM!");
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Throws(expectedException);

            mockProcessor
                .Setup(processor => processor.ValidateStartupAsync(
                    It.IsAny<bool>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            mockLogger
                .Setup(log => log.EventProcessorTaskError(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() => completionSource.TrySetResult(true));

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Faulted), "The processor status should report that it is in a faulted state.");

            mockLogger
                .Verify(log => log.EventProcessorTaskError(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup,
                    expectedException.Message),
                Times.Once);

            Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.TypeOf(expectedException.GetType()));
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundProcessingToleratesPartitionIdQueryFailure()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new DivideByZeroException("BOOM!");
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = new Mock<EventHubConnection>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockConnection
                .Setup(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .Throws(expectedException);

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            // Delay the return from the error handler by slightly longer than cancellation is triggered in
            // order to validate that the handler call does not block or delay other processor operations.

            mockProcessor
               .Protected()
               .Setup<Task>("OnProcessingErrorAsync", expectedException, ItExpr.IsAny<EventProcessorPartition>(), ItExpr.IsAny<string>(), ItExpr.IsAny<CancellationToken>())
               .Callback(() => completionSource.TrySetResult(true))
               .Returns(Task.Delay(TimeSpan.FromSeconds(20)));

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should not fault if querying partitions fails.");

            mockProcessor
                .Protected()
                .Verify("OnProcessingErrorAsync", Times.Once(),
                     expectedException,
                     ItExpr.IsNull<EventProcessorPartition>(),
                     Resources.OperationGetPartitionIds,
                     CancellationToken.None);

            Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.Nothing);
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundProcessingToleratesALoadBalancingRunFailure()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionIds = new[] { "0", "1" };
            var expectedException = new DivideByZeroException("BOOM!");
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions), mockLoadBalancer.Object) { CallBase = true };

            mockLoadBalancer
                .Setup(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()))
                .Throws(expectedException);

            mockConnection
                .Setup(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitionIds);

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
               .Protected()
               .Setup<Task>("OnProcessingErrorAsync", expectedException, ItExpr.IsAny<EventProcessorPartition>(), ItExpr.IsAny<string>(), ItExpr.IsAny<CancellationToken>())
               .Callback(() => completionSource.TrySetResult(true))
               .Returns(Task.CompletedTask);

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should not fault if a load balancing cycle fails.");

            mockLogger
                .Verify(log => log.EventProcessorLoadBalancingError(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup,
                    expectedException.Message),
                Times.Once);

            mockProcessor
                .Protected()
                .Verify("OnProcessingErrorAsync", Times.Once(),
                     expectedException,
                     ItExpr.IsNull<EventProcessorPartition>(),
                     Resources.OperationLoadBalancing,
                     CancellationToken.None);

            Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.Nothing);
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundProcessingToleratesAnOwnershipClaimFailureWhenThePartitionIsOwned()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "27";
            var partitionIds = new[] { "0", partitionId };
            var wrappedExcepton = new NotImplementedException("BOOM!");
            var expectedException = new EventHubsException(false, "eh", "LB FAIL", EventHubsException.FailureReason.GeneralError, wrappedExcepton);
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions), mockLoadBalancer.Object) { CallBase = true };

            mockLoadBalancer
                .Setup(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()))
                .Callback(() =>
                {
                    GetActivePartitionProcessors(mockProcessor.Object).TryAdd(
                        partitionId,
                        new EventProcessor<EventProcessorPartition>.PartitionProcessor(Task.CompletedTask, new EventProcessorPartition { PartitionId = partitionId }, () => default, new CancellationTokenSource())
                    );
                })
                .Throws(expectedException);

            mockConnection
                .Setup(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitionIds);

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            // Delay the return from the error handler by slightly longer than cancellation is triggered in
            // order to validate that the handler call does not block or delay other processor operations.

            mockProcessor
               .Protected()
               .Setup<Task>("OnProcessingErrorAsync", ItExpr.IsAny<Exception>(), ItExpr.IsAny<EventProcessorPartition>(), ItExpr.IsAny<string>(), ItExpr.IsAny<CancellationToken>())
               .Callback(() => completionSource.TrySetResult(true))
               .Returns(Task.Delay(TimeSpan.FromSeconds(20)));

            expectedException.SetFailureOperation(Resources.OperationClaimOwnership);
            expectedException.SetFailureData(partitionId);

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should not fault if a load balancing cycle fails.");

            mockLogger
                .Verify(log => log.EventProcessorClaimOwnershipError(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup,
                    partitionId,
                    wrappedExcepton.Message),
                Times.Once);

            mockProcessor
                .Protected()
                .Verify("OnProcessingErrorAsync", Times.Once(),
                     wrappedExcepton,
                     ItExpr.Is<EventProcessorPartition>(part => part.PartitionId == partitionId),
                     Resources.OperationClaimOwnership,
                     CancellationToken.None);

            Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.Nothing);
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundProcessingToleratesAnOwnershipClaimFailureWhenThePartitionIsUnowned()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "27";
            var partitionIds = new[] { "0", partitionId };
            var expectedException = new EventHubsException(false, "eh", "LB FAIL", EventHubsException.FailureReason.GeneralError);
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions), mockLoadBalancer.Object) { CallBase = true };

            mockLoadBalancer
                .Setup(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()))
                .Throws(expectedException);

            mockConnection
                .Setup(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitionIds);

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            // Delay the return from the error handler by slightly longer than cancellation is triggered in
            // order to validate that the handler call does not block or delay other processor operations.

            mockProcessor
               .Protected()
               .Setup<Task>("OnProcessingErrorAsync", ItExpr.IsAny<Exception>(), ItExpr.IsAny<EventProcessorPartition>(), ItExpr.IsAny<string>(), ItExpr.IsAny<CancellationToken>())
               .Callback(() => completionSource.TrySetResult(true))
               .Returns(Task.Delay(TimeSpan.FromSeconds(20)));

            expectedException.SetFailureOperation(Resources.OperationClaimOwnership);
            expectedException.SetFailureData(partitionId);

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should not fault if a load balancing cycle fails.");

            mockLogger
                .Verify(log => log.EventProcessorClaimOwnershipError(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup,
                    partitionId,
                    expectedException.Message),
                Times.Once);

            mockProcessor
                .Protected()
                .Verify("OnProcessingErrorAsync", Times.Once(),
                     expectedException,
                     ItExpr.Is<EventProcessorPartition>(part => part.PartitionId == partitionId),
                     Resources.OperationClaimOwnership,
                     CancellationToken.None);

            Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.Nothing);
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundProcessingToleratesAnOwnershipClaimFailureWhenThePartitionIsNotSet()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionIds = new[] { "0", "13" };
            var wrappedExcepton = new NotImplementedException("BOOM!");
            var expectedException = new EventHubsException(false, "eh", "LB FAIL", EventHubsException.FailureReason.GeneralError, wrappedExcepton);
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions), mockLoadBalancer.Object) { CallBase = true };

            mockLoadBalancer
                .Setup(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()))
                .Throws(expectedException);

            mockConnection
                .Setup(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitionIds);

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            // Delay the return from the error handler by slightly longer than cancellation is triggered in
            // order to validate that the handler call does not block or delay other processor operations.

            mockProcessor
               .Protected()
               .Setup<Task>("OnProcessingErrorAsync", ItExpr.IsAny<Exception>(), ItExpr.IsAny<EventProcessorPartition>(), ItExpr.IsAny<string>(), ItExpr.IsAny<CancellationToken>())
               .Callback(() => completionSource.TrySetResult(true))
               .Returns(Task.Delay(TimeSpan.FromSeconds(20)));

            expectedException.SetFailureOperation(Resources.OperationClaimOwnership);

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should not fault if a load balancing cycle fails.");

            mockLogger
                .Verify(log => log.EventProcessorClaimOwnershipError(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup,
                    null,
                    wrappedExcepton.Message),
                Times.Once);

            mockProcessor
                .Protected()
                .Verify("OnProcessingErrorAsync", Times.Once(),
                     wrappedExcepton,
                     ItExpr.IsNull<EventProcessorPartition>(),
                     Resources.OperationClaimOwnership,
                     CancellationToken.None);

            Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.Nothing);
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundProcessingStartsProcessingForClaimedPartitions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var firstPartiton = "27";
            var secondPartition = "15";
            var partitionIds = new[] { "0", secondPartition, firstPartiton };
            var ownedPartitions = new List<string> { firstPartiton };
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMilliseconds(5) };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockConsumer = new Mock<TransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options, mockLoadBalancer.Object) { CallBase = true };

            mockLogger
                .Setup(log => log.EventProcessorPartitionProcessingStartComplete(secondPartition, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() => completionSource.TrySetResult(true));

            mockLoadBalancer
                .SetupGet(lb => lb.OwnedPartitionIds)
                .Returns(ownedPartitions);

            mockLoadBalancer
                .SetupSequence(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<EventProcessorPartitionOwnership>(new EventProcessorPartitionOwnership { PartitionId = firstPartiton }))
                .Returns(() =>
                {
                    ownedPartitions.Add(secondPartition);
                    return new ValueTask<EventProcessorPartitionOwnership>(new EventProcessorPartitionOwnership { PartitionId = secondPartition });
                })
                .Returns(() => default);

            mockConnection
                .Setup(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitionIds);

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { new EventData(new byte[] { 0x34 }) });

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<EventHubConnection>(), It.IsAny<EventProcessorOptions>()))
                .Returns(mockConsumer.Object);

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should have started.");

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            var activeProcessors = GetActivePartitionProcessors(mockProcessor.Object);
            Assert.That(activeProcessors.ContainsKey(firstPartiton), Is.True, "The partition processing for the first partition should be active.");
            Assert.That(activeProcessors.ContainsKey(secondPartition), Is.True, "The partition processing for the second partition should be active.");

            mockProcessor
                .Verify(processor => processor.CreatePartitionProcessor(
                    It.Is<EventProcessorPartition>(value => value.PartitionId == firstPartiton),
                    It.IsAny<CancellationTokenSource>(),
                    It.IsAny<EventPosition?>()),
                Times.Once);

            mockProcessor
                .Verify(processor => processor.CreatePartitionProcessor(
                    It.Is<EventProcessorPartition>(value => value.PartitionId == secondPartition),
                    It.IsAny<CancellationTokenSource>(),
                    It.IsAny<EventPosition?>()),
                Times.Once);

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token).IgnoreExceptions();
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundProcessingStopsProcessingAllPartitionsWhenShutdown()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedProcessingCalls = 2L;
            var startProcessingCalls = 0L;
            var stopProcessingCalls = 0L;
            var firstPartiton = "27";
            var secondPartition = "15";
            var partitionIds = new[] { "0", secondPartition, firstPartiton };
            var ownedPartitions = new List<string>();
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMilliseconds(15) };
            var startCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var stopCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options, mockLoadBalancer.Object) { CallBase = true };

            mockLogger
                .Setup(log => log.EventProcessorPartitionProcessingStartComplete(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() =>
                {
                    if (Interlocked.Increment(ref startProcessingCalls) >= expectedProcessingCalls)
                    {
                        startCompletionSource.TrySetResult(true);
                    }
                });

            mockLogger
                .Setup(log => log.EventProcessorPartitionProcessingStopComplete(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() =>
                {
                    if (Interlocked.Increment(ref stopProcessingCalls) >= expectedProcessingCalls)
                    {
                        stopCompletionSource.TrySetResult(true);
                    }
                });

            mockLoadBalancer
                .SetupGet(lb => lb.OwnedPartitionIds)
                .Returns(ownedPartitions);

            mockLoadBalancer
                .SetupSequence(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    ownedPartitions.Add(firstPartiton);
                    return new ValueTask<EventProcessorPartitionOwnership>(new EventProcessorPartitionOwnership { PartitionId = firstPartiton });
                })
                .Returns(() =>
                {
                    ownedPartitions.Add(secondPartition);
                    return new ValueTask<EventProcessorPartitionOwnership>(new EventProcessorPartitionOwnership { PartitionId = secondPartition });
                })
                .Returns(() => default);

            mockConnection
                .Setup(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitionIds);

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<EventHubConnection>(), It.IsAny<EventProcessorOptions>()))
                .Returns(Mock.Of<TransportConsumer>());

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should have started.");

            await Task.WhenAny(startCompletionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);
            await Task.WhenAny(stopCompletionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockProcessor
                .Protected()
                .Verify("OnPartitionProcessingStoppedAsync", Times.Once(),
                    ItExpr.Is<EventProcessorPartition>(value => value.PartitionId == firstPartiton),
                    ItExpr.IsAny<ProcessingStoppedReason>(),
                    ItExpr.IsAny<CancellationToken>());

            mockLogger
                .Verify(log => log.EventProcessorPartitionProcessingStopComplete(
                    firstPartiton,
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                Times.Once);

            mockProcessor
                .Protected()
                .Verify("OnPartitionProcessingStoppedAsync", Times.Once(),
                    ItExpr.Is<EventProcessorPartition>(value => value.PartitionId == secondPartition),
                    ItExpr.IsAny<ProcessingStoppedReason>(),
                    ItExpr.IsAny<CancellationToken>());

            mockLogger
                .Verify(log => log.EventProcessorPartitionProcessingStopComplete(
                    secondPartition,
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                Times.Once);

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundProcessingLogsHandlerErrorWhenPartitionProcessingStops()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new InvalidOperationException("BOOM goes the handler!");
            var partitionId = "27";
            var partitionIds = new[] { "0", partitionId };
            var ownedPartitions = new List<string>();
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMilliseconds(5) };
            var startCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var stopCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options, mockLoadBalancer.Object) { CallBase = true };

            mockLogger
                .Setup(log => log.EventProcessorPartitionProcessingStopComplete(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() => stopCompletionSource.TrySetResult(true));

            mockLoadBalancer
                .SetupGet(lb => lb.OwnedPartitionIds)
                .Returns(ownedPartitions);

            mockLoadBalancer
                .SetupSequence(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    ownedPartitions.Add(partitionId);
                    return new ValueTask<EventProcessorPartitionOwnership>(new EventProcessorPartitionOwnership { PartitionId = partitionId });
                })
                .Returns(() => default);

            mockConnection
                .Setup(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitionIds);

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<EventHubConnection>(), It.IsAny<EventProcessorOptions>()))
                .Callback(() => startCompletionSource.TrySetResult(true))
                .Returns(Mock.Of<TransportConsumer>());

            mockProcessor
                .Setup(processor => processor.CreatePartitionProcessor(It.IsAny<EventProcessorPartition>(), It.IsAny<CancellationTokenSource>(), It.IsAny<EventPosition?>()))
                .CallBase();

            mockProcessor
               .Protected()
               .Setup<Task>("OnPartitionProcessingStoppedAsync", ItExpr.IsAny<EventProcessorPartition>(), ItExpr.IsAny<ProcessingStoppedReason>(), ItExpr.IsAny<CancellationToken>())
               .Throws(expectedException);

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should have started.");

            await Task.WhenAny(startCompletionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);
            await Task.WhenAny(stopCompletionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockProcessor
                .Protected()
                .Verify("OnPartitionProcessingStoppedAsync", Times.Once(),
                    ItExpr.Is<EventProcessorPartition>(value => value.PartitionId == partitionId),
                    ItExpr.IsAny<ProcessingStoppedReason>(),
                    ItExpr.IsAny<CancellationToken>());

            mockProcessor
                .Protected()
                .Verify("OnProcessingErrorAsync", Times.Never(),
                    ItExpr.IsAny<Exception>(),
                    ItExpr.IsAny<EventProcessorPartition>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<CancellationToken>());

            mockLogger
                .Verify(log => log.EventProcessorPartitionProcessingStopError(
                    partitionId,
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup,
                    expectedException.Message),
                Times.Once);

            mockLogger
                .Verify(log => log.EventProcessorPartitionProcessingStopComplete(
                    partitionId,
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                Times.Once);

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundProcessingStopsProcessingForPartitionsWithLostOwnership()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var firstPartiton = "27";
            var secondPartition = "15";
            var partitionIds = new[] { "0", secondPartition, firstPartiton };
            var ownedPartitions = new List<string> { firstPartiton };
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMilliseconds(5) };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockConsumer = new Mock<TransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options, mockLoadBalancer.Object) { CallBase = true };

            mockLogger
                .Setup(log => log.EventProcessorPartitionProcessingStopComplete(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() => completionSource.TrySetResult(true));

            mockLoadBalancer
                .SetupGet(lb => lb.OwnedPartitionIds)
                .Returns(ownedPartitions);

            mockLoadBalancer
                .SetupSequence(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<EventProcessorPartitionOwnership>(new EventProcessorPartitionOwnership { PartitionId = firstPartiton }))
                .Returns(() =>
                {
                    ownedPartitions.Add(secondPartition);
                    return new ValueTask<EventProcessorPartitionOwnership>(new EventProcessorPartitionOwnership { PartitionId = secondPartition });
                })
                .Returns(() =>
                {
                    ownedPartitions.Remove(firstPartiton);
                    return default;
                })
                .Returns(() => default);

            mockConnection
                .Setup(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitionIds);

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { new EventData(new byte[] { 0x34 }) });

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<EventHubConnection>(), It.IsAny<EventProcessorOptions>()))
                .Returns(mockConsumer.Object);

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should have started.");

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            var activeProcessors = GetActivePartitionProcessors(mockProcessor.Object);
            Assert.That(activeProcessors.ContainsKey(firstPartiton), Is.False, "The partition processing for the first partition should not be active.");
            Assert.That(activeProcessors.ContainsKey(secondPartition), Is.True, "The partition processing for the second partition should be active.");

            mockProcessor
                .Verify(processor => processor.CreatePartitionProcessor(
                    It.Is<EventProcessorPartition>(value => value.PartitionId == firstPartiton),
                    It.IsAny<CancellationTokenSource>(),
                    It.IsAny<EventPosition?>()),
                Times.Once);

            mockProcessor
                .Verify(processor => processor.CreatePartitionProcessor(
                    It.Is<EventProcessorPartition>(value => value.PartitionId == secondPartition),
                    It.IsAny<CancellationTokenSource>(),
                    It.IsAny<EventPosition?>()),
                Times.Once);

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token).IgnoreExceptions();
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundProcessingRestartsProcessingForFaultedPartitions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var firstProcessorCreate = true;
            var partitionId = "27";
            var partitionIds = new[] { "0", "14", partitionId };
            var ownedPartitions = new List<string> { partitionId };
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMilliseconds(5) };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockConsumer = new Mock<TransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options, mockLoadBalancer.Object) { CallBase = true };

            mockLoadBalancer
                .SetupGet(lb => lb.OwnedPartitionIds)
                .Returns(ownedPartitions);

            mockLoadBalancer
                .SetupSequence(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<EventProcessorPartitionOwnership>(new EventProcessorPartitionOwnership { PartitionId = partitionId }))
                .Returns(() => default);

            mockConnection
                .Setup(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitionIds);

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { new EventData(new byte[] { 0x34 }) });

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<EventHubConnection>(), It.IsAny<EventProcessorOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor
                .Setup(processor => processor.CreatePartitionProcessor(It.IsAny<EventProcessorPartition>(), It.IsAny<CancellationTokenSource>(), It.IsAny<EventPosition?>()))
                .Returns((EventProcessorPartition partition, CancellationTokenSource source, EventPosition? overridePosition) =>
                {
                    if (firstProcessorCreate)
                    {
                        firstProcessorCreate = false;
                        return new EventProcessor<EventProcessorPartition>.PartitionProcessor(Task.FromException(new DivideByZeroException()), partition, () => default, source);
                    }

                    completionSource.TrySetResult(true);
                    return new EventProcessor<EventProcessorPartition>.PartitionProcessor(Task.CompletedTask, partition, () => default, source);
                });

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should have started.");

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockProcessor
                .Verify(processor => processor.CreatePartitionProcessor(
                    It.Is<EventProcessorPartition>(value => value.PartitionId == partitionId),
                    It.IsAny<CancellationTokenSource>(),
                    It.IsAny<EventPosition?>()),
                Times.Exactly(2));

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token).IgnoreExceptions();
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundProcessingUsesCheckpointsWhenProcessingPartitions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedStartingPosition = EventPosition.FromOffset(775, true);
            var partitionId = "27";
            var partitionIds = new[] { "0", partitionId, "11" };
            var ownedPartitions = new List<string> { partitionId };
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMilliseconds(5) };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options, mockLoadBalancer.Object) { CallBase = true };

            mockLoadBalancer
                .SetupGet(lb => lb.OwnedPartitionIds)
                .Returns(ownedPartitions);

            mockLoadBalancer
                .SetupSequence(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<EventProcessorPartitionOwnership>(new EventProcessorPartitionOwnership { PartitionId = partitionId }))
                .Returns(() => default);

            mockConnection
                .Setup(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitionIds);

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<EventHubConnection>(), It.IsAny<EventProcessorOptions>()))
                .Returns(Mock.Of<TransportConsumer>())
                .Callback(() => completionSource.TrySetResult(true));

            mockProcessor
                .Protected()
                .Setup<Task<IEnumerable<EventProcessorCheckpoint>>>("ListCheckpointsAsync", ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new[] { new EventProcessorCheckpoint { PartitionId = partitionId, StartingPosition = expectedStartingPosition } });

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should have started.");

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockProcessor
                .Verify(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), expectedStartingPosition, mockConnection.Object, It.IsAny<EventProcessorOptions>()),
                Times.Once);

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token).IgnoreExceptions();
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundProcessingDelegatesInitializationWhenProcessingClaimedPartitions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedDescription = "This is a custom partition.";
            var partitionId = "27";
            var partitionIds = new[] { "0", partitionId, "77" };
            var ownedPartitions = new List<string> { partitionId };
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMilliseconds(5) };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockProcessor = new Mock<EventProcessor<CustomPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options, mockLoadBalancer.Object) { CallBase = true };

            mockLoadBalancer
                .SetupGet(lb => lb.OwnedPartitionIds)
                .Returns(ownedPartitions);

            mockLoadBalancer
                .SetupSequence(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<EventProcessorPartitionOwnership>(new EventProcessorPartitionOwnership { PartitionId = partitionId }))
                .Returns(() => default);

            mockConnection
                .Setup(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitionIds);

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<EventHubConnection>(), It.IsAny<EventProcessorOptions>()))
                .Returns(Mock.Of<TransportConsumer>())
                .Callback(() => completionSource.TrySetResult(true));

            mockProcessor
                .Protected()
                .Setup<Task>("OnInitializingPartitionAsync", ItExpr.IsAny<CustomPartition>(), ItExpr.IsAny<CancellationToken>())
                .Returns((CustomPartition partition, CancellationToken token) =>
                {
                    partition.Description = expectedDescription;
                    return Task.CompletedTask;
                });

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should have started.");

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockProcessor
                .Verify(processor => processor.CreatePartitionProcessor(
                    It.Is<CustomPartition>(value => ((value.PartitionId == partitionId) && (value.Description == expectedDescription))),
                    It.IsAny<CancellationTokenSource>(),
                    It.IsAny<EventPosition?>()),
                Times.Once);

            mockProcessor
                .Protected()
                .Verify("OnInitializingPartitionAsync", Times.Once(),
                    ItExpr.Is<CustomPartition>(value => ((value.PartitionId == partitionId) && (value.Description == expectedDescription))),
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
        public async Task BackgroundProcessingLogsWhenStartingToProcessClaimedPartitions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "27";
            var partitionIds = new[] { "0", partitionId, "111" };
            var ownedPartitions = new List<string> { partitionId };
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMilliseconds(5) };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockConsumer = new Mock<TransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options, mockLoadBalancer.Object) { CallBase = true };

            mockLoadBalancer
                .SetupGet(lb => lb.OwnedPartitionIds)
                .Returns(ownedPartitions);

            mockLoadBalancer
                .SetupSequence(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<EventProcessorPartitionOwnership>(new EventProcessorPartitionOwnership { PartitionId = partitionId }))
                .Returns(() => default);

            mockConnection
                .Setup(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitionIds);

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { new EventData(new byte[] { 0x34 }) })
                .Callback(() => completionSource.TrySetResult(true));

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<EventHubConnection>(), It.IsAny<EventProcessorOptions>()))
                .Returns(mockConsumer.Object);

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should have started.");

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockLogger
                .Verify(log => log.EventProcessorPartitionProcessingStart(
                    partitionId,
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                 Times.Once);

            mockLogger
                .Verify(log => log.EventProcessorPartitionProcessingStartComplete(
                    partitionId,
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                 Times.Once);

            mockProcessor
                .Verify(processor => processor.CreatePartitionProcessor(
                    It.Is<EventProcessorPartition>(value => value.PartitionId == partitionId),
                    It.IsAny<CancellationTokenSource>(),
                    It.IsAny<EventPosition?>()),
                Times.Once);

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token).IgnoreExceptions();
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundProcessingLogsWhenStartingToProcessClaimedPartitionsFails()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var firstProcessorCreate = true;
            var expectedException = new FormatException("This was a bad idea");
            var partitionId = "27";
            var partitionIds = new[] { "0", partitionId, "111" };
            var ownedPartitions = new List<string> { partitionId };
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMilliseconds(5) };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options, mockLoadBalancer.Object) { CallBase = true };

            mockLogger
                .Setup(log => log.EventProcessorPartitionProcessingStartError(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() => completionSource.TrySetResult(true));

            mockLoadBalancer
                .SetupGet(lb => lb.OwnedPartitionIds)
                .Returns(ownedPartitions);

            mockLoadBalancer
                .SetupSequence(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<EventProcessorPartitionOwnership>(new EventProcessorPartitionOwnership { PartitionId = partitionId }))
                .Returns(() => default);

            mockConnection
                .Setup(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitionIds);

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<EventHubConnection>(), It.IsAny<EventProcessorOptions>()))
                .Returns(Mock.Of<TransportConsumer>());

            mockProcessor
                .Setup(processor => processor.CreatePartitionProcessor(It.IsAny<EventProcessorPartition>(), It.IsAny<CancellationTokenSource>(), It.IsAny<EventPosition?>()))
                .Returns((EventProcessorPartition partition, CancellationTokenSource cancellation, EventPosition? overridePosition) =>
                {
                    if (firstProcessorCreate)
                    {
                        firstProcessorCreate = false;
                        throw expectedException;
                    }

                    return new EventProcessor<EventProcessorPartition>.PartitionProcessor(Task.Delay(Timeout.Infinite, cancellation.Token), partition, () => default, cancellation);
                });

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should have started.");

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockLogger
                .Verify(log => log.EventProcessorPartitionProcessingStartError(
                    partitionId,
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup,
                    expectedException.Message),
                 Times.Once);

            mockLogger
                .Verify(log => log.EventProcessorPartitionProcessingStartComplete(
                    partitionId,
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                 Times.Exactly(2));

            mockProcessor
                .Verify(processor => processor.CreatePartitionProcessor(
                    It.Is<EventProcessorPartition>(value => value.PartitionId == partitionId),
                    It.IsAny<CancellationTokenSource>(),
                    It.IsAny<EventPosition?>()),
                Times.Exactly(2));

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token).IgnoreExceptions();
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundProcessingDispatchesExceptionsWhenStartingToProcessClaimedPartitionsFails()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var firstProcessorCreate = true;
            var expectedException = new FormatException("This was a bad idea");
            var partitionId = "27";
            var partitionIds = new[] { "0", partitionId, "111" };
            var ownedPartitions = new List<string> { partitionId };
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMilliseconds(5) };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options, mockLoadBalancer.Object) { CallBase = true };

            mockLoadBalancer
                 .SetupGet(lb => lb.OwnedPartitionIds)
                 .Returns(ownedPartitions);

            mockLoadBalancer
                .SetupSequence(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<EventProcessorPartitionOwnership>(new EventProcessorPartitionOwnership { PartitionId = partitionId }))
                .Returns(() => default);

            mockConnection
                .Setup(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitionIds);

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<EventHubConnection>(), It.IsAny<EventProcessorOptions>()))
                .Returns(Mock.Of<TransportConsumer>());

            mockProcessor
                .Setup(processor => processor.CreatePartitionProcessor(It.IsAny<EventProcessorPartition>(), It.IsAny<CancellationTokenSource>(), It.IsAny<EventPosition?>()))
                .Returns((EventProcessorPartition partition, CancellationTokenSource cancellation, EventPosition? overridePosition) =>
                {
                    if (firstProcessorCreate)
                    {
                        firstProcessorCreate = false;
                        throw expectedException;
                    }

                    return new EventProcessor<EventProcessorPartition>.PartitionProcessor(Task.Delay(Timeout.Infinite, cancellation.Token), partition, () => default, cancellation);
                });

            mockProcessor
                .Protected()
                .Setup<Task>("OnProcessingErrorAsync", ItExpr.IsAny<Exception>(), ItExpr.IsAny<EventProcessorPartition>(), ItExpr.IsAny<string>(), ItExpr.IsAny<CancellationToken>())
                .Callback(() => completionSource.TrySetResult(true))
                .Returns(Task.CompletedTask);

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should have started.");

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            // Because load balancing will attempt to recover, allow for multiple log attempts, making sure that logging occurs at least once.

            mockProcessor
                .Protected()
                .Verify("OnProcessingErrorAsync", Times.Once(),
                    expectedException,
                    ItExpr.Is<EventProcessorPartition>(value => value.PartitionId == partitionId),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<CancellationToken>());

            mockProcessor
                .Verify(processor => processor.CreatePartitionProcessor(
                    It.Is<EventProcessorPartition>(value => value.PartitionId == partitionId),
                    It.IsAny<CancellationTokenSource>(),
                    It.IsAny<EventPosition?>()),
                Times.Exactly(2));

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token).IgnoreExceptions();
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundProcessingLogsWhenSurrenderingClaimedPartitions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "27";
            var partitionIds = new[] { "0", partitionId, "111" };
            var ownedPartitions = new List<string> { partitionId };
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMilliseconds(5) };
            var startCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var stopCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options, mockLoadBalancer.Object) { CallBase = true };

            mockLogger
                .Setup(log => log.EventProcessorPartitionProcessingStopComplete(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() => stopCompletionSource.TrySetResult(true));

            mockLoadBalancer
                .SetupGet(lb => lb.OwnedPartitionIds)
                .Returns(ownedPartitions);

            mockLoadBalancer
                .SetupSequence(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<EventProcessorPartitionOwnership>(new EventProcessorPartitionOwnership { PartitionId = partitionId }))
                .Returns(() => default);

            mockConnection
                .Setup(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitionIds);

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<EventHubConnection>(), It.IsAny<EventProcessorOptions>()))
                .Returns(Mock.Of<TransportConsumer>())
                .Callback(() => startCompletionSource.TrySetResult(true));

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should have started.");

            await Task.WhenAny(startCompletionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);
            await Task.WhenAny(stopCompletionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockLogger
                .Verify(log => log.EventProcessorPartitionProcessingStop(
                    partitionId,
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                 Times.Once);

            mockLogger
                .Verify(log => log.EventProcessorPartitionProcessingStopComplete(
                    partitionId,
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                 Times.Once);

            mockProcessor
                .Verify(processor => processor.CreatePartitionProcessor(
                    It.Is<EventProcessorPartition>(value => value.PartitionId == partitionId),
                    It.IsAny<CancellationTokenSource>(),
                    It.IsAny<EventPosition?>()),
                Times.Once);

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundProcessingDelegatesStopNotificationWhenSurrenderingClaimedPartitions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "27";
            var partitionIds = new[] { "0", partitionId, "111" };
            var ownedPartitions = new List<string> { partitionId };
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMilliseconds(5) };
            var startCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var stopCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options, mockLoadBalancer.Object) { CallBase = true };

            mockLogger
                .Setup(log => log.EventProcessorPartitionProcessingStopComplete(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() => stopCompletionSource.TrySetResult(true));

            mockLoadBalancer
                .SetupGet(lb => lb.OwnedPartitionIds)
                .Returns(ownedPartitions);

            mockLoadBalancer
                .SetupSequence(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<EventProcessorPartitionOwnership>(new EventProcessorPartitionOwnership { PartitionId = partitionId }))
                .Returns(() => default);

            mockConnection
                .Setup(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitionIds);

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<EventHubConnection>(), It.IsAny<EventProcessorOptions>()))
                .Returns(Mock.Of<TransportConsumer>())
                .Callback(() => startCompletionSource.TrySetResult(true));

            mockProcessor.Object.Logger = mockLogger.Object;

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should have started.");

            await Task.WhenAny(startCompletionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);
            await Task.WhenAny(stopCompletionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockProcessor
                .Protected()
                .Verify("OnPartitionProcessingStoppedAsync", Times.Once(),
                    ItExpr.Is<EventProcessorPartition>(value => value.PartitionId == partitionId),
                    ProcessingStoppedReason.Shutdown,
                    ItExpr.IsAny<CancellationToken>());

            mockProcessor
                .Verify(processor => processor.CreatePartitionProcessor(
                    It.Is<EventProcessorPartition>(value => value.PartitionId == partitionId),
                    It.IsAny<CancellationTokenSource>(),
                    It.IsAny<EventPosition?>()),
                Times.Once);

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        public async Task LoadBalancingAppliesTheGreedyStrategy()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var firstPartiton = "27";
            var secondPartition = "15";
            var partitionIds = new[] { "0", secondPartition, firstPartiton };
            var ownedPartitions = new List<string>();
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromDays(5), LoadBalancingStrategy = LoadBalancingStrategy.Greedy };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockConsumer = new Mock<TransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options, mockLoadBalancer.Object) { CallBase = true };

            mockLoadBalancer
                .SetupGet(lb => lb.OwnedPartitionIds)
                .Returns(ownedPartitions);

            mockLoadBalancer
                .SetupGet(lb => lb.IsBalanced)
                .Returns(() => ownedPartitions.Count >= 2);

            mockLoadBalancer
                .SetupSequence(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    ownedPartitions.Add(firstPartiton);
                    return new ValueTask<EventProcessorPartitionOwnership>(new EventProcessorPartitionOwnership { PartitionId = firstPartiton });
                })
                .Returns(() =>
                {
                    ownedPartitions.Add(secondPartition);
                    return new ValueTask<EventProcessorPartitionOwnership>(new EventProcessorPartitionOwnership { PartitionId = secondPartition });
                })
                .Returns(() =>
                {
                    completionSource.TrySetResult(true);
                    return new ValueTask<EventProcessorPartitionOwnership>(default(EventProcessorPartitionOwnership));
                });

            mockConnection
                .Setup(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitionIds);

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { new EventData(new byte[] { 0x34 }) });

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<EventHubConnection>(), It.IsAny<EventProcessorOptions>()))
                .Returns(mockConsumer.Object);

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should have started.");

            // Wait for the load balancer to be called multiple times; if the completion source is set before cancellation, then
            // the load balancing update interval is not being applied and the greedy strategy is overriding.

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token).IgnoreExceptions();
            cancellationSource.Cancel();

            Assert.That(ownedPartitions.Count, Is.EqualTo(2), "There should be two owned partitions.");
            Assert.That(ownedPartitions.Contains(firstPartiton), Is.True, "The first partition should be owned.");
            Assert.That(ownedPartitions.Contains(secondPartition), Is.True, "The second partition should be owned.");

            mockLoadBalancer
                .Verify(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()), Times.Exactly(3), "The load balancer did not run the correct number of cycles.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        public async Task LoadBalancingWhenGreedyAppliesTheTimeoutAfterBalance()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionIds = new[] { "0", "1", "2" };
            var ownedPartitions = new List<string>();
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromDays(5), LoadBalancingStrategy = LoadBalancingStrategy.Greedy };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockConsumer = new Mock<TransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options, mockLoadBalancer.Object) { CallBase = true };

            mockLoadBalancer
                .SetupGet(lb => lb.OwnedPartitionIds)
                .Returns(ownedPartitions);

            mockLoadBalancer
                .SetupGet(lb => lb.IsBalanced)
                .Returns(() => ownedPartitions.Count >= 1);

            mockLoadBalancer
                .SetupSequence(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    ownedPartitions.Add(partitionIds[2]);
                    return new ValueTask<EventProcessorPartitionOwnership>(new EventProcessorPartitionOwnership { PartitionId = partitionIds[2] });
                })
                .Returns(() =>
                {
                    ownedPartitions.Add(partitionIds[0]);
                    return new ValueTask<EventProcessorPartitionOwnership>(new EventProcessorPartitionOwnership { PartitionId = partitionIds[0] });
                })
                .Returns(() =>
                {
                    completionSource.TrySetResult(true);
                    return new ValueTask<EventProcessorPartitionOwnership>(default(EventProcessorPartitionOwnership));
                });

            mockConnection
                .Setup(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitionIds);

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { new EventData(new byte[] { 0x34 }) });

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<EventHubConnection>(), It.IsAny<EventProcessorOptions>()))
                .Returns(mockConsumer.Object);

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should have started.");

            // The load balancer should be called until no partition was claimed and then the interval should be applied; because the interval
            // is unreasonably long, the final call to the load balancer should not occur and the completion source should never be set.

            var delayTask = Task.Delay(TimeSpan.FromSeconds(1), cancellationSource.Token);
            var completedTask = await Task.WhenAny(completionSource.Task, delayTask);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(completedTask, Is.SameAs(delayTask), "The completion source should have timed out because the load balancing interval should not have passed.");

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token).IgnoreExceptions();
            cancellationSource.Cancel();

            Assert.That(ownedPartitions.Count, Is.EqualTo(1), "There should be a single owned partition.");
            Assert.That(ownedPartitions.Contains(partitionIds[2]), Is.True, "The last partition should be owned.");

            // Because the load balancer is signaling that it is in a balanced state after the first claim, there should be no
            // attempts to claim again within the time period allowed by the test.

            mockLoadBalancer
                .Verify(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()), Times.Once(), "The load balancer did not run the correct number of cycles.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        [Test]
        public async Task LoadBalancingAppliesTheBalancedStrategy()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var firstPartiton = "27";
            var secondPartition = "15";
            var partitionIds = new[] { "0", secondPartition, firstPartiton };
            var ownedPartitions = new List<string>();
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromDays(5), LoadBalancingStrategy = LoadBalancingStrategy.Balanced };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockConnection = new Mock<EventHubConnection>();
            var mockConsumer = new Mock<TransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options, mockLoadBalancer.Object) { CallBase = true };

            mockLoadBalancer
                .SetupGet(lb => lb.OwnedPartitionIds)
                .Returns(ownedPartitions);

            mockLoadBalancer
                .SetupGet(lb => lb.IsBalanced)
                .Returns(() => ownedPartitions.Count == 2);

            mockLoadBalancer
                .SetupSequence(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    ownedPartitions.Add(firstPartiton);
                    return new ValueTask<EventProcessorPartitionOwnership>(new EventProcessorPartitionOwnership { PartitionId = firstPartiton });
                })
                .Returns(() =>
                {
                    ownedPartitions.Add(secondPartition);
                    return new ValueTask<EventProcessorPartitionOwnership>(new EventProcessorPartitionOwnership { PartitionId = secondPartition });
                })
                .Returns(() =>
                {
                    completionSource.TrySetResult(true);
                    return new ValueTask<EventProcessorPartitionOwnership>(default(EventProcessorPartitionOwnership));
                });

            mockConnection
                .Setup(conn => conn.GetPartitionIdsAsync(It.IsAny<EventHubsRetryPolicy>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitionIds);

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { new EventData(new byte[] { 0x34 }) });

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<EventHubConnection>(), It.IsAny<EventProcessorOptions>()))
                .Returns(mockConsumer.Object);

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor should have started.");

            // The load balancer should be called once and then the interval should be applied; because the interval is unreasonably long,
            // the final call to the load balancer should not occur and the completion source should never be set.

            var delayTask = Task.Delay(TimeSpan.FromSeconds(1), cancellationSource.Token);
            var completedTask = await Task.WhenAny(completionSource.Task, delayTask);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(completedTask, Is.SameAs(delayTask), "The completion source should have timed out because the load balancing interval should not have passed.");

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token).IgnoreExceptions();
            cancellationSource.Cancel();

            Assert.That(ownedPartitions.Count, Is.EqualTo(1), "There should be a single owned partition.");
            Assert.That(ownedPartitions[0], Is.EqualTo(firstPartiton), "The first partition should be owned.");

            mockLoadBalancer
                .Verify(lb => lb.RunLoadBalancingAsync(partitionIds, It.IsAny<CancellationToken>()), Times.Once(), "The load balancer did not run a single cycle.");
        }
    }
}
