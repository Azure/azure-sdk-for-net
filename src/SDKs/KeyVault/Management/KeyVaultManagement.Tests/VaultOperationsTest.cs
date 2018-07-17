// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace KeyVault.Management.Tests
{
    public class VaultOperationsTest : TestBase
    {
        [Fact]
        public void KeyVaultManagementVaultCreateUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new KeyVaultTestBase(context);
                testBase.vaultProperties.EnableSoftDelete = null;

                var createdVault = testBase.client.Vaults.CreateOrUpdate(
                    resourceGroupName: testBase.rgName,
                    vaultName: testBase.vaultName,
                    parameters: new VaultCreateOrUpdateParameters
                    {
                        Location = testBase.location,
                        Tags = testBase.tags,
                        Properties = testBase.vaultProperties
                    }
                    );

                ValidateVault(createdVault,
                    testBase.vaultName,
                    testBase.rgName,
                    testBase.subscriptionId,
                    testBase.tenantIdGuid,
                    testBase.location,
                    "A",
                    SkuName.Standard,
                    true,
                    true,
                    true,
                    null,
                    new[] { testBase.accPol },
                    testBase.vaultProperties.NetworkAcls,
                    testBase.tags);

                //Update

                createdVault.Properties.Sku.Name = SkuName.Premium;
                testBase.accPol.Permissions.Secrets = new string[] { "get", "set" };
                testBase.accPol.Permissions.Keys = null;
                testBase.accPol.Permissions.Storage = new string[] { "get", "regenerateKey" };
                createdVault.Properties.AccessPolicies = new[] { testBase.accPol };

                var updateVault = testBase.client.Vaults.CreateOrUpdate(
                    resourceGroupName: testBase.rgName,
                    vaultName: testBase.vaultName,
                    parameters: new VaultCreateOrUpdateParameters
                    {
                        Location = testBase.location,
                        Tags = testBase.tags,
                        Properties = createdVault.Properties
                    }
                    );

                ValidateVault(updateVault,
                    testBase.vaultName,
                    testBase.rgName,
                    testBase.subscriptionId,
                    testBase.tenantIdGuid,
                    testBase.location,
                    "A",
                    SkuName.Premium,
                    true,
                    true,
                    true,
                    null,
                    new[] { testBase.accPol },
                    testBase.vaultProperties.NetworkAcls,
                    testBase.tags);

                var retrievedVault = testBase.client.Vaults.Get(
                    resourceGroupName: testBase.rgName,
                    vaultName: testBase.vaultName);

                ValidateVault(retrievedVault,
                    testBase.vaultName,
                    testBase.rgName,
                    testBase.subscriptionId,
                    testBase.tenantIdGuid,
                    testBase.location,
                    "A",
                    SkuName.Premium,
                    true,
                    true,
                    true,
                    null,
                    new[] { testBase.accPol },
                    testBase.vaultProperties.NetworkAcls,
                    testBase.tags);

                // Delete
                testBase.client.Vaults.Delete(
                    resourceGroupName: testBase.rgName,
                    vaultName: testBase.vaultName);

                Assert.Throws<CloudException>(() =>
                {
                    testBase.client.Vaults.Get(
                        resourceGroupName: testBase.rgName,
                        vaultName: testBase.vaultName);
                });
            }
        }

        [Fact]
        public void KeyVaultManagementVaultTestCompoundIdentityAccessControlPolicy()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new KeyVaultTestBase(context);
                testBase.accPol.ApplicationId = Guid.Parse(testBase.applicationId);
                testBase.vaultProperties.EnableSoftDelete = null;

                var createVault = testBase.client.Vaults.CreateOrUpdate(
                    resourceGroupName: testBase.rgName,
                    vaultName: testBase.vaultName,
                    parameters: new VaultCreateOrUpdateParameters
                    {
                        Location = testBase.location,
                        Tags = testBase.tags,
                        Properties = testBase.vaultProperties
                    }
                    );

                ValidateVault(createVault,
                    testBase.vaultName,
                    testBase.rgName,
                    testBase.subscriptionId,
                    testBase.tenantIdGuid,
                    testBase.location,
                    "A",
                    SkuName.Standard,
                    true,
                    true,
                    true,
                    null,
                    new[] { testBase.accPol },
                    testBase.tags);

                // Get
                var retrievedVault = testBase.client.Vaults.Get(
                   resourceGroupName: testBase.rgName,
                   vaultName: testBase.vaultName);

                ValidateVault(retrievedVault,
                    testBase.vaultName,
                    testBase.rgName,
                    testBase.subscriptionId,
                    testBase.tenantIdGuid,
                    testBase.location,
                    "A",
                    SkuName.Standard,
                    true,
                    true,
                    true,
                    null,
                    new[] { testBase.accPol },
                    testBase.tags);


                // Delete
                testBase.client.Vaults.Delete(
                    resourceGroupName: testBase.rgName,
                    vaultName: testBase.vaultName);

                Assert.Throws<CloudException>(() =>
                {
                    testBase.client.Vaults.Get(
                        resourceGroupName: testBase.rgName,
                        vaultName: testBase.vaultName);
                });
            }
        }

        [Fact]
        public void KeyVaultManagementListVaults()
        {
            int n = 3;
            int top = 2;
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new KeyVaultTestBase(context);
                testBase.vaultProperties.EnableSoftDelete = null;

                List<string> resourceIds = new List<string>();
                List<string> vaultNameList = new List<string>();
                for (int i = 0; i < n; i++)
                {
                    string vaultName = TestUtilities.GenerateName("sdktestvault");
                    var createdVault = testBase.client.Vaults.CreateOrUpdate(
                        resourceGroupName: testBase.rgName,
                        vaultName: vaultName,
                        parameters: new VaultCreateOrUpdateParameters
                        {
                            Location = testBase.location,
                            Tags = testBase.tags,
                            Properties = testBase.vaultProperties
                        }
                        );

                    Assert.NotNull(createdVault);
                    Assert.NotNull(createdVault.Id);
                    resourceIds.Add(createdVault.Id);
                    vaultNameList.Add(createdVault.Name);
                }

                var vaults = testBase.client.Vaults.ListByResourceGroup(testBase.rgName, top);
                Assert.NotNull(vaults);

                foreach (var v in vaults)
                {
                    Assert.True(resourceIds.Remove(v.Id));
                }

                while (vaults.NextPageLink != null)
                {
                    vaults = testBase.client.Vaults.ListByResourceGroupNext(vaults.NextPageLink);
                    Assert.NotNull(vaults);
                    foreach (var v in vaults)
                    {
                        Assert.True(resourceIds.Remove(v.Id));
                    }
                }
                Assert.True(resourceIds.Count == 0);

                var allVaults = testBase.client.Vaults.List(top);
                Assert.NotNull(vaults);

                // Delete
                foreach (var v in vaultNameList)
                {
                    testBase.client.Vaults.Delete(resourceGroupName: testBase.rgName, vaultName: v);
                }
            }
        }

        [Fact]
        public void KeyVaultManagementRecoverDeletedVault()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new KeyVaultTestBase(context);

                var createdVault = testBase.client.Vaults.CreateOrUpdate(
                    resourceGroupName: testBase.rgName,
                    vaultName: testBase.vaultName,
                    parameters: new VaultCreateOrUpdateParameters
                    {
                        Location = testBase.location,
                        Tags = testBase.tags,
                        Properties = testBase.vaultProperties
                    }
                    );

                // Delete
                testBase.client.Vaults.Delete(
                    resourceGroupName: testBase.rgName,
                    vaultName: testBase.vaultName);

                // Get deleted vault
                Assert.Throws<CloudException>(() =>
                {
                    testBase.client.Vaults.Get(
                        resourceGroupName: testBase.rgName,
                        vaultName: testBase.vaultName);
                });

                // Recover in default mode
                var recoveredVault = testBase.client.Vaults.CreateOrUpdate(
                    resourceGroupName: testBase.rgName,
                    vaultName: testBase.vaultName,
                    parameters: new VaultCreateOrUpdateParameters
                    {
                        Location = testBase.location,
                        Tags = testBase.tags,
                        Properties = testBase.vaultProperties
                    }
                    );

                Assert.True(recoveredVault.IsEqual(createdVault));

                // Get recovered vault
                testBase.client.Vaults.Get(
                    resourceGroupName: testBase.rgName,
                    vaultName: testBase.vaultName);

                // Delete
                testBase.client.Vaults.Delete(
                    resourceGroupName: testBase.rgName,
                    vaultName: testBase.vaultName);

                // Recover in recover mode
                var recoveredVault2 = testBase.client.Vaults.CreateOrUpdate(
                    resourceGroupName: testBase.rgName,
                    vaultName: testBase.vaultName,
                    parameters: new VaultCreateOrUpdateParameters
                    {
                        Location = testBase.location,
                        Tags = testBase.tags,
                        Properties = new VaultProperties
                        {
                            CreateMode = CreateMode.Recover
                        }
                    }
                    );
                
                Assert.True(recoveredVault2.IsEqual(createdVault));

                // Get recovered vault
                testBase.client.Vaults.Get(
                    resourceGroupName: testBase.rgName,
                    vaultName: testBase.vaultName);

                // Delete
                testBase.client.Vaults.Delete(
                    resourceGroupName: testBase.rgName,
                    vaultName: testBase.vaultName);
            }
        }

        [Fact]
        public void KeyVaultManagementListDeletedVaults()
        {
            int n = 3;
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new KeyVaultTestBase(context);

                List<string> resourceIds = new List<string>();
                List<string> vaultNameList = new List<string>();
                for (int i = 0; i < n; i++)
                {
                    string vaultName = TestUtilities.GenerateName("sdktestvault");
                    var createdVault = testBase.client.Vaults.CreateOrUpdate(
                        resourceGroupName: testBase.rgName,
                        vaultName: vaultName,
                        parameters: new VaultCreateOrUpdateParameters
                        {
                            Location = testBase.location,
                            Tags = testBase.tags,
                            Properties = testBase.vaultProperties
                        }
                        );

                    Assert.NotNull(createdVault);
                    Assert.NotNull(createdVault.Id);
                    resourceIds.Add(createdVault.Id);
                    vaultNameList.Add(createdVault.Name);

                    testBase.client.Vaults.Delete(resourceGroupName: testBase.rgName, vaultName: vaultName);

                    var deletedVault = testBase.client.Vaults.GetDeleted(vaultName, testBase.location);
                    deletedVault.IsEqual(createdVault);
                }

                var deletedVaults = testBase.client.Vaults.ListDeleted();
                Assert.NotNull(deletedVaults);

                foreach (var v in deletedVaults)
                {
                    var exists = resourceIds.Remove(v.Properties.VaultId);

                    if (exists)
                    {
                        // Purge vault
                        testBase.client.Vaults.PurgeDeleted(v.Name, testBase.location);
                        Assert.Throws<CloudException>(() => testBase.client.Vaults.GetDeleted(v.Name, testBase.location));
                    }
                }

                while (deletedVaults.NextPageLink != null)
                {
                    deletedVaults = testBase.client.Vaults.ListDeletedNext(deletedVaults.NextPageLink);
                    Assert.NotNull(deletedVaults);
                    foreach (var v in deletedVaults)
                    {
                        var exists = resourceIds.Remove(v.Id);

                        if (exists)
                        {
                            // Purge vault
                            testBase.client.Vaults.PurgeDeleted(v.Name, testBase.location);
                            Assert.Throws<CloudException>(() => testBase.client.Vaults.GetDeleted(v.Name, testBase.location));
                        }
                    }

                    if (resourceIds.Count == 0)
                        break;
                }
                Assert.True(resourceIds.Count == 0);
            }
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

            Assert.Equal(expectedResourceId, vault.Id);
            Assert.Equal(expectedLocation, vault.Location);
            Assert.Equal(expectedTenantId, vault.Properties.TenantId);
            Assert.Equal(expectedSku, vault.Properties.Sku.Name);
            Assert.Equal(expectedVaultName, vault.Name);
            Assert.Equal(expectedEnabledForDeployment, vault.Properties.EnabledForDeployment);
            Assert.Equal(expectedEnabledForTemplateDeployment, vault.Properties.EnabledForTemplateDeployment);
            Assert.Equal(expectedEnabledForDiskEncryption, vault.Properties.EnabledForDiskEncryption);
            Assert.Equal(expectedEnableSoftDelete, vault.Properties.EnableSoftDelete);
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
            Assert.Equal(networkRuleSet.DefaultAction, vault.Properties.NetworkAcls.DefaultAction);
            Assert.Equal(networkRuleSet.Bypass, vault.Properties.NetworkAcls.Bypass);
            Assert.True(vault.Properties.NetworkAcls.IpRules != null && vault.Properties.NetworkAcls.IpRules.Count == 2);
            Assert.Equal(networkRuleSet.IpRules[0].Value, vault.Properties.NetworkAcls.IpRules[0].Value);
            Assert.Equal(networkRuleSet.IpRules[1].Value, vault.Properties.NetworkAcls.IpRules[1].Value);
        }
    }

    public static class Extensions
    {
        public static bool DictionaryEqual<TKey, TValue>(this IDictionary<TKey, TValue> first, IDictionary<TKey, TValue> second)
        {
            return first.DictionaryEqual(second, null);
        }

        public static bool DictionaryEqual<TKey, TValue>(
            this IDictionary<TKey, TValue> first, IDictionary<TKey, TValue> second,
            IEqualityComparer<TValue> valueComparer)
        {
            if (first == second) return true;
            if ((first == null) || (second == null)) return false;
            if (first.Count != second.Count) return false;

            valueComparer = valueComparer ?? EqualityComparer<TValue>.Default;

            foreach (var kvp in first)
            {
                TValue secondValue;
                if (!second.TryGetValue(kvp.Key, out secondValue)) return false;
                if (!valueComparer.Equals(kvp.Value, secondValue)) return false;
            }
            return true;
        }

        public static bool IsEqual(this DeletedVault deletedVault, Vault createdVault)
        {
            Assert.Equal(createdVault.Location, deletedVault.Properties.Location);
            Assert.Equal(createdVault.Name, deletedVault.Name);
            Assert.Equal(createdVault.Id, deletedVault.Properties.VaultId);
            Assert.Equal("Microsoft.KeyVault/deletedVaults", deletedVault.Type);
            Assert.True(createdVault.Tags.DictionaryEqual(deletedVault.Properties.Tags));
            Assert.NotNull(deletedVault.Properties.ScheduledPurgeDate);
            Assert.NotNull(deletedVault.Properties.DeletionDate);
            Assert.NotNull(deletedVault.Id);
            return true;
        }
        public static bool IsEqual(this Vault vault1, Vault vault2)
        {
            Assert.Equal(vault2.Location, vault1.Location);
            Assert.Equal(vault2.Name, vault1.Name);
            Assert.Equal(vault2.Id, vault1.Id);
            Assert.True(vault2.Tags.DictionaryEqual(vault1.Tags));
            
            Assert.Equal(vault2.Properties.VaultUri.TrimEnd('/'), vault1.Properties.VaultUri.TrimEnd('/'));
            Assert.Equal(vault2.Properties.TenantId, vault1.Properties.TenantId);
            Assert.Equal(vault2.Properties.Sku.Name, vault1.Properties.Sku.Name);
            Assert.Equal(vault2.Properties.EnableSoftDelete, vault1.Properties.EnableSoftDelete);
            Assert.Equal(vault2.Properties.EnabledForTemplateDeployment, vault1.Properties.EnabledForTemplateDeployment);
            Assert.Equal(vault2.Properties.EnabledForDiskEncryption, vault1.Properties.EnabledForDiskEncryption);
            Assert.Equal(vault2.Properties.EnabledForDeployment, vault1.Properties.EnabledForDeployment);
            Assert.True(vault2.Properties.AccessPolicies.IsEqual(vault1.Properties.AccessPolicies));
            return true;
        }
        
        public static bool IsEqual(this IList<AccessPolicyEntry> expected, IList<AccessPolicyEntry> actual)
        {
            if (expected == null && actual == null)
                return true;

            if (expected == null || actual == null)
                return false;

            if (expected.Count != actual.Count)
                return false;

            AccessPolicyEntry[] expectedCopy = new AccessPolicyEntry[expected.Count];
            expected.CopyTo(expectedCopy, 0);

            foreach (AccessPolicyEntry a in actual)
            {
                var match = expectedCopy.Where(e =>
                    e.TenantId == a.TenantId &&
                    e.ObjectId == a.ObjectId &&
                    e.ApplicationId == a.ApplicationId &&
                    ((a.Permissions.Secrets == null && e.Permissions.Secrets == null) ||
                        Enumerable.SequenceEqual(a.Permissions.Secrets, e.Permissions.Secrets)) &&
                    ((a.Permissions.Keys == null && e.Permissions.Keys == null) ||
                        Enumerable.SequenceEqual(a.Permissions.Keys, e.Permissions.Keys)) &&
                     ((a.Permissions.Certificates == null && e.Permissions.Certificates == null) ||
                      Enumerable.SequenceEqual(a.Permissions.Certificates, e.Permissions.Certificates)) &&
                    ((a.Permissions.Storage == null && e.Permissions.Storage == null) ||
                        Enumerable.SequenceEqual(a.Permissions.Storage, e.Permissions.Storage))
                    ).FirstOrDefault();
                if (match == null)
                    return false;

                expectedCopy = expectedCopy.Where(e => e != match).ToArray();
            }
            if (expectedCopy.Length > 0)
                return false;

            return true;
        }
    }
}