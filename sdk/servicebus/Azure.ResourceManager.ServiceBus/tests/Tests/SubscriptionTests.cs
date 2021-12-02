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
        public async Task CreateGetUpdateDeleteSubscription()
        {
            //create namespace
            ResourceGroup resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            ServiceBusNamespaceCollection namespaceCollection = resourceGroup.GetServiceBusNamespaces();
            ServiceBusNamespace serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(namespaceName, new ServiceBusNamespaceData(DefaultLocation))).Value;

            //create a topic
            ServiceBusTopicCollection topicCollection = serviceBusNamespace.GetServiceBusTopics();
            string topicName = Recording.GenerateAssetName("topic");
            ServiceBusTopic topic = (await topicCollection.CreateOrUpdateAsync(topicName, new ServiceBusTopicData())).Value;
            Assert.NotNull(topic);
            Assert.AreEqual(topic.Id.Name, topicName);

            //create a subscription
            ServiceBusSubscriptionCollection serviceBusSubscriptionCollection = topic.GetServiceBusSubscriptions();
            string subscriptionName = Recording.GenerateAssetName("subscription");
            ServiceBusSubscriptionData parameters = new ServiceBusSubscriptionData()
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
            ServiceBusSubscription serviceBusSubscription = (await serviceBusSubscriptionCollection.CreateOrUpdateAsync(subscriptionName, parameters)).Value;
            Assert.NotNull(serviceBusSubscription);
            Assert.AreEqual(serviceBusSubscription.Id.Name, subscriptionName);

            //get created subscription
            serviceBusSubscription = await serviceBusSubscriptionCollection.GetAsync(subscriptionName);
            Assert.NotNull(serviceBusSubscription);
            Assert.AreEqual(serviceBusSubscription.Id.Name, subscriptionName);
            Assert.AreEqual(serviceBusSubscription.Data.Status, EntityStatus.Active);

            //get all subscriptions
            List<ServiceBusSubscription> serviceBusSubscriptions = await serviceBusSubscriptionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(serviceBusSubscriptions.Count, 1);

            //create a topic for autoforward
            string topicName1 = Recording.GenerateAssetName("topic");
            ServiceBusTopic topic1 = (await topicCollection.CreateOrUpdateAsync(topicName1, new ServiceBusTopicData() { EnablePartitioning = true})).Value;
            Assert.NotNull(topic1);
            Assert.AreEqual(topic1.Id.Name, topicName1);

            //update subscription and validate
            ServiceBusSubscriptionData updateParameters = new ServiceBusSubscriptionData()
            {
                EnableBatchedOperations = true,
                DeadLetteringOnMessageExpiration = true,
                ForwardDeadLetteredMessagesTo = topicName1,
                ForwardTo = topicName1
            };
            serviceBusSubscription = (await serviceBusSubscriptionCollection.CreateOrUpdateAsync(subscriptionName, updateParameters)).Value;
            Assert.NotNull(serviceBusSubscription);
            Assert.AreEqual(serviceBusSubscription.Id.Name, subscriptionName);
            Assert.AreEqual(serviceBusSubscription.Data.Status, EntityStatus.Active);
            Assert.IsTrue(serviceBusSubscription.Data.EnableBatchedOperations);
            Assert.AreEqual(serviceBusSubscription.Data.ForwardTo, topicName1);

            //delete subscription
            await serviceBusSubscription.DeleteAsync();
            Assert.IsFalse(await serviceBusSubscriptionCollection.CheckIfExistsAsync(subscriptionName));

            //delete created topics
            await topic.DeleteAsync();
            await topic1.DeleteAsync();

            //delete namespace
            await serviceBusNamespace.DeleteAsync();
        }
    }
}
