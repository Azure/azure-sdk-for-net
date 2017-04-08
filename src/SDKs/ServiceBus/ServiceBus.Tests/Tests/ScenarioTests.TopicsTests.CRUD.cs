// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace ServiceBus.Tests.ScenarioTests
{
    using System;
    using System.Linq;
    using Microsoft.Azure.Management.ServiceBus;
    using Microsoft.Azure.Management.ServiceBus.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using Xunit;
    public partial class ScenarioTests 
    {
        [Fact]
        public void TopicsCreateGetUpdateDelete()
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
                
                // Create a Topic
                var topicName = TestUtilities.GenerateName(ServiceBusManagementHelper.TopicPrefix);
                var createTopicResponse = this.ServiceBusManagementClient.Topics.CreateOrUpdate(resourceGroup, namespaceName, topicName,
                new TopicCreateOrUpdateParameters()
                {
                    Location = location
                });
                Assert.NotNull(createTopicResponse);
                Assert.Equal(createTopicResponse.Name, topicName);

                // Get the created topic
                var getTopicResponse = ServiceBusManagementClient.Topics.Get(resourceGroup, namespaceName, topicName);
                Assert.NotNull(getTopicResponse);
                Assert.Equal(EntityStatus.Active, getTopicResponse.Status);
                Assert.Equal(getTopicResponse.Name, topicName);
                                
                // Get all Topics   
                var getTopicsListAllResponse = ServiceBusManagementClient.Topics.ListAll(resourceGroup, namespaceName);
                Assert.NotNull(getTopicsListAllResponse);
                Assert.True(getTopicsListAllResponse.Count() >= 1);                
                Assert.True(getTopicsListAllResponse.All(ns => ns.Id.Contains(resourceGroup)));

                // Update Topic
                var updateTopicsParameter = new TopicCreateOrUpdateParameters()
                {
                    Location = location,
                    EnableExpress = true,                   
                    IsAnonymousAccessible = true                   
                };

                var updateTopicsResponse = ServiceBusManagementClient.Topics.CreateOrUpdate(resourceGroup, namespaceName, topicName, updateTopicsParameter);
                Assert.NotNull(updateTopicsResponse);
                Assert.True(updateTopicsResponse.EnableExpress);
                Assert.True(updateTopicsResponse.IsAnonymousAccessible);
                Assert.NotEqual(updateTopicsResponse.UpdatedAt, getTopicResponse.UpdatedAt);

                // Get the created topic to check the Updated values. 
                getTopicResponse = ServiceBusManagementClient.Topics.Get(resourceGroup, namespaceName, topicName);
                Assert.NotNull(getTopicResponse);
                Assert.Equal(EntityStatus.Active, getTopicResponse.Status);
                Assert.Equal(getTopicResponse.Name, topicName);
                Assert.True(updateTopicsResponse.EnableExpress);
                Assert.True(updateTopicsResponse.IsAnonymousAccessible);
                Assert.NotEqual(updateTopicsResponse.UpdatedAt, getTopicResponse.UpdatedAt);

                // Delete Created Topics  and check for the NotFound exception 
                ServiceBusManagementClient.Topics.Delete(resourceGroup, namespaceName, topicName);
                try
                {
                    var getTopicsResponse1 = ServiceBusManagementClient.Topics.Get(resourceGroup, namespaceName, topicName);
                }
                catch (Exception ex)
                {
                    Assert.Equal(ex.Message, "The requested resource " + topicName + " does not exist.");
                }

                // Delete namespace
                try
                {                    
                    ServiceBusManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
                }
                catch (Exception ex)
                {
                    Assert.True(ex.Message.Contains("NotFound"));
                }
            }
        }
    }
}
