// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Managing_StorageAccounts_NameSpaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using Sku = Azure.ResourceManager.Storage.Models.Sku;
using Azure.Core;
#endregion

namespace Azure.ResourceManager.Storage.Tests.Samples
{
    public class ReadMe_ManagingStorageAccounts
    {
        private ResourceGroup resourceGroup;
        [SetUp]
        public async Task createResourceGroup()
        {
            #region Snippet:Managing_StorageAccounts_DefaultSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            #endregion
            #region Snippet:Managing_StorageAccounts_GetResourceGroupCollection
            string rgName = "myRgName";
            AzureLocation location = AzureLocation.WestUS2;
            ResourceGroupCreateOrUpdateOperation operation= await subscription.GetResourceGroups().CreateOrUpdateAsync(true, rgName, new ResourceGroupData(location));
            ResourceGroup resourceGroup = operation.Value;
            #endregion

            this.resourceGroup = resourceGroup;
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateOrUpdate()
        {
            #region Snippet:Managing_StorageAccounts_CreateStorageAccount
            //first we need to define the StorageAccountCreateParameters
            Sku sku = new Sku(SkuName.StandardGRS);
            Kind kind = Kind.Storage;
            string location = "westus2";
            StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku, kind, location);
            //now we can create a storage account with defined account name and parameters
            StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
            string accountName = "myAccount";
            StorageAccountCreateOrUpdateOperation accountCreateOperation = await accountCollection.CreateOrUpdateAsync(true, accountName, parameters);
            StorageAccount storageAccount = accountCreateOperation.Value;
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task list()
        {
            #region Snippet:Managing_StorageAccounts_ListStorageAccounts
            StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
            AsyncPageable<StorageAccount> response = accountCollection.GetAllAsync();
            await foreach (StorageAccount storageAccount in response)
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
            StorageAccount storageAccount = await accountCollection.GetAsync("myAccount");
            Console.WriteLine(storageAccount.Id.Name);
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetIfExist()
        {
            #region Snippet:Managing_StorageAccounts_GetStorageAccountIfExists
            StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
            StorageAccount storageAccount = await accountCollection.GetIfExistsAsync("foo");
            if (storageAccount != null)
            {
                Console.WriteLine(storageAccount.Id.Name);
            }
            if (await accountCollection.ExistsAsync("bar"))
            {
                Console.WriteLine("storage account 'bar' exists");
            }
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Delete()
        {
            #region Snippet:Managing_StorageAccounts_DeleteStorageAccount
            StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
            StorageAccount storageAccount = await accountCollection.GetAsync("myAccount");
            await storageAccount.DeleteAsync(true);
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task AddTag()
        {
            #region Snippet:Managing_StorageAccounts_AddTagStorageAccount
            StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
            StorageAccount storageAccount = await accountCollection.GetAsync("myAccount");
            // add a tag on this storage account
            await storageAccount.AddTagAsync("key", "value");
            #endregion
        }
    }
}
