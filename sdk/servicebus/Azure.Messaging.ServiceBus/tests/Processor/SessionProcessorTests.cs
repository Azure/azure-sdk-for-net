// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Processor
{
    public class SessionProcessorTests
    {
        [Test]
        public void CannotAddNullHandler()
        {
            var processor = new ServiceBusSessionProcessor(
                ServiceBusTestUtilities.GetMockedReceiverConnection(),
                "entityPath",
                new ServiceBusSessionProcessorOptions());

            Assert.That(() => processor.ProcessMessageAsync += null, Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => processor.ProcessErrorAsync += null, Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => processor.SessionInitializingAsync += null, Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => processor.SessionClosingAsync += null, Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void MustSetMessageHandler()
        {
            var processor = new ServiceBusSessionProcessor(
                ServiceBusTestUtilities.GetMockedReceiverConnection(),
                "entityPath",
                new ServiceBusSessionProcessorOptions());

            Assert.That(async () => await processor.StartProcessingAsync(), Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void MustSetErrorHandler()
        {
            var processor = new ServiceBusSessionProcessor(
                ServiceBusTestUtilities.GetMockedReceiverConnection(),
                "entityPath",
                new ServiceBusSessionProcessorOptions());

            processor.ProcessMessageAsync += eventArgs => Task.CompletedTask;

            Assert.That(async () => await processor.StartProcessingAsync(), Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void CannotAddTwoHandlersToTheSameEvent()
        {
            var processor = new ServiceBusSessionProcessor(
                ServiceBusTestUtilities.GetMockedReceiverConnection(),
                "entityPath",
                new ServiceBusSessionProcessorOptions());

            processor.ProcessMessageAsync += eventArgs => Task.CompletedTask;
            processor.ProcessErrorAsync += eventArgs => Task.CompletedTask;
            processor.SessionInitializingAsync += eventArgs => Task.CompletedTask;
            processor.SessionClosingAsync += eventArgs => Task.CompletedTask;

            Assert.That(() => processor.ProcessMessageAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<NotSupportedException>());
            Assert.That(() => processor.ProcessErrorAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<NotSupportedException>());
            Assert.That(() => processor.SessionInitializingAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<NotSupportedException>());
            Assert.That(() => processor.SessionClosingAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<NotSupportedException>());
        }

        [Test]
        public void CannotRemoveHandlerThatHasNotBeenAdded()
        {
            var processor = new ServiceBusSessionProcessor(
                ServiceBusTestUtilities.GetMockedReceiverConnection(),
                "entityPath",
                new ServiceBusSessionProcessorOptions());

            // First scenario: no handler has been set.

            Assert.That(() => processor.ProcessMessageAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>());
            Assert.That(() => processor.ProcessErrorAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>());
            Assert.That(() => processor.SessionInitializingAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>());
            Assert.That(() => processor.SessionClosingAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>());

            // Second scenario: there is a handler set, but it's not the one we are trying to remove.

            processor.ProcessMessageAsync += eventArgs => Task.CompletedTask;
            processor.ProcessErrorAsync += eventArgs => Task.CompletedTask;
            processor.SessionInitializingAsync += eventArgs => Task.CompletedTask;
            processor.SessionClosingAsync += eventArgs => Task.CompletedTask;

            Assert.That(() => processor.ProcessMessageAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>());
            Assert.That(() => processor.ProcessErrorAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>());
            Assert.That(() => processor.SessionInitializingAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>());
            Assert.That(() => processor.SessionClosingAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void CanRemoveHandlerThatHasBeenAdded()
        {
            var processor = new ServiceBusSessionProcessor(
                ServiceBusTestUtilities.GetMockedReceiverConnection(),
                "entityPath",
                new ServiceBusSessionProcessorOptions());

            Func<ProcessSessionMessageEventArgs, Task> eventHandler = eventArgs => Task.CompletedTask;
            Func<ProcessErrorEventArgs, Task> errorHandler = eventArgs => Task.CompletedTask;
            Func<ProcessSessionEventArgs, Task> sessionInitHandler = eventArgs => Task.CompletedTask;
            Func<ProcessSessionEventArgs, Task> sessionCloseHandler = eventArgs => Task.CompletedTask;

            processor.ProcessMessageAsync += eventHandler;
            processor.ProcessErrorAsync += errorHandler;
            processor.SessionInitializingAsync += sessionInitHandler;
            processor.SessionClosingAsync += sessionCloseHandler;

            Assert.That(() => processor.ProcessMessageAsync -= eventHandler, Throws.Nothing);
            Assert.That(() => processor.ProcessErrorAsync -= errorHandler, Throws.Nothing);
            Assert.That(() => processor.SessionInitializingAsync -= sessionInitHandler, Throws.Nothing);
            Assert.That(() => processor.SessionClosingAsync -= sessionCloseHandler, Throws.Nothing);

            // Assert that handlers can be added again.

            Assert.That(() => processor.ProcessMessageAsync += eventHandler, Throws.Nothing);
            Assert.That(() => processor.ProcessErrorAsync += errorHandler, Throws.Nothing);
            Assert.That(() => processor.SessionInitializingAsync += sessionInitHandler, Throws.Nothing);
            Assert.That(() => processor.SessionClosingAsync += sessionCloseHandler, Throws.Nothing);
        }

        [Test]
        public void ProcessorOptionsSetOnClient()
        {
            var account = Encoding.Default.GetString(ServiceBusTestUtilities.GetRandomBuffer(12));
            var fullyQualifiedNamespace = new UriBuilder($"{account}.servicebus.windows.net/").Host;
            var client = new ServiceBusClient(fullyQualifiedNamespace, Mock.Of<TokenCredential>());
            var identifier = "MyProcessor";
            var options = new ServiceBusSessionProcessorOptions
            {
                AutoCompleteMessages = false,
                MaxConcurrentSessions = 10,
                PrefetchCount = 5,
                ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete,
                MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(60),
                MaxConcurrentCallsPerSession = 4,
                Identifier = identifier
            };
            var processor = client.CreateSessionProcessor("queueName", options);
            Assert.Multiple(() =>
            {
                Assert.That(processor.AutoCompleteMessages, Is.EqualTo(options.AutoCompleteMessages));
                Assert.That(processor.MaxConcurrentSessions, Is.EqualTo(options.MaxConcurrentSessions));
                Assert.That(processor.MaxConcurrentCallsPerSession, Is.EqualTo(options.MaxConcurrentCallsPerSession));
                Assert.That(processor.PrefetchCount, Is.EqualTo(options.PrefetchCount));
                Assert.That(processor.ReceiveMode, Is.EqualTo(options.ReceiveMode));
                Assert.That(processor.MaxAutoLockRenewalDuration, Is.EqualTo(options.MaxAutoLockRenewalDuration));
                Assert.That(processor.SessionIdleTimeout, Is.EqualTo(options.SessionIdleTimeout));
                Assert.That(processor.FullyQualifiedNamespace, Is.EqualTo(fullyQualifiedNamespace));
                Assert.That(processor.Identifier, Is.EqualTo(identifier));
                Assert.That(processor.IsClosed, Is.False);
                Assert.That(processor.IsProcessing, Is.False);
            });
        }

        [Test]
        public void ProcessorOptionsValidation()
        {
            var options = new ServiceBusSessionProcessorOptions();
            Assert.That(
                () => options.PrefetchCount = -1,
                Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(
                () => options.MaxConcurrentSessions = 0,
                Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(
                () => options.MaxConcurrentCallsPerSession = -1,
                Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(
                () => options.MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(-1),
                Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(
                () => options.SessionIdleTimeout = TimeSpan.FromSeconds(0),
                Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(
                () => options.SessionIdleTimeout = TimeSpan.FromSeconds(-1),
                Throws.InstanceOf<ArgumentOutOfRangeException>());

            // should not throw
            options.PrefetchCount = 0;
            options.SessionIdleTimeout = TimeSpan.FromSeconds(1);
            options.MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(0);
            options.MaxAutoLockRenewalDuration = Timeout.InfiniteTimeSpan;
        }

        [Test]
        public async Task UserSettledPropertySetCorrectly()
        {
            var msg = new ServiceBusReceivedMessage();
            var args = new ProcessSessionMessageEventArgs(
                msg,
                new Mock<ServiceBusSessionReceiver>().Object,
                CancellationToken.None);

            Assert.That(msg.IsSettled, Is.False);

            msg.IsSettled = false;
            await args.AbandonMessageAsync(msg);
            Assert.That(msg.IsSettled, Is.True);

            await args.CompleteMessageAsync(msg);
            Assert.That(msg.IsSettled, Is.True);

            msg.IsSettled = false;
            await args.DeadLetterMessageAsync(msg);
            Assert.That(msg.IsSettled, Is.True);

            msg.IsSettled = false;
            await args.DeadLetterMessageAsync(msg, "reason");
            Assert.That(msg.IsSettled, Is.True);

            msg.IsSettled = false;
            await args.DeferMessageAsync(msg);
            Assert.That(msg.IsSettled, Is.True);

            // getting or setting session state doesn't count as settling
            msg.IsSettled = false;
            await args.GetSessionStateAsync();
            Assert.That(msg.IsSettled, Is.False);

            msg.IsSettled = false;
            await args.SetSessionStateAsync(default);
            Assert.That(msg.IsSettled, Is.False);
        }

        [Test]
        public void UserSettledPropertySetCorrectlyOnException()
        {
            var msg = new ServiceBusReceivedMessage();
            var mockReceiver = new Mock<ServiceBusSessionReceiver>();

            mockReceiver
                .Setup(receiver => receiver.AbandonMessageAsync(
                    It.IsAny<ServiceBusReceivedMessage>(),
                    It.IsAny<IDictionary<string, object>>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());

            mockReceiver
                .Setup(receiver => receiver.DeferMessageAsync(
                    It.IsAny<ServiceBusReceivedMessage>(),
                    It.IsAny<IDictionary<string, object>>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());

            mockReceiver
                .Setup(receiver => receiver.CompleteMessageAsync(
                    It.IsAny<ServiceBusReceivedMessage>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());

            mockReceiver
                .Setup(receiver => receiver.DeadLetterMessageAsync(
                    It.IsAny<ServiceBusReceivedMessage>(),
                    It.IsAny<IDictionary<string, object>>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());

            mockReceiver
                .Setup(receiver => receiver.DeadLetterMessageAsync(
                    It.IsAny<ServiceBusReceivedMessage>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());

            var args = new ProcessSessionMessageEventArgs(
                msg,
                mockReceiver.Object,
                CancellationToken.None);

            Assert.That(msg.IsSettled, Is.False);

            msg.IsSettled = false;
            Assert.That(async () => await args.AbandonMessageAsync(msg),
                Throws.InstanceOf<Exception>());
            Assert.That(msg.IsSettled, Is.False);

            Assert.That(async () => await args.CompleteMessageAsync(msg),
                Throws.InstanceOf<Exception>());
            Assert.That(msg.IsSettled, Is.False);

            msg.IsSettled = false;
            Assert.That(async () => await args.DeadLetterMessageAsync(msg),
                Throws.InstanceOf<Exception>());
            Assert.That(msg.IsSettled, Is.False);

            msg.IsSettled = false;
            Assert.That(async () => await args.DeadLetterMessageAsync(msg, "reason"),
                Throws.InstanceOf<Exception>());
            Assert.That(msg.IsSettled, Is.False);

            msg.IsSettled = false;
            Assert.That(async () => await args.DeferMessageAsync(msg),
                Throws.InstanceOf<Exception>());
            Assert.That(msg.IsSettled, Is.False);
        }

        [Test]
        public async Task CanRaiseEventsOnMockSessionProcessor()
        {
            var mockProcessor = new MockSessionProcessor();
            var mockReceiver = new Mock<ServiceBusSessionReceiver>();
            mockReceiver.Setup(r => r.SessionId).Returns("sessionId");
            mockReceiver.Setup(r => r.FullyQualifiedNamespace).Returns("namespace");
            mockReceiver.Setup(r => r.EntityPath).Returns("entityPath");
            bool processMessageCalled = false;
            bool processErrorCalled = false;
            bool sessionOpenCalled = false;
            bool sessionCloseCalled = false;

            var processArgs = new ProcessSessionMessageEventArgs(
                ServiceBusModelFactory.ServiceBusReceivedMessage(messageId: "1", sessionId: "sessionId"),
                mockReceiver.Object,
                CancellationToken.None);

            var errorArgs = new ProcessErrorEventArgs(
                new ServiceBusException("error", ServiceBusFailureReason.MessageSizeExceeded),
                ServiceBusErrorSource.Abandon,
                "namespace",
                "entityPath",
                CancellationToken.None);

            var processSessionArgs = new ProcessSessionEventArgs(
                mockReceiver.Object,
                CancellationToken.None);

            mockProcessor.ProcessMessageAsync += args =>
            {
                processMessageCalled = true;
                Assert.Multiple(() =>
                {
                    Assert.That(args.Message.MessageId, Is.EqualTo("1"));
                    Assert.That(args.SessionId, Is.EqualTo("sessionId"));
                    Assert.That(args.FullyQualifiedNamespace, Is.EqualTo("namespace"));
                    Assert.That(args.EntityPath, Is.EqualTo("entityPath"));
                });
                return Task.CompletedTask;
            };

            mockProcessor.ProcessErrorAsync += args =>
            {
                processErrorCalled = true;
                Assert.Multiple(() =>
                {
                    Assert.That(
                                    ((ServiceBusException)args.Exception).Reason,
                                    Is.EqualTo(ServiceBusFailureReason.MessageSizeExceeded));
                    Assert.That(args.FullyQualifiedNamespace, Is.EqualTo("namespace"));
                    Assert.That(args.EntityPath, Is.EqualTo("entityPath"));
                    Assert.That(args.ErrorSource, Is.EqualTo(ServiceBusErrorSource.Abandon));
                });
                return Task.CompletedTask;
            };

            mockProcessor.SessionInitializingAsync += args =>
            {
                sessionOpenCalled = true;
                Assert.Multiple(() =>
                {
                    Assert.That(args.SessionId, Is.EqualTo("sessionId"));
                    Assert.That(args.FullyQualifiedNamespace, Is.EqualTo("namespace"));
                    Assert.That(args.EntityPath, Is.EqualTo("entityPath"));
                });
                return Task.CompletedTask;
            };

            mockProcessor.SessionClosingAsync += args =>
            {
                sessionCloseCalled = true;
                Assert.Multiple(() =>
                {
                    Assert.That(args.SessionId, Is.EqualTo("sessionId"));
                    Assert.That(args.FullyQualifiedNamespace, Is.EqualTo("namespace"));
                    Assert.That(args.EntityPath, Is.EqualTo("entityPath"));
                });
                return Task.CompletedTask;
            };

            await mockProcessor.OnProcessSessionMessageAsync(processArgs);
            await mockProcessor.OnProcessErrorAsync(errorArgs);
            await mockProcessor.OnSessionInitializingAsync(processSessionArgs);
            await mockProcessor.OnSessionClosingAsync(processSessionArgs);

            Assert.Multiple(() =>
            {
                Assert.That(processMessageCalled, Is.True);
                Assert.That(processErrorCalled, Is.True);
                Assert.That(sessionOpenCalled, Is.True);
                Assert.That(sessionCloseCalled, Is.True);
            });
        }

        [Test]
        public async Task CanRaiseLockLostOnMockProcessor()
        {
            var mockProcessor = new MockSessionProcessor();
            bool processMessageCalled = false;
            bool sessionOpenCalled = false;
            bool sessionCloseCalled = false;
            var mockReceiver = new Mock<ServiceBusSessionReceiver>();
            mockReceiver.Setup(r => r.SessionId).Returns("sessionId");
            mockReceiver.Setup(r => r.FullyQualifiedNamespace).Returns("namespace");
            mockReceiver.Setup(r => r.EntityPath).Returns("entityPath");
            var message = ServiceBusModelFactory.ServiceBusReceivedMessage(messageId: "1", sessionId: "sessionId");
            var processArgs = new ProcessSessionMessageEventArgs(
                message,
                mockReceiver.Object,
                CancellationToken.None);

            bool sessionLockLostEventRaised = false;

            mockProcessor.ProcessMessageAsync += args =>
            {
                args.SessionLockLostAsync += (lockLostArgs) =>
                {
                    sessionLockLostEventRaised = true;
                    Assert.That(lockLostArgs.Exception, Is.Null);
                    return Task.CompletedTask;
                };
                processMessageCalled = true;
                return Task.CompletedTask;
            };

            mockProcessor.ProcessErrorAsync += _ => Task.CompletedTask;

            var processSessionArgs = new ProcessSessionEventArgs(
                mockReceiver.Object,
                CancellationToken.None);

            mockProcessor.SessionInitializingAsync += args =>
            {
                sessionOpenCalled = true;
                return Task.CompletedTask;
            };

            mockProcessor.SessionClosingAsync += args =>
            {
                sessionCloseCalled = true;
                return Task.CompletedTask;
            };
            await mockProcessor.OnProcessSessionMessageAsync(processArgs);
            await mockProcessor.OnSessionInitializingAsync(processSessionArgs);

            Assert.That(sessionLockLostEventRaised, Is.False);
            await processArgs.OnSessionLockLostAsync(new SessionLockLostEventArgs(message, DateTimeOffset.Now, null));
            Assert.That(sessionLockLostEventRaised, Is.True);

            await mockProcessor.OnSessionClosingAsync(processSessionArgs);

            Assert.Multiple(() =>
            {
                Assert.That(processMessageCalled, Is.True);
                Assert.That(sessionOpenCalled, Is.True);
                Assert.That(sessionCloseCalled, Is.True);
            });
        }

        [Test]
        public void CanUpdateConcurrencyOnMockSessionProcessor()
        {
            var mockProcessor = new MockSessionProcessor();
            mockProcessor.UpdateConcurrency(5, 2);
            Assert.Multiple(() =>
            {
                Assert.That(mockProcessor.MaxConcurrentSessions, Is.EqualTo(5));
                Assert.That(mockProcessor.MaxConcurrentCallsPerSession, Is.EqualTo(2));
            });
        }

        [Test]
        public void CanUpdatePrefetchOnMockSessionProcessor()
        {
            var mockProcessor = new MockSessionProcessor();
            mockProcessor.UpdatePrefetchCount(10);
            Assert.That(mockProcessor.PrefetchCount, Is.EqualTo(10));
        }

        [Test]
        public async Task CloseRespectsCancellationToken()
        {
            var mockProcessor = new Mock<ServiceBusProcessor>() {CallBase = true};
            var mockSessionProcessor = new Mock<ServiceBusSessionProcessor>() {CallBase = true};

            mockSessionProcessor.Setup(
                p => p.InnerProcessor).Returns(mockProcessor.Object);
            mockProcessor.Setup(
                p => p.IsProcessing).Returns(true);
            var cts = new CancellationTokenSource();

            // mutate the cancellation token to distinguish it from CancellationToken.None
            cts.CancelAfter(500);

            await mockSessionProcessor.Object.CloseAsync(cts.Token);
            mockProcessor.Verify(p => p.StopProcessingAsync(It.Is<CancellationToken>(ct => ct == cts.Token)));
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal class MockSessionProcessor : ServiceBusSessionProcessor
#pragma warning restore SA1402 // File may only contain a single type
    {
        protected internal override ServiceBusProcessor InnerProcessor { get; } = new MockProcessor();
    }
}
