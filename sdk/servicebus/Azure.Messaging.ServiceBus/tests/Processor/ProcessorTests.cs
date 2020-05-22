﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Processor
{
    public class ProcessorTests : ServiceBusTestBase
    {
        [Test]
        public void CannotAddNullHandler()
        {
            var processor = new ServiceBusProcessor(
                GetMockedConnection(),
                "entityPath",
                false,
                new ServiceBusProcessorOptions());

            Assert.That(() => processor.ProcessMessageAsync += null, Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => processor.ProcessErrorAsync += null, Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void CannotAddTwoHandlersToTheSameEvent()
        {
            var processor = new ServiceBusProcessor(
                GetMockedConnection(),
                "entityPath",
                false,
                new ServiceBusProcessorOptions());

            processor.ProcessMessageAsync += eventArgs => Task.CompletedTask;
            processor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            Assert.That(() => processor.ProcessMessageAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<NotSupportedException>());
            Assert.That(() => processor.ProcessErrorAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<NotSupportedException>());
        }

        [Test]
        public void CannotRemoveHandlerThatHasNotBeenAdded()
        {
            var processor = new ServiceBusProcessor(
                GetMockedConnection(),
                "entityPath",
                false,
                new ServiceBusProcessorOptions());

            // First scenario: no handler has been set.

            Assert.That(() => processor.ProcessMessageAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>());
            Assert.That(() => processor.ProcessErrorAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>());

            // Second scenario: there is a handler set, but it's not the one we are trying to remove.

            processor.ProcessMessageAsync += eventArgs => Task.CompletedTask;
            processor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            Assert.That(() => processor.ProcessMessageAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>());
            Assert.That(() => processor.ProcessErrorAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void CanRemoveHandlerThatHasBeenAdded()
        {
            var processor = new ServiceBusProcessor(
                GetMockedConnection(),
                "entityPath",
                false,
                new ServiceBusProcessorOptions());

            Func<ProcessMessageEventArgs, Task> eventHandler = eventArgs => Task.CompletedTask;
            Func<ProcessErrorEventArgs, Task> errorHandler = eventArgs => Task.CompletedTask;

            processor.ProcessMessageAsync += eventHandler;
            processor.ProcessErrorAsync += errorHandler;

            Assert.That(() => processor.ProcessMessageAsync -= eventHandler, Throws.Nothing);
            Assert.That(() => processor.ProcessErrorAsync -= errorHandler, Throws.Nothing);

            // Assert that handlers can be added again.

            Assert.That(() => processor.ProcessMessageAsync += eventHandler, Throws.Nothing);
            Assert.That(() => processor.ProcessErrorAsync += errorHandler, Throws.Nothing);
        }

        [Test]
        public void ProcessorOptionsSetOnClient()
        {
            var account = Encoding.Default.GetString(GetRandomBuffer(12));
            var fullyQualifiedNamespace = new UriBuilder($"{account}.servicebus.windows.net/").Host;
            var connString = $"Endpoint=sb://{fullyQualifiedNamespace};SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey={Encoding.Default.GetString(GetRandomBuffer(64))}";
            var client = new ServiceBusClient(connString);
            var options = new ServiceBusProcessorOptions
            {
                AutoComplete = false,
                MaxConcurrentCalls = 10,
                PrefetchCount = 5,
                ReceiveMode = ReceiveMode.ReceiveAndDelete,
                MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(60),
                MaxReceiveWaitTime = TimeSpan.FromSeconds(10)
            };
            var processor = client.CreateProcessor("queueName", options);
            Assert.AreEqual(options.AutoComplete, processor.AutoComplete);
            Assert.AreEqual(options.MaxConcurrentCalls, processor.MaxConcurrentCalls);
            Assert.AreEqual(options.PrefetchCount, processor.PrefetchCount);
            Assert.AreEqual(options.ReceiveMode, processor.ReceiveMode);
            Assert.AreEqual(options.MaxAutoLockRenewalDuration, processor.MaxAutoLockRenewalDuration);
            Assert.AreEqual(fullyQualifiedNamespace, processor.FullyQualifiedNamespace);
            Assert.AreEqual(options.MaxReceiveWaitTime, processor.MaxReceiveWaitTime);
        }

        [Test]
        public void ProcessorOptionsValidation()
        {
            var options = new ServiceBusProcessorOptions();
            Assert.That(
                () => options.PrefetchCount = -1,
                Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(
                () => options.MaxConcurrentCalls = 0,
                Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(
                () => options.MaxConcurrentCalls = -1,
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
            var args = new ProcessMessageEventArgs(
                msg,
                new Mock<ServiceBusReceiver>().Object,
                CancellationToken.None);

            Assert.IsFalse(msg.IsSettled);

            msg.IsSettled = false;
            await args.AbandonAsync(msg);
            Assert.IsTrue(msg.IsSettled);

            await args.CompleteAsync(msg);
            Assert.IsTrue(msg.IsSettled);

            msg.IsSettled = false;
            await args.DeadLetterAsync(msg);
            Assert.IsTrue(msg.IsSettled);

            msg.IsSettled = false;
            await args.DeadLetterAsync(msg, "reason");
            Assert.IsTrue(msg.IsSettled);

            msg.IsSettled = false;
            await args.DeferAsync(msg);
            Assert.IsTrue(msg.IsSettled);
        }

        [Test]
        public void UserSettledPropertySetCorrectlyOnException()
        {
            var msg = new ServiceBusReceivedMessage();
            var mockReceiver = new Mock<ServiceBusReceiver>();

            mockReceiver
                .Setup(receiver => receiver.AbandonAsync(
                    It.IsAny<ServiceBusReceivedMessage>(),
                    It.IsAny<IDictionary<string, object>>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());

            mockReceiver
                .Setup(receiver => receiver.DeferAsync(
                    It.IsAny<ServiceBusReceivedMessage>(),
                    It.IsAny<IDictionary<string, object>>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());

            mockReceiver
                .Setup(receiver => receiver.CompleteAsync(
                    It.IsAny<ServiceBusReceivedMessage>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());

            mockReceiver
                .Setup(receiver => receiver.DeadLetterAsync(
                    It.IsAny<ServiceBusReceivedMessage>(),
                    It.IsAny<IDictionary<string, object>>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());

            mockReceiver
                .Setup(receiver => receiver.DeadLetterAsync(
                    It.IsAny<ServiceBusReceivedMessage>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception());

            var args = new ProcessMessageEventArgs(
                msg,
                mockReceiver.Object,
                CancellationToken.None);

            Assert.IsFalse(msg.IsSettled);

            msg.IsSettled = false;
            Assert.That(async () => await args.AbandonAsync(msg),
                Throws.InstanceOf<Exception>());
            Assert.IsFalse(msg.IsSettled);

            Assert.That(async () => await args.CompleteAsync(msg),
                Throws.InstanceOf<Exception>());
            Assert.IsFalse(msg.IsSettled);

            msg.IsSettled = false;
            Assert.That(async () => await args.DeadLetterAsync(msg),
                Throws.InstanceOf<Exception>());
            Assert.IsFalse(msg.IsSettled);

            msg.IsSettled = false;
            Assert.That(async () => await args.DeadLetterAsync(msg, "reason"),
                Throws.InstanceOf<Exception>());
            Assert.IsFalse(msg.IsSettled);

            msg.IsSettled = false;
            Assert.That(async () => await args.DeferAsync(msg),
                Throws.InstanceOf<Exception>());
            Assert.IsFalse(msg.IsSettled);
        }
    }
}
