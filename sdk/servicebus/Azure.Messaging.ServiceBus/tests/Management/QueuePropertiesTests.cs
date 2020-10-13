// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Messaging.ServiceBus.Management;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Management
{
    public class QueuePropertiesTests
    {
        [Test]
        [TestCase("sb://fakepath/", 261)]
        [TestCase("", 261)]
        public void ForwardToThrowsArgumentOutOfRangeException(string baseUrl, int lengthOfName)
        {
            var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
            var sub = new QueueProperties("Fake SubscriptionName");

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sub.ForwardTo = $"{baseUrl}{longName}");

            Assert.AreEqual($"Entity path '{longName}' exceeds the '260' character limit.{Environment.NewLine}Parameter name: ForwardTo", ex.Message);
            Assert.AreEqual($"ForwardTo", ex.ParamName);
        }

        [Test]
        public void AutoDeleteOnIdleThrowsOutOfRangeException()
        {
            var sub = new QueueProperties("Fake Name");
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => sub.AutoDeleteOnIdle = TimeSpan.FromMinutes(2));

            Assert.AreEqual($"The value supplied must be greater than or equal to {ManagementClientConstants.MinimumAllowedAutoDeleteOnIdle}.{Environment.NewLine}Parameter name: AutoDeleteOnIdle", ex.Message);
            Assert.AreEqual($"AutoDeleteOnIdle", ex.ParamName);
        }

        [Test]
        [TestCase("sb://fakepath/", 261)]
        [TestCase("", 261)]
        public void ForwardDeadLetteredMessagesToThrowsArgumentOutOfRangeException(string baseUrl, int lengthOfName)
        {
            var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
            var sub = new QueueProperties("Fake SubscriptionName");

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sub.ForwardDeadLetteredMessagesTo = $"{baseUrl}{longName}");

            Assert.AreEqual($"Entity path '{longName}' exceeds the '260' character limit.{Environment.NewLine}Parameter name: ForwardDeadLetteredMessagesTo", ex.Message);
            Assert.AreEqual($"ForwardDeadLetteredMessagesTo", ex.ParamName);
        }

        [Test]
        [TestCase("sb://fakepath/", 261)]
        [TestCase("", 261)]
        public void PathToThrowsArgumentOutOfRangeException(string baseUrl, int lengthOfName)
        {
            var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
            var sub = new CreateQueueOptions("Fake SubscriptionName");

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sub.Name = $"{baseUrl}{longName}");

            Assert.AreEqual($"Entity path '{longName}' exceeds the '260' character limit.{Environment.NewLine}Parameter name: Name", ex.Message);
            Assert.AreEqual($"Name", ex.ParamName);
        }

        [Test]
        [TestCase("sb://fakepath/", 260)]
        [TestCase("", 260)]
        public void ForwardToAllowsMaxLengthMinusBaseUrl(string baseUrl, int lengthOfName)
        {
            var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
            var sub = new QueueProperties("Fake SubscriptionName");
            sub.ForwardTo = $"{baseUrl}{longName}";
            Assert.AreEqual($"{baseUrl}{longName}", sub.ForwardTo);
        }

        [Test]
        [TestCase("sb://fakepath/", 260)]
        [TestCase("", 260)]
        public void ForwardDeadLetteredMessagesToAllowsMaxLengthMinusBaseUrl(string baseUrl, int lengthOfName)
        {
            var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
            var sub = new QueueProperties("Fake SubscriptionName");
            sub.ForwardDeadLetteredMessagesTo = $"{baseUrl}{longName}";
            Assert.AreEqual($"{baseUrl}{longName}", sub.ForwardDeadLetteredMessagesTo);
        }

        [Test]
        [TestCase("sb://fakepath/", 260)]
        [TestCase("", 260)]
        public void PathAllowsMaxLengthMinusBaseUrl(string baseUrl, int lengthOfName)
        {
            var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
            var sub = new CreateQueueOptions("Fake SubscriptionName");
            sub.Name = $"{baseUrl}{longName}";
            Assert.AreEqual($"{baseUrl}{longName}", sub.Name);
        }
    }
}
