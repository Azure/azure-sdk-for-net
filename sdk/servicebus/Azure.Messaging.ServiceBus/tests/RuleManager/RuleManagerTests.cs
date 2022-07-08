// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.RuleManager
{
    public class RuleManagerTests
    {
        [Test]
        public void PropertiesSetCorrectlyConnectionString()
        {
            var client = new ServiceBusClient(
                "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];");
            var ruleManager = client.CreateRuleManager("topic", "subscription");
            Assert.AreEqual("topic/Subscriptions/subscription", ruleManager.SubscriptionPath);
            Assert.AreEqual("not-real.servicebus.windows.net", ruleManager.FullyQualifiedNamespace);
        }

        [Test]
        public void PropertiesSetCorrectlyCredential()
        {
            var client = new ServiceBusClient("not-real.servicebus.windows.net", new MockCredential());
            var ruleManager = client.CreateRuleManager("topic", "subscription");
            Assert.AreEqual("topic/Subscriptions/subscription", ruleManager.SubscriptionPath);
            Assert.AreEqual("not-real.servicebus.windows.net", ruleManager.FullyQualifiedNamespace);
        }
    }
}