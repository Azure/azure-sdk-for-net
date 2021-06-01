// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Communication.Models;

namespace Azure.ResourceManager.Communication.Tests
{
    public class ListResourcesTests : CommunicationManagementClientLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListResourcesTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public ListResourcesTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void Setup()
        {
            InitializeClients();
        }

        [TearDown]
        public async Task Cleanup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task ListBySubscription()
        {
            // Setup resource group for the test. This resource group is deleted by CleanupResourceGroupsAsync after the test ends
            ResourceGroup rg = await ResourcesManagementClient.ResourceGroups.CreateOrUpdateAsync(
                Recording.GenerateAssetName(ResourceGroupPrefix),
                new ResourceGroup(Location));

            // Create a new resource with the test parameters
            CommunicationManagementClient acsClient = GetCommunicationManagementClient();
            var resourceName = Recording.GenerateAssetName("sdk-test-list-by-subscription-");
            var testResource = new CommunicationServiceResource { Location = ResourceLocation, DataLocation = ResourceDataLocation };

            CommunicationServiceCreateOrUpdateOperation result = await acsClient.CommunicationService.StartCreateOrUpdateAsync(
                rg.Name,
                resourceName,
                testResource);
            await result.WaitForCompletionAsync();

            Assert.IsTrue(result.HasCompleted);
            Assert.IsTrue(result.HasValue);

            // Verify that the resource we just created is in the list
            var resources = acsClient.CommunicationService.ListBySubscriptionAsync();
            bool resourceFound = false;
            await foreach (var resource in resources)
            {
                if (resource.Name.Equals(resourceName))
                {
                    resourceFound = true;
                    break;
                }
            }
            Assert.True(resourceFound);
        }

        [Test]
        public async Task ListByRg()
        {
            // Setup resource group for the test. This resource group is deleted by CleanupResourceGroupsAsync after the test ends
            ResourceGroup rg = await ResourcesManagementClient.ResourceGroups.CreateOrUpdateAsync(
                Recording.GenerateAssetName(ResourceGroupPrefix),
                new ResourceGroup(Location));

            // Create a new resource with the test parameters
            CommunicationManagementClient acsClient = GetCommunicationManagementClient();
            var resourceName = Recording.GenerateAssetName("sdk-test-list-by-rg-");
            var testResource = new CommunicationServiceResource { Location = ResourceLocation, DataLocation = ResourceDataLocation };

            CommunicationServiceCreateOrUpdateOperation result = await acsClient.CommunicationService.StartCreateOrUpdateAsync(
                rg.Name,
                resourceName,
                testResource);
            await result.WaitForCompletionAsync();

            Assert.IsTrue(result.HasCompleted);
            Assert.IsTrue(result.HasValue);

            // Verify that the resource we just created is in the list
            var resources = acsClient.CommunicationService.ListByResourceGroupAsync(rg.Name);
            bool resourceFound = false;
            await foreach (var resource in resources)
            {
                if (resource.Name.Equals(resourceName))
                {
                    resourceFound = true;
                    break;
                }
            }
            Assert.True(resourceFound);
        }
    }
}
