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
                EntityStatus.Active);
            Assert.AreEqual("topicName", properties.Name);
            Assert.AreEqual(100, properties.MaxSizeInMegabytes);
            Assert.IsTrue(properties.RequiresDuplicateDetection);
            Assert.AreEqual(TimeSpan.FromSeconds(10), properties.DefaultMessageTimeToLive);
            Assert.AreEqual(TimeSpan.FromMinutes(5), properties.AutoDeleteOnIdle);
            Assert.AreEqual(TimeSpan.FromMinutes(10), properties.DuplicateDetectionHistoryTimeWindow);
            Assert.IsFalse(properties.EnableBatchedOperations);
            Assert.AreEqual(EntityStatus.Active, properties.Status);
        }
    }
}
