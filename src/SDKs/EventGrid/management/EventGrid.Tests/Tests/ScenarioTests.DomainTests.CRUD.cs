// Copyright(c) Microsoft Corporation.All rights reserved.

// Licensed under the MIT License.See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.EventGrid;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using EventGrid.Tests.TestHelper;
using Xunit;
using System.Threading;

namespace EventGrid.Tests.ScenarioTests
{
    public partial class ScenarioTests
    {
        [Fact]
        public void DomainCreateGetUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.InitializeClients(context);
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(300));

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(EventGridManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                var domainName = TestUtilities.GenerateName(EventGridManagementHelper.DomainPrefix);

                var domainTopicName = TestUtilities.GenerateName(EventGridManagementHelper.DomainTopicPrefix);

                var originalTagsDictionary = new Dictionary<string, string>()
                {
                    {"originalTag1", "originalValue1"},
                    {"originalTag2", "originalValue2"}
                };

                Domain domain = new Domain()
                {
                    Location = location,
                    Tags = originalTagsDictionary
                };

                var createDomainResponse = this.EventGridManagementClient.Domains.CreateOrUpdateAsync(resourceGroup, domainName, domain, cancellationTokenSource.Token).Result;

                Assert.NotNull(createDomainResponse);
                Assert.Equal(createDomainResponse.Name, domainName, StringComparer.CurrentCultureIgnoreCase);

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

                // Get all domains created within a resourceGroup
                var getAllDomainsResponse = this.EventGridManagementClient.Domains.ListByResourceGroupAsync(resourceGroup, cancellationTokenSource.Token).Result;
                Assert.NotNull(getAllDomainsResponse);
                Assert.True(getAllDomainsResponse.Count() >= 1);
                Assert.Contains(getAllDomainsResponse, t => t.Name == domainName);
                Assert.True(getAllDomainsResponse.All(ns => ns.Id.Contains(resourceGroup)));

                // Get all domains created within the subscription irrespective of the resourceGroup
                getAllDomainsResponse = this.EventGridManagementClient.Domains.ListBySubscriptionAsync(cancellationTokenSource.Token).Result;
                Assert.NotNull(getAllDomainsResponse);
                Assert.True(getAllDomainsResponse.Count() >= 1);
                Assert.Contains(getAllDomainsResponse, t => t.Name == domainName);

                var replaceDomainTagsDictionary = new Dictionary<string, string>()
                {
                    { "replacedTag1", "replacedValue1" },
                    { "replacedTag2", "replacedValue2" }
                };

                // Replace the domain
                domain.Tags = replaceDomainTagsDictionary;
                var replaceDomainResponse = this.EventGridManagementClient.Domains.CreateOrUpdateAsync(resourceGroup, domainName, domain, cancellationTokenSource.Token).Result;

                Assert.Contains(replaceDomainResponse.Tags, tag => tag.Key == "replacedTag1");
                Assert.DoesNotContain(replaceDomainResponse.Tags, tag => tag.Key == "originalTag1");

                // Update the domain
                var updateDomainTagsDictionary = new Dictionary<string, string>()
                {
                    { "updatedTag1", "updatedValue1" },
                    { "updatedTag2", "updatedValue2" }
                };

                var updateDomainResponse = this.EventGridManagementClient.Domains.UpdateAsync(resourceGroup, domainName, updateDomainTagsDictionary, cancellationTokenSource.Token).Result;
                Assert.Contains(updateDomainResponse.Tags, tag => tag.Key == "updatedTag1");
                Assert.DoesNotContain(updateDomainResponse.Tags, tag => tag.Key == "replacedTag1");

                // Get domain keys
                var getKeysResponse = this.EventGridManagementClient.Domains.ListSharedAccessKeysAsync(resourceGroup, domainName, cancellationTokenSource.Token).Result;
                Assert.True(!string.IsNullOrEmpty(getKeysResponse.Key1) && !string.IsNullOrEmpty(getKeysResponse.Key2));

                // Generate new domain keys
                var generateKey1Response = this.EventGridManagementClient.Domains.RegenerateKeyAsync(resourceGroup, domainName, "Key1", cancellationTokenSource.Token).Result;
                Assert.True(!string.IsNullOrEmpty(generateKey1Response.Key1) && !string.IsNullOrEmpty(generateKey1Response.Key2));
                Assert.True(!getKeysResponse.Key1.Equals(generateKey1Response.Key1, StringComparison.OrdinalIgnoreCase));
                Assert.Equal(getKeysResponse.Key2, generateKey1Response.Key2, StringComparer.CurrentCultureIgnoreCase);

                // Create an event subscription to this domain
                var eventSubscriptionName = TestUtilities.GenerateName(EventGridManagementHelper.EventSubscriptionPrefix);
                string scope = $"/subscriptions/55f3dcd4-cac7-43b4-990b-a139d62a1eb2/resourceGroups/{resourceGroup}/providers/Microsoft.EventGrid/domains/{domainName}/topics/{domainTopicName}";

                EventSubscription eventSubscription = new EventSubscription()
                {
                    Destination = new WebHookEventSubscriptionDestination()
                    {
                        EndpointUrl = AzureFunctionEndpointUrl
                    },
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
                    }
                };

