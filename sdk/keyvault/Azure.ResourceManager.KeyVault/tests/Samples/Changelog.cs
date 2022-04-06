// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Changelog_Namespaces
using System;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.KeyVault;
using Azure.ResourceManager.KeyVault.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
#endregion

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
            #region Snippet:Changelog_NewCode
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync("myRgName");

            VaultCollection vaultCollection = resourceGroup.GetVaults();
            VaultCreateOrUpdateContent parameters = new VaultCreateOrUpdateContent(AzureLocation.WestUS2, new VaultProperties(Guid.NewGuid(), new KeyVaultSku(KeyVaultSkuFamily.A, KeyVaultSkuName.Standard)));

            ArmOperation<VaultResource> lro = await vaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, "myVaultName", parameters);
            VaultResource vault = lro.Value;
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void CreateModel()
        {
            #region Snippet:Changelog_CreateModel
            VaultProperties properties = new VaultProperties(Guid.NewGuid(), new KeyVaultSku(KeyVaultSkuFamily.A, KeyVaultSkuName.Standard));
            VaultCreateOrUpdateContent parameters = new VaultCreateOrUpdateContent(AzureLocation.WestUS2, properties);
            #endregion
        }
    }
}
