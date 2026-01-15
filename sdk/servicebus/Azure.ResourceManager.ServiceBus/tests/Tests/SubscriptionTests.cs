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
    public class SubscriptionTests : ServiceBusManagementTestBase
    {
        public SubscriptionTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [RecordedTest]
        public async Task CreateGetUpdateDeleteSubscription()
        {
            IgnoreTestInLiveMode();
            //create namespace
            ResourceGroupResource resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            ServiceBusNamespaceCollection namespaceCollection = resourceGroup.GetServiceBusNamespaces();
            ServiceBusNamespaceResource serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new ServiceBusNamespaceData(DefaultLocation))).Value;

            //create a topic
            ServiceBusTopicCollection topicCollection = serviceBusNamespace.GetServiceBusTopics();
            string topicName = Recording.GenerateAssetName("topic");
            ServiceBusTopicResource topic = (await topicCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicName, new ServiceBusTopicData())).Value;
            Assert.NotNull(topic);
            Assert.That(topicName, Is.EqualTo(topic.Id.Name));

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
                Status = ServiceBusMessagingEntityStatus.Active,
                AutoDeleteOnIdle = TimeSpan.Parse("00:07:00"),
                DeadLetteringOnFilterEvaluationExceptions = true
            };
            ServiceBusSubscriptionResource serviceBusSubscription = (await serviceBusSubscriptionCollection.CreateOrUpdateAsync(WaitUntil.Completed, subscriptionName, parameters)).Value;
            Assert.NotNull(serviceBusSubscription);
            Assert.That(subscriptionName, Is.EqualTo(serviceBusSubscription.Id.Name));

            //get created subscription
            serviceBusSubscription = await serviceBusSubscriptionCollection.GetAsync(subscriptionName);
            Assert.NotNull(serviceBusSubscription);
            Assert.That(subscriptionName, Is.EqualTo(serviceBusSubscription.Id.Name));
            Assert.That(serviceBusSubscription.Data.Status, Is.EqualTo(ServiceBusMessagingEntityStatus.Active));

            //get all subscriptions
            List<ServiceBusSubscriptionResource> serviceBusSubscriptions = await serviceBusSubscriptionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(serviceBusSubscriptions.Count, Is.EqualTo(1));

            //create a topic for autoforward
            string topicName1 = Recording.GenerateAssetName("topic");
            ServiceBusTopicResource topic1 = (await topicCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicName1, new ServiceBusTopicData() { EnablePartitioning = true})).Value;
            Assert.NotNull(topic1);
            Assert.That(topicName1, Is.EqualTo(topic1.Id.Name));

            //update subscription and validate
            ServiceBusSubscriptionData updateParameters = new ServiceBusSubscriptionData()
            {
                EnableBatchedOperations = true,
                DeadLetteringOnMessageExpiration = true,
                ForwardDeadLetteredMessagesTo = topicName1,
                ForwardTo = topicName1
            };
            serviceBusSubscription = (await serviceBusSubscriptionCollection.CreateOrUpdateAsync(WaitUntil.Completed, subscriptionName, updateParameters)).Value;
            Assert.NotNull(serviceBusSubscription);
            Assert.That(subscriptionName, Is.EqualTo(serviceBusSubscription.Id.Name));
            Assert.That(serviceBusSubscription.Data.Status, Is.EqualTo(ServiceBusMessagingEntityStatus.Active));
            Assert.That(serviceBusSubscription.Data.EnableBatchedOperations, Is.True);
            Assert.That(topicName1, Is.EqualTo(serviceBusSubscription.Data.ForwardTo));

            //delete subscription
            await serviceBusSubscription.DeleteAsync(WaitUntil.Completed);
            Assert.That((bool)await serviceBusSubscriptionCollection.ExistsAsync(subscriptionName), Is.False);
        }
    }
}
