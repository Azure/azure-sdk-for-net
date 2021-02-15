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

            var rawVault = await VaultsClient.StartCreateOrUpdateAsync(
                ResGroupName,
                VaultName,
                parameters);

            var createdVault = (await WaitForCompletionAsync(rawVault)).Value;

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
            var rawUpdateVault = await VaultsClient.StartCreateOrUpdateAsync(
                resourceGroupName: ResGroupName,
                vaultName: VaultName,
                parameters: parameters
                );

            var updateVault = (await WaitForCompletionAsync(rawUpdateVault)).Value;

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

            var rawRetrievedVault = await VaultsClient.GetAsync(
                resourceGroupName: ResGroupName,
                vaultName: VaultName);

            var retrievedVault = rawRetrievedVault.Value;
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
            await VaultsClient.DeleteAsync(
                resourceGroupName: ResGroupName,
                vaultName: VaultName);

            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await VaultsClient.GetAsync(
                    resourceGroupName: ResGroupName,
                    vaultName: VaultName);
            });
        }

        [Test]
        public async Task CreateKeyVaultDisableSoftDelete()
        {
            this.AccessPolicy.ApplicationId = Guid.Parse(TestEnvironment.ClientId);
            this.VaultProperties.EnableSoftDelete = false;

            var parameters = new VaultCreateOrUpdateParameters(Location, VaultProperties);
            parameters.Tags.InitializeFrom(Tags);
            var vault = await VaultsClient.StartCreateOrUpdateAsync(
                resourceGroupName: this.ResGroupName,
                vaultName: this.VaultName,
                parameters: parameters
                );
            var vaultValue = await WaitForCompletionAsync(vault);

            Assert.False(vaultValue.Value.Properties.EnableSoftDelete);

            await VaultsClient.DeleteAsync(ResGroupName, VaultName);
        }

        [Test]
        public async Task KeyVaultManagementVaultTestCompoundIdentityAccessControlPolicy()
        {
            AccessPolicy.ApplicationId = Guid.Parse(TestEnvironment.ClientId);
            VaultProperties.EnableSoftDelete = null;

            var parameters = new VaultCreateOrUpdateParameters(Location, VaultProperties);
            parameters.Tags.InitializeFrom(Tags);

            var createVault = await VaultsClient.StartCreateOrUpdateAsync(
                resourceGroupName: ResGroupName,
                vaultName: VaultName,
                parameters: parameters
                );
            var vaultResponse = await WaitForCompletionAsync(createVault);

            ValidateVault(vaultResponse.Value,
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
            var retrievedVault = await VaultsClient.GetAsync(
               resourceGroupName: ResGroupName,
               vaultName: VaultName);

            ValidateVault(retrievedVault.Value,
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
            await VaultsClient.DeleteAsync(
                resourceGroupName: ResGroupName,
                vaultName: VaultName);

            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await VaultsClient.GetAsync(
                    resourceGroupName: ResGroupName,
                    vaultName: VaultName);
            });
        }

        [Test]
        public async Task KeyVaultManagementListVaults()
        {
            int n = 3;
            int top = 2;
            VaultProperties.EnableSoftDelete = null;

            List<string> resourceIds = new List<string>();
            List<string> vaultNameList = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string vaultName = Recording.GenerateAssetName("sdktestvault");
                var parameters = new VaultCreateOrUpdateParameters(Location, VaultProperties);
                parameters.Tags.InitializeFrom(Tags);
                var createdVault = await VaultsClient.StartCreateOrUpdateAsync(
                    resourceGroupName: ResGroupName,
                    vaultName: vaultName,
                    parameters: parameters
                    );

                var vaultResponse = await WaitForCompletionAsync(createdVault);
                var vaultValue = vaultResponse.Value;

                Assert.NotNull(vaultValue);
                Assert.NotNull(vaultValue.Id);
                resourceIds.Add(vaultValue.Id);
                vaultNameList.Add(vaultValue.Name);
            }

            var vaults = VaultsClient.ListByResourceGroupAsync(ResGroupName, top);

            await foreach (var v in vaults)
            {
                Assert.True(resourceIds.Remove(v.Id));
            }

            Assert.True(resourceIds.Count == 0);

            var allVaults = VaultsClient.ListAsync(top);
            Assert.NotNull(vaults);

            // Delete
            foreach (var v in vaultNameList)
            {
                await VaultsClient.DeleteAsync(resourceGroupName: ResGroupName, vaultName: v);
            }
        }

        [Test]
        public async Task KeyVaultManagementRecoverDeletedVault()
        {
            var parameters = new VaultCreateOrUpdateParameters(Location, VaultProperties);
            parameters.Tags.InitializeFrom(Tags);
            var createdVault = await VaultsClient.StartCreateOrUpdateAsync(
                resourceGroupName: ResGroupName,
                vaultName: VaultName,
                parameters: parameters
                );

            var vaultValue = await WaitForCompletionAsync(createdVault);

            // Delete
            await VaultsClient.DeleteAsync(
                resourceGroupName: ResGroupName,
                vaultName: VaultName);

            // Get deleted vault
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await VaultsClient.GetAsync(
                    resourceGroupName: ResGroupName,
                    vaultName: VaultName);
            });

            parameters = new VaultCreateOrUpdateParameters(Location, VaultProperties);
            parameters.Tags.InitializeFrom(Tags);
            // Recover in default mode
            var recoveredRawVault = await VaultsClient.StartCreateOrUpdateAsync(
                resourceGroupName: ResGroupName,
                vaultName: VaultName,
                parameters: parameters
                );
            var recoveredVault = await WaitForCompletionAsync(recoveredRawVault);
            Assert.True(recoveredVault.Value.IsEqual(vaultValue.Value));

            // Get recovered vault
            await VaultsClient.GetAsync(
                resourceGroupName: ResGroupName,
                vaultName: VaultName);

            // Delete
            await VaultsClient.DeleteAsync(
                resourceGroupName: ResGroupName,
                vaultName: VaultName);

            VaultProperties.CreateMode = CreateMode.Recover;
            parameters = new VaultCreateOrUpdateParameters(Location, VaultProperties);

            // Recover in recover mode
            var recoveredRawVault2 = await VaultsClient.StartCreateOrUpdateAsync(
                resourceGroupName: ResGroupName,
                vaultName: VaultName,
                parameters: parameters
                );
            var recoveredVault2 = await WaitForCompletionAsync(recoveredRawVault);

            Assert.True(recoveredVault2.Value.IsEqual(vaultValue.Value));

            // Get recovered vault
            await VaultsClient.GetAsync(
                resourceGroupName: ResGroupName,
                vaultName: VaultName);

            // Delete
            await VaultsClient.DeleteAsync(
                resourceGroupName: ResGroupName,
                vaultName: VaultName);
        }

        [Test]
        public async Task KeyVaultManagementListDeletedVaults()
        {
            int n = 3;
            List<string> resourceIds = new List<string>();
            List<string> vaultNameList = new List<string>();
            var parameters = new VaultCreateOrUpdateParameters(Location, VaultProperties);
            parameters.Tags.InitializeFrom(Tags);
            for (int i = 0; i < n; i++)
            {
                string vaultName = Recording.GenerateAssetName("sdktestvault");
                var createdRawVault = await VaultsClient.StartCreateOrUpdateAsync(
                    resourceGroupName: ResGroupName,
                    vaultName: vaultName,
                    parameters: parameters
                    );

                var createdVault = (await WaitForCompletionAsync(createdRawVault)).Value;

                Assert.NotNull(createdVault);
                Assert.NotNull(createdVault.Id);
                resourceIds.Add(createdVault.Id);
                vaultNameList.Add(createdVault.Name);

                await VaultsClient.DeleteAsync(resourceGroupName: ResGroupName, vaultName: vaultName);

                var deletedVault = await VaultsClient.GetDeletedAsync(vaultName, Location);
                deletedVault.Value.IsEqual(createdVault);
            }

            var deletedVaults = VaultsClient.ListDeletedAsync();
            Assert.NotNull(deletedVaults);

            await foreach (var v in deletedVaults)
            {
                var exists = resourceIds.Remove(v.Properties.VaultId);

                if (exists)
                {
                    // Purge vault
                    var purgeOperation = await VaultsClient.StartPurgeDeletedAsync(v.Name, Location);
                    await WaitForCompletionAsync(purgeOperation);
                    Assert.ThrowsAsync<RequestFailedException>(async () => await VaultsClient.GetDeletedAsync(v.Name, Location));
                }
                if (resourceIds.Count == 0)
                    break;
            }

            Assert.True(resourceIds.Count == 0);
        }

        private void ValidateVault(
            Vault vault,
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
            Assert.NotNull(vault);
            Assert.NotNull(vault.Properties);

            string resourceIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.KeyVault/vaults/{2}";
            string expectedResourceId = string.Format(resourceIdFormat, expectedSubId, expectedResourceGroupName, expectedVaultName);

            Assert.AreEqual(expectedResourceId, vault.Id);
            Assert.AreEqual(expectedLocation, vault.Location);
            Assert.AreEqual(expectedTenantId, vault.Properties.TenantId);
            Assert.AreEqual(expectedSku, vault.Properties.Sku.Name);
            Assert.AreEqual(expectedVaultName, vault.Name);
            Assert.AreEqual(expectedEnabledForDeployment, vault.Properties.EnabledForDeployment);
            Assert.AreEqual(expectedEnabledForTemplateDeployment, vault.Properties.EnabledForTemplateDeployment);
            Assert.AreEqual(expectedEnabledForDiskEncryption, vault.Properties.EnabledForDiskEncryption);
            Assert.AreEqual(expectedEnableSoftDelete, vault.Properties.EnableSoftDelete);
            Assert.True(expectedTags.DictionaryEqual(vault.Tags));
            Assert.True(expectedPolicies.IsEqual(vault.Properties.AccessPolicies));
        }

        private void ValidateVault(
            Vault vault,
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
                vault,
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

            Assert.NotNull(vault.Properties.NetworkAcls);
            Assert.AreEqual(networkRuleSet.DefaultAction, vault.Properties.NetworkAcls.DefaultAction);
            Assert.AreEqual(networkRuleSet.Bypass, vault.Properties.NetworkAcls.Bypass);
            Assert.True(vault.Properties.NetworkAcls.IpRules != null && vault.Properties.NetworkAcls.IpRules.Count == 2);
            Assert.AreEqual(networkRuleSet.IpRules[0].Value, vault.Properties.NetworkAcls.IpRules[0].Value);
            Assert.AreEqual(networkRuleSet.IpRules[1].Value, vault.Properties.NetworkAcls.IpRules[1].Value);
        }
    }
}
