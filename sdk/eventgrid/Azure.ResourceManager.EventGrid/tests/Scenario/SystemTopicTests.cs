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
        // from the Azure Portal for "sdk-test-logic-app" -> workflowUrl.
        private const string LogicAppEndpointUrl = "https://prod-16.centraluseuap.logic.azure.com:443/workflows/9ace43ec97744a61acea5db9feaae8af/triggers/When_a_HTTP_request_is_received/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2FWhen_a_HTTP_request_is_received%2Frun&sv=SANITIZED_FUNCTION_KEY&sig=SANITIZED_FUNCTION_KEY";

        private async Task SetCollection()
        {
            const string subscriptionId = "5b4b650e-28b9-4790-b3ab-ddbd88d727c4";
            const string resourceGroupName = "sdk-eventgrid-test-rg";

            ArmClient armClient = GetArmClient();

            var rgId = new ResourceIdentifier($"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}");
            ResourceGroup = await armClient.GetResourceGroupResource(rgId).GetAsync();

            SystemTopicCollection = ResourceGroup.GetSystemTopics();
            NamespaceCollection = ResourceGroup.GetEventGridNamespaces();
        }

        [Test]
        public async Task SystemTopicWithMonitorDestinationCreateGetUpdateDelete()
        {
            await SetCollection();
            string systemTopicName = Recording.GenerateAssetName("sdk-SystemTopic-");
            string systemTopicEventSubscriptionName1 = Recording.GenerateAssetName("sdk-EventSubscription-");
            string systemTopicEventSubscriptionName2 = Recording.GenerateAssetName("sdk-EventSubscription-");

            string sourceResourceIdentifier = $"/subscriptions/{SystemTopicCollection.Id.SubscriptionId}/resourceGroups/sdk-eventgrid-test-rg/providers/Microsoft.KeyVault/vaults/sdkeventgridtestkeyvault";

            var systemTopicData = new SystemTopicData(new AzureLocation("centraluseuap"))
            {
                Source = new ResourceIdentifier(sourceResourceIdentifier),
                TopicType = "Microsoft.KeyVault.Vaults",
                Tags = {
                    ["tag1"] = "value1",
                    ["tag2"] = "value2",
                },
            };

            var existingTopics = await SystemTopicCollection.GetAllAsync().ToEnumerableAsync();
            var existing = existingTopics.FirstOrDefault(t => t.Data.Source.ToString().Equals(sourceResourceIdentifier, StringComparison.OrdinalIgnoreCase));

            SystemTopicResource systemTopic;
            if (existing != null)
            {
                systemTopic = existing;
            }
            else
            {
                systemTopic = (await SystemTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicName, systemTopicData)).Value;
                Assert.NotNull(systemTopic);
                Assert.AreEqual(systemTopic.Data.ProvisioningState, EventGridResourceProvisioningState.Succeeded);
            }

            var eventSubscriptions = systemTopic.GetSystemTopicEventSubscriptions();

            var eventSubscriptionData = new EventGridSubscriptionData()
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

            var sub1 = (await eventSubscriptions.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicEventSubscriptionName1, eventSubscriptionData)).Value;
            var sub2 = (await eventSubscriptions.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicEventSubscriptionName2, eventSubscriptionData)).Value;

            Assert.NotNull(sub1);
            Assert.NotNull(sub2);
            Assert.AreEqual(EndpointType.MonitorAlert, sub1.Data.Destination.EndpointType);
            Assert.AreEqual(EndpointType.MonitorAlert, sub2.Data.Destination.EndpointType);

            var patch = new EventGridSubscriptionPatch()
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

            var updatedSub = (await sub1.UpdateAsync(WaitUntil.Completed, patch)).Value;
            Assert.AreEqual("ExamplePrefix2", updatedSub.Data.Filter.SubjectBeginsWith);
            Assert.AreEqual("ExampleSuffix2", updatedSub.Data.Filter.SubjectEndsWith);
            Assert.AreEqual(MonitorAlertSeverity.Sev4, ((MonitorAlertEventSubscriptionDestination)updatedSub.Data.Destination).Severity);

            var allSubs = await eventSubscriptions.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(allSubs.Count, 2);

            await sub1.DeleteAsync(WaitUntil.Completed);
            await sub2.DeleteAsync(WaitUntil.Completed);

            if (existing == null)
            {
                await systemTopic.DeleteAsync(WaitUntil.Completed);
                var exists = (await SystemTopicCollection.ExistsAsync(systemTopicName)).Value;
                Assert.IsFalse(exists);
            }
        }

        [Test]
        public async Task SystemTopicWithNamespaceTopicDestinationCreateGetUpdateDelete()
        {
            await SetCollection();

            string systemTopicName = Recording.GenerateAssetName("sdk-SystemTopic-");
            string systemTopicEventSubscriptionName1 = Recording.GenerateAssetName("sdk-EventSubscription-");
            string systemTopicEventSubscriptionName2 = Recording.GenerateAssetName("sdk-EventSubscription-");

            string sourceResourceIdentifier = $"/subscriptions/{SystemTopicCollection.Id.SubscriptionId}/resourceGroups/sdk-eventgrid-test-rg/providers/Microsoft.Storage/storageAccounts/sdkegteststorageaccount";

            var existingTopics = await SystemTopicCollection.GetAllAsync().ToEnumerableAsync();
            var existing = existingTopics.FirstOrDefault(t =>
                t.Data.Source.ToString().Equals(sourceResourceIdentifier, StringComparison.OrdinalIgnoreCase));

            SystemTopicResource systemTopic;
            if (existing != null)
            {
                systemTopic = existing;
                systemTopicName = systemTopic.Data.Name;
            }
            else
            {
                var userAssignedIdentity = new UserAssignedIdentity();
                var data = new SystemTopicData(new AzureLocation("centraluseuap"))
                {
                    Source = new ResourceIdentifier(sourceResourceIdentifier),
                    TopicType = "microsoft.storage.storageaccounts",
                    Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned),
                    Tags = {
                        ["tag1"] = "value1",
                        ["tag2"] = "value2",
                    },
                };
                data.Identity.UserAssignedIdentities.Add(
                    new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk-eventgrid-test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sdk-eventgrid-test-userAssignedManagedIdentity"),
                    userAssignedIdentity);

                systemTopic = (await SystemTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicName, data)).Value;
                Assert.NotNull(systemTopic);
                Assert.AreEqual(systemTopic.Data.ProvisioningState, EventGridResourceProvisioningState.Succeeded);
            }

            // Update tags
            var systemTopicPatch = new SystemTopicPatch()
            {
                Tags = {
                    {"updatedTag1", "updatedValue1"},
                    {"updatedTag2", "updatedValue2"}
                }
            };
            var updateSystemTopicResponse = (await systemTopic.UpdateAsync(WaitUntil.Completed, systemTopicPatch)).Value;
            Assert.NotNull(updateSystemTopicResponse);
            Assert.AreEqual(updateSystemTopicResponse.Data.Name, systemTopicName);

            var eventSubscriptions = systemTopic.GetSystemTopicEventSubscriptions();

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

            var eventSubscriptionData = new EventGridSubscriptionData()
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

            var sub1 = (await eventSubscriptions.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicEventSubscriptionName1, eventSubscriptionData)).Value;
            var sub2 = (await eventSubscriptions.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicEventSubscriptionName2, eventSubscriptionData)).Value;

            Assert.AreEqual(systemTopicEventSubscriptionName1, sub1.Data.Name);
            Assert.AreEqual(EndpointType.NamespaceTopic, sub1.Data.DeliveryWithResourceIdentity.Destination.EndpointType);
            Assert.AreEqual(systemTopicEventSubscriptionName2, sub2.Data.Name);
            Assert.AreEqual(EndpointType.NamespaceTopic, sub2.Data.DeliveryWithResourceIdentity.Destination.EndpointType);

            // Update one subscription
            var patch = new EventGridSubscriptionPatch()
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
            var updatedSub = (await sub1.UpdateAsync(WaitUntil.Completed, patch)).Value;
            Assert.AreEqual("ExamplePrefix2", updatedSub.Data.Filter.SubjectBeginsWith);
            Assert.AreEqual("ExampleSuffix2", updatedSub.Data.Filter.SubjectEndsWith);

            // List and validate
            var allSubs = await eventSubscriptions.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(allSubs);
            Assert.AreEqual(2, allSubs.Count);

            // Cleanup
            await sub1.DeleteAsync(WaitUntil.Completed);
            await sub2.DeleteAsync(WaitUntil.Completed);

            var subsAfterDelete = await eventSubscriptions.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, subsAfterDelete.Count);

            if (existing == null)
            {
                await systemTopic.DeleteAsync(WaitUntil.Completed);
                var exists = (await SystemTopicCollection.ExistsAsync(systemTopicName)).Value;
                Assert.IsFalse(exists);
            }
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

            // Cleanup
            await systemTopicResource.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task SystemTopicEventSubscriptionLifecycleGetAttributesUriAndResource()
        {
            await SetCollection();
            string systemTopicName = Recording.GenerateAssetName("sdk-SystemTopic-EventSubLifecycle-");
            string eventSubscriptionName = Recording.GenerateAssetName("sdk-EventSubscription-EventSubLifecycle-");

            // Ensure the resource group for the system topic matches the source resource group
            // Use the resource group created by SetCollection()
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

            // Get delivery attributes (handle null/empty array)
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
    }
}
