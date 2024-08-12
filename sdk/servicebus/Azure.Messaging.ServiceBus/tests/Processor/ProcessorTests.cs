// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Authorization;
using Azure.Messaging.ServiceBus.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Processor
{
    public class ProcessorTests
    {
        [Test]
        public void CannotAddNullHandler()
        {
            var processor = new ServiceBusProcessor(
                ServiceBusTestUtilities.GetMockedReceiverConnection(),
                "entityPath",
                false,
                new ServiceBusProcessorOptions());

            Assert.That(() => processor.ProcessMessageAsync += null, Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => processor.ProcessErrorAsync += null, Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void MustSetMessageHandler()
        {
            var processor = new ServiceBusProcessor(
                ServiceBusTestUtilities.GetMockedReceiverConnection(),
                "entityPath",
                false,
                new ServiceBusProcessorOptions());

            Assert.That(async () => await processor.StartProcessingAsync(), Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void MustSetErrorHandler()
        {
            var processor = new ServiceBusProcessor(
                ServiceBusTestUtilities.GetMockedReceiverConnection(),
                "entityPath",
                false,
                new ServiceBusProcessorOptions());

            processor.ProcessMessageAsync += eventArgs => Task.CompletedTask;

            Assert.That(async () => await processor.StartProcessingAsync(), Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void CannotAddTwoHandlersToTheSameEvent()
        {
            var processor = new ServiceBusProcessor(
                ServiceBusTestUtilities.GetMockedReceiverConnection(),
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
                ServiceBusTestUtilities.GetMockedReceiverConnection(),
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
                ServiceBusTestUtilities.GetMockedReceiverConnection(),
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
            var account = Encoding.Default.GetString(ServiceBusTestUtilities.GetRandomBuffer(12));
            var fullyQualifiedNamespace = new UriBuilder($"{account}.servicebus.windows.net/").Host;
            var connString = $"Endpoint=sb://{fullyQualifiedNamespace};SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey={Encoding.Default.GetString(ServiceBusTestUtilities.GetRandomBuffer(64))}";
            var client = new ServiceBusClient(connString);
            var identifier = "MyProcessor";
            var options = new ServiceBusProcessorOptions
            {
                AutoCompleteMessages = false,
                MaxConcurrentCalls = 10,
                PrefetchCount = 5,
                ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete,
                MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(60),
                MaxReceiveWaitTime = TimeSpan.FromSeconds(10),
                SubQueue = SubQueue.DeadLetter,
                Identifier = identifier
            };
            var processor = client.CreateProcessor("queueName", options);
            Assert.AreEqual(options.AutoCompleteMessages, processor.AutoCompleteMessages);
            Assert.AreEqual(options.MaxConcurrentCalls, processor.MaxConcurrentCalls);
            Assert.AreEqual(options.PrefetchCount, processor.PrefetchCount);
            Assert.AreEqual(options.Identifier, processor.Identifier);
            Assert.AreEqual(options.ReceiveMode, processor.ReceiveMode);
            Assert.AreEqual(options.MaxAutoLockRenewalDuration, processor.MaxAutoLockRenewalDuration);
            Assert.AreEqual(options.MaxReceiveWaitTime, processor.MaxReceiveWaitTime);
            Assert.AreEqual(fullyQualifiedNamespace, processor.FullyQualifiedNamespace);
            Assert.AreEqual(EntityNameFormatter.FormatDeadLetterPath("queueName"), processor.EntityPath);
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
            options.MaxAutoLockRenewalDuration = Timeout.InfiniteTimeSpan;
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

        [Test]
        public async Task CanDisposeStartedProcessorMultipleTimes()
        {
            var processor = new ServiceBusProcessor(
                ServiceBusTestUtilities.GetMockedReceiverConnection(),
                "entityPath",
                false,
                new ServiceBusProcessorOptions());
            processor.ProcessMessageAsync += _ => Task.CompletedTask;
            processor.ProcessErrorAsync += _ => Task.CompletedTask;
            await processor.StartProcessingAsync().ConfigureAwait(false);

            await processor.DisposeAsync();
            await processor.DisposeAsync();
        }

        [Test]
        public async Task CanDisposeClosedProcessor()
        {
            var processor = new ServiceBusProcessor(
                ServiceBusTestUtilities.GetMockedReceiverConnection(),
                "entityPath",
                false,
                new ServiceBusProcessorOptions());

            processor.ProcessMessageAsync += _ => Task.CompletedTask;
            processor.ProcessErrorAsync += _ => Task.CompletedTask;
            await processor.StartProcessingAsync().ConfigureAwait(false);
            await processor.CloseAsync();

            await processor.DisposeAsync();
        }

        [Test]
        public async Task CanRaiseEventsOnMockProcessor()
        {
            var mockProcessor = new MockProcessor();
            bool processMessageCalled = false;
            bool processErrorCalled = false;
            var mockReceiver = new Mock<ServiceBusReceiver>();
            mockReceiver.Setup(r => r.FullyQualifiedNamespace).Returns("namespace");
            mockReceiver.Setup(r => r.EntityPath).Returns("entityPath");

            var processArgs = new ProcessMessageEventArgs(
                ServiceBusModelFactory.ServiceBusReceivedMessage(messageId: "1"),
                mockReceiver.Object,
                CancellationToken.None);

            var errorArgs = new ProcessErrorEventArgs(
                new ServiceBusException("error", ServiceBusFailureReason.MessageSizeExceeded),
                ServiceBusErrorSource.Abandon,
                "namespace",
                "entityPath",
                CancellationToken.None);

            mockProcessor.ProcessMessageAsync += args =>
            {
                processMessageCalled = true;
                Assert.AreEqual("1", args.Message.MessageId);
                Assert.AreEqual("namespace", args.FullyQualifiedNamespace);
                Assert.AreEqual("entityPath", args.EntityPath);
                return Task.CompletedTask;
            };

            mockProcessor.ProcessErrorAsync += args =>
            {
                processErrorCalled = true;
                Assert.AreEqual(
                    ServiceBusFailureReason.MessageSizeExceeded,
                    ((ServiceBusException)args.Exception).Reason);
                Assert.AreEqual("namespace", args.FullyQualifiedNamespace);
                Assert.AreEqual("entityPath", args.EntityPath);
                Assert.AreEqual(ServiceBusErrorSource.Abandon, args.ErrorSource);
                return Task.CompletedTask;
            };

            await mockProcessor.OnProcessMessageAsync(processArgs);
            await mockProcessor.OnProcessErrorAsync(errorArgs);

            Assert.IsTrue(processMessageCalled);
            Assert.IsTrue(processErrorCalled);
        }

        [Test]
        public async Task CanRaiseLockLostOnMockProcessor()
        {
            var mockProcessor = new MockProcessor();
            bool processMessageCalled = false;
            var mockReceiver = new Mock<ServiceBusReceiver>();
            mockReceiver.Setup(r => r.FullyQualifiedNamespace).Returns("namespace");
            mockReceiver.Setup(r => r.EntityPath).Returns("entityPath");
            var message = ServiceBusModelFactory.ServiceBusReceivedMessage(messageId: "1");
            var processArgs = new ProcessMessageEventArgs(
                message,
                mockReceiver.Object,
                CancellationToken.None);

            bool lockLostEventRaised = false;
            mockProcessor.ProcessMessageAsync += args =>
            {
                args.MessageLockLostAsync += (lockLostArgs) =>
                {
                    lockLostEventRaised = true;
                    Assert.IsNull(lockLostArgs.Exception);
                    return Task.CompletedTask;
                };
                processMessageCalled = true;
                return Task.CompletedTask;
            };

            mockProcessor.ProcessErrorAsync += _ => Task.CompletedTask;

            await mockProcessor.OnProcessMessageAsync(processArgs);
            Assert.IsFalse(lockLostEventRaised);
            await processArgs.OnMessageLockLostAsync(new MessageLockLostEventArgs(message, null));
            Assert.IsTrue(lockLostEventRaised);

            Assert.IsTrue(processMessageCalled);
        }

        [Test]
        public async Task CannotStartProcessorWhenProcessorIsDisposed()
        {
            var mockConnection = ServiceBusTestUtilities.GetMockedReceiverConnection();

            var processor = new ServiceBusProcessor(
                mockConnection,
                "entityPath",
                false,
                new ServiceBusProcessorOptions());

            processor.ProcessMessageAsync += _ => Task.CompletedTask;
            processor.ProcessErrorAsync += _ => Task.CompletedTask;

            await processor.DisposeAsync();

            Assert.That(async () => await processor.StartProcessingAsync(),
                Throws.InstanceOf<ObjectDisposedException>().And.Property(nameof(ObjectDisposedException.ObjectName)).EqualTo(nameof(ServiceBusProcessor)));
        }

        [Test]
        public async Task CannotStartProcessorWhenConnectionIsClosed()
        {
            var connectionClosed = false;
            var mockTransportClient = new Mock<TransportClient>();
            var mockConnection = new Mock<ServiceBusConnection>("not.real.com", Mock.Of<TokenCredential>(), new ServiceBusClientOptions())
            {
                CallBase = true
            };

            mockTransportClient
                .SetupGet(client => client.IsClosed)
                .Returns(() => connectionClosed);

            mockConnection
                .Setup(connection => connection.CreateTransportClient(
                    It.IsAny<ServiceBusTokenCredential>(),
                    It.IsAny<ServiceBusClientOptions>(),
                    It.IsAny<bool>()))
                .Returns(mockTransportClient.Object);

            var processor = new ServiceBusProcessor(
                mockConnection.Object,
                "entityPath",
                false,
                new ServiceBusProcessorOptions());

            processor.ProcessMessageAsync += _ => Task.CompletedTask;
            processor.ProcessErrorAsync += _ => Task.CompletedTask;

            connectionClosed = true;

            Assert.That(async () => await processor.StartProcessingAsync(),
                Throws.InstanceOf<ObjectDisposedException>().And.Property(nameof(ObjectDisposedException.ObjectName)).EqualTo(nameof(ServiceBusConnection)));

            await processor.DisposeAsync();
        }

        [Test]
        public void CanUpdateConcurrencyOnMockProcessor()
        {
            var mockProcessor = new Mock<ServiceBusProcessor> { CallBase = true };
            mockProcessor.Object.UpdateConcurrency(5);
            Assert.AreEqual(5, mockProcessor.Object.MaxConcurrentCalls);
        }

        [Test]
        public void CanUpdatePrefetchOnMockProcessor()
        {
            var mockProcessor = new Mock<ServiceBusProcessor>() { CallBase = true };
            mockProcessor.Object.UpdatePrefetchCount(10);
            Assert.AreEqual(10, mockProcessor.Object.PrefetchCount);
        }

        [Test]
        public async Task CloseRespectsCancellationToken()
        {
            var mockProcessor = new Mock<ServiceBusProcessor>() {CallBase = true};
            mockProcessor.Setup(
                p => p.IsProcessing).Returns(true);
            var cts = new CancellationTokenSource();

            // mutate the cancellation token to distinguish it from CancellationToken.None
            cts.CancelAfter(500);

            await mockProcessor.Object.CloseAsync(cts.Token);
            mockProcessor.Verify(p => p.StopProcessingAsync(It.Is<CancellationToken>(ct => ct == cts.Token)));
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal class MockProcessor : ServiceBusProcessor
#pragma warning restore SA1402 // File may only contain a single type
    {
        public MockProcessor() : base()
        {
        }

        protected internal override async Task OnProcessMessageAsync(ProcessMessageEventArgs args)
        {
            await base.OnProcessMessageAsync(args);
        }

        protected internal override async Task OnProcessErrorAsync(ProcessErrorEventArgs args)
        {
            await base.OnProcessErrorAsync(args);
        }
    }
}
