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
        public void NonSessionReceiverCannotAccessSessionProperties()
        {
            var account = Encoding.Default.GetString(GetRandomBuffer(12));
            var fullyQualifiedNamespace = new UriBuilder($"{account}.servicebus.windows.net/").Host;
            var connString = $"Endpoint=sb://{fullyQualifiedNamespace};SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey={Encoding.Default.GetString(GetRandomBuffer(64))}";
            var client = new ServiceBusClient(connString);
            var receiver = client.GetReceiver("fakeQueue");

            Assert.IsFalse(receiver.IsSessionReceiver);
            Assert.That(() => receiver.SessionManager, Throws.InstanceOf<NotSupportedException>());
        }

        [Test]
        public void SessionReceiverCanAccessSessionProperties()
        {
            var receiver = new ServiceBusReceiver(
                Mock.Of<ServiceBusConnection>(),
                "fakeQueue",
                true,
                options: new ServiceBusReceiverOptions());

            // should not throw
            var sessionManager = receiver.SessionManager;
            Assert.IsTrue(receiver.IsSessionReceiver);
        }

        [Test]
        public void SessionReceiverCannotPerformMessageLock()
        {
            var receiver = new ServiceBusReceiver(
                Mock.Of<ServiceBusConnection>(),
                "fakeQueue",
                true,
                options: new ServiceBusReceiverOptions());

            Assert.That(async () => await receiver.RenewMessageLockAsync(
                new ServiceBusReceivedMessage()),
                Throws.InstanceOf<InvalidOperationException>());
        }

        //[Test]
        // TODO add test that validates service error thrown
        // now that we removed assumption that subscription path
        // won't ever be passed into queueName property.
        //public void NonSubscriptionReceiver_CannotAccessSubscriptionProperties()
        //{
        //    var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
        //    var receiver = client.GetReceiver("fakeQueue");

        //    Assert.IsFalse(receiver.IsSessionReceiver);
        //    Assert.That(() => receiver.SubscriptionManager, Throws.InstanceOf<NotSupportedException>());
        //}

        //[Test]
        //public void SubscriptionReceiver_CanAccessSubscriptionProperties()
        //{
        //    var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
        //    var receiver = client.GetSubscriptionReceiver("fakeTopic", "fakeSubscription");

        //    // should not throw
        //    var subscriptionManager =  receiver.SubscriptionManager;
        //    Assert.IsFalse(receiver.IsSessionReceiver);
        //}

        [Test]
        public void ClientProperties()
        {
            var account = Encoding.Default.GetString(GetRandomBuffer(12));
            var fullyQualifiedNamespace = new UriBuilder($"{account}.servicebus.windows.net/").Host;
            var connString = $"Endpoint=sb://{fullyQualifiedNamespace};SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey={Encoding.Default.GetString(GetRandomBuffer(64))}";
            var queueName = Encoding.Default.GetString(GetRandomBuffer(12));
            var receiver = new ServiceBusClient(connString).GetReceiver(queueName);
            Assert.AreEqual(queueName, receiver.EntityPath);
            Assert.AreEqual(fullyQualifiedNamespace, receiver.FullyQualifiedNamespace);
            Assert.IsNotNull(receiver.Identifier);
            Assert.IsFalse(receiver.IsSessionReceiver);
        }
    }
}
