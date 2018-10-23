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
        const string AzureFunctionEndpointUrl = "https://eventgridrunnerfunction.azurewebsites.net/api/HttpTriggerCSharp1?code=<Hidden>";

        [Fact]
        public void EventSubscriptionCreateGetUpdateDelete()
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

                var createTopicResponse = this.EventGridManagementClient.Topics.CreateOrUpdateAsync(resourceGroup, topicName,
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
                string scope = $"/subscriptions/55f3dcd4-cac7-43b4-990b-a139d62a1eb2/resourceGroups/{resourceGroup}/providers/Microsoft.EventGrid/topics/{topicName}";

                var advFilters = new AdvancedFilter[]
                {
                    new StringContainsAdvancedFilter("topic", new[] { "runner" }),
                    new StringEndsWithAdvancedFilter("data.EventData", new[] { "Info" }),
                    new NumberInAdvancedFilter("data.key1", new List<double?> {1.0, 2.0, 3.0}),
                    new BoolEqualsAdvancedFilter("data.key2", true),
                    new StringContainsAdvancedFilter("dataversion", new[] { "3.0" }),
                };

                var expDate = DateTime.UtcNow.AddMinutes(2);

                EventSubscription eventSubscription = new EventSubscription()
                {
                    Destination = new WebHookEventSubscriptionDestination()
                    {
                        EndpointUrl = AzureFunctionEndpointUrl
                    },
                    ExpirationTimeUtc = expDate,
                    Filter = new EventSubscriptionFilter()
                    {
                        IncludedEventTypes = new List<string>() { "All" },
                        IsSubjectCaseSensitive = true,
                        SubjectBeginsWith = "TestPrefix",
                        SubjectEndsWith = "TestSuffix",
                        AdvancedFilters = advFilters
                    },
                    Labels = new List<string>()
                    {
                        "TestLabel1",
                        "TestLabel2"
                    }
                };

                var eventSubscriptionResponse = this.EventGridManagementClient.EventSubscriptions.CreateOrUpdateAsync(scope, eventSubscriptionName, eventSubscription).Result;
                Assert.NotNull(eventSubscriptionResponse);
                Assert.Equal(eventSubscriptionResponse.Name, eventSubscriptionName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Get the created event subscription
                eventSubscriptionResponse = EventGridManagementClient.EventSubscriptions.Get(scope, eventSubscriptionName);
                if (string.Compare(eventSubscriptionResponse.ProvisioningState, "Succeeded", true) != 0)
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));
                }

                eventSubscriptionResponse = EventGridManagementClient.EventSubscriptions.Get(scope, eventSubscriptionName);
                Assert.NotNull(eventSubscriptionResponse);
                Assert.Equal("Succeeded", eventSubscriptionResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal("TestPrefix", eventSubscriptionResponse.Filter.SubjectBeginsWith, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal("TestSuffix", eventSubscriptionResponse.Filter.SubjectEndsWith, StringComparer.CurrentCultureIgnoreCase);
                Assert.NotNull(eventSubscriptionResponse.Filter.AdvancedFilters);
                Assert.Equal(5, eventSubscriptionResponse.Filter.AdvancedFilters.Count);

                // Commented this out as this will fail in playback offline mode.
                // Assert.Equal(expDate, eventSubscriptionResponse.ExpirationTimeUtc);

                // Update the event subscription
                var eventSubscriptionUpdateParameters = new EventSubscriptionUpdateParameters()
                {
                    Destination = new WebHookEventSubscriptionDestination()
                    {
                        EndpointUrl = AzureFunctionEndpointUrl,
                    },
                    ExpirationTimeUtc = DateTime.UtcNow.AddMinutes(10),
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

                eventSubscriptionResponse = this.eventGridManagementClient.EventSubscriptions.UpdateAsync(scope, eventSubscriptionName, eventSubscriptionUpdateParameters).Result;
                Assert.Equal(".jpg", eventSubscriptionResponse.Filter.SubjectEndsWith, StringComparer.CurrentCultureIgnoreCase);
                Assert.Contains(eventSubscriptionResponse.Labels, label => label == "UpdatedLabel1");

                // List event subscriptions
                var eventSubscriptionsList = this.EventGridManagementClient.EventSubscriptions.ListRegionalByResourceGroupAsync(resourceGroup, location).Result;
                Assert.Contains(eventSubscriptionsList, es => es.Name == eventSubscriptionName);

                // Delete the event subscription
                EventGridManagementClient.EventSubscriptions.DeleteAsync(scope, eventSubscriptionName).Wait();

                // Delete the topic
                EventGridManagementClient.Topics.DeleteAsync(resourceGroup, topicName).Wait();
            }
        }

        [Fact]
        public void EventSubscriptionToAzureSubscriptionCreateGetUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                InitializeClients(context);

                // Create an event subscription to an Azure subscription
                var eventSubscriptionName = TestUtilities.GenerateName(EventGridManagementHelper.EventSubscriptionPrefix);

                string scope = $"/subscriptions/55f3dcd4-cac7-43b4-990b-a139d62a1eb2";

                var advFilters = new AdvancedFilter[]
                {
                    new StringContainsAdvancedFilter("topic", new[] { "runner" }),
                    new StringEndsWithAdvancedFilter("data.EventData", new[] { "Info" }),
                    new NumberInAdvancedFilter("data.key1", new List<double?> {1.0, 2.0, 3.0}),
                    new BoolEqualsAdvancedFilter("data.key2", true),
                    new StringContainsAdvancedFilter("dataversion", new[] { "3.0" }),
                };

                var expDate = DateTime.UtcNow.AddMinutes(2);

                EventSubscription eventSubscription = new EventSubscription()
                {
                    Destination = new WebHookEventSubscriptionDestination()
                    {
                        EndpointUrl = AzureFunctionEndpointUrl
                    },
                    ExpirationTimeUtc = expDate,
                    Filter = new EventSubscriptionFilter()
                    {
                        IncludedEventTypes = new List<string>() { "All" },
                        IsSubjectCaseSensitive = false,
                        SubjectBeginsWith = "TestPrefix",
                        SubjectEndsWith = "TestSuffix",
                        AdvancedFilters = advFilters
                    },
                    Labels = new List<string>()
                    {
                        "TestLabel1",
                        "TestLabel2"
                    }
                };
                var eventSubscriptionResponse = this.EventGridManagementClient.EventSubscriptions.CreateOrUpdateAsync(scope, eventSubscriptionName, eventSubscription).Result;

                Assert.NotNull(eventSubscriptionResponse);
                Assert.Equal(eventSubscriptionResponse.Name, eventSubscriptionName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Get the created event subscription
                eventSubscriptionResponse = EventGridManagementClient.EventSubscriptions.Get(scope, eventSubscriptionName);
                if (string.Compare(eventSubscriptionResponse.ProvisioningState, "Succeeded", true) != 0)
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));
                }

                eventSubscriptionResponse = EventGridManagementClient.EventSubscriptions.Get(scope, eventSubscriptionName);
                Assert.NotNull(eventSubscriptionResponse);
                Assert.Equal("Succeeded", eventSubscriptionResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.NotNull(eventSubscriptionResponse.Filter.AdvancedFilters);
                Assert.Equal(5, eventSubscriptionResponse.Filter.AdvancedFilters.Count);

                // Commented this out as this will fail in playback offline mode.
                // Assert.Equal(expDate, eventSubscriptionResponse.ExpirationTimeUtc);

                // List event subscriptions by Azure subscription
                var eventSubscriptionsList = this.EventGridManagementClient.EventSubscriptions.ListGlobalBySubscriptionAsync().Result;
                Assert.Contains(eventSubscriptionsList, es => es.Name == eventSubscriptionName);

                // Delete the event subscription
                EventGridManagementClient.EventSubscriptions.DeleteAsync(scope, eventSubscriptionName).Wait();
            }
        }

        [Fact]
        public void EventSubscriptionToResourceGroupCreateGetUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(EventGridManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                // Create an event subscription to a resource group
                var eventSubscriptionName = TestUtilities.GenerateName(EventGridManagementHelper.EventSubscriptionPrefix);

                string scope = $"/subscriptions/55f3dcd4-cac7-43b4-990b-a139d62a1eb2/resourceGroups/{resourceGroup}";

                var advFilters = new AdvancedFilter[]
                {
                    new StringContainsAdvancedFilter("topic", new[] { "runner" }),
                    new StringEndsWithAdvancedFilter("data.EventData", new[] { "Info" }),
                    new NumberInAdvancedFilter("data.key1", new List<double?> {1.0, 2.0, 3.0}),
                    new BoolEqualsAdvancedFilter("data.key2", true),
                    new StringContainsAdvancedFilter("dataversion", new[] { "3.0" }),
                };

                var expDate = DateTime.UtcNow.AddMinutes(2);

                EventSubscription eventSubscription = new EventSubscription()
                {
                    Destination = new WebHookEventSubscriptionDestination()
                    {
                        EndpointUrl = AzureFunctionEndpointUrl
                    },
                    ExpirationTimeUtc = expDate,
                    Filter = new EventSubscriptionFilter()
                    {
                        IncludedEventTypes = new List<string>() { "All" },
                        IsSubjectCaseSensitive = false,
                        SubjectBeginsWith = "TestPrefix",
                        SubjectEndsWith = "TestSuffix",
                        AdvancedFilters = advFilters
                    },
                    Labels = new List<string>()
                    {
                        "TestLabel1",
                        "TestLabel2"
                    }
                };
                var eventSubscriptionResponse = this.EventGridManagementClient.EventSubscriptions.CreateOrUpdateAsync(scope, eventSubscriptionName, eventSubscription).Result;

                Assert.NotNull(eventSubscriptionResponse);
                Assert.Equal(eventSubscriptionResponse.Name, eventSubscriptionName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Get the created event subscription
                eventSubscriptionResponse = EventGridManagementClient.EventSubscriptions.Get(scope, eventSubscriptionName);
                if (string.Compare(eventSubscriptionResponse.ProvisioningState, "Succeeded", true) != 0)
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));
                }

                eventSubscriptionResponse = EventGridManagementClient.EventSubscriptions.Get(scope, eventSubscriptionName);
                Assert.NotNull(eventSubscriptionResponse);
                Assert.Equal("Succeeded", eventSubscriptionResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.NotNull(eventSubscriptionResponse.Filter.AdvancedFilters);
                Assert.Equal(5, eventSubscriptionResponse.Filter.AdvancedFilters.Count);

                // Commented this out as this will fail in playback offline mode.
                // Assert.Equal(expDate, eventSubscriptionResponse.ExpirationTimeUtc);

                // List the event subscriptions by resource group
                var eventSubscriptionsList = this.EventGridManagementClient.EventSubscriptions.ListGlobalByResourceGroup(resourceGroup);
                Assert.Contains(eventSubscriptionsList, es => es.Name == eventSubscriptionName);

                // Delete the event subscription
                EventGridManagementClient.EventSubscriptions.DeleteAsync(scope, eventSubscriptionName).Wait();
            }
        }

        [Fact]
        public void EventSubscriptionCreateGetUpdateDeleteWithDeadLettering()
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

                var createTopicResponse = this.EventGridManagementClient.Topics.CreateOrUpdateAsync(resourceGroup, topicName,
                    new Topic()
                    {
                        Location = location
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
                string scope = $"/subscriptions/55f3dcd4-cac7-43b4-990b-a139d62a1eb2/resourceGroups/{resourceGroup}/providers/Microsoft.EventGrid/topics/{topicName}";
                var advFilters = new AdvancedFilter[]
                {
                    new StringContainsAdvancedFilter("topic", new[] { "runner" }),
                    new StringEndsWithAdvancedFilter("data.EventData", new[] { "Info" }),
                    new NumberInAdvancedFilter("data.key1", new List<double?> {1.0, 2.0, 3.0}),
                    new BoolEqualsAdvancedFilter("data.key2", true),
                    new StringContainsAdvancedFilter("dataversion", new[] { "3.0" }),
                };

                var expDate = DateTime.UtcNow.AddMinutes(2);

                EventSubscription eventSubscription = new EventSubscription()
                {
                    Destination = new WebHookEventSubscriptionDestination()
                    {
                        EndpointUrl = AzureFunctionEndpointUrl
                    },
                    ExpirationTimeUtc = expDate,
                    Filter = new EventSubscriptionFilter()
                    {
                        IncludedEventTypes = new List<string>() { "All" },
                        IsSubjectCaseSensitive = true,
                        SubjectBeginsWith = "TestPrefix",
                        SubjectEndsWith = "TestSuffix"
                    },
                    Labels = new List<string>()
                    {
                        "TestLabel1",
                        "TestLabel2"
                    },
                    DeadLetterDestination = new StorageBlobDeadLetterDestination()
                    {
                        ResourceId = "/subscriptions/55f3dcd4-cac7-43b4-990b-a139d62a1eb2/resourceGroups/kalstest/providers/Microsoft.Storage/storageAccounts/kalsdemo",
                        BlobContainerName = "dlq"
                    },
                    EventDeliverySchema = EventDeliverySchema.CloudEventV01Schema,
                    RetryPolicy = new RetryPolicy()
                    {
                        EventTimeToLiveInMinutes = 20,
                        MaxDeliveryAttempts = 10
                    }
                };

                var eventSubscriptionResponse = this.EventGridManagementClient.EventSubscriptions.CreateOrUpdateAsync(scope, eventSubscriptionName, eventSubscription).Result;
                Assert.NotNull(eventSubscriptionResponse);
                Assert.Equal(eventSubscriptionResponse.Name, eventSubscriptionName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Get the created event subscription
                eventSubscriptionResponse = EventGridManagementClient.EventSubscriptions.Get(scope, eventSubscriptionName);
                if (string.Compare(eventSubscriptionResponse.ProvisioningState, "Succeeded", true) != 0)
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));
                }

                eventSubscriptionResponse = EventGridManagementClient.EventSubscriptions.Get(scope, eventSubscriptionName);
                Assert.NotNull(eventSubscriptionResponse);
                Assert.Equal("Succeeded", eventSubscriptionResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal("TestPrefix", eventSubscriptionResponse.Filter.SubjectBeginsWith, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal("TestSuffix", eventSubscriptionResponse.Filter.SubjectEndsWith, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(EventDeliverySchema.CloudEventV01Schema, eventSubscriptionResponse.EventDeliverySchema, StringComparer.CurrentCultureIgnoreCase);

                // Commented this out as this will fail in playback offline mode.
                // Assert.Equal(expDate, eventSubscriptionResponse.ExpirationTimeUtc);

                // Delete the event subscription
                EventGridManagementClient.EventSubscriptions.DeleteAsync(scope, eventSubscriptionName).Wait();

                // Delete the topic
                EventGridManagementClient.Topics.DeleteAsync(resourceGroup, topicName).Wait();
            }
        }
    }
}
