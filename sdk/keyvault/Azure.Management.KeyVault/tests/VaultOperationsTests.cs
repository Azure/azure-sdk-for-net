// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Azure.Core.TestFramework;
using Azure.Management.KeyVault.Models;

using NUnit.Framework;

namespace Azure.Management.KeyVault.Tests
{
    public class VaultOperationsTests : VaultOperationsTestsBase
    {
        public VaultOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            // in record mode we reset the challenge cache before each test so that the challenge call
            // is always made.  This allows tests to be replayed independently and in any order
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize().ConfigureAwait(false).GetAwaiter().GetResult();
                //ChallengeBasedAuthenticationPolicy.AuthenticationChallenge.ClearCache();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            var resGroup = await ResourceGroupsClient.StartDeleteAsync(rgName);
            await WaitForCompletionAsync(resGroup);
        }

        [Test]
        public async Task KeyVaultManagementVaultCreateUpdateDelete()
        {
            vaultProperties.EnableSoftDelete = null;

            var parameters = new VaultCreateOrUpdateParameters(location, vaultProperties);
            parameters.Tags = tags;

            var rawVault = await VaultsClient.StartCreateOrUpdateAsync(
                rgName,
                vaultName,
                parameters);

            var createdVault = (await WaitForCompletionAsync(rawVault)).Value;

            ValidateVault(createdVault,
                vaultName,
                rgName,
                subscriptionId,
                tenantIdGuid,
                location,
                "A",
                SkuName.Standard,
                true,
                true,
                true,
                true, // enableSoftDelete defaults to true
                new[] { accPol },
                vaultProperties.NetworkAcls,
                tags);

            //Update
            accPol.Permissions.Secrets = new SecretPermissions[] { SecretPermissions.Get, SecretPermissions.Set };
            accPol.Permissions.Keys = null;
            accPol.Permissions.Storage = new StoragePermissions[] { StoragePermissions.Get, StoragePermissions.Regeneratekey };
            createdVault.Properties.AccessPolicies = new[] { accPol };
            createdVault.Properties.Sku.Name = SkuName.Premium;

            parameters = new VaultCreateOrUpdateParameters(location, createdVault.Properties);
            parameters.Tags = tags;
            var rawUpdateVault = await VaultsClient.StartCreateOrUpdateAsync(
                resourceGroupName: rgName,
                vaultName: vaultName,
                parameters: parameters
                );

            var updateVault = (await WaitForCompletionAsync(rawUpdateVault)).Value;

            ValidateVault(updateVault,
                vaultName,
                rgName,
                subscriptionId,
                tenantIdGuid,
                location,
                "A",
                SkuName.Premium,
                true,
                true,
                true,
                true,
                new[] { accPol },
                vaultProperties.NetworkAcls,
                tags);

            var rawRetrievedVault = await VaultsClient.GetAsync(
                resourceGroupName: rgName,
                vaultName: vaultName);

            var retrievedVault = rawRetrievedVault.Value;
            ValidateVault(retrievedVault,
                vaultName,
                rgName,
                subscriptionId,
                tenantIdGuid,
                location,
                "A",
                SkuName.Premium,
                true,
                true,
                true,
                true,
                new[] { accPol },
                vaultProperties.NetworkAcls,
                tags);

            // Delete
            await VaultsClient.DeleteAsync(
                resourceGroupName: rgName,
                vaultName: vaultName);

            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await VaultsClient.GetAsync(
                    resourceGroupName: rgName,
                    vaultName: vaultName);
            });
        }

        [Test]
        public async Task CreateKeyVaultDisableSoftDelete()
        {
            this.accPol.ApplicationId = Guid.Parse(this.applicationId);
            this.vaultProperties.EnableSoftDelete = false;

            var parameters = new VaultCreateOrUpdateParameters(location, vaultProperties);
            parameters.Tags = this.tags;
            var vault = await VaultsClient.StartCreateOrUpdateAsync(
                resourceGroupName: this.rgName,
                vaultName: this.vaultName,
                parameters: parameters
                );
            var vaultValue = await WaitForCompletionAsync(vault);

            Assert.False(vaultValue.Value.Properties.EnableSoftDelete);

            await VaultsClient.DeleteAsync(rgName, vaultName);
        }

        [Test]
        public async Task KeyVaultManagementVaultTestCompoundIdentityAccessControlPolicy()
        {
            accPol.ApplicationId = Guid.Parse(applicationId);
            vaultProperties.EnableSoftDelete = null;

            var parameters = new VaultCreateOrUpdateParameters(location, vaultProperties);
            parameters.Tags = tags;

            var createVault = await VaultsClient.StartCreateOrUpdateAsync(
                resourceGroupName: rgName,
                vaultName: vaultName,
                parameters: parameters
                );
            var vaultResponse = await WaitForCompletionAsync(createVault);

            ValidateVault(vaultResponse.Value,
                vaultName,
                rgName,
                subscriptionId,
                tenantIdGuid,
                location,
                "A",
                SkuName.Standard,
                true,
                true,
                true,
                true,
                new[] { accPol },
                tags);

            // Get
            var retrievedVault = await VaultsClient.GetAsync(
               resourceGroupName: rgName,
               vaultName: vaultName);

            ValidateVault(retrievedVault.Value,
                vaultName,
                rgName,
                subscriptionId,
                tenantIdGuid,
                location,
                "A",
                SkuName.Standard,
                true,
                true,
                true,
                true,
                new[] { accPol },
                tags);


            // Delete
            await VaultsClient.DeleteAsync(
                resourceGroupName: rgName,
                vaultName: vaultName);

            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await VaultsClient.GetAsync(
                    resourceGroupName: rgName,
                    vaultName: vaultName);
            });
        }

        [Test]
        public async Task KeyVaultManagementListVaults()
        {
            int n = 3;
            int top = 2;
            vaultProperties.EnableSoftDelete = null;

            List<string> resourceIds = new List<string>();
            List<string> vaultNameList = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string vaultName = Recording.GenerateAssetName("sdktestvault");
                var parameters = new VaultCreateOrUpdateParameters(location, vaultProperties);
                parameters.Tags = tags;
                var createdVault = await VaultsClient.StartCreateOrUpdateAsync(
                    resourceGroupName: rgName,
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

            var vaults = VaultsClient.ListByResourceGroupAsync(rgName, top);

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
                await VaultsClient.DeleteAsync(resourceGroupName: rgName, vaultName: v);
            }
        }

        [Test]
        public async Task KeyVaultManagementRecoverDeletedVault()
        {
            var parameters = new VaultCreateOrUpdateParameters(location, vaultProperties);
            parameters.Tags = tags;
            var createdVault = await VaultsClient.StartCreateOrUpdateAsync(
                resourceGroupName: rgName,
                vaultName: vaultName,
                parameters: parameters
                );

            var vaultValue = await WaitForCompletionAsync(createdVault);

            // Delete
            await VaultsClient.DeleteAsync(
                resourceGroupName: rgName,
                vaultName: vaultName);

            // Get deleted vault
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await VaultsClient.GetAsync(
                    resourceGroupName: rgName,
                    vaultName: vaultName);
            });

            parameters = new VaultCreateOrUpdateParameters(location, vaultProperties);
            parameters.Tags = tags;
            // Recover in default mode
            var recoveredRawVault = await VaultsClient.StartCreateOrUpdateAsync(
                resourceGroupName: rgName,
                vaultName: vaultName,
                parameters: parameters
                );
            var recoveredVault = await WaitForCompletionAsync(recoveredRawVault);
            Assert.True(recoveredVault.Value.IsEqual(vaultValue.Value));

            // Get recovered vault
            await VaultsClient.GetAsync(
                resourceGroupName: rgName,
                vaultName: vaultName);

            // Delete
            await VaultsClient.DeleteAsync(
                resourceGroupName: rgName,
                vaultName: vaultName);

            vaultProperties.CreateMode = CreateMode.Recover;
            parameters = new VaultCreateOrUpdateParameters(location, vaultProperties);

            // Recover in recover mode
            var recoveredRawVault2 = await VaultsClient.StartCreateOrUpdateAsync(
                resourceGroupName: rgName,
                vaultName: vaultName,
                parameters: parameters
                );
            var recoveredVault2 = await WaitForCompletionAsync(recoveredRawVault);

            Assert.True(recoveredVault2.Value.IsEqual(vaultValue.Value));

            // Get recovered vault
            await VaultsClient.GetAsync(
                resourceGroupName: rgName,
                vaultName: vaultName);

            // Delete
            await VaultsClient.DeleteAsync(
                resourceGroupName: rgName,
                vaultName: vaultName);
        }

        [Test]
        public async Task KeyVaultManagementListDeletedVaults()
        {
            int n = 3;
            List<string> resourceIds = new List<string>();
            List<string> vaultNameList = new List<string>();
            var parameters = new VaultCreateOrUpdateParameters(location, vaultProperties)
            {
                Tags = tags
            };
            for (int i = 0; i < n; i++)
            {
                string vaultName = Recording.GenerateAssetName("sdktestvault");
                var createdRawVault = await VaultsClient.StartCreateOrUpdateAsync(
                    resourceGroupName: rgName,
                    vaultName: vaultName,
                    parameters: parameters
                    );

                var createdVault = (await WaitForCompletionAsync(createdRawVault)).Value;

                Assert.NotNull(createdVault);
                Assert.NotNull(createdVault.Id);
                resourceIds.Add(createdVault.Id);
                vaultNameList.Add(createdVault.Name);

                await VaultsClient.DeleteAsync(resourceGroupName: rgName, vaultName: vaultName);

                var deletedVault = await VaultsClient.GetDeletedAsync(vaultName, location);
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
                    var purgeOperation = await VaultsClient.StartPurgeDeletedAsync(v.Name, location);
                    await WaitForCompletionAsync(purgeOperation);
                    Assert.ThrowsAsync<RequestFailedException>(async () => await VaultsClient.GetDeletedAsync(v.Name, location));
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
