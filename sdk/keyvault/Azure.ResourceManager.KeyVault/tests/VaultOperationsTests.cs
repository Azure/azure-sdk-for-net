// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.KeyVault.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.KeyVault.Tests
{
    [NonParallelizable]
    public class VaultOperationsTests : VaultOperationsTestsBase
    {
        public VaultOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await Initialize().ConfigureAwait(false);
            }
        }

        [Test]
        public async Task KeyVaultManagementVaultCreateWithoutAccessPolicies()
        {
            IgnoreTestInLiveMode();
            VaultProperties vaultProperties = new VaultProperties(TenantIdGuid, new KeyVaultSku(KeyVaultSkuFamily.A, KeyVaultSkuName.Standard));
            VaultCreateOrUpdateContent content = new VaultCreateOrUpdateContent(Location, vaultProperties);
            ArmOperation<VaultResource> rawVault = await VaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, VaultName, content);
            VaultData createdVault = rawVault.Value.Data;
            Assert.IsNotNull(createdVault);
            Assert.AreEqual(VaultName, createdVault.Name);
        }

        [Test]
        public async Task KeyVaultManagementVaultCreateUpdateDelete()
        {
            IgnoreTestInLiveMode();
            VaultProperties.EnableSoftDelete = null;

            VaultCreateOrUpdateContent parameters = new VaultCreateOrUpdateContent(Location, VaultProperties);
            parameters.Tags.InitializeFrom(Tags);

            ArmOperation<VaultResource> rawVault = await VaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, VaultName, parameters).ConfigureAwait(false);

            VaultData createdVault = rawVault.Value.Data;

            ValidateVault(createdVault,
                VaultName,
                ResGroupName,
                TestEnvironment.SubscriptionId,
                TenantIdGuid,
                Location,
                "A",
                KeyVaultSkuName.Standard,
                true,
                true,
                true,
                true, // enableSoftDelete defaults to true
                new[] { AccessPolicy },
                VaultProperties.NetworkAcls,
                Tags);

            //Update
            AccessPolicy.Permissions.Secrets.Clear();
            AccessPolicy.Permissions.Secrets.Add(SecretPermission.Get);
            AccessPolicy.Permissions.Secrets.Add(SecretPermission.Set);
            (AccessPolicy.Permissions.Keys as ChangeTrackingList<KeyPermission>).Reset();

            AccessPolicy.Permissions.Storage.Clear();
            AccessPolicy.Permissions.Storage.Add(StoragePermission.Get);
            AccessPolicy.Permissions.Storage.Add(StoragePermission.RegenerateKey);

            createdVault.Properties.AccessPolicies.Clear();
            createdVault.Properties.AccessPolicies.Add(AccessPolicy);
            createdVault.Properties.Sku.Name = KeyVaultSkuName.Premium;

            parameters = new VaultCreateOrUpdateContent(Location, createdVault.Properties);
            parameters.Tags.InitializeFrom(Tags);
            ArmOperation<VaultResource> rawUpdateVault = await VaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, VaultName, parameters).ConfigureAwait(false);

            VaultData updateVault = rawUpdateVault.Value.Data;

            ValidateVault(updateVault,
                VaultName,
                ResGroupName,
                TestEnvironment.SubscriptionId,
                TenantIdGuid,
                Location,
                "A",
                KeyVaultSkuName.Premium,
                true,
                true,
                true,
                true,
                new[] { AccessPolicy },
                VaultProperties.NetworkAcls,
                Tags);

            Response<VaultResource> rawRetrievedVault = await VaultCollection.GetAsync(VaultName);

            VaultData retrievedVault = rawRetrievedVault.Value.Data;
            ValidateVault(retrievedVault,
                VaultName,
                ResGroupName,
                TestEnvironment.SubscriptionId,
                TenantIdGuid,
                Location,
                "A",
                KeyVaultSkuName.Premium,
                true,
                true,
                true,
                true,
                new[] { AccessPolicy },
                VaultProperties.NetworkAcls,
                Tags);

            // Delete
            ArmOperation deleteVault = await rawRetrievedVault.Value.DeleteAsync(WaitUntil.Completed);

            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await VaultCollection.GetAsync(VaultName);
            });
        }

        [Test]
        public async Task KeyVaultManagementVaultTestCompoundIdentityAccessControlPolicy()
        {
            IgnoreTestInLiveMode();
            AccessPolicy.ApplicationId = Guid.Parse(TestEnvironment.ClientId);
            VaultProperties.EnableSoftDelete = null;

            VaultCreateOrUpdateContent parameters = new VaultCreateOrUpdateContent(Location, VaultProperties);
            parameters.Tags.InitializeFrom(Tags);

            ArmOperation<VaultResource> createVault = await VaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, VaultName, parameters).ConfigureAwait(false);
            VaultResource vaultResponse = createVault.Value;

            ValidateVault(vaultResponse.Data,
                VaultName,
                ResGroupName,
                TestEnvironment.SubscriptionId,
                TenantIdGuid,
                Location,
                "A",
                KeyVaultSkuName.Standard,
                true,
                true,
                true,
                true,
                new[] { AccessPolicy },
                Tags);

            // Get
            Response<VaultResource> retrievedVault = await VaultCollection.GetAsync(VaultName);

            ValidateVault(retrievedVault.Value.Data,
                VaultName,
                ResGroupName,
                TestEnvironment.SubscriptionId,
                TenantIdGuid,
                Location,
                "A",
                KeyVaultSkuName.Standard,
                true,
                true,
                true,
                true,
                new[] { AccessPolicy },
                Tags);

            // Delete
            await retrievedVault.Value.DeleteAsync(WaitUntil.Completed);

            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await VaultCollection.GetAsync(VaultName);
            });
        }

        [Test]
        public async Task KeyVaultManagementListVaults()
        {
            IgnoreTestInLiveMode();
            int n = 3;
            int top = 2;
            VaultProperties.EnableSoftDelete = null;

            List<string> resourceIds = new List<string>();
            List<VaultResource> vaultList = new List<VaultResource>();
            for (int i = 0; i < n; i++)
            {
                string vaultName = Recording.GenerateAssetName("sdktest-vault-");
                VaultCreateOrUpdateContent parameters = new VaultCreateOrUpdateContent(Location, VaultProperties);
                parameters.Tags.InitializeFrom(Tags);
                ArmOperation<VaultResource> createdVault = await VaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, vaultName, parameters).ConfigureAwait(false);
                VaultResource vaultValue = createdVault.Value;

                Assert.NotNull(vaultValue);
                Assert.NotNull(vaultValue.Id);
                resourceIds.Add(vaultValue.Id);
                vaultList.Add(vaultValue);
            }

            AsyncPageable<VaultResource> vaults = VaultCollection.GetAllAsync(top);

            await foreach (var v in vaults)
            {
                Assert.True(resourceIds.Remove(v.Id));
            }

            Assert.True(resourceIds.Count == 0);

            AsyncPageable<VaultResource> allVaults = VaultCollection.GetAllAsync(top);
            Assert.NotNull(vaults);

            // Delete
            foreach (var item in vaultList)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        public async Task KeyVaultManagementRecoverDeletedVault()
        {
            IgnoreTestInLiveMode();
            VaultCreateOrUpdateContent parameters = new VaultCreateOrUpdateContent(Location, VaultProperties);
            parameters.Tags.InitializeFrom(Tags);
            ArmOperation<VaultResource> createdVault = await VaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, VaultName, parameters).ConfigureAwait(false);
            VaultResource vaultValue = createdVault.Value;

            // Delete
            await vaultValue.DeleteAsync(WaitUntil.Completed);

            // Get deleted vault
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await VaultCollection.GetAsync(VaultName);
            });

            parameters = new VaultCreateOrUpdateContent(Location, VaultProperties);
            parameters.Tags.InitializeFrom(Tags);
            // Recover in default mode
            ArmOperation<VaultResource> recoveredRawVault = await VaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, VaultName,parameters).ConfigureAwait(false);
            VaultResource recoveredVault = recoveredRawVault.Value;
            Assert.True(recoveredVault.Data.IsEqual(vaultValue.Data));

            // Get recovered vault
            Response<VaultResource> getResult =  await VaultCollection.GetAsync(VaultName);

            // Delete
            await getResult.Value.DeleteAsync(WaitUntil.Completed);

            VaultProperties.CreateMode = VaultCreateMode.Recover;
            parameters = new VaultCreateOrUpdateContent(Location, VaultProperties);

            // Recover in recover mode
            ArmOperation<VaultResource> recoveredRawVault2 = await VaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, VaultName, parameters).ConfigureAwait(false);
            VaultResource recoveredVault2 = recoveredRawVault.Value;

            Assert.True(recoveredVault2.Data.IsEqual(vaultValue.Data));

            // Get recovered vault
            getResult = await VaultCollection.GetAsync(VaultName);

            // Delete
            await getResult.Value.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task KeyVaultManagementListDeletedVaults()
        {
            IgnoreTestInLiveMode();
            int n = 3;
            List<string> resourceIds = new List<string>();
            List<VaultResource> vaultList = new List<VaultResource>();
            VaultCreateOrUpdateContent parameters = new VaultCreateOrUpdateContent(Location, VaultProperties);
            parameters.Tags.InitializeFrom(Tags);
            for (int i = 0; i < n; i++)
            {
                string vaultName = Recording.GenerateAssetName("sdktest-vault-");
                ArmOperation<VaultResource> createdRawVault = await VaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, vaultName, parameters).ConfigureAwait(false);

                VaultResource createdVault = createdRawVault.Value;

                Assert.NotNull(createdVault.Data);
                Assert.NotNull(createdVault.Data.Id);
                resourceIds.Add(createdVault.Data.Id);
                vaultList.Add(createdVault);

                await createdVault.DeleteAsync(WaitUntil.Completed).ConfigureAwait(false);

                Response<DeletedVaultResource> deletedVault = await DeletedVaultCollection.GetAsync(Location, vaultName).ConfigureAwait(false);
                Assert.IsTrue(deletedVault.Value.Data.Name.Equals(createdVault.Data.Name));
            }

            List<DeletedVaultResource> deletedVaults = Subscription.GetDeletedVaultsAsync().ToEnumerableAsync().Result;
            Assert.NotNull(deletedVaults);

            foreach (var v in deletedVaults)
            {
                bool exists = resourceIds.Remove(v.Data.Properties.VaultId);
                if (resourceIds.Count == 0)
                    break;
            }

            Assert.True(resourceIds.Count == 0);
        }

        private void ValidateVault(
            VaultData vaultData,
            string expectedVaultName,
            string expectedResourceGroupName,
            string expectedSubId,
            Guid expectedTenantId,
            AzureLocation expectedLocation,
            string expectedSkuFamily,
            KeyVaultSkuName expectedSku,
            bool expectedEnabledForDeployment,
            bool expectedEnabledForTemplateDeployment,
            bool expectedEnabledForDiskEncryption,
            bool? expectedEnableSoftDelete,
            AccessPolicyEntry[] expectedPolicies,
            Dictionary<string, string> expectedTags)
        {
            Assert.NotNull(vaultData);
            Assert.NotNull(vaultData.Properties);

            string resourceIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.KeyVault/vaults/{2}";
            string expectedResourceId = string.Format(resourceIdFormat, expectedSubId, expectedResourceGroupName, expectedVaultName);

            Assert.AreEqual(expectedResourceId, vaultData.Id.ToString());
            Assert.AreEqual(expectedLocation, vaultData.Location);
            Assert.AreEqual(expectedTenantId, vaultData.Properties.TenantId);
            Assert.AreEqual(expectedSku, vaultData.Properties.Sku.Name);
            Assert.AreEqual(expectedVaultName, vaultData.Name);
            Assert.AreEqual(expectedEnabledForDeployment, vaultData.Properties.EnabledForDeployment);
            Assert.AreEqual(expectedEnabledForTemplateDeployment, vaultData.Properties.EnabledForTemplateDeployment);
            Assert.AreEqual(expectedEnabledForDiskEncryption, vaultData.Properties.EnabledForDiskEncryption);
            Assert.AreEqual(expectedEnableSoftDelete, vaultData.Properties.EnableSoftDelete);
            Assert.True(expectedTags.DictionaryEqual(vaultData.Tags));
            Assert.True(expectedPolicies.IsEqual(vaultData.Properties.AccessPolicies));
        }

        private void ValidateVault(
            VaultData vaultData,
            string expectedVaultName,
            string expectedResourceGroupName,
            string expectedSubId,
            Guid expectedTenantId,
            AzureLocation expectedLocation,
            string expectedSkuFamily,
            KeyVaultSkuName expectedSku,
            bool expectedEnabledForDeployment,
            bool expectedEnabledForTemplateDeployment,
            bool expectedEnabledForDiskEncryption,
            bool? expectedEnableSoftDelete,
            AccessPolicyEntry[] expectedPolicies,
            NetworkRuleSet networkRuleSet,
            Dictionary<string, string> expectedTags)
        {
            ValidateVault(
                vaultData,
                expectedVaultName,
                expectedResourceGroupName,
                expectedSubId,
                expectedTenantId,
                expectedLocation,
                expectedSkuFamily,
                expectedSku,
                expectedEnabledForDeployment,
                expectedEnabledForTemplateDeployment,
                expectedEnabledForDiskEncryption,
                expectedEnableSoftDelete,
                expectedPolicies,
                expectedTags);

            Assert.NotNull(vaultData.Properties.NetworkAcls);
            Assert.AreEqual(networkRuleSet.DefaultAction, vaultData.Properties.NetworkAcls.DefaultAction);
            Assert.AreEqual(networkRuleSet.Bypass, vaultData.Properties.NetworkAcls.Bypass);
            Assert.True(vaultData.Properties.NetworkAcls.IPRules != null && vaultData.Properties.NetworkAcls.IPRules.Count == 2);
            Assert.AreEqual(networkRuleSet.IPRules[0].AddressRange, vaultData.Properties.NetworkAcls.IPRules[0].AddressRange);
            Assert.AreEqual(networkRuleSet.IPRules[1].AddressRange, vaultData.Properties.NetworkAcls.IPRules[1].AddressRange);
        }
    }
}
