// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace EventHub.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using Microsoft.Azure.Management.EventHub;
    using Microsoft.Azure.Management.EventHub.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using Xunit;
    public partial class ScenarioTests
    {
        [Fact]
        public void EventCreateGetUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                var resourceGroup = string.Empty;
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(EventHubManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                var namespaceName = TestUtilities.GenerateName(EventHubManagementHelper.NamespacePrefix);

                try
                {
                    var createNamespaceResponse = this.EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new EHNamespace()
                    {
                        Location = location,
                        Sku = new Sku
                        {
                            Name = SkuName.Standard,
                            Tier = SkuTier.Standard
                        },
                        Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        }
                    });

                    Assert.NotNull(createNamespaceResponse);
                    Assert.Equal(createNamespaceResponse.Name, namespaceName);
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                    // Create a EventHub
                    var eventhubName = TestUtilities.GenerateName(EventHubManagementHelper.EventHubPrefix);

                    var createEventHubResponse = this.EventHubManagementClient.EventHubs.CreateOrUpdate(resourceGroup, namespaceName, eventhubName,
                    new Eventhub()
                    {
                        MessageRetentionInDays = 4,
                        PartitionCount = 4,
                        Status = EntityStatus.Active,
                        CaptureDescription = new CaptureDescription()
                        {
                            Enabled = true,
                            Encoding = EncodingCaptureDescription.Avro,
                            IntervalInSeconds = 120,
                            SizeLimitInBytes = 10485763,
                            Destination = new Destination()
                            {
                                Name = "EventHubArchive.AzureBlockBlob",
                                BlobContainer = "container",
                                ArchiveNameFormat = "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}",
                                StorageAccountResourceId = "/subscriptions/" + ResourceManagementClient.SubscriptionId.ToString() + "/resourcegroups/v-ajnavtest/providers/Microsoft.Storage/storageAccounts/testingsdkeventhubnew"
                            },
                            SkipEmptyArchives = true
                        }
                    });

                    Assert.NotNull(createEventHubResponse);
                    Assert.Equal(createEventHubResponse.Name, eventhubName);
                    Assert.True(createEventHubResponse.CaptureDescription.SkipEmptyArchives);

                    // Get the created EventHub
                    var getEventResponse = EventHubManagementClient.EventHubs.Get(resourceGroup, namespaceName, eventhubName);
                    Assert.NotNull(getEventResponse);
                    Assert.Equal(EntityStatus.Active, getEventResponse.Status);

                    // Get all Event Hubs for a given NameSpace
                    var getListEventHubResponse = EventHubManagementClient.EventHubs.ListByNamespace(resourceGroup, namespaceName);
                    Assert.NotNull(getListEventHubResponse);
                    Assert.True(getListEventHubResponse.Count<Eventhub>() >= 1);

                    // Update the EventHub
                    getEventResponse.CaptureDescription.IntervalInSeconds = 130;
                    getEventResponse.CaptureDescription.SizeLimitInBytes = 10485900;
                    getEventResponse.MessageRetentionInDays = 5;

                    var getUpdateEventhubPropertiesResponse = EventHubManagementClient.EventHubs.CreateOrUpdate(resourceGroup, namespaceName, eventhubName, getEventResponse);
                    Assert.NotNull(getUpdateEventhubPropertiesResponse);

                    getEventResponse.MessageRetentionInDays = 6;
                    var getUpdateEventhubPropertiesResponse1 = EventHubManagementClient.EventHubs.CreateOrUpdate(resourceGroup, namespaceName, eventhubName, getEventResponse);


                    // Get the updated EventHub and verify the properties
                    getEventResponse = EventHubManagementClient.EventHubs.Get(resourceGroup, namespaceName, eventhubName);
                    Assert.NotNull(getEventResponse);
                    Assert.Equal(EntityStatus.Active, getEventResponse.Status);
                    Assert.Equal(6, getEventResponse.MessageRetentionInDays);

                    // Delete the Evnet Hub
                    EventHubManagementClient.EventHubs.Delete(resourceGroup, namespaceName, eventhubName);

                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                    // Delete namespace and check for the NotFound exception
                    EventHubManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
                }
                finally
                {
                    //Delete Resource Group
                    this.ResourceManagementClient.ResourceGroups.DeleteWithHttpMessagesAsync(resourceGroup, null, default(CancellationToken)).ConfigureAwait(false);
                    Console.WriteLine("End of EH2018 Namespace CRUD IPFilter Rules test");
                }
            }
        }
    }
}
