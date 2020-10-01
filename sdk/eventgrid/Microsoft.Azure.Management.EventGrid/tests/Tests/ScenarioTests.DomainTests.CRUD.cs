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
using Microsoft.Rest.Azure;

namespace EventGrid.Tests.ScenarioTests
{
    public partial class ScenarioTests
    {
        [Fact]
        public void DomainCreateGetUpdateDelete()
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
                var domainTopicName1 = TestUtilities.GenerateName(EventGridManagementHelper.DomainTopicPrefix);
                var domainTopicName2 = TestUtilities.GenerateName(EventGridManagementHelper.DomainTopicPrefix);

                // Temporarily commenting this out as this is not yet enabled for the new API version
                // var operationsResponse = this.EventGridManagementClient.Operations.List();

                var originalTagsDictionary = new Dictionary<string, string>()
                {
                    {"originalTag1", "originalValue1"},
                    {"originalTag2", "originalValue2"}
                };

                Domain domain = new Domain()
                {
                    Location = location,
                    Tags = originalTagsDictionary,
                    InputSchema = InputSchema.CloudEventSchemaV10,
                    InputSchemaMapping = new JsonInputSchemaMapping()
                    {
                        Topic = new JsonField("myTopicField")
                    }
                };

                var createDomainResponse = this.EventGridManagementClient.Domains.CreateOrUpdateAsync(resourceGroup, domainName, domain).Result;

