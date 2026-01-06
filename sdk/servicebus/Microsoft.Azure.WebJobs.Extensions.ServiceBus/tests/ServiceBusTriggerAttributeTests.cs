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
            Assert.Multiple(() =>
            {
                Assert.That(attribute.QueueName, Is.EqualTo("testqueue"));
                Assert.That(attribute.SubscriptionName, Is.Null);
                Assert.That(attribute.TopicName, Is.Null);
            });

            attribute = new ServiceBusTriggerAttribute("testqueue");
            Assert.Multiple(() =>
            {
                Assert.That(attribute.QueueName, Is.EqualTo("testqueue"));
                Assert.That(attribute.SubscriptionName, Is.Null);
                Assert.That(attribute.TopicName, Is.Null);
            });
        }

        [Test]
        public void Constructor_Topic_SetsExpectedValues()
        {
            ServiceBusTriggerAttribute attribute = new ServiceBusTriggerAttribute("testtopic", "testsubscription");
            Assert.Multiple(() =>
            {
                Assert.That(attribute.QueueName, Is.Null);
                Assert.That(attribute.TopicName, Is.EqualTo("testtopic"));
                Assert.That(attribute.SubscriptionName, Is.EqualTo("testsubscription"));
            });

            attribute = new ServiceBusTriggerAttribute("testtopic", "testsubscription");
            Assert.Multiple(() =>
            {
                Assert.That(attribute.QueueName, Is.Null);
                Assert.That(attribute.TopicName, Is.EqualTo("testtopic"));
                Assert.That(attribute.SubscriptionName, Is.EqualTo("testsubscription"));
            });
        }
    }
}
