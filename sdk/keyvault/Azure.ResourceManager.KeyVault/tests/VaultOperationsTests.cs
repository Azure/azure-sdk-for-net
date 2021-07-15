// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;

using NUnit.Framework;

namespace Azure.ResourceManager.KeyVault.Tests
{
    [RunFrequency(RunTestFrequency.Manually)]
    public class VaultOperationsTests : VaultOperationsTestsBase
    {
        public VaultOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize().ConfigureAwait(false).GetAwaiter().GetResult();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task KeyVaultManagementVaultCreateUpdateDelete()
        {
            VaultProperties.EnableSoftDelete = null;

            var parameters = new VaultCreateOrUpdateParameters(Location, VaultProperties);
            parameters.Tags.InitializeFrom(Tags);

            var rawVault = await VaultContainer.StartCreateOrUpdateAsync(VaultName, parameters);

            var createdVault = (await WaitForCompletionAsync(rawVault)).Value.Data;

            ValidateVault(createdVault,
                VaultName,
                ResGroupName,
                TestEnvironment.SubscriptionId,
                TenantIdGuid,
                Location,
                "A",
                SkuName.Standard,
                true,
                true,
                true,
                true, // enableSoftDelete defaults to true
                new[] { AccessPolicy },
                VaultProperties.NetworkAcls,
                Tags);

            //Update
            AccessPolicy.Permissions.Secrets.Clear();
            AccessPolicy.Permissions.Secrets.Add(SecretPermissions.Get);
            AccessPolicy.Permissions.Secrets.Add(SecretPermissions.Set);
            (AccessPolicy.Permissions.Keys as ChangeTrackingList<KeyPermissions>).Reset();

            AccessPolicy.Permissions.Storage.Clear();
            AccessPolicy.Permissions.Storage.Add(StoragePermissions.Get);
            AccessPolicy.Permissions.Storage.Add(StoragePermissions.Regeneratekey);

            createdVault.Properties.AccessPolicies.Clear();
            createdVault.Properties.AccessPolicies.Add(AccessPolicy);
            createdVault.Properties.Sku.Name = SkuName.Premium;

            parameters = new VaultCreateOrUpdateParameters(Location, createdVault.Properties);
            parameters.Tags.InitializeFrom(Tags);
            var rawUpdateVault = await VaultContainer.StartCreateOrUpdateAsync(VaultName, parameters);

            var updateVault = (await WaitForCompletionAsync(rawUpdateVault)).Value.Data;

            ValidateVault(updateVault,
                VaultName,
                ResGroupName,
                TestEnvironment.SubscriptionId,
                TenantIdGuid,
                Location,
                "A",
                SkuName.Premium,
                true,
                true,
                true,
                true,
                new[] { AccessPolicy },
                VaultProperties.NetworkAcls,
                Tags);

            var rawRetrievedVault = await VaultContainer.GetAsync(VaultName);

            var retrievedVault = rawRetrievedVault.Value.Data;
            ValidateVault(retrievedVault,
                VaultName,
                ResGroupName,
                TestEnvironment.SubscriptionId,
                TenantIdGuid,
                Location,
                "A",
                SkuName.Premium,
                true,
                true,
                true,
                true,
                new[] { AccessPolicy },
                VaultProperties.NetworkAcls,
                Tags);

            // Delete
            VaultOperations = new VaultOperations(rawRetrievedVault.Value, rawRetrievedVault.Value.Id);
            await VaultOperations.DeleteAsync();

            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await VaultContainer.GetAsync(VaultName);
            });
        }

        [Ignore("This parameter should be deprecated")]
        [Test]
        public async Task CreateKeyVaultDisableSoftDelete()
        {
            this.AccessPolicy.ApplicationId = Guid.Parse(TestEnvironment.ClientId);
            this.VaultProperties.EnableSoftDelete = false;

            var parameters = new VaultCreateOrUpdateParameters("westeurope", VaultProperties);
            parameters.Tags.InitializeFrom(Tags);
            var vault = await VaultContainer.StartCreateOrUpdateAsync(VaultName, parameters);
            var vaultValue = await WaitForCompletionAsync(vault);

            Assert.False(vaultValue.Value.Data.Properties.EnableSoftDelete);

            VaultOperations = new VaultOperations(vaultValue.Value, vaultValue.Value.Id);
            await VaultOperations.DeleteAsync();
        }

        [Test]
        public async Task KeyVaultManagementVaultTestCompoundIdentityAccessControlPolicy()
        {
            AccessPolicy.ApplicationId = Guid.Parse(TestEnvironment.ClientId);
            VaultProperties.EnableSoftDelete = null;

            var parameters = new VaultCreateOrUpdateParameters(Location, VaultProperties);
            parameters.Tags.InitializeFrom(Tags);

            var createVault = await VaultContainer.StartCreateOrUpdateAsync(
                vaultName: VaultName,
                parameters: parameters
                );
            var vaultResponse = await WaitForCompletionAsync(createVault);

            ValidateVault(vaultResponse.Value.Data,
                VaultName,
                ResGroupName,
                TestEnvironment.SubscriptionId,
                TenantIdGuid,
                Location,
                "A",
                SkuName.Standard,
                true,
                true,
                true,
                true,
                new[] { AccessPolicy },
                Tags);

            // Get
            var retrievedVault = await VaultContainer.GetAsync(VaultName);

            ValidateVault(retrievedVault.Value.Data,
                VaultName,
                ResGroupName,
                TestEnvironment.SubscriptionId,
                TenantIdGuid,
                Location,
                "A",
                SkuName.Standard,
                true,
                true,
                true,
                true,
                new[] { AccessPolicy },
                Tags);

            // Delete
            VaultOperations = new VaultOperations(retrievedVault.Value, retrievedVault.Value.Id);
            await VaultOperations.DeleteAsync();

            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await VaultContainer.GetAsync(VaultName);
            });
        }

        [Test]
        public async Task KeyVaultManagementListVaults()
        {
            int n = 3;
            int top = 2;
            VaultProperties.EnableSoftDelete = null;

            List<string> resourceIds = new List<string>();
            List<Vault> vaultList = new List<Vault>();
            for (int i = 0; i < n; i++)
            {
                string vaultName = Recording.GenerateAssetName("sdktestvault");
                var parameters = new VaultCreateOrUpdateParameters(Location, VaultProperties);
                parameters.Tags.InitializeFrom(Tags);
                var createdVault = await VaultContainer.StartCreateOrUpdateAsync(vaultName, parameters);

                var vaultResponse = await WaitForCompletionAsync(createdVault);
                var vaultValue = vaultResponse.Value.Data;

                Assert.NotNull(vaultValue);
                Assert.NotNull(vaultValue.Id);
                resourceIds.Add(vaultValue.Id);
                vaultList.Add(vaultResponse.Value);
            }

            var vaults = VaultContainer.ListAsync(top);

            await foreach (var v in vaults)
            {
                Assert.True(resourceIds.Remove(v.Id));
            }

            Assert.True(resourceIds.Count == 0);

            var allVaults = VaultContainer.ListAsync(top);
            Assert.NotNull(vaults);

            // Delete
            foreach (var item in vaultList)
            {
                VaultOperations = new VaultOperations(item, item.Id);
                await VaultOperations.DeleteAsync();
            }
        }

        [Test]
        public async Task KeyVaultManagementRecoverDeletedVault()
        {
            var parameters = new VaultCreateOrUpdateParameters(Location, VaultProperties);
            parameters.Tags.InitializeFrom(Tags);
            var createdVault = await VaultContainer.StartCreateOrUpdateAsync(VaultName, parameters);

            var vaultValue = await WaitForCompletionAsync(createdVault);

            // Delete
            VaultOperations = new VaultOperations(vaultValue.Value, vaultValue.Value.Id);
            await VaultOperations.DeleteAsync();

            // Get deleted vault
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await VaultContainer.GetAsync(VaultName);
            });

            parameters = new VaultCreateOrUpdateParameters(Location, VaultProperties);
            parameters.Tags.InitializeFrom(Tags);
            // Recover in default mode
            var recoveredRawVault = await VaultContainer.StartCreateOrUpdateAsync(VaultName,parameters);
            var recoveredVault = await WaitForCompletionAsync(recoveredRawVault);
            Assert.True(recoveredVault.Value.Data.IsEqual(vaultValue.Value.Data));

            // Get recovered vault
            var getResult =  await VaultContainer.GetAsync(VaultName);

            // Delete
            VaultOperations = new VaultOperations(getResult.Value, getResult.Value.Id);
            await VaultOperations.DeleteAsync();

            VaultProperties.CreateMode = CreateMode.Recover;
            parameters = new VaultCreateOrUpdateParameters(Location, VaultProperties);

            // Recover in recover mode
            var recoveredRawVault2 = await VaultContainer.StartCreateOrUpdateAsync(VaultName, parameters);
            var recoveredVault2 = await WaitForCompletionAsync(recoveredRawVault);

            Assert.True(recoveredVault2.Value.Data.IsEqual(vaultValue.Value.Data));

            // Get recovered vault
            getResult = await VaultContainer.GetAsync(VaultName);

            // Delete
            VaultOperations = new VaultOperations(getResult.Value, getResult.Value.Id);
            await VaultOperations.DeleteAsync();
        }

        [Test]
        public async Task KeyVaultManagementListDeletedVaults()
        {
            int n = 3;
            List<string> resourceIds = new List<string>();
            List<Vault> vaultList = new List<Vault>();
            var parameters = new VaultCreateOrUpdateParameters(Location, VaultProperties);
            parameters.Tags.InitializeFrom(Tags);
            for (int i = 0; i < n; i++)
            {
                string vaultName = Recording.GenerateAssetName("sdktestvault");
                var createdRawVault = await VaultContainer.StartCreateOrUpdateAsync(vaultName, parameters);

                var createdVault = (await WaitForCompletionAsync(createdRawVault)).Value;

                Assert.NotNull(createdVault.Data);
                Assert.NotNull(createdVault.Data.Id);
                resourceIds.Add(createdVault.Data.Id);
                vaultList.Add(createdVault);

                VaultOperations = new VaultOperations(createdVault, createdVault.Id);
                await VaultOperations.DeleteAsync();

                var deletedVault = await DeletedVaultContainer.GetAsync(Location).ConfigureAwait(false);
                Assert.IsTrue(deletedVault.Value.Data.Name.Equals(createdVault.Data.Name));
            }

            var deletedVaults = DeletedVaultContainer.ListAsync().ToEnumerableAsync().Result;
            Assert.NotNull(deletedVaults);

            foreach (var v in deletedVaults)
            {
                var exists = resourceIds.Remove(v.Data.Properties.VaultId);

                if (exists)
                {
                    // Purge vault
                    var deletedVaultOperations = new DeletedVaultOperations(v, Client.DefaultSubscription.Id);
                    await deletedVaultOperations.StartPurgeAsync().ConfigureAwait(false);
                    Assert.ThrowsAsync<RequestFailedException>(async () => await DeletedVaultContainer.GetAsync(Location));
                }
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
            string expectedLocation,
            string expectedSkuFamily,
            SkuName expectedSku,
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
            string expectedLocation,
            string expectedSkuFamily,
            SkuName expectedSku,
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
            Assert.True(vaultData.Properties.NetworkAcls.IpRules != null && vaultData.Properties.NetworkAcls.IpRules.Count == 2);
            Assert.AreEqual(networkRuleSet.IpRules[0].Value, vaultData.Properties.NetworkAcls.IpRules[0].Value);
            Assert.AreEqual(networkRuleSet.IpRules[1].Value, vaultData.Properties.NetworkAcls.IpRules[1].Value);
        }
    }
}
