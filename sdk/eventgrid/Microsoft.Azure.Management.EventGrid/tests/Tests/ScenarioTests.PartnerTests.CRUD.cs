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
        // Disable the test as it is not part of the GA version yet
        ////////[Fact]
        ////////public void PartnerCreateGetUpdateDelete()
        ////////{
        ////////    using (MockContext context = MockContext.Start(this.GetType()))
        ////////    {
        ////////        this.InitializeClients(context);

        ////////        var location = this.ResourceManagementClient.GetLocationFromProvider();

        ////////        var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
        ////////        if (string.IsNullOrWhiteSpace(resourceGroup))
        ////////        {
        ////////            resourceGroup = TestUtilities.GenerateName(EventGridManagementHelper.ResourceGroupPrefix);
        ////////            this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
        ////////        }

        ////////        bool partnerRegistrationCreated = false;
        ////////        bool partnerNamespaceCreated = false;
        ////////        bool eventChannelCreated = false;
        ////////        bool partnerTopicCreated = false;
        ////////        bool eventSubscriptionCreated = false;
        ////////        var partnerNamespaceName = TestUtilities.GenerateName(EventGridManagementHelper.PartnerNamespacePrefix);
        ////////        var eventChannelName = TestUtilities.GenerateName(EventGridManagementHelper.EventChannelPrefix);
        ////////        var partnerTopicName = TestUtilities.GenerateName(EventGridManagementHelper.PartnerTopicPrefix);
        ////////        var eventSubscriptionName = TestUtilities.GenerateName(EventGridManagementHelper.EventSubscriptionPrefix);

        ////////        var partnerRegistrationName = TestUtilities.GenerateName(EventGridManagementHelper.PartnerRegistrationPrefix);

        ////////        // Temporarily commenting this out as this is not yet enabled for the new API version
        ////////        // var operationsResponse = this.EventGridManagementClient.Operations.List();

        ////////        var originalTagsDictionary = new Dictionary<string, string>()
        ////////        {
        ////////            {"originalTag1", "originalValue1"},
        ////////            {"originalTag2", "originalValue2"}
        ////////        };

        ////////        Guid uniqueId = Guid.NewGuid();
        ////////        string subId = "5b4b650e-28b9-4790-b3ab-ddbd88d727c4";

        ////////        try
        ////////        {
        ////////            PartnerRegistration partnerRegistration = new PartnerRegistration()
        ////////            {
        ////////                Location = "global",
        ////////                Tags = originalTagsDictionary,
        ////////                LogoUri = "https://www.contoso.com/logo.png",
        ////////                SetupUri = "https://www.contoso.com/setup.html",
        ////////                PartnerName = "Contoso",
        ////////                PartnerResourceTypeName = $"Accounts.{uniqueId}",
        ////////                PartnerResourceTypeDisplayName = $"DisplayName Text -- {uniqueId}",
        ////////                PartnerResourceTypeDescription = $"Description Text -- {uniqueId}",
        ////////                AuthorizedAzureSubscriptionIds = new List<string>
        ////////            {
        ////////                subId
        ////////            },
        ////////            };

        ////////            var createPartnerRegistrationResponse = this.EventGridManagementClient.PartnerRegistrations.CreateOrUpdateAsync(resourceGroup, partnerRegistrationName, partnerRegistration).Result;

        ////////            partnerRegistrationCreated = true;

        ////////            Assert.NotNull(createPartnerRegistrationResponse);
        ////////            Assert.Equal(createPartnerRegistrationResponse.Name, partnerRegistrationName);

        ////////            TestUtilities.Wait(TimeSpan.FromSeconds(5));

        ////////            // Get the created partnerRegistration
        ////////            var getPartnerRegistrationResponse = this.EventGridManagementClient.PartnerRegistrations.Get(resourceGroup, partnerRegistrationName);
        ////////            if (string.Compare(getPartnerRegistrationResponse.ProvisioningState, "Succeeded", true) != 0)
        ////////            {
        ////////                TestUtilities.Wait(TimeSpan.FromSeconds(5));
        ////////            }

        ////////            getPartnerRegistrationResponse = this.EventGridManagementClient.PartnerRegistrations.Get(resourceGroup, partnerRegistrationName);
        ////////            Assert.NotNull(getPartnerRegistrationResponse);
        ////////            Assert.Equal("Succeeded", getPartnerRegistrationResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
        ////////            Assert.Equal("global", getPartnerRegistrationResponse.Location, StringComparer.CurrentCultureIgnoreCase);
        ////////            Assert.Contains(getPartnerRegistrationResponse.Tags, tag => tag.Key == "originalTag1");

        ////////            // Get all partnerRegistrations created within a resourceGroup
        ////////            IPage<PartnerRegistration> partnerRegistrationsInResourceGroupPage = this.EventGridManagementClient.PartnerRegistrations.ListByResourceGroupAsync(resourceGroup).Result;
        ////////            var partnerRegistrationsInResourceGroupList = new List<PartnerRegistration>();
        ////////            if (partnerRegistrationsInResourceGroupPage.Any())
        ////////            {
        ////////                partnerRegistrationsInResourceGroupList.AddRange(partnerRegistrationsInResourceGroupPage);
        ////////                var nextLink = partnerRegistrationsInResourceGroupPage.NextPageLink;
        ////////                while (nextLink != null)
        ////////                {
        ////////                    partnerRegistrationsInResourceGroupPage = this.EventGridManagementClient.PartnerRegistrations.ListByResourceGroupNextAsync(nextLink).Result;
        ////////                    partnerRegistrationsInResourceGroupList.AddRange(partnerRegistrationsInResourceGroupPage);
        ////////                    nextLink = partnerRegistrationsInResourceGroupPage.NextPageLink;
        ////////                }
        ////////            }

        ////////            Assert.NotNull(partnerRegistrationsInResourceGroupList);
        ////////            Assert.True(partnerRegistrationsInResourceGroupList.Count() >= 1);
        ////////            Assert.Contains(partnerRegistrationsInResourceGroupList, t => t.Name == partnerRegistrationName);
        ////////            Assert.True(partnerRegistrationsInResourceGroupList.All(ns => ns.Id.Contains(resourceGroup)));

        ////////            IPage<PartnerRegistration> partnerRegistrationsInResourceGroupPageWithTop = this.EventGridManagementClient.PartnerRegistrations.ListByResourceGroupAsync(resourceGroup, null, 5).Result;
        ////////            var partnerRegistrationsInResourceGroupListWithTop = new List<PartnerRegistration>();
        ////////            if (partnerRegistrationsInResourceGroupPageWithTop.Any())
        ////////            {
        ////////                partnerRegistrationsInResourceGroupListWithTop.AddRange(partnerRegistrationsInResourceGroupPageWithTop);
        ////////                var nextLink = partnerRegistrationsInResourceGroupPageWithTop.NextPageLink;
        ////////                while (nextLink != null)
        ////////                {
        ////////                    partnerRegistrationsInResourceGroupPageWithTop = this.EventGridManagementClient.PartnerRegistrations.ListByResourceGroupNextAsync(nextLink).Result;
        ////////                    partnerRegistrationsInResourceGroupListWithTop.AddRange(partnerRegistrationsInResourceGroupPageWithTop);
        ////////                    nextLink = partnerRegistrationsInResourceGroupPageWithTop.NextPageLink;
        ////////                }
        ////////            }

        ////////            Assert.NotNull(partnerRegistrationsInResourceGroupListWithTop);
        ////////            Assert.True(partnerRegistrationsInResourceGroupListWithTop.Count() >= 1);
        ////////            Assert.Contains(partnerRegistrationsInResourceGroupListWithTop, t => t.Name == partnerRegistrationName);
        ////////            Assert.True(partnerRegistrationsInResourceGroupListWithTop.All(ns => ns.Id.Contains(resourceGroup)));

        ////////            // Get all partnerRegistrations created within the subscription irrespective of the resourceGroup
        ////////            IPage<PartnerRegistration> partnerRegistrationsInAzureSubscription = this.EventGridManagementClient.PartnerRegistrations.ListBySubscriptionAsync(null, 100).Result;
        ////////            var partnerRegistrationsInAzureSubscriptionList = new List<PartnerRegistration>();
        ////////            if (partnerRegistrationsInAzureSubscription.Any())
        ////////            {
        ////////                partnerRegistrationsInAzureSubscriptionList.AddRange(partnerRegistrationsInAzureSubscription);
        ////////                var nextLink = partnerRegistrationsInAzureSubscription.NextPageLink;
        ////////                while (nextLink != null)
        ////////                {
        ////////                    try
        ////////                    {
        ////////                        partnerRegistrationsInAzureSubscription = this.EventGridManagementClient.PartnerRegistrations.ListBySubscriptionNextAsync(nextLink).Result;
        ////////                        partnerRegistrationsInAzureSubscriptionList.AddRange(partnerRegistrationsInAzureSubscription);
        ////////                        nextLink = partnerRegistrationsInAzureSubscription.NextPageLink;
        ////////                    }
        ////////                    catch (Exception ex)
        ////////                    {
        ////////                        Console.WriteLine(ex);
        ////////                        break;
        ////////                    }
        ////////                }
        ////////            }

        ////////            Assert.NotNull(partnerRegistrationsInAzureSubscriptionList);
        ////////            Assert.True(partnerRegistrationsInAzureSubscriptionList.Count() >= 1);
        ////////            Assert.Contains(partnerRegistrationsInAzureSubscriptionList, t => t.Name == partnerRegistrationName);

        ////////            var replacePartnerRegistrationTagsDictionary = new Dictionary<string, string>()
        ////////            {
        ////////                { "replacedTag1", "replacedValue1" },
        ////////                { "replacedTag2", "replacedValue2" }
        ////////            };

        ////////            // Replace the partnerRegistration
        ////////            partnerRegistration.Tags = replacePartnerRegistrationTagsDictionary;
        ////////            var replacePartnerRegistrationResponse = this.EventGridManagementClient.PartnerRegistrations.CreateOrUpdateAsync(resourceGroup, partnerRegistrationName, partnerRegistration).Result;

        ////////            Assert.Contains(replacePartnerRegistrationResponse.Tags, tag => tag.Key == "replacedTag1");
        ////////            Assert.DoesNotContain(replacePartnerRegistrationResponse.Tags, tag => tag.Key == "originalTag1");

        ////////            // Update the partnerRegistration with tags
        ////////            //////PartnerRegistrationUpdateParameters partnerRegistrationUpdateParameters = new PartnerRegistrationUpdateParameters();
        ////////            //////partnerRegistrationUpdateParameters.Tags = new Dictionary<string, string>()
        ////////            //////{
        ////////            //////    { "updatedTag1", "updatedValue1" },
        ////////            //////    { "updatedTag2", "updatedValue2" }
        ////////            //////};

        ////////            //////var updatePartnerRegistrationResponse = this.EventGridManagementClient.PartnerRegistrations.UpdateAsync(resourceGroup, partnerRegistrationName, partnerRegistrationUpdateParameters).Result;
        ////////            //////Assert.Contains(updatePartnerRegistrationResponse.Tags, tag => tag.Key == "updatedTag1");
        ////////            //////Assert.DoesNotContain(updatePartnerRegistrationResponse.Tags, tag => tag.Key == "replacedTag1");

        ////////            // Partner namespace operations

        ////////            var originalNamespaceTagsDictionary = new Dictionary<string, string>()
        ////////            {
        ////////                {"originalTag111", "originalValue111"},
        ////////                {"originalTag222", "originalValue222"}
        ////////            };

        ////////            PartnerNamespace partnerNamespace = new PartnerNamespace()
        ////////            {
        ////////                Location = location,
        ////////                Tags = originalNamespaceTagsDictionary,
        ////////                PartnerRegistrationFullyQualifiedId = getPartnerRegistrationResponse.Id
        ////////            };

        ////////            var createPartnerNamespaceResponse = this.EventGridManagementClient.PartnerNamespaces.CreateOrUpdateAsync(resourceGroup, partnerNamespaceName, partnerNamespace).Result;
        ////////            partnerNamespaceCreated = true;

        ////////            Assert.NotNull(createPartnerNamespaceResponse);
        ////////            Assert.Equal(createPartnerNamespaceResponse.Name, partnerNamespaceName);

        ////////            TestUtilities.Wait(TimeSpan.FromSeconds(5));

        ////////            // Get the created partnerNamespace
        ////////            var getPartnerNamespaceResponse = this.EventGridManagementClient.PartnerNamespaces.Get(resourceGroup, partnerNamespaceName);
        ////////            if (string.Compare(getPartnerNamespaceResponse.ProvisioningState, "Succeeded", true) != 0)
        ////////            {
        ////////                TestUtilities.Wait(TimeSpan.FromSeconds(5));
        ////////            }

        ////////            getPartnerNamespaceResponse = this.EventGridManagementClient.PartnerNamespaces.Get(resourceGroup, partnerNamespaceName);
        ////////            Assert.NotNull(getPartnerNamespaceResponse);
        ////////            Assert.Equal("Succeeded", getPartnerNamespaceResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
        ////////            Assert.Equal(location, getPartnerNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);
        ////////            Assert.Contains(getPartnerNamespaceResponse.Tags, tag => tag.Key == "originalTag111");

        ////////            // Get all partnerNamespaces created within a resourceGroup
        ////////            IPage<PartnerNamespace> partnerNamespacesInResourceGroupPage = this.EventGridManagementClient.PartnerNamespaces.ListByResourceGroupAsync(resourceGroup).Result;
        ////////            var partnerNamespacesInResourceGroupList = new List<PartnerNamespace>();
        ////////            if (partnerNamespacesInResourceGroupPage.Any())
        ////////            {
        ////////                partnerNamespacesInResourceGroupList.AddRange(partnerNamespacesInResourceGroupPage);
        ////////                var nextLink = partnerNamespacesInResourceGroupPage.NextPageLink;
        ////////                while (nextLink != null)
        ////////                {
        ////////                    partnerNamespacesInResourceGroupPage = this.EventGridManagementClient.PartnerNamespaces.ListByResourceGroupNextAsync(nextLink).Result;
        ////////                    partnerNamespacesInResourceGroupList.AddRange(partnerNamespacesInResourceGroupPage);
        ////////                    nextLink = partnerNamespacesInResourceGroupPage.NextPageLink;
        ////////                }
        ////////            }

        ////////            Assert.NotNull(partnerNamespacesInResourceGroupList);
        ////////            Assert.True(partnerNamespacesInResourceGroupList.Count() >= 1);
        ////////            Assert.Contains(partnerNamespacesInResourceGroupList, t => t.Name == partnerNamespaceName);
        ////////            Assert.True(partnerNamespacesInResourceGroupList.All(ns => ns.Id.Contains(resourceGroup)));

        ////////            IPage<PartnerNamespace> partnerNamespacesInResourceGroupPageWithTop = this.EventGridManagementClient.PartnerNamespaces.ListByResourceGroupAsync(resourceGroup, null, 5).Result;
        ////////            var partnerNamespacesInResourceGroupListWithTop = new List<PartnerNamespace>();
        ////////            if (partnerNamespacesInResourceGroupPageWithTop.Any())
        ////////            {
        ////////                partnerNamespacesInResourceGroupListWithTop.AddRange(partnerNamespacesInResourceGroupPageWithTop);
        ////////                var nextLink = partnerNamespacesInResourceGroupPageWithTop.NextPageLink;
        ////////                while (nextLink != null)
        ////////                {
        ////////                    partnerNamespacesInResourceGroupPageWithTop = this.EventGridManagementClient.PartnerNamespaces.ListByResourceGroupNextAsync(nextLink).Result;
        ////////                    partnerNamespacesInResourceGroupListWithTop.AddRange(partnerNamespacesInResourceGroupPageWithTop);
        ////////                    nextLink = partnerNamespacesInResourceGroupPageWithTop.NextPageLink;
        ////////                }
        ////////            }

        ////////            Assert.NotNull(partnerNamespacesInResourceGroupListWithTop);
        ////////            Assert.True(partnerNamespacesInResourceGroupListWithTop.Count() >= 1);
        ////////            Assert.Contains(partnerNamespacesInResourceGroupListWithTop, t => t.Name == partnerNamespaceName);
        ////////            Assert.True(partnerNamespacesInResourceGroupListWithTop.All(ns => ns.Id.Contains(resourceGroup)));

        ////////            // Get all partnerNamespaces created within the subscription irrespective of the resourceGroup
        ////////            IPage<PartnerNamespace> partnerNamespacesInAzureSubscription = this.EventGridManagementClient.PartnerNamespaces.ListBySubscriptionAsync(null, 100).Result;
        ////////            var partnerNamespacesInAzureSubscriptionList = new List<PartnerNamespace>();
        ////////            if (partnerNamespacesInAzureSubscription.Any())
        ////////            {
        ////////                partnerNamespacesInAzureSubscriptionList.AddRange(partnerNamespacesInAzureSubscription);
        ////////                var nextLink = partnerNamespacesInAzureSubscription.NextPageLink;
        ////////                while (nextLink != null)
        ////////                {
        ////////                    try
        ////////                    {
        ////////                        partnerNamespacesInAzureSubscription = this.EventGridManagementClient.PartnerNamespaces.ListBySubscriptionNextAsync(nextLink).Result;
        ////////                        partnerNamespacesInAzureSubscriptionList.AddRange(partnerNamespacesInAzureSubscription);
        ////////                        nextLink = partnerNamespacesInAzureSubscription.NextPageLink;
        ////////                    }
        ////////                    catch (Exception ex)
        ////////                    {
        ////////                        Console.WriteLine(ex);
        ////////                        break;
        ////////                    }
        ////////                }
        ////////            }

        ////////            Assert.NotNull(partnerNamespacesInAzureSubscriptionList);
        ////////            Assert.True(partnerNamespacesInAzureSubscriptionList.Count() >= 1);
        ////////            Assert.Contains(partnerNamespacesInAzureSubscriptionList, t => t.Name == partnerNamespaceName);

        ////////            var replacePartnerNamespaceTagsDictionary = new Dictionary<string, string>()
        ////////            {
        ////////                { "replacedTag111", "replacedValue111" },
        ////////                { "replacedTag222", "replacedValue222" }
        ////////            };

        ////////            // Replace the partnerNamespace
        ////////            partnerNamespace.Tags = replacePartnerNamespaceTagsDictionary;
        ////////            var replacePartnerNamespaceResponse = this.EventGridManagementClient.PartnerNamespaces.CreateOrUpdateAsync(resourceGroup, partnerNamespaceName, partnerNamespace).Result;

        ////////            Assert.Contains(replacePartnerNamespaceResponse.Tags, tag => tag.Key == "replacedTag111");
        ////////            Assert.DoesNotContain(replacePartnerNamespaceResponse.Tags, tag => tag.Key == "originalTag111");

        ////////            // EventChannel/PartnerTopic operations
        ////////            var originalPartnerTopicTagsDictionary = new Dictionary<string, string>()
        ////////            {
        ////////                {"originalTag11111", "originalValue11111"},
        ////////                {"originalTag22222", "originalValue22222"}
        ////////            };

        ////////            EventChannel eventChannel = new EventChannel()
        ////////            {
        ////////                Source = new EventChannelSource
        ////////                {
        ////////                    Source = $"Accounts.User.{uniqueId}",
        ////////                },
        ////////                Destination = new EventChannelDestination
        ////////                {
        ////////                    AzureSubscriptionId = subId,
        ////////                    ResourceGroup = resourceGroup,
        ////////                    PartnerTopicName = partnerTopicName
        ////////                },
        ////////            };

        ////////            var createEventChannelResponse = this.EventGridManagementClient.EventChannels.CreateOrUpdateAsync(resourceGroup, partnerNamespaceName, eventChannelName, eventChannel).Result;
        ////////            eventChannelCreated = true;
        ////////            partnerTopicCreated = true;

        ////////            Assert.NotNull(createEventChannelResponse);
        ////////            Assert.Equal(createEventChannelResponse.Name, eventChannelName);

        ////////            TestUtilities.Wait(TimeSpan.FromSeconds(5));

        ////////            // Get the created eventChannel
        ////////            var getEventChannelResponse = this.EventGridManagementClient.EventChannels.Get(resourceGroup, partnerNamespaceName, eventChannelName);
        ////////            if (string.Compare(getEventChannelResponse.ProvisioningState, "Succeeded", true) != 0)
        ////////            {
        ////////                TestUtilities.Wait(TimeSpan.FromSeconds(5));
        ////////            }

        ////////            getEventChannelResponse = this.EventGridManagementClient.EventChannels.Get(resourceGroup, partnerNamespaceName, eventChannelName);
        ////////            Assert.NotNull(getEventChannelResponse);
        ////////            Assert.Equal("Succeeded", getEventChannelResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);

        ////////            // Get all eventChannels created within a partnerNamespace
        ////////            IPage<EventChannel> eventChannelsInPartnerNamespacePage = this.EventGridManagementClient.EventChannels.ListByPartnerNamespaceAsync(resourceGroup, partnerNamespaceName).Result;
        ////////            var eventChannelsInPartnerNamespaceList = new List<EventChannel>();
        ////////            if (eventChannelsInPartnerNamespacePage.Any())
        ////////            {
        ////////                eventChannelsInPartnerNamespaceList.AddRange(eventChannelsInPartnerNamespacePage);
        ////////                var nextLink = eventChannelsInPartnerNamespacePage.NextPageLink;
        ////////                while (nextLink != null)
        ////////                {
        ////////                    eventChannelsInPartnerNamespacePage = this.EventGridManagementClient.EventChannels.ListByPartnerNamespaceNextAsync(nextLink).Result;
        ////////                    eventChannelsInPartnerNamespaceList.AddRange(eventChannelsInPartnerNamespacePage);
        ////////                    nextLink = eventChannelsInPartnerNamespacePage.NextPageLink;
        ////////                }
        ////////            }

        ////////            Assert.NotNull(eventChannelsInPartnerNamespaceList);
        ////////            Assert.True(eventChannelsInPartnerNamespaceList.Count() >= 1);
        ////////            Assert.Contains(eventChannelsInPartnerNamespaceList, t => t.Name == eventChannelName);
        ////////            Assert.True(eventChannelsInPartnerNamespaceList.All(ns => ns.Id.Contains(resourceGroup)));

        ////////            // Partner topic operations

        ////////            // Get the created partnerTopic
        ////////            var getPartnerTopicResponse = this.EventGridManagementClient.PartnerTopics.Get(resourceGroup, partnerTopicName);
        ////////            if (string.Compare(getPartnerTopicResponse.ProvisioningState, "Succeeded", true) != 0)
        ////////            {
        ////////                TestUtilities.Wait(TimeSpan.FromSeconds(5));
        ////////            }

        ////////            getPartnerTopicResponse = this.EventGridManagementClient.PartnerTopics.Get(resourceGroup, partnerTopicName);
        ////////            Assert.NotNull(getPartnerTopicResponse);
        ////////            Assert.Equal("Succeeded", getPartnerTopicResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
        ////////            Assert.Equal(location, getPartnerTopicResponse.Location, StringComparer.CurrentCultureIgnoreCase);
        ////////            Assert.Null(getPartnerTopicResponse.Tags);

        ////////            // Get all partnerTopics created within a resourceGroup
        ////////            IPage<PartnerTopic> partnerTopicsInResourceGroupPage = this.EventGridManagementClient.PartnerTopics.ListByResourceGroupAsync(resourceGroup).Result;
        ////////            var partnerTopicsInResourceGroupList = new List<PartnerTopic>();
        ////////            if (partnerTopicsInResourceGroupPage.Any())
        ////////            {
        ////////                partnerTopicsInResourceGroupList.AddRange(partnerTopicsInResourceGroupPage);
        ////////                var nextLink = partnerTopicsInResourceGroupPage.NextPageLink;
        ////////                while (nextLink != null)
        ////////                {
        ////////                    partnerTopicsInResourceGroupPage = this.EventGridManagementClient.PartnerTopics.ListByResourceGroupNextAsync(nextLink).Result;
        ////////                    partnerTopicsInResourceGroupList.AddRange(partnerTopicsInResourceGroupPage);
        ////////                    nextLink = partnerTopicsInResourceGroupPage.NextPageLink;
        ////////                }
        ////////            }

        ////////            Assert.NotNull(partnerTopicsInResourceGroupList);
        ////////            Assert.True(partnerTopicsInResourceGroupList.Count() >= 1);
        ////////            Assert.Contains(partnerTopicsInResourceGroupList, t => t.Name == partnerTopicName);
        ////////            Assert.True(partnerTopicsInResourceGroupList.All(ns => ns.Id.Contains(resourceGroup)));

        ////////            IPage<PartnerTopic> partnerTopicsInResourceGroupPageWithTop = this.EventGridManagementClient.PartnerTopics.ListByResourceGroupAsync(resourceGroup, null, 5).Result;
        ////////            var partnerTopicsInResourceGroupListWithTop = new List<PartnerTopic>();
        ////////            if (partnerTopicsInResourceGroupPageWithTop.Any())
        ////////            {
        ////////                partnerTopicsInResourceGroupListWithTop.AddRange(partnerTopicsInResourceGroupPageWithTop);
        ////////                var nextLink = partnerTopicsInResourceGroupPageWithTop.NextPageLink;
        ////////                while (nextLink != null)
        ////////                {
        ////////                    partnerTopicsInResourceGroupPageWithTop = this.EventGridManagementClient.PartnerTopics.ListByResourceGroupNextAsync(nextLink).Result;
        ////////                    partnerTopicsInResourceGroupListWithTop.AddRange(partnerTopicsInResourceGroupPageWithTop);
        ////////                    nextLink = partnerTopicsInResourceGroupPageWithTop.NextPageLink;
        ////////                }
        ////////            }

        ////////            Assert.NotNull(partnerTopicsInResourceGroupListWithTop);
        ////////            Assert.True(partnerTopicsInResourceGroupListWithTop.Count() >= 1);
        ////////            Assert.Contains(partnerTopicsInResourceGroupListWithTop, t => t.Name == partnerTopicName);
        ////////            Assert.True(partnerTopicsInResourceGroupListWithTop.All(ns => ns.Id.Contains(resourceGroup)));

        ////////            // Get all partnerTopics created within the subscription irrespective of the resourceGroup
        ////////            IPage<PartnerTopic> partnerTopicsInAzureSubscription = this.EventGridManagementClient.PartnerTopics.ListBySubscriptionAsync(null, 100).Result;
        ////////            var partnerTopicsInAzureSubscriptionList = new List<PartnerTopic>();
        ////////            if (partnerTopicsInAzureSubscription.Any())
        ////////            {
        ////////                partnerTopicsInAzureSubscriptionList.AddRange(partnerTopicsInAzureSubscription);
        ////////                var nextLink = partnerTopicsInAzureSubscription.NextPageLink;
        ////////                while (nextLink != null)
        ////////                {
        ////////                    try
        ////////                    {
        ////////                        partnerTopicsInAzureSubscription = this.EventGridManagementClient.PartnerTopics.ListBySubscriptionNextAsync(nextLink).Result;
        ////////                        partnerTopicsInAzureSubscriptionList.AddRange(partnerTopicsInAzureSubscription);
        ////////                        nextLink = partnerTopicsInAzureSubscription.NextPageLink;
        ////////                    }
        ////////                    catch (Exception ex)
        ////////                    {
        ////////                        Console.WriteLine(ex);
        ////////                        break;
        ////////                    }
        ////////                }
        ////////            }

        ////////            Assert.NotNull(partnerTopicsInAzureSubscriptionList);
        ////////            Assert.True(partnerTopicsInAzureSubscriptionList.Count() >= 1);
        ////////            Assert.Contains(partnerTopicsInAzureSubscriptionList, t => t.Name == partnerTopicName);

        ////////            EventSubscription eventSubscription = new EventSubscription()
        ////////            {
        ////////                Destination = new StorageQueueEventSubscriptionDestination()
        ////////                {
        ////////                    QueueName = "queue1",
        ////////                    ResourceId = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/DevExpRg/providers/Microsoft.Storage/storageAccounts/devexpstg"
        ////////                },
        ////////                Filter = new EventSubscriptionFilter()
        ////////                {
        ////////                    IncludedEventTypes = null,
        ////////                    IsSubjectCaseSensitive = true,
        ////////                    SubjectBeginsWith = "TestPrefix",
        ////////                    SubjectEndsWith = "TestSuffix"
        ////////                },
        ////////                Labels = new List<string>()
        ////////            {
        ////////                "TestLabel1",
        ////////                "TestLabel2"
        ////////            }
        ////////            };

        ////////            var eventSubscriptionResponse = this.EventGridManagementClient.PartnerTopicEventSubscriptions.CreateOrUpdateAsync(resourceGroup, partnerTopicName, eventSubscriptionName, eventSubscription).Result;
        ////////            eventSubscriptionCreated = true;

        ////////            Assert.NotNull(eventSubscriptionResponse);
        ////////            Assert.Equal(eventSubscriptionResponse.Name, eventSubscriptionName);

        ////////            TestUtilities.Wait(TimeSpan.FromSeconds(5));

        ////////            // Get the created event subscription
        ////////            eventSubscriptionResponse = EventGridManagementClient.PartnerTopicEventSubscriptions.Get(resourceGroup, partnerTopicName, eventSubscriptionName);
        ////////            if (string.Compare(eventSubscriptionResponse.ProvisioningState, "Succeeded", true) != 0)
        ////////            {
        ////////                TestUtilities.Wait(TimeSpan.FromSeconds(5));
        ////////            }

        ////////            eventSubscriptionResponse = EventGridManagementClient.PartnerTopicEventSubscriptions.Get(resourceGroup, partnerTopicName, eventSubscriptionName);
        ////////            Assert.NotNull(eventSubscriptionResponse);
        ////////            Assert.Equal("Succeeded", eventSubscriptionResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
        ////////            Assert.Equal("TestPrefix", eventSubscriptionResponse.Filter.SubjectBeginsWith, StringComparer.CurrentCultureIgnoreCase);
        ////////            Assert.Equal("TestSuffix", eventSubscriptionResponse.Filter.SubjectEndsWith, StringComparer.CurrentCultureIgnoreCase);

        ////////            // Update the event subscription
        ////////            var eventSubscriptionUpdateParameters = new EventSubscriptionUpdateParameters()
        ////////            {
        ////////                Destination = new StorageQueueEventSubscriptionDestination()
        ////////                {
        ////////                    QueueName = "queue1",
        ////////                    ResourceId = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/DevExpRg/providers/Microsoft.Storage/storageAccounts/devexpstg"
        ////////                },
        ////////                Filter = new EventSubscriptionFilter()
        ////////                {
        ////////                    IncludedEventTypes = new List<string>()
        ////////                {
        ////////                    "Event1",
        ////////                    "Event2"
        ////////                },
        ////////                    SubjectEndsWith = ".jpg",
        ////////                    SubjectBeginsWith = "TestPrefix"
        ////////                },
        ////////                Labels = new List<string>()
        ////////            {
        ////////                "UpdatedLabel1",
        ////////                "UpdatedLabel2",
        ////////            }
        ////////            };

        ////////            eventSubscriptionResponse = this.eventGridManagementClient.PartnerTopicEventSubscriptions.UpdateAsync(resourceGroup, partnerTopicName, eventSubscriptionName, eventSubscriptionUpdateParameters).Result;
        ////////            Assert.Equal(".jpg", eventSubscriptionResponse.Filter.SubjectEndsWith, StringComparer.CurrentCultureIgnoreCase);
        ////////            Assert.Contains(eventSubscriptionResponse.Labels, label => label == "UpdatedLabel1");

        ////////            // List event subscriptions
        ////////            ////////var eventSubscriptionsPage = this.EventGridManagementClient.PartnerTopicEventSubscriptions.ListByPartnerTopicAsync(resourceGroup, partnerTopicName).Result;
        ////////            ////////List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
        ////////            ////////string nextLink = null;

        ////////            ////////if (eventSubscriptionsPage != null)
        ////////            ////////{
        ////////            ////////    eventSubscriptionsList.AddRange(eventSubscriptionsPage);
        ////////            ////////    nextLink = eventSubscriptionsPage.NextPageLink;
        ////////            ////////    while (nextLink != null)
        ////////            ////////    {
        ////////            ////////        eventSubscriptionsPage = this.EventGridManagementClient.EventSubscriptions.ListRegionalByResourceGroupNextAsync(nextLink).Result;
        ////////            ////////        eventSubscriptionsList.AddRange(eventSubscriptionsPage);
        ////////            ////////        nextLink = eventSubscriptionsPage.NextPageLink;
        ////////            ////////    }
        ////////            ////////}
        ////////        }
        ////////        finally
        ////////        {
        ////////            if (eventSubscriptionCreated)
        ////////            {
        ////////                // Delete the event subscription
        ////////                EventGridManagementClient.PartnerTopicEventSubscriptions.DeleteAsync(resourceGroup, partnerTopicName, eventSubscriptionName).Wait();
        ////////            }

        ////////            if (partnerTopicCreated)
        ////////            {
        ////////                // Delete partnerTopic
        ////////                this.EventGridManagementClient.PartnerTopics.DeleteAsync(resourceGroup, partnerTopicName).Wait();
        ////////            }

        ////////            if (eventChannelCreated)
        ////////            {
        ////////                // Delete eventChannel
        ////////                this.EventGridManagementClient.EventChannels.DeleteAsync(resourceGroup, partnerNamespaceName, eventChannelName).Wait();
        ////////            }

        ////////            if (partnerNamespaceCreated)
        ////////            {
        ////////                // Delete partnerNamespace
        ////////                this.EventGridManagementClient.PartnerNamespaces.DeleteAsync(resourceGroup, partnerNamespaceName).Wait();
        ////////            }

        ////////            if (partnerRegistrationCreated)
        ////////            {
        ////////                // Delete partnerRegistration
        ////////                this.EventGridManagementClient.PartnerRegistrations.DeleteAsync(resourceGroup, partnerRegistrationName).Wait();
        ////////            }
        ////////        }
        ////////    }
        ////////}
    }
}