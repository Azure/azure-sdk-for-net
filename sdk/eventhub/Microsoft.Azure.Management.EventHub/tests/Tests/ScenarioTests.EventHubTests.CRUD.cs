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
                var dataLakeName = "datalaketestps";

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
                    var eventhubWithDataLakeCapture = TestUtilities.GenerateName(EventHubManagementHelper.EventHubPrefix);

                    //Test Creation of eventhub with capture enabled

                    // -------------------------------------------------------------------------------------------------------------

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
                    Assert.Equal(4, createEventHubResponse.MessageRetentionInDays);
                    Assert.Equal(4, createEventHubResponse.PartitionCount);
                    Assert.Equal(EntityStatus.Active, createEventHubResponse.Status);
                    Assert.Equal(120, createEventHubResponse.CaptureDescription.IntervalInSeconds);
                    Assert.Equal(10485763, createEventHubResponse.CaptureDescription.SizeLimitInBytes);
                    Assert.Equal(EncodingCaptureDescription.Avro, createEventHubResponse.CaptureDescription.Encoding);
                    Assert.True(createEventHubResponse.CaptureDescription.SkipEmptyArchives);
                    Assert.True(createEventHubResponse.CaptureDescription.Enabled);
                    Assert.Equal("EventHubArchive.AzureBlockBlob", createEventHubResponse.CaptureDescription.Destination.Name);
                    Assert.Equal("container", createEventHubResponse.CaptureDescription.Destination.BlobContainer);
                    Assert.Equal("{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}", createEventHubResponse.CaptureDescription.Destination.ArchiveNameFormat);
                    Assert.Equal("/subscriptions/" + ResourceManagementClient.SubscriptionId.ToString() + "/resourcegroups/v-ajnavtest/providers/Microsoft.Storage/storageAccounts/testingsdkeventhubnew", createEventHubResponse.CaptureDescription.Destination.StorageAccountResourceId);

                    createEventHubResponse.Status = EntityStatus.Disabled;

                    createEventHubResponse = EventHubManagementClient.EventHubs.CreateOrUpdate(resourceGroup, namespaceName, eventhubName, createEventHubResponse);
                    Assert.Equal(EntityStatus.Disabled, createEventHubResponse.Status);

                    createEventHubResponse.Status = EntityStatus.SendDisabled;

                    createEventHubResponse = EventHubManagementClient.EventHubs.CreateOrUpdate(resourceGroup, namespaceName, eventhubName, createEventHubResponse);
                    Assert.Equal(EntityStatus.SendDisabled, createEventHubResponse.Status);

                    createEventHubResponse.CaptureDescription.Enabled = false;
                    createEventHubResponse.Status = EntityStatus.Active;

                    createEventHubResponse = EventHubManagementClient.EventHubs.CreateOrUpdate(resourceGroup, namespaceName, eventhubName, createEventHubResponse);
                    Assert.Equal(EntityStatus.Active, createEventHubResponse.Status);
                    Assert.False(createEventHubResponse.CaptureDescription.Enabled);


                    // ------------------------------------------------------------------------------------------------------------------------

                    // Get the created EventHub
                    var getEventResponse = EventHubManagementClient.EventHubs.Get(resourceGroup, namespaceName, eventhubName);
                    Assert.NotNull(getEventResponse);
                    Assert.Equal(EntityStatus.Active, getEventResponse.Status);

                    // Get all Event Hubs for a given NameSpace
                    var getListEventHubResponse = EventHubManagementClient.EventHubs.ListByNamespace(resourceGroup, namespaceName);
                    Assert.NotNull(getListEventHubResponse);
                    Assert.True(getListEventHubResponse.Count<Eventhub>() == 1);

                    // Update the EventHub
                    getEventResponse.CaptureDescription.IntervalInSeconds = 130;
                    getEventResponse.CaptureDescription.SizeLimitInBytes = 10485900;
                    getEventResponse.MessageRetentionInDays = 5;

                    var getUpdateEventhubPropertiesResponse = EventHubManagementClient.EventHubs.CreateOrUpdate(resourceGroup, namespaceName, eventhubName, getEventResponse);
                    Assert.NotNull(getUpdateEventhubPropertiesResponse);

                    Assert.NotNull(getUpdateEventhubPropertiesResponse);
                    Assert.Equal(getUpdateEventhubPropertiesResponse.Name, eventhubName);
                    Assert.Equal(5, getUpdateEventhubPropertiesResponse.MessageRetentionInDays);
                    Assert.Equal(4, getUpdateEventhubPropertiesResponse.PartitionCount);
                    Assert.Equal(EntityStatus.Active, getUpdateEventhubPropertiesResponse.Status);
                    Assert.Equal(130, getUpdateEventhubPropertiesResponse.CaptureDescription.IntervalInSeconds);
                    Assert.Equal(10485900, getUpdateEventhubPropertiesResponse.CaptureDescription.SizeLimitInBytes);
                    Assert.Equal(EncodingCaptureDescription.Avro, getUpdateEventhubPropertiesResponse.CaptureDescription.Encoding);
                    Assert.True(getUpdateEventhubPropertiesResponse.CaptureDescription.SkipEmptyArchives);
                    Assert.False(getUpdateEventhubPropertiesResponse.CaptureDescription.Enabled);
                    Assert.Equal("EventHubArchive.AzureBlockBlob", getUpdateEventhubPropertiesResponse.CaptureDescription.Destination.Name);
                    Assert.Equal("container", getUpdateEventhubPropertiesResponse.CaptureDescription.Destination.BlobContainer);
                    Assert.Equal("{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}", getUpdateEventhubPropertiesResponse.CaptureDescription.Destination.ArchiveNameFormat);
                    Assert.Equal("/subscriptions/" + ResourceManagementClient.SubscriptionId.ToString() + "/resourcegroups/v-ajnavtest/providers/Microsoft.Storage/storageAccounts/testingsdkeventhubnew", getUpdateEventhubPropertiesResponse.CaptureDescription.Destination.StorageAccountResourceId);


                    // Get the updated EventHub and verify the properties
                    getEventResponse = EventHubManagementClient.EventHubs.Get(resourceGroup, namespaceName, eventhubName);
                    Assert.NotNull(getEventResponse);
                    Assert.Equal(EntityStatus.Active, getEventResponse.Status);
                    Assert.Equal(5, getEventResponse.MessageRetentionInDays);

                    var eventHubWithDataLakeCaptureResponse = this.EventHubManagementClient.EventHubs.CreateOrUpdate(resourceGroup, namespaceName, eventhubWithDataLakeCapture, 
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
                                    Name = "EventHubArchive.AzureDataLake",
                                    DataLakeSubscriptionId = new Guid(this.ResourceManagementClient.SubscriptionId),
                                    ArchiveNameFormat = "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}",
                                    DataLakeAccountName = dataLakeName,
                                    DataLakeFolderPath = "/"
                                },
                                SkipEmptyArchives = false
                            }
                        });

                    Assert.NotNull(eventHubWithDataLakeCaptureResponse);
                    Assert.Equal(eventHubWithDataLakeCaptureResponse.Name, eventhubWithDataLakeCapture);
                    Assert.Equal(4, eventHubWithDataLakeCaptureResponse.MessageRetentionInDays);
                    Assert.Equal(4, eventHubWithDataLakeCaptureResponse.PartitionCount);
                    Assert.Equal(EntityStatus.Active, eventHubWithDataLakeCaptureResponse.Status);
                    Assert.Equal(120, eventHubWithDataLakeCaptureResponse.CaptureDescription.IntervalInSeconds);
                    Assert.Equal(10485763, eventHubWithDataLakeCaptureResponse.CaptureDescription.SizeLimitInBytes);
                    Assert.Equal(EncodingCaptureDescription.Avro, eventHubWithDataLakeCaptureResponse.CaptureDescription.Encoding);
                    Assert.Null(eventHubWithDataLakeCaptureResponse.CaptureDescription.SkipEmptyArchives);
                    Assert.True(eventHubWithDataLakeCaptureResponse.CaptureDescription.Enabled);
                    Assert.Equal("EventHubArchive.AzureDataLake", eventHubWithDataLakeCaptureResponse.CaptureDescription.Destination.Name);
                    Assert.Equal(dataLakeName, eventHubWithDataLakeCaptureResponse.CaptureDescription.Destination.DataLakeAccountName);
                    Assert.Equal("/", eventHubWithDataLakeCaptureResponse.CaptureDescription.Destination.DataLakeFolderPath);
                    Assert.Equal(new Guid(this.ResourceManagementClient.SubscriptionId), eventHubWithDataLakeCaptureResponse.CaptureDescription.Destination.DataLakeSubscriptionId);


                    // Delete the Event Hub
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
