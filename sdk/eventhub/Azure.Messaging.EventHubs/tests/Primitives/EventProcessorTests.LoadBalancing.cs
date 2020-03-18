// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;
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
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   background processing loop.
        /// </summary>
        ///
        ///
        ///
        [Test]
        public async Task BackgroundProcessingDispatchesTopLevelExceptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var expectedException = new DivideByZeroException("BOOM!");
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Throws(expectedException);

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
        public async Task BackgroundProcessinLogsTopLevelExceptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var expectedException = new DivideByZeroException("BOOM!");
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Throws(expectedException);

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
        public async Task BackgroundProcessinLogToleratesPartitionIdQueryFailure()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

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
        public async Task BackgroundProcessinLogToleratesALoadBalancingRunFailure()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

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
        public async Task BackgroundProcessinLogToleratesAnOwnershipClaimFailureWhenThePartitionIsOwned()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

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
        public async Task BackgroundProcessinLogToleratesAnOwnershipClaimFailureWhenThePartitionIsUnowned()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

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
        public async Task BackgroundProcessinLogToleratesAnOwnershipClaimFailureWhenThePartitionIsNotSet()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

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
    }
}
