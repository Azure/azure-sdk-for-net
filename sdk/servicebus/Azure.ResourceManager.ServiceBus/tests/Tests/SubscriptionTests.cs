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
    public class SubscriptionTests : ServiceBusTestBase
    {
        public SubscriptionTests(bool isAsync) : base(isAsync)
        {
        }
        [Test]
        [RecordedTest]
        [Ignore("cannot parse SBSubscription id")]
        public async Task CreateGetUpdateDeleteSubscription()
        {
            //create namespace
            ResourceGroup resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            SBNamespaceCollection namespaceCollection = resourceGroup.GetSBNamespaces();
            SBNamespace sBNamespace = (await namespaceCollection.CreateOrUpdateAsync(namespaceName, new SBNamespaceData(DefaultLocation))).Value;

            //create a topic
            SBTopicCollection topicCollection = sBNamespace.GetSBTopics();
            string topicName = Recording.GenerateAssetName("topic");
            SBTopic topic = (await topicCollection.CreateOrUpdateAsync(topicName, new SBTopicData())).Value;
            Assert.NotNull(topic);
            Assert.AreEqual(topic.Id.Name, topicName);

            //create a subscription
            SBSubscriptionCollection sBSubscriptionCollection = topic.GetSBSubscriptions();
            string subscriptionName = Recording.GenerateAssetName("subscription");
            SBSubscriptionData parameters = new SBSubscriptionData()
            {
                EnableBatchedOperations = true,
                LockDuration = TimeSpan.Parse("00:03:00"),
                DefaultMessageTimeToLive = TimeSpan.Parse("00:05:00"),
                DeadLetteringOnMessageExpiration = true,
                MaxDeliveryCount = 14,
                Status = EntityStatus.Active,
                AutoDeleteOnIdle = TimeSpan.Parse("00:07:00"),
                DeadLetteringOnFilterEvaluationExceptions = true
            };
            SBSubscription sBSubscription = (await sBSubscriptionCollection.CreateOrUpdateAsync(subscriptionName, parameters)).Value;
            Assert.NotNull(sBSubscription);
            Assert.AreEqual(sBSubscription.Id.Name, subscriptionName);

            //get created subscription
            sBSubscription = await sBSubscriptionCollection.GetAsync(subscriptionName);
            Assert.NotNull(sBSubscription);
            Assert.AreEqual(sBSubscription.Id.Name, subscriptionName);
            Assert.AreEqual(sBSubscription.Data.Status, EntityStatus.Active);

            //get all subscriptions
            List<SBSubscription> sBSubscriptions = await sBSubscriptionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(sBSubscriptions.Count, 1);

            //create a topic for autoforward
            string topicName1 = Recording.GenerateAssetName("topic");
            SBTopic topic1 = (await topicCollection.CreateOrUpdateAsync(topicName1, new SBTopicData() { EnablePartitioning = true})).Value;
            Assert.NotNull(topic1);
            Assert.AreEqual(topic1.Id.Name, topicName1);

            //update subscription and validate
            SBSubscriptionData updateParameters = new SBSubscriptionData()
            {
                EnableBatchedOperations = true,
                DeadLetteringOnMessageExpiration = true,
                ForwardDeadLetteredMessagesTo = topicName1,
                ForwardTo = topicName1
            };
            sBSubscription = (await sBSubscriptionCollection.CreateOrUpdateAsync(subscriptionName, updateParameters)).Value;
            Assert.NotNull(sBSubscription);
            Assert.AreEqual(sBSubscription.Id.Name, subscriptionName);
            Assert.AreEqual(sBSubscription.Data.Status, EntityStatus.Active);
            Assert.IsTrue(sBSubscription.Data.EnableBatchedOperations);
            Assert.AreEqual(sBSubscription.Data.ForwardTo, topicName1);

            //delete subscription
            await sBSubscription.DeleteAsync();
            Assert.IsFalse(await sBSubscriptionCollection.CheckIfExistsAsync(subscriptionName));

            //delete created topics
            await topic.DeleteAsync();
            await topic1.DeleteAsync();

            //delete namespace
            await sBNamespace.DeleteAsync();
        }
    }
}
