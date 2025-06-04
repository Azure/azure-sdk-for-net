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
            KeyVaultProperties vaultProperties = new KeyVaultProperties(TenantIdGuid, new KeyVaultSku(KeyVaultSkuFamily.A, KeyVaultSkuName.Standard));
            KeyVaultCreateOrUpdateContent content = new KeyVaultCreateOrUpdateContent(Location, vaultProperties);
            ArmOperation<KeyVaultResource> rawVault = await VaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, VaultName, content);
            KeyVaultData createdVault = rawVault.Value.Data;
            Assert.IsNotNull(createdVault);
            Assert.AreEqual(VaultName, createdVault.Name);
        }

        [Test]
        public async Task KeyVaultManagementVaultCreateUpdateDelete()
        {
            IgnoreTestInLiveMode();
            VaultProperties.EnableSoftDelete = null;

            KeyVaultCreateOrUpdateContent parameters = new KeyVaultCreateOrUpdateContent(Location, VaultProperties);
            parameters.Tags.InitializeFrom(Tags);

            ArmOperation<KeyVaultResource> rawVault = await VaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, VaultName, parameters).ConfigureAwait(false);

            KeyVaultData createdVault = rawVault.Value.Data;

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
                VaultProperties.NetworkRuleSet,
                Tags);

            //Update
            AccessPolicy.Permissions.Secrets.Clear();
            AccessPolicy.Permissions.Secrets.Add(IdentityAccessSecretPermission.Get);
            AccessPolicy.Permissions.Secrets.Add(IdentityAccessSecretPermission.Set);
            (AccessPolicy.Permissions.Keys as ChangeTrackingList<IdentityAccessKeyPermission>).Reset();

            AccessPolicy.Permissions.Storage.Clear();
            AccessPolicy.Permissions.Storage.Add(IdentityAccessStoragePermission.Get);
            AccessPolicy.Permissions.Storage.Add(IdentityAccessStoragePermission.RegenerateKey);

            createdVault.Properties.AccessPolicies.Clear();
            createdVault.Properties.AccessPolicies.Add(AccessPolicy);
            createdVault.Properties.Sku.Name = KeyVaultSkuName.Premium;

            parameters = new KeyVaultCreateOrUpdateContent(Location, createdVault.Properties);
            parameters.Tags.InitializeFrom(Tags);
            ArmOperation<KeyVaultResource> rawUpdateVault = await VaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, VaultName, parameters).ConfigureAwait(false);

            KeyVaultData updateVault = rawUpdateVault.Value.Data;

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
                VaultProperties.NetworkRuleSet,
                Tags);

            Response<KeyVaultResource> rawRetrievedVault = await VaultCollection.GetAsync(VaultName);

            KeyVaultData retrievedVault = rawRetrievedVault.Value.Data;
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
                VaultProperties.NetworkRuleSet,
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

            KeyVaultCreateOrUpdateContent parameters = new KeyVaultCreateOrUpdateContent(Location, VaultProperties);
            parameters.Tags.InitializeFrom(Tags);

            ArmOperation<KeyVaultResource> createVault = await VaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, VaultName, parameters).ConfigureAwait(false);
            KeyVaultResource vaultResponse = createVault.Value;

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
            Response<KeyVaultResource> retrievedVault = await VaultCollection.GetAsync(VaultName);

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
            List<KeyVaultResource> vaultList = new List<KeyVaultResource>();
            for (int i = 0; i < n; i++)
            {
                string vaultName = Recording.GenerateAssetName("sdktest-vault-");
                KeyVaultCreateOrUpdateContent parameters = new KeyVaultCreateOrUpdateContent(Location, VaultProperties);
                parameters.Tags.InitializeFrom(Tags);
                ArmOperation<KeyVaultResource> createdVault = await VaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, vaultName, parameters).ConfigureAwait(false);
                KeyVaultResource vaultValue = createdVault.Value;

                Assert.NotNull(vaultValue);
                Assert.NotNull(vaultValue.Id);
                resourceIds.Add(vaultValue.Id);
                vaultList.Add(vaultValue);
            }

            AsyncPageable<KeyVaultResource> vaults = VaultCollection.GetAllAsync(top);

            await foreach (var v in vaults)
            {
                Assert.True(resourceIds.Remove(v.Id));
            }

            Assert.True(resourceIds.Count == 0);

            AsyncPageable<KeyVaultResource> allVaults = VaultCollection.GetAllAsync(top);
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
            KeyVaultCreateOrUpdateContent parameters = new KeyVaultCreateOrUpdateContent(Location, VaultProperties);
            parameters.Tags.InitializeFrom(Tags);
            ArmOperation<KeyVaultResource> createdVault = await VaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, VaultName, parameters).ConfigureAwait(false);
            KeyVaultResource vaultValue = createdVault.Value;

            // Delete
            await vaultValue.DeleteAsync(WaitUntil.Completed);

            // Get deleted vault
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await VaultCollection.GetAsync(VaultName);
            });

            parameters = new KeyVaultCreateOrUpdateContent(Location, VaultProperties);
            parameters.Tags.InitializeFrom(Tags);
            // Recover in default mode
            ArmOperation<KeyVaultResource> recoveredRawVault = await VaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, VaultName,parameters).ConfigureAwait(false);
            KeyVaultResource recoveredVault = recoveredRawVault.Value;
            Assert.True(recoveredVault.Data.IsEqual(vaultValue.Data));

            // Get recovered vault
            Response<KeyVaultResource> getResult =  await VaultCollection.GetAsync(VaultName);

            // Delete
            await getResult.Value.DeleteAsync(WaitUntil.Completed);

            VaultProperties.CreateMode = KeyVaultCreateMode.Recover;
            parameters = new KeyVaultCreateOrUpdateContent(Location, VaultProperties);

            // Recover in recover mode
            ArmOperation<KeyVaultResource> recoveredRawVault2 = await VaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, VaultName, parameters).ConfigureAwait(false);
            KeyVaultResource recoveredVault2 = recoveredRawVault.Value;

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
            List<KeyVaultResource> vaultList = new List<KeyVaultResource>();
            KeyVaultCreateOrUpdateContent parameters = new KeyVaultCreateOrUpdateContent(Location, VaultProperties);
            parameters.Tags.InitializeFrom(Tags);
            for (int i = 0; i < n; i++)
            {
                string vaultName = Recording.GenerateAssetName("sdktest-vault-");
                ArmOperation<KeyVaultResource> createdRawVault = await VaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, vaultName, parameters).ConfigureAwait(false);

                KeyVaultResource createdVault = createdRawVault.Value;

                Assert.NotNull(createdVault.Data);
                Assert.NotNull(createdVault.Data.Id);
                resourceIds.Add(createdVault.Data.Id);
                vaultList.Add(createdVault);

                await createdVault.DeleteAsync(WaitUntil.Completed).ConfigureAwait(false);

                Response<DeletedKeyVaultResource> deletedVault = await DeletedVaultCollection.GetAsync(Location, vaultName).ConfigureAwait(false);
                Assert.IsTrue(deletedVault.Value.Data.Name.Equals(createdVault.Data.Name));
            }

            List<DeletedKeyVaultResource> deletedVaults = Subscription.GetDeletedKeyVaultsAsync().ToEnumerableAsync().Result;
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
            KeyVaultData vaultData,
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
            KeyVaultAccessPolicy[] expectedPolicies,
            Dictionary<string, string> expectedTags)
        {
            Assert.NotNull(vaultData);
            Assert.NotNull(vaultData.Properties);

            string resourceIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.KeyVault/vaults/{2}";
            string expectedResourceId = string.Format(resourceIdFormat, expectedSubId, expectedResourceGroupName, expectedVaultName);

            Assert.AreEqual(expectedResourceId, vaultData.Id.ToString());
            Assert.AreEqual(expectedLocation, vaultData.Location);
            Assert.AreEqual(Mode == RecordedTestMode.Live ? expectedTenantId : Guid.Empty, vaultData.Properties.TenantId);
            Assert.AreEqual(expectedSku, vaultData.Properties.Sku.Name);
            Assert.AreEqual(expectedVaultName, vaultData.Name);
            Assert.AreEqual(expectedEnabledForDeployment, vaultData.Properties.EnabledForDeployment);
            Assert.AreEqual(expectedEnabledForTemplateDeployment, vaultData.Properties.EnabledForTemplateDeployment);
            Assert.AreEqual(expectedEnabledForDiskEncryption, vaultData.Properties.EnabledForDiskEncryption);
            Assert.AreEqual(expectedEnableSoftDelete, vaultData.Properties.EnableSoftDelete);
            Assert.True(expectedTags.DictionaryEqual(vaultData.Tags));
            if (Mode == RecordedTestMode.Live)
            {
                Assert.True(expectedPolicies.IsEqual(vaultData.Properties.AccessPolicies));
            }
        }

        private void ValidateVault(
            KeyVaultData vaultData,
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
            KeyVaultAccessPolicy[] expectedPolicies,
            KeyVaultNetworkRuleSet networkRuleSet,
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

            Assert.NotNull(vaultData.Properties.NetworkRuleSet);
            Assert.AreEqual(networkRuleSet.DefaultAction, vaultData.Properties.NetworkRuleSet.DefaultAction);
            Assert.AreEqual(networkRuleSet.Bypass, vaultData.Properties.NetworkRuleSet.Bypass);
            Assert.True(vaultData.Properties.NetworkRuleSet.IPRules != null && vaultData.Properties.NetworkRuleSet.IPRules.Count == 2);
            Assert.AreEqual(networkRuleSet.IPRules[0].AddressRange, vaultData.Properties.NetworkRuleSet.IPRules[0].AddressRange);
            Assert.AreEqual(networkRuleSet.IPRules[1].AddressRange, vaultData.Properties.NetworkRuleSet.IPRules[1].AddressRange);
        }
    }
}
