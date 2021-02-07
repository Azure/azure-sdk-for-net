// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests
{
    public class MessagingProviderTests
    {
        [Test]
        public void CreateMessageReceiver_ReturnsExpectedReceiver()
        {
            string defaultConnection = "Endpoint=sb://default.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=";
            var config = new ServiceBusOptions
            {
                ConnectionString = defaultConnection
            };
            var provider = new MessagingProvider(new OptionsWrapper<ServiceBusOptions>(config));
            var receiver = provider.CreateMessageReceiver("entityPath", defaultConnection);
            Assert.AreEqual("entityPath", receiver.Path);

            var receiver2 = provider.CreateMessageReceiver("entityPath", defaultConnection);
            Assert.AreSame(receiver, receiver2);

            config.PrefetchCount = 100;
            receiver = provider.CreateMessageReceiver("entityPath1", defaultConnection);
            Assert.AreEqual(100, receiver.PrefetchCount);
        }

        [Test]
        public void CreateClientEntity_ReturnsExpectedReceiver()
        {
            string defaultConnection = "Endpoint=sb://default.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=";
            var config = new ServiceBusOptions
            {
                ConnectionString = defaultConnection
            };
            var provider = new MessagingProvider(new OptionsWrapper<ServiceBusOptions>(config));
            var clientEntity = provider.CreateClientEntity("entityPath", defaultConnection);
            Assert.AreEqual("entityPath", clientEntity.Path);

            var receiver2 = provider.CreateClientEntity("entityPath", defaultConnection);
            Assert.AreSame(clientEntity, receiver2);

            config.PrefetchCount = 100;
            clientEntity = provider.CreateClientEntity("entityPath1", defaultConnection);
            Assert.AreEqual(100, ((QueueClient)clientEntity).PrefetchCount);
        }

        [Test]
        public void CreateMessageSender_ReturnsExpectedSender()
        {
            string defaultConnection = "Endpoint=sb://default.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=";
            var config = new ServiceBusOptions
            {
                ConnectionString = defaultConnection
            };
            var provider = new MessagingProvider(new OptionsWrapper<ServiceBusOptions>(config));
            var sender = provider.CreateMessageSender("entityPath", defaultConnection);
            Assert.AreEqual("entityPath", sender.Path);

            var sender2 = provider.CreateMessageSender("entityPath", defaultConnection);
            Assert.AreSame(sender, sender2);
        }
    }
}
