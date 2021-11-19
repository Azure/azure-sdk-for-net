// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Create_Storage_Account
using System.Collections.Generic;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
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
Sku sku = new Sku(SkuName.PremiumLRS);
StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(new Sku(SkuName.StandardGRS), Kind.Storage, Location.WestUS);
parameters.Tags.Add("key1", "value1");
parameters.Tags.Add("key2", "value2");
StorageAccount account = storageAccountCollection.CreateOrUpdate(accountName, parameters).Value;
            #endregion
        }
    }
}
