// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Receiver
{
    public class ReceiverTests : ServiceBusTestBase
    {
        [Test]
        public void ClientProperties()
        {
            var account = Encoding.Default.GetString(GetRandomBuffer(12));
            var fullyQualifiedNamespace = new UriBuilder($"{account}.servicebus.windows.net/").Host;
            var connString = $"Endpoint=sb://{fullyQualifiedNamespace};SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey={Encoding.Default.GetString(GetRandomBuffer(64))}";
            var queueName = Encoding.Default.GetString(GetRandomBuffer(12));
            var options = new ServiceBusReceiverOptions()
            {
                ReceiveMode = ReceiveMode.ReceiveAndDelete
            };
            var receiver = new ServiceBusClient(connString).CreateReceiver(queueName, options);
            Assert.AreEqual(queueName, receiver.EntityPath);
            Assert.AreEqual(fullyQualifiedNamespace, receiver.FullyQualifiedNamespace);
            Assert.IsNotNull(receiver.Identifier);
            Assert.IsFalse(receiver.IsSessionReceiver);
            Assert.AreEqual(ReceiveMode.ReceiveAndDelete, receiver.ReceiveMode);
        }

        [Test]
        public void ReceiverOptionsValidation()
        {
            var options = new ServiceBusReceiverOptions();
            Assert.That(
                () => options.PrefetchCount = -1,
                Throws.InstanceOf<ArgumentOutOfRangeException>());

            // should not throw
            options.PrefetchCount = 0;
        }

        [Test]
        public void ReceiveValidatesMaxWaitTime()
        {
            var account = Encoding.Default.GetString(GetRandomBuffer(12));
            var fullyQualifiedNamespace = new UriBuilder($"{account}.servicebus.windows.net/").Host;
            var connString = $"Endpoint=sb://{fullyQualifiedNamespace};SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey={Encoding.Default.GetString(GetRandomBuffer(64))}";
            var client = new ServiceBusClient(connString);
            var receiver = client.CreateReceiver("queue");
            Assert.That(
                async () => await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(0)),
                Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(
                async () => await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(-1)),
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }
}
