// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Plugins;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Processor
{
    public class SessionProcessorTests : ServiceBusTestBase
    {
        [Test]
        public void CannotAddNullHandler()
        {
            var processor = new ServiceBusSessionProcessor(
                GetMockedConnection(),
                "entityPath",
                new ServiceBusPlugin[] { },
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
                GetMockedConnection(),
                "entityPath",
                new ServiceBusPlugin[] { },
                new ServiceBusSessionProcessorOptions());

            Assert.That(async () => await processor.StartProcessingAsync(), Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void MustSetErrorHandler()
        {
            var processor = new ServiceBusSessionProcessor(
                GetMockedConnection(),
                "entityPath",
                new ServiceBusPlugin[] { },
                new ServiceBusSessionProcessorOptions());

            processor.ProcessMessageAsync += eventArgs => Task.CompletedTask;

            Assert.That(async () => await processor.StartProcessingAsync(), Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void CannotAddTwoHandlersToTheSameEvent()
        {
            var processor = new ServiceBusSessionProcessor(
                GetMockedConnection(),
                "entityPath",
                new ServiceBusPlugin[] { },
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
                GetMockedConnection(),
                "entityPath",
                new ServiceBusPlugin[] { },
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
                GetMockedConnection(),
                "entityPath",
                new ServiceBusPlugin[] { },
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
            var account = Encoding.Default.GetString(GetRandomBuffer(12));
            var fullyQualifiedNamespace = new UriBuilder($"{account}.servicebus.windows.net/").Host;
            var connString = $"Endpoint=sb://{fullyQualifiedNamespace};SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey={Encoding.Default.GetString(GetRandomBuffer(64))}";
            var client = new ServiceBusClient(connString);
            var options = new ServiceBusSessionProcessorOptions
            {
                AutoCompleteMessages = false,
                MaxConcurrentSessions = 10,
                PrefetchCount = 5,
                ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete,
                MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(60),
                MaxConcurrentCallsPerSession = 4
            };
            var processor = client.CreateSessionProcessor("queueName", options);
            Assert.AreEqual(options.AutoCompleteMessages, processor.AutoCompleteMessages);
            Assert.AreEqual(options.MaxConcurrentSessions, processor.MaxConcurrentSessions);
            Assert.AreEqual(options.MaxConcurrentCallsPerSession, processor.MaxConcurrentCallsPerSession);
            Assert.AreEqual(options.PrefetchCount, processor.PrefetchCount);
            Assert.AreEqual(options.ReceiveMode, processor.ReceiveMode);
            Assert.AreEqual(options.MaxAutoLockRenewalDuration, processor.MaxAutoLockRenewalDuration);
            Assert.AreEqual(fullyQualifiedNamespace, processor.FullyQualifiedNamespace);
            Assert.IsFalse(processor.IsClosed);
            Assert.IsFalse(processor.IsProcessing);
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
                () => options.MaxReceiveWaitTime = TimeSpan.FromSeconds(0),
                Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(
                () => options.MaxReceiveWaitTime = TimeSpan.FromSeconds(-1),
                Throws.InstanceOf<ArgumentOutOfRangeException>());

            // should not throw
            options.PrefetchCount = 0;
            options.MaxReceiveWaitTime = TimeSpan.FromSeconds(1);
            options.MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(0);
        }

        [Test]
        public async Task UserSettledPropertySetCorrectly()
        {
            var msg = new ServiceBusReceivedMessage();
            var args = new ProcessSessionMessageEventArgs(
                msg,
                new Mock<ServiceBusSessionReceiver>().Object,
                CancellationToken.None);

            Assert.IsFalse(msg.IsSettled);

            msg.IsSettled = false;
            await args.AbandonMessageAsync(msg);
            Assert.IsTrue(msg.IsSettled);

            await args.CompleteMessageAsync(msg);
            Assert.IsTrue(msg.IsSettled);

            msg.IsSettled = false;
            await args.DeadLetterMessageAsync(msg);
            Assert.IsTrue(msg.IsSettled);

            msg.IsSettled = false;
            await args.DeadLetterMessageAsync(msg, "reason");
            Assert.IsTrue(msg.IsSettled);

            msg.IsSettled = false;
            await args.DeferMessageAsync(msg);
            Assert.IsTrue(msg.IsSettled);

            // getting or setting session state doesn't count as settling
            msg.IsSettled = false;
            await args.GetSessionStateAsync();
            Assert.IsFalse(msg.IsSettled);

            msg.IsSettled = false;
            await args.SetSessionStateAsync(default);
            Assert.IsFalse(msg.IsSettled);
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

            Assert.IsFalse(msg.IsSettled);

            msg.IsSettled = false;
            Assert.That(async () => await args.AbandonMessageAsync(msg),
                Throws.InstanceOf<Exception>());
            Assert.IsFalse(msg.IsSettled);

            Assert.That(async () => await args.CompleteMessageAsync(msg),
                Throws.InstanceOf<Exception>());
            Assert.IsFalse(msg.IsSettled);

            msg.IsSettled = false;
            Assert.That(async () => await args.DeadLetterMessageAsync(msg),
                Throws.InstanceOf<Exception>());
            Assert.IsFalse(msg.IsSettled);

            msg.IsSettled = false;
            Assert.That(async () => await args.DeadLetterMessageAsync(msg, "reason"),
                Throws.InstanceOf<Exception>());
            Assert.IsFalse(msg.IsSettled);

            msg.IsSettled = false;
            Assert.That(async () => await args.DeferMessageAsync(msg),
                Throws.InstanceOf<Exception>());
            Assert.IsFalse(msg.IsSettled);
        }
    }
}