                var eventSubscriptionResponse = this.EventGridManagementClient.EventSubscriptions.CreateOrUpdateAsync(scope, eventSubscriptionName, eventSubscription).Result;
                Assert.NotNull(eventSubscriptionResponse);
                Assert.Equal(eventSubscriptionResponse.Name, eventSubscriptionName, StringComparer.CurrentCultureIgnoreCase);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Get the created event subscription
                eventSubscriptionResponse = EventGridManagementClient.EventSubscriptions.Get(scope, eventSubscriptionName);
                if (string.Compare(eventSubscriptionResponse.ProvisioningState, "Succeeded", true) != 0)
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));
                }

                // Get the specific domain topic info.
                var domainTopicResponse = this.EventGridManagementClient.DomainTopics.Get(resourceGroup, domainName, domainTopicName);
                Assert.NotNull(domainTopicResponse);
                Assert.Equal(domainTopicResponse.Name, domainTopicName, StringComparer.CurrentCultureIgnoreCase);

                // List all the domain topics info.
                var allDomainTopicsResponse = this.EventGridManagementClient.DomainTopics.ListByDomain(resourceGroup, domainName);
                Assert.NotNull(allDomainTopicsResponse);
                Assert.True(allDomainTopicsResponse.Count() == 1);
                Assert.Contains(allDomainTopicsResponse, t => t.Name.ToLower() == domainTopicName.ToLower());
                Assert.True(allDomainTopicsResponse.All(ns => ns.Id.Contains(resourceGroup.ToLower())));

                // Delete domain
                this.EventGridManagementClient.Domains.DeleteAsync(resourceGroup, domainName, cancellationTokenSource.Token).Wait();
            }
        }

        [Fact]
        public void DomainCreateGetUpdateDeleteWithCustomInputMappings()
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

                var domainName = TestUtilities.GenerateName(EventGridManagementHelper.DomainPrefix);

                Domain domain = new Domain()
                {
                    Location = location,
                    InputSchema = InputSchema.CustomEventSchema,
                    InputSchemaMapping = new JsonInputSchemaMapping()
                    {
                        Id = new JsonField()
                        {
                            SourceField = "myid"
                        },
                        Topic = new JsonField
                        {
                            SourceField = "myTopic"
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

                var createDomainResponse = this.EventGridManagementClient.Domains.CreateOrUpdateAsync(resourceGroup, domainName, domain).Result;

                Assert.NotNull(createDomainResponse);
                Assert.Equal(createDomainResponse.Name, domainName, StringComparer.CurrentCultureIgnoreCase);

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
                Assert.Equal(createDomainResponse.InputSchema, InputSchema.CustomEventSchema);
                Assert.NotNull(createDomainResponse.InputSchemaMapping);

                // Delete domain
                this.EventGridManagementClient.Domains.DeleteAsync(resourceGroup, domainName).Wait();
            }
        }

        [Fact]
        public void DomainCreateGetUpdateDeleteWithCloudEvent()
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

                var domainName = TestUtilities.GenerateName(EventGridManagementHelper.DomainPrefix);

                Domain domain = new Domain()
                {
                    Location = location,
                    InputSchema = InputSchema.CloudEventV01Schema
                };

                var createDomainResponse = this.EventGridManagementClient.Domains.CreateOrUpdateAsync(resourceGroup, domainName, domain).Result;

                Assert.NotNull(createDomainResponse);
                Assert.Equal(createDomainResponse.Name, domainName, StringComparer.CurrentCultureIgnoreCase);

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
                Assert.Equal(createDomainResponse.InputSchema, InputSchema.CloudEventV01Schema, StringComparer.CurrentCultureIgnoreCase);
                Assert.Null(createDomainResponse.InputSchemaMapping);

                // Delete domain
                this.EventGridManagementClient.Topics.DeleteAsync(resourceGroup, domainName).Wait();
            }
        }
    }
}

