// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.ResourceManager.EnergyServices.Tests.Helpers;
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
        public void ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                CreateCommonClient();
            }
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        public async void TestEnergyServicesOperations()
        {
            var resourceGroupName = Recording.GenerateAssetName("SdkRg");
            await EnergyServicesTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,
                EnergyServicesTestUtilities.DefaultResourceLocation, resourceGroupName);
            var energyServicesResourceName = Recording.GenerateAssetName("SdkAddress");
            EnergyServiceCollection energyServicesCollection = await GetEnergyServicesCollectionAsync(resourceGroupName);
            //EnergyServiceData energyServiceData = new EnergyServiceData();
            var createAddressOperation = await energyServicesCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName: energyServicesResourceName );
        }
    }
}
