// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace EventHub.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(EventHubManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                var namespaceName = TestUtilities.GenerateName(EventHubManagementHelper.NamespacePrefix);

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
                new EventHubModel() { MessageRetentionInDays = 4, PartitionCount = 4, Status = EntityStatus.Active });

                Assert.NotNull(createEventHubResponse);
                Assert.Equal(createEventHubResponse.Name, eventhubName);
                
                // Get the created EventHub
                var getEventResponse = EventHubManagementClient.EventHubs.Get(resourceGroup, namespaceName, eventhubName);
                Assert.NotNull(getEventResponse);
                Assert.Equal(getEventResponse.Status, EntityStatus.Active);
                
                // Get all Event Hubs for a given NameSpace
                var getListEventHubResponse = EventHubManagementClient.EventHubs.ListByNamespace(resourceGroup, namespaceName);
                Assert.NotNull(getListEventHubResponse);
                Assert.True(getListEventHubResponse.Count<EventHubModel>() >= 1 );

                // Update the EventHub
                EventHubModel updateEventHubProperties = new EventHubModel()
                {
                   MessageRetentionInDays = 5
                };

                var getUpdateEventhubPropertiesResponse = EventHubManagementClient.EventHubs.CreateOrUpdate(resourceGroup, namespaceName, eventhubName, updateEventHubProperties);
                Assert.NotNull(getUpdateEventhubPropertiesResponse);
                
                // Get the updated EventHub and verify the properties
                getEventResponse = EventHubManagementClient.EventHubs.Get(resourceGroup, namespaceName, eventhubName);
                Assert.NotNull(getEventResponse);
                Assert.Equal(getEventResponse.Status, EntityStatus.Active);
                Assert.Equal(getEventResponse.MessageRetentionInDays, 5);

                // Delete the Evnet Hub
                EventHubManagementClient.EventHubs.Delete(resourceGroup, namespaceName, eventhubName);
                

                // Delete namespace and check for the NotFound exception
                EventHubManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
                
            }
        }
    }
}
