// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Managing_StorageAccounts_NameSpaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.Core;
#endregion

namespace Azure.ResourceManager.Storage.Tests.Samples
{
    public class Sample1_ManagingStorageAccounts
    {
        private ResourceGroupResource resourceGroup;
        private StorageAccountResource storageAccount;
        [SetUp]
        public async Task createResourceGroup()
        {
            #region Snippet:Managing_StorageAccounts_DefaultSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            #endregion
            #region Snippet:Managing_StorageAccounts_GetResourceGroupCollection
            string rgName = "myRgName";
            AzureLocation location = AzureLocation.WestUS2;
            ArmOperation<ResourceGroupResource> operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
            ResourceGroupResource resourceGroup = operation.Value;
            #endregion

            this.resourceGroup = resourceGroup;
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateOrUpdate()
        {
            #region Snippet:Managing_StorageAccounts_CreateStorageAccount
            //first we need to define the StorageAccountCreateParameters
            StorageSku sku = new StorageSku(StorageSkuName.StandardGrs);
            StorageKind kind = StorageKind.Storage;
            string location = "westus2";
            StorageAccountCreateOrUpdateContent parameters = new StorageAccountCreateOrUpdateContent(sku, kind, location);
            //now we can create a storage account with defined account name and parameters
            StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
            string accountName = "myAccount";
            ArmOperation<StorageAccountResource> accountCreateOperation = await accountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters);
            StorageAccountResource storageAccount = accountCreateOperation.Value;
            #endregion

            this.storageAccount = storageAccount;
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetKeys()
        {
            #region Snippet:Managing_StorageAccounts_GetKeys
            await foreach (StorageAccountKey key in storageAccount.GetKeysAsync())
            {
                Console.WriteLine(key.Value);
            }
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_StorageAccounts_ListStorageAccounts
            StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
            AsyncPageable<StorageAccountResource> response = accountCollection.GetAllAsync();
            await foreach (StorageAccountResource storageAccount in response)
            {
                Console.WriteLine(storageAccount.Id.Name);
            }
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Get()
        {
            #region Snippet:Managing_StorageAccounts_GetStorageAccount
            StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
            StorageAccountResource storageAccount = await accountCollection.GetAsync("myAccount");
            Console.WriteLine(storageAccount.Id.Name);
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Delete()
        {
            #region Snippet:Managing_StorageAccounts_DeleteStorageAccount
            StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
            StorageAccountResource storageAccount = await accountCollection.GetAsync("myAccount");
            await storageAccount.DeleteAsync(WaitUntil.Completed);
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task AddTag()
        {
            #region Snippet:Managing_StorageAccounts_AddTagStorageAccount
            StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
            StorageAccountResource storageAccount = await accountCollection.GetAsync("myAccount");
            // add a tag on this storage account
            await storageAccount.AddTagAsync("key", "value");
            #endregion
        }
    }
}
