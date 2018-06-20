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

                // Temporarily commenting this out as this is not yet enabled for the new API version
                // var operationsResponse = this.EventGridManagementClient.Operations.List();

                var originalTagsDictionary = new Dictionary<string, string>()
                {
                    {"originalTag1", "originalValue1"},
                    {"originalTag2", "originalValue2"}
                };

                Topic topic = new Topic()
                {
                    Location = location,
                    Tags = originalTagsDictionary
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
                Assert.Contains(getTopicResponse.Tags, tag => tag.Key == "originalTag1");

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

                var replaceTopicTagsDictionary = new Dictionary<string, string>()
                {
                    { "replacedTag1", "replacedValue1" },
                    { "replacedTag2", "replacedValue2" }
                };

                // Replace the topic
                topic.Tags = replaceTopicTagsDictionary;
                var replaceTopicResponse = this.EventGridManagementClient.Topics.CreateOrUpdateAsync(resourceGroup, topicName, topic).Result;

                Assert.Contains(replaceTopicResponse.Tags, tag => tag.Key == "replacedTag1");
                Assert.DoesNotContain(replaceTopicResponse.Tags, tag => tag.Key == "originalTag1");

                // Update the topic
                var updateTopicTagsDictionary = new Dictionary<string, string>()
                {
                    { "updatedTag1", "updatedValue1" },
                    { "updatedTag2", "updatedValue2" }
                };

                var updateTopicResponse = this.EventGridManagementClient.Topics.UpdateAsync(resourceGroup, topicName, updateTopicTagsDictionary).Result;
                Assert.Contains(updateTopicResponse.Tags, tag => tag.Key == "updatedTag1");
                Assert.DoesNotContain(updateTopicResponse.Tags, tag => tag.Key == "replacedTag1");

                // Delete topic
                this.EventGridManagementClient.Topics.DeleteAsync(resourceGroup, topicName).Wait();
            }
        }

        [Fact]
        public void TopicCreateGetUpdateDeleteWithCustomInputMappings()
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

                Topic topic = new Topic()
                {
                    Location = location,
                    InputSchema = InputSchema.CustomEventSchema,
                    InputSchemaMapping = new JsonInputSchemaMapping()
                    {
                        Id = new JsonField()
                        {
                            SourceField = "myid"
                        },
                        Subject = new JsonFieldWithDefault()
                        {
                            SourceField = "mysubject",
                            DefaultValue = "defaultvalue"
                        },
                        DataVersion = new JsonFieldWithDefault()
                        {
                            DefaultValue = "2.0"
                        },
                        EventTime = new JsonField()
                        {
                            SourceField = "myeventTime"
                        },
                        EventType = new JsonFieldWithDefault()
                        {
                            SourceField = "myeventtype",
                            DefaultValue = "defaultvalue"
                        }
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
                Assert.Equal(createTopicResponse.InputSchema, InputSchema.CustomEventSchema);
                Assert.NotNull(createTopicResponse.InputSchemaMapping);

                // Delete topic
                this.EventGridManagementClient.Topics.DeleteAsync(resourceGroup, topicName).Wait();
            }
        }


        [Fact]
        public void TopicCreateGetUpdateDeleteWithCloudEvent()
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

                Topic topic = new Topic()
                {
                    Location = location,
                    InputSchema = InputSchema.CloudEventV01Schema
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
                Assert.Equal(createTopicResponse.InputSchema, InputSchema.CloudEventV01Schema);
                Assert.Null(createTopicResponse.InputSchemaMapping);

                // Delete topic
                this.EventGridManagementClient.Topics.DeleteAsync(resourceGroup, topicName).Wait();
            }
        }
    }
}
