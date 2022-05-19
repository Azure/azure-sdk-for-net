// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace EventHub.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using Microsoft.Azure.Management.EventHub;
    using Microsoft.Azure.Management.EventHub.Models;
    using Microsoft.Azure.Management.KeyVault;
    using Microsoft.Azure.Management.KeyVault.Models;
    using Microsoft.Azure.Management.ManagedServiceIdentity;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using Xunit;
    public partial class ScenarioTests
    {
        [Fact]
        public void NamespaceBYOKCreateGetUpdateDelete1()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                var location = "West US 2";

                var resourceGroup = string.Empty;

                var resourceGroupCluster = EventHubManagementHelper.ResourceGroupCluster;

                var testClusterName = "PMTestCluster1";

                var keyVaultName = "SDKTestingKey1";
                var KeyName = "sdktestingkey11";
                var KeyName2 = "sdktestingkey12";
                var KeyName3 = "sdktestingkey13";

                var identityName1 = TestUtilities.GenerateName(EventHubManagementHelper.IdentityPrefix);
                var identityName2 = TestUtilities.GenerateName(EventHubManagementHelper.IdentityPrefix);

                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(EventHubManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                var namespaceName = TestUtilities.GenerateName(EventHubManagementHelper.NamespacePrefix);
                var namespaceName2 = TestUtilities.GenerateName(EventHubManagementHelper.NamespacePrefix);

                try
                {

                    Cluster getClusterResponse = EventHubManagementClient.Clusters.Get(resourceGroupCluster, testClusterName);

                    var checkNameAvailable = EventHubManagementClient.Namespaces.CheckNameAvailability(namespaceName);

                    var createNamespaceResponse = this.EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroupCluster, namespaceName,
                        new EHNamespace()
                        {
                            Location = location,
                            Sku = new Microsoft.Azure.Management.EventHub.Models.Sku
                            {
                                Name = Microsoft.Azure.Management.EventHub.Models.SkuName.Standard,
                                Tier = SkuTier.Standard
                            },
                            Tags = new Dictionary<string, string>()
                            {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                            },
                            IsAutoInflateEnabled = false,
                            MaximumThroughputUnits = 0,
                            ClusterArmId = getClusterResponse.Id,
                            Identity = new Identity() { Type = ManagedServiceIdentityType.SystemAssigned }
                        });

                    Assert.NotNull(createNamespaceResponse);
                    Assert.Equal(namespaceName, createNamespaceResponse.Name);
                    Assert.Equal(getClusterResponse.Id, createNamespaceResponse.ClusterArmId);
                    Assert.False(createNamespaceResponse.IsAutoInflateEnabled);
                    Assert.Equal(0, createNamespaceResponse.MaximumThroughputUnits);
                    Assert.Equal(ManagedServiceIdentityType.SystemAssigned, createNamespaceResponse.Identity.Type);

                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                    // Create KeyVault
                    Microsoft.Azure.Management.KeyVault.Models.VaultCreateOrUpdateParameters vaultparams = new Microsoft.Azure.Management.KeyVault.Models.VaultCreateOrUpdateParameters();
                    var accesPolicies = new Microsoft.Azure.Management.KeyVault.Models.AccessPolicyEntry()
                    {
                        ObjectId = createNamespaceResponse.Identity.PrincipalId,
                        TenantId = Guid.Parse(createNamespaceResponse.Identity.TenantId),
                        Permissions = new Microsoft.Azure.Management.KeyVault.Models.Permissions()
                        {
                            Keys = new List<string> { "get", "wrapKey", "unwrapKey" }
                        }
                    };


                    Vault getVaultRsponse = KeyVaultManagementClient.Vaults.Get(resourceGroupCluster, keyVaultName);

                    vaultparams = new VaultCreateOrUpdateParameters(getVaultRsponse.Location, getVaultRsponse.Properties);

                    vaultparams.Properties.AccessPolicies.Add(accesPolicies);

                    var updateVault = KeyVaultManagementClient.Vaults.CreateOrUpdate(resourceGroupCluster, keyVaultName, vaultparams);

                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                    // Encrypt data in Event Hub namespace Customer managed key from keyvault

                    var getNamespaceResponse = EventHubManagementClient.Namespaces.Get(resourceGroupCluster, namespaceName);

                    getNamespaceResponse.Encryption = new Encryption()
                    {
                        KeySource = KeySource.MicrosoftKeyVault,
                        KeyVaultProperties = new[] {
                            new KeyVaultProperties()
                            {
                                KeyName = KeyName,
                                KeyVaultUri = updateVault.Properties.VaultUri,
                                KeyVersion = ""
                            }
                        }
                    };

                    var updateNamespaceResponse = this.EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroupCluster, namespaceName, getNamespaceResponse);

                    Assert.Equal(1, updateNamespaceResponse.Encryption.KeyVaultProperties.Count);
                    Assert.Equal(KeyName, updateNamespaceResponse.Encryption.KeyVaultProperties[0].KeyName);
                    Assert.Equal(updateVault.Properties.VaultUri, updateNamespaceResponse.Encryption.KeyVaultProperties[0].KeyVaultUri + "/");

                    Vault getVaultRsponse1 = KeyVaultManagementClient.Vaults.Get(resourceGroupCluster, keyVaultName);
                    vaultparams = new VaultCreateOrUpdateParameters(getVaultRsponse.Location, getVaultRsponse.Properties);
                    vaultparams.Properties.AccessPolicies.Remove(accesPolicies);
                    var updateVault1 = KeyVaultManagementClient.Vaults.CreateOrUpdate(resourceGroupCluster, keyVaultName, vaultparams);
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));
                    //Delete the namesapce within the cluster

                    Microsoft.Azure.Management.ManagedServiceIdentity.Models.Identity identity1 = new Microsoft.Azure.Management.ManagedServiceIdentity.Models.Identity() { Location = "westus"  };

                    Microsoft.Azure.Management.ManagedServiceIdentity.Models.Identity identity2 = new Microsoft.Azure.Management.ManagedServiceIdentity.Models.Identity() { Location = "westus" };

                    var userAssignedIdentity1 = IdentityManagementClient.UserAssignedIdentities.CreateOrUpdate(resourceGroup, identityName1, identity1);

                    var userAssignedIdentity2 = IdentityManagementClient.UserAssignedIdentities.CreateOrUpdate(resourceGroup, identityName2, identity2);

                    var accessPolicies = new Microsoft.Azure.Management.KeyVault.Models.AccessPolicyEntry()
                    {
                        ObjectId = userAssignedIdentity1.PrincipalId.ToString(),
                        TenantId = (Guid)userAssignedIdentity1.TenantId,
                        Permissions = new Microsoft.Azure.Management.KeyVault.Models.Permissions()
                        {
                            Keys = new List<string> { "get", "wrapKey", "unwrapKey" }
                        }
                    };

                    var accessPolicies2 = new Microsoft.Azure.Management.KeyVault.Models.AccessPolicyEntry()
                    {
                        ObjectId = userAssignedIdentity2.PrincipalId.ToString(),
                        TenantId = (Guid)userAssignedIdentity2.TenantId,
                        Permissions = new Microsoft.Azure.Management.KeyVault.Models.Permissions()
                        {
                            Keys = new List<string> { "get", "wrapKey", "unwrapKey" }
                        }
                    };

                    getVaultRsponse = KeyVaultManagementClient.Vaults.Get(resourceGroupCluster, keyVaultName);

                    vaultparams = new VaultCreateOrUpdateParameters(getVaultRsponse.Location, getVaultRsponse.Properties);

                    vaultparams.Properties.AccessPolicies.Add(accessPolicies);
                    vaultparams.Properties.AccessPolicies.Add(accessPolicies2);

                    updateVault = KeyVaultManagementClient.Vaults.CreateOrUpdate(resourceGroupCluster, keyVaultName, vaultparams);

                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                    createNamespaceResponse = this.EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName2,
                        new EHNamespace()
                        {
                            Location = location,
                            Sku = new Microsoft.Azure.Management.EventHub.Models.Sku
                            {
                                Name = Microsoft.Azure.Management.EventHub.Models.SkuName.Premium,
                                Tier = SkuTier.Premium
                            },
                            Identity = new Identity()
                            {
                                Type = ManagedServiceIdentityType.UserAssigned,
                                UserAssignedIdentities = new Dictionary<string, UserAssignedIdentity>()
                                {
                                    { userAssignedIdentity1.Id, new UserAssignedIdentity() },
                                    { userAssignedIdentity2.Id, new UserAssignedIdentity() }
                                },
                            },
                            Encryption = new Encryption()
                            {
                                KeySource = KeySource.MicrosoftKeyVault,
                                KeyVaultProperties = new List<KeyVaultProperties> {
                                    new KeyVaultProperties()
                                    {
                                        KeyName = KeyName2,
                                        KeyVaultUri = updateVault.Properties.VaultUri,
                                        KeyVersion = "",
                                        Identity = new UserAssignedIdentityProperties()
                                        {
                                            UserAssignedIdentity = userAssignedIdentity1.Id
                                        }
                                    },
                                    new KeyVaultProperties()
                                    {
                                        KeyName = KeyName3,
                                        KeyVaultUri = updateVault.Properties.VaultUri,
                                        KeyVersion = "",
                                        Identity = new UserAssignedIdentityProperties()
                                        {
                                            UserAssignedIdentity = userAssignedIdentity1.Id
                                        }
                                    }
                                }
                            }
                        });

                    TestUtilities.Wait(40000);

                    Assert.Equal(ManagedServiceIdentityType.UserAssigned, createNamespaceResponse.Identity.Type);
                    Assert.Equal(2, createNamespaceResponse.Encryption.KeyVaultProperties.Count);
                    Assert.Equal(KeyName2, createNamespaceResponse.Encryption.KeyVaultProperties[0].KeyName);
                    Assert.Equal(KeyName3, createNamespaceResponse.Encryption.KeyVaultProperties[1].KeyName);
                    Assert.Equal(updateVault.Properties.VaultUri, createNamespaceResponse.Encryption.KeyVaultProperties[0].KeyVaultUri + "/");
                    Assert.Equal(updateVault.Properties.VaultUri, createNamespaceResponse.Encryption.KeyVaultProperties[1].KeyVaultUri + "/");
                    Assert.Equal(userAssignedIdentity1.Id, createNamespaceResponse.Encryption.KeyVaultProperties[0].Identity.UserAssignedIdentity);
                    Assert.Equal(userAssignedIdentity1.Id, createNamespaceResponse.Encryption.KeyVaultProperties[1].Identity.UserAssignedIdentity);
                    Assert.Equal(2, createNamespaceResponse.Identity.UserAssignedIdentities.Count);


                }
                finally
                {
                    this.EventHubManagementClient.Namespaces.DeleteAsync(resourceGroupCluster, namespaceName, default(CancellationToken)).ConfigureAwait(false);
                    this.EventHubManagementClient.Namespaces.DeleteAsync(resourceGroupCluster, namespaceName2, default(CancellationToken)).ConfigureAwait(false);
                    //Delete Resource Group
                    this.ResourceManagementClient.ResourceGroups.DeleteWithHttpMessagesAsync(resourceGroup, null, default(CancellationToken)).ConfigureAwait(false);
                    Console.WriteLine("End of EH2018 Namespace CRUD IPFilter Rules test");
                }

            }
        }
    }
}