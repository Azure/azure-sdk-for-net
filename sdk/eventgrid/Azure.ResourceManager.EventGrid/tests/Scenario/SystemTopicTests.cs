// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Metrics;
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
    public class SystemTopicTests : EventGridManagementTestBase
    {
        public SystemTopicTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private SystemTopicCollection SystemTopicCollection { get; set; }
        private ResourceGroupResource ResourceGroup { get; set; }
        private EventGridNamespaceCollection NamespaceCollection { get; set; }

        private async Task SetCollection()
        {
            // this assumes that resource group TestRG exists under your subscription and storage accounts are setup under this resource groups
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

            // delete system topic
            await createSystemTopicResponse.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task SystemTopicWithNamespaceTopicDestinationCreateGetUpdateDelete()
        {
            await SetCollection();

            // Setup Namespace topic
            /*var namespaceName = Recording.GenerateAssetName("sdk-Namespace-");
            var namespaceTopicName = Recording.GenerateAssetName("sdk-Namespace-Topic");
            var namespaceSkuName = "Standard";
            var namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 1,
            };
            AzureLocation location = new AzureLocation("eastus", "eastus");
            UserAssignedIdentity userAssignedIdentity = new UserAssignedIdentity();
            var nameSpace = new EventGridNamespaceData(location)
            {
                Tags = {
                    {"originalTag1", "originalValue1"},
                    {"originalTag2", "originalValue2"}
                },
                Sku = namespaceSku,
                IsZoneRedundant = true,
                TopicSpacesConfiguration = new TopicSpacesConfiguration()
                {
                    State = TopicSpacesConfigurationState.Enabled
                },
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned)
            };
            nameSpace.Identity.UserAssignedIdentities.Add(new ResourceIdentifier("/subscriptions/b6a8bef9-9220-454a-a229-f360b6e9f0f6/resourcegroups/TestRG/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sdktestuseridentity"), userAssignedIdentity);
            var createNamespaceResponse = (await NamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, nameSpace)).Value;
            Assert.NotNull(createNamespaceResponse);
            Assert.AreEqual(createNamespaceResponse.Data.Name, namespaceName);
            var namespaceTopicsCollection = createNamespaceResponse.GetNamespaceTopics();
            Assert.NotNull(namespaceTopicsCollection);

            var namespaceTopic = new NamespaceTopicData()
            {
                EventRetentionInDays = 1
            };
            var namespaceTopicsResponse1 = (await namespaceTopicsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicName, namespaceTopic)).Value;
            Assert.NotNull(namespaceTopicsResponse1);
            Assert.AreEqual(namespaceTopicsResponse1.Data.ProvisioningState, NamespaceTopicProvisioningState.Succeeded);*/

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
            data.Identity.UserAssignedIdentities.Add(new ResourceIdentifier("/subscriptions/b6a8bef9-9220-454a-a229-f360b6e9f0f6/resourcegroups/TestRG/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sdktestuseridentity"), userAssignedIdentity);
            var createSystemTopicResponse = (await SystemTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicName, data)).Value;
            Assert.NotNull(createSystemTopicResponse);
            Assert.AreEqual(createSystemTopicResponse.Data.ProvisioningState, EventGridResourceProvisioningState.Succeeded);
            var SystemTopicEventSubscriptionsCollection = createSystemTopicResponse.GetSystemTopicEventSubscriptions();

            var namespaceTopicDestination = new DeliveryWithResourceIdentity()
            {
                Identity = new EventSubscriptionIdentity()
                {
                    IdentityType = EventSubscriptionIdentityType.UserAssigned,
                    UserAssignedIdentity = "/subscriptions/b6a8bef9-9220-454a-a229-f360b6e9f0f6/resourcegroups/TestRG/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sdktestuseridentity",
                },
                Destination = new NamespaceTopicEventSubscriptionDestination()
                {
                    ResourceId = new ResourceIdentifier("/subscriptions/b6a8bef9-9220-454a-a229-f360b6e9f0f6/resourceGroups/TestRG/providers/Microsoft.EventGrid/namespaces/testnamespace/topics/testtopic"),
                }
            };

            EventGridSubscriptionData eventSubscriptionData = new EventGridSubscriptionData()
            {
                /*Destination = new NamespaceTopicEventSubscriptionDestination
                {
                    EndpointType = EndpointType.NamespaceTopic,
                    ResourceId = createNamespaceResponse.Id
                },*/
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

            // delete system topic and namespace
            await createSystemTopicResponse.DeleteAsync(WaitUntil.Completed);
            //await namespaceTopicsResponse1.DeleteAsync(WaitUntil.Completed);
            //await createNamespaceResponse.DeleteAsync(WaitUntil.Completed);
        }
    }
}
