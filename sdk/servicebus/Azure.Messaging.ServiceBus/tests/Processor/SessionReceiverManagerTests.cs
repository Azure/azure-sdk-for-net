// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Processor
{
    public class SessionReceiverManagerTests
    {
        [TestCase(true, ServiceBusReceiveMode.ReceiveAndDelete)]
        [TestCase(true, ServiceBusReceiveMode.PeekLock)]
        [TestCase(false, ServiceBusReceiveMode.ReceiveAndDelete)]
        [TestCase(false, ServiceBusReceiveMode.PeekLock)]
        public async Task HealthySessionReceiverSurvivesStopStartButNotProcessorDisposal(
            bool fixedSession,
            ServiceBusReceiveMode receiveMode)
        {
            var messages = new ConcurrentQueue<ServiceBusReceivedMessage>();
            var firstReceived = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var secondReceived = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var errors = new ConcurrentQueue<ProcessErrorEventArgs>();
            var closed = 0;
            var receiver = new Mock<TransportReceiver>();
            receiver.SetupGet(receiver => receiver.IsClosed).Returns(() => Volatile.Read(ref closed) != 0);
            receiver.SetupGet(receiver => receiver.SessionId).Returns("session");
            receiver.SetupGet(receiver => receiver.SessionLockedUntil).Returns(DateTimeOffset.UtcNow.AddMinutes(5));
            receiver.Setup(receiver => receiver.OpenLinkAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            receiver.Setup(receiver => receiver.ReceiveMessagesAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Returns(async (int count, TimeSpan? wait, CancellationToken cancellationToken) =>
                {
                    if (messages.TryDequeue(out var message))
                    {
                        return new[] { message };
                    }

                    await Task.Delay(Timeout.Infinite, cancellationToken);
                    return Array.Empty<ServiceBusReceivedMessage>();
                });
            receiver.Setup(receiver => receiver.CloseAsync(It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    Interlocked.Exchange(ref closed, 1);
                    return Task.CompletedTask;
                });
            var options = new ServiceBusSessionProcessorOptions
            {
                ReceiveMode = receiveMode,
                AutoCompleteMessages = false,
                MaxAutoLockRenewalDuration = TimeSpan.Zero,
                MaxConcurrentSessions = 1,
                MaxConcurrentCallsPerSession = 1
            };
            if (fixedSession)
            {
                options.SessionIds.Add("session");
            }

            await using var processor = new ServiceBusSessionProcessor(
                ServiceBusTestUtilities.GetMockedReceiverConnection(receiver), "queue", options);
            try
            {
                processor.ProcessMessageAsync += OnMessage;
                processor.ProcessErrorAsync += OnError;
                messages.Enqueue(ServiceBusModelFactory.ServiceBusReceivedMessage(messageId: "first", sessionId: "session"));
                await processor.StartProcessingAsync();
                Assert.That(await Task.WhenAny(firstReceived.Task, Task.Delay(TimeSpan.FromSeconds(10))), Is.SameAs(firstReceived.Task));
                await processor.StopProcessingAsync();
                receiver.Verify(receiver => receiver.CloseAsync(It.IsAny<CancellationToken>()), Times.Never);

                messages.Enqueue(ServiceBusModelFactory.ServiceBusReceivedMessage(messageId: "second", sessionId: "session"));
                await processor.StartProcessingAsync();
                Assert.That(await Task.WhenAny(secondReceived.Task, Task.Delay(TimeSpan.FromSeconds(10))), Is.SameAs(secondReceived.Task));
                await processor.DisposeAsync();
                receiver.Verify(receiver => receiver.CloseAsync(It.IsAny<CancellationToken>()), Times.Once);
                Assert.ThrowsAsync<ObjectDisposedException>(async () => await processor.StartProcessingAsync());
                receiver.Verify(receiver => receiver.OpenLinkAsync(It.IsAny<CancellationToken>()), Times.Once);
                Assert.That(errors, Is.Empty);
            }
            finally
            {
                if (!processor.IsClosed)
                {
                    await processor.StopProcessingAsync();
                }
                processor.ProcessMessageAsync -= OnMessage;
                processor.ProcessErrorAsync -= OnError;
            }

            Task OnMessage(ProcessSessionMessageEventArgs args)
            {
                (args.Message.MessageId == "first" ? firstReceived : secondReceived).TrySetResult(true);
                return Task.CompletedTask;
            }

            Task OnError(ProcessErrorEventArgs args)
            {
                errors.Enqueue(args);
                return Task.CompletedTask;
            }
        }

        [TestCase(true, true, ServiceBusReceiveMode.ReceiveAndDelete, 1)]
        [TestCase(true, true, ServiceBusReceiveMode.PeekLock, 1)]
        [TestCase(true, false, ServiceBusReceiveMode.ReceiveAndDelete, 1)]
        [TestCase(true, false, ServiceBusReceiveMode.PeekLock, 1)]
        [TestCase(true, true, ServiceBusReceiveMode.ReceiveAndDelete, 3)]
        [TestCase(true, true, ServiceBusReceiveMode.PeekLock, 3)]
        [TestCase(true, false, ServiceBusReceiveMode.ReceiveAndDelete, 3)]
        [TestCase(true, false, ServiceBusReceiveMode.PeekLock, 3)]
        [TestCase(false, true, ServiceBusReceiveMode.ReceiveAndDelete, 1)]
        [TestCase(false, true, ServiceBusReceiveMode.PeekLock, 1)]
        [TestCase(false, false, ServiceBusReceiveMode.ReceiveAndDelete, 1)]
        [TestCase(false, false, ServiceBusReceiveMode.PeekLock, 1)]
        public async Task ClosedSessionReceiverIsReplacedOnlyAfterLinkLoss(
            bool linkLost,
            bool fixedSession,
            ServiceBusReceiveMode receiveMode,
            int concurrentCalls)
        {
            var firstClosed = 0;
            var firstReceiveCount = 0;
            var secondReceiveCount = 0;
            var receiverCount = 0;
            var disposedErrorCount = 0;
            var enteredHandlerCount = 0;
            var sentinelReceived = false;
            var errors = new ConcurrentQueue<ProcessErrorEventArgs>();
            var handlerTokens = new ConcurrentQueue<CancellationToken>();
            var handlersEntered = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var releaseHandlers = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var lossReported = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var observation = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var first = new Mock<TransportReceiver>();
            first.SetupGet(receiver => receiver.IsClosed).Returns(() => Volatile.Read(ref firstClosed) != 0);
            first.SetupGet(receiver => receiver.IsSessionLinkClosed).Returns(() => linkLost && Volatile.Read(ref firstClosed) != 0);
            first.SetupGet(receiver => receiver.SessionId).Returns("session");
            first.SetupGet(receiver => receiver.SessionLockedUntil).Returns(DateTimeOffset.UtcNow.AddMinutes(5));
            first.Setup(receiver => receiver.OpenLinkAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            first.Setup(receiver => receiver.ReceiveMessagesAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Returns(async (int count, TimeSpan? wait, CancellationToken cancellationToken) =>
                {
                    var sequence = Interlocked.Increment(ref firstReceiveCount);
                    if (sequence <= concurrentCalls)
                    {
                        return new[] { ServiceBusModelFactory.ServiceBusReceivedMessage(messageId: $"seed-{sequence}", sessionId: "session") };
                    }

                    await Task.Delay(Timeout.Infinite, cancellationToken);
                    return Array.Empty<ServiceBusReceivedMessage>();
                });
            first.Setup(receiver => receiver.CloseAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            var second = new Mock<TransportReceiver>();
            second.SetupGet(receiver => receiver.SessionId).Returns("session");
            second.SetupGet(receiver => receiver.SessionLockedUntil).Returns(DateTimeOffset.UtcNow.AddMinutes(5));
            second.Setup(receiver => receiver.OpenLinkAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            second.Setup(receiver => receiver.ReceiveMessagesAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Returns(async (int count, TimeSpan? wait, CancellationToken cancellationToken) =>
                {
                    if (Interlocked.Increment(ref secondReceiveCount) == 1)
                    {
                        return new[] { ServiceBusModelFactory.ServiceBusReceivedMessage(messageId: "sentinel", sessionId: "session") };
                    }

                    await Task.Delay(Timeout.Infinite, cancellationToken);
                    return Array.Empty<ServiceBusReceivedMessage>();
                });
            second.Setup(receiver => receiver.CloseAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            var connection = ServiceBusTestUtilities.CreateMockConnection();
            connection.Setup(connection => connection.CreateTransportReceiver(
                    It.IsAny<string>(),
                    It.IsAny<ServiceBusRetryPolicy>(),
                    It.IsAny<ServiceBusReceiveMode>(),
                    It.IsAny<uint>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<Guid?>(),
                    It.IsAny<CancellationToken>()))
                .Returns(() => Interlocked.Increment(ref receiverCount) == 1 ? first.Object : second.Object);

            var options = new ServiceBusSessionProcessorOptions
            {
                ReceiveMode = receiveMode,
                AutoCompleteMessages = false,
                MaxAutoLockRenewalDuration = TimeSpan.Zero,
                MaxConcurrentSessions = 1,
                MaxConcurrentCallsPerSession = concurrentCalls
            };
            if (fixedSession)
            {
                options.SessionIds.Add("session");
            }

            await using var processor = new ServiceBusSessionProcessor(connection.Object, "queue", options);
            try
            {
                processor.ProcessMessageAsync += OnMessage;
                processor.ProcessErrorAsync += OnError;
                await processor.StartProcessingAsync();
                if (concurrentCalls > 1)
                {
                    var reported = await Task.WhenAny(lossReported.Task, Task.Delay(TimeSpan.FromSeconds(10)));
                    Assert.That(reported, Is.SameAs(lossReported.Task));
                    Assert.That(receiverCount, Is.EqualTo(1), "The receiver cannot be replaced while other handlers still use it.");
                    Assert.That(handlerTokens.Count, Is.EqualTo(concurrentCalls - 1));
                    Assert.That(handlerTokens, Has.All.Matches<CancellationToken>(token => token.IsCancellationRequested),
                        "Session loss must signal every in-flight handler.");
                    releaseHandlers.TrySetResult(true);
                }
                var completed = await Task.WhenAny(observation.Task, Task.Delay(TimeSpan.FromSeconds(10)));
                Assert.That(completed, Is.SameAs(observation.Task), "The processor must make progress after the first receiver closes.");
                Assert.That(sentinelReceived, Is.EqualTo(linkLost));
                Assert.That(receiverCount, Is.EqualTo(linkLost ? 2 : 1));
                Assert.That(disposedErrorCount, Is.GreaterThanOrEqualTo(1));
                Assert.That(errors, Has.All.Matches<ProcessErrorEventArgs>(error =>
                    error.ErrorSource == ServiceBusErrorSource.Receive && error.Exception is ObjectDisposedException));
                if (linkLost)
                {
                    first.Verify(receiver => receiver.CloseAsync(It.IsAny<CancellationToken>()), Times.Once);
                }
            }
            finally
            {
                handlersEntered.TrySetResult(true);
                releaseHandlers.TrySetResult(true);
                await processor.StopProcessingAsync();
                processor.ProcessMessageAsync -= OnMessage;
                processor.ProcessErrorAsync -= OnError;
            }

            async Task OnMessage(ProcessSessionMessageEventArgs args)
            {
                if (args.Message.MessageId.StartsWith("seed-", StringComparison.Ordinal))
                {
                    if (args.Message.MessageId != "seed-1")
                    {
                        handlerTokens.Enqueue(args.CancellationToken);
                    }
                    if (Interlocked.Increment(ref enteredHandlerCount) == concurrentCalls)
                    {
                        handlersEntered.TrySetResult(true);
                    }
                    await handlersEntered.Task;
                    if (args.Message.MessageId == "seed-1")
                    {
                        // Close the transport between receive calls, so the outer disposed guard runs first.
                        Interlocked.Exchange(ref firstClosed, 1);
                    }
                    else
                    {
                        await releaseHandlers.Task;
                    }
                }
                else
                {
                    sentinelReceived = true;
                    observation.TrySetResult(true);
                }
            }

            Task OnError(ProcessErrorEventArgs args)
            {
                errors.Enqueue(args);
                lossReported.TrySetResult(true);
                if (args.Exception is ObjectDisposedException &&
                    Interlocked.Increment(ref disposedErrorCount) >= 2 && !linkLost)
                {
                    observation.TrySetResult(true);
                }
                return Task.CompletedTask;
            }
        }
    }
}
