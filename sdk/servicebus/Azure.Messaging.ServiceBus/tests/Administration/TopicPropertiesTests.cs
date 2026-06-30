// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
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

        [Test]
        public async Task ParsesTopicWithMaskedAuthorizationRuleKeys()
        {
            // The service masks SAS key values (returning empty strings) when the caller
            // lacks the listkeys/action permission. Parsing such a response must not throw.
            // See https://github.com/Azure/azure-sdk-for-net/issues/60469.
            string topicDescriptionXml = $@"<entry xmlns=""{AdministrationClientConstants.AtomNamespace}"">" +
                $@"<title xmlns=""{AdministrationClientConstants.AtomNamespace}"">maskedtopic</title>" +
                $@"<content xmlns=""{AdministrationClientConstants.AtomNamespace}"">" +
                $@"<TopicDescription xmlns=""{AdministrationClientConstants.ServiceBusNamespace}"" xmlns:i=""{AdministrationClientConstants.XmlSchemaInstanceNamespace}"">" +
                $"<MaxSizeInMegabytes>1024</MaxSizeInMegabytes>" +
                $"<AuthorizationRules>" +
                $@"<AuthorizationRule i:type=""SharedAccessAuthorizationRule"">" +
                $"<ClaimType>SharedAccessKey</ClaimType>" +
                $"<ClaimValue>None</ClaimValue>" +
                $"<Rights><AccessRights>Listen</AccessRights></Rights>" +
                $"<KeyName>Decisions</KeyName>" +
                $"<PrimaryKey></PrimaryKey>" +
                $"<SecondaryKey></SecondaryKey>" +
                $"</AuthorizationRule>" +
                $"</AuthorizationRules>" +
                $"<Status>Active</Status>" +
                $"</TopicDescription>" +
                $"</content>" +
                $"</entry>";
            MockResponse response = new MockResponse(200);
            response.SetContent(topicDescriptionXml);

            TopicProperties topicDesc = await TopicPropertiesExtensions.ParseResponseAsync(response);

            Assert.AreEqual("maskedtopic", topicDesc.Name);
            Assert.AreEqual(1, topicDesc.AuthorizationRules.Count);
            var rule = (SharedAccessAuthorizationRule)topicDesc.AuthorizationRules[0];
            Assert.AreEqual("Decisions", rule.KeyName);
            Assert.AreEqual(string.Empty, rule.PrimaryKey);
            Assert.AreEqual(string.Empty, rule.SecondaryKey);
            CollectionAssert.AreEqual(new[] { AccessRights.Listen }, rule.Rights);
        }

        [Test]
        public async Task ParsesTopicWithNoAuthorizationRulesSection()
        {
            // When the caller lacks listkeys/action, the service redaction removes the
            // entire AuthorizationRules section (the intended contract). Parsing a response
            // with no section must succeed and yield an empty rule collection.
            // See https://github.com/Azure/azure-sdk-for-net/issues/60469.
            string topicDescriptionXml = $@"<entry xmlns=""{AdministrationClientConstants.AtomNamespace}"">" +
                $@"<title xmlns=""{AdministrationClientConstants.AtomNamespace}"">noauthrules</title>" +
                $@"<content xmlns=""{AdministrationClientConstants.AtomNamespace}"">" +
                $@"<TopicDescription xmlns=""{AdministrationClientConstants.ServiceBusNamespace}"">" +
                $"<MaxSizeInMegabytes>1024</MaxSizeInMegabytes>" +
                $"<Status>Active</Status>" +
                $"</TopicDescription>" +
                $"</content>" +
                $"</entry>";
            MockResponse response = new MockResponse(200);
            response.SetContent(topicDescriptionXml);

            TopicProperties topicDesc = await TopicPropertiesExtensions.ParseResponseAsync(response);

            Assert.AreEqual("noauthrules", topicDesc.Name);
            Assert.IsNotNull(topicDesc.AuthorizationRules);
            Assert.AreEqual(0, topicDesc.AuthorizationRules.Count);
        }
    }
}
