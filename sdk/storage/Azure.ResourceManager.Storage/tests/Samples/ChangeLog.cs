// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Create_Storage_Account
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage.Models;
#if !SNIPPET
using NUnit.Framework;

namespace Azure.ResourceManager.Storage.Tests.Samples
{
    internal class ChangeLog
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void CreateStorageAccount()
        {
#endif
string accountName = "myaccount";
string resourceGroupName = "myResourceGroup";
ArmClient client = new ArmClient(new DefaultAzureCredential());
ResourceGroupResource resourceGroup = client.GetDefaultSubscription().GetResourceGroups().Get(resourceGroupName);
StorageAccountCollection storageAccountCollection = resourceGroup.GetStorageAccounts();
StorageSku sku = new StorageSku(StorageSkuName.PremiumLrs);
StorageAccountCreateOrUpdateContent parameters = new StorageAccountCreateOrUpdateContent(sku, StorageKind.Storage, AzureLocation.WestUS)
{
    Tags =
    {
        ["key1"] = "value1",
        ["key2"] = "value2"
    }
};
StorageAccountResource account = storageAccountCollection.CreateOrUpdate(WaitUntil.Completed, accountName, parameters).Value;
            #endregion
        }
    }
}
