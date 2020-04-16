// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
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
    }
}
