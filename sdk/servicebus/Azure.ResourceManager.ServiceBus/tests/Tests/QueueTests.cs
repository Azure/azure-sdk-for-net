// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ServiceBus.Models;
using Azure.ResourceManager.ServiceBus.Tests.Helpers;

namespace Azure.ResourceManager.ServiceBus.Tests
{
    public class QueueTests : ServiceBusTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ServiceBusQueueCollection _queueCollection;
        public QueueTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateNamespaceAndGetQueueCollection()
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
            _queueCollection = serviceBusNamespace.GetServiceBusQueues();
        }

        [Test]
        [RecordedTest]
        public async Task CreateDeleteQueue()
        {
            IgnoreTestInLiveMode();
            //create queue
            string queueName = Recording.GenerateAssetName("queue");
            ServiceBusQueueResource queue = (await _queueCollection.CreateOrUpdateAsync(WaitUntil.Completed, queueName, new ServiceBusQueueData())).Value;
            Assert.NotNull(queue);
            Assert.AreEqual(queue.Id.Name, queueName);

            //validate if created successfully
            Assert.IsTrue(await _queueCollection.ExistsAsync(queueName));
            queue = await _queueCollection.GetAsync(queueName);

            //delete queue
            await queue.DeleteAsync(WaitUntil.Completed);

            //validate
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _queueCollection.GetAsync(queueName); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsFalse(await _queueCollection.ExistsAsync(queueName));
        }

        [Test]
        [RecordedTest]
        public async Task GetAllQueues()
        {
            IgnoreTestInLiveMode();
            //create ten queues
            for (int i = 0; i < 10; i++)
            {
                string queueName = Recording.GenerateAssetName("queue" + i.ToString());
                _ = await _queueCollection.CreateOrUpdateAsync(WaitUntil.Completed, queueName, new ServiceBusQueueData());
            }

            //validate
            List<ServiceBusQueueResource> list = await _queueCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(10, list.Count);
            list = await _queueCollection.GetAllAsync(5, 5).ToEnumerableAsync();
            Assert.AreEqual(5, list.Count);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateQueue()
        {
            IgnoreTestInLiveMode();
            //create queue
            string queueName = Recording.GenerateAssetName("queue");
            ServiceBusQueueResource queue = (await _queueCollection.CreateOrUpdateAsync(WaitUntil.Completed, queueName, new ServiceBusQueueData())).Value;
            Assert.NotNull(queue);
            Assert.AreEqual(queue.Id.Name, queueName);

            //update queue
            ServiceBusQueueData parameters = new ServiceBusQueueData()
            {
                MaxSizeInMegabytes = 1024
            };
            queue = (await _queueCollection.CreateOrUpdateAsync(WaitUntil.Completed, queueName, parameters)).Value;
            Assert.AreEqual(queue.Data.MaxMessageSizeInKilobytes, 1024);
        }

        [Test]
        [RecordedTest]
        public async Task QueueCreateGetUpdateDeleteAuthorizationRule()
        {
            IgnoreTestInLiveMode();
            //create queue
            string queueName = Recording.GenerateAssetName("queue");
            ServiceBusQueueResource queue = (await _queueCollection.CreateOrUpdateAsync(WaitUntil.Completed, queueName, new ServiceBusQueueData())).Value;

            //create an authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            NamespaceQueueAuthorizationRuleCollection ruleCollection = queue.GetNamespaceQueueAuthorizationRules();
            ServiceBusAuthorizationRuleData parameter = new ServiceBusAuthorizationRuleData()
            {
                Rights = { AccessRights.Listen, AccessRights.Send }
            };
            NamespaceQueueAuthorizationRuleResource authorizationRule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get authorization rule
            authorizationRule = await ruleCollection.GetAsync(ruleName);
            Assert.AreEqual(authorizationRule.Id.Name, ruleName);
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get all authorization rules
            List<NamespaceQueueAuthorizationRuleResource> rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();

            //validate
            Assert.True(rules.Count == 1);
            bool isContainAuthorizationRuleName = false;
            foreach (NamespaceQueueAuthorizationRuleResource rule in rules)
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
        public async Task QueueAuthorizationRuleRegenerateKey()
        {
            IgnoreTestInLiveMode();
            //create queue
            string queueName = Recording.GenerateAssetName("queue");
            ServiceBusQueueResource queue = (await _queueCollection.CreateOrUpdateAsync(WaitUntil.Completed, queueName, new ServiceBusQueueData())).Value;
            NamespaceQueueAuthorizationRuleCollection ruleCollection = queue.GetNamespaceQueueAuthorizationRules();

            //create authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            ServiceBusAuthorizationRuleData parameter = new ServiceBusAuthorizationRuleData()
            {
                Rights = { AccessRights.Listen, AccessRights.Send }
            };
            NamespaceQueueAuthorizationRuleResource authorizationRule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            AccessKeys keys1 = await authorizationRule.GetKeysAsync();
            Assert.NotNull(keys1);
            Assert.NotNull(keys1.PrimaryConnectionString);
            Assert.NotNull(keys1.SecondaryConnectionString);

            AccessKeys keys2 = await authorizationRule.RegenerateKeysAsync(new RegenerateAccessKeyContent(KeyType.PrimaryKey));

            //the recordings are sanitized therefore cannot be compared
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreNotEqual(keys1.PrimaryKey, keys2.PrimaryKey);
                Assert.AreEqual(keys1.SecondaryKey, keys2.SecondaryKey);
            }

            AccessKeys keys3 = await authorizationRule.RegenerateKeysAsync(new RegenerateAccessKeyContent(KeyType.SecondaryKey));
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreEqual(keys2.PrimaryKey, keys3.PrimaryKey);
                Assert.AreNotEqual(keys2.SecondaryKey, keys3.SecondaryKey);
            }
        }
    }
}
