// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
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

        // For the webhook endpoint, replace "SANITIZED_FUNCTION_KEY" with the function key
        // from the Logic App "sdk-test-logic-app" in the CentralUSEUAP region under the
        // "Azure Event Grid SDK" subscription.
        private const string LogicAppEndpointUrl = "https://prod-16.centraluseuap.logic.azure.com:443/workflows/9ace43ec97744a61acea5db9feaae8af/triggers/When_a_HTTP_request_is_received/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2FWhen_a_HTTP_request_is_received%2Frun&sv=SANITIZED_FUNCTION_KEY&sig=SANITIZED_FUNCTION_KEY";

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
            AzureLocation location = new AzureLocation("eastus2", "eastus2");
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
            Assert.That(createNamespaceResponse, Is.Not.Null);
            Assert.That(namespaceName, Is.EqualTo(createNamespaceResponse.Data.Name));

            // create namespace topics
            var namespaceTopicsCollection = createNamespaceResponse.GetNamespaceTopics();
            Assert.That(namespaceTopicsCollection, Is.Not.Null);

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
            Assert.That(namespaceTopicsResponse1, Is.Not.Null);
            Assert.That(NamespaceTopicProvisioningState.Succeeded, Is.EqualTo(namespaceTopicsResponse1.Data.ProvisioningState));
            Assert.That(namespaceTopicsResponse1.Data.EventRetentionInDays, Is.EqualTo(1));

            var namespaceTopicsResponse2 = (await namespaceTopicsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicName2, namespaceTopic2)).Value;
            Assert.That(namespaceTopicsResponse2, Is.Not.Null);
            Assert.That(NamespaceTopicProvisioningState.Succeeded, Is.EqualTo(namespaceTopicsResponse2.Data.ProvisioningState));
            Assert.That(namespaceTopicsResponse2.Data.EventRetentionInDays, Is.EqualTo(1));

            var namespaceTopicsResponse3 = (await namespaceTopicsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicName3, namespaceTopic3)).Value;
            Assert.That(namespaceTopicsResponse3, Is.Not.Null);
            Assert.That(NamespaceTopicProvisioningState.Succeeded, Is.EqualTo(namespaceTopicsResponse3.Data.ProvisioningState));
            Assert.That(namespaceTopicsResponse3.Data.EventRetentionInDays, Is.EqualTo(1));

            //Update namespace topic
            NamespaceTopicPatch namespaceTopicPatch = new NamespaceTopicPatch()
            {
                EventRetentionInDays = 1
            };
            var updateNamespaceTopicResponse = (await namespaceTopicsResponse1.UpdateAsync(WaitUntil.Completed, namespaceTopicPatch)).Value;
            Assert.That(updateNamespaceTopicResponse, Is.Not.Null);

            var getUpdatedNamespaceTopic = (await namespaceTopicsResponse1.GetAsync()).Value;
            Assert.That(getUpdatedNamespaceTopic, Is.Not.Null);
            Assert.That(getUpdatedNamespaceTopic.Data.EventRetentionInDays, Is.EqualTo(1));

            // Get Shared Access Keys
            var sharedAccessKeyBefore = (await getUpdatedNamespaceTopic.GetSharedAccessKeysAsync()).Value;
            Assert.That(sharedAccessKeyBefore, Is.Not.Null);
            TopicRegenerateKeyContent topicRegenerateKeyContent = new TopicRegenerateKeyContent("key1");
            // Regenerate namespace topic keys
            var sharedAccessKeyAfter = (await getUpdatedNamespaceTopic.RegenerateKeyAsync(WaitUntil.Completed, topicRegenerateKeyContent)).Value;
            Assert.That(sharedAccessKeyAfter, Is.Not.Null);
            // TODO: Uncomment when the bug is fixed in the service
            // Assert.AreNotEqual(sharedAccessKeyBefore.Key1, sharedAccessKeyAfter.Key1);
            Assert.That(sharedAccessKeyAfter.Key2, Is.EqualTo(sharedAccessKeyBefore.Key2));

            //list namespace topics
            var getAllNamespaceTopics = await namespaceTopicsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(getAllNamespaceTopics, Is.Not.Null);
            Assert.That(getAllNamespaceTopics.Count, Is.EqualTo(3));

            // delete namespace
            await getUpdatedNamespaceTopic.DeleteAsync(WaitUntil.Completed);

            //verify deletion
            var getAllNamespaceTopicsUpdated = await namespaceTopicsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(getAllNamespaceTopicsUpdated, Is.Not.Null);
            Assert.That(getAllNamespaceTopicsUpdated.Count, Is.EqualTo(2));

            // delete all namespace topics
            await namespaceTopicsResponse2.DeleteAsync(WaitUntil.Completed);
            await namespaceTopicsResponse3.DeleteAsync(WaitUntil.Completed);
            var getAllNamespaceTopicsDeleted = await namespaceTopicsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(getAllNamespaceTopicsDeleted, Is.Not.Null);
            Assert.That(getAllNamespaceTopicsDeleted.Count, Is.EqualTo(0));

            // delete namespace
            await createNamespaceResponse.DeleteAsync(WaitUntil.Completed);
            await ResourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task NamespaceTopicsSubscriptionCreateUpdateDelete()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                Assert.Ignore("Ignoring Test in Playback mode as the test exceeding global time limit of 10 seconds ");
            }
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
            AzureLocation location = new AzureLocation("eastus2", "eastus2");
            var nameSpace = new EventGridNamespaceData(location)
            {
                Tags = {
                    {"originalTag1", "originalValue1"},
                    {"originalTag2", "originalValue2"}
                },
                Sku = namespaceSku,
                IsZoneRedundant = true,
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned)
            };
            UserAssignedIdentity userAssignedIdentity = new UserAssignedIdentity();
            nameSpace.Identity.UserAssignedIdentities.Add(
                new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk_test_easteuap/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test_identity"),
                userAssignedIdentity);

            var createNamespaceResponse = (await NamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, nameSpace)).Value;
            Assert.That(createNamespaceResponse, Is.Not.Null);
            Assert.That(namespaceName, Is.EqualTo(createNamespaceResponse.Data.Name));

            // Create namespace topics
            var namespaceTopicsCollection = createNamespaceResponse.GetNamespaceTopics();
            Assert.That(namespaceTopicsCollection, Is.Not.Null);

            var namespaceTopic = new NamespaceTopicData()
            {
                EventRetentionInDays = 1
            };
            var namespaceTopicsResponse1 = (await namespaceTopicsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicName, namespaceTopic)).Value;
            Assert.That(namespaceTopicsResponse1, Is.Not.Null);
            Assert.That(NamespaceTopicProvisioningState.Succeeded, Is.EqualTo(namespaceTopicsResponse1.Data.ProvisioningState));
            Assert.That(namespaceTopicsResponse1.Data.EventRetentionInDays, Is.EqualTo(1));

            // Create subscriptions
            var subscriptionsCollection = namespaceTopicsResponse1.GetNamespaceTopicEventSubscriptions();
            DeliveryConfiguration deliveryConfiguration = new DeliveryConfiguration
            {
                DeliveryMode = DeliveryMode.Push,
                Push = new PushInfo
                {
                    Destination = new WebHookEventSubscriptionDestination
                    {
                        Endpoint = new Uri(LogicAppEndpointUrl),
                    }
                }
            };

            NamespaceTopicEventSubscriptionData subscriptionData = new NamespaceTopicEventSubscriptionData()
            {
                DeliveryConfiguration = deliveryConfiguration,
                EventDeliverySchema = DeliverySchema.CloudEventSchemaV10,
            };

            var createEventsubscription1 = (await subscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicSubscriptionName1, subscriptionData)).Value;
            Assert.That(createEventsubscription1, Is.Not.Null);
            Assert.That(SubscriptionProvisioningState.Succeeded, Is.EqualTo(createEventsubscription1.Data.ProvisioningState));

            var createEventsubscription2 = (await subscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicSubscriptionName2, subscriptionData)).Value;
            Assert.That(createEventsubscription2, Is.Not.Null);
            Assert.That(SubscriptionProvisioningState.Succeeded, Is.EqualTo(createEventsubscription2.Data.ProvisioningState));

            // Test getting full URL and delivery attributes
            var fullUrlResponse = (await createEventsubscription2.GetFullUriAsync()).Value;
            Assert.That(fullUrlResponse, Is.Not.Null);
            Assert.That(fullUrlResponse.EndpointUri, Is.Not.Null);

            var deliveryAttributesResponse = await createEventsubscription2.GetDeliveryAttributesAsync().ToEnumerableAsync();
            Assert.That(deliveryAttributesResponse, Is.Not.Null);

            var createEventsubscription3 = (await subscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicSubscriptionName3, subscriptionData)).Value;
            Assert.That(createEventsubscription3, Is.Not.Null);
            Assert.That(SubscriptionProvisioningState.Succeeded, Is.EqualTo(createEventsubscription3.Data.ProvisioningState));

            // TAG ADD/REMOVE TEST
            await createEventsubscription1.AddTagAsync("removeMe", "yes");
            await createEventsubscription1.RemoveTagAsync("removeMe");
            var updatedWithTags = (await createEventsubscription1.GetAsync()).Value;
            Assert.That(updatedWithTags.Data.Tags.ContainsKey("removeMe"), Is.False);

            // GET SUBSCRIPTION FROM TOPIC TEST
            var fetchedSubFromTopic = (await namespaceTopicsResponse1.GetNamespaceTopicEventSubscriptionAsync(createEventsubscription1.Data.Name)).Value;
            Assert.That(fetchedSubFromTopic, Is.Not.Null);
            Assert.That(fetchedSubFromTopic.Data.Name, Is.EqualTo(createEventsubscription1.Data.Name));

            // Validate get event subscription
            var getEventSubscription1 = (await subscriptionsCollection.GetAsync(namespaceTopicSubscriptionName1)).Value;
            Assert.That(getEventSubscription1, Is.Not.Null);
            Assert.That(namespaceTopicSubscriptionName1, Is.EqualTo(getEventSubscription1.Data.Name));
            Assert.That(DeliveryMode.Push.ToString(), Is.EqualTo(getEventSubscription1.Data.DeliveryConfiguration.DeliveryMode.ToString()));

            // Update event subscription
            DeliveryConfiguration deliveryConfiguration2 = new DeliveryConfiguration()
            {
                DeliveryMode = DeliveryMode.Push.ToString(),
                Push = new PushInfo()
                {
                    DeliveryWithResourceIdentity = new DeliveryWithResourceIdentity()
                    {
                        Identity = new EventSubscriptionIdentity
                        {
                            IdentityType = EventSubscriptionIdentityType.UserAssigned,
                            UserAssignedIdentity = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk_test_easteuap/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test_identity",
                        },
                        Destination = new EventHubEventSubscriptionDestination()
                        {
                            ResourceId = new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/sdk_test_easteuap/providers/Microsoft.EventHub/namespaces/testsdk-eh-namespace/eventhubs/eh1"),
                        },
                    }
                }
            };

            NamespaceTopicEventSubscriptionPatch subscriptionPatch = new NamespaceTopicEventSubscriptionPatch()
            {
                DeliveryConfiguration = deliveryConfiguration2
            };

            var updateEventSubscription1 = (await createEventsubscription1.UpdateAsync(WaitUntil.Completed, subscriptionPatch)).Value;
            Assert.That(updateEventSubscription1, Is.Not.Null);
            Assert.AreEqual(updateEventSubscription1.Data.ProvisioningState, SubscriptionProvisioningState.Succeeded);

            var getUpdatedEventSubscription1 = (await subscriptionsCollection.GetAsync(namespaceTopicSubscriptionName1)).Value;
            Assert.That(getUpdatedEventSubscription1, Is.Not.Null);
            Assert.AreEqual(getUpdatedEventSubscription1.Data.Name, namespaceTopicSubscriptionName1);
            Assert.AreEqual(getUpdatedEventSubscription1.Data.DeliveryConfiguration.DeliveryMode.ToString(), DeliveryMode.Push.ToString());

            // List all event subscriptions
            var listAllSubscriptionsBefore = await subscriptionsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listAllSubscriptionsBefore, Is.Not.Null);
            Assert.AreEqual(3, listAllSubscriptionsBefore.Count);

            // Delete event subscriptions
            await getUpdatedEventSubscription1.DeleteAsync(WaitUntil.Completed);
            var listAllSubscriptionsAfter = await subscriptionsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listAllSubscriptionsAfter, Is.Not.Null);
            Assert.AreEqual(2, listAllSubscriptionsAfter.Count);

            // Delete all resources
            await createEventsubscription2.DeleteAsync(WaitUntil.Completed);
            await createEventsubscription3.DeleteAsync(WaitUntil.Completed);
            var listAllSubscriptionsAfterAllDeleted = await subscriptionsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listAllSubscriptionsAfterAllDeleted, Is.Not.Null);
            Assert.AreEqual(0, listAllSubscriptionsAfterAllDeleted.Count);

            await namespaceTopicsResponse1.DeleteAsync(WaitUntil.Completed);
            await createNamespaceResponse.DeleteAsync(WaitUntil.Completed);
            await ResourceGroup.DeleteAsync(WaitUntil.Completed);
        }
    }
}
