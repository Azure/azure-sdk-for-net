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

namespace Azure.ResourceManager.ServiceBus.Tests.Tests
{
    public class QueueTests : ServiceBusTestBase
    {
        private ResourceGroup _resourceGroup;
        private SBQueueContainer _queueContainer;
        public QueueTests(bool isAsync) : base(isAsync)
        {
        }
        [SetUp]
        public async Task CreateNamespaceAndGetQueueContainer()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            SBNamespaceContainer namespaceContainer = _resourceGroup.GetSBNamespaces();
            SBNamespaceData parameters = new SBNamespaceData(DefaultLocation)
            {
                Sku = new SBSku(SkuName.Premium)
                {
                    Tier = SkuTier.Premium
                }
            };
            SBNamespace sBNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, parameters)).Value;
            _queueContainer = sBNamespace.GetSBQueues();
        }
        [TearDown]
        public async Task ClearNamespaces()
        {
            //remove all namespaces under current resource group
            if (_resourceGroup != null)
            {
                SBNamespaceContainer namespaceContainer = _resourceGroup.GetSBNamespaces();
                List<SBNamespace> namespaceList = await namespaceContainer.GetAllAsync().ToEnumerableAsync();
                foreach (SBNamespace sBNamespace in namespaceList)
                {
                    await sBNamespace.DeleteAsync();
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
            SBQueue queue = (await _queueContainer.CreateOrUpdateAsync(queueName, new SBQueueData())).Value;
            Assert.NotNull(queue);
            Assert.AreEqual(queue.Id.Name, queueName);

            //validate if created successfully
            queue = await _queueContainer.GetIfExistsAsync(queueName);
            Assert.NotNull(queue);
            Assert.IsTrue(await _queueContainer.CheckIfExistsAsync(queueName));

            //delete queue
            await queue.DeleteAsync();

            //validate
            queue = await _queueContainer.GetIfExistsAsync(queueName);
            Assert.Null(queue);
            Assert.IsFalse(await _queueContainer.CheckIfExistsAsync(queueName));
        }

        [Test]
        [RecordedTest]
        public async Task GetAllqueues()
        {
            //create two queues
            string queueName1 = Recording.GenerateAssetName("queue1");
            string queueName2 = Recording.GenerateAssetName("queue2");
            _ = (await _queueContainer.CreateOrUpdateAsync(queueName1, new SBQueueData())).Value;
            _ = (await _queueContainer.CreateOrUpdateAsync(queueName2, new SBQueueData())).Value;

            //validate
            int count = 0;
            SBQueue queue1 = null;
            SBQueue queue2 = null;
            await foreach (SBQueue queue in _queueContainer.GetAllAsync())
            {
                count++;
                if (queue.Id.Name == queueName1)
                    queue1 = queue;
                if (queue.Id.Name == queueName2)
                    queue2 = queue;
            }
            Assert.AreEqual(count, 2);
            Assert.NotNull(queue1);
            Assert.NotNull(queue2);
        }

        [Test]
        [RecordedTest]
        public async Task Updatequeue()
        {
            //create queue
            string queueName = Recording.GenerateAssetName("queue");
            SBQueue queue = (await _queueContainer.CreateOrUpdateAsync(queueName, new SBQueueData())).Value;
            Assert.NotNull(queue);
            Assert.AreEqual(queue.Id.Name, queueName);

            //update queue
            SBQueueData parameters = new SBQueueData()
            {
                MaxSizeInMegabytes = 1024
            };
            queue = (await _queueContainer.CreateOrUpdateAsync(queueName, parameters)).Value;
            Assert.AreEqual(queue.Data.MaxMessageSizeInKilobytes, 1024);
        }

        [Test]
        [RecordedTest]
        public async Task QueueCreateGetUpdateDeleteAuthorizationRule()
        {
            //create queue
            string queueName = Recording.GenerateAssetName("queue");
            SBQueue queue = (await _queueContainer.CreateOrUpdateAsync(queueName, new SBQueueData())).Value;

            //create an authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            SBAuthorizationRuleQueueContainer ruleContainer = queue.GetSBAuthorizationRuleQueues();
            SBAuthorizationRuleData parameter = new SBAuthorizationRuleData()
            {
                Rights = { AccessRights.Listen, AccessRights.Send }
            };
            SBAuthorizationRuleQueue authorizationRule = (await ruleContainer.CreateOrUpdateAsync(ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get authorization rule
            authorizationRule = await ruleContainer.GetAsync(ruleName);
            Assert.AreEqual(authorizationRule.Id.Name, ruleName);
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get all authorization rules
            List<SBAuthorizationRuleQueue> rules = await ruleContainer.GetAllAsync().ToEnumerableAsync();

            //validate
            Assert.True(rules.Count == 1);
            bool isContainAuthorizationRuleName = false;
            foreach (SBAuthorizationRuleQueue rule in rules)
            {
                if (rule.Id.Name == ruleName)
                {
                    isContainAuthorizationRuleName = true;
                }
            }
            Assert.True(isContainAuthorizationRuleName);

            //update authorization rule
            parameter.Rights.Add(AccessRights.Manage);
            authorizationRule = (await ruleContainer.CreateOrUpdateAsync(ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //delete authorization rule
            await authorizationRule.DeleteAsync();

            //validate if deleted
            Assert.IsFalse(await ruleContainer.CheckIfExistsAsync(ruleName));
            rules = await ruleContainer.GetAllAsync().ToEnumerableAsync();
            Assert.True(rules.Count == 0);
        }

        [Test]
        [RecordedTest]
        public async Task QueueAuthorizationRuleRegenerateKey()
        {
            //create queue
            string queueName = Recording.GenerateAssetName("queue");
            SBQueue queue = (await _queueContainer.CreateOrUpdateAsync(queueName, new SBQueueData())).Value;
            SBAuthorizationRuleQueueContainer ruleContainer = queue.GetSBAuthorizationRuleQueues();

            //create authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            SBAuthorizationRuleData parameter = new SBAuthorizationRuleData()
            {
                Rights = { AccessRights.Listen, AccessRights.Send }
            };
            SBAuthorizationRuleQueue authorizationRule = (await ruleContainer.CreateOrUpdateAsync(ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            AccessKeys keys1 = await authorizationRule.GetKeysAsync();
            Assert.NotNull(keys1);
            Assert.NotNull(keys1.PrimaryConnectionString);
            Assert.NotNull(keys1.SecondaryConnectionString);

            AccessKeys keys2 = await authorizationRule.RegenerateKeysAsync(new RegenerateAccessKeyParameters(KeyType.PrimaryKey));

            //the recordings are sanitized therefore cannot be compared
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreNotEqual(keys1.PrimaryKey, keys2.PrimaryKey);
                Assert.AreEqual(keys1.SecondaryKey, keys2.SecondaryKey);
            }

            AccessKeys keys3 = await authorizationRule.RegenerateKeysAsync(new RegenerateAccessKeyParameters(KeyType.SecondaryKey));
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreEqual(keys2.PrimaryKey, keys3.PrimaryKey);
                Assert.AreNotEqual(keys2.SecondaryKey, keys3.SecondaryKey);
            }
        }
    }
}
