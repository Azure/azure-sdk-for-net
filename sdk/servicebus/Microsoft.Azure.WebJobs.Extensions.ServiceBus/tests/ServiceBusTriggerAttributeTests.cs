// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests
{
    public class ServiceBusTriggerAttributeTests
    {
        [Test]
        public void Constructor_Queue_SetsExpectedValues()
        {
            ServiceBusTriggerAttribute attribute = new ServiceBusTriggerAttribute("testqueue");
            Assert.AreEqual("testqueue", attribute.QueueName);
            Assert.Null(attribute.SubscriptionName);
            Assert.Null(attribute.TopicName);

            attribute = new ServiceBusTriggerAttribute("testqueue");
            Assert.AreEqual("testqueue", attribute.QueueName);
            Assert.Null(attribute.SubscriptionName);
            Assert.Null(attribute.TopicName);
        }

        [Test]
        public void Constructor_Topic_SetsExpectedValues()
        {
            ServiceBusTriggerAttribute attribute = new ServiceBusTriggerAttribute("testtopic", "testsubscription");
            Assert.Null(attribute.QueueName);
            Assert.AreEqual("testtopic", attribute.TopicName);
            Assert.AreEqual("testsubscription", attribute.SubscriptionName);

            attribute = new ServiceBusTriggerAttribute("testtopic", "testsubscription");
            Assert.Null(attribute.QueueName);
            Assert.AreEqual("testtopic", attribute.TopicName);
            Assert.AreEqual("testsubscription", attribute.SubscriptionName);
        }
    }
}
