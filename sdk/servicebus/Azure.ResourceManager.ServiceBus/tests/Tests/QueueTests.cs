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
            ServiceBusQueueAuthorizationRuleCollection ruleCollection = queue.GetServiceBusQueueAuthorizationRules();
            ServiceBusAuthorizationRuleData parameter = new ServiceBusAuthorizationRuleData()
            {
                Rights = { ServiceBusAccessRight.Listen, ServiceBusAccessRight.Send }
            };
            ServiceBusQueueAuthorizationRuleResource authorizationRule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get authorization rule
            authorizationRule = await ruleCollection.GetAsync(ruleName);
            Assert.AreEqual(authorizationRule.Id.Name, ruleName);
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get all authorization rules
            List<ServiceBusQueueAuthorizationRuleResource> rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();

            //validate
            Assert.True(rules.Count == 1);
            bool isContainAuthorizationRuleName = false;
            foreach (ServiceBusQueueAuthorizationRuleResource rule in rules)
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
        public async Task QueueAuthorizationRuleRegenerateKey()
        {
            IgnoreTestInLiveMode();
            //create queue
            string queueName = Recording.GenerateAssetName("queue");
            ServiceBusQueueResource queue = (await _queueCollection.CreateOrUpdateAsync(WaitUntil.Completed, queueName, new ServiceBusQueueData())).Value;
            ServiceBusQueueAuthorizationRuleCollection ruleCollection = queue.GetServiceBusQueueAuthorizationRules();

            //create authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            ServiceBusAuthorizationRuleData parameter = new ServiceBusAuthorizationRuleData()
            {
                Rights = { ServiceBusAccessRight.Listen, ServiceBusAccessRight.Send }
            };
            ServiceBusQueueAuthorizationRuleResource authorizationRule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName, parameter)).Value;
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
        public async Task QueueCreateOrUpdateParameters()
        {
            //This test is written with an intention of testing each and every parameter on the queue
            //create queue
            string firstQueueName = Recording.GenerateAssetName("queue");
            string secondQueueName = Recording.GenerateAssetName("queue");
            string thirdQueueName = Recording.GenerateAssetName("queue");
            string fourthQueueName = Recording.GenerateAssetName("queue");
            ServiceBusQueueResource firstQueue = (await _queueCollection.CreateOrUpdateAsync(WaitUntil.Completed, firstQueueName, new ServiceBusQueueData())).Value;

            ServiceBusQueueData queueData = new ServiceBusQueueData()
            {
                LockDuration = new TimeSpan(0, 3, 0),
                MaxSizeInMegabytes = 4096,
                DuplicateDetectionHistoryTimeWindow = new TimeSpan(0, 10, 0),
                DeadLetteringOnMessageExpiration = true,
                RequiresDuplicateDetection = true,
                MaxDeliveryCount = 8,
                Status = ServiceBusMessagingEntityStatus.Active,
                DefaultMessageTimeToLive = new TimeSpan(428, 3, 11, 2),
                EnableBatchedOperations = false,
                ForwardTo = firstQueueName,
                ForwardDeadLetteredMessagesTo = firstQueueName,
                MaxMessageSizeInKilobytes = 102400
            };

            ServiceBusQueueResource secondQueue = (await _queueCollection.CreateOrUpdateAsync(WaitUntil.Completed, secondQueueName, queueData)).Value;
            Assert.AreEqual(new TimeSpan(0, 3, 0), secondQueue.Data.LockDuration);
            Assert.AreEqual(new TimeSpan(0, 10, 0), secondQueue.Data.DuplicateDetectionHistoryTimeWindow);
            Assert.AreEqual(new TimeSpan(428, 3, 11, 2), secondQueue.Data.DefaultMessageTimeToLive);
            Assert.AreEqual(4096, queueData.MaxSizeInMegabytes);
            Assert.AreEqual(8, queueData.MaxDeliveryCount);
            Assert.True(queueData.DeadLetteringOnMessageExpiration);
            Assert.True(queueData.RequiresDuplicateDetection);
            Assert.AreEqual(ServiceBusMessagingEntityStatus.Active, queueData.Status);
            Assert.AreEqual(firstQueueName, queueData.ForwardTo);
            Assert.AreEqual(firstQueueName, queueData.ForwardDeadLetteredMessagesTo);
            Assert.AreEqual(102400, queueData.MaxMessageSizeInKilobytes);

            secondQueue.Data.Status = ServiceBusMessagingEntityStatus.Disabled;
            queueData = secondQueue.Data;
            secondQueue = (await _queueCollection.CreateOrUpdateAsync(WaitUntil.Completed, secondQueueName, secondQueue.Data)).Value;
            AssertQueuePropertiesOnUpdates(queueData, secondQueue.Data);

            secondQueue.Data.Status = ServiceBusMessagingEntityStatus.ReceiveDisabled;
            queueData = secondQueue.Data;
            secondQueue = (await _queueCollection.CreateOrUpdateAsync(WaitUntil.Completed, secondQueueName, secondQueue.Data)).Value;
            AssertQueuePropertiesOnUpdates(queueData, secondQueue.Data);

            secondQueue.Data.Status = ServiceBusMessagingEntityStatus.SendDisabled;
            queueData = secondQueue.Data;
            secondQueue = (await _queueCollection.CreateOrUpdateAsync(WaitUntil.Completed, secondQueueName, secondQueue.Data)).Value;
            AssertQueuePropertiesOnUpdates(queueData, secondQueue.Data);

            queueData = new ServiceBusQueueData()
            {
                AutoDeleteOnIdle = new TimeSpan(7, 0, 0, 0),
                RequiresSession = true
            };

            ServiceBusQueueResource thirdQueue = (await _queueCollection.CreateOrUpdateAsync(WaitUntil.Completed, thirdQueueName, queueData)).Value;
            Assert.AreEqual(new TimeSpan(7, 0, 0, 0), thirdQueue.Data.AutoDeleteOnIdle);
            Assert.True(thirdQueue.Data.RequiresSession);

            //EnableExpress can only be set for Standard Namespaces
            queueData = new ServiceBusQueueData()
            {
                EnableExpress = true
            };
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _queueCollection.CreateOrUpdateAsync(WaitUntil.Completed, fourthQueueName, queueData); });
            Assert.AreEqual(400, exception.Status);
        }

        public void AssertQueuePropertiesOnUpdates(ServiceBusQueueData actualQueue, ServiceBusQueueData expectedQueue)
        {
            Assert.AreEqual(expectedQueue.Location, actualQueue.Location);
            Assert.AreEqual(expectedQueue.LockDuration, actualQueue.LockDuration);
            Assert.AreEqual(expectedQueue.DefaultMessageTimeToLive, actualQueue.DefaultMessageTimeToLive);
            Assert.AreEqual(expectedQueue.DuplicateDetectionHistoryTimeWindow, actualQueue.DuplicateDetectionHistoryTimeWindow);
            Assert.AreEqual(expectedQueue.RequiresDuplicateDetection, actualQueue.RequiresDuplicateDetection);
            Assert.AreEqual(expectedQueue.RequiresSession, actualQueue.RequiresSession);
            Assert.AreEqual(expectedQueue.ForwardDeadLetteredMessagesTo, actualQueue.ForwardDeadLetteredMessagesTo);
            Assert.AreEqual(expectedQueue.ForwardTo, actualQueue.ForwardTo);
            Assert.AreEqual(expectedQueue.MaxDeliveryCount, actualQueue.MaxDeliveryCount);
            Assert.AreEqual(expectedQueue.EnableBatchedOperations, actualQueue.EnableBatchedOperations);
            Assert.AreEqual(expectedQueue.MaxMessageSizeInKilobytes, actualQueue.MaxMessageSizeInKilobytes);
            Assert.AreEqual(expectedQueue.MaxSizeInMegabytes, actualQueue.MaxSizeInMegabytes);
            Assert.AreEqual(expectedQueue.Status, actualQueue.Status);
            Assert.AreEqual(expectedQueue.AutoDeleteOnIdle, actualQueue.AutoDeleteOnIdle);
            Assert.AreEqual(expectedQueue.EnableExpress, actualQueue.EnableExpress);
            Assert.AreEqual(expectedQueue.EnablePartitioning, actualQueue.EnablePartitioning);
        }
    }
}
