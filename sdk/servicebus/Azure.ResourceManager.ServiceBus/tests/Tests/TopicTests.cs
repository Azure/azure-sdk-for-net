// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ServiceBus.Models;

namespace Azure.ResourceManager.ServiceBus.Tests
{
    public class TopicTests : ServiceBusManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ServiceBusTopicCollection _topicCollection;
        public TopicTests(bool isAsync): base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateNamespaceAndGetTopicCollection()
        {
            IgnoreTestInLiveMode();
            _resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            ServiceBusNamespaceCollection namespaceCollection = _resourceGroup.GetServiceBusNamespaces();
            ServiceBusNamespaceData parameters = new ServiceBusNamespaceData(DefaultLocation)
            {
                Sku = new ServiceBusSku(ServiceBusSkuName.Premium)
                {
                    Tier = ServiceBusSkuTier.Premium
                }
            };
            ServiceBusNamespaceResource serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, parameters)).Value;
            _topicCollection = serviceBusNamespace.GetServiceBusTopics();
        }

        [Test]
        [RecordedTest]
        public async Task CreateDeleteTopic()
        {
            IgnoreTestInLiveMode();
            //create topic
            string topicName = Recording.GenerateAssetName("topic");
            ServiceBusTopicResource topic = (await _topicCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicName, new ServiceBusTopicData())).Value;
            Assert.That(topic, Is.Not.Null);
            Assert.That(topicName, Is.EqualTo(topic.Id.Name));

            //validate if created successfully
            Assert.That((bool)await _topicCollection.ExistsAsync(topicName), Is.True);
            topic = await _topicCollection.GetAsync(topicName);

            //delete topic
            await topic.DeleteAsync(WaitUntil.Completed);

            //validate
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _topicCollection.GetAsync(topicName); });
            Assert.That(exception.Status, Is.EqualTo(404));
            Assert.That((bool)await _topicCollection.ExistsAsync(topicName), Is.False);
        }

        [Test]
        [RecordedTest]
        public async Task GetAllTopics()
        {
            IgnoreTestInLiveMode();
            //create ten queues
            for (int i = 0; i < 10; i++)
            {
                string topicName = Recording.GenerateAssetName("topic" + i.ToString());
                _ = await _topicCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicName, new ServiceBusTopicData());
            }

            //validate
            List<ServiceBusTopicResource> list = await _topicCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list.Count, Is.EqualTo(10));
            list = await _topicCollection.GetAllAsync(5, 5).ToEnumerableAsync();
            Assert.That(list.Count, Is.EqualTo(5));
        }

        [Test]
        [RecordedTest]
        public async Task UpdateTopic()
        {
            IgnoreTestInLiveMode();
            //create topic
            string topicName = Recording.GenerateAssetName("topic");
            ServiceBusTopicResource topic = (await _topicCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicName, new ServiceBusTopicData())).Value;
            Assert.That(topic, Is.Not.Null);
            Assert.That(topicName, Is.EqualTo(topic.Id.Name));

            //update topic
            topic.Data.MaxMessageSizeInKilobytes = 13312;
            topic = (await _topicCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicName, topic.Data)).Value;
            Assert.That(topic.Data.MaxMessageSizeInKilobytes, Is.EqualTo(13312));
        }

        [Test]
        [RecordedTest]
        public async Task TopicCreateGetUpdateDeleteAuthorizationRule()
        {
            IgnoreTestInLiveMode();
            //create topic
            string topicName = Recording.GenerateAssetName("topic");
            ServiceBusTopicResource topic = (await _topicCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicName, new ServiceBusTopicData())).Value;

            //create an authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            ServiceBusTopicAuthorizationRuleCollection ruleCollection = topic.GetServiceBusTopicAuthorizationRules();
            ServiceBusAuthorizationRuleData parameter = new ServiceBusAuthorizationRuleData()
            {
                Rights = { ServiceBusAccessRight.Listen, ServiceBusAccessRight.Send }
            };
            ServiceBusTopicAuthorizationRuleResource authorizationRule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName, parameter)).Value;
            Assert.That(authorizationRule, Is.Not.Null);
            Assert.That(parameter.Rights.Count, Is.EqualTo(authorizationRule.Data.Rights.Count));

            //get authorization rule
            authorizationRule = await ruleCollection.GetAsync(ruleName);
            Assert.That(ruleName, Is.EqualTo(authorizationRule.Id.Name));
            Assert.That(authorizationRule, Is.Not.Null);
            Assert.That(parameter.Rights.Count, Is.EqualTo(authorizationRule.Data.Rights.Count));

            //get all authorization rules
            List<ServiceBusTopicAuthorizationRuleResource> rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();

            //validate
            Assert.That(rules.Count == 1, Is.True);
            bool isContainAuthorizationRuleName = false;
            foreach (ServiceBusTopicAuthorizationRuleResource rule in rules)
            {
                if (rule.Id.Name == ruleName)
                {
                    isContainAuthorizationRuleName = true;
                }
            }
            Assert.That(isContainAuthorizationRuleName, Is.True);

            //update authorization rule
            parameter.Rights.Add(ServiceBusAccessRight.Manage);
            authorizationRule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName, parameter)).Value;
            Assert.That(authorizationRule, Is.Not.Null);
            Assert.That(parameter.Rights.Count, Is.EqualTo(authorizationRule.Data.Rights.Count));

            //delete authorization rule
            await authorizationRule.DeleteAsync(WaitUntil.Completed);

            //validate if deleted
            Assert.That((bool)await ruleCollection.ExistsAsync(ruleName), Is.False);
            rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(rules.Count == 0, Is.True);
        }

        [Test]
        [RecordedTest]
        public async Task TopicAuthorizationRuleRegenerateKey()
        {
            IgnoreTestInLiveMode();
            //create topic
            string topicName = Recording.GenerateAssetName("topic");
            ServiceBusTopicResource topic = (await _topicCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicName, new ServiceBusTopicData())).Value;
            ServiceBusTopicAuthorizationRuleCollection ruleCollection = topic.GetServiceBusTopicAuthorizationRules();

            //create authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            ServiceBusAuthorizationRuleData parameter = new ServiceBusAuthorizationRuleData()
            {
                Rights = { ServiceBusAccessRight.Listen, ServiceBusAccessRight.Send }
            };
            ServiceBusTopicAuthorizationRuleResource authorizationRule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName, parameter)).Value;
            Assert.That(authorizationRule, Is.Not.Null);
            Assert.That(parameter.Rights.Count, Is.EqualTo(authorizationRule.Data.Rights.Count));

            ServiceBusAccessKeys keys1 = await authorizationRule.GetKeysAsync();
            Assert.That(keys1, Is.Not.Null);
            Assert.That(keys1.PrimaryConnectionString, Is.Not.Null);
            Assert.That(keys1.SecondaryConnectionString, Is.Not.Null);

            ServiceBusAccessKeys keys2 = await authorizationRule.RegenerateKeysAsync(new ServiceBusRegenerateAccessKeyContent(ServiceBusAccessKeyType.PrimaryKey));

            //the recordings are sanitized therefore cannot be compared
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.That(keys2.PrimaryKey, Is.Not.EqualTo(keys1.PrimaryKey));
                Assert.That(keys2.SecondaryKey, Is.EqualTo(keys1.SecondaryKey));
            }

            ServiceBusAccessKeys keys3 = await authorizationRule.RegenerateKeysAsync(new ServiceBusRegenerateAccessKeyContent(ServiceBusAccessKeyType.SecondaryKey));
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.That(keys3.PrimaryKey, Is.EqualTo(keys2.PrimaryKey));
                Assert.That(keys3.SecondaryKey, Is.Not.EqualTo(keys2.SecondaryKey));
            }

            var updatePrimaryKey = GenerateRandomKey();
            ServiceBusAccessKeys currentKeys = keys3;

            ServiceBusAccessKeys keys4 = await authorizationRule.RegenerateKeysAsync(new ServiceBusRegenerateAccessKeyContent(ServiceBusAccessKeyType.PrimaryKey)
            {
                Key = updatePrimaryKey
            });
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.That(keys4.PrimaryKey, Is.EqualTo(updatePrimaryKey));
                Assert.That(keys4.SecondaryKey, Is.EqualTo(currentKeys.SecondaryKey));
            }

            currentKeys = keys4;
            var updateSecondaryKey = GenerateRandomKey();
            ServiceBusAccessKeys keys5 = await authorizationRule.RegenerateKeysAsync(new ServiceBusRegenerateAccessKeyContent(ServiceBusAccessKeyType.SecondaryKey)
            {
                Key = updateSecondaryKey
            });
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.That(keys5.SecondaryKey, Is.EqualTo(updateSecondaryKey));
                Assert.That(keys5.PrimaryKey, Is.EqualTo(currentKeys.PrimaryKey));
            }
        }

        [Test]
        [RecordedTest]
        public async Task TopicCreateOrUpdateParameters()
        {
            //This test is written with an intention of testing each and every parameter on the queue
            //create queue
            string firstTopicName = Recording.GenerateAssetName("topic");
            string secondTopicName = Recording.GenerateAssetName("topic");
            string thirdTopicName = Recording.GenerateAssetName("topic");
            ServiceBusTopicResource firstTopic = (await _topicCollection.CreateOrUpdateAsync(WaitUntil.Completed, firstTopicName, new ServiceBusTopicData())).Value;

            ServiceBusTopicData topicData = new ServiceBusTopicData()
            {
                DefaultMessageTimeToLive = new TimeSpan(365, 0, 0, 0),
                RequiresDuplicateDetection = true,
                DuplicateDetectionHistoryTimeWindow = new TimeSpan(1, 0, 3, 4),
                EnableBatchedOperations = true,
                Status = ServiceBusMessagingEntityStatus.Active,
                SupportOrdering = true,
                AutoDeleteOnIdle = new TimeSpan(428, 3, 11, 2),
                MaxMessageSizeInKilobytes = 102400
            };

            ServiceBusTopicResource secondTopic = (await _topicCollection.CreateOrUpdateAsync(WaitUntil.Completed, secondTopicName, topicData)).Value;
            Assert.That(secondTopic.Data.DuplicateDetectionHistoryTimeWindow, Is.EqualTo(new TimeSpan(1, 0, 3, 4)));
            Assert.That(secondTopic.Data.DefaultMessageTimeToLive, Is.EqualTo(new TimeSpan(365, 0, 0, 0)));
            Assert.That(secondTopic.Data.RequiresDuplicateDetection, Is.True);
            Assert.That(secondTopic.Data.SupportOrdering, Is.True);
            Assert.That(secondTopic.Data.EnableBatchedOperations, Is.True);
            Assert.That(secondTopic.Data.Status, Is.EqualTo(ServiceBusMessagingEntityStatus.Active));
            Assert.That(secondTopic.Data.MaxMessageSizeInKilobytes, Is.EqualTo(102400));

            secondTopic.Data.Status = ServiceBusMessagingEntityStatus.Disabled;
            topicData = secondTopic.Data;
            secondTopic = (await _topicCollection.CreateOrUpdateAsync(WaitUntil.Completed, secondTopicName, secondTopic.Data)).Value;
            AssertTopicPropertiesOnUpdates(topicData, secondTopic.Data);

            secondTopic.Data.Status = ServiceBusMessagingEntityStatus.SendDisabled;
            topicData = secondTopic.Data;
            secondTopic = (await _topicCollection.CreateOrUpdateAsync(WaitUntil.Completed, secondTopicName, secondTopic.Data)).Value;
            AssertTopicPropertiesOnUpdates(topicData, secondTopic.Data);

            topicData = new ServiceBusTopicData()
            {
                MaxSizeInMegabytes = 3072
            };

            ServiceBusTopicResource thirdTopic = (await _topicCollection.CreateOrUpdateAsync(WaitUntil.Completed, thirdTopicName, topicData)).Value;
            Assert.That(topicData.MaxSizeInMegabytes, Is.EqualTo(3072));
        }

        public void AssertTopicPropertiesOnUpdates(ServiceBusTopicData actualTopic, ServiceBusTopicData expectedTopic)
        {
            Assert.That(actualTopic.Location, Is.EqualTo(expectedTopic.Location));
            Assert.That(actualTopic.DefaultMessageTimeToLive, Is.EqualTo(expectedTopic.DefaultMessageTimeToLive));
            Assert.That(actualTopic.DuplicateDetectionHistoryTimeWindow, Is.EqualTo(expectedTopic.DuplicateDetectionHistoryTimeWindow));
            Assert.That(actualTopic.RequiresDuplicateDetection, Is.EqualTo(expectedTopic.RequiresDuplicateDetection));
            Assert.That(actualTopic.EnableBatchedOperations, Is.EqualTo(expectedTopic.EnableBatchedOperations));
            Assert.That(actualTopic.MaxMessageSizeInKilobytes, Is.EqualTo(expectedTopic.MaxMessageSizeInKilobytes));
            Assert.That(actualTopic.MaxSizeInMegabytes, Is.EqualTo(expectedTopic.MaxSizeInMegabytes));
            Assert.That(actualTopic.Status, Is.EqualTo(expectedTopic.Status));
            Assert.That(actualTopic.AutoDeleteOnIdle, Is.EqualTo(expectedTopic.AutoDeleteOnIdle));
            Assert.That(actualTopic.EnableExpress, Is.EqualTo(expectedTopic.EnableExpress));
            Assert.That(actualTopic.EnablePartitioning, Is.EqualTo(expectedTopic.EnablePartitioning));
        }
    }
}
