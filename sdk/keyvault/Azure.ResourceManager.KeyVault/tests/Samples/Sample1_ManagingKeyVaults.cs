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
            VaultContainer vaultContainer = resourceGroup.GetVaults();

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

            var rawVault = await vaultContainer.CreateOrUpdateAsync(vaultName, parameters).ConfigureAwait(false);
            Vault vault = await rawVault.WaitForCompletionAsync();
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_KeyVaults_ListAllVaults
            VaultContainer vaultContainer = resourceGroup.GetVaults();

            AsyncPageable<Vault> response = vaultContainer.GetAllAsync();
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
            VaultContainer vaultContainer = resourceGroup.GetVaults();

            Vault vault = await vaultContainer.GetAsync("myVault");
            Console.WriteLine(vault.Data.Name);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetIfExists()
        {
            #region Snippet:Managing_KeyVaults_GetAVaultIfExists
            VaultContainer vaultContainer = resourceGroup.GetVaults();

            Vault vault = await vaultContainer.GetIfExistsAsync("foo");
            if (vault != null)
            {
                Console.WriteLine(vault.Data.Name);
            }

            if (await vaultContainer.CheckIfExistsAsync("bar"))
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
            VaultContainer vaultContainer = resourceGroup.GetVaults();

            Vault vault = await vaultContainer.GetAsync("myVault");
            await vault.DeleteAsync();
            #endregion
        }

        [SetUp]
        protected async Task initialize()
        {
            #region Snippet:Readme_DefaultSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.DefaultSubscription;
            #endregion

            #region Snippet:Readme_GetResourceGroupContainer
            ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
            // With the container, we can create a new resource group with an specific name
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            ResourceGroup resourceGroup = await rgContainer.CreateOrUpdate(rgName, new ResourceGroupData(location)).WaitForCompletionAsync();
            #endregion

            this.resourceGroup = resourceGroup;
        }
    }
}
