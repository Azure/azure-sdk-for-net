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
        // Disable the test as system topic is not part of GA API yet.
        //////[Fact]
        //////public void SystemTopicCreateGetUpdateDelete()
        //////{
        //////    using (MockContext context = MockContext.Start(this.GetType()))
        //////    {
        //////        this.InitializeClients(context);

        //////        var location = this.ResourceManagementClient.GetLocationFromProvider();

        //////        string resourceGroup = "testtobedeleted";
        //////        var systemTopicName = TestUtilities.GenerateName(EventGridManagementHelper.SystemTopicPrefix);

        //////        // Temporarily commenting this out as this is not yet enabled for the new API version
        //////        // var operationsResponse = this.EventGridManagementClient.Operations.List();

        //////        var originalTagsDictionary = new Dictionary<string, string>()
        //////        {
        //////            {"originalTag1", "originalValue1"},
        //////            {"originalTag2", "originalValue2"}
        //////        };

        //////        SystemTopic systemTopic = new SystemTopic()
        //////        {
        //////            Location = location,
        //////            Tags = originalTagsDictionary,
        //////            TopicType = "microsoft.storage.storageaccounts",
        //////            Source = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/testtobedeleted/providers/Microsoft.Storage/storageAccounts/testtrackedsourcev2",
        //////        };

        //////        try
        //////        {
        //////            var createSystemTopicResponse = this.EventGridManagementClient.SystemTopics.CreateOrUpdateAsync(resourceGroup, systemTopicName, systemTopic).Result;

        //////            Assert.NotNull(createSystemTopicResponse);
        //////            Assert.Equal(createSystemTopicResponse.Name, systemTopicName);

        //////            TestUtilities.Wait(TimeSpan.FromSeconds(5));

        //////            // Get the created systemTopic
        //////            var getSystemTopicResponse = this.EventGridManagementClient.SystemTopics.Get(resourceGroup, systemTopicName);
        //////            if (string.Compare(getSystemTopicResponse.ProvisioningState, "Succeeded", true) != 0)
        //////            {
        //////                TestUtilities.Wait(TimeSpan.FromSeconds(5));
        //////            }

        //////            getSystemTopicResponse = this.EventGridManagementClient.SystemTopics.Get(resourceGroup, systemTopicName);
        //////            Assert.NotNull(getSystemTopicResponse);
        //////            Assert.Equal("Succeeded", getSystemTopicResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
        //////            Assert.Equal(location, getSystemTopicResponse.Location, StringComparer.CurrentCultureIgnoreCase);

        //////            // Get all systemTopics created within a resourceGroup
        //////            IPage<SystemTopic> systemTopicsInResourceGroupPage = this.EventGridManagementClient.SystemTopics.ListByResourceGroupAsync(resourceGroup).Result;
        //////            var systemTopicsInResourceGroupList = new List<SystemTopic>();
        //////            if (systemTopicsInResourceGroupPage.Any())
        //////            {
        //////                systemTopicsInResourceGroupList.AddRange(systemTopicsInResourceGroupPage);
        //////                var nextLink = systemTopicsInResourceGroupPage.NextPageLink;
        //////                while (nextLink != null)
        //////                {
        //////                    systemTopicsInResourceGroupPage = this.EventGridManagementClient.SystemTopics.ListByResourceGroupNextAsync(nextLink).Result;
        //////                    systemTopicsInResourceGroupList.AddRange(systemTopicsInResourceGroupPage);
        //////                    nextLink = systemTopicsInResourceGroupPage.NextPageLink;
        //////                }
        //////            }

        //////            Assert.NotNull(systemTopicsInResourceGroupList);
        //////            Assert.True(systemTopicsInResourceGroupList.Count() >= 1);
        //////            Assert.Contains(systemTopicsInResourceGroupList, t => t.Name == systemTopicName);
        //////            Assert.True(systemTopicsInResourceGroupList.All(ns => ns.Id.Contains(resourceGroup)));

        //////            IPage<SystemTopic> systemTopicsInResourceGroupPageWithTop = this.EventGridManagementClient.SystemTopics.ListByResourceGroupAsync(resourceGroup, null, 5).Result;
        //////            var systemTopicsInResourceGroupListWithTop = new List<SystemTopic>();
        //////            if (systemTopicsInResourceGroupPageWithTop.Any())
        //////            {
        //////                systemTopicsInResourceGroupListWithTop.AddRange(systemTopicsInResourceGroupPageWithTop);
        //////                var nextLink = systemTopicsInResourceGroupPageWithTop.NextPageLink;
        //////                while (nextLink != null)
        //////                {
        //////                    systemTopicsInResourceGroupPageWithTop = this.EventGridManagementClient.SystemTopics.ListByResourceGroupNextAsync(nextLink).Result;
        //////                    systemTopicsInResourceGroupListWithTop.AddRange(systemTopicsInResourceGroupPageWithTop);
        //////                    nextLink = systemTopicsInResourceGroupPageWithTop.NextPageLink;
        //////                }
        //////            }

        //////            Assert.NotNull(systemTopicsInResourceGroupListWithTop);
        //////            Assert.True(systemTopicsInResourceGroupListWithTop.Count() >= 1);
        //////            Assert.Contains(systemTopicsInResourceGroupListWithTop, t => t.Name == systemTopicName);
        //////            Assert.True(systemTopicsInResourceGroupListWithTop.All(ns => ns.Id.Contains(resourceGroup)));

        //////            // Get all systemTopics created within the subscription irrespective of the resourceGroup
        //////            IPage<SystemTopic> systemTopicsInAzureSubscription = this.EventGridManagementClient.SystemTopics.ListBySubscriptionAsync(null, 100).Result;
        //////            var systemTopicsInAzureSubscriptionList = new List<SystemTopic>();
        //////            if (systemTopicsInAzureSubscription.Any())
        //////            {
        //////                systemTopicsInAzureSubscriptionList.AddRange(systemTopicsInAzureSubscription);
        //////                var nextLink = systemTopicsInAzureSubscription.NextPageLink;
        //////                while (nextLink != null)
        //////                {
        //////                    try
        //////                    {
        //////                        systemTopicsInAzureSubscription = this.EventGridManagementClient.SystemTopics.ListBySubscriptionNextAsync(nextLink).Result;
        //////                        systemTopicsInAzureSubscriptionList.AddRange(systemTopicsInAzureSubscription);
        //////                        nextLink = systemTopicsInAzureSubscription.NextPageLink;
        //////                    }
        //////                    catch (Exception ex)
        //////                    {
        //////                        Console.WriteLine(ex);
        //////                        break;
        //////                    }
        //////                }
        //////            }

        //////            Assert.NotNull(systemTopicsInAzureSubscriptionList);
        //////            Assert.True(systemTopicsInAzureSubscriptionList.Count() >= 1);
        //////            Assert.Contains(systemTopicsInAzureSubscriptionList, t => t.Name == systemTopicName);

        //////            var replaceSystemTopicTagsDictionary = new Dictionary<string, string>()
        //////            {
        //////                { "replacedTag1", "replacedValue1" },
        //////                { "replacedTag2", "replacedValue2" }
        //////            };

        //////            // Replace the systemTopic
        //////            systemTopic.Tags = replaceSystemTopicTagsDictionary;
        //////            var replaceSystemTopicResponse = this.EventGridManagementClient.SystemTopics.CreateOrUpdateAsync(resourceGroup, systemTopicName, systemTopic).Result;

        //////            Assert.Contains(replaceSystemTopicResponse.Tags, tag => tag.Key == "replacedTag1");
        //////            Assert.DoesNotContain(replaceSystemTopicResponse.Tags, tag => tag.Key == "originalTag1");

        //////            // Update the systemTopic with tags & allow traffic from all ips
        //////            SystemTopicUpdateParameters systemTopicUpdateParameters = new SystemTopicUpdateParameters();
        //////            systemTopicUpdateParameters.Tags = new Dictionary<string, string>()
        //////            {
        //////                { "updatedTag1", "updatedValue1" },
        //////                { "updatedTag2", "updatedValue2" }
        //////            };

        //////            var updateSystemTopicResponse = this.EventGridManagementClient.SystemTopics.UpdateAsync(resourceGroup, systemTopicName, systemTopicUpdateParameters.Tags).Result;
        //////            Assert.Contains(updateSystemTopicResponse.Tags, tag => tag.Key == "updatedTag1");
        //////            Assert.DoesNotContain(updateSystemTopicResponse.Tags, tag => tag.Key == "replacedTag1");
        //////        }
        //////        finally
        //////        {
        //////            // Delete systemTopic
        //////            this.EventGridManagementClient.SystemTopics.DeleteAsync(resourceGroup, systemTopicName).Wait();
        //////        }
        //////    }
        //////}
    }
}