// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DevCenter.Tests
{
    public class DevCenterOperationsTests : DevCenterManagementTestBase
    {
        public DevCenterOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        [PlaybackOnly("TODO")]
        public async Task DevCenterResourceFull()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            ArmOperation<ResourceGroupResource> rgResponse = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.ResourceGroup, new ResourceGroupData(TestEnvironment.Location)).ConfigureAwait(false);
            ResourceGroupResource rg = rgResponse.Value;

            DevCenterCollection devCenterCollection = rg.GetDevCenters();

            string devCenterName = "sdktest-devcenter";

            // Create a DevCenter resource

            var devCenterData = new DevCenterData(TestEnvironment.Location);
            ArmOperation<DevCenterResource> createdDevCenterResponse = await devCenterCollection.CreateOrUpdateAsync(WaitUntil.Completed, devCenterName, devCenterData);
            DevCenterResource devCenterResource = createdDevCenterResponse.Value;

            Assert.NotNull(devCenterResource);
            Assert.NotNull(devCenterResource.Data);

            // List DevCenters
            AsyncPageable<DevCenterResource> devCenters = devCenterCollection.GetAllAsync();
            int count = 0;
            await foreach (DevCenterResource v in devCenters)
            {
                if (v.Id == devCenterResource.Id)
                {
                    count++;
                    break;
                }
            }
            Assert.True(count == 1);

            // Get
            Response<DevCenterResource> retrievedDevCenter = await devCenterCollection.GetAsync(devCenterName);
            Assert.NotNull(retrievedDevCenter.Value);
            Assert.NotNull(retrievedDevCenter.Value.Data);

            // Update
            DevCenterData updatedData = new DevCenterData(TestEnvironment.Location);
            updatedData.Tags["t1"] = "v1";

            ArmOperation<DevCenterResource> updatedDevCenter = await devCenterCollection.CreateOrUpdateAsync(WaitUntil.Completed, devCenterName, updatedData);

            // Delete
            ArmOperation deleteOp = await updatedDevCenter.Value.DeleteAsync(WaitUntil.Completed);
        }

        ////[Test]
        ////public async Task KeyVaultManagementVaultCreateWithoutAccessPolicies()
        ////{
        ////    IgnoreTestInLiveMode();
        ////    KeyVaultProperties vaultProperties = new KeyVaultProperties(TenantIdGuid, new KeyVaultSku(KeyVaultSkuFamily.A, KeyVaultSkuName.Standard));
        ////    KeyVaultCreateOrUpdateContent content = new KeyVaultCreateOrUpdateContent(Location, vaultProperties);
        ////    ArmOperation<KeyVaultResource> rawVault = await VaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, VaultName, content);
        ////    KeyVaultData createdVault = rawVault.Value.Data;
        ////    Assert.IsNotNull(createdVault);
        ////    Assert.AreEqual(VaultName, createdVault.Name);
        ////}
    }
}
