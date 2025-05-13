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
        // from the Azure Portal for the function "EventGridTrigger1" in "devexpfuncappdestination".
        private const string AzureFunctionEndpointUrl = "https://devexpfuncappdestination.azurewebsites.net/runtime/webhooks/EventGrid?functionName=EventGridTrigger1&code=SANITIZED_FUNCTION_KEY";
        private async Task SetCollection()
        {
            // This test relies on the existence of the 'TestRG' resource group within the subscription, ensuring that system topics and related resources (such as Key Vault) are deployed within the same resource group for validation
            // Subscription: 5b4b650e-28b9-4790-b3ab-ddbd88d727c4 (Azure Event Grid SDK Subscription)
            ResourceGroup = await GetResourceGroupAsync(DefaultSubscription, "TestRG");
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
            string sourceResourceIdentifier = String.Format("/subscriptions/{0}/resourceGroups/TestRG/providers/Microsoft.KeyVault/vaults/sdktestkeyvault", SystemTopicCollection.Id.SubscriptionId);
            SystemTopicData data = new SystemTopicData(new AzureLocation("eastus"))
            {
                Source = new ResourceIdentifier(sourceResourceIdentifier),
                TopicType = "Microsoft.KeyVault.Vaults",
                Tags =
                     {
                         ["tag1"] = "value1",
                         ["tag2"] = "value2",
                     },
            };
            var createSystemTopicResponse = (await SystemTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicName, data)).Value;
            Assert.NotNull(createSystemTopicResponse);
            Assert.AreEqual(createSystemTopicResponse.Data.ProvisioningState, EventGridResourceProvisioningState.Succeeded);

            // List all system topics under resource group
            var systemTopicsUnderResourceGroup = await ResourceGroup.GetSystemTopics().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(systemTopicsUnderResourceGroup.Count, 1);

            // List all system topics under subscription
            var systemTopicsInAzureSubscription = await DefaultSubscription.GetSystemTopicsAsync().ToEnumerableAsync();
            Assert.AreEqual(systemTopicsInAzureSubscription.Count, 179);

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
            Assert.AreEqual(listSystemTopicsResponse.Count, 2);

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
            // Create system topic and create subscription to namespace topic for that system topic
            string systemTopicName = Recording.GenerateAssetName("sdk-SystemTopic-");
            string systemTopicEventSubscriptionName1 = Recording.GenerateAssetName("sdk-EventSubscription-");
            string systemTopicEventSubscriptionName2 = Recording.GenerateAssetName("sdk-EventSubscription-");
            UserAssignedIdentity userAssignedIdentity = new UserAssignedIdentity();
            string sourceResourceIdentifier = String.Format("/subscriptions/{0}/resourceGroups/TestRG/providers/Microsoft.Storage/storageAccounts/testcontosso3", SystemTopicCollection.Id.SubscriptionId);
            SystemTopicData data = new SystemTopicData(new AzureLocation("eastus2euap"))
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
            data.Identity.UserAssignedIdentities.Add(new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/TestRG/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sdktestuseridentity"), userAssignedIdentity);
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
                    UserAssignedIdentity = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/TestRG/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sdktestuseridentity",
                },
                Destination = new NamespaceTopicEventSubscriptionDestination()
                {
                    ResourceId = new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/TestRG/providers/Microsoft.EventGrid/namespaces/testnamespace/topics/testtopic"),
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
    }
}
