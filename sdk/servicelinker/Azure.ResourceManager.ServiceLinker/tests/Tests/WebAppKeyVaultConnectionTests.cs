// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppService;
using Azure.ResourceManager.KeyVault;
using Azure.ResourceManager.KeyVault.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ServiceLinker.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ServiceLinker.Tests.Tests
{
    [TestFixture]
    public class WebAppKeyVaultConnectionTests : ServiceLinkerTestBase
    {
        public WebAppKeyVaultConnectionTests() : base(true)
        {
        }

        [SetUp]
        public async Task Init()
        {
            await InitializeUserTokenClients();
        }

        [TestCase]
        public async Task WebAppKeyVaultConnectionCRUD()
        {
            string resourceGroupName = Recording.GenerateAssetName("SdkRg");
            string webAppName = Recording.GenerateAssetName("SdkWeb");
            string vaultName = Recording.GenerateAssetName("SdkVault");
            string linkerName = Recording.GenerateAssetName("SdkLinker");

            // create resource group
            await ResourceGroups.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, new Resources.ResourceGroupData(DefaultLocation));
            ResourceGroupResource resourceGroup = await ResourceGroups.GetAsync(resourceGroupName);

            // create web app
            WebSiteCollection webSites = resourceGroup.GetWebSites();
            await webSites.CreateOrUpdateAsync(WaitUntil.Completed, webAppName, new WebSiteData(DefaultLocation));
            WebSiteResource webapp = await webSites.GetAsync(webAppName);

            // create key vault
            KeyVaultCollection vaults = resourceGroup.GetKeyVaults();
            var vaultProperties = new KeyVaultProperties(new Guid(TestEnvironment.TenantId), new KeyVaultSku(KeyVaultSkuFamily.A, KeyVaultSkuName.Standard));
            vaultProperties.AccessPolicies.Clear();
            await vaults.CreateOrUpdateAsync(WaitUntil.Completed, vaultName, new KeyVaultCreateOrUpdateContent(DefaultLocation, vaultProperties));
            KeyVaultResource vault = await vaults.GetAsync(vaultName);

            // create service linker
            LinkerResourceCollection linkers = webapp.GetLinkerResources();
            var linkerData = new LinkerResourceData
            {
                TargetService = new Models.AzureResourceInfo
                {
                    Id = vault.Id,
                },
                AuthInfo = new SystemAssignedIdentityAuthInfo(),
                ClientType = LinkerClientType.Dotnet,
            };
            await linkers.CreateOrUpdateAsync(WaitUntil.Completed, linkerName, linkerData);

            // list service linker
            var linkerResources = await linkers.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, linkerResources.Count);
            Assert.AreEqual(linkerName, linkerResources[0].Data.Name);

            // get service linker
            LinkerResource linker = await linkers.GetAsync(linkerName);
            Assert.IsTrue(linker.Id.ToString().StartsWith(webapp.Id.ToString(), StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(vault.Id, (linker.Data.TargetService as AzureResourceInfo).Id);
            Assert.AreEqual(LinkerAuthType.SystemAssignedIdentity, linker.Data.AuthInfo.AuthType);

            // get service linker configurations
            SourceConfigurationResult configurations = await linker.GetConfigurationsAsync();
            foreach (var configuration in configurations.Configurations)
            {
                Assert.IsNotNull(configuration.Name);
                Assert.IsNotNull(configuration.Value);
            }

            // delete service linker
            var operation = await linker.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(operation.HasCompleted);
        }
    }
}
