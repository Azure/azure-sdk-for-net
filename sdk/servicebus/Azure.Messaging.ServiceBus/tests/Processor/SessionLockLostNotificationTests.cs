// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Messaging.ServiceBus.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Processor
{
    [NonParallelizable]
    public class SessionLockLostNotificationTests
    {
        private TestAppContextSwitch _compatibilitySwitch;
        private bool? _previousSwitch;
        private string _previousEnvironmentValue;

        [SetUp]
        public void ResetCompatibilitySettings()
        {
            _previousSwitch = AppContext.TryGetSwitch(SessionReceiverManager.DisableEagerSessionLockLostSwitch, out bool previousSwitch)
                ? previousSwitch
                : null;
            _previousEnvironmentValue = Environment.GetEnvironmentVariable(SessionReceiverManager.DisableEagerSessionLockLostEnvironmentVariable);
            _compatibilitySwitch = new TestAppContextSwitch(SessionReceiverManager.DisableEagerSessionLockLostSwitch, "false");
            Environment.SetEnvironmentVariable(SessionReceiverManager.DisableEagerSessionLockLostEnvironmentVariable, null);
        }

        [TearDown]
        public void RestoreCompatibilitySettings()
        {
            _compatibilitySwitch.Dispose();
            if (_previousSwitch.HasValue)
            {
                // The shared helper restores any existing switch as true; preserve explicit false too.
                AppContext.SetSwitch(SessionReceiverManager.DisableEagerSessionLockLostSwitch, _previousSwitch.Value);
            }
            Environment.SetEnvironmentVariable(SessionReceiverManager.DisableEagerSessionLockLostEnvironmentVariable, _previousEnvironmentValue);
        }

        [TestCase(true, ServiceBusReceiveMode.PeekLock, 1)]
        [TestCase(true, ServiceBusReceiveMode.ReceiveAndDelete, 1)]
        [TestCase(false, ServiceBusReceiveMode.PeekLock, 1)]
        [TestCase(false, ServiceBusReceiveMode.ReceiveAndDelete, 1)]
        [TestCase(true, ServiceBusReceiveMode.PeekLock, 3)]
        [TestCase(true, ServiceBusReceiveMode.ReceiveAndDelete, 3)]
        [TestCase(false, ServiceBusReceiveMode.PeekLock, 3)]
        [TestCase(false, ServiceBusReceiveMode.ReceiveAndDelete, 3)]
        [TestCase(true, ServiceBusReceiveMode.PeekLock, 1, true)]
        [TestCase(true, ServiceBusReceiveMode.PeekLock, 1, false, true)]
        [TestCase(true, ServiceBusReceiveMode.PeekLock, 1, true, true)]
        [TestCase(true, ServiceBusReceiveMode.PeekLock, 1, false, false, true)]
        public async Task LinkLossSignalsActiveHandlersBeforeRetiringReceiver(
            bool fixedSession, ServiceBusReceiveMode receiveMode, int concurrentCalls, bool throwingCallback = false,
            bool throwingNotification = false, bool asynchronousNotification = false)
        {
            var loss = NewCompletion<Exception>();
            var exception = new ServiceBusException("Lost session link", ServiceBusFailureReason.SessionLockLost);
            var first = CreateReceiver(loss.Task, concurrentCalls, "seed");
            var second = CreateReceiver(NewCompletion<Exception>().Task, 1, "sentinel");
            var receiverCount = 0;
            var connection = CreateConnection(() => Interlocked.Increment(ref receiverCount) == 1 ? first.Object : second.Object);
            await using var processor = new ServiceBusSessionProcessor(connection, "queue", CreateOptions(fixedSession, receiveMode, concurrentCalls));
            var active = new ConcurrentQueue<ProcessSessionMessageEventArgs>();
            var errors = new ConcurrentQueue<ProcessErrorEventArgs>();
            var entered = NewCompletion<bool>();
            var release = NewCompletion<bool>();
            var notified = NewCompletion<bool>();
            var cancelled = NewCompletion<bool>();
            var notificationCompleted = NewCompletion<bool>();
            var recovered = NewCompletion<bool>();
            var eventCount = 0;
            var enteredCount = 0;
            var cancelledCount = 0;
            try
            {
                processor.ProcessMessageAsync += OnMessage;
                processor.ProcessErrorAsync += OnError;
                await processor.StartProcessingAsync();
                await Await(entered.Task);
                Assert.That(active.Count, Is.EqualTo(concurrentCalls));
                Assert.That(active, Has.All.Matches<ProcessSessionMessageEventArgs>(args => !args.CancellationToken.IsCancellationRequested));

                loss.SetResult(exception);
                await Await(notified.Task);
                await Await(cancelled.Task);
                Assert.That(active, Has.All.Matches<ProcessSessionMessageEventArgs>(args => args.CancellationToken.IsCancellationRequested));
                Assert.That(receiverCount, Is.EqualTo(1), "A lost receiver must remain assigned until its active handlers return.");
                first.Verify(receiver => receiver.CloseAsync(It.IsAny<CancellationToken>()), Times.Never);
                Assert.That(eventCount, Is.EqualTo(concurrentCalls));
                if (asynchronousNotification)
                {
                    Assert.That(notificationCompleted.Task.IsCompleted, Is.False);
                }

                release.TrySetResult(true);
                await Await(recovered.Task);
                first.Verify(receiver => receiver.CloseAsync(It.IsAny<CancellationToken>()), Times.Once);
                Assert.That(receiverCount, Is.EqualTo(2));
                Assert.That(errors.Count, Is.EqualTo(throwingCallback || throwingNotification ? 1 : 0));
                if (throwingCallback || throwingNotification)
                {
                    Assert.That(errors, Has.All.Matches<ProcessErrorEventArgs>(args => args.Exception is AggregateException));
                    foreach (var error in errors)
                    {
                        var callbacks = ((AggregateException)error.Exception).Flatten().InnerExceptions;
                        Assert.That(callbacks.Count, Is.EqualTo((throwingCallback ? 1 : 0) + (throwingNotification ? 1 : 0)));
                        if (throwingCallback)
                        {
                            Assert.That(callbacks, Has.Some.Matches<Exception>(callback => callback.Message == "Cancellation callback failed"));
                        }
                        if (throwingNotification)
                        {
                            Assert.That(callbacks, Has.Some.Matches<Exception>(callback => callback.Message == "Notification callback failed"));
                        }
                    }
                }
            }
            finally
            {
                release.TrySetResult(true);
                notificationCompleted.TrySetResult(true);
                await processor.StopProcessingAsync();
                processor.ProcessMessageAsync -= OnMessage;
                processor.ProcessErrorAsync -= OnError;
            }

            async Task OnMessage(ProcessSessionMessageEventArgs args)
            {
                if (args.Message.MessageId == "sentinel")
                {
                    recovered.TrySetResult(true);
                    return;
                }
                args.SessionLockLostAsync += OnLost;
                using var callback = args.CancellationToken.Register(OnCancelled);
                try
                {
                    active.Enqueue(args);
                    if (Interlocked.Increment(ref enteredCount) == concurrentCalls)
                    {
                        entered.TrySetResult(true);
                    }
                    await release.Task;
                }
                finally
                {
                    args.SessionLockLostAsync -= OnLost;
                }
            }

            Task OnLost(SessionLockLostEventArgs args)
            {
                Assert.That(args.Exception, Is.SameAs(exception));
                if (Interlocked.Increment(ref eventCount) == concurrentCalls)
                {
                    notified.TrySetResult(true);
                }
                if (throwingNotification)
                {
                    throw new InvalidOperationException("Notification callback failed");
                }
                return asynchronousNotification ? notificationCompleted.Task : Task.CompletedTask;
            }

            void OnCancelled()
            {
                if (Interlocked.Increment(ref cancelledCount) == concurrentCalls)
                {
                    cancelled.TrySetResult(true);
                }
                if (throwingCallback)
                {
                    throw new InvalidOperationException("Cancellation callback failed");
                }
            }

            Task OnError(ProcessErrorEventArgs args)
            {
                errors.Enqueue(args);
                return Task.CompletedTask;
            }
        }

        [TestCase(true, ServiceBusReceiveMode.PeekLock)]
        [TestCase(false, ServiceBusReceiveMode.PeekLock)]
        [TestCase(true, ServiceBusReceiveMode.ReceiveAndDelete)]
        [TestCase(false, ServiceBusReceiveMode.ReceiveAndDelete)]
        public async Task LockLossNotifiesBeforeCancellationDrivenHandlerReturns(bool fixedSession, ServiceBusReceiveMode receiveMode)
        {
            var loss = NewCompletion<Exception>();
            var first = CreateReceiver(loss.Task, 1, "seed");
            var second = CreateReceiver(NewCompletion<Exception>().Task, 1, "sentinel");
            int receiverCount = 0;
            var connection = CreateConnection(() => Interlocked.Increment(ref receiverCount) == 1 ? first.Object : second.Object);
            await using var processor = new ServiceBusSessionProcessor(connection, "queue", CreateOptions(fixedSession, receiveMode, 1));
            var entered = NewCompletion<bool>();
            var returnHandler = new TaskCompletionSource<bool>();
            var returned = NewCompletion<bool>();
            var recovered = NewCompletion<bool>();
            int events = 0;
            int eventsAtReturn = 0;
            bool cancelledBeforeReturn = false;
            try
            {
                processor.ProcessMessageAsync += OnMessage;
                processor.ProcessErrorAsync += OnError;
                await processor.StartProcessingAsync();
                await Await(entered.Task);
                loss.SetResult(new ServiceBusException("Lost session link", ServiceBusFailureReason.SessionLockLost));
                await Await(returned.Task);
                Assert.That(eventsAtReturn, Is.EqualTo(1));
                Assert.That(cancelledBeforeReturn, Is.True);
                await Await(recovered.Task);
                first.Verify(receiver => receiver.CloseAsync(It.IsAny<CancellationToken>()), Times.Once);
            }
            finally
            {
                returnHandler.TrySetResult(true);
                await processor.StopProcessingAsync();
                processor.ProcessMessageAsync -= OnMessage;
                processor.ProcessErrorAsync -= OnError;
            }

            async Task OnMessage(ProcessSessionMessageEventArgs args)
            {
                if (args.Message.MessageId == "sentinel")
                {
                    recovered.TrySetResult(true);
                    return;
                }
                args.SessionLockLostAsync += OnLost;
                using var cancellation = args.CancellationToken.Register(OnCancelled);
                try
                {
                    entered.TrySetResult(true);
                    await returnHandler.Task.ConfigureAwait(false);
                }
                finally
                {
                    eventsAtReturn = Volatile.Read(ref events);
                    cancelledBeforeReturn = args.CancellationToken.IsCancellationRequested;
                    args.SessionLockLostAsync -= OnLost;
                    returned.TrySetResult(true);
                }
            }

            void OnCancelled() => returnHandler.TrySetResult(true);
            Task OnLost(SessionLockLostEventArgs args) { Interlocked.Increment(ref events); return Task.CompletedTask; }
            Task OnError(ProcessErrorEventArgs args) { Assert.Fail(args.Exception.ToString()); return Task.CompletedTask; }
        }

        [Test]
        public async Task OptOutDoesNotSubscribeToEagerLoss()
        {
            AppContext.SetSwitch(SessionReceiverManager.DisableEagerSessionLockLostSwitch, true);
            var loss = NewCompletion<Exception>();
            var receiver = CreateReceiver(loss.Task, 1, "seed");
            await using var processor = new ServiceBusSessionProcessor(
                ServiceBusTestUtilities.GetMockedReceiverConnection(receiver), "queue", CreateOptions(true, ServiceBusReceiveMode.PeekLock, 1));
            var entered = NewCompletion<ProcessSessionMessageEventArgs>();
            var release = NewCompletion<bool>();
            var eventCount = 0;
            try
            {
                processor.ProcessMessageAsync += OnMessage;
                processor.ProcessErrorAsync += OnError;
                await processor.StartProcessingAsync();
                var args = await Await(entered.Task);
                receiver.VerifyGet(receiver => receiver.SessionLockLostTask, Times.Never);
                loss.SetResult(new ServiceBusException("Lost session link", ServiceBusFailureReason.SessionLockLost));
                Assert.That(args.CancellationToken.IsCancellationRequested, Is.False);
                Assert.That(eventCount, Is.Zero);
            }
            finally
            {
                release.TrySetResult(true);
                await processor.StopProcessingAsync();
                processor.ProcessMessageAsync -= OnMessage;
                processor.ProcessErrorAsync -= OnError;
            }

            async Task OnMessage(ProcessSessionMessageEventArgs args)
            {
                args.SessionLockLostAsync += OnLost;
                try { entered.TrySetResult(args); await release.Task; }
                finally { args.SessionLockLostAsync -= OnLost; }
            }

            Task OnLost(SessionLockLostEventArgs args) { Interlocked.Increment(ref eventCount); return Task.CompletedTask; }
            Task OnError(ProcessErrorEventArgs args) { Assert.Fail(args.Exception.ToString()); return Task.CompletedTask; }
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task RetiredReceiverCannotSignalReplacement(bool initializationFails)
        {
            var oldLoss = NewCompletion<Exception>();
            var newLoss = NewCompletion<Exception>();
            var first = CreateReceiver(oldLoss.Task, 1, "seed");
            var second = CreateReceiver(newLoss.Task, 1, "sentinel");
            var receiverCount = 0;
            var connection = CreateConnection(() => Interlocked.Increment(ref receiverCount) == 1 ? first.Object : second.Object);
            await using var processor = new ServiceBusSessionProcessor(connection, "queue", CreateOptions(true, ServiceBusReceiveMode.PeekLock, 1));
            var entered = NewCompletion<ProcessSessionMessageEventArgs>();
            var release = NewCompletion<bool>();
            var notified = NewCompletion<bool>();
            var cancelled = NewCompletion<bool>();
            var initializationCount = 0;
            var eventCount = 0;
            try
            {
                processor.ProcessMessageAsync += OnMessage;
                processor.ProcessErrorAsync += OnError;
                processor.SessionInitializingAsync += OnInitialize;
                await processor.StartProcessingAsync();
                var args = await Await(entered.Task);
                first.Verify(receiver => receiver.CloseAsync(It.IsAny<CancellationToken>()), Times.Once);
                oldLoss.SetResult(new ServiceBusException("Old receiver lost", ServiceBusFailureReason.SessionLockLost));
                Assert.That(args.CancellationToken.IsCancellationRequested, Is.False);
                Assert.That(eventCount, Is.Zero);
                newLoss.SetResult(new ServiceBusException("Replacement lost", ServiceBusFailureReason.SessionLockLost));
                await Await(notified.Task);
                await Await(cancelled.Task);
                Assert.That(args.CancellationToken.IsCancellationRequested, Is.True);
                Assert.That(eventCount, Is.EqualTo(1));
            }
            finally
            {
                release.TrySetResult(true);
                await processor.StopProcessingAsync();
                processor.ProcessMessageAsync -= OnMessage;
                processor.ProcessErrorAsync -= OnError;
                processor.SessionInitializingAsync -= OnInitialize;
            }

            Task OnInitialize(ProcessSessionEventArgs args)
            {
                if (Interlocked.Increment(ref initializationCount) == 1 && initializationFails)
                {
                    throw new InvalidOperationException("Initialization failed");
                }
                return Task.CompletedTask;
            }

            async Task OnMessage(ProcessSessionMessageEventArgs args)
            {
                if (args.Message.MessageId == "seed")
                {
                    args.ReleaseSession();
                    return;
                }
                args.SessionLockLostAsync += OnLost;
                using var cancellation = args.CancellationToken.Register(OnCancelled);
                try { entered.TrySetResult(args); await release.Task; }
                finally { args.SessionLockLostAsync -= OnLost; }
            }

            Task OnLost(SessionLockLostEventArgs args) { Interlocked.Increment(ref eventCount); notified.TrySetResult(true); return Task.CompletedTask; }
            void OnCancelled() => cancelled.TrySetResult(true);
            Task OnError(ProcessErrorEventArgs args) { Assert.That(initializationFails, Is.True); return Task.CompletedTask; }
        }

        [Test]
        public async Task LossBeforeObserverRegistrationRetiresReceiverWithoutProcessingItsMessage()
        {
            var lost = NewCompletion<Exception>();
            lost.SetResult(new ServiceBusException("Already lost", ServiceBusFailureReason.SessionLockLost));
            var first = CreateReceiver(lost.Task, 1, "seed");
            var second = CreateReceiver(NewCompletion<Exception>().Task, 1, "sentinel");
            var receiverCount = 0;
            await using var processor = new ServiceBusSessionProcessor(
                CreateConnection(() => Interlocked.Increment(ref receiverCount) == 1 ? first.Object : second.Object),
                "queue", CreateOptions(true, ServiceBusReceiveMode.PeekLock, 1));
            var recovered = NewCompletion<bool>();
            try
            {
                processor.ProcessMessageAsync += OnMessage;
                processor.ProcessErrorAsync += OnError;
                await processor.StartProcessingAsync();
                await Await(recovered.Task);
                first.Verify(receiver => receiver.ReceiveMessagesAsync(
                    It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()), Times.Never);
                first.Verify(receiver => receiver.CloseAsync(It.IsAny<CancellationToken>()), Times.Once);
            }
            finally
            {
                await processor.StopProcessingAsync();
                processor.ProcessMessageAsync -= OnMessage;
                processor.ProcessErrorAsync -= OnError;
            }

            Task OnMessage(ProcessSessionMessageEventArgs args)
            {
                Assert.That(args.Message.MessageId, Is.EqualTo("sentinel"));
                recovered.TrySetResult(true);
                return Task.CompletedTask;
            }
            Task OnError(ProcessErrorEventArgs args) { Assert.Fail(args.Exception.ToString()); return Task.CompletedTask; }
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task OperationDetectedLossSignalsAnotherActiveHandler(bool renewal)
        {
            var receiver = CreateReceiver(NewCompletion<Exception>().Task, 1, "seed");
            var detection = NewCompletion<bool>();
            var exception = new ServiceBusException("Operation detected lock loss", ServiceBusFailureReason.SessionLockLost);
            var options = CreateOptions(true, ServiceBusReceiveMode.PeekLock, renewal ? 1 : 2);
            if (renewal)
            {
                options.MaxAutoLockRenewalDuration = Timeout.InfiniteTimeSpan;
                receiver.SetupGet(receiver => receiver.SessionLockedUntil).Returns(DateTimeOffset.UtcNow.AddSeconds(5));
                receiver.Setup(receiver => receiver.RenewSessionLockAsync(It.IsAny<CancellationToken>()))
                    .Returns(async () => { await detection.Task; throw exception; });
            }
            else
            {
                var receiveCount = 0;
                receiver.Setup(receiver => receiver.ReceiveMessagesAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                    .Returns(async () =>
                    {
                        if (Interlocked.Increment(ref receiveCount) == 1)
                        {
                            return new[] { ServiceBusModelFactory.ServiceBusReceivedMessage(messageId: "seed", sessionId: "session") };
                        }
                        await detection.Task;
                        throw exception;
                    });
            }
            await using var processor = new ServiceBusSessionProcessor(
                ServiceBusTestUtilities.GetMockedReceiverConnection(receiver), "queue", options);
            var entered = NewCompletion<ProcessSessionMessageEventArgs>();
            var notified = NewCompletion<SessionLockLostEventArgs>();
            var release = NewCompletion<bool>();
            var cancelled = NewCompletion<bool>();
            try
            {
                processor.ProcessMessageAsync += OnMessage;
                processor.ProcessErrorAsync += OnError;
                await processor.StartProcessingAsync();
                var args = await Await(entered.Task);
                detection.TrySetResult(true);
                var loss = await Await(notified.Task);
                await Await(cancelled.Task);
                Assert.That(loss.Exception, Is.SameAs(exception));
                Assert.That(args.CancellationToken.IsCancellationRequested, Is.True);
                receiver.Verify(receiver => receiver.CloseAsync(It.IsAny<CancellationToken>()), Times.Never);
            }
            finally
            {
                release.TrySetResult(true);
                detection.TrySetResult(true);
                await processor.StopProcessingAsync();
                processor.ProcessMessageAsync -= OnMessage;
                processor.ProcessErrorAsync -= OnError;
            }

            async Task OnMessage(ProcessSessionMessageEventArgs args)
            {
                args.SessionLockLostAsync += OnLost;
                using var cancellation = args.CancellationToken.Register(OnCancelled);
                try { entered.TrySetResult(args); await release.Task; }
                finally { args.SessionLockLostAsync -= OnLost; }
            }
            Task OnLost(SessionLockLostEventArgs args) { notified.TrySetResult(args); return Task.CompletedTask; }
            void OnCancelled() => cancelled.TrySetResult(true);
            Task OnError(ProcessErrorEventArgs args) { Assert.That(args.Exception, Is.SameAs(exception)); return Task.CompletedTask; }
        }

        [Test]
        public async Task LocalExpiryDoesNotCancelActiveHandler()
        {
            var receiver = CreateReceiver(NewCompletion<Exception>().Task, 1, "seed");
            var expires = DateTimeOffset.UtcNow.AddMinutes(5);
            receiver.SetupGet(receiver => receiver.SessionLockedUntil).Returns(() => expires);
            receiver.Setup(receiver => receiver.RenewSessionLockAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            await using var processor = new ServiceBusSessionProcessor(
                ServiceBusTestUtilities.GetMockedReceiverConnection(receiver), "queue", CreateOptions(true, ServiceBusReceiveMode.PeekLock, 1));
            var entered = NewCompletion<ProcessSessionMessageEventArgs>();
            var notified = NewCompletion<SessionLockLostEventArgs>();
            var release = NewCompletion<bool>();
            try
            {
                processor.ProcessMessageAsync += OnMessage;
                processor.ProcessErrorAsync += OnError;
                await processor.StartProcessingAsync();
                var args = await Await(entered.Task);
                expires = DateTimeOffset.UtcNow.AddMilliseconds(100);
                await args.RenewSessionLockAsync();
                var lost = await Await(notified.Task);
                Assert.That(lost.Exception, Is.Null);
                Assert.That(args.CancellationToken.IsCancellationRequested, Is.False);
            }
            finally
            {
                release.TrySetResult(true);
                await processor.StopProcessingAsync();
                processor.ProcessMessageAsync -= OnMessage;
                processor.ProcessErrorAsync -= OnError;
            }

            async Task OnMessage(ProcessSessionMessageEventArgs args)
            {
                args.SessionLockLostAsync += OnLost;
                try { entered.TrySetResult(args); await release.Task; }
                finally { args.SessionLockLostAsync -= OnLost; }
            }

            Task OnLost(SessionLockLostEventArgs args) { notified.TrySetResult(args); return Task.CompletedTask; }
            Task OnError(ProcessErrorEventArgs args) { Assert.Fail(args.Exception.ToString()); return Task.CompletedTask; }
        }

        private static TaskCompletionSource<T> NewCompletion<T>() => new TaskCompletionSource<T>(TaskCreationOptions.RunContinuationsAsynchronously);

        private static async Task<T> Await<T>(Task<T> task)
        {
            Assert.That(await Task.WhenAny(task, Task.Delay(TimeSpan.FromSeconds(10))), Is.SameAs(task));
            return await task;
        }

        private static ServiceBusSessionProcessorOptions CreateOptions(bool fixedSession, ServiceBusReceiveMode receiveMode, int concurrentCalls)
        {
            var options = new ServiceBusSessionProcessorOptions
            {
                AutoCompleteMessages = false,
                MaxAutoLockRenewalDuration = TimeSpan.Zero,
                MaxConcurrentSessions = 1,
                MaxConcurrentCallsPerSession = concurrentCalls,
                ReceiveMode = receiveMode
            };
            if (fixedSession)
            {
                options.SessionIds.Add("session");
            }
            return options;
        }

        private static Mock<TransportReceiver> CreateReceiver(Task<Exception> loss, int seedCount, string messageId)
        {
            var receiver = new Mock<TransportReceiver>();
            var receiveCount = 0;
            receiver.SetupGet(receiver => receiver.SessionLockLostTask).Returns(loss);
            receiver.SetupGet(receiver => receiver.SessionId).Returns("session");
            receiver.SetupGet(receiver => receiver.IsSessionExclusive).Returns(true);
            receiver.SetupGet(receiver => receiver.SessionLockedUntil).Returns(DateTimeOffset.UtcNow.AddMinutes(5));
            receiver.Setup(receiver => receiver.OpenLinkAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            receiver.Setup(receiver => receiver.CloseAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            receiver.Setup(receiver => receiver.ReceiveMessagesAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Returns(async (int count, TimeSpan? wait, CancellationToken cancellationToken) =>
                {
                    if (Interlocked.Increment(ref receiveCount) <= seedCount)
                    {
                        return new[] { ServiceBusModelFactory.ServiceBusReceivedMessage(messageId: messageId, sessionId: "session") };
                    }
                    await Task.Delay(Timeout.Infinite, cancellationToken);
                    return Array.Empty<ServiceBusReceivedMessage>();
                });
            return receiver;
        }

        private static ServiceBusConnection CreateConnection(Func<TransportReceiver> createReceiver)
        {
            var connection = ServiceBusTestUtilities.CreateMockConnection();
            connection.Setup(connection => connection.CreateTransportReceiver(
                It.IsAny<string>(), It.IsAny<ServiceBusRetryPolicy>(), It.IsAny<ServiceBusReceiveMode>(), It.IsAny<uint>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<bool>(),
                It.IsAny<Guid?>(), It.IsAny<CancellationToken>())).Returns(createReceiver);
            return connection.Object;
        }
    }
}
