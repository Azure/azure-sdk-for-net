﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
    using System.Threading;
    public partial class ScenarioTests 
    {
        [Fact]
        public void QueuesCreateGetUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
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
                    new SBNamespace()
                    {
                        Location = location,
                        Sku = new SBSku
                        {
                            Name = SkuName.Standard,
                            Tier = SkuTier.Standard
                        }
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Create Queue
                var queueName = TestUtilities.GenerateName(ServiceBusManagementHelper.QueuesPrefix);
                var createQueueResponse = this.ServiceBusManagementClient.Queues.CreateOrUpdate(resourceGroup, namespaceName, queueName,
                new SBQueue() { EnableExpress = true, EnableBatchedOperations = true});

                Assert.NotNull(createQueueResponse);
                Assert.Equal(createQueueResponse.Name, queueName);
                Assert.True(createQueueResponse.EnableExpress);
                
                // Get the created Queue
                var getQueueResponse = ServiceBusManagementClient.Queues.Get(resourceGroup, namespaceName, queueName);
                Assert.NotNull(getQueueResponse);
                Assert.Equal(EntityStatus.Active, getQueueResponse.Status);
                Assert.Equal(getQueueResponse.Name, queueName);
                  
                // Get all Queues
                var getQueueListAllResponse = ServiceBusManagementClient.Queues.ListByNamespace(resourceGroup, namespaceName);
                Assert.NotNull(getQueueListAllResponse);
                Assert.True(getQueueListAllResponse.Count() >= 1);                
                Assert.True(getQueueListAllResponse.All(ns => ns.Id.Contains(resourceGroup)));


                // Create Queue1
                var queueName1 = TestUtilities.GenerateName(ServiceBusManagementHelper.QueuesPrefix);
                var createQueueResponse1 = this.ServiceBusManagementClient.Queues.CreateOrUpdate(resourceGroup, namespaceName, queueName1,
                new SBQueue() { EnableExpress = true });


                // Update Queue. 
                var updateQueuesParameter = new SBQueue()
                {
                    EnableExpress = true,
                    MaxDeliveryCount = 5,
                    MaxSizeInMegabytes = 1024,
                    ForwardTo = queueName1,
                    ForwardDeadLetteredMessagesTo = queueName1
                    
                };

                var updateQueueResponse = ServiceBusManagementClient.Queues.CreateOrUpdate(resourceGroup, namespaceName, queueName, updateQueuesParameter);
                Assert.NotNull(updateQueueResponse);
                Assert.True(updateQueueResponse.EnableExpress);
                Assert.Equal(updateQueueResponse.ForwardTo, queueName1);
                Assert.Equal(updateQueueResponse.ForwardDeadLetteredMessagesTo, queueName1);

                // Delete Created Queue 
                ServiceBusManagementClient.Queues.Delete(resourceGroup, namespaceName, queueName);

                //Delete Namespace Async
                ServiceBusManagementClient.Namespaces.DeleteWithHttpMessagesAsync(resourceGroup, namespaceName, null, new CancellationToken()).ConfigureAwait(false);
            }
        }
    }
}
