// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EnergyServices.Models;
using Azure.ResourceManager.EnergyServices.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EnergyServices.Tests.Tests
{
    [TestFixture]
    public class EnergyServicesTests : EnergyServicesManagementTestBase
    {
        public EnergyServicesTests() : base(true)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateCommonClient();
            }
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            //CleanupResourceGroups();
        }

        [TestCase]
        public async Task TestEnergyServicesOperations()
        {
            // Set-up
            SubscriptionResource subscription = await ArmClient.GetDefaultSubscriptionAsync();

            var resourceGroupName = Recording.GenerateAssetName("komakkarsdk");
            ResourceGroupResource rg = await CreateResourceGroup(subscription, resourceGroupName, AzureLocation.EastUS);

            var energyServicesName = "komakkarsdk11"; //Recording.GenerateAssetName("Sdk-EnergyServices");
            EnergyServiceCollection energyServiceCollection = rg.GetEnergyServices();
            EnergyServiceData energyServiceData = GetDefaultEnergyServiceData();

            // Act - Create.
            var createEnergyServicesOperation = await energyServiceCollection.CreateOrUpdateAsync(data: energyServiceData, resourceName: energyServicesName, waitUntil: WaitUntil.Completed);

            // Assert
            await createEnergyServicesOperation.WaitForCompletionAsync();
            Assert.IsTrue(createEnergyServicesOperation.HasCompleted);
            Assert.IsTrue(createEnergyServicesOperation.HasValue);

            // Act - Get
            Response<EnergyServiceResource> energyServiceResponse = await energyServiceCollection.GetAsync(energyServicesName);
            EnergyServiceResource energyServiceResource = energyServiceResponse.Value;

            // Assert
            Assert.IsNotNull(energyServiceResource);

            // Act - Delete
            var deleteEnergyServicesByNameOperation = await energyServiceResource.DeleteAsync(WaitUntil.Completed);

            // Assert
            Assert.IsTrue(deleteEnergyServicesByNameOperation.HasCompleted);
        }
    }
}
