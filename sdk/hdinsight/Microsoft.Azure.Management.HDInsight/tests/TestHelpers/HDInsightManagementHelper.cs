// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Azure.Management.ManagedServiceIdentity;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using System;
using System.Collections.Generic;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.Azure.KeyVault.Models;

using Identity = Microsoft.Azure.Management.ManagedServiceIdentity.Models.Identity;
using Permissions = Microsoft.Azure.Management.KeyVault.Models.Permissions;
using SkuName = Microsoft.Azure.Management.KeyVault.Models.SkuName;
using Sku = Microsoft.Azure.Management.KeyVault.Models.Sku;
using StorageAccountCreateParameters = Microsoft.Azure.Management.Storage.Models.StorageAccountCreateParameters;
using static Management.HDInsight.Tests.HDInsightManagementTestUtilities;
using Microsoft.Azure.Management.Authorization;
using System.Linq;
using Microsoft.Azure.Management.Authorization.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;

namespace Management.HDInsight.Tests
{
    /// <summary>
    /// Provides operations for working with Azure resources.
    /// </summary>
    public class HDInsightManagementHelper
    {
        /// <summary>
        /// Provides operations for working with resources and resource groups.
        /// </summary>
        private ResourceManagementClient resourceManagementClient;

        /// <summary>
        /// The Azure Storage Management API.
        /// </summary>
        private StorageManagementClient storageManagementClient;

        /// <summary>
        /// The Managed Service Identity Client.
        /// </summary>
        private ManagedServiceIdentityClient identityManagementClient;

        /// <summary>
        /// Provides operations for authorization with Azure resources
        /// </summary>
        private AuthorizationManagementClient authorizationManagementClient;

        /// <summary>
        /// The Azure management API provides a RESTful set of web services that
        /// interact with Azure Key Vault.
        /// </summary>
        private KeyVaultManagementClient keyVaultManagementClient;

        /// <summary>
        /// The Azure network management client provides operations about vnet.
        /// </summary>
        private NetworkManagementClient networkManagementClient;

        /// <summary>
        /// Client class to perform cryptographic key operations and vault
        /// operations against the Key Vault service.
        /// </summary>
        private KeyVaultClient keyVaultClient;

        /// <summary>
        /// Common data
        /// </summary>
        private CommonTestFixture commonData;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="commonData"></param>
        /// <param name="context"></param>
        public HDInsightManagementHelper(CommonTestFixture commonData, HDInsightMockContext context)
        {
            resourceManagementClient = context.GetServiceClient<ResourceManagementClient>();
            storageManagementClient = context.GetServiceClient<StorageManagementClient>();
            identityManagementClient = context.GetServiceClient<ManagedServiceIdentityClient>();
            authorizationManagementClient = context.GetServiceClient<AuthorizationManagementClient>();
            keyVaultManagementClient = context.GetServiceClient<KeyVaultManagementClient>();
            keyVaultClient = GetKeyVaultClient();
            networkManagementClient = context.GetServiceClient<NetworkManagementClient>();
            this.commonData = commonData;
        }

        /// <summary>
        /// Register subscription for resource
        /// </summary>
        /// <param name="providerName"></param>
        public void RegisterSubscriptionForResource(string providerName)
        {
            var reg = resourceManagementClient.Providers.Register(providerName);
            ThrowIfTrue(
                reg == null,
                "resourceManagementClient.Providers.Register returned null."
            );

            var resultAfterRegister = resourceManagementClient.Providers.Get(providerName);
            ThrowIfTrue(
                resultAfterRegister == null,
                "resourceManagementClient.Providers.Get returned null."
            );
            ThrowIfTrue(
                string.IsNullOrEmpty(resultAfterRegister.Id),
                "Provider.Id is null or empty."
            );
            ThrowIfTrue(
                !providerName.Equals(resultAfterRegister.NamespaceProperty),
                string.Format(
                    "Provider name: {0} is not equal to {1}.",
                    resultAfterRegister.NamespaceProperty,
                    providerName
                )
            );
            ThrowIfTrue(
                !resultAfterRegister.RegistrationState.Equals("Registered") &&
                !resultAfterRegister.RegistrationState.Equals("Registering"),
                string.Format(
                    "Provider registration state was not 'Registered' or 'Registering', instead it was '{0}'",
                    resultAfterRegister.RegistrationState
                )
            );
            ThrowIfTrue(
                resultAfterRegister.ResourceTypes == null || resultAfterRegister.ResourceTypes.Count == 0,
                "Provider.ResourceTypes is empty."
            );
        }

