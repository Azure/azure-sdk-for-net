﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.KeyVault.Tests
{
    public class ManagedHsmTests : VaultOperationsTestsBase
    {
        public ManagedHsmTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize().ConfigureAwait(false).GetAwaiter().GetResult();
                Location = "eastus2";
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task ManagedHsmCreateUpdateDelete()
        {
            var parameters = new ManagedHsmData(Location)
            {
                Sku = new ManagedHsmSku(ManagedHsmSkuFamily.B, ManagedHsmSkuName.StandardB1),
                Properties = ManagedHsmProperties
            };
            parameters.Tags.InitializeFrom(Tags);

            var managedHsm = await ManagedHsmContainer.CreateOrUpdateAsync(VaultName, parameters).ConfigureAwait(false);

            ValidateVault(managedHsm.Value.Data,
                VaultName,
                ResGroupName,
                TestEnvironment.SubscriptionId,
                TenantIdGuid,
                Location,
                ManagedHsmSkuFamily.B,
                ManagedHsmSkuName.StandardB1,
                CreateMode.Default,
                true,
                true,
                new List<string> { ObjectId },
                ManagedHsmProperties.NetworkAcls,
                PublicNetworkAccess.Disabled,
                new DateTimeOffset(2008, 5, 1, 8, 6, 32, new TimeSpan(1, 0, 0)),
                10,
                Tags);

            managedHsm.Value.Data.Properties.PublicNetworkAccess = PublicNetworkAccess.Enabled;
            managedHsm.Value.Data.Properties.NetworkAcls.DefaultAction = "Allow";
            parameters = new ManagedHsmData(Location)
            {
                Sku = new ManagedHsmSku(ManagedHsmSkuFamily.B, ManagedHsmSkuName.StandardB1),
                Properties = managedHsm.Value.Data.Properties
            };
            parameters.Tags.InitializeFrom(Tags);

            var updateManagedHsm = await ManagedHsmContainer.CreateOrUpdateAsync(VaultName, parameters).ConfigureAwait(false);

            ValidateVault(updateManagedHsm.Value.Data,
                VaultName,
                ResGroupName,
                TestEnvironment.SubscriptionId,
                TenantIdGuid,
                Location,
                ManagedHsmSkuFamily.B,
                ManagedHsmSkuName.StandardB1,
                CreateMode.Default,
                true,
                true,
                new List<string> { ObjectId },
                ManagedHsmProperties.NetworkAcls,
                PublicNetworkAccess.Enabled,
                new DateTimeOffset(2008, 5, 1, 8, 6, 32, new TimeSpan(1, 0, 0)),
                20,
                Tags);

            var retrievedVault = await ManagedHsmContainer.GetAsync(VaultName);

            ValidateVault(retrievedVault.Value.Data,
                VaultName,
                ResGroupName,
                TestEnvironment.SubscriptionId,
                TenantIdGuid,
                Location,
                ManagedHsmSkuFamily.B,
                ManagedHsmSkuName.StandardB1,
                CreateMode.Default,
                true,
                true,
                new List<string> { ObjectId },
                ManagedHsmProperties.NetworkAcls,
                PublicNetworkAccess.Enabled,
                new DateTimeOffset(2008, 5, 1, 8, 6, 32, new TimeSpan(1, 0, 0)),
                20,
                Tags);

            // Delete
            await retrievedVault.Value.DeleteAsync();

            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await ManagedHsmContainer.GetAsync(VaultName);
            });
        }

        [Test]
        public async Task ManagedHsmListKeys()
        {
            int n = 3;
            int top = 2;

            List<string> resourceIds = new List<string>();
            List<ManagedHsm> vaultList = new List<ManagedHsm>();
            for (int i = 0; i < n; i++)
            {
                string vaultName = Recording.GenerateAssetName("sdktestvault");
                var parameters = new ManagedHsmData(Location)
                {
                    Sku = new ManagedHsmSku(ManagedHsmSkuFamily.B, ManagedHsmSkuName.StandardB1),
                    Properties = ManagedHsmProperties
                };
                parameters.Tags.InitializeFrom(Tags);

                var managedHsm = await ManagedHsmContainer.CreateOrUpdateAsync(vaultName, parameters).ConfigureAwait(false);

                Assert.NotNull(managedHsm.Value);
                Assert.NotNull(managedHsm.Value.Id);
                resourceIds.Add(managedHsm.Value.Id);
                vaultList.Add(managedHsm.Value);
            }

            var vaults = ManagedHsmContainer.ListAsync(top);

            await foreach (var v in vaults)
            {
                Assert.True(resourceIds.Remove(v.Id));
            }

            Assert.True(resourceIds.Count == 0);

            var allVaults = ManagedHsmContainer.ListAsync(top);
            Assert.NotNull(vaults);

            // Delete
            foreach (var item in vaultList)
            {
                ManagedHsmOperations = new ManagedHsmOperations(item, item.Id);
                await ManagedHsmOperations.DeleteAsync();
            }
        }

        [Test]
        public async Task ManagedHsmRecoverDeletedVault()
        {
            var parameters = new ManagedHsmData(Location)
            {
                Sku = new ManagedHsmSku(ManagedHsmSkuFamily.B, ManagedHsmSkuName.StandardB1),
                Properties = ManagedHsmProperties
            };
            parameters.Tags.InitializeFrom(Tags);

            var managedHsm = await ManagedHsmContainer.CreateOrUpdateAsync(VaultName, parameters).ConfigureAwait(false);

            // Delete
            ManagedHsmOperations = new ManagedHsmOperations(managedHsm.Value, managedHsm.Value.Id);
            await ManagedHsmOperations.DeleteAsync();

            // Get deleted vault
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await ManagedHsmContainer.GetAsync(VaultName);
            });

            // Recover in default mode
            var recoveredVault = await ManagedHsmContainer.CreateOrUpdateAsync(VaultName, parameters).ConfigureAwait(false);
            Assert.True(recoveredVault.Value.Data.IsEqual(managedHsm.Value.Data));

            // Get recovered vault
            var getResult = await ManagedHsmContainer.GetAsync(VaultName);

            // Delete
            await getResult.Value.DeleteAsync();

            parameters.Properties.CreateMode = CreateMode.Recover;

            // Recover in recover mode
            var recoveredVault2 = await ManagedHsmContainer.CreateOrUpdateAsync(VaultName, parameters).ConfigureAwait(false);

            Assert.True(recoveredVault2.Value.Data.IsEqual(managedHsm.Value.Data));

            // Get recovered vault
            getResult = await ManagedHsmContainer.GetAsync(VaultName);

            // Delete
            await getResult.Value.DeleteAsync();
        }

        private void ValidateVault(
            ManagedHsmData managedHsmData,
            string expectedVaultName,
            string expectedResourceGroupName,
            string expectedSubId,
            Guid expectedTenantId,
            string expectedLocation,
            ManagedHsmSkuFamily expectedSkuFamily,
            ManagedHsmSkuName expectedSkuName,
            CreateMode expectedCreateMode,
            bool expectedEnablePurgeProtection,
            bool expectedEnableSoftDelete,
            List<string> expectedInitialAdminObjectIds,
            MhsmNetworkRuleSet expectedNetworkAcls,
            PublicNetworkAccess expectedPublicNetworkAccess,
            DateTimeOffset expectedScheduledPurgeDate,
            int expectedSoftDeleteRetentionInDays,
            Dictionary<string, string> expectedTags)
        {
            Assert.NotNull(managedHsmData);
            Assert.NotNull(managedHsmData.Properties);

            string resourceIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.KeyVault/managedHSMs/{2}";
            string expectedResourceId = string.Format(resourceIdFormat, expectedSubId, expectedResourceGroupName, expectedVaultName);
            string expectedHsmUri = $"https://{expectedVaultName}.managedhsm.azure.net/";

            Assert.AreEqual(expectedResourceId, managedHsmData.Id.ToString());
            Assert.AreEqual(expectedLocation, managedHsmData.Location.ToString());
            Assert.AreEqual(expectedTenantId, managedHsmData.Properties.TenantId);
            Assert.AreEqual(expectedVaultName, managedHsmData.Name);
            Assert.AreEqual(expectedSkuFamily, managedHsmData.Sku.Family);
            Assert.AreEqual(expectedSkuName, managedHsmData.Sku.Name);
            //Assert.AreEqual(expectedCreateMode, managedHsmData.Properties.CreateMode);
            Assert.AreEqual(expectedEnablePurgeProtection, managedHsmData.Properties.EnablePurgeProtection);
            Assert.AreEqual(expectedEnableSoftDelete, managedHsmData.Properties.EnableSoftDelete);
            Assert.AreEqual(expectedHsmUri, managedHsmData.Properties.HsmUri);
            Assert.AreEqual(expectedInitialAdminObjectIds, managedHsmData.Properties.InitialAdminObjectIds);
            Assert.AreEqual(expectedNetworkAcls.Bypass, managedHsmData.Properties.NetworkAcls.Bypass);
            Assert.AreEqual(expectedNetworkAcls.DefaultAction, managedHsmData.Properties.NetworkAcls.DefaultAction);
            //Assert.AreEqual(expectedPrivateEndpointConnections, managedHsmData.Properties.PrivateEndpointConnections);
            Assert.AreEqual(expectedPublicNetworkAccess, managedHsmData.Properties.PublicNetworkAccess);
            //Assert.AreEqual(expectedScheduledPurgeDate, managedHsmData.Properties.ScheduledPurgeDate);
            Assert.AreEqual(expectedSoftDeleteRetentionInDays, managedHsmData.Properties.SoftDeleteRetentionInDays);
            Assert.True(expectedTags.DictionaryEqual(managedHsmData.Tags));
        }
    }
}
