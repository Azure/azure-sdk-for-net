// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests
{
    public class SystemTopicTests : EventGridManagementTestBase
    {
        public SystemTopicTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private SystemTopicCollection SystemTopicCollection { get; set; }
        private ResourceGroupResource ResourceGroup { get; set; }
        private EventGridNamespaceCollection NamespaceCollection { get; set; }

        // For live tests, replace "SANITIZED_FUNCTION_KEY" with the actual function key
        // from the Azure Portal for the Logic App "sdk-test-logic-app" -> workflow
        private const string LogicAppEndpointUrl = "https://prod-16.centraluseuap.logic.azure.com:443/workflows/9ace43ec97744a61acea5db9feaae8af/triggers/When_a_HTTP_request_is_received/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2FWhen_a_HTTP_request_is_received%2Frun&sv=SANITIZED_FUNCTION_KEY&sig=SANITIZED_FUNCTION_KEY";

        private async Task SetCollection()
        {
            // This test relies on the existence of the 'sdk-eventgrid-test-rg' resource group within the subscription, ensuring that system topics and related resources (such as Key Vault) are deployed within the same resource group for validation
            // Subscription: 5b4b650e-28b9-4790-b3ab-ddbd88d727c4 (Azure Event Grid SDK Subscription)
            ResourceGroup = await GetResourceGroupAsync(DefaultSubscription, "sdk-eventgrid-test-rg");
            SystemTopicCollection = ResourceGroup.GetSystemTopics();
            NamespaceCollection = ResourceGroup.GetEventGridNamespaces();
        }

        [Test]
        public async Task SystemTopicWithMonitorDestinationCreateGetUpdateDelete()
        {
            await SetCollection();
            string systemTopicName = Recording.GenerateAssetName("sdk-eventgrid-SystemTopic-");
            string systemTopicEventSubscriptionName1 = Recording.GenerateAssetName("sdk-eventgrid-EventSubscription-");
            string systemTopicEventSubscriptionName2 = Recording.GenerateAssetName("sdk-eventgrid-EventSubscription-");
            string sourceResourceIdentifier = String.Format("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/sdk-eventgrid-test-rg/providers/Microsoft.KeyVault/vaults/sdkeventgridtestkeyvault");
            SystemTopicData data = new SystemTopicData(new AzureLocation("centraluseuap"))
            {
                Source = new ResourceIdentifier(sourceResourceIdentifier),
                TopicType = "Microsoft.KeyVault.Vaults",
                Tags =
                     {
                         ["tag1"] = "value1",
                         ["tag2"] = "value2",
                     },
            };

            var beforeCreateSystemTopics = await SystemTopicCollection.GetAllAsync().ToEnumerableAsync();
            var createSystemTopicResponse = (await SystemTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicName, data)).Value;
            Assert.NotNull(createSystemTopicResponse);
            Assert.AreEqual(createSystemTopicResponse.Data.ProvisioningState, EventGridResourceProvisioningState.Succeeded);
            var afterCreateSystemTopics = await SystemTopicCollection.GetAllAsync().ToEnumerableAsync();

            // List all system topics under resource group
            var systemTopicsUnderResourceGroup = await ResourceGroup.GetSystemTopics().GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(systemTopicsUnderResourceGroup.Count > 0);

            // List all system topics under subscription
            var systemTopicsInAzureSubscription = await DefaultSubscription.GetSystemTopicsAsync().ToEnumerableAsync();
            Assert.NotNull(systemTopicsInAzureSubscription);
            Assert.IsTrue(systemTopicsInAzureSubscription.Count >= 0);

            var SystemTopicEventSubscriptionsCollection = createSystemTopicResponse.GetSystemTopicEventSubscriptions();

            EventGridSubscriptionData eventSubscriptionData = new EventGridSubscriptionData()
            {
                Destination = new MonitorAlertEventSubscriptionDestination
                {
                    EndpointType = EndpointType.MonitorAlert,
                    Severity = MonitorAlertSeverity.Sev3,
                },
                Filter = new EventSubscriptionFilter()
                {
                    SubjectBeginsWith = "ExamplePrefix",
                    SubjectEndsWith = "ExampleSuffix",
                    IsSubjectCaseSensitive = false,
                },
                EventDeliverySchema = EventDeliverySchema.CloudEventSchemaV1_0
            };
            var createSystemTopicEventSubscriptionResponse1 = (await SystemTopicEventSubscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicEventSubscriptionName1, eventSubscriptionData)).Value;
            var createSystemTopicEventSubscriptionResponse2 = (await SystemTopicEventSubscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicEventSubscriptionName2, eventSubscriptionData)).Value;
            Assert.NotNull(createSystemTopicEventSubscriptionResponse1);
            Assert.AreEqual(createSystemTopicEventSubscriptionResponse1.Data.ProvisioningState, EventSubscriptionProvisioningState.Succeeded);
            Assert.NotNull(createSystemTopicEventSubscriptionResponse2);
            Assert.AreEqual(createSystemTopicEventSubscriptionResponse2.Data.ProvisioningState, EventSubscriptionProvisioningState.Succeeded);

            // Get created System topic
            var getSystemTopicSubscription1Response = (await SystemTopicEventSubscriptionsCollection.GetAsync(systemTopicEventSubscriptionName1)).Value;
            var getSystemTopicSubscription2Response = (await SystemTopicEventSubscriptionsCollection.GetAsync(systemTopicEventSubscriptionName2)).Value;
            Assert.AreEqual(systemTopicEventSubscriptionName1, getSystemTopicSubscription1Response.Data.Name);
            Assert.AreEqual(EndpointType.MonitorAlert, getSystemTopicSubscription1Response.Data.Destination.EndpointType);
            Assert.AreEqual(systemTopicEventSubscriptionName2, getSystemTopicSubscription2Response.Data.Name);
            Assert.AreEqual(EndpointType.MonitorAlert, getSystemTopicSubscription2Response.Data.Destination.EndpointType);

            // Update System topic
            EventGridSubscriptionPatch patch = new EventGridSubscriptionPatch()
            {
                Destination = new MonitorAlertEventSubscriptionDestination
                {
                    EndpointType = EndpointType.MonitorAlert,
                    Severity = MonitorAlertSeverity.Sev4,
                },
                Filter = new EventSubscriptionFilter()
                {
                    SubjectBeginsWith = "ExamplePrefix2",
                    SubjectEndsWith = "ExampleSuffix2",
                    IsSubjectCaseSensitive = false,
                },
                EventDeliverySchema = EventDeliverySchema.CloudEventSchemaV1_0
            };
            var updateSystemTopicSubscriptionResponse = (await getSystemTopicSubscription1Response.UpdateAsync(WaitUntil.Completed, patch)).Value;
            Assert.AreEqual("ExamplePrefix2", updateSystemTopicSubscriptionResponse.Data.Filter.SubjectBeginsWith);
            Assert.AreEqual("ExampleSuffix2", updateSystemTopicSubscriptionResponse.Data.Filter.SubjectEndsWith);
            Assert.AreEqual(MonitorAlertSeverity.Sev4, ((MonitorAlertEventSubscriptionDestination)updateSystemTopicSubscriptionResponse.Data.Destination).Severity);

            // List all event subscriptions under system topics
            var eventSubscriptionCollection = createSystemTopicResponse.GetSystemTopicEventSubscriptions();
            var listSystemTopicsResponse = await eventSubscriptionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(listSystemTopicsResponse);
            Assert.AreEqual(2, listSystemTopicsResponse.Count, "Expected 2 event subscriptions, but found " + listSystemTopicsResponse.Count);

            // Delete System topics event subscription
            await getSystemTopicSubscription1Response.DeleteAsync(WaitUntil.Completed);
            await getSystemTopicSubscription2Response.DeleteAsync(WaitUntil.Completed);
            var listSystemTopicsResponseAfterDeletion = await eventSubscriptionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(listSystemTopicsResponseAfterDeletion);
            Assert.AreEqual(listSystemTopicsResponseAfterDeletion.Count, 0);

            // Delete the System Topic
            await createSystemTopicResponse.DeleteAsync(WaitUntil.Completed);
            var resultFalse = (await SystemTopicCollection.ExistsAsync(systemTopicName)).Value;
            Assert.IsFalse(resultFalse);
        }

        [Test]
        public async Task SystemTopicWithNamespaceTopicDestinationCreateGetUpdateDelete()
        {
            await SetCollection();
            await foreach (var existingTopic in SystemTopicCollection.GetAllAsync())
            {
                if (existingTopic.Data.Source.ToString().Equals(
                    "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/sdk-eventgrid-test-rg/providers/Microsoft.Storage/storageAccounts/sdkegteststorageaccount",
                    StringComparison.OrdinalIgnoreCase))
                {
                    await existingTopic.DeleteAsync(WaitUntil.Completed);
                }
            }

            // Create system topic and create subscription to namespace topic for that system topic
            string systemTopicName = Recording.GenerateAssetName("sdk-SystemTopic-");
            string systemTopicEventSubscriptionName1 = Recording.GenerateAssetName("sdk-EventSubscription-");
            string systemTopicEventSubscriptionName2 = Recording.GenerateAssetName("sdk-EventSubscription-");
            UserAssignedIdentity userAssignedIdentity = new UserAssignedIdentity();
            string sourceResourceIdentifier = String.Format("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/sdk-eventgrid-test-rg/providers/Microsoft.Storage/storageAccounts/sdkegteststorageaccount");
            SystemTopicData data = new SystemTopicData(new AzureLocation("centraluseuap"))
            {
                Source = new ResourceIdentifier(sourceResourceIdentifier),
                TopicType = "microsoft.storage.storageaccounts",
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned),
                Tags =
                     {
                         ["tag1"] = "value1",
                         ["tag2"] = "value2",
                     },
            };
            data.Identity.UserAssignedIdentities.Add(new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk-eventgrid-test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sdk-eventgrid-test-userAssignedManagedIdentity"), userAssignedIdentity);
            var createSystemTopicResponse = (await SystemTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicName, data)).Value;
            Assert.NotNull(createSystemTopicResponse);
            Assert.AreEqual(createSystemTopicResponse.Data.ProvisioningState, EventGridResourceProvisioningState.Succeeded);

            // Update the system topic
            SystemTopicPatch systemTopicPatch = new SystemTopicPatch()
            {
                Tags = {
                    {"updatedTag1", "updatedValue1"},
                    {"updatedTag2", "updatedValue2"}
                }
            };
            var updateSystemTopicResponse = (await createSystemTopicResponse.UpdateAsync(WaitUntil.Completed, systemTopicPatch)).Value;
            Assert.NotNull(updateSystemTopicResponse);
            Assert.AreEqual(updateSystemTopicResponse.Data.Name, systemTopicName);

            var SystemTopicEventSubscriptionsCollection = createSystemTopicResponse.GetSystemTopicEventSubscriptions();

            var namespaceTopicDestination = new DeliveryWithResourceIdentity()
            {
                Identity = new EventSubscriptionIdentity()
                {
                    IdentityType = EventSubscriptionIdentityType.UserAssigned,
                    UserAssignedIdentity = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk-eventgrid-test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sdk-eventgrid-test-userAssignedManagedIdentity",
                },
                Destination = new NamespaceTopicEventSubscriptionDestination()
                {
                    ResourceId = new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/sdk-eventgrid-test-rg/providers/Microsoft.EventGrid/namespaces/sdk-eventgrid-test-eventgridNamespace/topics/sdk-eventgrid-test-eventGridTopic"),
                }
            };

            EventGridSubscriptionData eventSubscriptionData = new EventGridSubscriptionData()
            {
                Filter = new EventSubscriptionFilter()
                {
                    SubjectBeginsWith = "ExamplePrefix",
                    SubjectEndsWith = "ExampleSuffix",
                    IsSubjectCaseSensitive = false,
                },
                DeliveryWithResourceIdentity = namespaceTopicDestination,
                EventDeliverySchema = EventDeliverySchema.CloudEventSchemaV1_0
            };
            var createSystemTopicEventSubscriptionResponse1 = (await SystemTopicEventSubscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicEventSubscriptionName1, eventSubscriptionData)).Value;
            var createSystemTopicEventSubscriptionResponse2 = (await SystemTopicEventSubscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicEventSubscriptionName2, eventSubscriptionData)).Value;

            // Get created System topic
            var getSystemTopicSubscription1Response = (await SystemTopicEventSubscriptionsCollection.GetAsync(systemTopicEventSubscriptionName1)).Value;
            var getSystemTopicSubscription2Response = (await SystemTopicEventSubscriptionsCollection.GetAsync(systemTopicEventSubscriptionName2)).Value;
            Assert.AreEqual(systemTopicEventSubscriptionName1, getSystemTopicSubscription1Response.Data.Name);
            Assert.AreEqual(EndpointType.NamespaceTopic, getSystemTopicSubscription1Response.Data.DeliveryWithResourceIdentity.Destination.EndpointType);
            Assert.AreEqual(systemTopicEventSubscriptionName2, getSystemTopicSubscription2Response.Data.Name);
            Assert.AreEqual(EndpointType.NamespaceTopic, getSystemTopicSubscription2Response.Data.DeliveryWithResourceIdentity.Destination.EndpointType);

            // Update System topic event subscription
            EventGridSubscriptionPatch patch = new EventGridSubscriptionPatch()
            {
                DeliveryWithResourceIdentity = namespaceTopicDestination,
                Filter = new EventSubscriptionFilter()
                {
                    SubjectBeginsWith = "ExamplePrefix2",
                    SubjectEndsWith = "ExampleSuffix2",
                    IsSubjectCaseSensitive = false,
                },
                EventDeliverySchema = EventDeliverySchema.CloudEventSchemaV1_0
            };
            var updateSystemTopicSubscriptionResponse = (await getSystemTopicSubscription1Response.UpdateAsync(WaitUntil.Completed, patch)).Value;
            Assert.AreEqual("ExamplePrefix2", updateSystemTopicSubscriptionResponse.Data.Filter.SubjectBeginsWith);
            Assert.AreEqual("ExampleSuffix2", updateSystemTopicSubscriptionResponse.Data.Filter.SubjectEndsWith);

            // List all event subscriptions under system topics
            var eventSubscriptionCollection = createSystemTopicResponse.GetSystemTopicEventSubscriptions();
            var listSystemTopicsResponse = await eventSubscriptionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(listSystemTopicsResponse);
            Assert.AreEqual(listSystemTopicsResponse.Count, 2);

            // Delete System topic event subscriptions
            await getSystemTopicSubscription1Response.DeleteAsync(WaitUntil.Completed);
            await getSystemTopicSubscription2Response.DeleteAsync(WaitUntil.Completed);
            var listSystemTopicsResponseAfterDeletion = await eventSubscriptionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(listSystemTopicsResponseAfterDeletion);
            Assert.AreEqual(listSystemTopicsResponseAfterDeletion.Count, 0);
            // Delete the System Topic
            await createSystemTopicResponse.DeleteAsync(WaitUntil.Completed);
            var resultFalse = (await SystemTopicCollection.ExistsAsync(systemTopicName)).Value;
            Assert.IsFalse(resultFalse);
        }

        [Test]
        public async Task SystemTopicLifecycleCreateGetUpdateDeleteTags()
        {
            await SetCollection();
            string systemTopicName = Recording.GenerateAssetName("sdk-SystemTopic-Lifecycle-");
            string sourceResourceIdentifier = $"/subscriptions/{SystemTopicCollection.Id.SubscriptionId}/resourceGroups/sdk-eventgrid-test-rg/providers/Microsoft.KeyVault/vaults/sdkeventgridtestkeyvault";

            // Create system topic
            var systemTopicData = new SystemTopicData(new AzureLocation("centraluseuap"))
            {
                Source = new ResourceIdentifier(sourceResourceIdentifier),
                TopicType = "Microsoft.KeyVault.Vaults"
            };
            var existingTopics = await SystemTopicCollection.GetAllAsync().ToEnumerableAsync();
            var existing = existingTopics.FirstOrDefault(t =>
                t.Data.Source.ToString().Equals(sourceResourceIdentifier, StringComparison.OrdinalIgnoreCase));

            SystemTopicResource systemTopicResource;
            if (existing != null)
            {
                systemTopicResource = existing;
                systemTopicName = systemTopicResource.Data.Name;
            }
            else
            {
                systemTopicResource = (await SystemTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicName, systemTopicData)).Value;
            }
            Assert.NotNull(systemTopicResource);

            // Get system topic from collection
            var getFromCollectionResponse = await SystemTopicCollection.GetAsync(systemTopicName);
            Assert.NotNull(getFromCollectionResponse);
            Assert.AreEqual(systemTopicName, getFromCollectionResponse.Value.Data.Name);

            // Get system topic from resource
            var getFromResourceResponse = await systemTopicResource.GetAsync();
            Assert.NotNull(getFromResourceResponse);
            Assert.AreEqual(systemTopicName, getFromResourceResponse.Value.Data.Name);

            // Add a tag
            var addTagResponse = await systemTopicResource.AddTagAsync("testTag", "testValue");
            Assert.NotNull(addTagResponse);
            Assert.IsTrue(addTagResponse.Value.Data.Tags.ContainsKey("testTag"));
            Assert.AreEqual("testValue", addTagResponse.Value.Data.Tags["testTag"]);

            // Set tags
            var tagsToSet = new Dictionary<string, string>
            {
                { "tagA", "valueA" },
                { "tagB", "valueB" }
            };
            var setTagsResponse = await systemTopicResource.SetTagsAsync(tagsToSet);
            Assert.NotNull(setTagsResponse);
            Assert.IsTrue(setTagsResponse.Value.Data.Tags.ContainsKey("tagA"));
            Assert.AreEqual("valueA", setTagsResponse.Value.Data.Tags["tagA"]);
            Assert.IsTrue(setTagsResponse.Value.Data.Tags.ContainsKey("tagB"));
            Assert.AreEqual("valueB", setTagsResponse.Value.Data.Tags["tagB"]);

            // Remove a tag
            var removeTagResponse = await systemTopicResource.RemoveTagAsync("tagA");
            Assert.NotNull(removeTagResponse);
            Assert.IsFalse(removeTagResponse.Value.Data.Tags.ContainsKey("tagA"));
            Assert.IsTrue(removeTagResponse.Value.Data.Tags.ContainsKey("tagB"));

            // ExtensionTopicResourceGetAsync
            var resourceId = SystemTopicResource.CreateResourceIdentifier(
                SystemTopicCollection.Id.SubscriptionId,
                ResourceGroup.Data.Name,
                systemTopicName);

            var systemTopicFromId = Client.GetSystemTopicResource(resourceId);
            var response = await systemTopicFromId.GetAsync();

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            Assert.AreEqual(systemTopicName, response.Value.Data.Name);

            // Cleanup
            await systemTopicResource.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task SystemTopicEventSubscriptionLifecycleGetAttributesUriAndResource()
        {
            await SetCollection();
            string systemTopicName = Recording.GenerateAssetName("sdk-SystemTopic-EventSubLifecycle-");
            string eventSubscriptionName = Recording.GenerateAssetName("sdk-EventSubscription-EventSubLifecycle-");

            string sourceResourceIdentifier = $"/subscriptions/{SystemTopicCollection.Id.SubscriptionId}/resourceGroups/{ResourceGroup.Data.Name}/providers/Microsoft.KeyVault/vaults/sdkeventgridtestkeyvault";

            var systemTopicData = new SystemTopicData(new AzureLocation("centraluseuap"))
            {
                Source = new ResourceIdentifier(sourceResourceIdentifier),
                TopicType = "Microsoft.KeyVault.Vaults"
            };

            var existingTopics = await SystemTopicCollection.GetAllAsync().ToEnumerableAsync();
            var existing = existingTopics.FirstOrDefault(t =>
                t.Data.Source.ToString().Equals(sourceResourceIdentifier, StringComparison.OrdinalIgnoreCase));

            SystemTopicResource systemTopicResource;
            if (existing != null)
            {
                systemTopicResource = existing;
                systemTopicName = systemTopicResource.Data.Name;
            }
            else
            {
                systemTopicResource = (await SystemTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicName, systemTopicData)).Value;
            }
            Assert.NotNull(systemTopicResource);

            var eventSubscriptions = systemTopicResource.GetSystemTopicEventSubscriptions();

            var eventSubscriptionData = new EventGridSubscriptionData()
            {
                Destination = new WebHookEventSubscriptionDestination
                {
                    Endpoint = new Uri(LogicAppEndpointUrl)
                },
                Filter = new EventSubscriptionFilter()
                {
                    SubjectBeginsWith = "Prefix",
                    SubjectEndsWith = "Suffix",
                    IsSubjectCaseSensitive = false,
                },
                EventDeliverySchema = EventDeliverySchema.CloudEventSchemaV1_0
            };

            var eventSubscriptionResource = (await eventSubscriptions.CreateOrUpdateAsync(WaitUntil.Completed, eventSubscriptionName, eventSubscriptionData)).Value;
            Assert.NotNull(eventSubscriptionResource);

            // Get delivery attributes
            IReadOnlyList<DeliveryAttributeMapping> deliveryAttributesList = null;
            try
            {
                deliveryAttributesList = await eventSubscriptionResource.GetDeliveryAttributesAsync().ToEnumerableAsync();
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("type 'Null'"))
            {
                deliveryAttributesList = Array.Empty<DeliveryAttributeMapping>();
            }
            Assert.NotNull(deliveryAttributesList);

            // Get full URI
            var fullUriResponse = await eventSubscriptionResource.GetFullUriAsync();
            Assert.NotNull(fullUriResponse);
            Assert.NotNull(fullUriResponse.Value);

            // Get event subscription resource from system topic
            var getEventSubscriptionResponse = await systemTopicResource.GetSystemTopicEventSubscriptionAsync(eventSubscriptionName);
            Assert.NotNull(getEventSubscriptionResponse);
            Assert.AreEqual(eventSubscriptionName, getEventSubscriptionResponse.Value.Data.Name);

            // Cleanup
            await eventSubscriptionResource.DeleteAsync(WaitUntil.Completed);
            if (existing == null)
            {
                await systemTopicResource.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        public async Task ExtensionTopicGetAsyncThrowsRequestFailedException()
        {
            await SetCollection();

            // Arrange
            string nonExistentSystemTopicName = "nonexistent-system-topic";
            string subscriptionId = SystemTopicCollection.Id.SubscriptionId;
            string resourceGroupName = ResourceGroup.Data.Name;

            var resourceId = SystemTopicResource.CreateResourceIdentifier(
                subscriptionId, resourceGroupName, nonExistentSystemTopicName);

            var systemTopicResource = Client.GetSystemTopicResource(resourceId);

            // Act & Assert
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await systemTopicResource.GetAsync();
            });
        }
    }
}
