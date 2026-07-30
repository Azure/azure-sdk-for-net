// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Xml.Linq;
using Azure.Core.TestFramework;
using Azure.Messaging.ServiceBus.Administration;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Management
{
    public class TopicRuntimePropertiesTests
    {
        private const string AtomNs = "http://www.w3.org/2005/Atom";
        private const string SbNs = "http://schemas.microsoft.com/netservices/2010/10/servicebus/connect";

        private static XElement BuildTopicEntry(string topicDescriptionInnerXml) =>
            XElement.Parse(
                $"<entry xmlns=\"{AtomNs}\">" +
                    "<title>my-topic</title>" +
                    "<content>" +
                        $"<TopicDescription xmlns=\"{SbNs}\">" +
                            topicDescriptionInnerXml +
                        "</TopicDescription>" +
                    "</content>" +
                "</entry>");

        [Test]
        public void CanCreateTopicRuntimePropertiesFromFactory()
        {
            TopicRuntimeProperties properties = ServiceBusModelFactory.TopicRuntimeProperties(
                name: "topicName",
                scheduledMessageCount: 3,
                sizeInBytes: 1024,
                subscriptionCount: 4,
                sqlFilterCount: 5,
                correlationFilterCount: 6);

            Assert.AreEqual("topicName", properties.Name);
            Assert.AreEqual(3, properties.ScheduledMessageCount);
            Assert.AreEqual(1024, properties.SizeInBytes);
            Assert.AreEqual(4, properties.SubscriptionCount);
            Assert.AreEqual(5, properties.SqlFilterCount);
            Assert.AreEqual(6, properties.CorrelationFilterCount);
        }

        [Test]
        public void CanCreateTopicRuntimePropertiesFromLegacyFactoryOverload()
        {
            // The 7-parameter overload predates the filter counts and is retained for binary
            // compatibility. A 7-positional-argument call binds to it (not the extended
            // overload), so the new counts must default to zero rather than being uninitialized.
            var created = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);
            var updated = new DateTimeOffset(2024, 1, 2, 0, 0, 0, TimeSpan.Zero);
            var accessed = new DateTimeOffset(2024, 1, 3, 0, 0, 0, TimeSpan.Zero);

            TopicRuntimeProperties properties = ServiceBusModelFactory.TopicRuntimeProperties(
                "topicName",
                3,
                1024,
                4,
                created,
                updated,
                accessed);

            Assert.AreEqual("topicName", properties.Name);
            Assert.AreEqual(3, properties.ScheduledMessageCount);
            Assert.AreEqual(1024, properties.SizeInBytes);
            Assert.AreEqual(4, properties.SubscriptionCount);
            Assert.AreEqual(created, properties.CreatedAt);
            Assert.AreEqual(updated, properties.UpdatedAt);
            Assert.AreEqual(accessed, properties.AccessedAt);
            Assert.AreEqual(0, properties.SqlFilterCount);
            Assert.AreEqual(0, properties.CorrelationFilterCount);
        }

        [Test]
        public void ParsesSqlAndCorrelationFilterCountsFromRuntimeXml()
        {
            XElement entry = BuildTopicEntry(
                "<SubscriptionCount>2</SubscriptionCount>" +
                "<SqlFilterCount>7</SqlFilterCount>" +
                "<CorrelationFilterCount>9</CorrelationFilterCount>");

            TopicRuntimeProperties properties =
                TopicRuntimePropertiesExtensions.ParseFromEntryElement(entry, new MockResponse(200));

            Assert.AreEqual("my-topic", properties.Name);
            Assert.AreEqual(2, properties.SubscriptionCount);
            Assert.AreEqual(7, properties.SqlFilterCount);
            Assert.AreEqual(9, properties.CorrelationFilterCount);
        }

        [Test]
        public void FilterCountsDefaultToZeroWhenElementsAbsent()
        {
            // A service region that has not yet deployed the topic filter-count feature
            // omits the elements entirely; the counts must gracefully default to zero.
            XElement entry = BuildTopicEntry("<SubscriptionCount>1</SubscriptionCount>");

            TopicRuntimeProperties properties =
                TopicRuntimePropertiesExtensions.ParseFromEntryElement(entry, new MockResponse(200));

            Assert.AreEqual(1, properties.SubscriptionCount);
            Assert.AreEqual(0, properties.SqlFilterCount);
            Assert.AreEqual(0, properties.CorrelationFilterCount);
        }
    }
}
