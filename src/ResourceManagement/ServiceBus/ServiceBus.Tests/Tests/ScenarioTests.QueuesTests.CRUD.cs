//  
//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.


namespace ServiceBus.Tests.ScenarioTests
{
    using Microsoft.Azure.Management.ServiceBus;
    using Microsoft.Azure.Management.ServiceBus.Models;    
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.Rest.Azure;
    using System;
    using System.Linq;
    using System.Net;
    using TestHelper;
    using Xunit;
    using System.Collections.Generic;
    public partial class ScenarioTests 
    {
        [Fact]
        public void QueuesCreateGetUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                InitializeClients(context);
                var location = ServiceBusManagementHelper.DefaultLocation;

                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(ServiceBusManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

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

                // TestUtilities.Wait(TimeSpan.FromSeconds(5));
                // Queues

                var queueName = TestUtilities.GenerateName(ServiceBusManagementHelper.QueuesPrefix);
                //var namespaceName = "sdk-Namespace4123";

                var createQueueResponse = this.ServiceBusManagementClient.Queues.CreateOrUpdate(resourceGroup, namespaceName, queueName,
                new QueueCreateOrUpdateParameters()
                {
                    Location = location
                }
                    );

                Assert.NotNull(createQueueResponse);
                Assert.Equal(createQueueResponse.Name, queueName);

                // Verify with invalid Queue name


                string queueName_invalid = queueName + "12";
                try
                {
                    var invalidQueueNameResponse = ServiceBusManagementClient.Queues.CreateOrUpdate(resourceGroup, namespaceName, queueName_invalid, new QueueCreateOrUpdateParameters()
                    {
                        Location = location                        
                    }
                    );                                    

                }
                catch (CloudException ex)
                {
                    Assert.Equal(ex.Response.StatusCode, HttpStatusCode.BadRequest);
                }

                // Verify with null parameters
                try
                {
                    var invalidQueueNameResponse = ServiceBusManagementClient.Queues.CreateOrUpdate(resourceGroup, namespaceName, queueName, new QueueCreateOrUpdateParameters()
                    {
                        Location = "qwqw2_"                        
                    }
                        );
                }
                catch (CloudException ex)
                {
                    Assert.Equal(ex.Response.StatusCode, HttpStatusCode.BadRequest);
                }
                catch (Exception ex)
                {
                    string x = ex.Message;
                }

                //Get the created Queue
                var getQueueResponse = ServiceBusManagementClient.Queues.Get(resourceGroup, namespaceName, queueName);
                Assert.NotNull(getQueueResponse);
                Assert.Equal(EntityStatus.Active, getQueueResponse.Status);
                Assert.Equal(getQueueResponse.Name, queueName);
                                               
                //Get Queue with invalid name
                try
                {
                    var getQueueResponse1 = ServiceBusManagementClient.Queues.Get(resourceGroup, namespaceName, queueName_invalid);                    
                }
                catch (Exception ex)
                {
                    Assert.Equal(ex.Message, "The requested resource "+ queueName_invalid + " does not exist.");
                }


                // Get all Queues with valid parameters
                var getQueueListAllResponse = ServiceBusManagementClient.Queues.ListAll(resourceGroup, namespaceName);
                Assert.NotNull(getQueueListAllResponse);
                Assert.True(getQueueListAllResponse.Count() >= 1);                
                Assert.True(getQueueListAllResponse.All(ns => ns.Id.Contains(resourceGroup)));

                // Get all Queues with invalid parameters
                

                // Update Queue. 

                // Set the Parameters to update he Queue 

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


                //Delete Created Queue  and check for the NotFound exception 

                ServiceBusManagementClient.Queues.Delete(resourceGroup, namespaceName, queueName);
                try
                {
                    var getQueueResponse1 = ServiceBusManagementClient.Queues.Get(resourceGroup, namespaceName, queueName);
                }
                catch (Exception ex)
                {
                    Assert.Equal(ex.Message, "The requested resource " + queueName + " does not exist.");
                }
                
                //Queue end
                
            }
        }
    }
}
