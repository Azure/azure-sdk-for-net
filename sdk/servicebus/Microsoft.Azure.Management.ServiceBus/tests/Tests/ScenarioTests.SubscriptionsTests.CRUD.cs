﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
    using System.Threading;
    public partial class ScenarioTests 
    {
        [Fact]
        public void SubscriptionsCreateGetUpdateDelete()
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

                // Create a Topic
                var topicName = TestUtilities.GenerateName(ServiceBusManagementHelper.TopicPrefix);

                var createTopicResponse = this.ServiceBusManagementClient.Topics.CreateOrUpdate(resourceGroup, namespaceName, topicName,
                new SBTopic() { EnablePartitioning = true });
                Assert.NotNull(createTopicResponse);
                Assert.Equal(createTopicResponse.Name, topicName);

                // Get the created topic
                var getTopicResponse = ServiceBusManagementClient.Topics.Get(resourceGroup, namespaceName, topicName);
                Assert.NotNull(getTopicResponse);
                Assert.Equal(EntityStatus.Active, getTopicResponse.Status);
                Assert.Equal(getTopicResponse.Name, topicName);

                // Create Subscription.
                var subscriptionName = TestUtilities.GenerateName(ServiceBusManagementHelper.SubscritpitonPrefix);
                SBSubscription createSub = new SBSubscription();

                createSub.EnableBatchedOperations = true;
                createSub.LockDuration = TimeSpan.Parse("00:03:00");
                createSub.DefaultMessageTimeToLive = TimeSpan.Parse("00:05:00");
                createSub.DeadLetteringOnMessageExpiration = true;
                createSub.MaxDeliveryCount = 14;
                createSub.Status = EntityStatus.Active;
                createSub.AutoDeleteOnIdle = TimeSpan.Parse("00:07:00");
                createSub.DeadLetteringOnFilterEvaluationExceptions = true;

                var createSubscriptionResponse = ServiceBusManagementClient.Subscriptions.CreateOrUpdate(resourceGroup, namespaceName, topicName, subscriptionName, createSub);
                Assert.NotNull(createSubscriptionResponse);
                Assert.Equal(createSubscriptionResponse.Name, subscriptionName);

                // Get Created Subscription
                var subscriptionGetResponse = ServiceBusManagementClient.Subscriptions.Get(resourceGroup, namespaceName, topicName, subscriptionName);
                Assert.NotNull(subscriptionGetResponse);
                Assert.Equal(EntityStatus.Active, subscriptionGetResponse.Status);
                Assert.Equal(subscriptionGetResponse.Name, subscriptionName);

                // Get all Subscriptions  
                var getSubscriptionsListAllResponse = ServiceBusManagementClient.Subscriptions.ListByTopic(resourceGroup, namespaceName,topicName);
                Assert.NotNull(getSubscriptionsListAllResponse);
                Assert.True(getSubscriptionsListAllResponse.Count() == 1);                
                Assert.True(getSubscriptionsListAllResponse.All(ns => ns.Id.Contains(resourceGroup)));


                // Create a Topic for Auto Forward
                var topicName1 = TestUtilities.GenerateName(ServiceBusManagementHelper.TopicPrefix);

                var createTopicResponse1 = this.ServiceBusManagementClient.Topics.CreateOrUpdate(resourceGroup, namespaceName, topicName1,
                new SBTopic() { EnablePartitioning = true });
                Assert.NotNull(createTopicResponse);
                Assert.Equal(createTopicResponse1.Name, topicName1);

                // Update Subscription. 
                var updateSubscriptionParameter = new SBSubscription() {
                    EnableBatchedOperations = true,
                    DeadLetteringOnMessageExpiration = true,
                    ForwardDeadLetteredMessagesTo = topicName1,
                    ForwardTo = topicName1
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

                // Delete Created Subscription
                ServiceBusManagementClient.Subscriptions.Delete(resourceGroup, namespaceName, topicName, subscriptionName);
                
                // Delete Created Topics
                ServiceBusManagementClient.Topics.Delete(resourceGroup, namespaceName, topicName);

                //Delete Namespace Async
                ServiceBusManagementClient.Namespaces.DeleteWithHttpMessagesAsync(resourceGroup, namespaceName, null, new CancellationToken()).ConfigureAwait(false);
            }
        }
    }
}
