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
        public void DomainEventSubscriptionCreateGetUpdateDelete()
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

                var domainName = TestUtilities.GenerateName(EventGridManagementHelper.DomainPrefix);
                var domainTopicName = TestUtilities.GenerateName(EventGridManagementHelper.DomainTopicPrefix);

                var createDomainResponse = this.EventGridManagementClient.Domains.CreateOrUpdateAsync(resourceGroup, domainName,
                    new Domain()
                    {
                        Location = location,
                        Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        }
                    }).Result;

                Assert.NotNull(createDomainResponse);
                Assert.Equal(createDomainResponse.Name, domainName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Get the created domain
                var getDomainResponse = EventGridManagementClient.Domains.Get(resourceGroup, domainName);
                if (string.Compare(getDomainResponse.ProvisioningState, "Succeeded", true) != 0)
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));
                }

                getDomainResponse = EventGridManagementClient.Domains.Get(resourceGroup, domainName);
                Assert.NotNull(getDomainResponse);
                Assert.Equal("Succeeded", getDomainResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(location, getDomainResponse.Location, StringComparer.CurrentCultureIgnoreCase);

                // Create an event subscription to this domain
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

                var eventSubscriptionResponse = EventGridManagementClient.DomainEventSubscriptions.CreateOrUpdateAsync(resourceGroup, domainName, eventSubscriptionName, eventSubscription).Result;
                Assert.NotNull(eventSubscriptionResponse);
                Assert.Equal(eventSubscriptionResponse.Name, eventSubscriptionName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Get the created event subscription
                eventSubscriptionResponse = EventGridManagementClient.DomainEventSubscriptions.Get(resourceGroup, domainName, eventSubscriptionName);
                if (string.Compare(eventSubscriptionResponse.ProvisioningState, "Succeeded", true) != 0)
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));
                }

                eventSubscriptionResponse = EventGridManagementClient.DomainEventSubscriptions.Get(resourceGroup, domainName, eventSubscriptionName);
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

                eventSubscriptionResponse = EventGridManagementClient.DomainEventSubscriptions.UpdateAsync(resourceGroup, domainName, eventSubscriptionName, eventSubscriptionUpdateParameters).Result;
                Assert.Equal(".jpg", eventSubscriptionResponse.Filter.SubjectEndsWith, StringComparer.CurrentCultureIgnoreCase);
                Assert.Contains(eventSubscriptionResponse.Labels, label => label == "UpdatedLabel1");

                // Test getting full URL and delivery attributes
                var fullUrlResponse = EventGridManagementClient.DomainEventSubscriptions.GetFullUrlAsync(resourceGroup, domainName, eventSubscriptionName).Result;
                Assert.NotNull(fullUrlResponse);
                Assert.NotNull(fullUrlResponse.EndpointUrl);

                var deliveryAttributesResponse = EventGridManagementClient.DomainEventSubscriptions.GetDeliveryAttributesAsync(resourceGroup, domainName, eventSubscriptionName).Result;
                Assert.NotNull(deliveryAttributesResponse);

                // List domain event subscriptions
                var listDomainEventSubscriptionsResponse = this.EventGridManagementClient.DomainEventSubscriptions.List(resourceGroup, domainName);
                Assert.NotNull(listDomainEventSubscriptionsResponse);
                Assert.True(listDomainEventSubscriptionsResponse.IsAny());

                // Delete the event subscription
                EventGridManagementClient.DomainEventSubscriptions.DeleteAsync(resourceGroup, domainName, eventSubscriptionName).Wait();

                // Create an event subscription to a domain topic scope
                eventSubscriptionName = TestUtilities.GenerateName(EventGridManagementHelper.EventSubscriptionPrefix);
                eventSubscription = new EventSubscription()
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

                eventSubscriptionResponse = EventGridManagementClient.DomainTopicEventSubscriptions.CreateOrUpdateAsync(resourceGroup, domainName, domainTopicName, eventSubscriptionName, eventSubscription).Result;
                Assert.NotNull(eventSubscriptionResponse);
                Assert.Equal(eventSubscriptionResponse.Name, eventSubscriptionName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Get the created event subscription
                eventSubscriptionResponse = EventGridManagementClient.DomainTopicEventSubscriptions.Get(resourceGroup, domainName, domainTopicName, eventSubscriptionName);
                if (string.Compare(eventSubscriptionResponse.ProvisioningState, "Succeeded", true) != 0)
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));
                }

                eventSubscriptionResponse = EventGridManagementClient.DomainTopicEventSubscriptions.Get(resourceGroup, domainName, domainTopicName, eventSubscriptionName);
                Assert.NotNull(eventSubscriptionResponse);
                Assert.Equal("Succeeded", eventSubscriptionResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal("TestPrefix", eventSubscriptionResponse.Filter.SubjectBeginsWith, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal("TestSuffix", eventSubscriptionResponse.Filter.SubjectEndsWith, StringComparer.CurrentCultureIgnoreCase);

                // List domain topic event subscriptions
                var listDomainTopicEventSubscriptionsResponse = this.EventGridManagementClient.DomainTopicEventSubscriptions.List(resourceGroup, domainName, domainTopicName);
                Assert.NotNull(listDomainTopicEventSubscriptionsResponse);
                Assert.True(listDomainTopicEventSubscriptionsResponse.IsAny());

                // Test getting full URL and delivery attributes
                fullUrlResponse = EventGridManagementClient.DomainTopicEventSubscriptions.GetFullUrlAsync(resourceGroup, domainName, domainTopicName, eventSubscriptionName).Result;
                Assert.NotNull(fullUrlResponse);
                Assert.NotNull(fullUrlResponse.EndpointUrl);

                deliveryAttributesResponse = EventGridManagementClient.DomainTopicEventSubscriptions.GetDeliveryAttributesAsync(resourceGroup, domainName, domainTopicName, eventSubscriptionName).Result;
                Assert.NotNull(deliveryAttributesResponse);

                // Delete the domain topic event subscription
                EventGridManagementClient.DomainTopicEventSubscriptions.DeleteAsync(resourceGroup, domainName,domainTopicName, eventSubscriptionName).Wait();

                // Delete the Domain
                EventGridManagementClient.Domains.DeleteAsync(resourceGroup, domainName).Wait();
            }
        }
    }
}