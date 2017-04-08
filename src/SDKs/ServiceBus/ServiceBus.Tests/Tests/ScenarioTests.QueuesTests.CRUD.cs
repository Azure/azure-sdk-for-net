// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace ServiceBus.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Management.ServiceBus;
    using Microsoft.Azure.Management.ServiceBus.Models;    
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using Xunit;
    public partial class ScenarioTests 
    {
        [Fact]
        public void QueuesCreateGetUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(ServiceBusManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                // Create Namespace
                var namespaceName = TestUtilities.GenerateName(ServiceBusManagementHelper.NamespacePrefix);

                var createNamespaceResponse = this.ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
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

                // Create Queue
                var queueName = TestUtilities.GenerateName(ServiceBusManagementHelper.QueuesPrefix);
                var createQueueResponse = this.ServiceBusManagementClient.Queues.CreateOrUpdate(resourceGroup, namespaceName, queueName,
                new QueueCreateOrUpdateParameters()
                {
                    Location = location
                });

                Assert.NotNull(createQueueResponse);
                Assert.Equal(createQueueResponse.Name, queueName);
                
                // Get the created Queue
                var getQueueResponse = ServiceBusManagementClient.Queues.Get(resourceGroup, namespaceName, queueName);
                Assert.NotNull(getQueueResponse);
                Assert.Equal(EntityStatus.Active, getQueueResponse.Status);
                Assert.Equal(getQueueResponse.Name, queueName);
                  
                // Get all Queues
                var getQueueListAllResponse = ServiceBusManagementClient.Queues.ListAll(resourceGroup, namespaceName);
                Assert.NotNull(getQueueListAllResponse);
                Assert.True(getQueueListAllResponse.Count() >= 1);                
                Assert.True(getQueueListAllResponse.All(ns => ns.Id.Contains(resourceGroup)));
                
                // Update Queue. 
                var updateQueuesParameter = new QueueCreateOrUpdateParameters()
                {
                    Location = location,
                    EnableExpress = true,                   
                    IsAnonymousAccessible = true                   
                };

                var updateQueueResponse = ServiceBusManagementClient.Queues.CreateOrUpdate(resourceGroup, namespaceName, queueName, updateQueuesParameter);
                Assert.NotNull(updateQueueResponse);
                Assert.True(updateQueueResponse.EnableExpress);
                Assert.True(updateQueueResponse.IsAnonymousAccessible);

                // Delete Created Queue  and check for the NotFound exception 
                ServiceBusManagementClient.Queues.Delete(resourceGroup, namespaceName, queueName);
                try
                {
                    var getQueueResponse1 = ServiceBusManagementClient.Queues.Get(resourceGroup, namespaceName, queueName);
                }
                catch (Exception ex)
                {
                    Assert.Equal(ex.Message, "The requested resource " + queueName + " does not exist.");
                }                
            }
        }
    }
}
