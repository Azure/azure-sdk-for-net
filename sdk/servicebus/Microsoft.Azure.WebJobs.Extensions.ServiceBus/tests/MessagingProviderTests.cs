// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Options;
using NUnit.Framework;
using System;

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
            var receiver = provider.CreateBatchMessageReceiver("entityPath", defaultConnection);
            Assert.AreEqual("entityPath", receiver.EntityPath);

            var receiver2 = provider.CreateBatchMessageReceiver("entityPath", defaultConnection);
            Assert.AreSame(receiver, receiver2);

            config.PrefetchCount = 100;
            receiver = provider.CreateBatchMessageReceiver("entityPath1", defaultConnection);
            Assert.AreEqual(100, receiver.PrefetchCount);
        }

        [Test]
        public void CreateProcessor_ReturnsExpectedProcessor()
        {
            string defaultConnection = "Endpoint=sb://default.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=";
            var config = new ServiceBusOptions
            {
                ConnectionString = defaultConnection
            };
            var provider = new MessagingProvider(new OptionsWrapper<ServiceBusOptions>(config));
            var processor = provider.CreateProcessor("entityPath", defaultConnection);
            Assert.AreEqual("entityPath", processor.EntityPath);

            var processor2 = provider.CreateProcessor("entityPath", defaultConnection);
            Assert.AreSame(processor, processor2);

            config.PrefetchCount = 100;
            config.MaxConcurrentCalls = 5;
            config.MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(30);
            processor = provider.CreateProcessor("entityPath1", defaultConnection);
            Assert.AreEqual(config.PrefetchCount, processor.PrefetchCount);
            Assert.AreEqual(config.MaxConcurrentCalls, processor.MaxConcurrentCalls);
            Assert.AreEqual(config.MaxAutoLockRenewalDuration, processor.MaxAutoLockRenewalDuration);
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
            Assert.AreEqual("entityPath", sender.EntityPath);

            var sender2 = provider.CreateMessageSender("entityPath", defaultConnection);
            Assert.AreSame(sender, sender2);
        }
    }
}
