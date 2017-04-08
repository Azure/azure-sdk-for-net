// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace ServiceBus.Tests.ScenarioTests
{
    using System;
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
        public void SubscriptionsCreateGetUpdateDelete()
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

                // Create Subscription.
                var subscriptionName = TestUtilities.GenerateName(ServiceBusManagementHelper.SubscritpitonPrefix);
                var createSubscriptionResponse = ServiceBusManagementClient.Subscriptions.CreateOrUpdate(resourceGroup, namespaceName, topicName, subscriptionName, new SubscriptionCreateOrUpdateParameters()
                {
                    Location = location               
                });
                Assert.NotNull(createSubscriptionResponse);
                Assert.Equal(createSubscriptionResponse.Name, subscriptionName);

                // Get Created Subscription
                var subscriptionGetResponse = ServiceBusManagementClient.Subscriptions.Get(resourceGroup, namespaceName, topicName, subscriptionName);
                Assert.NotNull(subscriptionGetResponse);
                Assert.Equal(EntityStatus.Active, subscriptionGetResponse.Status);
                Assert.Equal(subscriptionGetResponse.Name, subscriptionName);

                // Get all Subscriptions  
                var getSubscriptionsListAllResponse = ServiceBusManagementClient.Subscriptions.ListAll(resourceGroup, namespaceName,topicName);
                Assert.NotNull(getSubscriptionsListAllResponse);
                Assert.True(getSubscriptionsListAllResponse.Count() == 1);                
                Assert.True(getSubscriptionsListAllResponse.All(ns => ns.Id.Contains(resourceGroup)));

                // Update Subscription. 
                var updateSubscriptionParameter = new SubscriptionCreateOrUpdateParameters()
                {
                    Location = location,
                    EnableBatchedOperations = true
                };

                var updateSubscriptionsResponse = ServiceBusManagementClient.Subscriptions.CreateOrUpdate(resourceGroup, namespaceName, topicName,subscriptionName,updateSubscriptionParameter);
                Assert.NotNull(updateSubscriptionsResponse);
                Assert.True(updateSubscriptionsResponse.EnableBatchedOperations);
                Assert.NotEqual(updateSubscriptionsResponse.UpdatedAt, subscriptionGetResponse.UpdatedAt);

                // Get the updated subscription to check the Updated values. 
                var getSubscriptionsResponse = ServiceBusManagementClient.Subscriptions.Get(resourceGroup, namespaceName, topicName,subscriptionName);
                Assert.NotNull(getSubscriptionsResponse);
                Assert.Equal(EntityStatus.Active, getSubscriptionsResponse.Status);
                Assert.Equal(getSubscriptionsResponse.Name, subscriptionName);
                Assert.True(getSubscriptionsResponse.EnableBatchedOperations);
                Assert.NotEqual(getSubscriptionsResponse.UpdatedAt, createSubscriptionResponse.UpdatedAt);

                // Delete Created Subscription and check for the NotFound exception 
                ServiceBusManagementClient.Subscriptions.Delete(resourceGroup, namespaceName, topicName, subscriptionName);
                try
                {
                    var getSubscriptionResponse1 = ServiceBusManagementClient.Subscriptions.Get(resourceGroup, namespaceName, topicName,subscriptionName);                    
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound,ex.Response.StatusCode);
                }
                
                // Delete Created Topics  and check for the NotFound exception
                ServiceBusManagementClient.Topics.Delete(resourceGroup, namespaceName, topicName);
                try
                {
                    var getTopicsResponse1 = ServiceBusManagementClient.Topics.Get(resourceGroup, namespaceName, topicName);
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
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
