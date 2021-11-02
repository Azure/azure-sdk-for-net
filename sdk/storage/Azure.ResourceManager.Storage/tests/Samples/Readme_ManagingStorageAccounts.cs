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
            Subscription subscription = armClient.DefaultSubscription;
            #endregion
            #region Snippet:Managing_StorageAccounts_GetResourceGroupContainer
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            ResourceGroupCreateOrUpdateOperation operation= await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
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
            StorageAccountContainer accountContainer = resourceGroup.GetStorageAccounts();
            string accountName = "myAccount";
            StorageAccountCreateOperation accountCreateOperation = await accountContainer.CreateOrUpdateAsync(accountName, parameters);
            StorageAccount storageAccount = accountCreateOperation.Value;
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task list()
        {
            #region Snippet:Managing_StorageAccounts_ListStorageAccounts
            StorageAccountContainer accountContainer = resourceGroup.GetStorageAccounts();
            AsyncPageable<StorageAccount> response = accountContainer.GetAllAsync();
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
            StorageAccountContainer accountContainer = resourceGroup.GetStorageAccounts();
            StorageAccount storageAccount = await accountContainer.GetAsync("myAccount");
            Console.WriteLine(storageAccount.Id.Name);
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetIfExist()
        {
            #region Snippet:Managing_StorageAccounts_GetStorageAccountIfExists
            StorageAccountContainer accountContainer = resourceGroup.GetStorageAccounts();
            StorageAccount storageAccount = await accountContainer.GetIfExistsAsync("foo");
            if (storageAccount != null)
            {
                Console.WriteLine(storageAccount.Id.Name);
            }
            if (await accountContainer.CheckIfExistsAsync("bar"))
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
            StorageAccountContainer accountContainer = resourceGroup.GetStorageAccounts();
            StorageAccount storageAccount = await accountContainer.GetAsync("myAccount");
            await storageAccount.DeleteAsync();
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task AddTag()
        {
            #region Snippet:Managing_StorageAccounts_AddTagStorageAccount
            StorageAccountContainer accountContainer = resourceGroup.GetStorageAccounts();
            StorageAccount storageAccount = await accountContainer.GetAsync("myAccount");
            // add a tag on this storage account
            await storageAccount.AddTagAsync("key", "value");
            #endregion
        }
    }
}
