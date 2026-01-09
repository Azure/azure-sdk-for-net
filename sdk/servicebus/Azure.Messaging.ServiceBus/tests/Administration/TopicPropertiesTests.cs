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
            Assert.Multiple(() =>
            {
                Assert.That(properties.Name, Is.EqualTo("topicName"));
                Assert.That(properties.MaxSizeInMegabytes, Is.EqualTo(100));
                Assert.That(properties.RequiresDuplicateDetection, Is.True);
                Assert.That(properties.DefaultMessageTimeToLive, Is.EqualTo(TimeSpan.FromSeconds(10)));
                Assert.That(properties.AutoDeleteOnIdle, Is.EqualTo(TimeSpan.FromMinutes(5)));
                Assert.That(properties.DuplicateDetectionHistoryTimeWindow, Is.EqualTo(TimeSpan.FromMinutes(10)));
                Assert.That(properties.EnableBatchedOperations, Is.False);
                Assert.That(properties.Status, Is.EqualTo(EntityStatus.Active));
                Assert.That(properties.EnablePartitioning, Is.True);
                Assert.That(properties.MaxMessageSizeInKilobytes, Is.EqualTo(2000));
            });
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
            Assert.Multiple(() =>
            {
                Assert.That(properties.Name, Is.EqualTo("topicName"));
                Assert.That(properties.ScheduledMessageCount, Is.EqualTo(10));
                Assert.That(properties.SizeInBytes, Is.EqualTo(1000));
                Assert.That(properties.SubscriptionCount, Is.EqualTo(5));
                Assert.That(properties.CreatedAt, Is.EqualTo(twoDaysAgo));
                Assert.That(properties.UpdatedAt, Is.EqualTo(yesterday));
                Assert.That(properties.AccessedAt, Is.EqualTo(today));
            });
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

            Assert.That(new CreateTopicOptions(properties), Is.EqualTo(options));
        }
    }
}
