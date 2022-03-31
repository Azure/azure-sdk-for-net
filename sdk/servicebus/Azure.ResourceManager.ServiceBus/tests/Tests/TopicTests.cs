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
using Azure.ResourceManager.ServiceBus.Tests.Helpers;

namespace Azure.ResourceManager.ServiceBus.Tests
{
    public class TopicTests : ServiceBusTestBase
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
            NamespaceTopicAuthorizationRuleCollection ruleCollection = topic.GetNamespaceTopicAuthorizationRules();
            ServiceBusAuthorizationRuleData parameter = new ServiceBusAuthorizationRuleData()
            {
                Rights = { AccessRights.Listen, AccessRights.Send }
            };
            NamespaceTopicAuthorizationRuleResource authorizationRule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get authorization rule
            authorizationRule = await ruleCollection.GetAsync(ruleName);
            Assert.AreEqual(authorizationRule.Id.Name, ruleName);
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get all authorization rules
            List<NamespaceTopicAuthorizationRuleResource> rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();

            //validate
            Assert.True(rules.Count == 1);
            bool isContainAuthorizationRuleName = false;
            foreach (NamespaceTopicAuthorizationRuleResource rule in rules)
            {
                if (rule.Id.Name == ruleName)
                {
                    isContainAuthorizationRuleName = true;
                }
            }
            Assert.True(isContainAuthorizationRuleName);

            //update authorization rule
            parameter.Rights.Add(AccessRights.Manage);
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
            NamespaceTopicAuthorizationRuleCollection ruleCollection = topic.GetNamespaceTopicAuthorizationRules();

            //create authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            ServiceBusAuthorizationRuleData parameter = new ServiceBusAuthorizationRuleData()
            {
                Rights = { AccessRights.Listen, AccessRights.Send }
            };
            NamespaceTopicAuthorizationRuleResource authorizationRule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            AccessKeys keys1 = await authorizationRule.GetKeysAsync();
            Assert.NotNull(keys1);
            Assert.NotNull(keys1.PrimaryConnectionString);
            Assert.NotNull(keys1.SecondaryConnectionString);

            AccessKeys keys2 = await authorizationRule.RegenerateKeysAsync(new RegenerateAccessKeyOptions(KeyType.PrimaryKey));

            //the recordings are sanitized therefore cannot be compared
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreNotEqual(keys1.PrimaryKey, keys2.PrimaryKey);
                Assert.AreEqual(keys1.SecondaryKey, keys2.SecondaryKey);
            }

            AccessKeys keys3 = await authorizationRule.RegenerateKeysAsync(new RegenerateAccessKeyOptions(KeyType.SecondaryKey));
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreEqual(keys2.PrimaryKey, keys3.PrimaryKey);
                Assert.AreNotEqual(keys2.SecondaryKey, keys3.SecondaryKey);
            }
        }
    }
}
