// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests
{
    public class EventGridNamespaceTopicTests : EventGridManagementTestBase
    {
        public EventGridNamespaceTopicTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        private EventGridNamespaceCollection NamespaceCollection { get; set; }
        private ResourceGroupResource ResourceGroup { get; set; }

        private async Task SetCollection()
        {
            ResourceGroup = await CreateResourceGroupAsync(DefaultSubscription, Recording.GenerateAssetName("sdktest-"), DefaultLocation);
            NamespaceCollection = ResourceGroup.GetEventGridNamespaces();
        }

        [Test]
        public async Task NamespaceTopicsCreateUpdateDelete()
        {
            await SetCollection();
            var namespaceName = Recording.GenerateAssetName("sdk-Namespace-");
            var namespaceTopicName = Recording.GenerateAssetName("sdk-Namespace-Topic");
            var namespaceTopicName2 = Recording.GenerateAssetName("sdk-Namespace-Topic");
            var namespaceTopicName3 = Recording.GenerateAssetName("sdk-Namespace-Topic");
            var namespaceSkuName = "Standard";
            var namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 1,
            };
            AzureLocation location = new AzureLocation("eastus2euap", "eastus2euap");
            var nameSpace = new EventGridNamespaceData(location)
            {
                Tags = {
                    {"originalTag1", "originalValue1"},
                    {"originalTag2", "originalValue2"}
                },
                Sku = namespaceSku,
                IsZoneRedundant = true
            };

            var createNamespaceResponse = (await NamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, nameSpace)).Value;
            Assert.NotNull(createNamespaceResponse);
            Assert.AreEqual(createNamespaceResponse.Data.Name, namespaceName);

            // create namespace topics
            var namespaceTopicsCollection = createNamespaceResponse.GetNamespaceTopics();
            Assert.NotNull(namespaceTopicsCollection);

            var namespaceTopic = new NamespaceTopicData()
            {
                EventRetentionInDays = 1
            };
            var namespaceTopic2 = new NamespaceTopicData()
            {
                EventRetentionInDays = 1
            };
            var namespaceTopic3 = new NamespaceTopicData()
            {
                EventRetentionInDays = 1
            };

            var namespaceTopicsResponse1 = (await namespaceTopicsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicName, namespaceTopic)).Value;
            Assert.NotNull(namespaceTopicsResponse1);
            Assert.AreEqual(namespaceTopicsResponse1.Data.ProvisioningState, NamespaceTopicProvisioningState.Succeeded);
            Assert.AreEqual(namespaceTopicsResponse1.Data.EventRetentionInDays, 1);

            var namespaceTopicsResponse2 = (await namespaceTopicsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicName2, namespaceTopic2)).Value;
            Assert.NotNull(namespaceTopicsResponse2);
            Assert.AreEqual(namespaceTopicsResponse2.Data.ProvisioningState, NamespaceTopicProvisioningState.Succeeded);
            Assert.AreEqual(namespaceTopicsResponse2.Data.EventRetentionInDays, 1);

            var namespaceTopicsResponse3 = (await namespaceTopicsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicName3, namespaceTopic3)).Value;
            Assert.NotNull(namespaceTopicsResponse3);
            Assert.AreEqual(namespaceTopicsResponse3.Data.ProvisioningState, NamespaceTopicProvisioningState.Succeeded);
            Assert.AreEqual(namespaceTopicsResponse3.Data.EventRetentionInDays, 1);

            //Update namespace topic
            NamespaceTopicPatch namespaceTopicPatch = new NamespaceTopicPatch()
            {
                EventRetentionInDays = 1
            };
            var updateNamespaceTopicResponse = (await namespaceTopicsResponse1.UpdateAsync(WaitUntil.Completed, namespaceTopicPatch)).Value;
            Assert.NotNull(updateNamespaceTopicResponse);

            var getUpdatedNamespaceTopic = (await namespaceTopicsResponse1.GetAsync()).Value;
            Assert.NotNull(getUpdatedNamespaceTopic);
            Assert.AreEqual(getUpdatedNamespaceTopic.Data.EventRetentionInDays, 1);

            // Regenerate namespace topic keys
            var sharedAccessKeyBefore = (await getUpdatedNamespaceTopic.GetSharedAccessKeysAsync()).Value;
            Assert.NotNull(sharedAccessKeyBefore);
            TopicRegenerateKeyContent topicRegenerateKeyContent = new TopicRegenerateKeyContent("key1");
            var sharedAccessKeyAfter = (await getUpdatedNamespaceTopic.RegenerateKeyAsync(WaitUntil.Completed, topicRegenerateKeyContent)).Value;
            Assert.NotNull(sharedAccessKeyAfter);
            Assert.AreNotEqual(sharedAccessKeyBefore.Key1, sharedAccessKeyAfter.Key1);
            Assert.AreEqual(sharedAccessKeyBefore.Key2, sharedAccessKeyAfter.Key2);

            //list namespace topics
            var getAllNamespaceTopics = await namespaceTopicsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(getAllNamespaceTopics);
            Assert.AreEqual(3, getAllNamespaceTopics.Count);

            // delete namespace
            await getUpdatedNamespaceTopic.DeleteAsync(WaitUntil.Completed);

            //verify deletion
            var getAllNamespaceTopicsUpdated = await namespaceTopicsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(getAllNamespaceTopicsUpdated);
            Assert.AreEqual(2, getAllNamespaceTopicsUpdated.Count);

            // delete all namespace topics
            await namespaceTopicsResponse2.DeleteAsync(WaitUntil.Completed);
            await namespaceTopicsResponse3.DeleteAsync(WaitUntil.Completed);
            var getAllNamespaceTopicsDeleted = await namespaceTopicsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(getAllNamespaceTopicsDeleted);
            Assert.AreEqual(0, getAllNamespaceTopicsDeleted.Count);

            // delete namespace
            await createNamespaceResponse.DeleteAsync(WaitUntil.Completed);
            await ResourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task NamespaceTopicsSubscriptionCreateUpdateDelete()
        {
            await SetCollection();
            var namespaceName = Recording.GenerateAssetName("sdk-Namespace-");
            var namespaceTopicName = Recording.GenerateAssetName("sdk-Namespace-Topic");
            var namespaceTopicSubscriptionName1 = Recording.GenerateAssetName("sdk-Namespace-Topic-Subscription");
            var namespaceTopicSubscriptionName2 = Recording.GenerateAssetName("sdk-Namespace-Topic-Subscription");
            var namespaceTopicSubscriptionName3 = Recording.GenerateAssetName("sdk-Namespace-Topic-Subscription");
            var namespaceSkuName = "Standard";
            var namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 1,
            };
            AzureLocation location = new AzureLocation("eastus2euap", "eastus2euap");
            var nameSpace = new EventGridNamespaceData(location)
            {
                Tags = {
                    {"originalTag1", "originalValue1"},
                    {"originalTag2", "originalValue2"}
                },
                Sku = namespaceSku,
                IsZoneRedundant = true
            };
            var createNamespaceResponse = (await NamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, nameSpace)).Value;
            Assert.NotNull(createNamespaceResponse);
            Assert.AreEqual(createNamespaceResponse.Data.Name, namespaceName);

            // create namespace topics
            var namespaceTopicsCollection = createNamespaceResponse.GetNamespaceTopics();
            Assert.NotNull(namespaceTopicsCollection);
            var namespaceTopic = new NamespaceTopicData()
            {
                EventRetentionInDays = 1
            };
            var namespaceTopicsResponse1 = (await namespaceTopicsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicName, namespaceTopic)).Value;
            Assert.NotNull(namespaceTopicsResponse1);
            Assert.AreEqual(namespaceTopicsResponse1.Data.ProvisioningState, NamespaceTopicProvisioningState.Succeeded);
            Assert.AreEqual(namespaceTopicsResponse1.Data.EventRetentionInDays, 1);

            // create subscriptions
            var subscriptionsCollection = namespaceTopicsResponse1.GetNamespaceTopicEventSubscriptions();

            DeliveryConfiguration deliveryConfiguration = new DeliveryConfiguration()
            {
                DeliveryMode = DeliveryMode.Queue.ToString(),
                Queue = new QueueInfo()
                {
                    EventTimeToLive = TimeSpan.FromDays(1),
                    MaxDeliveryCount = 5,
                    ReceiveLockDurationInSeconds = 120
                }
            };
            NamespaceTopicEventSubscriptionData subscriptionData = new NamespaceTopicEventSubscriptionData()
            {
                DeliveryConfiguration = deliveryConfiguration
            };
            var createEventsubscription1 = (await subscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicSubscriptionName1, subscriptionData)).Value;
            Assert.NotNull(createEventsubscription1);
            Assert.AreEqual(createEventsubscription1.Data.ProvisioningState, SubscriptionProvisioningState.Succeeded);

            var createEventsubscription2 = (await subscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicSubscriptionName2, subscriptionData)).Value;
            Assert.NotNull(createEventsubscription2);
            Assert.AreEqual(createEventsubscription2.Data.ProvisioningState, SubscriptionProvisioningState.Succeeded);

            var createEventsubscription3 = (await subscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicSubscriptionName3, subscriptionData)).Value;
            Assert.NotNull(createEventsubscription3);
            Assert.AreEqual(createEventsubscription3.Data.ProvisioningState, SubscriptionProvisioningState.Succeeded);

            // Validate get event subscription
            var getEventSubscription1 = (await subscriptionsCollection.GetAsync(namespaceTopicSubscriptionName1)).Value;
            Assert.NotNull (getEventSubscription1);
            Assert.AreEqual(getEventSubscription1.Data.Name, namespaceTopicSubscriptionName1);
            Assert.AreEqual(getEventSubscription1.Data.DeliveryConfiguration.DeliveryMode.ToString(), DeliveryMode.Queue.ToString());
            Assert.AreEqual(getEventSubscription1.Data.DeliveryConfiguration.Queue.EventTimeToLive, TimeSpan.FromDays(1));
            Assert.AreEqual(getEventSubscription1.Data.DeliveryConfiguration.Queue.MaxDeliveryCount, 5);

            //update event subscription
            DeliveryConfiguration deliveryConfiguration2 = new DeliveryConfiguration()
            {
                DeliveryMode = DeliveryMode.Queue.ToString(),
                Queue = new QueueInfo()
                {
                    EventTimeToLive = TimeSpan.FromDays(0.5),
                    MaxDeliveryCount = 6,
                    ReceiveLockDurationInSeconds = 120
                }
            };
            NamespaceTopicEventSubscriptionPatch subscriptionPatch = new NamespaceTopicEventSubscriptionPatch()
            {
                DeliveryConfiguration = deliveryConfiguration2
            };
            var updateEventSubscription1 = (await createEventsubscription1.UpdateAsync(WaitUntil.Completed, subscriptionPatch)).Value;
            Assert.NotNull(updateEventSubscription1);
            Assert.AreEqual(updateEventSubscription1.Data.ProvisioningState, SubscriptionProvisioningState.Succeeded);

            var getUpdatedEventSubscription1 = (await subscriptionsCollection.GetAsync(namespaceTopicSubscriptionName1)).Value;
            Assert.NotNull(getUpdatedEventSubscription1);
            Assert.AreEqual(getUpdatedEventSubscription1.Data.Name, namespaceTopicSubscriptionName1);
            Assert.AreEqual(getUpdatedEventSubscription1.Data.DeliveryConfiguration.DeliveryMode.ToString(), DeliveryMode.Queue.ToString());
            Assert.AreEqual(getUpdatedEventSubscription1.Data.DeliveryConfiguration.Queue.EventTimeToLive, TimeSpan.FromDays(0.5));
            Assert.AreEqual(getUpdatedEventSubscription1.Data.DeliveryConfiguration.Queue.MaxDeliveryCount, 6);

            // List all event subscriptions
            var listAllSubscriptionsBefore = await subscriptionsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(listAllSubscriptionsBefore);
            Assert.AreEqual(listAllSubscriptionsBefore.Count, 3);

            // Delete event subscriptions
            await getUpdatedEventSubscription1.DeleteAsync(WaitUntil.Completed);
            var listAllSubscriptionsAfter = await subscriptionsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(listAllSubscriptionsAfter);
            Assert.AreEqual(listAllSubscriptionsAfter.Count, 2);

            // delete all resources
            await createEventsubscription2.DeleteAsync(WaitUntil.Completed);
            await createEventsubscription3.DeleteAsync(WaitUntil.Completed);
            var listAllSubscriptionsAfterAllDeleted = await subscriptionsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(listAllSubscriptionsAfterAllDeleted);
            Assert.AreEqual(listAllSubscriptionsAfterAllDeleted.Count, 0);
            await namespaceTopicsResponse1.DeleteAsync(WaitUntil.Completed);
            await createNamespaceResponse.DeleteAsync(WaitUntil.Completed);
            await ResourceGroup.DeleteAsync(WaitUntil.Completed);
        }
    }
}