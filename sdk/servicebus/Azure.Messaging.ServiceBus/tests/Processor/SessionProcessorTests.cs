// Copyright (c) Microsoft Corporation. All rights reserved.
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
    public class SessionProcessorTests : ServiceBusTestBase
    {
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
            };
            var processor = client.CreateSessionProcessor("queueName", options);
            Assert.AreEqual(options.AutoComplete, processor.AutoComplete);
            Assert.AreEqual(options.MaxConcurrentCalls, processor.MaxConcurrentCalls);
            Assert.AreEqual(options.PrefetchCount, processor.PrefetchCount);
            Assert.AreEqual(options.ReceiveMode, processor.ReceiveMode);
            Assert.AreEqual(options.MaxAutoLockRenewalDuration, processor.MaxAutoLockRenewalDuration);
            Assert.AreEqual(fullyQualifiedNamespace, processor.FullyQualifiedNamespace);
        }


        [Test]
        public async Task UserSettledPropertySetCorrectly()
        {
            var msg = new ServiceBusReceivedMessage();
            var args = new ProcessSessionMessageEventArgs(
                msg,
                new Mock<ServiceBusSessionReceiver>().Object,
                CancellationToken.None);

            Assert.IsFalse(args.UserSettled);

            args.UserSettled = false;
            await args.AbandonAsync(msg);
            Assert.IsTrue(args.UserSettled);

            await args.CompleteAsync(msg);
            Assert.IsTrue(args.UserSettled);

            args.UserSettled = false;
            await args.DeadLetterAsync(msg);
            Assert.IsTrue(args.UserSettled);

            args.UserSettled = false;
            await args.DeadLetterAsync(msg, "reason");
            Assert.IsTrue(args.UserSettled);

            args.UserSettled = false;
            await args.DeferAsync(msg);
            Assert.IsTrue(args.UserSettled);

            // getting or setting session state doesn't count as settling
            args.UserSettled = false;
            await args.GetSessionStateAsync();
            Assert.IsFalse(args.UserSettled);

            args.UserSettled = false;
            await args.SetSessionStateAsync(new byte[] { });
            Assert.IsFalse(args.UserSettled);
        }

        [Test]
        public void UserSettledPropertySetCorrectlyOnException()
        {
            var msg = new ServiceBusReceivedMessage();
            var mockReceiver = new Mock<ServiceBusSessionReceiver>();

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

            var args = new ProcessSessionMessageEventArgs(
                msg,
                mockReceiver.Object,
                CancellationToken.None);

            Assert.IsFalse(args.UserSettled);

            args.UserSettled = false;
            Assert.That(async () => await args.AbandonAsync(msg),
                Throws.InstanceOf<Exception>());
            Assert.IsFalse(args.UserSettled);

            Assert.That(async () => await args.CompleteAsync(msg),
                Throws.InstanceOf<Exception>());
            Assert.IsFalse(args.UserSettled);

            args.UserSettled = false;
            Assert.That(async () => await args.DeadLetterAsync(msg),
                Throws.InstanceOf<Exception>());
            Assert.IsFalse(args.UserSettled);

            args.UserSettled = false;
            Assert.That(async () => await args.DeadLetterAsync(msg, "reason"),
                Throws.InstanceOf<Exception>());
            Assert.IsFalse(args.UserSettled);

            args.UserSettled = false;
            Assert.That(async () => await args.DeferAsync(msg),
                Throws.InstanceOf<Exception>());
            Assert.IsFalse(args.UserSettled);
        }
    }
}
