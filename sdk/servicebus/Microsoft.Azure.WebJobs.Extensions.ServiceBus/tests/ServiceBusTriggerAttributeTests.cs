// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Xunit;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests
{
    public class ServiceBusTriggerAttributeTests
    {
        [Fact]
        public void Constructor_Queue_SetsExpectedValues()
        {
            ServiceBusTriggerAttribute attribute = new ServiceBusTriggerAttribute("testqueue");
            Assert.Equal("testqueue", attribute.QueueName);
            Assert.Null(attribute.SubscriptionName);
            Assert.Null(attribute.TopicName);

            attribute = new ServiceBusTriggerAttribute("testqueue");
            Assert.Equal("testqueue", attribute.QueueName);
            Assert.Null(attribute.SubscriptionName);
            Assert.Null(attribute.TopicName);
        }

        [Fact]
        public void Constructor_Topic_SetsExpectedValues()
        {
            ServiceBusTriggerAttribute attribute = new ServiceBusTriggerAttribute("testtopic", "testsubscription");
            Assert.Null(attribute.QueueName);
            Assert.Equal("testtopic", attribute.TopicName);
            Assert.Equal("testsubscription", attribute.SubscriptionName);

            attribute = new ServiceBusTriggerAttribute("testtopic", "testsubscription");
            Assert.Null(attribute.QueueName);
            Assert.Equal("testtopic", attribute.TopicName);
            Assert.Equal("testsubscription", attribute.SubscriptionName);
        }
    }
}
