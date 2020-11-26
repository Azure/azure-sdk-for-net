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
    public class ProcessorTests : ServiceBusTestBase
    {
        [Test]
        public void CannotAddNullHandler()
        {
            var processor = new ServiceBusProcessor(
                GetMockedConnection(),
                "entityPath",
                false,
                new ServiceBusPlugin[] { },
                new ServiceBusProcessorOptions());

            Assert.That(() => processor.ProcessMessageAsync += null, Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => processor.ProcessErrorAsync += null, Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void MustSetMessageHandler()
        {
            var processor = new ServiceBusProcessor(
                GetMockedConnection(),
                "entityPath",
                false,
                new ServiceBusPlugin[] { },
                new ServiceBusProcessorOptions());

            Assert.That(async () => await processor.StartProcessingAsync(), Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void MustSetErrorHandler()
        {
            var processor = new ServiceBusProcessor(
                GetMockedConnection(),
                "entityPath",
                false,
                new ServiceBusPlugin[] { },
                new ServiceBusProcessorOptions());

            processor.ProcessMessageAsync += eventArgs => Task.CompletedTask;

            Assert.That(async () => await processor.StartProcessingAsync(), Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void CannotAddTwoHandlersToTheSameEvent()
        {
            var processor = new ServiceBusProcessor(
                GetMockedConnection(),
                "entityPath",
                false,
                new ServiceBusPlugin[] { },
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
                new ServiceBusPlugin[] { },
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
                new ServiceBusPlugin[] { },
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
                AutoCompleteMessages = false,
                MaxConcurrentCalls = 10,
                PrefetchCount = 5,
                ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete,
                MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(60),
                MaxReceiveWaitTime = TimeSpan.FromSeconds(10)
            };
            var processor = client.CreateProcessor("queueName", options);
            Assert.AreEqual(options.AutoCompleteMessages, processor.AutoCompleteMessages);
            Assert.AreEqual(options.MaxConcurrentCalls, processor.MaxConcurrentCalls);
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
        }

        [Test]
        public void UserSettledPropertySetCorrectlyOnException()
        {
            var msg = new ServiceBusReceivedMessage();
            var mockReceiver = new Mock<ServiceBusReceiver>();

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

            var args = new ProcessMessageEventArgs(
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
