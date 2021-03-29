// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests
{
    public class ClientFactoryTests
    {
        [Test]
        public void CreateMessageReceiver_ReturnsExpectedReceiver()
        {
            string defaultConnection = "Endpoint=sb://default.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=";
            var options = new ServiceBusOptions();
            var configuration = CreateConfiguration(new KeyValuePair<string, string>("connection", defaultConnection));

            var provider = new ServiceBusClientFactory(configuration, Mock.Of<AzureComponentFactory>(), new OptionsWrapper<ServiceBusOptions>(options), new AzureEventSourceLogForwarder(new NullLoggerFactory()));

            var receiver = provider.CreateBatchMessageReceiver("entityPath", "connection");
            Assert.AreEqual("entityPath", receiver.EntityPath);

            var receiver2 = provider.CreateBatchMessageReceiver("entityPath", "connection");
            Assert.AreSame(receiver, receiver2);

            options.PrefetchCount = 100;
            receiver = provider.CreateBatchMessageReceiver("entityPath1", "connection");
            Assert.AreEqual(100, receiver.PrefetchCount);
        }

        [Test]
        public void CreateProcessor_ReturnsExpectedProcessor()
        {
            string defaultConnection = "Endpoint=sb://default.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=";
            var options = new ServiceBusOptions();
            var configuration = CreateConfiguration(new KeyValuePair<string, string>("connection", defaultConnection));
            var provider = new ServiceBusClientFactory(configuration, Mock.Of<AzureComponentFactory>(), new OptionsWrapper<ServiceBusOptions>(options), new AzureEventSourceLogForwarder(new NullLoggerFactory()));

            var processor = provider.CreateProcessor("entityPath", "connection");
            Assert.AreEqual("entityPath", processor.EntityPath);

            var processor2 = provider.CreateProcessor("entityPath", "connection");
            Assert.AreSame(processor, processor2);

            options.PrefetchCount = 100;
            options.MaxConcurrentCalls = 5;
            options.MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(30);
            processor = provider.CreateProcessor("entityPath1", "connection");
            Assert.AreEqual(options.PrefetchCount, processor.PrefetchCount);
            Assert.AreEqual(options.MaxConcurrentCalls, processor.MaxConcurrentCalls);
            Assert.AreEqual(options.MaxAutoLockRenewalDuration, processor.MaxAutoLockRenewalDuration);
        }

        [Test]
        public void CreateMessageSender_ReturnsExpectedSender()
        {
            string defaultConnection = "Endpoint=sb://default.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=";
            var options = new ServiceBusOptions();

            var configuration = CreateConfiguration(new KeyValuePair<string, string>("connection", defaultConnection));
            var provider = new ServiceBusClientFactory(configuration, Mock.Of<AzureComponentFactory>(), new OptionsWrapper<ServiceBusOptions>(options), new AzureEventSourceLogForwarder(new NullLoggerFactory()));

            var sender = provider.CreateMessageSender("entityPath", "connection");
            Assert.AreEqual("entityPath", sender.EntityPath);

            var sender2 = provider.CreateMessageSender("entityPath", "connection");
            Assert.AreSame(sender, sender2);
        }

        private IConfiguration CreateConfiguration(params KeyValuePair<string, string>[] data)
        {
            return new ConfigurationBuilder().AddInMemoryCollection(data).Build();
        }
    }
}