                Assert.NotNull(createDomainResponse);
                Assert.Equal(createDomainResponse.Name, domainName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Get the created domain
                var getDomainResponse = this.EventGridManagementClient.Domains.Get(resourceGroup, domainName);
                if (string.Compare(getDomainResponse.ProvisioningState, "Succeeded", true) != 0)
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));
                }

                getDomainResponse = this.EventGridManagementClient.Domains.Get(resourceGroup, domainName);
                Assert.NotNull(getDomainResponse);
                Assert.Equal("Succeeded", getDomainResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(location, getDomainResponse.Location, StringComparer.CurrentCultureIgnoreCase);
                Assert.Contains(getDomainResponse.Tags, tag => tag.Key == "originalTag1");

                //// Diable test as identity is not part of GA Version yet.
                //// Assert.Null(getDomainResponse.Identity);
                Assert.Null(getDomainResponse.InboundIpRules);

                // Get all domains created within a resourceGroup
                IPage<Domain> domainsInResourceGroupPage = this.EventGridManagementClient.Domains.ListByResourceGroupAsync(resourceGroup).Result;
                var domainsInResourceGroupList = new List<Domain>();
                if (domainsInResourceGroupPage.Any())
                {
                    domainsInResourceGroupList.AddRange(domainsInResourceGroupPage);
                    var nextLink = domainsInResourceGroupPage.NextPageLink;
                    while (nextLink != null)
                    {
                        domainsInResourceGroupPage = this.EventGridManagementClient.Domains.ListByResourceGroupNextAsync(nextLink).Result;
                        domainsInResourceGroupList.AddRange(domainsInResourceGroupPage);
                        nextLink = domainsInResourceGroupPage.NextPageLink;
                    }
                }

                Assert.NotNull(domainsInResourceGroupList);
                Assert.True(domainsInResourceGroupList.Count() >= 1);
                Assert.Contains(domainsInResourceGroupList, t => t.Name == domainName);
                Assert.True(domainsInResourceGroupList.All(ns => ns.Id.Contains(resourceGroup)));

                IPage<Domain> domainsInResourceGroupPageWithTop = this.EventGridManagementClient.Domains.ListByResourceGroupAsync(resourceGroup, null, 5).Result;
                var domainsInResourceGroupListWithTop = new List<Domain>();
                if (domainsInResourceGroupPageWithTop.Any())
                {
                    domainsInResourceGroupListWithTop.AddRange(domainsInResourceGroupPageWithTop);
                    var nextLink = domainsInResourceGroupPageWithTop.NextPageLink;
                    while (nextLink != null)
                    {
                        domainsInResourceGroupPageWithTop = this.EventGridManagementClient.Domains.ListByResourceGroupNextAsync(nextLink).Result;
                        domainsInResourceGroupListWithTop.AddRange(domainsInResourceGroupPageWithTop);
                        nextLink = domainsInResourceGroupPageWithTop.NextPageLink;
                    }
                }

                Assert.NotNull(domainsInResourceGroupListWithTop);
                Assert.True(domainsInResourceGroupListWithTop.Count() >= 1);
                Assert.Contains(domainsInResourceGroupListWithTop, t => t.Name == domainName);
                Assert.True(domainsInResourceGroupListWithTop.All(ns => ns.Id.Contains(resourceGroup)));

                // Get all domains created within the subscription irrespective of the resourceGroup
                IPage<Domain> domainsInAzureSubscription = this.EventGridManagementClient.Domains.ListBySubscriptionAsync(null, 100).Result;
                var domainsInAzureSubscriptionList = new List<Domain>();
                if (domainsInAzureSubscription.Any())
                {
                    domainsInAzureSubscriptionList.AddRange(domainsInAzureSubscription);
                    var nextLink = domainsInAzureSubscription.NextPageLink;
                    while (nextLink != null)
                    {
                        try
                        {
                            domainsInAzureSubscription = this.EventGridManagementClient.Domains.ListBySubscriptionNextAsync(nextLink).Result;
                            domainsInAzureSubscriptionList.AddRange(domainsInAzureSubscription);
                            nextLink = domainsInAzureSubscription.NextPageLink;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            break;
                        }
                    }
                }

                Assert.NotNull(domainsInAzureSubscriptionList);
                Assert.True(domainsInAzureSubscriptionList.Count() >= 1);
                Assert.Contains(domainsInAzureSubscriptionList, t => t.Name == domainName);

                var replaceDomainTagsDictionary = new Dictionary<string, string>()
                {
                    { "replacedTag1", "replacedValue1" },
                    { "replacedTag2", "replacedValue2" }
                };

                // Replace the domain
                domain.Tags = replaceDomainTagsDictionary;
                var replaceDomainResponse = this.EventGridManagementClient.Domains.CreateOrUpdateAsync(resourceGroup, domainName, domain).Result;

                Assert.Contains(replaceDomainResponse.Tags, tag => tag.Key == "replacedTag1");
                Assert.DoesNotContain(replaceDomainResponse.Tags, tag => tag.Key == "originalTag1");

                // Update the domain with tags & allow traffic from all ips
                var domainUpdateParameters = new DomainUpdateParameters()
                {
                    Tags = new Dictionary<string, string>()
                    {
                        { "updatedTag1", "updatedValue1" },
                        { "updatedTag2", "updatedValue2" }
                    },
                    PublicNetworkAccess = PublicNetworkAccess.Enabled,
                };

                var updateDomainResponse = this.EventGridManagementClient.Domains.UpdateAsync(resourceGroup, domainName, domainUpdateParameters).Result;
                Assert.Contains(updateDomainResponse.Tags, tag => tag.Key == "updatedTag1");
                Assert.DoesNotContain(updateDomainResponse.Tags, tag => tag.Key == "replacedTag1");
                Assert.True(updateDomainResponse.PublicNetworkAccess == PublicNetworkAccess.Enabled);
                Assert.Null(updateDomainResponse.InboundIpRules);

                // Update the Topic with IP filtering feature
                domain.PublicNetworkAccess = PublicNetworkAccess.Disabled;
                domain.InboundIpRules = new List<InboundIpRule>();
                domain.InboundIpRules.Add(new InboundIpRule() { Action = IpActionType.Allow, IpMask = "12.35.67.98" });
                domain.InboundIpRules.Add(new InboundIpRule() { Action = IpActionType.Allow, IpMask = "12.35.90.100" });
                var updateDomainResponseWithIpFilteringFeature = this.EventGridManagementClient.Domains.CreateOrUpdateAsync(resourceGroup, domainName, domain).Result;
                Assert.False(updateDomainResponseWithIpFilteringFeature.PublicNetworkAccess == PublicNetworkAccess.Enabled);
                Assert.True(updateDomainResponseWithIpFilteringFeature.InboundIpRules.Count() == 2);

                // Create domain topic manually.
                DomainTopic createDomainTopicResponse = this.EventGridManagementClient.DomainTopics.CreateOrUpdateAsync(resourceGroup, domainName, domainTopicName1).Result;

                Assert.NotNull(createDomainTopicResponse);
                Assert.Equal(createDomainTopicResponse.Name, domainTopicName1);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Get the created domain Topic
                var getDomainTopicResponse = this.EventGridManagementClient.DomainTopics.Get(resourceGroup, domainName, domainTopicName1);
                if (string.Compare(getDomainTopicResponse.ProvisioningState, "Succeeded", true) != 0)
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));
                }

                getDomainTopicResponse = this.EventGridManagementClient.DomainTopics.Get(resourceGroup, domainName, domainTopicName1);
                Assert.NotNull(getDomainTopicResponse);
                Assert.Equal("Succeeded", getDomainTopicResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);

                createDomainTopicResponse = this.EventGridManagementClient.DomainTopics.CreateOrUpdateAsync(resourceGroup, domainName, domainTopicName2).Result;

                Assert.NotNull(createDomainTopicResponse);
                Assert.Equal(createDomainTopicResponse.Name, domainTopicName2);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Get the created domain Topic
                getDomainTopicResponse = this.EventGridManagementClient.DomainTopics.Get(resourceGroup, domainName, domainTopicName2);
                if (string.Compare(getDomainTopicResponse.ProvisioningState, "Succeeded", true) != 0)
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));
                }

                getDomainTopicResponse = this.EventGridManagementClient.DomainTopics.Get(resourceGroup, domainName, domainTopicName2);
                Assert.NotNull(getDomainTopicResponse);
                Assert.Equal("Succeeded", getDomainTopicResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);


                // Get all domainTopics created within a resourceGroup
                IPage<DomainTopic> domainTopicsInDomainPage = this.EventGridManagementClient.DomainTopics.ListByDomainAsync(resourceGroup, domainName).Result;
                var domainTopicsInResourceGroupList = new List<DomainTopic>();
                if (domainTopicsInDomainPage.Any())
                {
                    domainTopicsInResourceGroupList.AddRange(domainTopicsInDomainPage);
                    var nextLink = domainTopicsInDomainPage.NextPageLink;
                    while (nextLink != null)
                    {
                        domainTopicsInDomainPage = this.EventGridManagementClient.DomainTopics.ListByDomainNextAsync(nextLink).Result;
                        domainTopicsInResourceGroupList.AddRange(domainTopicsInDomainPage);
                        nextLink = domainTopicsInDomainPage.NextPageLink;
                    }
                }

                Assert.NotNull(domainTopicsInResourceGroupList);
                Assert.True(domainTopicsInResourceGroupList.Count() == 2);
                Assert.Contains(domainTopicsInResourceGroupList, t => t.Name == domainTopicName1);
                Assert.Contains(domainTopicsInResourceGroupList, t => t.Name == domainTopicName2);
                Assert.True(domainTopicsInResourceGroupList.All(ns => ns.Id.Contains(resourceGroup)));
                Assert.True(domainTopicsInResourceGroupList.All(ns => ns.Id.Contains(domainName)));

                // Delete domainTopics
                this.EventGridManagementClient.DomainTopics.DeleteAsync(resourceGroup, domainName, domainTopicName1).Wait();
                this.EventGridManagementClient.DomainTopics.DeleteAsync(resourceGroup, domainName, domainTopicName2).Wait();

                // Delete domain
                this.EventGridManagementClient.Domains.DeleteAsync(resourceGroup, domainName).Wait();
            }
        }
    }
}