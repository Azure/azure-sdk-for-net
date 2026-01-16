// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Messaging.ServiceBus;
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
    public class MessagingProviderTests
    {
        private static string _defaultConnection = "Endpoint=sb://default.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=";
        private static ServiceBusClient _client = new(_defaultConnection);

        private static string _secondaryConnection = "Endpoint=sb://default2.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=";
        private static ServiceBusClient _secondaryClient = new(_secondaryConnection);

        [Test]
        public void CreateMessageReceiver_ReturnsExpectedReceiver()
        {
            var options = new ServiceBusOptions();

            var provider = new MessagingProvider(new OptionsWrapper<ServiceBusOptions>(options));
            var receiverOptions = options.ToReceiverOptions();

            var receiver = provider.CreateBatchMessageReceiver(_client, "entityPath", receiverOptions);
            Assert.That(receiver.EntityPath, Is.EqualTo("entityPath"));

            var receiver2 = provider.CreateBatchMessageReceiver(_client, "entityPath", receiverOptions);
            Assert.That(receiver2, Is.SameAs(receiver));

            options.PrefetchCount = 100;
            receiver = provider.CreateBatchMessageReceiver(_client, "entityPath1", options.ToReceiverOptions());
            Assert.That(receiver.PrefetchCount, Is.EqualTo(100));
        }

        [Test]
        public void CreateProcessor_ReturnsExpectedProcessor()
        {
            var options = new ServiceBusOptions();
            var provider = new MessagingProvider(new OptionsWrapper<ServiceBusOptions>(options));
            var processorOptions = options.ToProcessorOptions(options.AutoCompleteMessages, false);

            var processor = provider.CreateProcessor(_client, "entityPath", processorOptions);
            Assert.That(processor.EntityPath, Is.EqualTo("entityPath"));

            var processor2 = provider.CreateProcessor(_client, "entityPath", processorOptions);
            Assert.That(processor2, Is.Not.SameAs(processor));

            options.PrefetchCount = 100;
            options.MaxConcurrentCalls = 5;
            options.MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(30);
            processor = provider.CreateProcessor(_client, "entityPath1", options.ToProcessorOptions(options.AutoCompleteMessages, false));
            Assert.That(processor.PrefetchCount, Is.EqualTo(options.PrefetchCount));
            Assert.That(processor.MaxConcurrentCalls, Is.EqualTo(options.MaxConcurrentCalls));
            Assert.That(processor.MaxAutoLockRenewalDuration, Is.EqualTo(options.MaxAutoLockRenewalDuration));
        }

        [Test]
        public void CreateSessionProcessor_ReturnsExpectedProcessor()
        {
            var options = new ServiceBusOptions();
            var provider = new MessagingProvider(new OptionsWrapper<ServiceBusOptions>(options));
            var processorOptions = options.ToSessionProcessorOptions(options.AutoCompleteMessages, false);

            var processor = provider.CreateSessionProcessor(_client, "entityPath", processorOptions);
            Assert.That(processor.EntityPath, Is.EqualTo("entityPath"));

            var processor2 = provider.CreateSessionProcessor(_client, "entityPath", processorOptions);
            Assert.That(processor2, Is.Not.SameAs(processor));

            options.PrefetchCount = 100;
            options.MaxConcurrentSessions = 5;
            options.MaxAutoLockRenewalDuration = TimeSpan.FromSeconds(30);
            processor = provider.CreateSessionProcessor(_client, "entityPath1", options.ToSessionProcessorOptions(options.AutoCompleteMessages, false));
            Assert.That(processor.PrefetchCount, Is.EqualTo(options.PrefetchCount));
            Assert.That(processor.MaxConcurrentSessions, Is.EqualTo(options.MaxConcurrentSessions));
            Assert.That(processor.MaxAutoLockRenewalDuration, Is.EqualTo(options.MaxAutoLockRenewalDuration));
        }

        [Test]
        public void CreateMessageSender_ReturnsExpectedSender()
        {
            string defaultConnection = "Endpoint=sb://default.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=";
            var options = new ServiceBusOptions();

            var configuration = CreateConfiguration(new KeyValuePair<string, string>("connection", defaultConnection));
            var provider = new MessagingProvider(new OptionsWrapper<ServiceBusOptions>(options));

            var sender = provider.CreateMessageSender(_client, "entityPath");
            Assert.That(sender.EntityPath, Is.EqualTo("entityPath"));

            var sender2 = provider.CreateMessageSender(_client, "entityPath");
            Assert.That(sender2, Is.SameAs(sender));
        }

        [Test]
        public void CreateMessageSender_MultipleNamespacesWithSameEntityName_ReturnsCorrectSender()
        {
            var options = new ServiceBusOptions();

            var provider = new MessagingProvider(new OptionsWrapper<ServiceBusOptions>(options));

            var sender1 = provider.CreateMessageSender(_client, "entityPath");
            Assert.That(sender1.EntityPath, Is.EqualTo("entityPath"));
            Assert.That(sender1.FullyQualifiedNamespace, Is.EqualTo(_client.FullyQualifiedNamespace));

            var sender2 = provider.CreateMessageSender(_secondaryClient, "entityPath");
            Assert.That(sender2, Is.Not.SameAs(sender1));
            Assert.That(sender2.EntityPath, Is.EqualTo("entityPath"));
            Assert.That(sender2.FullyQualifiedNamespace, Is.EqualTo(_secondaryClient.FullyQualifiedNamespace));
        }

        [Test]
        public void CreateMessageReceiver_MultipleNamespacesWithSameEntityName_ReturnsCorrectReceiver()
        {
            var options = new ServiceBusOptions();

            var provider = new MessagingProvider(new OptionsWrapper<ServiceBusOptions>(options));

            var receiver1 = provider.CreateBatchMessageReceiver(_client, "entityPath", new ServiceBusReceiverOptions());
            Assert.That(receiver1.EntityPath, Is.EqualTo("entityPath"));
            Assert.That(receiver1.FullyQualifiedNamespace, Is.EqualTo(_client.FullyQualifiedNamespace));

            var receiver2 = provider.CreateBatchMessageReceiver(_secondaryClient, "entityPath", new ServiceBusReceiverOptions());
            Assert.That(receiver2, Is.Not.SameAs(receiver1));
            Assert.That(receiver2.EntityPath, Is.EqualTo("entityPath"));
            Assert.That(receiver2.FullyQualifiedNamespace, Is.EqualTo(_secondaryClient.FullyQualifiedNamespace));
        }

        private IConfiguration CreateConfiguration(params KeyValuePair<string, string>[] data)
        {
            return new ConfigurationBuilder().AddInMemoryCollection(data).Build();
        }
    }
}
