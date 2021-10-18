// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Communication.Models;
using Azure.Core.TestFramework;

namespace Azure.ResourceManager.Communication.Tests
{
    public class CheckNameAvailabilityTests : CommunicationManagementClientLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckNameAvailabilityTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public CheckNameAvailabilityTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public void Setup()
        {
            InitializeClients();
        }

        [Test]
        public async Task CheckNameUniqueness()
        {
            // Setup resource group for the test. This resource group is deleted by CleanupResourceGroupsAsync after the test ends
            var lro = await ArmClient.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                Recording.GenerateAssetName(ResourceGroupPrefix),
                new ResourceGroupData(Location));
            ResourceGroup rg = lro.Value;

            var resourceName = Recording.GenerateAssetName("sdk-test-name-availablity-");

            ResourceIdentifier testId = rg.Id.AppendProviderResource("Microsoft.Communication", "CommunicationServices", resourceName);

            // Check if name is unique
            CommunicationService testComService = ArmClient.GetCommunicationService(testId);
            Response<NameAvailability> nameAvailabilityResult = await testComService.CheckNameAvailabilityAsync(new NameAvailabilityParameters("Microsoft.Communication/CommunicationServices", resourceName));
            Assert.IsTrue(nameAvailabilityResult.Value.NameAvailable);

            // Create a new resource with a our test parameters
            CommunicationServiceCreateOrUpdateOperation result = await rg.GetCommunicationServices().CreateOrUpdateAsync(
                resourceName,
                new CommunicationServiceData { Location = ResourceLocation, DataLocation = ResourceDataLocation });
            await result.WaitForCompletionAsync();

            // Check that our resource has been created successfully
            Assert.IsTrue(result.HasCompleted);
            Assert.IsTrue(result.HasValue);
            CommunicationService resource = result.Value;

            // Retrieve
            CommunicationService resourceRetrieved = await resource.GetAsync();

            Assert.AreEqual(
                resourceName,
                resourceRetrieved.Data.Name);
            Assert.AreEqual(
                "Succeeded",
                resourceRetrieved.Data.ProvisioningState.ToString());

            // Check if name is unique
            nameAvailabilityResult = await resource.CheckNameAvailabilityAsync(new NameAvailabilityParameters("Microsoft.Communication/CommunicationServices", resourceName));
            Assert.IsFalse(nameAvailabilityResult.Value.NameAvailable);
        }
    }
}
