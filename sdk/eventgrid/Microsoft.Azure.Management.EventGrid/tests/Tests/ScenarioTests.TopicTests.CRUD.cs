// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.EventGrid;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Rest.Azure;
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
            using (MockContext context = MockContext.Start(this.GetType()))
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
                    Tags = originalTagsDictionary,
                    InputSchema = InputSchema.CustomEventSchema,
                    InputSchemaMapping = new JsonInputSchemaMapping()
                    {
                        Subject = new JsonFieldWithDefault("mySubjectField"),
                        Topic = new JsonField("myTopicField"),
                        DataVersion = new JsonFieldWithDefault(sourceField: null, defaultValue: "2"),
                        EventType = new JsonFieldWithDefault("MyEventTypeField"),
                        EventTime = new JsonField("MyEventTimeField"),
                        Id = new JsonField("MyIDFIELD")
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
                Assert.Contains(getTopicResponse.Tags, tag => tag.Key == "originalTag1");

                //// Disable the test as Sku is not part of GA API yet.
                //// Assert.Equal("Basic", getTopicResponse.Sku.Name, StringComparer.CurrentCultureIgnoreCase);

                //// Disable the test as Identity is not part of GA API yet.
                //// Assert.Null(getTopicResponse.Identity);
                Assert.Null(getTopicResponse.InboundIpRules);

                // Get all topics created within a resourceGroup
                IPage<Topic> topicsInResourceGroupPage = this.EventGridManagementClient.Topics.ListByResourceGroupAsync(resourceGroup).Result;
                var topicsInResourceGroupList = new List<Topic>();
                if (topicsInResourceGroupPage.Any())
                {
                    topicsInResourceGroupList.AddRange(topicsInResourceGroupPage);
                    var nextLink = topicsInResourceGroupPage.NextPageLink;
                    while (nextLink != null)
                    {
                        topicsInResourceGroupPage = this.EventGridManagementClient.Topics.ListByResourceGroupNextAsync(nextLink).Result;
                        topicsInResourceGroupList.AddRange(topicsInResourceGroupPage);
                        nextLink = topicsInResourceGroupPage.NextPageLink;
                    }
                }

                Assert.NotNull(topicsInResourceGroupList);
                Assert.True(topicsInResourceGroupList.Count() >= 1);
                Assert.Contains(topicsInResourceGroupList, t => t.Name == topicName);
                Assert.True(topicsInResourceGroupList.All(ns => ns.Id.Contains(resourceGroup)));

                IPage<Topic> topicsInResourceGroupPageWithTop = this.EventGridManagementClient.Topics.ListByResourceGroupAsync(resourceGroup, null, 5).Result;
                var topicsInResourceGroupListWithTop = new List<Topic>();
                if (topicsInResourceGroupPageWithTop.Any())
                {
                    topicsInResourceGroupListWithTop.AddRange(topicsInResourceGroupPageWithTop);
                    var nextLink = topicsInResourceGroupPageWithTop.NextPageLink;
                    while (nextLink != null)
                    {
                        topicsInResourceGroupPageWithTop = this.EventGridManagementClient.Topics.ListByResourceGroupNextAsync(nextLink).Result;
                        topicsInResourceGroupListWithTop.AddRange(topicsInResourceGroupPageWithTop);
                        nextLink = topicsInResourceGroupPageWithTop.NextPageLink;
                    }
                }

                Assert.NotNull(topicsInResourceGroupListWithTop);
                Assert.True(topicsInResourceGroupListWithTop.Count() >= 1);
                Assert.Contains(topicsInResourceGroupListWithTop, t => t.Name == topicName);
                Assert.True(topicsInResourceGroupListWithTop.All(ns => ns.Id.Contains(resourceGroup)));

                // Get all topics created within the subscription irrespective of the resourceGroup
                IPage<Topic> topicsInAzureSubscription = this.EventGridManagementClient.Topics.ListBySubscriptionAsync(null, 100).Result;
                var topicsInAzureSubscriptionList = new List<Topic>();
                if (topicsInAzureSubscription.Any())
                {
                    topicsInAzureSubscriptionList.AddRange(topicsInAzureSubscription);
                    var nextLink = topicsInAzureSubscription.NextPageLink;
                    while (nextLink != null)
                    {
                        try
                        {
                            topicsInAzureSubscription = this.EventGridManagementClient.Topics.ListBySubscriptionNextAsync(nextLink).Result;
                            topicsInAzureSubscriptionList.AddRange(topicsInAzureSubscription);
                            nextLink = topicsInAzureSubscription.NextPageLink;
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex);
                            break;
                        }
                    }
                }

                Assert.NotNull(topicsInAzureSubscriptionList);
                Assert.True(topicsInAzureSubscriptionList.Count() >= 1);
                Assert.Contains(topicsInAzureSubscriptionList, t => t.Name == topicName);

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

                // Update the topic with tags & allow traffic from all ips
                TopicUpdateParameters topicUpdateParameters = new TopicUpdateParameters();
                topicUpdateParameters.Tags = new Dictionary<string, string>()
                {
                    { "updatedTag1", "updatedValue1" },
                    { "updatedTag2", "updatedValue2" }
                };
                topic.PublicNetworkAccess = PublicNetworkAccess.Enabled;
                var updateTopicResponse = this.EventGridManagementClient.Topics.UpdateAsync(resourceGroup, topicName, topicUpdateParameters).Result;
                Assert.Contains(updateTopicResponse.Tags, tag => tag.Key == "updatedTag1");
                Assert.DoesNotContain(updateTopicResponse.Tags, tag => tag.Key == "replacedTag1");
                Assert.True(updateTopicResponse.PublicNetworkAccess == PublicNetworkAccess.Enabled);
                Assert.Null(updateTopicResponse.InboundIpRules);

                // Update the Topic with IP filtering feature
                topic.PublicNetworkAccess = PublicNetworkAccess.Disabled;
                topic.InboundIpRules = new List<InboundIpRule>();
                topic.InboundIpRules.Add(new InboundIpRule() { Action = IpActionType.Allow, IpMask = "12.35.67.98" });
                topic.InboundIpRules.Add(new InboundIpRule() { Action = IpActionType.Allow, IpMask = "12.35.90.100" });
                var updateTopicResponseWithIpFilteringFeature = this.EventGridManagementClient.Topics.CreateOrUpdateAsync(resourceGroup, topicName, topic).Result;
                Assert.False(updateTopicResponseWithIpFilteringFeature.PublicNetworkAccess == PublicNetworkAccess.Enabled);
                Assert.True(updateTopicResponseWithIpFilteringFeature.InboundIpRules.Count() == 2);

                // Delete topic
                this.EventGridManagementClient.Topics.DeleteAsync(resourceGroup, topicName).Wait();
            }
        }
    }
}