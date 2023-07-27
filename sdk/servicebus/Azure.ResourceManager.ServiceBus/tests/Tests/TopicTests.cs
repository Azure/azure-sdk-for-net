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
            Assert.NotNull(topic);
            Assert.AreEqual(topic.Id.Name, topicName);

            //validate if created successfully
            Assert.IsTrue(await _topicCollection.ExistsAsync(topicName));
            topic = await _topicCollection.GetAsync(topicName);

            //delete topic
            await topic.DeleteAsync(WaitUntil.Completed);

            //validate
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _topicCollection.GetAsync(topicName); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsFalse(await _topicCollection.ExistsAsync(topicName));
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
            Assert.AreEqual(10, list.Count);
            list = await _topicCollection.GetAllAsync(5, 5).ToEnumerableAsync();
            Assert.AreEqual(5, list.Count);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateTopic()
        {
            IgnoreTestInLiveMode();
            //create topic
            string topicName = Recording.GenerateAssetName("topic");
            ServiceBusTopicResource topic = (await _topicCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicName, new ServiceBusTopicData())).Value;
            Assert.NotNull(topic);
            Assert.AreEqual(topic.Id.Name, topicName);

            //update topic
            topic.Data.MaxMessageSizeInKilobytes = 13312;
            topic = (await _topicCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicName, topic.Data)).Value;
            Assert.AreEqual(topic.Data.MaxMessageSizeInKilobytes, 13312);
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
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get authorization rule
            authorizationRule = await ruleCollection.GetAsync(ruleName);
            Assert.AreEqual(authorizationRule.Id.Name, ruleName);
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get all authorization rules
            List<ServiceBusTopicAuthorizationRuleResource> rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();

            //validate
            Assert.True(rules.Count == 1);
            bool isContainAuthorizationRuleName = false;
            foreach (ServiceBusTopicAuthorizationRuleResource rule in rules)
            {
                if (rule.Id.Name == ruleName)
                {
                    isContainAuthorizationRuleName = true;
                }
            }
            Assert.True(isContainAuthorizationRuleName);

            //update authorization rule
            parameter.Rights.Add(ServiceBusAccessRight.Manage);
            authorizationRule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //delete authorization rule
            await authorizationRule.DeleteAsync(WaitUntil.Completed);

            //validate if deleted
            Assert.IsFalse(await ruleCollection.ExistsAsync(ruleName));
            rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();
            Assert.True(rules.Count == 0);
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
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            ServiceBusAccessKeys keys1 = await authorizationRule.GetKeysAsync();
            Assert.NotNull(keys1);
            Assert.NotNull(keys1.PrimaryConnectionString);
            Assert.NotNull(keys1.SecondaryConnectionString);

            ServiceBusAccessKeys keys2 = await authorizationRule.RegenerateKeysAsync(new ServiceBusRegenerateAccessKeyContent(ServiceBusAccessKeyType.PrimaryKey));

            //the recordings are sanitized therefore cannot be compared
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreNotEqual(keys1.PrimaryKey, keys2.PrimaryKey);
                Assert.AreEqual(keys1.SecondaryKey, keys2.SecondaryKey);
            }

            ServiceBusAccessKeys keys3 = await authorizationRule.RegenerateKeysAsync(new ServiceBusRegenerateAccessKeyContent(ServiceBusAccessKeyType.SecondaryKey));
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreEqual(keys2.PrimaryKey, keys3.PrimaryKey);
                Assert.AreNotEqual(keys2.SecondaryKey, keys3.SecondaryKey);
            }

            var updatePrimaryKey = GenerateRandomKey();
            ServiceBusAccessKeys currentKeys = keys3;

            ServiceBusAccessKeys keys4 = await authorizationRule.RegenerateKeysAsync(new ServiceBusRegenerateAccessKeyContent(ServiceBusAccessKeyType.PrimaryKey)
            {
                Key = updatePrimaryKey
            });
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreEqual(updatePrimaryKey, keys4.PrimaryKey);
                Assert.AreEqual(currentKeys.SecondaryKey, keys4.SecondaryKey);
            }

            currentKeys = keys4;
            var updateSecondaryKey = GenerateRandomKey();
            ServiceBusAccessKeys keys5 = await authorizationRule.RegenerateKeysAsync(new ServiceBusRegenerateAccessKeyContent(ServiceBusAccessKeyType.SecondaryKey)
            {
                Key = updateSecondaryKey
            });
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreEqual(updateSecondaryKey, keys5.SecondaryKey);
                Assert.AreEqual(currentKeys.PrimaryKey, keys5.PrimaryKey);
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
            Assert.AreEqual(new TimeSpan(1, 0, 3, 4), secondTopic.Data.DuplicateDetectionHistoryTimeWindow);
            Assert.AreEqual(new TimeSpan(365, 0, 0, 0), secondTopic.Data.DefaultMessageTimeToLive);
            Assert.True(secondTopic.Data.RequiresDuplicateDetection);
            Assert.True(secondTopic.Data.SupportOrdering);
            Assert.True(secondTopic.Data.EnableBatchedOperations);
            Assert.AreEqual(ServiceBusMessagingEntityStatus.Active, secondTopic.Data.Status);
            Assert.AreEqual(102400, secondTopic.Data.MaxMessageSizeInKilobytes);

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
            Assert.AreEqual(3072, topicData.MaxSizeInMegabytes);
        }

        public void AssertTopicPropertiesOnUpdates(ServiceBusTopicData actualTopic, ServiceBusTopicData expectedTopic)
        {
            Assert.AreEqual(expectedTopic.Location, actualTopic.Location);
            Assert.AreEqual(expectedTopic.DefaultMessageTimeToLive, actualTopic.DefaultMessageTimeToLive);
            Assert.AreEqual(expectedTopic.DuplicateDetectionHistoryTimeWindow, actualTopic.DuplicateDetectionHistoryTimeWindow);
            Assert.AreEqual(expectedTopic.RequiresDuplicateDetection, actualTopic.RequiresDuplicateDetection);
            Assert.AreEqual(expectedTopic.EnableBatchedOperations, actualTopic.EnableBatchedOperations);
            Assert.AreEqual(expectedTopic.MaxMessageSizeInKilobytes, actualTopic.MaxMessageSizeInKilobytes);
            Assert.AreEqual(expectedTopic.MaxSizeInMegabytes, actualTopic.MaxSizeInMegabytes);
            Assert.AreEqual(expectedTopic.Status, actualTopic.Status);
            Assert.AreEqual(expectedTopic.AutoDeleteOnIdle, actualTopic.AutoDeleteOnIdle);
            Assert.AreEqual(expectedTopic.EnableExpress, actualTopic.EnableExpress);
            Assert.AreEqual(expectedTopic.EnablePartitioning, actualTopic.EnablePartitioning);
        }
    }
}
