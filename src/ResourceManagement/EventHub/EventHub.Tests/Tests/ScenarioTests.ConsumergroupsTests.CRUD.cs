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
        public void ConsumerGroupsCreateGetUpdateDelete()
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
                    new NamespaceCreateOrUpdateParameters()
                    {
                        Location = location,
                        Sku = new Sku
                        {
                            Name = "Standard",
                            Tier = "Standard"
                        }
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Create Eventhub
                var eventhubName = TestUtilities.GenerateName(EventHubManagementHelper.EventHubPrefix);

                var createEventhubResponse = this.EventHubManagementClient.EventHubs.CreateOrUpdate(resourceGroup, namespaceName, eventhubName,
                new EventHubCreateOrUpdateParameters()
                {
                    Location = location
                }
                 );

                Assert.NotNull(createEventhubResponse);
                Assert.Equal(createEventhubResponse.Name, eventhubName);

                //Get the created EventHub
                var geteventhubResponse = EventHubManagementClient.EventHubs.Get(resourceGroup, namespaceName, eventhubName);
                Assert.NotNull(geteventhubResponse);
                Assert.Equal(EntityStatus.Active, geteventhubResponse.Status);
                Assert.Equal(geteventhubResponse.Name, eventhubName);

                // Create ConsumerGroup.
                var consumergroupName = TestUtilities.GenerateName(EventHubManagementHelper.ConsumerGroupPrefix);
                var createSubscriptionResponse = EventHubManagementClient.ConsumerGroups.CreateOrUpdate(resourceGroup, namespaceName, eventhubName, consumergroupName, new ConsumerGroupCreateOrUpdateParameters()
                {
                    Location = location               
                }
                );
                Assert.NotNull(createSubscriptionResponse);
                Assert.Equal(createSubscriptionResponse.Name, consumergroupName);

                // Get Created ConsumerGroup
                var getConsumergroupGetResponse = EventHubManagementClient.ConsumerGroups.Get(resourceGroup, namespaceName, eventhubName, consumergroupName);
                Assert.NotNull(getConsumergroupGetResponse);                
                Assert.Equal(getConsumergroupGetResponse.Name, consumergroupName);

                // Get all ConsumerGroup   
                var getSubscriptionsListAllResponse = EventHubManagementClient.ConsumerGroups.ListAll(resourceGroup, namespaceName,eventhubName);
                Assert.NotNull(getSubscriptionsListAllResponse);              
                Assert.True(getSubscriptionsListAllResponse.All(ns => ns.Id.Contains(resourceGroup)));

                // Delete Created ConsumerGroup and check for the NotFound exception 
                EventHubManagementClient.ConsumerGroups.Delete(resourceGroup, namespaceName, eventhubName, consumergroupName);
                try
                {
                    var getConsumerGroupResponse1 = EventHubManagementClient.ConsumerGroups.Get(resourceGroup, namespaceName, eventhubName,consumergroupName);                    
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound,ex.Response.StatusCode);
                }

                // Delete Created EventHub  and check for the NotFound exception 
                EventHubManagementClient.EventHubs.Delete(resourceGroup, namespaceName, eventhubName);
                try
                {
                    var getEventHugResponse1 = EventHubManagementClient.EventHubs.Get(resourceGroup, namespaceName, eventhubName);
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }

                // Delete namespace
                try
                {                    
                    EventHubManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
                }
                catch (Exception ex)
                {
                    Assert.True(ex.Message.Contains("NotFound"));
                }
                //Subscription end
            }
        }
    }
}
