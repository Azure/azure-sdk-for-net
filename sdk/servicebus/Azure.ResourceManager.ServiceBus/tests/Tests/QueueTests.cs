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
        private ResourceGroup _resourceGroup;
        private ServiceBusQueueCollection _queueCollection;
        public QueueTests(bool isAsync) : base(isAsync)
        {
        }
        [SetUp]
        public async Task CreateNamespaceAndGetQueueCollection()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            ServiceBusNamespaceCollection namespaceCollection = _resourceGroup.GetServiceBusNamespaces();
            ServiceBusNamespaceData parameters = new ServiceBusNamespaceData(DefaultLocation)
            {
                Sku = new ServiceBusSku(SkuName.Premium)
                {
                    Tier = SkuTier.Premium
                }
            };
            ServiceBusNamespace serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(namespaceName, parameters)).Value;
            _queueCollection = serviceBusNamespace.GetServiceBusQueues();
        }
        [TearDown]
        public async Task ClearNamespaces()
        {
            //remove all namespaces under current resource group
            if (_resourceGroup != null)
            {
                ServiceBusNamespaceCollection namespaceCollection = _resourceGroup.GetServiceBusNamespaces();
                List<ServiceBusNamespace> namespaceList = await namespaceCollection.GetAllAsync().ToEnumerableAsync();
                foreach (ServiceBusNamespace serviceBusNamespace in namespaceList)
                {
                    await serviceBusNamespace.DeleteAsync();
                }
                _resourceGroup = null;
            }
        }
        [Test]
        [RecordedTest]
        public async Task CreateDeleteQueue()
        {
            //create queue
            string queueName = Recording.GenerateAssetName("queue");
            ServiceBusQueue queue = (await _queueCollection.CreateOrUpdateAsync(queueName, new ServiceBusQueueData())).Value;
            Assert.NotNull(queue);
            Assert.AreEqual(queue.Id.Name, queueName);

            //validate if created successfully
            queue = await _queueCollection.GetIfExistsAsync(queueName);
            Assert.NotNull(queue);
            Assert.IsTrue(await _queueCollection.CheckIfExistsAsync(queueName));

            //delete queue
            await queue.DeleteAsync();

            //validate
            queue = await _queueCollection.GetIfExistsAsync(queueName);
            Assert.Null(queue);
            Assert.IsFalse(await _queueCollection.CheckIfExistsAsync(queueName));
        }

        [Test]
        [RecordedTest]
        public async Task GetAllQueues()
        {
            //create ten queues
            for (int i = 0; i < 10; i++)
            {
                string queueName = Recording.GenerateAssetName("queue" + i.ToString());
                _ = await _queueCollection.CreateOrUpdateAsync(queueName, new ServiceBusQueueData());
            }

            //validate
            List<ServiceBusQueue> list = await _queueCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(10, list.Count);
            list = await _queueCollection.GetAllAsync(5, 5).ToEnumerableAsync();
            Assert.AreEqual(5, list.Count);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateQueue()
        {
            //create queue
            string queueName = Recording.GenerateAssetName("queue");
            ServiceBusQueue queue = (await _queueCollection.CreateOrUpdateAsync(queueName, new ServiceBusQueueData())).Value;
            Assert.NotNull(queue);
            Assert.AreEqual(queue.Id.Name, queueName);

            //update queue
            ServiceBusQueueData parameters = new ServiceBusQueueData()
            {
                MaxSizeInMegabytes = 1024
            };
            queue = (await _queueCollection.CreateOrUpdateAsync(queueName, parameters)).Value;
            Assert.AreEqual(queue.Data.MaxMessageSizeInKilobytes, 1024);
        }

        [Test]
        [RecordedTest]
        public async Task QueueCreateGetUpdateDeleteAuthorizationRule()
        {
            //create queue
            string queueName = Recording.GenerateAssetName("queue");
            ServiceBusQueue queue = (await _queueCollection.CreateOrUpdateAsync(queueName, new ServiceBusQueueData())).Value;

            //create an authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            NamespaceQueueAuthorizationRuleCollection ruleCollection = queue.GetNamespaceQueueAuthorizationRules();
            ServiceBusAuthorizationRuleData parameter = new ServiceBusAuthorizationRuleData()
            {
                Rights = { AccessRights.Listen, AccessRights.Send }
            };
            NamespaceQueueAuthorizationRule authorizationRule = (await ruleCollection.CreateOrUpdateAsync(ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get authorization rule
            authorizationRule = await ruleCollection.GetAsync(ruleName);
            Assert.AreEqual(authorizationRule.Id.Name, ruleName);
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get all authorization rules
            List<NamespaceQueueAuthorizationRule> rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();

            //validate
            Assert.True(rules.Count == 1);
            bool isContainAuthorizationRuleName = false;
            foreach (NamespaceQueueAuthorizationRule rule in rules)
            {
                if (rule.Id.Name == ruleName)
                {
                    isContainAuthorizationRuleName = true;
                }
            }
            Assert.True(isContainAuthorizationRuleName);

            //update authorization rule
            parameter.Rights.Add(AccessRights.Manage);
            authorizationRule = (await ruleCollection.CreateOrUpdateAsync(ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //delete authorization rule
            await authorizationRule.DeleteAsync();

            //validate if deleted
            Assert.IsFalse(await ruleCollection.CheckIfExistsAsync(ruleName));
            rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();
            Assert.True(rules.Count == 0);
        }

        [Test]
        [RecordedTest]
        public async Task QueueAuthorizationRuleRegenerateKey()
        {
            //create queue
            string queueName = Recording.GenerateAssetName("queue");
            ServiceBusQueue queue = (await _queueCollection.CreateOrUpdateAsync(queueName, new ServiceBusQueueData())).Value;
            NamespaceQueueAuthorizationRuleCollection ruleCollection = queue.GetNamespaceQueueAuthorizationRules();

            //create authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            ServiceBusAuthorizationRuleData parameter = new ServiceBusAuthorizationRuleData()
            {
                Rights = { AccessRights.Listen, AccessRights.Send }
            };
            NamespaceQueueAuthorizationRule authorizationRule = (await ruleCollection.CreateOrUpdateAsync(ruleName, parameter)).Value;
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
