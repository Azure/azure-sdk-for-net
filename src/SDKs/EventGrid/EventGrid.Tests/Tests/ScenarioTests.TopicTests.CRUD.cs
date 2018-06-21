// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.EventGrid;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using EventGrid.Tests.TestHelper;
using Xunit;

namespace EventGrid.Tests.ScenarioTests
{
    public partial class ScenarioTests
    {
        [Fact]
        public void TopicCreateGetUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(EventGridManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                var topicName = TestUtilities.GenerateName(EventGridManagementHelper.TopicPrefix);

                var operationsResponse = this.EventGridManagementClient.Operations.List();

                Topic topic = new Topic()
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                    {
                        { "tag1", "value1" },
                        { "tag2", "value2" }
                    }
                };

                var createTopicResponse = this.EventGridManagementClient.Topics.CreateOrUpdateAsync(resourceGroup, topicName, topic).Result;

                Assert.NotNull(createTopicResponse);
                Assert.Equal(createTopicResponse.Name, topicName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Get the created topic
                var getTopicResponse = this.EventGridManagementClient.Topics.Get(resourceGroup, topicName);
                if (string.Compare(getTopicResponse.ProvisioningState, "Succeeded", true) != 0)
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));
                }

                getTopicResponse = this.EventGridManagementClient.Topics.Get(resourceGroup, topicName);
                Assert.NotNull(getTopicResponse);
                Assert.Equal("Succeeded", getTopicResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(location, getTopicResponse.Location, StringComparer.CurrentCultureIgnoreCase);
                Assert.Contains(getTopicResponse.Tags, tag => tag.Key == "tag1");

                // Get all topics created within a resourceGroup
                var getAllTopicsResponse = this.EventGridManagementClient.Topics.ListByResourceGroupAsync(resourceGroup).Result;
                Assert.NotNull(getAllTopicsResponse);
                Assert.True(getAllTopicsResponse.Count() >= 1);
                Assert.Contains(getAllTopicsResponse, t => t.Name == topicName);
                Assert.True(getAllTopicsResponse.All(ns => ns.Id.Contains(resourceGroup)));

                // Get all topics created within the subscription irrespective of the resourceGroup
                getAllTopicsResponse = this.EventGridManagementClient.Topics.ListBySubscriptionAsync().Result;
                Assert.NotNull(getAllTopicsResponse);
                Assert.True(getAllTopicsResponse.Count() >= 1);
                Assert.Contains(getAllTopicsResponse, t => t.Name == topicName);

                // Update the topic
                topic.Tags = new Dictionary<string, string>()
                {
                    { "newTag1", "value1" },
                    { "newTag2", "value2"}
                };

                var updateTopicResponse = this.EventGridManagementClient.Topics.CreateOrUpdateAsync(resourceGroup, topicName, topic).Result;

                // TODO: Uncomment the below lines after the Tags update bug is resolved.
                // Assert.Contains(getTopicResponse.Tags, tag => tag.Key == "newTag1");
                // Assert.DoesNotContain(getTopicResponse.Tags, tag => tag.Key == "tag1");

                // Delete topic
                EventGridManagementClient.Topics.DeleteAsync(resourceGroup, topicName).Wait();
            }
        }
    }
}