        /// <summary>
        /// Create resource group
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="location"></param>
        public void CreateResourceGroup(string resourceGroupName, string location)
        {
            // Get the resource group first
            bool exists = false;
            ResourceGroup newlyCreatedGroup = null;
            try
            {
                newlyCreatedGroup = resourceManagementClient.ResourceGroups.Get(resourceGroupName);
                exists = true;
            }
            catch
            {
                // Do nothing because it means it doesn't exist
            }

            if (!exists)
            {
                var result =
                    resourceManagementClient.ResourceGroups.CreateOrUpdate(
                        resourceGroupName,
                        new ResourceGroup { Location = location }
                    );

                newlyCreatedGroup =
                    resourceManagementClient.ResourceGroups.Get(
                        resourceGroupName
                    );
            }

            ThrowIfTrue(
                newlyCreatedGroup == null,
                "resourceManagementClient.ResourceGroups.Get returned null."
            );
            ThrowIfTrue(
                !resourceGroupName.Equals(newlyCreatedGroup.Name),
                string.Format(
                    "resourceGroupName is not equal to {0}",
                    resourceGroupName
                )
            );
        }

        /// <summary>
        /// Create storage account
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="storageAccountName"></param>
        /// <param name="location"></param>
        /// <param name="storageAccountSuffix"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        public string CreateStorageAccount(
            string resourceGroupName,
            string storageAccountName,
            string location,
            out string storageAccountSuffix,
            Kind kind = Kind.Storage,
            bool? isHnsEnabled = default(bool?))
        {
            var stoInput = new StorageAccountCreateParameters
            {
                Location = location,
                Kind = kind,
                Sku = new Microsoft.Azure.Management.Storage.Models.Sku
                {
                    Name = Microsoft.Azure.Management.Storage.Models.SkuName.StandardGRS
                },
                IsHnsEnabled = isHnsEnabled
            };

            // Retrieve the storage account
            storageManagementClient.StorageAccounts.Create(
                resourceGroupName,
                storageAccountName,
                stoInput
            );

            // Retrieve the storage account primary access key
            var accessKey =
                storageManagementClient.StorageAccounts.ListKeys(
                    resourceGroupName,
                    storageAccountName
                ).Keys[0].Value;

            ThrowIfTrue(
                string.IsNullOrEmpty(accessKey),
                "storageManagementClient.StorageAccounts.ListKeys returned null."
            );

            // Set the storage account suffix
            var getResponse =
                storageManagementClient.StorageAccounts.GetProperties(
                    resourceGroupName,
                    storageAccountName
                );
            storageAccountSuffix = getResponse.PrimaryEndpoints.Blob.ToString();
            storageAccountSuffix = storageAccountSuffix.Replace("https://", "").TrimEnd('/');
            storageAccountSuffix = storageAccountSuffix.Replace(storageAccountName, "").TrimStart('.');
            // Remove the opening "blob." if it exists.
            storageAccountSuffix = storageAccountSuffix.Replace("blob.", "");

            return accessKey;
        }

        /// <summary>
        /// Get resouce id of the specific storage account
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="storageAccountName"></param>
        /// <returns></returns>
        public string GetStorageAccountId(string resourceGroupName, string storageAccountName)
        {
            var storageAccount = storageManagementClient.StorageAccounts.GetProperties(resourceGroupName, storageAccountName);
            return storageAccount.Id;
        }

        /// <summary>
        /// Create user-assigned managed identity.
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="msiName"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public Identity CreateManagedIdentity(
            string resourceGroupName,
            string msiName,
            string location)
        {
            var createParams = new Identity
            {
                Location = location
            };

            return identityManagementClient.UserAssignedIdentities.CreateOrUpdate(resourceGroupName, msiName, createParams);
        }

        /// <summary>
        /// Default vault permissions
        /// </summary>
        private static readonly Permissions DefaultPermissions = new Permissions
        {
            Keys = new string[] { "all" },
            Secrets = new string[] { "all" },
            Certificates = new string[] { "all" },
            Storage = new string[] { "all" }
        };

        /// <summary>
        /// Create key vault.
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="vaultName"></param>
        /// <param name="region"></param>
        /// <param name="sku"></param>
        /// <param name="permissions"></param>
        /// <param name="enabledForDeployment"></param>
        /// <param name="enabledForDiskEncryption"></param>
        /// <param name="enabledForTemplateDeployment"></param>
        /// <param name="enableSoftDelete"></param>
        /// <returns></returns>
        public Vault CreateVault(
            string resourceGroupName,
            string vaultName,
            string region,
            SkuName sku = SkuName.Premium,
            Permissions permissions = null,
            bool? enabledForDeployment = true,
            bool? enabledForDiskEncryption = true,
            bool? enabledForTemplateDeployment = true,
            bool? enableSoftDelete = null)
        {
            var accessPolicies = new List<AccessPolicyEntry>()
            {
                new AccessPolicyEntry
                {
                    TenantId = Guid.Parse(commonData.TenantId),
                    ObjectId = commonData.ClientObjectId,
                    Permissions = permissions ?? DefaultPermissions
                }
            };

            var properties = new VaultProperties
            {
                TenantId = Guid.Parse(commonData.TenantId),
                Sku = new Sku
                {
                    Name = sku
                },
                AccessPolicies = accessPolicies,
                EnabledForDeployment = enabledForDeployment,
                EnabledForDiskEncryption = enabledForDiskEncryption,
                EnabledForTemplateDeployment = enabledForTemplateDeployment,
                EnableSoftDelete = enableSoftDelete
            };

            var parameters = new VaultCreateOrUpdateParameters
            {
                Location = region,
                Properties = properties
            };

            return keyVaultManagementClient.Vaults.CreateOrUpdate(resourceGroupName, vaultName, parameters);
        }

