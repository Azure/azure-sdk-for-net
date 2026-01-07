// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ServiceBus.Models;

namespace Azure.ResourceManager.ServiceBus.Tests
{
    public class QueueTests : ServiceBusManagementTestBase
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
            Assert.That(queue, Is.Not.Null);
            Assert.That(queueName, Is.EqualTo(queue.Id.Name));

            //validate if created successfully
            Assert.That((bool)await _queueCollection.ExistsAsync(queueName), Is.True);
            queue = await _queueCollection.GetAsync(queueName);

            //delete queue
            await queue.DeleteAsync(WaitUntil.Completed);

            //validate
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _queueCollection.GetAsync(queueName); });
            Assert.That(exception.Status, Is.EqualTo(404));
            Assert.That((bool)await _queueCollection.ExistsAsync(queueName), Is.False);
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
            Assert.That(list.Count, Is.EqualTo(10));
            list = await _queueCollection.GetAllAsync(5, 5).ToEnumerableAsync();
            Assert.That(list.Count, Is.EqualTo(5));
        }

        [Test]
        [RecordedTest]
        public async Task UpdateQueue()
        {
            IgnoreTestInLiveMode();
            //create queue
            string queueName = Recording.GenerateAssetName("queue");
            ServiceBusQueueResource queue = (await _queueCollection.CreateOrUpdateAsync(WaitUntil.Completed, queueName, new ServiceBusQueueData())).Value;
            Assert.That(queue, Is.Not.Null);
            Assert.That(queueName, Is.EqualTo(queue.Id.Name));

            //update queue
            ServiceBusQueueData parameters = new ServiceBusQueueData()
            {
                MaxSizeInMegabytes = 1024
            };
            queue = (await _queueCollection.CreateOrUpdateAsync(WaitUntil.Completed, queueName, parameters)).Value;
            Assert.That(queue.Data.MaxMessageSizeInKilobytes, Is.EqualTo(1024));
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
            Assert.That(authorizationRule, Is.Not.Null);
            Assert.That(parameter.Rights.Count, Is.EqualTo(authorizationRule.Data.Rights.Count));

            //get authorization rule
            authorizationRule = await ruleCollection.GetAsync(ruleName);
            Assert.That(ruleName, Is.EqualTo(authorizationRule.Id.Name));
            Assert.That(authorizationRule, Is.Not.Null);
            Assert.That(parameter.Rights.Count, Is.EqualTo(authorizationRule.Data.Rights.Count));

            //get all authorization rules
            List<ServiceBusQueueAuthorizationRuleResource> rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();

            //validate
            Assert.That(rules.Count, Is.EqualTo(1));
            bool isContainAuthorizationRuleName = false;
            foreach (ServiceBusQueueAuthorizationRuleResource rule in rules)
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
            Assert.That(rules.Count, Is.EqualTo(0));
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
            Assert.That(secondQueue.Data.LockDuration, Is.EqualTo(new TimeSpan(0, 3, 0)));
            Assert.That(secondQueue.Data.DuplicateDetectionHistoryTimeWindow, Is.EqualTo(new TimeSpan(0, 10, 0)));
            Assert.That(secondQueue.Data.DefaultMessageTimeToLive, Is.EqualTo(new TimeSpan(428, 3, 11, 2)));
            Assert.That(queueData.MaxSizeInMegabytes, Is.EqualTo(4096));
            Assert.That(queueData.MaxDeliveryCount, Is.EqualTo(8));
            Assert.That(queueData.DeadLetteringOnMessageExpiration, Is.True);
            Assert.That(queueData.RequiresDuplicateDetection, Is.True);
            Assert.That(queueData.Status, Is.EqualTo(ServiceBusMessagingEntityStatus.Active));
            Assert.That(queueData.ForwardTo, Is.EqualTo(firstQueueName));
            Assert.That(queueData.ForwardDeadLetteredMessagesTo, Is.EqualTo(firstQueueName));
            Assert.That(queueData.MaxMessageSizeInKilobytes, Is.EqualTo(102400));

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
            Assert.That(thirdQueue.Data.AutoDeleteOnIdle, Is.EqualTo(new TimeSpan(7, 0, 0, 0)));
            Assert.That(thirdQueue.Data.RequiresSession, Is.True);

            //EnableExpress can only be set for Standard Namespaces
            queueData = new ServiceBusQueueData()
            {
                EnableExpress = true
            };
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _queueCollection.CreateOrUpdateAsync(WaitUntil.Completed, fourthQueueName, queueData); });
            Assert.That(exception.Status, Is.EqualTo(400));
        }

        public void AssertQueuePropertiesOnUpdates(ServiceBusQueueData actualQueue, ServiceBusQueueData expectedQueue)
        {
            Assert.That(actualQueue.Location, Is.EqualTo(expectedQueue.Location));
            Assert.That(actualQueue.LockDuration, Is.EqualTo(expectedQueue.LockDuration));
            Assert.That(actualQueue.DefaultMessageTimeToLive, Is.EqualTo(expectedQueue.DefaultMessageTimeToLive));
            Assert.That(actualQueue.DuplicateDetectionHistoryTimeWindow, Is.EqualTo(expectedQueue.DuplicateDetectionHistoryTimeWindow));
            Assert.That(actualQueue.RequiresDuplicateDetection, Is.EqualTo(expectedQueue.RequiresDuplicateDetection));
            Assert.That(actualQueue.RequiresSession, Is.EqualTo(expectedQueue.RequiresSession));
            Assert.That(actualQueue.ForwardDeadLetteredMessagesTo, Is.EqualTo(expectedQueue.ForwardDeadLetteredMessagesTo));
            Assert.That(actualQueue.ForwardTo, Is.EqualTo(expectedQueue.ForwardTo));
            Assert.That(actualQueue.MaxDeliveryCount, Is.EqualTo(expectedQueue.MaxDeliveryCount));
            Assert.That(actualQueue.EnableBatchedOperations, Is.EqualTo(expectedQueue.EnableBatchedOperations));
            Assert.That(actualQueue.MaxMessageSizeInKilobytes, Is.EqualTo(expectedQueue.MaxMessageSizeInKilobytes));
            Assert.That(actualQueue.MaxSizeInMegabytes, Is.EqualTo(expectedQueue.MaxSizeInMegabytes));
            Assert.That(actualQueue.Status, Is.EqualTo(expectedQueue.Status));
            Assert.That(actualQueue.AutoDeleteOnIdle, Is.EqualTo(expectedQueue.AutoDeleteOnIdle));
            Assert.That(actualQueue.EnableExpress, Is.EqualTo(expectedQueue.EnableExpress));
            Assert.That(actualQueue.EnablePartitioning, Is.EqualTo(expectedQueue.EnablePartitioning));
        }
    }
}
