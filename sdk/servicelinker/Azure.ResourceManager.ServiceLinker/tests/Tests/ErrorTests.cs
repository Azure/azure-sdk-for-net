// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.ResourceManager.KeyVault;
using Azure.ResourceManager.KeyVault.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ServiceLinker.Tests.Tests
{
    [TestFixture]
    public class ErrorTests : ServiceLinkerTestBase
    {
        public ErrorTests() : base(true)
        {
        }

        [SetUp]
        public async Task Init()
        {
            await InitializeClients();
        }

        [TestCase]
        public async Task ErrorTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("SdkRg");
            string vaultName = Recording.GenerateAssetName("SdkVault");
            string linkerName = Recording.GenerateAssetName("SdkLinker");

            // create resource group
            await ResourceGroups.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, new Resources.ResourceGroupData(DefaultLocation));
            ResourceGroupResource resourceGroup = await ResourceGroups.GetAsync(resourceGroupName);

            // create key vault
            KeyVaultCollection vaults = resourceGroup.GetKeyVaults();
            var vaultProperties = new KeyVaultProperties(new Guid(TestEnvironment.TenantId), new KeyVaultSku(KeyVaultSkuFamily.A, KeyVaultSkuName.Standard));
            vaultProperties.AccessPolicies.Clear();
            await vaults.CreateOrUpdateAsync(WaitUntil.Completed, vaultName, new KeyVaultCreateOrUpdateContent(DefaultLocation, vaultProperties));
            KeyVaultResource vault = await vaults.GetAsync(vaultName);

            // list linkers by key vault
            LinkerResourceCollection linkers = vault.GetLinkerResources();
            await foreach (LinkerResource linker0 in linkers.GetAllAsync())
            {
                Assert.Fail(); // key vault should not contain any linker
            }

            // get linker with 404
            try
            {
                LinkerResource linker1 = await linkers.GetAsync(linkerName);
                Assert.Fail(); // key vault should not contain this linker
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(404, e.Status);
            }
        }
    }
}
