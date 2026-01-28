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
            Assert.That(createdVault, Is.Not.Null);
            Assert.That(createdVault.Name, Is.EqualTo(VaultName));
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

                Assert.That(vaultValue, Is.Not.Null);
                Assert.That(vaultValue.Id, Is.Not.Null);
                resourceIds.Add(vaultValue.Id);
                vaultList.Add(vaultValue);
            }

            AsyncPageable<KeyVaultResource> vaults = VaultCollection.GetAllAsync(top);

            await foreach (var v in vaults)
            {
                Assert.That(resourceIds.Remove(v.Id), Is.True);
            }

            Assert.That(resourceIds.Count, Is.EqualTo(0));

            AsyncPageable<KeyVaultResource> allVaults = VaultCollection.GetAllAsync(top);
            Assert.That(vaults, Is.Not.Null);

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
            ArmOperation<KeyVaultResource> recoveredRawVault = await VaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, VaultName, parameters).ConfigureAwait(false);
            KeyVaultResource recoveredVault = recoveredRawVault.Value;
            Assert.That(recoveredVault.Data.IsEqual(vaultValue.Data), Is.True);

            // Get recovered vault
            Response<KeyVaultResource> getResult = await VaultCollection.GetAsync(VaultName);

            // Delete
            await getResult.Value.DeleteAsync(WaitUntil.Completed);

            VaultProperties.CreateMode = KeyVaultCreateMode.Recover;
            parameters = new KeyVaultCreateOrUpdateContent(Location, VaultProperties);

            // Recover in recover mode
            ArmOperation<KeyVaultResource> recoveredRawVault2 = await VaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, VaultName, parameters).ConfigureAwait(false);
            KeyVaultResource recoveredVault2 = recoveredRawVault.Value;

            Assert.That(recoveredVault2.Data.IsEqual(vaultValue.Data), Is.True);

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

                Assert.That(createdVault.Data, Is.Not.Null);
                Assert.That(createdVault.Data.Id, Is.Not.Null);
                resourceIds.Add(createdVault.Data.Id);
                vaultList.Add(createdVault);

                await createdVault.DeleteAsync(WaitUntil.Completed).ConfigureAwait(false);

                Response<DeletedKeyVaultResource> deletedVault = await DeletedVaultCollection.GetAsync(Location, vaultName).ConfigureAwait(false);
                Assert.That(deletedVault.Value.Data.Name, Is.EqualTo(createdVault.Data.Name));
            }

            List<DeletedKeyVaultResource> deletedVaults = Subscription.GetDeletedKeyVaultsAsync().ToEnumerableAsync().Result;
            Assert.That(deletedVaults, Is.Not.Null);

            foreach (var v in deletedVaults)
            {
                bool exists = resourceIds.Remove(v.Data.Properties.VaultId);
                if (resourceIds.Count == 0)
                    break;
            }

            Assert.That(resourceIds.Count, Is.EqualTo(0));
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
            Assert.That(vaultData, Is.Not.Null);
            Assert.That(vaultData.Properties, Is.Not.Null);

            string resourceIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.KeyVault/vaults/{2}";
            string expectedResourceId = string.Format(resourceIdFormat, expectedSubId, expectedResourceGroupName, expectedVaultName);

            Assert.That(vaultData.Id.ToString(), Is.EqualTo(expectedResourceId));
            Assert.That(vaultData.Location, Is.EqualTo(expectedLocation));
            Assert.That(vaultData.Properties.TenantId, Is.EqualTo(Mode == RecordedTestMode.Live ? expectedTenantId : Guid.Empty));
            Assert.That(vaultData.Properties.Sku.Name, Is.EqualTo(expectedSku));
            Assert.That(vaultData.Name, Is.EqualTo(expectedVaultName));
            Assert.That(vaultData.Properties.EnabledForDeployment, Is.EqualTo(expectedEnabledForDeployment));
            Assert.That(vaultData.Properties.EnabledForTemplateDeployment, Is.EqualTo(expectedEnabledForTemplateDeployment));
            Assert.That(vaultData.Properties.EnabledForDiskEncryption, Is.EqualTo(expectedEnabledForDiskEncryption));
            Assert.That(vaultData.Properties.EnableSoftDelete, Is.EqualTo(expectedEnableSoftDelete));
            Assert.That(expectedTags.DictionaryEqual(vaultData.Tags), Is.True);
            if (Mode == RecordedTestMode.Live)
            {
                Assert.That(expectedPolicies.IsEqual(vaultData.Properties.AccessPolicies), Is.True);
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

            Assert.That(vaultData.Properties.NetworkRuleSet, Is.Not.Null);
            Assert.That(vaultData.Properties.NetworkRuleSet.DefaultAction, Is.EqualTo(networkRuleSet.DefaultAction));
            Assert.That(vaultData.Properties.NetworkRuleSet.Bypass, Is.EqualTo(networkRuleSet.Bypass));
            Assert.That(vaultData.Properties.NetworkRuleSet.IPRules != null && vaultData.Properties.NetworkRuleSet.IPRules.Count == 2, Is.True);
            Assert.That(vaultData.Properties.NetworkRuleSet.IPRules[0].AddressRange, Is.EqualTo(networkRuleSet.IPRules[0].AddressRange));
            Assert.That(vaultData.Properties.NetworkRuleSet.IPRules[1].AddressRange, Is.EqualTo(networkRuleSet.IPRules[1].AddressRange));
        }
    }
}
