// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.ServiceBus.Listeners;
using Microsoft.Azure.WebJobs.Host.EndToEndTests;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests.Listeners
{
    [TestFixture]
    [NUnit.Framework.Timeout(10000)]
    public class BatchLockRenewalManagerTests
    {
        [TestCase(300000)]
        [TestCase(-1)]
        public async Task RenewsWithDefaultOrInfiniteBudgetAndStopsOnCompletion(int durationMilliseconds)
        {
            var receiver = new Mock<ServiceBusReceiver>();
            var message = ServiceBusModelFactory.ServiceBusReceivedMessage(lockedUntil: DateTimeOffset.UtcNow);
            var invoked = new TaskCompletionSource<CancellationToken>(TaskCreationOptions.RunContinuationsAsynchronously);
            receiver.Setup(r => r.RenewMessageLockAsync(message, It.IsAny<CancellationToken>()))
                .Returns((ServiceBusReceivedMessage _, CancellationToken token) => BlockRenewalAsync(invoked, token));
            var manager = CreateManager(TimeSpan.FromMilliseconds(durationMilliseconds));
            try
            {
                manager.Start(message, receiver.Object);
                var token = await invoked.Task;
                Assert.IsFalse(token.IsCancellationRequested);
                await manager.StopAsync(message);
                Assert.IsTrue(token.IsCancellationRequested);
                receiver.Verify(r => r.RenewMessageLockAsync(message, It.IsAny<CancellationToken>()), Times.Once);
            }
            finally
            {
                await manager.StopAllAsync();
            }
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task DoesNotRenewWhenDisabledOrReceiveAndDelete(bool receiveAndDelete)
        {
            var receiver = new Mock<ServiceBusReceiver>();
            receiver.SetupGet(r => r.ReceiveMode).Returns(receiveAndDelete ? ServiceBusReceiveMode.ReceiveAndDelete : ServiceBusReceiveMode.PeekLock);
            var message = ServiceBusModelFactory.ServiceBusReceivedMessage(lockedUntil: DateTimeOffset.UtcNow);
            var manager = CreateManager(receiveAndDelete ? TimeSpan.FromMinutes(5) : TimeSpan.Zero);
            manager.Start(message, receiver.Object);
            await manager.StopAllAsync();
            receiver.Verify(r => r.RenewMessageLockAsync(It.IsAny<ServiceBusReceivedMessage>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Test]
        public async Task RenewalBudgetCancelsAnInProgressRenewal()
        {
            var receiver = new Mock<ServiceBusReceiver>();
            var message = ServiceBusModelFactory.ServiceBusReceivedMessage(lockedUntil: DateTimeOffset.UtcNow);
            var invoked = new TaskCompletionSource<CancellationToken>(TaskCreationOptions.RunContinuationsAsynchronously);
            var canceled = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            receiver.Setup(r => r.RenewMessageLockAsync(message, It.IsAny<CancellationToken>()))
                .Returns(async (ServiceBusReceivedMessage _, CancellationToken token) =>
                {
                    try
                    {
                        await BlockRenewalAsync(invoked, token);
                    }
                    finally
                    {
                        canceled.TrySetResult(token.IsCancellationRequested);
                    }
                });
            var manager = CreateManager(TimeSpan.FromSeconds(1));
            try
            {
                manager.Start(message, receiver.Object);
                await invoked.Task;
                Assert.IsTrue(await canceled.Task);
            }
            finally
            {
                await manager.StopAllAsync();
            }
        }

        [Test]
        public async Task ListenerCancellationStopsRenewal()
        {
            using var cancellation = new CancellationTokenSource();
            var receiver = new Mock<ServiceBusReceiver>();
            var message = ServiceBusModelFactory.ServiceBusReceivedMessage(lockedUntil: DateTimeOffset.UtcNow);
            var invoked = new TaskCompletionSource<CancellationToken>(TaskCreationOptions.RunContinuationsAsynchronously);
            receiver.Setup(r => r.RenewMessageLockAsync(message, It.IsAny<CancellationToken>()))
                .Returns((ServiceBusReceivedMessage _, CancellationToken token) => BlockRenewalAsync(invoked, token));
            var manager = new BatchLockRenewalManager(Timeout.InfiniteTimeSpan, cancellation.Token, NullLogger.Instance);
            try
            {
                manager.Start(message, receiver.Object);
                var token = await invoked.Task;
                cancellation.Cancel();
                await manager.StopAllAsync();
                Assert.IsTrue(token.IsCancellationRequested);
            }
            finally
            {
                await manager.StopAllAsync();
            }
        }

        [TestCase("complete")]
        [TestCase("abandon")]
        [TestCase("defer")]
        [TestCase("deadletter")]
        public async Task ExplicitSettlementCancelsOnlyTheSettledMessage(string settlement)
        {
            var receiver = new Mock<ServiceBusReceiver>();
            var first = ServiceBusModelFactory.ServiceBusReceivedMessage(lockedUntil: DateTimeOffset.UtcNow);
            var second = ServiceBusModelFactory.ServiceBusReceivedMessage(lockedUntil: DateTimeOffset.UtcNow);
            var firstInvoked = new TaskCompletionSource<CancellationToken>(TaskCreationOptions.RunContinuationsAsynchronously);
            var secondInvoked = new TaskCompletionSource<CancellationToken>(TaskCreationOptions.RunContinuationsAsynchronously);
            receiver.Setup(r => r.RenewMessageLockAsync(first, It.IsAny<CancellationToken>()))
                .Returns((ServiceBusReceivedMessage _, CancellationToken token) => BlockRenewalAsync(firstInvoked, token));
            receiver.Setup(r => r.RenewMessageLockAsync(second, It.IsAny<CancellationToken>()))
                .Returns((ServiceBusReceivedMessage _, CancellationToken token) => BlockRenewalAsync(secondInvoked, token));
            var manager = CreateManager(Timeout.InfiniteTimeSpan);
            var actions = new ServiceBusMessageActions(receiver.Object) { MessageSettled = manager.Cancel };
            try
            {
                manager.Start(first, receiver.Object);
                manager.Start(second, receiver.Object);
                var firstToken = await firstInvoked.Task;
                var secondToken = await secondInvoked.Task;
                switch (settlement)
                {
                    case "complete":
                        await actions.CompleteMessageAsync(first);
                        break;
                    case "abandon":
                        await actions.AbandonMessageAsync(first);
                        break;
                    case "defer":
                        await actions.DeferMessageAsync(first);
                        break;
                    case "deadletter":
                        await actions.DeadLetterMessageAsync(first);
                        break;
                }

                Assert.IsTrue(firstToken.IsCancellationRequested);
                Assert.IsFalse(secondToken.IsCancellationRequested);
            }
            finally
            {
                await manager.StopAllAsync();
            }
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task AdditionalAndDeferredReceivesAreRenewed(bool deferred)
        {
            var receiver = new Mock<ServiceBusReceiver>();
            var message = ServiceBusModelFactory.ServiceBusReceivedMessage(lockedUntil: DateTimeOffset.UtcNow);
            IReadOnlyList<ServiceBusReceivedMessage> messages = new[] { message };
            receiver.Setup(r => r.ReceiveMessagesAsync(1, null, It.IsAny<CancellationToken>())).ReturnsAsync(messages);
            receiver.Setup(r => r.ReceiveDeferredMessagesAsync(It.IsAny<IEnumerable<long>>(), It.IsAny<CancellationToken>())).ReturnsAsync(messages);
            var invoked = new TaskCompletionSource<CancellationToken>(TaskCreationOptions.RunContinuationsAsynchronously);
            receiver.Setup(r => r.RenewMessageLockAsync(message, It.IsAny<CancellationToken>()))
                .Returns((ServiceBusReceivedMessage _, CancellationToken token) => BlockRenewalAsync(invoked, token));
            var manager = CreateManager(Timeout.InfiniteTimeSpan);
            var actions = new ServiceBusReceiveActions(receiver.Object, manager);
            try
            {
                if (deferred)
                {
                    await actions.ReceiveDeferredMessagesAsync(new long[] { 1 });
                }
                else
                {
                    await actions.ReceiveMessagesAsync(1);
                }

                var token = await invoked.Task;
                actions.EndExecutionScope();
                await manager.StopAsync(actions.Messages.Keys);
                Assert.IsTrue(token.IsCancellationRequested);
            }
            finally
            {
                await manager.StopAllAsync();
            }
        }

        [Test]
        public async Task ReceiveCompletingAfterInvocationCannotStartRenewal()
        {
            var receiver = new Mock<ServiceBusReceiver>();
            var received = new TaskCompletionSource<IReadOnlyList<ServiceBusReceivedMessage>>(TaskCreationOptions.RunContinuationsAsynchronously);
            receiver.Setup(r => r.ReceiveMessagesAsync(1, null, It.IsAny<CancellationToken>())).Returns(received.Task);
            var manager = CreateManager(Timeout.InfiniteTimeSpan);
            var actions = new ServiceBusReceiveActions(receiver.Object, manager);
            var receive = actions.ReceiveMessagesAsync(1);
            actions.EndExecutionScope();
            received.SetResult(new[] { ServiceBusModelFactory.ServiceBusReceivedMessage(lockedUntil: DateTimeOffset.UtcNow) });
            Assert.ThrowsAsync<InvalidOperationException>(async () => await receive);
            await manager.StopAllAsync();
            Assert.IsEmpty(actions.Messages);
            receiver.Verify(r => r.RenewMessageLockAsync(It.IsAny<ServiceBusReceivedMessage>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Test]
        public async Task SessionsRenewTheSessionLockInsteadOfMessageLocks()
        {
            var receiver = new Mock<ServiceBusSessionReceiver>();
            receiver.Setup(r => r.Equals(It.IsAny<object>())).CallBase();
            receiver.Setup(r => r.GetHashCode()).CallBase();
            receiver.SetupGet(r => r.SessionLockedUntil).Returns(DateTimeOffset.UtcNow);
            var invoked = new TaskCompletionSource<CancellationToken>(TaskCreationOptions.RunContinuationsAsynchronously);
            receiver.Setup(r => r.RenewSessionLockAsync(It.IsAny<CancellationToken>()))
                .Returns((CancellationToken token) => BlockRenewalAsync(invoked, token));
            var manager = CreateManager(Timeout.InfiniteTimeSpan);
            try
            {
                manager.Start(receiver.Object);
                manager.Start(ServiceBusModelFactory.ServiceBusReceivedMessage(), receiver.Object);
                var token = await invoked.Task;
                await manager.StopAsync(receiver.Object);
                Assert.IsTrue(token.IsCancellationRequested);
                receiver.Verify(r => r.RenewSessionLockAsync(It.IsAny<CancellationToken>()), Times.Once);
                receiver.Verify(r => r.RenewMessageLockAsync(It.IsAny<ServiceBusReceivedMessage>(), It.IsAny<CancellationToken>()), Times.Never);
            }
            finally
            {
                await manager.StopAllAsync();
            }
        }

        [Test]
        public void RenewalStartsBeforeExpiry()
        {
            var delay = BatchLockRenewalManager.CalculateRenewDelay(DateTimeOffset.UtcNow.AddMinutes(5));
            Assert.That(delay.TotalSeconds, Is.InRange(289, 291));
            delay = BatchLockRenewalManager.CalculateRenewDelay(DateTimeOffset.UtcNow.AddSeconds(10));
            Assert.That(delay.TotalSeconds, Is.InRange(4, 6));
            Assert.AreEqual(TimeSpan.Zero, BatchLockRenewalManager.CalculateRenewDelay(DateTimeOffset.UtcNow.AddSeconds(-1)));
        }

        private static BatchLockRenewalManager CreateManager(TimeSpan duration)
            => new(duration, CancellationToken.None, NullLogger.Instance);

        [TestCase(false)]
        [TestCase(true)]
        public async Task LiveHostStartsLocallyWithExternalWritesDisabled(bool sessions)
        {
            using var host = BatchLockRenewalEndToEndTests.BuildHost(
                sessions,
                "Endpoint=sb://test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=",
                "batch-renewal-qualification", 1, disableTrigger: true);
            await host.StartAsync();
            try
            {
                var options = host.Services.GetRequiredService<IOptions<ServiceBusOptions>>().Value;
                Assert.AreEqual(TimeSpan.FromMinutes(5), options.MaxAutoLockRenewalDuration);
                Assert.IsTrue(host.GetTestLoggerProvider().GetAllLogMessages().Any(message =>
                    message.FormattedMessage.Contains("disabled")));
            }
            finally
            {
                await host.StopAsync();
            }
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task RenewalErrorsAreLoggedAndOnlyTransientErrorsRetry(bool transient)
        {
            using var factory = new LoggerFactory();
            var logs = new TestLoggerProvider();
            factory.AddProvider(logs);
            var receiver = new Mock<ServiceBusReceiver>();
            var message = ServiceBusModelFactory.ServiceBusReceivedMessage(lockedUntil: DateTimeOffset.UtcNow);
            var retry = new TaskCompletionSource<CancellationToken>(TaskCreationOptions.RunContinuationsAsynchronously);
            int calls = 0;
            receiver.Setup(r => r.RenewMessageLockAsync(message, It.IsAny<CancellationToken>()))
                .Returns((ServiceBusReceivedMessage _, CancellationToken token) =>
                {
                    if (Interlocked.Increment(ref calls) == 1)
                    {
                        throw new ServiceBusException(transient, "Renewal failed", "queue",
                            transient ? ServiceBusFailureReason.ServiceBusy : ServiceBusFailureReason.MessageLockLost);
                    }

                    return BlockRenewalAsync(retry, token);
                });
            var manager = new BatchLockRenewalManager(Timeout.InfiniteTimeSpan, CancellationToken.None, factory.CreateLogger("Renewal"));
            try
            {
                manager.Start(message, receiver.Object);
                await TestHelpers.Await(() => logs.GetAllLogMessages().Any(message => message.Level == LogLevel.Error), timeout: 3000);
                if (transient)
                {
                    await retry.Task;
                    Assert.AreEqual(2, calls);
                }
                else
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(1100));
                    Assert.AreEqual(1, calls);
                }
            }
            finally
            {
                await manager.StopAllAsync();
            }
        }

        private static async Task BlockRenewalAsync(TaskCompletionSource<CancellationToken> invoked, CancellationToken token)
        {
            invoked.TrySetResult(token);
            await Task.Delay(Timeout.Infinite, token);
        }
    }
}
