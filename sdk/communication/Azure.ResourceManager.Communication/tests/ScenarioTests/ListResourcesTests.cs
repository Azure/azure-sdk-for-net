// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Communication.Models;
using Azure.Core.TestFramework;

namespace Azure.ResourceManager.Communication.Tests
{
    public class ListResourcesTests : CommunicationManagementClientLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListResourcesTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public ListResourcesTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public void Setup()
        {
            InitializeClients();
        }

        [Test]
        public async Task ListBySubscription()
        {
            // Setup resource group for the test. This resource group is deleted by CleanupResourceGroupsAsync after the test ends
            var lro = await ArmClient.GetDefaultSubscription().GetResourceGroups().CreateOrUpdateAsync(
                Recording.GenerateAssetName(ResourceGroupPrefix),
                new ResourceGroupData(Location));
            ResourceGroup rg = lro.Value;

            // Create a new resource with the test parameters
            var resourceName = Recording.GenerateAssetName("sdk-test-list-by-subscription-");
            var testResource = new CommunicationServiceData { Location = ResourceLocation, DataLocation = ResourceDataLocation };

            CommunicationServiceCreateOrUpdateOperation result = await rg.GetCommunicationServices().CreateOrUpdateAsync(
                resourceName,
                testResource);
            await result.WaitForCompletionAsync();

            Assert.IsTrue(result.HasCompleted);
            Assert.IsTrue(result.HasValue);

            // Verify that the resource we just created is in the list
            var resources = ArmClient.GetDefaultSubscription().GetCommunicationServicesAsync();
            bool resourceFound = false;
            await foreach (var resource in resources)
            {
                if (resource.Data.Name.Equals(resourceName))
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
            var lro = await ArmClient.GetDefaultSubscription().GetResourceGroups().CreateOrUpdateAsync(
                Recording.GenerateAssetName(ResourceGroupPrefix),
                new ResourceGroupData(Location));
            ResourceGroup rg = lro.Value;

            // Create a new resource with the test parameters
            var resourceName = Recording.GenerateAssetName("sdk-test-list-by-rg-");
            var testResource = new CommunicationServiceData { Location = ResourceLocation, DataLocation = ResourceDataLocation };

            CommunicationServiceCreateOrUpdateOperation result = await rg.GetCommunicationServices().CreateOrUpdateAsync(
                resourceName,
                testResource);
            await result.WaitForCompletionAsync();

            Assert.IsTrue(result.HasCompleted);
            Assert.IsTrue(result.HasValue);

            // Verify that the resource we just created is in the list
            var resources = rg.GetCommunicationServices().GetAllAsync();
            bool resourceFound = false;
            await foreach (var resource in resources)
            {
                if (resource.Data.Name.Equals(resourceName))
                {
                    resourceFound = true;
                    break;
                }
            }
            Assert.True(resourceFound);
        }
    }
}
