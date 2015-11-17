using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using Hyak.Common;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Newtonsoft.Json;
using Xunit;

namespace KeyVault.Management.Tests
{
    public class VaultOperationsTest : TestBase
    {
        [Fact]
        public void KeyVaultManagementVaultCreateUpdateDelete()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                var testBase = new KeyVaultTestBase();
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
                                      PermissionsToKeys = new string[] { "all" },
                                      PermissionsToSecrets = null
                                  };
                var createResponse = client.Vaults.CreateOrUpdate(
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
                            Sku = new Sku { Family = "A", Name = "Standard" },
                            TenantId = tenantIdGuid,
                            VaultUri = "",
                            AccessPolicies = new[]
                              {
                                  accPol
                              }
                        }
                    }
                    );

                ValidateVaultGetResponse(createResponse,
                    vaultName,
                    rgName,
                    testBase.subscriptionId,
                    tenantIdGuid,
                    testBase.location,
                    "A",
                    "Standard",
                    true,
                    true,
                    true,
                    new[] { accPol },
                    tags);

                //Update

                createResponse.Vault.Properties.Sku.Name = "Premium";
                accPol.PermissionsToSecrets = new string[] { "get", "set" };
                accPol.PermissionsToKeys = null;
                createResponse.Vault.Properties.AccessPolicies = new[] { accPol };

                var updateResponse = client.Vaults.CreateOrUpdate(
                    resourceGroupName: rgName,
                    vaultName: vaultName,
                    parameters: new VaultCreateOrUpdateParameters
                    {
                        Location = testBase.location,
                        Tags = tags,
                        Properties = createResponse.Vault.Properties
                    }
                    );

                ValidateVaultGetResponse(updateResponse,
                    vaultName,
                    rgName,
                    testBase.subscriptionId,
                    tenantIdGuid,
                    testBase.location,
                    "A",
                    "Premium",
                    true,
                    true,
                    true,
                    new[] { accPol },
                    tags);

                var getResponse = client.Vaults.Get(
                    resourceGroupName: rgName,
                    vaultName: vaultName);

                ValidateVaultGetResponse(getResponse,
                    vaultName,
                    rgName,
                    testBase.subscriptionId,
                    tenantIdGuid,
                    testBase.location,
                    "A",
                    "Premium",
                    true,
                    true,
                    true,
                    new[] { accPol },
                    tags);

                // Delete
                var deleteResponse = client.Vaults.Delete(
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
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                var testBase = new KeyVaultTestBase();
                var client = testBase.client;

                string rgName = TestUtilities.GenerateName("sdktestrg");
                testBase.resourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = testBase.location });

                string vaultName = TestUtilities.GenerateName("sdktestvault");
                var tenantIdGuid = Guid.Parse(testBase.tenantId);
                var objectIdGuid = Guid.Parse(testBase.objectId);
                var applicationIdGuid = Guid.Parse(testBase.applicationId);
                var tags = new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "value2" }, { "tag3", "value3" } };
                var accPol = new AccessPolicyEntry
                {
                    TenantId = tenantIdGuid,
                    ObjectId = objectIdGuid,
                    ApplicationId = applicationIdGuid,
                    PermissionsToKeys = new string[] { "all" },
                    PermissionsToSecrets = null
                };
                var createResponse = client.Vaults.CreateOrUpdate(
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
                            Sku = new Sku { Family = "A", Name = "Standard" },
                            TenantId = tenantIdGuid,
                            VaultUri = "",
                            AccessPolicies = new[]
                              {
                                  accPol
                              }
                        }
                    }
                    );

                ValidateVaultGetResponse(createResponse,
                    vaultName,
                    rgName,
                    testBase.subscriptionId,
                    tenantIdGuid,
                    testBase.location,
                    "A",
                    "Standard",
                    true,
                    true,
                    true,
                    new[] { accPol },
                    tags);

                // Get
                var getResponse = client.Vaults.Get(
                   resourceGroupName: rgName,
                   vaultName: vaultName);

                ValidateVaultGetResponse(getResponse,
                    vaultName,
                    rgName,
                    testBase.subscriptionId,
                    tenantIdGuid,
                    testBase.location,
                    "A",
                    "Standard",
                    true,
                    true,
                    true,
                    new[] { accPol },
                    tags);
                

                // Delete
                var deleteResponse = client.Vaults.Delete(
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

        private void ValidateVaultGetResponse(
            VaultGetResponse response,
            string expectedVaultName,
            string expectedResourceGroupName,
            string expectedSubId,
            Guid expectedTenantId,
            string expectedLocation,
            string expectedSkuFamily,
            string expectedSku,
            bool expectedEnabledForDeployment,
            bool expectedEnabledForTemplateDeployment,
            bool expectedEnabledForDiskEncryption,
            AccessPolicyEntry[] expectedPolicies,
            Dictionary<string, string> expectedTags)
        {
            Assert.NotNull(response);
            Assert.True(response.StatusCode == HttpStatusCode.OK);
            Assert.NotNull(response.Vault);
            Assert.NotNull(response.Vault.Properties);

            string resourceIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.KeyVault/vaults/{2}";
            string expectedResourceId = string.Format(resourceIdFormat, expectedSubId, expectedResourceGroupName, expectedVaultName);

            Assert.Equal(expectedResourceId, response.Vault.Id);
            Assert.Equal(expectedLocation, response.Vault.Location);
            Assert.Equal(expectedTenantId, response.Vault.Properties.TenantId);
            Assert.Equal(expectedSkuFamily, response.Vault.Properties.Sku.Family);
            Assert.Equal(expectedSku, response.Vault.Properties.Sku.Name);
            Assert.Equal(expectedVaultName, response.Vault.Name);
            Assert.Equal(expectedEnabledForDeployment, response.Vault.Properties.EnabledForDeployment);
            Assert.Equal(expectedEnabledForTemplateDeployment, response.Vault.Properties.EnabledForTemplateDeployment);
            Assert.Equal(expectedEnabledForDiskEncryption, response.Vault.Properties.EnabledForDiskEncryption);
            Assert.True(expectedTags.DictionaryEqual(response.Vault.Tags));
            Assert.True(CompareAccessPolicies(expectedPolicies, response.Vault.Properties.AccessPolicies.ToArray()));

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

            foreach(AccessPolicyEntry a in actual)
            {
                var match = expectedCopy.Where(e =>
                    e.TenantId == a.TenantId &&
                    e.ObjectId == a.ObjectId &&
                    ((!e.ApplicationId.HasValue && !a.ApplicationId.HasValue) ||
                     (e.ApplicationId.Value == e.ApplicationId.Value)) &&
                    Enumerable.SequenceEqual(e.PermissionsToSecrets, a.PermissionsToSecrets) &&
                    Enumerable.SequenceEqual(a.PermissionsToKeys, a.PermissionsToKeys)
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
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                var testBase = new KeyVaultTestBase();
                var client = testBase.client;

                string rgName = TestUtilities.GenerateName("sdktestrg");
                var tenantIdGuid = Guid.Parse(testBase.tenantId);
                var objectIdGuid = Guid.Parse(testBase.objectId);

                var tags = new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "value2" }, { "tag3", "value3" } };

                testBase.resourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = testBase.location });
                List<string> resourceIds = new List<string>();
                for (int i = 0; i < n; i++)
                {
                    string vaultName = TestUtilities.GenerateName("sdktestvault");
                    var createResponse = client.Vaults.CreateOrUpdate(
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
                                Sku = new Sku { Family = "A", Name = "Standard" },
                                TenantId = tenantIdGuid,
                                VaultUri = "",
                                AccessPolicies = new[]
                                {
                                    new AccessPolicyEntry
                                    {
                                        TenantId = tenantIdGuid,
                                        ObjectId = objectIdGuid,
                                        PermissionsToKeys = new string[]{"all"},
                                        PermissionsToSecrets = new string[]{"all"}
                                    }
                                }
                            }
                        }
                        );

                    Assert.NotNull(createResponse);
                    Assert.True(createResponse.StatusCode == HttpStatusCode.OK);
                    Assert.NotNull(createResponse.Vault);
                    Assert.NotNull(createResponse.Vault.Id);
                    resourceIds.Add(createResponse.Vault.Id);
                }

                var listResponse = client.Vaults.List(rgName, top);
                Assert.Equal(HttpStatusCode.OK, listResponse.StatusCode);
                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Vaults);
                foreach (var v in listResponse.Vaults)
                {
                    Assert.True(resourceIds.Remove(v.Id));
                }

                while (listResponse.NextLink != null)
                {
                    listResponse = client.Vaults.ListNext(listResponse.NextLink);
                    Assert.Equal(HttpStatusCode.OK, listResponse.StatusCode);
                    Assert.NotNull(listResponse);
                    foreach (var v in listResponse.Vaults)
                    {
                        Assert.True(resourceIds.Remove(v.Id));
                    }
                }
                Assert.True(resourceIds.Count == 0);
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
