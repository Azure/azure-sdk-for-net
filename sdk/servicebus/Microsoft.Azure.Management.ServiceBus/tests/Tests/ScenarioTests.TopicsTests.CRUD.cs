// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace ServiceBus.Tests.ScenarioTests
{
    using System;
    using System.Linq;
    using System.Threading;
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
                var standardNamespaceName = TestUtilities.GenerateName(ServiceBusManagementHelper.NamespacePrefix);

                var createNamespaceResponse = this.ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new SBNamespace()
                    {
                        Location = location,
                        Sku = new SBSku
                        {
                            Name = SkuName.Premium,
                            Tier = SkuTier.Premium
                        }
                    });

                var standardNamespaceResponse = this.ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, standardNamespaceName,
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

                Assert.NotNull(standardNamespaceResponse);
                Assert.Equal(standardNamespaceResponse.Name, standardNamespaceName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));
                
                // Create a Topic
                var topicName = TestUtilities.GenerateName(ServiceBusManagementHelper.TopicPrefix);
                var createTopicResponse = this.ServiceBusManagementClient.Topics.CreateOrUpdate(resourceGroup, namespaceName, topicName,
                new SBTopic() { MaxMessageSizeInKilobytes = 14336 });
                Assert.NotNull(createTopicResponse);
                Assert.Equal(createTopicResponse.Name, topicName);
                Assert.Equal(14336, createTopicResponse.MaxMessageSizeInKilobytes);

                // Get the created topic
                var getTopicResponse = ServiceBusManagementClient.Topics.Get(resourceGroup, namespaceName, topicName);
                Assert.NotNull(getTopicResponse);
                Assert.Equal(EntityStatus.Active, getTopicResponse.Status);
                Assert.Equal(getTopicResponse.Name, topicName);
                                
                // Get all Topics   
                var getTopicsListAllResponse = ServiceBusManagementClient.Topics.ListByNamespace(resourceGroup, namespaceName);
                Assert.NotNull(getTopicsListAllResponse);
                Assert.True(getTopicsListAllResponse.Count() >= 1);                
                Assert.True(getTopicsListAllResponse.All(ns => ns.Id.Contains(resourceGroup)));

                // Update Topic
                getTopicResponse.MaxMessageSizeInKilobytes = 13312;

                var updateTopicsResponse = ServiceBusManagementClient.Topics.CreateOrUpdate(resourceGroup, namespaceName, topicName, getTopicResponse);
                Assert.NotNull(updateTopicsResponse);
                Assert.NotEqual(updateTopicsResponse.UpdatedAt, getTopicResponse.UpdatedAt);
                Assert.Equal(13312, updateTopicsResponse.MaxMessageSizeInKilobytes);

                // Get the created topic to check the Updated values. 
                getTopicResponse = ServiceBusManagementClient.Topics.Get(resourceGroup, namespaceName, topicName);
                Assert.NotNull(getTopicResponse);
                Assert.Equal(EntityStatus.Active, getTopicResponse.Status);
                Assert.Equal(getTopicResponse.Name, topicName);
                Assert.NotEqual(updateTopicsResponse.UpdatedAt, getTopicResponse.UpdatedAt);

                // Delete Created Topics 
                ServiceBusManagementClient.Topics.Delete(resourceGroup, namespaceName, topicName);
                
                var secondTopicName = TestUtilities.GenerateName(ServiceBusManagementHelper.TopicPrefix);

                var secondTopicResponse = ServiceBusManagementClient.Topics.CreateOrUpdate(resourceGroup, namespaceName, secondTopicName, new SBTopic()
                {
                    DefaultMessageTimeToLive = new TimeSpan(365, 0, 0, 0),
                    AutoDeleteOnIdle = new TimeSpan(428, 3, 11, 2),
                    DuplicateDetectionHistoryTimeWindow = new TimeSpan(1, 0, 3, 4),
                    EnableBatchedOperations = true,
                    RequiresDuplicateDetection = true,
                    SupportOrdering = true
                });

                Assert.Equal(new TimeSpan(365, 0, 0, 0), secondTopicResponse.DefaultMessageTimeToLive);
                Assert.Equal(new TimeSpan(428, 3, 11, 2), secondTopicResponse.AutoDeleteOnIdle);
                Assert.Equal(new TimeSpan(1, 0, 3, 4), secondTopicResponse.DuplicateDetectionHistoryTimeWindow);
                Assert.True(secondTopicResponse.EnableBatchedOperations);
                Assert.True(secondTopicResponse.RequiresDuplicateDetection);
                Assert.True(secondTopicResponse.SupportOrdering);

                var thirdTopicName = TestUtilities.GenerateName(ServiceBusManagementHelper.TopicPrefix);

                var thirdTopicResponse = ServiceBusManagementClient.Topics.CreateOrUpdate(resourceGroup, namespaceName, thirdTopicName, new SBTopic()
                {
                    MaxMessageSizeInKilobytes = 102400,
                    MaxSizeInMegabytes = 81920
                });

                Assert.Equal(102400, thirdTopicResponse.MaxMessageSizeInKilobytes);
                Assert.Equal(81920, thirdTopicResponse.MaxSizeInMegabytes);

                var standardTopicName = TestUtilities.GenerateName(ServiceBusManagementHelper.TopicPrefix);

                var standardTopicResponse = ServiceBusManagementClient.Topics.CreateOrUpdate(resourceGroup, standardNamespaceName, standardTopicName, new SBTopic()
                    {
                        EnablePartitioning = true
                    }
                );

                Assert.True(standardTopicResponse.EnablePartitioning);

                var listOfTopics = ServiceBusManagementClient.Topics.ListByNamespace(resourceGroup, namespaceName);

                Assert.Equal(2, listOfTopics.Count());

                // Delete namespace                                   
                ServiceBusManagementClient.Namespaces.DeleteWithHttpMessagesAsync(resourceGroup, namespaceName, null, new CancellationToken()).ConfigureAwait(false);
                ServiceBusManagementClient.Namespaces.DeleteWithHttpMessagesAsync(resourceGroup, standardNamespaceName, null, new CancellationToken()).ConfigureAwait(false);
            }
        }
    }
}
