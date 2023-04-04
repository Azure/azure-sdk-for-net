// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.KeyVault;
using Azure.ResourceManager.KeyVault.Models;
using Azure.ResourceManager.ManagedServiceIdentities;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.PostgreSql.FlexibleServers;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;
using Azure.ResourceManager.PrivateDns;
using System.Linq;
using Azure.Security.KeyVault.Keys;
using System;
using Microsoft.Graph;

namespace Azure.ResourceManager.PostgreSql.Tests
{
    public class PostgreSqlManagementTestBase : ManagementRecordedTestBase<PostgreSqlManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected SubscriptionResource Subscription { get; private set; }

        protected PostgreSqlManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            CompareBodies = false;
        }

        protected PostgreSqlManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            CompareBodies = false;
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            Subscription = await Client.GetDefaultSubscriptionAsync();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        public async Task<ResourceGroupResource> GetResourceGroup(string name)
        {
            return (await Subscription.GetResourceGroups().GetAsync(name)).Value;
        }

        public async Task<(ResourceIdentifier Vnet, ResourceIdentifier Subnet)> CreateVirtualNetwork(string vnetName, string subnetName, string resourceGroupName, AzureLocation location)
        {
            var rg = await GetResourceGroup(resourceGroupName);

            var vnetCollection = rg.GetVirtualNetworks();
            var networkData = new VirtualNetworkData()
            {
                AddressPrefixes = { "10.0.0.0/16" },
                Location = location,
                Subnets = {
                    new SubnetData()
                    {
                        Name = subnetName,
                        AddressPrefix = "10.0.0.0/24",
                        PrivateEndpointNetworkPolicy = VirtualNetworkPrivateEndpointNetworkPolicy.Disabled,
                        Delegations = {
                            new ServiceDelegation()
                            {
                                Name = "Microsoft.DBforPostgreSQL/flexibleServers",
                                ServiceName = "Microsoft.DBforPostgreSQL/flexibleServers",
                            },
                        },
                        PrivateLinkServiceNetworkPolicy = VirtualNetworkPrivateLinkServiceNetworkPolicy.Enabled,
                    },
                },
            };
            ResourceIdentifier subnetID;
            ResourceIdentifier vnetID;
            if (Mode == RecordedTestMode.Playback)
            {
                vnetID = VirtualNetworkResource.CreateResourceIdentifier(rg.Id.SubscriptionId, rg.Id.Name, vnetName);
                subnetID = SubnetResource.CreateResourceIdentifier(rg.Id.SubscriptionId, rg.Id.Name, vnetName, subnetName);
            }
            else
            {
                using (Recording.DisableRecording())
                {
                    VirtualNetworkResource vnetResource = (await rg.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, networkData)).Value;
                    var subnetCollection = vnetResource.GetSubnets();
                    //SubnetResource subnetResource = (await subnetCollection.CreateOrUpdateAsync(WaitUntil.Completed, subnetName2, subnetData)).Value;
                    vnetID = vnetResource.Data.Id;
                    subnetID = vnetResource.Data.Subnets[0].Id;
                }
            };

            //var subnet = (await vnet.GetSubnetAsync(subnetName)).Value;

            return (vnetID, subnetID);
        }

        public async Task<PrivateDnsZoneResource> CreatePrivateDnsZone(string serverName, ResourceIdentifier vnetID, string resourceGroupName)
        {
            var rg = await GetResourceGroup(resourceGroupName);
            var tenants = Client.GetTenants().GetAllAsync();

            await foreach (var tenant in tenants)
            {
                var privateDnsZoneSuffixOperation = await tenant.ExecuteGetPrivateDnsZoneSuffixAsync();
                var privateDnsZoneSuffix = privateDnsZoneSuffixOperation.Value;
                var privateDnsZoneName = $"{serverName}.private.{privateDnsZoneSuffix}";

                var privateDnsZoneCollection = rg.GetPrivateDnsZones();
                var privateDnsZoneOperation = await privateDnsZoneCollection.CreateOrUpdateAsync(WaitUntil.Completed, privateDnsZoneName, new PrivateDnsZoneData("global"));
                var privateDnsZone = privateDnsZoneOperation.Value;

                var virtualLinkNetworkName = $"{vnetID.ToString()}-link";
                var virtualNetworkLinkCollection = privateDnsZone.GetVirtualNetworkLinks();
                var virtualLinkNetworkOperation = await virtualNetworkLinkCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualLinkNetworkName, new VirtualNetworkLinkData("global")
                {
                    RegistrationEnabled = false,
                    VirtualNetworkId = vnetID,
                });

                return privateDnsZone;
            }

            return null;
        }

        public async Task<(KeyVaultKey Key, UserAssignedIdentityResource Identity)> CreateKeyAndIdentity(string keyVaultName, string keyName, string identityName, string resourceGroupName)
        {
            var rg = await GetResourceGroup(resourceGroupName);
            var tenants = await Client.GetTenants().GetAllAsync().ToEnumerableAsync();
            var tenant = tenants.FirstOrDefault();
            var tenantId = tenant.Data.TenantId.Value;

            // Create keyvault
            KeyVaultResource keyVault = null;
            try
            {
                keyVault = await rg.GetKeyVaultAsync(keyVaultName);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                var keyVaultOperation = await rg.GetKeyVaults().CreateOrUpdateAsync(WaitUntil.Completed, keyVaultName, new KeyVaultCreateOrUpdateContent(rg.Data.Location, new KeyVaultProperties(tenantId, new KeyVaultSku(KeyVaultSkuFamily.A, KeyVaultSkuName.Standard))));
                keyVault = keyVaultOperation.Value;

                var keyVaultUpdateOperation = await keyVault.UpdateAsync(new KeyVaultPatch()
                {
                    Properties = new KeyVaultPatchProperties()
                    {
                        EnablePurgeProtection = true,
                        SoftDeleteRetentionInDays = 90,
                    },
                });
                keyVault = keyVaultUpdateOperation.Value;

                var graphClient = new GraphServiceClient(TestEnvironment.Credential);
                var servicePrincipals = await graphClient.ServicePrincipals
                    .Request()
                    .Filter($"servicePrincipalNames/any(c:c eq '{TestEnvironment.ClientId}')")
                    .Top(1)
                    .GetAsync();
                var servicePrincipal = servicePrincipals.FirstOrDefault();

                var keyAccessPolicies = new KeyVaultAccessPolicy[] {
                    new KeyVaultAccessPolicy(tenantId, servicePrincipal.Id, new IdentityAccessPermissions()
                    {
                        Keys = { IdentityAccessKeyPermission.All },
                    }),
                };
                await keyVault.UpdateAccessPolicyAsync(AccessPolicyUpdateKind.Add, new KeyVaultAccessPolicyParameters(new KeyVaultAccessPolicyProperties(keyAccessPolicies)));
            }

            // Create key
            var keyClient = new KeyClient(new Uri($"https://{keyVaultName}.vault.azure.net"), TestEnvironment.Credential);
            var key = (await keyClient.CreateRsaKeyAsync(new CreateRsaKeyOptions(keyName))).Value;

            // Create identity
            var identityOperation = await rg.GetUserAssignedIdentities().CreateOrUpdateAsync(WaitUntil.Completed, identityName, new UserAssignedIdentityData(rg.Data.Location));
            var identity = identityOperation.Value;

            // Set keyvault policy to identity
            var identityAccessPolicies = new KeyVaultAccessPolicy[] {
                new KeyVaultAccessPolicy(tenantId, identity.Data.PrincipalId.Value.ToString(), new IdentityAccessPermissions()
                {
                    Keys = { IdentityAccessKeyPermission.WrapKey, IdentityAccessKeyPermission.UnwrapKey, IdentityAccessKeyPermission.Get, IdentityAccessKeyPermission.List },
                }),
            };
            await keyVault.UpdateAccessPolicyAsync(AccessPolicyUpdateKind.Add, new KeyVaultAccessPolicyParameters(new KeyVaultAccessPolicyProperties(identityAccessPolicies)));

            return (key, identity);
        }
    }
}
