// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Options;
using Xunit;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests
{
    public class MessagingProviderTests
    {
        [Fact]
        public void CreateMessageReceiver_ReturnsExpectedReceiver()
        {
            string defaultConnection = "Endpoint=sb://default.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=";
            var config = new ServiceBusOptions
            {
                ConnectionString = defaultConnection
            };
            var provider = new MessagingProvider(new OptionsWrapper<ServiceBusOptions>(config));
            var receiver = provider.CreateMessageReceiver("entityPath", defaultConnection);
            Assert.Equal("entityPath", receiver.Path);

            var receiver2 = provider.CreateMessageReceiver("entityPath", defaultConnection);
            Assert.Same(receiver, receiver2);

            config.PrefetchCount = 100;
            receiver = provider.CreateMessageReceiver("entityPath1", defaultConnection);
            Assert.Equal(100, receiver.PrefetchCount);
        }

        [Fact]
        public void CreateClientEntity_ReturnsExpectedReceiver()
        {
            string defaultConnection = "Endpoint=sb://default.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=";
            var config = new ServiceBusOptions
            {
                ConnectionString = defaultConnection
            };
            var provider = new MessagingProvider(new OptionsWrapper<ServiceBusOptions>(config));
            var clientEntity = provider.CreateClientEntity("entityPath", defaultConnection);
            Assert.Equal("entityPath", clientEntity.Path);

            var receiver2 = provider.CreateClientEntity("entityPath", defaultConnection);
            Assert.Same(clientEntity, receiver2);

            config.PrefetchCount = 100;
            clientEntity = provider.CreateClientEntity("entityPath1", defaultConnection);
            Assert.Equal(100, ((QueueClient)clientEntity).PrefetchCount);
        }

        [Fact]
        public void CreateMessageSender_ReturnsExpectedSender()
        {
            string defaultConnection = "Endpoint=sb://default.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=";
            var config = new ServiceBusOptions
            {
                ConnectionString = defaultConnection
            };
            var provider = new MessagingProvider(new OptionsWrapper<ServiceBusOptions>(config));
            var sender = provider.CreateMessageSender("entityPath", defaultConnection);
            Assert.Equal("entityPath", sender.Path);

            var sender2 = provider.CreateMessageSender("entityPath", defaultConnection);
            Assert.Same(sender, sender2);
        }
    }
}
