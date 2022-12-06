// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
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
        public void TopicEventSubscriptionCreateGetUpdateDelete()
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
                var createTopicResponse = EventGridManagementClient.Topics.CreateOrUpdateAsync(resourceGroup, topicName,
                    new Topic()
                    {
                        Location = location,
                        Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        }
                    }).Result;

                Assert.NotNull(createTopicResponse);
                Assert.Equal(createTopicResponse.Name, topicName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Get the created topic
                var getTopicResponse = EventGridManagementClient.Topics.Get(resourceGroup, topicName);
                if (string.Compare(getTopicResponse.ProvisioningState, "Succeeded", true) != 0)
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));
                }

                getTopicResponse = EventGridManagementClient.Topics.Get(resourceGroup, topicName);
                Assert.NotNull(getTopicResponse);
                Assert.Equal("Succeeded", getTopicResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(location, getTopicResponse.Location, StringComparer.CurrentCultureIgnoreCase);

                // Create an event subscription to this topic
                var eventSubscriptionName = TestUtilities.GenerateName(EventGridManagementHelper.EventSubscriptionPrefix);
                EventSubscription eventSubscription = new EventSubscription()
                {
                    Destination = new WebHookEventSubscriptionDestination()
                    {
                        EndpointUrl = AzureFunctionEndpointUrl
                    },
                    Filter = new EventSubscriptionFilter()
                    {
                        IncludedEventTypes = null,
                        IsSubjectCaseSensitive = true,
                        SubjectBeginsWith = "TestPrefix",
                        SubjectEndsWith = "TestSuffix"
                    },
                    Labels = new List<string>()
                    {
                        "TestLabel1",
                        "TestLabel2"
                    }
                };

                var eventSubscriptionResponse = EventGridManagementClient.TopicEventSubscriptions.CreateOrUpdateAsync(resourceGroup, topicName, eventSubscriptionName, eventSubscription).Result;
                Assert.NotNull(eventSubscriptionResponse);
                Assert.Equal(eventSubscriptionResponse.Name, eventSubscriptionName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Get the created event subscription
                eventSubscriptionResponse = EventGridManagementClient.TopicEventSubscriptions.Get(resourceGroup, topicName, eventSubscriptionName);
                if (string.Compare(eventSubscriptionResponse.ProvisioningState, "Succeeded", true) != 0)
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));
                }

                eventSubscriptionResponse = EventGridManagementClient.TopicEventSubscriptions.Get(resourceGroup, topicName, eventSubscriptionName);
                Assert.NotNull(eventSubscriptionResponse);
                Assert.Equal("Succeeded", eventSubscriptionResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal("TestPrefix", eventSubscriptionResponse.Filter.SubjectBeginsWith, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal("TestSuffix", eventSubscriptionResponse.Filter.SubjectEndsWith, StringComparer.CurrentCultureIgnoreCase);

                // Update the event subscription
                var eventSubscriptionUpdateParameters = new EventSubscriptionUpdateParameters()
                {
                    Destination = new WebHookEventSubscriptionDestination()
                    {
                        EndpointUrl = AzureFunctionEndpointUrl,
                    },
                    Filter = new EventSubscriptionFilter()
                    {
                        IncludedEventTypes = new List<string>()
                        {
                            "Event1",
                            "Event2"
                        },
                        SubjectEndsWith = ".jpg",
                        SubjectBeginsWith = "TestPrefix"
                    },
                    Labels = new List<string>()
                    {
                        "UpdatedLabel1",
                        "UpdatedLabel2",
                    }
                };

                eventSubscriptionResponse = EventGridManagementClient.TopicEventSubscriptions.UpdateAsync(resourceGroup, topicName, eventSubscriptionName, eventSubscriptionUpdateParameters).Result;
                Assert.Equal(".jpg", eventSubscriptionResponse.Filter.SubjectEndsWith, StringComparer.CurrentCultureIgnoreCase);
                Assert.Contains(eventSubscriptionResponse.Labels, label => label == "UpdatedLabel1");

                // Test getting full URL and delivery attributes
                var fullUrlResponse = EventGridManagementClient.TopicEventSubscriptions.GetFullUrlAsync(resourceGroup, topicName, eventSubscriptionName).Result;
                Assert.NotNull(fullUrlResponse);
                Assert.NotNull(fullUrlResponse.EndpointUrl);

                var deliveryAttributesResponse = EventGridManagementClient.TopicEventSubscriptions.GetDeliveryAttributesAsync(resourceGroup, topicName, eventSubscriptionName).Result;
                Assert.NotNull(deliveryAttributesResponse);

                // List topic event subscriptions
                var listTopicEventSubscriptionsResponse = EventGridManagementClient.TopicEventSubscriptions.List(resourceGroup, topicName);
                Assert.NotNull(listTopicEventSubscriptionsResponse);
                Assert.True(listTopicEventSubscriptionsResponse.IsAny());

                // Delete the event subscription
                EventGridManagementClient.TopicEventSubscriptions.DeleteAsync(resourceGroup, topicName, eventSubscriptionName).Wait();

                // Delete the topic
                EventGridManagementClient.Topics.DeleteAsync(resourceGroup, topicName).Wait();
            }
        }
    }
}