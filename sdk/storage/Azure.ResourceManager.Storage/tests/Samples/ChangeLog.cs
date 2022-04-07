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
ResourceGroup resourceGroup = client.GetDefaultSubscription().GetResourceGroups().Get(resourceGroupName);
StorageAccountCollection storageAccountCollection = resourceGroup.GetStorageAccounts();
StorageSku sku = new StorageSku(StorageSkuName.PremiumLRS);
StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(new StorageSku(StorageSkuName.StandardGRS), StorageKind.Storage, AzureLocation.WestUS);
parameters.Tags.Add("key1", "value1");
parameters.Tags.Add("key2", "value2");
StorageAccount account = storageAccountCollection.CreateOrUpdate(WaitUntil.Completed, accountName, parameters).Value;
            #endregion
        }
    }
}
