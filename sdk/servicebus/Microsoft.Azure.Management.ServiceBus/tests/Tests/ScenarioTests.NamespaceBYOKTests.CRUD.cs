// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ServiceBus.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.ServiceBus;
    using Microsoft.Azure.Management.ServiceBus.Models;
    using Microsoft.Azure.Management.KeyVault;
    using Microsoft.Azure.Management.KeyVault.Models;
    using Microsoft.Azure.Management.ManagedServiceIdentity;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using Xunit;
    using SkuName = Microsoft.Azure.Management.ServiceBus.Models.SkuName;
    using System.Threading;

    public partial class ScenarioTests
    {
        [Fact]
        public void NamespaceBYOKCreateGetUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                var resourceGroupCluster = ServiceBusManagementHelper.ResourceGroupCluster;

                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(ServiceBusManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                var keyVaultName = "SDKTestingKey1";
                var KeyName = "sdktestingkey11";
                var KeyName2 = "sdktestingkey12";
                var KeyName3 = "sdktestingkey13";

                // Create Namespace
                var namespaceName = TestUtilities.GenerateName(ServiceBusManagementHelper.NamespacePrefix);

                //Check namespace name available
                var checknamespaceavailable = ServiceBusManagementClient.Namespaces.CheckNameAvailabilityMethod(new CheckNameAvailability() { Name = namespaceName });

                var createNamespaceResponse = this.ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new SBNamespace()
                    {
                        Location = location,
                        Sku = new SBSku
                        {
                            Name = SkuName.Premium,
                            Tier = SkuTier.Premium
                        },
                        Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        },
                        Identity = new Identity() { Type = ManagedServiceIdentityType.SystemAssigned }
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);
                Assert.Equal(ManagedServiceIdentityType.SystemAssigned, createNamespaceResponse.Identity.Type);

                createNamespaceResponse.Identity = new Identity() { Type = ManagedServiceIdentityType.None };

                createNamespaceResponse = ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName, createNamespaceResponse);
                Assert.Null(createNamespaceResponse.Identity);

                createNamespaceResponse.Identity = new Identity() { Type = ManagedServiceIdentityType.SystemAssigned };

                createNamespaceResponse = ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName, createNamespaceResponse);
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

                var getNamespaceResponse = ServiceBusManagementClient.Namespaces.Get(resourceGroup, namespaceName);

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

                var updateNamespaceResponse = this.ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName, getNamespaceResponse);

                Vault getVaultRsponse1 = KeyVaultManagementClient.Vaults.Get(resourceGroupCluster, keyVaultName);
                vaultparams = new VaultCreateOrUpdateParameters(getVaultRsponse.Location, getVaultRsponse.Properties);
                vaultparams.Properties.AccessPolicies.Remove(accesPolicies);
                var updateVault1 = KeyVaultManagementClient.Vaults.CreateOrUpdate(resourceGroupCluster, keyVaultName, vaultparams);
                TestUtilities.Wait(TimeSpan.FromSeconds(5));
                //Delete the namesapce within the cluster

                //Create User Assigned Identities and give permissions to access keyvault
                //----------------------------------------------------------------

                var identityName1 = TestUtilities.GenerateName(ServiceBusManagementHelper.IdentityPrefix);
                var identityName2 = TestUtilities.GenerateName(ServiceBusManagementHelper.IdentityPrefix);
                Microsoft.Azure.Management.ManagedServiceIdentity.Models.Identity identity1 = new Microsoft.Azure.Management.ManagedServiceIdentity.Models.Identity() { Location = "westus" };

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
                //--------------------------------------------------------

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                //Enable User Assigned Identity Encryption
                //---------------------------------------------
                createNamespaceResponse = this.ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new SBNamespace()
                    {
                        Location = location,
                        Sku = new Microsoft.Azure.Management.ServiceBus.Models.SBSku
                        {
                            Name = Microsoft.Azure.Management.ServiceBus.Models.SkuName.Premium,
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
                    }
                );

                Assert.Equal(ManagedServiceIdentityType.UserAssigned, createNamespaceResponse.Identity.Type);
                Assert.Equal(2, createNamespaceResponse.Encryption.KeyVaultProperties.Count);
                Assert.Equal(KeyName2, createNamespaceResponse.Encryption.KeyVaultProperties[0].KeyName);
                Assert.Equal(KeyName3, createNamespaceResponse.Encryption.KeyVaultProperties[1].KeyName);
                Assert.Equal(updateVault.Properties.VaultUri, createNamespaceResponse.Encryption.KeyVaultProperties[0].KeyVaultUri + "/");
                Assert.Equal(updateVault.Properties.VaultUri, createNamespaceResponse.Encryption.KeyVaultProperties[1].KeyVaultUri + "/");
                Assert.Equal(userAssignedIdentity1.Id, createNamespaceResponse.Encryption.KeyVaultProperties[0].Identity.UserAssignedIdentity);
                Assert.Equal(userAssignedIdentity1.Id, createNamespaceResponse.Encryption.KeyVaultProperties[1].Identity.UserAssignedIdentity);
                Assert.Equal(2, createNamespaceResponse.Identity.UserAssignedIdentities.Count);
                //-------------------------------------------------------------------------------------

                //Test if identity can be set to System and User assigned.
                //---------------------------------------------------------------------------------
                createNamespaceResponse.Identity.Type = ManagedServiceIdentityType.SystemAssignedUserAssigned;

                createNamespaceResponse = ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName, createNamespaceResponse);

                Assert.Equal(ManagedServiceIdentityType.SystemAssignedUserAssigned, createNamespaceResponse.Identity.Type);
                Assert.Equal(2, createNamespaceResponse.Encryption.KeyVaultProperties.Count);
                Assert.Equal(KeyName2, createNamespaceResponse.Encryption.KeyVaultProperties[0].KeyName);
                Assert.Equal(KeyName3, createNamespaceResponse.Encryption.KeyVaultProperties[1].KeyName);
                Assert.Equal(updateVault.Properties.VaultUri, createNamespaceResponse.Encryption.KeyVaultProperties[0].KeyVaultUri + "/");
                Assert.Equal(updateVault.Properties.VaultUri, createNamespaceResponse.Encryption.KeyVaultProperties[1].KeyVaultUri + "/");
                Assert.Equal(userAssignedIdentity1.Id, createNamespaceResponse.Encryption.KeyVaultProperties[0].Identity.UserAssignedIdentity);
                Assert.Equal(userAssignedIdentity1.Id, createNamespaceResponse.Encryption.KeyVaultProperties[1].Identity.UserAssignedIdentity);
                Assert.Equal(2, createNamespaceResponse.Identity.UserAssignedIdentities.Count);
                //----------------------------------------------------------------------------------

                // Delete namespace
                ServiceBusManagementClient.Namespaces.DeleteWithHttpMessagesAsync(resourceGroup, namespaceName, null, new CancellationToken()).ConfigureAwait(false);
            }
        }
    }
}