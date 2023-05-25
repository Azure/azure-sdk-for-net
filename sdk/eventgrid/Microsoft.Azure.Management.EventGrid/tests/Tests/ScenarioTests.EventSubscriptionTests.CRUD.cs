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
        const string AzureFunctionEndpointUrl = "https://devexpfuncappdestination.azurewebsites.net/runtime/webhooks/EventGrid?functionName=EventGridTrigger1&code=PASSWORDCODE";
        const string AzureFunctionArmId = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/DevExpRg/providers/Microsoft.Web/sites/devexpfuncappdestination/functions/EventGridTrigger1";
        const string SampleAzureActiveDirectoryTenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
        const string SampleAzureActiveDirectoryApplicationIdOrUri = "03d47d4a-7c50-43e0-ba90-89d090cc4582";

        [Fact]
        public void EventSubscriptionToCustomTopicCreateGetUpdateDelete()
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
                string scope = $"/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/{resourceGroup}/providers/Microsoft.EventGrid/topics/{topicName}";

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

                // Update the event subscription
                var eventSubscriptionUpdateParameters = new EventSubscriptionUpdateParameters()
                {
                    Destination = new WebHookEventSubscriptionDestination()
                    {
                        EndpointUrl = AzureFunctionEndpointUrl,
                        DeliveryAttributeMappings = new List<DeliveryAttributeMapping> 
                        {
                            new StaticDeliveryAttributeMapping()
                            {
                                Name = "StaticDeliveryAttribute1",
                                IsSecret = false,
                                Value = "someValue"
                            },
                            new DynamicDeliveryAttributeMapping()
                            {
                                Name = "DynamicDeliveryAttribute1",
                                SourceField = "data.field1"
                            }
                        }
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

                eventSubscriptionResponse = this.eventGridManagementClient.EventSubscriptions.UpdateAsync(scope, eventSubscriptionName, eventSubscriptionUpdateParameters).Result;
                Assert.Equal(".jpg", eventSubscriptionResponse.Filter.SubjectEndsWith, StringComparer.CurrentCultureIgnoreCase);
                Assert.Contains(eventSubscriptionResponse.Labels, label => label == "UpdatedLabel1");
                Assert.NotNull(((WebHookEventSubscriptionDestination)eventSubscriptionResponse.Destination).DeliveryAttributeMappings);
                Assert.Equal(2, ((WebHookEventSubscriptionDestination)eventSubscriptionResponse.Destination).DeliveryAttributeMappings.Count);
                // Assert.Equal(1, ((WebHookEventSubscriptionDestination)eventSubscriptionResponse.Destination).DeliveryAttributeMappings.Count);
                Assert.Equal("StaticDeliveryAttribute1", ((WebHookEventSubscriptionDestination)eventSubscriptionUpdateParameters.Destination).DeliveryAttributeMappings[0].Name);
                Assert.Equal("DynamicDeliveryAttribute1", ((WebHookEventSubscriptionDestination)eventSubscriptionUpdateParameters.Destination).DeliveryAttributeMappings[1].Name);

                // List event subscriptions
                var eventSubscriptionsPage = this.EventGridManagementClient.EventSubscriptions.ListRegionalByResourceGroupAsync(resourceGroup, location).Result;
                List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
                string nextLink = null;

                if (eventSubscriptionsPage != null)
                {
                    eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                    nextLink = eventSubscriptionsPage.NextPageLink;
                    while (nextLink != null)
                    {
                        eventSubscriptionsPage = this.EventGridManagementClient.EventSubscriptions.ListRegionalByResourceGroupNextAsync(nextLink).Result;
                        eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                        nextLink = eventSubscriptionsPage.NextPageLink;
                    }
                }

                Assert.Contains(eventSubscriptionsList, es => es.Name == eventSubscriptionName);

                // Delete the event subscription
                EventGridManagementClient.EventSubscriptions.DeleteAsync(scope, eventSubscriptionName).Wait();

                // Delete the topic
                EventGridManagementClient.Topics.DeleteAsync(resourceGroup, topicName).Wait();
            }
        }

        [Fact]
        public void EventSubscriptionToDomainCreateGetUpdateDelete()
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
                string scope = $"/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/{resourceGroup}/providers/Microsoft.EventGrid/domains/{domainName}";

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

                // Get the created event subscription using nested API
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

                eventSubscriptionResponse = this.eventGridManagementClient.EventSubscriptions.UpdateAsync(scope, eventSubscriptionName, eventSubscriptionUpdateParameters).Result;
                Assert.Equal(".jpg", eventSubscriptionResponse.Filter.SubjectEndsWith, StringComparer.CurrentCultureIgnoreCase);
                Assert.Contains(eventSubscriptionResponse.Labels, label => label == "UpdatedLabel1");

                // Create an event subscription to a domain topic scope
                eventSubscriptionName = TestUtilities.GenerateName(EventGridManagementHelper.EventSubscriptionPrefix);
                scope = $"/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/{resourceGroup}/providers/Microsoft.EventGrid/domains/{domainName}/topics/{domainTopicName}";

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

                eventSubscriptionResponse = this.EventGridManagementClient.EventSubscriptions.CreateOrUpdateAsync(scope, eventSubscriptionName, eventSubscription).Result;
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

                // List event subscriptions
                var eventSubscriptionsPage = this.EventGridManagementClient.EventSubscriptions.ListRegionalByResourceGroupAsync(resourceGroup, location).Result;
                List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
                string nextLink = null;

                if (eventSubscriptionsPage != null)
                {
                    eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                    nextLink = eventSubscriptionsPage.NextPageLink;
                    while (nextLink != null)
                    {
                        eventSubscriptionsPage = this.EventGridManagementClient.EventSubscriptions.ListRegionalByResourceGroupNextAsync(nextLink).Result;
                        eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                        nextLink = eventSubscriptionsPage.NextPageLink;
                    }
                }

                // Delete the event subscription
                EventGridManagementClient.EventSubscriptions.DeleteAsync(scope, eventSubscriptionName).Wait();
                //EventGridManagementClient.DomainEventSubscriptions.DeleteAsync(resourceGroup, domainName, eventSubscriptionName).Wait();

                // Delete the Domain
                EventGridManagementClient.Domains.DeleteAsync(resourceGroup, domainName).Wait();
            }
        }

        [Fact]
        public void EventSubscriptionToAzureSubscriptionCreateGetUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                // Create an event subscription to an Azure subscription
                var eventSubscriptionName = TestUtilities.GenerateName(EventGridManagementHelper.EventSubscriptionPrefix);

                string scope = $"/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4";

                EventSubscription eventSubscription = new EventSubscription()
                {
                    Destination = new WebHookEventSubscriptionDestination()
                    {
                        EndpointUrl = AzureFunctionEndpointUrl
                    },
                    Filter = new EventSubscriptionFilter()
                    {
                        IncludedEventTypes = null,
                        IsSubjectCaseSensitive = false,
                        SubjectBeginsWith = "TestPrefix",
                        SubjectEndsWith = "TestSuffix"
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

                // List event subscriptions by Azure subscription
                var eventSubscriptionsList = this.EventGridManagementClient.EventSubscriptions.ListGlobalBySubscriptionAsync().Result;
                // Assert.Contains(eventSubscriptionsList, es => es.Name == eventSubscriptionName);

                // Delete the event subscription
                EventGridManagementClient.EventSubscriptions.DeleteAsync(scope, eventSubscriptionName).Wait();
            }
        }

        [Fact]
        public void EventSubscriptionToResourceGroupCreateGetUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
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

                string scope = $"/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/{resourceGroup}";

                EventSubscription eventSubscription = new EventSubscription()
                {
                    Destination = new WebHookEventSubscriptionDestination()
                    {
                        EndpointUrl = AzureFunctionEndpointUrl
                    },
                    Filter = new EventSubscriptionFilter()
                    {
                        IncludedEventTypes = null,
                        IsSubjectCaseSensitive = false,
                        SubjectBeginsWith = "TestPrefix",
                        SubjectEndsWith = "TestSuffix"
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
                string scope = $"/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/{resourceGroup}/providers/Microsoft.EventGrid/topics/{topicName}";

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
                    },
                    DeadLetterDestination = new StorageBlobDeadLetterDestination()
                    {
                        ResourceId = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/DevExpRg/providers/Microsoft.Storage/storageAccounts/devexpstg",
                        BlobContainerName = "dlq"
                    },
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

                // Delete the event subscription
                EventGridManagementClient.EventSubscriptions.DeleteAsync(scope, eventSubscriptionName).Wait();

                // Delete the topic
                EventGridManagementClient.Topics.DeleteAsync(resourceGroup, topicName).Wait();
            }
        }

        [Fact]
        public void EventSubscriptionCreateGetUpdateDeleteWithDlqAdvancedFilterServiceBusAsDestination()
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
                string scope = $"/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/{resourceGroup}/providers/Microsoft.EventGrid/topics/{topicName}";

                EventSubscription eventSubscription = new EventSubscription()
                {
                    Destination = new ServiceBusQueueEventSubscriptionDestination()
                    {
                        ResourceId = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/DevExpRg/providers/Microsoft.ServiceBus/namespaces/devexpservicebus/queues/devexpdestination",
                    },
                    Filter = new EventSubscriptionFilter()
                    {
                        IncludedEventTypes = null,
                        IsSubjectCaseSensitive = true,
                        SubjectBeginsWith = "TestPrefix",
                        SubjectEndsWith = "TestSuffix",
                        AdvancedFilters =new AdvancedFilter[]
                        {
                            new StringContainsAdvancedFilter("topic", new[] { "sdk" }),
                            new NumberInAdvancedFilter("data.key1", new List<double?> {1.0, 2.0, 3.0}),
                            new BoolEqualsAdvancedFilter("data.key2", true),
                            new StringContainsAdvancedFilter("dataversion", new[] { "3.0" }),
                        }
                    },
                    Labels = new List<string>()
                    {
                        "TestLabel1",
                        "TestLabel2"
                    },
                    DeadLetterDestination = new StorageBlobDeadLetterDestination()
                    {
                        ResourceId = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/DevExpRg/providers/Microsoft.Storage/storageAccounts/devexpstg",
                        BlobContainerName = "dlq"
                    },
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

                // Delete the event subscription
                EventGridManagementClient.EventSubscriptions.DeleteAsync(scope, eventSubscriptionName).Wait();

                // Delete the topic
                EventGridManagementClient.Topics.DeleteAsync(resourceGroup, topicName).Wait();
            }
        }


        [Fact(Skip = "Skip temportarily.")]
        public void EventSubscriptionToCustomTopicCreateGetUpdateDeleteWithEventDeliverySchema()
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
                string scope = $"/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/{resourceGroup}/providers/Microsoft.EventGrid/topics/{topicName}";

                EventSubscription eventSubscription = new EventSubscription()
                {
                    Destination = new WebHookEventSubscriptionDestination()
                    {
                        EndpointUrl = AzureFunctionEndpointUrl,
                        MaxEventsPerBatch = 1000,
                        PreferredBatchSizeInKilobytes = 1000,
                        AzureActiveDirectoryTenantId = SampleAzureActiveDirectoryTenantId,
                        AzureActiveDirectoryApplicationIdOrUri = SampleAzureActiveDirectoryApplicationIdOrUri,
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
                    },
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

                // Update the event subscription
                var eventSubscriptionUpdateParameters = new EventSubscriptionUpdateParameters()
                {
                    Destination = new WebHookEventSubscriptionDestination()
                    {
                        EndpointUrl = AzureFunctionEndpointUrl,
                        MaxEventsPerBatch = 4400,
                        PreferredBatchSizeInKilobytes = 900,
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

                eventSubscriptionResponse = this.eventGridManagementClient.EventSubscriptions.UpdateAsync(scope, eventSubscriptionName, eventSubscriptionUpdateParameters).Result;
                Assert.Equal(".jpg", eventSubscriptionResponse.Filter.SubjectEndsWith, StringComparer.CurrentCultureIgnoreCase);
                Assert.Contains(eventSubscriptionResponse.Labels, label => label == "UpdatedLabel1");

                // List event subscriptions
                var eventSubscriptionsPage = this.EventGridManagementClient.EventSubscriptions.ListRegionalByResourceGroupAsync(resourceGroup, location).Result;
                List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
                string nextLink = null;

                if (eventSubscriptionsPage != null)
                {
                    eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                    nextLink = eventSubscriptionsPage.NextPageLink;
                    while (nextLink != null)
                    {
                        eventSubscriptionsPage = this.EventGridManagementClient.EventSubscriptions.ListRegionalByResourceGroupNextAsync(nextLink).Result;
                        eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                        nextLink = eventSubscriptionsPage.NextPageLink;
                    }
                }

                Assert.Contains(eventSubscriptionsList, es => es.Name == eventSubscriptionName);

                // Delete the event subscription
                EventGridManagementClient.EventSubscriptions.DeleteAsync(scope, eventSubscriptionName).Wait();

                // Delete the topic
                EventGridManagementClient.Topics.DeleteAsync(resourceGroup, topicName).Wait();
            }
        }

        [Fact]
        public void EventSubscriptionCreateGetUpdateDeleteWithDlqAdvancedFilterAzureFunctionAsDestination()
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
                string scope = $"/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/{resourceGroup}/providers/Microsoft.EventGrid/topics/{topicName}";

                EventSubscription eventSubscription = new EventSubscription()
                {
                    Destination = new AzureFunctionEventSubscriptionDestination()
                    {
                        ResourceId = AzureFunctionArmId,
                        MaxEventsPerBatch = 10,
                        PreferredBatchSizeInKilobytes = 1000,
                    },
                    Filter = new EventSubscriptionFilter()
                    {
                        IncludedEventTypes = null,
                        IsSubjectCaseSensitive = true,
                        SubjectBeginsWith = "TestPrefix",
                        SubjectEndsWith = "TestSuffix",
                        AdvancedFilters = new AdvancedFilter[]
                        {
                            new StringContainsAdvancedFilter("topic", new[] { "sdk" }),
                            new NumberInAdvancedFilter("data.key1", new List<double?> {1.0, 2.0, 3.0}),
                            new BoolEqualsAdvancedFilter("data.key2", true),
                            new StringContainsAdvancedFilter("dataversion", new[] { "3.0" }),
                        }
                    },
                    Labels = new List<string>()
                    {
                        "TestLabel1",
                        "TestLabel2"
                    },
                    DeadLetterDestination = new StorageBlobDeadLetterDestination()
                    {
                        ResourceId = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/DevExpRg/providers/Microsoft.Storage/storageAccounts/devexpstg",
                        BlobContainerName = "dlq"
                    },
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

                // Delete the event subscription
                EventGridManagementClient.EventSubscriptions.DeleteAsync(scope, eventSubscriptionName).Wait();

                // Delete the topic
                EventGridManagementClient.Topics.DeleteAsync(resourceGroup, topicName).Wait();
            }
        }

        [Fact]
        public void DisableLocalAuthCRUDOperations()
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

                var createTopicResponse = this.EventGridManagementClient.Topics.CreateOrUpdateAsync(
                    resourceGroup,
                    topicName,
                    new Topic()
                    {
                        Location = location,
                        Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        },
                        DisableLocalAuth = false
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
                Assert.False(getTopicResponse.DisableLocalAuth);

                // Delete the topic
                EventGridManagementClient.Topics.DeleteAsync(resourceGroup, topicName).Wait();
            }
        }
    }
}