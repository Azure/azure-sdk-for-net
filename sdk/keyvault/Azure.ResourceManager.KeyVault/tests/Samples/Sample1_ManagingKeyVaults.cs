// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#region Snippet:Manage_KeyVaults_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.KeyVault.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
#endregion Snippet:Manage_KeyVaults_Namespaces

namespace Azure.ResourceManager.KeyVault.Tests.Samples
{
    public class Sample1_ManagingKeyVaults
    {
        private ResourceGroup resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateOrUpdate()
        {
            #region Snippet:Managing_KeyVaults_CreateAVault
            VaultCollection vaultCollection = resourceGroup.GetVaults();

            string vaultName = "myVault";
            Guid tenantIdGuid = new Guid("Your tenantId");
            string objectId = "Your Object Id";
            Permissions permissions = new Permissions
            {
                Keys = { new KeyPermissions("all") },
                Secrets = { new SecretPermissions("all") },
                Certificates = { new CertificatePermissions("all") },
                Storage = { new StoragePermissions("all") },
            };
            AccessPolicyEntry AccessPolicy = new AccessPolicyEntry(tenantIdGuid, objectId, permissions);

            VaultProperties VaultProperties = new VaultProperties(tenantIdGuid, new Sku(SkuFamily.A, SkuName.Standard));
            VaultProperties.EnabledForDeployment = true;
            VaultProperties.EnabledForDiskEncryption = true;
            VaultProperties.EnabledForTemplateDeployment = true;
            VaultProperties.EnableSoftDelete = true;
            VaultProperties.VaultUri = "";
            VaultProperties.NetworkAcls = new NetworkRuleSet()
            {
                Bypass = "AzureServices",
                DefaultAction = "Allow",
                IpRules =
                {
                    new IPRule("1.2.3.4/32"),
                    new IPRule("1.0.0.0/25")
                }
            };
            VaultProperties.AccessPolicies.Add(AccessPolicy);

            VaultCreateOrUpdateParameters parameters = new VaultCreateOrUpdateParameters(Location.WestUS, VaultProperties);

            var rawVault = await vaultCollection.CreateOrUpdateAsync(vaultName, parameters).ConfigureAwait(false);
            Vault vault = await rawVault.WaitForCompletionAsync();
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_KeyVaults_ListAllVaults
            VaultCollection vaultCollection = resourceGroup.GetVaults();

            AsyncPageable<Vault> response = vaultCollection.GetAllAsync();
            await foreach (Vault vault in response)
            {
                Console.WriteLine(vault.Data.Name);
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Get()
        {
            #region Snippet:Managing_KeyVaults_GetAVault
            VaultCollection vaultCollection = resourceGroup.GetVaults();

            Vault vault = await vaultCollection.GetAsync("myVault");
            Console.WriteLine(vault.Data.Name);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetIfExists()
        {
            #region Snippet:Managing_KeyVaults_GetAVaultIfExists
            VaultCollection vaultCollection = resourceGroup.GetVaults();

            Vault vault = await vaultCollection.GetIfExistsAsync("foo");
            if (vault != null)
            {
                Console.WriteLine(vault.Data.Name);
            }

            if (await vaultCollection.CheckIfExistsAsync("bar"))
            {
                Console.WriteLine("KeyVault 'bar' exists.");
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Delete()
        {
            #region Snippet:Managing_KeyVaults_DeleteAVault
            VaultCollection vaultCollection = resourceGroup.GetVaults();

            Vault vault = await vaultCollection.GetAsync("myVault");
            await vault.DeleteAsync();
            #endregion
        }

        [SetUp]
        protected async Task initialize()
        {
            #region Snippet:Readme_DefaultSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            #endregion

            #region Snippet:Readme_GetResourceGroupCollection
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            // With the collection, we can create a new resource group with an specific name
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            ResourceGroup resourceGroup = await rgCollection.CreateOrUpdate(rgName, new ResourceGroupData(location)).WaitForCompletionAsync();
            #endregion

            this.resourceGroup = resourceGroup;
        }
    }
}
