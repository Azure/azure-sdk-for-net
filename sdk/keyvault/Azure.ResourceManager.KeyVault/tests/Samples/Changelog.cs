// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Changelog_NewCode
            using Azure.Identity;
            using Azure.ResourceManager.KeyVault;
            using Azure.ResourceManager.KeyVault.Models;
            using Azure.ResourceManager.Resources;
            using Azure.ResourceManager.Resources.Models;
            using System;
#if !SNIPPET
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.KeyVault.Tests.Samples
{
    internal class Changelog
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task NewCode()
        {
#endif
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync("myRgName");

            VaultCollection vaultCollection = resourceGroup.GetVaults();
            VaultCreateOrUpdateParameters parameters = new VaultCreateOrUpdateParameters(Location.WestUS2, new VaultProperties(Guid.NewGuid(), new Sku(SkuFamily.A, SkuName.Standard)));

            VaultCreateOrUpdateOperation lro = await vaultCollection.CreateOrUpdateAsync("myVaultName", parameters);
            Vault vault = lro.Value;
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void CreateModel()
        {
            #region Snippet:Changelog_CreateModel
            VaultProperties properties = new VaultProperties(Guid.NewGuid(), new Sku(SkuFamily.A, SkuName.Standard));
            VaultCreateOrUpdateParameters parameters = new VaultCreateOrUpdateParameters(Location.WestUS2, properties);
            #endregion
        }
    }
}
