// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Rest.Azure;
using System;

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
                var client = testBase.client;

                string rgName = TestUtilities.GenerateName("sdktestrg");
                testBase.resourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = testBase.location });

                string vaultName = TestUtilities.GenerateName("sdktestvault");
                var tenantIdGuid = Guid.Parse(testBase.tenantId);
                var objectIdGuid = Guid.Parse(testBase.objectId);
                var tags = new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "value2" }, { "tag3", "value3" } };
                var accPol = new AccessPolicyEntry
                {
                    TenantId = tenantIdGuid,
                    ObjectId = objectIdGuid,
                    Permissions = new Permissions
                    {
                        Keys = new string[] { "all" },
                        Secrets = null,
                        Certificates = new string[] { "all" }
                    }
                };
                var createdVault = client.Vaults.CreateOrUpdate(
                    resourceGroupName: rgName,
                    vaultName: vaultName,
                    parameters: new VaultCreateOrUpdateParameters
                    {
                        Location = testBase.location,
                        Tags = tags,
                        Properties = new VaultProperties
                        {
                            EnabledForDeployment = true,
                            EnabledForDiskEncryption = true,
                            EnabledForTemplateDeployment = true,
                            Sku = new Microsoft.Azure.Management.KeyVault.Models.Sku { Name = SkuName.Standard },
                            TenantId = tenantIdGuid,
                            VaultUri = "",
                            AccessPolicies = new[]
                              {
                                  accPol
                              }
                        }
                    }
                    );

                ValidateVault(createdVault,
                    vaultName,
                    rgName,
                    testBase.subscriptionId,
                    tenantIdGuid,
                    testBase.location,
                    "A",
                    SkuName.Standard,
                    true,
                    true,
                    true,
                    new[] { accPol },
                    tags);

                //Update

                createdVault.Properties.Sku.Name = SkuName.Premium;
                accPol.Permissions.Secrets = new string[] { "get", "set" };
                accPol.Permissions.Keys = null;
                createdVault.Properties.AccessPolicies = new[] { accPol };

                var updateVault = client.Vaults.CreateOrUpdate(
                    resourceGroupName: rgName,
                    vaultName: vaultName,
                    parameters: new VaultCreateOrUpdateParameters
                    {
                        Location = testBase.location,
                        Tags = tags,
                        Properties = createdVault.Properties
                    }
                    );

                ValidateVault(updateVault,
                    vaultName,
                    rgName,
                    testBase.subscriptionId,
                    tenantIdGuid,
                    testBase.location,
                    "A",
                    SkuName.Premium,
                    true,
                    true,
                    true,
                    new[] { accPol },
                    tags);

                var retrievedVault = client.Vaults.Get(
                    resourceGroupName: rgName,
                    vaultName: vaultName);

                ValidateVault(retrievedVault,
                    vaultName,
                    rgName,
                    testBase.subscriptionId,
                    tenantIdGuid,
                    testBase.location,
                    "A",
                    SkuName.Premium,
                    true,
                    true,
                    true,
                    new[] { accPol },
                    tags);

                // Delete
                client.Vaults.Delete(
                    resourceGroupName: rgName,
                    vaultName: vaultName);

                Assert.Throws<CloudException>(() =>
                {
                    client.Vaults.Get(
                        resourceGroupName: rgName,
                        vaultName: vaultName);
                });
            }
        }

        [Fact]
        public void KeyVaultManagementVaultTestCompoundIdentityAccessControlPolicy()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new KeyVaultTestBase(context);
                var client = testBase.client;

                string rgName = TestUtilities.GenerateName("sdktestrg");
                testBase.resourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = testBase.location });

                string vaultName = TestUtilities.GenerateName("sdktestvault");
                var tenantIdGuid = Guid.Parse(testBase.tenantId);
                var objectIdGuid = Guid.Parse(testBase.objectId);
                var applicationId = Guid.Parse(testBase.applicationId);
                var tags = new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "value2" }, { "tag3", "value3" } };
                var accPol = new AccessPolicyEntry
                {
                    TenantId = tenantIdGuid,
                    ObjectId = objectIdGuid,
                    ApplicationId = applicationId,
                    Permissions = new Permissions
                    {
                        Keys = new string[] { "all" },
                        Secrets = null,
                        Certificates = new string[] { "all" }
                    }
                };
                var createVault = client.Vaults.CreateOrUpdate(
                    resourceGroupName: rgName,
                    vaultName: vaultName,
                    parameters: new VaultCreateOrUpdateParameters
                    {
                        Location = testBase.location,
                        Tags = tags,
                        Properties = new VaultProperties
                        {
                            EnabledForDeployment = true,
                            EnabledForDiskEncryption = true,
                            EnabledForTemplateDeployment = true,
                            Sku = new Microsoft.Azure.Management.KeyVault.Models.Sku { Name = SkuName.Standard },
                            TenantId = tenantIdGuid,
                            VaultUri = "",
                            AccessPolicies = new[]
                              {
                                  accPol
                              }
                        }
                    }
                    );

                ValidateVault(createVault,
                    vaultName,
                    rgName,
                    testBase.subscriptionId,
                    tenantIdGuid,
                    testBase.location,
                    "A",
                    SkuName.Standard,
                    true,
                    true,
                    true,
                    new[] { accPol },
                    tags);

                // Get
                var retrievedVault = client.Vaults.Get(
                   resourceGroupName: rgName,
                   vaultName: vaultName);

                ValidateVault(retrievedVault,
                    vaultName,
                    rgName,
                    testBase.subscriptionId,
                    tenantIdGuid,
                    testBase.location,
                    "A",
                    SkuName.Standard,
                    true,
                    true,
                    true,
                    new[] { accPol },
                    tags);


                // Delete
                client.Vaults.Delete(
                    resourceGroupName: rgName,
                    vaultName: vaultName);

                Assert.Throws<CloudException>(() =>
                {
                    client.Vaults.Get(
                        resourceGroupName: rgName,
                        vaultName: vaultName);
                });
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
            Assert.True(expectedTags.DictionaryEqual(vault.Tags));
            Assert.True(CompareAccessPolicies(expectedPolicies, vault.Properties.AccessPolicies.ToArray()));
        }

        private bool CompareAccessPolicies(AccessPolicyEntry[] expected, AccessPolicyEntry[] actual)
        {
            if (expected == null && actual == null)
                return true;

            if (expected == null || actual == null)
                return false;

            if (expected.Length != actual.Length)
                return false;

            AccessPolicyEntry[] expectedCopy = new AccessPolicyEntry[expected.Length];
            expected.CopyTo(expectedCopy, 0);

            foreach (AccessPolicyEntry a in actual)
            {
                var match = expectedCopy.Where(e =>
                    e.TenantId == a.TenantId &&
                    e.ObjectId == a.ObjectId &&
                    e.ApplicationId == a.ApplicationId &&
                    ((a.Permissions.Secrets == null && e.Permissions.Secrets == null) ||
                        Enumerable.SequenceEqual(e.Permissions.Secrets, a.Permissions.Secrets)) &&
                    ((a.Permissions.Keys == null && e.Permissions.Keys == null) ||
                        Enumerable.SequenceEqual(a.Permissions.Keys, a.Permissions.Keys))
                    ).FirstOrDefault();
                if (match == null)
                    return false;

                expectedCopy = expectedCopy.Where(e => e != match).ToArray();
            }
            if (expectedCopy.Length > 0)
                return false;

            return true;
        }


        [Fact]
        public void KeyVaultManagementListVaults()
        {
            int n = 3;
            int top = 2;
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new KeyVaultTestBase(context);
                var client = testBase.client;

                string rgName = TestUtilities.GenerateName("sdktestrg");
                var tenantIdGuid = Guid.Parse(testBase.tenantId);
                var objectIdGuid = Guid.Parse(testBase.objectId);

                var tags = new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "value2" }, { "tag3", "value3" } };

                testBase.resourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = testBase.location });
                List<string> resourceIds = new List<string>();
                List<string> vaultNameList = new List<string>();
                for (int i = 0; i < n; i++)
                {
                    string vaultName = TestUtilities.GenerateName("sdktestvault");
                    var createdVault = client.Vaults.CreateOrUpdate(
                        resourceGroupName: rgName,
                        vaultName: vaultName,
                        parameters: new VaultCreateOrUpdateParameters
                        {
                            Location = testBase.location,
                            Tags = tags,
                            Properties = new VaultProperties
                            {
                                EnabledForDeployment = true,
                                EnabledForDiskEncryption = true,
                                EnabledForTemplateDeployment = true,
                                Sku = new Microsoft.Azure.Management.KeyVault.Models.Sku { Name = SkuName.Standard },
                                TenantId = tenantIdGuid,
                                VaultUri = "",
                                AccessPolicies = new[]
                                {
                                    new AccessPolicyEntry
                                    {
                                        TenantId = tenantIdGuid,
                                        ObjectId = objectIdGuid,
                                        Permissions = new Permissions{
                                            Keys = new string[]{"all"},
                                            Secrets = new string[]{"all"},
                                            Certificates = new string[] { "all" }
                                        }
                                    }
                                }
                            }
                        }
                        );

                    Assert.NotNull(createdVault);
                    Assert.NotNull(createdVault.Id);
                    resourceIds.Add(createdVault.Id);
                    vaultNameList.Add(createdVault.Name);
                }

                var vaults = client.Vaults.ListByResourceGroup(rgName, top);
                Assert.NotNull(vaults);

                foreach (var v in vaults)
                {
                    Assert.True(resourceIds.Remove(v.Id));
                }

                while (vaults.NextPageLink != null)
                {
                    vaults = client.Vaults.ListNext(vaults.NextPageLink);
                    Assert.NotNull(vaults);
                    foreach (var v in vaults)
                    {
                        Assert.True(resourceIds.Remove(v.Id));
                    }
                }
                Assert.True(resourceIds.Count == 0);

                var allVaults = client.Vaults.List(top);
                Assert.NotNull(vaults);

                // Delete
                foreach (var v in vaultNameList)
                {
                    client.Vaults.Delete(resourceGroupName: rgName, vaultName: v);
                }
            }
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
    }
}