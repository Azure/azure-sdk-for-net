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
            Assert.Multiple(() =>
            {
                Assert.That(createSystemTopicResponse, Is.Not.Null);
                Assert.That(EventGridResourceProvisioningState.Succeeded, Is.EqualTo(createSystemTopicResponse.Data.ProvisioningState));
            });
            var afterCreateSystemTopics = await SystemTopicCollection.GetAllAsync().ToEnumerableAsync();

            // List all system topics under resource group
            var systemTopicsUnderResourceGroup = await ResourceGroup.GetSystemTopics().GetAllAsync().ToEnumerableAsync();
            Assert.That(systemTopicsUnderResourceGroup.Count, Is.GreaterThan(0));

            // List all system topics under subscription
            var systemTopicsInAzureSubscription = await DefaultSubscription.GetSystemTopicsAsync().ToEnumerableAsync();
            Assert.That(systemTopicsInAzureSubscription, Is.Not.Null);
            Assert.That(systemTopicsInAzureSubscription.Count >= 0, Is.True);

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
            Assert.Multiple(() =>
            {
                Assert.That(createSystemTopicEventSubscriptionResponse1, Is.Not.Null);
                Assert.That(EventSubscriptionProvisioningState.Succeeded, Is.EqualTo(createSystemTopicEventSubscriptionResponse1.Data.ProvisioningState));
                Assert.That(createSystemTopicEventSubscriptionResponse2, Is.Not.Null);
            });
            Assert.That(EventSubscriptionProvisioningState.Succeeded, Is.EqualTo(createSystemTopicEventSubscriptionResponse2.Data.ProvisioningState));

            // Get created System topic
            var getSystemTopicSubscription1Response = (await SystemTopicEventSubscriptionsCollection.GetAsync(systemTopicEventSubscriptionName1)).Value;
            var getSystemTopicSubscription2Response = (await SystemTopicEventSubscriptionsCollection.GetAsync(systemTopicEventSubscriptionName2)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(getSystemTopicSubscription1Response.Data.Name, Is.EqualTo(systemTopicEventSubscriptionName1));
                Assert.That(getSystemTopicSubscription1Response.Data.Destination.EndpointType, Is.EqualTo(EndpointType.MonitorAlert));
                Assert.That(getSystemTopicSubscription2Response.Data.Name, Is.EqualTo(systemTopicEventSubscriptionName2));
                Assert.That(getSystemTopicSubscription2Response.Data.Destination.EndpointType, Is.EqualTo(EndpointType.MonitorAlert));
            });

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
            Assert.Multiple(() =>
            {
                Assert.That(updateSystemTopicSubscriptionResponse.Data.Filter.SubjectBeginsWith, Is.EqualTo("ExamplePrefix2"));
                Assert.That(updateSystemTopicSubscriptionResponse.Data.Filter.SubjectEndsWith, Is.EqualTo("ExampleSuffix2"));
                Assert.That(((MonitorAlertEventSubscriptionDestination)updateSystemTopicSubscriptionResponse.Data.Destination).Severity, Is.EqualTo(MonitorAlertSeverity.Sev4));
            });

            // List all event subscriptions under system topics
            var eventSubscriptionCollection = createSystemTopicResponse.GetSystemTopicEventSubscriptions();
            var listSystemTopicsResponse = await eventSubscriptionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listSystemTopicsResponse, Is.Not.Null);
            Assert.That(listSystemTopicsResponse, Has.Count.EqualTo(2), "Expected 2 event subscriptions, but found " + listSystemTopicsResponse.Count);

            // Delete System topics event subscription
            await getSystemTopicSubscription1Response.DeleteAsync(WaitUntil.Completed);
            await getSystemTopicSubscription2Response.DeleteAsync(WaitUntil.Completed);
            var listSystemTopicsResponseAfterDeletion = await eventSubscriptionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listSystemTopicsResponseAfterDeletion, Is.Not.Null);
            Assert.That(listSystemTopicsResponseAfterDeletion.Count, Is.EqualTo(0));

            // Delete the System Topic
            await createSystemTopicResponse.DeleteAsync(WaitUntil.Completed);
            var resultFalse = (await SystemTopicCollection.ExistsAsync(systemTopicName)).Value;
            Assert.That(resultFalse, Is.False);
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
            Assert.Multiple(() =>
            {
                Assert.That(createSystemTopicResponse, Is.Not.Null);
                Assert.That(EventGridResourceProvisioningState.Succeeded, Is.EqualTo(createSystemTopicResponse.Data.ProvisioningState));
            });

            // Update the system topic
            SystemTopicPatch systemTopicPatch = new SystemTopicPatch()
            {
                Tags = {
                    {"updatedTag1", "updatedValue1"},
                    {"updatedTag2", "updatedValue2"}
                }
            };
            var updateSystemTopicResponse = (await createSystemTopicResponse.UpdateAsync(WaitUntil.Completed, systemTopicPatch)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(updateSystemTopicResponse, Is.Not.Null);
                Assert.That(systemTopicName, Is.EqualTo(updateSystemTopicResponse.Data.Name));
            });

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
            Assert.Multiple(() =>
            {
                Assert.That(getSystemTopicSubscription1Response.Data.Name, Is.EqualTo(systemTopicEventSubscriptionName1));
                Assert.That(getSystemTopicSubscription1Response.Data.DeliveryWithResourceIdentity.Destination.EndpointType, Is.EqualTo(EndpointType.NamespaceTopic));
                Assert.That(getSystemTopicSubscription2Response.Data.Name, Is.EqualTo(systemTopicEventSubscriptionName2));
                Assert.That(getSystemTopicSubscription2Response.Data.DeliveryWithResourceIdentity.Destination.EndpointType, Is.EqualTo(EndpointType.NamespaceTopic));
            });

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
            Assert.Multiple(() =>
            {
                Assert.That(updateSystemTopicSubscriptionResponse.Data.Filter.SubjectBeginsWith, Is.EqualTo("ExamplePrefix2"));
                Assert.That(updateSystemTopicSubscriptionResponse.Data.Filter.SubjectEndsWith, Is.EqualTo("ExampleSuffix2"));
            });

            // List all event subscriptions under system topics
            var eventSubscriptionCollection = createSystemTopicResponse.GetSystemTopicEventSubscriptions();
            var listSystemTopicsResponse = await eventSubscriptionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listSystemTopicsResponse, Is.Not.Null);
            Assert.That(listSystemTopicsResponse, Has.Count.EqualTo(2));

            // Delete System topic event subscriptions
            await getSystemTopicSubscription1Response.DeleteAsync(WaitUntil.Completed);
            await getSystemTopicSubscription2Response.DeleteAsync(WaitUntil.Completed);
            var listSystemTopicsResponseAfterDeletion = await eventSubscriptionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listSystemTopicsResponseAfterDeletion, Is.Not.Null);
            Assert.That(listSystemTopicsResponseAfterDeletion.Count, Is.EqualTo(0));
            // Delete the System Topic
            await createSystemTopicResponse.DeleteAsync(WaitUntil.Completed);
            var resultFalse = (await SystemTopicCollection.ExistsAsync(systemTopicName)).Value;
            Assert.That(resultFalse, Is.False);
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
            Assert.That(systemTopicResource, Is.Not.Null);

            // Get system topic from collection
            var getFromCollectionResponse = await SystemTopicCollection.GetAsync(systemTopicName);
            Assert.That(getFromCollectionResponse, Is.Not.Null);
            Assert.That(getFromCollectionResponse.Value.Data.Name, Is.EqualTo(systemTopicName));

            // Get system topic from resource
            var getFromResourceResponse = await systemTopicResource.GetAsync();
            Assert.That(getFromResourceResponse, Is.Not.Null);
            Assert.That(getFromResourceResponse.Value.Data.Name, Is.EqualTo(systemTopicName));

            // Add a tag
            var addTagResponse = await systemTopicResource.AddTagAsync("testTag", "testValue");
            Assert.That(addTagResponse, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(addTagResponse.Value.Data.Tags.ContainsKey("testTag"), Is.True);
                Assert.That(addTagResponse.Value.Data.Tags["testTag"], Is.EqualTo("testValue"));
            });

            // Set tags
            var tagsToSet = new Dictionary<string, string>
            {
                { "tagA", "valueA" },
                { "tagB", "valueB" }
            };
            var setTagsResponse = await systemTopicResource.SetTagsAsync(tagsToSet);
            Assert.That(setTagsResponse, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(setTagsResponse.Value.Data.Tags.ContainsKey("tagA"), Is.True);
                Assert.That(setTagsResponse.Value.Data.Tags["tagA"], Is.EqualTo("valueA"));
                Assert.That(setTagsResponse.Value.Data.Tags.ContainsKey("tagB"), Is.True);
                Assert.That(setTagsResponse.Value.Data.Tags["tagB"], Is.EqualTo("valueB"));
            });

            // Remove a tag
            var removeTagResponse = await systemTopicResource.RemoveTagAsync("tagA");
            Assert.That(removeTagResponse, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(removeTagResponse.Value.Data.Tags.ContainsKey("tagA"), Is.False);
                Assert.That(removeTagResponse.Value.Data.Tags.ContainsKey("tagB"), Is.True);
            });

            // ExtensionTopicResourceGetAsync
            var resourceId = SystemTopicResource.CreateResourceIdentifier(
                SystemTopicCollection.Id.SubscriptionId,
                ResourceGroup.Data.Name,
                systemTopicName);

            var systemTopicFromId = Client.GetSystemTopicResource(resourceId);
            var response = await systemTopicFromId.GetAsync();

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Data.Name, Is.EqualTo(systemTopicName));

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
            Assert.That(systemTopicResource, Is.Not.Null);

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
            Assert.That(eventSubscriptionResource, Is.Not.Null);

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
            Assert.That(deliveryAttributesList, Is.Not.Null);

            // Get full URI
            var fullUriResponse = await eventSubscriptionResource.GetFullUriAsync();
            Assert.That(fullUriResponse, Is.Not.Null);
            Assert.That(fullUriResponse.Value, Is.Not.Null);

            // Get event subscription resource from system topic
            var getEventSubscriptionResponse = await systemTopicResource.GetSystemTopicEventSubscriptionAsync(eventSubscriptionName);
            Assert.That(getEventSubscriptionResponse, Is.Not.Null);
            Assert.That(getEventSubscriptionResponse.Value.Data.Name, Is.EqualTo(eventSubscriptionName));

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