        /// <summary>
        /// Set vault permissions to some resouce by its object id.
        /// </summary>
        /// <param name="vault"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="objectId"></param>
        /// <param name="permissions"></param>
        /// <returns></returns>
        public Vault SetVaultPermissions(Vault vault, string resourceGroupName, string objectId, Permissions permissions)
        {
            vault.Properties.AccessPolicies.Add(
                new AccessPolicyEntry
                {
                    TenantId = Guid.Parse(commonData.TenantId),
                    ObjectId = objectId,
                    Permissions = permissions
                }
            );

            var updateParams = new VaultCreateOrUpdateParameters
            {
                Location = vault.Location,
                Properties = vault.Properties
            };

            return keyVaultManagementClient.Vaults.CreateOrUpdate(resourceGroupName, vault.Name, updateParams);
        }

        /// <summary>
        /// Generate vault key
        /// </summary>
        /// <param name="vault"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public KeyIdentifier GenerateVaultKey(Vault vault, string keyName)
        {
            string vaultUri = vault.Properties.VaultUri;
            var attributes = new KeyAttributes();
            var createdKey = keyVaultClient.CreateKeyAsync(vaultUri, keyName, JsonWebKeyType.Rsa,
                    keyOps: JsonWebKeyOperation.AllOperations).GetAwaiter().GetResult();
            return new KeyIdentifier(createdKey.Key.Kid);
        }

        /// <summary>
        /// Remove a vault
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="vaultName"></param>
        public void DeleteVault(string resourceGroupName, string vaultName)
        {
            keyVaultManagementClient.Vaults.Delete(resourceGroupName, vaultName);
        }

        /// <summary>
        /// Purge a deleted vault
        /// </summary>
        /// <param name="vaultName"></param>
        /// <param name="location"></param>
        public void PurgeDeletedVault(string vaultName, string location)
        {
            keyVaultManagementClient.Vaults.PurgeDeleted(vaultName, location);
        }

        /// <summary>
        /// Add role assignment by role name
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="roleName"></param>
        /// <param name="assignmentName"></param>
        /// <param name="assigneePrincipalId"></param>
        public void AddRoleAssignment(string scope, string roleName, string assignmentName, string assigneePrincipalId)
        {
            var roleDefinition = authorizationManagementClient.RoleDefinitions
                .List(scope)
                .First(role => role.RoleName.StartsWith(roleName));

            var newRoleAssignment = new RoleAssignmentCreateParameters()
            {
                RoleDefinitionId = roleDefinition.Id,
                PrincipalId = assigneePrincipalId,
                CanDelegate = false
            };

            authorizationManagementClient.RoleAssignments.Create(scope, assignmentName, newRoleAssignment);
        }

        public VirtualNetwork CreateVirtualNetworkWithSubnet(string resourceGroupName, string location, string virtualNetworkName, string subnetName, bool subnetPrivateEndpointNetworkPoliciesFlag =true, bool subnetPrivateLinkServiceNetworkPoliciesFlag = true)
        {
            VirtualNetwork vnet = new VirtualNetwork()
            {
                Location = location,
                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = new List<string>()
                    {
                        "10.0.0.0/16",
                    }
                },
                Subnets = new List<Subnet>()
                {
                    new Subnet()
                    {
                        Name = subnetName,
                        AddressPrefix = "10.0.0.0/24",
                        PrivateEndpointNetworkPolicies = subnetPrivateEndpointNetworkPoliciesFlag ? "Enabled" : "Disabled",
                        PrivateLinkServiceNetworkPolicies =subnetPrivateLinkServiceNetworkPoliciesFlag ? "Enabled" : "Disabled"
                    }
                }
            };
            return networkManagementClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, virtualNetworkName, vnet);
        }

        /// <summary>
        /// Throw expception if the given condition is satisfied
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        private void ThrowIfTrue(bool condition, string message)
        {
            if (condition)
            {
                throw new Exception(message);
            }
        }
    }
}