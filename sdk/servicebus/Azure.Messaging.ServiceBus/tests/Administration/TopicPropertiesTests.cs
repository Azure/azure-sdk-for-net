// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.ServiceBus.Administration;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Management
{
    public class TopicPropertiesTests
    {
        [Test]
        public void CanCreateTopicPropertiesFromFactory()
        {
            var properties = ServiceBusModelFactory.TopicProperties(
                "topicName",
                100,
                true,
                TimeSpan.FromSeconds(10),
                TimeSpan.FromMinutes(5),
                TimeSpan.FromMinutes(10),
                false,
                EntityStatus.Active,
                true,
                2000);
            Assert.AreEqual("topicName", properties.Name);
            Assert.AreEqual(100, properties.MaxSizeInMegabytes);
            Assert.IsTrue(properties.RequiresDuplicateDetection);
            Assert.AreEqual(TimeSpan.FromSeconds(10), properties.DefaultMessageTimeToLive);
            Assert.AreEqual(TimeSpan.FromMinutes(5), properties.AutoDeleteOnIdle);
            Assert.AreEqual(TimeSpan.FromMinutes(10), properties.DuplicateDetectionHistoryTimeWindow);
            Assert.IsFalse(properties.EnableBatchedOperations);
            Assert.AreEqual(EntityStatus.Active, properties.Status);
            Assert.IsTrue(properties.EnablePartitioning);
            Assert.AreEqual(2000, properties.MaxMessageSizeInKilobytes);
        }

        [Test]
        public void CanCreateTopicRuntimePropertiesFromFactory()
        {
            var today = DateTimeOffset.Now;
            var yesterday = today.Subtract(TimeSpan.FromDays(1));
            var twoDaysAgo = today.Subtract(TimeSpan.FromDays(2));
            var properties = ServiceBusModelFactory.TopicRuntimeProperties(
                "topicName",
                10,
                1000,
                5,
                twoDaysAgo,
                yesterday,
                today);
            Assert.AreEqual("topicName", properties.Name);
            Assert.AreEqual(10, properties.ScheduledMessageCount);
            Assert.AreEqual(1000, properties.SizeInBytes);
            Assert.AreEqual(5, properties.SubscriptionCount);
            Assert.AreEqual(twoDaysAgo, properties.CreatedAt);
            Assert.AreEqual(yesterday, properties.UpdatedAt);
            Assert.AreEqual(today, properties.AccessedAt);
        }

        [Test]
        public void CanCreateTopicPropertiesFromOptions()
        {
            var options = new CreateTopicOptions("topic")
            {
                MaxSizeInMegabytes = 1024,
                RequiresDuplicateDetection = true,
                DefaultMessageTimeToLive = TimeSpan.FromSeconds(120),
                AutoDeleteOnIdle = TimeSpan.FromMinutes(10),
                DuplicateDetectionHistoryTimeWindow = TimeSpan.FromSeconds(100),
                EnableBatchedOperations = true,
                AuthorizationRules = { new SharedAccessAuthorizationRule("key", new AccessRights[] { AccessRights.Listen }) },
                Status = EntityStatus.Disabled,
                EnablePartitioning = true,
                UserMetadata = "metadata",
                MaxMessageSizeInKilobytes = 2000
            };
            var properties = new TopicProperties(options);

            Assert.AreEqual(options, new CreateTopicOptions(properties));
        }
    }
}
